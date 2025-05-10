Public Class Schermata_grs_Pagamenti_dipendenti_Modi
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
        CampiTrimSpazi(TxtDescDipe, TxtDescPaga)
        Field.CampiDecimali(9, 2, TxtImpoPaga)
        Field.Data(TxtDataPaga)
        FormattaNumero(2, TxtImpoPaga)
        CampiNumerici(TxtImpoPaga)
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
        TxtDescDipe.Text = row("desc_dipen")
        TxtDescPaga.Text = row("desc_pagam")

        If IsDate(row("data_pagam")) Then
            TxtDataPaga.Text = row("data_pagam")
        End If

        TxtImpoPaga.Text = row("impo_pagam")

    End Sub
    Private Sub modi(ByRef row As DataRow)
        AzzeraRigo(row, True)
        row("desc_dipen") = TxtDescDipe.Text
        row("desc_pagam") = TxtDescPaga.Text
        If IsDate(TxtDataPaga.Text) Then
            row("data_pagam") = TxtDataPaga.Text
        Else
            row("data_pagam") = DBNull.Value
        End If
        row("impo_pagam") = TxtImpoPaga.Text

    End Sub

    'validating
    Private Sub TxtDescDipe_Validating(sender As Object, e As CancelEventArgs) Handles TxtDescDipe.Validating
        e.Cancel = Not controlloCampo(conn, sender, "ragi_socia", TabelleDatabase.tb_anagrafica, True, tipo_anagrafica)
        'If sender.Text.Trim <> "" Then
        '    Try
        '        conn.Open()

        '        Dim rigo As DataRow = New Query().CaricaRigoAnagrafica(conn, tipo_anagrafica, sender.text.trim)
        '        If rigo Is Nothing Then
        '            MessageBox.Show(sender.text & " inesistente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '            e.Cancel = True
        '        Else
        '            sender.text = rigo("ragi_socia")
        '        End If
        '    Catch ex As Exception
        '        Console.WriteLine("Errore: " & ex.Message)
        '    Finally
        '        conn.Close()
        '    End Try
        'Else
        '    MessageBox.Show("Dipendente " & " obbligatorio.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    e.Cancel = True
        'End If
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
        If TxtDescDipe.Text.Trim = "" Then
            MessageBox.Show("Dipendente " & " obbligatorio.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescDipe)
            ActiveControl = TxtDescDipe
            Return False
        ElseIf TxtDescPaga.Text.Trim = "" Then
            MessageBox.Show("Dettagli pagamento " & " obbligatorio.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescPaga)
            ActiveControl = TxtDescPaga
            Return False
        ElseIf Not isdate(TxtDataPaga.Text) OrElse (isdate(TxtDataPaga.Text) AndAlso TxtDataPaga.Text.Length <> 10) Then
            MessageBox.Show("Data pagamento " & " obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescPaga)
            ActiveControl = TxtDescPaga
            Return False
        ElseIf TxtImpoPaga.Text.Trim = "" OrElse Decimal.parse(TxtImpoPaga.Text).CompareTo(Decimal.Zero) = 0 Then
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
                AggiornaPagamentoDipendenti(rowCorpo, conn)

            Catch ex As Exception
                Console.WriteLine("Errore: " & ex.Message)
            Finally
                conn.Close()
            End Try

            If rowCorpo.RowState = DataRowState.Detached Then
                If TypeOf fp Is Schermata_grs_Pagamenti_dipendenti Then
                    CType(fp, Schermata_grs_Pagamenti_dipendenti).carica
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
        If ActiveControl Is TxtDescDipe Then
            rowF6 = QueryF6.Anagrafica_Dipendenti(Me, TxtDescDipe, conn)
            If rowF6 IsNot Nothing AndAlso rowF6.Table.Rows.Count > 0 Then
                TxtDescDipe.Text = rowF6("ragi_socia")
            End If
        End If
    End Sub

    'setta
    Private Sub settaVaribili()
        TxtDataPaga.Text = Date.Now.ToString("dd/MM/yyyy")
        TxtImpoPaga.Text = "0,00"
    End Sub


    'Etichetta
    Public Sub InfoCamp()
        Tsstabella.Text = TltTabella.GetToolTip(ActiveControl)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class