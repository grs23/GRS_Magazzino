Module ModuloGenerale
    Public StringaConn As String = ""

    Public Function GetConnDb() As IDbConnection
        Dim conn = connessioni.GetConn(StringaConn, TipiConn.ConnMySQL)
        Return conn
    End Function

    Public Sub ColorButton(ParamArray buttons As Button())
        For Each Button In buttons

            If Button IsNot Nothing Then
                AddHandler Button.Enter, Sub()
                                             Button.BackColor = Color.FromArgb(102, 178, 255)
                                         End Sub
                AddHandler Button.Leave, Sub()
                                             Button.BackColor = Color.FromArgb(150, 225, 255)
                                         End Sub
                'Button.Enabled = True
                Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Button.FlatStyle = FlatStyle.Flat
                Button.FlatAppearance.BorderSize = 2
                Button.FlatAppearance.BorderColor = Color.Blue
                Button.BackColor = Color.FromArgb(150, 225, 255)
            End If
        Next
    End Sub
End Module
