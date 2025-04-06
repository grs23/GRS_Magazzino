<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schermata_grs_interventi
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
        Me.PnlDati = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtCostInte = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtPrezVend = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDescLavo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtFineInte = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtInizInte = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDescClie = New System.Windows.Forms.TextBox()
        Me.PnlTestata = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNumeInte = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtAnnoInte = New System.Windows.Forms.TextBox()
        Me.PnlPiede = New System.Windows.Forms.Panel()
        Me.BtnCancella = New System.Windows.Forms.Button()
        Me.BtnNuovo = New System.Windows.Forms.Button()
        Me.BtnSalva = New System.Windows.Forms.Button()
        Me.BtnEsci = New System.Windows.Forms.Button()
        Me.StsTabella = New System.Windows.Forms.StatusStrip()
        Me.Tsstabella = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PnlCorpo = New System.Windows.Forms.Panel()
        Me.DgvCorpo = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TltTabella = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.PnlDati.SuspendLayout()
        Me.PnlTestata.SuspendLayout()
        Me.PnlPiede.SuspendLayout()
        Me.StsTabella.SuspendLayout()
        Me.PnlCorpo.SuspendLayout()
        CType(Me.DgvCorpo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Controls.Add(Me.PnlDati)
        Me.Panel1.Controls.Add(Me.PnlTestata)
        Me.Panel1.Controls.Add(Me.PnlPiede)
        Me.Panel1.Controls.Add(Me.PnlCorpo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1104, 714)
        Me.Panel1.TabIndex = 0
        '
        'PnlDati
        '
        Me.PnlDati.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlDati.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnlDati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlDati.Controls.Add(Me.Label9)
        Me.PnlDati.Controls.Add(Me.TxtCostInte)
        Me.PnlDati.Controls.Add(Me.Label8)
        Me.PnlDati.Controls.Add(Me.TxtPrezVend)
        Me.PnlDati.Controls.Add(Me.Label7)
        Me.PnlDati.Controls.Add(Me.TxtDescLavo)
        Me.PnlDati.Controls.Add(Me.Label6)
        Me.PnlDati.Controls.Add(Me.TxtFineInte)
        Me.PnlDati.Controls.Add(Me.Label5)
        Me.PnlDati.Controls.Add(Me.TxtInizInte)
        Me.PnlDati.Controls.Add(Me.Label4)
        Me.PnlDati.Controls.Add(Me.TxtDescClie)
        Me.PnlDati.Location = New System.Drawing.Point(7, 93)
        Me.PnlDati.Name = "PnlDati"
        Me.PnlDati.Size = New System.Drawing.Size(1088, 304)
        Me.PnlDati.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Location = New System.Drawing.Point(284, 243)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 20)
        Me.Label9.TabIndex = 234
        Me.Label9.Text = "Costo"
        '
        'TxtCostInte
        '
        Me.TxtCostInte.Location = New System.Drawing.Point(190, 266)
        Me.TxtCostInte.MaxLength = 7
        Me.TxtCostInte.Name = "TxtCostInte"
        Me.TxtCostInte.ReadOnly = True
        Me.TxtCostInte.Size = New System.Drawing.Size(150, 20)
        Me.TxtCostInte.TabIndex = 5
        Me.TxtCostInte.TabStop = False
        Me.TxtCostInte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtCostInte, "Costo dei materiali")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Location = New System.Drawing.Point(16, 243)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 20)
        Me.Label8.TabIndex = 232
        Me.Label8.Text = "Prezzo di vendita"
        '
        'TxtPrezVend
        '
        Me.TxtPrezVend.Location = New System.Drawing.Point(10, 266)
        Me.TxtPrezVend.MaxLength = 7
        Me.TxtPrezVend.Name = "TxtPrezVend"
        Me.TxtPrezVend.Size = New System.Drawing.Size(150, 20)
        Me.TxtPrezVend.TabIndex = 4
        Me.TxtPrezVend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtPrezVend, "Prezzo di vendita")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Location = New System.Drawing.Point(10, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 20)
        Me.Label7.TabIndex = 230
        Me.Label7.Text = "Note"
        '
        'TxtDescLavo
        '
        Me.TxtDescLavo.Location = New System.Drawing.Point(10, 154)
        Me.TxtDescLavo.MaxLength = 300
        Me.TxtDescLavo.Multiline = True
        Me.TxtDescLavo.Name = "TxtDescLavo"
        Me.TxtDescLavo.Size = New System.Drawing.Size(750, 74)
        Me.TxtDescLavo.TabIndex = 3
        Me.TltTabella.SetToolTip(Me.TxtDescLavo, "Descrizione Intervento")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(143, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 20)
        Me.Label6.TabIndex = 228
        Me.Label6.Text = "Fine"
        '
        'TxtFineInte
        '
        Me.TxtFineInte.Location = New System.Drawing.Point(147, 94)
        Me.TxtFineInte.Mask = "00/00/0000"
        Me.TxtFineInte.Name = "TxtFineInte"
        Me.TxtFineInte.Size = New System.Drawing.Size(70, 20)
        Me.TxtFineInte.TabIndex = 2
        Me.TltTabella.SetToolTip(Me.TxtFineInte, "Fine Intervento")
        Me.TxtFineInte.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(10, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 20)
        Me.Label5.TabIndex = 226
        Me.Label5.Text = "Inizio"
        '
        'TxtInizInte
        '
        Me.TxtInizInte.Location = New System.Drawing.Point(10, 94)
        Me.TxtInizInte.Mask = "00/00/0000"
        Me.TxtInizInte.Name = "TxtInizInte"
        Me.TxtInizInte.Size = New System.Drawing.Size(70, 20)
        Me.TxtInizInte.TabIndex = 1
        Me.TltTabella.SetToolTip(Me.TxtInizInte, "Inizio Intervento")
        Me.TxtInizInte.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(10, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Cliente"
        '
        'TxtDescClie
        '
        Me.TxtDescClie.Location = New System.Drawing.Point(10, 33)
        Me.TxtDescClie.MaxLength = 100
        Me.TxtDescClie.Name = "TxtDescClie"
        Me.TxtDescClie.Size = New System.Drawing.Size(750, 20)
        Me.TxtDescClie.TabIndex = 0
        Me.TltTabella.SetToolTip(Me.TxtDescClie, "Ragione sociale Cliente")
        '
        'PnlTestata
        '
        Me.PnlTestata.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlTestata.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnlTestata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlTestata.Controls.Add(Me.Label1)
        Me.PnlTestata.Controls.Add(Me.TxtNumeInte)
        Me.PnlTestata.Controls.Add(Me.Label3)
        Me.PnlTestata.Controls.Add(Me.TxtAnnoInte)
        Me.PnlTestata.Location = New System.Drawing.Point(7, 12)
        Me.PnlTestata.Name = "PnlTestata"
        Me.PnlTestata.Size = New System.Drawing.Size(1088, 75)
        Me.PnlTestata.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(79, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 20)
        Me.Label1.TabIndex = 225
        Me.Label1.Text = "Prog."
        '
        'TxtNumeInte
        '
        Me.TxtNumeInte.Location = New System.Drawing.Point(80, 46)
        Me.TxtNumeInte.MaxLength = 13
        Me.TxtNumeInte.Name = "TxtNumeInte"
        Me.TxtNumeInte.Size = New System.Drawing.Size(50, 20)
        Me.TxtNumeInte.TabIndex = 1
        Me.TxtNumeInte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtNumeInte, "Progressivo annuale intervento")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(10, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 20)
        Me.Label3.TabIndex = 223
        Me.Label3.Text = "Anno"
        '
        'TxtAnnoInte
        '
        Me.TxtAnnoInte.Location = New System.Drawing.Point(10, 46)
        Me.TxtAnnoInte.MaxLength = 13
        Me.TxtAnnoInte.Name = "TxtAnnoInte"
        Me.TxtAnnoInte.Size = New System.Drawing.Size(50, 20)
        Me.TxtAnnoInte.TabIndex = 0
        Me.TxtAnnoInte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtAnnoInte, "Anno Intervento")
        '
        'PnlPiede
        '
        Me.PnlPiede.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlPiede.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnlPiede.Controls.Add(Me.BtnCancella)
        Me.PnlPiede.Controls.Add(Me.BtnNuovo)
        Me.PnlPiede.Controls.Add(Me.BtnSalva)
        Me.PnlPiede.Controls.Add(Me.BtnEsci)
        Me.PnlPiede.Controls.Add(Me.StsTabella)
        Me.PnlPiede.Location = New System.Drawing.Point(7, 629)
        Me.PnlPiede.Name = "PnlPiede"
        Me.PnlPiede.Size = New System.Drawing.Size(1088, 77)
        Me.PnlPiede.TabIndex = 3
        '
        'BtnCancella
        '
        Me.BtnCancella.Location = New System.Drawing.Point(786, 11)
        Me.BtnCancella.Name = "BtnCancella"
        Me.BtnCancella.Size = New System.Drawing.Size(137, 34)
        Me.BtnCancella.TabIndex = 2
        Me.BtnCancella.Text = "Cancella"
        Me.BtnCancella.UseVisualStyleBackColor = True
        '
        'BtnNuovo
        '
        Me.BtnNuovo.Location = New System.Drawing.Point(643, 11)
        Me.BtnNuovo.Name = "BtnNuovo"
        Me.BtnNuovo.Size = New System.Drawing.Size(137, 34)
        Me.BtnNuovo.TabIndex = 1
        Me.BtnNuovo.Text = "Nuovo"
        Me.BtnNuovo.UseVisualStyleBackColor = True
        '
        'BtnSalva
        '
        Me.BtnSalva.Location = New System.Drawing.Point(500, 11)
        Me.BtnSalva.Name = "BtnSalva"
        Me.BtnSalva.Size = New System.Drawing.Size(137, 34)
        Me.BtnSalva.TabIndex = 0
        Me.BtnSalva.Text = "Salva"
        Me.BtnSalva.UseVisualStyleBackColor = True
        '
        'BtnEsci
        '
        Me.BtnEsci.Location = New System.Drawing.Point(929, 11)
        Me.BtnEsci.Name = "BtnEsci"
        Me.BtnEsci.Size = New System.Drawing.Size(137, 34)
        Me.BtnEsci.TabIndex = 3
        Me.BtnEsci.Text = "Esci"
        Me.BtnEsci.UseVisualStyleBackColor = True
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
        Me.PnlCorpo.Location = New System.Drawing.Point(7, 403)
        Me.PnlCorpo.Name = "PnlCorpo"
        Me.PnlCorpo.Size = New System.Drawing.Size(1088, 220)
        Me.PnlCorpo.TabIndex = 2
        '
        'DgvCorpo
        '
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
        Me.DgvCorpo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.DgvCorpo.Location = New System.Drawing.Point(5, 8)
        Me.DgvCorpo.Name = "DgvCorpo"
        Me.DgvCorpo.RowHeadersVisible = False
        Me.DgvCorpo.Size = New System.Drawing.Size(1077, 208)
        Me.DgvCorpo.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Articolo"
        Me.Column1.MinimumWidth = 200
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Costo"
        Me.Column2.MinimumWidth = 200
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.HeaderText = "Quantità"
        Me.Column3.MinimumWidth = 200
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 200
        '
        'Schermata_grs_interventi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 714)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Schermata_grs_interventi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Intervento"
        Me.Panel1.ResumeLayout(False)
        Me.PnlDati.ResumeLayout(False)
        Me.PnlDati.PerformLayout()
        Me.PnlTestata.ResumeLayout(False)
        Me.PnlTestata.PerformLayout()
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
    Friend WithEvents StsTabella As StatusStrip
    Friend WithEvents Tsstabella As ToolStripStatusLabel
    Friend WithEvents PnlCorpo As Panel
    Friend WithEvents DgvCorpo As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents TltTabella As ToolTip
    Friend WithEvents PnlDati As Panel
    Friend WithEvents PnlTestata As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtNumeInte As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtAnnoInte As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtDescClie As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtFineInte As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtInizInte As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtDescLavo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtCostInte As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtPrezVend As TextBox
    Friend WithEvents BtnCancella As Button
    Friend WithEvents BtnNuovo As Button
    Friend WithEvents BtnSalva As Button
End Class
