<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schermata_grs_inventario
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PnlPiede = New System.Windows.Forms.Panel()
        Me.BtnEsci = New System.Windows.Forms.Button()
        Me.BtnAnnulla = New System.Windows.Forms.Button()
        Me.BtnFiltra = New System.Windows.Forms.Button()
        Me.TxtRicerca = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StsTabella = New System.Windows.Forms.StatusStrip()
        Me.Tsstabella = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PnlCorpo = New System.Windows.Forms.Panel()
        Me.DgvCorpo = New System.Windows.Forms.DataGridView()
        Me.TltTabella = New System.Windows.Forms.ToolTip(Me.components)
        Me.ClnArticolo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.PnlPiede.SuspendLayout()
        Me.StsTabella.SuspendLayout()
        Me.PnlCorpo.SuspendLayout()
        CType(Me.DgvCorpo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Panel1.TabIndex = 2
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
        'BtnEsci
        '
        Me.BtnEsci.Location = New System.Drawing.Point(929, 11)
        Me.BtnEsci.Name = "BtnEsci"
        Me.BtnEsci.Size = New System.Drawing.Size(137, 34)
        Me.BtnEsci.TabIndex = 236
        Me.BtnEsci.Text = "Esci"
        Me.BtnEsci.UseVisualStyleBackColor = True
        '
        'BtnAnnulla
        '
        Me.BtnAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAnnulla.Location = New System.Drawing.Point(716, 19)
        Me.BtnAnnulla.Name = "BtnAnnulla"
        Me.BtnAnnulla.Size = New System.Drawing.Size(138, 26)
        Me.BtnAnnulla.TabIndex = 235
        Me.BtnAnnulla.Text = "<F8> Annulla"
        Me.BtnAnnulla.UseVisualStyleBackColor = True
        '
        'BtnFiltra
        '
        Me.BtnFiltra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFiltra.Location = New System.Drawing.Point(558, 19)
        Me.BtnFiltra.Name = "BtnFiltra"
        Me.BtnFiltra.Size = New System.Drawing.Size(138, 26)
        Me.BtnFiltra.TabIndex = 234
        Me.BtnFiltra.Text = "<F7> Filtra"
        Me.BtnFiltra.UseVisualStyleBackColor = True
        '
        'TxtRicerca
        '
        Me.TxtRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtRicerca.Location = New System.Drawing.Point(17, 25)
        Me.TxtRicerca.Name = "TxtRicerca"
        Me.TxtRicerca.Size = New System.Drawing.Size(192, 20)
        Me.TxtRicerca.TabIndex = 231
        Me.TltTabella.SetToolTip(Me.TxtRicerca, "Descrizione")
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
        Me.Label2.Size = New System.Drawing.Size(83, 15)
        Me.Label2.TabIndex = 230
        Me.Label2.Text = "Descrizione"
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
        'Tsstabella
        '
        Me.Tsstabella.BackColor = System.Drawing.SystemColors.Control
        Me.Tsstabella.ForeColor = System.Drawing.Color.Blue
        Me.Tsstabella.Name = "Tsstabella"
        Me.Tsstabella.Size = New System.Drawing.Size(37, 17)
        Me.Tsstabella.Text = "          "
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
        Me.DgvCorpo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClnArticolo, Me.Column2, Me.Column3})
        Me.DgvCorpo.Location = New System.Drawing.Point(5, 8)
        Me.DgvCorpo.Name = "DgvCorpo"
        Me.DgvCorpo.RowHeadersVisible = False
        Me.DgvCorpo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCorpo.Size = New System.Drawing.Size(1077, 607)
        Me.DgvCorpo.TabIndex = 0
        '
        'ClnArticolo
        '
        Me.ClnArticolo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ClnArticolo.DataPropertyName = "desc_artic"
        Me.ClnArticolo.HeaderText = "Articolo"
        Me.ClnArticolo.MinimumWidth = 200
        Me.ClnArticolo.Name = "ClnArticolo"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "prez_unita"
        Me.Column2.HeaderText = "Costo"
        Me.Column2.MinimumWidth = 200
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.DataPropertyName = "quan_artic"
        Me.Column3.HeaderText = "Quantità"
        Me.Column3.MinimumWidth = 200
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 200
        '
        'Schermata_grs_inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 714)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Schermata_grs_inventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Schermata_grs_inventario"
        Me.Panel1.ResumeLayout(False)
        Me.PnlPiede.ResumeLayout(False)
        Me.PnlPiede.PerformLayout()
        Me.StsTabella.ResumeLayout(False)
        Me.StsTabella.PerformLayout()
        Me.PnlCorpo.ResumeLayout(False)
        CType(Me.DgvCorpo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PnlPiede As Panel
    Friend WithEvents BtnEsci As Button
    Friend WithEvents BtnAnnulla As Button
    Friend WithEvents BtnFiltra As Button
    Friend WithEvents TxtRicerca As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StsTabella As StatusStrip
    Friend WithEvents Tsstabella As ToolStripStatusLabel
    Friend WithEvents PnlCorpo As Panel
    Friend WithEvents DgvCorpo As DataGridView
    Friend WithEvents TltTabella As ToolTip
    Friend WithEvents ClnArticolo As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
