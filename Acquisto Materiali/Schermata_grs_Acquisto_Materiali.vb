Public Class Schermata_grs_Acquisto_Materiali
    Public fp As Form
    Private conn As MySqlConnection = GetConnDb()
    Public dtCorpo As New DataTable


    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.WParam.ToInt64 = &HF060 Then
            AutoValidate = False
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Schermata_grs_Acquisto_Materiali_Load(sender As Object, e As EventArgs) Handles Me.Load
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
    Private Sub Schermata_grs_Acquisto_Materiali_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                    If Service.CancRigo(TabelleDatabase.tb_acquisto_articoli, DgvCorpo.CurrentRow.DataBoundItem.row("id"), conn, True) Then
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
        If CheckFormAperto(Schermata_grs_Acquisto_Materiale_Modi, My.Application.OpenForms) = False Then
            Schermata_grs_Acquisto_Materiale_Modi.fp = Me

            If rowAppo IsNot Nothing Then
                Schermata_grs_Acquisto_Materiale_Modi.rowCorpo = rowAppo
            Else
                Schermata_grs_Acquisto_Materiale_Modi.rowCorpo = dtCorpo.NewRow
            End If

            Schermata_grs_Acquisto_Materiale_Modi.Show()
        Else
            MessageBox.Show("E' gia in corso una variazione.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Public Function Carica() As Boolean
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                dtCorpo = New Query().CaricaRiepilogoAcquistoMateriali(conn, TxtDallData.Text, TxtAllaData.Text)
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

    Public Sub Filtra() Handles TxtRicerca.TextChanged
        If dtCorpo.Rows.Count <> 0 Then
            'MI SALVO L'INDICE NEL CASO IL FILTRA VENISSE RICHIAMATO DALLA GRIGLIA, IN MODO DA POTERMI RIPOSIZIONARE SULL'INDICE CORRETTO QUALORA VENISSE FILTRATA DALLA GRIGLIA STESSA
            Dim index As Integer = 0
            Try
                If DgvCorpo.Rows.Count > 0 Then
                    index = DgvCorpo.CurrentRow.Index
                End If
            Catch ex As Exception

            End Try

            'DI SEGUITO NON HO USATO NOMI DI CAMPI FISSI COSÌ NEL CASO IL DATAPROPERTYNAME CAMBIASSE NON C'È BISOGNO DI CORREGGERE ANCHE QUI
            'UNICA ECCEZIONE LO FA IL TIPO_FATTU PERCHÈ NON PRESENTE NELLE COLONNE
            DgvCorpo.DataSource = New DataView(dtCorpo, ClnDescArtic.DataPropertyName & " LIKE '%" & TxtRicerca.Text.Replace("'", "''") & "%' OR " &
                                                        ClnDescPAgam.DataPropertyName & " LIKE '%" & TxtRicerca.Text.Replace("'", "''") & "%' ",
                                                     ClnDataAcqui.DataPropertyName & " DESC, " & ClnDescArtic.DataPropertyName & " ASC", DataViewRowState.CurrentRows)

            'RIPOSIZIONAMENTO SUL RIGO DELLA GRIGLIA
            Try
                If ActiveControl Is DgvCorpo Then
                    ActiveControl = DgvCorpo
                    DgvCorpo.Rows(index).Selected = True
                    DgvCorpo.CurrentCell = DgvCorpo.Rows(index).Cells(0)
                End If
            Catch ex As Exception

            End Try
        End If

        'lblNumeOper.Text = DgvCorpo.Rows.Count
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