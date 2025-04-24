<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.PnlModulo = New System.Windows.Forms.Panel()
        Me.LblLicenza = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.TimerAggiornamento = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRiprova = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.PnlModulo.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PnlModulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(668, 267)
        Me.Panel1.TabIndex = 1
        '
        'PnlModulo
        '
        Me.PnlModulo.BackColor = System.Drawing.Color.Transparent
        Me.PnlModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlModulo.Controls.Add(Me.LblLicenza)
        Me.PnlModulo.Controls.Add(Me.BtnCancel)
        Me.PnlModulo.Controls.Add(Me.BtnOK)
        Me.PnlModulo.Controls.Add(Me.TxtPassword)
        Me.PnlModulo.Controls.Add(Me.TxtUsername)
        Me.PnlModulo.Controls.Add(Me.PasswordLabel)
        Me.PnlModulo.Controls.Add(Me.UsernameLabel)
        Me.PnlModulo.Controls.Add(Me.LogoPictureBox)
        Me.PnlModulo.Location = New System.Drawing.Point(8, 7)
        Me.PnlModulo.Name = "PnlModulo"
        Me.PnlModulo.Size = New System.Drawing.Size(654, 253)
        Me.PnlModulo.TabIndex = 0
        '
        'LblLicenza
        '
        Me.LblLicenza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblLicenza.AutoSize = True
        Me.LblLicenza.BackColor = System.Drawing.Color.White
        Me.LblLicenza.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLicenza.ForeColor = System.Drawing.Color.Red
        Me.LblLicenza.Location = New System.Drawing.Point(311, 214)
        Me.LblLicenza.Name = "LblLicenza"
        Me.LblLicenza.Size = New System.Drawing.Size(0, 17)
        Me.LblLicenza.TabIndex = 24
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(555, 187)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 23)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "&Annulla"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(452, 187)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 23)
        Me.BtnOK.TabIndex = 2
        Me.BtnOK.Text = "&OK"
        '
        'TxtPassword
        '
        Me.TxtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPassword.Location = New System.Drawing.Point(453, 127)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(189, 20)
        Me.TxtPassword.TabIndex = 1
        '
        'TxtUsername
        '
        Me.TxtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUsername.Location = New System.Drawing.Point(453, 70)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(189, 20)
        Me.TxtUsername.TabIndex = 0
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PasswordLabel.ForeColor = System.Drawing.Color.White
        Me.PasswordLabel.Location = New System.Drawing.Point(451, 106)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(71, 20)
        Me.PasswordLabel.TabIndex = 23
        Me.PasswordLabel.Text = "&Password"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UsernameLabel.ForeColor = System.Drawing.Color.White
        Me.UsernameLabel.Location = New System.Drawing.Point(451, 49)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(99, 20)
        Me.UsernameLabel.TabIndex = 20
        Me.UsernameLabel.Text = "&Nome utente"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackgroundImage = Global.GRS_Magazzino.My.Resources.Resources.LOGO_FOTO
        Me.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LogoPictureBox.ErrorImage = Nothing
        Me.LogoPictureBox.InitialImage = Nothing
        Me.LogoPictureBox.Location = New System.Drawing.Point(-16, 6)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(463, 244)
        Me.LogoPictureBox.TabIndex = 21
        Me.LogoPictureBox.TabStop = False
        '
        'TimerAggiornamento
        '
        Me.TimerAggiornamento.Interval = 3000
        '
        'TimerRiprova
        '
        Me.TimerRiprova.Interval = 1000
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 267)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Login"
        Me.Text = "Login"
        Me.Panel1.ResumeLayout(False)
        Me.PnlModulo.ResumeLayout(False)
        Me.PnlModulo.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PnlModulo As Panel
    Friend WithEvents LblLicenza As Label
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnOK As Button
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents LogoPictureBox As PictureBox
    Friend WithEvents TimerAggiornamento As Timer
    Friend WithEvents TimerRiprova As Timer
End Class
