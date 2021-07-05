<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fisco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fisco))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblIE = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblEndereco = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblRazao = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblCnpj = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblRegime = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblSimples = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblNomeFantasia = New System.Windows.Forms.Label()
        Me.LblCNAE = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblMunicipio = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblUf = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LstSecundárias = New System.Windows.Forms.ListBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblCapitalSocial = New System.Windows.Forms.Label()
        Me.LstSocios = New System.Windows.Forms.ListBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LstFiliais = New System.Windows.Forms.ListBox()
        Me.LblSuframa = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LblAliquotas = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtIPI = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TxtICMS = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CkPadrao = New System.Windows.Forms.CheckBox()
        Me.BttAddCFOP = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CmbCFOP = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CmbTipoOperacao = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DtCotFinal = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmDeletar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DtCotFinal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(850, 30)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Tributos e taxas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.PnnInferior.Location = New System.Drawing.Point(1, 668)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(850, 32)
        Me.PnnInferior.TabIndex = 97
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
        Me.Panel5.Size = New System.Drawing.Size(803, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(803, 0)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(47, 32)
        Me.Panel12.TabIndex = 50
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(13, 7)
        Me.BttFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(21, 20)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(851, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 700)
        Me.Panel1.TabIndex = 98
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 700)
        Me.Panel2.TabIndex = 99
        '
        'LblIE
        '
        Me.LblIE.AutoSize = True
        Me.LblIE.ForeColor = System.Drawing.Color.Peru
        Me.LblIE.Location = New System.Drawing.Point(590, 39)
        Me.LblIE.Name = "LblIE"
        Me.LblIE.Size = New System.Drawing.Size(34, 17)
        Me.LblIE.TabIndex = 120
        Me.LblIE.Text = "CNPJ"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(474, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 17)
        Me.Label12.TabIndex = 119
        Me.Label12.Text = "Inscrição estadual"
        '
        'LblEndereco
        '
        Me.LblEndereco.ForeColor = System.Drawing.Color.Peru
        Me.LblEndereco.Location = New System.Drawing.Point(131, 123)
        Me.LblEndereco.Name = "LblEndereco"
        Me.LblEndereco.Size = New System.Drawing.Size(703, 38)
        Me.LblEndereco.TabIndex = 118
        Me.LblEndereco.Text = "CNPJ"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 17)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "Endereço"
        '
        'LblRazao
        '
        Me.LblRazao.AutoSize = True
        Me.LblRazao.ForeColor = System.Drawing.Color.Peru
        Me.LblRazao.Location = New System.Drawing.Point(131, 66)
        Me.LblRazao.Name = "LblRazao"
        Me.LblRazao.Size = New System.Drawing.Size(34, 17)
        Me.LblRazao.TabIndex = 116
        Me.LblRazao.Text = "CNPJ"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 17)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Razão Social"
        '
        'LblCnpj
        '
        Me.LblCnpj.AutoSize = True
        Me.LblCnpj.ForeColor = System.Drawing.Color.Peru
        Me.LblCnpj.Location = New System.Drawing.Point(131, 39)
        Me.LblCnpj.Name = "LblCnpj"
        Me.LblCnpj.Size = New System.Drawing.Size(106, 17)
        Me.LblCnpj.TabIndex = 114
        Me.LblCnpj.Text = "17489894000128"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 17)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "CNPJ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 317)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 17)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Regime tributário"
        '
        'LblRegime
        '
        Me.LblRegime.AutoSize = True
        Me.LblRegime.ForeColor = System.Drawing.Color.Peru
        Me.LblRegime.Location = New System.Drawing.Point(131, 317)
        Me.LblRegime.Name = "LblRegime"
        Me.LblRegime.Size = New System.Drawing.Size(34, 17)
        Me.LblRegime.TabIndex = 122
        Me.LblRegime.Text = "CNPJ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 346)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Simples Nacional"
        '
        'LblSimples
        '
        Me.LblSimples.AutoSize = True
        Me.LblSimples.ForeColor = System.Drawing.Color.Peru
        Me.LblSimples.Location = New System.Drawing.Point(131, 346)
        Me.LblSimples.Name = "LblSimples"
        Me.LblSimples.Size = New System.Drawing.Size(34, 17)
        Me.LblSimples.TabIndex = 124
        Me.LblSimples.Text = "CNPJ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 17)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "Nome fantasia"
        '
        'LblNomeFantasia
        '
        Me.LblNomeFantasia.AutoSize = True
        Me.LblNomeFantasia.ForeColor = System.Drawing.Color.Peru
        Me.LblNomeFantasia.Location = New System.Drawing.Point(131, 95)
        Me.LblNomeFantasia.Name = "LblNomeFantasia"
        Me.LblNomeFantasia.Size = New System.Drawing.Size(34, 17)
        Me.LblNomeFantasia.TabIndex = 126
        Me.LblNomeFantasia.Text = "CNPJ"
        '
        'LblCNAE
        '
        Me.LblCNAE.AutoSize = True
        Me.LblCNAE.ForeColor = System.Drawing.Color.Peru
        Me.LblCNAE.Location = New System.Drawing.Point(131, 223)
        Me.LblCNAE.Name = "LblCNAE"
        Me.LblCNAE.Size = New System.Drawing.Size(34, 17)
        Me.LblCNAE.TabIndex = 128
        Me.LblCNAE.Text = "CNPJ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 223)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 17)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "CNAE Principal"
        '
        'LblMunicipio
        '
        Me.LblMunicipio.AutoSize = True
        Me.LblMunicipio.ForeColor = System.Drawing.Color.Peru
        Me.LblMunicipio.Location = New System.Drawing.Point(131, 164)
        Me.LblMunicipio.Name = "LblMunicipio"
        Me.LblMunicipio.Size = New System.Drawing.Size(34, 17)
        Me.LblMunicipio.TabIndex = 130
        Me.LblMunicipio.Text = "CNPJ"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 17)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Municipio"
        '
        'LblUf
        '
        Me.LblUf.AutoSize = True
        Me.LblUf.ForeColor = System.Drawing.Color.Peru
        Me.LblUf.Location = New System.Drawing.Point(590, 164)
        Me.LblUf.Name = "LblUf"
        Me.LblUf.Size = New System.Drawing.Size(34, 17)
        Me.LblUf.TabIndex = 132
        Me.LblUf.Text = "CNPJ"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(474, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 17)
        Me.Label11.TabIndex = 131
        Me.Label11.Text = "Estado / UF"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Gainsboro
        Me.Label20.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label20.ForeColor = System.Drawing.Color.SlateGray
        Me.Label20.Location = New System.Drawing.Point(5, 11)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(829, 17)
        Me.Label20.TabIndex = 133
        Me.Label20.Text = "Dados cadastrais"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label6.ForeColor = System.Drawing.Color.SlateGray
        Me.Label6.Location = New System.Drawing.Point(5, 194)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(829, 17)
        Me.Label6.TabIndex = 134
        Me.Label6.Text = "Atividade principal e regime de tributação"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Gainsboro
        Me.Label13.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label13.ForeColor = System.Drawing.Color.SlateGray
        Me.Label13.Location = New System.Drawing.Point(5, 377)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(362, 17)
        Me.Label13.TabIndex = 135
        Me.Label13.Text = "Representantes"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 254)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 17)
        Me.Label15.TabIndex = 136
        Me.Label15.Text = "CNAE secundário"
        '
        'LstSecundárias
        '
        Me.LstSecundárias.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LstSecundárias.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LstSecundárias.ForeColor = System.Drawing.Color.Peru
        Me.LstSecundárias.FormattingEnabled = True
        Me.LstSecundárias.ItemHeight = 17
        Me.LstSecundárias.Location = New System.Drawing.Point(135, 254)
        Me.LstSecundárias.Margin = New System.Windows.Forms.Padding(2)
        Me.LstSecundárias.Name = "LstSecundárias"
        Me.LstSecundárias.Size = New System.Drawing.Size(699, 51)
        Me.LstSecundárias.TabIndex = 137
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(474, 95)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 17)
        Me.Label16.TabIndex = 139
        Me.Label16.Text = "Capital social"
        '
        'LblCapitalSocial
        '
        Me.LblCapitalSocial.AutoSize = True
        Me.LblCapitalSocial.ForeColor = System.Drawing.Color.Peru
        Me.LblCapitalSocial.Location = New System.Drawing.Point(590, 95)
        Me.LblCapitalSocial.Name = "LblCapitalSocial"
        Me.LblCapitalSocial.Size = New System.Drawing.Size(34, 17)
        Me.LblCapitalSocial.TabIndex = 140
        Me.LblCapitalSocial.Text = "CNPJ"
        '
        'LstSocios
        '
        Me.LstSocios.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LstSocios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LstSocios.ForeColor = System.Drawing.Color.Peru
        Me.LstSocios.FormattingEnabled = True
        Me.LstSocios.ItemHeight = 17
        Me.LstSocios.Location = New System.Drawing.Point(15, 403)
        Me.LstSocios.Margin = New System.Windows.Forms.Padding(2)
        Me.LstSocios.Name = "LstSocios"
        Me.LstSocios.Size = New System.Drawing.Size(352, 187)
        Me.LstSocios.TabIndex = 141
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gainsboro
        Me.Label14.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label14.ForeColor = System.Drawing.Color.SlateGray
        Me.Label14.Location = New System.Drawing.Point(378, 377)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(456, 17)
        Me.Label14.TabIndex = 142
        Me.Label14.Text = "Filiais"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Gainsboro
        Me.Label17.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label17.ForeColor = System.Drawing.Color.SlateGray
        Me.Label17.Location = New System.Drawing.Point(373, 379)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(1, 116)
        Me.Label17.TabIndex = 143
        Me.Label17.Text = "Filiais"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LstFiliais
        '
        Me.LstFiliais.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LstFiliais.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LstFiliais.ForeColor = System.Drawing.Color.Peru
        Me.LstFiliais.FormattingEnabled = True
        Me.LstFiliais.ItemHeight = 17
        Me.LstFiliais.Location = New System.Drawing.Point(381, 403)
        Me.LstFiliais.Margin = New System.Windows.Forms.Padding(2)
        Me.LstFiliais.Name = "LstFiliais"
        Me.LstFiliais.Size = New System.Drawing.Size(453, 187)
        Me.LstFiliais.TabIndex = 144
        '
        'LblSuframa
        '
        Me.LblSuframa.AutoSize = True
        Me.LblSuframa.ForeColor = System.Drawing.Color.Peru
        Me.LblSuframa.Location = New System.Drawing.Point(474, 346)
        Me.LblSuframa.Name = "LblSuframa"
        Me.LblSuframa.Size = New System.Drawing.Size(34, 17)
        Me.LblSuframa.TabIndex = 146
        Me.LblSuframa.Text = "CNPJ"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(378, 346)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 17)
        Me.Label19.TabIndex = 145
        Me.Label19.Text = "SUFRAMA"
        '
        'LblAliquotas
        '
        Me.LblAliquotas.BackColor = System.Drawing.Color.Gainsboro
        Me.LblAliquotas.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblAliquotas.ForeColor = System.Drawing.Color.SlateGray
        Me.LblAliquotas.Location = New System.Drawing.Point(7, 15)
        Me.LblAliquotas.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblAliquotas.Name = "LblAliquotas"
        Me.LblAliquotas.Size = New System.Drawing.Size(827, 17)
        Me.LblAliquotas.TabIndex = 147
        Me.LblAliquotas.Text = "Configurações de relacionadas a saída dos produtos"
        Me.LblAliquotas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 17)
        Me.Label18.TabIndex = 148
        Me.Label18.Text = "Aliq. ICMS %"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(344, 84)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 17)
        Me.Label21.TabIndex = 149
        Me.Label21.Text = "Aliq. IPI %"
        '
        'TxtIPI
        '
        Me.TxtIPI.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtIPI.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIPI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtIPI.Enabled = False
        Me.TxtIPI.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.TxtIPI.Location = New System.Drawing.Point(424, 84)
        Me.TxtIPI.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtIPI.Name = "TxtIPI"
        Me.TxtIPI.Size = New System.Drawing.Size(143, 17)
        Me.TxtIPI.TabIndex = 152
        Me.TxtIPI.Text = "0"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(1, 30)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(850, 638)
        Me.TabControl1.TabIndex = 153
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.LblCnpj)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.LblRazao)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.LblSuframa)
        Me.TabPage1.Controls.Add(Me.LblEndereco)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.LstFiliais)
        Me.TabPage1.Controls.Add(Me.LblIE)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.LblRegime)
        Me.TabPage1.Controls.Add(Me.LstSocios)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.LblCapitalSocial)
        Me.TabPage1.Controls.Add(Me.LblSimples)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.LstSecundárias)
        Me.TabPage1.Controls.Add(Me.LblNomeFantasia)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.LblCNAE)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.LblMunicipio)
        Me.TabPage1.Controls.Add(Me.LblUf)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(842, 605)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dados SEFAZ"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TxtICMS)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.CkPadrao)
        Me.TabPage2.Controls.Add(Me.BttAddCFOP)
        Me.TabPage2.Controls.Add(Me.CmbCFOP)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.CmbTipoOperacao)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.DtCotFinal)
        Me.TabPage2.Controls.Add(Me.LblAliquotas)
        Me.TabPage2.Controls.Add(Me.TxtIPI)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(842, 605)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tributação"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TxtICMS
        '
        Me.TxtICMS.AutoSize = True
        Me.TxtICMS.Location = New System.Drawing.Point(134, 84)
        Me.TxtICMS.Name = "TxtICMS"
        Me.TxtICMS.Size = New System.Drawing.Size(15, 17)
        Me.TxtICMS.TabIndex = 163
        Me.TxtICMS.Text = "0"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Gainsboro
        Me.Label23.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label23.ForeColor = System.Drawing.Color.SlateGray
        Me.Label23.Location = New System.Drawing.Point(7, 367)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(827, 17)
        Me.Label23.TabIndex = 162
        Me.Label23.Text = "Configurações dos tributos relacionados a serviços  prestados"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CkPadrao
        '
        Me.CkPadrao.AutoSize = True
        Me.CkPadrao.Enabled = False
        Me.CkPadrao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CkPadrao.Location = New System.Drawing.Point(621, 84)
        Me.CkPadrao.Margin = New System.Windows.Forms.Padding(2)
        Me.CkPadrao.Name = "CkPadrao"
        Me.CkPadrao.Size = New System.Drawing.Size(145, 21)
        Me.CkPadrao.TabIndex = 161
        Me.CkPadrao.Text = "Marcar como padrão"
        Me.CkPadrao.UseVisualStyleBackColor = True
        '
        'BttAddCFOP
        '
        Me.BttAddCFOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddCFOP.Enabled = False
        Me.BttAddCFOP.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.BttAddCFOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddCFOP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttAddCFOP.ImageIndex = 0
        Me.BttAddCFOP.ImageList = Me.ImageList1
        Me.BttAddCFOP.Location = New System.Drawing.Point(621, 124)
        Me.BttAddCFOP.Margin = New System.Windows.Forms.Padding(4)
        Me.BttAddCFOP.Name = "BttAddCFOP"
        Me.BttAddCFOP.Size = New System.Drawing.Size(215, 30)
        Me.BttAddCFOP.TabIndex = 160
        Me.BttAddCFOP.Text = "Cadastrar tributação"
        Me.BttAddCFOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttAddCFOP.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "add-1-icon.png")
        Me.ImageList1.Images.SetKeyName(1, "Delete-80_icon-icons.com_57340.png")
        '
        'CmbCFOP
        '
        Me.CmbCFOP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCFOP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCFOP.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbCFOP.Enabled = False
        Me.CmbCFOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCFOP.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbCFOP.FormattingEnabled = True
        Me.CmbCFOP.Items.AddRange(New Object() {"Vendas"})
        Me.CmbCFOP.Location = New System.Drawing.Point(424, 46)
        Me.CmbCFOP.Margin = New System.Windows.Forms.Padding(2)
        Me.CmbCFOP.Name = "CmbCFOP"
        Me.CmbCFOP.Size = New System.Drawing.Size(410, 25)
        Me.CmbCFOP.TabIndex = 159
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(344, 52)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 17)
        Me.Label24.TabIndex = 158
        Me.Label24.Text = "CFOP"
        '
        'CmbTipoOperacao
        '
        Me.CmbTipoOperacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbTipoOperacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbTipoOperacao.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbTipoOperacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbTipoOperacao.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbTipoOperacao.FormattingEnabled = True
        Me.CmbTipoOperacao.Items.AddRange(New Object() {"Vendas"})
        Me.CmbTipoOperacao.Location = New System.Drawing.Point(137, 46)
        Me.CmbTipoOperacao.Margin = New System.Windows.Forms.Padding(2)
        Me.CmbTipoOperacao.Name = "CmbTipoOperacao"
        Me.CmbTipoOperacao.Size = New System.Drawing.Size(185, 25)
        Me.CmbTipoOperacao.TabIndex = 155
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(11, 49)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(105, 17)
        Me.Label22.TabIndex = 154
        Me.Label22.Text = "Tipo da operação"
        '
        'DtCotFinal
        '
        Me.DtCotFinal.AllowUserToAddRows = False
        Me.DtCotFinal.AllowUserToDeleteRows = False
        Me.DtCotFinal.AllowUserToResizeColumns = False
        Me.DtCotFinal.AllowUserToResizeRows = False
        Me.DtCotFinal.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtCotFinal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtCotFinal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtCotFinal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtCotFinal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtCotFinal.ColumnHeadersHeight = 24
        Me.DtCotFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DtCotFinal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.ClmDeletar, Me.Column6})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtCotFinal.DefaultCellStyle = DataGridViewCellStyle7
        Me.DtCotFinal.EnableHeadersVisualStyles = False
        Me.DtCotFinal.GridColor = System.Drawing.Color.Gainsboro
        Me.DtCotFinal.Location = New System.Drawing.Point(10, 172)
        Me.DtCotFinal.Margin = New System.Windows.Forms.Padding(2)
        Me.DtCotFinal.MultiSelect = False
        Me.DtCotFinal.Name = "DtCotFinal"
        Me.DtCotFinal.ReadOnly = True
        Me.DtCotFinal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DtCotFinal.RowHeadersVisible = False
        Me.DtCotFinal.RowHeadersWidth = 100
        Me.DtCotFinal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtCotFinal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtCotFinal.ShowCellErrors = False
        Me.DtCotFinal.ShowCellToolTips = False
        Me.DtCotFinal.ShowEditingIcon = False
        Me.DtCotFinal.ShowRowErrors = False
        Me.DtCotFinal.Size = New System.Drawing.Size(824, 193)
        Me.DtCotFinal.TabIndex = 153
        '
        'Column5
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column5.HeaderText = "Padrão"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 50
        '
        'Column1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "Tipo da operação"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 135
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = "CFOP"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column3.HeaderText = "Aliq. ICMS"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column4
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column4.HeaderText = "Aliq. IPI"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'ClmDeletar
        '
        Me.ClmDeletar.HeaderText = ""
        Me.ClmDeletar.MinimumWidth = 6
        Me.ClmDeletar.Name = "ClmDeletar"
        Me.ClmDeletar.ReadOnly = True
        Me.ClmDeletar.Width = 30
        '
        'Column6
        '
        Me.Column6.HeaderText = "Id"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        Me.Column6.Width = 125
        '
        'Fisco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(852, 700)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Fisco"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fisco"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DtCotFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblIE As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LblEndereco As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblRazao As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LblCnpj As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblRegime As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblSimples As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblNomeFantasia As Label
    Friend WithEvents LblCNAE As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblMunicipio As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblUf As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents LstSecundárias As ListBox
    Friend WithEvents Label16 As Label
    Friend WithEvents LblCapitalSocial As Label
    Friend WithEvents LstSocios As ListBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents LstFiliais As ListBox
    Friend WithEvents LblSuframa As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents LblAliquotas As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TxtIPI As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label22 As Label
    Friend WithEvents DtCotFinal As DataGridView
    Friend WithEvents CmbCFOP As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents CmbTipoOperacao As ComboBox
    Friend WithEvents CkPadrao As CheckBox
    Friend WithEvents BttAddCFOP As Button
    Friend WithEvents Label23 As Label
    Friend WithEvents TxtICMS As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents ClmDeletar As DataGridViewImageColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
End Class
