Public Class Schermata_grs_Acquisto_Materiale_Modi
    Public fp As Form = Nothing
    Private conn As MySqlConnection = GetConnDb()
    Public rowCorpo As DataRow = Nothing
    Public tipo_anagrafica As String = Schermata_grs_anagrafica.tipo_dipendente

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.WParam.ToInt64 = &HF060 Then
            AutoValidate = False
        End If
        MyBase.WndProc(m)
    End Sub
    Private Sub Schermata_grs_anagrafica_Modi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InizializzaForm.Init(Me, fp, True)
        ImpostaTema(Me)
        CampiTrimSpazi(TxtDescArti, TxtDescPaga)
        Field.CampiDecimali(9, 2, TxtQuanArti, TxtImpoPaga)
        Field.Data(TxtDataAcqu)
        FormattaNumero(2, TxtQuanArti, TxtImpoPaga)
        CampiNumerici(TxtImpoPaga, TxtQuanArti)
        settaVaribili()

        If rowCorpo.RowState <> DataRowState.Detached Then
            asse(rowCorpo)
        End If

    End Sub


    'keydown 
    Private Sub Schermata_grs_anagrafica_Modi_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            'corpesc()
        End If
    End Sub


    'Private Sub CmbTipoCfLg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles CmbTipoCfLg.PreviewKeyDown
    '    If My.Computer.Keyboard.ShiftKeyDown = False AndAlso e.KeyCode = Keys.Tab Then
    '        e.IsInputKey = True
    '        If CmbTipoCfLg.Text.Trim <> "" Then
    '            corpesc()
    '        End If
    '    End If
    'End Sub


    'asse
    Private Sub asse(ByVal row As DataRow)
        TxtDescArti.Text = row("desc_dipen")
        TxtDescPaga.Text = row("desc_pagam")

        If IsDate(row("data_acqui")) Then
            TxtDataAcqu.Text = row("data_acqui")
        End If

        TxtQuanArti.Text = row("quan_artic")
        TxtImpoPaga.Text = row("impo_pagam")

    End Sub
    Private Sub modi(ByRef row As DataRow)
        AzzeraRigo(row, True)
        row("desc_dipen") = TxtDescArti.Text
        row("desc_pagam") = TxtDescPaga.Text

        If IsDate(TxtDataAcqu.Text) Then
            row("data_acqui") = TxtDataAcqu.Text
        Else
            row("data_acqui") = DBNull.Value
        End If

        row("quan_artic") = TxtQuanArti.Text
        row("impo_pagam") = TxtImpoPaga.Text

    End Sub

    'validating
    Private Sub TxtDescDipe_Validating(sender As Object, e As CancelEventArgs) Handles TxtDescArti.Validating
        e.Cancel = Not controlloCampo(conn, sender, "desc_artic", TabelleDatabase.tb_articoli, True)
    End Sub



    ''button
    'Private Sub corpesc()
    '    If Not PnlModulo.Controls.Contains(BtnEsci) Then
    '        sinoConf(Me, PnlModulo, BtnConferma, BtnEsci)
    '        BtnConferma.Focus()
    '    Else
    '        BtnConferma.Focus()
    '    End If
    'End Sub
    Private Function vericamp() As Boolean
        If TxtDescArti.Text.Trim = "" Then
            MessageBox.Show("Articolo " & " obbligatorio.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescArti)
            ActiveControl = TxtDescArti
            Return False
        ElseIf TxtDescPaga.Text.Trim = "" Then
            MessageBox.Show("Dettagli pagamento " & " obbligatorio.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescPaga)
            ActiveControl = TxtDescPaga
            Return False
        ElseIf Not IsDate(TxtDataAcqu.Text) OrElse (IsDate(TxtDataAcqu.Text) AndAlso TxtDataAcqu.Text.Length <> 10) Then
            MessageBox.Show("Data Acquisto " & " obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescPaga)
            ActiveControl = TxtDescPaga
            Return False
        ElseIf TxtQuanArti.Text.Trim = "" OrElse Decimal.Parse(TxtQuanArti.Text).CompareTo(Decimal.Zero) = 0 Then
            MessageBox.Show("Quantità" & " obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescPaga)
            ActiveControl = TxtDescPaga
            Return False
        ElseIf TxtImpoPaga.Text.Trim = "" OrElse Decimal.Parse(TxtImpoPaga.Text).CompareTo(Decimal.Zero) = 0 Then
            MessageBox.Show("Importo del pagamento " & " obbligatorio.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescPaga)
            ActiveControl = TxtDescPaga
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub BtnSalva_Click(sender As Object, e As EventArgs) Handles BtnSalva.Click

        If vericamp() Then

            modi(rowCorpo)
            Try
                conn.Open()
                AggiornaAcquistoArticoli(rowCorpo, conn)
                ControlloPrezzoArticolo()

            Catch ex As Exception
                Console.WriteLine("Errore: " & ex.Message)
            Finally
                conn.Close()
            End Try

            If rowCorpo.RowState = DataRowState.Detached Then
                If TypeOf fp Is Schermata_grs_Acquisto_Materiali Then
                    CType(fp, Schermata_grs_Acquisto_Materiali).Carica()
                End If
            End If
            Close()
        End If
    End Sub

    Private Sub BtnEsci_Click(sender As Object, e As EventArgs) Handles BtnEsci.Click
        Close()
    End Sub


    Public Sub F6()
        Dim rowF6 As DataRow
        If ActiveControl Is TxtDescArti Then
            rowF6 = QueryF6.Articoli(Me, TxtDescArti, conn)
            If rowF6 IsNot Nothing AndAlso rowF6.Table.Rows.Count > 0 Then
                TxtDescArti.Text = rowF6("desc_artic")
            End If
        End If
    End Sub

    'setta
    Private Sub settaVaribili()
        TxtDataAcqu.Text = Date.Now.ToString("dd/MM/yyyy")
        TxtImpoPaga.Text = "0,00"
        TxtQuanArti.Text = "0,00"
    End Sub


    'Etichetta
    Public Sub InfoCamp()
        Tsstabella.Text = TltTabella.GetToolTip(ActiveControl)
    End Sub

    Private Sub TxtQuanArti_Validating(sender As Object, e As CancelEventArgs) Handles TxtQuanArti.Validating
        If TxtQuanArti.Text.Trim <> "" Then
            Dim rowArti As DataRow = New Query().CaricaRigoInventario(conn, TxtDescArti.Text)
            If rowArti IsNot Nothing Then
                TxtImpoPaga.Text = Oc.FMulNoBox(2, Decimal.Parse(TxtQuanArti.Text), Decimal.Parse(rowArti("prez_unita")))
            End If
        End If
    End Sub

    Private Sub ControlloPrezzoArticolo()
        Try

            Dim prezzo_unitario As Decimal = Oc.FDivNoBox(2, Decimal.Parse(TxtImpoPaga.Text), Decimal.Parse(TxtQuanArti.Text))
            Dim rowArti As DataRow = New Query().CaricaRigoInventario(conn, TxtDescArti.Text)
            If rowArti IsNot Nothing Then
                If prezzo_unitario.CompareTo(Decimal.Parse(rowArti("prez_unita"))) <> 0 Then
                    If MessageBox.Show("Prezzo Calcolato diverso rispetto al prezzo unitario dell'articolo." & Environment.NewLine & "Prezzo Pagato: " &
                                       prezzo_unitario & Environment.NewLine & "Prezzo unitario articolo: " & rowArti("prez_unita") &
                                                                 Environment.NewLine & "Vuoi Aggiornare il prezzo unitario dell'articolo?", "Question!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        rowArti("prez_unita") = prezzo_unitario
                        AggiornaArticoli(rowArti, conn)
                        MessageBox.Show("Prezzo unitario articolo Aggiornato!!", "Success!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class

