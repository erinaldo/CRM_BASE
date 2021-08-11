<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.PnnColaboradores = New System.Windows.Forms.Panel()
        Me.LblColaboradores = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvarColaborador = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ImgLstIco = New System.Windows.Forms.ImageList(Me.components)
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Ckisento = New System.Windows.Forms.CheckBox()
        Me.RdbFisica = New System.Windows.Forms.RadioButton()
        Me.RdbJuridica = New System.Windows.Forms.RadioButton()
        Me.LblRG_IE = New System.Windows.Forms.Label()
        Me.TxtIE = New System.Windows.Forms.TextBox()
        Me.LblDocCPF_CPNJ = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNomeCompleto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtComplemento = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtCep = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtApelido = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtCPF = New System.Windows.Forms.MaskedTextBox()
        Me.LblPais = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.LblCidade = New System.Windows.Forms.Label()
        Me.LblBairro = New System.Windows.Forms.Label()
        Me.LblEndereco = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BttColaboradores = New System.Windows.Forms.Button()
        Me.BttFunções = New System.Windows.Forms.Button()
        Me.BttSetores = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DtFornecedores = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmEditarCliente = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ClmExcluirCLiente = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ClmCAT = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ClmASO = New System.Windows.Forms.DataGridViewImageColumn()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.PnnColaboradores.SuspendLayout()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.DtFornecedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 663)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(877, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 663)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(1, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(876, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 662)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(876, 1)
        Me.Panel4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(876, 28)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Cadastro de clientes"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.PnnColaboradores)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(191, 35)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(21, 200)
        Me.FlowLayoutPanel1.TabIndex = 39
        Me.FlowLayoutPanel1.Visible = False
        '
        'PnnColaboradores
        '
        Me.PnnColaboradores.Controls.Add(Me.LblColaboradores)
        Me.PnnColaboradores.Controls.Add(Me.Label2)
        Me.PnnColaboradores.Location = New System.Drawing.Point(3, 3)
        Me.PnnColaboradores.Name = "PnnColaboradores"
        Me.PnnColaboradores.Size = New System.Drawing.Size(200, 129)
        Me.PnnColaboradores.TabIndex = 0
        '
        'LblColaboradores
        '
        Me.LblColaboradores.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblColaboradores.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblColaboradores.Font = New System.Drawing.Font("Calibri", 22.0!)
        Me.LblColaboradores.ForeColor = System.Drawing.Color.SlateGray
        Me.LblColaboradores.Location = New System.Drawing.Point(0, 20)
        Me.LblColaboradores.Name = "LblColaboradores"
        Me.LblColaboradores.Size = New System.Drawing.Size(200, 106)
        Me.LblColaboradores.TabIndex = 1
        Me.LblColaboradores.Text = "0"
        Me.LblColaboradores.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Clientes"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.LblIdVistoria)
        Me.PnnInferior.Controls.Add(Me.LblIdSolução)
        Me.PnnInferior.Controls.Add(Me.LblIdmarca)
        Me.PnnInferior.Controls.Add(Me.Panel10)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Controls.Add(Me.Panel6)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 632)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(876, 30)
        Me.PnnInferior.TabIndex = 125
        '
        'LblIdVistoria
        '
        Me.LblIdVistoria.AutoSize = True
        Me.LblIdVistoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdVistoria.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdVistoria.Location = New System.Drawing.Point(214, 5)
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
        Me.LblIdSolução.Location = New System.Drawing.Point(199, 5)
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
        Me.LblIdmarca.Location = New System.Drawing.Point(184, 5)
        Me.LblIdmarca.Name = "LblIdmarca"
        Me.LblIdmarca.Size = New System.Drawing.Size(15, 17)
        Me.LblIdmarca.TabIndex = 46
        Me.LblIdmarca.Text = "0"
        Me.LblIdmarca.Visible = False
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(184, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(611, 5)
        Me.Panel10.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvarColaborador)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(795, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(81, 30)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvarColaborador
        '
        Me.BttSalvarColaborador.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvarColaborador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvarColaborador.FlatAppearance.BorderSize = 0
        Me.BttSalvarColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvarColaborador.Location = New System.Drawing.Point(15, 7)
        Me.BttSalvarColaborador.Name = "BttSalvarColaborador"
        Me.BttSalvarColaborador.Size = New System.Drawing.Size(15, 15)
        Me.BttSalvarColaborador.TabIndex = 29
        Me.BttSalvarColaborador.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(53, 7)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(15, 15)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(184, 30)
        Me.Panel6.TabIndex = 49
        '
        'ImgLstIco
        '
        Me.ImgLstIco.ImageStream = CType(resources.GetObject("ImgLstIco.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgLstIco.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgLstIco.Images.SetKeyName(0, "Cancel_40972.png")
        Me.ImgLstIco.Images.SetKeyName(1, "DocumentEdit_40924.png")
        Me.ImgLstIco.Images.SetKeyName(2, "add-1-icon.png")
        Me.ImgLstIco.Images.SetKeyName(3, "avatardefault_92824.png")
        Me.ImgLstIco.Images.SetKeyName(4, "capacete.png")
        Me.ImgLstIco.Images.SetKeyName(5, "gestor.png")
        Me.ImgLstIco.Images.SetKeyName(6, "png-transparent-accident-personal-injury-calza-hotel-sa-de-cv-lawyer-falling-acci" &
        "dent-hand-logo-accident-thumbnail.png")
        Me.ImgLstIco.Images.SetKeyName(7, "icone-plano-de-saude-manah-corp.png")
        Me.ImgLstIco.Images.SetKeyName(8, "seguranca-do-trabalho.png")
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Gainsboro
        Me.Label29.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label29.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label29.Location = New System.Drawing.Point(202, 38)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(662, 20)
        Me.Label29.TabIndex = 126
        Me.Label29.Text = "Dados do cliente"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Ckisento
        '
        Me.Ckisento.AutoSize = True
        Me.Ckisento.Enabled = False
        Me.Ckisento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Ckisento.Location = New System.Drawing.Point(699, 173)
        Me.Ckisento.Name = "Ckisento"
        Me.Ckisento.Size = New System.Drawing.Size(61, 21)
        Me.Ckisento.TabIndex = 136
        Me.Ckisento.Text = "Isento"
        Me.Ckisento.UseVisualStyleBackColor = True
        Me.Ckisento.Visible = False
        '
        'RdbFisica
        '
        Me.RdbFisica.Enabled = False
        Me.RdbFisica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RdbFisica.Location = New System.Drawing.Point(411, 114)
        Me.RdbFisica.Name = "RdbFisica"
        Me.RdbFisica.Size = New System.Drawing.Size(76, 17)
        Me.RdbFisica.TabIndex = 135
        Me.RdbFisica.TabStop = True
        Me.RdbFisica.Text = "Física"
        Me.RdbFisica.UseVisualStyleBackColor = True
        '
        'RdbJuridica
        '
        Me.RdbJuridica.Enabled = False
        Me.RdbJuridica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RdbJuridica.Location = New System.Drawing.Point(330, 114)
        Me.RdbJuridica.Name = "RdbJuridica"
        Me.RdbJuridica.Size = New System.Drawing.Size(75, 17)
        Me.RdbJuridica.TabIndex = 134
        Me.RdbJuridica.TabStop = True
        Me.RdbJuridica.Text = "Juridica"
        Me.RdbJuridica.UseVisualStyleBackColor = True
        '
        'LblRG_IE
        '
        Me.LblRG_IE.AutoSize = True
        Me.LblRG_IE.Location = New System.Drawing.Point(485, 176)
        Me.LblRG_IE.Name = "LblRG_IE"
        Me.LblRG_IE.Size = New System.Drawing.Size(25, 17)
        Me.LblRG_IE.TabIndex = 133
        Me.LblRG_IE.Text = "RG"
        '
        'TxtIE
        '
        Me.TxtIE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIE.Enabled = False
        Me.TxtIE.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtIE.Location = New System.Drawing.Point(555, 173)
        Me.TxtIE.Name = "TxtIE"
        Me.TxtIE.Size = New System.Drawing.Size(135, 21)
        Me.TxtIE.TabIndex = 132
        '
        'LblDocCPF_CPNJ
        '
        Me.LblDocCPF_CPNJ.AutoSize = True
        Me.LblDocCPF_CPNJ.Location = New System.Drawing.Point(218, 178)
        Me.LblDocCPF_CPNJ.Name = "LblDocCPF_CPNJ"
        Me.LblDocCPF_CPNJ.Size = New System.Drawing.Size(28, 17)
        Me.LblDocCPF_CPNJ.TabIndex = 131
        Me.LblDocCPF_CPNJ.Text = "CPF"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(218, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Personalidade"
        '
        'TxtNomeCompleto
        '
        Me.TxtNomeCompleto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeCompleto.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeCompleto.Location = New System.Drawing.Point(330, 79)
        Me.TxtNomeCompleto.Name = "TxtNomeCompleto"
        Me.TxtNomeCompleto.Size = New System.Drawing.Size(360, 21)
        Me.TxtNomeCompleto.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "Nome completo"
        '
        'TxtComplemento
        '
        Me.TxtComplemento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtComplemento.Enabled = False
        Me.TxtComplemento.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtComplemento.Location = New System.Drawing.Point(453, 311)
        Me.TxtComplemento.Name = "TxtComplemento"
        Me.TxtComplemento.Size = New System.Drawing.Size(156, 21)
        Me.TxtComplemento.TabIndex = 164
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(400, 312)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(47, 17)
        Me.Label22.TabIndex = 163
        Me.Label22.Text = "Compl."
        '
        'TxtNumero
        '
        Me.TxtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNumero.Location = New System.Drawing.Point(330, 310)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(64, 21)
        Me.TxtNumero.TabIndex = 162
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(218, 311)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(23, 17)
        Me.Label21.TabIndex = 161
        Me.Label21.Text = "Nº"
        '
        'TxtCep
        '
        Me.TxtCep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCep.Enabled = False
        Me.TxtCep.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCep.Location = New System.Drawing.Point(330, 200)
        Me.TxtCep.Name = "TxtCep"
        Me.TxtCep.Size = New System.Drawing.Size(149, 21)
        Me.TxtCep.TabIndex = 157
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(218, 203)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 17)
        Me.Label18.TabIndex = 156
        Me.Label18.Text = "Cep"
        '
        'TxtApelido
        '
        Me.TxtApelido.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtApelido.Enabled = False
        Me.TxtApelido.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtApelido.Location = New System.Drawing.Point(330, 146)
        Me.TxtApelido.Name = "TxtApelido"
        Me.TxtApelido.Size = New System.Drawing.Size(360, 21)
        Me.TxtApelido.TabIndex = 183
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(218, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 17)
        Me.Label10.TabIndex = 182
        Me.Label10.Text = "Apelido"
        '
        'TxtCPF
        '
        Me.TxtCPF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCPF.Enabled = False
        Me.TxtCPF.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCPF.Location = New System.Drawing.Point(330, 173)
        Me.TxtCPF.Mask = "000,000,000-000"
        Me.TxtCPF.Name = "TxtCPF"
        Me.TxtCPF.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtCPF.Size = New System.Drawing.Size(149, 21)
        Me.TxtCPF.TabIndex = 184
        Me.TxtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'LblPais
        '
        Me.LblPais.AutoSize = True
        Me.LblPais.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblPais.Location = New System.Drawing.Point(787, 283)
        Me.LblPais.Name = "LblPais"
        Me.LblPais.Size = New System.Drawing.Size(11, 17)
        Me.LblPais.TabIndex = 291
        Me.LblPais.Text = " "
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblEstado.Location = New System.Drawing.Point(399, 283)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(11, 17)
        Me.LblEstado.TabIndex = 290
        Me.LblEstado.Text = " "
        '
        'LblCidade
        '
        Me.LblCidade.AutoSize = True
        Me.LblCidade.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblCidade.Location = New System.Drawing.Point(696, 256)
        Me.LblCidade.Name = "LblCidade"
        Me.LblCidade.Size = New System.Drawing.Size(11, 17)
        Me.LblCidade.TabIndex = 289
        Me.LblCidade.Text = " "
        '
        'LblBairro
        '
        Me.LblBairro.AutoSize = True
        Me.LblBairro.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblBairro.Location = New System.Drawing.Point(399, 256)
        Me.LblBairro.Name = "LblBairro"
        Me.LblBairro.Size = New System.Drawing.Size(11, 17)
        Me.LblBairro.TabIndex = 288
        Me.LblBairro.Text = " "
        '
        'LblEndereco
        '
        Me.LblEndereco.AutoSize = True
        Me.LblEndereco.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblEndereco.Location = New System.Drawing.Point(399, 229)
        Me.LblEndereco.Name = "LblEndereco"
        Me.LblEndereco.Size = New System.Drawing.Size(11, 17)
        Me.LblEndereco.TabIndex = 287
        Me.LblEndereco.Text = " "
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(327, 283)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(46, 17)
        Me.Label26.TabIndex = 286
        Me.Label26.Text = "Estado"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(644, 256)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(46, 17)
        Me.Label24.TabIndex = 285
        Me.Label24.Text = "Cidade"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(327, 256)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 17)
        Me.Label23.TabIndex = 284
        Me.Label23.Text = "Bairro"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(327, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 17)
        Me.Label6.TabIndex = 283
        Me.Label6.Text = "Endereço"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel5.Controls.Add(Me.BttColaboradores)
        Me.Panel5.Controls.Add(Me.BttFunções)
        Me.Panel5.Controls.Add(Me.BttSetores)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(1, 29)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(184, 603)
        Me.Panel5.TabIndex = 292
        '
        'BttColaboradores
        '
        Me.BttColaboradores.BackColor = System.Drawing.Color.SlateGray
        Me.BttColaboradores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttColaboradores.Dock = System.Windows.Forms.DockStyle.Top
        Me.BttColaboradores.Enabled = False
        Me.BttColaboradores.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttColaboradores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttColaboradores.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttColaboradores.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttColaboradores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttColaboradores.ImageKey = "avatardefault_92824.png"
        Me.BttColaboradores.ImageList = Me.ImgLstIco
        Me.BttColaboradores.Location = New System.Drawing.Point(0, 77)
        Me.BttColaboradores.Name = "BttColaboradores"
        Me.BttColaboradores.Size = New System.Drawing.Size(184, 38)
        Me.BttColaboradores.TabIndex = 51
        Me.BttColaboradores.Text = "Colaboradores"
        Me.BttColaboradores.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttColaboradores.UseVisualStyleBackColor = False
        Me.BttColaboradores.Visible = False
        '
        'BttFunções
        '
        Me.BttFunções.BackColor = System.Drawing.Color.SlateGray
        Me.BttFunções.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFunções.Dock = System.Windows.Forms.DockStyle.Top
        Me.BttFunções.Enabled = False
        Me.BttFunções.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttFunções.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFunções.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttFunções.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttFunções.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttFunções.ImageKey = "capacete.png"
        Me.BttFunções.ImageList = Me.ImgLstIco
        Me.BttFunções.Location = New System.Drawing.Point(0, 39)
        Me.BttFunções.Name = "BttFunções"
        Me.BttFunções.Size = New System.Drawing.Size(184, 38)
        Me.BttFunções.TabIndex = 50
        Me.BttFunções.Text = "Funções"
        Me.BttFunções.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttFunções.UseVisualStyleBackColor = False
        Me.BttFunções.Visible = False
        '
        'BttSetores
        '
        Me.BttSetores.BackColor = System.Drawing.Color.SlateGray
        Me.BttSetores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSetores.Dock = System.Windows.Forms.DockStyle.Top
        Me.BttSetores.Enabled = False
        Me.BttSetores.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttSetores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSetores.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttSetores.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttSetores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttSetores.ImageKey = "gestor.png"
        Me.BttSetores.ImageList = Me.ImgLstIco
        Me.BttSetores.Location = New System.Drawing.Point(0, 1)
        Me.BttSetores.Name = "BttSetores"
        Me.BttSetores.Size = New System.Drawing.Size(184, 38)
        Me.BttSetores.TabIndex = 49
        Me.BttSetores.Text = "Setores"
        Me.BttSetores.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttSetores.UseVisualStyleBackColor = False
        Me.BttSetores.Visible = False
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(184, 1)
        Me.Panel7.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(199, 345)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(665, 20)
        Me.Label5.TabIndex = 173
        Me.Label5.Text = "Colaboradores"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Cancel_40972.png")
        Me.ImageList1.Images.SetKeyName(1, "DocumentEdit_40924.png")
        Me.ImageList1.Images.SetKeyName(2, "add-1-icon.png")
        Me.ImageList1.Images.SetKeyName(3, "avatardefault_92824.png")
        Me.ImageList1.Images.SetKeyName(4, "capacete.png")
        Me.ImageList1.Images.SetKeyName(5, "gestor.png")
        '
        'DtFornecedores
        '
        Me.DtFornecedores.AllowUserToAddRows = False
        Me.DtFornecedores.AllowUserToDeleteRows = False
        Me.DtFornecedores.AllowUserToResizeColumns = False
        Me.DtFornecedores.AllowUserToResizeRows = False
        Me.DtFornecedores.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtFornecedores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtFornecedores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtFornecedores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtFornecedores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtFornecedores.ColumnHeadersHeight = 20
        Me.DtFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DtFornecedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column2, Me.Column3, Me.ClmEditarCliente, Me.ClmExcluirCLiente, Me.ClmCAT, Me.ClmASO})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtFornecedores.DefaultCellStyle = DataGridViewCellStyle2
        Me.DtFornecedores.EnableHeadersVisualStyles = False
        Me.DtFornecedores.Location = New System.Drawing.Point(197, 368)
        Me.DtFornecedores.MultiSelect = False
        Me.DtFornecedores.Name = "DtFornecedores"
        Me.DtFornecedores.ReadOnly = True
        Me.DtFornecedores.RowHeadersVisible = False
        Me.DtFornecedores.RowHeadersWidth = 51
        Me.DtFornecedores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtFornecedores.RowTemplate.Height = 30
        Me.DtFornecedores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DtFornecedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtFornecedores.Size = New System.Drawing.Size(667, 258)
        Me.DtFornecedores.TabIndex = 115
        '
        'Column6
        '
        Me.Column6.HeaderText = "IdColaboradorCliente"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        Me.Column6.Width = 125
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Nome completo"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Cargo"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 125
        '
        'Column3
        '
        Me.Column3.HeaderText = "Setor"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 125
        '
        'ClmEditarCliente
        '
        Me.ClmEditarCliente.HeaderText = ""
        Me.ClmEditarCliente.MinimumWidth = 6
        Me.ClmEditarCliente.Name = "ClmEditarCliente"
        Me.ClmEditarCliente.ReadOnly = True
        Me.ClmEditarCliente.Width = 35
        '
        'ClmExcluirCLiente
        '
        Me.ClmExcluirCLiente.HeaderText = ""
        Me.ClmExcluirCLiente.MinimumWidth = 6
        Me.ClmExcluirCLiente.Name = "ClmExcluirCLiente"
        Me.ClmExcluirCLiente.ReadOnly = True
        Me.ClmExcluirCLiente.Width = 35
        '
        'ClmCAT
        '
        Me.ClmCAT.HeaderText = "C.A.T."
        Me.ClmCAT.MinimumWidth = 6
        Me.ClmCAT.Name = "ClmCAT"
        Me.ClmCAT.ReadOnly = True
        Me.ClmCAT.Width = 35
        '
        'ClmASO
        '
        Me.ClmASO.HeaderText = "A.S.O."
        Me.ClmASO.MinimumWidth = 6
        Me.ClmASO.Name = "ClmASO"
        Me.ClmASO.ReadOnly = True
        Me.ClmASO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ClmASO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ClmASO.Width = 35
        '
        'FrmClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(878, 663)
        Me.Controls.Add(Me.DtFornecedores)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.LblPais)
        Me.Controls.Add(Me.LblEstado)
        Me.Controls.Add(Me.LblCidade)
        Me.Controls.Add(Me.LblBairro)
        Me.Controls.Add(Me.LblEndereco)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.TxtCPF)
        Me.Controls.Add(Me.TxtApelido)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtComplemento)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TxtCep)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Ckisento)
        Me.Controls.Add(Me.RdbFisica)
        Me.Controls.Add(Me.RdbJuridica)
        Me.Controls.Add(Me.LblRG_IE)
        Me.Controls.Add(Me.TxtIE)
        Me.Controls.Add(Me.LblDocCPF_CPNJ)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtNomeCompleto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmClientes"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmClientes"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.PnnColaboradores.ResumeLayout(False)
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.DtFornecedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents PnnColaboradores As Panel
    Friend WithEvents LblColaboradores As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents Ckisento As CheckBox
    Friend WithEvents RdbFisica As RadioButton
    Friend WithEvents RdbJuridica As RadioButton
    Friend WithEvents LblRG_IE As Label
    Friend WithEvents TxtIE As TextBox
    Friend WithEvents LblDocCPF_CPNJ As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNomeCompleto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtComplemento As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TxtNumero As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TxtCep As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents BttSalvarColaborador As Button
    Friend WithEvents TxtApelido As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtCPF As MaskedTextBox
    Friend WithEvents BttSetores As Button
    Friend WithEvents BttFunções As Button
    Friend WithEvents BttColaboradores As Button
    Friend WithEvents ImgLstIco As ImageList
    Friend WithEvents LblPais As Label
    Friend WithEvents LblEstado As Label
    Friend WithEvents LblCidade As Label
    Friend WithEvents LblBairro As Label
    Friend WithEvents LblEndereco As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents DtFornecedores As DataGridView
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents ClmEditarCliente As DataGridViewImageColumn
    Friend WithEvents ClmExcluirCLiente As DataGridViewImageColumn
    Friend WithEvents ClmCAT As DataGridViewImageColumn
    Friend WithEvents ClmASO As DataGridViewImageColumn
End Class
