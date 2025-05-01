Public Class Schermata_grs_anagrafica
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
        ImpostaTemaChiaro(Me)
        Field.ScrollingContextMenu(True, True, True, DgvCorpo)
        DgvCorpo.DataSource = dtCorpo
        DgvCorpo.AutoGenerateColumns = False

        Carica()

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
        If CheckFormAperto(Schermata_grs_anagrafica_Modi, My.Application.OpenForms) = False Then
            Schermata_grs_anagrafica_Modi.fp = Me
            Schermata_grs_anagrafica_Modi.tipo_anagrafica = tipo_anagrafica

            If rowAppo IsNot Nothing Then
                Schermata_grs_anagrafica_Modi.rowCorpo = rowAppo
            Else
                Schermata_grs_anagrafica_Modi.rowCorpo = dtCorpo.NewRow
                Schermata_grs_anagrafica_Modi.rowCorpo("cancellato") = False
            End If

            Schermata_grs_anagrafica_Modi.Show()
        Else
            MessageBox.Show("E' gia in corso una variazione.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Function Carica() As Boolean
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                dtCorpo = New Query().CaricaAnagrafica(conn, tipo_anagrafica)
                DgvCorpo.DataSource = dtCorpo

                DgvCorpo.AutoResizeColumns()
                DgvCorpo.AutoResizeRows()

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

    Private Sub BtnEsci_Click(sender As Object, e As EventArgs) Handles BtnEsci.Click
        Close()
    End Sub

    'filtra
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
            DgvCorpo.DataSource = New DataView(dtCorpo, ClnRagiSoci.DataPropertyName & " LIKE '%" & TxtRicerca.Text.Replace("'", "''") & "%' OR " &
                                                        ClnDescReca.DataPropertyName & " LIKE '%" & TxtRicerca.Text.Replace("'", "''") & "%' ",
                                                     ClnRagiSoci.DataPropertyName & " DESC", DataViewRowState.CurrentRows)

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




    'etichetta
    Public Sub InfoCamp()
        Tsstabella.Text = TltTabella.GetToolTip(ActiveControl)
    End Sub





End Class