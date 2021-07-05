<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBalancete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBalancete))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblBalalco = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TrFluxo = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.LblEntrada = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblSaida = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblEntradaPendente = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblSaidaPendente = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BttBaixarLanc = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 720)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1272, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 720)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(2, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1270, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(2, 719)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1270, 1)
        Me.Panel4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1250, 20)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Fluxo financeiro"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.SlateGray
        Me.Label2.Location = New System.Drawing.Point(889, 599)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(373, 20)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Total dos caixas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblBalalco
        '
        Me.LblBalalco.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblBalalco.Font = New System.Drawing.Font("Calibri", 22.0!)
        Me.LblBalalco.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblBalalco.Location = New System.Drawing.Point(887, 627)
        Me.LblBalalco.Name = "LblBalalco"
        Me.LblBalalco.Size = New System.Drawing.Size(376, 51)
        Me.LblBalalco.TabIndex = 84
        Me.LblBalalco.Text = "R$ 0.00"
        Me.LblBalalco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(12, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1250, 1)
        Me.Label4.TabIndex = 85
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrFluxo
        '
        Me.TrFluxo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TrFluxo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TrFluxo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TrFluxo.ForeColor = System.Drawing.Color.SlateGray
        Me.TrFluxo.ImageIndex = 4
        Me.TrFluxo.ImageList = Me.ImageList1
        Me.TrFluxo.Location = New System.Drawing.Point(15, 66)
        Me.TrFluxo.Name = "TrFluxo"
        Me.TrFluxo.SelectedImageIndex = 0
        Me.TrFluxo.Size = New System.Drawing.Size(1239, 376)
        Me.TrFluxo.TabIndex = 86
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Close_Icon_icon-icons.com_69144.png")
        Me.ImageList1.Images.SetKeyName(1, "arrowdown_flech_1539.png")
        Me.ImageList1.Images.SetKeyName(2, "uparrow_arriba_1538.png")
        Me.ImageList1.Images.SetKeyName(3, "ic_select_all_128_28720.png")
        Me.ImageList1.Images.SetKeyName(4, "calendar-icon_34471.png")
        Me.ImageList1.Images.SetKeyName(5, "ic_attach_money_128_28210.png")
        Me.ImageList1.Images.SetKeyName(6, "icons8-mais-16.png")
        Me.ImageList1.Images.SetKeyName(7, "icons8-menos-16.png")
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(2, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(1270, 28)
        Me.LblTitulo.TabIndex = 87
        Me.LblTitulo.Text = "Fluxo financeiro"
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
        Me.PnnInferior.Location = New System.Drawing.Point(2, 681)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1270, 38)
        Me.PnnInferior.TabIndex = 88
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
        Me.Panel5.Size = New System.Drawing.Size(1211, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1211, 0)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(59, 38)
        Me.Panel12.TabIndex = 50
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(18, 9)
        Me.BttFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'LblEntrada
        '
        Me.LblEntrada.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblEntrada.Font = New System.Drawing.Font("Calibri", 8.0!)
        Me.LblEntrada.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblEntrada.Location = New System.Drawing.Point(888, 506)
        Me.LblEntrada.Name = "LblEntrada"
        Me.LblEntrada.Size = New System.Drawing.Size(184, 30)
        Me.LblEntrada.TabIndex = 91
        Me.LblEntrada.Text = "R$ 0.00"
        Me.LblEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label6.ForeColor = System.Drawing.Color.SlateGray
        Me.Label6.Location = New System.Drawing.Point(888, 478)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 20)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Entradas"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSaida
        '
        Me.LblSaida.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblSaida.Font = New System.Drawing.Font("Calibri", 8.0!)
        Me.LblSaida.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblSaida.Location = New System.Drawing.Point(1078, 506)
        Me.LblSaida.Name = "LblSaida"
        Me.LblSaida.Size = New System.Drawing.Size(184, 30)
        Me.LblSaida.TabIndex = 93
        Me.LblSaida.Text = "R$ 0.00"
        Me.LblSaida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.SlateGray
        Me.Label8.Location = New System.Drawing.Point(1078, 478)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(184, 20)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "Saídas"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.SlateGray
        Me.Label5.Location = New System.Drawing.Point(44, 529)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(178, 20)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Abrir calendário "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1273, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 720)
        Me.Panel6.TabIndex = 97
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.SlateGray
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1, 720)
        Me.Panel7.TabIndex = 98
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column11, Me.Column9, Me.Column10})
        Me.DataGridView1.Location = New System.Drawing.Point(1047, 66)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(215, 392)
        Me.DataGridView1.TabIndex = 99
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
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label7.ForeColor = System.Drawing.Color.SlateGray
        Me.Label7.Location = New System.Drawing.Point(226, 530)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 20)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Movimentar contas"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblEntradaPendente
        '
        Me.LblEntradaPendente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblEntradaPendente.Font = New System.Drawing.Font("Calibri", 8.0!)
        Me.LblEntradaPendente.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblEntradaPendente.Location = New System.Drawing.Point(889, 570)
        Me.LblEntradaPendente.Name = "LblEntradaPendente"
        Me.LblEntradaPendente.Size = New System.Drawing.Size(184, 30)
        Me.LblEntradaPendente.TabIndex = 103
        Me.LblEntradaPendente.Text = "R$ 0.00"
        Me.LblEntradaPendente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label10.ForeColor = System.Drawing.Color.SlateGray
        Me.Label10.Location = New System.Drawing.Point(889, 542)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(184, 20)
        Me.Label10.TabIndex = 102
        Me.Label10.Text = "Entradas pendentes"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSaidaPendente
        '
        Me.LblSaidaPendente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblSaidaPendente.Font = New System.Drawing.Font("Calibri", 8.0!)
        Me.LblSaidaPendente.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblSaidaPendente.Location = New System.Drawing.Point(1079, 570)
        Me.LblSaidaPendente.Name = "LblSaidaPendente"
        Me.LblSaidaPendente.Size = New System.Drawing.Size(184, 30)
        Me.LblSaidaPendente.TabIndex = 105
        Me.LblSaidaPendente.Text = "R$ 0.00"
        Me.LblSaidaPendente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label12.ForeColor = System.Drawing.Color.SlateGray
        Me.Label12.Location = New System.Drawing.Point(1079, 542)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(184, 20)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = "Saídas pendentes"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label9.ForeColor = System.Drawing.Color.SlateGray
        Me.Label9.Location = New System.Drawing.Point(420, 530)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(182, 20)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "Baixar lançamento"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "icone-tipo-traducao-financeira-fluxo-caixa.png")
        Me.ImageList2.Images.SetKeyName(1, "pngwing.com (9).png")
        Me.ImageList2.Images.SetKeyName(2, "pngwing.com (6).png")
        Me.ImageList2.Images.SetKeyName(3, "Cifrao.png")
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gainsboro
        Me.Label11.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label11.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label11.Location = New System.Drawing.Point(31, 640)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(787, 1)
        Me.Label11.TabIndex = 108
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Gainsboro
        Me.Label13.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label13.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label13.Location = New System.Drawing.Point(31, 513)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(787, 1)
        Me.Label13.TabIndex = 109
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BttBaixarLanc
        '
        Me.BttBaixarLanc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttBaixarLanc.Enabled = False
        Me.BttBaixarLanc.FlatAppearance.BorderSize = 0
        Me.BttBaixarLanc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttBaixarLanc.ImageKey = "pngwing.com (9).png"
        Me.BttBaixarLanc.ImageList = Me.ImageList2
        Me.BttBaixarLanc.Location = New System.Drawing.Point(420, 554)
        Me.BttBaixarLanc.Margin = New System.Windows.Forms.Padding(4)
        Me.BttBaixarLanc.Name = "BttBaixarLanc"
        Me.BttBaixarLanc.Size = New System.Drawing.Size(182, 69)
        Me.BttBaixarLanc.TabIndex = 106
        Me.BttBaixarLanc.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ImageKey = "icone-tipo-traducao-financeira-fluxo-caixa.png"
        Me.Button2.ImageList = Me.ImageList2
        Me.Button2.Location = New System.Drawing.Point(230, 554)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(182, 69)
        Me.Button2.TabIndex = 100
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ImageKey = "pngwing.com (6).png"
        Me.Button1.ImageList = Me.ImageList2
        Me.Button1.Location = New System.Drawing.Point(40, 553)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(182, 69)
        Me.Button1.TabIndex = 95
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.SlateGray
        Me.Label3.Location = New System.Drawing.Point(610, 530)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 20)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Novo lançamento"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ImageKey = "Cifrao.png"
        Me.Button3.ImageList = Me.ImageList2
        Me.Button3.Location = New System.Drawing.Point(610, 554)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(182, 69)
        Me.Button3.TabIndex = 110
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmBalancete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1274, 720)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BttBaixarLanc)
        Me.Controls.Add(Me.LblSaidaPendente)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LblEntradaPendente)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LblSaida)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblEntrada)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.TrFluxo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblBalalco)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel7)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmBalancete"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBalancete"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblBalalco As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblTitulo As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents TrFluxo As TreeView
    Friend WithEvents LblEntrada As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblSaida As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents DataGridView1 As DataGridView
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
    Friend WithEvents Button2 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents LblEntradaPendente As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblSaidaPendente As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents BttBaixarLanc As Button
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
End Class
