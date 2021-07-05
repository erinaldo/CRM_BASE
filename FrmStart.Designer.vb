<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStart
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BttAvaliacaoComplementar = New System.Windows.Forms.Button()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.BttIniciarServiços = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ChTimeline = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtLiberações = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ClmSolicitar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.TrHistórico = New System.Windows.Forms.TreeView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.PnnInferior.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.ChTimeline, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtLiberações, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1108, 28)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Escolha a operação desejada"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 460)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1108, 38)
        Me.PnnInferior.TabIndex = 55
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1054, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(93, 5)
        Me.Panel5.TabIndex = 32
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1054, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(54, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(15, 10)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1106, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(3, 431)
        Me.Panel1.TabIndex = 58
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BttAvaliacaoComplementar)
        Me.Panel2.Controls.Add(Me.Panel16)
        Me.Panel2.Controls.Add(Me.BttIniciarServiços)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Panel17)
        Me.Panel2.Controls.Add(Me.Panel14)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(835, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(271, 431)
        Me.Panel2.TabIndex = 59
        '
        'BttAvaliacaoComplementar
        '
        Me.BttAvaliacaoComplementar.BackColor = System.Drawing.Color.SlateGray
        Me.BttAvaliacaoComplementar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAvaliacaoComplementar.Dock = System.Windows.Forms.DockStyle.Top
        Me.BttAvaliacaoComplementar.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.BttAvaliacaoComplementar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAvaliacaoComplementar.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.BttAvaliacaoComplementar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttAvaliacaoComplementar.Location = New System.Drawing.Point(3, 67)
        Me.BttAvaliacaoComplementar.Name = "BttAvaliacaoComplementar"
        Me.BttAvaliacaoComplementar.Size = New System.Drawing.Size(265, 30)
        Me.BttAvaliacaoComplementar.TabIndex = 63
        Me.BttAvaliacaoComplementar.Text = "Avaliação complementar"
        Me.BttAvaliacaoComplementar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BttAvaliacaoComplementar.UseVisualStyleBackColor = False
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(3, 64)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(265, 3)
        Me.Panel16.TabIndex = 66
        '
        'BttIniciarServiços
        '
        Me.BttIniciarServiços.BackColor = System.Drawing.Color.SlateGray
        Me.BttIniciarServiços.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttIniciarServiços.Dock = System.Windows.Forms.DockStyle.Top
        Me.BttIniciarServiços.Enabled = False
        Me.BttIniciarServiços.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray
        Me.BttIniciarServiços.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttIniciarServiços.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.BttIniciarServiços.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttIniciarServiços.Location = New System.Drawing.Point(3, 34)
        Me.BttIniciarServiços.Name = "BttIniciarServiços"
        Me.BttIniciarServiços.Size = New System.Drawing.Size(265, 30)
        Me.BttIniciarServiços.TabIndex = 62
        Me.BttIniciarServiços.Text = "Iniciar serviços"
        Me.BttIniciarServiços.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BttIniciarServiços.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(3, 428)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(265, 3)
        Me.Panel6.TabIndex = 61
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(265, 3)
        Me.Panel3.TabIndex = 60
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(268, 31)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(3, 400)
        Me.Panel7.TabIndex = 64
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(268, 28)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Menu"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel17.Location = New System.Drawing.Point(3, 0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(268, 3)
        Me.Panel17.TabIndex = 68
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(3, 431)
        Me.Panel14.TabIndex = 65
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(1, 29)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(834, 3)
        Me.Panel8.TabIndex = 61
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(1, 457)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(834, 3)
        Me.Panel9.TabIndex = 62
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Panel13)
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(1, 32)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(834, 425)
        Me.Panel10.TabIndex = 63
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel13.Controls.Add(Me.Label3)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(10, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(824, 425)
        Me.Panel13.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.ChTimeline)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel1.Controls.Add(Me.DtLiberações)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 28)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(824, 397)
        Me.FlowLayoutPanel1.TabIndex = 67
        '
        'ChTimeline
        '
        Me.ChTimeline.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ChTimeline.BorderlineColor = System.Drawing.Color.Gainsboro
        Me.ChTimeline.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.Area3DStyle.Inclination = 70
        ChartArea1.Area3DStyle.IsRightAngleAxes = False
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea1.Area3DStyle.PointDepth = 50
        ChartArea1.Area3DStyle.WallWidth = 3
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.0!)
        ChartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.SlateGray
        ChartArea1.AxisX.LineColor = System.Drawing.Color.Gainsboro
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.AxisX2.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.0!)
        ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.SlateGray
        ChartArea1.AxisY.LineColor = System.Drawing.Color.Gainsboro
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.AxisY2.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.BackColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.Name = "ChartArea1"
        Me.ChTimeline.ChartAreas.Add(ChartArea1)
        Legend1.Alignment = System.Drawing.StringAlignment.Far
        Legend1.BackColor = System.Drawing.Color.WhiteSmoke
        Legend1.Font = New System.Drawing.Font("Calibri", 8.0!)
        Legend1.ForeColor = System.Drawing.Color.DarkSlateGray
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Legend1.TitleFont = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ChTimeline.Legends.Add(Legend1)
        Me.ChTimeline.Location = New System.Drawing.Point(3, 3)
        Me.ChTimeline.Name = "ChTimeline"
        Series1.BorderWidth = 0
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Font = New System.Drawing.Font("Calibri", 8.0!)
        Series1.LabelForeColor = System.Drawing.Color.SlateGray
        Series1.Legend = "Legend1"
        Series1.Name = "Progresso na oficina"
        Me.ChTimeline.Series.Add(Series1)
        Me.ChTimeline.Size = New System.Drawing.Size(815, 165)
        Me.ChTimeline.TabIndex = 0
        Me.ChTimeline.Text = "Chart1"
        Title1.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Title1.BackColor = System.Drawing.Color.WhiteSmoke
        Title1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Title1.ForeColor = System.Drawing.Color.DarkSlateGray
        Title1.Name = "Title1"
        Title1.Text = "Histórico detalhado"
        Me.ChTimeline.Titles.Add(Title1)
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(3, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(824, 25)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Peças solicitadas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtLiberações
        '
        Me.DtLiberações.AllowUserToAddRows = False
        Me.DtLiberações.AllowUserToDeleteRows = False
        Me.DtLiberações.AllowUserToResizeColumns = False
        Me.DtLiberações.AllowUserToResizeRows = False
        Me.DtLiberações.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtLiberações.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtLiberações.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtLiberações.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtLiberações.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtLiberações.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtLiberações.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.ClmSolicitar})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtLiberações.DefaultCellStyle = DataGridViewCellStyle2
        Me.DtLiberações.EnableHeadersVisualStyles = False
        Me.DtLiberações.GridColor = System.Drawing.Color.Gainsboro
        Me.DtLiberações.Location = New System.Drawing.Point(3, 199)
        Me.DtLiberações.MultiSelect = False
        Me.DtLiberações.Name = "DtLiberações"
        Me.DtLiberações.RowHeadersVisible = False
        Me.DtLiberações.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtLiberações.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtLiberações.Size = New System.Drawing.Size(815, 192)
        Me.DtLiberações.TabIndex = 168
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cod."
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Descrição"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column3.HeaderText = "N.I."
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column4.HeaderText = "Status"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 61
        '
        'Column5
        '
        Me.Column5.HeaderText = ""
        Me.Column5.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 15
        '
        'ClmSolicitar
        '
        Me.ClmSolicitar.HeaderText = ""
        Me.ClmSolicitar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.ClmSolicitar.Name = "ClmSolicitar"
        Me.ClmSolicitar.Width = 15
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(824, 28)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Dashboard"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.TrHistórico)
        Me.Panel11.Controls.Add(Me.Label2)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(10, 425)
        Me.Panel11.TabIndex = 0
        Me.Panel11.Visible = False
        '
        'TrHistórico
        '
        Me.TrHistórico.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TrHistórico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrHistórico.Location = New System.Drawing.Point(0, 28)
        Me.TrHistórico.Name = "TrHistórico"
        Me.TrHistórico.Size = New System.Drawing.Size(10, 397)
        Me.TrHistórico.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 28)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Histório operacional"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel18.Location = New System.Drawing.Point(1, 498)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(1108, 1)
        Me.Panel18.TabIndex = 68
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel19.Location = New System.Drawing.Point(1, 0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(1108, 1)
        Me.Panel19.TabIndex = 69
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel20.Location = New System.Drawing.Point(0, 0)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(1, 499)
        Me.Panel20.TabIndex = 70
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel21.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel21.Location = New System.Drawing.Point(1109, 0)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(1, 499)
        Me.Panel21.TabIndex = 71
        '
        'FrmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 499)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel18)
        Me.Controls.Add(Me.Panel19)
        Me.Controls.Add(Me.Panel20)
        Me.Controls.Add(Me.Panel21)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmStart"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmStart"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.ChTimeline, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtLiberações, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents BttAvaliacaoComplementar As Button
    Friend WithEvents BttIniciarServiços As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents Panel21 As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ChTimeline As DataVisualization.Charting.Chart
    Friend WithEvents TrHistórico As TreeView
    Friend WithEvents Label5 As Label
    Friend WithEvents DtLiberações As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewCheckBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewImageColumn
    Friend WithEvents ClmSolicitar As DataGridViewImageColumn
End Class
