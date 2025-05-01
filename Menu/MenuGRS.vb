Public Class MenuGRS
    'Public conn As IDbConnection = GetConnDb()

    Public boolLice As Boolean = False
    'Public percorso As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\GRS"
    Public percorso As String = Application.StartupPath
    Public exe As String = Application.ExecutablePath.Replace(percorso & "\", "")
    Public nomeFileConnessione As String = "GRSMagazzinoConn.cfg"
    Public percorsoPrincipaleConnessione As String = IO.Path.GetPathRoot(percorso) & "\GRS\Programs\" & nomeFileConnessione
    Public versione As String = "2025.04.06.1"

    Public rigoUten As DataRow = Nothing
    Public rigoPers As DataRow = Nothing
    Private Sub MenuGRS_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dgvType As Type = LblClienti.[GetType]()
        Dim pi As System.Reflection.PropertyInfo = dgvType.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        pi.SetValue(LblClienti, True, Nothing)
        InizializzaForm.Init(Me)
        Text &= " " & GRSLib.PrendiVersioneFile(percorso & "\" & exe)
    End Sub

    Private Sub MenuGRS_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If Process.GetProcessesByName(IO.Path.GetFileNameWithoutExtension(Reflection.Assembly.GetEntryAssembly().Location)).AsEnumerable().Where(Function(p) p.MainModule.FileName = percorso & "\" & exe AndAlso p.Id <> Process.GetCurrentProcess.Id).Any Then
                MessageBox.Show("Il programma è già in esecuzione", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End
            Else

            End If
        Catch ex As Exception
        End Try
        If IO.File.Exists(percorso & "\GRSMagazzinoConfig\" & nomeFileConnessione) Then
            percorsoPrincipaleConnessione = percorso & "\GRSMagazzinoConfig\" & nomeFileConnessione
        End If

        Dim fileConnessioneEsiste As Boolean = IO.File.Exists(percorsoPrincipaleConnessione)

        If Service.LeggiFileConnessione(If(fileConnessioneEsiste,
                                        percorsoPrincipaleConnessione,
                                        percorso & "\" & nomeFileConnessione),
                                        Not fileConnessioneEsiste OrElse IO.File.Exists(percorso & "\" & nomeFileConnessione)) Then
            'Crea_Archivi.CreaTabellaLicenza()
            'ModificaTabelle.ModificaTabellaLicenza()
            'Crea_Archivi.CreaRigoLicenza()

            CreaArchivi.CreaTabellaUtenti()
            CreaArchivi.CreaTabellaPersonalizzazione()
            'ModificaTabelle.ModificaTabellaUtenti()
            Login.fp = Me
            Login.Show()


            'LETTURA FILE SETTAGGI
            '       If IO.File.Exists(percorsoSettaggi) Then
            'Service.LeggiFileSettaggi(percorsoSettaggi)
            '      End If
        Else
            End
        End If
    End Sub

    Private Sub MenuGRS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim lista As List(Of String) = GRSLib.Seriali.SerialNumberMB
            Dim lista2 As List(Of String) = GRSLib.Seriali.MACAddressSchedeDiRete
            For Each elem In lista
                Console.WriteLine("serial number: " & elem)
            Next
            For Each elem In lista2
                Console.WriteLine("MAC: " & elem)
            Next
            LblInterventi.Visible = False
        Else

        End If
    End Sub
    Public Sub LanciaRoutine()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            '-----------------------------------

            BGW.CambiaTestoLabel(LblAggiorna, "Verifica Licenza")
            'boolLice = controlloLicenza()
            If boolLice Then
                BGW.CambiaTestoLabel(LblAggiorna, "")
            Else
                BGW.CambiaTestoLabel(LblAggiorna, "")
                'BGW.CambiaTestoLabel(LblAggiorna, "Verifico Aggiornamenti")
                'AggiornaLabel("Verifico Aggiornamenti", True)
                'If Aggiornamenti.VersEAggi(percorso, exe, versione, , False,,,,, Me) = True Then
                '    Close()
                'Else
                BGW.CambiaTestoLabel(LblAggiorna, "")
                    'AggiornaLabel()
                    'If rigoUten("username") = "ADMIN" Then
                    '    CreaArchivi()
                    'End If

                    Dim conn As MySqlConnection = GetConnDb()
                    ' If dbesiste(NomeDB) = True Then
                    'EliminaElementiDuplicati(conn)
                    BGW.CambiaTestoLabel(LblAggiorna, "Verifica Struttura Dati")
                CreaArchivi.CreaArchivi(False)
                CreaIndici(False)
                    BGW.CambiaTestoLabel(LblAggiorna, "")


                ModificaTabelle.Modifica()
                '----------------------------------------------- 
                BGW.CambiaTestoLabel(LblAggiorna, "")

                '-----------------------------------------------
                '-----------------------------------


                'End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            BGW.CambiaTestoLabel(LblAggiorna, "")
        End Try
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If boolLice = False Then
            Me.Enabled = True
        End If
    End Sub


    Private Sub Verticale_MouseEnter(sender As Object, e As EventArgs) Handles LblPagamenti.MouseEnter, LblAcquistoMateriali.MouseEnter, LblInterventi.MouseEnter
        CType(sender, Label).MaximumSize = New Size(200, 110)
        CType(sender, Label).Size = New Size(200, 110)
        CType(sender, Label).BackColor = Color.FromArgb(46, 40, 230)
    End Sub

    Private Sub Orizzontale_MouseEnter(sender As Object, e As EventArgs) Handles LblClienti.MouseEnter, LblDipendenti.MouseEnter, LblArticoli.MouseEnter
        CType(sender, Label).MaximumSize = New Size(220, 100)
        CType(sender, Label).Size = New Size(220, 100)
        CType(sender, Label).BackColor = Color.FromArgb(46, 40, 230)
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles LblPagamenti.MouseLeave, LblAcquistoMateriali.MouseLeave, LblInterventi.MouseLeave,
                                                                               LblClienti.MouseLeave, LblDipendenti.MouseLeave, LblArticoli.MouseLeave
        CType(sender, Label).MaximumSize = New Size(200, 100)
        CType(sender, Label).Size = New Size(200, 100)
        CType(sender, Label).BackColor = Color.Transparent
    End Sub

    Private Sub LblClienti_Click(sender As Object, e As EventArgs) Handles LblClienti.Click
        If CheckFormAperto(Schermata_grs_anagrafica, Application.OpenForms, True) Then
            MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Schermata_grs_anagrafica.tipo_anagrafica = Schermata_grs_anagrafica.tipo_cliente
            Schermata_grs_anagrafica.Show()
        End If
    End Sub

    Private Sub LblDipendente_Click(sender As Object, e As EventArgs) Handles LblDipendenti.Click
        If CheckFormAperto(Schermata_grs_anagrafica, Application.OpenForms, True) Then
            MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Schermata_grs_anagrafica.tipo_anagrafica = Schermata_grs_anagrafica.tipo_dipendente
            Schermata_grs_anagrafica.Show()
        End If
    End Sub
    Private Sub LblArticoli_Click(sender As Object, e As EventArgs) Handles LblArticoli.Click
        If CheckFormAperto(Schermata_grs_inventario, Application.OpenForms, True) Then
            MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Schermata_grs_inventario.Show()

        End If
    End Sub

    Private Sub LblRubrica_Click(sender As Object, e As EventArgs)
        'If CheckFormAperto(AutoSostate, Application.OpenForms, True) OrElse
        '   CheckFormAperto(AnagraficaModi, Application.OpenForms, True) OrElse
        '   CheckFormAperto(AnagraficaVeicoliModi, Application.OpenForms, True) Then
        '    MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        'Else
        '    Anagrafica.Show()
        'End If
    End Sub

    Private Sub LblScadenze_Click(sender As Object, e As EventArgs)
        'If CheckFormAperto(Scadenze, Application.OpenForms, True) Then
        '    MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        'Else
        '    Scadenze.Show()
        'End If
    End Sub


    Private Sub LblImpostazioni_Click(sender As Object, e As EventArgs)
        'Tariffe.Show()
    End Sub

    Private Sub LblInterventi_Click(sender As Object, e As EventArgs) Handles LblInterventi.Click
        If CheckFormAperto(Schermata_grs_interventi, Application.OpenForms, True) OrElse CheckFormAperto(Schermata_grs_interventi_Modi, Application.OpenForms, True) Then
            MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Schermata_grs_interventi.fp = Me
            Schermata_grs_interventi.Show()
        End If
    End Sub

    Private Sub LblPagamenti_Click(sender As Object, e As EventArgs) Handles LblPagamenti.Click
        If CheckFormAperto(Schermata_grs_interventi, Application.OpenForms, True) OrElse CheckFormAperto(Schermata_grs_interventi_Modi, Application.OpenForms, True) Then
            MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Schermata_grs_Pagamenti_dipendenti.fp = Me
            Schermata_grs_Pagamenti_dipendenti.Show()
        End If
    End Sub

    Private Sub LblRiepilogoInterventi_Click(sender As Object, e As EventArgs) Handles LblRiepilogoInterventi.Click
        If CheckFormAperto(Schermata_grs_riepilogo_interventi, Application.OpenForms, True) Then
            MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Schermata_grs_riepilogo_interventi.fp = Me
            Schermata_grs_riepilogo_interventi.Show()
        End If
    End Sub
End Class
