﻿Module RegiData
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
                                                nome,
                                                cognome,
                                                telefono,
                                                cellulare,
                                                indirizzo,
                                                note,
                                                email,
                                                iban,
                                                uten_inser,
                                                uten_aggio,
                                                uten_cance)
                                           VALUES 
                                              (@cancellato,
                                               @bloccato,
                                               @nome,
                                               @cognome,
                                               @telefono,
                                               @cellulare,
                                               @indirizzo,
                                               @note,
                                               @email,
                                               @iban,
                                               @uten_inser,
                                               @uten_aggio,
                                               @uten_cance)"

            Else
                SQLstr = "UPDATE " & tabella & " SET 
                                               cancellato   = @cancellato,
                                               bloccato     = @bloccato,
                                               nome         = @nome,
                                               cognome      = @cognome,
                                               telefono     = @telefono,
                                               cellulare    = @cellulare,
                                               indirizzo    = @indirizzo,
                                               note         = @note,
                                               email        = @email,
                                               iban         = @iban,
                                               
                                               uten_aggio   = @uten_aggio,
                                               uten_cance   = @uten_cance
                                               WHERE id     = @id"
            End If
            If Not ctrlimmi Then
                AggiungiParametro(Command, "@id", row("id"))
            Else
                AggiungiParametro(Command, "@uten_inse", Service.UtenteDelMomento(row, "uten_inse"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")
            AggiungiParametro(Command, "@nome", row("nome"))
            AggiungiParametro(Command, "@cognome", row("cognome"))
            AggiungiParametro(Command, "@telefono", row("telefono"))
            AggiungiParametro(Command, "@cellulare", row("cellulare"))
            AggiungiParametro(Command, "@indirizzo", row("indirizzo"))
            AggiungiParametro(Command, "@note", row("note"))
            AggiungiParametro(Command, "@email", row("email"))
            AggiungiParametro(Command, "@iban", row("iban"))
            AggiungiParametro(Command, "@uten_aggi", Service.UtenteDelMomento(row, "uten_aggi"))
            AggiungiParametro(Command, "@uten_canc", "")

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
                    CancRigo(conn, TabelleDatabase.tb_anagrafica, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                RegiArticoli(conn, True, TabelleDatabase.tb_anagrafica, rowD)
                Try
                    rowD.AcceptChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            ElseIf rowD.RowState = DataRowState.Modified Then
                RegiArticoli(conn, False, TabelleDatabase.tb_anagrafica, rowD)
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
                AggiungiParametro(Command, "@uten_inse", Service.UtenteDelMomento(row, "uten_inse"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")
            AggiungiParametro(Command, "@desc_artic", row("desc_artic"))
            AggiungiParametro(Command, "@prez_unita", row("prez_unita"))
            AggiungiParametro(Command, "@unit_misur", row("unit_misur"))
            AggiungiParametro(Command, "@quan_artic", row("quan_artic"))
            AggiungiParametro(Command, "@quan_minim", row("quan_minim"))
            AggiungiParametro(Command, "@uten_aggi", Service.UtenteDelMomento(row, "uten_aggi"))
            AggiungiParametro(Command, "@uten_canc", "")

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
                                               
                                               uten_aggio   = @uten_aggio,
                                               uten_cance   = @uten_cance
                                               WHERE id     = @id"
            End If
            If Not ctrlimmi Then
                AggiungiParametro(Command, "@id", row("id"))
            Else
                AggiungiParametro(Command, "@uten_inse", Service.UtenteDelMomento(row, "uten_inse"))
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

            AggiungiParametro(Command, "@uten_aggi", Service.UtenteDelMomento(row, "uten_aggi"))
            AggiungiParametro(Command, "@uten_canc", "")

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
                Try
                    rowD.AcceptChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
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
                AggiungiParametro(Command, "@uten_inse", Service.UtenteDelMomento(row, "uten_inse"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")

            AggiungiParametro(Command, "@anno_inter", row("anno_inter"))
            AggiungiParametro(Command, "@nume_inter", row("nume_inter"))

            AggiungiParametro(Command, "@desc_artic", row("desc_artic"))
            AggiungiParametro(Command, "@quantita", row("quantita"))

            AggiungiParametro(Command, "@prez_unita", row("prez_unita"))

            AggiungiParametro(Command, "@uten_aggi", Service.UtenteDelMomento(row, "uten_aggi"))
            AggiungiParametro(Command, "@uten_canc", "")

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
                    CancRigo(conn, TabelleDatabase.tb_anagrafica, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                RegiPagamentoDipendenti(conn, True, TabelleDatabase.tb_anagrafica, rowD)
                Try
                    rowD.AcceptChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            ElseIf rowD.RowState = DataRowState.Modified Then
                RegiPagamentoDipendenti(conn, False, TabelleDatabase.tb_anagrafica, rowD)
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
                AggiungiParametro(Command, "@uten_inse", Service.UtenteDelMomento(row, "uten_inse"))
            End If
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@cancellato", canc)
            AggiungiParametro(Command, "@bloccato", " ")
            AggiungiParametro(Command, "@desc_dipen", row("desc_dipen"))
            AggiungiParametro(Command, "@data_pagam", row("data_pagam"))
            AggiungiParametro(Command, "@impo_pagam", row("impo_pagam"))
            AggiungiParametro(Command, "@desc_pagam", row("desc_pagam"))
            AggiungiParametro(Command, "@uten_aggi", Service.UtenteDelMomento(row, "uten_aggi"))
            AggiungiParametro(Command, "@uten_canc", "")

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
                                             uten_canc = @uten_canc
                                             WHERE id = @id"
            Command.CommandText = SQLstr
            AggiungiParametro(Command, "@id", id)
            AggiungiParametro(Command, "@cancellato", True)
            AggiungiParametro(Command, "@uten_canc", Service.UtenteDelMomento(Nothing, "uten_canc"))
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
