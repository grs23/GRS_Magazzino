<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schermata_grs_Pagamenti_dipendenti_Modi
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PnlCorpo = New System.Windows.Forms.Panel()
        Me.StsTabella = New System.Windows.Forms.StatusStrip()
        Me.Tsstabella = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDescDipe = New System.Windows.Forms.TextBox()
        Me.TxtDescPaga = New System.Windows.Forms.TextBox()
        Me.TxtImpoPaga = New System.Windows.Forms.TextBox()
        Me.TxtDataPaga = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnSalva = New System.Windows.Forms.Button()
        Me.BtnEsci = New System.Windows.Forms.Button()
        Me.TltTabella = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.PnlCorpo.SuspendLayout()
        Me.StsTabella.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Controls.Add(Me.PnlCorpo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 226)
        Me.Panel1.TabIndex = 0
        '
        'PnlCorpo
        '
        Me.PnlCorpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlCorpo.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PnlCorpo.Controls.Add(Me.StsTabella)
        Me.PnlCorpo.Controls.Add(Me.Label1)
        Me.PnlCorpo.Controls.Add(Me.Label4)
        Me.PnlCorpo.Controls.Add(Me.TxtDescDipe)
        Me.PnlCorpo.Controls.Add(Me.TxtDescPaga)
        Me.PnlCorpo.Controls.Add(Me.TxtImpoPaga)
        Me.PnlCorpo.Controls.Add(Me.TxtDataPaga)
        Me.PnlCorpo.Controls.Add(Me.Label2)
        Me.PnlCorpo.Controls.Add(Me.Label3)
        Me.PnlCorpo.Controls.Add(Me.BtnSalva)
        Me.PnlCorpo.Controls.Add(Me.BtnEsci)
        Me.PnlCorpo.Location = New System.Drawing.Point(12, 12)
        Me.PnlCorpo.Name = "PnlCorpo"
        Me.PnlCorpo.Size = New System.Drawing.Size(776, 202)
        Me.PnlCorpo.TabIndex = 0
        '
        'StsTabella
        '
        Me.StsTabella.BackColor = System.Drawing.SystemColors.Control
        Me.StsTabella.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StsTabella.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsstabella})
        Me.StsTabella.Location = New System.Drawing.Point(0, 180)
        Me.StsTabella.Name = "StsTabella"
        Me.StsTabella.Padding = New System.Windows.Forms.Padding(1, 0, 9, 0)
        Me.StsTabella.Size = New System.Drawing.Size(776, 22)
        Me.StsTabella.TabIndex = 561
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Dipendente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(12, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 20)
        Me.Label4.TabIndex = 560
        Me.Label4.Text = "Dettagli Pagamento"
        '
        'TxtDescDipe
        '
        Me.TxtDescDipe.Location = New System.Drawing.Point(16, 38)
        Me.TxtDescDipe.MaxLength = 100
        Me.TxtDescDipe.Name = "TxtDescDipe"
        Me.TxtDescDipe.Size = New System.Drawing.Size(750, 20)
        Me.TxtDescDipe.TabIndex = 0
        Me.TltTabella.SetToolTip(Me.TxtDescDipe, "Dipendente - <F6> Elenco")
        '
        'TxtDescPaga
        '
        Me.TxtDescPaga.Location = New System.Drawing.Point(16, 92)
        Me.TxtDescPaga.MaxLength = 100
        Me.TxtDescPaga.Name = "TxtDescPaga"
        Me.TxtDescPaga.Size = New System.Drawing.Size(750, 20)
        Me.TxtDescPaga.TabIndex = 1
        Me.TltTabella.SetToolTip(Me.TxtDescPaga, "Dettaglio Pagamento")
        '
        'TxtImpoPaga
        '
        Me.TxtImpoPaga.Location = New System.Drawing.Point(218, 147)
        Me.TxtImpoPaga.MaxLength = 20
        Me.TxtImpoPaga.Name = "TxtImpoPaga"
        Me.TxtImpoPaga.Size = New System.Drawing.Size(100, 20)
        Me.TxtImpoPaga.TabIndex = 3
        Me.TxtImpoPaga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtImpoPaga, "Importo del Pagamento")
        '
        'TxtDataPaga
        '
        Me.TxtDataPaga.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.TxtDataPaga.Location = New System.Drawing.Point(16, 147)
        Me.TxtDataPaga.Mask = "00/00/0000"
        Me.TxtDataPaga.Name = "TxtDataPaga"
        Me.TxtDataPaga.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtDataPaga.Size = New System.Drawing.Size(82, 20)
        Me.TxtDataPaga.TabIndex = 2
        Me.TxtDataPaga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TltTabella.SetToolTip(Me.TxtDataPaga, "Data Pagamento")
        Me.TxtDataPaga.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(247, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Importo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 558
        Me.Label3.Text = "Data"
        '
        'BtnSalva
        '
        Me.BtnSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalva.Location = New System.Drawing.Point(469, 133)
        Me.BtnSalva.Name = "BtnSalva"
        Me.BtnSalva.Size = New System.Drawing.Size(137, 34)
        Me.BtnSalva.TabIndex = 4
        Me.BtnSalva.Text = "Salva"
        Me.BtnSalva.UseVisualStyleBackColor = True
        '
        'BtnEsci
        '
        Me.BtnEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEsci.Location = New System.Drawing.Point(625, 133)
        Me.BtnEsci.Name = "BtnEsci"
        Me.BtnEsci.Size = New System.Drawing.Size(137, 34)
        Me.BtnEsci.TabIndex = 5
        Me.BtnEsci.Text = "Esci"
        Me.BtnEsci.UseVisualStyleBackColor = True
        '
        'Schermata_grs_Pagamenti_dipendenti_Modi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 226)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Schermata_grs_Pagamenti_dipendenti_Modi"
        Me.Text = "Pagamenti_grs_dipendenti_Modi"
        Me.Panel1.ResumeLayout(False)
        Me.PnlCorpo.ResumeLayout(False)
        Me.PnlCorpo.PerformLayout()
        Me.StsTabella.ResumeLayout(False)
        Me.StsTabella.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnEsci As Button
    Friend WithEvents BtnSalva As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtImpoPaga As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtDescDipe As TextBox
    Friend WithEvents TxtDataPaga As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtDescPaga As TextBox
    Friend WithEvents TltTabella As ToolTip
    Friend WithEvents PnlCorpo As Panel
    Friend WithEvents StsTabella As StatusStrip
    Friend WithEvents Tsstabella As ToolStripStatusLabel
End Class
