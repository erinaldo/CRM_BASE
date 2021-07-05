<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmitirNovaNF
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttEmitirNfFiscal = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblCnpj = New System.Windows.Forms.Label()
        Me.LblRazao = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblEndereco = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblIE = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblInscricaoEstadualIe = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblEnderecoDestinatario = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblRazaoSocial_Nome = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblCnpj_Cpf_Destinatário = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblRGIETransp = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblEnderecoTransp = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblCnpjTranp = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.CmbTransporteModo = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.CmbTransportadores = New System.Windows.Forms.ComboBox()
        Me.Seguradora = New System.Windows.Forms.Label()
        Me.CmbSeguradora = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtValorSeguro = New System.Windows.Forms.TextBox()
        Me.TxtPlaca = New System.Windows.Forms.TextBox()
        Me.LblModeloVeiculo = New System.Windows.Forms.Label()
        Me.CmbEspecie = New System.Windows.Forms.ComboBox()
        Me.DtProdutos = New System.Windows.Forms.DataGridView()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LblIcms = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.LblICMSST = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.LblIPI = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.LblUF = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.DtProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.LblIdVistoria)
        Me.PnnInferior.Controls.Add(Me.LblIdSolução)
        Me.PnnInferior.Controls.Add(Me.LblIdmarca)
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Controls.Add(Me.BttEmitirNfFiscal)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 758)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1401, 28)
        Me.PnnInferior.TabIndex = 97
        '
        'LblIdVistoria
        '
        Me.LblIdVistoria.AutoSize = True
        Me.LblIdVistoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdVistoria.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdVistoria.Location = New System.Drawing.Point(261, 5)
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
        Me.LblIdSolução.Location = New System.Drawing.Point(246, 5)
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
        Me.LblIdmarca.Location = New System.Drawing.Point(231, 5)
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
        Me.Panel5.Location = New System.Drawing.Point(231, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1125, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1356, 0)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(45, 28)
        Me.Panel12.TabIndex = 50
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(15, 6)
        Me.BttFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(15, 15)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BttEmitirNfFiscal
        '
        Me.BttEmitirNfFiscal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttEmitirNfFiscal.Dock = System.Windows.Forms.DockStyle.Left
        Me.BttEmitirNfFiscal.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttEmitirNfFiscal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttEmitirNfFiscal.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttEmitirNfFiscal.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttEmitirNfFiscal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttEmitirNfFiscal.Location = New System.Drawing.Point(0, 0)
        Me.BttEmitirNfFiscal.Margin = New System.Windows.Forms.Padding(4)
        Me.BttEmitirNfFiscal.Name = "BttEmitirNfFiscal"
        Me.BttEmitirNfFiscal.Size = New System.Drawing.Size(231, 28)
        Me.BttEmitirNfFiscal.TabIndex = 51
        Me.BttEmitirNfFiscal.Text = "Emitir nota fiscal"
        Me.BttEmitirNfFiscal.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1402, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 766)
        Me.Panel1.TabIndex = 98
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1402, 20)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Nova nota fiscal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 786)
        Me.Panel2.TabIndex = 100
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Gainsboro
        Me.Label20.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label20.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label20.Location = New System.Drawing.Point(12, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(680, 21)
        Me.Label20.TabIndex = 101
        Me.Label20.Text = "Emissor"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(705, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(680, 21)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Destinatário"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(12, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(680, 21)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Transportador"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(12, 378)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1373, 21)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Itens na NF"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 17)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "CNPJ"
        '
        'LblCnpj
        '
        Me.LblCnpj.AutoSize = True
        Me.LblCnpj.ForeColor = System.Drawing.Color.SlateGray
        Me.LblCnpj.Location = New System.Drawing.Point(150, 74)
        Me.LblCnpj.Name = "LblCnpj"
        Me.LblCnpj.Size = New System.Drawing.Size(34, 17)
        Me.LblCnpj.TabIndex = 106
        Me.LblCnpj.Text = "CNPJ"
        '
        'LblRazao
        '
        Me.LblRazao.AutoSize = True
        Me.LblRazao.ForeColor = System.Drawing.Color.SlateGray
        Me.LblRazao.Location = New System.Drawing.Point(150, 102)
        Me.LblRazao.Name = "LblRazao"
        Me.LblRazao.Size = New System.Drawing.Size(34, 17)
        Me.LblRazao.TabIndex = 108
        Me.LblRazao.Text = "CNPJ"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 17)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Razão Social"
        '
        'LblEndereco
        '
        Me.LblEndereco.AutoSize = True
        Me.LblEndereco.ForeColor = System.Drawing.Color.SlateGray
        Me.LblEndereco.Location = New System.Drawing.Point(150, 131)
        Me.LblEndereco.Name = "LblEndereco"
        Me.LblEndereco.Size = New System.Drawing.Size(34, 17)
        Me.LblEndereco.TabIndex = 110
        Me.LblEndereco.Text = "CNPJ"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 131)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 17)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "Endereço"
        '
        'LblIE
        '
        Me.LblIE.AutoSize = True
        Me.LblIE.ForeColor = System.Drawing.Color.SlateGray
        Me.LblIE.Location = New System.Drawing.Point(463, 74)
        Me.LblIE.Name = "LblIE"
        Me.LblIE.Size = New System.Drawing.Size(34, 17)
        Me.LblIE.TabIndex = 112
        Me.LblIE.Text = "CNPJ"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(348, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 17)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "Inscrição estadual"
        '
        'LblInscricaoEstadualIe
        '
        Me.LblInscricaoEstadualIe.AutoSize = True
        Me.LblInscricaoEstadualIe.ForeColor = System.Drawing.Color.SlateGray
        Me.LblInscricaoEstadualIe.Location = New System.Drawing.Point(1088, 78)
        Me.LblInscricaoEstadualIe.Name = "LblInscricaoEstadualIe"
        Me.LblInscricaoEstadualIe.Size = New System.Drawing.Size(34, 17)
        Me.LblInscricaoEstadualIe.TabIndex = 120
        Me.LblInscricaoEstadualIe.Text = "CNPJ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1041, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 17)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "RG/IE"
        '
        'LblEnderecoDestinatario
        '
        Me.LblEnderecoDestinatario.AutoSize = True
        Me.LblEnderecoDestinatario.ForeColor = System.Drawing.Color.SlateGray
        Me.LblEnderecoDestinatario.Location = New System.Drawing.Point(843, 135)
        Me.LblEnderecoDestinatario.Name = "LblEnderecoDestinatario"
        Me.LblEnderecoDestinatario.Size = New System.Drawing.Size(34, 17)
        Me.LblEnderecoDestinatario.TabIndex = 118
        Me.LblEnderecoDestinatario.Text = "CNPJ"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(720, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 17)
        Me.Label11.TabIndex = 117
        Me.Label11.Text = "Endereço"
        '
        'LblRazaoSocial_Nome
        '
        Me.LblRazaoSocial_Nome.AutoSize = True
        Me.LblRazaoSocial_Nome.ForeColor = System.Drawing.Color.SlateGray
        Me.LblRazaoSocial_Nome.Location = New System.Drawing.Point(843, 106)
        Me.LblRazaoSocial_Nome.Name = "LblRazaoSocial_Nome"
        Me.LblRazaoSocial_Nome.Size = New System.Drawing.Size(34, 17)
        Me.LblRazaoSocial_Nome.TabIndex = 116
        Me.LblRazaoSocial_Nome.Text = "CNPJ"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(720, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 17)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Razão Social/Nome"
        '
        'LblCnpj_Cpf_Destinatário
        '
        Me.LblCnpj_Cpf_Destinatário.AutoSize = True
        Me.LblCnpj_Cpf_Destinatário.ForeColor = System.Drawing.Color.SlateGray
        Me.LblCnpj_Cpf_Destinatário.Location = New System.Drawing.Point(843, 78)
        Me.LblCnpj_Cpf_Destinatário.Name = "LblCnpj_Cpf_Destinatário"
        Me.LblCnpj_Cpf_Destinatário.Size = New System.Drawing.Size(34, 17)
        Me.LblCnpj_Cpf_Destinatário.TabIndex = 114
        Me.LblCnpj_Cpf_Destinatário.Text = "CNPJ"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(720, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 17)
        Me.Label16.TabIndex = 113
        Me.Label16.Text = "CNPJ/CPF"
        '
        'LblRGIETransp
        '
        Me.LblRGIETransp.AutoSize = True
        Me.LblRGIETransp.ForeColor = System.Drawing.Color.SlateGray
        Me.LblRGIETransp.Location = New System.Drawing.Point(463, 277)
        Me.LblRGIETransp.Name = "LblRGIETransp"
        Me.LblRGIETransp.Size = New System.Drawing.Size(11, 17)
        Me.LblRGIETransp.TabIndex = 128
        Me.LblRGIETransp.Text = " "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(347, 277)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 17)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "RG/IE"
        '
        'LblEnderecoTransp
        '
        Me.LblEnderecoTransp.AutoSize = True
        Me.LblEnderecoTransp.ForeColor = System.Drawing.Color.SlateGray
        Me.LblEnderecoTransp.Location = New System.Drawing.Point(149, 309)
        Me.LblEnderecoTransp.Name = "LblEnderecoTransp"
        Me.LblEnderecoTransp.Size = New System.Drawing.Size(11, 17)
        Me.LblEnderecoTransp.TabIndex = 126
        Me.LblEnderecoTransp.Text = " "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(26, 309)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 17)
        Me.Label15.TabIndex = 125
        Me.Label15.Text = "Endereço"
        '
        'LblCnpjTranp
        '
        Me.LblCnpjTranp.AutoSize = True
        Me.LblCnpjTranp.ForeColor = System.Drawing.Color.SlateGray
        Me.LblCnpjTranp.Location = New System.Drawing.Point(149, 277)
        Me.LblCnpjTranp.Name = "LblCnpjTranp"
        Me.LblCnpjTranp.Size = New System.Drawing.Size(11, 17)
        Me.LblCnpjTranp.TabIndex = 122
        Me.LblCnpjTranp.Text = " "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(26, 277)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 17)
        Me.Label21.TabIndex = 121
        Me.Label21.Text = "CNPJ/CPF"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label6.Location = New System.Drawing.Point(698, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1, 135)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "Emissor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(720, 213)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 17)
        Me.Label17.TabIndex = 130
        Me.Label17.Text = "Placa do veículo"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Gainsboro
        Me.Label19.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label19.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label19.Location = New System.Drawing.Point(698, 170)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(1, 195)
        Me.Label19.TabIndex = 132
        Me.Label19.Text = "Emissor"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Gainsboro
        Me.Label22.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label22.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label22.Location = New System.Drawing.Point(705, 170)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(680, 21)
        Me.Label22.TabIndex = 133
        Me.Label22.Text = "Dados do veículo do transporte"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(1041, 213)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(23, 17)
        Me.Label23.TabIndex = 134
        Me.Label23.Text = "UF"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(720, 245)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(110, 17)
        Me.Label25.TabIndex = 136
        Me.Label25.Text = "Modelo do veículo"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(720, 341)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(50, 17)
        Me.Label27.TabIndex = 138
        Me.Label27.Text = "Espécie"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Gainsboro
        Me.Label29.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label29.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label29.Location = New System.Drawing.Point(12, 686)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(1373, 21)
        Me.Label29.TabIndex = 140
        Me.Label29.Text = "Calculo de impostos"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(27, 213)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(121, 17)
        Me.Label30.TabIndex = 141
        Me.Label30.Text = "Modo do transporte"
        '
        'CmbTransporteModo
        '
        Me.CmbTransporteModo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbTransporteModo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbTransporteModo.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbTransporteModo.FormattingEnabled = True
        Me.CmbTransporteModo.Location = New System.Drawing.Point(154, 209)
        Me.CmbTransporteModo.Name = "CmbTransporteModo"
        Me.CmbTransporteModo.Size = New System.Drawing.Size(511, 25)
        Me.CmbTransporteModo.TabIndex = 142
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(27, 245)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(100, 17)
        Me.Label31.TabIndex = 143
        Me.Label31.Text = "Transportadores"
        '
        'CmbTransportadores
        '
        Me.CmbTransportadores.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbTransportadores.Enabled = False
        Me.CmbTransportadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbTransportadores.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbTransportadores.FormattingEnabled = True
        Me.CmbTransportadores.Location = New System.Drawing.Point(154, 241)
        Me.CmbTransportadores.Name = "CmbTransportadores"
        Me.CmbTransportadores.Size = New System.Drawing.Size(511, 25)
        Me.CmbTransportadores.TabIndex = 144
        '
        'Seguradora
        '
        Me.Seguradora.AutoSize = True
        Me.Seguradora.Location = New System.Drawing.Point(27, 341)
        Me.Seguradora.Name = "Seguradora"
        Me.Seguradora.Size = New System.Drawing.Size(61, 17)
        Me.Seguradora.TabIndex = 145
        Me.Seguradora.Text = "Endereço"
        '
        'CmbSeguradora
        '
        Me.CmbSeguradora.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbSeguradora.Enabled = False
        Me.CmbSeguradora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbSeguradora.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbSeguradora.FormattingEnabled = True
        Me.CmbSeguradora.Items.AddRange(New Object() {"Sem seguro"})
        Me.CmbSeguradora.Location = New System.Drawing.Point(152, 337)
        Me.CmbSeguradora.Name = "CmbSeguradora"
        Me.CmbSeguradora.Size = New System.Drawing.Size(305, 25)
        Me.CmbSeguradora.TabIndex = 146
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.SlateGray
        Me.Label18.Location = New System.Drawing.Point(463, 341)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 17)
        Me.Label18.TabIndex = 147
        Me.Label18.Text = "Valor"
        '
        'TxtValorSeguro
        '
        Me.TxtValorSeguro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtValorSeguro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtValorSeguro.Enabled = False
        Me.TxtValorSeguro.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtValorSeguro.Location = New System.Drawing.Point(529, 341)
        Me.TxtValorSeguro.Name = "TxtValorSeguro"
        Me.TxtValorSeguro.Size = New System.Drawing.Size(136, 21)
        Me.TxtValorSeguro.TabIndex = 148
        Me.TxtValorSeguro.Text = "R$ 0,00"
        '
        'TxtPlaca
        '
        Me.TxtPlaca.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPlaca.Enabled = False
        Me.TxtPlaca.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtPlaca.Location = New System.Drawing.Point(846, 213)
        Me.TxtPlaca.Name = "TxtPlaca"
        Me.TxtPlaca.Size = New System.Drawing.Size(136, 21)
        Me.TxtPlaca.TabIndex = 149
        '
        'LblModeloVeiculo
        '
        Me.LblModeloVeiculo.AutoSize = True
        Me.LblModeloVeiculo.ForeColor = System.Drawing.Color.SlateGray
        Me.LblModeloVeiculo.Location = New System.Drawing.Point(843, 245)
        Me.LblModeloVeiculo.Name = "LblModeloVeiculo"
        Me.LblModeloVeiculo.Size = New System.Drawing.Size(11, 17)
        Me.LblModeloVeiculo.TabIndex = 137
        Me.LblModeloVeiculo.Text = " "
        '
        'CmbEspecie
        '
        Me.CmbEspecie.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbEspecie.Enabled = False
        Me.CmbEspecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbEspecie.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbEspecie.FormattingEnabled = True
        Me.CmbEspecie.Items.AddRange(New Object() {"CAIXAS", "PACOTES"})
        Me.CmbEspecie.Location = New System.Drawing.Point(846, 337)
        Me.CmbEspecie.Name = "CmbEspecie"
        Me.CmbEspecie.Size = New System.Drawing.Size(511, 25)
        Me.CmbEspecie.TabIndex = 151
        '
        'DtProdutos
        '
        Me.DtProdutos.AllowUserToAddRows = False
        Me.DtProdutos.AllowUserToDeleteRows = False
        Me.DtProdutos.AllowUserToResizeColumns = False
        Me.DtProdutos.AllowUserToResizeRows = False
        Me.DtProdutos.BackgroundColor = System.Drawing.Color.White
        Me.DtProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column2, Me.Column3, Me.Column1, Me.Column5, Me.Column7, Me.Column8, Me.Column4, Me.Column6, Me.Column9})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtProdutos.DefaultCellStyle = DataGridViewCellStyle4
        Me.DtProdutos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DtProdutos.EnableHeadersVisualStyles = False
        Me.DtProdutos.GridColor = System.Drawing.Color.Gainsboro
        Me.DtProdutos.Location = New System.Drawing.Point(3, 3)
        Me.DtProdutos.MultiSelect = False
        Me.DtProdutos.Name = "DtProdutos"
        Me.DtProdutos.ReadOnly = True
        Me.DtProdutos.RowHeadersVisible = False
        Me.DtProdutos.RowHeadersWidth = 51
        Me.DtProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtProdutos.Size = New System.Drawing.Size(1345, 247)
        Me.DtProdutos.TabIndex = 152
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column10.HeaderText = "Cod. Produto"
        Me.Column10.MinimumWidth = 6
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "Descrição do item"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.HeaderText = "NCM"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 125
        '
        'Column1
        '
        Me.Column1.HeaderText = "EAN"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 125
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column5.HeaderText = "CST"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 56
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column7.HeaderText = "CFOP"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 65
        '
        'Column8
        '
        Me.Column8.HeaderText = "Valor unitário"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column8.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "Desc."
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 125
        '
        'Column6
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column6.HeaderText = "Qt"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 60
        '
        'Column9
        '
        Me.Column9.HeaderText = "Subtotal"
        Me.Column9.MinimumWidth = 6
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 125
        '
        'LblIcms
        '
        Me.LblIcms.AutoSize = True
        Me.LblIcms.ForeColor = System.Drawing.Color.SlateGray
        Me.LblIcms.Location = New System.Drawing.Point(150, 723)
        Me.LblIcms.Name = "LblIcms"
        Me.LblIcms.Size = New System.Drawing.Size(22, 17)
        Me.LblIcms.TabIndex = 154
        Me.LblIcms.Text = "18"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(27, 723)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(87, 17)
        Me.Label24.TabIndex = 153
        Me.Label24.Text = "Alíquota ICMS"
        '
        'LblICMSST
        '
        Me.LblICMSST.AutoSize = True
        Me.LblICMSST.ForeColor = System.Drawing.Color.SlateGray
        Me.LblICMSST.Location = New System.Drawing.Point(351, 723)
        Me.LblICMSST.Name = "LblICMSST"
        Me.LblICMSST.Size = New System.Drawing.Size(22, 17)
        Me.LblICMSST.TabIndex = 156
        Me.LblICMSST.Text = "18"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(228, 723)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(103, 17)
        Me.Label28.TabIndex = 155
        Me.Label28.Text = "Alíquota ICMS ST"
        '
        'LblIPI
        '
        Me.LblIPI.AutoSize = True
        Me.LblIPI.ForeColor = System.Drawing.Color.SlateGray
        Me.LblIPI.Location = New System.Drawing.Point(585, 723)
        Me.LblIPI.Name = "LblIPI"
        Me.LblIPI.Size = New System.Drawing.Size(15, 17)
        Me.LblIPI.TabIndex = 158
        Me.LblIPI.Text = "0"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(462, 723)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(73, 17)
        Me.Label33.TabIndex = 157
        Me.Label33.Text = "Alíquota IPI"
        '
        'LblUF
        '
        Me.LblUF.AutoSize = True
        Me.LblUF.ForeColor = System.Drawing.Color.SlateGray
        Me.LblUF.Location = New System.Drawing.Point(1088, 213)
        Me.LblUF.Name = "LblUF"
        Me.LblUF.Size = New System.Drawing.Size(11, 17)
        Me.LblUF.TabIndex = 159
        Me.LblUF.Text = " "
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 402)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1359, 281)
        Me.TabControl1.TabIndex = 160
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DtProdutos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1351, 253)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Produtos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1351, 253)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Serviços"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FrmEmitirNovaNF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1403, 786)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.LblUF)
        Me.Controls.Add(Me.LblIPI)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.LblICMSST)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.LblIcms)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.CmbEspecie)
        Me.Controls.Add(Me.TxtPlaca)
        Me.Controls.Add(Me.TxtValorSeguro)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CmbSeguradora)
        Me.Controls.Add(Me.Seguradora)
        Me.Controls.Add(Me.CmbTransportadores)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.CmbTransporteModo)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.LblModeloVeiculo)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblRGIETransp)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LblEnderecoTransp)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.LblCnpjTranp)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.LblInscricaoEstadualIe)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblEnderecoDestinatario)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LblRazaoSocial_Nome)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LblCnpj_Cpf_Destinatário)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LblIE)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LblEndereco)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblRazao)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblCnpj)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmEmitirNovaNF"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEmitirNovaNF"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        CType(Me.DtProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BttEmitirNfFiscal As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents LblCnpj As Label
    Friend WithEvents LblRazao As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LblEndereco As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblIE As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LblInscricaoEstadualIe As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblEnderecoDestinatario As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblRazaoSocial_Nome As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents LblCnpj_Cpf_Destinatário As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents LblRGIETransp As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblEnderecoTransp As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents LblCnpjTranp As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents CmbTransporteModo As ComboBox
    Friend WithEvents Label31 As Label
    Friend WithEvents CmbTransportadores As ComboBox
    Friend WithEvents Seguradora As Label
    Friend WithEvents CmbSeguradora As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TxtValorSeguro As TextBox
    Friend WithEvents TxtPlaca As TextBox
    Friend WithEvents LblModeloVeiculo As Label
    Friend WithEvents CmbEspecie As ComboBox
    Friend WithEvents DtProdutos As DataGridView
    Friend WithEvents LblIcms As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents LblICMSST As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents LblIPI As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents LblUF As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
End Class
