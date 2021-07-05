<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovoChecklist
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GpEtapas = New System.Windows.Forms.GroupBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GpCriterios = New System.Windows.Forms.GroupBox()
        Me.LblResposta = New System.Windows.Forms.Label()
        Me.LblRepostas = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.LblTipoResposta = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CmbPergunta = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GpDetalhes = New System.Windows.Forms.GroupBox()
        Me.LblDetalhesEtapa = New System.Windows.Forms.Label()
        Me.LblModoInteração = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NmPosiçãoEtapaProcesso = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BttAddEtapa = New System.Windows.Forms.Button()
        Me.CmbEtapasProcesso = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GpProcesso = New System.Windows.Forms.GroupBox()
        Me.NmPosiçãoProcesso = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BttAddProcesso = New System.Windows.Forms.Button()
        Me.CmbProcessos = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GpCategoriasChecklist = New System.Windows.Forms.GroupBox()
        Me.NmPosiçãoCatChecklist = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BttAddCatChecklist = New System.Windows.Forms.Button()
        Me.CmbCategoriasChecklist = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NmPosição = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblNivelReq = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BttcadChecllist = New System.Windows.Forms.Button()
        Me.CmbChecklist = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GpEtapas.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GpCriterios.SuspendLayout()
        Me.GpDetalhes.SuspendLayout()
        CType(Me.NmPosiçãoEtapaProcesso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpProcesso.SuspendLayout()
        CType(Me.NmPosiçãoProcesso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpCategoriasChecklist.SuspendLayout()
        CType(Me.NmPosiçãoCatChecklist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NmPosição, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 652)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(977, 36)
        Me.Panel2.TabIndex = 33
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(882, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BttFechar)
        Me.Panel3.Controls.Add(Me.BttSalvar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(882, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(95, 36)
        Me.Panel3.TabIndex = 26
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(60, 7)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 26
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(19, 7)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 27
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.GpEtapas)
        Me.Panel1.Controls.Add(Me.GpProcesso)
        Me.Panel1.Controls.Add(Me.GpCategoriasChecklist)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(977, 624)
        Me.Panel1.TabIndex = 31
        '
        'GpEtapas
        '
        Me.GpEtapas.Controls.Add(Me.Panel6)
        Me.GpEtapas.Controls.Add(Me.LblModoInteração)
        Me.GpEtapas.Controls.Add(Me.Label11)
        Me.GpEtapas.Controls.Add(Me.NmPosiçãoEtapaProcesso)
        Me.GpEtapas.Controls.Add(Me.Label9)
        Me.GpEtapas.Controls.Add(Me.BttAddEtapa)
        Me.GpEtapas.Controls.Add(Me.CmbEtapasProcesso)
        Me.GpEtapas.Controls.Add(Me.Label10)
        Me.GpEtapas.Enabled = False
        Me.GpEtapas.Location = New System.Drawing.Point(10, 182)
        Me.GpEtapas.Name = "GpEtapas"
        Me.GpEtapas.Size = New System.Drawing.Size(952, 434)
        Me.GpEtapas.TabIndex = 7
        Me.GpEtapas.TabStop = False
        Me.GpEtapas.Text = "Etapas definidas"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.GpCriterios)
        Me.Panel6.Controls.Add(Me.GpDetalhes)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(3, 125)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(946, 306)
        Me.Panel6.TabIndex = 37
        '
        'GpCriterios
        '
        Me.GpCriterios.Controls.Add(Me.LblResposta)
        Me.GpCriterios.Controls.Add(Me.LblRepostas)
        Me.GpCriterios.Controls.Add(Me.Label15)
        Me.GpCriterios.Controls.Add(Me.LblTipo)
        Me.GpCriterios.Controls.Add(Me.LblTipoResposta)
        Me.GpCriterios.Controls.Add(Me.Label14)
        Me.GpCriterios.Controls.Add(Me.Button1)
        Me.GpCriterios.Controls.Add(Me.CmbPergunta)
        Me.GpCriterios.Controls.Add(Me.Label13)
        Me.GpCriterios.Controls.Add(Me.Label12)
        Me.GpCriterios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GpCriterios.Location = New System.Drawing.Point(0, 0)
        Me.GpCriterios.Name = "GpCriterios"
        Me.GpCriterios.Size = New System.Drawing.Size(946, 306)
        Me.GpCriterios.TabIndex = 41
        Me.GpCriterios.TabStop = False
        Me.GpCriterios.Text = "Critérios"
        '
        'LblResposta
        '
        Me.LblResposta.AutoSize = True
        Me.LblResposta.ForeColor = System.Drawing.Color.SlateGray
        Me.LblResposta.Location = New System.Drawing.Point(106, 98)
        Me.LblResposta.Name = "LblResposta"
        Me.LblResposta.Size = New System.Drawing.Size(82, 13)
        Me.LblResposta.TabIndex = 47
        Me.LblResposta.Text = "Respostas prog."
        '
        'LblRepostas
        '
        Me.LblRepostas.AutoSize = True
        Me.LblRepostas.ForeColor = System.Drawing.Color.SlateGray
        Me.LblRepostas.Location = New System.Drawing.Point(106, 98)
        Me.LblRepostas.Name = "LblRepostas"
        Me.LblRepostas.Size = New System.Drawing.Size(0, 13)
        Me.LblRepostas.TabIndex = 46
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Respostas prog."
        '
        'LblTipo
        '
        Me.LblTipo.AutoSize = True
        Me.LblTipo.ForeColor = System.Drawing.Color.SlateGray
        Me.LblTipo.Location = New System.Drawing.Point(106, 68)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(0, 13)
        Me.LblTipo.TabIndex = 44
        '
        'LblTipoResposta
        '
        Me.LblTipoResposta.AutoSize = True
        Me.LblTipoResposta.ForeColor = System.Drawing.Color.SlateGray
        Me.LblTipoResposta.Location = New System.Drawing.Point(106, 68)
        Me.LblTipoResposta.Name = "LblTipoResposta"
        Me.LblTipoResposta.Size = New System.Drawing.Size(0, 13)
        Me.LblTipoResposta.TabIndex = 43
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 68)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Tipo da resposta"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(425, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 21)
        Me.Button1.TabIndex = 41
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CmbPergunta
        '
        Me.CmbPergunta.FormattingEnabled = True
        Me.CmbPergunta.Location = New System.Drawing.Point(109, 31)
        Me.CmbPergunta.Name = "CmbPergunta"
        Me.CmbPergunta.Size = New System.Drawing.Size(310, 21)
        Me.CmbPergunta.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Pergunta"
        '
        'Label12
        '
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.25!)
        Me.Label12.ForeColor = System.Drawing.Color.SlateGray
        Me.Label12.Location = New System.Drawing.Point(3, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(940, 286)
        Me.Label12.TabIndex = 38
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GpDetalhes
        '
        Me.GpDetalhes.Controls.Add(Me.LblDetalhesEtapa)
        Me.GpDetalhes.Location = New System.Drawing.Point(410, 163)
        Me.GpDetalhes.Name = "GpDetalhes"
        Me.GpDetalhes.Size = New System.Drawing.Size(98, 78)
        Me.GpDetalhes.TabIndex = 40
        Me.GpDetalhes.TabStop = False
        Me.GpDetalhes.Text = "Detalhes"
        '
        'LblDetalhesEtapa
        '
        Me.LblDetalhesEtapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblDetalhesEtapa.Font = New System.Drawing.Font("Calibri", 12.25!)
        Me.LblDetalhesEtapa.ForeColor = System.Drawing.Color.SlateGray
        Me.LblDetalhesEtapa.Location = New System.Drawing.Point(3, 17)
        Me.LblDetalhesEtapa.Name = "LblDetalhesEtapa"
        Me.LblDetalhesEtapa.Size = New System.Drawing.Size(92, 58)
        Me.LblDetalhesEtapa.TabIndex = 38
        Me.LblDetalhesEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblModoInteração
        '
        Me.LblModoInteração.AutoSize = True
        Me.LblModoInteração.ForeColor = System.Drawing.Color.SlateGray
        Me.LblModoInteração.Location = New System.Drawing.Point(109, 98)
        Me.LblModoInteração.Name = "LblModoInteração"
        Me.LblModoInteração.Size = New System.Drawing.Size(0, 13)
        Me.LblModoInteração.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Tipo de interação"
        '
        'NmPosiçãoEtapaProcesso
        '
        Me.NmPosiçãoEtapaProcesso.Enabled = False
        Me.NmPosiçãoEtapaProcesso.Location = New System.Drawing.Point(341, 53)
        Me.NmPosiçãoEtapaProcesso.Name = "NmPosiçãoEtapaProcesso"
        Me.NmPosiçãoEtapaProcesso.Size = New System.Drawing.Size(81, 21)
        Me.NmPosiçãoEtapaProcesso.TabIndex = 34
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(212, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Posição de execução"
        '
        'BttAddEtapa
        '
        Me.BttAddEtapa.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttAddEtapa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddEtapa.FlatAppearance.BorderSize = 0
        Me.BttAddEtapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddEtapa.Location = New System.Drawing.Point(428, 26)
        Me.BttAddEtapa.Name = "BttAddEtapa"
        Me.BttAddEtapa.Size = New System.Drawing.Size(33, 21)
        Me.BttAddEtapa.TabIndex = 26
        Me.BttAddEtapa.UseVisualStyleBackColor = True
        '
        'CmbEtapasProcesso
        '
        Me.CmbEtapasProcesso.FormattingEnabled = True
        Me.CmbEtapasProcesso.Location = New System.Drawing.Point(112, 26)
        Me.CmbEtapasProcesso.Name = "CmbEtapasProcesso"
        Me.CmbEtapasProcesso.Size = New System.Drawing.Size(310, 21)
        Me.CmbEtapasProcesso.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Etapas do processo"
        '
        'GpProcesso
        '
        Me.GpProcesso.Controls.Add(Me.NmPosiçãoProcesso)
        Me.GpProcesso.Controls.Add(Me.Label8)
        Me.GpProcesso.Controls.Add(Me.BttAddProcesso)
        Me.GpProcesso.Controls.Add(Me.CmbProcessos)
        Me.GpProcesso.Controls.Add(Me.Label4)
        Me.GpProcesso.Enabled = False
        Me.GpProcesso.Location = New System.Drawing.Point(10, 92)
        Me.GpProcesso.Name = "GpProcesso"
        Me.GpProcesso.Size = New System.Drawing.Size(473, 84)
        Me.GpProcesso.TabIndex = 6
        Me.GpProcesso.TabStop = False
        Me.GpProcesso.Text = "Processo definido para a categoria"
        '
        'NmPosiçãoProcesso
        '
        Me.NmPosiçãoProcesso.Enabled = False
        Me.NmPosiçãoProcesso.Location = New System.Drawing.Point(341, 53)
        Me.NmPosiçãoProcesso.Name = "NmPosiçãoProcesso"
        Me.NmPosiçãoProcesso.Size = New System.Drawing.Size(81, 21)
        Me.NmPosiçãoProcesso.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(212, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Posição de execução"
        '
        'BttAddProcesso
        '
        Me.BttAddProcesso.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttAddProcesso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddProcesso.FlatAppearance.BorderSize = 0
        Me.BttAddProcesso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddProcesso.Location = New System.Drawing.Point(428, 26)
        Me.BttAddProcesso.Name = "BttAddProcesso"
        Me.BttAddProcesso.Size = New System.Drawing.Size(33, 21)
        Me.BttAddProcesso.TabIndex = 26
        Me.BttAddProcesso.UseVisualStyleBackColor = True
        '
        'CmbProcessos
        '
        Me.CmbProcessos.FormattingEnabled = True
        Me.CmbProcessos.Location = New System.Drawing.Point(112, 26)
        Me.CmbProcessos.Name = "CmbProcessos"
        Me.CmbProcessos.Size = New System.Drawing.Size(310, 21)
        Me.CmbProcessos.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Titulo do processo"
        '
        'GpCategoriasChecklist
        '
        Me.GpCategoriasChecklist.Controls.Add(Me.NmPosiçãoCatChecklist)
        Me.GpCategoriasChecklist.Controls.Add(Me.Label6)
        Me.GpCategoriasChecklist.Controls.Add(Me.BttAddCatChecklist)
        Me.GpCategoriasChecklist.Controls.Add(Me.CmbCategoriasChecklist)
        Me.GpCategoriasChecklist.Controls.Add(Me.Label3)
        Me.GpCategoriasChecklist.Enabled = False
        Me.GpCategoriasChecklist.Location = New System.Drawing.Point(489, 3)
        Me.GpCategoriasChecklist.Name = "GpCategoriasChecklist"
        Me.GpCategoriasChecklist.Size = New System.Drawing.Size(473, 83)
        Me.GpCategoriasChecklist.TabIndex = 5
        Me.GpCategoriasChecklist.TabStop = False
        Me.GpCategoriasChecklist.Text = "Categorias para o checklist"
        '
        'NmPosiçãoCatChecklist
        '
        Me.NmPosiçãoCatChecklist.Enabled = False
        Me.NmPosiçãoCatChecklist.Location = New System.Drawing.Point(341, 53)
        Me.NmPosiçãoCatChecklist.Name = "NmPosiçãoCatChecklist"
        Me.NmPosiçãoCatChecklist.Size = New System.Drawing.Size(81, 21)
        Me.NmPosiçãoCatChecklist.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(212, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Posição de execução"
        '
        'BttAddCatChecklist
        '
        Me.BttAddCatChecklist.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttAddCatChecklist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddCatChecklist.FlatAppearance.BorderSize = 0
        Me.BttAddCatChecklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddCatChecklist.Location = New System.Drawing.Point(428, 26)
        Me.BttAddCatChecklist.Name = "BttAddCatChecklist"
        Me.BttAddCatChecklist.Size = New System.Drawing.Size(33, 21)
        Me.BttAddCatChecklist.TabIndex = 26
        Me.BttAddCatChecklist.UseVisualStyleBackColor = True
        '
        'CmbCategoriasChecklist
        '
        Me.CmbCategoriasChecklist.FormattingEnabled = True
        Me.CmbCategoriasChecklist.Location = New System.Drawing.Point(112, 26)
        Me.CmbCategoriasChecklist.Name = "CmbCategoriasChecklist"
        Me.CmbCategoriasChecklist.Size = New System.Drawing.Size(310, 21)
        Me.CmbCategoriasChecklist.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Titulo da categoria"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NmPosição)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblNivelReq)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.BttcadChecllist)
        Me.GroupBox1.Controls.Add(Me.CmbChecklist)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 83)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Checklist"
        '
        'NmPosição
        '
        Me.NmPosição.Enabled = False
        Me.NmPosição.Location = New System.Drawing.Point(341, 53)
        Me.NmPosição.Name = "NmPosição"
        Me.NmPosição.Size = New System.Drawing.Size(81, 21)
        Me.NmPosição.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(212, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Posição de execução"
        '
        'LblNivelReq
        '
        Me.LblNivelReq.AutoSize = True
        Me.LblNivelReq.ForeColor = System.Drawing.Color.SlateGray
        Me.LblNivelReq.Location = New System.Drawing.Point(109, 57)
        Me.LblNivelReq.Name = "LblNivelReq"
        Me.LblNivelReq.Size = New System.Drawing.Size(0, 13)
        Me.LblNivelReq.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Nivel de requisição"
        '
        'BttcadChecllist
        '
        Me.BttcadChecllist.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttcadChecllist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttcadChecllist.FlatAppearance.BorderSize = 0
        Me.BttcadChecllist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttcadChecllist.Location = New System.Drawing.Point(428, 26)
        Me.BttcadChecllist.Name = "BttcadChecllist"
        Me.BttcadChecllist.Size = New System.Drawing.Size(33, 21)
        Me.BttcadChecllist.TabIndex = 26
        Me.BttcadChecllist.UseVisualStyleBackColor = True
        '
        'CmbChecklist
        '
        Me.CmbChecklist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbChecklist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbChecklist.FormattingEnabled = True
        Me.CmbChecklist.Location = New System.Drawing.Point(112, 26)
        Me.CmbChecklist.Name = "CmbChecklist"
        Me.CmbChecklist.Size = New System.Drawing.Size(310, 21)
        Me.CmbChecklist.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Titulo do cheklist"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.SeaShell
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(977, 28)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Cadastro de novo checklist"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmNovoChecklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 688)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovoChecklist"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovoChecklist"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GpEtapas.ResumeLayout(False)
        Me.GpEtapas.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.GpCriterios.ResumeLayout(False)
        Me.GpCriterios.PerformLayout()
        Me.GpDetalhes.ResumeLayout(False)
        CType(Me.NmPosiçãoEtapaProcesso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpProcesso.ResumeLayout(False)
        Me.GpProcesso.PerformLayout()
        CType(Me.NmPosiçãoProcesso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpCategoriasChecklist.ResumeLayout(False)
        Me.GpCategoriasChecklist.PerformLayout()
        CType(Me.NmPosiçãoCatChecklist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NmPosição, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CmbChecklist As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GpProcesso As GroupBox
    Friend WithEvents BttAddProcesso As Button
    Friend WithEvents CmbProcessos As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GpCategoriasChecklist As GroupBox
    Friend WithEvents BttAddCatChecklist As Button
    Friend WithEvents CmbCategoriasChecklist As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BttcadChecllist As Button
    Friend WithEvents NmPosição As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents LblNivelReq As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents NmPosiçãoCatChecklist As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents NmPosiçãoProcesso As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents GpEtapas As GroupBox
    Friend WithEvents NmPosiçãoEtapaProcesso As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents BttAddEtapa As Button
    Friend WithEvents CmbEtapasProcesso As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents LblModoInteração As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents GpDetalhes As GroupBox
    Friend WithEvents LblDetalhesEtapa As Label
    Friend WithEvents GpCriterios As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents LblTipoResposta As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents CmbPergunta As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents LblTipo As Label
    Friend WithEvents LblRepostas As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents LblResposta As Label
End Class
