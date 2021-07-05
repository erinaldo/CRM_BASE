<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovaFuncao
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RdbMensal = New System.Windows.Forms.RadioButton()
        Me.RdbHora = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDiaFechamento = New System.Windows.Forms.NumericUpDown()
        Me.TxtRemuneracao = New System.Windows.Forms.TextBox()
        Me.TxtDescricao = New System.Windows.Forms.TextBox()
        Me.CkComissao = New System.Windows.Forms.CheckBox()
        Me.TxtVlrComissao = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.TxtDiaFechamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVlrComissao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(552, 33)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nova função"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 277)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(553, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 277)
        Me.Panel2.TabIndex = 3
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 237)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(552, 40)
        Me.PnnInferior.TabIndex = 60
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(476, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(476, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(76, 40)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(14, 10)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(18, 21)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(46, 10)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(18, 21)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(26, 69)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(121, 17)
        Me.Label23.TabIndex = 61
        Me.Label23.Text = "Descrição da função"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 17)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Valor da remuneraçao"
        '
        'RdbMensal
        '
        Me.RdbMensal.AutoSize = True
        Me.RdbMensal.Enabled = False
        Me.RdbMensal.Location = New System.Drawing.Point(29, 149)
        Me.RdbMensal.Name = "RdbMensal"
        Me.RdbMensal.Size = New System.Drawing.Size(151, 21)
        Me.RdbMensal.TabIndex = 65
        Me.RdbMensal.TabStop = True
        Me.RdbMensal.Text = "Remuneração mensal"
        Me.RdbMensal.UseVisualStyleBackColor = True
        '
        'RdbHora
        '
        Me.RdbHora.AutoSize = True
        Me.RdbHora.Enabled = False
        Me.RdbHora.Location = New System.Drawing.Point(186, 149)
        Me.RdbHora.Name = "RdbHora"
        Me.RdbHora.Size = New System.Drawing.Size(159, 21)
        Me.RdbHora.TabIndex = 66
        Me.RdbHora.TabStop = True
        Me.RdbHora.Text = "Remuneração por hora"
        Me.RdbHora.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 17)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Dia para fechamento da folha"
        '
        'TxtDiaFechamento
        '
        Me.TxtDiaFechamento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDiaFechamento.Enabled = False
        Me.TxtDiaFechamento.Location = New System.Drawing.Point(207, 199)
        Me.TxtDiaFechamento.Maximum = New Decimal(New Integer() {28, 0, 0, 0})
        Me.TxtDiaFechamento.Name = "TxtDiaFechamento"
        Me.TxtDiaFechamento.Size = New System.Drawing.Size(120, 20)
        Me.TxtDiaFechamento.TabIndex = 68
        Me.TxtDiaFechamento.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'TxtRemuneracao
        '
        Me.TxtRemuneracao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemuneracao.Enabled = False
        Me.TxtRemuneracao.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtRemuneracao.Location = New System.Drawing.Point(207, 96)
        Me.TxtRemuneracao.Name = "TxtRemuneracao"
        Me.TxtRemuneracao.Size = New System.Drawing.Size(120, 21)
        Me.TxtRemuneracao.TabIndex = 69
        Me.TxtRemuneracao.Text = "R$ 0,00"
        '
        'TxtDescricao
        '
        Me.TxtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescricao.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescricao.Location = New System.Drawing.Point(207, 66)
        Me.TxtDescricao.Name = "TxtDescricao"
        Me.TxtDescricao.Size = New System.Drawing.Size(335, 21)
        Me.TxtDescricao.TabIndex = 70
        '
        'CkComissao
        '
        Me.CkComissao.AutoSize = True
        Me.CkComissao.Enabled = False
        Me.CkComissao.Location = New System.Drawing.Point(333, 96)
        Me.CkComissao.Name = "CkComissao"
        Me.CkComissao.Size = New System.Drawing.Size(82, 21)
        Me.CkComissao.TabIndex = 71
        Me.CkComissao.Text = "Comissão"
        Me.CkComissao.UseVisualStyleBackColor = True
        '
        'TxtVlrComissao
        '
        Me.TxtVlrComissao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVlrComissao.DecimalPlaces = 2
        Me.TxtVlrComissao.Enabled = False
        Me.TxtVlrComissao.Location = New System.Drawing.Point(421, 96)
        Me.TxtVlrComissao.Name = "TxtVlrComissao"
        Me.TxtVlrComissao.Size = New System.Drawing.Size(89, 20)
        Me.TxtVlrComissao.TabIndex = 72
        Me.TxtVlrComissao.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(516, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 17)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "%"
        '
        'FrmNovaFuncao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 277)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtVlrComissao)
        Me.Controls.Add(Me.CkComissao)
        Me.Controls.Add(Me.TxtDescricao)
        Me.Controls.Add(Me.TxtRemuneracao)
        Me.Controls.Add(Me.TxtDiaFechamento)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RdbHora)
        Me.Controls.Add(Me.RdbMensal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovaFuncao"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovaFuncao"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.TxtDiaFechamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVlrComissao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvar As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Label23 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RdbMensal As RadioButton
    Friend WithEvents RdbHora As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtDiaFechamento As NumericUpDown
    Friend WithEvents TxtRemuneracao As TextBox
    Friend WithEvents TxtDescricao As TextBox
    Friend WithEvents CkComissao As CheckBox
    Friend WithEvents TxtVlrComissao As NumericUpDown
    Friend WithEvents Label4 As Label
End Class
