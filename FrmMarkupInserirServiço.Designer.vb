<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMarkupInserirServiço
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BttSalvarMarkup = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblTamamnho = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LblDescrição = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblAquisicao = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.LblRevenda = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.LblCustoTotal = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtMarkup = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.LblMkpSug = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LblNotificação = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
        CType(Me.TxtMarkup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 442)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(704, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 442)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(1, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(703, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 441)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(703, 1)
        Me.Panel4.TabIndex = 3
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(703, 28)
        Me.LblTitulo.TabIndex = 38
        Me.LblTitulo.Text = "Montar preço para venda"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.LblIdVistoria)
        Me.PnnInferior.Controls.Add(Me.LblIdSolução)
        Me.PnnInferior.Controls.Add(Me.LblIdmarca)
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Button1)
        Me.PnnInferior.Controls.Add(Me.BttSalvarMarkup)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 403)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(703, 38)
        Me.PnnInferior.TabIndex = 39
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
        Me.Panel5.Size = New System.Drawing.Size(357, 5)
        Me.Panel5.TabIndex = 27
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Button1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageIndex = 0
        Me.Button1.Location = New System.Drawing.Point(357, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 38)
        Me.Button1.TabIndex = 52
        Me.Button1.Text = "Cotar tercerização"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BttSalvarMarkup
        '
        Me.BttSalvarMarkup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvarMarkup.Dock = System.Windows.Forms.DockStyle.Right
        Me.BttSalvarMarkup.Enabled = False
        Me.BttSalvarMarkup.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttSalvarMarkup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvarMarkup.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttSalvarMarkup.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttSalvarMarkup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttSalvarMarkup.ImageIndex = 0
        Me.BttSalvarMarkup.Location = New System.Drawing.Point(530, 0)
        Me.BttSalvarMarkup.Name = "BttSalvarMarkup"
        Me.BttSalvarMarkup.Size = New System.Drawing.Size(173, 38)
        Me.BttSalvarMarkup.TabIndex = 51
        Me.BttSalvarMarkup.Text = "Salvar "
        Me.BttSalvarMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttSalvarMarkup.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gainsboro
        Me.Label14.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label14.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label14.Location = New System.Drawing.Point(12, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(678, 20)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Serviço a ser precificado"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(12, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(678, 20)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Custos envolvidos"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTamamnho
        '
        Me.LblTamamnho.AutoSize = True
        Me.LblTamamnho.ForeColor = System.Drawing.Color.SlateGray
        Me.LblTamamnho.Location = New System.Drawing.Point(153, 129)
        Me.LblTamamnho.Name = "LblTamamnho"
        Me.LblTamamnho.Size = New System.Drawing.Size(58, 17)
        Me.LblTamamnho.TabIndex = 95
        Me.LblTamamnho.Text = "00:00:00"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(41, 129)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 17)
        Me.Label17.TabIndex = 94
        Me.Label17.Text = "Tempo reservado"
        '
        'LblDescrição
        '
        Me.LblDescrição.AutoSize = True
        Me.LblDescrição.ForeColor = System.Drawing.Color.SlateGray
        Me.LblDescrição.Location = New System.Drawing.Point(153, 104)
        Me.LblDescrição.Name = "LblDescrição"
        Me.LblDescrição.Size = New System.Drawing.Size(63, 17)
        Me.LblDescrição.TabIndex = 93
        Me.LblDescrição.Text = "Descrição"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 17)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Descrição"
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.ForeColor = System.Drawing.Color.SlateGray
        Me.LblCodigo.Location = New System.Drawing.Point(153, 79)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(15, 17)
        Me.LblCodigo.TabIndex = 91
        Me.LblCodigo.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 17)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Código do produto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 210)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Ferramentas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 17)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "EPI"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 260)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 17)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Insumos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 316)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 17)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Custos operacionais"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.SlateGray
        Me.Label8.Location = New System.Drawing.Point(153, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 17)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "R$ 0.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.SlateGray
        Me.Label9.Location = New System.Drawing.Point(153, 235)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 17)
        Me.Label9.TabIndex = 101
        Me.Label9.Text = "R$ 0.00"
        '
        'LblAquisicao
        '
        Me.LblAquisicao.AutoSize = True
        Me.LblAquisicao.ForeColor = System.Drawing.Color.SlateGray
        Me.LblAquisicao.Location = New System.Drawing.Point(153, 316)
        Me.LblAquisicao.Name = "LblAquisicao"
        Me.LblAquisicao.Size = New System.Drawing.Size(51, 17)
        Me.LblAquisicao.TabIndex = 102
        Me.LblAquisicao.Text = "R$ 0.00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.SlateGray
        Me.Label11.Location = New System.Drawing.Point(153, 260)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 17)
        Me.Label11.TabIndex = 103
        Me.Label11.Text = "R$ 0.00"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel6.Location = New System.Drawing.Point(376, 186)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 211)
        Me.Panel6.TabIndex = 104
        '
        'LblRevenda
        '
        Me.LblRevenda.BackColor = System.Drawing.Color.Gainsboro
        Me.LblRevenda.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblRevenda.ForeColor = System.Drawing.Color.SlateGray
        Me.LblRevenda.Location = New System.Drawing.Point(406, 359)
        Me.LblRevenda.Name = "LblRevenda"
        Me.LblRevenda.Size = New System.Drawing.Size(276, 25)
        Me.LblRevenda.TabIndex = 112
        Me.LblRevenda.Text = "R$ 0,00"
        Me.LblRevenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(406, 338)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(101, 17)
        Me.Label28.TabIndex = 111
        Me.Label28.Text = "Valor p/ revenda"
        '
        'LblCustoTotal
        '
        Me.LblCustoTotal.BackColor = System.Drawing.Color.Gainsboro
        Me.LblCustoTotal.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblCustoTotal.ForeColor = System.Drawing.Color.SlateGray
        Me.LblCustoTotal.Location = New System.Drawing.Point(404, 307)
        Me.LblCustoTotal.Name = "LblCustoTotal"
        Me.LblCustoTotal.Size = New System.Drawing.Size(276, 25)
        Me.LblCustoTotal.TabIndex = 110
        Me.LblCustoTotal.Text = "R$ 0,00"
        Me.LblCustoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(404, 286)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(69, 17)
        Me.Label25.TabIndex = 109
        Me.Label25.Text = "Custo total"
        '
        'TxtMarkup
        '
        Me.TxtMarkup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMarkup.DecimalPlaces = 2
        Me.TxtMarkup.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtMarkup.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.TxtMarkup.Location = New System.Drawing.Point(519, 234)
        Me.TxtMarkup.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.TxtMarkup.Name = "TxtMarkup"
        Me.TxtMarkup.Size = New System.Drawing.Size(82, 24)
        Me.TxtMarkup.TabIndex = 108
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(404, 236)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(102, 17)
        Me.Label24.TabIndex = 107
        Me.Label24.Text = "Markup aplicado"
        '
        'LblMkpSug
        '
        Me.LblMkpSug.AutoSize = True
        Me.LblMkpSug.ForeColor = System.Drawing.Color.SlateGray
        Me.LblMkpSug.Location = New System.Drawing.Point(516, 210)
        Me.LblMkpSug.Name = "LblMkpSug"
        Me.LblMkpSug.Size = New System.Drawing.Size(43, 17)
        Me.LblMkpSug.TabIndex = 106
        Me.LblMkpSug.Text = "0,00%"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(404, 210)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 17)
        Me.Label19.TabIndex = 105
        Me.Label19.Text = "Markup sugerido"
        '
        'LblNotificação
        '
        Me.LblNotificação.AutoSize = True
        Me.LblNotificação.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNotificação.ForeColor = System.Drawing.Color.Red
        Me.LblNotificação.Location = New System.Drawing.Point(41, 368)
        Me.LblNotificação.Name = "LblNotificação"
        Me.LblNotificação.Size = New System.Drawing.Size(382, 17)
        Me.LblNotificação.TabIndex = 113
        Me.LblNotificação.Text = "Não foram identificados prestadores  selecionado para este serviço"
        Me.LblNotificação.Visible = False
        '
        'FrmMarkupInserirServiço
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(705, 442)
        Me.Controls.Add(Me.LblNotificação)
        Me.Controls.Add(Me.LblRevenda)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.LblCustoTotal)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TxtMarkup)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.LblMkpSug)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LblAquisicao)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblTamamnho)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.LblDescrição)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblCodigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMarkupInserirServiço"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMarkupInserirServiço"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        CType(Me.TxtMarkup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BttSalvarMarkup As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblTamamnho As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents LblDescrição As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblCodigo As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblAquisicao As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents LblRevenda As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents LblCustoTotal As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents TxtMarkup As NumericUpDown
    Friend WithEvents Label24 As Label
    Friend WithEvents LblMkpSug As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents LblNotificação As Label
    Friend WithEvents Button1 As Button
End Class
