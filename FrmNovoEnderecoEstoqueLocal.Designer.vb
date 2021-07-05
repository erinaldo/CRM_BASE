<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovoEnderecoEstoqueLocal
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NmQtInserir = New System.Windows.Forms.NumericUpDown()
        Me.TxtNomeEstoque = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttBuscarCliente = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPeso = New System.Windows.Forms.NumericUpDown()
        Me.TxtProfundidade = New System.Windows.Forms.NumericUpDown()
        Me.TxtLargura = New System.Windows.Forms.NumericUpDown()
        Me.TxtAltura = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        CType(Me.NmQtInserir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.TxtPeso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProfundidade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtLargura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAltura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(254, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 17)
        Me.Label3.TabIndex = 198
        Me.Label3.Text = "quadras"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "Inserir"
        '
        'NmQtInserir
        '
        Me.NmQtInserir.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NmQtInserir.Location = New System.Drawing.Point(128, 58)
        Me.NmQtInserir.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NmQtInserir.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NmQtInserir.Name = "NmQtInserir"
        Me.NmQtInserir.Size = New System.Drawing.Size(120, 20)
        Me.NmQtInserir.TabIndex = 196
        Me.NmQtInserir.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtNomeEstoque
        '
        Me.TxtNomeEstoque.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeEstoque.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeEstoque.Location = New System.Drawing.Point(128, 47)
        Me.TxtNomeEstoque.Name = "TxtNomeEstoque"
        Me.TxtNomeEstoque.Size = New System.Drawing.Size(234, 21)
        Me.TxtNomeEstoque.TabIndex = 195
        Me.TxtNomeEstoque.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 17)
        Me.Label6.TabIndex = 194
        Me.Label6.Text = "Nome do endereço"
        Me.Label6.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(346, 28)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Novo endereço para o andar selecionado"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 195)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(346, 38)
        Me.PnnInferior.TabIndex = 192
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(264, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttBuscarCliente)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(264, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(82, 38)
        Me.Panel12.TabIndex = 29
        '
        'BttBuscarCliente
        '
        Me.BttBuscarCliente.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttBuscarCliente.Enabled = False
        Me.BttBuscarCliente.FlatAppearance.BorderSize = 0
        Me.BttBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttBuscarCliente.Location = New System.Drawing.Point(12, 8)
        Me.BttBuscarCliente.Name = "BttBuscarCliente"
        Me.BttBuscarCliente.Size = New System.Drawing.Size(20, 23)
        Me.BttBuscarCliente.TabIndex = 25
        Me.BttBuscarCliente.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(53, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 23)
        Me.BttFechar.TabIndex = 26
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(1, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(346, 1)
        Me.Panel3.TabIndex = 191
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(347, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 233)
        Me.Panel2.TabIndex = 190
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 233)
        Me.Panel1.TabIndex = 189
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(254, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 17)
        Me.Label9.TabIndex = 210
        Me.Label9.Text = "Kg"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(254, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 17)
        Me.Label8.TabIndex = 209
        Me.Label8.Text = "mm"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(254, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 17)
        Me.Label5.TabIndex = 208
        Me.Label5.Text = "mm"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(254, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 17)
        Me.Label4.TabIndex = 207
        Me.Label4.Text = "mm"
        '
        'TxtPeso
        '
        Me.TxtPeso.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPeso.DecimalPlaces = 3
        Me.TxtPeso.Enabled = False
        Me.TxtPeso.Location = New System.Drawing.Point(128, 150)
        Me.TxtPeso.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(120, 20)
        Me.TxtPeso.TabIndex = 206
        '
        'TxtProfundidade
        '
        Me.TxtProfundidade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtProfundidade.Enabled = False
        Me.TxtProfundidade.Location = New System.Drawing.Point(128, 127)
        Me.TxtProfundidade.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.TxtProfundidade.Name = "TxtProfundidade"
        Me.TxtProfundidade.Size = New System.Drawing.Size(120, 20)
        Me.TxtProfundidade.TabIndex = 205
        '
        'TxtLargura
        '
        Me.TxtLargura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLargura.Enabled = False
        Me.TxtLargura.Location = New System.Drawing.Point(128, 104)
        Me.TxtLargura.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.TxtLargura.Name = "TxtLargura"
        Me.TxtLargura.Size = New System.Drawing.Size(120, 20)
        Me.TxtLargura.TabIndex = 204
        '
        'TxtAltura
        '
        Me.TxtAltura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAltura.Location = New System.Drawing.Point(128, 81)
        Me.TxtAltura.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.TxtAltura.Name = "TxtAltura"
        Me.TxtAltura.Size = New System.Drawing.Size(120, 20)
        Me.TxtAltura.TabIndex = 203
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(26, 151)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(34, 17)
        Me.Label24.TabIndex = 202
        Me.Label24.Text = "Peso"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(26, 128)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 17)
        Me.Label23.TabIndex = 201
        Me.Label23.Text = "Profundidade"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(26, 105)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 17)
        Me.Label21.TabIndex = 200
        Me.Label21.Text = "Largura"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(26, 82)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 17)
        Me.Label22.TabIndex = 199
        Me.Label22.Text = "Altura"
        '
        'FrmNovoEnderecoEstoqueLocal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 233)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtPeso)
        Me.Controls.Add(Me.TxtProfundidade)
        Me.Controls.Add(Me.TxtLargura)
        Me.Controls.Add(Me.TxtAltura)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NmQtInserir)
        Me.Controls.Add(Me.TxtNomeEstoque)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovoEnderecoEstoqueLocal"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovoEnderecoEstoqueLocal"
        CType(Me.NmQtInserir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.TxtPeso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProfundidade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtLargura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAltura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NmQtInserir As NumericUpDown
    Friend WithEvents TxtNomeEstoque As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttBuscarCliente As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtPeso As NumericUpDown
    Friend WithEvents TxtProfundidade As NumericUpDown
    Friend WithEvents TxtLargura As NumericUpDown
    Friend WithEvents TxtAltura As NumericUpDown
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
End Class
