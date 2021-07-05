<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNovaVersaoModelo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNovaVersaoModelo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmbCambio = New System.Windows.Forms.ComboBox()
        Me.BttAddCambio = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCilindrada = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPotencia = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbCombustivel = New System.Windows.Forms.ComboBox()
        Me.BttAddCombustivel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtDescrição = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCaption = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.TxtCilindrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPotencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.CmbCambio)
        Me.Panel1.Controls.Add(Me.BttAddCambio)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtCilindrada)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtPotencia)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.CmbCombustivel)
        Me.Panel1.Controls.Add(Me.BttAddCombustivel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TxtDescrição)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(384, 226)
        Me.Panel1.TabIndex = 19
        '
        'CmbCambio
        '
        Me.CmbCambio.Enabled = False
        Me.CmbCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCambio.FormattingEnabled = True
        Me.CmbCambio.Location = New System.Drawing.Point(96, 116)
        Me.CmbCambio.Name = "CmbCambio"
        Me.CmbCambio.Size = New System.Drawing.Size(230, 21)
        Me.CmbCambio.TabIndex = 50
        '
        'BttAddCambio
        '
        Me.BttAddCambio.BackgroundImage = CType(resources.GetObject("BttAddCambio.BackgroundImage"), System.Drawing.Image)
        Me.BttAddCambio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddCambio.Enabled = False
        Me.BttAddCambio.FlatAppearance.BorderSize = 0
        Me.BttAddCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddCambio.Location = New System.Drawing.Point(332, 116)
        Me.BttAddCambio.Name = "BttAddCambio"
        Me.BttAddCambio.Size = New System.Drawing.Size(18, 18)
        Me.BttAddCambio.TabIndex = 49
        Me.BttAddCambio.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Cambio"
        '
        'TxtCilindrada
        '
        Me.TxtCilindrada.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCilindrada.Enabled = False
        Me.TxtCilindrada.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCilindrada.Location = New System.Drawing.Point(248, 149)
        Me.TxtCilindrada.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.TxtCilindrada.Name = "TxtCilindrada"
        Me.TxtCilindrada.Size = New System.Drawing.Size(102, 20)
        Me.TxtCilindrada.TabIndex = 47
        Me.TxtCilindrada.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(198, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Cavalos"
        '
        'TxtPotencia
        '
        Me.TxtPotencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPotencia.DecimalPlaces = 1
        Me.TxtPotencia.Enabled = False
        Me.TxtPotencia.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtPotencia.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.TxtPotencia.Location = New System.Drawing.Point(96, 149)
        Me.TxtPotencia.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.TxtPotencia.Name = "TxtPotencia"
        Me.TxtPotencia.Size = New System.Drawing.Size(96, 20)
        Me.TxtPotencia.TabIndex = 45
        Me.TxtPotencia.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Potência"
        '
        'CmbCombustivel
        '
        Me.CmbCombustivel.Enabled = False
        Me.CmbCombustivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCombustivel.FormattingEnabled = True
        Me.CmbCombustivel.Location = New System.Drawing.Point(96, 89)
        Me.CmbCombustivel.Name = "CmbCombustivel"
        Me.CmbCombustivel.Size = New System.Drawing.Size(230, 21)
        Me.CmbCombustivel.TabIndex = 43
        '
        'BttAddCombustivel
        '
        Me.BttAddCombustivel.BackgroundImage = CType(resources.GetObject("BttAddCombustivel.BackgroundImage"), System.Drawing.Image)
        Me.BttAddCombustivel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddCombustivel.Enabled = False
        Me.BttAddCombustivel.FlatAppearance.BorderSize = 0
        Me.BttAddCombustivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddCombustivel.Location = New System.Drawing.Point(332, 89)
        Me.BttAddCombustivel.Name = "BttAddCombustivel"
        Me.BttAddCombustivel.Size = New System.Drawing.Size(18, 18)
        Me.BttAddCombustivel.TabIndex = 42
        Me.BttAddCombustivel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Combustível"
        '
        'TxtDescrição
        '
        Me.TxtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescrição.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescrição.Location = New System.Drawing.Point(96, 61)
        Me.TxtDescrição.Name = "TxtDescrição"
        Me.TxtDescrição.Size = New System.Drawing.Size(254, 17)
        Me.TxtDescrição.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descrição"
        '
        'LblCaption
        '
        Me.LblCaption.BackColor = System.Drawing.Color.LightSlateGray
        Me.LblCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblCaption.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.LblCaption.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblCaption.Location = New System.Drawing.Point(0, 0)
        Me.LblCaption.Name = "LblCaption"
        Me.LblCaption.Size = New System.Drawing.Size(384, 31)
        Me.LblCaption.TabIndex = 0
        Me.LblCaption.Text = "Nova versão para o modelo"
        Me.LblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SlateGray
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(1, 203)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(384, 36)
        Me.Panel3.TabIndex = 25
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(289, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SlateGray
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.BttSalvar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(289, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(95, 36)
        Me.Panel5.TabIndex = 26
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(60, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 26
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(19, 7)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 27
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 238)
        Me.Panel2.TabIndex = 26
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(385, 1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 238)
        Me.Panel6.TabIndex = 27
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(386, 1)
        Me.Panel7.TabIndex = 28
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 239)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(386, 1)
        Me.Panel8.TabIndex = 29
        '
        'FrmNovaVersaoModelo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(386, 240)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel8)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovaVersaoModelo"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovaVersaoModelo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TxtCilindrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPotencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtDescrição As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LblCaption As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCilindrada As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtPotencia As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents CmbCombustivel As ComboBox
    Friend WithEvents BttAddCombustivel As Button
    Friend WithEvents CmbCambio As ComboBox
    Friend WithEvents BttAddCambio As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
End Class
