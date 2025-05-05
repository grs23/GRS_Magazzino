<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schermata_grs_inventario_Modi
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtPrezUnita = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtUnitMisur = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtQuantMinim = New System.Windows.Forms.TextBox()
        Me.BtnEsci = New System.Windows.Forms.Button()
        Me.BtnSalva = New System.Windows.Forms.Button()
        Me.StsTabella = New System.Windows.Forms.StatusStrip()
        Me.Tsstabella = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtQuantArtic = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtDescArtic = New System.Windows.Forms.TextBox()
        Me.TltTabella = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.StsTabella.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtPrezUnita)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtUnitMisur)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtQuantMinim)
        Me.Panel1.Controls.Add(Me.BtnEsci)
        Me.Panel1.Controls.Add(Me.BtnSalva)
        Me.Panel1.Controls.Add(Me.StsTabella)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtQuantArtic)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtDescArtic)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(795, 339)
        Me.Panel1.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(651, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 225
        Me.Label5.Text = "Prezzo Unitario"
        '
        'TxtPrezUnita
        '
        Me.TxtPrezUnita.Location = New System.Drawing.Point(612, 158)
        Me.TxtPrezUnita.MaxLength = 7
        Me.TxtPrezUnita.Name = "TxtPrezUnita"
        Me.TxtPrezUnita.Size = New System.Drawing.Size(150, 20)
        Me.TxtPrezUnita.TabIndex = 4
        Me.TxtPrezUnita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtPrezUnita, "Prezzo unitario")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(183, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 20)
        Me.Label4.TabIndex = 223
        Me.Label4.Text = "U.M."
        '
        'TxtUnitMisur
        '
        Me.TxtUnitMisur.Location = New System.Drawing.Point(187, 158)
        Me.TxtUnitMisur.MaxLength = 2
        Me.TxtUnitMisur.Name = "TxtUnitMisur"
        Me.TxtUnitMisur.Size = New System.Drawing.Size(50, 20)
        Me.TxtUnitMisur.TabIndex = 2
        Me.TltTabella.SetToolTip(Me.TxtUnitMisur, "Unità Di Misura")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(389, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 20)
        Me.Label3.TabIndex = 221
        Me.Label3.Text = "Quantità Minima"
        '
        'TxtQuantMinim
        '
        Me.TxtQuantMinim.Location = New System.Drawing.Point(358, 158)
        Me.TxtQuantMinim.MaxLength = 13
        Me.TxtQuantMinim.Name = "TxtQuantMinim"
        Me.TxtQuantMinim.Size = New System.Drawing.Size(150, 20)
        Me.TxtQuantMinim.TabIndex = 3
        Me.TxtQuantMinim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtQuantMinim, "Quantità minima articolo")
        '
        'BtnEsci
        '
        Me.BtnEsci.Location = New System.Drawing.Point(625, 260)
        Me.BtnEsci.Name = "BtnEsci"
        Me.BtnEsci.Size = New System.Drawing.Size(137, 34)
        Me.BtnEsci.TabIndex = 6
        Me.BtnEsci.Text = "Esci"
        Me.BtnEsci.UseVisualStyleBackColor = True
        '
        'BtnSalva
        '
        Me.BtnSalva.Location = New System.Drawing.Point(469, 260)
        Me.BtnSalva.Name = "BtnSalva"
        Me.BtnSalva.Size = New System.Drawing.Size(137, 34)
        Me.BtnSalva.TabIndex = 5
        Me.BtnSalva.Text = "Salva"
        Me.BtnSalva.UseVisualStyleBackColor = True
        '
        'StsTabella
        '
        Me.StsTabella.BackColor = System.Drawing.SystemColors.Control
        Me.StsTabella.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StsTabella.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsstabella})
        Me.StsTabella.Location = New System.Drawing.Point(0, 317)
        Me.StsTabella.Name = "StsTabella"
        Me.StsTabella.Padding = New System.Windows.Forms.Padding(1, 0, 9, 0)
        Me.StsTabella.Size = New System.Drawing.Size(795, 22)
        Me.StsTabella.TabIndex = 218
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(99, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Quantità"
        '
        'TxtQuantArtic
        '
        Me.TxtQuantArtic.Location = New System.Drawing.Point(12, 158)
        Me.TxtQuantArtic.MaxLength = 13
        Me.TxtQuantArtic.Name = "TxtQuantArtic"
        Me.TxtQuantArtic.Size = New System.Drawing.Size(150, 20)
        Me.TxtQuantArtic.TabIndex = 1
        Me.TxtQuantArtic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtQuantArtic, "Quantità Articolo")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(8, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Articolo"
        '
        'TxtDescArtic
        '
        Me.TxtDescArtic.Location = New System.Drawing.Point(12, 58)
        Me.TxtDescArtic.Name = "TxtDescArtic"
        Me.TxtDescArtic.Size = New System.Drawing.Size(750, 20)
        Me.TxtDescArtic.TabIndex = 0
        Me.TltTabella.SetToolTip(Me.TxtDescArtic, "Descrizione Articolo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'Schermata_grs_inventario_Modi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 339)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Schermata_grs_inventario_Modi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StsTabella.ResumeLayout(False)
        Me.StsTabella.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnEsci As Button
    Friend WithEvents BtnSalva As Button
    Friend WithEvents StsTabella As StatusStrip
    Friend WithEvents Tsstabella As ToolStripStatusLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtQuantArtic As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtDescArtic As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtUnitMisur As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtQuantMinim As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtPrezUnita As TextBox
    Friend WithEvents TltTabella As ToolTip
End Class
