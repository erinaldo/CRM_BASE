<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVinculoFornecedor
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
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.CmbFornecedores = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCodFabricante = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtSRC = New System.Windows.Forms.TextBox()
        Me.BttSrc = New System.Windows.Forms.Button()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvarProduto = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(800, 28)
        Me.LblTitulo.TabIndex = 68
        Me.LblTitulo.Text = "Cadastro de produtos"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Gainsboro
        Me.Label29.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label29.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label29.Location = New System.Drawing.Point(12, 38)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(776, 20)
        Me.Label29.TabIndex = 69
        Me.Label29.Text = "Escolha um fornecedor"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbFornecedores
        '
        Me.CmbFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbFornecedores.FormattingEnabled = True
        Me.CmbFornecedores.Location = New System.Drawing.Point(16, 61)
        Me.CmbFornecedores.Name = "CmbFornecedores"
        Me.CmbFornecedores.Size = New System.Drawing.Size(772, 24)
        Me.CmbFornecedores.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(12, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 20)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Código do fornecedor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCodFabricante
        '
        Me.TxtCodFabricante.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCodFabricante.Enabled = False
        Me.TxtCodFabricante.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCodFabricante.Location = New System.Drawing.Point(16, 123)
        Me.TxtCodFabricante.Name = "TxtCodFabricante"
        Me.TxtCodFabricante.Size = New System.Drawing.Size(284, 21)
        Me.TxtCodFabricante.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(320, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(468, 20)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Selecione o arquivo do manual do produto"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtSRC
        '
        Me.TxtSRC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSRC.Enabled = False
        Me.TxtSRC.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtSRC.Location = New System.Drawing.Point(324, 123)
        Me.TxtSRC.Name = "TxtSRC"
        Me.TxtSRC.Size = New System.Drawing.Size(404, 21)
        Me.TxtSRC.TabIndex = 74
        '
        'BttSrc
        '
        Me.BttSrc.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.arrow_up_16741
        Me.BttSrc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSrc.Enabled = False
        Me.BttSrc.FlatAppearance.BorderSize = 0
        Me.BttSrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSrc.Location = New System.Drawing.Point(734, 123)
        Me.BttSrc.Name = "BttSrc"
        Me.BttSrc.Size = New System.Drawing.Size(54, 21)
        Me.BttSrc.TabIndex = 75
        Me.BttSrc.UseVisualStyleBackColor = True
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(0, 171)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(800, 38)
        Me.PnnInferior.TabIndex = 76
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(716, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvarProduto)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(716, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(84, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvarProduto
        '
        Me.BttSalvarProduto.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvarProduto.Enabled = False
        Me.BttSalvarProduto.FlatAppearance.BorderSize = 0
        Me.BttSalvarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvarProduto.Location = New System.Drawing.Point(12, 9)
        Me.BttSalvarProduto.Name = "BttSalvarProduto"
        Me.BttSalvarProduto.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvarProduto.TabIndex = 29
        Me.BttSalvarProduto.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(48, 9)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'FrmVinculoFornecedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 209)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.BttSrc)
        Me.Controls.Add(Me.TxtSRC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCodFabricante)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbFornecedores)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.LblTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmVinculoFornecedor"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmVinculoFornecedor"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents CmbFornecedores As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCodFabricante As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtSRC As TextBox
    Friend WithEvents BttSrc As Button
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvarProduto As Button
    Friend WithEvents BttFechar As Button
End Class
