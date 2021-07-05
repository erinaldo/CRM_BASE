<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNF_Exibir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNF_Exibir))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BtnValidar = New System.Windows.Forms.Button()
        Me.BtnSolicitarRevisao = New System.Windows.Forms.Button()
        Me.PicNF = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblPctg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TxtItemNf = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDescricao = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblMkX = New System.Windows.Forms.Label()
        Me.LblMkY = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.PicNF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(800, 22)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Nota fiscal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel9)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Controls.Add(Me.BtnValidar)
        Me.PnnInferior.Controls.Add(Me.BtnSolicitarRevisao)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 707)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(800, 32)
        Me.PnnInferior.TabIndex = 70
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(482, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(277, 5)
        Me.Panel9.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(759, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(41, 32)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(13, 7)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(14, 17)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BtnValidar
        '
        Me.BtnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnValidar.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnValidar.Enabled = False
        Me.BtnValidar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnValidar.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BtnValidar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnValidar.Location = New System.Drawing.Point(241, 0)
        Me.BtnValidar.Name = "BtnValidar"
        Me.BtnValidar.Size = New System.Drawing.Size(241, 32)
        Me.BtnValidar.TabIndex = 34
        Me.BtnValidar.Text = "Validar item"
        Me.BtnValidar.UseVisualStyleBackColor = True
        '
        'BtnSolicitarRevisao
        '
        Me.BtnSolicitarRevisao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnSolicitarRevisao.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnSolicitarRevisao.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnSolicitarRevisao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSolicitarRevisao.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BtnSolicitarRevisao.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSolicitarRevisao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSolicitarRevisao.Location = New System.Drawing.Point(0, 0)
        Me.BtnSolicitarRevisao.Name = "BtnSolicitarRevisao"
        Me.BtnSolicitarRevisao.Size = New System.Drawing.Size(241, 32)
        Me.BtnSolicitarRevisao.TabIndex = 35
        Me.BtnSolicitarRevisao.Text = "Solicitar revisão do item"
        Me.BtnSolicitarRevisao.UseVisualStyleBackColor = True
        '
        'PicNF
        '
        Me.PicNF.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PicNF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicNF.Location = New System.Drawing.Point(7, 14)
        Me.PicNF.Name = "PicNF"
        Me.PicNF.Size = New System.Drawing.Size(281, 358)
        Me.PicNF.TabIndex = 71
        Me.PicNF.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(801, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 739)
        Me.Panel1.TabIndex = 72
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 739)
        Me.Panel2.TabIndex = 73
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.PicNF)
        Me.Panel3.Location = New System.Drawing.Point(1, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(800, 483)
        Me.Panel3.TabIndex = 74
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.LblPctg})
        Me.StatusStrip1.Location = New System.Drawing.Point(666, 552)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(134, 26)
        Me.StatusStrip1.TabIndex = 72
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.zoomin_zoom_search_find_1531
        Me.ToolStripStatusLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 20)
        Me.ToolStripStatusLabel1.Text = " "
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel2.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.zoomout_zoom_search_find_1530
        Me.ToolStripStatusLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(39, 20)
        Me.ToolStripStatusLabel2.Text = " "
        '
        'LblPctg
        '
        Me.LblPctg.AutoSize = False
        Me.LblPctg.BackColor = System.Drawing.SystemColors.Control
        Me.LblPctg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LblPctg.Font = New System.Drawing.Font("Calibri", 7.0!)
        Me.LblPctg.ForeColor = System.Drawing.Color.SlateGray
        Me.LblPctg.Name = "LblPctg"
        Me.LblPctg.Size = New System.Drawing.Size(39, 20)
        Me.LblPctg.Text = "100%"
        '
        'TxtItemNf
        '
        Me.TxtItemNf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtItemNf.Enabled = False
        Me.TxtItemNf.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtItemNf.Location = New System.Drawing.Point(18, 655)
        Me.TxtItemNf.Name = "TxtItemNf"
        Me.TxtItemNf.Size = New System.Drawing.Size(149, 21)
        Me.TxtItemNf.TabIndex = 120
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 636)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 17)
        Me.Label10.TabIndex = 119
        Me.Label10.Text = "Número do item na nota"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(230, 636)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 17)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Descrição procurada"
        '
        'LblDescricao
        '
        Me.LblDescricao.AutoSize = True
        Me.LblDescricao.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblDescricao.Location = New System.Drawing.Point(230, 659)
        Me.LblDescricao.Name = "LblDescricao"
        Me.LblDescricao.Size = New System.Drawing.Size(15, 17)
        Me.LblDescricao.TabIndex = 128
        Me.LblDescricao.Text = "0"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(12, 591)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(784, 22)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Dados da conferência"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Location = New System.Drawing.Point(12, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(784, 22)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Imagem registrada da NF"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblMkX
        '
        Me.LblMkX.AutoSize = True
        Me.LblMkX.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblMkX.Location = New System.Drawing.Point(490, 659)
        Me.LblMkX.Name = "LblMkX"
        Me.LblMkX.Size = New System.Drawing.Size(15, 17)
        Me.LblMkX.TabIndex = 131
        Me.LblMkX.Text = "0"
        Me.LblMkX.Visible = False
        '
        'LblMkY
        '
        Me.LblMkY.AutoSize = True
        Me.LblMkY.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblMkY.Location = New System.Drawing.Point(580, 659)
        Me.LblMkY.Name = "LblMkY"
        Me.LblMkY.Size = New System.Drawing.Size(15, 17)
        Me.LblMkY.TabIndex = 132
        Me.LblMkY.Text = "0"
        Me.LblMkY.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "—Pngtree—finger next_3549983.png")
        '
        'FrmNF_Exibir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 739)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LblMkY)
        Me.Controls.Add(Me.LblMkX)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblDescricao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtItemNf)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNF_Exibir"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNF_Exibir"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.PicNF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents PicNF As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents LblPctg As ToolStripStatusLabel
    Friend WithEvents TxtItemNf As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblDescricao As Label
    Friend WithEvents BtnValidar As Button
    Friend WithEvents BtnSolicitarRevisao As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblMkX As Label
    Friend WithEvents LblMkY As Label
    Friend WithEvents ImageList1 As ImageList
End Class
