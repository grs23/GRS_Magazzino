Public Class Schermata_grs_riepilogo_interventi
    Public fp As Form = Nothing
    Private conn As MySqlConnection = GetConnDb()

    Public dtCorpo As New DataTable

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.WParam.ToInt64 = &HF060 Then
            AutoValidate = False
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles Me.Load
        InizializzaForm.Init(Me, fp)
        Field.ScrollingContextMenu(True, True, True, DgvCorpo)

        SettaVariabili()
    End Sub

    'Keydown
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            ActiveControl = BtnEsci
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
                Try
                    conn.Open()
                    If Service.CancRigo(TabelleDatabase.tb_intervento_testata, DgvCorpo.CurrentRow.DataBoundItem.row("id"), conn, True) Then
                        Dim dtDett As DataTable = New Query().CaricaInterventiDettagliLista(conn,
                                                                                            DgvCorpo.CurrentRow.DataBoundItem.row("anno_inter"),
                                                                                            DgvCorpo.CurrentRow.DataBoundItem.row("nume_inter"))

                        For Each rowDett As DataRow In dtDett.Rows
                            Service.CancRigo(TabelleDatabase.tb_intervento_dettaglio, rowDett("id"), conn, True)
                        Next

                        dtCorpo.Rows.Remove(DgvCorpo.CurrentRow.DataBoundItem.row)
                    End If
                Catch ex As Exception
                Finally
                    conn.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub Modi(Optional rowAppo As DataRow = Nothing)
        If CheckFormAperto(Schermata_grs_interventi, Application.OpenForms, True) OrElse CheckFormAperto(Schermata_grs_interventi_Modi, Application.OpenForms, True) Then
            MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Schermata_grs_interventi.fp = Me

            If rowAppo IsNot Nothing Then
                Schermata_grs_interventi.rigoRiepilogo = rowAppo
            Else
                Schermata_grs_interventi.rigoRiepilogo = dtCorpo.NewRow
                AzzeraRigo(Schermata_grs_interventi.rigoRiepilogo)

                Schermata_grs_interventi.rigoRiepilogo("anno_inter") = Date.Now.Year
            End If

            Schermata_grs_interventi.Show()
        End If
    End Sub

    Public Function Carica() As Boolean
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                dtCorpo = New Query().CaricaInterventiLista(conn,,, Date.Parse(TxtDallData.Text), Date.Parse(TxtAllaData.Text))
                DgvCorpo.DataSource = dtCorpo

                DgvCorpo.AutoResizeColumns()
                DgvCorpo.AutoResizeRows()

                PnlCorpo.Enabled = True
                PnlPiede.Enabled = True
                PnlTestata.Enabled = False
                ActiveControl = DgvCorpo

            End If
        Catch ex As Exception
            MessageBox.Show("Error while connecting to Server. " & ex.Message)
            Return False
        Finally
            conn.Close()
        End Try
        Return True
    End Function



    Private Sub TxtDallData_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDallData.Validating
        If IsDate(TxtDallData.Text) AndAlso TxtDallData.Text.Length = 10 Then
        Else
            MessageBox.Show("Inserire una data valida", "ATTENZIONE!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtAllaData_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtAllaData.PreviewKeyDown
        If My.Computer.Keyboard.ShiftKeyDown = False AndAlso e.KeyCode = Keys.Tab Then
            e.IsInputKey = True

            If Not IsDate(TxtDallData.Text) OrElse TxtDallData.Text.Length <> 10 Then
                MessageBox.Show("Inserire una data valida", "ATTENZIONE!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                ActiveControl = TxtDallData
            ElseIf Not IsDate(TxtAllaData.Text) OrElse TxtAllaData.Text.Length <> 10 Then
                MessageBox.Show("Inserire una data valida", "ATTENZIONE!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                ActiveControl = TxtAllaData
            Else
                Carica()
            End If
        End If
    End Sub

    Private Sub BtnEsci_Click(sender As Object, e As EventArgs) Handles BtnEsci.Click
        Close()
    End Sub

    Private Sub SettaVariabili()
        TxtDallData.Text = Date.Now.AddMonths(-1)
        TxtAllaData.Text = Date.Now

        DgvCorpo.DataSource = dtCorpo
        DgvCorpo.AutoGenerateColumns = False

        PnlTestata.Enabled = True
        PnlCorpo.Enabled = False
        PnlPiede.Enabled = False

        ActiveControl = TxtDallData
    End Sub

    'etichetta
    Public Sub InfoCamp()
        Tsstabella.Text = TltTabella.GetToolTip(ActiveControl)
    End Sub
End Class