﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuGRS
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuGRS))
        Me.ImageListMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.PnlBottoniV = New System.Windows.Forms.Panel()
        Me.LblArticoli = New System.Windows.Forms.Label()
        Me.LblDipendenti = New System.Windows.Forms.Label()
        Me.LblClienti = New System.Windows.Forms.Label()
        Me.PnlBottoniO = New System.Windows.Forms.Panel()
        Me.LblInterventi = New System.Windows.Forms.Label()
        Me.LblAcquistoMateriali = New System.Windows.Forms.Label()
        Me.LblPagamenti = New System.Windows.Forms.Label()
        Me.PnlLogo = New System.Windows.Forms.Panel()
        Me.LblLicenza = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PnlBottoniV.SuspendLayout()
        Me.PnlBottoniO.SuspendLayout()
        Me.PnlLogo.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageListMenu
        '
        Me.ImageListMenu.ImageStream = CType(resources.GetObject("ImageListMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListMenu.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListMenu.Images.SetKeyName(0, "uscita_2.png")
        Me.ImageListMenu.Images.SetKeyName(1, "ingresso 2.png")
        Me.ImageListMenu.Images.SetKeyName(2, "rubrica.png")
        Me.ImageListMenu.Images.SetKeyName(3, "imageedit_15_4412799452.png")
        Me.ImageListMenu.Images.SetKeyName(4, "imageedit_4_9062273277.png")
        Me.ImageListMenu.Images.SetKeyName(5, "imageedit_19_7338845434.png")
        Me.ImageListMenu.Images.SetKeyName(6, "imageedit_27_5196813309.png")
        Me.ImageListMenu.Images.SetKeyName(7, "imageedit_1_4119941565.png")
        Me.ImageListMenu.Images.SetKeyName(8, "imageedit_6_5806935903.png")
        '
        'PnlBottoniV
        '
        Me.PnlBottoniV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PnlBottoniV.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.PnlBottoniV.Controls.Add(Me.LblArticoli)
        Me.PnlBottoniV.Controls.Add(Me.LblDipendenti)
        Me.PnlBottoniV.Controls.Add(Me.LblClienti)
        Me.PnlBottoniV.Location = New System.Drawing.Point(0, 0)
        Me.PnlBottoniV.Name = "PnlBottoniV"
        Me.PnlBottoniV.Size = New System.Drawing.Size(220, 722)
        Me.PnlBottoniV.TabIndex = 4
        '
        'LblArticoli
        '
        Me.LblArticoli.BackColor = System.Drawing.Color.Transparent
        Me.LblArticoli.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblArticoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArticoli.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblArticoli.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblArticoli.ImageIndex = 5
        Me.LblArticoli.ImageList = Me.ImageListMenu
        Me.LblArticoli.Location = New System.Drawing.Point(0, 200)
        Me.LblArticoli.MaximumSize = New System.Drawing.Size(200, 100)
        Me.LblArticoli.Name = "LblArticoli"
        Me.LblArticoli.Size = New System.Drawing.Size(200, 100)
        Me.LblArticoli.TabIndex = 3
        Me.LblArticoli.Text = "Articoli"
        Me.LblArticoli.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDipendenti
        '
        Me.LblDipendenti.BackColor = System.Drawing.Color.Transparent
        Me.LblDipendenti.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblDipendenti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDipendenti.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblDipendenti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDipendenti.ImageIndex = 1
        Me.LblDipendenti.ImageList = Me.ImageListMenu
        Me.LblDipendenti.Location = New System.Drawing.Point(0, 100)
        Me.LblDipendenti.MaximumSize = New System.Drawing.Size(200, 100)
        Me.LblDipendenti.Name = "LblDipendenti"
        Me.LblDipendenti.Size = New System.Drawing.Size(200, 100)
        Me.LblDipendenti.TabIndex = 2
        Me.LblDipendenti.Text = "Dipendenti"
        Me.LblDipendenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblClienti
        '
        Me.LblClienti.BackColor = System.Drawing.Color.Transparent
        Me.LblClienti.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblClienti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClienti.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblClienti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblClienti.ImageIndex = 0
        Me.LblClienti.ImageList = Me.ImageListMenu
        Me.LblClienti.Location = New System.Drawing.Point(0, 0)
        Me.LblClienti.MaximumSize = New System.Drawing.Size(200, 100)
        Me.LblClienti.Name = "LblClienti"
        Me.LblClienti.Size = New System.Drawing.Size(200, 100)
        Me.LblClienti.TabIndex = 1
        Me.LblClienti.Text = "Clienti"
        Me.LblClienti.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PnlBottoniO
        '
        Me.PnlBottoniO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlBottoniO.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.PnlBottoniO.Controls.Add(Me.LblInterventi)
        Me.PnlBottoniO.Controls.Add(Me.LblAcquistoMateriali)
        Me.PnlBottoniO.Controls.Add(Me.LblPagamenti)
        Me.PnlBottoniO.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.PnlBottoniO.Location = New System.Drawing.Point(226, 0)
        Me.PnlBottoniO.Name = "PnlBottoniO"
        Me.PnlBottoniO.Size = New System.Drawing.Size(956, 110)
        Me.PnlBottoniO.TabIndex = 5
        '
        'LblInterventi
        '
        Me.LblInterventi.BackColor = System.Drawing.Color.Transparent
        Me.LblInterventi.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblInterventi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInterventi.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblInterventi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LblInterventi.ImageIndex = 7
        Me.LblInterventi.ImageList = Me.ImageListMenu
        Me.LblInterventi.Location = New System.Drawing.Point(400, 0)
        Me.LblInterventi.MaximumSize = New System.Drawing.Size(200, 100)
        Me.LblInterventi.Name = "LblInterventi"
        Me.LblInterventi.Size = New System.Drawing.Size(200, 100)
        Me.LblInterventi.TabIndex = 11
        Me.LblInterventi.Text = "Interventi"
        Me.LblInterventi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'LblAcquistoMateriali
        '
        Me.LblAcquistoMateriali.BackColor = System.Drawing.Color.Transparent
        Me.LblAcquistoMateriali.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblAcquistoMateriali.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcquistoMateriali.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblAcquistoMateriali.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LblAcquistoMateriali.ImageIndex = 7
        Me.LblAcquistoMateriali.ImageList = Me.ImageListMenu
        Me.LblAcquistoMateriali.Location = New System.Drawing.Point(200, 0)
        Me.LblAcquistoMateriali.MaximumSize = New System.Drawing.Size(200, 100)
        Me.LblAcquistoMateriali.Name = "LblAcquistoMateriali"
        Me.LblAcquistoMateriali.Size = New System.Drawing.Size(200, 100)
        Me.LblAcquistoMateriali.TabIndex = 10
        Me.LblAcquistoMateriali.Text = "Acquisto Materiali"
        Me.LblAcquistoMateriali.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'LblPagamenti
        '
        Me.LblPagamenti.BackColor = System.Drawing.Color.Transparent
        Me.LblPagamenti.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblPagamenti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPagamenti.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblPagamenti.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LblPagamenti.ImageIndex = 8
        Me.LblPagamenti.ImageList = Me.ImageListMenu
        Me.LblPagamenti.Location = New System.Drawing.Point(0, 0)
        Me.LblPagamenti.MaximumSize = New System.Drawing.Size(200, 100)
        Me.LblPagamenti.Name = "LblPagamenti"
        Me.LblPagamenti.Size = New System.Drawing.Size(200, 100)
        Me.LblPagamenti.TabIndex = 9
        Me.LblPagamenti.Text = "Pagamento Dipententi"
        Me.LblPagamenti.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PnlLogo
        '
        Me.PnlLogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlLogo.BackgroundImage = Global.GRS_Magazzino.My.Resources.Resources.LOGO_FOTO
        Me.PnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlLogo.Controls.Add(Me.LblLicenza)
        Me.PnlLogo.Location = New System.Drawing.Point(226, 116)
        Me.PnlLogo.Name = "PnlLogo"
        Me.PnlLogo.Size = New System.Drawing.Size(956, 604)
        Me.PnlLogo.TabIndex = 6
        '
        'LblLicenza
        '
        Me.LblLicenza.AutoSize = True
        Me.LblLicenza.BackColor = System.Drawing.Color.White
        Me.LblLicenza.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblLicenza.ForeColor = System.Drawing.Color.Red
        Me.LblLicenza.Location = New System.Drawing.Point(567, 568)
        Me.LblLicenza.Name = "LblLicenza"
        Me.LblLicenza.Size = New System.Drawing.Size(0, 19)
        Me.LblLicenza.TabIndex = 20
        '
        'MenuGRS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1184, 721)
        Me.Controls.Add(Me.PnlLogo)
        Me.Controls.Add(Me.PnlBottoniO)
        Me.Controls.Add(Me.PnlBottoniV)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MenuGRS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menù Principale"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PnlBottoniV.ResumeLayout(False)
        Me.PnlBottoniO.ResumeLayout(False)
        Me.PnlLogo.ResumeLayout(False)
        Me.PnlLogo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageListMenu As ImageList
    Friend WithEvents PnlBottoniV As Panel
    Friend WithEvents LblArticoli As Label
    Friend WithEvents LblDipendenti As Label
    Friend WithEvents LblClienti As Label
    Friend WithEvents PnlBottoniO As Panel
    Friend WithEvents PnlLogo As Panel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LblLicenza As Label
    Friend WithEvents LblInterventi As Label
    Friend WithEvents LblAcquistoMateriali As Label
    Friend WithEvents LblPagamenti As Label
End Class
