<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNovoStudioAvaliacao
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PnnAreaTrabalho = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TrRespostashecklist = New System.Windows.Forms.TreeView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.BtnRiscos = New System.Windows.Forms.ToolStripButton()
        Me.BtnAmassado = New System.Windows.Forms.ToolStripButton()
        Me.BtnImpossívelReparar = New System.Windows.Forms.ToolStripButton()
        Me.BtnPeçaAusente = New System.Windows.Forms.ToolStripButton()
        Me.BtnPinturaDesbotada = New System.Windows.Forms.ToolStripButton()
        Me.BtnCorrosão = New System.Windows.Forms.ToolStripButton()
        Me.BtnRasgos = New System.Windows.Forms.ToolStripButton()
        Me.BtnManchas = New System.Windows.Forms.ToolStripButton()
        Me.BtnAcabAusente = New System.Windows.Forms.ToolStripButton()
        Me.BtnAcabQuebrado = New System.Windows.Forms.ToolStripButton()
        Me.BtnAcabRisco = New System.Windows.Forms.ToolStripButton()
        Me.BtnPMAusente = New System.Windows.Forms.ToolStripButton()
        Me.BtnPmQuebrado = New System.Windows.Forms.ToolStripButton()
        Me.BtnPMFalha = New System.Windows.Forms.ToolStripButton()
        Me.BtnPmSubst = New System.Windows.Forms.ToolStripButton()
        Me.BtnVidroAusente = New System.Windows.Forms.ToolStripButton()
        Me.BtnVidroQuebrado = New System.Windows.Forms.ToolStripButton()
        Me.BtnVidroTrincado = New System.Windows.Forms.ToolStripButton()
        Me.BtnPEAusente = New System.Windows.Forms.ToolStripButton()
        Me.BtnPEFalha = New System.Windows.Forms.ToolStripButton()
        Me.BtnPEQuebrado = New System.Windows.Forms.ToolStripButton()
        Me.BtnPESubstituição = New System.Windows.Forms.ToolStripButton()
        Me.PicImagem = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiscosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AmassadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PeçaIrrecuperávelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeçaAusenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.PinturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesbotamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PercaDeTintaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CorrosãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcabamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiscosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RasgosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManchaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PeçaQuebradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeçaAusenteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MotorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MalFuncionamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FalaConstanteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FalhaIntermitenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.PeçaAusenteToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeçaQuabradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VidrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrincosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuebradoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.VidroAusenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeçasEletronicasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MalFuncionamentoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FalhaConstanteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FalhaIntermitenteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.BttCarregar = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.LstEncontrados = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PicLocalizadas = New System.Windows.Forms.PictureBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.LblStagio = New System.Windows.Forms.Label()
        Me.LblNumSoluçãoN = New System.Windows.Forms.Label()
        Me.LblNumProcessoN = New System.Windows.Forms.Label()
        Me.LblPlacaN = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LblFrontal = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LblTraseira = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LblLatEsq = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripDropDownButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LblLatDir = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripDropDownButton5 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LblInterior = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripDropDownButton6 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LblPm = New System.Windows.Forms.ToolStripLabel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.LblPlaca = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.PnnAreaTrabalho.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PicImagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.PicLocalizadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 711)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1302, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 711)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(1, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1301, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 710)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1301, 1)
        Me.Panel4.TabIndex = 3
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
        Me.PnnInferior.Location = New System.Drawing.Point(1, 680)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1301, 30)
        Me.PnnInferior.TabIndex = 35
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
        Me.Panel5.Size = New System.Drawing.Size(1246, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1246, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(55, 30)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(18, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(15, 15)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(1301, 28)
        Me.LblTitulo.TabIndex = 36
        Me.LblTitulo.Text = "Avaliação de avarias"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PnnAreaTrabalho
        '
        Me.PnnAreaTrabalho.Controls.Add(Me.Panel8)
        Me.PnnAreaTrabalho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnnAreaTrabalho.Location = New System.Drawing.Point(1, 29)
        Me.PnnAreaTrabalho.Name = "PnnAreaTrabalho"
        Me.PnnAreaTrabalho.Size = New System.Drawing.Size(1301, 651)
        Me.PnnAreaTrabalho.TabIndex = 38
        '
        'Panel8
        '
        Me.Panel8.AutoScroll = True
        Me.Panel8.BackColor = System.Drawing.Color.SlateGray
        Me.Panel8.Controls.Add(Me.TrRespostashecklist)
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Controls.Add(Me.Panel15)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1301, 651)
        Me.Panel8.TabIndex = 1
        '
        'TrRespostashecklist
        '
        Me.TrRespostashecklist.Dock = System.Windows.Forms.DockStyle.Right
        Me.TrRespostashecklist.Location = New System.Drawing.Point(1291, 59)
        Me.TrRespostashecklist.Name = "TrRespostashecklist"
        Me.TrRespostashecklist.Size = New System.Drawing.Size(10, 592)
        Me.TrRespostashecklist.TabIndex = 1
        Me.TrRespostashecklist.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(200, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1101, 2)
        Me.Label7.TabIndex = 114
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.Controls.Add(Me.ToolStrip1)
        Me.Panel9.Controls.Add(Me.PicImagem)
        Me.Panel9.Controls.Add(Me.PictureBox1)
        Me.Panel9.Controls.Add(Me.Panel6)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(200, 57)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1101, 594)
        Me.Panel9.TabIndex = 41
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.BtnRiscos, Me.BtnAmassado, Me.BtnImpossívelReparar, Me.BtnPeçaAusente, Me.BtnPinturaDesbotada, Me.BtnCorrosão, Me.BtnRasgos, Me.BtnManchas, Me.BtnAcabAusente, Me.BtnAcabQuebrado, Me.BtnAcabRisco, Me.BtnPMAusente, Me.BtnPmQuebrado, Me.BtnPMFalha, Me.BtnPmSubst, Me.BtnVidroAusente, Me.BtnVidroQuebrado, Me.BtnVidroTrincado, Me.BtnPEAusente, Me.BtnPEFalha, Me.BtnPEQuebrado, Me.BtnPESubstituição})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(876, 10)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.AutoSize = False
        Me.ToolStripButton1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.SoftwareIcons_38_5121
        Me.ToolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(25, 25)
        Me.ToolStripButton1.Text = "Selecionar"
        '
        'BtnRiscos
        '
        Me.BtnRiscos.AutoSize = False
        Me.BtnRiscos.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.RiscoP
        Me.BtnRiscos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRiscos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRiscos.Enabled = False
        Me.BtnRiscos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnRiscos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRiscos.Name = "BtnRiscos"
        Me.BtnRiscos.Size = New System.Drawing.Size(38, 23)
        Me.BtnRiscos.Text = "Riscos"
        Me.BtnRiscos.Visible = False
        '
        'BtnAmassado
        '
        Me.BtnAmassado.AutoSize = False
        Me.BtnAmassado.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.AmassadoP
        Me.BtnAmassado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAmassado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnAmassado.Enabled = False
        Me.BtnAmassado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAmassado.Name = "BtnAmassado"
        Me.BtnAmassado.Size = New System.Drawing.Size(38, 23)
        Me.BtnAmassado.Text = "Amassados"
        Me.BtnAmassado.Visible = False
        '
        'BtnImpossívelReparar
        '
        Me.BtnImpossívelReparar.AutoSize = False
        Me.BtnImpossívelReparar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.PeçaIrrecup
        Me.BtnImpossívelReparar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnImpossívelReparar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnImpossívelReparar.Enabled = False
        Me.BtnImpossívelReparar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImpossívelReparar.Name = "BtnImpossívelReparar"
        Me.BtnImpossívelReparar.Size = New System.Drawing.Size(38, 23)
        Me.BtnImpossívelReparar.Text = "Peça irreparável"
        Me.BtnImpossívelReparar.Visible = False
        '
        'BtnPeçaAusente
        '
        Me.BtnPeçaAusente.AutoSize = False
        Me.BtnPeçaAusente.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.PeçaAusente
        Me.BtnPeçaAusente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPeçaAusente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPeçaAusente.Enabled = False
        Me.BtnPeçaAusente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPeçaAusente.Name = "BtnPeçaAusente"
        Me.BtnPeçaAusente.Size = New System.Drawing.Size(38, 23)
        Me.BtnPeçaAusente.Text = "Peça ausente"
        Me.BtnPeçaAusente.Visible = False
        '
        'BtnPinturaDesbotada
        '
        Me.BtnPinturaDesbotada.AutoSize = False
        Me.BtnPinturaDesbotada.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.PinturaD
        Me.BtnPinturaDesbotada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPinturaDesbotada.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPinturaDesbotada.Enabled = False
        Me.BtnPinturaDesbotada.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPinturaDesbotada.Name = "BtnPinturaDesbotada"
        Me.BtnPinturaDesbotada.Size = New System.Drawing.Size(38, 23)
        Me.BtnPinturaDesbotada.Text = "Manchas na pintura"
        Me.BtnPinturaDesbotada.Visible = False
        '
        'BtnCorrosão
        '
        Me.BtnCorrosão.AutoSize = False
        Me.BtnCorrosão.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.PinturaC
        Me.BtnCorrosão.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnCorrosão.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCorrosão.Enabled = False
        Me.BtnCorrosão.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCorrosão.Name = "BtnCorrosão"
        Me.BtnCorrosão.Size = New System.Drawing.Size(38, 23)
        Me.BtnCorrosão.Text = "Corrosão"
        Me.BtnCorrosão.Visible = False
        '
        'BtnRasgos
        '
        Me.BtnRasgos.AutoSize = False
        Me.BtnRasgos.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.RasgosB
        Me.BtnRasgos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnRasgos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRasgos.Enabled = False
        Me.BtnRasgos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRasgos.Name = "BtnRasgos"
        Me.BtnRasgos.Size = New System.Drawing.Size(38, 23)
        Me.BtnRasgos.Text = "Rasgos "
        Me.BtnRasgos.Visible = False
        '
        'BtnManchas
        '
        Me.BtnManchas.AutoSize = False
        Me.BtnManchas.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.ManchasB
        Me.BtnManchas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnManchas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnManchas.Enabled = False
        Me.BtnManchas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnManchas.Name = "BtnManchas"
        Me.BtnManchas.Size = New System.Drawing.Size(38, 23)
        Me.BtnManchas.Text = "Manchas "
        Me.BtnManchas.Visible = False
        '
        'BtnAcabAusente
        '
        Me.BtnAcabAusente.AutoSize = False
        Me.BtnAcabAusente.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.AcabAusente1
        Me.BtnAcabAusente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAcabAusente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnAcabAusente.Enabled = False
        Me.BtnAcabAusente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAcabAusente.Name = "BtnAcabAusente"
        Me.BtnAcabAusente.Size = New System.Drawing.Size(38, 23)
        Me.BtnAcabAusente.Text = "Peça  ausente"
        Me.BtnAcabAusente.Visible = False
        '
        'BtnAcabQuebrado
        '
        Me.BtnAcabQuebrado.AutoSize = False
        Me.BtnAcabQuebrado.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.AcabQuebrado
        Me.BtnAcabQuebrado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAcabQuebrado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnAcabQuebrado.Enabled = False
        Me.BtnAcabQuebrado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAcabQuebrado.Name = "BtnAcabQuebrado"
        Me.BtnAcabQuebrado.Size = New System.Drawing.Size(38, 23)
        Me.BtnAcabQuebrado.Text = "Quebrado"
        Me.BtnAcabQuebrado.Visible = False
        '
        'BtnAcabRisco
        '
        Me.BtnAcabRisco.AutoSize = False
        Me.BtnAcabRisco.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.AcabRiscos
        Me.BtnAcabRisco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAcabRisco.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnAcabRisco.Enabled = False
        Me.BtnAcabRisco.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAcabRisco.Name = "BtnAcabRisco"
        Me.BtnAcabRisco.Size = New System.Drawing.Size(38, 23)
        Me.BtnAcabRisco.Text = "Riscos"
        Me.BtnAcabRisco.Visible = False
        '
        'BtnPMAusente
        '
        Me.BtnPMAusente.AutoSize = False
        Me.BtnPMAusente.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.PeçaMAus
        Me.BtnPMAusente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPMAusente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPMAusente.Enabled = False
        Me.BtnPMAusente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPMAusente.Name = "BtnPMAusente"
        Me.BtnPMAusente.Size = New System.Drawing.Size(38, 23)
        Me.BtnPMAusente.Text = "Peça ausente"
        Me.BtnPMAusente.Visible = False
        '
        'BtnPmQuebrado
        '
        Me.BtnPmQuebrado.AutoSize = False
        Me.BtnPmQuebrado.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.PeçaQuebradaM
        Me.BtnPmQuebrado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPmQuebrado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPmQuebrado.Enabled = False
        Me.BtnPmQuebrado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPmQuebrado.Name = "BtnPmQuebrado"
        Me.BtnPmQuebrado.Size = New System.Drawing.Size(38, 23)
        Me.BtnPmQuebrado.Text = "Quebrado"
        Me.BtnPmQuebrado.Visible = False
        '
        'BtnPMFalha
        '
        Me.BtnPMFalha.AutoSize = False
        Me.BtnPMFalha.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.PeçaM_MalFunc
        Me.BtnPMFalha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPMFalha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPMFalha.Enabled = False
        Me.BtnPMFalha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPMFalha.Name = "BtnPMFalha"
        Me.BtnPMFalha.Size = New System.Drawing.Size(38, 23)
        Me.BtnPMFalha.Text = "Falha"
        Me.BtnPMFalha.Visible = False
        '
        'BtnPmSubst
        '
        Me.BtnPmSubst.AutoSize = False
        Me.BtnPmSubst.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.PeçaSubs
        Me.BtnPmSubst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPmSubst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPmSubst.Enabled = False
        Me.BtnPmSubst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPmSubst.Name = "BtnPmSubst"
        Me.BtnPmSubst.Size = New System.Drawing.Size(38, 23)
        Me.BtnPmSubst.Text = "Substituir"
        Me.BtnPmSubst.Visible = False
        '
        'BtnVidroAusente
        '
        Me.BtnVidroAusente.AutoSize = False
        Me.BtnVidroAusente.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.VidroA
        Me.BtnVidroAusente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnVidroAusente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnVidroAusente.Enabled = False
        Me.BtnVidroAusente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVidroAusente.Name = "BtnVidroAusente"
        Me.BtnVidroAusente.Size = New System.Drawing.Size(38, 23)
        Me.BtnVidroAusente.Text = "Ausente"
        Me.BtnVidroAusente.Visible = False
        '
        'BtnVidroQuebrado
        '
        Me.BtnVidroQuebrado.AutoSize = False
        Me.BtnVidroQuebrado.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.VidroQ
        Me.BtnVidroQuebrado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnVidroQuebrado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnVidroQuebrado.Enabled = False
        Me.BtnVidroQuebrado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVidroQuebrado.Name = "BtnVidroQuebrado"
        Me.BtnVidroQuebrado.Size = New System.Drawing.Size(38, 23)
        Me.BtnVidroQuebrado.Text = "Quebrado"
        Me.BtnVidroQuebrado.Visible = False
        '
        'BtnVidroTrincado
        '
        Me.BtnVidroTrincado.AutoSize = False
        Me.BtnVidroTrincado.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.VidroT
        Me.BtnVidroTrincado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnVidroTrincado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnVidroTrincado.Enabled = False
        Me.BtnVidroTrincado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVidroTrincado.Name = "BtnVidroTrincado"
        Me.BtnVidroTrincado.Size = New System.Drawing.Size(38, 23)
        Me.BtnVidroTrincado.Text = "Trincos"
        Me.BtnVidroTrincado.Visible = False
        '
        'BtnPEAusente
        '
        Me.BtnPEAusente.AutoSize = False
        Me.BtnPEAusente.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.ParteEletricaA
        Me.BtnPEAusente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPEAusente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPEAusente.Enabled = False
        Me.BtnPEAusente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPEAusente.Name = "BtnPEAusente"
        Me.BtnPEAusente.Size = New System.Drawing.Size(38, 23)
        Me.BtnPEAusente.Text = "Peça ausente "
        Me.BtnPEAusente.Visible = False
        '
        'BtnPEFalha
        '
        Me.BtnPEFalha.AutoSize = False
        Me.BtnPEFalha.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.ParteEletricaAMF
        Me.BtnPEFalha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPEFalha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPEFalha.Enabled = False
        Me.BtnPEFalha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPEFalha.Name = "BtnPEFalha"
        Me.BtnPEFalha.Size = New System.Drawing.Size(38, 23)
        Me.BtnPEFalha.Text = "Falha"
        Me.BtnPEFalha.Visible = False
        '
        'BtnPEQuebrado
        '
        Me.BtnPEQuebrado.AutoSize = False
        Me.BtnPEQuebrado.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.ParteEletricaQ
        Me.BtnPEQuebrado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPEQuebrado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPEQuebrado.Enabled = False
        Me.BtnPEQuebrado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPEQuebrado.Name = "BtnPEQuebrado"
        Me.BtnPEQuebrado.Size = New System.Drawing.Size(38, 23)
        Me.BtnPEQuebrado.Text = "Quebrado"
        Me.BtnPEQuebrado.Visible = False
        '
        'BtnPESubstituição
        '
        Me.BtnPESubstituição.AutoSize = False
        Me.BtnPESubstituição.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.ParteEletricaS
        Me.BtnPESubstituição.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPESubstituição.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPESubstituição.Enabled = False
        Me.BtnPESubstituição.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPESubstituição.Name = "BtnPESubstituição"
        Me.BtnPESubstituição.Size = New System.Drawing.Size(38, 23)
        Me.BtnPESubstituição.Text = "Substituir"
        Me.BtnPESubstituição.Visible = False
        '
        'PicImagem
        '
        Me.PicImagem.BackColor = System.Drawing.Color.White
        Me.PicImagem.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.untitled_n
        Me.PicImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicImagem.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PicImagem.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PicImagem.Location = New System.Drawing.Point(17, 5)
        Me.PicImagem.Name = "PicImagem"
        Me.PicImagem.Size = New System.Drawing.Size(848, 582)
        Me.PicImagem.TabIndex = 0
        Me.PicImagem.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.AcabamentoToolStripMenuItem, Me.MotorToolStripMenuItem, Me.VidrosToolStripMenuItem, Me.PeçasEletronicasToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(191, 124)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RiscosToolStripMenuItem, Me.AmassadosToolStripMenuItem, Me.ToolStripSeparator2, Me.PeçaIrrecuperávelToolStripMenuItem, Me.PeçaAusenteToolStripMenuItem, Me.ToolStripSeparator4, Me.PinturaToolStripMenuItem, Me.CorrosãoToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(190, 24)
        Me.ToolStripMenuItem1.Text = "Lataria"
        '
        'RiscosToolStripMenuItem
        '
        Me.RiscosToolStripMenuItem.Name = "RiscosToolStripMenuItem"
        Me.RiscosToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.RiscosToolStripMenuItem.Text = "Riscos"
        '
        'AmassadosToolStripMenuItem
        '
        Me.AmassadosToolStripMenuItem.Name = "AmassadosToolStripMenuItem"
        Me.AmassadosToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.AmassadosToolStripMenuItem.Text = "Amassados"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(209, 6)
        '
        'PeçaIrrecuperávelToolStripMenuItem
        '
        Me.PeçaIrrecuperávelToolStripMenuItem.Name = "PeçaIrrecuperávelToolStripMenuItem"
        Me.PeçaIrrecuperávelToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PeçaIrrecuperávelToolStripMenuItem.Text = "Peça irrecuperável"
        '
        'PeçaAusenteToolStripMenuItem
        '
        Me.PeçaAusenteToolStripMenuItem.Name = "PeçaAusenteToolStripMenuItem"
        Me.PeçaAusenteToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PeçaAusenteToolStripMenuItem.Text = "Peça ausente"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(209, 6)
        '
        'PinturaToolStripMenuItem
        '
        Me.PinturaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesbotamentoToolStripMenuItem, Me.PercaDeTintaToolStripMenuItem})
        Me.PinturaToolStripMenuItem.Name = "PinturaToolStripMenuItem"
        Me.PinturaToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PinturaToolStripMenuItem.Text = "Pintura"
        '
        'DesbotamentoToolStripMenuItem
        '
        Me.DesbotamentoToolStripMenuItem.Name = "DesbotamentoToolStripMenuItem"
        Me.DesbotamentoToolStripMenuItem.Size = New System.Drawing.Size(191, 26)
        Me.DesbotamentoToolStripMenuItem.Text = "Desbotamento"
        '
        'PercaDeTintaToolStripMenuItem
        '
        Me.PercaDeTintaToolStripMenuItem.Name = "PercaDeTintaToolStripMenuItem"
        Me.PercaDeTintaToolStripMenuItem.Size = New System.Drawing.Size(191, 26)
        Me.PercaDeTintaToolStripMenuItem.Text = "Perca de tinta"
        '
        'CorrosãoToolStripMenuItem
        '
        Me.CorrosãoToolStripMenuItem.Name = "CorrosãoToolStripMenuItem"
        Me.CorrosãoToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.CorrosãoToolStripMenuItem.Text = "Corrosão"
        '
        'AcabamentoToolStripMenuItem
        '
        Me.AcabamentoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RiscosToolStripMenuItem1, Me.RasgosToolStripMenuItem, Me.ManchaToolStripMenuItem, Me.ToolStripSeparator3, Me.PeçaQuebradaToolStripMenuItem, Me.PeçaAusenteToolStripMenuItem1})
        Me.AcabamentoToolStripMenuItem.Name = "AcabamentoToolStripMenuItem"
        Me.AcabamentoToolStripMenuItem.Size = New System.Drawing.Size(190, 24)
        Me.AcabamentoToolStripMenuItem.Text = "Acabamento"
        '
        'RiscosToolStripMenuItem1
        '
        Me.RiscosToolStripMenuItem1.Name = "RiscosToolStripMenuItem1"
        Me.RiscosToolStripMenuItem1.Size = New System.Drawing.Size(190, 26)
        Me.RiscosToolStripMenuItem1.Text = "Riscos"
        '
        'RasgosToolStripMenuItem
        '
        Me.RasgosToolStripMenuItem.Name = "RasgosToolStripMenuItem"
        Me.RasgosToolStripMenuItem.Size = New System.Drawing.Size(190, 26)
        Me.RasgosToolStripMenuItem.Text = "Rasgos"
        '
        'ManchaToolStripMenuItem
        '
        Me.ManchaToolStripMenuItem.Name = "ManchaToolStripMenuItem"
        Me.ManchaToolStripMenuItem.Size = New System.Drawing.Size(190, 26)
        Me.ManchaToolStripMenuItem.Text = "Manchas"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(187, 6)
        '
        'PeçaQuebradaToolStripMenuItem
        '
        Me.PeçaQuebradaToolStripMenuItem.Name = "PeçaQuebradaToolStripMenuItem"
        Me.PeçaQuebradaToolStripMenuItem.Size = New System.Drawing.Size(190, 26)
        Me.PeçaQuebradaToolStripMenuItem.Text = "Peça quebrada"
        '
        'PeçaAusenteToolStripMenuItem1
        '
        Me.PeçaAusenteToolStripMenuItem1.Name = "PeçaAusenteToolStripMenuItem1"
        Me.PeçaAusenteToolStripMenuItem1.Size = New System.Drawing.Size(190, 26)
        Me.PeçaAusenteToolStripMenuItem1.Text = "Peça ausente"
        '
        'MotorToolStripMenuItem
        '
        Me.MotorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MalFuncionamentoToolStripMenuItem, Me.ToolStripSeparator5, Me.PeçaAusenteToolStripMenuItem2, Me.PeçaQuabradaToolStripMenuItem})
        Me.MotorToolStripMenuItem.Name = "MotorToolStripMenuItem"
        Me.MotorToolStripMenuItem.Size = New System.Drawing.Size(190, 24)
        Me.MotorToolStripMenuItem.Text = "Peças mecânicas"
        '
        'MalFuncionamentoToolStripMenuItem
        '
        Me.MalFuncionamentoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FalaConstanteToolStripMenuItem, Me.FalhaIntermitenteToolStripMenuItem})
        Me.MalFuncionamentoToolStripMenuItem.Name = "MalFuncionamentoToolStripMenuItem"
        Me.MalFuncionamentoToolStripMenuItem.Size = New System.Drawing.Size(221, 26)
        Me.MalFuncionamentoToolStripMenuItem.Text = "Mal funcionamento"
        '
        'FalaConstanteToolStripMenuItem
        '
        Me.FalaConstanteToolStripMenuItem.Name = "FalaConstanteToolStripMenuItem"
        Me.FalaConstanteToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.FalaConstanteToolStripMenuItem.Text = "Falha constante"
        '
        'FalhaIntermitenteToolStripMenuItem
        '
        Me.FalhaIntermitenteToolStripMenuItem.Name = "FalhaIntermitenteToolStripMenuItem"
        Me.FalhaIntermitenteToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.FalhaIntermitenteToolStripMenuItem.Text = "Falha intermitente"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(218, 6)
        '
        'PeçaAusenteToolStripMenuItem2
        '
        Me.PeçaAusenteToolStripMenuItem2.Name = "PeçaAusenteToolStripMenuItem2"
        Me.PeçaAusenteToolStripMenuItem2.Size = New System.Drawing.Size(221, 26)
        Me.PeçaAusenteToolStripMenuItem2.Text = "Peça ausente"
        '
        'PeçaQuabradaToolStripMenuItem
        '
        Me.PeçaQuabradaToolStripMenuItem.Name = "PeçaQuabradaToolStripMenuItem"
        Me.PeçaQuabradaToolStripMenuItem.Size = New System.Drawing.Size(221, 26)
        Me.PeçaQuabradaToolStripMenuItem.Text = "Peça quebrada"
        '
        'VidrosToolStripMenuItem
        '
        Me.VidrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrincosToolStripMenuItem, Me.QuebradoToolStripMenuItem, Me.ToolStripSeparator6, Me.VidroAusenteToolStripMenuItem})
        Me.VidrosToolStripMenuItem.Name = "VidrosToolStripMenuItem"
        Me.VidrosToolStripMenuItem.Size = New System.Drawing.Size(190, 24)
        Me.VidrosToolStripMenuItem.Text = "Vidros"
        '
        'TrincosToolStripMenuItem
        '
        Me.TrincosToolStripMenuItem.Name = "TrincosToolStripMenuItem"
        Me.TrincosToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.TrincosToolStripMenuItem.Text = "Trincos"
        '
        'QuebradoToolStripMenuItem
        '
        Me.QuebradoToolStripMenuItem.Name = "QuebradoToolStripMenuItem"
        Me.QuebradoToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.QuebradoToolStripMenuItem.Text = "Vidro quebrado"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(194, 6)
        '
        'VidroAusenteToolStripMenuItem
        '
        Me.VidroAusenteToolStripMenuItem.Name = "VidroAusenteToolStripMenuItem"
        Me.VidroAusenteToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.VidroAusenteToolStripMenuItem.Text = "Vidro ausente"
        '
        'PeçasEletronicasToolStripMenuItem
        '
        Me.PeçasEletronicasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MalFuncionamentoToolStripMenuItem1})
        Me.PeçasEletronicasToolStripMenuItem.Name = "PeçasEletronicasToolStripMenuItem"
        Me.PeçasEletronicasToolStripMenuItem.Size = New System.Drawing.Size(190, 24)
        Me.PeçasEletronicasToolStripMenuItem.Text = "Peças eletrônicas"
        '
        'MalFuncionamentoToolStripMenuItem1
        '
        Me.MalFuncionamentoToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FalhaConstanteToolStripMenuItem, Me.FalhaIntermitenteToolStripMenuItem1})
        Me.MalFuncionamentoToolStripMenuItem1.Name = "MalFuncionamentoToolStripMenuItem1"
        Me.MalFuncionamentoToolStripMenuItem1.Size = New System.Drawing.Size(221, 26)
        Me.MalFuncionamentoToolStripMenuItem1.Text = "Mal funcionamento"
        '
        'FalhaConstanteToolStripMenuItem
        '
        Me.FalhaConstanteToolStripMenuItem.Name = "FalhaConstanteToolStripMenuItem"
        Me.FalhaConstanteToolStripMenuItem.Size = New System.Drawing.Size(211, 26)
        Me.FalhaConstanteToolStripMenuItem.Text = "Falha constante"
        '
        'FalhaIntermitenteToolStripMenuItem1
        '
        Me.FalhaIntermitenteToolStripMenuItem1.Name = "FalhaIntermitenteToolStripMenuItem1"
        Me.FalhaIntermitenteToolStripMenuItem1.Size = New System.Drawing.Size(211, 26)
        Me.FalhaIntermitenteToolStripMenuItem1.Text = "Falha intermitente"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Location = New System.Drawing.Point(19, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(848, 582)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.Controls.Add(Me.BttCarregar)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(876, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(225, 594)
        Me.Panel6.TabIndex = 0
        '
        'BttCarregar
        '
        Me.BttCarregar.Dock = System.Windows.Forms.DockStyle.Top
        Me.BttCarregar.Enabled = False
        Me.BttCarregar.FlatAppearance.BorderSize = 0
        Me.BttCarregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttCarregar.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.BttCarregar.Image = Global.CRM_BASE.My.Resources.Resources.Search_find_locate_1542
        Me.BttCarregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttCarregar.Location = New System.Drawing.Point(0, 0)
        Me.BttCarregar.Name = "BttCarregar"
        Me.BttCarregar.Size = New System.Drawing.Size(225, 10)
        Me.BttCarregar.TabIndex = 112
        Me.BttCarregar.Text = "Carregar imagem      "
        Me.BttCarregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttCarregar.UseVisualStyleBackColor = True
        Me.BttCarregar.Visible = False
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.LstEncontrados)
        Me.Panel7.Controls.Add(Me.PicLocalizadas)
        Me.Panel7.Location = New System.Drawing.Point(6, 2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(208, 597)
        Me.Panel7.TabIndex = 111
        '
        'LstEncontrados
        '
        Me.LstEncontrados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LstEncontrados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstEncontrados.HideSelection = False
        Me.LstEncontrados.LargeImageList = Me.ImageList1
        Me.LstEncontrados.Location = New System.Drawing.Point(0, 0)
        Me.LstEncontrados.Name = "LstEncontrados"
        Me.LstEncontrados.Size = New System.Drawing.Size(208, 597)
        Me.LstEncontrados.TabIndex = 1
        Me.LstEncontrados.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(150, 150)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'PicLocalizadas
        '
        Me.PicLocalizadas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicLocalizadas.Location = New System.Drawing.Point(210, 5)
        Me.PicLocalizadas.Name = "PicLocalizadas"
        Me.PicLocalizadas.Size = New System.Drawing.Size(10, 587)
        Me.PicLocalizadas.TabIndex = 0
        Me.PicLocalizadas.TabStop = False
        Me.PicLocalizadas.Visible = False
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel10.Controls.Add(Me.LblStagio)
        Me.Panel10.Controls.Add(Me.LblNumSoluçãoN)
        Me.Panel10.Controls.Add(Me.LblNumProcessoN)
        Me.Panel10.Controls.Add(Me.LblPlacaN)
        Me.Panel10.Controls.Add(Me.Label4)
        Me.Panel10.Controls.Add(Me.Panel14)
        Me.Panel10.Controls.Add(Me.Label3)
        Me.Panel10.Controls.Add(Me.Panel13)
        Me.Panel10.Controls.Add(Me.Label1)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(200, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1101, 57)
        Me.Panel10.TabIndex = 42
        '
        'LblStagio
        '
        Me.LblStagio.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblStagio.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblStagio.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblStagio.Location = New System.Drawing.Point(801, 27)
        Me.LblStagio.Name = "LblStagio"
        Me.LblStagio.Size = New System.Drawing.Size(269, 21)
        Me.LblStagio.TabIndex = 121
        Me.LblStagio.Text = "Stagio"
        Me.LblStagio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNumSoluçãoN
        '
        Me.LblNumSoluçãoN.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblNumSoluçãoN.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblNumSoluçãoN.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblNumSoluçãoN.Location = New System.Drawing.Point(587, 27)
        Me.LblNumSoluçãoN.Name = "LblNumSoluçãoN"
        Me.LblNumSoluçãoN.Size = New System.Drawing.Size(200, 21)
        Me.LblNumSoluçãoN.TabIndex = 120
        Me.LblNumSoluçãoN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNumProcessoN
        '
        Me.LblNumProcessoN.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblNumProcessoN.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblNumProcessoN.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblNumProcessoN.Location = New System.Drawing.Point(373, 27)
        Me.LblNumProcessoN.Name = "LblNumProcessoN"
        Me.LblNumProcessoN.Size = New System.Drawing.Size(200, 21)
        Me.LblNumProcessoN.TabIndex = 119
        Me.LblNumProcessoN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblPlacaN
        '
        Me.LblPlacaN.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblPlacaN.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblPlacaN.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblPlacaN.Location = New System.Drawing.Point(3, 27)
        Me.LblPlacaN.Name = "LblPlacaN"
        Me.LblPlacaN.Size = New System.Drawing.Size(570, 21)
        Me.LblPlacaN.TabIndex = 118
        Me.LblPlacaN.Text = "Dados do veículo"
        Me.LblPlacaN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(801, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(285, 21)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Stagio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel14.Location = New System.Drawing.Point(793, 4)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(1, 50)
        Me.Panel14.TabIndex = 116
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(587, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 21)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Num. processo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel13.Location = New System.Drawing.Point(579, 4)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(1, 50)
        Me.Panel13.TabIndex = 114
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(570, 21)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Dados do veículo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel15.Controls.Add(Me.ToolStrip2)
        Me.Panel15.Controls.Add(Me.Panel16)
        Me.Panel15.Controls.Add(Me.Panel17)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel15.Location = New System.Drawing.Point(0, 0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(200, 651)
        Me.Panel15.TabIndex = 115
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.LblFrontal, Me.ToolStripDropDownButton2, Me.LblTraseira, Me.ToolStripDropDownButton3, Me.LblLatEsq, Me.ToolStripDropDownButton4, Me.LblLatDir, Me.ToolStripDropDownButton5, Me.LblInterior, Me.ToolStripDropDownButton6, Me.LblPm})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 67)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(194, 584)
        Me.ToolStrip2.TabIndex = 40
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.AutoSize = False
        Me.ToolStripDropDownButton1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.VFrenteVetor
        Me.ToolStripDropDownButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(134, 70)
        Me.ToolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'LblFrontal
        '
        Me.LblFrontal.AutoSize = False
        Me.LblFrontal.BackColor = System.Drawing.Color.Black
        Me.LblFrontal.ForeColor = System.Drawing.Color.SlateGray
        Me.LblFrontal.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.LblFrontal.Name = "LblFrontal"
        Me.LblFrontal.Size = New System.Drawing.Size(134, 20)
        Me.LblFrontal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.AutoSize = False
        Me.ToolStripDropDownButton2.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.VtrasVetor
        Me.ToolStripDropDownButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ToolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(134, 70)
        Me.ToolStripDropDownButton2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'LblTraseira
        '
        Me.LblTraseira.AutoSize = False
        Me.LblTraseira.ForeColor = System.Drawing.Color.SlateGray
        Me.LblTraseira.Name = "LblTraseira"
        Me.LblTraseira.Size = New System.Drawing.Size(134, 20)
        Me.LblTraseira.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.AutoSize = False
        Me.ToolStripDropDownButton3.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.VLateEsq
        Me.ToolStripDropDownButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ToolStripDropDownButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(134, 70)
        Me.ToolStripDropDownButton3.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'LblLatEsq
        '
        Me.LblLatEsq.AutoSize = False
        Me.LblLatEsq.ForeColor = System.Drawing.Color.SlateGray
        Me.LblLatEsq.Name = "LblLatEsq"
        Me.LblLatEsq.Size = New System.Drawing.Size(134, 20)
        Me.LblLatEsq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripDropDownButton4
        '
        Me.ToolStripDropDownButton4.AutoSize = False
        Me.ToolStripDropDownButton4.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.VLatDir
        Me.ToolStripDropDownButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ToolStripDropDownButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton4.Name = "ToolStripDropDownButton4"
        Me.ToolStripDropDownButton4.Size = New System.Drawing.Size(134, 70)
        Me.ToolStripDropDownButton4.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'LblLatDir
        '
        Me.LblLatDir.AutoSize = False
        Me.LblLatDir.ForeColor = System.Drawing.Color.SlateGray
        Me.LblLatDir.Name = "LblLatDir"
        Me.LblLatDir.Size = New System.Drawing.Size(134, 20)
        Me.LblLatDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripDropDownButton5
        '
        Me.ToolStripDropDownButton5.AutoSize = False
        Me.ToolStripDropDownButton5.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.VInteriorVetor1
        Me.ToolStripDropDownButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ToolStripDropDownButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton5.Name = "ToolStripDropDownButton5"
        Me.ToolStripDropDownButton5.Size = New System.Drawing.Size(134, 70)
        Me.ToolStripDropDownButton5.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'LblInterior
        '
        Me.LblInterior.AutoSize = False
        Me.LblInterior.ForeColor = System.Drawing.Color.SlateGray
        Me.LblInterior.Name = "LblInterior"
        Me.LblInterior.Size = New System.Drawing.Size(134, 20)
        Me.LblInterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripDropDownButton6
        '
        Me.ToolStripDropDownButton6.AutoSize = False
        Me.ToolStripDropDownButton6.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripDropDownButton6.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.VAcessorios
        Me.ToolStripDropDownButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ToolStripDropDownButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton6.Name = "ToolStripDropDownButton6"
        Me.ToolStripDropDownButton6.Size = New System.Drawing.Size(134, 80)
        Me.ToolStripDropDownButton6.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolStripDropDownButton6.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90
        '
        'LblPm
        '
        Me.LblPm.AutoSize = False
        Me.LblPm.ForeColor = System.Drawing.Color.SlateGray
        Me.LblPm.Name = "LblPm"
        Me.LblPm.Size = New System.Drawing.Size(134, 20)
        Me.LblPm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel16.Controls.Add(Me.LblPlaca)
        Me.Panel16.Controls.Add(Me.Label6)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(199, 67)
        Me.Panel16.TabIndex = 41
        '
        'LblPlaca
        '
        Me.LblPlaca.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblPlaca.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblPlaca.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblPlaca.Location = New System.Drawing.Point(11, 27)
        Me.LblPlaca.Name = "LblPlaca"
        Me.LblPlaca.Size = New System.Drawing.Size(182, 21)
        Me.LblPlaca.TabIndex = 119
        Me.LblPlaca.Text = "Dados do veículo"
        Me.LblPlaca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label6.Location = New System.Drawing.Point(11, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(183, 21)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Partes do veiculo"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel17.Location = New System.Drawing.Point(199, 0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(1, 651)
        Me.Panel17.TabIndex = 42
        '
        'FrmNovoStudioAvaliacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 711)
        Me.Controls.Add(Me.PnnAreaTrabalho)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovoStudioAvaliacao"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovoStudioAvaliacao"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.PnnAreaTrabalho.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PicImagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.PicLocalizadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents LblTitulo As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents PnnAreaTrabalho As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents PicImagem As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RiscosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AmassadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel7 As Panel
    Friend WithEvents PicLocalizadas As PictureBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents PeçaIrrecuperávelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PeçaAusenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcabamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RiscosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ManchaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RasgosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents PeçaQuebradaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PeçaAusenteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents PinturaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesbotamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PercaDeTintaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MotorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MalFuncionamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FalaConstanteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FalhaIntermitenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents PeçaAusenteToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents PeçaQuabradaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VidrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TrincosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuebradoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents VidroAusenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PeçasEletronicasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MalFuncionamentoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FalhaConstanteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FalhaIntermitenteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TrRespostashecklist As TreeView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CorrosãoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents Panel9 As Panel
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents Panel10 As Panel
    Friend WithEvents LblStagio As Label
    Friend WithEvents LblNumSoluçãoN As Label
    Friend WithEvents LblNumProcessoN As Label
    Friend WithEvents LblPlacaN As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents BttCarregar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnRiscos As ToolStripButton
    Friend WithEvents BtnAmassado As ToolStripButton
    Friend WithEvents BtnImpossívelReparar As ToolStripButton
    Friend WithEvents BtnPeçaAusente As ToolStripButton
    Friend WithEvents BtnPinturaDesbotada As ToolStripButton
    Friend WithEvents BtnCorrosão As ToolStripButton
    Friend WithEvents BtnRasgos As ToolStripButton
    Friend WithEvents BtnManchas As ToolStripButton
    Friend WithEvents BtnAcabAusente As ToolStripButton
    Friend WithEvents ToolStripDropDownButton4 As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownButton5 As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownButton6 As ToolStripDropDownButton
    Friend WithEvents BtnAcabRisco As ToolStripButton
    Friend WithEvents BtnAcabQuebrado As ToolStripButton
    Friend WithEvents BtnPMAusente As ToolStripButton
    Friend WithEvents BtnPmQuebrado As ToolStripButton
    Friend WithEvents BtnPMFalha As ToolStripButton
    Friend WithEvents BtnPmSubst As ToolStripButton
    Friend WithEvents BtnVidroAusente As ToolStripButton
    Friend WithEvents BtnVidroQuebrado As ToolStripButton
    Friend WithEvents BtnVidroTrincado As ToolStripButton
    Friend WithEvents BtnPEAusente As ToolStripButton
    Friend WithEvents BtnPEQuebrado As ToolStripButton
    Friend WithEvents BtnPESubstituição As ToolStripButton
    Friend WithEvents BtnPEFalha As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents LblFrontal As ToolStripLabel
    Friend WithEvents LblTraseira As ToolStripLabel
    Friend WithEvents LblLatEsq As ToolStripLabel
    Friend WithEvents LblLatDir As ToolStripLabel
    Friend WithEvents LblInterior As ToolStripLabel
    Friend WithEvents LblPm As ToolStripLabel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents ToolStripDropDownButton3 As ToolStripDropDownButton
    Friend WithEvents LblPlaca As Label
    Friend WithEvents LstEncontrados As ListView
    Friend WithEvents ImageList1 As ImageList
End Class
