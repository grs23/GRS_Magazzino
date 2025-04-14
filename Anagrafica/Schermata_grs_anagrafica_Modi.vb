Public Class Schermata_grs_anagrafica_Modi
    Public fp As Form = Nothing
    Private conn As MySqlConnection = GetConnDb()
    Public rowCorpo As DataRow = Nothing
    Public tipo_anagrafica As String = ""

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.WParam.ToInt64 = &HF060 Then
            AutoValidate = False
        End If
        MyBase.WndProc(m)
    End Sub
    Private Sub Schermata_grs_anagrafica_Modi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InizializzaForm.Init(Me, fp, True)
        CampiTrimSpazi(TxtRagiSoci, TxtDescReca)


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
        TxtRagiSoci.Text = row("ragi_socia")
        TxtDescReca.Text = row("desc_recap")
    End Sub
    Private Sub modi(ByRef row As DataRow)
        AzzeraRigo(row, True)
        row("ragi_socia") = TxtRagiSoci.Text
        row("desc_recap") = TxtDescReca.Text
    End Sub

    'validating
    Private Sub TxtRagiSoci_Validating(sender As Object, e As CancelEventArgs) Handles TxtRagiSoci.Validating

        If TxtRagiSoci.Text.Trim <> "" Then
            Try
                conn.Open()
                If TypeOf fp Is Schermata_grs_anagrafica Then
                    Dim dw = New DataView(CType(fp, Schermata_grs_anagrafica).dtCorpo, "ragi_socia = '" & TxtRagiSoci.Text.Trim.Replace("'", "''") & "'",
                                              "ragi_socia ASC", DataViewRowState.CurrentRows)

                    'If dw.Count > 0 AndAlso (IsDBNull(row("id")) OrElse dw(0)("id") <> row("id")) Then
                    If dw.Count > 0 AndAlso rowCorpo IsNot dw(0).Row Then
                        MessageBox.Show("Ragione sociale " & TxtRagiSoci.Text & " già presente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        e.Cancel = True
                    End If
                Else
                    Dim rigo As DataRow = New Query().CaricaRigoAnagrafica(conn, tipo_anagrafica, TxtRagiSoci.Text.Trim)
                    If rigo.RowState = DataRowState.Unchanged AndAlso (rigo("id") <> rowCorpo("id")) Then
                        MessageBox.Show(TxtRagiSoci.Text & " già presente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception
                Console.WriteLine("Errore: " & ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MessageBox.Show("Ragione sociale" & " obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            e.Cancel = True
        End If
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
        If TxtRagiSoci.Text.Trim = "" Then
            MessageBox.Show("Ragione sociale " & " obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtRagiSoci)
            ActiveControl = TxtRagiSoci
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
                AggiornaAnagrafica(rowCorpo, conn)

            Catch ex As Exception
                Console.WriteLine("Errore: " & ex.Message)
            Finally
                conn.Close()
            End Try

            If rowCorpo.RowState = DataRowState.Detached Then
                If TypeOf fp Is Schermata_grs_anagrafica Then
                    CType(fp, Schermata_grs_anagrafica).dtCorpo.Rows.Add(rowCorpo)
                    CType(fp, Schermata_grs_anagrafica).dtCorpo.AcceptChanges()
                End If
            End If
            Close()
        End If
    End Sub

    Private Sub BtnEsci_Click(sender As Object, e As EventArgs) Handles BtnEsci.Click
        Close()
    End Sub


    'setta
    Private Sub settaVaribili()
    End Sub


    'Etichetta
    Public Sub InfoCamp()
        Tsstabella.Text = TltTabella.GetToolTip(ActiveControl)
    End Sub






End Class