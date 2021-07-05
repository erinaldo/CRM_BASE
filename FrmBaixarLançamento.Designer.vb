<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBaixarLançamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBaixarLançamento))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtAcrescimo = New System.Windows.Forms.TextBox()
        Me.TxtDesconto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblValorOriginal = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblFormaPG = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblDescricao = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DtFormas = New System.Windows.Forms.DataGridView()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmExcluir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BttInsere = New System.Windows.Forms.Button()
        Me.TxtValor = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.NmParcelas = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CmbFormasPgEntrada = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblVencimento = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DtFormas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmParcelas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(701, 22)
        Me.LblTitulo.TabIndex = 94
        Me.LblTitulo.Text = "Baixar lançamento"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.PnnInferior.Location = New System.Drawing.Point(1, 607)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(701, 32)
        Me.PnnInferior.TabIndex = 95
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
        Me.Panel5.Size = New System.Drawing.Size(661, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(661, 0)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(40, 32)
        Me.Panel12.TabIndex = 50
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(12, 8)
        Me.BttFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(14, 17)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(702, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 639)
        Me.Panel1.TabIndex = 96
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 639)
        Me.Panel2.TabIndex = 97
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.SlateGray
        Me.Label1.Location = New System.Drawing.Point(13, 178)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 17)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Identificador do comprovante"
        Me.Label1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TextBox1.Location = New System.Drawing.Point(16, 198)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(477, 21)
        Me.TextBox1.TabIndex = 99
        Me.TextBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.SlateGray
        Me.Label2.Location = New System.Drawing.Point(16, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 17)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Acréscimos"
        '
        'TxtAcrescimo
        '
        Me.TxtAcrescimo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAcrescimo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtAcrescimo.Location = New System.Drawing.Point(19, 198)
        Me.TxtAcrescimo.Name = "TxtAcrescimo"
        Me.TxtAcrescimo.Size = New System.Drawing.Size(172, 21)
        Me.TxtAcrescimo.TabIndex = 101
        Me.TxtAcrescimo.Text = "R$ 0,00"
        '
        'TxtDesconto
        '
        Me.TxtDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDesconto.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDesconto.Location = New System.Drawing.Point(220, 198)
        Me.TxtDesconto.Name = "TxtDesconto"
        Me.TxtDesconto.Size = New System.Drawing.Size(172, 21)
        Me.TxtDesconto.TabIndex = 103
        Me.TxtDesconto.Text = "R$ 0,00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.SlateGray
        Me.Label3.Location = New System.Drawing.Point(217, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 17)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Descontos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.SlateGray
        Me.Label4.Location = New System.Drawing.Point(13, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Valor original"
        '
        'LblValorOriginal
        '
        Me.LblValorOriginal.AutoSize = True
        Me.LblValorOriginal.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblValorOriginal.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblValorOriginal.Location = New System.Drawing.Point(11, 135)
        Me.LblValorOriginal.Name = "LblValorOriginal"
        Me.LblValorOriginal.Size = New System.Drawing.Size(85, 29)
        Me.LblValorOriginal.TabIndex = 105
        Me.LblValorOriginal.Text = "R$ 0,00"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Cifrao.png")
        Me.ImageList1.Images.SetKeyName(1, "pngwing.com (9).png")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.SlateGray
        Me.Label5.Location = New System.Drawing.Point(214, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 17)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "Forma de pagamento"
        Me.Label5.Visible = False
        '
        'LblFormaPG
        '
        Me.LblFormaPG.AutoSize = True
        Me.LblFormaPG.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblFormaPG.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblFormaPG.Location = New System.Drawing.Point(212, 135)
        Me.LblFormaPG.Name = "LblFormaPG"
        Me.LblFormaPG.Size = New System.Drawing.Size(85, 29)
        Me.LblFormaPG.TabIndex = 108
        Me.LblFormaPG.Text = "R$ 0,00"
        Me.LblFormaPG.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.SlateGray
        Me.Label6.Location = New System.Drawing.Point(16, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 17)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Descrição"
        '
        'LblDescricao
        '
        Me.LblDescricao.AutoSize = True
        Me.LblDescricao.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblDescricao.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblDescricao.Location = New System.Drawing.Point(14, 66)
        Me.LblDescricao.Name = "LblDescricao"
        Me.LblDescricao.Size = New System.Drawing.Size(64, 29)
        Me.LblDescricao.TabIndex = 110
        Me.LblDescricao.Text = "Teste"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DtFormas)
        Me.GroupBox4.Controls.Add(Me.BttInsere)
        Me.GroupBox4.Controls.Add(Me.TxtValor)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.NmParcelas)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.CmbFormasPgEntrada)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.ForeColor = System.Drawing.Color.SlateGray
        Me.GroupBox4.Location = New System.Drawing.Point(19, 244)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(670, 280)
        Me.GroupBox4.TabIndex = 111
        Me.GroupBox4.TabStop = False
        '
        'DtFormas
        '
        Me.DtFormas.AllowUserToAddRows = False
        Me.DtFormas.AllowUserToDeleteRows = False
        Me.DtFormas.AllowUserToResizeColumns = False
        Me.DtFormas.AllowUserToResizeRows = False
        Me.DtFormas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtFormas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtFormas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtFormas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtFormas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtFormas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtFormas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column14, Me.Column7, Me.Column8, Me.Column9, Me.Column11, Me.Column1, Me.ClmExcluir})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtFormas.DefaultCellStyle = DataGridViewCellStyle3
        Me.DtFormas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DtFormas.EnableHeadersVisualStyles = False
        Me.DtFormas.GridColor = System.Drawing.Color.Gainsboro
        Me.DtFormas.Location = New System.Drawing.Point(3, 112)
        Me.DtFormas.MultiSelect = False
        Me.DtFormas.Name = "DtFormas"
        Me.DtFormas.RowHeadersVisible = False
        Me.DtFormas.RowHeadersWidth = 51
        Me.DtFormas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtFormas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtFormas.Size = New System.Drawing.Size(664, 165)
        Me.DtFormas.TabIndex = 114
        '
        'Column14
        '
        Me.Column14.HeaderText = "Cod Forma"
        Me.Column14.MinimumWidth = 6
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Visible = False
        Me.Column14.Width = 125
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column7.HeaderText = "Forma de pg"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Pc"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 125
        '
        'Column9
        '
        Me.Column9.HeaderText = "Valor"
        Me.Column9.MinimumWidth = 6
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 125
        '
        'Column11
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column11.HeaderText = "Vencimento"
        Me.Column11.MinimumWidth = 6
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 125
        '
        'Column1
        '
        Me.Column1.HeaderText = "Identificador"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 125
        '
        'ClmExcluir
        '
        Me.ClmExcluir.HeaderText = ""
        Me.ClmExcluir.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.ClmExcluir.MinimumWidth = 6
        Me.ClmExcluir.Name = "ClmExcluir"
        Me.ClmExcluir.ReadOnly = True
        Me.ClmExcluir.Width = 13
        '
        'BttInsere
        '
        Me.BttInsere.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttInsere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttInsere.Enabled = False
        Me.BttInsere.FlatAppearance.BorderSize = 0
        Me.BttInsere.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttInsere.Location = New System.Drawing.Point(458, 67)
        Me.BttInsere.Name = "BttInsere"
        Me.BttInsere.Size = New System.Drawing.Size(20, 16)
        Me.BttInsere.TabIndex = 108
        Me.BttInsere.UseVisualStyleBackColor = True
        '
        'TxtValor
        '
        Me.TxtValor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtValor.Enabled = False
        Me.TxtValor.Location = New System.Drawing.Point(352, 70)
        Me.TxtValor.Name = "TxtValor"
        Me.TxtValor.Size = New System.Drawing.Size(100, 16)
        Me.TxtValor.TabIndex = 107
        Me.TxtValor.Text = "R$ 0,00"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(290, 70)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 17)
        Me.Label18.TabIndex = 106
        Me.Label18.Text = "Valor"
        '
        'NmParcelas
        '
        Me.NmParcelas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NmParcelas.Enabled = False
        Me.NmParcelas.Location = New System.Drawing.Point(198, 67)
        Me.NmParcelas.Name = "NmParcelas"
        Me.NmParcelas.Size = New System.Drawing.Size(86, 19)
        Me.NmParcelas.TabIndex = 105
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 70)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 17)
        Me.Label17.TabIndex = 104
        Me.Label17.Text = "Parcelas"
        '
        'CmbFormasPgEntrada
        '
        Me.CmbFormasPgEntrada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbFormasPgEntrada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbFormasPgEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbFormasPgEntrada.FormattingEnabled = True
        Me.CmbFormasPgEntrada.Location = New System.Drawing.Point(198, 34)
        Me.CmbFormasPgEntrada.Name = "CmbFormasPgEntrada"
        Me.CmbFormasPgEntrada.Size = New System.Drawing.Size(280, 23)
        Me.CmbFormasPgEntrada.TabIndex = 103
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(129, 17)
        Me.Label16.TabIndex = 102
        Me.Label16.Text = "Forma de pagamento"
        '
        'LblVencimento
        '
        Me.LblVencimento.AutoSize = True
        Me.LblVencimento.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblVencimento.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblVencimento.Location = New System.Drawing.Point(472, 135)
        Me.LblVencimento.Name = "LblVencimento"
        Me.LblVencimento.Size = New System.Drawing.Size(85, 29)
        Me.LblVencimento.TabIndex = 113
        Me.LblVencimento.Text = "R$ 0,00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.SlateGray
        Me.Label8.Location = New System.Drawing.Point(474, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 17)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Data do vencimento"
        '
        'Button3
        '
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.Button3.ForeColor = System.Drawing.Color.SlateGray
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.ImageKey = "Cifrao.png"
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(414, 528)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(276, 56)
        Me.Button3.TabIndex = 106
        Me.Button3.Text = "Baixar lançamento"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmBaixarLançamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 639)
        Me.Controls.Add(Me.LblVencimento)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LblDescricao)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblFormaPG)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.LblValorOriginal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtDesconto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtAcrescimo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmBaixarLançamento"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBaixarLançamento"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DtFormas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmParcelas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtAcrescimo As TextBox
    Friend WithEvents TxtDesconto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblValorOriginal As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label5 As Label
    Friend WithEvents LblFormaPG As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblDescricao As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents DtFormas As DataGridView
    Friend WithEvents BttInsere As Button
    Friend WithEvents TxtValor As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents NmParcelas As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents CmbFormasPgEntrada As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents ClmExcluir As DataGridViewImageColumn
    Friend WithEvents LblVencimento As Label
    Friend WithEvents Label8 As Label
End Class
