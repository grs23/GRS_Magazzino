Public Class Schermata_grs_interventi
    Public fp As Form
    Private conn As MySqlConnection = GetConnDb()

    Public rigoTestata As DataRow = Nothing
    Public dtCorpo As New DataTable

    Public rigoRiepilogo As DataRow = Nothing

    Public Const tipo_cliente As String = "C"

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.WParam.ToInt64 = &HF060 Then
            AutoValidate = False
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles Me.Load
        InizializzaForm.Init(Me, fp)
        ImpostaTema(Me)
        CampiTrimSpazi(TxtDescClie, TxtDescLavo)
        CampiNumerici(TxtAnnoInte, TxtNumeInte, TxtPrezVend, TxtCostInte)
        CampiInteri(4, TxtAnnoInte)
        CampiInteri(5, TxtNumeInte)
        CampiDecimali(11, 2, TxtPrezVend, TxtPrezVend)
        Field.Data(TxtInizInte, TxtFineInte)

        Field.ScrollingContextMenu(True, True, True, DgvCorpo)
        disabilita()

        If rigoRiepilogo Is Nothing Then
            SettaVariabili()
        Else
            TxtAnnoInte.Text = rigoRiepilogo("anno_inter")
            TxtNumeInte.Text = rigoRiepilogo("nume_inter")

            Carica()
        End If
    End Sub

    Private Sub TxtNumeInte_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtNumeInte.PreviewKeyDown
        If My.Computer.Keyboard.ShiftKeyDown = False AndAlso e.KeyCode = Keys.Tab Then
            e.IsInputKey = True
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

            If New GRSLib.Query.magazzino().CaricaRigoAnagrafica(conn, tipo_cliente, TxtDescClie.Text.Trim) Is Nothing Then
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
                    TrasfDati(DgvCorpo.CurrentRow.DataBoundItem.row)
                End If
            End If
        ElseIf e.KeyCode = Keys.Insert Then
            e.SuppressKeyPress = True
            TrasfDati()
        ElseIf e.KeyCode = Keys.Delete Then
            If DgvCorpo.CurrentRow IsNot Nothing Then
                e.SuppressKeyPress = True
                DgvCorpo.CurrentRow.DataBoundItem.row("cancellato") = Not DgvCorpo.CurrentRow.DataBoundItem.row("cancellato")

                If dtCorpo.Rows.Count > 0 AndAlso dtCorpo.AsEnumerable().Any(Function(x) x("cancellato") = False) Then
                    TxtCostInte.Text = dtCorpo.AsEnumerable.
                                                    Where(Function(x) x("cancellato") = False).
                                                    Sum(Function(x) (x("quantita") * x("prez_unita")))
                Else
                    TxtCostInte.Text = "0"
                End If
            End If
        End If
    End Sub

    Private Sub TrasfDati(Optional rowAppo As DataRow = Nothing)
        If CheckFormAperto(Schermata_grs_interventi_Modi, My.Application.OpenForms) = False Then
            Schermata_grs_interventi_Modi.fp = Me

            If rowAppo IsNot Nothing Then
                Schermata_grs_interventi_Modi.rowCorpo = rowAppo
            Else
                Schermata_grs_interventi_Modi.rowCorpo = dtCorpo.NewRow
                AzzeraRigo(Schermata_grs_interventi_Modi.rowCorpo)
            End If

            Schermata_grs_interventi_Modi.Show()
        Else
            MessageBox.Show("E' gia in corso una variazione.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub Asse(rowAppo As DataRow)
        TxtAnnoInte.Text = rowAppo("anno_inter")

        rigoTestata("nume_inter") = rowAppo("nume_inter")

        If IsDate(rowAppo("iniz_inter")) Then
            TxtInizInte.Text = rowAppo("iniz_inter")
        End If

        If IsDate(rowAppo("fine_inter")) Then
            TxtFineInte.Text = rowAppo("fine_inter")
        End If
        TxtDescClie.Text = rowAppo("desc_clien")
        TxtDescLavo.Text = rowAppo("desc_lavor")

        TxtCostInte.Text = rowAppo("cost_inter")
        TxtPrezVend.Text = rowAppo("prez_vendi")
    End Sub

    Private Sub Modi(Optional rowAppo As DataRow = Nothing)
        rowAppo("anno_inter") = TxtAnnoInte.Text

        If TxtNumeInte.Text = "0" Then
            rowAppo("nume_inter") = New Query().CalcolaProgressivoInterventiAnnuale(conn, rowAppo("anno_inter"))
        Else
            rowAppo("nume_inter") = rigoTestata("nume_inter")
        End If

        If TxtInizInte.Text.Length = 10 AndAlso IsDate(TxtInizInte.Text) Then
            rowAppo("iniz_inter") = Date.Parse(TxtInizInte.Text)
        End If

        If TxtFineInte.Text.Length = 10 AndAlso IsDate(TxtFineInte.Text) Then
            rowAppo("fine_inter") = Date.Parse(TxtFineInte.Text)
        End If
        rowAppo("desc_clien") = TxtDescClie.Text
        rowAppo("desc_lavor") = TxtDescLavo.Text

        rowAppo("prez_vendi") = TxtPrezVend.Text

        If dtCorpo.Rows.Count > 0 AndAlso dtCorpo.AsEnumerable().Any(Function(x) x("cancellato") = False) Then
            rowAppo("cost_inter") = dtCorpo.AsEnumerable.
                                            Where(Function(x) x("cancellato") = False).
                                            Sum(Function(x) (x("quantita") * x("prez_unita")))
        Else
            rowAppo("cost_inter") = "0"
        End If
    End Sub

    Private Sub AsseDett(Optional rowAppo As DataRow = Nothing)
        rowAppo("anno_inter") = rigoTestata("anno_inter")
        rowAppo("nume_inter") = rigoTestata("nume_inter")
    End Sub

    Private Sub BtnSalva_Click(sender As Object, e As EventArgs) Handles BtnSalva.Click
        Try
            conn.Open()
            Modi(rigoTestata)

            AggiornaInterventoTestata(rigoTestata, conn)

            For Each rigoDettaglio As DataRow In dtCorpo.Rows
                AsseDett(rigoDettaglio)
                AggiornaInterventoDettaglio(rigoDettaglio, conn)
            Next

            If rigoRiepilogo IsNot Nothing Then
                For Each col As DataColumn In rigoRiepilogo.Table.Columns
                    If rigoTestata.Table.Columns.Contains(col.ColumnName) Then
                        rigoRiepilogo(col.ColumnName) = rigoTestata(col.ColumnName)
                    End If
                Next

                If rigoRiepilogo.RowState = DataRowState.Detached Then
                    rigoRiepilogo.Table.Rows.Add(rigoRiepilogo)
                End If

                rigoRiepilogo.AcceptChanges()
            End If

            If TypeOf fp Is MenuGRS Then
                BtnNuovo.PerformClick()
            Else
                If TypeOf fp Is Schermata_grs_riepilogo_interventi Then
                    'Schermata_grs_riepilogo_interventi.Carica()

                    'Dim rigaTrovata = (From r In rigoRiepilogo.Table.AsEnumerable()
                    '                   Where r.Field(Of String)("id") = rigoRiepilogo("id")
                    '                   Select r).FirstOrDefault()

                    'If rigaTrovata IsNot Nothing Then
                    If rigoRiepilogo IsNot Nothing Then
                        ' Trova l'indice della riga nel DataTable
                        Dim indice As Integer = rigoRiepilogo.Table.Rows.IndexOf(rigoRiepilogo)

                        ' Posizionati e seleziona la riga nel DataGridView
                        Schermata_grs_riepilogo_interventi.DgvCorpo.ClearSelection()
                        Schermata_grs_riepilogo_interventi.DgvCorpo.Rows(indice).Selected = True
                        Schermata_grs_riepilogo_interventi.DgvCorpo.FirstDisplayedScrollingRowIndex = indice
                    End If
                End If

                BtnEsci.PerformClick()
            End If
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
            If Service.CancRigo(TabelleDatabase.tb_intervento_testata, rigoTestata("id"), conn, True) Then
                For Each rigoDettaglio As DataRow In dtCorpo.Rows
                    Service.CancRigo(TabelleDatabase.tb_intervento_dettaglio, DgvCorpo.CurrentRow.DataBoundItem.row("id"), conn, False)
                Next

                If TypeOf fp Is MenuGRS Then
                    BtnNuovo.PerformClick()
                Else
                    BtnEsci.PerformClick()
                End If
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
                        Asse(rigoTestata)
                    End If
                End If

                DgvCorpo.DataSource = dtCorpo
                DgvCorpo.AutoGenerateColumns = False

                abilita(PnlDati, PnlCorpo, PnlPiede)
                disabilita(PnlTestata)

                ActiveControl = TxtDescClie
            End If
        Catch ex As Exception
            MessageBox.Show("Error while connecting to Server. " & ex.Message)
            Return False
        Finally
            conn.Close()
        End Try
        Return True
    End Function

    Public Sub F6()
        Dim rowF6 As DataRow = Nothing
        If ActiveControl Is TxtDescClie Then
            rowF6 = QueryF6.Anagrafica_Clienti(Me, TxtDescClie, conn)
            If rowF6 IsNot Nothing Then
                TxtDescClie.Text = rowF6("ragi_socia")
            End If
        End If
    End Sub


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
        abilita(PnlTestata)
        disabilita(PnlCorpo, PnlDati, PnlPiede)
        BtnEsci.Enabled = True
        ActiveControl = TxtAnnoInte
    End Sub

    'cellformatting
    Private Sub DgvCorpo_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvCorpo.CellFormatting
        If dtCorpo.Rows.Count > 0 Then
            If e.RowIndex >= 0 AndAlso e.RowIndex <= dtCorpo.Rows.Count - 1 Then
                If DgvCorpo.Rows(e.RowIndex).DataBoundItem.row("cancellato") = True Then
                    DgvCorpo.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                    DgvCorpo.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Gray
                Else
                    DgvCorpo.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
                    DgvCorpo.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Empty
                End If
            End If
        End If
    End Sub


    'etichetta
    Public Sub InfoCamp()
        Tsstabella.Text = TltTabella.GetToolTip(ActiveControl)
    End Sub
End Class