<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schermata_grs_anagrafica
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TltTabella = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnAnnulla = New System.Windows.Forms.Button()
        Me.BtnFiltra = New System.Windows.Forms.Button()
        Me.BtnEsci = New System.Windows.Forms.Button()
        Me.Tsstabella = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TxtRicerca = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StsTabella = New System.Windows.Forms.StatusStrip()
        Me.PnlPiede = New System.Windows.Forms.Panel()
        Me.PnlCorpo = New System.Windows.Forms.Panel()
        Me.DgvCorpo = New System.Windows.Forms.DataGridView()
        Me.ClnRagiSoci = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClnDescReca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StsTabella.SuspendLayout()
        Me.PnlPiede.SuspendLayout()
        Me.PnlCorpo.SuspendLayout()
        CType(Me.DgvCorpo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnAnnulla
        '
        Me.BtnAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAnnulla.Location = New System.Drawing.Point(724, 19)
        Me.BtnAnnulla.Name = "BtnAnnulla"
        Me.BtnAnnulla.Size = New System.Drawing.Size(138, 26)
        Me.BtnAnnulla.TabIndex = 235
        Me.BtnAnnulla.Text = "<F8> Annulla"
        Me.TltTabella.SetToolTip(Me.BtnAnnulla, "<F8> Annulla")
        Me.BtnAnnulla.UseVisualStyleBackColor = True
        '
        'BtnFiltra
        '
        Me.BtnFiltra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFiltra.Location = New System.Drawing.Point(570, 19)
        Me.BtnFiltra.Name = "BtnFiltra"
        Me.BtnFiltra.Size = New System.Drawing.Size(138, 26)
        Me.BtnFiltra.TabIndex = 234
        Me.BtnFiltra.Text = "<F7> Filtra"
        Me.TltTabella.SetToolTip(Me.BtnFiltra, "<F7> Filtra")
        Me.BtnFiltra.UseVisualStyleBackColor = True
        '
        'BtnEsci
        '
        Me.BtnEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEsci.Location = New System.Drawing.Point(929, 11)
        Me.BtnEsci.Name = "BtnEsci"
        Me.BtnEsci.Size = New System.Drawing.Size(137, 34)
        Me.BtnEsci.TabIndex = 236
        Me.BtnEsci.Text = "Esci"
        Me.TltTabella.SetToolTip(Me.BtnEsci, "Esci")
        Me.BtnEsci.UseVisualStyleBackColor = True
        '
        'Tsstabella
        '
        Me.Tsstabella.BackColor = System.Drawing.SystemColors.Control
        Me.Tsstabella.ForeColor = System.Drawing.Color.Blue
        Me.Tsstabella.Name = "Tsstabella"
        Me.Tsstabella.Size = New System.Drawing.Size(37, 17)
        Me.Tsstabella.Text = "          "
        '
        'TxtRicerca
        '
        Me.TxtRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtRicerca.Location = New System.Drawing.Point(17, 25)
        Me.TxtRicerca.Name = "TxtRicerca"
        Me.TxtRicerca.Size = New System.Drawing.Size(192, 20)
        Me.TxtRicerca.TabIndex = 231
        Me.TltTabella.SetToolTip(Me.TxtRicerca, "Ricerca")
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(18, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 230
        Me.Label2.Text = "Ricerca"
        '
        'StsTabella
        '
        Me.StsTabella.BackColor = System.Drawing.SystemColors.Control
        Me.StsTabella.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StsTabella.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsstabella})
        Me.StsTabella.Location = New System.Drawing.Point(0, 55)
        Me.StsTabella.Name = "StsTabella"
        Me.StsTabella.Padding = New System.Windows.Forms.Padding(1, 0, 9, 0)
        Me.StsTabella.Size = New System.Drawing.Size(1088, 22)
        Me.StsTabella.TabIndex = 217
        Me.StsTabella.Text = "StatusStrip1"
        '
        'PnlPiede
        '
        Me.PnlPiede.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlPiede.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnlPiede.Controls.Add(Me.BtnEsci)
        Me.PnlPiede.Controls.Add(Me.BtnAnnulla)
        Me.PnlPiede.Controls.Add(Me.BtnFiltra)
        Me.PnlPiede.Controls.Add(Me.TxtRicerca)
        Me.PnlPiede.Controls.Add(Me.Label2)
        Me.PnlPiede.Controls.Add(Me.StsTabella)
        Me.PnlPiede.Location = New System.Drawing.Point(7, 629)
        Me.PnlPiede.Name = "PnlPiede"
        Me.PnlPiede.Size = New System.Drawing.Size(1088, 77)
        Me.PnlPiede.TabIndex = 4
        '
        'PnlCorpo
        '
        Me.PnlCorpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlCorpo.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnlCorpo.Controls.Add(Me.DgvCorpo)
        Me.PnlCorpo.Location = New System.Drawing.Point(7, 4)
        Me.PnlCorpo.Name = "PnlCorpo"
        Me.PnlCorpo.Size = New System.Drawing.Size(1088, 619)
        Me.PnlCorpo.TabIndex = 1
        '
        'DgvCorpo
        '
        Me.DgvCorpo.AllowUserToAddRows = False
        Me.DgvCorpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvCorpo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvCorpo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCorpo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClnRagiSoci, Me.ClnDescReca})
        Me.DgvCorpo.Location = New System.Drawing.Point(5, 8)
        Me.DgvCorpo.Name = "DgvCorpo"
        Me.DgvCorpo.ReadOnly = True
        Me.DgvCorpo.RowHeadersVisible = False
        Me.DgvCorpo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCorpo.Size = New System.Drawing.Size(1077, 607)
        Me.DgvCorpo.TabIndex = 0
        Me.TltTabella.SetToolTip(Me.DgvCorpo, "<Inse> Inserim. - <Enter> Modifica - <Canc> Cancella")
        '
        'ClnRagiSoci
        '
        Me.ClnRagiSoci.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ClnRagiSoci.DataPropertyName = "ragi_socia"
        Me.ClnRagiSoci.HeaderText = "Ragione Sociale"
        Me.ClnRagiSoci.MinimumWidth = 200
        Me.ClnRagiSoci.Name = "ClnRagiSoci"
        Me.ClnRagiSoci.ReadOnly = True
        '
        'ClnDescReca
        '
        Me.ClnDescReca.DataPropertyName = "desc_recap"
        Me.ClnDescReca.HeaderText = "Recapito"
        Me.ClnDescReca.MinimumWidth = 200
        Me.ClnDescReca.Name = "ClnDescReca"
        Me.ClnDescReca.ReadOnly = True
        Me.ClnDescReca.Width = 200
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Controls.Add(Me.PnlPiede)
        Me.Panel1.Controls.Add(Me.PnlCorpo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1104, 714)
        Me.Panel1.TabIndex = 1
        '
        'Schermata_grs_anagrafica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 714)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Schermata_grs_anagrafica"
        Me.Text = "Schermata_grs_anagrafica"
        Me.StsTabella.ResumeLayout(False)
        Me.StsTabella.PerformLayout()
        Me.PnlPiede.ResumeLayout(False)
        Me.PnlPiede.PerformLayout()
        Me.PnlCorpo.ResumeLayout(False)
        CType(Me.DgvCorpo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TltTabella As ToolTip
    Friend WithEvents Tsstabella As ToolStripStatusLabel
    Friend WithEvents BtnAnnulla As Button
    Friend WithEvents BtnFiltra As Button
    Friend WithEvents TxtRicerca As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StsTabella As StatusStrip
    Friend WithEvents PnlPiede As Panel
    Friend WithEvents PnlCorpo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DgvCorpo As DataGridView
    Friend WithEvents BtnEsci As Button
    Friend WithEvents ClnRagiSoci As DataGridViewTextBoxColumn
    Friend WithEvents ClnDescReca As DataGridViewTextBoxColumn
End Class
