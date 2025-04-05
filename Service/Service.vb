Public Class Service
    Private Shared Host As String = ""
    Private Shared Server As String = ""
    Private Shared Username As String = ""
    Private Shared Password As String = ""
    Private Shared Porta As String = ""
    Private Shared Dbname As String = ""
    Private Shared SerialNumber As String = ""

    'Lettura file Configurazione
    Shared Function LeggiFileConnessione(filePath As String, Optional spostaFile As Boolean = False) As Boolean
        If FileExists(filePath) Then
            ''----------------------------------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------CRIPTA
            Dim leggiTesto As String = IO.File.ReadAllText(filePath)

            Dim lunghezzaStringaRandom = 10

            If leggiTesto.ToUpper.Contains("USERNAME") AndAlso leggiTesto.ToUpper.Contains("DATABASE") AndAlso leggiTesto.ToUpper.Contains("HOST") Then
                '-----------------------------------------------------------------
                'AGGIUNTA SERIAL NUMBER COME PROPRIETÀ AL FILE DI CONFIGURAZIONE
                If Not leggiTesto.ToUpper.Contains("SERIAL NUMBER") Then
                    leggiTesto &= If(leggiTesto.EndsWith(Environment.NewLine), "", Environment.NewLine) & "Serial Number = "
                End If
                '-----------------------------------------------------------------

                Dim testoCriptato As String = Cripta(leggiTesto, lunghezzaStringaRandom, lunghezzaStringaRandom)
                IO.File.WriteAllText(filePath, testoCriptato)
                leggiTesto = IO.File.ReadAllText(filePath)
            End If

            '-----------------------------------------------------------------DECRIPTA
            Dim testoDecriptato As String = Decripta(leggiTesto, lunghezzaStringaRandom, lunghezzaStringaRandom)

            '-----------------------------------------------------------------
            'AGGIUNTA SERIAL NUMBER COME PROPRIETÀ AL FILE DI CONFIGURAZIONE
            If Not testoDecriptato.ToUpper.Contains("SERIAL NUMBER") Then
                testoDecriptato &= If(testoDecriptato.EndsWith(Environment.NewLine), "", Environment.NewLine) & "Serial Number = "
                Dim testoCriptato As String = Cripta(testoDecriptato, lunghezzaStringaRandom, lunghezzaStringaRandom)
                IO.File.WriteAllText(filePath, testoCriptato)
                'leggiTesto = IO.File.ReadAllText(filePath)
            End If
            '-----------------------------------------------------------------
            Dim listaElementi As New List(Of String)
            listaElementi.AddRange(testoDecriptato.Split(Environment.NewLine))
            '----------------------------------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------METODO SENZA CIFRATURA NE NULLA
            'Dim listaElementi As New List(Of String)
            'listaElementi.AddRange(IO.File.ReadAllLines(filePath).ToList)
            '----------------------------------------------------------------------------------------------------------------------------------

            Dim CambiaFileLogin As Boolean = False

            For Each sLine In listaElementi
                sLine = sLine.Replace(vbLf, "")
                If sLine.ToString.Contains("=") Then
                    If sLine.ToUpper.StartsWith("HOST") Then

                        Host = sLine.ToString.Substring(sLine.ToString.IndexOf("=") + 1).Trim
                    ElseIf sLine.ToUpper.StartsWith("SERVER") Then
                        Server = sLine.ToString.Substring(sLine.ToString.IndexOf("=") + 1).Trim
                    ElseIf sLine.ToUpper.StartsWith("DATABASE") Then
                        Dbname = sLine.ToString.Substring(sLine.ToString.IndexOf("=") + 1).Trim
                        'NomeDB = Dbname
                    ElseIf sLine.ToUpper.StartsWith("USERNAME") Then
                        Username = sLine.ToString.Substring(sLine.ToString.IndexOf("=") + 1).Trim
                    ElseIf sLine.ToUpper.StartsWith("PASSWORD") Then
                        Password = sLine.ToString.Substring(sLine.ToString.IndexOf("=") + 1).Trim
                    ElseIf sLine.ToUpper.StartsWith("PORTA") Then
                        Porta = sLine.ToString.Substring(sLine.ToString.IndexOf("=") + 1).Trim
                    ElseIf sLine.ToUpper.StartsWith("SERIAL NUMBER") Then
                        SerialNumber = sLine.ToString.Substring(sLine.ToString.IndexOf("=") + 1).Trim
                    End If
                End If
            Next

            If Dbname.Trim = "" Then
                MessageBox.Show("Database Mancante!!", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Service.ApriFileConf(filePath)
                Return False
            ElseIf Username.Trim = "" Then
                MessageBox.Show("Username Mancante!!", "Username", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Service.ApriFileConf(filePath)
                Return False
            Else
                'menuprad.service = New Service(HostProp, ServerProp, DbnameProp, UsernameProp, PasswordProp, PortaProp)
                'If CambiaFileLogin Then
                '    Dim txt = My.Computer.FileSystem.ReadAllText(filePath)
                '    txt = txt.Replace(CONNSTRINGAMAZON, "SI")
                '    My.Computer.FileSystem.WriteAllText(filePath, txt, False)
                'End If

                ''CAMBIO UTENTE, AGGIUNTA DA RIMUOVERE IN FUTURO IL 04/12/2023 Solinfo2021
                ''------------------------------------------------------------------------
                ''Dim nuovaPassword = "prova"
                'Dim nuovaPassword = "Solinfo2021"
                'If Dbname.toupper.contains("MILELLA") andalso Username = "muletto" AndAlso
                '   Password <> nuovaPassword Then
                '    For i = 0 To listaElementi.Count - 1
                '        If listaElementi(i).Trim.ToUpper.StartsWith("PASSWORD") Then
                '            listaElementi(i) = listaElementi(i).Replace(Password, nuovaPassword)
                '        End If
                '    Next

                '    Password = nuovaPassword

                '    My.Computer.FileSystem.WriteAllText(filePath, String.Join(Environment.NewLine, listaElementi), False)
                'End If
                '------------------------------------------------------------------------

                If spostaFile Then
                    Try
                        If DirectoryExists(MenuGRS.percorsoPrincipaleConnessione.Replace(MenuGRS.nomeFileConnessione, "")) = False Then
                            IO.Directory.CreateDirectory(MenuGRS.percorsoPrincipaleConnessione.Replace(MenuGRS.nomeFileConnessione, ""))
                        End If
                        If FileExists(MenuGRS.percorsoPrincipaleConnessione) Then
                            IO.File.Delete(MenuGRS.percorso & "\" & MenuGRS.nomeFileConnessione)
                        Else
                            IO.File.Move(MenuGRS.percorso & "\" & MenuGRS.nomeFileConnessione, MenuGRS.percorsoPrincipaleConnessione)
                        End If
                    Catch ex As Exception

                    End Try
                End If

                If Host.Trim <> "" Then
                    StringaConn &= "host=" & Host & ";"
                End If

                If Server.Trim <> "" Then
                    StringaConn &= "server=" & Server & ";"
                End If

                StringaConn &= "database=" & Dbname & ";username=" & Username & ";password=" & Password  ' stringa di connessione ' stringa di connessione

                If Porta.Trim <> "" Then
                    StringaConn &= ";port=" & Porta & ";"
                End If

                StringaConn &= ";Convert Zero Datetime=True;"
                'MenuGRS.conn = GetConnDb()
                Console.WriteLine("Connessione: " & StringaConn)
                Console.WriteLine("Serial Number: " & SerialNumber)
                Return True
            End If
        Else
            If MessageBox.Show("file di configurazione non trovato, Desideri crearlo?", "Connessione", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                If ConfermaPassword() Then
                    Using sw As IO.StreamWriter = IO.File.CreateText(filePath)
                        sw.WriteLine("Host = ")
                        sw.WriteLine("Server = ")
                        sw.WriteLine("Database = ")
                        sw.WriteLine("Username = ")
                        sw.WriteLine("Password = ")
                        sw.WriteLine("Porta = ")
                        sw.WriteLine("Serial Number = ")
                    End Using
                    MessageBox.Show("Si prega di settare il file e riavviare il programma", "Connessione", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Service.ApriFileConf(filePath)
                    Return False
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function

    Shared Sub ApriFileConf(filePath)
        Shell("notepad.exe " & filePath, AppWinStyle.MaximizedFocus)
    End Sub

    'ACCESSO AL DB-----------------------------------------------------------
    Private Shared Function ConfermaPassword() As Boolean
        If ConfrontaPasswordGRS(MenuGRS) Then
            Return True
        Else
            MessageBox.Show("Password errata!!", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return False
        End If
    End Function

    Public Function AccessDB() As IDbConnection
        Dim conn As IDbConnection = Nothing

inizio:
        'SetParam()
        'Dim connstring As String = "Server=localhost;database=Trasporti;username=root;password=;port=3306" ' stringa di connessione ' stringa di connessione
        'Dim connstring As String = "host=database-tra.cjupdon7a8eb.us-east-1.rds.amazonaws.com;database=Trasporti;username=admin;password=SME_1975;port=3306" ' stringa di connessione ' stringa di connessione
        'Dim connstring As String = "database=Trasporti;username=root;password=" ' stringa di connessione ' stringa di connessione
        Dim connstring As String = ""

        If Host.Trim <> "" Then
            connstring &= "host=" & Host & ";"
        End If

        If Server.Trim <> "" Then
            connstring &= "server=" & Server & ";"
        End If

        connstring &= "database=" & Dbname & ";username=" & Username & ";password=" & Password  ' stringa di connessione ' stringa di connessione

        If Porta.Trim <> "" Then
            connstring &= ";port=" & Porta & ";"
        End If

        connstring &= "Convert Zero Datetime=True;"
        Console.WriteLine("conn: " & connstring)
        Try
            conn = connessioni.GetConn(connstring, TipiConn.ConnMySQL)
            conn.Open()
            conn.Close()
        Catch ex As Exception
            Console.WriteLine("Errore: " & ex.Message)
            If ex.Message.ToUpper.Contains("UNKNOWN DATABASE") Then
                If ConfermaPassword() Then
                    'connstring = "host=database-tra.cjupdon7a8eb.us-east-1.rds.amazonaws.com;username=admin;password=SME_1975;port=3306"

                    connstring = ""

                    If Host.Trim <> "" Then
                        connstring &= "host=" & Host & ";"
                    End If

                    If Server.Trim <> "" Then
                        connstring &= "server=" & Server & ";"
                    End If

                    connstring &= "username=" & Username & ";password=" & Password

                    If Porta.Trim <> "" Then
                        connstring &= ";port=" & Porta & ";"
                    End If

                    Console.WriteLine("conn: " & connstring)
                    conn = connessioni.GetConn(connstring, TipiConn.ConnMySQL)
                    Try
                        conn.Open()
                        If conn.State = ConnectionState.Open Then

                            Dim command As IDbCommand = conn.CreateCommand

                            command.CommandText = " CREATE DATABASE IF NOT EXISTS " & Dbname & " "

                            command.ExecuteNonQuery()

                        End If
                        conn.Close()
                        GoTo inizio
                    Catch exe As Exception
                        MessageBox.Show("Errore di connessione:" & Environment.NewLine & exe.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End Try
                Else
                    End
                End If
            End If
        End Try
        StringaConn = connstring
        'NomeDB = Dbname
        Return conn
    End Function

    'prende l'username se presente altrimenti scrive -UNKNOWN- e aggiunge la data formato AAMMDDhhmm
    Shared Function UtenteDelMomento(Optional ByRef row As DataRow = Nothing, Optional campo As String = "") As String

        Dim user As String

        If MenuGRS.rigoUten IsNot Nothing AndAlso IsDBNull(MenuGRS.rigoUten("username")) = False Then
            user = MenuGRS.rigoUten("username")
        Else
            user = "-UNKNOWN-"
        End If

        user &= Date.Now.Year.ToString.Substring(2, 2) &
                Date.Now.Month.ToString.PadLeft(2, "0") &
                Date.Now.Day.ToString.PadLeft(2, "0") &
                Date.Now.Hour.ToString.PadLeft(2, "0") &
                Date.Now.Minute.ToString.PadLeft(2, "0")

        If row IsNot Nothing AndAlso campo IsNot Nothing Then
            Try
                row(campo) = user
            Catch ex As Exception
                Console.WriteLine("errore nel settare il campo " & ex.Message)
            End Try
        End If

        Return user
    End Function


    'prende l'username se presente altrimenti scrive -UNKNOWN- e aggiunge la data formato AAMMDDhhmm
    Shared Function RitornaNominativo(ByVal username As String, Optional ByVal conn As IDbConnection = Nothing) As String
        Dim dtUten As New DataTable
        Dim rowUten As DataRow = Nothing
        Dim nominativo As String = ""
        If conn Is Nothing Then
            conn = GetConnDb()
        End If

        If username.Trim.Length > 10 Then
            Try
                conn.Open()
                dtUten = New Query().CaricaUtenti(conn, True)
                If dtUten.Rows.Count > 1 Then 'significa ch ha inserito un utente
                    Console.WriteLine(username.Substring(0, username.Length - 10))
                    rowUten = dtUten.AsEnumerable().Where(Function(x) x("username") = username.Substring(0, username.Length - 10)).FirstOrDefault
                    If rowUten IsNot Nothing Then
                        nominativo = rowUten("nominativo").ToString
                    End If
                End If
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            Finally
                conn.Close()
            End Try
        End If
        Return nominativo
    End Function


    'CANCELLAZIONE-----------------------------------------------------------
    Private Shared Function Cancella(tabella As String, id As Integer, conn As MySqlConnection) As Boolean
        Try
            Dim command As New MySqlCommand With {
                .Connection = conn
            }
            command.CommandText = "UPDATE " + tabella + " SET 
                                   cancellato = @cancellato,
                                   uten_cance = @uten_cance
								   WHERE id  = @id"

            command.Parameters.AddWithValue("@cancellato", True)

            command.Parameters.AddWithValue("@uten_cance", UtenteDelMomento())

            command.Parameters.AddWithValue("@id", id)

            command.ExecuteNonQuery()

            command.Dispose()
        Catch ex As Exception
            MessageBox.Show("Impossibile completare l'operazione, contattare l'assistenza.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return False
        End Try

        Return True
    End Function
    Public Shared Function CancRigo(tabella As String, id As Integer, conn As MySqlConnection, box As Boolean) As Boolean
        If box Then
            If id <> 0 Then
                Dim res As DialogResult = MessageBox.Show("Vuoi cancellare questa registrazione?", "Cancellazione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                If res = DialogResult.OK Then
                    Return Cancella(tabella, id, conn)
                End If
            Else
                MessageBox.Show("Impossibile completare l'operazione" & Environment.NewLine & "poichè il dato non è memorizzato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Else
            If id <> 0 Then
                Return Cancella(tabella, id, conn)
            End If
        End If

        Return False
    End Function
End Class
