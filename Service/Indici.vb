Module Indici

    Dim conn As MySqlConnection = GetConnDb()
    Dim command As New MySqlCommand
    Sub CreaIndici(ByVal msg As Boolean, Optional forza As Boolean = False)
        Dim SQLstr As String
        conn.Open()
        'If forza OrElse ControllaIndiceEsiste(conn, "dsaumovi", "idx1") = False Then
        '    Try
        '        command.Connection = conn
        '        SQLstr = "ALTER TABLE dsaumovi DROP INDEX idx1"
        '        command.CommandText = SQLstr
        '        command.ExecuteNonQuery()
        '    Catch ex As Exception
        '        'MessageBox.Show(ex.Message.ToString)
        '    End Try

        '    Try
        '        command.Connection = conn
        '        SQLstr = "CREATE INDEX idx1 ON dsaumovi(anno_rifer,nume_rifer)" ' NON DARE ALL'INDICE LO STESSO NOME DEL DATABASE
        '        command.CommandText = SQLstr
        '        command.ExecuteNonQuery()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message.ToString)
        '    End Try
        'End If
        '--------------------------------------


        conn.Close()
        If msg Then
            MessageBox.Show("Creazione ultimata!!", "SUCCESS!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Console.WriteLine("creazione Indici ultimata")
        End If
    End Sub



End Module
