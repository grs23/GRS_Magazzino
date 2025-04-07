Public Class Schermata_grs_interventi_Modi
    Public fp As Form = Nothing
    Private conn As MySqlConnection = GetConnDb()

    Public rowCorpo As DataRow = Nothing

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.WParam.ToInt64 = &HF060 Then
            AutoValidate = False
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Schermata_grs_anagrafica_Modi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InizializzaForm.Init(Me, fp, True)

        CampiTrimSpazi(TxtDescArti)
        CampiNumerici(TxtPrezUnit, TxtQuantita)
        CampiInteri(5, TxtQuantita)
        CampiDecimali(11, 2, TxtPrezUnit)

        Asse(rowCorpo)
    End Sub

    Private Sub TxtDescArti_Validating(sender As Object, e As CancelEventArgs) Handles TxtDescArti.Validating
        If TxtDescArti.Text.Trim <> "" Then
            TxtDescArti.Text = RicercaCampo(conn, TxtDescArti.Text.Trim, TabelleDatabase.tb_articoli, "desc_artic")

            If New Query().CaricaRigoInventario(conn, TxtDescArti.Text.Trim) Is Nothing Then
                e.Cancel = True
                MessageBox.Show("Articolo non trovato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                SegnalaErrori(TxtDescArti)
            Else
                Dim dw = New DataView(CType(fp, Schermata_grs_interventi).dtCorpo, "desc_artic = '" & TxtDescArti.Text.Trim.Replace("'", "''") & "'",
                                            "desc_artic ASC", DataViewRowState.CurrentRows)

                If dw.Count > 0 AndAlso rowCorpo IsNot dw(0).Row Then
                    MessageBox.Show("L'articolo " & TxtDescArti.Text & " è già presente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    'asse
    Private Sub Asse(ByVal row As DataRow)
        TxtDescArti.Text = row("desc_artic")
        TxtQuantita.Text = row("quant_artic")
        TxtPrezUnit.Text = row("prez_unita")
    End Sub

    Private Sub Modi(ByRef row As DataRow)
        row("desc_artic") = TxtDescArti.Text
        row("quantita") = TxtQuantita.Text
        row("prez_unita") = TxtPrezUnit.Text
    End Sub

    Private Function VeriCamp() As Boolean
        If TxtDescArti.Text.Trim = "" Then
            MessageBox.Show("Descrizione articolo obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescArti)
            ActiveControl = TxtDescArti
            Return False
        ElseIf TxtQuantita.Text.Trim = "" OrElse TxtQuantita.Text = 0 Then
            MessageBox.Show("Quantità articolo obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtQuantita)
            ActiveControl = TxtQuantita
            Return False
        ElseIf TxtPrezUnit.Text.Trim = "" Then
            MessageBox.Show("Prezzo unitario articolo obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtPrezUnit)
            ActiveControl = TxtPrezUnit
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub BtnSalva_Click(sender As Object, e As EventArgs) Handles BtnSalva.Click
        If VeriCamp() Then

            Modi(rowCorpo)

            If rowCorpo.RowState = DataRowState.Detached Then
                If TypeOf fp Is Schermata_grs_interventi Then
                    CType(fp, Schermata_grs_interventi).dtCorpo.Rows.Add(rowCorpo, conn)
                End If
            End If
            BtnEsci.PerformClick()
        End If
    End Sub

    Private Sub BtnEsci_Click(sender As Object, e As EventArgs) Handles BtnEsci.Click
        Close()
    End Sub

    Private Sub SwitchEsc()
        If ActiveControl Is TxtDescArti Then
            Close()
        ElseIf ActiveControl Is BtnSalva Then
            ActiveControl = BtnEsci
        Else
            ActiveControl = BtnSalva
        End If
    End Sub

    'Etichetta
    Public Sub InfoCamp()
        Tsstabella.Text = TltTabella.GetToolTip(ActiveControl)
    End Sub

End Class