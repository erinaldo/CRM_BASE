<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovaConta
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
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvarFormaDePgSaida = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtNomeConta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CkCofre = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CkSemvinculo = New System.Windows.Forms.CheckBox()
        Me.TxtAgencia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNumConta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.TxtValor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbContasBancarias = New System.Windows.Forms.ComboBox()
        Me.PnnInferior.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel12.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(343, 26)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Orçamento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel6)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 377)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(343, 34)
        Me.PnnInferior.TabIndex = 67
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(275, 5)
        Me.Panel6.TabIndex = 27
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(71, 5)
        Me.Panel7.TabIndex = 32
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvarFormaDePgSaida)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(275, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(68, 34)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvarFormaDePgSaida
        '
        Me.BttSalvarFormaDePgSaida.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvarFormaDePgSaida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvarFormaDePgSaida.Enabled = False
        Me.BttSalvarFormaDePgSaida.FlatAppearance.BorderSize = 0
        Me.BttSalvarFormaDePgSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvarFormaDePgSaida.Location = New System.Drawing.Point(9, 8)
        Me.BttSalvarFormaDePgSaida.Name = "BttSalvarFormaDePgSaida"
        Me.BttSalvarFormaDePgSaida.Size = New System.Drawing.Size(16, 18)
        Me.BttSalvarFormaDePgSaida.TabIndex = 29
        Me.BttSalvarFormaDePgSaida.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(37, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(16, 18)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(344, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 411)
        Me.Panel1.TabIndex = 68
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 411)
        Me.Panel2.TabIndex = 69
        '
        'TxtNomeConta
        '
        Me.TxtNomeConta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeConta.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeConta.Location = New System.Drawing.Point(22, 72)
        Me.TxtNomeConta.Name = "TxtNomeConta"
        Me.TxtNomeConta.Size = New System.Drawing.Size(298, 21)
        Me.TxtNomeConta.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 17)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Nome da conta"
        '
        'CkCofre
        '
        Me.CkCofre.AutoSize = True
        Me.CkCofre.Enabled = False
        Me.CkCofre.Location = New System.Drawing.Point(24, 99)
        Me.CkCofre.Name = "CkCofre"
        Me.CkCofre.Size = New System.Drawing.Size(60, 21)
        Me.CkCofre.TabIndex = 116
        Me.CkCofre.Text = "Cofre"
        Me.CkCofre.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 17)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Nome da instiruição vinculada"
        '
        'CkSemvinculo
        '
        Me.CkSemvinculo.AutoSize = True
        Me.CkSemvinculo.Enabled = False
        Me.CkSemvinculo.Location = New System.Drawing.Point(90, 99)
        Me.CkSemvinculo.Name = "CkSemvinculo"
        Me.CkSemvinculo.Size = New System.Drawing.Size(96, 21)
        Me.CkSemvinculo.TabIndex = 119
        Me.CkSemvinculo.Text = "Sem vinculo"
        Me.CkSemvinculo.UseVisualStyleBackColor = True
        '
        'TxtAgencia
        '
        Me.TxtAgencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAgencia.Enabled = False
        Me.TxtAgencia.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtAgencia.Location = New System.Drawing.Point(23, 210)
        Me.TxtAgencia.Name = "TxtAgencia"
        Me.TxtAgencia.Size = New System.Drawing.Size(140, 21)
        Me.TxtAgencia.TabIndex = 121
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 191)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 17)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Agência"
        '
        'TxtNumConta
        '
        Me.TxtNumConta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumConta.Enabled = False
        Me.TxtNumConta.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNumConta.Location = New System.Drawing.Point(181, 210)
        Me.TxtNumConta.Name = "TxtNumConta"
        Me.TxtNumConta.Size = New System.Drawing.Size(139, 21)
        Me.TxtNumConta.TabIndex = 123
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(179, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 17)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Número da conta"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.Location = New System.Drawing.Point(24, 261)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(114, 21)
        Me.RadioButton1.TabIndex = 124
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Conta corrente"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Location = New System.Drawing.Point(144, 261)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(120, 21)
        Me.RadioButton2.TabIndex = 125
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Conta poupança"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'TxtValor
        '
        Me.TxtValor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtValor.Enabled = False
        Me.TxtValor.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtValor.Location = New System.Drawing.Point(22, 323)
        Me.TxtValor.Name = "TxtValor"
        Me.TxtValor.Size = New System.Drawing.Size(298, 21)
        Me.TxtValor.TabIndex = 127
        Me.TxtValor.Text = "R$ 0,00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 304)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Saldo inicial"
        '
        'CmbContasBancarias
        '
        Me.CmbContasBancarias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbContasBancarias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbContasBancarias.Enabled = False
        Me.CmbContasBancarias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbContasBancarias.FormattingEnabled = True
        Me.CmbContasBancarias.Location = New System.Drawing.Point(22, 165)
        Me.CmbContasBancarias.Name = "CmbContasBancarias"
        Me.CmbContasBancarias.Size = New System.Drawing.Size(298, 23)
        Me.CmbContasBancarias.TabIndex = 128
        '
        'FrmNovaConta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 411)
        Me.Controls.Add(Me.CmbContasBancarias)
        Me.Controls.Add(Me.TxtValor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.TxtNumConta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtAgencia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CkSemvinculo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CkCofre)
        Me.Controls.Add(Me.TxtNomeConta)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovaConta"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovaConta"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvarFormaDePgSaida As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtNomeConta As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CkCofre As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CkSemvinculo As CheckBox
    Friend WithEvents TxtAgencia As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNumConta As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents TxtValor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CmbContasBancarias As ComboBox
End Class
