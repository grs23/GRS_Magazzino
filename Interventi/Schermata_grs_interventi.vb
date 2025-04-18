﻿Public Class Schermata_grs_interventi
    Public fp As Form
    Private conn As MySqlConnection = GetConnDb()

    Public rigoTestata As DataRow = Nothing
    Public dtCorpo As New DataTable

    Public Const tipo_cliente As String = "C"

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.WParam.ToInt64 = &HF060 Then
            AutoValidate = False
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles Me.Load
        InizializzaForm.Init(Me, fp)

        CampiTrimSpazi(TxtDescClie, TxtDescLavo)
        CampiNumerici(TxtAnnoInte, TxtNumeInte, TxtPrezVend, TxtCostInte)
        CampiInteri(4, TxtAnnoInte)
        CampiInteri(5, TxtNumeInte)
        CampiDecimali(11, 2, TxtPrezVend, TxtPrezVend)
        Field.Data(TxtInizInte, TxtFineInte)

        Field.ScrollingContextMenu(True, True, True, DgvCorpo)

        SettaVariabili()
    End Sub

    Private Sub TxtNumeInte_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtNumeInte.PreviewKeyDown
        If My.Computer.Keyboard.ShiftKeyDown = False AndAlso e.KeyCode = Keys.Tab Then
            If TxtNumeInte.Text = "" Then
                TxtNumeInte.Text = "0"
            End If

            If TxtAnnoInte.Text.Length <> 4 Then
                MessageBox.Show("Anno non valido.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                SegnalaErrori(TxtAnnoInte)
                ActiveControl = TxtAnnoInte
            Else
                Carica()
            End If
        End If
    End Sub

    Private Sub TxtDescClie_Validating(sender As Object, e As CancelEventArgs) Handles TxtDescClie.Validating
        If TxtDescClie.Text.Trim <> "" Then
            TxtDescClie.Text = RicercaCampo(conn, TxtDescClie.Text.Trim, TabelleDatabase.tb_anagrafica, "ragi_socia",,, " AND tipo_anagr = '" & tipo_cliente & "'")

            If New Query().CaricaRigoAnagrafica(conn, tipo_cliente, TxtDescClie.Text.Trim) Is Nothing Then
                e.Cancel = True
                MessageBox.Show("Cliente non trovato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                SegnalaErrori(TxtDescClie)
            End If
        End If
    End Sub

    Private Sub DvgCorpo_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCorpo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If My.Computer.Keyboard.ShiftKeyDown = False Then
                If DgvCorpo.CurrentRow IsNot Nothing Then
                    e.SuppressKeyPress = True
                    Modi(DgvCorpo.CurrentRow.DataBoundItem.row)
                End If
            End If
        ElseIf e.KeyCode = Keys.Insert Then
            e.SuppressKeyPress = True
            Modi()
        ElseIf e.KeyCode = Keys.Delete Then
            If DgvCorpo.CurrentRow IsNot Nothing Then
                e.SuppressKeyPress = True
                DgvCorpo.CurrentRow.DataBoundItem.row("cancellato") = Not DgvCorpo.CurrentRow.DataBoundItem.row("cancellato")
            End If
        End If
    End Sub

    Private Sub Modi(Optional rowAppo As DataRow = Nothing)
        If CheckFormAperto(Schermata_grs_interventi_Modi, My.Application.OpenForms) = False Then
            Schermata_grs_interventi_Modi.fp = Me

            If rowAppo IsNot Nothing Then
                Schermata_grs_interventi_Modi.rowCorpo = rowAppo
            Else
                Schermata_grs_interventi_Modi.rowCorpo = dtCorpo.NewRow
                Schermata_grs_interventi_Modi.rowCorpo("cancellato") = False
            End If

            Schermata_grs_interventi_Modi.Show()
        Else
            MessageBox.Show("E' gia in corso una variazione.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub Asse(Optional rowAppo As DataRow = Nothing)
        rowAppo("anno_inter") = TxtAnnoInte.Text

        If TxtNumeInte.Text = "0" Then
            rowAppo("nume_inter") = rigoTestata("nume_inter")
        Else
            rowAppo("nume_inter") = New Query().CalcolaProgressivoInterventiAnnuale(conn, rowAppo("anno_inter"))
        End If

        If TxtInizInte.Text.Length = 10 AndAlso IsDate(TxtInizInte.Text) Then
            rowAppo("iniz_inter") = Date.Parse(TxtInizInte.Text)
        End If

        If TxtFineInte.Text.Length = 10 AndAlso IsDate(TxtFineInte.Text) Then
            rowAppo("fine_inter") = Date.Parse(TxtFineInte.Text)
        End If
        rowAppo("desc_clien") = TxtDescClie.Text
        rowAppo("desc_lavor") = TxtDescLavo.Text

        rowAppo("cost_inter") = TxtCostInte.Text

        If dtCorpo.Rows.Count > 0 AndAlso dtCorpo.AsEnumerable().Any(Function(x) x("cancellato") = False) Then
            rowAppo("prez_vendi") = dtCorpo.AsEnumerable.
                                            Where(Function(x) x("cancellato") = False).
                                            Sum(Function(x) (x("quantita") * x("prez_unita")))
        Else
            rowAppo("prez_vendi") = "0"
        End If
    End Sub

    Private Sub AsseDett(Optional rowAppo As DataRow = Nothing)
        rowAppo("anno_inter") = rigoTestata("anno_inter")
        rowAppo("nume_inter") = rigoTestata("nume_inter")
    End Sub

    Private Sub BtnSalva_Click(sender As Object, e As EventArgs) Handles BtnSalva.Click
        Try
            conn.Open()
            Asse(rigoTestata)

            AggiornaInterventoTestata(rigoTestata, conn)

            For Each rigoDettaglio As DataRow In dtCorpo.Rows
                AsseDett(rigoDettaglio)
                AggiornaInterventoDettaglio(rigoDettaglio, conn)
            Next

            SettaVariabili()
        Catch ex As Exception
            MessageBox.Show("Errore: " & ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub BtnNuovo_Click(sender As Object, e As EventArgs) Handles BtnNuovo.Click
        SettaVariabili()
    End Sub

    Private Sub BtnCancella_Click(sender As Object, e As EventArgs) Handles BtnCancella.Click
        Try
            conn.Open()
            If Service.CancRigo(TabelleDatabase.tb_intervento_testata, DgvCorpo.CurrentRow.DataBoundItem.row("id"), conn, True) Then
                For Each rigoDettaglio As DataRow In dtCorpo.Rows
                    Service.CancRigo(TabelleDatabase.tb_intervento_dettaglio, DgvCorpo.CurrentRow.DataBoundItem.row("id"), conn, False)
                Next

                SettaVariabili()
            End If
        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub BtnEsci_Click(sender As Object, e As EventArgs) Handles BtnEsci.Click
        Close()
    End Sub

    Private Function Carica() As Boolean
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                If TxtNumeInte.Text = 0 Then
                    rigoTestata = PrendiStrutturaTabella(conn, TabelleDatabase.tb_intervento_testata).NewRow
                    AzzeraRigo(rigoTestata)

                    dtCorpo = PrendiStrutturaTabella(conn, TabelleDatabase.tb_intervento_dettaglio)
                Else
                    rigoTestata = New Query().CaricaRigoInterventoTestata(conn, TxtAnnoInte.Text, TxtNumeInte.Text)
                    If rigoTestata Is Nothing Then
                        MessageBox.Show("Intervento non trovato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        SegnalaErrori(TxtAnnoInte, TxtNumeInte)
                        ActiveControl = TxtAnnoInte

                        Return False
                    Else
                        dtCorpo = New Query().CaricaInterventiDettagliLista(conn, TxtAnnoInte.Text, TxtNumeInte.Text)
                    End If
                End If

                DgvCorpo.DataSource = dtCorpo
                DgvCorpo.AutoGenerateColumns = False

                PnlDati.Enabled = True
                PnlCorpo.Enabled = True

                BtnSalva.Enabled = True
                BtnNuovo.Enabled = True
                BtnCancella.Enabled = True

                PnlTestata.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error while connecting to Server. " & ex.Message)
            Return False
        Finally
            conn.Close()
        End Try
        Return True
    End Function


    Private Sub SwitchEsc()
        If ActiveControl Is TxtAnnoInte OrElse ActiveControl Is TxtNumeInte Then
            Close()
        ElseIf ActiveControl Is DgvCorpo Then
            ActiveControl = BtnSalva
        ElseIf BtnSalva.Enabled Then
            ActiveControl = BtnSalva
        Else
            ActiveControl = BtnEsci
        End If
    End Sub

    Private Sub SettaVariabili()
        TxtAnnoInte.Text = Date.Now.Year
        TxtNumeInte.Text = "0"

        TxtInizInte.Text = Date.Now
        TxtFineInte.Text = ""

        TxtDescClie.Text = ""
        TxtDescLavo.Text = ""

        TxtPrezVend.Text = "0"
        TxtCostInte.Text = "0"

        rigoTestata = Nothing
        dtCorpo = New DataTable

        DgvCorpo.DataSource = dtCorpo
        DgvCorpo.AutoGenerateColumns = False

        PnlTestata.Enabled = False
        PnlDati.Enabled = False
        PnlCorpo.Enabled = False

        BtnSalva.Enabled = False
        BtnNuovo.Enabled = False
        BtnCancella.Enabled = False
    End Sub


    'etichetta
    Public Sub InfoCamp()
        Tsstabella.Text = TltTabella.GetToolTip(ActiveControl)
    End Sub
End Class