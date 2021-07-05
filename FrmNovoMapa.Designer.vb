<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovoMapa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNovoMapa))
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnSalvar = New System.Windows.Forms.Button()
        Me.BttSetores = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BttFunções = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PicSetores = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtCPF = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblNomeCompleto = New System.Windows.Forms.Label()
        Me.LblApelido = New System.Windows.Forms.Label()
        Me.LblTelefone = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblCelular = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PicSetores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(956, 24)
        Me.LblTitulo.TabIndex = 43
        Me.LblTitulo.Text = "Mapas levantados"
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
        Me.PnnInferior.Controls.Add(Me.BttSetores)
        Me.PnnInferior.Controls.Add(Me.BttFunções)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 770)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(956, 34)
        Me.PnnInferior.TabIndex = 44
        '
        'LblIdVistoria
        '
        Me.LblIdVistoria.AutoSize = True
        Me.LblIdVistoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdVistoria.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdVistoria.Location = New System.Drawing.Point(376, 5)
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
        Me.LblIdSolução.Location = New System.Drawing.Point(361, 5)
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
        Me.LblIdmarca.Location = New System.Drawing.Point(346, 5)
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
        Me.Panel5.Location = New System.Drawing.Point(346, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(536, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.Button1)
        Me.Panel12.Controls.Add(Me.BtnSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(882, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(74, 34)
        Me.Panel12.TabIndex = 49
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
        'BttSetores
        '
        Me.BttSetores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSetores.Dock = System.Windows.Forms.DockStyle.Left
        Me.BttSetores.Enabled = False
        Me.BttSetores.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttSetores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSetores.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttSetores.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttSetores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttSetores.ImageKey = "add-1-icon.png"
        Me.BttSetores.ImageList = Me.ImageList1
        Me.BttSetores.Location = New System.Drawing.Point(173, 0)
        Me.BttSetores.Name = "BttSetores"
        Me.BttSetores.Size = New System.Drawing.Size(173, 34)
        Me.BttSetores.TabIndex = 51
        Me.BttSetores.Text = "Cadatrar setor"
        Me.BttSetores.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttSetores.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Cancel_40972.png")
        Me.ImageList1.Images.SetKeyName(1, "DocumentEdit_40924.png")
        Me.ImageList1.Images.SetKeyName(2, "add-1-icon.png")
        '
        'BttFunções
        '
        Me.BttFunções.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFunções.Dock = System.Windows.Forms.DockStyle.Left
        Me.BttFunções.Enabled = False
        Me.BttFunções.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttFunções.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFunções.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttFunções.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttFunções.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttFunções.ImageKey = "add-1-icon.png"
        Me.BttFunções.ImageList = Me.ImageList1
        Me.BttFunções.Location = New System.Drawing.Point(0, 0)
        Me.BttFunções.Name = "BttFunções"
        Me.BttFunções.Size = New System.Drawing.Size(173, 34)
        Me.BttFunções.TabIndex = 52
        Me.BttFunções.Text = "Cadastrar função"
        Me.BttFunções.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttFunções.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(13, 192)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(935, 573)
        Me.TabControl1.TabIndex = 45
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PicSetores)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(927, 542)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Setores"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PicSetores
        '
        Me.PicSetores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicSetores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicSetores.Location = New System.Drawing.Point(3, 3)
        Me.PicSetores.Name = "PicSetores"
        Me.PicSetores.Size = New System.Drawing.Size(921, 536)
        Me.PicSetores.TabIndex = 0
        Me.PicSetores.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(10, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(938, 18)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "Dados do cliente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(10, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(938, 18)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "Mapas disponíveis para análise"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 17)
        Me.Label12.TabIndex = 180
        Me.Label12.Text = "Documento"
        '
        'TxtCPF
        '
        Me.TxtCPF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCPF.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCPF.Location = New System.Drawing.Point(142, 70)
        Me.TxtCPF.Mask = "00,000,000/0000-00"
        Me.TxtCPF.Name = "TxtCPF"
        Me.TxtCPF.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtCPF.Size = New System.Drawing.Size(199, 21)
        Me.TxtCPF.TabIndex = 0
        Me.TxtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(550, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 17)
        Me.Label10.TabIndex = 210
        Me.Label10.Text = "Apelido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "Nome completo"
        '
        'LblNomeCompleto
        '
        Me.LblNomeCompleto.AutoSize = True
        Me.LblNomeCompleto.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblNomeCompleto.Location = New System.Drawing.Point(139, 101)
        Me.LblNomeCompleto.Name = "LblNomeCompleto"
        Me.LblNomeCompleto.Size = New System.Drawing.Size(11, 17)
        Me.LblNomeCompleto.TabIndex = 213
        Me.LblNomeCompleto.Text = " "
        '
        'LblApelido
        '
        Me.LblApelido.AutoSize = True
        Me.LblApelido.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblApelido.Location = New System.Drawing.Point(621, 101)
        Me.LblApelido.Name = "LblApelido"
        Me.LblApelido.Size = New System.Drawing.Size(11, 17)
        Me.LblApelido.TabIndex = 214
        Me.LblApelido.Text = " "
        '
        'LblTelefone
        '
        Me.LblTelefone.AutoSize = True
        Me.LblTelefone.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblTelefone.Location = New System.Drawing.Point(139, 130)
        Me.LblTelefone.Name = "LblTelefone"
        Me.LblTelefone.Size = New System.Drawing.Size(11, 17)
        Me.LblTelefone.TabIndex = 216
        Me.LblTelefone.Text = " "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 215
        Me.Label5.Text = "Telefone"
        '
        'LblCelular
        '
        Me.LblCelular.AutoSize = True
        Me.LblCelular.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblCelular.Location = New System.Drawing.Point(373, 130)
        Me.LblCelular.Name = "LblCelular"
        Me.LblCelular.Size = New System.Drawing.Size(11, 17)
        Me.LblCelular.TabIndex = 218
        Me.LblCelular.Text = " "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(294, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 17)
        Me.Label6.TabIndex = 217
        Me.Label6.Text = "Celular"
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblEmail.Location = New System.Drawing.Point(621, 130)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(11, 17)
        Me.LblEmail.TabIndex = 220
        Me.LblEmail.Text = " "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(550, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 17)
        Me.Label8.TabIndex = 219
        Me.Label8.Text = "E-mail"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 803)
        Me.Panel1.TabIndex = 221
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(957, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 803)
        Me.Panel2.TabIndex = 222
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 804)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(958, 1)
        Me.Panel3.TabIndex = 223
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(958, 1)
        Me.Panel4.TabIndex = 224
        '
        'FrmNovoMapa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(958, 805)
        Me.Controls.Add(Me.LblEmail)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblCelular)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblTelefone)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblApelido)
        Me.Controls.Add(Me.LblNomeCompleto)
        Me.Controls.Add(Me.TxtCPF)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovoMapa"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovoMapa"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.PicSetores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents PicSetores As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents BtnSalvar As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtCPF As MaskedTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblNomeCompleto As Label
    Friend WithEvents LblApelido As Label
    Friend WithEvents LblTelefone As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblCelular As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblEmail As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents BttSetores As Button
    Friend WithEvents BttFunções As Button
    Friend WithEvents ImageList1 As ImageList
End Class
