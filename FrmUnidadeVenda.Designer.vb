<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUnidadeVenda
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RdbMultiplicar = New System.Windows.Forms.RadioButton()
        Me.RdbDividir = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.BttAddUnidade = New System.Windows.Forms.Button()
        Me.CmbUnidadeCompra = New System.Windows.Forms.ComboBox()
        Me.TxtEquivalencia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PnnInferior)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(1, 119)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(376, 39)
        Me.Panel2.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RdbMultiplicar)
        Me.Panel1.Controls.Add(Me.RdbDividir)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.BttAddUnidade)
        Me.Panel1.Controls.Add(Me.CmbUnidadeCompra)
        Me.Panel1.Controls.Add(Me.TxtEquivalencia)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 119)
        Me.Panel1.TabIndex = 12
        '
        'RdbMultiplicar
        '
        Me.RdbMultiplicar.AutoSize = True
        Me.RdbMultiplicar.Enabled = False
        Me.RdbMultiplicar.Location = New System.Drawing.Point(269, 82)
        Me.RdbMultiplicar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RdbMultiplicar.Name = "RdbMultiplicar"
        Me.RdbMultiplicar.Size = New System.Drawing.Size(90, 21)
        Me.RdbMultiplicar.TabIndex = 57
        Me.RdbMultiplicar.TabStop = True
        Me.RdbMultiplicar.Text = "Multiplicar"
        Me.RdbMultiplicar.UseVisualStyleBackColor = True
        '
        'RdbDividir
        '
        Me.RdbDividir.AutoSize = True
        Me.RdbDividir.Enabled = False
        Me.RdbDividir.Location = New System.Drawing.Point(199, 82)
        Me.RdbDividir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RdbDividir.Name = "RdbDividir"
        Me.RdbDividir.Size = New System.Drawing.Size(65, 21)
        Me.RdbDividir.TabIndex = 56
        Me.RdbDividir.TabStop = True
        Me.RdbDividir.Text = "Dividir"
        Me.RdbDividir.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(-18, -17)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(106, 21)
        Me.RadioButton1.TabIndex = 55
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "RadioButton1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'BttAddUnidade
        '
        Me.BttAddUnidade.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttAddUnidade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddUnidade.FlatAppearance.BorderSize = 0
        Me.BttAddUnidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddUnidade.Location = New System.Drawing.Point(322, 52)
        Me.BttAddUnidade.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BttAddUnidade.Name = "BttAddUnidade"
        Me.BttAddUnidade.Size = New System.Drawing.Size(27, 22)
        Me.BttAddUnidade.TabIndex = 54
        Me.BttAddUnidade.UseVisualStyleBackColor = True
        '
        'CmbUnidadeCompra
        '
        Me.CmbUnidadeCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbUnidadeCompra.FormattingEnabled = True
        Me.CmbUnidadeCompra.Location = New System.Drawing.Point(98, 51)
        Me.CmbUnidadeCompra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbUnidadeCompra.Name = "CmbUnidadeCompra"
        Me.CmbUnidadeCompra.Size = New System.Drawing.Size(217, 23)
        Me.CmbUnidadeCompra.TabIndex = 53
        '
        'TxtEquivalencia
        '
        Me.TxtEquivalencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEquivalencia.Enabled = False
        Me.TxtEquivalencia.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtEquivalencia.Location = New System.Drawing.Point(98, 81)
        Me.TxtEquivalencia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtEquivalencia.Name = "TxtEquivalencia"
        Me.TxtEquivalencia.Size = New System.Drawing.Size(92, 21)
        Me.TxtEquivalencia.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 84)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Equivalencia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Unidade"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(376, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nova unidade de saída"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(0, 1)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(376, 38)
        Me.PnnInferior.TabIndex = 59
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(292, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(292, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(84, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(12, 9)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 158)
        Me.Panel3.TabIndex = 31
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SlateGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(377, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1, 158)
        Me.Panel5.TabIndex = 32
        '
        'FrmUnidadeVenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 158)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmUnidadeVenda"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmUnidadeVenda"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtEquivalencia As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BttAddUnidade As Button
    Friend WithEvents CmbUnidadeCompra As ComboBox
    Friend WithEvents RdbMultiplicar As RadioButton
    Friend WithEvents RdbDividir As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvar As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
End Class
