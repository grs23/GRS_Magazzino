Public Class Login
    Public fp As Form = Nothing
    Dim tempoRiprova As Integer = 35

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.WParam.ToInt64 = &HF060 Then
            fp.Close()
        End If
        MyBase.WndProc(m)
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        TimerAggiornamento.Start()
        TxtUsername.Text = "admin"
        TxtPassword.Text = "************"
        InizializzaForm.Init(Me, fp, True)
        'setForm(Me)
        'PnlModulo.BackColor = Color.FromArgb(150, 225, 255)
        'setfont(PnlModulo)
        ColorButton(BtnCancel, BtnOK)


        Dim conn As MySqlConnection = GetConnDb()
        MenuGRS.boolLice = Licenza.ControlloLicenza(conn, LblLicenza, MenuGRS.LblLicenza)
        Try
            Dim dtUten As New DataTable

            conn.Open()
            dtUten = New Query().CaricaUtenti(conn, True,)
            If dtUten.Rows.Count > 1 Then

                TxtUsername.Text = ""
                TxtPassword.Text = ""
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            conn.Close()
        End Try
        'Dim fileConnessioneEsiste As Boolean = IO.File.Exists(menuprad.percorsoPrincipaleConnessione)

        'If Service.LeggiFileConnessione(If(fileConnessioneEsiste,
        '                                menuprad.percorsoPrincipaleConnessione,
        '                                menuprad.percorso & "\" & menuprad.nomeFileConnessione),
        '                                Not fileConnessioneEsiste OrElse IO.File.Exists(menuprad.percorso & "\" & menuprad.nomeFileConnessione)) Then
        '    Crea_Archivi.CreaTabellaUtenti()
        '    ModificaTabelle.Modifica()
        'Else
        '    End
        'End If
    End Sub
    Private Sub Login_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Chiudere il programma?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                End
            End If
        ElseIf My.Computer.Keyboard.CtrlKeyDown AndAlso e.KeyCode = Keys.F1 Then
            Dim conn As MySqlConnection = GetConnDb()
            MessageBox.Show("Connessione: " & Environment.NewLine &
                             conn.DataSource & Environment.NewLine &
                            conn.Database, "Attenzione")
            'ElseIf My.Computer.Keyboard.CtrlKeyDown AndAlso e.KeyCode = Keys.F11 Then
            '    If GetConnDb.DataSource <> Service.CONNSTRINGAMAZON Then
            '        If Passwords.ConfrontaPasswordSI(Me) Then
            '            AssistenzaSI.ScaricaHeidi(MenuDsAu.percorso, GetConnDb())
            '        End If
            '    Else
            '        MessageBox.Show("Impossibile Effettuare l'operazione")
            '    End If
        ElseIf My.Computer.Keyboard.CtrlKeyDown AndAlso e.KeyCode = Keys.F12 Then
            ConfConn.ApriFileConfigurazione(Me, MenuGRS.percorsoPrincipaleConnessione, MenuGRS.percorso & "\" & MenuGRS.exe)
        End If
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        '-------------------------------------------------------------
        '-----------------------------------------------SENZA PASSWORD   da eliminare appena tutto OK
        '-------------------------------------------------------------
        Dim dtUten As New DataTable

        Dim conn As MySqlConnection = GetConnDb()
        Try
            conn.Open()
            dtUten = New Query().CaricaUtenti(conn, True,)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            conn.Close()
        End Try
        Try
            conn.Open()
            Dim rigoUten As DataRow
            rigoUten = dtUten.NewRow
            AzzeraRigo(rigoUten)

            If TxtUsername.Text.Trim = "ADMIN" AndAlso ConfrontaPasswordGRS(TxtPassword.Text.Trim) Then
                rigoUten("username") = "ADMIN"
                rigoUten("password") = "ADMIN"
                'rigoUten("ruolo") = 0
                rigoUten("nickname") = "GRS"
                rigoUten("nominativo") = "GRS"
                rigoUten("email") = "info.grs23@gmail.com"
                rigoUten("ctrl_acces") = True
                'ElseIf dtUten.Rows.Count > 0 Then  
                '    rigoUten = dtUten.AsEnumerable().Where(Function(x) x("username").ToString = TxtUsername.Text AndAlso x("password").ToString = TxtPassword.Text).FirstOrDefault
                '    If TxtUsername.Text.Trim <> "ADMIN" AndAlso rigoUten IsNot Nothing Then
                '    Else
                '        '                   If MessageBox.Show("Utene non trovato. Vuoi comunque continuare?", "ATTENZIONE!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                '        rigoUten = dtUten.NewRow
                '            rigoUten("username") = "-UNKNOWN-"
                '            rigoUten("password") = "-UNKNOWN-"
                '            rigoUten("ruolo") = 0
                '            rigoUten("nickname") = "-UNKNOWN-"
                '            rigoUten("nominativo") = "-UNKNOWN-"
                '            rigoUten("email") = "-UNKNOWN-"
                '            rigoUten("ctrl_acces") = True
                '        '             End If

                '    End If
            ElseIf dtUten.Rows.Count > 1 Then 'cio significa che hanno inserito un utente
                rigoUten = dtUten.AsEnumerable().Where(Function(x) x("username").ToString = TxtUsername.Text AndAlso x("password").ToString = TxtPassword.Text).FirstOrDefault
                If rigoUten Is Nothing Then
                    Dim Appouten As DataRow = dtUten.AsEnumerable().Where(Function(x) x("username").ToString = TxtUsername.Text).FirstOrDefault
                    If Appouten IsNot Nothing Then
                        MessageBox.Show("Password errata", "ATTENZIONE!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Else
                        MessageBox.Show("Utente non trovato.", "ATTENZIONE!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If

                End If
            ElseIf dtUten.Rows.Count > 0 Then
                rigoUten = dtUten.AsEnumerable().Where(Function(x) x("username").ToString = TxtUsername.Text AndAlso x("password").ToString = TxtPassword.Text).FirstOrDefault
                If TxtUsername.Text.Trim <> "ADMIN" AndAlso rigoUten IsNot Nothing Then
                Else
                    '                   If MessageBox.Show("Utene non trovato. Vuoi comunque continuare?", "ATTENZIONE!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    rigoUten = dtUten.NewRow
                    rigoUten("username") = "-UNKNOWN-"
                    rigoUten("password") = "-UNKNOWN-"
                    'rigoUten("ruolo") = 0
                    rigoUten("nickname") = "-UNKNOWN-"
                    rigoUten("nominativo") = "-UNKNOWN-"
                    rigoUten("email") = "-UNKNOWN-"
                    rigoUten("ctrl_acces") = True
                    '             End If

                End If
            End If
            MenuGRS.rigoUten = rigoUten

            'BGW.CambiaTestoLabel(LblAggiorna, "")

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            conn.Close()
        End Try
        '------------------------------------------------------------- 
        '-------------------------------------------------------------
        '-------------------------------------------------------------
        'If TxtUsername.Text = "" Then
        '    MessageBox.Show("Username obbligatorio!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    ActiveControl = TxtUsername
        'ElseIf TxtPassword.Text = "" Then
        '    MessageBox.Show("Password obbligatoria!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    ActiveControl = TxtPassword
        'ElseIf TxtUsername.Text.Trim = "ADMIN" AndAlso Not ConfrontaPasswordSI(TxtPassword.Text.Trim) Then
        '    MessageBox.Show("Username o password errati!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    ActiveControl = TxtUsername
        'Else
        '    Dim conn As MySqlConnection = GetConnDb()
        '    Try
        '        conn.Open()
        '        Dim rowUten As DataRow
        '        If TxtUsername.Text.Trim = "ADMIN" Then
        '            rowUten = New Query().CaricaUtente(conn, TxtUsername.Text, "ADMIN", True)
        '        Else
        '            rowUten = New Query().CaricaUtente(conn, TxtUsername.Text, TxtPassword.Text, True)
        '        End If
        '        If rowUten.RowState <> DataRowState.Unchanged Then
        '            MessageBox.Show("Username o password errati!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '            ActiveControl = TxtUsername
        '        Else
        '            If rowUten("username") <> "ADMIN" AndAlso rowUten("ctrl_acces") = True Then
        '                If MessageBox.Show("Utente già loggato! Rieffettuare l'accesso?" & Environment.NewLine & "(Attesa richiesta di 35 secondi)", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
        '                    TxtUsername.Enabled = False
        '                    TxtPassword.Enabled = False
        '                    BtnOK.Enabled = False
        '                    TimerRiprova.Start()

        '                End If
        '            Else
        '                rowUten("ctrl_acces") = True
        '                menuprad.rigoUten = rowUten


        '                UtentiModi.AggiornaUten(rowUten, conn)

        '-------------------------------------------------------------
        '------------------------------------------------SENZA PASSWORD   da eliminare appena tutto OK
        '-------------------------------------------------------------
        If MenuGRS.rigoUten IsNot Nothing Then
            '-------------------------------------------------------------
            '------------------------------------------------
            '-------------------------------------------------------------
            Close()
            ' If dbesiste(NomeDB) = True Then
            'EliminaElementiDuplicati(conn)
            CreaArchivi.CreaArchivi(False)
            MenuGRS.rigoPers = New Query().CaricaPersonalizzazione(conn)
            TimerAggiornamento.Stop()
            MenuGRS.LanciaRoutine()
            '-------------------------------------------------------------
            '------------------------------------------------SENZA PASSWORD   da eliminare appena tutto OK
            '-------------------------------------------------------------
        End If
        '-------------------------------------------------------------
        '------------------------------------------------
        '-------------------------------------------------------------
        '            End If
        '        End If
        '    Catch ex As Exception
        '        Console.WriteLine(ex.Message)
        '    Finally
        '        conn.Close()
        '    End Try
        'End If
        '-------------------------------------------------------------
        '------------------------------------------------SENZA PASSWORD   da eliminare appena tutto OK
        '-------------------------------------------------------------
        'End If
        '-------------------------------------------------------------
        '------------------------------------------------
        '-------------------------------------------------------------
    End Sub

    Private Sub TimerAggiornamento_Tick(sender As Object, e As EventArgs) Handles TimerAggiornamento.Tick
        'If Aggiornamenti.AggiornamentoFinito(MenuDsAu.exe.Replace(".exe", "")) = False Then
        '    Console.WriteLine("aggiornamento in corso")
        'Else
        '    Console.WriteLine("controllo agg.")
        'End If
    End Sub

    Private Sub TimerRiprova_Tick(sender As Object, e As EventArgs) Handles TimerRiprova.Tick
        Text = "Login - Riprovo il Login tra: " & tempoRiprova.ToString.PadLeft(2, "0")

        If tempoRiprova = 0 Then
            TimerRiprova.Stop()
            BtnOK.Enabled = True
            BtnOK.PerformClick()
        End If
        tempoRiprova -= 1
    End Sub


    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        MenuGRS.Close()
    End Sub


    Private Sub PasswordTextBox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If My.Computer.Keyboard.ShiftKeyDown = False AndAlso e.KeyCode = Keys.Tab Then
            If TxtPassword.Text <> "" Then
                e.IsInputKey = True
                OK_Click(sender, e)
            End If
        End If
    End Sub
End Class