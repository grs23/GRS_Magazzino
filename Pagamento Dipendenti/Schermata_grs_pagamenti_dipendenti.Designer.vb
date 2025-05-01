<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schermata_grs_Pagamenti_dipendenti
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
        Me.BtnEsci = New System.Windows.Forms.Button()
        Me.BtnAnnulla = New System.Windows.Forms.Button()
        Me.BtnFiltra = New System.Windows.Forms.Button()
        Me.Tsstabella = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TxtRicerca = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StsTabella = New System.Windows.Forms.StatusStrip()
        Me.PnlPiede = New System.Windows.Forms.Panel()
        Me.PnlCorpo = New System.Windows.Forms.Panel()
        Me.DgvCorpo = New System.Windows.Forms.DataGridView()
        Me.ClnDipendente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClnImpoPagam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PnlTestata = New System.Windows.Forms.Panel()
        Me.TxtDallData = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtAllaData = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StsTabella.SuspendLayout()
        Me.PnlPiede.SuspendLayout()
        Me.PnlCorpo.SuspendLayout()
        CType(Me.DgvCorpo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PnlTestata.SuspendLayout()
        Me.SuspendLayout()
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
        'BtnAnnulla
        '
        Me.BtnAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAnnulla.Location = New System.Drawing.Point(740, 23)
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
        Me.BtnFiltra.Location = New System.Drawing.Point(596, 23)
        Me.BtnFiltra.Name = "BtnFiltra"
        Me.BtnFiltra.Size = New System.Drawing.Size(138, 26)
        Me.BtnFiltra.TabIndex = 234
        Me.BtnFiltra.Text = "<F7> Filtra"
        Me.TltTabella.SetToolTip(Me.BtnFiltra, "<F7> Filtra")
        Me.BtnFiltra.UseVisualStyleBackColor = True
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
        Me.TxtRicerca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
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
        Me.StsTabella.Size = New System.Drawing.Size(1085, 22)
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
        Me.PnlPiede.Location = New System.Drawing.Point(7, 607)
        Me.PnlPiede.Name = "PnlPiede"
        Me.PnlPiede.Size = New System.Drawing.Size(1085, 77)
        Me.PnlPiede.TabIndex = 4
        '
        'PnlCorpo
        '
        Me.PnlCorpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlCorpo.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnlCorpo.Controls.Add(Me.DgvCorpo)
        Me.PnlCorpo.Location = New System.Drawing.Point(7, 73)
        Me.PnlCorpo.Name = "PnlCorpo"
        Me.PnlCorpo.Size = New System.Drawing.Size(1085, 528)
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
        Me.DgvCorpo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClnDipendente, Me.ClnImpoPagam})
        Me.DgvCorpo.Location = New System.Drawing.Point(5, 8)
        Me.DgvCorpo.Name = "DgvCorpo"
        Me.DgvCorpo.RowHeadersVisible = False
        Me.DgvCorpo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCorpo.Size = New System.Drawing.Size(1074, 516)
        Me.DgvCorpo.TabIndex = 0
        Me.TltTabella.SetToolTip(Me.DgvCorpo, "<Inse> Inserim. - <Enter> Modifica - <Canc> Cancella")
        '
        'ClnDipendente
        '
        Me.ClnDipendente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ClnDipendente.DataPropertyName = "dipendente"
        Me.ClnDipendente.HeaderText = "Dipendente"
        Me.ClnDipendente.MinimumWidth = 150
        Me.ClnDipendente.Name = "ClnDipendente"
        '
        'ClnImpoPagam
        '
        Me.ClnImpoPagam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ClnImpoPagam.DataPropertyName = "importopagamento"
        Me.ClnImpoPagam.HeaderText = "Importo Pagato"
        Me.ClnImpoPagam.MinimumWidth = 150
        Me.ClnImpoPagam.Name = "ClnImpoPagam"
        Me.ClnImpoPagam.Width = 150
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Controls.Add(Me.PnlTestata)
        Me.Panel1.Controls.Add(Me.PnlPiede)
        Me.Panel1.Controls.Add(Me.PnlCorpo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1101, 692)
        Me.Panel1.TabIndex = 2
        '
        'PnlTestata
        '
        Me.PnlTestata.Controls.Add(Me.TxtDallData)
        Me.PnlTestata.Controls.Add(Me.Label1)
        Me.PnlTestata.Controls.Add(Me.TxtAllaData)
        Me.PnlTestata.Controls.Add(Me.Label4)
        Me.PnlTestata.Location = New System.Drawing.Point(7, 12)
        Me.PnlTestata.Name = "PnlTestata"
        Me.PnlTestata.Size = New System.Drawing.Size(1085, 55)
        Me.PnlTestata.TabIndex = 5
        '
        'TxtDallData
        '
        Me.TxtDallData.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.TxtDallData.Location = New System.Drawing.Point(17, 24)
        Me.TxtDallData.Mask = "00/00/0000"
        Me.TxtDallData.Name = "TxtDallData"
        Me.TxtDallData.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtDallData.Size = New System.Drawing.Size(82, 20)
        Me.TxtDallData.TabIndex = 554
        Me.TxtDallData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TltTabella.SetToolTip(Me.TxtDallData, "Dalla data")
        Me.TxtDallData.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 556
        Me.Label1.Text = "Dalla Data"
        '
        'TxtAllaData
        '
        Me.TxtAllaData.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.TxtAllaData.Location = New System.Drawing.Point(143, 24)
        Me.TxtAllaData.Mask = "00/00/0000"
        Me.TxtAllaData.Name = "TxtAllaData"
        Me.TxtAllaData.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtAllaData.Size = New System.Drawing.Size(82, 20)
        Me.TxtAllaData.TabIndex = 555
        Me.TxtAllaData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TltTabella.SetToolTip(Me.TxtAllaData, "Alla data")
        Me.TxtAllaData.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(143, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 15)
        Me.Label4.TabIndex = 557
        Me.Label4.Text = "Alla Data"
        '
        'Schermata_grs_Pagamenti_dipendenti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 692)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Schermata_grs_Pagamenti_dipendenti"
        Me.Text = "pagamenti_dipendenti"
        Me.StsTabella.ResumeLayout(False)
        Me.StsTabella.PerformLayout()
        Me.PnlPiede.ResumeLayout(False)
        Me.PnlPiede.PerformLayout()
        Me.PnlCorpo.ResumeLayout(False)
        CType(Me.DgvCorpo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PnlTestata.ResumeLayout(False)
        Me.PnlTestata.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TltTabella As ToolTip
    Friend WithEvents BtnEsci As Button
    Friend WithEvents BtnAnnulla As Button
    Friend WithEvents BtnFiltra As Button
    Friend WithEvents Tsstabella As ToolStripStatusLabel
    Friend WithEvents TxtRicerca As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StsTabella As StatusStrip
    Friend WithEvents PnlPiede As Panel
    Friend WithEvents PnlCorpo As Panel
    Friend WithEvents DgvCorpo As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PnlTestata As Panel
    Friend WithEvents TxtDallData As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtAllaData As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ClnDipendente As DataGridViewTextBoxColumn
    Friend WithEvents ClnImpoPagam As DataGridViewTextBoxColumn
End Class
