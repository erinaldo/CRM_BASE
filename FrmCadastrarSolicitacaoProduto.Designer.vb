<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCadastrarSolicitacaoProduto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCadastrarSolicitacaoProduto))
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnSalvar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtPartNumber = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtDescricao = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbCategria = New System.Windows.Forms.ComboBox()
        Me.CmbFabricante = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BttAddSubcategoria = New System.Windows.Forms.Button()
        Me.BttFabricante = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(499, 26)
        Me.LblTitulo.TabIndex = 37
        Me.LblTitulo.Text = "Avaliação de avarias"
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
        Me.PnnInferior.Location = New System.Drawing.Point(1, 262)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(499, 36)
        Me.PnnInferior.TabIndex = 38
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
        Me.Panel5.Size = New System.Drawing.Size(425, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.Button1)
        Me.Panel12.Controls.Add(Me.BtnSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(425, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(74, 36)
        Me.Panel12.TabIndex = 28
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(44, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(18, 19)
        Me.Button1.TabIndex = 29
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnSalvar
        '
        Me.BtnSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BtnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnSalvar.FlatAppearance.BorderSize = 0
        Me.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalvar.Location = New System.Drawing.Point(10, 8)
        Me.BtnSalvar.Name = "BtnSalvar"
        Me.BtnSalvar.Size = New System.Drawing.Size(18, 19)
        Me.BtnSalvar.TabIndex = 28
        Me.BtnSalvar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 298)
        Me.Panel1.TabIndex = 39
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(500, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 298)
        Me.Panel2.TabIndex = 40
        '
        'TxtPartNumber
        '
        Me.TxtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartNumber.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtPartNumber.Location = New System.Drawing.Point(18, 60)
        Me.TxtPartNumber.Name = "TxtPartNumber"
        Me.TxtPartNumber.Size = New System.Drawing.Size(147, 21)
        Me.TxtPartNumber.TabIndex = 147
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 17)
        Me.Label12.TabIndex = 146
        Me.Label12.Text = "Part number"
        '
        'TxtDescricao
        '
        Me.TxtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescricao.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescricao.Location = New System.Drawing.Point(18, 110)
        Me.TxtDescricao.Name = "TxtDescricao"
        Me.TxtDescricao.Size = New System.Drawing.Size(256, 21)
        Me.TxtDescricao.TabIndex = 149
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Descrição"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Subcategoria"
        '
        'CmbCategria
        '
        Me.CmbCategria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCategria.FormattingEnabled = True
        Me.CmbCategria.Location = New System.Drawing.Point(18, 162)
        Me.CmbCategria.Name = "CmbCategria"
        Me.CmbCategria.Size = New System.Drawing.Size(232, 23)
        Me.CmbCategria.TabIndex = 151
        '
        'CmbFabricante
        '
        Me.CmbFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbFabricante.FormattingEnabled = True
        Me.CmbFabricante.Location = New System.Drawing.Point(18, 218)
        Me.CmbFabricante.Name = "CmbFabricante"
        Me.CmbFabricante.Size = New System.Drawing.Size(232, 23)
        Me.CmbFabricante.TabIndex = 153
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "Fabricante"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(295, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 17)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "Imagem da peça"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.unavailable
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(298, 60)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(186, 181)
        Me.PictureBox1.TabIndex = 155
        Me.PictureBox1.TabStop = False
        '
        'BttAddSubcategoria
        '
        Me.BttAddSubcategoria.BackgroundImage = CType(resources.GetObject("BttAddSubcategoria.BackgroundImage"), System.Drawing.Image)
        Me.BttAddSubcategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddSubcategoria.FlatAppearance.BorderSize = 0
        Me.BttAddSubcategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddSubcategoria.Location = New System.Drawing.Point(256, 163)
        Me.BttAddSubcategoria.Name = "BttAddSubcategoria"
        Me.BttAddSubcategoria.Size = New System.Drawing.Size(18, 19)
        Me.BttAddSubcategoria.TabIndex = 156
        Me.BttAddSubcategoria.UseVisualStyleBackColor = True
        '
        'BttFabricante
        '
        Me.BttFabricante.BackgroundImage = CType(resources.GetObject("BttFabricante.BackgroundImage"), System.Drawing.Image)
        Me.BttFabricante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFabricante.FlatAppearance.BorderSize = 0
        Me.BttFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFabricante.Location = New System.Drawing.Point(256, 222)
        Me.BttFabricante.Name = "BttFabricante"
        Me.BttFabricante.Size = New System.Drawing.Size(18, 19)
        Me.BttFabricante.TabIndex = 157
        Me.BttFabricante.UseVisualStyleBackColor = True
        '
        'FrmCadastrarSolicitacaoProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 298)
        Me.Controls.Add(Me.BttFabricante)
        Me.Controls.Add(Me.BttAddSubcategoria)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbFabricante)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbCategria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtDescricao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPartNumber)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCadastrarSolicitacaoProduto"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCadastrarSolicitacaoProduto"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BtnSalvar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtPartNumber As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtDescricao As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CmbCategria As ComboBox
    Friend WithEvents CmbFabricante As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BttAddSubcategoria As Button
    Friend WithEvents BttFabricante As Button
End Class
