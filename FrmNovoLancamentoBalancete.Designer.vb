<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovoLancamentoBalancete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNovoLancamentoBalancete))
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TrFluxo = New System.Windows.Forms.TreeView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblIdItem = New System.Windows.Forms.Label()
        Me.LblFormaPg = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblDescricaoComprovante = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblDesconto = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblAcrescimo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblValorOriginal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblDataDaBaixa = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNomedoBeneficiario = New System.Windows.Forms.Label()
        Me.LblDescricaoInicial = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnBaixarPagamento = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 694)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(730, 34)
        Me.PnnInferior.TabIndex = 92
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
        Me.Panel5.Size = New System.Drawing.Size(684, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(684, 0)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(46, 34)
        Me.Panel12.TabIndex = 50
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(14, 8)
        Me.BttFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(16, 18)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(730, 24)
        Me.LblTitulo.TabIndex = 93
        Me.LblTitulo.Text = "Fluxo financeiro"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(731, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 728)
        Me.Panel1.TabIndex = 94
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 728)
        Me.Panel2.TabIndex = 95
        '
        'TrFluxo
        '
        Me.TrFluxo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TrFluxo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TrFluxo.Dock = System.Windows.Forms.DockStyle.Top
        Me.TrFluxo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TrFluxo.ForeColor = System.Drawing.Color.SlateGray
        Me.TrFluxo.ImageIndex = 4
        Me.TrFluxo.ImageList = Me.ImageList2
        Me.TrFluxo.Location = New System.Drawing.Point(1, 24)
        Me.TrFluxo.Name = "TrFluxo"
        Me.TrFluxo.SelectedImageIndex = 0
        Me.TrFluxo.Size = New System.Drawing.Size(730, 270)
        Me.TrFluxo.TabIndex = 96
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Close_Icon_icon-icons.com_69144.png")
        Me.ImageList2.Images.SetKeyName(1, "arrowdown_flech_1539.png")
        Me.ImageList2.Images.SetKeyName(2, "uparrow_arriba_1538.png")
        Me.ImageList2.Images.SetKeyName(3, "ic_select_all_128_28720.png")
        Me.ImageList2.Images.SetKeyName(4, "calendar-icon_34471.png")
        Me.ImageList2.Images.SetKeyName(5, "ic_attach_money_128_28210.png")
        Me.ImageList2.Images.SetKeyName(6, "icons8-mais-16.png")
        Me.ImageList2.Images.SetKeyName(7, "icons8-menos-16.png")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblIdItem)
        Me.GroupBox1.Controls.Add(Me.LblFormaPg)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LblDescricaoComprovante)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.LblDesconto)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.LblAcrescimo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblValorOriginal)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.LblDataDaBaixa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.LblNomedoBeneficiario)
        Me.GroupBox1.Controls.Add(Me.LblDescricaoInicial)
        Me.GroupBox1.ForeColor = System.Drawing.Color.SlateGray
        Me.GroupBox1.Location = New System.Drawing.Point(12, 300)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(708, 313)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalhes do lançamento"
        '
        'LblIdItem
        '
        Me.LblIdItem.AutoSize = True
        Me.LblIdItem.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblIdItem.Location = New System.Drawing.Point(573, 128)
        Me.LblIdItem.Name = "LblIdItem"
        Me.LblIdItem.Size = New System.Drawing.Size(11, 17)
        Me.LblIdItem.TabIndex = 18
        Me.LblIdItem.Text = " "
        Me.LblIdItem.Visible = False
        '
        'LblFormaPg
        '
        Me.LblFormaPg.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblFormaPg.Location = New System.Drawing.Point(6, 248)
        Me.LblFormaPg.Name = "LblFormaPg"
        Me.LblFormaPg.Size = New System.Drawing.Size(699, 22)
        Me.LblFormaPg.TabIndex = 17
        Me.LblFormaPg.Text = " "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 227)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Forma de pagamento"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblStatus.Location = New System.Drawing.Point(573, 53)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(11, 17)
        Me.LblStatus.TabIndex = 15
        Me.LblStatus.Text = " "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(573, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Tipo do lançamento"
        '
        'LblDescricaoComprovante
        '
        Me.LblDescricaoComprovante.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblDescricaoComprovante.Location = New System.Drawing.Point(9, 176)
        Me.LblDescricaoComprovante.Name = "LblDescricaoComprovante"
        Me.LblDescricaoComprovante.Size = New System.Drawing.Size(699, 22)
        Me.LblDescricaoComprovante.TabIndex = 13
        Me.LblDescricaoComprovante.Text = " "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 158)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(158, 17)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Descricao do comprovante"
        '
        'LblDesconto
        '
        Me.LblDesconto.AutoSize = True
        Me.LblDesconto.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblDesconto.Location = New System.Drawing.Point(573, 111)
        Me.LblDesconto.Name = "LblDesconto"
        Me.LblDesconto.Size = New System.Drawing.Size(11, 17)
        Me.LblDesconto.TabIndex = 9
        Me.LblDesconto.Text = " "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(573, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Descontos"
        '
        'LblAcrescimo
        '
        Me.LblAcrescimo.AutoSize = True
        Me.LblAcrescimo.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblAcrescimo.Location = New System.Drawing.Point(409, 111)
        Me.LblAcrescimo.Name = "LblAcrescimo"
        Me.LblAcrescimo.Size = New System.Drawing.Size(11, 17)
        Me.LblAcrescimo.TabIndex = 7
        Me.LblAcrescimo.Text = " "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(409, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Acréscimos"
        '
        'LblValorOriginal
        '
        Me.LblValorOriginal.AutoSize = True
        Me.LblValorOriginal.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblValorOriginal.Location = New System.Drawing.Point(237, 111)
        Me.LblValorOriginal.Name = "LblValorOriginal"
        Me.LblValorOriginal.Size = New System.Drawing.Size(11, 17)
        Me.LblValorOriginal.TabIndex = 5
        Me.LblValorOriginal.Text = " "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(237, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Valor Original"
        '
        'LblDataDaBaixa
        '
        Me.LblDataDaBaixa.AutoSize = True
        Me.LblDataDaBaixa.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblDataDaBaixa.Location = New System.Drawing.Point(6, 111)
        Me.LblDataDaBaixa.Name = "LblDataDaBaixa"
        Me.LblDataDaBaixa.Size = New System.Drawing.Size(11, 17)
        Me.LblDataDaBaixa.TabIndex = 3
        Me.LblDataDaBaixa.Text = " "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Status"
        '
        'LblNomedoBeneficiario
        '
        Me.LblNomedoBeneficiario.AutoSize = True
        Me.LblNomedoBeneficiario.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblNomedoBeneficiario.Location = New System.Drawing.Point(6, 53)
        Me.LblNomedoBeneficiario.Name = "LblNomedoBeneficiario"
        Me.LblNomedoBeneficiario.Size = New System.Drawing.Size(11, 17)
        Me.LblNomedoBeneficiario.TabIndex = 1
        Me.LblNomedoBeneficiario.Text = " "
        '
        'LblDescricaoInicial
        '
        Me.LblDescricaoInicial.AutoSize = True
        Me.LblDescricaoInicial.Location = New System.Drawing.Point(6, 31)
        Me.LblDescricaoInicial.Name = "LblDescricaoInicial"
        Me.LblDescricaoInicial.Size = New System.Drawing.Size(75, 17)
        Me.LblDescricaoInicial.TabIndex = 0
        Me.LblDescricaoInicial.Text = "Beneficiário"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column11, Me.Column9, Me.Column10})
        Me.DataGridView1.Location = New System.Drawing.Point(505, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(215, 267)
        Me.DataGridView1.TabIndex = 98
        Me.DataGridView1.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "DescTreeNode"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descricao"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 125
        '
        'Column3
        '
        Me.Column3.HeaderText = "Valor"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "Baixado"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 125
        '
        'Column5
        '
        Me.Column5.HeaderText = "Tipo"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 125
        '
        'Column6
        '
        Me.Column6.HeaderText = "A"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 125
        '
        'Column7
        '
        Me.Column7.HeaderText = "D"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 125
        '
        'Column8
        '
        Me.Column8.HeaderText = "Detalhe"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 125
        '
        'Column11
        '
        Me.Column11.HeaderText = "IdItemBalancete"
        Me.Column11.MinimumWidth = 6
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 125
        '
        'Column9
        '
        Me.Column9.HeaderText = "IdFormaPg"
        Me.Column9.MinimumWidth = 6
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 125
        '
        'Column10
        '
        Me.Column10.HeaderText = "Forma"
        Me.Column10.MinimumWidth = 6
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 125
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Cifrao.png")
        Me.ImageList1.Images.SetKeyName(1, "pngwing.com (9).png")
        '
        'BtnBaixarPagamento
        '
        Me.BtnBaixarPagamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnBaixarPagamento.Enabled = False
        Me.BtnBaixarPagamento.FlatAppearance.BorderSize = 0
        Me.BtnBaixarPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBaixarPagamento.ForeColor = System.Drawing.Color.SlateGray
        Me.BtnBaixarPagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBaixarPagamento.ImageKey = "pngwing.com (9).png"
        Me.BtnBaixarPagamento.ImageList = Me.ImageList1
        Me.BtnBaixarPagamento.Location = New System.Drawing.Point(431, 620)
        Me.BtnBaixarPagamento.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnBaixarPagamento.Name = "BtnBaixarPagamento"
        Me.BtnBaixarPagamento.Size = New System.Drawing.Size(289, 49)
        Me.BtnBaixarPagamento.TabIndex = 97
        Me.BtnBaixarPagamento.Text = "Baixar pagamento"
        Me.BtnBaixarPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBaixarPagamento.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.SlateGray
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.ImageKey = "Cifrao.png"
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(134, 620)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(289, 49)
        Me.Button3.TabIndex = 99
        Me.Button3.Text = "Novo lançamento financeiro"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmNovoLancamentoBalancete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 728)
        Me.Controls.Add(Me.BtnBaixarPagamento)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TrFluxo)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovoLancamentoBalancete"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovoLancamentoBalancete"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents LblTitulo As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TrFluxo As TreeView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents LblDescricaoComprovante As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblDesconto As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblAcrescimo As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblValorOriginal As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblDataDaBaixa As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblNomedoBeneficiario As Label
    Friend WithEvents LblDescricaoInicial As Label
    Friend WithEvents BtnBaixarPagamento As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents LblStatus As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblFormaPg As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As DataGridViewCheckBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents LblIdItem As Label
    Friend WithEvents ImageList2 As ImageList
End Class
