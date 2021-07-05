<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovaFerramenta
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnnDadosServiço = New System.Windows.Forms.Panel()
        Me.TxtDescrição = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.CkNdefinido = New System.Windows.Forms.CheckBox()
        Me.BttVincula = New System.Windows.Forms.Button()
        Me.DtProdutos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmExcluir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.CmbCargos = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TxtDescriçãoInsumos = New System.Windows.Forms.TextBox()
        Me.RdbEPI = New System.Windows.Forms.RadioButton()
        Me.RdbInsumos = New System.Windows.Forms.RadioButton()
        Me.BttVinculaInsumo = New System.Windows.Forms.Button()
        Me.DtInsumos = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmExcluir1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PnnDadosServiço.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.DtProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.DtInsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 656)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(615, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 656)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(1, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(614, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 655)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(614, 1)
        Me.Panel4.TabIndex = 3
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(614, 28)
        Me.LblTitulo.TabIndex = 39
        Me.LblTitulo.Text = "Ferramentas"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnDadosServiço
        '
        Me.PnnDadosServiço.Controls.Add(Me.TxtDescrição)
        Me.PnnDadosServiço.Controls.Add(Me.Label1)
        Me.PnnDadosServiço.Location = New System.Drawing.Point(15, 63)
        Me.PnnDadosServiço.Name = "PnnDadosServiço"
        Me.PnnDadosServiço.Size = New System.Drawing.Size(589, 40)
        Me.PnnDadosServiço.TabIndex = 120
        '
        'TxtDescrição
        '
        Me.TxtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescrição.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescrição.Location = New System.Drawing.Point(145, 12)
        Me.TxtDescrição.Name = "TxtDescrição"
        Me.TxtDescrição.Size = New System.Drawing.Size(428, 17)
        Me.TxtDescrição.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descrição"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(12, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(592, 21)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "Dados da feramenta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(12, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(592, 21)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "Profissionais aptos ao manuseio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.CkNdefinido)
        Me.Panel6.Controls.Add(Me.BttVincula)
        Me.Panel6.Controls.Add(Me.DtProdutos)
        Me.Panel6.Controls.Add(Me.CmbCargos)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Location = New System.Drawing.Point(15, 130)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(589, 206)
        Me.Panel6.TabIndex = 122
        '
        'CkNdefinido
        '
        Me.CkNdefinido.AutoSize = True
        Me.CkNdefinido.Enabled = False
        Me.CkNdefinido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CkNdefinido.Location = New System.Drawing.Point(15, 14)
        Me.CkNdefinido.Name = "CkNdefinido"
        Me.CkNdefinido.Size = New System.Drawing.Size(83, 17)
        Me.CkNdefinido.TabIndex = 120
        Me.CkNdefinido.Text = "Não definido"
        Me.CkNdefinido.UseVisualStyleBackColor = True
        '
        'BttVincula
        '
        Me.BttVincula.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttVincula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttVincula.Enabled = False
        Me.BttVincula.FlatAppearance.BorderSize = 0
        Me.BttVincula.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttVincula.Location = New System.Drawing.Point(565, 43)
        Me.BttVincula.Name = "BttVincula"
        Me.BttVincula.Size = New System.Drawing.Size(20, 20)
        Me.BttVincula.TabIndex = 119
        Me.BttVincula.UseVisualStyleBackColor = True
        '
        'DtProdutos
        '
        Me.DtProdutos.AllowUserToAddRows = False
        Me.DtProdutos.AllowUserToDeleteRows = False
        Me.DtProdutos.AllowUserToResizeColumns = False
        Me.DtProdutos.AllowUserToResizeRows = False
        Me.DtProdutos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.ClmExcluir})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtProdutos.DefaultCellStyle = DataGridViewCellStyle2
        Me.DtProdutos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DtProdutos.EnableHeadersVisualStyles = False
        Me.DtProdutos.GridColor = System.Drawing.Color.Gainsboro
        Me.DtProdutos.Location = New System.Drawing.Point(0, 69)
        Me.DtProdutos.MultiSelect = False
        Me.DtProdutos.Name = "DtProdutos"
        Me.DtProdutos.ReadOnly = True
        Me.DtProdutos.RowHeadersVisible = False
        Me.DtProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtProdutos.Size = New System.Drawing.Size(589, 137)
        Me.DtProdutos.TabIndex = 114
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cod."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Profissional"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'ClmExcluir
        '
        Me.ClmExcluir.HeaderText = ""
        Me.ClmExcluir.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.ClmExcluir.Name = "ClmExcluir"
        Me.ClmExcluir.ReadOnly = True
        Me.ClmExcluir.Width = 20
        '
        'CmbCargos
        '
        Me.CmbCargos.Enabled = False
        Me.CmbCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCargos.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CmbCargos.FormattingEnabled = True
        Me.CmbCargos.Location = New System.Drawing.Point(145, 40)
        Me.CmbCargos.Name = "CmbCargos"
        Me.CmbCargos.Size = New System.Drawing.Size(407, 23)
        Me.CmbCargos.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Profissionais necessarios"
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
        Me.PnnInferior.Location = New System.Drawing.Point(1, 617)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(614, 38)
        Me.PnnInferior.TabIndex = 123
        '
        'LblIdVistoria
        '
        Me.LblIdVistoria.AutoSize = True
        Me.LblIdVistoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdVistoria.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdVistoria.Location = New System.Drawing.Point(26, 5)
        Me.LblIdVistoria.Name = "LblIdVistoria"
        Me.LblIdVistoria.Size = New System.Drawing.Size(13, 13)
        Me.LblIdVistoria.TabIndex = 48
        Me.LblIdVistoria.Text = "0"
        Me.LblIdVistoria.Visible = False
        '
        'LblIdSolução
        '
        Me.LblIdSolução.AutoSize = True
        Me.LblIdSolução.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdSolução.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdSolução.Location = New System.Drawing.Point(13, 5)
        Me.LblIdSolução.Name = "LblIdSolução"
        Me.LblIdSolução.Size = New System.Drawing.Size(13, 13)
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
        Me.LblIdmarca.Size = New System.Drawing.Size(13, 13)
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
        Me.Panel5.Size = New System.Drawing.Size(533, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(533, 0)
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
        Me.BttFechar.Location = New System.Drawing.Point(45, 8)
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
        Me.BttSalvar.Location = New System.Drawing.Point(12, 8)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.TxtDescriçãoInsumos)
        Me.Panel7.Controls.Add(Me.RdbEPI)
        Me.Panel7.Controls.Add(Me.RdbInsumos)
        Me.Panel7.Controls.Add(Me.BttVinculaInsumo)
        Me.Panel7.Controls.Add(Me.DtInsumos)
        Me.Panel7.Controls.Add(Me.Label2)
        Me.Panel7.Location = New System.Drawing.Point(15, 363)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(589, 206)
        Me.Panel7.TabIndex = 125
        '
        'TxtDescriçãoInsumos
        '
        Me.TxtDescriçãoInsumos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescriçãoInsumos.Enabled = False
        Me.TxtDescriçãoInsumos.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescriçãoInsumos.Location = New System.Drawing.Point(145, 42)
        Me.TxtDescriçãoInsumos.Name = "TxtDescriçãoInsumos"
        Me.TxtDescriçãoInsumos.Size = New System.Drawing.Size(407, 17)
        Me.TxtDescriçãoInsumos.TabIndex = 124
        '
        'RdbEPI
        '
        Me.RdbEPI.AutoSize = True
        Me.RdbEPI.Enabled = False
        Me.RdbEPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RdbEPI.Location = New System.Drawing.Point(86, 13)
        Me.RdbEPI.Name = "RdbEPI"
        Me.RdbEPI.Size = New System.Drawing.Size(48, 17)
        Me.RdbEPI.TabIndex = 121
        Me.RdbEPI.Text = "E.P.I. "
        Me.RdbEPI.UseVisualStyleBackColor = True
        '
        'RdbInsumos
        '
        Me.RdbInsumos.AutoSize = True
        Me.RdbInsumos.Enabled = False
        Me.RdbInsumos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RdbInsumos.Location = New System.Drawing.Point(15, 13)
        Me.RdbInsumos.Name = "RdbInsumos"
        Me.RdbInsumos.Size = New System.Drawing.Size(64, 17)
        Me.RdbInsumos.TabIndex = 120
        Me.RdbInsumos.Text = "Insumos"
        Me.RdbInsumos.UseVisualStyleBackColor = True
        '
        'BttVinculaInsumo
        '
        Me.BttVinculaInsumo.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttVinculaInsumo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttVinculaInsumo.Enabled = False
        Me.BttVinculaInsumo.FlatAppearance.BorderSize = 0
        Me.BttVinculaInsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttVinculaInsumo.Location = New System.Drawing.Point(565, 40)
        Me.BttVinculaInsumo.Name = "BttVinculaInsumo"
        Me.BttVinculaInsumo.Size = New System.Drawing.Size(20, 20)
        Me.BttVinculaInsumo.TabIndex = 119
        Me.BttVinculaInsumo.UseVisualStyleBackColor = True
        '
        'DtInsumos
        '
        Me.DtInsumos.AllowUserToAddRows = False
        Me.DtInsumos.AllowUserToDeleteRows = False
        Me.DtInsumos.AllowUserToResizeColumns = False
        Me.DtInsumos.AllowUserToResizeRows = False
        Me.DtInsumos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtInsumos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtInsumos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtInsumos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtInsumos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DtInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtInsumos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.DataGridViewTextBoxColumn2, Me.ClmExcluir1})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtInsumos.DefaultCellStyle = DataGridViewCellStyle4
        Me.DtInsumos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DtInsumos.EnableHeadersVisualStyles = False
        Me.DtInsumos.GridColor = System.Drawing.Color.Gainsboro
        Me.DtInsumos.Location = New System.Drawing.Point(0, 69)
        Me.DtInsumos.MultiSelect = False
        Me.DtInsumos.Name = "DtInsumos"
        Me.DtInsumos.ReadOnly = True
        Me.DtInsumos.RowHeadersVisible = False
        Me.DtInsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtInsumos.Size = New System.Drawing.Size(589, 137)
        Me.DtInsumos.TabIndex = 114
        '
        'Column3
        '
        Me.Column3.HeaderText = "Tipo"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descrição"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'ClmExcluir1
        '
        Me.ClmExcluir1.HeaderText = ""
        Me.ClmExcluir1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.ClmExcluir1.Name = "ClmExcluir1"
        Me.ClmExcluir1.ReadOnly = True
        Me.ClmExcluir1.Width = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Descrição"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(12, 339)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(592, 21)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "Insumos e EPIs "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmNovaFerramenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 656)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PnnDadosServiço)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovaFerramenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovaFerramenta"
        Me.PnnDadosServiço.ResumeLayout(False)
        Me.PnnDadosServiço.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.DtProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.DtInsumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents PnnDadosServiço As Panel
    Friend WithEvents TxtDescrição As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents BttVincula As Button
    Friend WithEvents DtProdutos As DataGridView
    Friend WithEvents CmbCargos As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents CkNdefinido As CheckBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents BttVinculaInsumo As Button
    Friend WithEvents DtInsumos As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents RdbEPI As RadioButton
    Friend WithEvents RdbInsumos As RadioButton
    Friend WithEvents TxtDescriçãoInsumos As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents ClmExcluir As DataGridViewImageColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents ClmExcluir1 As DataGridViewImageColumn
End Class
