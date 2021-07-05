<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFormasPgSaida
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
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CmbContaVinculada = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NmParcelas = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RdbMeses = New System.Windows.Forms.RadioButton()
        Me.RdbDias = New System.Windows.Forms.RadioButton()
        Me.NmIntervalo = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CkModoPg = New System.Windows.Forms.CheckBox()
        Me.TxtDescrição = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvarFormaDePgSaida = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BttAddConta = New System.Windows.Forms.Button()
        Me.Panel5.SuspendLayout()
        CType(Me.NmParcelas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmIntervalo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnnInferior.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 415)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(396, 1)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(1, 414)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(396, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(396, 1)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 413)
        Me.Panel4.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.BttAddConta)
        Me.Panel5.Controls.Add(Me.CmbContaVinculada)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.NmParcelas)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.RdbMeses)
        Me.Panel5.Controls.Add(Me.RdbDias)
        Me.Panel5.Controls.Add(Me.NmIntervalo)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.CkModoPg)
        Me.Panel5.Controls.Add(Me.TxtDescrição)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.PnnInferior)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.ForeColor = System.Drawing.Color.SlateGray
        Me.Panel5.Location = New System.Drawing.Point(1, 1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(395, 413)
        Me.Panel5.TabIndex = 4
        '
        'CmbContaVinculada
        '
        Me.CmbContaVinculada.Enabled = False
        Me.CmbContaVinculada.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbContaVinculada.FormattingEnabled = True
        Me.CmbContaVinculada.Location = New System.Drawing.Point(11, 312)
        Me.CmbContaVinculada.Name = "CmbContaVinculada"
        Me.CmbContaVinculada.Size = New System.Drawing.Size(328, 25)
        Me.CmbContaVinculada.TabIndex = 72
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 292)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Conta vinculada"
        '
        'NmParcelas
        '
        Me.NmParcelas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NmParcelas.Enabled = False
        Me.NmParcelas.Location = New System.Drawing.Point(11, 254)
        Me.NmParcelas.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NmParcelas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NmParcelas.Name = "NmParcelas"
        Me.NmParcelas.Size = New System.Drawing.Size(120, 20)
        Me.NmParcelas.TabIndex = 70
        Me.NmParcelas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 234)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 17)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Máximo de parcelas possíveis"
        '
        'RdbMeses
        '
        Me.RdbMeses.AutoSize = True
        Me.RdbMeses.Enabled = False
        Me.RdbMeses.Location = New System.Drawing.Point(218, 191)
        Me.RdbMeses.Name = "RdbMeses"
        Me.RdbMeses.Size = New System.Drawing.Size(64, 21)
        Me.RdbMeses.TabIndex = 68
        Me.RdbMeses.TabStop = True
        Me.RdbMeses.Text = "meses"
        Me.RdbMeses.UseVisualStyleBackColor = True
        '
        'RdbDias
        '
        Me.RdbDias.AutoSize = True
        Me.RdbDias.Enabled = False
        Me.RdbDias.Location = New System.Drawing.Point(142, 191)
        Me.RdbDias.Name = "RdbDias"
        Me.RdbDias.Size = New System.Drawing.Size(51, 21)
        Me.RdbDias.TabIndex = 67
        Me.RdbDias.TabStop = True
        Me.RdbDias.Text = "dias"
        Me.RdbDias.UseVisualStyleBackColor = True
        '
        'NmIntervalo
        '
        Me.NmIntervalo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NmIntervalo.Enabled = False
        Me.NmIntervalo.Location = New System.Drawing.Point(11, 191)
        Me.NmIntervalo.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NmIntervalo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NmIntervalo.Name = "NmIntervalo"
        Me.NmIntervalo.Size = New System.Drawing.Size(120, 20)
        Me.NmIntervalo.TabIndex = 66
        Me.NmIntervalo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 17)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Intervalo"
        '
        'CkModoPg
        '
        Me.CkModoPg.AutoSize = True
        Me.CkModoPg.Checked = True
        Me.CkModoPg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkModoPg.Enabled = False
        Me.CkModoPg.Location = New System.Drawing.Point(11, 130)
        Me.CkModoPg.Name = "CkModoPg"
        Me.CkModoPg.Size = New System.Drawing.Size(187, 21)
        Me.CkModoPg.TabIndex = 64
        Me.CkModoPg.Text = "Modo de pagamento a vista"
        Me.CkModoPg.UseVisualStyleBackColor = True
        '
        'TxtDescrição
        '
        Me.TxtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescrição.Font = New System.Drawing.Font("Calibri", 10.25!)
        Me.TxtDescrição.Location = New System.Drawing.Point(11, 86)
        Me.TxtDescrição.Name = "TxtDescrição"
        Me.TxtDescrição.Size = New System.Drawing.Size(365, 21)
        Me.TxtDescrição.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 17)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Descrição da forma de pagamento"
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel6)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(0, 375)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(395, 38)
        Me.PnnInferior.TabIndex = 61
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(307, 5)
        Me.Panel6.TabIndex = 27
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(93, 5)
        Me.Panel7.TabIndex = 32
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvarFormaDePgSaida)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(307, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(88, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvarFormaDePgSaida
        '
        Me.BttSalvarFormaDePgSaida.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvarFormaDePgSaida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvarFormaDePgSaida.Enabled = False
        Me.BttSalvarFormaDePgSaida.FlatAppearance.BorderSize = 0
        Me.BttSalvarFormaDePgSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvarFormaDePgSaida.Location = New System.Drawing.Point(11, 8)
        Me.BttSalvarFormaDePgSaida.Name = "BttSalvarFormaDePgSaida"
        Me.BttSalvarFormaDePgSaida.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvarFormaDePgSaida.TabIndex = 29
        Me.BttSalvarFormaDePgSaida.UseVisualStyleBackColor = True
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
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SlateGray
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(395, 34)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Nova forma de pagamento"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BttAddConta
        '
        Me.BttAddConta.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttAddConta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddConta.Enabled = False
        Me.BttAddConta.FlatAppearance.BorderSize = 0
        Me.BttAddConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddConta.Location = New System.Drawing.Point(356, 315)
        Me.BttAddConta.Name = "BttAddConta"
        Me.BttAddConta.Size = New System.Drawing.Size(20, 20)
        Me.BttAddConta.TabIndex = 73
        Me.BttAddConta.UseVisualStyleBackColor = True
        '
        'FrmFormasPgSaida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 415)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmFormasPgSaida"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmFormasPgSaida"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.NmParcelas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmIntervalo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents CkModoPg As CheckBox
    Friend WithEvents TxtDescrição As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BttSalvarFormaDePgSaida As Button
    Friend WithEvents RdbMeses As RadioButton
    Friend WithEvents RdbDias As RadioButton
    Friend WithEvents NmIntervalo As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents NmParcelas As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents CmbContaVinculada As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BttAddConta As Button
End Class
