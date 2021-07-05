<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVeiculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVeiculo))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtAnoMod = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtAnoFab = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtChassi = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtRenavan = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbCor = New System.Windows.Forms.ComboBox()
        Me.BttAddCor = New System.Windows.Forms.Button()
        Me.CmbVersão = New System.Windows.Forms.ComboBox()
        Me.BttAddVersão = New System.Windows.Forms.Button()
        Me.CmbModelo = New System.Windows.Forms.ComboBox()
        Me.BttAddModelo = New System.Windows.Forms.Button()
        Me.CmbFabricantes = New System.Windows.Forms.ComboBox()
        Me.BttAddFabricante = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblCaption = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtAnoMod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAnoFab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(1, 402)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(739, 38)
        Me.Panel2.TabIndex = 16
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(639, 5)
        Me.Panel4.TabIndex = 25
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BttSalvar)
        Me.Panel3.Controls.Add(Me.BttFechar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(639, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(100, 38)
        Me.Panel3.TabIndex = 24
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(14, 9)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(35, 20)
        Me.BttSalvar.TabIndex = 23
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(55, 9)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(35, 20)
        Me.BttFechar.TabIndex = 22
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtAnoMod)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TxtAnoFab)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TxtChassi)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TxtRenavan)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.CmbCor)
        Me.Panel1.Controls.Add(Me.BttAddCor)
        Me.Panel1.Controls.Add(Me.CmbVersão)
        Me.Panel1.Controls.Add(Me.BttAddVersão)
        Me.Panel1.Controls.Add(Me.CmbModelo)
        Me.Panel1.Controls.Add(Me.BttAddModelo)
        Me.Panel1.Controls.Add(Me.CmbFabricantes)
        Me.Panel1.Controls.Add(Me.BttAddFabricante)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(739, 401)
        Me.Panel1.TabIndex = 15
        '
        'TxtAnoMod
        '
        Me.TxtAnoMod.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAnoMod.Enabled = False
        Me.TxtAnoMod.Location = New System.Drawing.Point(271, 95)
        Me.TxtAnoMod.Maximum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.TxtAnoMod.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.TxtAnoMod.Name = "TxtAnoMod"
        Me.TxtAnoMod.Size = New System.Drawing.Size(88, 17)
        Me.TxtAnoMod.TabIndex = 54
        Me.TxtAnoMod.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(199, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Ano mod"
        '
        'TxtAnoFab
        '
        Me.TxtAnoFab.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAnoFab.Enabled = False
        Me.TxtAnoFab.Location = New System.Drawing.Point(105, 95)
        Me.TxtAnoFab.Maximum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.TxtAnoFab.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.TxtAnoFab.Name = "TxtAnoFab"
        Me.TxtAnoFab.Size = New System.Drawing.Size(88, 17)
        Me.TxtAnoFab.TabIndex = 52
        Me.TxtAnoFab.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Ano Fab."
        '
        'TxtChassi
        '
        Me.TxtChassi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtChassi.Enabled = False
        Me.TxtChassi.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtChassi.Location = New System.Drawing.Point(437, 72)
        Me.TxtChassi.MaxLength = 17
        Me.TxtChassi.Name = "TxtChassi"
        Me.TxtChassi.Size = New System.Drawing.Size(254, 17)
        Me.TxtChassi.TabIndex = 50
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(365, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Chassi"
        '
        'TxtRenavan
        '
        Me.TxtRenavan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRenavan.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtRenavan.Location = New System.Drawing.Point(105, 72)
        Me.TxtRenavan.MaxLength = 11
        Me.TxtRenavan.Name = "TxtRenavan"
        Me.TxtRenavan.Size = New System.Drawing.Size(254, 17)
        Me.TxtRenavan.TabIndex = 48
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Renavam"
        '
        'CmbCor
        '
        Me.CmbCor.Enabled = False
        Me.CmbCor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCor.FormattingEnabled = True
        Me.CmbCor.Location = New System.Drawing.Point(437, 186)
        Me.CmbCor.Name = "CmbCor"
        Me.CmbCor.Size = New System.Drawing.Size(217, 21)
        Me.CmbCor.TabIndex = 45
        '
        'BttAddCor
        '
        Me.BttAddCor.BackgroundImage = CType(resources.GetObject("BttAddCor.BackgroundImage"), System.Drawing.Image)
        Me.BttAddCor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddCor.Enabled = False
        Me.BttAddCor.FlatAppearance.BorderSize = 0
        Me.BttAddCor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddCor.Location = New System.Drawing.Point(674, 191)
        Me.BttAddCor.Name = "BttAddCor"
        Me.BttAddCor.Size = New System.Drawing.Size(17, 17)
        Me.BttAddCor.TabIndex = 44
        Me.BttAddCor.UseVisualStyleBackColor = True
        '
        'CmbVersão
        '
        Me.CmbVersão.Enabled = False
        Me.CmbVersão.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbVersão.FormattingEnabled = True
        Me.CmbVersão.Location = New System.Drawing.Point(105, 188)
        Me.CmbVersão.Name = "CmbVersão"
        Me.CmbVersão.Size = New System.Drawing.Size(213, 21)
        Me.CmbVersão.TabIndex = 43
        '
        'BttAddVersão
        '
        Me.BttAddVersão.BackgroundImage = CType(resources.GetObject("BttAddVersão.BackgroundImage"), System.Drawing.Image)
        Me.BttAddVersão.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddVersão.Enabled = False
        Me.BttAddVersão.FlatAppearance.BorderSize = 0
        Me.BttAddVersão.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddVersão.Location = New System.Drawing.Point(342, 191)
        Me.BttAddVersão.Name = "BttAddVersão"
        Me.BttAddVersão.Size = New System.Drawing.Size(17, 17)
        Me.BttAddVersão.TabIndex = 42
        Me.BttAddVersão.UseVisualStyleBackColor = True
        '
        'CmbModelo
        '
        Me.CmbModelo.Enabled = False
        Me.CmbModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbModelo.FormattingEnabled = True
        Me.CmbModelo.Location = New System.Drawing.Point(437, 159)
        Me.CmbModelo.Name = "CmbModelo"
        Me.CmbModelo.Size = New System.Drawing.Size(217, 21)
        Me.CmbModelo.TabIndex = 41
        '
        'BttAddModelo
        '
        Me.BttAddModelo.BackgroundImage = CType(resources.GetObject("BttAddModelo.BackgroundImage"), System.Drawing.Image)
        Me.BttAddModelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddModelo.Enabled = False
        Me.BttAddModelo.FlatAppearance.BorderSize = 0
        Me.BttAddModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddModelo.Location = New System.Drawing.Point(674, 162)
        Me.BttAddModelo.Name = "BttAddModelo"
        Me.BttAddModelo.Size = New System.Drawing.Size(17, 17)
        Me.BttAddModelo.TabIndex = 40
        Me.BttAddModelo.UseVisualStyleBackColor = True
        '
        'CmbFabricantes
        '
        Me.CmbFabricantes.Enabled = False
        Me.CmbFabricantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbFabricantes.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CmbFabricantes.FormattingEnabled = True
        Me.CmbFabricantes.Location = New System.Drawing.Point(105, 159)
        Me.CmbFabricantes.Name = "CmbFabricantes"
        Me.CmbFabricantes.Size = New System.Drawing.Size(213, 23)
        Me.CmbFabricantes.TabIndex = 39
        '
        'BttAddFabricante
        '
        Me.BttAddFabricante.BackgroundImage = CType(resources.GetObject("BttAddFabricante.BackgroundImage"), System.Drawing.Image)
        Me.BttAddFabricante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddFabricante.FlatAppearance.BorderSize = 0
        Me.BttAddFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddFabricante.Location = New System.Drawing.Point(342, 162)
        Me.BttAddFabricante.Name = "BttAddFabricante"
        Me.BttAddFabricante.Size = New System.Drawing.Size(17, 17)
        Me.BttAddFabricante.TabIndex = 38
        Me.BttAddFabricante.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(365, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Cor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Versão"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(365, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Modelo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fabricante"
        '
        'LblCaption
        '
        Me.LblCaption.BackColor = System.Drawing.Color.SlateGray
        Me.LblCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblCaption.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblCaption.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblCaption.Location = New System.Drawing.Point(0, 0)
        Me.LblCaption.Name = "LblCaption"
        Me.LblCaption.Size = New System.Drawing.Size(739, 31)
        Me.LblCaption.TabIndex = 0
        Me.LblCaption.Text = "Novo veículo"
        Me.LblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1, 439)
        Me.Panel5.TabIndex = 56
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(740, 1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 439)
        Me.Panel6.TabIndex = 57
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(741, 1)
        Me.Panel7.TabIndex = 58
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 440)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(741, 1)
        Me.Panel8.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(11, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(711, 21)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Dados principais"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gainsboro
        Me.Label10.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label10.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Location = New System.Drawing.Point(11, 126)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(711, 21)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "Descrição"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(437, 94)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(254, 23)
        Me.ComboBox1.TabIndex = 126
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(365, 99)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "Categoria"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Gainsboro
        Me.Label12.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label12.Location = New System.Drawing.Point(11, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(711, 21)
        Me.Label12.TabIndex = 127
        Me.Label12.Text = "Imagens "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmVeiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 441)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmVeiculo"
        Me.Opacity = 0.97R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmVeiculo"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtAnoMod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAnoFab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents BttSalvar As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents LblCaption As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BttAddFabricante As Button
    Friend WithEvents CmbCor As ComboBox
    Friend WithEvents BttAddCor As Button
    Friend WithEvents CmbVersão As ComboBox
    Friend WithEvents BttAddVersão As Button
    Friend WithEvents CmbModelo As ComboBox
    Friend WithEvents BttAddModelo As Button
    Friend WithEvents CmbFabricantes As ComboBox
    Friend WithEvents TxtAnoMod As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtAnoFab As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtChassi As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtRenavan As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
End Class
