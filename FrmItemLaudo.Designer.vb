<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemLaudo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItemLaudo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BtnProximoItem = New System.Windows.Forms.Button()
        Me.BtnSolicitarRevisao = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblDescricaoDoItem = New System.Windows.Forms.Label()
        Me.LblPartNumber = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblNomeCliente = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblIdLaudo = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblIdItemLaudo = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblNumNF = New System.Windows.Forms.Label()
        Me.LblChaveCliente = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PicReview = New System.Windows.Forms.PictureBox()
        Me.BttNf = New System.Windows.Forms.Button()
        Me.PicImagemNova = New System.Windows.Forms.PictureBox()
        Me.PicImagemUsada = New System.Windows.Forms.PictureBox()
        Me.LblCodFornecedor = New System.Windows.Forms.Label()
        Me.LblItemNf = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.PicReview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImagemNova, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImagemUsada, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(870, 24)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Laudos periciais"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel9)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Controls.Add(Me.BtnProximoItem)
        Me.PnnInferior.Controls.Add(Me.BtnSolicitarRevisao)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 655)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(870, 34)
        Me.PnnInferior.TabIndex = 69
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(482, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(351, 5)
        Me.Panel9.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(833, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(37, 34)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(8, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(16, 18)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BtnProximoItem
        '
        Me.BtnProximoItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnProximoItem.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnProximoItem.Enabled = False
        Me.BtnProximoItem.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnProximoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProximoItem.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BtnProximoItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnProximoItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProximoItem.Location = New System.Drawing.Point(241, 0)
        Me.BtnProximoItem.Name = "BtnProximoItem"
        Me.BtnProximoItem.Size = New System.Drawing.Size(241, 34)
        Me.BtnProximoItem.TabIndex = 32
        Me.BtnProximoItem.Text = "Próximo item"
        Me.BtnProximoItem.UseVisualStyleBackColor = True
        '
        'BtnSolicitarRevisao
        '
        Me.BtnSolicitarRevisao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnSolicitarRevisao.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnSolicitarRevisao.Enabled = False
        Me.BtnSolicitarRevisao.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnSolicitarRevisao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSolicitarRevisao.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BtnSolicitarRevisao.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnSolicitarRevisao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSolicitarRevisao.Location = New System.Drawing.Point(0, 0)
        Me.BtnSolicitarRevisao.Name = "BtnSolicitarRevisao"
        Me.BtnSolicitarRevisao.Size = New System.Drawing.Size(241, 34)
        Me.BtnSolicitarRevisao.TabIndex = 33
        Me.BtnSolicitarRevisao.Text = "Solicitar revisão do item"
        Me.BtnSolicitarRevisao.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(871, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 689)
        Me.Panel1.TabIndex = 70
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 689)
        Me.Panel2.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(12, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(421, 22)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Imagem da peça usada"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Location = New System.Drawing.Point(439, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(421, 22)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "Imagem da peça nova"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(12, 513)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(848, 22)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Dados da conferência"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "danfe.png")
        Me.ImageList1.Images.SetKeyName(1, "1486486291-arrows-swap-direction-orientation-switch_81211.png")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(135, 547)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 17)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "Descrição do item"
        '
        'LblDescricaoDoItem
        '
        Me.LblDescricaoDoItem.AutoSize = True
        Me.LblDescricaoDoItem.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblDescricaoDoItem.Location = New System.Drawing.Point(135, 570)
        Me.LblDescricaoDoItem.Name = "LblDescricaoDoItem"
        Me.LblDescricaoDoItem.Size = New System.Drawing.Size(109, 17)
        Me.LblDescricaoDoItem.TabIndex = 114
        Me.LblDescricaoDoItem.Text = "Descrição do item"
        '
        'LblPartNumber
        '
        Me.LblPartNumber.AutoSize = True
        Me.LblPartNumber.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblPartNumber.Location = New System.Drawing.Point(135, 619)
        Me.LblPartNumber.Name = "LblPartNumber"
        Me.LblPartNumber.Size = New System.Drawing.Size(0, 17)
        Me.LblPartNumber.TabIndex = 116
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(135, 596)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 17)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Part Number"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(750, 547)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 17)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "Nº do item na NF"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "danfe.png")
        Me.ImageList2.Images.SetKeyName(1, "1486486291-arrows-swap-direction-orientation-switch_81211.png")
        Me.ImageList2.Images.SetKeyName(2, "CarRepair_icon-icons.com_74915.png")
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Location = New System.Drawing.Point(12, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(848, 22)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "Dados da solicitação"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblNomeCliente
        '
        Me.LblNomeCliente.AutoSize = True
        Me.LblNomeCliente.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblNomeCliente.Location = New System.Drawing.Point(26, 96)
        Me.LblNomeCliente.Name = "LblNomeCliente"
        Me.LblNomeCliente.Size = New System.Drawing.Size(109, 17)
        Me.LblNomeCliente.TabIndex = 121
        Me.LblNomeCliente.Text = "Descrição do item"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 17)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Nome do cliente"
        '
        'LblIdLaudo
        '
        Me.LblIdLaudo.AutoSize = True
        Me.LblIdLaudo.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblIdLaudo.Location = New System.Drawing.Point(586, 96)
        Me.LblIdLaudo.Name = "LblIdLaudo"
        Me.LblIdLaudo.Size = New System.Drawing.Size(109, 17)
        Me.LblIdLaudo.TabIndex = 123
        Me.LblIdLaudo.Text = "Descrição do item"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(586, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 17)
        Me.Label12.TabIndex = 122
        Me.Label12.Text = "Número da solicitação"
        '
        'LblIdItemLaudo
        '
        Me.LblIdItemLaudo.AutoSize = True
        Me.LblIdItemLaudo.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblIdItemLaudo.Location = New System.Drawing.Point(750, 96)
        Me.LblIdItemLaudo.Name = "LblIdItemLaudo"
        Me.LblIdItemLaudo.Size = New System.Drawing.Size(109, 17)
        Me.LblIdItemLaudo.TabIndex = 125
        Me.LblIdItemLaudo.Text = "Descrição do item"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(750, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 17)
        Me.Label14.TabIndex = 124
        Me.Label14.Text = "Código do item"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(586, 547)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 17)
        Me.Label15.TabIndex = 126
        Me.Label15.Text = "Número NF"
        '
        'LblNumNF
        '
        Me.LblNumNF.AutoSize = True
        Me.LblNumNF.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblNumNF.Location = New System.Drawing.Point(586, 570)
        Me.LblNumNF.Name = "LblNumNF"
        Me.LblNumNF.Size = New System.Drawing.Size(15, 17)
        Me.LblNumNF.TabIndex = 127
        Me.LblNumNF.Text = "0"
        '
        'LblChaveCliente
        '
        Me.LblChaveCliente.AutoSize = True
        Me.LblChaveCliente.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblChaveCliente.Location = New System.Drawing.Point(586, 619)
        Me.LblChaveCliente.Name = "LblChaveCliente"
        Me.LblChaveCliente.Size = New System.Drawing.Size(109, 17)
        Me.LblChaveCliente.TabIndex = 129
        Me.LblChaveCliente.Text = "Descrição do item"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(586, 596)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 17)
        Me.Label11.TabIndex = 128
        Me.Label11.Text = "Chave do cliente"
        '
        'PicReview
        '
        Me.PicReview.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.kissclipart_review_clipart_post_it_note_computer_icons_clip_ar_7058b07da9db8383
        Me.PicReview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicReview.Location = New System.Drawing.Point(379, 3)
        Me.PicReview.Name = "PicReview"
        Me.PicReview.Size = New System.Drawing.Size(115, 90)
        Me.PicReview.TabIndex = 130
        Me.PicReview.TabStop = False
        Me.PicReview.Visible = False
        '
        'BttNf
        '
        Me.BttNf.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BttNf.FlatAppearance.BorderSize = 0
        Me.BttNf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttNf.ImageKey = "danfe.png"
        Me.BttNf.ImageList = Me.ImageList1
        Me.BttNf.Location = New System.Drawing.Point(12, 538)
        Me.BttNf.Name = "BttNf"
        Me.BttNf.Size = New System.Drawing.Size(117, 100)
        Me.BttNf.TabIndex = 112
        Me.BttNf.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BttNf.UseVisualStyleBackColor = False
        '
        'PicImagemNova
        '
        Me.PicImagemNova.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicImagemNova.Location = New System.Drawing.Point(439, 158)
        Me.PicImagemNova.Name = "PicImagemNova"
        Me.PicImagemNova.Size = New System.Drawing.Size(421, 352)
        Me.PicImagemNova.TabIndex = 73
        Me.PicImagemNova.TabStop = False
        '
        'PicImagemUsada
        '
        Me.PicImagemUsada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicImagemUsada.Location = New System.Drawing.Point(12, 158)
        Me.PicImagemUsada.Name = "PicImagemUsada"
        Me.PicImagemUsada.Size = New System.Drawing.Size(421, 352)
        Me.PicImagemUsada.TabIndex = 72
        Me.PicImagemUsada.TabStop = False
        '
        'LblCodFornecedor
        '
        Me.LblCodFornecedor.AutoSize = True
        Me.LblCodFornecedor.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblCodFornecedor.Location = New System.Drawing.Point(835, 618)
        Me.LblCodFornecedor.Name = "LblCodFornecedor"
        Me.LblCodFornecedor.Size = New System.Drawing.Size(15, 17)
        Me.LblCodFornecedor.TabIndex = 131
        Me.LblCodFornecedor.Text = "0"
        Me.LblCodFornecedor.Visible = False
        '
        'LblItemNf
        '
        Me.LblItemNf.AutoSize = True
        Me.LblItemNf.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblItemNf.Location = New System.Drawing.Point(750, 570)
        Me.LblItemNf.Name = "LblItemNf"
        Me.LblItemNf.Size = New System.Drawing.Size(15, 17)
        Me.LblItemNf.TabIndex = 132
        Me.LblItemNf.Text = "0"
        '
        'FrmItemLaudo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 689)
        Me.Controls.Add(Me.LblItemNf)
        Me.Controls.Add(Me.LblCodFornecedor)
        Me.Controls.Add(Me.PicReview)
        Me.Controls.Add(Me.LblChaveCliente)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LblNumNF)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.LblIdItemLaudo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LblIdLaudo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LblNomeCliente)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblPartNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblDescricaoDoItem)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BttNf)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PicImagemNova)
        Me.Controls.Add(Me.PicImagemUsada)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmItemLaudo"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmItemLaudo"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.PicReview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImagemNova, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImagemUsada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PicImagemUsada As PictureBox
    Friend WithEvents PicImagemNova As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BttNf As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label5 As Label
    Friend WithEvents LblDescricaoDoItem As Label
    Friend WithEvents LblPartNumber As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents BtnProximoItem As Button
    Friend WithEvents BtnSolicitarRevisao As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents LblNomeCliente As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblIdLaudo As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LblIdItemLaudo As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents LblNumNF As Label
    Friend WithEvents LblChaveCliente As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents PicReview As PictureBox
    Friend WithEvents LblCodFornecedor As Label
    Friend WithEvents LblItemNf As Label
End Class
