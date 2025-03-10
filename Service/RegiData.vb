Module RegiData
    'regimovi
    ReadOnly canc As Boolean = False
    Public Sub AggiornaAnagrafica(ByRef rowD As DataRow, conn As IDbConnection)
        Dim tabella As String = "grsanag"
        Try

            If IsDBNull(rowD("cancellato")) = False AndAlso rowD("cancellato") = True Then
                If rowD.RowState <> DataRowState.Added AndAlso rowD.RowState <> DataRowState.Detached Then
                    CancRigo(conn, tabella, rowD("id"))
                End If
            ElseIf rowD.RowState = DataRowState.Added OrElse rowD.RowState = DataRowState.Detached Then
                regiAnagrafica(conn, True, tabella, rowD)
                Try
                    rowD.AcceptChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            ElseIf rowD.RowState = DataRowState.Modified Then
                regiAnagrafica(conn, False, tabella, rowD)
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
