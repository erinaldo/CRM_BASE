<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmParceirosComerciais
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParceirosComerciais))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GpTipoParceiro = New System.Windows.Forms.GroupBox()
        Me.RdbPrestador = New System.Windows.Forms.RadioButton()
        Me.RdbSeguradora = New System.Windows.Forms.RadioButton()
        Me.RdbParceiro = New System.Windows.Forms.RadioButton()
        Me.GpDadosPessoais = New System.Windows.Forms.GroupBox()
        Me.Ckisento = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RdbFisica = New System.Windows.Forms.RadioButton()
        Me.RdbJuridica = New System.Windows.Forms.RadioButton()
        Me.LblRG_IE = New System.Windows.Forms.Label()
        Me.TxtIE = New System.Windows.Forms.TextBox()
        Me.LblDocCPF_CPNJ = New System.Windows.Forms.Label()
        Me.TxtCPF = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BttAddEndereço = New System.Windows.Forms.Button()
        Me.CmbEndereço = New System.Windows.Forms.ComboBox()
        Me.GpContatos = New System.Windows.Forms.GroupBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtCelular = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtTelefone = New System.Windows.Forms.MaskedTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BttAddBairro = New System.Windows.Forms.Button()
        Me.CmbBairro = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BttAddCidade = New System.Windows.Forms.Button()
        Me.CmbCidade = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BttAddEstado = New System.Windows.Forms.Button()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BttAddPais = New System.Windows.Forms.Button()
        Me.CmbPais = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtComplemento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BttBuscaCep = New System.Windows.Forms.Button()
        Me.TxtCep = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtNomeCompleto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BttAddColaborador = New System.Windows.Forms.ToolStripButton()
        Me.BttEditColaborador = New System.Windows.Forms.ToolStripButton()
        Me.BttSalvarColaborador = New System.Windows.Forms.ToolStripButton()
        Me.BttDesligar = New System.Windows.Forms.ToolStripButton()
        Me.CmbColaboradores = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.BttCancelar = New System.Windows.Forms.ToolStripButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GpTipoParceiro.SuspendLayout()
        Me.GpDadosPessoais.SuspendLayout()
        Me.GpContatos.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(941, 559)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TabControl2)
        Me.TabPage1.Controls.Add(Me.ToolStrip1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(933, 533)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Parceiros comerciais"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(3, 30)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(927, 500)
        Me.TabControl2.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GpTipoParceiro)
        Me.TabPage4.Controls.Add(Me.GpDadosPessoais)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(919, 474)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "Dados cadastrais"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GpTipoParceiro
        '
        Me.GpTipoParceiro.Controls.Add(Me.RdbPrestador)
        Me.GpTipoParceiro.Controls.Add(Me.RdbSeguradora)
        Me.GpTipoParceiro.Controls.Add(Me.RdbParceiro)
        Me.GpTipoParceiro.Enabled = False
        Me.GpTipoParceiro.Location = New System.Drawing.Point(3, 320)
        Me.GpTipoParceiro.Name = "GpTipoParceiro"
        Me.GpTipoParceiro.Size = New System.Drawing.Size(910, 70)
        Me.GpTipoParceiro.TabIndex = 46
        Me.GpTipoParceiro.TabStop = False
        Me.GpTipoParceiro.Text = "Tipo de parceiro"
        '
        'RdbPrestador
        '
        Me.RdbPrestador.AutoSize = True
        Me.RdbPrestador.Location = New System.Drawing.Point(318, 36)
        Me.RdbPrestador.Name = "RdbPrestador"
        Me.RdbPrestador.Size = New System.Drawing.Size(122, 17)
        Me.RdbPrestador.TabIndex = 46
        Me.RdbPrestador.TabStop = True
        Me.RdbPrestador.Text = "Prestador de serviço"
        Me.RdbPrestador.UseVisualStyleBackColor = True
        '
        'RdbSeguradora
        '
        Me.RdbSeguradora.AutoSize = True
        Me.RdbSeguradora.Location = New System.Drawing.Point(181, 36)
        Me.RdbSeguradora.Name = "RdbSeguradora"
        Me.RdbSeguradora.Size = New System.Drawing.Size(79, 17)
        Me.RdbSeguradora.TabIndex = 45
        Me.RdbSeguradora.TabStop = True
        Me.RdbSeguradora.Text = "Seguradora"
        Me.RdbSeguradora.UseVisualStyleBackColor = True
        '
        'RdbParceiro
        '
        Me.RdbParceiro.AutoSize = True
        Me.RdbParceiro.Location = New System.Drawing.Point(10, 36)
        Me.RdbParceiro.Name = "RdbParceiro"
        Me.RdbParceiro.Size = New System.Drawing.Size(114, 17)
        Me.RdbParceiro.TabIndex = 44
        Me.RdbParceiro.TabStop = True
        Me.RdbParceiro.Text = "Parceiro comercial"
        Me.RdbParceiro.UseVisualStyleBackColor = True
        '
        'GpDadosPessoais
        '
        Me.GpDadosPessoais.Controls.Add(Me.Ckisento)
        Me.GpDadosPessoais.Controls.Add(Me.CheckedListBox1)
        Me.GpDadosPessoais.Controls.Add(Me.GroupBox2)
        Me.GpDadosPessoais.Controls.Add(Me.RdbFisica)
        Me.GpDadosPessoais.Controls.Add(Me.RdbJuridica)
        Me.GpDadosPessoais.Controls.Add(Me.LblRG_IE)
        Me.GpDadosPessoais.Controls.Add(Me.TxtIE)
        Me.GpDadosPessoais.Controls.Add(Me.LblDocCPF_CPNJ)
        Me.GpDadosPessoais.Controls.Add(Me.TxtCPF)
        Me.GpDadosPessoais.Controls.Add(Me.Label2)
        Me.GpDadosPessoais.Controls.Add(Me.BttAddEndereço)
        Me.GpDadosPessoais.Controls.Add(Me.CmbEndereço)
        Me.GpDadosPessoais.Controls.Add(Me.GpContatos)
        Me.GpDadosPessoais.Controls.Add(Me.BttAddBairro)
        Me.GpDadosPessoais.Controls.Add(Me.CmbBairro)
        Me.GpDadosPessoais.Controls.Add(Me.Label12)
        Me.GpDadosPessoais.Controls.Add(Me.BttAddCidade)
        Me.GpDadosPessoais.Controls.Add(Me.CmbCidade)
        Me.GpDadosPessoais.Controls.Add(Me.Label13)
        Me.GpDadosPessoais.Controls.Add(Me.BttAddEstado)
        Me.GpDadosPessoais.Controls.Add(Me.CmbEstado)
        Me.GpDadosPessoais.Controls.Add(Me.Label11)
        Me.GpDadosPessoais.Controls.Add(Me.BttAddPais)
        Me.GpDadosPessoais.Controls.Add(Me.CmbPais)
        Me.GpDadosPessoais.Controls.Add(Me.Label10)
        Me.GpDadosPessoais.Controls.Add(Me.TxtComplemento)
        Me.GpDadosPessoais.Controls.Add(Me.Label9)
        Me.GpDadosPessoais.Controls.Add(Me.TxtNumero)
        Me.GpDadosPessoais.Controls.Add(Me.Label8)
        Me.GpDadosPessoais.Controls.Add(Me.Label7)
        Me.GpDadosPessoais.Controls.Add(Me.BttBuscaCep)
        Me.GpDadosPessoais.Controls.Add(Me.TxtCep)
        Me.GpDadosPessoais.Controls.Add(Me.Label6)
        Me.GpDadosPessoais.Controls.Add(Me.TxtNomeCompleto)
        Me.GpDadosPessoais.Controls.Add(Me.Label1)
        Me.GpDadosPessoais.Dock = System.Windows.Forms.DockStyle.Top
        Me.GpDadosPessoais.Enabled = False
        Me.GpDadosPessoais.Location = New System.Drawing.Point(3, 3)
        Me.GpDadosPessoais.Name = "GpDadosPessoais"
        Me.GpDadosPessoais.Size = New System.Drawing.Size(913, 311)
        Me.GpDadosPessoais.TabIndex = 1
        Me.GpDadosPessoais.TabStop = False
        Me.GpDadosPessoais.Text = "Dados principais"
        '
        'Ckisento
        '
        Me.Ckisento.AutoSize = True
        Me.Ckisento.Location = New System.Drawing.Point(462, 51)
        Me.Ckisento.Name = "Ckisento"
        Me.Ckisento.Size = New System.Drawing.Size(56, 17)
        Me.Ckisento.TabIndex = 47
        Me.Ckisento.Text = "Isento"
        Me.Ckisento.UseVisualStyleBackColor = True
        Me.Ckisento.Visible = False
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(-29, -90)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(120, 84)
        Me.CheckedListBox1.TabIndex = 46
        '
        'GroupBox2
        '
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(459, 189)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(444, 116)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Logomarca"
        '
        'RdbFisica
        '
        Me.RdbFisica.Enabled = False
        Me.RdbFisica.Location = New System.Drawing.Point(621, 24)
        Me.RdbFisica.Name = "RdbFisica"
        Me.RdbFisica.Size = New System.Drawing.Size(52, 17)
        Me.RdbFisica.TabIndex = 44
        Me.RdbFisica.TabStop = True
        Me.RdbFisica.Text = "Física"
        Me.RdbFisica.UseVisualStyleBackColor = True
        '
        'RdbJuridica
        '
        Me.RdbJuridica.Enabled = False
        Me.RdbJuridica.Location = New System.Drawing.Point(553, 24)
        Me.RdbJuridica.Name = "RdbJuridica"
        Me.RdbJuridica.Size = New System.Drawing.Size(62, 17)
        Me.RdbJuridica.TabIndex = 43
        Me.RdbJuridica.TabStop = True
        Me.RdbJuridica.Text = "Juridica"
        Me.RdbJuridica.UseVisualStyleBackColor = True
        '
        'LblRG_IE
        '
        Me.LblRG_IE.AutoSize = True
        Me.LblRG_IE.Location = New System.Drawing.Point(266, 52)
        Me.LblRG_IE.Name = "LblRG_IE"
        Me.LblRG_IE.Size = New System.Drawing.Size(20, 13)
        Me.LblRG_IE.TabIndex = 42
        Me.LblRG_IE.Text = "RG"
        '
        'TxtIE
        '
        Me.TxtIE.Enabled = False
        Me.TxtIE.Location = New System.Drawing.Point(318, 49)
        Me.TxtIE.Name = "TxtIE"
        Me.TxtIE.Size = New System.Drawing.Size(135, 21)
        Me.TxtIE.TabIndex = 41
        '
        'LblDocCPF_CPNJ
        '
        Me.LblDocCPF_CPNJ.AutoSize = True
        Me.LblDocCPF_CPNJ.Location = New System.Drawing.Point(7, 52)
        Me.LblDocCPF_CPNJ.Name = "LblDocCPF_CPNJ"
        Me.LblDocCPF_CPNJ.Size = New System.Drawing.Size(24, 13)
        Me.LblDocCPF_CPNJ.TabIndex = 40
        Me.LblDocCPF_CPNJ.Text = "CPF"
        '
        'TxtCPF
        '
        Me.TxtCPF.Enabled = False
        Me.TxtCPF.Location = New System.Drawing.Point(93, 49)
        Me.TxtCPF.Name = "TxtCPF"
        Me.TxtCPF.Size = New System.Drawing.Size(167, 21)
        Me.TxtCPF.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(459, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Personalidade"
        '
        'BttAddEndereço
        '
        Me.BttAddEndereço.BackgroundImage = CType(resources.GetObject("BttAddEndereço.BackgroundImage"), System.Drawing.Image)
        Me.BttAddEndereço.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddEndereço.Enabled = False
        Me.BttAddEndereço.FlatAppearance.BorderSize = 0
        Me.BttAddEndereço.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddEndereço.Location = New System.Drawing.Point(418, 102)
        Me.BttAddEndereço.Name = "BttAddEndereço"
        Me.BttAddEndereço.Size = New System.Drawing.Size(35, 20)
        Me.BttAddEndereço.TabIndex = 37
        Me.BttAddEndereço.UseVisualStyleBackColor = True
        '
        'CmbEndereço
        '
        Me.CmbEndereço.Enabled = False
        Me.CmbEndereço.FormattingEnabled = True
        Me.CmbEndereço.Location = New System.Drawing.Point(93, 101)
        Me.CmbEndereço.Name = "CmbEndereço"
        Me.CmbEndereço.Size = New System.Drawing.Size(319, 21)
        Me.CmbEndereço.TabIndex = 36
        '
        'GpContatos
        '
        Me.GpContatos.Controls.Add(Me.TxtEmail)
        Me.GpContatos.Controls.Add(Me.Label16)
        Me.GpContatos.Controls.Add(Me.TxtCelular)
        Me.GpContatos.Controls.Add(Me.Label15)
        Me.GpContatos.Controls.Add(Me.TxtTelefone)
        Me.GpContatos.Controls.Add(Me.Label14)
        Me.GpContatos.Enabled = False
        Me.GpContatos.Location = New System.Drawing.Point(9, 189)
        Me.GpContatos.Name = "GpContatos"
        Me.GpContatos.Size = New System.Drawing.Size(444, 116)
        Me.GpContatos.TabIndex = 31
        Me.GpContatos.TabStop = False
        Me.GpContatos.Text = "Contatos"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(84, 81)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(354, 21)
        Me.TxtEmail.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 84)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "E-mail"
        '
        'TxtCelular
        '
        Me.TxtCelular.Location = New System.Drawing.Point(84, 55)
        Me.TxtCelular.Mask = "(00) 0000-00000"
        Me.TxtCelular.Name = "TxtCelular"
        Me.TxtCelular.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtCelular.Size = New System.Drawing.Size(167, 21)
        Me.TxtCelular.TabIndex = 6
        Me.TxtCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Celular"
        '
        'TxtTelefone
        '
        Me.TxtTelefone.Location = New System.Drawing.Point(84, 29)
        Me.TxtTelefone.Mask = "(00) 0000-00000"
        Me.TxtTelefone.Name = "TxtTelefone"
        Me.TxtTelefone.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtTelefone.Size = New System.Drawing.Size(167, 21)
        Me.TxtTelefone.TabIndex = 4
        Me.TxtTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Telefone"
        '
        'BttAddBairro
        '
        Me.BttAddBairro.BackgroundImage = CType(resources.GetObject("BttAddBairro.BackgroundImage"), System.Drawing.Image)
        Me.BttAddBairro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddBairro.Enabled = False
        Me.BttAddBairro.FlatAppearance.BorderSize = 0
        Me.BttAddBairro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddBairro.Location = New System.Drawing.Point(871, 155)
        Me.BttAddBairro.Name = "BttAddBairro"
        Me.BttAddBairro.Size = New System.Drawing.Size(35, 20)
        Me.BttAddBairro.TabIndex = 30
        Me.BttAddBairro.UseVisualStyleBackColor = True
        '
        'CmbBairro
        '
        Me.CmbBairro.Enabled = False
        Me.CmbBairro.FormattingEnabled = True
        Me.CmbBairro.Location = New System.Drawing.Point(553, 154)
        Me.CmbBairro.Name = "CmbBairro"
        Me.CmbBairro.Size = New System.Drawing.Size(312, 21)
        Me.CmbBairro.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(459, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Bairro"
        '
        'BttAddCidade
        '
        Me.BttAddCidade.BackgroundImage = CType(resources.GetObject("BttAddCidade.BackgroundImage"), System.Drawing.Image)
        Me.BttAddCidade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddCidade.Enabled = False
        Me.BttAddCidade.FlatAppearance.BorderSize = 0
        Me.BttAddCidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddCidade.Location = New System.Drawing.Point(418, 155)
        Me.BttAddCidade.Name = "BttAddCidade"
        Me.BttAddCidade.Size = New System.Drawing.Size(35, 20)
        Me.BttAddCidade.TabIndex = 27
        Me.BttAddCidade.UseVisualStyleBackColor = True
        '
        'CmbCidade
        '
        Me.CmbCidade.Enabled = False
        Me.CmbCidade.FormattingEnabled = True
        Me.CmbCidade.Location = New System.Drawing.Point(93, 154)
        Me.CmbCidade.Name = "CmbCidade"
        Me.CmbCidade.Size = New System.Drawing.Size(319, 21)
        Me.CmbCidade.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 157)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Cidade"
        '
        'BttAddEstado
        '
        Me.BttAddEstado.BackgroundImage = CType(resources.GetObject("BttAddEstado.BackgroundImage"), System.Drawing.Image)
        Me.BttAddEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddEstado.Enabled = False
        Me.BttAddEstado.FlatAppearance.BorderSize = 0
        Me.BttAddEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddEstado.Location = New System.Drawing.Point(871, 128)
        Me.BttAddEstado.Name = "BttAddEstado"
        Me.BttAddEstado.Size = New System.Drawing.Size(35, 20)
        Me.BttAddEstado.TabIndex = 24
        Me.BttAddEstado.UseVisualStyleBackColor = True
        '
        'CmbEstado
        '
        Me.CmbEstado.Enabled = False
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Location = New System.Drawing.Point(553, 127)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(312, 21)
        Me.CmbEstado.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(459, 130)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Estado"
        '
        'BttAddPais
        '
        Me.BttAddPais.BackgroundImage = CType(resources.GetObject("BttAddPais.BackgroundImage"), System.Drawing.Image)
        Me.BttAddPais.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddPais.Enabled = False
        Me.BttAddPais.FlatAppearance.BorderSize = 0
        Me.BttAddPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddPais.Location = New System.Drawing.Point(418, 128)
        Me.BttAddPais.Name = "BttAddPais"
        Me.BttAddPais.Size = New System.Drawing.Size(35, 20)
        Me.BttAddPais.TabIndex = 21
        Me.BttAddPais.UseVisualStyleBackColor = True
        '
        'CmbPais
        '
        Me.CmbPais.Enabled = False
        Me.CmbPais.FormattingEnabled = True
        Me.CmbPais.Location = New System.Drawing.Point(93, 127)
        Me.CmbPais.Name = "CmbPais"
        Me.CmbPais.Size = New System.Drawing.Size(319, 21)
        Me.CmbPais.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "País"
        '
        'TxtComplemento
        '
        Me.TxtComplemento.Enabled = False
        Me.TxtComplemento.Location = New System.Drawing.Point(706, 101)
        Me.TxtComplemento.Name = "TxtComplemento"
        Me.TxtComplemento.Size = New System.Drawing.Size(90, 21)
        Me.TxtComplemento.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(649, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Compl."
        '
        'TxtNumero
        '
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Location = New System.Drawing.Point(553, 101)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(90, 21)
        Me.TxtNumero.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(459, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Nº"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Endereço"
        '
        'BttBuscaCep
        '
        Me.BttBuscaCep.BackgroundImage = CType(resources.GetObject("BttBuscaCep.BackgroundImage"), System.Drawing.Image)
        Me.BttBuscaCep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttBuscaCep.Enabled = False
        Me.BttBuscaCep.FlatAppearance.BorderSize = 0
        Me.BttBuscaCep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttBuscaCep.Location = New System.Drawing.Point(234, 75)
        Me.BttBuscaCep.Name = "BttBuscaCep"
        Me.BttBuscaCep.Size = New System.Drawing.Size(35, 20)
        Me.BttBuscaCep.TabIndex = 12
        Me.BttBuscaCep.UseVisualStyleBackColor = True
        '
        'TxtCep
        '
        Me.TxtCep.Enabled = False
        Me.TxtCep.Location = New System.Drawing.Point(93, 75)
        Me.TxtCep.Name = "TxtCep"
        Me.TxtCep.Size = New System.Drawing.Size(135, 21)
        Me.TxtCep.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "CEP"
        '
        'TxtNomeCompleto
        '
        Me.TxtNomeCompleto.Location = New System.Drawing.Point(93, 23)
        Me.TxtNomeCompleto.Name = "TxtNomeCompleto"
        Me.TxtNomeCompleto.Size = New System.Drawing.Size(360, 21)
        Me.TxtNomeCompleto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome completo"
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(919, 469)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "Referencias"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.TreeView1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(919, 469)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Histórico"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(3, 3)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(913, 463)
        Me.TreeView1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BttAddColaborador, Me.BttEditColaborador, Me.BttSalvarColaborador, Me.BttDesligar, Me.CmbColaboradores, Me.ToolStripLabel1, Me.BttCancelar})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(927, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BttAddColaborador
        '
        Me.BttAddColaborador.AutoSize = False
        Me.BttAddColaborador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BttAddColaborador.Image = Global.CRM_BASE.My.Resources.Resources._1486564412_plus_81511
        Me.BttAddColaborador.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttAddColaborador.Name = "BttAddColaborador"
        Me.BttAddColaborador.Size = New System.Drawing.Size(22, 20)
        Me.BttAddColaborador.Text = "ToolStripButton1"
        '
        'BttEditColaborador
        '
        Me.BttEditColaborador.AutoSize = False
        Me.BttEditColaborador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BttEditColaborador.Enabled = False
        Me.BttEditColaborador.Image = Global.CRM_BASE.My.Resources.Resources.diskette_save_saveas_1514
        Me.BttEditColaborador.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttEditColaborador.Name = "BttEditColaborador"
        Me.BttEditColaborador.Size = New System.Drawing.Size(22, 20)
        Me.BttEditColaborador.Text = "ToolStripButton2"
        '
        'BttSalvarColaborador
        '
        Me.BttSalvarColaborador.AutoSize = False
        Me.BttSalvarColaborador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BttSalvarColaborador.Enabled = False
        Me.BttSalvarColaborador.Image = Global.CRM_BASE.My.Resources.Resources.Save_icon_icons_com_73702
        Me.BttSalvarColaborador.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttSalvarColaborador.Name = "BttSalvarColaborador"
        Me.BttSalvarColaborador.Size = New System.Drawing.Size(22, 20)
        Me.BttSalvarColaborador.Text = "ToolStripButton3"
        '
        'BttDesligar
        '
        Me.BttDesligar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BttDesligar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BttDesligar.Enabled = False
        Me.BttDesligar.Image = Global.CRM_BASE.My.Resources.Resources._1486564409_lock_81509
        Me.BttDesligar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttDesligar.Name = "BttDesligar"
        Me.BttDesligar.Size = New System.Drawing.Size(24, 24)
        Me.BttDesligar.Text = "ToolStripButton3"
        '
        'CmbColaboradores
        '
        Me.CmbColaboradores.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.CmbColaboradores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbColaboradores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbColaboradores.Name = "CmbColaboradores"
        Me.CmbColaboradores.Size = New System.Drawing.Size(355, 27)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripLabel1.Text = "Cliente"
        Me.ToolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BttCancelar
        '
        Me.BttCancelar.AutoSize = False
        Me.BttCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BttCancelar.Enabled = False
        Me.BttCancelar.Image = Global.CRM_BASE.My.Resources.Resources.Close_Icon_icon_icons_com_69144
        Me.BttCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttCancelar.Name = "BttCancelar"
        Me.BttCancelar.Size = New System.Drawing.Size(22, 20)
        Me.BttCancelar.Text = "ToolStripButton3"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(899, 565)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 20)
        Me.Button1.TabIndex = 35
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmParceirosComerciais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 593)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmParceirosComerciais"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmParceirosComerciais"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GpTipoParceiro.ResumeLayout(False)
        Me.GpTipoParceiro.PerformLayout()
        Me.GpDadosPessoais.ResumeLayout(False)
        Me.GpDadosPessoais.PerformLayout()
        Me.GpContatos.ResumeLayout(False)
        Me.GpContatos.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GpTipoParceiro As GroupBox
    Friend WithEvents RdbPrestador As RadioButton
    Friend WithEvents RdbSeguradora As RadioButton
    Friend WithEvents RdbParceiro As RadioButton
    Friend WithEvents GpDadosPessoais As GroupBox
    Friend WithEvents Ckisento As CheckBox
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RdbFisica As RadioButton
    Friend WithEvents RdbJuridica As RadioButton
    Friend WithEvents LblRG_IE As Label
    Friend WithEvents TxtIE As TextBox
    Friend WithEvents LblDocCPF_CPNJ As Label
    Friend WithEvents TxtCPF As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BttAddEndereço As Button
    Friend WithEvents CmbEndereço As ComboBox
    Friend WithEvents GpContatos As GroupBox
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TxtCelular As MaskedTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TxtTelefone As MaskedTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BttAddBairro As Button
    Friend WithEvents CmbBairro As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents BttAddCidade As Button
    Friend WithEvents CmbCidade As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents BttAddEstado As Button
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents BttAddPais As Button
    Friend WithEvents CmbPais As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtComplemento As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtNumero As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BttBuscaCep As Button
    Friend WithEvents TxtCep As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtNomeCompleto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BttAddColaborador As ToolStripButton
    Friend WithEvents BttEditColaborador As ToolStripButton
    Friend WithEvents BttSalvarColaborador As ToolStripButton
    Friend WithEvents BttDesligar As ToolStripButton
    Friend WithEvents CmbColaboradores As ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents BttCancelar As ToolStripButton
    Friend WithEvents Button1 As Button
End Class
