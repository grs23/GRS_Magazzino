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
            command.CommandText = "SELECT * FROM " & TabelleDatabase.tb_personalizzazione & "  WHERE cancellato != @cancellato "

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

    Public Function caricaPersonalizzazioneTema() As String
        Dim conn As IDbConnection = GetConnDb()
        Dim tema As String = "CHIARO"
        Dim rowPers As DataRow = CaricaPersonalizzazione(conn)
        If rowPers IsNot Nothing AndAlso rowPers("tema").ToString.Trim <> "" Then
            tema = rowPers("tema").ToString.Trim
        End If
        Return tema
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
            command.CommandText = "SELECT * FROM " & TabelleDatabase.tb_utente & "  WHERE cancellato != @cancellato "

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
        Dim dt As DataTable = CaricaUtenti(conn, "", "", False, AdminIncluso, GestoreIncluso)
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

    'Public Function CaricaRigoAnagrafica(conn As IDbConnection, tipo_anagr As String, ragi_socia As String, Optional desc_recap As String = "") As DataRow
    '    Dim dt As DataTable = CaricaAnagrafiche(conn, tipo_anagr, ragi_socia, desc_recap)
    '    If dt.Rows.Count > 0 Then
    '        Return dt.Rows(0)
    '    Else
    '        Return Nothing
    '    End If
    'End Function
    'Public Function CaricaAnagrafica(conn As IDbConnection, tipo_anagr As String, Optional ragi_socia As String = "", Optional desc_recap As String = "") As DataTable
    '    Dim dt As DataTable = CaricaAnagrafiche(conn, tipo_anagr, ragi_socia, desc_recap)
    '    Return dt
    'End Function

    'Private Function CaricaAnagrafiche(conn As IDbConnection, tipo_anagr As String, ragi_socia As String, desc_recap As String) As DataTable
    '    Dim dt As New DataTable
    '    Dim chiudiConn As Boolean = False
    '    Try
    '        If conn.State <> ConnectionState.Open Then
    '            chiudiConn = True
    '            conn.Open()
    '        End If

    '        Dim command As IDbCommand = conn.CreateCommand

    '        command.CommandText = "SELECT * FROM " & TabelleDatabase.tb_anagrafica & " WHERE cancellato = @cancellato "
    '        command.CommandText &= "AND tipo_anagr = @tipo_anagr "

    '        AggiungiParametro(command, "@cancellato", False)
    '        AggiungiParametro(command, "@tipo_anagr", tipo_anagr.Trim)

    '        If ragi_socia IsNot Nothing AndAlso ragi_socia <> "" Then
    '            command.CommandText &= "AND ragi_socia = @ragi_socia "
    '            AggiungiParametro(command, "@ragi_socia", ragi_socia.Trim)
    '        End If
    '        If desc_recap IsNot Nothing AndAlso desc_recap <> "" Then
    '            command.CommandText &= "AND desc_recap = @desc_recap "
    '            AggiungiParametro(command, "@desc_recap", desc_recap.Trim)
    '        End If
    '        Dim reader As IDataReader = command.ExecuteReader()

    '        dt.Load(reader)
    '    Catch ex As Exception
    '        Console.WriteLine("Errore : " & ex.Message)
    '    Finally
    '        If chiudiConn Then
    '            conn.Close()
    '        End If
    '    End Try

    '    Return dt
    'End Function
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

            command.CommandText = "SELECT * FROM " & TabelleDatabase.tb_articoli & "  WHERE cancellato = @cancellato "

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



    Public Function CaricaRigoInterventoTestata(conn As IDbConnection,
                                                anno_inter As Integer, nume_inter As Integer) As DataRow
        Dim dt As DataTable = CaricaInterventi(conn, anno_inter, nume_inter, "", Nothing, Nothing)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        Else
            Return Nothing
        End If
    End Function
    Public Function CaricaInterventiLista(conn As IDbConnection,
                                          Optional anno_inter As Integer = 0, Optional desc_clien As String = "",
                                          Optional da_data_inizi As Date = Nothing, Optional a_data_inizi As Date = Nothing) As DataTable
        Dim dt As DataTable = CaricaInterventi(conn, anno_inter, 0, desc_clien, da_data_inizi, a_data_inizi)
        Return dt
    End Function

    Private Function CaricaInterventi(conn As IDbConnection,
                                      anno_inter As Integer, nume_inter As Integer,
                                      desc_clien As String, da_data_inizi As Date, a_data_inizi As Date) As DataTable
        Dim dt As New DataTable
        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand

            command.CommandText = "SELECT * FROM " & TabelleDatabase.tb_intervento_testata & " WHERE cancellato = @cancellato "

            AggiungiParametro(command, "@cancellato", False)

            If anno_inter <> 0 Then
                command.CommandText &= "AND anno_inter = @anno_inter "
                AggiungiParametro(command, "@anno_inter", anno_inter)
            End If

            If nume_inter <> 0 Then
                command.CommandText &= "AND nume_inter = @nume_inter "
                AggiungiParametro(command, "@nume_inter", nume_inter)
            End If

            If desc_clien IsNot Nothing AndAlso desc_clien <> "" Then
                command.CommandText &= "AND desc_clien = @desc_clien "
                AggiungiParametro(command, "@desc_clien", desc_clien.Trim)
            End If

            If da_data_inizi <> Nothing Then
                command.CommandText &= "AND data_inizi >= @data_inizi "
                AggiungiParametro(command, "@data_inizi", da_data_inizi)
            End If

            If a_data_inizi <> Nothing Then
                command.CommandText &= "AND data_inizi <= @data_inizi "
                AggiungiParametro(command, "@data_inizi", a_data_inizi)
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

    Public Function CaricaRigoInterventoDettaglio(conn As IDbConnection,
                                                anno_inter As Integer, nume_inter As Integer, desc_artic As String) As DataRow
        Dim dt As DataTable = CaricaInterventiDettagli(conn, anno_inter, nume_inter, desc_artic)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        Else
            Return Nothing
        End If
    End Function
    Public Function CaricaInterventiDettagliLista(conn As IDbConnection,
                                          Optional anno_inter As Integer = 0, Optional nume_inter As Integer = 0) As DataTable
        Dim dt As DataTable = CaricaInterventiDettagli(conn, anno_inter, nume_inter, "")
        Return dt
    End Function

    Private Function CaricaInterventiDettagli(conn As IDbConnection,
                                      anno_inter As Integer, nume_inter As Integer,
                                      desc_artic As String) As DataTable
        Dim dt As New DataTable
        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand

            command.CommandText = "SELECT * FROM " & TabelleDatabase.tb_intervento_dettaglio & " WHERE cancellato = @cancellato "

            AggiungiParametro(command, "@cancellato", False)

            If anno_inter <> 0 Then
                command.CommandText &= "AND anno_inter = @anno_inter "
                AggiungiParametro(command, "@anno_inter", anno_inter)
            End If

            If nume_inter <> 0 Then
                command.CommandText &= "AND nume_inter = @nume_inter "
                AggiungiParametro(command, "@nume_inter", nume_inter)
            End If

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

    Public Function CalcolaProgressivoInterventiAnnuale(conn As IDbConnection,
                                      anno_inter As Integer) As Integer
        Dim dt As New DataTable
        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand

            command.CommandText = "SELECT MAX(nume_inter) AS max FROM " & TabelleDatabase.tb_intervento_testata &
                                  " WHERE cancellato = @cancellato AND anno_inter = @anno_inter"

            AggiungiParametro(command, "@cancellato", False)
            AggiungiParametro(command, "@anno_inter", anno_inter)

            Dim reader As IDataReader = command.ExecuteReader()

            dt.Load(reader)
        Catch ex As Exception
            Console.WriteLine("Errore : " & ex.Message)
        Finally
            If chiudiConn Then
                conn.Close()
            End If
        End Try
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("max")) Then
            Return dt.Rows(0)("max") + 1
        Else
            Return 1
        End If
    End Function



    Public Function CaricaRiepilogoPagamentoDipendenti(conn As IDbConnection, ByVal DallData As Date, ByVal AllaData As Date) As DataTable
        Dim dt As New DataTable
        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand

            command.CommandText = "SELECT pagadipe.*, pagadipe.desc_dipen as dipendente, sum(pagadipe.impo_pagam) as importopagamento, pagadipe.data_pagam "
            command.CommandText &= "FROM " & TabelleDatabase.tb_pagamento_dipendente & "  as pagadipe "
            command.CommandText &= "WHERE pagadipe.cancellato = @cancellato "
            command.CommandText &= "AND pagadipe.data_pagam BETWEEN date(@DallData) AND date(@AllaData) "
            command.CommandText &= "GROUP BY pagadipe.desc_dipen "
            command.CommandText &= "ORDER BY pagadipe.data_pagam DESC, pagadipe.desc_dipen"

            AggiungiParametro(command, "@cancellato", False)
            AggiungiParametro(command, "@DallData", DallData.Date)
            AggiungiParametro(command, "@AllaData", AllaData.Date)

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



    Public Function CaricaRiepilogoAcquistoMateriali(conn As IDbConnection, ByVal DallData As Date, ByVal AllaData As Date) As DataTable
        Dim dt As New DataTable
        Dim chiudiConn As Boolean = False
        Try
            If conn.State <> ConnectionState.Open Then
                chiudiConn = True
                conn.Open()
            End If

            Dim command As IDbCommand = conn.CreateCommand

            command.CommandText = "SELECT acquarti.* "
            command.CommandText &= "FROM " & TabelleDatabase.tb_acquisto_articoli & "  as acquiarti "
            command.CommandText &= "WHERE acquiarti.cancellato = @cancellato "
            command.CommandText &= "AND acquiarti.data_acqui BETWEEN date(@DallData) AND date(@AllaData) "
            command.CommandText &= "ORDER BY acquiarti.data_acqui DESC, acquiarti.desc_artic"

            AggiungiParametro(command, "@cancellato", False)
            AggiungiParametro(command, "@DallData", DallData.Date)
            AggiungiParametro(command, "@AllaData", AllaData.Date)

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
