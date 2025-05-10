Public Class Schermata_grs_Pagamenti_dipendenti
    Public fp As Form
    Private conn As MySqlConnection = GetConnDb()
    Public dtCorpo As New DataTable

    Public tipo_anagrafica As String = ""
    Public Const tipo_cliente As String = "C"
    Public Const tipo_dipendente As String = "D"

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.WParam.ToInt64 = &HF060 Then
            AutoValidate = False
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Schermata_grs_anagrafica_Load(sender As Object, e As EventArgs) Handles Me.Load
        InizializzaForm.Init(Me, fp)
        Field.ScrollingContextMenu(True, True, True, DgvCorpo)

        ImpostaTema(Me)
        Field.Data(TxtDallData, TxtAllaData)
        DgvCorpo.DataSource = dtCorpo
        DgvCorpo.AutoGenerateColumns = False
        settaVariabili()
        'PnlCorpo.Enabled = False

        'PnlPiede.Enabled = False
        TxtRicerca.Enabled = False
        DgvCorpo.Enabled = False
        ActiveControl = TxtDallData
    End Sub

    'Keydown
    Private Sub Schermata_grs_anagrafica_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                    If Service.CancRigo(TabelleDatabase.tb_anagrafica, DgvCorpo.CurrentRow.DataBoundItem.row("id"), conn, True) Then
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
        If CheckFormAperto(Schermata_grs_Pagamenti_dipendenti_Modi, My.Application.OpenForms) = False Then
            Schermata_grs_Pagamenti_dipendenti_Modi.fp = Me
            Schermata_grs_Pagamenti_dipendenti_Modi.tipo_anagrafica = tipo_dipendente

            If rowAppo IsNot Nothing Then
                Schermata_grs_Pagamenti_dipendenti_Modi.rowCorpo = rowAppo
            Else
                Schermata_grs_Pagamenti_dipendenti_Modi.rowCorpo = dtCorpo.NewRow
            End If

            Schermata_grs_Pagamenti_dipendenti_Modi.Show()
        Else
            MessageBox.Show("E' gia in corso una variazione.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Public Function Carica() As Boolean
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                dtCorpo = New Query().CaricaRiepilogoPagamentoDipendenti(conn, TxtDallData.Text, TxtAllaData.Text)
                DgvCorpo.DataSource = dtCorpo

                DgvCorpo.AutoResizeColumns()
                DgvCorpo.AutoResizeRows()

                'PnlCorpo.Enabled = True
                'PnlPiede.Enabled = True
                'PnlTestata.Enabled = False
                TxtDallData.Enabled = False
                TxtAllaData.Enabled = False
                DgvCorpo.Enabled = True
                TxtRicerca.Enabled = True
                ActiveControl = DgvCorpo
                DgvCorpo.Focus()
                Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show("Error while connecting to Server. " & ex.Message)
            Return False
        Finally
            conn.Close()
        End Try
        Return True
    End Function



    Private Sub TxtAllaData_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtAllaData.PreviewKeyDown
        If My.Computer.Keyboard.ShiftKeyDown = False AndAlso e.KeyCode = Keys.Tab Then
            e.IsInputKey = True
            If IsDate(TxtAllaData.Text) AndAlso TxtAllaData.Text.Length = 10 Then

                Carica()
            Else
                e.IsInputKey = False
            End If
        End If
    End Sub


    Private Sub TxtDallData_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDallData.Validating
        If IsDate(TxtDallData.Text) AndAlso TxtDallData.Text.Length = 10 Then
        Else
            MessageBox.Show("Inserire una data valida", "ATTENZIONE!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            e.Cancel = True
        End If
    End Sub




    Private Sub BtnEsci_Click(sender As Object, e As EventArgs) Handles BtnEsci.Click
        Close()
    End Sub



    Private Sub settaVariabili()
        TxtDallData.Text = Date.Now.AddDays(-7).ToString("dd/MM/yyyy")
        TxtAllaData.Text = Date.Now.ToString("dd/MM/yyyy")
    End Sub



    'etichetta
    Public Sub InfoCamp()
        Tsstabella.Text = TltTabella.GetToolTip(ActiveControl)
    End Sub





End Class