Public Class MenuGRS
    'Public conn As IDbConnection = GetConnDb()

    Public percorso As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & "\GRS"
    Public exe As String = Application.ExecutablePath.Replace(percorso & "\", "")
    Public nomeFileConnessione As String = "GRSConn.cfg"
    Public percorsoPrincipaleConnessione As String = percorso & "\Programs\" & nomeFileConnessione
    Public versione As String = "2023.12.11.1"

    Public rigoUten As DataRow = Nothing
    Private Sub MenuGRS_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dgvType As Type = LblClienti.[GetType]()
        Dim pi As System.Reflection.PropertyInfo = dgvType.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        pi.SetValue(LblClienti, True, Nothing)
        Text &= " " & GRSLib.PrendiVersioneFile(percorso & "\" & exe)
    End Sub

    Private Sub MenuGRS_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Dim fileConnessioneEsiste As Boolean = IO.File.Exists(percorsoPrincipaleConnessione)

        'If Service.LeggiFileConnessione(If(fileConnessioneEsiste, percorsoPrincipaleConnessione, percorso & "\" & nomeFileConnessione), Not fileConnessioneEsiste OrElse IO.File.Exists(percorso & "\" & nomeFileConnessione)) Then
        '    'CreaArchivi.CreaTabellaLicenza()
        '    'CreaArchivi.ModificaTabellaLicenza()
        '    'CreaArchivi.CreaRigoLicenza()
        '    CreaArchivi.CreaArchivi(False)
        '    'CreaArchivi.CreaArchiviUtenti()
        '    'login.fp = Me
        '    'login.Show()
        'Else
        '    End
        'End If

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
            Schermata_grs_anagrafica.Show()
            Schermata_grs_anagrafica.tipo_anagrafica = Schermata_grs_anagrafica.tipo_cliente
        End If
    End Sub

    Private Sub LblDipendente_Click(sender As Object, e As EventArgs) Handles LblDipendenti.Click
        If CheckFormAperto(Schermata_grs_anagrafica, Application.OpenForms, True) Then
            MessageBox.Show("Schermata già aperta!!!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Schermata_grs_anagrafica.Show()
            Schermata_grs_anagrafica.tipo_anagrafica = Schermata_grs_anagrafica.tipo_dipendente
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


End Class
