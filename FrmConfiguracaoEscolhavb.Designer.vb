<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracaoEscolhavb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfiguracaoEscolhavb))
        Me.BttLogout = New System.Windows.Forms.Button()
        Me.BttEncerra = New System.Windows.Forms.Button()
        Me.BttConfig = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'BttLogout
        '
        Me.BttLogout.FlatAppearance.BorderSize = 0
        Me.BttLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttLogout.ImageIndex = 0
        Me.BttLogout.ImageList = Me.ImageList1
        Me.BttLogout.Location = New System.Drawing.Point(12, 43)
        Me.BttLogout.Name = "BttLogout"
        Me.BttLogout.Size = New System.Drawing.Size(210, 161)
        Me.BttLogout.TabIndex = 0
        Me.BttLogout.Text = "Deslogar"
        Me.BttLogout.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BttLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.BttLogout.UseVisualStyleBackColor = True
        '
        'BttEncerra
        '
        Me.BttEncerra.FlatAppearance.BorderSize = 0
        Me.BttEncerra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttEncerra.ImageIndex = 1
        Me.BttEncerra.ImageList = Me.ImageList1
        Me.BttEncerra.Location = New System.Drawing.Point(292, 43)
        Me.BttEncerra.Name = "BttEncerra"
        Me.BttEncerra.Size = New System.Drawing.Size(210, 161)
        Me.BttEncerra.TabIndex = 1
        Me.BttEncerra.Text = "Sair"
        Me.BttEncerra.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BttEncerra.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.BttEncerra.UseVisualStyleBackColor = True
        '
        'BttConfig
        '
        Me.BttConfig.FlatAppearance.BorderSize = 0
        Me.BttConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttConfig.ImageIndex = 2
        Me.BttConfig.ImageList = Me.ImageList1
        Me.BttConfig.Location = New System.Drawing.Point(578, 43)
        Me.BttConfig.Name = "BttConfig"
        Me.BttConfig.Size = New System.Drawing.Size(210, 161)
        Me.BttConfig.TabIndex = 2
        Me.BttConfig.Text = "Configurações"
        Me.BttConfig.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BttConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.BttConfig.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(803, 24)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Solicitar laudos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel9)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 210)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(803, 34)
        Me.PnnInferior.TabIndex = 70
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(755, 5)
        Me.Panel9.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(755, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(48, 34)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(15, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(16, 18)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(804, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 244)
        Me.Panel1.TabIndex = 71
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 244)
        Me.Panel2.TabIndex = 72
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "iconfinder-key-4341299_120569 (1).png")
        Me.ImageList1.Images.SetKeyName(1, "systemshutdown_103390.png")
        Me.ImageList1.Images.SetKeyName(2, "kisspng-innovation-computer-icons-innovator-innovacion-5b367622e11155.23432462153" &
        "02958429219.png")
        '
        'FrmConfiguracaoEscolhavb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 244)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BttConfig)
        Me.Controls.Add(Me.BttEncerra)
        Me.Controls.Add(Me.BttLogout)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmConfiguracaoEscolhavb"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmConfiguracaoEscolhavb"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BttLogout As Button
    Friend WithEvents BttEncerra As Button
    Friend WithEvents BttConfig As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
