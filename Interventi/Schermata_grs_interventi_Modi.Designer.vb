<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schermata_grs_interventi_Modi
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
        Me.TxtPrezUnit = New System.Windows.Forms.TextBox()
        Me.BtnEsci = New System.Windows.Forms.Button()
        Me.BtnSalva = New System.Windows.Forms.Button()
        Me.StsTabella = New System.Windows.Forms.StatusStrip()
        Me.Tsstabella = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtQuantita = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtDescArti = New System.Windows.Forms.TextBox()
        Me.TltTabella = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.StsTabella.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtPrezUnit)
        Me.Panel1.Controls.Add(Me.BtnEsci)
        Me.Panel1.Controls.Add(Me.BtnSalva)
        Me.Panel1.Controls.Add(Me.StsTabella)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtQuantita)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtDescArti)
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
        Me.Label5.Location = New System.Drawing.Point(213, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 225
        Me.Label5.Text = "Prezzo Unitario"
        '
        'TxtPrezUnit
        '
        Me.TxtPrezUnit.Location = New System.Drawing.Point(195, 158)
        Me.TxtPrezUnit.MaxLength = 7
        Me.TxtPrezUnit.Name = "TxtPrezUnit"
        Me.TxtPrezUnit.Size = New System.Drawing.Size(150, 20)
        Me.TxtPrezUnit.TabIndex = 2
        Me.TxtPrezUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtPrezUnit, "Prezzo unitario")
        '
        'BtnEsci
        '
        Me.BtnEsci.Location = New System.Drawing.Point(625, 260)
        Me.BtnEsci.Name = "BtnEsci"
        Me.BtnEsci.Size = New System.Drawing.Size(137, 34)
        Me.BtnEsci.TabIndex = 4
        Me.BtnEsci.Text = "Esci"
        Me.BtnEsci.UseVisualStyleBackColor = True
        '
        'BtnSalva
        '
        Me.BtnSalva.Location = New System.Drawing.Point(469, 260)
        Me.BtnSalva.Name = "BtnSalva"
        Me.BtnSalva.Size = New System.Drawing.Size(137, 34)
        Me.BtnSalva.TabIndex = 3
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
        Me.Label2.Location = New System.Drawing.Point(84, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Quantità"
        '
        'TxtQuantita
        '
        Me.TxtQuantita.Location = New System.Drawing.Point(12, 158)
        Me.TxtQuantita.MaxLength = 13
        Me.TxtQuantita.Name = "TxtQuantita"
        Me.TxtQuantita.Size = New System.Drawing.Size(150, 20)
        Me.TxtQuantita.TabIndex = 1
        Me.TxtQuantita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TltTabella.SetToolTip(Me.TxtQuantita, "Quantità Articolo")
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
        'TxtDescArti
        '
        Me.TxtDescArti.Location = New System.Drawing.Point(12, 58)
        Me.TxtDescArti.Name = "TxtDescArti"
        Me.TxtDescArti.Size = New System.Drawing.Size(750, 20)
        Me.TxtDescArti.TabIndex = 0
        Me.TltTabella.SetToolTip(Me.TxtDescArti, "Descrizione Articolo. <F6> Scelta.")
        '
        'Schermata_grs_interventi_Modi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 339)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Schermata_grs_interventi_Modi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Intervento - Articolo"
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
    Friend WithEvents TxtQuantita As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtDescArti As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtPrezUnit As TextBox
    Friend WithEvents TltTabella As ToolTip
End Class
