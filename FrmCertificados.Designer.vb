<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCertificados
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCNPJEmitente = New System.Windows.Forms.Label()
        Me.LblRazaoSocial = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblTelefone = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BttProcurarCertificado = New System.Windows.Forms.Button()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnSalvar = New System.Windows.Forms.Button()
        Me.LblNomeTitular = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblCPF = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblCNPJ = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LblTipoCErt = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblCertificador = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblSerialNumber = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(692, 27)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Configuração do certificado digital"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "CNPJ Emitente"
        '
        'LblCNPJEmitente
        '
        Me.LblCNPJEmitente.AutoSize = True
        Me.LblCNPJEmitente.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblCNPJEmitente.Location = New System.Drawing.Point(12, 62)
        Me.LblCNPJEmitente.Name = "LblCNPJEmitente"
        Me.LblCNPJEmitente.Size = New System.Drawing.Size(89, 17)
        Me.LblCNPJEmitente.TabIndex = 32
        Me.LblCNPJEmitente.Text = "CNPJ Emitente"
        '
        'LblRazaoSocial
        '
        Me.LblRazaoSocial.AutoSize = True
        Me.LblRazaoSocial.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblRazaoSocial.Location = New System.Drawing.Point(10, 111)
        Me.LblRazaoSocial.Name = "LblRazaoSocial"
        Me.LblRazaoSocial.Size = New System.Drawing.Size(89, 17)
        Me.LblRazaoSocial.TabIndex = 34
        Me.LblRazaoSocial.Text = "CNPJ Emitente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 17)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Razão social"
        '
        'LblTelefone
        '
        Me.LblTelefone.AutoSize = True
        Me.LblTelefone.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblTelefone.Location = New System.Drawing.Point(15, 159)
        Me.LblTelefone.Name = "LblTelefone"
        Me.LblTelefone.Size = New System.Drawing.Size(89, 17)
        Me.LblTelefone.TabIndex = 36
        Me.LblTelefone.Text = "CNPJ Emitente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Telefone"
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblEmail.Location = New System.Drawing.Point(218, 159)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(39, 17)
        Me.LblEmail.TabIndex = 38
        Me.LblEmail.Text = "email"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(218, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 17)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "E-mail"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(10, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(672, 22)
        Me.Label3.TabIndex = 243
        Me.Label3.Text = "Dados do certificadoSelecionado"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BttProcurarCertificado
        '
        Me.BttProcurarCertificado.Location = New System.Drawing.Point(13, 227)
        Me.BttProcurarCertificado.Name = "BttProcurarCertificado"
        Me.BttProcurarCertificado.Size = New System.Drawing.Size(181, 23)
        Me.BttProcurarCertificado.TabIndex = 244
        Me.BttProcurarCertificado.Text = "Procurar certificado"
        Me.BttProcurarCertificado.UseVisualStyleBackColor = True
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.LblIdVistoria)
        Me.PnnInferior.Controls.Add(Me.LblIdSolução)
        Me.PnnInferior.Controls.Add(Me.LblIdmarca)
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 527)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(692, 32)
        Me.PnnInferior.TabIndex = 245
        '
        'LblIdVistoria
        '
        Me.LblIdVistoria.AutoSize = True
        Me.LblIdVistoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdVistoria.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdVistoria.Location = New System.Drawing.Point(30, 5)
        Me.LblIdVistoria.Name = "LblIdVistoria"
        Me.LblIdVistoria.Size = New System.Drawing.Size(15, 17)
        Me.LblIdVistoria.TabIndex = 48
        Me.LblIdVistoria.Text = "0"
        Me.LblIdVistoria.Visible = False
        '
        'LblIdSolução
        '
        Me.LblIdSolução.AutoSize = True
        Me.LblIdSolução.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdSolução.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdSolução.Location = New System.Drawing.Point(15, 5)
        Me.LblIdSolução.Name = "LblIdSolução"
        Me.LblIdSolução.Size = New System.Drawing.Size(15, 17)
        Me.LblIdSolução.TabIndex = 47
        Me.LblIdSolução.Text = "0"
        Me.LblIdSolução.Visible = False
        '
        'LblIdmarca
        '
        Me.LblIdmarca.AutoSize = True
        Me.LblIdmarca.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdmarca.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdmarca.Location = New System.Drawing.Point(0, 5)
        Me.LblIdmarca.Name = "LblIdmarca"
        Me.LblIdmarca.Size = New System.Drawing.Size(15, 17)
        Me.LblIdmarca.TabIndex = 46
        Me.LblIdmarca.Text = "0"
        Me.LblIdmarca.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(627, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.Button1)
        Me.Panel12.Controls.Add(Me.BtnSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(627, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(65, 32)
        Me.Panel12.TabIndex = 49
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(38, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(16, 18)
        Me.Button1.TabIndex = 29
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnSalvar
        '
        Me.BtnSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BtnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnSalvar.FlatAppearance.BorderSize = 0
        Me.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalvar.Location = New System.Drawing.Point(9, 8)
        Me.BtnSalvar.Name = "BtnSalvar"
        Me.BtnSalvar.Size = New System.Drawing.Size(16, 18)
        Me.BtnSalvar.TabIndex = 28
        Me.BtnSalvar.UseVisualStyleBackColor = True
        '
        'LblNomeTitular
        '
        Me.LblNomeTitular.AutoSize = True
        Me.LblNomeTitular.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblNomeTitular.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblNomeTitular.Location = New System.Drawing.Point(15, 290)
        Me.LblNomeTitular.Name = "LblNomeTitular"
        Me.LblNomeTitular.Size = New System.Drawing.Size(14, 21)
        Me.LblNomeTitular.TabIndex = 247
        Me.LblNomeTitular.Text = " "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 273)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(177, 17)
        Me.Label9.TabIndex = 246
        Me.Label9.Text = "Nome do titular do certificado"
        '
        'LblCPF
        '
        Me.LblCPF.AutoSize = True
        Me.LblCPF.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblCPF.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblCPF.Location = New System.Drawing.Point(17, 361)
        Me.LblCPF.Name = "LblCPF"
        Me.LblCPF.Size = New System.Drawing.Size(14, 21)
        Me.LblCPF.TabIndex = 249
        Me.LblCPF.Text = " "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 327)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(220, 17)
        Me.Label10.TabIndex = 248
        Me.Label10.Text = "Documentos vinculados ao certificado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.Label8.Location = New System.Drawing.Point(15, 344)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 17)
        Me.Label8.TabIndex = 250
        Me.Label8.Text = "CPF"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.Label11.Location = New System.Drawing.Point(151, 344)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 17)
        Me.Label11.TabIndex = 252
        Me.Label11.Text = "CNPJ"
        '
        'LblCNPJ
        '
        Me.LblCNPJ.AutoSize = True
        Me.LblCNPJ.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblCNPJ.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblCNPJ.Location = New System.Drawing.Point(151, 361)
        Me.LblCNPJ.Name = "LblCNPJ"
        Me.LblCNPJ.Size = New System.Drawing.Size(14, 21)
        Me.LblCNPJ.TabIndex = 251
        Me.LblCNPJ.Text = " "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 558)
        Me.Panel1.TabIndex = 253
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(693, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 558)
        Me.Panel2.TabIndex = 254
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 559)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(694, 1)
        Me.Panel3.TabIndex = 255
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(694, 1)
        Me.Panel4.TabIndex = 256
        '
        'LblTipoCErt
        '
        Me.LblTipoCErt.AutoSize = True
        Me.LblTipoCErt.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTipoCErt.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblTipoCErt.Location = New System.Drawing.Point(548, 290)
        Me.LblTipoCErt.Name = "LblTipoCErt"
        Me.LblTipoCErt.Size = New System.Drawing.Size(14, 21)
        Me.LblTipoCErt.TabIndex = 258
        Me.LblTipoCErt.Text = " "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(548, 273)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 17)
        Me.Label13.TabIndex = 257
        Me.Label13.Text = "Tipo do certificado"
        '
        'LblCertificador
        '
        Me.LblCertificador.AutoSize = True
        Me.LblCertificador.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblCertificador.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblCertificador.Location = New System.Drawing.Point(16, 424)
        Me.LblCertificador.Name = "LblCertificador"
        Me.LblCertificador.Size = New System.Drawing.Size(14, 21)
        Me.LblCertificador.TabIndex = 260
        Me.LblCertificador.Text = " "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 407)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 17)
        Me.Label14.TabIndex = 259
        Me.Label14.Text = "Certificador"
        '
        'LblSerialNumber
        '
        Me.LblSerialNumber.AutoSize = True
        Me.LblSerialNumber.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblSerialNumber.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblSerialNumber.Location = New System.Drawing.Point(17, 478)
        Me.LblSerialNumber.Name = "LblSerialNumber"
        Me.LblSerialNumber.Size = New System.Drawing.Size(14, 21)
        Me.LblSerialNumber.TabIndex = 262
        Me.LblSerialNumber.Text = " "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 461)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 17)
        Me.Label15.TabIndex = 261
        Me.Label15.Text = "Serial Number"
        '
        'FrmCertificados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 560)
        Me.Controls.Add(Me.LblSerialNumber)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.LblCertificador)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LblTipoCErt)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LblCNPJ)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblCPF)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblNomeTitular)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.BttProcurarCertificado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblEmail)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblTelefone)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblRazaoSocial)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblCNPJEmitente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCertificados"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCertificados"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblCNPJEmitente As Label
    Friend WithEvents LblRazaoSocial As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblTelefone As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblEmail As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BttProcurarCertificado As Button
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents BtnSalvar As Button
    Friend WithEvents LblNomeTitular As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblCPF As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblCNPJ As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LblTipoCErt As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents LblCertificador As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents LblSerialNumber As Label
    Friend WithEvents Label15 As Label
End Class
