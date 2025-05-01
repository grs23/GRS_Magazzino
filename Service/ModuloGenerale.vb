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
                                             Button.BackColor = Color.FromArgb(153, 204, 255)
                                             Button.ForeColor = Color.Black
                                             Button.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                                         End Sub
                AddHandler Button.MouseEnter, Sub()
                                                  Button.BackColor = Color.FromArgb(153, 204, 255)
                                                  Button.ForeColor = Color.Black
                                                  Button.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                                              End Sub
                AddHandler Button.Leave, Sub()
                                             Button.BackColor = Color.FromArgb(100, 149, 237)
                                             Button.ForeColor = Color.White
                                             Button.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                                         End Sub
                AddHandler Button.MouseLeave, Sub()
                                                  Button.BackColor = Color.FromArgb(100, 149, 237)
                                                  Button.ForeColor = Color.White
                                                  Button.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                                              End Sub
            End If
        Next
    End Sub

    Public Sub ImpostaTemaChiaro(fp As Form)
        'fp.Text = "Form Gestione Dati"
        'fp.Size = New Size(900, 600)
        fp.BackColor = Color.White
        If fp.Controls.Find("Panel1", False).Length > 0 Then
            Dim panel1 As Panel = fp.Controls.Find("panel1", False).First
            panel1.BackColor = Color.White
            ' Testata (PnlTestata)
            If panel1.Controls.Find("PnlTestata", False).Length > 0 Then
                Dim PnlTestata As Panel = panel1.Controls.Find("PnlTestata", False).First
                PnlTestata.BackColor = Color.FromArgb(230, 230, 230)
            End If


            ' Corpo (PnlCorpo)
            If panel1.Controls.Find("PnlCorpo", False).Length > 0 Then
                Dim PnlCorpo As Panel = panel1.Controls.Find("PnlCorpo", False).First
                PnlCorpo.BackColor = Color.White

                If PnlCorpo.Controls.Find("DgvCorpo", False).Length > 0 Then
                    Dim dgv As DataGridView = PnlCorpo.Controls.Find("DgvCorpo", False).First
                    dgv.BackgroundColor = Color.White
                    dgv.BorderStyle = BorderStyle.None
                    'dgv.EnableHeadersVisualStyles = False
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
                End If

            End If

            ' Piede (PnlPiede)
            If panel1.Controls.Find("PnlPiede", False).Length > 0 Then
                Dim PnlPiede As Panel = panel1.Controls.Find("PnlPiede", False).First

                PnlPiede.BackColor = Color.FromArgb(210, 210, 210)

                ' Pulsante di esempio
                'If PnlPiede.Controls.Find("BtnConferma", False).Length > 0 Then
                '    Dim btnConferma As Button = PnlPiede.Controls.Find("BtnConferma", False).First
                '    btnConferma.BackColor = Color.FromArgb(100, 149, 237)
                '    btnConferma.ForeColor = Color.White
                '    btnConferma.FlatStyle = FlatStyle.Flat
                'End If
                'If PnlPiede.Controls.Find("BtnEsci", False).Length > 0 Then
                '    Dim BtnEsci As Button = PnlPiede.Controls.Find("BtnEsci", False).First
                '    BtnEsci.BackColor = Color.FromArgb(100, 149, 237)
                '    BtnEsci.ForeColor = Color.White
                '    BtnEsci.FlatStyle = FlatStyle.Flat
                'End If

            End If
            ImpostaTemaControlli("CHIARO_PROFESSIONALE", panel1)

        End If

    End Sub

    Private Sub ImpostaTemaControlli(tema As String, ParamArray pnlLibb() As Panel)

        For Each pnl As Panel In pnlLibb
            For Each cnt As Control In pnl.Controls
                If TypeOf cnt Is Panel Then
                    ImpostaTemaControlli(tema, cnt)
                ElseIf TypeOf cnt Is TextBox OrElse TypeOf cnt Is MaskedTextBox OrElse TypeOf cnt Is ComboBox OrElse TypeOf cnt Is ComboBox OrElse TypeOf cnt Is RadioButton Then
                    If tema = "CHIARO_PROFESSIONALE" Then
                        cnt.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                        cnt.BackColor = Color.FromArgb(250, 250, 250)
                        cnt.ForeColor = Color.Black
                        If TypeOf cnt Is TextBox Then
                            CType(cnt, TextBox).BorderStyle = BorderStyle.FixedSingle
                        End If
                    End If
                ElseIf TypeOf cnt Is Label Then
                    If tema = "CHIARO_PROFESSIONALE" Then
                        cnt.ForeColor = Color.FromArgb(50, 50, 50)
                        cnt.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                    End If
                ElseIf TypeOf cnt Is CheckBox Then
                    CType(cnt, CheckBox).Checked = False
                ElseIf TypeOf cnt Is Button Then
                    If tema = "CHIARO_PROFESSIONALE" Then
                        cnt.BackColor = Color.FromArgb(100, 149, 237)
                        cnt.ForeColor = Color.White
                        cnt.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                        If TypeOf cnt Is Button Then
                            CType(cnt, Button).FlatStyle = FlatStyle.Flat
                        End If
                        ColorButton(cnt)
                    End If
                End If

            Next
        Next

    End Sub
End Module
