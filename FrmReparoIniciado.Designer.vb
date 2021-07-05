<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReparoIniciado
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReparoIniciado))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrItensAprovados = New System.Windows.Forms.TreeView()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.LblStagio = New System.Windows.Forms.Label()
        Me.LblNumSoluçãoN = New System.Windows.Forms.Label()
        Me.LblNumProcessoN = New System.Windows.Forms.Label()
        Me.LblPlacaN = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 572)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1209, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 572)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1210, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 657)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1208, 1)
        Me.Panel4.TabIndex = 3
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 619)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1208, 38)
        Me.PnnInferior.TabIndex = 36
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1121, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1121, 0)
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
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(0, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(1210, 28)
        Me.LblTitulo.TabIndex = 37
        Me.LblTitulo.Text = "Reparos "
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.TrItensAprovados)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(1, 86)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(366, 533)
        Me.Panel6.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(355, 21)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Itens aprovados"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrItensAprovados
        '
        Me.TrItensAprovados.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TrItensAprovados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TrItensAprovados.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.TrItensAprovados.Location = New System.Drawing.Point(6, 34)
        Me.TrItensAprovados.Name = "TrItensAprovados"
        Me.TrItensAprovados.Size = New System.Drawing.Size(352, 550)
        Me.TrItensAprovados.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(365, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1, 533)
        Me.Panel7.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "capacete.png")
        Me.ImageList1.Images.SetKeyName(1, "Risco.png")
        Me.ImageList1.Images.SetKeyName(2, "estoque.png")
        Me.ImageList1.Images.SetKeyName(3, "Desligar.png")
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel10.Controls.Add(Me.LblStagio)
        Me.Panel10.Controls.Add(Me.LblNumSoluçãoN)
        Me.Panel10.Controls.Add(Me.LblNumProcessoN)
        Me.Panel10.Controls.Add(Me.LblPlacaN)
        Me.Panel10.Controls.Add(Me.Label4)
        Me.Panel10.Controls.Add(Me.Panel14)
        Me.Panel10.Controls.Add(Me.Label3)
        Me.Panel10.Controls.Add(Me.Panel13)
        Me.Panel10.Controls.Add(Me.Label1)
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Controls.Add(Me.Label5)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 29)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1210, 57)
        Me.Panel10.TabIndex = 104
        '
        'LblStagio
        '
        Me.LblStagio.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblStagio.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblStagio.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblStagio.Location = New System.Drawing.Point(801, 27)
        Me.LblStagio.Name = "LblStagio"
        Me.LblStagio.Size = New System.Drawing.Size(397, 21)
        Me.LblStagio.TabIndex = 121
        Me.LblStagio.Text = "Stagio"
        Me.LblStagio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNumSoluçãoN
        '
        Me.LblNumSoluçãoN.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblNumSoluçãoN.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblNumSoluçãoN.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblNumSoluçãoN.Location = New System.Drawing.Point(587, 27)
        Me.LblNumSoluçãoN.Name = "LblNumSoluçãoN"
        Me.LblNumSoluçãoN.Size = New System.Drawing.Size(200, 21)
        Me.LblNumSoluçãoN.TabIndex = 120
        Me.LblNumSoluçãoN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNumProcessoN
        '
        Me.LblNumProcessoN.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblNumProcessoN.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblNumProcessoN.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblNumProcessoN.Location = New System.Drawing.Point(373, 27)
        Me.LblNumProcessoN.Name = "LblNumProcessoN"
        Me.LblNumProcessoN.Size = New System.Drawing.Size(200, 21)
        Me.LblNumProcessoN.TabIndex = 119
        Me.LblNumProcessoN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblPlacaN
        '
        Me.LblPlacaN.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblPlacaN.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblPlacaN.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblPlacaN.Location = New System.Drawing.Point(3, 27)
        Me.LblPlacaN.Name = "LblPlacaN"
        Me.LblPlacaN.Size = New System.Drawing.Size(356, 21)
        Me.LblPlacaN.TabIndex = 118
        Me.LblPlacaN.Text = "Dados do veículo"
        Me.LblPlacaN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(801, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(397, 21)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Stagio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel14.Location = New System.Drawing.Point(793, 4)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(1, 50)
        Me.Panel14.TabIndex = 116
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(587, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 21)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Num. solução"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel13.Location = New System.Drawing.Point(579, 4)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(1, 50)
        Me.Panel13.TabIndex = 114
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(373, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 21)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Num. processo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel11.Location = New System.Drawing.Point(366, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1, 50)
        Me.Panel11.TabIndex = 112
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(3, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(356, 21)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Dados do veículo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmReparoIniciado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1210, 658)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmReparoIniciado"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmReparoIniciado"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents LblTitulo As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TrItensAprovados As TreeView
    Friend WithEvents Label2 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel10 As Panel
    Friend WithEvents LblStagio As Label
    Friend WithEvents LblNumSoluçãoN As Label
    Friend WithEvents LblNumProcessoN As Label
    Friend WithEvents LblPlacaN As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label5 As Label
End Class
