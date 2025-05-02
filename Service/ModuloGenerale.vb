Module ModuloGenerale
    Public StringaConn As String = ""

    Public Function GetConnDb() As IDbConnection
        Dim conn = connessioni.GetConn(StringaConn, TipiConn.ConnMySQL)
        Return conn
    End Function

    Public Sub ColorButton(ByVal tema As String, ParamArray buttons As Button())
        For Each Button In buttons

            If Button IsNot Nothing Then

                RemoveHandler Button.Enter, Nothing
                RemoveHandler Button.Leave, Nothing
                RemoveHandler Button.MouseEnter, Nothing
                RemoveHandler Button.MouseLeave, Nothing
                If tema = "CHIARO" Then
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
                ElseIf tema = "SCURO" Then
                    AddHandler Button.Enter, Sub()
                                                 Button.BackColor = Color.FromArgb(0, 153, 255)
                                                 Button.ForeColor = Color.Black
                                                 Button.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                                             End Sub
                    AddHandler Button.MouseEnter, Sub()
                                                      Button.BackColor = Color.FromArgb(0, 153, 255)
                                                      Button.ForeColor = Color.Black
                                                      Button.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                                                  End Sub
                    AddHandler Button.Leave, Sub()
                                                 Button.BackColor = Color.FromArgb(0, 122, 204)
                                                 Button.ForeColor = Color.White
                                                 Button.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                                             End Sub
                    AddHandler Button.MouseLeave, Sub()
                                                      Button.BackColor = Color.FromArgb(0, 122, 204)
                                                      Button.ForeColor = Color.White
                                                      Button.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                                                  End Sub
                End If
            End If
        Next
    End Sub

    Public Sub ImpostaTema(fp As Form)
        Dim tema As String = New Query().caricaPersonalizzazioneTema()
        If tema = "CHIARO" Then
            ImpostaTemaChiaro(fp)
        ElseIf tema = "SCURO" Then
            ImpostaTemaScuro(fp)
        End If


    End Sub

    Private Sub ImpostaTemaChiaro(fp As Form)
        'fp.Text = "Form Gestione Dati"
        'fp.Size = New Size(900, 600)
        fp.BackColor = Color.FromArgb(240, 240, 240)
        If fp.Controls.Find("Panel1", False).Length > 0 Then
            Dim panel1 As Panel = fp.Controls.Find("panel1", False).First
            panel1.BackColor = Color.FromArgb(240, 240, 240)
            ' Testata (PnlTestata)
            If panel1.Controls.Find("PnlTestata", False).Length > 0 Then
                Dim PnlTestata As Panel = panel1.Controls.Find("PnlTestata", False).First
                PnlTestata.BackColor = Color.FromArgb(230, 230, 230)
            End If


            ' Corpo (PnlCorpo)
            If panel1.Controls.Find("PnlCorpo", False).Length > 0 Then
                Dim PnlCorpo As Panel = panel1.Controls.Find("PnlCorpo", False).First
                PnlCorpo.BackColor = Color.FromArgb(230, 230, 230)

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

            End If
            ImpostaTemaControlli("CHIARO", panel1)

        End If

    End Sub
    Private Sub ImpostaTemaScuro(fp As Form)
        fp.BackColor = Color.FromArgb(9, 22, 61)

        If fp.Controls.Find("Panel1", False).Length > 0 Then
            Dim panel1 As Panel = fp.Controls.Find("panel1", False).First
            panel1.BackColor = Color.FromArgb(9, 22, 61)

            If panel1.Controls.Find("PnlTestata", False).Length > 0 Then
                panel1.Controls.Find("PnlTestata", False).First.BackColor = Color.FromArgb(11, 24, 77)
            End If

            If panel1.Controls.Find("PnlCorpo", False).Length > 0 Then
                Dim PnlCorpo As Panel = panel1.Controls.Find("PnlCorpo", False).First
                PnlCorpo.BackColor = Color.FromArgb(11, 24, 77)

                If PnlCorpo.Controls.Find("DgvCorpo", False).Length > 0 Then
                    Dim dgv As DataGridView = PnlCorpo.Controls.Find("DgvCorpo", False).First
                    dgv.BackgroundColor = Color.FromArgb(11, 24, 77)
                    dgv.BorderStyle = BorderStyle.None
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 70, 70)
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                End If
            End If

            If panel1.Controls.Find("PnlPiede", False).Length > 0 Then
                panel1.Controls.Find("PnlPiede", False).First.BackColor = Color.FromArgb(11, 24, 77)
            End If

            ImpostaTemaControlli("SCURO", panel1)
        End If
    End Sub

    Private Sub ImpostaTemaControlli(tema As String, ParamArray pnlLibb() As Panel)

        For Each pnl As Panel In pnlLibb
            For Each cnt As Control In pnl.Controls
                If TypeOf cnt Is Panel Then
                    ImpostaTemaControlli(tema, cnt)
                ElseIf TypeOf cnt Is TextBox OrElse TypeOf cnt Is MaskedTextBox OrElse TypeOf cnt Is ComboBox OrElse TypeOf cnt Is ComboBox OrElse TypeOf cnt Is RadioButton Then
                    If tema = "CHIARO" Then
                        cnt.BackColor = Color.FromArgb(250, 250, 250)
                        cnt.ForeColor = Color.Black
                    ElseIf tema = "SCURO" Then
                        'cnt.BackColor = Color.FromArgb(45, 45, 48)
                        'cnt.ForeColor = Color.White

                        cnt.BackColor = Color.FromArgb(250, 250, 250)
                        cnt.ForeColor = Color.Black
                    End If
                    cnt.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                    If TypeOf cnt Is TextBox Then
                        CType(cnt, TextBox).BorderStyle = BorderStyle.FixedSingle
                    End If
                ElseIf TypeOf cnt Is Label Then
                    If tema = "CHIARO" Then
                        cnt.ForeColor = Color.FromArgb(50, 50, 50)
                    ElseIf tema = "SCURO" Then
                        cnt.ForeColor = Color.LightGray
                    End If
                    cnt.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                ElseIf TypeOf cnt Is CheckBox Then
                    CType(cnt, CheckBox).Checked = False
                ElseIf TypeOf cnt Is Button Then
                    If tema = "CHIARO" Then
                        cnt.BackColor = Color.FromArgb(100, 149, 237)
                        cnt.ForeColor = Color.White
                    ElseIf tema = "SCURO" Then
                        cnt.BackColor = Color.FromArgb(0, 122, 204)
                        cnt.ForeColor = Color.White
                    End If
                    cnt.Font = New Font("Segoe UI", 11, FontStyle.Regular)
                    If TypeOf cnt Is Button Then
                        CType(cnt, Button).FlatStyle = FlatStyle.Flat
                    End If
                    ColorButton(tema, cnt)
                End If

            Next
        Next

    End Sub
End Module
