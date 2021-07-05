<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagamento
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagamento))
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnNovaFormaPg = New System.Windows.Forms.Button()
        Me.BtnConcluirRecebimento = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LblValorRestante = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblTroco = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblRecebidos = New System.Windows.Forms.Label()
        Me.DtFormas = New System.Windows.Forms.DataGridView()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmReceber = New System.Windows.Forms.DataGridViewImageColumn()
        Me.clmcomum = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmExcluir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BttInsere = New System.Windows.Forms.Button()
        Me.TxtValor = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.NmParcelas = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CmbFormasPgEntrada = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtCotFinal = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DtFormas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmParcelas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtCotFinal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LblTitulo.Size = New System.Drawing.Size(1164, 30)
        Me.LblTitulo.TabIndex = 39
        Me.LblTitulo.Text = "Pagamentos"
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
        Me.PnnInferior.Location = New System.Drawing.Point(1, 663)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1164, 40)
        Me.PnnInferior.TabIndex = 40
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
        Me.Panel5.Size = New System.Drawing.Size(1117, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1117, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(47, 40)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(14, 11)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(18, 21)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 703)
        Me.Panel1.TabIndex = 41
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1165, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 703)
        Me.Panel2.TabIndex = 42
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnNovaFormaPg)
        Me.GroupBox4.Controls.Add(Me.BtnConcluirRecebimento)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.DtFormas)
        Me.GroupBox4.Controls.Add(Me.BttInsere)
        Me.GroupBox4.Controls.Add(Me.TxtValor)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.NmParcelas)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.CmbFormasPgEntrada)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 275)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1130, 373)
        Me.GroupBox4.TabIndex = 125
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Formas de pagamento"
        '
        'BtnNovaFormaPg
        '
        Me.BtnNovaFormaPg.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BtnNovaFormaPg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnNovaFormaPg.FlatAppearance.BorderSize = 0
        Me.BtnNovaFormaPg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNovaFormaPg.Location = New System.Drawing.Point(764, 36)
        Me.BtnNovaFormaPg.Name = "BtnNovaFormaPg"
        Me.BtnNovaFormaPg.Size = New System.Drawing.Size(18, 16)
        Me.BtnNovaFormaPg.TabIndex = 119
        Me.BtnNovaFormaPg.UseVisualStyleBackColor = True
        '
        'BtnConcluirRecebimento
        '
        Me.BtnConcluirRecebimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnConcluirRecebimento.Enabled = False
        Me.BtnConcluirRecebimento.FlatAppearance.BorderSize = 0
        Me.BtnConcluirRecebimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConcluirRecebimento.Image = Global.CRM_BASE.My.Resources.Resources.dollars_98561
        Me.BtnConcluirRecebimento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConcluirRecebimento.Location = New System.Drawing.Point(906, 301)
        Me.BtnConcluirRecebimento.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnConcluirRecebimento.Name = "BtnConcluirRecebimento"
        Me.BtnConcluirRecebimento.Size = New System.Drawing.Size(228, 66)
        Me.BtnConcluirRecebimento.TabIndex = 118
        Me.BtnConcluirRecebimento.Text = "Concluir pagamento (F12)"
        Me.BtnConcluirRecebimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnConcluirRecebimento.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LblValorRestante)
        Me.GroupBox3.Location = New System.Drawing.Point(368, 300)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(175, 67)
        Me.GroupBox3.TabIndex = 117
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Restante"
        '
        'LblValorRestante
        '
        Me.LblValorRestante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblValorRestante.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblValorRestante.ForeColor = System.Drawing.Color.SlateGray
        Me.LblValorRestante.Location = New System.Drawing.Point(3, 20)
        Me.LblValorRestante.Name = "LblValorRestante"
        Me.LblValorRestante.Size = New System.Drawing.Size(169, 44)
        Me.LblValorRestante.TabIndex = 105
        Me.LblValorRestante.Text = "R$ 0.00"
        Me.LblValorRestante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblTroco)
        Me.GroupBox2.Location = New System.Drawing.Point(188, 300)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(175, 67)
        Me.GroupBox2.TabIndex = 116
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Troco"
        '
        'LblTroco
        '
        Me.LblTroco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTroco.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblTroco.ForeColor = System.Drawing.Color.SlateGray
        Me.LblTroco.Location = New System.Drawing.Point(3, 20)
        Me.LblTroco.Name = "LblTroco"
        Me.LblTroco.Size = New System.Drawing.Size(169, 44)
        Me.LblTroco.TabIndex = 105
        Me.LblTroco.Text = "R$ 0.00"
        Me.LblTroco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblRecebidos)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 300)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 67)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Valores recebidos"
        '
        'LblRecebidos
        '
        Me.LblRecebidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblRecebidos.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblRecebidos.ForeColor = System.Drawing.Color.SlateGray
        Me.LblRecebidos.Location = New System.Drawing.Point(3, 20)
        Me.LblRecebidos.Name = "LblRecebidos"
        Me.LblRecebidos.Size = New System.Drawing.Size(169, 44)
        Me.LblRecebidos.TabIndex = 105
        Me.LblRecebidos.Text = "R$ 0.00"
        Me.LblRecebidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtFormas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtFormas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtFormas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column14, Me.DataGridViewTextBoxColumn1, Me.Column8, Me.Column9, Me.Column11, Me.Column6, Me.Column12, Me.Column17, Me.ClmReceber, Me.clmcomum, Me.Column13, Me.ClmExcluir})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtFormas.DefaultCellStyle = DataGridViewCellStyle3
        Me.DtFormas.EnableHeadersVisualStyles = False
        Me.DtFormas.GridColor = System.Drawing.Color.Gainsboro
        Me.DtFormas.Location = New System.Drawing.Point(5, 64)
        Me.DtFormas.MultiSelect = False
        Me.DtFormas.Name = "DtFormas"
        Me.DtFormas.RowHeadersVisible = False
        Me.DtFormas.RowHeadersWidth = 51
        Me.DtFormas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtFormas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtFormas.Size = New System.Drawing.Size(1125, 230)
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Forma de pg"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
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
        'Column6
        '
        Me.Column6.HeaderText = "Valor Recebido"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 125
        '
        'Column12
        '
        Me.Column12.HeaderText = "Troco"
        Me.Column12.MinimumWidth = 6
        Me.Column12.Name = "Column12"
        Me.Column12.Width = 125
        '
        'Column17
        '
        Me.Column17.HeaderText = ""
        Me.Column17.MinimumWidth = 6
        Me.Column17.Name = "Column17"
        Me.Column17.Visible = False
        Me.Column17.Width = 30
        '
        'ClmReceber
        '
        Me.ClmReceber.HeaderText = ""
        Me.ClmReceber.MinimumWidth = 6
        Me.ClmReceber.Name = "ClmReceber"
        Me.ClmReceber.Width = 40
        '
        'clmcomum
        '
        Me.clmcomum.HeaderText = ""
        Me.clmcomum.MinimumWidth = 6
        Me.clmcomum.Name = "clmcomum"
        Me.clmcomum.Visible = False
        Me.clmcomum.Width = 12
        '
        'Column13
        '
        Me.Column13.HeaderText = "Comporvante"
        Me.Column13.MinimumWidth = 6
        Me.Column13.Name = "Column13"
        Me.Column13.Visible = False
        Me.Column13.Width = 200
        '
        'ClmExcluir
        '
        Me.ClmExcluir.HeaderText = ""
        Me.ClmExcluir.MinimumWidth = 6
        Me.ClmExcluir.Name = "ClmExcluir"
        Me.ClmExcluir.Width = 40
        '
        'BttInsere
        '
        Me.BttInsere.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttInsere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttInsere.Enabled = False
        Me.BttInsere.FlatAppearance.BorderSize = 0
        Me.BttInsere.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttInsere.Location = New System.Drawing.Point(741, 36)
        Me.BttInsere.Name = "BttInsere"
        Me.BttInsere.Size = New System.Drawing.Size(18, 16)
        Me.BttInsere.TabIndex = 108
        Me.BttInsere.UseVisualStyleBackColor = True
        '
        'TxtValor
        '
        Me.TxtValor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtValor.Enabled = False
        Me.TxtValor.Location = New System.Drawing.Point(634, 37)
        Me.TxtValor.Name = "TxtValor"
        Me.TxtValor.Size = New System.Drawing.Size(88, 17)
        Me.TxtValor.TabIndex = 107
        Me.TxtValor.Text = "R$ 0,00"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(570, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 17)
        Me.Label18.TabIndex = 106
        Me.Label18.Text = "Valor"
        '
        'NmParcelas
        '
        Me.NmParcelas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NmParcelas.Enabled = False
        Me.NmParcelas.Location = New System.Drawing.Point(472, 36)
        Me.NmParcelas.Name = "NmParcelas"
        Me.NmParcelas.Size = New System.Drawing.Size(75, 20)
        Me.NmParcelas.TabIndex = 105
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(396, 36)
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
        Me.CmbFormasPgEntrada.Location = New System.Drawing.Point(135, 33)
        Me.CmbFormasPgEntrada.Name = "CmbFormasPgEntrada"
        Me.CmbFormasPgEntrada.Size = New System.Drawing.Size(246, 25)
        Me.CmbFormasPgEntrada.TabIndex = 103
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(129, 17)
        Me.Label16.TabIndex = 102
        Me.Label16.Text = "Forma de pagamento"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(10, 252)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1141, 20)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Recebimento"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtCotFinal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DtCotFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtCotFinal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column7, Me.Column10, Me.Column16, Me.Column15})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtCotFinal.DefaultCellStyle = DataGridViewCellStyle5
        Me.DtCotFinal.Enabled = False
        Me.DtCotFinal.EnableHeadersVisualStyles = False
        Me.DtCotFinal.GridColor = System.Drawing.Color.Gainsboro
        Me.DtCotFinal.Location = New System.Drawing.Point(13, 64)
        Me.DtCotFinal.MultiSelect = False
        Me.DtCotFinal.Name = "DtCotFinal"
        Me.DtCotFinal.ReadOnly = True
        Me.DtCotFinal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DtCotFinal.RowHeadersVisible = False
        Me.DtCotFinal.RowHeadersWidth = 51
        Me.DtCotFinal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtCotFinal.RowTemplate.Height = 30
        Me.DtCotFinal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtCotFinal.ShowCellErrors = False
        Me.DtCotFinal.ShowCellToolTips = False
        Me.DtCotFinal.ShowEditingIcon = False
        Me.DtCotFinal.ShowRowErrors = False
        Me.DtCotFinal.Size = New System.Drawing.Size(1138, 185)
        Me.DtCotFinal.TabIndex = 123
        '
        'Column5
        '
        Me.Column5.HeaderText = "Id Pagamento"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        Me.Column5.Width = 125
        '
        'Column1
        '
        Me.Column1.HeaderText = "Id Fornecedor"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Fornecedor"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Valor do título"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "Data do vencimento"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 125
        '
        'Column7
        '
        Me.Column7.HeaderText = ""
        Me.Column7.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column7.Width = 14
        '
        'Column10
        '
        Me.Column10.HeaderText = "IdStatus"
        Me.Column10.MinimumWidth = 6
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Visible = False
        Me.Column10.Width = 125
        '
        'Column16
        '
        Me.Column16.HeaderText = ""
        Me.Column16.MinimumWidth = 6
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 10
        '
        'Column15
        '
        Me.Column15.HeaderText = "IdItem"
        Me.Column15.MinimumWidth = 6
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Visible = False
        Me.Column15.Width = 125
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(10, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1141, 20)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Pagamentos esperados"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "check_ok_accept_apply_1582.png")
        Me.ImageList1.Images.SetKeyName(1, "Close_Icon_icon-icons.com_69144.png")
        Me.ImageList1.Images.SetKeyName(2, "alert_warning_256.png")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Cifrao.png")
        Me.ImageList2.Images.SetKeyName(1, "key_password_lock_800.png")
        Me.ImageList2.Images.SetKeyName(2, "Delete-80_icon-icons.com_57340.png")
        '
        'FrmPagamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1166, 703)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtCotFinal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPagamento"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPagamento"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DtFormas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmParcelas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtCotFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnConcluirRecebimento As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents LblValorRestante As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LblTroco As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblRecebidos As Label
    Friend WithEvents DtFormas As DataGridView
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents ClmReceber As DataGridViewImageColumn
    Friend WithEvents clmcomum As DataGridViewImageColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents ClmExcluir As DataGridViewImageColumn
    Friend WithEvents BttInsere As Button
    Friend WithEvents TxtValor As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents NmParcelas As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents CmbFormasPgEntrada As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DtCotFinal As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewImageColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents BtnNovaFormaPg As Button
End Class
