<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrocarSenha
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtRepeteSenha = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TxtCODE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblCodInvalido = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Location = New System.Drawing.Point(0, 5)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(417, 227)
        Me.LblTitulo.TabIndex = 3
        Me.LblTitulo.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ola usuário, bem vindo ao universo I.A.R.A., reparei que seu login ainda não po" &
    "ssue uma senha válida, por favor " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "insira uma nova senha para ter acesso ao sist" &
    "ema."
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.SlateGray
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(689, 2)
        Me.Panel10.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.ForeColor = System.Drawing.Color.SlateGray
        Me.Label2.Location = New System.Drawing.Point(17, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Digite uma senha"
        '
        'TxtPassword
        '
        Me.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPassword.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtPassword.Location = New System.Drawing.Point(112, 144)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(146, 17)
        Me.TxtPassword.TabIndex = 1
        '
        'TxtRepeteSenha
        '
        Me.TxtRepeteSenha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRepeteSenha.Enabled = False
        Me.TxtRepeteSenha.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtRepeteSenha.Location = New System.Drawing.Point(112, 167)
        Me.TxtRepeteSenha.Name = "TxtRepeteSenha"
        Me.TxtRepeteSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtRepeteSenha.Size = New System.Drawing.Size(146, 17)
        Me.TxtRepeteSenha.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.ForeColor = System.Drawing.Color.SlateGray
        Me.Label3.Location = New System.Drawing.Point(17, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Repita sua senha"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.SlateGray
        Me.Label4.Location = New System.Drawing.Point(6, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(413, 224)
        Me.Label4.TabIndex = 26
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 243)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(689, 2)
        Me.Panel4.TabIndex = 27
        '
        'TxtCODE
        '
        Me.TxtCODE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCODE.Enabled = False
        Me.TxtCODE.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCODE.Location = New System.Drawing.Point(112, 190)
        Me.TxtCODE.MaxLength = 6
        Me.TxtCODE.Name = "TxtCODE"
        Me.TxtCODE.Size = New System.Drawing.Size(146, 17)
        Me.TxtCODE.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.ForeColor = System.Drawing.Color.SlateGray
        Me.Label5.Location = New System.Drawing.Point(17, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "CODE gerado"
        '
        'LblCodInvalido
        '
        Me.LblCodInvalido.AutoSize = True
        Me.LblCodInvalido.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblCodInvalido.ForeColor = System.Drawing.Color.Red
        Me.LblCodInvalido.Location = New System.Drawing.Point(147, 212)
        Me.LblCodInvalido.Name = "LblCodInvalido"
        Me.LblCodInvalido.Size = New System.Drawing.Size(72, 13)
        Me.LblCodInvalido.TabIndex = 30
        Me.LblCodInvalido.Text = "CODE inválido"
        Me.LblCodInvalido.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Control
        Me.Panel5.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.LogoIaraTrsnp
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel5.Controls.Add(Me.BttFechar)
        Me.Panel5.Controls.Add(Me.BttSalvar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(356, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(333, 241)
        Me.Panel5.TabIndex = 8
        '
        'BttFechar
        '
        Me.BttFechar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(301, 206)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 5
        Me.BttFechar.UseVisualStyleBackColor = False
        '
        'BttSalvar
        '
        Me.BttSalvar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(264, 206)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 4
        Me.BttSalvar.UseVisualStyleBackColor = False
        Me.BttSalvar.Visible = False
        '
        'FrmTrocarSenha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(689, 245)
        Me.Controls.Add(Me.LblCodInvalido)
        Me.Controls.Add(Me.TxtCODE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtRepeteSenha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTrocarSenha"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTrocarSenha"
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents TxtRepeteSenha As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TxtCODE As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LblCodInvalido As Label
End Class
