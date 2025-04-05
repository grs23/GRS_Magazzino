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

    Public Function CaricaRigoAnagrafica(conn As IDbConnection, tipo_anagr As String, ragi_socia As String, Optional desc_recap As String = "") As DataRow
        Dim dt As DataTable = CaricaAnagrafiche(conn, tipo_anagr, ragi_socia, desc_recap)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        Else
            Return Nothing
        End If
    End Function
    Public Function CaricaAnagrafica(conn As IDbConnection, tipo_anagr As String, Optional ragi_socia As String = "", Optional desc_recap As String = "") As DataTable
        Dim dt As DataTable = CaricaAnagrafiche(conn, tipo_anagr, ragi_socia, desc_recap)
        Return dt
    End Function

    Private Function CaricaAnagrafiche(conn As IDbConnection, tipo_anagr As String, ragi_socia As String, desc_recap As String) As DataTable
        Dim dt As New DataTable
        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand

            command.CommandText = "SELECT * FROM grsanag WHERE cancellato = @cancellato "
            command.CommandText &= "AND tipo_anagr = @tipo_anagr "

            AggiungiParametro(command, "@cancellato", False)
            AggiungiParametro(command, "@tipo_anagr", tipo_anagr.Trim)

            If ragi_socia IsNot Nothing AndAlso ragi_socia <> "" Then
                command.CommandText &= "AND ragi_socia = @ragi_socia "
                AggiungiParametro(command, "@ragi_socia", ragi_socia.Trim)
            End If
            If desc_recap IsNot Nothing AndAlso desc_recap <> "" Then
                command.CommandText &= "AND desc_recap = @desc_recap "
                AggiungiParametro(command, "@desc_recap", desc_recap.Trim)
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
    Public Function CaricaRigoInventario(conn As IDbConnection, desc_artic As String, Optional quant_artic As Decimal = Nothing) As DataRow
        Dim dt As DataTable = CaricaInventario(conn, desc_artic)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        Else
            Return Nothing
        End If
    End Function
    Public Function CaricaInventario(conn As IDbConnection, Optional desc_artic As String = "", Optional quant_artic As Decimal = Nothing) As DataTable
        Dim dt As DataTable = CaricaInventario(conn, desc_artic)
        Return dt
    End Function

    Private Function CaricaInventario(conn As IDbConnection, desc_artic As String) As DataTable
        Dim dt As New DataTable
        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand

            command.CommandText = "SELECT * FROM grs_articoli WHERE cancellato = @cancellato "

            AggiungiParametro(command, "@cancellato", False)

            If desc_artic IsNot Nothing AndAlso desc_artic <> "" Then
                command.CommandText &= "AND desc_artic = @desc_artic "
                AggiungiParametro(command, "@desc_artic", desc_artic.Trim)
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
