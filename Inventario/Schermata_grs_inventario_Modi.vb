Public Class Schermata_grs_inventario_Modi
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
        CampiTrimSpazi(TxtDescArtic, TxtUnitMisur)
        CampiNumerici(TxtPrezUnita, TxtQuantArtic, TxtQuantMinim)
        CampiDecimali(11, TxtQuantArtic, TxtQuantMinim)
        CampiDecimali(5, TxtPrezUnita)


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
        TxtDescArtic.Text = row("desc_artic")
        TxtQuantArtic.Text = row("quant_artic")
        TxtUnitMisur.Text = row("unit_misur")
        TxtQuantMinim.Text = row("quant_minim")
        TxtPrezUnita.Text = row("prez_unita")
    End Sub
    Private Sub modi(ByRef row As DataRow)
        row("desc_artic") = TxtDescArtic.Text
        row("quant_artic") = TxtQuantArtic.Text
        row("unit_misur") = TxtUnitMisur.Text
        row("quant_minim") = TxtQuantMinim.Text
        row("prez_unita") = TxtPrezUnita.Text
    End Sub

    'validating
    Private Sub TxtDescArtic_Validating(sender As Object, e As CancelEventArgs) Handles TxtDescArtic.Validating

        If TxtDescArtic.Text.Trim <> "" Then
            Try
                conn.Open()
                If TypeOf fp Is Schermata_grs_anagrafica Then
                    Dim dw = New DataView(CType(fp, Schermata_grs_inventario).dtCorpo, "desc_artic = '" & TxtDescArtic.Text.Trim.Replace("'", "''") & "'",
                                              "desc_artic ASC", DataViewRowState.CurrentRows)

                    'If dw.Count > 0 AndAlso (IsDBNull(row("id")) OrElse dw(0)("id") <> row("id")) Then
                    If dw.Count > 0 AndAlso rowCorpo IsNot dw(0).Row Then
                        MessageBox.Show("L'articolo " & TxtDescArtic.Text & " è già presente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        e.Cancel = True
                    End If
                Else
                    Dim rigoMezzo As DataRow = New Query().CaricaRigoInventario(conn, TxtDescArtic.Text.Trim)
                    If rigoMezzo.RowState = DataRowState.Unchanged AndAlso (rigoMezzo("id") <> rowCorpo("id")) Then
                        MessageBox.Show(TxtDescArtic.Text & " già presente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception
                Console.WriteLine("Errore: " & ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MessageBox.Show("Descrizione articolo obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            e.Cancel = True
        End If
    End Sub

    Private Function vericamp() As Boolean
        If TxtDescArtic.Text.Trim = "" Then
            MessageBox.Show("Descrizione articolo obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtDescArtic)
            ActiveControl = TxtDescArtic
            Return False
        ElseIf TxtQuantArtic.Text.Trim = "" OrElse TxtQuantArtic.Text = 0 Then
            MessageBox.Show("Quantità articolo obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtQuantArtic)
            ActiveControl = TxtQuantArtic
            Return False
        ElseIf TxtUnitMisur.Text.Trim = "" Then
            MessageBox.Show("Unità di misura articolo obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtUnitMisur)
            ActiveControl = TxtUnitMisur
            Return False
        ElseIf TxtQuantMinim.Text.Trim = "" Then
            MessageBox.Show("Quantià minima articolo obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtQuantMinim)
            ActiveControl = TxtQuantMinim
            Return False
        ElseIf TxtPrezUnita.Text.Trim = "" Then
            MessageBox.Show("Prezzo unitario articolo obbligatoria.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SegnalaErrori(TxtPrezUnita)
            ActiveControl = TxtPrezUnita
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
                AggiornaArticoli(rowCorpo, conn)

            Catch ex As Exception
                Console.WriteLine("Errore: " & ex.Message)
            Finally
                conn.Close()
            End Try

            If rowCorpo.RowState = DataRowState.Detached Then
                If TypeOf fp Is Schermata_grs_inventario Then
                    CType(fp, Schermata_grs_inventario).dtCorpo.Rows.Add(rowCorpo)
                    CType(fp, Schermata_grs_inventario).dtCorpo.AcceptChanges()
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