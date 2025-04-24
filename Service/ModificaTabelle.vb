Public Class ModificaTabelle
    Shared Sub Modifica(Optional ByVal ctrlbool As Boolean = False)
        Dim conn As MySqlConnection = GetConnDb()
        If conn IsNot Nothing Then
            Dim command As New MySqlCommand
            Try
                Console.WriteLine("fase 1 modifica")
                conn.Open()
                command.Connection = conn

                DropColumn(command, ctrlbool)
                AddColumn(command, ctrlbool)
                AddIndex(command)
                AlterColumn(command, ctrlbool)
                DropTabellaLicenza(command, ctrlbool)
            Catch ex As Exception
                Console.WriteLine("Sono in errore nella modifica: " & ex.Message)
            Finally
                command.Dispose()
                conn.Close()
            End Try
            'MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Shared Sub AlterColumn(command As MySqlCommand, ctrlBool As Boolean)
        Console.WriteLine("fase 3 Modifica")
        If ctrlBool Then
            ' '--------------------------- 2023-12-07-1
            'Try
            '    command.CommandText = "ALTER TABLE dsauanag CHANGE ragi_socia ragi_socia VARCHAR(100) DEFAULT ''"
            '    command.ExecuteNonQuery()
            'Catch ex As Exception
            'Finally
            '    command.Dispose()
            'End Try
        End If

    End Sub

    Private Shared Sub AddColumn(command As MySqlCommand, ctrlBool As Boolean)
        Console.WriteLine("fase 2 Aggiungi")
        If ctrlBool Then
            ' '--------------------------- 2023-12-07-1
            'Try
            '    command.CommandText = "SELECT peso_lordo from dsaumovi limit 1"
            '    command.ExecuteNonQuery()
            'Catch ex As Exception
            '    command.CommandText = "ALTER TABLE dsaumovi ADD COLUMN peso_lordo NUMERIC(15, 5) DEFAULT 0 AFTER prova"
            '    command.ExecuteNonQuery()
            'Finally
            '    command.Dispose()
            'End Try
        End If
    End Sub

    Private Shared Sub DropColumn(command As MySqlCommand, ctrlBool As Boolean)
        Console.WriteLine("fase 1 cancella")
        If ctrlBool Then

        End If
    End Sub
    Private Shared Sub AddIndex(command As MySqlCommand)

    End Sub



    '---------------------------------
    'ModificaTabellaUtenti
    Shared Sub ModificaTabellaLicenza(Optional ByVal ctrlbool As Boolean = False)
    End Sub

    Private Shared Sub AlterColumnLicenza(command As MySqlCommand, ctrlBool As Boolean)
        If ctrlBool Then
        End If
    End Sub

    Private Shared Sub AddColumnLicenza(command As MySqlCommand, ctrlBool As Boolean)
        If ctrlBool Then
        End If
    End Sub



    Private Shared Sub DropColumnLicenza(command As MySqlCommand, ctrlBool As Boolean)
        Console.WriteLine("fase 3 cancella")
        If ctrlBool Then
            'Try
            '    command.CommandText = "SELECT tipo from gedotbds limit 1"
            '    command.ExecuteNonQuery()
            '    Console.WriteLine("fase 3 modifica")
            '    command.CommandText = "ALTER TABLE gedotbds DROP COLUMN tipo"
            '    command.ExecuteNonQuery()
            'Catch ex As Exception
            'Finally
            '    command.Dispose()
            'End Try

        End If

    End Sub
    Private Shared Sub DropTabellaLicenza(command As MySqlCommand, ctrlBool As Boolean)
        Console.WriteLine("fase 3 cancella")
        If ctrlBool Then
            'Try
            '    command.CommandText = "SELECT tipo from gedotbds limit 1"
            '    command.ExecuteNonQuery()
            '    Console.WriteLine("fase 3 modifica")
            '    command.CommandText = "ALTER TABLE gedotbds DROP COLUMN tipo"
            '    command.ExecuteNonQuery()
            'Catch ex As Exception
            'Finally
            '    command.Dispose()
            'End Try

        End If

    End Sub


End Class
