Public Class Query

    Public Function CaricaPersonalizzazione(conn As IDbConnection) As DataRow
        Dim row As DataRow
        Dim dt As New DataTable

        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand
            command.Connection = conn
            command.CommandText = "SELECT * FROM grspers WHERE cancellato != @cancellato "

            AggiungiParametro(command, "@cancellato", True)
            Dim reader As IDataReader = command.ExecuteReader()

            dt.Load(reader)
            reader.Close()
            reader.Dispose()
        Catch ex As Exception
            Console.WriteLine("Errore pers: " & ex.Message)
        Finally
            If chiudiConn Then
                conn.Close()
            End If
        End Try

        If dt.Rows.Count > 0 Then
            row = dt.Rows(0)
        Else
            row = dt.NewRow
            row("cancellato") = False
        End If
        Return row
    End Function

    ''Sezione Utenti
    Private Function CaricaUtenti(conn As IDbConnection, Optional username As String = "", Optional password As String = "",
                                  Optional Limit1 As Boolean = False, Optional AdminIncluso As Boolean = False, Optional GestoreIncluso As Boolean = True) As DataTable
        Dim dt As New DataTable

        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand
            command.Connection = conn
            command.CommandText = "SELECT * FROM grsuten WHERE cancellato != @cancellato "

            AggiungiParametro(command, "@cancellato", True)

            If username.Trim <> "" Then
                command.CommandText &= "AND username = @username "
                AggiungiParametro(command, "@username", username)
            End If

            If password IsNot Nothing AndAlso password <> "" Then
                command.CommandText &= "AND password = @password "
                AggiungiParametro(command, "@password", password)
            End If

            If AdminIncluso = False Then
                command.CommandText &= "AND username != 'ADMIN' "
            End If

            If GestoreIncluso = False Then
                command.CommandText &= "AND ctrl_ammin = false "
            End If

            If Limit1 = True Then
                command.CommandText &= " LIMIT 1"
            End If
            Dim reader As IDataReader = command.ExecuteReader()

            dt.Load(reader)
            reader.Close()
            reader.Dispose()
        Catch ex As Exception
            Console.WriteLine("Errore idlg: " & ex.Message)
        Finally
            If chiudiConn Then
                conn.Close()
            End If
        End Try

        Return dt.Copy
    End Function
    Public Function CaricaUtenti(conn As IDbConnection, Optional AdminIncluso As Boolean = False, Optional GestoreIncluso As Boolean = True) As DataTable
        Dim dt As DataTable = CaricaUtenti(conn, Nothing, Nothing, False, AdminIncluso, GestoreIncluso)
        Return dt
    End Function

    Public Function CaricaUtente(conn As IDbConnection, username As String, password As String, Optional AdminIncluso As Boolean = False, Optional GestoreIncluso As Boolean = True) As DataRow
        Dim row As DataRow
        Dim dt As DataTable = CaricaUtenti(conn, username, password, True, AdminIncluso, GestoreIncluso)
        If dt.Rows.Count > 0 Then
            row = dt.Rows(0)
        Else
            row = dt.NewRow
            row("cancellato") = False
        End If
        Return row
    End Function

    Public Function CaricaAnagrafica(conn As IDbConnection, Optional nome As String = "", Optional cognome As String = "", Optional telefono As String = "") As DataTable
        Dim dt As New DataTable
        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand

            command.CommandText = "SELECT * FROM grsanag WHERE cancellato = @cancellato "

            AggiungiParametro(command, "@cancellato", False)
            If nome.Trim <> "" Then
                command.CommandText &= "AND nome = @nome "
                AggiungiParametro(command, "@nome", nome.Trim)
            End If
            If cognome IsNot Nothing AndAlso cognome <> "" Then
                command.CommandText &= "AND cognome = @cognome "
                AggiungiParametro(command, "@cognome", cognome.Trim)
            End If
            If telefono IsNot Nothing AndAlso telefono <> "" Then
                command.CommandText &= "AND telefono = @telefono "
                AggiungiParametro(command, "@telefono", telefono.Trim)
            End If
            Dim reader As IDataReader = command.ExecuteReader()

            dt.Load(reader)
        Catch ex As Exception
            Console.WriteLine("Errore : " & ex.Message)
        Finally
            If chiudiConn Then
                conn.Close()
            End If
        End Try

        Return dt
    End Function
End Class
