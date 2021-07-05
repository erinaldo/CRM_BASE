<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReceber
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCodProduto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblValorReceber = New System.Windows.Forms.Label()
        Me.LblTroco = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtIdentificador = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmbBandeira = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtParcelas = New System.Windows.Forms.NumericUpDown()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.TxtParcelas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(400, 28)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Recebimento de pagamentos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel9)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 407)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(400, 38)
        Me.PnnInferior.TabIndex = 67
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(324, 5)
        Me.Panel9.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(324, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(76, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(12, 9)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(18, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(47, 9)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(18, 20)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 16)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Valor recebido"
        '
        'TxtCodProduto
        '
        Me.TxtCodProduto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCodProduto.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.TxtCodProduto.Location = New System.Drawing.Point(11, 211)
        Me.TxtCodProduto.Multiline = True
        Me.TxtCodProduto.Name = "TxtCodProduto"
        Me.TxtCodProduto.Size = New System.Drawing.Size(374, 29)
        Me.TxtCodProduto.TabIndex = 0
        Me.TxtCodProduto.Text = "R$ 0,00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 16)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Vallor a receber"
        '
        'LblValorReceber
        '
        Me.LblValorReceber.AutoSize = True
        Me.LblValorReceber.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.LblValorReceber.ForeColor = System.Drawing.Color.SlateGray
        Me.LblValorReceber.Location = New System.Drawing.Point(12, 137)
        Me.LblValorReceber.Name = "LblValorReceber"
        Me.LblValorReceber.Size = New System.Drawing.Size(95, 27)
        Me.LblValorReceber.TabIndex = 105
        Me.LblValorReceber.Text = "R$ 0.00"
        '
        'LblTroco
        '
        Me.LblTroco.AutoSize = True
        Me.LblTroco.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.LblTroco.ForeColor = System.Drawing.Color.SlateGray
        Me.LblTroco.Location = New System.Drawing.Point(12, 276)
        Me.LblTroco.Name = "LblTroco"
        Me.LblTroco.Size = New System.Drawing.Size(95, 27)
        Me.LblTroco.TabIndex = 107
        Me.LblTroco.Text = "R$ 0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 16)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Troco"
        '
        'TxtIdentificador
        '
        Me.TxtIdentificador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIdentificador.Enabled = False
        Me.TxtIdentificador.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtIdentificador.Location = New System.Drawing.Point(14, 349)
        Me.TxtIdentificador.Name = "TxtIdentificador"
        Me.TxtIdentificador.Size = New System.Drawing.Size(371, 21)
        Me.TxtIdentificador.TabIndex = 109
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 329)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 16)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Identificador da transação"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 16)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "Bandeira"
        '
        'CmbBandeira
        '
        Me.CmbBandeira.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBandeira.FormattingEnabled = True
        Me.CmbBandeira.Location = New System.Drawing.Point(17, 67)
        Me.CmbBandeira.Name = "CmbBandeira"
        Me.CmbBandeira.Size = New System.Drawing.Size(221, 24)
        Me.CmbBandeira.TabIndex = 111
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(400, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 379)
        Me.Panel1.TabIndex = 112
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 445)
        Me.Panel2.TabIndex = 113
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "Parcelas"
        Me.Label4.Visible = False
        '
        'TxtParcelas
        '
        Me.TxtParcelas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtParcelas.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TxtParcelas.Location = New System.Drawing.Point(17, 128)
        Me.TxtParcelas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtParcelas.Name = "TxtParcelas"
        Me.TxtParcelas.Size = New System.Drawing.Size(221, 23)
        Me.TxtParcelas.TabIndex = 115
        Me.TxtParcelas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtParcelas.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.dollars_98561
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(303, 67)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(82, 84)
        Me.PictureBox1.TabIndex = 116
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(5, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(385, 1)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "Recebimento de pagamentos"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmReceber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 445)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TxtParcelas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CmbBandeira)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtIdentificador)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblTroco)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblValorReceber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCodProduto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmReceber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmReceber"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.TxtParcelas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvar As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtCodProduto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LblValorReceber As Label
    Friend WithEvents LblTroco As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtIdentificador As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents CmbBandeira As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtParcelas As NumericUpDown
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
End Class
