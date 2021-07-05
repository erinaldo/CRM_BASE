<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmitirNF
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
        Me.txtResultadoValidacao = New System.Windows.Forms.TextBox()
        Me.cmdValidarNFe = New System.Windows.Forms.Button()
        Me.chkComAssinatura = New System.Windows.Forms.CheckBox()
        Me.txtXSD = New System.Windows.Forms.TextBox()
        Me.cmdEscolheXSD = New System.Windows.Forms.Button()
        Me.cmdCarregaXML = New System.Windows.Forms.Button()
        Me.txtFonteXML = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
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
        Me.Label1.Location = New System.Drawing.Point(1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1189, 28)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Emissão de NFe"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtResultadoValidacao
        '
        Me.txtResultadoValidacao.Location = New System.Drawing.Point(181, 60)
        Me.txtResultadoValidacao.Name = "txtResultadoValidacao"
        Me.txtResultadoValidacao.Size = New System.Drawing.Size(284, 22)
        Me.txtResultadoValidacao.TabIndex = 68
        '
        'cmdValidarNFe
        '
        Me.cmdValidarNFe.Location = New System.Drawing.Point(471, 60)
        Me.cmdValidarNFe.Name = "cmdValidarNFe"
        Me.cmdValidarNFe.Size = New System.Drawing.Size(108, 23)
        Me.cmdValidarNFe.TabIndex = 69
        Me.cmdValidarNFe.Text = "Validar NFe"
        Me.cmdValidarNFe.UseVisualStyleBackColor = True
        '
        'chkComAssinatura
        '
        Me.chkComAssinatura.AutoSize = True
        Me.chkComAssinatura.Location = New System.Drawing.Point(585, 62)
        Me.chkComAssinatura.Name = "chkComAssinatura"
        Me.chkComAssinatura.Size = New System.Drawing.Size(177, 21)
        Me.chkComAssinatura.TabIndex = 70
        Me.chkComAssinatura.Text = "Valida com assinatura?"
        Me.chkComAssinatura.UseVisualStyleBackColor = True
        '
        'txtXSD
        '
        Me.txtXSD.Location = New System.Drawing.Point(181, 88)
        Me.txtXSD.Name = "txtXSD"
        Me.txtXSD.Size = New System.Drawing.Size(284, 22)
        Me.txtXSD.TabIndex = 71
        '
        'cmdEscolheXSD
        '
        Me.cmdEscolheXSD.Location = New System.Drawing.Point(471, 87)
        Me.cmdEscolheXSD.Name = "cmdEscolheXSD"
        Me.cmdEscolheXSD.Size = New System.Drawing.Size(108, 23)
        Me.cmdEscolheXSD.TabIndex = 72
        Me.cmdEscolheXSD.Text = "Escolhe XSD"
        Me.cmdEscolheXSD.UseVisualStyleBackColor = True
        '
        'cmdCarregaXML
        '
        Me.cmdCarregaXML.Location = New System.Drawing.Point(471, 116)
        Me.cmdCarregaXML.Name = "cmdCarregaXML"
        Me.cmdCarregaXML.Size = New System.Drawing.Size(108, 23)
        Me.cmdCarregaXML.TabIndex = 73
        Me.cmdCarregaXML.Text = "Carrega XML"
        Me.cmdCarregaXML.UseVisualStyleBackColor = True
        '
        'txtFonteXML
        '
        Me.txtFonteXML.Location = New System.Drawing.Point(181, 117)
        Me.txtFonteXML.Name = "txtFonteXML"
        Me.txtFonteXML.Size = New System.Drawing.Size(284, 22)
        Me.txtFonteXML.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 17)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Resultado da validação"
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
        Me.PnnInferior.Location = New System.Drawing.Point(1, 694)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1189, 38)
        Me.PnnInferior.TabIndex = 76
        '
        'LblIdVistoria
        '
        Me.LblIdVistoria.AutoSize = True
        Me.LblIdVistoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdVistoria.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdVistoria.Location = New System.Drawing.Point(32, 5)
        Me.LblIdVistoria.Name = "LblIdVistoria"
        Me.LblIdVistoria.Size = New System.Drawing.Size(16, 17)
        Me.LblIdVistoria.TabIndex = 48
        Me.LblIdVistoria.Text = "0"
        Me.LblIdVistoria.Visible = False
        '
        'LblIdSolução
        '
        Me.LblIdSolução.AutoSize = True
        Me.LblIdSolução.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdSolução.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdSolução.Location = New System.Drawing.Point(16, 5)
        Me.LblIdSolução.Name = "LblIdSolução"
        Me.LblIdSolução.Size = New System.Drawing.Size(16, 17)
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
        Me.LblIdmarca.Size = New System.Drawing.Size(16, 17)
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
        Me.Panel5.Size = New System.Drawing.Size(1108, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1108, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(81, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(48, 10)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(16, 8)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 732)
        Me.Panel1.TabIndex = 77
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1190, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 732)
        Me.Panel2.TabIndex = 78
        '
        'FrmEmitirNF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 732)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFonteXML)
        Me.Controls.Add(Me.cmdCarregaXML)
        Me.Controls.Add(Me.cmdEscolheXSD)
        Me.Controls.Add(Me.txtXSD)
        Me.Controls.Add(Me.chkComAssinatura)
        Me.Controls.Add(Me.cmdValidarNFe)
        Me.Controls.Add(Me.txtResultadoValidacao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmEmitirNF"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEmitirNF"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtResultadoValidacao As TextBox
    Friend WithEvents cmdValidarNFe As Button
    Friend WithEvents chkComAssinatura As CheckBox
    Friend WithEvents txtXSD As TextBox
    Friend WithEvents cmdEscolheXSD As Button
    Friend WithEvents cmdCarregaXML As Button
    Friend WithEvents txtFonteXML As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
