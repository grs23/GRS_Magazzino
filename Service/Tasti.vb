Module Tasti
    Public Sub RimuoviCorpesc(Pnl As Panel, Optional BtnConferma As Button = Nothing, Optional BtnStampa As Button = Nothing,
                              Optional BtnRiproponi As Button = Nothing, Optional BtnCancella As Button = Nothing, Optional BtnEsci As Button = Nothing, Optional BtnEmail As Button = Nothing)
        If BtnConferma IsNot Nothing Then
            Pnl.Controls.Remove(BtnConferma)
        End If
        If BtnStampa IsNot Nothing Then
            Pnl.Controls.Remove(BtnStampa)
        End If
        If BtnRiproponi IsNot Nothing Then
            Pnl.Controls.Remove(BtnRiproponi)
        End If
        If BtnCancella IsNot Nothing Then
            Pnl.Controls.Remove(BtnCancella)
        End If
        If BtnEsci IsNot Nothing Then
            Pnl.Controls.Remove(BtnEsci)
        End If
        If BtnEmail IsNot Nothing Then
            Pnl.Controls.Remove(BtnEmail)
        End If
    End Sub
    ''' <summary>
    ''' Questo è un metodo di prova.
    ''' Utilizzo: creare un unico metodo che si adatti in base a quanti e quali bottoni vengono inseriti
    ''' </summary>
    ''' <param name="frm"></param>
    ''' <param name="pnl"></param>
    ''' <param name="BtnConferma"></param>
    ''' <param name="BtnStampa"></param>
    ''' <param name="BtnEmail"></param>
    ''' <param name="BtnRiproponi"></param>
    ''' <param name="BtnCancella"></param>
    ''' <param name="BtnEsci"></param>
    Public Sub SinoBottoni(frm As Form, pnl As Panel, Optional BtnConferma As Button = Nothing, Optional BtnStampa As Button = Nothing, Optional BtnEmail As Button = Nothing,
                                                      Optional BtnRiproponi As Button = Nothing, Optional BtnCancella As Button = Nothing, Optional BtnEsci As Button = Nothing,
                                                      Optional BtnDaSelezionare As Button = Nothing)
        Dim lConferma As Boolean = True

        'numBtn = If(BtnConferma IsNot Nothing, 1, 0) +
        '         If(BtnStampa IsNot Nothing, 1, 0) +
        '         If(BtnEmail IsNot Nothing, 1, 0) +
        '         If(BtnRiproponi IsNot Nothing, 1, 0) +
        '         If(BtnCancella IsNot Nothing, 1, 0) +
        '         If(BtnEsci IsNot Nothing, 1, 0)

        'CALCOLO DEI BOTTONI 
        Dim totaleBottoni = 0

        If BtnConferma IsNot Nothing Then
            totaleBottoni += 1
        End If

        If BtnStampa IsNot Nothing Then
            totaleBottoni += 1
        End If

        If BtnEmail IsNot Nothing Then
            totaleBottoni += 1
        End If

        If BtnRiproponi IsNot Nothing Then
            totaleBottoni += 1
        End If

        If BtnCancella IsNot Nothing Then
            totaleBottoni += 1
        End If

        If BtnEsci IsNot Nothing Then
            totaleBottoni += 1
        End If
        '-------------------------------------------------------

        Dim AlteTast = 25
        Dim LungTast = 75
        Dim grbY = pnl.Size.Height
        Dim grbX = pnl.Size.Width
        Dim disY = grbY - AlteTast - 35

        'VARIABILE DI APPOGGIO PER IL CONTEGGIO DEI BOTTONI INSERITI
        Dim numeBottoni As Integer = 0

        'AGGIUNTA BOTTONE CONFERMA SE NON è NOTHING
        If BtnConferma IsNot Nothing Then
            Dim disX = grbX - (totaleBottoni - numeBottoni) * (10 + LungTast)
            CreaBottoni(pnl, BtnConferma, "BtnConferma", "Conferma", LungTast, AlteTast, disX, disY)

            AddHandler BtnConferma.Click, Sub()
                                              'If frm.GetType.GetMethod("conferma") <> Nothing Then
                                              '    If lConferma Then
                                              '        lConferma = False
                                              '        frm.GetType.GetMethod("conferma").Invoke(frm, Nothing)
                                              '    End If
                                              'End If
                                              SettaSubBottoni(frm, "conferma", lConferma)
                                              RimuoviBottoni(pnl, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                          End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
            BtnConferma.TabIndex = 9999 + numeBottoni - totaleBottoni
        End If

        'AGGIUNTA BOTTONE STAMPA SE NON è NOTHING
        If BtnStampa IsNot Nothing Then
            Dim disX = grbX - (totaleBottoni - numeBottoni) * (10 + LungTast)
            CreaBottoni(pnl, BtnStampa, "BtnStampa", "Stampa", LungTast, AlteTast, disX, disY)

            AddHandler BtnStampa.Click, Sub()
                                            'If frm.GetType.GetMethod("stampa") <> Nothing Then
                                            '    If lConferma Then
                                            '        lConferma = False
                                            '        frm.GetType.GetMethod("stampa").Invoke(frm, Nothing)
                                            '    End If
                                            'End If
                                            SettaSubBottoni(frm, "stampa", lConferma)
                                            RimuoviBottoni(pnl, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                        End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
            BtnStampa.TabIndex = 9999 + numeBottoni - totaleBottoni
        End If

        'AGGIUNTA BOTTONE EMAIL SE NON è NOTHING
        If BtnEmail IsNot Nothing Then
            Dim disX = grbX - (totaleBottoni - numeBottoni) * (10 + LungTast)
            CreaBottoni(pnl, BtnEmail, "BtnEmail", "Email", LungTast, AlteTast, disX, disY)

            AddHandler BtnEmail.Click, Sub()
                                           'If frm.GetType.GetMethod("email") <> Nothing Then
                                           '    If lConferma Then
                                           '        lConferma = False
                                           '        frm.GetType.GetMethod("email").Invoke(frm, Nothing)
                                           '    End If
                                           'End If
                                           SettaSubBottoni(frm, "email", lConferma)
                                           RimuoviBottoni(pnl, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                       End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
            BtnEmail.TabIndex = 9999 + numeBottoni - totaleBottoni
        End If

        'AGGIUNTA BOTTONE RIPROPONI SE NON è NOTHING
        If BtnRiproponi IsNot Nothing Then
            Dim disX = grbX - (totaleBottoni - numeBottoni) * (10 + LungTast)
            CreaBottoni(pnl, BtnRiproponi, "BtnRiproponi", "Riproponi", LungTast, AlteTast, disX, disY)
            AddHandler BtnRiproponi.Click, Sub()
                                               'If frm.GetType.GetMethod("riproponi") <> Nothing Then
                                               '    If lConferma Then
                                               '        lConferma = False
                                               '        frm.GetType.GetMethod("riproponi").Invoke(frm, Nothing)
                                               '    End If
                                               'End If
                                               SettaSubBottoni(frm, "riproponi", lConferma)
                                               RimuoviBottoni(pnl, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                           End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
            BtnRiproponi.TabIndex = 9999 + numeBottoni - totaleBottoni
        End If

        'AGGIUNTA BOTTONE CANCELLA SE NON è NOTHING
        If BtnCancella IsNot Nothing Then
            Dim disX = grbX - (totaleBottoni - numeBottoni) * (10 + LungTast)

            CreaBottoni(pnl, BtnCancella, "BtnCancella", "Cancella", LungTast, AlteTast, disX, disY)
            AddHandler BtnCancella.Click, Sub()
                                              'If frm.GetType.GetMethod("cancella") <> Nothing Then
                                              '    If lConferma Then
                                              '        lConferma = False
                                              '        frm.GetType.GetMethod("cancella").Invoke(frm, Nothing)
                                              '    End If
                                              'End If
                                              SettaSubBottoni(frm, "cancella", lConferma)
                                              RimuoviBottoni(pnl, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                          End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
            BtnCancella.TabIndex = 9999 + numeBottoni - totaleBottoni
        End If

        'AGGIUNTA BOTTONE ESCI SE NON è NOTHING
        If BtnEsci IsNot Nothing Then
            Dim disX = grbX - (totaleBottoni - numeBottoni) * (10 + LungTast)
            CreaBottoni(pnl, BtnEsci, "BtnEsci", "Esci", LungTast, AlteTast, disX, disY)

            AddHandler BtnEsci.Click, Sub()
                                          'If frm.GetType.GetMethod("esci") <> Nothing Then
                                          '    If lConferma Then
                                          '        lConferma = False
                                          '        frm.GetType.GetMethod("esci").Invoke(frm, Nothing)
                                          '    End If
                                          'End If
                                          SettaSubBottoni(frm, "esci", lConferma)
                                          RimuoviBottoni(pnl, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                      End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
            BtnEsci.TabIndex = 9999 + numeBottoni - totaleBottoni
        End If

        ColorButton(BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)

        If frm IsNot Nothing AndAlso BtnDaSelezionare IsNot Nothing Then
            frm.ActiveControl = BtnDaSelezionare
        End If
    End Sub

    ''' <summary>
    ''' Questo è un metodo di prova.
    ''' Utilizzo: creare un unico metodo che si adatti in base a quanti e quali bottoni vengono inseriti
    ''' </summary>
    ''' <param name="frm"></param>
    ''' <param name="grb"></param>
    ''' <param name="BtnConferma"></param>
    ''' <param name="BtnStampa"></param>
    ''' <param name="BtnEmail"></param>
    ''' <param name="BtnRiproponi"></param>
    ''' <param name="BtnCancella"></param>
    ''' <param name="BtnEsci"></param>
    Public Sub SinoBottoniGrb(frm As Form, grb As GroupBox, Optional BtnConferma As Button = Nothing, Optional BtnStampa As Button = Nothing, Optional BtnEmail As Button = Nothing,
                                                            Optional BtnRiproponi As Button = Nothing, Optional BtnCancella As Button = Nothing, Optional BtnEsci As Button = Nothing,
                                                            Optional BtnDaSelezionare As Button = Nothing)
        Dim lConferma As Boolean = True

        'numBtn = If(BtnConferma IsNot Nothing, 1, 0) +
        '         If(BtnStampa IsNot Nothing, 1, 0) +
        '         If(BtnEmail IsNot Nothing, 1, 0) +
        '         If(BtnRiproponi IsNot Nothing, 1, 0) +
        '         If(BtnCancella IsNot Nothing, 1, 0) +
        '         If(BtnEsci IsNot Nothing, 1, 0)

        'CALCOLO DEI BOTTONI 
        Dim numBtn = 0

        If BtnConferma IsNot Nothing Then
            numBtn += 1
        End If

        If BtnStampa IsNot Nothing Then
            numBtn += 1
        End If

        If BtnEmail IsNot Nothing Then
            numBtn += 1
        End If

        If BtnRiproponi IsNot Nothing Then
            numBtn += 1
        End If

        If BtnCancella IsNot Nothing Then
            numBtn += 1
        End If

        If BtnEsci IsNot Nothing Then
            numBtn += 1
        End If
        '-------------------------------------------------------

        Dim AlteTast = 25
        Dim LungTast = 75
        Dim grbY = grb.Size.Height
        Dim grbX = grb.Size.Width
        Dim disY = grbY - AlteTast - 35

        'VARIABILE DI APPOGGIO PER IL CONTEGGIO DEI BOTTONI INSERITI
        Dim numeBottoni As Integer = 0

        'AGGIUNTA BOTTONE CONFERMA SE NON è NOTHING
        If BtnConferma IsNot Nothing Then
            Dim disX = grbX - (numBtn - numeBottoni) * (10 + LungTast)
            CreaBottoniGrb(grb, BtnConferma, "BtnConferma", "Conferma", LungTast, AlteTast, disX, disY)

            AddHandler BtnConferma.Click, Sub()
                                              'If frm.GetType.GetMethod("conferma") <> Nothing Then
                                              '    If lConferma Then
                                              '        lConferma = False
                                              '        frm.GetType.GetMethod("conferma").Invoke(frm, Nothing)
                                              '    End If
                                              'End If
                                              SettaSubBottoni(frm, "conferma", lConferma)
                                              RimuoviBottoniGrb(grb, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                          End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
        End If

        'AGGIUNTA BOTTONE STAMPA SE NON è NOTHING
        If BtnStampa IsNot Nothing Then
            Dim disX = grbX - (numBtn - numeBottoni) * (10 + LungTast)
            CreaBottoniGrb(grb, BtnStampa, "BtnStampa", "Stampa", LungTast, AlteTast, disX, disY)

            AddHandler BtnStampa.Click, Sub()
                                            'If frm.GetType.GetMethod("stampa") <> Nothing Then
                                            '    If lConferma Then
                                            '        lConferma = False
                                            '        frm.GetType.GetMethod("stampa").Invoke(frm, Nothing)
                                            '    End If
                                            'End If
                                            SettaSubBottoni(frm, "stampa", lConferma)
                                            RimuoviBottoniGrb(grb, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                        End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
        End If

        'AGGIUNTA BOTTONE EMAIL SE NON è NOTHING
        If BtnEmail IsNot Nothing Then
            Dim disX = grbX - (numBtn - numeBottoni) * (10 + LungTast)
            CreaBottoniGrb(grb, BtnEmail, "BtnEmail", "Email", LungTast, AlteTast, disX, disY)

            AddHandler BtnEmail.Click, Sub()
                                           'If frm.GetType.GetMethod("email") <> Nothing Then
                                           '    If lConferma Then
                                           '        lConferma = False
                                           '        frm.GetType.GetMethod("email").Invoke(frm, Nothing)
                                           '    End If
                                           'End If
                                           SettaSubBottoni(frm, "email", lConferma)
                                           RimuoviBottoniGrb(grb, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                       End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
        End If

        'AGGIUNTA BOTTONE RIPROPONI SE NON è NOTHING
        If BtnRiproponi IsNot Nothing Then
            Dim disX = grbX - (numBtn - numeBottoni) * (10 + LungTast)
            CreaBottoniGrb(grb, BtnRiproponi, "BtnRiproponi", "Riproponi", LungTast, AlteTast, disX, disY)
            AddHandler BtnRiproponi.Click, Sub()
                                               'If frm.GetType.GetMethod("riproponi") <> Nothing Then
                                               '    If lConferma Then
                                               '        lConferma = False
                                               '        frm.GetType.GetMethod("riproponi").Invoke(frm, Nothing)
                                               '    End If
                                               'End If
                                               SettaSubBottoni(frm, "riproponi", lConferma)
                                               RimuoviBottoniGrb(grb, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                           End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
        End If

        'AGGIUNTA BOTTONE CANCELLA SE NON è NOTHING
        If BtnCancella IsNot Nothing Then
            Dim disX = grbX - (numBtn - numeBottoni) * (10 + LungTast)

            CreaBottoniGrb(grb, BtnCancella, "BtnCancella", "Cancella", LungTast, AlteTast, disX, disY)
            AddHandler BtnCancella.Click, Sub()
                                              'If frm.GetType.GetMethod("cancella") <> Nothing Then
                                              '    If lConferma Then
                                              '        lConferma = False
                                              '        frm.GetType.GetMethod("cancella").Invoke(frm, Nothing)
                                              '    End If
                                              'End If
                                              SettaSubBottoni(frm, "cancella", lConferma)
                                              RimuoviBottoniGrb(grb, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                          End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
        End If

        'AGGIUNTA BOTTONE ESCI SE NON è NOTHING
        If BtnEsci IsNot Nothing Then
            Dim disX = grbX - (numBtn - numeBottoni) * (10 + LungTast)
            CreaBottoniGrb(grb, BtnEsci, "BtnEsci", "Esci", LungTast, AlteTast, disX, disY)

            AddHandler BtnEsci.Click, Sub()
                                          'If frm.GetType.GetMethod("esci") <> Nothing Then
                                          '    If lConferma Then
                                          '        lConferma = False
                                          '        frm.GetType.GetMethod("esci").Invoke(frm, Nothing)
                                          '    End If
                                          'End If
                                          SettaSubBottoni(frm, "esci", lConferma)
                                          RimuoviBottoniGrb(grb, BtnConferma, BtnStampa, BtnEmail, BtnRiproponi, BtnCancella, BtnEsci)
                                      End Sub
            'INCREMENTO VARIABILE DI APPOGGIO
            numeBottoni += 1
        End If

        If frm IsNot Nothing AndAlso BtnDaSelezionare IsNot Nothing Then
            frm.ActiveControl = BtnDaSelezionare
        End If
    End Sub

    ''-------------------------SUB CLICK BOTTONI
    Private Sub SettaSubBottoni(frm As Form, metodo As String, ByRef lConferma As Boolean)
        If lConferma Then
            If metodo <> "" AndAlso frm IsNot Nothing AndAlso frm.GetType.GetMethod(metodo) <> Nothing Then
                'If lConferma Then
                '    lConferma = False
                frm.GetType.GetMethod(metodo).Invoke(frm, Nothing)
                'End If
            End If
            lConferma = False
        End If
    End Sub

    ''-------------------------CREA BOTTONI 
    Private Sub CreaBottoni(pnl As Panel, btn As Button, BtnNome As String, BtnTesto As String, BtnWidth As Integer, BtnHeight As Integer,
                        locX As Integer, locY As Integer)
        btn.Name = BtnNome
        btn.Text = BtnTesto
        btn.Width = BtnWidth
        btn.Height = BtnHeight
        btn.BackColor = Color.FromArgb(217, 217, 217)
        btn.Location = New Point(locX, locY)
        btn.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        pnl.Controls.Add(btn)
    End Sub

    Private Sub CreaBottoniGrb(grb As GroupBox, btn As Button, BtnNome As String, BtnTesto As String, BtnWidth As Integer, BtnHeight As Integer,
                            locX As Integer, locY As Integer)
        btn.Name = BtnNome
        btn.Text = BtnTesto
        btn.Width = BtnWidth
        btn.Height = BtnHeight
        btn.BackColor = Color.FromArgb(217, 217, 217)
        btn.Location = New Point(locX, locY)
        grb.Controls.Add(btn)
    End Sub

    ''-------------------------RIMUOVI BOTTONI 
    Public Sub RimuoviBottoni(pnl As Panel, Optional BtnConferma As Button = Nothing, Optional BtnStampa As Button = Nothing, Optional BtnEmail As Button = Nothing,
                                             Optional BtnRiproponi As Button = Nothing, Optional BtnCancella As Button = Nothing, Optional BtnEsci As Button = Nothing)
        If pnl IsNot Nothing Then
            'RIMUOVI CONFERMA
            If BtnConferma IsNot Nothing AndAlso pnl.Controls.Contains(BtnConferma) Then
                pnl.Controls.Remove(BtnConferma)
            End If

            'RIMUOVI STAMPA
            If BtnStampa IsNot Nothing AndAlso pnl.Controls.Contains(BtnStampa) Then
                pnl.Controls.Remove(BtnStampa)
            End If

            'RIMUOVI EMAIL
            If BtnEmail IsNot Nothing AndAlso pnl.Controls.Contains(BtnEmail) Then
                pnl.Controls.Remove(BtnEmail)
            End If

            'RIMUOVI RIPROPONI
            If BtnRiproponi IsNot Nothing AndAlso pnl.Controls.Contains(BtnRiproponi) Then
                pnl.Controls.Remove(BtnRiproponi)
            End If

            'RIMUOVI CANCELLA
            If BtnCancella IsNot Nothing AndAlso pnl.Controls.Contains(BtnCancella) Then
                pnl.Controls.Remove(BtnCancella)
            End If

            'RIMUOVI ESCI
            If BtnEsci IsNot Nothing AndAlso pnl.Controls.Contains(BtnEsci) Then
                pnl.Controls.Remove(BtnEsci)
            End If
        End If
    End Sub

    Public Sub RimuoviBottoniGrb(grb As GroupBox, Optional BtnConferma As Button = Nothing, Optional BtnStampa As Button = Nothing, Optional BtnEmail As Button = Nothing,
                                                   Optional BtnRiproponi As Button = Nothing, Optional BtnCancella As Button = Nothing, Optional BtnEsci As Button = Nothing)
        If grb IsNot Nothing Then
            'RIMUOVI CONFERMA
            If BtnConferma IsNot Nothing AndAlso grb.Controls.Contains(BtnConferma) Then
                grb.Controls.Remove(BtnConferma)
            End If

            'RIMUOVI STAMPA
            If BtnStampa IsNot Nothing AndAlso grb.Controls.Contains(BtnStampa) Then
                grb.Controls.Remove(BtnStampa)
            End If

            'RIMUOVI EMAIL
            If BtnEmail IsNot Nothing AndAlso grb.Controls.Contains(BtnEmail) Then
                grb.Controls.Remove(BtnEmail)
            End If

            'RIMUOVI RIPROPONI
            If BtnRiproponi IsNot Nothing AndAlso grb.Controls.Contains(BtnRiproponi) Then
                grb.Controls.Remove(BtnRiproponi)
            End If

            'RIMUOVI CANCELLA
            If BtnCancella IsNot Nothing AndAlso grb.Controls.Contains(BtnCancella) Then
                grb.Controls.Remove(BtnCancella)
            End If

            'RIMUOVI ESCI
            If BtnEsci IsNot Nothing AndAlso grb.Controls.Contains(BtnEsci) Then
                grb.Controls.Remove(BtnEsci)
            End If
        End If
    End Sub
End Module

