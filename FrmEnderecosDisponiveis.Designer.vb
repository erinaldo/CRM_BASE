<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEnderecosDisponiveis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEnderecosDisponiveis))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttBuscarCliente = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TrEstoque = New System.Windows.Forms.TreeView()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LStEstoques = New System.Windows.Forms.ListView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblQtDirecionada = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtQtdadeMovimentar = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtQtdadeDisponivel = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.TxtQtdadeMovimentar, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(936, 26)
        Me.Label1.TabIndex = 187
        Me.Label1.Text = "Endereços disponíveis"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(0, 755)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(938, 36)
        Me.PnnInferior.TabIndex = 188
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(866, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttBuscarCliente)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(866, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(72, 36)
        Me.Panel12.TabIndex = 29
        '
        'BttBuscarCliente
        '
        Me.BttBuscarCliente.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttBuscarCliente.FlatAppearance.BorderSize = 0
        Me.BttBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttBuscarCliente.Location = New System.Drawing.Point(10, 8)
        Me.BttBuscarCliente.Name = "BttBuscarCliente"
        Me.BttBuscarCliente.Size = New System.Drawing.Size(18, 22)
        Me.BttBuscarCliente.TabIndex = 25
        Me.BttBuscarCliente.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(46, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(18, 22)
        Me.BttFechar.TabIndex = 26
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(937, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 549)
        Me.Panel1.TabIndex = 189
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 549)
        Me.Panel2.TabIndex = 190
        '
        'TrEstoque
        '
        Me.TrEstoque.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TrEstoque.Location = New System.Drawing.Point(0, 549)
        Me.TrEstoque.Name = "TrEstoque"
        Me.TrEstoque.Size = New System.Drawing.Size(938, 206)
        Me.TrEstoque.TabIndex = 192
        Me.TrEstoque.Visible = False
        '
        'ListView2
        '
        Me.ListView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView2.CheckBoxes = True
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView2.HideSelection = False
        Me.ListView2.LargeImageList = Me.ImageList1
        Me.ListView2.Location = New System.Drawing.Point(1, 297)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(936, 252)
        Me.ListView2.TabIndex = 191
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "estoque.png")
        Me.ImageList1.Images.SetKeyName(1, "cargo_1_icon.png")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "add_1_icon.png")
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LStEstoques)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.LblQtDirecionada)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.TxtQtdadeMovimentar)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.TxtQtdadeDisponivel)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(1, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(936, 271)
        Me.Panel3.TabIndex = 193
        '
        'LStEstoques
        '
        Me.LStEstoques.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LStEstoques.CheckBoxes = True
        Me.LStEstoques.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LStEstoques.Enabled = False
        Me.LStEstoques.HideSelection = False
        Me.LStEstoques.LargeImageList = Me.ImageList1
        Me.LStEstoques.Location = New System.Drawing.Point(0, 126)
        Me.LStEstoques.Name = "LStEstoques"
        Me.LStEstoques.Size = New System.Drawing.Size(936, 144)
        Me.LStEstoques.TabIndex = 202
        Me.LStEstoques.UseCompatibleStateImageBehavior = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(0, 270)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(936, 1)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = "Endereços disponíveis"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblQtDirecionada
        '
        Me.LblQtDirecionada.AutoSize = True
        Me.LblQtDirecionada.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblQtDirecionada.Location = New System.Drawing.Point(824, 67)
        Me.LblQtDirecionada.Name = "LblQtDirecionada"
        Me.LblQtDirecionada.Size = New System.Drawing.Size(15, 17)
        Me.LblQtDirecionada.TabIndex = 200
        Me.LblQtDirecionada.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(824, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 17)
        Me.Label6.TabIndex = 199
        Me.Label6.Text = "Qt direcionada"
        '
        'TxtQtdadeMovimentar
        '
        Me.TxtQtdadeMovimentar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtQtdadeMovimentar.Location = New System.Drawing.Point(143, 65)
        Me.TxtQtdadeMovimentar.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.TxtQtdadeMovimentar.Name = "TxtQtdadeMovimentar"
        Me.TxtQtdadeMovimentar.Size = New System.Drawing.Size(130, 19)
        Me.TxtQtdadeMovimentar.TabIndex = 198
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(140, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 17)
        Me.Label4.TabIndex = 197
        Me.Label4.Text = "Qt a ser movimentado"
        '
        'TxtQtdadeDisponivel
        '
        Me.TxtQtdadeDisponivel.AutoSize = True
        Me.TxtQtdadeDisponivel.ForeColor = System.Drawing.Color.DarkOrange
        Me.TxtQtdadeDisponivel.Location = New System.Drawing.Point(40, 67)
        Me.TxtQtdadeDisponivel.Name = "TxtQtdadeDisponivel"
        Me.TxtQtdadeDisponivel.Size = New System.Drawing.Size(15, 17)
        Me.TxtQtdadeDisponivel.TabIndex = 196
        Me.TxtQtdadeDisponivel.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(40, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 195
        Me.Label9.Text = "Qt disponível"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(6, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(924, 19)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Endereços disponíveis"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(3, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(924, 19)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Endereços disponíveis"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmEnderecosDisponiveis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 791)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TrEstoque)
        Me.Controls.Add(Me.PnnInferior)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmEnderecosDisponiveis"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEnderecosDisponiveis"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.TxtQtdadeMovimentar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttBuscarCliente As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TrEstoque As TreeView
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtQtdadeDisponivel As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtQtdadeMovimentar As NumericUpDown
    Friend WithEvents LblQtDirecionada As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LStEstoques As ListView
    Friend WithEvents Label5 As Label
End Class
