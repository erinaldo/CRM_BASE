<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovoEstoque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNovoEstoque))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PnnMapa = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CmbEndereço = New System.Windows.Forms.ComboBox()
        Me.CmbBairro = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbCidade = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CmbPais = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtComplemento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtCep = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDescrição = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.PicMapa = New System.Windows.Forms.PictureBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.BttNovaRua = New System.Windows.Forms.ToolStripButton()
        Me.BttAddPredios = New System.Windows.Forms.ToolStripButton()
        Me.BttNovoAndar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.BttAddEndereço = New System.Windows.Forms.Button()
        Me.BttAddBairro = New System.Windows.Forms.Button()
        Me.BttAddCidade = New System.Windows.Forms.Button()
        Me.BttAddEstado = New System.Windows.Forms.Button()
        Me.BttAddPais = New System.Windows.Forms.Button()
        Me.BttBuscaCep = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PnnMapa.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PicMapa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BttSalvar)
        Me.Panel2.Controls.Add(Me.BttFechar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 650)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1317, 46)
        Me.Panel2.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.BttAddEndereço)
        Me.Panel1.Controls.Add(Me.CmbEndereço)
        Me.Panel1.Controls.Add(Me.BttAddBairro)
        Me.Panel1.Controls.Add(Me.CmbBairro)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.BttAddCidade)
        Me.Panel1.Controls.Add(Me.CmbCidade)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.BttAddEstado)
        Me.Panel1.Controls.Add(Me.CmbEstado)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.BttAddPais)
        Me.Panel1.Controls.Add(Me.CmbPais)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.TxtComplemento)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TxtNumero)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.BttBuscaCep)
        Me.Panel1.Controls.Add(Me.TxtCep)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TxtDescrição)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1317, 650)
        Me.Panel1.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.PnnMapa)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Controls.Add(Me.TreeView1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 204)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1317, 446)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estrutura do estoque"
        '
        'PnnMapa
        '
        Me.PnnMapa.AutoScroll = True
        Me.PnnMapa.BackColor = System.Drawing.Color.White
        Me.PnnMapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnnMapa.Controls.Add(Me.PicMapa)
        Me.PnnMapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnnMapa.Location = New System.Drawing.Point(27, 17)
        Me.PnnMapa.Name = "PnnMapa"
        Me.PnnMapa.Size = New System.Drawing.Size(1287, 329)
        Me.PnnMapa.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.BttNovaRua, Me.BttAddPredios, Me.BttNovoAndar, Me.ToolStripButton2, Me.ToolStripButton5})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 17)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(24, 329)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TreeView1.Location = New System.Drawing.Point(3, 346)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(1311, 97)
        Me.TreeView1.TabIndex = 3
        Me.TreeView1.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(15, 75)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(282, 17)
        Me.CheckBox1.TabIndex = 60
        Me.CheckBox1.Text = "Estoque no mesmo ambiente do registrado no sistema"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CmbEndereço
        '
        Me.CmbEndereço.Enabled = False
        Me.CmbEndereço.FormattingEnabled = True
        Me.CmbEndereço.Location = New System.Drawing.Point(109, 124)
        Me.CmbEndereço.Name = "CmbEndereço"
        Me.CmbEndereço.Size = New System.Drawing.Size(319, 21)
        Me.CmbEndereço.TabIndex = 58
        '
        'CmbBairro
        '
        Me.CmbBairro.Enabled = False
        Me.CmbBairro.FormattingEnabled = True
        Me.CmbBairro.Location = New System.Drawing.Point(569, 177)
        Me.CmbBairro.Name = "CmbBairro"
        Me.CmbBairro.Size = New System.Drawing.Size(312, 21)
        Me.CmbBairro.TabIndex = 56
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(475, 180)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "Bairro"
        '
        'CmbCidade
        '
        Me.CmbCidade.Enabled = False
        Me.CmbCidade.FormattingEnabled = True
        Me.CmbCidade.Location = New System.Drawing.Point(109, 177)
        Me.CmbCidade.Name = "CmbCidade"
        Me.CmbCidade.Size = New System.Drawing.Size(319, 21)
        Me.CmbCidade.TabIndex = 53
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 180)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Cidade"
        '
        'CmbEstado
        '
        Me.CmbEstado.Enabled = False
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Location = New System.Drawing.Point(569, 150)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(312, 21)
        Me.CmbEstado.TabIndex = 50
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(475, 153)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Estado"
        '
        'CmbPais
        '
        Me.CmbPais.Enabled = False
        Me.CmbPais.FormattingEnabled = True
        Me.CmbPais.Location = New System.Drawing.Point(109, 150)
        Me.CmbPais.Name = "CmbPais"
        Me.CmbPais.Size = New System.Drawing.Size(319, 21)
        Me.CmbPais.TabIndex = 47
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "País"
        '
        'TxtComplemento
        '
        Me.TxtComplemento.Enabled = False
        Me.TxtComplemento.Location = New System.Drawing.Point(722, 124)
        Me.TxtComplemento.Name = "TxtComplemento"
        Me.TxtComplemento.Size = New System.Drawing.Size(90, 21)
        Me.TxtComplemento.TabIndex = 45
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(665, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Compl."
        '
        'TxtNumero
        '
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Location = New System.Drawing.Point(569, 124)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(90, 21)
        Me.TxtNumero.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(475, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Nº"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Endereço"
        '
        'TxtCep
        '
        Me.TxtCep.Enabled = False
        Me.TxtCep.Location = New System.Drawing.Point(109, 98)
        Me.TxtCep.Name = "TxtCep"
        Me.TxtCep.Size = New System.Drawing.Size(135, 21)
        Me.TxtCep.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "CEP"
        '
        'TxtDescrição
        '
        Me.TxtDescrição.Location = New System.Drawing.Point(109, 44)
        Me.TxtDescrição.Name = "TxtDescrição"
        Me.TxtDescrição.Size = New System.Drawing.Size(319, 21)
        Me.TxtDescrição.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nome do estoque"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1317, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Novo estoque"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(1238, 14)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(35, 20)
        Me.BttSalvar.TabIndex = 23
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(1279, 14)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(35, 20)
        Me.BttFechar.TabIndex = 22
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'PicMapa
        '
        Me.PicMapa.Location = New System.Drawing.Point(3, 3)
        Me.PicMapa.Name = "PicMapa"
        Me.PicMapa.Size = New System.Drawing.Size(860, 156)
        Me.PicMapa.TabIndex = 0
        Me.PicMapa.TabStop = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.CRM_BASE.My.Resources.Resources.estoque_terceirizado
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(21, 20)
        Me.ToolStripButton1.Text = "Nova quadra"
        '
        'BttNovaRua
        '
        Me.BttNovaRua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BttNovaRua.Enabled = False
        Me.BttNovaRua.Image = Global.CRM_BASE.My.Resources.Resources.cargo_1_icon
        Me.BttNovaRua.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttNovaRua.Name = "BttNovaRua"
        Me.BttNovaRua.Size = New System.Drawing.Size(21, 20)
        Me.BttNovaRua.Text = "Nova rua"
        '
        'BttAddPredios
        '
        Me.BttAddPredios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BttAddPredios.Enabled = False
        Me.BttAddPredios.Image = Global.CRM_BASE.My.Resources.Resources.caixas_de_cartão_na_paleta_entregue_o_conceito_ícone_d_isolado_38186341
        Me.BttAddPredios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttAddPredios.Name = "BttAddPredios"
        Me.BttAddPredios.Size = New System.Drawing.Size(21, 20)
        Me.BttAddPredios.Text = "Novo prédio"
        '
        'BttNovoAndar
        '
        Me.BttNovoAndar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BttNovoAndar.Enabled = False
        Me.BttNovoAndar.Image = Global.CRM_BASE.My.Resources.Resources.caixas_de_cartão_na_paleta_entregue_o_conceito_ícone_d_isolado_38186341
        Me.BttNovoAndar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttNovoAndar.Name = "BttNovoAndar"
        Me.BttNovoAndar.Size = New System.Drawing.Size(21, 20)
        Me.BttNovoAndar.Text = "Nova quadra"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(21, 20)
        Me.ToolStripButton2.Text = "Nova quadra"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = Global.CRM_BASE.My.Resources.Resources._1486564394_edit_81508
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(21, 20)
        Me.ToolStripButton5.Text = "ToolStripButton5"
        '
        'BttAddEndereço
        '
        Me.BttAddEndereço.BackgroundImage = CType(resources.GetObject("BttAddEndereço.BackgroundImage"), System.Drawing.Image)
        Me.BttAddEndereço.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddEndereço.Enabled = False
        Me.BttAddEndereço.FlatAppearance.BorderSize = 0
        Me.BttAddEndereço.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddEndereço.Location = New System.Drawing.Point(434, 125)
        Me.BttAddEndereço.Name = "BttAddEndereço"
        Me.BttAddEndereço.Size = New System.Drawing.Size(35, 20)
        Me.BttAddEndereço.TabIndex = 59
        Me.BttAddEndereço.UseVisualStyleBackColor = True
        '
        'BttAddBairro
        '
        Me.BttAddBairro.BackgroundImage = CType(resources.GetObject("BttAddBairro.BackgroundImage"), System.Drawing.Image)
        Me.BttAddBairro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddBairro.Enabled = False
        Me.BttAddBairro.FlatAppearance.BorderSize = 0
        Me.BttAddBairro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddBairro.Location = New System.Drawing.Point(887, 178)
        Me.BttAddBairro.Name = "BttAddBairro"
        Me.BttAddBairro.Size = New System.Drawing.Size(35, 20)
        Me.BttAddBairro.TabIndex = 57
        Me.BttAddBairro.UseVisualStyleBackColor = True
        '
        'BttAddCidade
        '
        Me.BttAddCidade.BackgroundImage = CType(resources.GetObject("BttAddCidade.BackgroundImage"), System.Drawing.Image)
        Me.BttAddCidade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddCidade.Enabled = False
        Me.BttAddCidade.FlatAppearance.BorderSize = 0
        Me.BttAddCidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddCidade.Location = New System.Drawing.Point(434, 178)
        Me.BttAddCidade.Name = "BttAddCidade"
        Me.BttAddCidade.Size = New System.Drawing.Size(35, 20)
        Me.BttAddCidade.TabIndex = 54
        Me.BttAddCidade.UseVisualStyleBackColor = True
        '
        'BttAddEstado
        '
        Me.BttAddEstado.BackgroundImage = CType(resources.GetObject("BttAddEstado.BackgroundImage"), System.Drawing.Image)
        Me.BttAddEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddEstado.Enabled = False
        Me.BttAddEstado.FlatAppearance.BorderSize = 0
        Me.BttAddEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddEstado.Location = New System.Drawing.Point(887, 151)
        Me.BttAddEstado.Name = "BttAddEstado"
        Me.BttAddEstado.Size = New System.Drawing.Size(35, 20)
        Me.BttAddEstado.TabIndex = 51
        Me.BttAddEstado.UseVisualStyleBackColor = True
        '
        'BttAddPais
        '
        Me.BttAddPais.BackgroundImage = CType(resources.GetObject("BttAddPais.BackgroundImage"), System.Drawing.Image)
        Me.BttAddPais.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddPais.Enabled = False
        Me.BttAddPais.FlatAppearance.BorderSize = 0
        Me.BttAddPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddPais.Location = New System.Drawing.Point(434, 151)
        Me.BttAddPais.Name = "BttAddPais"
        Me.BttAddPais.Size = New System.Drawing.Size(35, 20)
        Me.BttAddPais.TabIndex = 48
        Me.BttAddPais.UseVisualStyleBackColor = True
        '
        'BttBuscaCep
        '
        Me.BttBuscaCep.BackgroundImage = CType(resources.GetObject("BttBuscaCep.BackgroundImage"), System.Drawing.Image)
        Me.BttBuscaCep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttBuscaCep.Enabled = False
        Me.BttBuscaCep.FlatAppearance.BorderSize = 0
        Me.BttBuscaCep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttBuscaCep.Location = New System.Drawing.Point(250, 98)
        Me.BttBuscaCep.Name = "BttBuscaCep"
        Me.BttBuscaCep.Size = New System.Drawing.Size(35, 20)
        Me.BttBuscaCep.TabIndex = 40
        Me.BttBuscaCep.UseVisualStyleBackColor = True
        '
        'FrmNovoEstoque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 696)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.HelpButton = True
        Me.Name = "FrmNovoEstoque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovoEstoque"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PnnMapa.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PicMapa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents BttSalvar As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtDescrição As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BttAddEndereço As Button
    Friend WithEvents CmbEndereço As ComboBox
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
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents BttNovaRua As ToolStripButton
    Friend WithEvents BttAddPredios As ToolStripButton
    Friend WithEvents BttNovoAndar As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents PnnMapa As Panel
    Friend WithEvents PicMapa As PictureBox
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents TreeView1 As TreeView
End Class
