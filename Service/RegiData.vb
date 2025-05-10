Module RegiData
    'regimovi
    ReadOnly canc As Boolean = False
    Public Sub AggiornaAnagrafica(ByRef rowD As DataRow, conn As IDbConnection)
        Try

            If IsDBNull(rowD("cancellato")) = False AndAlso rowD("cancellato") = True Then
                If rowD.RowState <> DataRowState.Added AndAlso rowD.RowState <> DataRowState.Detached Then
                    CancRigo(conn, TabelleDatabase.tb_anagrafica, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                RegiAnagrafica(conn, True, TabelleDatabase.tb_anagrafica, rowD)
                Try
                    rowD.AcceptChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            ElseIf rowD.RowState = DataRowState.Modified Then
                RegiAnagrafica(conn, False, TabelleDatabase.tb_anagrafica, rowD)
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show("Errore durante la conferma:  " & ex.Message, "Errore...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub
    Private Sub RegiAnagrafica(ByVal conn As IDbConnection, ctrlimmi As Boolean, tabella As String, row As DataRow)
        Dim SQLstr As String
        ' MsgBox(tabella)
        Dim ChiudiConn As Boolean = False
        'MsgBox(tabella)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            ChiudiConn = True
        End If

        Dim Command As IDbCommand = conn.CreateCommand

        Try
            If ctrlimmi = True Then
                SQLstr = "INSERT INTO " & tabella & " (
                                                cancellato,  
                                                bloccato,
                                                tipo_anagr,
                                                ragi_socia,
                                                desc_recap, 
                                                uten_inser,
                                                uten_aggio,
                                                uten_cance)
                                           VALUES 
                                              (@cancellato,
                                               @bloccato,
                                               @tipo_anagr,
                                               @ragi_socia,
                                               @desc_recap, 
                                               @uten_inser,
                                               @uten_aggio,
                                               @uten_cance)"

            Else
                SQLstr = "UPDATE " & tabella & " SET 
                                               cancellato   = @cancellato,
                                               bloccato     = @bloccato,
                                               tipo_anagr   = @tipo_anagr,
                                               ragi_socia   = @ragi_socia,
                                               desc_recap   = @desc_recap, 
                                               
                                               uten_aggio   = @uten_aggio,
                                               uten_cance   = @uten_cance
                                               WHERE id     = @id"
            End If
            If Not ctrlimmi Then
                AggiungiParametro(Command, "@id", row("id"))
            Else
                AggiungiParametro(Command, "@uten_inser", Service.UtenteDelMomento(row, "uten_inser"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")
            AggiungiParametro(Command, "@tipo_anagr", row("tipo_anagr"))
            AggiungiParametro(Command, "@ragi_socia", row("ragi_socia"))
            AggiungiParametro(Command, "@desc_recap", row("desc_recap"))
            AggiungiParametro(Command, "@uten_aggio", Service.UtenteDelMomento(row, "uten_aggio"))
            AggiungiParametro(Command, "@uten_cance", "")

            EseguiQueryAssegnazioneID(Command, tabella, row)
            Command.Dispose()
        Catch ex As Exception
            'Log.Error(ex.Message, ex)
            MessageBox.Show(ex.Message.ToString)
            'sqlTran.Rollback()
        Finally
            If ChiudiConn Then
                conn.Close()
            End If
        End Try

    End Sub

    Public Sub AggiornaArticoli(ByRef rowD As DataRow, conn As IDbConnection)
        Try

            If IsDBNull(rowD("cancellato")) = False AndAlso rowD("cancellato") = True Then
                If rowD.RowState <> DataRowState.Added AndAlso rowD.RowState <> DataRowState.Detached Then
                    CancRigo(conn, TabelleDatabase.tb_articoli, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                RegiArticoli(conn, True, TabelleDatabase.tb_articoli, rowD)
                Try
                    rowD.AcceptChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            ElseIf rowD.RowState = DataRowState.Modified Then
                RegiArticoli(conn, False, TabelleDatabase.tb_articoli, rowD)
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show("Errore durante la conferma:  " & ex.Message, "Errore...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub
    Private Sub RegiArticoli(ByVal conn As IDbConnection, ctrlimmi As Boolean, tabella As String, row As DataRow)
        Dim SQLstr As String
        ' MsgBox(tabella)
        Dim ChiudiConn As Boolean = False
        'MsgBox(tabella)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            ChiudiConn = True
        End If

        Dim Command As IDbCommand = conn.CreateCommand

        Try
            If ctrlimmi = True Then
                SQLstr = "INSERT INTO " & tabella & " (
                                                cancellato,  
                                                bloccato, 
                                                desc_artic,
                                                prez_unita,
                                                unit_misur,
                                                quan_artic,
                                                quan_minim,
                                                uten_inser,
                                                uten_aggio,
                                                uten_cance)
                                           VALUES 
                                              (@cancellato,
                                               @bloccato, 
                                               @desc_artic,
                                               @prez_unita,
                                               @unit_misur,
                                               @quan_artic,
                                               @quan_minim,
                                               @uten_inser,
                                               @uten_aggio,
                                               @uten_cance)"

            Else
                SQLstr = "UPDATE " & tabella & " SET 
                                               cancellato   = @cancellato,
                                               bloccato     = @bloccato,
                                               desc_artic   = @desc_artic,
                                               prez_unita   = @prez_unita,
                                               unit_misur   = @unit_misur,
                                               quan_artic   = @quan_artic,
                                               quan_minim   = @quan_minim, 
                                               
                                               uten_aggio   = @uten_aggio,
                                               uten_cance   = @uten_cance
                                               WHERE id     = @id"
            End If
            If Not ctrlimmi Then
                AggiungiParametro(Command, "@id", row("id"))
            Else
                AggiungiParametro(Command, "@uten_inser", Service.UtenteDelMomento(row, "uten_inser"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")
            AggiungiParametro(Command, "@desc_artic", row("desc_artic"))
            AggiungiParametro(Command, "@prez_unita", row("prez_unita"))
            AggiungiParametro(Command, "@unit_misur", row("unit_misur"))
            AggiungiParametro(Command, "@quan_artic", row("quan_artic"))
            AggiungiParametro(Command, "@quan_minim", row("quan_minim"))
            AggiungiParametro(Command, "@uten_aggio", Service.UtenteDelMomento(row, "uten_aggio"))
            AggiungiParametro(Command, "@uten_cance", "")

            EseguiQueryAssegnazioneID(Command, tabella, row)
            Command.Dispose()
        Catch ex As Exception
            'Log.Error(ex.Message, ex)
            MessageBox.Show(ex.Message.ToString)
            'sqlTran.Rollback()
        Finally
            If ChiudiConn Then
                conn.Close()
            End If
        End Try

    End Sub



    Public Sub AggiornaInterventoTestata(ByRef rowD As DataRow, conn As IDbConnection)
        Try

            If IsDBNull(rowD("cancellato")) = False AndAlso rowD("cancellato") = True Then
                If rowD.RowState <> DataRowState.Added AndAlso rowD.RowState <> DataRowState.Detached Then
                    CancRigo(conn, TabelleDatabase.tb_intervento_testata, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                RegiInterventoTestata(conn, True, TabelleDatabase.tb_intervento_testata, rowD)
                Try
                    rowD.AcceptChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            ElseIf rowD.RowState = DataRowState.Modified Then
                RegiInterventoTestata(conn, False, TabelleDatabase.tb_intervento_testata, rowD)
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show("Errore durante la conferma:  " & ex.Message, "Errore...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub

    Private Sub RegiInterventoTestata(ByVal conn As IDbConnection, ctrlimmi As Boolean, tabella As String, row As DataRow)
        Dim SQLstr As String
        ' MsgBox(tabella)
        Dim ChiudiConn As Boolean = False
        'MsgBox(tabella)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            ChiudiConn = True
        End If

        Dim Command As IDbCommand = conn.CreateCommand

        Try
            If ctrlimmi = True Then
                SQLstr = "INSERT INTO " & tabella & " (
                                                cancellato,  
                                                bloccato,

                                                anno_inter, 
                                                nume_inter, 

                                                iniz_inter,
                                                fine_inter,

                                                desc_clien,

                                                cost_inter,
                                                prez_vendi,

                                                desc_lavor,

                                                uten_inser,
                                                uten_aggio,
                                                uten_cance)
                                           VALUES 
                                              (@cancellato,
                                               @bloccato,

                                               @anno_inter, 
                                               @nume_inter, 

                                               @iniz_inter,
                                               @fine_inter,

                                               @desc_clien,

                                               @cost_inter,
                                               @prez_vendi,

                                               @desc_lavor,

                                               @uten_inser,
                                               @uten_aggio,
                                               @uten_cance)"

            Else
                SQLstr = "UPDATE " & tabella & " SET 
                                               cancellato   = @cancellato,
                                               bloccato     = @bloccato,
                                               
                                               anno_inter   = @anno_inter, 
                                               nume_inter   = @nume_inter, 

                                               iniz_inter   = @iniz_inter,
                                               fine_inter   = @fine_inter,

                                               desc_clien   = @desc_clien,

                                               cost_inter   = @cost_inter,
                                               prez_vendi   = @prez_vendi,

                                               desc_lavor   = @desc_lavor,
                                               
                                               uten_aggio   = @uten_aggio,
                                               uten_cance   = @uten_cance
                                               WHERE id     = @id"
            End If
            If Not ctrlimmi Then
                AggiungiParametro(Command, "@id", row("id"))
            Else
                AggiungiParametro(Command, "@uten_inser", Service.UtenteDelMomento(row, "uten_inser"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")

            AggiungiParametro(Command, "@anno_inter", row("anno_inter"))
            AggiungiParametro(Command, "@nume_inter", row("nume_inter"))

            AggiungiParametro(Command, "@iniz_inter", row("iniz_inter"))
            AggiungiParametro(Command, "@fine_inter", row("fine_inter"))

            AggiungiParametro(Command, "@desc_clien", row("desc_clien"))

            AggiungiParametro(Command, "@cost_inter", row("cost_inter"))
            AggiungiParametro(Command, "@prez_vendi", row("prez_vendi"))

            AggiungiParametro(Command, "@desc_lavor", row("desc_lavor"))

            AggiungiParametro(Command, "@uten_aggio", Service.UtenteDelMomento(row, "uten_aggio"))
            AggiungiParametro(Command, "@uten_cance", "")

            EseguiQueryAssegnazioneID(Command, tabella, row)
            Command.Dispose()
        Catch ex As Exception
            'Log.Error(ex.Message, ex)
            MessageBox.Show(ex.Message.ToString)
            'sqlTran.Rollback()
        Finally
            If ChiudiConn Then
                conn.Close()
            End If
        End Try

    End Sub

    Public Sub AggiornaInterventoDettaglio(ByRef rowD As DataRow, conn As IDbConnection)
        Try

            If IsDBNull(rowD("cancellato")) = False AndAlso rowD("cancellato") = True Then
                If rowD.RowState <> DataRowState.Added AndAlso rowD.RowState <> DataRowState.Detached Then
                    CancRigo(conn, TabelleDatabase.tb_intervento_dettaglio, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                RegiInterventoDettaglio(conn, True, TabelleDatabase.tb_intervento_dettaglio, rowD)
                'Try
                '    rowD.AcceptChanges()
                'Catch ex As Exception
                '    Console.WriteLine(ex)
                'End Try
            ElseIf rowD.RowState = DataRowState.Modified Then
                RegiInterventoDettaglio(conn, False, TabelleDatabase.tb_intervento_dettaglio, rowD)
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show("Errore durante la conferma:  " & ex.Message, "Errore...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub

    Private Sub RegiInterventoDettaglio(ByVal conn As IDbConnection, ctrlimmi As Boolean, tabella As String, row As DataRow)
        Dim SQLstr As String
        ' MsgBox(tabella)
        Dim ChiudiConn As Boolean = False
        'MsgBox(tabella)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            ChiudiConn = True
        End If

        Dim Command As IDbCommand = conn.CreateCommand

        Try
            If ctrlimmi = True Then
                SQLstr = "INSERT INTO " & tabella & " (
                                                cancellato,  
                                                bloccato,

                                                anno_inter, 
                                                nume_inter, 

                                                desc_artic,
                                                quantita,
                                                prez_unita,

                                                uten_inser,
                                                uten_aggio,
                                                uten_cance)
                                           VALUES 
                                              (@cancellato,
                                               @bloccato,

                                               @anno_inter, 
                                               @nume_inter, 

                                               @desc_artic,
                                               @quantita,
                                               @prez_unita,

                                               @uten_inser,
                                               @uten_aggio,
                                               @uten_cance)"

            Else
                SQLstr = "UPDATE " & tabella & " SET 
                                               cancellato   = @cancellato,
                                               bloccato     = @bloccato,
                                               
                                               anno_inter   = @anno_inter, 
                                               nume_inter   = @nume_inter, 

                                               desc_artic   = @desc_artic,
                                               quantita     = @quantita,

                                               prez_unita   = @prez_unita, 
                                               
                                               uten_aggio   = @uten_aggio,
                                               uten_cance   = @uten_cance
                                               WHERE id     = @id"
            End If
            If Not ctrlimmi Then
                AggiungiParametro(Command, "@id", row("id"))
            Else
                AggiungiParametro(Command, "@uten_inser", Service.UtenteDelMomento(row, "uten_inser"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")

            AggiungiParametro(Command, "@anno_inter", row("anno_inter"))
            AggiungiParametro(Command, "@nume_inter", row("nume_inter"))

            AggiungiParametro(Command, "@desc_artic", row("desc_artic"))
            AggiungiParametro(Command, "@quantita", row("quantita"))

            AggiungiParametro(Command, "@prez_unita", row("prez_unita"))

            AggiungiParametro(Command, "@uten_aggio", Service.UtenteDelMomento(row, "uten_aggio"))
            AggiungiParametro(Command, "@uten_cance", "")

            EseguiQueryAssegnazioneID(Command, tabella, row)
            Command.Dispose()
        Catch ex As Exception
            'Log.Error(ex.Message, ex)
            MessageBox.Show(ex.Message.ToString)
            'sqlTran.Rollback()
        Finally
            If ChiudiConn Then
                conn.Close()
            End If
        End Try

    End Sub



    Public Sub AggiornaPagamentoDipendenti(ByRef rowD As DataRow, conn As IDbConnection)
        Try

            If IsDBNull(rowD("cancellato")) = False AndAlso rowD("cancellato") = True Then
                If rowD.RowState <> DataRowState.Added AndAlso rowD.RowState <> DataRowState.Detached Then
                    CancRigo(conn, TabelleDatabase.tb_pagamento_dipendente, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                RegiPagamentoDipendenti(conn, True, TabelleDatabase.tb_pagamento_dipendente, rowD)
                Try
                    rowD.AcceptChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            ElseIf rowD.RowState = DataRowState.Modified Then
                RegiPagamentoDipendenti(conn, False, TabelleDatabase.tb_pagamento_dipendente, rowD)
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show("Errore durante la conferma:  " & ex.Message, "Errore...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub
    Private Sub RegiPagamentoDipendenti(ByVal conn As IDbConnection, ctrlimmi As Boolean, tabella As String, row As DataRow)
        Dim SQLstr As String
        ' MsgBox(tabella)
        Dim ChiudiConn As Boolean = False
        'MsgBox(tabella)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            ChiudiConn = True
        End If

        Dim Command As IDbCommand = conn.CreateCommand

        Try
            If ctrlimmi = True Then
                SQLstr = "INSERT INTO " & tabella & " (
                                                cancellato,  
                                                bloccato, 
                                                desc_dipen, 
                                                data_pagam,
                                                impo_pagam, 
                                                desc_pagam,
                                                uten_inser,
                                                uten_aggio,
                                                uten_cance)
                                           VALUES 
                                              (@cancellato,
                                               @bloccato,
                                               @desc_dipen, 
                                               @data_pagam,
                                               @impo_pagam, 
                                               @desc_pagam,
                                               @uten_inser,
                                               @uten_aggio,
                                               @uten_cance)"

            Else
                SQLstr = "UPDATE " & tabella & " SET 
                                               cancellato   = @cancellato,
                                               bloccato     = @bloccato,
                                               desc_dipen   = @desc_dipen, 
                                               data_pagam   = @data_pagam,
                                               impo_pagam   = @impo_pagam, 
                                               desc_pagam   = @desc_pagam,
                                               
                                               uten_aggio   = @uten_aggio,
                                               uten_cance   = @uten_cance
                                               WHERE id     = @id"
            End If
            If Not ctrlimmi Then
                AggiungiParametro(Command, "@id", row("id"))
            Else
                AggiungiParametro(Command, "@uten_inser", Service.UtenteDelMomento(row, "uten_inser"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")
            AggiungiParametro(Command, "@desc_dipen", row("desc_dipen"))
            AggiungiParametro(Command, "@data_pagam", row("data_pagam"))
            AggiungiParametro(Command, "@impo_pagam", row("impo_pagam"))
            AggiungiParametro(Command, "@desc_pagam", row("desc_pagam"))
            AggiungiParametro(Command, "@uten_aggio", Service.UtenteDelMomento(row, "uten_aggio"))
            AggiungiParametro(Command, "@uten_cance", "")

            EseguiQueryAssegnazioneID(Command, tabella, row)
            Command.Dispose()
        Catch ex As Exception
            'Log.Error(ex.Message, ex)
            MessageBox.Show(ex.Message.ToString)
            'sqlTran.Rollback()
        Finally
            If ChiudiConn Then
                conn.Close()
            End If
        End Try

    End Sub


    Public Sub AggiornaAcquistoArticoli(ByRef rowD As DataRow, conn As IDbConnection)
        Try

            If IsDBNull(rowD("cancellato")) = False AndAlso rowD("cancellato") = True Then
                If rowD.RowState <> DataRowState.Added AndAlso rowD.RowState <> DataRowState.Detached Then
                    CancRigo(conn, TabelleDatabase.tb_acquisto_articoli, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                RegiAcquistoArticoli(conn, True, TabelleDatabase.tb_acquisto_articoli, rowD)
                Try
                    rowD.AcceptChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            ElseIf rowD.RowState = DataRowState.Modified Then
                RegiAcquistoArticoli(conn, False, TabelleDatabase.tb_acquisto_articoli, rowD)
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show("Errore durante la conferma:  " & ex.Message, "Errore...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub
    Private Sub RegiAcquistoArticoli(ByVal conn As IDbConnection, ctrlimmi As Boolean, tabella As String, row As DataRow)
        Dim SQLstr As String
        ' MsgBox(tabella)
        Dim ChiudiConn As Boolean = False
        'MsgBox(tabella)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            ChiudiConn = True
        End If

        Dim Command As IDbCommand = conn.CreateCommand

        Try
            If ctrlimmi = True Then
                SQLstr = "INSERT INTO " & tabella & " (
                                                cancellato,  
                                                bloccato, 
                                                desc_artic, 
                                                data_acqui,
                                                impo_acqui, 
                                                quan_acqui, 
                                                desc_pagam,
                                                uten_inser,
                                                uten_aggio,
                                                uten_cance)
                                           VALUES 
                                              (@cancellato,
                                               @desc_artic, 
                                               @data_acqui,
                                               @impo_acqui, 
                                               @quan_acqui, 
                                               @desc_pagam,
                                               @uten_inser,
                                               @uten_aggio,
                                               @uten_cance)"

            Else
                SQLstr = "UPDATE " & tabella & " SET 
                                               cancellato   = @cancellato,
                                               bloccato     = @bloccato,
                                               desc_artic   = @desc_artic, 
                                               data_acqui   = @data_acqui,
                                               impo_acqui   = @impo_acqui, 
                                               quan_acqui   = @quan_acqui, 
                                               desc_pagam   = @desc_pagam,
                                               
                                               uten_aggio   = @uten_aggio,
                                               uten_cance   = @uten_cance
                                               WHERE id     = @id"
            End If
            If Not ctrlimmi Then
                AggiungiParametro(Command, "@id", row("id"))
            Else
                AggiungiParametro(Command, "@uten_inser", Service.UtenteDelMomento(row, "uten_inser"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")
            AggiungiParametro(Command, "@desc_artic", row("desc_artic"))
            AggiungiParametro(Command, "@data_acqui", row("data_acqui"))
            AggiungiParametro(Command, "@impo_acqui", row("impo_acqui"))
            AggiungiParametro(Command, "@quan_acqui", row("quan_acqui"))
            AggiungiParametro(Command, "@desc_pagam", row("desc_pagam"))
            AggiungiParametro(Command, "@uten_aggio", Service.UtenteDelMomento(row, "uten_aggio"))
            AggiungiParametro(Command, "@uten_cance", "")

            EseguiQueryAssegnazioneID(Command, tabella, row)
            Command.Dispose()
        Catch ex As Exception
            'Log.Error(ex.Message, ex)
            MessageBox.Show(ex.Message.ToString)
            'sqlTran.Rollback()
        Finally
            If ChiudiConn Then
                conn.Close()
            End If
        End Try

    End Sub

    Public Sub AggiornaUtente(ByRef rowD As DataRow, conn As MySqlConnection)
        Try
            If IsDBNull(rowD("cancellato")) = False AndAlso rowD("cancellato") = True Then
                If rowD.RowState <> DataRowState.Added AndAlso rowD.RowState <> DataRowState.Detached AndAlso rowD("id") <> 0 Then
                    CancRigo(conn, TabelleDatabase.tb_utente, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                regiUtente(conn, True, TabelleDatabase.tb_utente, rowD)
            ElseIf rowD.RowState = DataRowState.Modified Then
                regiUtente(conn, False, TabelleDatabase.tb_utente, rowD)
            End If
        Catch ex As Exception
            MessageBox.Show("Errore durante la conferma: " & ex.Message, "Errore...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub
    Private Sub regiUtente(ByVal conn As MySqlConnection, ctrlimmi As Boolean, tabella As String, row As DataRow)
        Dim SQLstr As String
        ' MsgBox(tabella)
        Dim ChiudiConn As Boolean = False
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            ChiudiConn = True
        End If
        Dim Command = New MySqlCommand()
        Command.Connection = conn
        Try
            If ctrlimmi = True Then
                SQLstr = "INSERT INTO " & tabella & " (
                                               cancellato,
                                               bloccato,
                                               username,
                                               password, 
                                               nominativo,
                                               nickname,
                                               email,
                                               ctrl_acces,
                                               uten_inser,
                                               uten_aggio,
                                               uten_cance)
                                           VALUES 
                                              (@cancellato,
                                               @bloccato,
                                               @username,
                                               @password, 
                                               @nominativo,
                                               @nickname,
                                               @email,
                                               @ctrl_acces, 
                                               @uten_inser,
                                               @uten_aggio,
                                               @uten_cance)"

            Else
                SQLstr = "UPDATE " & tabella & " SET 
                                               cancellato = @cancellato,
                                               bloccato   = @bloccato,
                                               username   = @username,
                                               password   = @password, 
                                               nominativo = @nominativo,
                                               nickname   = @nickname,
                                               email      = @email,
                                               ctrl_acces = @ctrl_acces, 

                                        	   uten_aggio = @uten_aggio,
                                               uten_cance = @uten_cance
                                               WHERE id   = @id"
            End If
            If Not ctrlimmi Then
                Command.Parameters.AddWithValue("@id", row("id"))
            Else
                Command.Parameters.AddWithValue("@uten_inser", Service.UtenteDelMomento(row, "uten_inser"))
            End If
            Command.CommandText = SQLstr
            Command.Parameters.AddWithValue("@cancellato", canc)
            Command.Parameters.AddWithValue("@bloccato", " ")
            Command.Parameters.AddWithValue("@username", row("username"))
            Command.Parameters.AddWithValue("@password", row("password"))
            Command.Parameters.AddWithValue("@nominativo", row("nominativo"))
            Command.Parameters.AddWithValue("@nickname", row("nickname"))
            Command.Parameters.AddWithValue("@email", row("email"))
            Command.Parameters.AddWithValue("@ctrl_acces", row("ctrl_acces"))

            Command.Parameters.AddWithValue("@uten_aggio", Service.UtenteDelMomento(row, "uten_aggio"))
            Command.Parameters.AddWithValue("@uten_cance", "")

            EseguiQueryAssegnazioneID(Command, tabella, row)
            Command.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
            If ChiudiConn Then
                conn.Close()
            End If
        End Try
    End Sub

    Public Sub AggioraPersonalizzazione(ByRef rowD As DataRow, conn As MySqlConnection)
        Try
            If IsDBNull(rowD("cancellato")) = False AndAlso rowD("cancellato") = True Then
                If rowD.RowState <> DataRowState.Added AndAlso rowD.RowState <> DataRowState.Detached AndAlso rowD("id") <> 0 Then
                    CancRigo(conn, TabelleDatabase.tb_personalizzazione, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                regiPersonalizzazione(conn, True, TabelleDatabase.tb_personalizzazione, rowD)
            ElseIf rowD.RowState = DataRowState.Modified Then
                regiPersonalizzazione(conn, False, TabelleDatabase.tb_personalizzazione, rowD)
            End If
        Catch ex As Exception
            MessageBox.Show("Errore durante la conferma: " & ex.Message, "Errore...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub
    Private Sub regiPersonalizzazione(ByVal conn As MySqlConnection, ctrlimmi As Boolean, tabella As String, row As DataRow)
        Dim SQLstr As String
        ' MsgBox(tabella)
        Dim ChiudiConn As Boolean = False
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            ChiudiConn = True
        End If
        Dim Command = New MySqlCommand()
        Command.Connection = conn
        Try
            If ctrlimmi = True Then
                SQLstr = "INSERT INTO " & tabella & " (
                                               cancellato,
                                               bloccato,  

                                               perc_stamp,
                                               perc_excel,
                                               perc_logo,
                                               tema,

                                               uten_inser,
                                               uten_aggio,
                                               uten_cance
                                              )
                                           VALUES 
                                              (@cancellato,
                                               @bloccato,

                                               @perc_stamp,
                                               @perc_excel,
                                               @perc_logo,
                                               @tema,
 
                                               @uten_inser,
                                               @uten_aggio,
                                               @uten_cance)"

            Else
                SQLstr = "UPDATE " & tabella & " SET 
                                               cancellato = @cancellato,
                                               bloccato   = @bloccato,

                                               perc_stamp = @perc_stamp,
                                               perc_excel = @perc_excel,
                                               perc_logo  = @perc_logo,
                                               tema       = @tema,

                                        	   uten_aggio = @uten_aggio,
                                               uten_cance = @uten_cance
                                               WHERE id   = @id"
            End If
            If Not ctrlimmi Then
                Command.Parameters.AddWithValue("@id", row("id"))
            Else
                Command.Parameters.AddWithValue("@uten_inser", Service.UtenteDelMomento(row, "uten_inser"))
            End If
            Command.CommandText = SQLstr
            Command.Parameters.AddWithValue("@cancellato", canc)
            Command.Parameters.AddWithValue("@bloccato", " ")

            Command.Parameters.AddWithValue("@perc_stamp", row("perc_stamp"))
            Command.Parameters.AddWithValue("@perc_excel", row("perc_excel"))
            Command.Parameters.AddWithValue("@perc_logo", row("perc_logo"))
            Command.Parameters.AddWithValue("@tema", row("tema"))

            Command.Parameters.AddWithValue("@uten_aggio", Service.UtenteDelMomento(row, "uten_aggio"))
            Command.Parameters.AddWithValue("@uten_cance", "")

            EseguiQueryAssegnazioneID(Command, tabella, row)
            Command.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
            If ChiudiConn Then
                conn.Close()
            End If
        End Try
    End Sub

    'CANCELLAZIONE
    Public Sub CancRigo(ByVal conn As IDbConnection, ByVal tabella As String, ByVal id As Integer)
        Dim SQLstr As String
        Dim ChiudiConn As Boolean = False
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            ChiudiConn = True
        End If

        Dim Command As IDbCommand = conn.CreateCommand

        Try

            SQLstr = "UPDATE " & tabella & " SET 
                                             cancellato = @cancellato,
                                             uten_cance = @uten_cance
                                             WHERE id = @id"
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@id", id)
            AggiungiParametro(Command, "@cancellato", True)
            AggiungiParametro(Command, "@uten_cance", Service.UtenteDelMomento(Nothing, "uten_cance"))
            AggiungiParametro(Command, "@bloccato", " ")
            If Command.ExecuteNonQuery() = 0 Then
                MessageBox.Show("operazione non riuscita!", "errore....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Command.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
            If ChiudiConn Then
                conn.Close()
            End If
        End Try
    End Sub
End Module
