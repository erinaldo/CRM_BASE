<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmImagemAvaliação
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImagemAvaliação))
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MarcarAvariaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiscoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AmassadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarcarPeçaAusenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TrMarcação = New System.Windows.Forms.TreeView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.BttMarcarAvaria = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PnnLayout = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.BttPonteiro = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.BttRisco = New System.Windows.Forms.ToolStripButton()
        Me.BttAmassado = New System.Windows.Forms.ToolStripButton()
        Me.BttPeçaAusente = New System.Windows.Forms.ToolStripButton()
        Me.BttPeçaIrrecuperavel = New System.Windows.Forms.ToolStripButton()
        Me.BttCorrosão = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.BttDelaminação = New System.Windows.Forms.ToolStripButton()
        Me.BttDesgaste = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.BttTrinco = New System.Windows.Forms.ToolStripButton()
        Me.BttDelaminaçãoVidro = New System.Windows.Forms.ToolStripButton()
        Me.BttQuebrado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.BttRasgado = New System.Windows.Forms.ToolStripButton()
        Me.BttDesgasteAcab = New System.Windows.Forms.ToolStripButton()
        Me.BttQuebradoAcab = New System.Windows.Forms.ToolStripButton()
        Me.BttRiscosAcab = New System.Windows.Forms.ToolStripButton()
        Me.BttMancha = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.BttInoperante = New System.Windows.Forms.ToolStripButton()
        Me.BttFalha = New System.Windows.Forms.ToolStripButton()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnnLayout.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.DarkSlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(1350, 28)
        Me.LblTitulo.TabIndex = 30
        Me.LblTitulo.Text = "Vistoria inicial"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarcarAvariaToolStripMenuItem, Me.MarcarPeçaAusenteToolStripMenuItem, Me.MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(270, 70)
        '
        'MarcarAvariaToolStripMenuItem
        '
        Me.MarcarAvariaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RiscoToolStripMenuItem, Me.AmassadoToolStripMenuItem})
        Me.MarcarAvariaToolStripMenuItem.Name = "MarcarAvariaToolStripMenuItem"
        Me.MarcarAvariaToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.MarcarAvariaToolStripMenuItem.Text = "Marcar avaria"
        '
        'RiscoToolStripMenuItem
        '
        Me.RiscoToolStripMenuItem.Name = "RiscoToolStripMenuItem"
        Me.RiscoToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.RiscoToolStripMenuItem.Text = "Risco"
        '
        'AmassadoToolStripMenuItem
        '
        Me.AmassadoToolStripMenuItem.Name = "AmassadoToolStripMenuItem"
        Me.AmassadoToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.AmassadoToolStripMenuItem.Text = "Amassado"
        '
        'MarcarPeçaAusenteToolStripMenuItem
        '
        Me.MarcarPeçaAusenteToolStripMenuItem.Name = "MarcarPeçaAusenteToolStripMenuItem"
        Me.MarcarPeçaAusenteToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.MarcarPeçaAusenteToolStripMenuItem.Text = "Marcar peça ausente"
        '
        'MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem
        '
        Me.MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem.Name = "MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem"
        Me.MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem.Size = New System.Drawing.Size(269, 22)
        Me.MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem.Text = "Marcar peça sem condição de reparo"
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.DarkSlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(0, 652)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1350, 38)
        Me.PnnInferior.TabIndex = 32
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1263, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1263, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(87, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(51, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(10, 8)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TrMarcação)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1094, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(252, 620)
        Me.Panel2.TabIndex = 1
        Me.Panel2.Visible = False
        '
        'TrMarcação
        '
        Me.TrMarcação.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrMarcação.Location = New System.Drawing.Point(0, 163)
        Me.TrMarcação.Name = "TrMarcação"
        Me.TrMarcação.Size = New System.Drawing.Size(252, 457)
        Me.TrMarcação.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.CheckBox3)
        Me.Panel3.Controls.Add(Me.CheckBox2)
        Me.Panel3.Controls.Add(Me.CheckBox1)
        Me.Panel3.Controls.Add(Me.BttMarcarAvaria)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(252, 163)
        Me.Panel3.TabIndex = 0
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(7, 133)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(157, 17)
        Me.CheckBox3.TabIndex = 36
        Me.CheckBox3.Text = "Mostrar apenas amassados"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(7, 110)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(131, 17)
        Me.CheckBox2.TabIndex = 35
        Me.CheckBox2.Text = "Mostrar apenas riscos"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(6, 87)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(160, 17)
        Me.CheckBox1.TabIndex = 34
        Me.CheckBox1.Text = "Mostrar todas as marcações"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'BttMarcarAvaria
        '
        Me.BttMarcarAvaria.Location = New System.Drawing.Point(137, 48)
        Me.BttMarcarAvaria.Name = "BttMarcarAvaria"
        Me.BttMarcarAvaria.Size = New System.Drawing.Size(105, 23)
        Me.BttMarcarAvaria.TabIndex = 33
        Me.BttMarcarAvaria.Text = "Marcar avaria"
        Me.BttMarcarAvaria.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Calibri", 10.25!)
        Me.Label10.ForeColor = System.Drawing.Color.SlateGray
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(252, 30)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Avarias"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PnnLayout)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1350, 624)
        Me.Panel1.TabIndex = 31
        '
        'PnnLayout
        '
        Me.PnnLayout.Controls.Add(Me.PictureBox1)
        Me.PnnLayout.Controls.Add(Me.ToolStrip1)
        Me.PnnLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnnLayout.Location = New System.Drawing.Point(0, 0)
        Me.PnnLayout.Name = "PnnLayout"
        Me.PnnLayout.Size = New System.Drawing.Size(1094, 620)
        Me.PnnLayout.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(93, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1001, 620)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.BttPonteiro, Me.ToolStripLabel1, Me.BttRisco, Me.BttAmassado, Me.BttPeçaAusente, Me.BttPeçaIrrecuperavel, Me.BttCorrosão, Me.ToolStripLabel2, Me.BttDelaminação, Me.BttDesgaste, Me.ToolStripLabel3, Me.BttTrinco, Me.BttDelaminaçãoVidro, Me.BttQuebrado, Me.ToolStripLabel5, Me.BttRasgado, Me.BttDesgasteAcab, Me.BttQuebradoAcab, Me.BttRiscosAcab, Me.BttMancha, Me.ToolStripLabel6, Me.BttInoperante, Me.BttFalha})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(93, 620)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ToolStripLabel4.ForeColor = System.Drawing.Color.SlateGray
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(38, 14)
        Me.ToolStripLabel4.Text = "Menu"
        '
        'BttPonteiro
        '
        Me.BttPonteiro.Checked = True
        Me.BttPonteiro.CheckOnClick = True
        Me.BttPonteiro.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BttPonteiro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BttPonteiro.Image = Global.CRM_BASE.My.Resources.Resources.SoftwareIcons_38_5121
        Me.BttPonteiro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttPonteiro.Name = "BttPonteiro"
        Me.BttPonteiro.Size = New System.Drawing.Size(23, 20)
        Me.BttPonteiro.Text = "Riscos"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.SlateGray
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(45, 14)
        Me.ToolStripLabel1.Text = "Lataria"
        '
        'BttRisco
        '
        Me.BttRisco.CheckOnClick = True
        Me.BttRisco.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttRisco.Image = Global.CRM_BASE.My.Resources.Resources.Risco
        Me.BttRisco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttRisco.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttRisco.Name = "BttRisco"
        Me.BttRisco.Size = New System.Drawing.Size(44, 20)
        Me.BttRisco.Text = "Risco"
        Me.BttRisco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BttAmassado
        '
        Me.BttAmassado.CheckOnClick = True
        Me.BttAmassado.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttAmassado.Image = Global.CRM_BASE.My.Resources.Resources.Risco
        Me.BttAmassado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttAmassado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttAmassado.Name = "BttAmassado"
        Me.BttAmassado.Size = New System.Drawing.Size(61, 20)
        Me.BttAmassado.Text = "Amassado"
        Me.BttAmassado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BttPeçaAusente
        '
        Me.BttPeçaAusente.CheckOnClick = True
        Me.BttPeçaAusente.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttPeçaAusente.Image = CType(resources.GetObject("BttPeçaAusente.Image"), System.Drawing.Image)
        Me.BttPeçaAusente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttPeçaAusente.Name = "BttPeçaAusente"
        Me.BttPeçaAusente.Size = New System.Drawing.Size(71, 20)
        Me.BttPeçaAusente.Text = "Peça ausente"
        '
        'BttPeçaIrrecuperavel
        '
        Me.BttPeçaIrrecuperavel.CheckOnClick = True
        Me.BttPeçaIrrecuperavel.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttPeçaIrrecuperavel.Image = CType(resources.GetObject("BttPeçaIrrecuperavel.Image"), System.Drawing.Image)
        Me.BttPeçaIrrecuperavel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttPeçaIrrecuperavel.Name = "BttPeçaIrrecuperavel"
        Me.BttPeçaIrrecuperavel.Size = New System.Drawing.Size(90, 20)
        Me.BttPeçaIrrecuperavel.Text = "Peça irrecuperável"
        '
        'BttCorrosão
        '
        Me.BttCorrosão.CheckOnClick = True
        Me.BttCorrosão.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttCorrosão.Image = CType(resources.GetObject("BttCorrosão.Image"), System.Drawing.Image)
        Me.BttCorrosão.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttCorrosão.Name = "BttCorrosão"
        Me.BttCorrosão.Size = New System.Drawing.Size(58, 20)
        Me.BttCorrosão.Text = "Corrosão"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.SlateGray
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(46, 14)
        Me.ToolStripLabel2.Text = "Pintura"
        '
        'BttDelaminação
        '
        Me.BttDelaminação.CheckOnClick = True
        Me.BttDelaminação.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttDelaminação.Image = CType(resources.GetObject("BttDelaminação.Image"), System.Drawing.Image)
        Me.BttDelaminação.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttDelaminação.Name = "BttDelaminação"
        Me.BttDelaminação.Size = New System.Drawing.Size(72, 20)
        Me.BttDelaminação.Text = "Delaminação"
        '
        'BttDesgaste
        '
        Me.BttDesgaste.CheckOnClick = True
        Me.BttDesgaste.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttDesgaste.Image = CType(resources.GetObject("BttDesgaste.Image"), System.Drawing.Image)
        Me.BttDesgaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttDesgaste.Name = "BttDesgaste"
        Me.BttDesgaste.Size = New System.Drawing.Size(57, 20)
        Me.BttDesgaste.Text = "Desgaste"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.SlateGray
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(42, 14)
        Me.ToolStripLabel3.Text = "Vidros"
        '
        'BttTrinco
        '
        Me.BttTrinco.CheckOnClick = True
        Me.BttTrinco.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttTrinco.Image = CType(resources.GetObject("BttTrinco.Image"), System.Drawing.Image)
        Me.BttTrinco.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttTrinco.Name = "BttTrinco"
        Me.BttTrinco.Size = New System.Drawing.Size(50, 20)
        Me.BttTrinco.Text = "Trincos"
        '
        'BttDelaminaçãoVidro
        '
        Me.BttDelaminaçãoVidro.CheckOnClick = True
        Me.BttDelaminaçãoVidro.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttDelaminaçãoVidro.Image = CType(resources.GetObject("BttDelaminaçãoVidro.Image"), System.Drawing.Image)
        Me.BttDelaminaçãoVidro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttDelaminaçãoVidro.Name = "BttDelaminaçãoVidro"
        Me.BttDelaminaçãoVidro.Size = New System.Drawing.Size(72, 20)
        Me.BttDelaminaçãoVidro.Text = "Delaminação"
        '
        'BttQuebrado
        '
        Me.BttQuebrado.CheckOnClick = True
        Me.BttQuebrado.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttQuebrado.Image = CType(resources.GetObject("BttQuebrado.Image"), System.Drawing.Image)
        Me.BttQuebrado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttQuebrado.Name = "BttQuebrado"
        Me.BttQuebrado.Size = New System.Drawing.Size(62, 20)
        Me.BttQuebrado.Text = "Quebrado"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ToolStripLabel5.ForeColor = System.Drawing.Color.SlateGray
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(81, 14)
        Me.ToolStripLabel5.Text = "Acabamentos"
        '
        'BttRasgado
        '
        Me.BttRasgado.CheckOnClick = True
        Me.BttRasgado.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttRasgado.Image = CType(resources.GetObject("BttRasgado.Image"), System.Drawing.Image)
        Me.BttRasgado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttRasgado.Name = "BttRasgado"
        Me.BttRasgado.Size = New System.Drawing.Size(56, 20)
        Me.BttRasgado.Text = "Rasgado"
        '
        'BttDesgasteAcab
        '
        Me.BttDesgasteAcab.CheckOnClick = True
        Me.BttDesgasteAcab.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttDesgasteAcab.Image = CType(resources.GetObject("BttDesgasteAcab.Image"), System.Drawing.Image)
        Me.BttDesgasteAcab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttDesgasteAcab.Name = "BttDesgasteAcab"
        Me.BttDesgasteAcab.Size = New System.Drawing.Size(57, 20)
        Me.BttDesgasteAcab.Text = "Desgaste"
        '
        'BttQuebradoAcab
        '
        Me.BttQuebradoAcab.CheckOnClick = True
        Me.BttQuebradoAcab.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttQuebradoAcab.Image = CType(resources.GetObject("BttQuebradoAcab.Image"), System.Drawing.Image)
        Me.BttQuebradoAcab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttQuebradoAcab.Name = "BttQuebradoAcab"
        Me.BttQuebradoAcab.Size = New System.Drawing.Size(62, 20)
        Me.BttQuebradoAcab.Text = "Quebrado"
        '
        'BttRiscosAcab
        '
        Me.BttRiscosAcab.CheckOnClick = True
        Me.BttRiscosAcab.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttRiscosAcab.Image = Global.CRM_BASE.My.Resources.Resources.Risco
        Me.BttRiscosAcab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttRiscosAcab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttRiscosAcab.Name = "BttRiscosAcab"
        Me.BttRiscosAcab.Size = New System.Drawing.Size(44, 20)
        Me.BttRiscosAcab.Text = "Risco"
        Me.BttRiscosAcab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BttMancha
        '
        Me.BttMancha.CheckOnClick = True
        Me.BttMancha.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttMancha.Image = CType(resources.GetObject("BttMancha.Image"), System.Drawing.Image)
        Me.BttMancha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttMancha.Name = "BttMancha"
        Me.BttMancha.Size = New System.Drawing.Size(54, 20)
        Me.BttMancha.Text = "Mancha"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ToolStripLabel6.ForeColor = System.Drawing.Color.SlateGray
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(92, 14)
        Me.ToolStripLabel6.Text = "Funcionamento"
        '
        'BttInoperante
        '
        Me.BttInoperante.CheckOnClick = True
        Me.BttInoperante.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttInoperante.Image = CType(resources.GetObject("BttInoperante.Image"), System.Drawing.Image)
        Me.BttInoperante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttInoperante.Name = "BttInoperante"
        Me.BttInoperante.Size = New System.Drawing.Size(65, 20)
        Me.BttInoperante.Text = "Inoperante"
        '
        'BttFalha
        '
        Me.BttFalha.CheckOnClick = True
        Me.BttFalha.Font = New System.Drawing.Font("Segoe UI", 6.0!)
        Me.BttFalha.Image = CType(resources.GetObject("BttFalha.Image"), System.Drawing.Image)
        Me.BttFalha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BttFalha.Name = "BttFalha"
        Me.BttFalha.Size = New System.Drawing.Size(44, 20)
        Me.BttFalha.Text = "Falha"
        '
        'FrmImagemAvaliação
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 690)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PnnInferior)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmImagemAvaliação"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmImagemAvaliação"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.PnnLayout.ResumeLayout(False)
        Me.PnnLayout.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MarcarAvariaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RiscoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AmassadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarcarPeçaAusenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TrMarcação As TreeView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents BttMarcarAvaria As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PnnLayout As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents BttRisco As ToolStripButton
    Friend WithEvents BttAmassado As ToolStripButton
    Friend WithEvents BttPeçaAusente As ToolStripButton
    Friend WithEvents BttPeçaIrrecuperavel As ToolStripButton
    Friend WithEvents BttCorrosão As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents BttDesgaste As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents BttTrinco As ToolStripButton
    Friend WithEvents BttQuebrado As ToolStripButton
    Friend WithEvents BttPonteiro As ToolStripButton
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents BttRasgado As ToolStripButton
    Friend WithEvents BttDesgasteAcab As ToolStripButton
    Friend WithEvents BttMancha As ToolStripButton
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents BttInoperante As ToolStripButton
    Friend WithEvents BttFalha As ToolStripButton
    Friend WithEvents BttDelaminação As ToolStripButton
    Friend WithEvents BttQuebradoAcab As ToolStripButton
    Friend WithEvents BttDelaminaçãoVidro As ToolStripButton
    Friend WithEvents BttRiscosAcab As ToolStripButton
End Class
