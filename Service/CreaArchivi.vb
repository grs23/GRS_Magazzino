Module CreaArchivi
    Sub CreaArchivi(ByVal msg As Boolean)
        Dim motore As String = "ENGINE = MyIsam"
        Dim Conn As IDbConnection = GetConnDb()
        Dim command As IDbCommand = Conn.CreateCommand


        Try
            Conn.Open()

            'ANAGRAFICA 
            command.CommandText = "CREATE TABLE IF NOT EXISTS grs_anagrafi (
                                                id SERIAL,
                                                cancellato      BOOLEAN DEFAULT FALSE,
                                                uten_inser      VARCHAR(30) DEFAULT '', 
                                        		uten_aggio      VARCHAR(30) DEFAULT '',
                                                uten_cance      VARCHAR(30) DEFAULT '',

                                                tipo_anagr      VARCHAR(  1) DEFAULT '',
                                                ragi_socia      VARCHAR(100) DEFAULT '',
                                                desc_recap      VARCHAR(100) DEFAULT '' 
                                                ) " & motore

            command.ExecuteNonQuery()

            'PAGAMENTO DIPENDENTE
            command.CommandText = "CREATE TABLE IF NOT EXISTS grs_pagadipe (
                                                id SERIAL,
                                                cancellato      BOOLEAN DEFAULT FALSE,
                                                bloccato        VARCHAR(30) DEFAULT '', 
                                                uten_inser      VARCHAR(30) DEFAULT '', 
                                        		uten_aggio      VARCHAR(30) DEFAULT '',
                                                uten_cance      VARCHAR(30) DEFAULT '',

                                                desc_dipen      VARCHAR(100) DEFAULT '', 
                                                data_pagam      DATE,
                                                impo_pagam      NUMERIC(11,2) DEFAULT 0,

                                                desc_pagam      VARCHAR(100) DEFAULT ''
                                                ) " & motore

            command.ExecuteNonQuery()

            'ARTICOLI 
            command.CommandText = "CREATE TABLE IF NOT EXISTS grs_articoli (
                                                id SERIAL,
                                                cancellato      BOOLEAN DEFAULT FALSE,
                                                bloccato        VARCHAR(30) DEFAULT '', 
                                                uten_inser      VARCHAR(30) DEFAULT '', 
                                        		uten_aggio      VARCHAR(30) DEFAULT '',
                                                uten_cance      VARCHAR(30) DEFAULT '', 

                                                desc_artic      VARCHAR(100) DEFAULT '',
                                                prez_unita      NUMERIC(5,2) DEFAULT 0,
                                                unit_misur      VARCHAR(  2) DEFAULT '',
                                                quan_minim      INTEGER      DEFAULT 0
                                                ) " & motore

            command.ExecuteNonQuery()

            'ACQUISTO ARTICOLI
            command.CommandText = "CREATE TABLE IF NOT EXISTS grs_acquarti (
                                                id SERIAL,
                                                cancellato      BOOLEAN DEFAULT FALSE,
                                                bloccato        VARCHAR(30) DEFAULT '', 
                                                uten_inser      VARCHAR(30) DEFAULT '', 
                                        		uten_aggio      VARCHAR(30) DEFAULT '',
                                                uten_cance      VARCHAR(30) DEFAULT '',

                                                desc_artic      VARCHAR(100) DEFAULT '', 
                                                data_acqui      DATE,
                                                impo_acqui      NUMERIC(11,2) DEFAULT 0,
                                                quan_acqui      INTEGER      DEFAULT 0,

                                                desc_pagam      VARCHAR(100) DEFAULT ''
                                                ) " & motore

            command.ExecuteNonQuery()

            'GIACENZA ARTICOLI
            command.CommandText = "CREATE TABLE IF NOT EXISTS grs_giacarti (
                                                id SERIAL,
                                                cancellato      BOOLEAN DEFAULT FALSE,
                                                bloccato        VARCHAR(30) DEFAULT '', 
                                                uten_inser      VARCHAR(30) DEFAULT '', 
                                        		uten_aggio      VARCHAR(30) DEFAULT '',
                                                uten_cance      VARCHAR(30) DEFAULT '',

                                                desc_artic      VARCHAR(100) DEFAULT '',
                                                quan_giace      INTEGER      DEFAULT 0,

                                                desc_pagam      VARCHAR(100) DEFAULT ''
                                                ) " & motore

            command.ExecuteNonQuery()

            'INTERVENTO - TESTATA
            command.CommandText = "CREATE TABLE IF NOT EXISTS grs_intetest (
                                                id SERIAL,
                                                cancellato      BOOLEAN DEFAULT FALSE,
                                                bloccato        VARCHAR(30) DEFAULT '', 
                                                uten_inser      VARCHAR(30) DEFAULT '', 
                                        		uten_aggio      VARCHAR(30) DEFAULT '',
                                                uten_cance      VARCHAR(30) DEFAULT '',

                                                anno_inter      INTEGER      DEFAULT 0, 
                                                nume_inter      INTEGER      DEFAULT 0, 

                                                iniz_inter      DATE,
                                                fine_inter      DATE,

                                                desc_clien      VARCHAR(100) DEFAULT '',

                                                cost_inter      NUMERIC(11,2) DEFAULT 0,
                                                prez_vendi      NUMERIC(11,2) DEFAULT 0

                                                desc_lavor      VARCHAR(300) DEFAULT '',
                                                ) " & motore

            command.ExecuteNonQuery()

            'INTERVENTO - DETTAGLIO
            command.CommandText = "CREATE TABLE IF NOT EXISTS grs_intedett (
                                                id SERIAL,
                                                cancellato      BOOLEAN DEFAULT FALSE,
                                                bloccato        VARCHAR(30) DEFAULT '', 
                                                uten_inser      VARCHAR(30) DEFAULT '', 
                                        		uten_aggio      VARCHAR(30) DEFAULT '',
                                                uten_cance      VARCHAR(30) DEFAULT '',

                                                anno_inter      INTEGER      DEFAULT 0, 
                                                nume_inter      INTEGER      DEFAULT 0, 

                                                desc_artic      VARCHAR(100) DEFAULT '',
                                                quan_minim      INTEGER      DEFAULT 0,
                                                prez_unita      NUMERIC(5,2) DEFAULT 0
                                                ) " & motore

            command.ExecuteNonQuery()


            'CREAZIONE TABELLE PREDEFINITE

            command.Dispose()
        Catch ex As Exception
            'Log.Error(ex.Message, ex)
            MessageBox.Show(ex.Message.ToString)
        Finally
            Conn.Close()
        End Try
        If msg Then
            MsgBox("creazione ultimata")
        End If
    End Sub

    Sub CreaArchiviUtenti()
        Dim motore As String = "ENGINE = MyIsam"
        Dim conn As IDbConnection = GetConnDb()
        Dim SQLstr As String = ""
        Dim command As IDbCommand = conn.CreateCommand

        Try
            conn.Open()

            command.CommandText = " CREATE TABLE IF NOT EXISTS grsuten (
                                         id 		      SERIAL,  
                                         cancellato       BOOLEAN DEFAULT FALSE,  
                                         bloccato         VARCHAR(30) DEFAULT '',

                                         username         VARCHAR(20) DEFAULT '',  
                                         password         VARCHAR(20) DEFAULT '', 
                                         nickname         VARCHAR(30) DEFAULT '',  
                                         nominativo       VARCHAR(40) DEFAULT '', 
                                         email            VARCHAR(60) DEFAULT '',   
                                         ctrl_acces       BOOLEAN DEFAULT FALSE, 

        	                             uten_inser       VARCHAR(30) DEFAULT '',   
        	                             uten_aggio       VARCHAR(30) DEFAULT '',   
        	                             uten_cance       VARCHAR(30) DEFAULT ''  
                                        )"
            command.ExecuteNonQuery()

            'Creazione Utente Admin

            Dim rigoUten As DataRow = New Query().CaricaUtente(conn, "ADMIN", "ADMIN", True)

            If rigoUten.RowState <> DataRowState.Unchanged Then
                AzzeraRigo(rigoUten, True)
                Try
                    rigoUten("username") = "ADMIN"
                    rigoUten("password") = "ADMIN"
                    rigoUten("ruolo") = 0
                    rigoUten("nickname") = "GRS"
                    rigoUten("nominativo") = "GRS"
                    rigoUten("email") = "assistenza@si-solinfo.it"
                    rigoUten("ctrl_acces") = False

                    'UtentiModi.AggiornaUten(rigoUten, ConnString)
                    MessageBox.Show("MANCA UtentiModi.AggiornaUten")
                Catch ex As Exception
                End Try
            End If


            ''  NomeDB = "gedolgut" 'utente loggato
            'Dim gedolgut As String = "gedolgut"
            'SQLstr = "CREATE TABLE IF NOT EXISTS " & gedolgut & "  (
            '                                    id         SERIAL,  
            '                                    ctrl_aggio BOOLEAN DEFAULT FALSE,  
            '                                    desc_aggio VARCHAR(200)
            '                                    )" & motore
            'command.CommandText = SQLstr
            'command.ExecuteNonQuery()

            command.CommandText = " CREATE TABLE IF NOT EXISTS grs_pers (
                                         id 		      SERIAL,  
                                         cancellato       BOOLEAN DEFAULT FALSE, 

                                         bloccato         VARCHAR(30) DEFAULT '',
                                         
                                         perc_stamp       VARCHAR(20) DEFAULT '',  
                                         perc_excel       VARCHAR(20) DEFAULT '',  
                                         perc_logo        VARCHAR(20) DEFAULT '',

        	                             uten_inser       VARCHAR(30) DEFAULT '',   
        	                             uten_aggio       VARCHAR(30) DEFAULT '',   
        	                             uten_cance       VARCHAR(30) DEFAULT ''  
                                        )"
            command.ExecuteNonQuery()

            'Creazione Personalizzazione

            Dim rigoPers As DataRow = New Query().CaricaPersonalizzazione(conn)

            If rigoPers.RowState <> DataRowState.Unchanged Then
                AzzeraRigo(rigoPers, True)
                Try
                    rigoPers("perc_stamp") = "ADMIN"
                    rigoPers("perc_excel") = "ADMIN"
                    rigoPers("perc_logo") = ""

                    'UtentiModi.AggiornaUten(rigoUten, ConnString)
                    MessageBox.Show("MANCA UtentiModi.AggiornaPersonalizzazione")
                Catch ex As Exception
                End Try
            End If

            command.Dispose()
        Catch ex As Exception
            'Log.Error(ex.Message, ex)
            MessageBox.Show(ex.Message.ToString)
        Finally
            conn.Close()
        End Try
    End Sub
End Module
