Public Class QueryF6
    Public Shared Function Anagrafica_Dipendenti(ByRef fp As Form, ByRef chiave As TextBox, ByVal conn As MySqlConnection)
        Return Anagrafica(fp, chiave, Schermata_grs_anagrafica.tipo_dipendente, conn)
    End Function
    Public Shared Function Anagrafica_Clienti(ByRef fp As Form, ByRef chiave As TextBox, ByVal conn As MySqlConnection)
        Return Anagrafica(fp, chiave, Schermata_grs_anagrafica.tipo_cliente, conn)
    End Function
    Private Shared Function Anagrafica(ByRef fp As Form, ByRef chiave As TextBox, tipo_anagr As String, ByVal conn As MySqlConnection)
        'Dim conn As SQLiteConnection = New Service().AccessDB
        Dim titolo As String = "Anagrafica"
        '


        'MsgBox(chiave.Text)
        Dim query As String = "SELECT DISTINCT ragi_socia, desc_recap FROM " & TabelleDatabase.tb_anagrafica &
                              " WHERE cancellato != @cancellato" &
                              " AND tipo_anagr = '" & tipo_anagr & "'" &
                              " AND ragi_socia LIKE @chiave" &
                              " ORDER BY ragi_socia"

        Dim colonne As New List(Of String()) From {
            New String() {"Ragione Sociale"},
            New String() {"Recapito"}
            }

        Return HelpF6Row(conn, query, titolo, colonne, chiave, "I", fp)
    End Function

End Class
