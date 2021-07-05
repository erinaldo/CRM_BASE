<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitarCadastro
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPartNumber = New System.Windows.Forms.TextBox()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.TxtDescrição = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.LblFabricante = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblPotencia = New System.Windows.Forms.Label()
        Me.LblMotor = New System.Windows.Forms.Label()
        Me.LblAnoMod = New System.Windows.Forms.Label()
        Me.LblAnoFab = New System.Windows.Forms.Label()
        Me.LblVersão = New System.Windows.Forms.Label()
        Me.LblModelo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbSubCategoria = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbCategoria = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(756, 28)
        Me.LblTitulo.TabIndex = 32
        Me.LblTitulo.Text = "Solução aplicada"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Part. Number"
        '
        'TxtPartNumber
        '
        Me.TxtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartNumber.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtPartNumber.Location = New System.Drawing.Point(106, 43)
        Me.TxtPartNumber.Name = "TxtPartNumber"
        Me.TxtPartNumber.Size = New System.Drawing.Size(207, 17)
        Me.TxtPartNumber.TabIndex = 49
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 313)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(756, 38)
        Me.PnnInferior.TabIndex = 50
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(669, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(669, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(87, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(51, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(10, 8)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'TxtDescrição
        '
        Me.TxtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescrição.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescrição.Location = New System.Drawing.Point(106, 70)
        Me.TxtDescrição.Multiline = True
        Me.TxtDescrição.Name = "TxtDescrição"
        Me.TxtDescrição.Size = New System.Drawing.Size(636, 76)
        Me.TxtDescrição.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Descrição"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 351)
        Me.Panel1.TabIndex = 54
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(757, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 351)
        Me.Panel2.TabIndex = 55
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(1, 351)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(756, 1)
        Me.Panel3.TabIndex = 56
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(758, 1)
        Me.Panel5.TabIndex = 57
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.LblFabricante)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.LblPotencia)
        Me.Panel6.Controls.Add(Me.LblMotor)
        Me.Panel6.Controls.Add(Me.LblAnoMod)
        Me.Panel6.Controls.Add(Me.LblAnoFab)
        Me.Panel6.Controls.Add(Me.LblVersão)
        Me.Panel6.Controls.Add(Me.LblModelo)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Location = New System.Drawing.Point(12, 179)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(733, 121)
        Me.Panel6.TabIndex = 58
        '
        'LblFabricante
        '
        Me.LblFabricante.AutoSize = True
        Me.LblFabricante.ForeColor = System.Drawing.Color.SlateGray
        Me.LblFabricante.Location = New System.Drawing.Point(91, 38)
        Me.LblFabricante.Name = "LblFabricante"
        Me.LblFabricante.Size = New System.Drawing.Size(43, 13)
        Me.LblFabricante.TabIndex = 60
        Me.LblFabricante.Text = "Modelo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Fabricante"
        '
        'LblPotencia
        '
        Me.LblPotencia.AutoSize = True
        Me.LblPotencia.ForeColor = System.Drawing.Color.SlateGray
        Me.LblPotencia.Location = New System.Drawing.Point(558, 96)
        Me.LblPotencia.Name = "LblPotencia"
        Me.LblPotencia.Size = New System.Drawing.Size(43, 13)
        Me.LblPotencia.TabIndex = 58
        Me.LblPotencia.Text = "Modelo"
        '
        'LblMotor
        '
        Me.LblMotor.AutoSize = True
        Me.LblMotor.ForeColor = System.Drawing.Color.SlateGray
        Me.LblMotor.Location = New System.Drawing.Point(331, 96)
        Me.LblMotor.Name = "LblMotor"
        Me.LblMotor.Size = New System.Drawing.Size(43, 13)
        Me.LblMotor.TabIndex = 57
        Me.LblMotor.Text = "Modelo"
        '
        'LblAnoMod
        '
        Me.LblAnoMod.AutoSize = True
        Me.LblAnoMod.ForeColor = System.Drawing.Color.SlateGray
        Me.LblAnoMod.Location = New System.Drawing.Point(558, 68)
        Me.LblAnoMod.Name = "LblAnoMod"
        Me.LblAnoMod.Size = New System.Drawing.Size(43, 13)
        Me.LblAnoMod.TabIndex = 56
        Me.LblAnoMod.Text = "Modelo"
        '
        'LblAnoFab
        '
        Me.LblAnoFab.AutoSize = True
        Me.LblAnoFab.ForeColor = System.Drawing.Color.SlateGray
        Me.LblAnoFab.Location = New System.Drawing.Point(414, 68)
        Me.LblAnoFab.Name = "LblAnoFab"
        Me.LblAnoFab.Size = New System.Drawing.Size(43, 13)
        Me.LblAnoFab.TabIndex = 55
        Me.LblAnoFab.Text = "Modelo"
        '
        'LblVersão
        '
        Me.LblVersão.AutoSize = True
        Me.LblVersão.ForeColor = System.Drawing.Color.SlateGray
        Me.LblVersão.Location = New System.Drawing.Point(91, 96)
        Me.LblVersão.Name = "LblVersão"
        Me.LblVersão.Size = New System.Drawing.Size(43, 13)
        Me.LblVersão.TabIndex = 54
        Me.LblVersão.Text = "Modelo"
        '
        'LblModelo
        '
        Me.LblModelo.AutoSize = True
        Me.LblModelo.ForeColor = System.Drawing.Color.SlateGray
        Me.LblModelo.Location = New System.Drawing.Point(91, 68)
        Me.LblModelo.Name = "LblModelo"
        Me.LblModelo.Size = New System.Drawing.Size(43, 13)
        Me.LblModelo.TabIndex = 53
        Me.LblModelo.Text = "Modelo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(331, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Ano fabricação"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(489, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Ano modelo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(489, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Potência"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(262, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Motor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Versão"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Modelo"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(733, 28)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Cadastro para o modelo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbSubCategoria
        '
        Me.CmbSubCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbSubCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbSubCategoria.Enabled = False
        Me.CmbSubCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbSubCategoria.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbSubCategoria.FormattingEnabled = True
        Me.CmbSubCategoria.Location = New System.Drawing.Point(501, 152)
        Me.CmbSubCategoria.Name = "CmbSubCategoria"
        Me.CmbSubCategoria.Size = New System.Drawing.Size(244, 21)
        Me.CmbSubCategoria.TabIndex = 114
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(392, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "Subcategoria"
        '
        'CmbCategoria
        '
        Me.CmbCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCategoria.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbCategoria.FormattingEnabled = True
        Me.CmbCategoria.Location = New System.Drawing.Point(106, 152)
        Me.CmbCategoria.Name = "CmbCategoria"
        Me.CmbCategoria.Size = New System.Drawing.Size(280, 21)
        Me.CmbCategoria.TabIndex = 112
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 111
        Me.Label13.Text = "Categoria"
        '
        'FrmSolicitarCadastro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 352)
        Me.Controls.Add(Me.CmbSubCategoria)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CmbCategoria)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.TxtDescrição)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPartNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel5)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSolicitarCadastro"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSolicitarCadastro"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtPartNumber As TextBox
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents TxtDescrição As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents LblPotencia As Label
    Friend WithEvents LblMotor As Label
    Friend WithEvents LblAnoMod As Label
    Friend WithEvents LblAnoFab As Label
    Friend WithEvents LblVersão As Label
    Friend WithEvents LblModelo As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblFabricante As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents CmbSubCategoria As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents CmbCategoria As ComboBox
    Friend WithEvents Label13 As Label
End Class
