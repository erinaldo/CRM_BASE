<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtNick = New System.Windows.Forms.TextBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LblAtualização = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtDoc = New System.Windows.Forms.MaskedTextBox()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblVersão = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PicLocal = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PicCioud = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PicLocal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicCioud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SlateGray
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(388, 294)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(364, 34)
        Me.Panel4.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Controls.Add(Me.BttFechar)
        Me.Panel5.Controls.Add(Me.BttSalvar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(364, 32)
        Me.Panel5.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(414, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 17)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Nome do usuário"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(414, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 17)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "Senha"
        '
        'TxtNick
        '
        Me.TxtNick.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNick.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNick.Location = New System.Drawing.Point(417, 98)
        Me.TxtNick.Name = "TxtNick"
        Me.TxtNick.Size = New System.Drawing.Size(312, 21)
        Me.TxtNick.TabIndex = 0
        '
        'TxtPassword
        '
        Me.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPassword.Enabled = False
        Me.TxtPassword.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtPassword.Location = New System.Drawing.Point(417, 153)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(312, 21)
        Me.TxtPassword.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(388, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(364, 2)
        Me.Panel6.TabIndex = 6
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'LblAtualização
        '
        Me.LblAtualização.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblAtualização.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblAtualização.Location = New System.Drawing.Point(388, 2)
        Me.LblAtualização.Name = "LblAtualização"
        Me.LblAtualização.Size = New System.Drawing.Size(364, 27)
        Me.LblAtualização.TabIndex = 16
        Me.LblAtualização.Text = "Atualização disponivel"
        Me.LblAtualização.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblAtualização.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(414, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 17)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Documento"
        '
        'TxtDoc
        '
        Me.TxtDoc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDoc.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDoc.Location = New System.Drawing.Point(417, 204)
        Me.TxtDoc.Mask = "00,000,000/0000-00"
        Me.TxtDoc.Name = "TxtDoc"
        Me.TxtDoc.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtDoc.Size = New System.Drawing.Size(312, 21)
        Me.TxtDoc.TabIndex = 3
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        Me.Timer3.Interval = 1000
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(332, 7)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 5
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(295, 7)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 4
        Me.BttSalvar.UseVisualStyleBackColor = True
        Me.BttSalvar.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.LogoIaraTrsnp
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(388, 328)
        Me.Panel1.TabIndex = 75
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.LblVersão)
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(388, 29)
        Me.Panel3.TabIndex = 8
        '
        'LblVersão
        '
        Me.LblVersão.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblVersão.ForeColor = System.Drawing.Color.SlateGray
        Me.LblVersão.Location = New System.Drawing.Point(0, 2)
        Me.LblVersão.Name = "LblVersão"
        Me.LblVersão.Size = New System.Drawing.Size(214, 27)
        Me.LblVersão.TabIndex = 14
        Me.LblVersão.Text = "Senha"
        Me.LblVersão.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.SlateGray
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(388, 2)
        Me.Panel10.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.LblStatus)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.PicLocal)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.PicCioud)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 294)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(388, 32)
        Me.Panel2.TabIndex = 14
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.Color.Transparent
        Me.LblStatus.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblStatus.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.LblStatus.ForeColor = System.Drawing.Color.SlateGray
        Me.LblStatus.Location = New System.Drawing.Point(0, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(124, 32)
        Me.LblStatus.TabIndex = 13
        Me.LblStatus.Text = "Abrindo conexôes"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.SlateGray
        Me.Label8.Location = New System.Drawing.Point(205, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 17)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Conexão local"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PicLocal
        '
        Me.PicLocal.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.globe_disconnected_21030
        Me.PicLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicLocal.Location = New System.Drawing.Point(301, 9)
        Me.PicLocal.Name = "PicLocal"
        Me.PicLocal.Size = New System.Drawing.Size(17, 17)
        Me.PicLocal.TabIndex = 11
        Me.PicLocal.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.SlateGray
        Me.Label7.Location = New System.Drawing.Point(272, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 17)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Cloud"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PicCioud
        '
        Me.PicCioud.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.globe_disconnected_21030
        Me.PicCioud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicCioud.Location = New System.Drawing.Point(365, 9)
        Me.PicCioud.Name = "PicCioud"
        Me.PicCioud.Size = New System.Drawing.Size(17, 17)
        Me.PicCioud.TabIndex = 8
        Me.PicCioud.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 24.0!)
        Me.Label4.ForeColor = System.Drawing.Color.SlateGray
        Me.Label4.Location = New System.Drawing.Point(57, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 50)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "A"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 24.0!)
        Me.Label3.ForeColor = System.Drawing.Color.SlateGray
        Me.Label3.Location = New System.Drawing.Point(57, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 50)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "R"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 24.0!)
        Me.Label2.ForeColor = System.Drawing.Color.SlateGray
        Me.Label2.Location = New System.Drawing.Point(57, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 50)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "A"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 24.0!)
        Me.Label1.ForeColor = System.Drawing.Color.SlateGray
        Me.Label1.Location = New System.Drawing.Point(57, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 50)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "I"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel11.Controls.Add(Me.Panel13)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel11.Location = New System.Drawing.Point(0, 326)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(388, 2)
        Me.Panel11.TabIndex = 5
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.SlateGray
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(388, 2)
        Me.Panel13.TabIndex = 7
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(752, 328)
        Me.Controls.Add(Me.TxtDoc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LblAtualização)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.TxtNick)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmLogin"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLogin"
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PicLocal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicCioud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtNick As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents PicCioud As PictureBox
    Friend WithEvents LblVersão As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PicLocal As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LblAtualização As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents LblStatus As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtDoc As MaskedTextBox
    Friend WithEvents Timer3 As Timer
End Class
