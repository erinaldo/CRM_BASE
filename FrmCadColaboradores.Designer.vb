<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCadColaboradores
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCadColaboradores))
        Me.GpDadosBancarios = New System.Windows.Forms.GroupBox()
        Me.TxtOperacao = New System.Windows.Forms.MaskedTextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TxtNumConta = New System.Windows.Forms.MaskedTextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TxtAg = New System.Windows.Forms.MaskedTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.RdbCP = New System.Windows.Forms.RadioButton()
        Me.RdbCC = New System.Windows.Forms.RadioButton()
        Me.CmbBanco = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GpDependentes = New System.Windows.Forms.GroupBox()
        Me.DtDependentes = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmExcluir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.BttAddVinculo = New System.Windows.Forms.Button()
        Me.CmbVinculo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNomeDependente = New System.Windows.Forms.MaskedTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GpDadosPessoais = New System.Windows.Forms.GroupBox()
        Me.TxtRg = New System.Windows.Forms.MaskedTextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TxtCPF = New System.Windows.Forms.MaskedTextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.LblCidade = New System.Windows.Forms.Label()
        Me.LblBairro = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.LblPais = New System.Windows.Forms.Label()
        Me.LblEndereco = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TrPermissoes = New System.Windows.Forms.TreeView()
        Me.PicImagem = New System.Windows.Forms.PictureBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.BttAddNacionalidade = New System.Windows.Forms.Button()
        Me.CmbNacionalidade = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GpReferencias = New System.Windows.Forms.GroupBox()
        Me.TxtNomeRef03 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtTelefoneRef03 = New System.Windows.Forms.MaskedTextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtNomeRef02 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtTelefoneRef02 = New System.Windows.Forms.MaskedTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtNomeRef01 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtTelefoneRef01 = New System.Windows.Forms.MaskedTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GpContatos = New System.Windows.Forms.GroupBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtCelular = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtTelefone = New System.Windows.Forms.MaskedTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtComplemento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtCep = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtNomePai = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNomeMae = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNomeCompleto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BtnConcluir = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GpFuncao = New System.Windows.Forms.GroupBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TxtComissao = New System.Windows.Forms.NumericUpDown()
        Me.CkComissionar = New System.Windows.Forms.CheckBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.LblRemuneracao = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.BttAddFuncao = New System.Windows.Forms.Button()
        Me.CmbFuncao = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BttLogin = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.CmbDocEspecial = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TxtNumDocEspecial = New System.Windows.Forms.MaskedTextBox()
        Me.GpDadosBancarios.SuspendLayout()
        Me.GpDependentes.SuspendLayout()
        CType(Me.DtDependentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpDadosPessoais.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PicImagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpReferencias.SuspendLayout()
        Me.GpContatos.SuspendLayout()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.GpFuncao.SuspendLayout()
        CType(Me.TxtComissao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GpDadosBancarios
        '
        Me.GpDadosBancarios.Controls.Add(Me.TxtOperacao)
        Me.GpDadosBancarios.Controls.Add(Me.Label27)
        Me.GpDadosBancarios.Controls.Add(Me.TxtNumConta)
        Me.GpDadosBancarios.Controls.Add(Me.Label26)
        Me.GpDadosBancarios.Controls.Add(Me.TxtAg)
        Me.GpDadosBancarios.Controls.Add(Me.Label23)
        Me.GpDadosBancarios.Controls.Add(Me.RdbCP)
        Me.GpDadosBancarios.Controls.Add(Me.RdbCC)
        Me.GpDadosBancarios.Controls.Add(Me.CmbBanco)
        Me.GpDadosBancarios.Controls.Add(Me.Label3)
        Me.GpDadosBancarios.Enabled = False
        Me.GpDadosBancarios.Location = New System.Drawing.Point(565, 575)
        Me.GpDadosBancarios.Name = "GpDadosBancarios"
        Me.GpDadosBancarios.Size = New System.Drawing.Size(427, 182)
        Me.GpDadosBancarios.TabIndex = 33
        Me.GpDadosBancarios.TabStop = False
        Me.GpDadosBancarios.Text = "Dados bancários"
        '
        'TxtOperacao
        '
        Me.TxtOperacao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOperacao.Enabled = False
        Me.TxtOperacao.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtOperacao.Location = New System.Drawing.Point(111, 106)
        Me.TxtOperacao.Name = "TxtOperacao"
        Me.TxtOperacao.Size = New System.Drawing.Size(76, 21)
        Me.TxtOperacao.TabIndex = 39
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(9, 108)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(63, 17)
        Me.Label27.TabIndex = 38
        Me.Label27.Text = "Operação"
        '
        'TxtNumConta
        '
        Me.TxtNumConta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumConta.Enabled = False
        Me.TxtNumConta.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNumConta.Location = New System.Drawing.Point(311, 68)
        Me.TxtNumConta.Name = "TxtNumConta"
        Me.TxtNumConta.Size = New System.Drawing.Size(94, 21)
        Me.TxtNumConta.TabIndex = 37
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(193, 71)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(106, 17)
        Me.Label26.TabIndex = 36
        Me.Label26.Text = "Numero da conta"
        '
        'TxtAg
        '
        Me.TxtAg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAg.Enabled = False
        Me.TxtAg.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtAg.Location = New System.Drawing.Point(111, 68)
        Me.TxtAg.Name = "TxtAg"
        Me.TxtAg.Size = New System.Drawing.Size(76, 21)
        Me.TxtAg.TabIndex = 35
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 71)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 17)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "Agência"
        '
        'RdbCP
        '
        Me.RdbCP.AutoSize = True
        Me.RdbCP.Enabled = False
        Me.RdbCP.Location = New System.Drawing.Point(132, 144)
        Me.RdbCP.Name = "RdbCP"
        Me.RdbCP.Size = New System.Drawing.Size(120, 21)
        Me.RdbCP.TabIndex = 33
        Me.RdbCP.Text = "Conta poupança"
        Me.RdbCP.UseVisualStyleBackColor = True
        '
        'RdbCC
        '
        Me.RdbCC.AutoSize = True
        Me.RdbCC.Checked = True
        Me.RdbCC.Enabled = False
        Me.RdbCC.Location = New System.Drawing.Point(12, 144)
        Me.RdbCC.Name = "RdbCC"
        Me.RdbCC.Size = New System.Drawing.Size(114, 21)
        Me.RdbCC.TabIndex = 32
        Me.RdbCC.TabStop = True
        Me.RdbCC.Text = "Conta corrente"
        Me.RdbCC.UseVisualStyleBackColor = True
        '
        'CmbBanco
        '
        Me.CmbBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBanco.FormattingEnabled = True
        Me.CmbBanco.Location = New System.Drawing.Point(111, 30)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(294, 25)
        Me.CmbBanco.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 17)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Nome do banco"
        '
        'GpDependentes
        '
        Me.GpDependentes.Controls.Add(Me.DtDependentes)
        Me.GpDependentes.Controls.Add(Me.BttSalvar)
        Me.GpDependentes.Controls.Add(Me.BttAddVinculo)
        Me.GpDependentes.Controls.Add(Me.CmbVinculo)
        Me.GpDependentes.Controls.Add(Me.Label2)
        Me.GpDependentes.Controls.Add(Me.TxtNomeDependente)
        Me.GpDependentes.Controls.Add(Me.Label22)
        Me.GpDependentes.Enabled = False
        Me.GpDependentes.Location = New System.Drawing.Point(16, 400)
        Me.GpDependentes.Name = "GpDependentes"
        Me.GpDependentes.Size = New System.Drawing.Size(1236, 166)
        Me.GpDependentes.TabIndex = 32
        Me.GpDependentes.TabStop = False
        Me.GpDependentes.Text = "Dependentes"
        '
        'DtDependentes
        '
        Me.DtDependentes.AllowUserToAddRows = False
        Me.DtDependentes.AllowUserToDeleteRows = False
        Me.DtDependentes.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtDependentes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtDependentes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtDependentes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtDependentes.ColumnHeadersHeight = 29
        Me.DtDependentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DtDependentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.ClmExcluir})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtDependentes.DefaultCellStyle = DataGridViewCellStyle2
        Me.DtDependentes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DtDependentes.EnableHeadersVisualStyles = False
        Me.DtDependentes.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DtDependentes.Location = New System.Drawing.Point(3, 62)
        Me.DtDependentes.MultiSelect = False
        Me.DtDependentes.Name = "DtDependentes"
        Me.DtDependentes.ReadOnly = True
        Me.DtDependentes.RowHeadersVisible = False
        Me.DtDependentes.RowHeadersWidth = 51
        Me.DtDependentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DtDependentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtDependentes.Size = New System.Drawing.Size(1230, 101)
        Me.DtDependentes.TabIndex = 34
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Id"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Nome completo"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.HeaderText = "Grau de parentesco"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 147
        '
        'ClmExcluir
        '
        Me.ClmExcluir.HeaderText = ""
        Me.ClmExcluir.MinimumWidth = 6
        Me.ClmExcluir.Name = "ClmExcluir"
        Me.ClmExcluir.ReadOnly = True
        Me.ClmExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ClmExcluir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ClmExcluir.Width = 80
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(929, 28)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(35, 20)
        Me.BttSalvar.TabIndex = 33
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'BttAddVinculo
        '
        Me.BttAddVinculo.BackgroundImage = CType(resources.GetObject("BttAddVinculo.BackgroundImage"), System.Drawing.Image)
        Me.BttAddVinculo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddVinculo.Enabled = False
        Me.BttAddVinculo.FlatAppearance.BorderSize = 0
        Me.BttAddVinculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddVinculo.Location = New System.Drawing.Point(888, 28)
        Me.BttAddVinculo.Name = "BttAddVinculo"
        Me.BttAddVinculo.Size = New System.Drawing.Size(35, 21)
        Me.BttAddVinculo.TabIndex = 31
        Me.BttAddVinculo.UseVisualStyleBackColor = True
        '
        'CmbVinculo
        '
        Me.CmbVinculo.Enabled = False
        Me.CmbVinculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbVinculo.FormattingEnabled = True
        Me.CmbVinculo.Location = New System.Drawing.Point(570, 28)
        Me.CmbVinculo.Name = "CmbVinculo"
        Me.CmbVinculo.Size = New System.Drawing.Size(312, 25)
        Me.CmbVinculo.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(468, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Vinculo"
        '
        'TxtNomeDependente
        '
        Me.TxtNomeDependente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeDependente.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeDependente.Location = New System.Drawing.Point(110, 29)
        Me.TxtNomeDependente.Name = "TxtNomeDependente"
        Me.TxtNomeDependente.Size = New System.Drawing.Size(343, 21)
        Me.TxtNomeDependente.TabIndex = 4
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 17)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Nome"
        '
        'GpDadosPessoais
        '
        Me.GpDadosPessoais.Controls.Add(Me.TxtRg)
        Me.GpDadosPessoais.Controls.Add(Me.Label38)
        Me.GpDadosPessoais.Controls.Add(Me.TxtCPF)
        Me.GpDadosPessoais.Controls.Add(Me.Label30)
        Me.GpDadosPessoais.Controls.Add(Me.LblCidade)
        Me.GpDadosPessoais.Controls.Add(Me.LblBairro)
        Me.GpDadosPessoais.Controls.Add(Me.LblEstado)
        Me.GpDadosPessoais.Controls.Add(Me.LblPais)
        Me.GpDadosPessoais.Controls.Add(Me.LblEndereco)
        Me.GpDadosPessoais.Controls.Add(Me.Panel1)
        Me.GpDadosPessoais.Controls.Add(Me.BttAddNacionalidade)
        Me.GpDadosPessoais.Controls.Add(Me.CmbNacionalidade)
        Me.GpDadosPessoais.Controls.Add(Me.Label21)
        Me.GpDadosPessoais.Controls.Add(Me.GpReferencias)
        Me.GpDadosPessoais.Controls.Add(Me.GpContatos)
        Me.GpDadosPessoais.Controls.Add(Me.Label12)
        Me.GpDadosPessoais.Controls.Add(Me.Label13)
        Me.GpDadosPessoais.Controls.Add(Me.Label11)
        Me.GpDadosPessoais.Controls.Add(Me.Label10)
        Me.GpDadosPessoais.Controls.Add(Me.TxtComplemento)
        Me.GpDadosPessoais.Controls.Add(Me.Label9)
        Me.GpDadosPessoais.Controls.Add(Me.TxtNumero)
        Me.GpDadosPessoais.Controls.Add(Me.Label8)
        Me.GpDadosPessoais.Controls.Add(Me.Label7)
        Me.GpDadosPessoais.Controls.Add(Me.TxtCep)
        Me.GpDadosPessoais.Controls.Add(Me.Label6)
        Me.GpDadosPessoais.Controls.Add(Me.TxtNomePai)
        Me.GpDadosPessoais.Controls.Add(Me.Label5)
        Me.GpDadosPessoais.Controls.Add(Me.TxtNomeMae)
        Me.GpDadosPessoais.Controls.Add(Me.Label4)
        Me.GpDadosPessoais.Controls.Add(Me.TxtNomeCompleto)
        Me.GpDadosPessoais.Controls.Add(Me.Label1)
        Me.GpDadosPessoais.Location = New System.Drawing.Point(16, 41)
        Me.GpDadosPessoais.Name = "GpDadosPessoais"
        Me.GpDadosPessoais.Size = New System.Drawing.Size(1236, 353)
        Me.GpDadosPessoais.TabIndex = 1
        Me.GpDadosPessoais.TabStop = False
        Me.GpDadosPessoais.Text = "Dados pessoais"
        '
        'TxtRg
        '
        Me.TxtRg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRg.Enabled = False
        Me.TxtRg.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtRg.Location = New System.Drawing.Point(332, 27)
        Me.TxtRg.Name = "TxtRg"
        Me.TxtRg.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtRg.Size = New System.Drawing.Size(138, 21)
        Me.TxtRg.TabIndex = 47
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(283, 30)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(25, 17)
        Me.Label38.TabIndex = 46
        Me.Label38.Text = "RG"
        '
        'TxtCPF
        '
        Me.TxtCPF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCPF.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCPF.Location = New System.Drawing.Point(110, 27)
        Me.TxtCPF.Mask = "000,000,000-00"
        Me.TxtCPF.Name = "TxtCPF"
        Me.TxtCPF.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtCPF.Size = New System.Drawing.Size(167, 21)
        Me.TxtCPF.TabIndex = 45
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(8, 30)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(28, 17)
        Me.Label30.TabIndex = 44
        Me.Label30.Text = "CPF"
        '
        'LblCidade
        '
        Me.LblCidade.AutoSize = True
        Me.LblCidade.ForeColor = System.Drawing.Color.SlateGray
        Me.LblCidade.Location = New System.Drawing.Point(107, 199)
        Me.LblCidade.Name = "LblCidade"
        Me.LblCidade.Size = New System.Drawing.Size(11, 17)
        Me.LblCidade.TabIndex = 43
        Me.LblCidade.Text = " "
        '
        'LblBairro
        '
        Me.LblBairro.AutoSize = True
        Me.LblBairro.ForeColor = System.Drawing.Color.SlateGray
        Me.LblBairro.Location = New System.Drawing.Point(567, 199)
        Me.LblBairro.Name = "LblBairro"
        Me.LblBairro.Size = New System.Drawing.Size(11, 17)
        Me.LblBairro.TabIndex = 42
        Me.LblBairro.Text = " "
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.ForeColor = System.Drawing.Color.SlateGray
        Me.LblEstado.Location = New System.Drawing.Point(567, 168)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(11, 17)
        Me.LblEstado.TabIndex = 41
        Me.LblEstado.Text = " "
        '
        'LblPais
        '
        Me.LblPais.AutoSize = True
        Me.LblPais.ForeColor = System.Drawing.Color.SlateGray
        Me.LblPais.Location = New System.Drawing.Point(107, 168)
        Me.LblPais.Name = "LblPais"
        Me.LblPais.Size = New System.Drawing.Size(11, 17)
        Me.LblPais.TabIndex = 40
        Me.LblPais.Text = " "
        '
        'LblEndereco
        '
        Me.LblEndereco.AutoSize = True
        Me.LblEndereco.ForeColor = System.Drawing.Color.SlateGray
        Me.LblEndereco.Location = New System.Drawing.Point(107, 137)
        Me.LblEndereco.Name = "LblEndereco"
        Me.LblEndereco.Size = New System.Drawing.Size(11, 17)
        Me.LblEndereco.TabIndex = 39
        Me.LblEndereco.Text = " "
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TrPermissoes)
        Me.Panel1.Controls.Add(Me.PicImagem)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Location = New System.Drawing.Point(929, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 303)
        Me.Panel1.TabIndex = 38
        '
        'TrPermissoes
        '
        Me.TrPermissoes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TrPermissoes.CheckBoxes = True
        Me.TrPermissoes.Location = New System.Drawing.Point(3, 24)
        Me.TrPermissoes.Name = "TrPermissoes"
        Me.TrPermissoes.Size = New System.Drawing.Size(284, 276)
        Me.TrPermissoes.TabIndex = 77
        Me.TrPermissoes.Visible = False
        '
        'PicImagem
        '
        Me.PicImagem.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.untitled_n
        Me.PicImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicImagem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicImagem.Location = New System.Drawing.Point(0, 24)
        Me.PicImagem.Name = "PicImagem"
        Me.PicImagem.Size = New System.Drawing.Size(296, 279)
        Me.PicImagem.TabIndex = 4
        Me.PicImagem.TabStop = False
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.LightGray
        Me.Label31.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label31.ForeColor = System.Drawing.Color.SlateGray
        Me.Label31.Location = New System.Drawing.Point(0, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(296, 24)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "Foto do colaborador"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BttAddNacionalidade
        '
        Me.BttAddNacionalidade.BackgroundImage = CType(resources.GetObject("BttAddNacionalidade.BackgroundImage"), System.Drawing.Image)
        Me.BttAddNacionalidade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddNacionalidade.Enabled = False
        Me.BttAddNacionalidade.FlatAppearance.BorderSize = 0
        Me.BttAddNacionalidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddNacionalidade.Location = New System.Drawing.Point(888, 53)
        Me.BttAddNacionalidade.Name = "BttAddNacionalidade"
        Me.BttAddNacionalidade.Size = New System.Drawing.Size(35, 22)
        Me.BttAddNacionalidade.TabIndex = 35
        Me.BttAddNacionalidade.UseVisualStyleBackColor = True
        '
        'CmbNacionalidade
        '
        Me.CmbNacionalidade.Enabled = False
        Me.CmbNacionalidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbNacionalidade.FormattingEnabled = True
        Me.CmbNacionalidade.Location = New System.Drawing.Point(570, 53)
        Me.CmbNacionalidade.Name = "CmbNacionalidade"
        Me.CmbNacionalidade.Size = New System.Drawing.Size(312, 25)
        Me.CmbNacionalidade.TabIndex = 34
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(476, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 17)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "Nacionalidade"
        '
        'GpReferencias
        '
        Me.GpReferencias.Controls.Add(Me.TxtNomeRef03)
        Me.GpReferencias.Controls.Add(Me.Label24)
        Me.GpReferencias.Controls.Add(Me.TxtTelefoneRef03)
        Me.GpReferencias.Controls.Add(Me.Label25)
        Me.GpReferencias.Controls.Add(Me.TxtNomeRef02)
        Me.GpReferencias.Controls.Add(Me.Label17)
        Me.GpReferencias.Controls.Add(Me.TxtTelefoneRef02)
        Me.GpReferencias.Controls.Add(Me.Label18)
        Me.GpReferencias.Controls.Add(Me.TxtNomeRef01)
        Me.GpReferencias.Controls.Add(Me.Label20)
        Me.GpReferencias.Controls.Add(Me.TxtTelefoneRef01)
        Me.GpReferencias.Controls.Add(Me.Label19)
        Me.GpReferencias.Enabled = False
        Me.GpReferencias.Location = New System.Drawing.Point(479, 231)
        Me.GpReferencias.Name = "GpReferencias"
        Me.GpReferencias.Size = New System.Drawing.Size(447, 116)
        Me.GpReferencias.TabIndex = 32
        Me.GpReferencias.TabStop = False
        Me.GpReferencias.Text = "Contatos de referencia"
        '
        'TxtNomeRef03
        '
        Me.TxtNomeRef03.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeRef03.Enabled = False
        Me.TxtNomeRef03.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeRef03.Location = New System.Drawing.Point(298, 81)
        Me.TxtNomeRef03.Name = "TxtNomeRef03"
        Me.TxtNomeRef03.Size = New System.Drawing.Size(140, 21)
        Me.TxtNomeRef03.TabIndex = 25
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(250, 84)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(42, 17)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "Nome"
        '
        'TxtTelefoneRef03
        '
        Me.TxtTelefoneRef03.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTelefoneRef03.Enabled = False
        Me.TxtTelefoneRef03.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtTelefoneRef03.Location = New System.Drawing.Point(94, 81)
        Me.TxtTelefoneRef03.Mask = "(00) 0000-00000"
        Me.TxtTelefoneRef03.Name = "TxtTelefoneRef03"
        Me.TxtTelefoneRef03.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtTelefoneRef03.Size = New System.Drawing.Size(142, 21)
        Me.TxtTelefoneRef03.TabIndex = 23
        Me.TxtTelefoneRef03.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(4, 84)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 17)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Telefone"
        '
        'TxtNomeRef02
        '
        Me.TxtNomeRef02.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeRef02.Enabled = False
        Me.TxtNomeRef02.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeRef02.Location = New System.Drawing.Point(298, 55)
        Me.TxtNomeRef02.Name = "TxtNomeRef02"
        Me.TxtNomeRef02.Size = New System.Drawing.Size(140, 21)
        Me.TxtNomeRef02.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(250, 58)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 17)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Nome"
        '
        'TxtTelefoneRef02
        '
        Me.TxtTelefoneRef02.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTelefoneRef02.Enabled = False
        Me.TxtTelefoneRef02.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtTelefoneRef02.Location = New System.Drawing.Point(95, 55)
        Me.TxtTelefoneRef02.Mask = "(00) 0000-00000"
        Me.TxtTelefoneRef02.Name = "TxtTelefoneRef02"
        Me.TxtTelefoneRef02.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtTelefoneRef02.Size = New System.Drawing.Size(142, 21)
        Me.TxtTelefoneRef02.TabIndex = 19
        Me.TxtTelefoneRef02.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(5, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 17)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "Telefone"
        '
        'TxtNomeRef01
        '
        Me.TxtNomeRef01.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeRef01.Enabled = False
        Me.TxtNomeRef01.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeRef01.Location = New System.Drawing.Point(298, 29)
        Me.TxtNomeRef01.Name = "TxtNomeRef01"
        Me.TxtNomeRef01.Size = New System.Drawing.Size(139, 21)
        Me.TxtNomeRef01.TabIndex = 17
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(250, 32)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 17)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Nome"
        '
        'TxtTelefoneRef01
        '
        Me.TxtTelefoneRef01.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTelefoneRef01.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtTelefoneRef01.Location = New System.Drawing.Point(95, 29)
        Me.TxtTelefoneRef01.Mask = "(00) 0000-00000"
        Me.TxtTelefoneRef01.Name = "TxtTelefoneRef01"
        Me.TxtTelefoneRef01.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtTelefoneRef01.Size = New System.Drawing.Size(142, 21)
        Me.TxtTelefoneRef01.TabIndex = 4
        Me.TxtTelefoneRef01.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 17)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Telefone"
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
        Me.GpContatos.Location = New System.Drawing.Point(9, 231)
        Me.GpContatos.Name = "GpContatos"
        Me.GpContatos.Size = New System.Drawing.Size(461, 116)
        Me.GpContatos.TabIndex = 31
        Me.GpContatos.TabStop = False
        Me.GpContatos.Text = "Contatos"
        '
        'TxtEmail
        '
        Me.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEmail.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtEmail.Location = New System.Drawing.Point(101, 83)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(343, 21)
        Me.TxtEmail.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 86)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 17)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "E-mail"
        '
        'TxtCelular
        '
        Me.TxtCelular.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCelular.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCelular.Location = New System.Drawing.Point(101, 56)
        Me.TxtCelular.Mask = "(00) 0 0000-00000"
        Me.TxtCelular.Name = "TxtCelular"
        Me.TxtCelular.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtCelular.Size = New System.Drawing.Size(167, 21)
        Me.TxtCelular.TabIndex = 6
        Me.TxtCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 17)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Celular"
        '
        'TxtTelefone
        '
        Me.TxtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTelefone.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtTelefone.Location = New System.Drawing.Point(101, 29)
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
        Me.Label14.Size = New System.Drawing.Size(56, 17)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Telefone"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(476, 199)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 17)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Bairro"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 199)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 17)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Cidade"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(476, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 17)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Estado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 17)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "País"
        '
        'TxtComplemento
        '
        Me.TxtComplemento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtComplemento.Enabled = False
        Me.TxtComplemento.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtComplemento.Location = New System.Drawing.Point(723, 134)
        Me.TxtComplemento.Name = "TxtComplemento"
        Me.TxtComplemento.Size = New System.Drawing.Size(90, 21)
        Me.TxtComplemento.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(666, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 17)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Compl."
        '
        'TxtNumero
        '
        Me.TxtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNumero.Location = New System.Drawing.Point(570, 134)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(90, 21)
        Me.TxtNumero.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(476, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 17)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Nº"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Endereço"
        '
        'TxtCep
        '
        Me.TxtCep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCep.Enabled = False
        Me.TxtCep.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCep.Location = New System.Drawing.Point(110, 108)
        Me.TxtCep.Name = "TxtCep"
        Me.TxtCep.Size = New System.Drawing.Size(167, 21)
        Me.TxtCep.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "CEP"
        '
        'TxtNomePai
        '
        Me.TxtNomePai.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomePai.Enabled = False
        Me.TxtNomePai.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomePai.Location = New System.Drawing.Point(570, 81)
        Me.TxtNomePai.Name = "TxtNomePai"
        Me.TxtNomePai.Size = New System.Drawing.Size(353, 21)
        Me.TxtNomePai.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(476, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Nome do pai"
        '
        'TxtNomeMae
        '
        Me.TxtNomeMae.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeMae.Enabled = False
        Me.TxtNomeMae.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeMae.Location = New System.Drawing.Point(110, 81)
        Me.TxtNomeMae.Name = "TxtNomeMae"
        Me.TxtNomeMae.Size = New System.Drawing.Size(360, 21)
        Me.TxtNomeMae.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nome da mãe"
        '
        'TxtNomeCompleto
        '
        Me.TxtNomeCompleto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeCompleto.Enabled = False
        Me.TxtNomeCompleto.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeCompleto.Location = New System.Drawing.Point(110, 54)
        Me.TxtNomeCompleto.Name = "TxtNomeCompleto"
        Me.TxtNomeCompleto.Size = New System.Drawing.Size(360, 21)
        Me.TxtNomeCompleto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome completo"
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 763)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1274, 38)
        Me.PnnInferior.TabIndex = 57
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1188, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BtnConcluir)
        Me.Panel12.Controls.Add(Me.Button1)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1188, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(86, 38)
        Me.Panel12.TabIndex = 28
        '
        'BtnConcluir
        '
        Me.BtnConcluir.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BtnConcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnConcluir.FlatAppearance.BorderSize = 0
        Me.BtnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConcluir.Location = New System.Drawing.Point(16, 9)
        Me.BtnConcluir.Name = "BtnConcluir"
        Me.BtnConcluir.Size = New System.Drawing.Size(20, 20)
        Me.BtnConcluir.TabIndex = 29
        Me.BtnConcluir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(53, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 28
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.SlateGray
        Me.Label28.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label28.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label28.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label28.Location = New System.Drawing.Point(1, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(1274, 26)
        Me.Label28.TabIndex = 69
        Me.Label28.Text = "Cadastro de Colaboradores"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1275, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 801)
        Me.Panel2.TabIndex = 70
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 801)
        Me.Panel3.TabIndex = 71
        '
        'GpFuncao
        '
        Me.GpFuncao.Controls.Add(Me.TxtNumDocEspecial)
        Me.GpFuncao.Controls.Add(Me.Label40)
        Me.GpFuncao.Controls.Add(Me.CmbDocEspecial)
        Me.GpFuncao.Controls.Add(Me.Label39)
        Me.GpFuncao.Controls.Add(Me.Label37)
        Me.GpFuncao.Controls.Add(Me.TxtComissao)
        Me.GpFuncao.Controls.Add(Me.CkComissionar)
        Me.GpFuncao.Controls.Add(Me.Label35)
        Me.GpFuncao.Controls.Add(Me.Label36)
        Me.GpFuncao.Controls.Add(Me.Label32)
        Me.GpFuncao.Controls.Add(Me.Label34)
        Me.GpFuncao.Controls.Add(Me.LblRemuneracao)
        Me.GpFuncao.Controls.Add(Me.Label29)
        Me.GpFuncao.Controls.Add(Me.BttAddFuncao)
        Me.GpFuncao.Controls.Add(Me.CmbFuncao)
        Me.GpFuncao.Controls.Add(Me.Label33)
        Me.GpFuncao.Enabled = False
        Me.GpFuncao.Location = New System.Drawing.Point(16, 572)
        Me.GpFuncao.Name = "GpFuncao"
        Me.GpFuncao.Size = New System.Drawing.Size(541, 185)
        Me.GpFuncao.TabIndex = 72
        Me.GpFuncao.TabStop = False
        Me.GpFuncao.Text = "Função"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.ForeColor = System.Drawing.Color.SlateGray
        Me.Label37.Location = New System.Drawing.Point(202, 145)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(18, 17)
        Me.Label37.TabIndex = 42
        Me.Label37.Text = "%"
        '
        'TxtComissao
        '
        Me.TxtComissao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtComissao.DecimalPlaces = 2
        Me.TxtComissao.Enabled = False
        Me.TxtComissao.Location = New System.Drawing.Point(115, 146)
        Me.TxtComissao.Name = "TxtComissao"
        Me.TxtComissao.Size = New System.Drawing.Size(81, 20)
        Me.TxtComissao.TabIndex = 41
        '
        'CkComissionar
        '
        Me.CkComissionar.AutoSize = True
        Me.CkComissionar.Location = New System.Drawing.Point(12, 147)
        Me.CkComissionar.Name = "CkComissionar"
        Me.CkComissionar.Size = New System.Drawing.Size(97, 21)
        Me.CkComissionar.TabIndex = 40
        Me.CkComissionar.Text = "Comissionar"
        Me.CkComissionar.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.SlateGray
        Me.Label35.Location = New System.Drawing.Point(468, 111)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(51, 17)
        Me.Label35.TabIndex = 38
        Me.Label35.Text = "R$ 0,00"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(396, 111)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(66, 17)
        Me.Label36.TabIndex = 37
        Me.Label36.Text = "Descontos"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.SlateGray
        Me.Label32.Location = New System.Drawing.Point(300, 111)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(51, 17)
        Me.Label32.TabIndex = 35
        Me.Label32.Text = "R$ 0,00"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(202, 111)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(65, 17)
        Me.Label34.TabIndex = 34
        Me.Label34.Text = "Beneficios"
        '
        'LblRemuneracao
        '
        Me.LblRemuneracao.AutoSize = True
        Me.LblRemuneracao.ForeColor = System.Drawing.Color.SlateGray
        Me.LblRemuneracao.Location = New System.Drawing.Point(107, 109)
        Me.LblRemuneracao.Name = "LblRemuneracao"
        Me.LblRemuneracao.Size = New System.Drawing.Size(51, 17)
        Me.LblRemuneracao.TabIndex = 33
        Me.LblRemuneracao.Text = "R$ 0,00"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(9, 109)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(87, 17)
        Me.Label29.TabIndex = 32
        Me.Label29.Text = "Remuneração"
        '
        'BttAddFuncao
        '
        Me.BttAddFuncao.BackgroundImage = CType(resources.GetObject("BttAddFuncao.BackgroundImage"), System.Drawing.Image)
        Me.BttAddFuncao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddFuncao.FlatAppearance.BorderSize = 0
        Me.BttAddFuncao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddFuncao.Location = New System.Drawing.Point(500, 34)
        Me.BttAddFuncao.Name = "BttAddFuncao"
        Me.BttAddFuncao.Size = New System.Drawing.Size(35, 21)
        Me.BttAddFuncao.TabIndex = 31
        Me.BttAddFuncao.UseVisualStyleBackColor = True
        '
        'CmbFuncao
        '
        Me.CmbFuncao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbFuncao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbFuncao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbFuncao.FormattingEnabled = True
        Me.CmbFuncao.Location = New System.Drawing.Point(111, 30)
        Me.CmbFuncao.Name = "CmbFuncao"
        Me.CmbFuncao.Size = New System.Drawing.Size(383, 25)
        Me.CmbFuncao.TabIndex = 30
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(9, 34)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(48, 17)
        Me.Label33.TabIndex = 19
        Me.Label33.Text = "Função"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BttLogin)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Location = New System.Drawing.Point(998, 575)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 185)
        Me.GroupBox1.TabIndex = 73
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Menus"
        '
        'BttLogin
        '
        Me.BttLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BttLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttLogin.ImageKey = "1486564409-lock_81509.png"
        Me.BttLogin.ImageList = Me.ImageList1
        Me.BttLogin.Location = New System.Drawing.Point(17, 108)
        Me.BttLogin.Name = "BttLogin"
        Me.BttLogin.Size = New System.Drawing.Size(231, 62)
        Me.BttLogin.TabIndex = 33
        Me.BttLogin.Text = "Login de usuário"
        Me.BttLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttLogin.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1486564394-edit_81508.png")
        Me.ImageList1.Images.SetKeyName(1, "1486564409-lock_81509.png")
        '
        'Button4
        '
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.Enabled = False
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.ImageKey = "1486564394-edit_81508.png"
        Me.Button4.ImageList = Me.ImageList1
        Me.Button4.Location = New System.Drawing.Point(17, 27)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(231, 62)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "Pasta digital"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Delete-80_icon-icons.com_57340.png")
        '
        'CmbDocEspecial
        '
        Me.CmbDocEspecial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbDocEspecial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbDocEspecial.Enabled = False
        Me.CmbDocEspecial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbDocEspecial.FormattingEnabled = True
        Me.CmbDocEspecial.Location = New System.Drawing.Point(117, 71)
        Me.CmbDocEspecial.Name = "CmbDocEspecial"
        Me.CmbDocEspecial.Size = New System.Drawing.Size(109, 25)
        Me.CmbDocEspecial.TabIndex = 44
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(15, 75)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(77, 17)
        Me.Label39.TabIndex = 43
        Me.Label39.Text = "Tipo do DOC"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(232, 74)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(98, 17)
        Me.Label40.TabIndex = 45
        Me.Label40.Text = "Numero do doc."
        '
        'TxtNumDocEspecial
        '
        Me.TxtNumDocEspecial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumDocEspecial.Enabled = False
        Me.TxtNumDocEspecial.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNumDocEspecial.Location = New System.Drawing.Point(341, 71)
        Me.TxtNumDocEspecial.Name = "TxtNumDocEspecial"
        Me.TxtNumDocEspecial.Size = New System.Drawing.Size(203, 21)
        Me.TxtNumDocEspecial.TabIndex = 35
        '
        'FrmCadColaboradores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1276, 801)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GpFuncao)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.GpDadosBancarios)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.GpDependentes)
        Me.Controls.Add(Me.GpDadosPessoais)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCadColaboradores"
        Me.Opacity = 0.95R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCadColaboradores"
        Me.GpDadosBancarios.ResumeLayout(False)
        Me.GpDadosBancarios.PerformLayout()
        Me.GpDependentes.ResumeLayout(False)
        Me.GpDependentes.PerformLayout()
        CType(Me.DtDependentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpDadosPessoais.ResumeLayout(False)
        Me.GpDadosPessoais.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PicImagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpReferencias.ResumeLayout(False)
        Me.GpReferencias.PerformLayout()
        Me.GpContatos.ResumeLayout(False)
        Me.GpContatos.PerformLayout()
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.GpFuncao.ResumeLayout(False)
        Me.GpFuncao.PerformLayout()
        CType(Me.TxtComissao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GpDadosPessoais As GroupBox
    Friend WithEvents TxtCep As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtNomePai As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNomeMae As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtNomeCompleto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GpReferencias As GroupBox
    Friend WithEvents TxtNomeRef02 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TxtTelefoneRef02 As MaskedTextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TxtNomeRef01 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtTelefoneRef01 As MaskedTextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents GpContatos As GroupBox
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TxtCelular As MaskedTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TxtTelefone As MaskedTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtComplemento As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtNumero As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BttAddNacionalidade As Button
    Friend WithEvents CmbNacionalidade As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents GpDependentes As GroupBox
    Friend WithEvents BttAddVinculo As Button
    Friend WithEvents CmbVinculo As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtNomeDependente As MaskedTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents DtDependentes As DataGridView
    Friend WithEvents BttSalvar As Button
    Friend WithEvents GpDadosBancarios As GroupBox
    Friend WithEvents CmbBanco As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtOperacao As MaskedTextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TxtNumConta As MaskedTextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents TxtAg As MaskedTextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents RdbCP As RadioButton
    Friend WithEvents RdbCC As RadioButton
    Friend WithEvents TxtNomeRef03 As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TxtTelefoneRef03 As MaskedTextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label31 As Label
    Friend WithEvents PicImagem As PictureBox
    Friend WithEvents Label28 As Label
    Friend WithEvents BtnConcluir As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LblCidade As Label
    Friend WithEvents LblBairro As Label
    Friend WithEvents LblEstado As Label
    Friend WithEvents LblPais As Label
    Friend WithEvents LblEndereco As Label
    Friend WithEvents GpFuncao As GroupBox
    Friend WithEvents LblRemuneracao As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents BttAddFuncao As Button
    Friend WithEvents CmbFuncao As ComboBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents TxtComissao As NumericUpDown
    Friend WithEvents CkComissionar As CheckBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents TxtRg As MaskedTextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents TxtCPF As MaskedTextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BttLogin As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents TrPermissoes As TreeView
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents ClmExcluir As DataGridViewImageColumn
    Friend WithEvents TxtNumDocEspecial As MaskedTextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents CmbDocEspecial As ComboBox
    Friend WithEvents Label39 As Label
End Class
