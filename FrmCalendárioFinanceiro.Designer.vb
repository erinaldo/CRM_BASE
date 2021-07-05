<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCalendárioFinanceiro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCalendárioFinanceiro))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BttSalvarMarkup = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PnnDia01 = New System.Windows.Forms.Panel()
        Me.LblD01 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.LblD02 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.LblD03 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.LblD04 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.LblD05 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.LblD06 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.LblD07 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
        Me.PnnDia01.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 737)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1484, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 737)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(1, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1483, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 736)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1483, 1)
        Me.Panel4.TabIndex = 3
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(1483, 28)
        Me.LblTitulo.TabIndex = 88
        Me.LblTitulo.Text = "Calendário financeiro"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.LblIdVistoria)
        Me.PnnInferior.Controls.Add(Me.LblIdSolução)
        Me.PnnInferior.Controls.Add(Me.LblIdmarca)
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.BttSalvarMarkup)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 698)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1483, 38)
        Me.PnnInferior.TabIndex = 89
        '
        'LblIdVistoria
        '
        Me.LblIdVistoria.AutoSize = True
        Me.LblIdVistoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdVistoria.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdVistoria.Location = New System.Drawing.Point(26, 5)
        Me.LblIdVistoria.Name = "LblIdVistoria"
        Me.LblIdVistoria.Size = New System.Drawing.Size(13, 13)
        Me.LblIdVistoria.TabIndex = 48
        Me.LblIdVistoria.Text = "0"
        Me.LblIdVistoria.Visible = False
        '
        'LblIdSolução
        '
        Me.LblIdSolução.AutoSize = True
        Me.LblIdSolução.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdSolução.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdSolução.Location = New System.Drawing.Point(13, 5)
        Me.LblIdSolução.Name = "LblIdSolução"
        Me.LblIdSolução.Size = New System.Drawing.Size(13, 13)
        Me.LblIdSolução.TabIndex = 47
        Me.LblIdSolução.Text = "0"
        Me.LblIdSolução.Visible = False
        '
        'LblIdmarca
        '
        Me.LblIdmarca.AutoSize = True
        Me.LblIdmarca.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdmarca.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdmarca.Location = New System.Drawing.Point(0, 5)
        Me.LblIdmarca.Name = "LblIdmarca"
        Me.LblIdmarca.Size = New System.Drawing.Size(13, 13)
        Me.LblIdmarca.TabIndex = 46
        Me.LblIdmarca.Text = "0"
        Me.LblIdmarca.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1373, 5)
        Me.Panel5.TabIndex = 27
        '
        'BttSalvarMarkup
        '
        Me.BttSalvarMarkup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvarMarkup.Dock = System.Windows.Forms.DockStyle.Right
        Me.BttSalvarMarkup.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttSalvarMarkup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvarMarkup.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttSalvarMarkup.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttSalvarMarkup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttSalvarMarkup.ImageIndex = 0
        Me.BttSalvarMarkup.ImageList = Me.ImageList1
        Me.BttSalvarMarkup.Location = New System.Drawing.Point(1373, 0)
        Me.BttSalvarMarkup.Name = "BttSalvarMarkup"
        Me.BttSalvarMarkup.Size = New System.Drawing.Size(110, 38)
        Me.BttSalvarMarkup.TabIndex = 51
        Me.BttSalvarMarkup.Text = "fechar"
        Me.BttSalvarMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttSalvarMarkup.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Close_Icon_icon-icons.com_69144.png")
        Me.ImageList1.Images.SetKeyName(1, "arrowdown_flech_1539.png")
        Me.ImageList1.Images.SetKeyName(2, "uparrow_arriba_1538.png")
        Me.ImageList1.Images.SetKeyName(3, "ic_select_all_128_28720.png")
        Me.ImageList1.Images.SetKeyName(4, "calendar-icon_34471.png")
        Me.ImageList1.Images.SetKeyName(5, "ic_attach_money_128_28210.png")
        '
        'PnnDia01
        '
        Me.PnnDia01.Controls.Add(Me.Panel6)
        Me.PnnDia01.Controls.Add(Me.LblD01)
        Me.PnnDia01.Location = New System.Drawing.Point(4, 32)
        Me.PnnDia01.Name = "PnnDia01"
        Me.PnnDia01.Size = New System.Drawing.Size(205, 312)
        Me.PnnDia01.TabIndex = 90
        '
        'LblD01
        '
        Me.LblD01.BackColor = System.Drawing.Color.Gainsboro
        Me.LblD01.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblD01.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblD01.Location = New System.Drawing.Point(3, 0)
        Me.LblD01.Name = "LblD01"
        Me.LblD01.Size = New System.Drawing.Size(221, 20)
        Me.LblD01.TabIndex = 91
        Me.LblD01.Text = "Entradas"
        Me.LblD01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 260)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(205, 52)
        Me.Panel6.TabIndex = 92
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Controls.Add(Me.LblD02)
        Me.Panel7.Location = New System.Drawing.Point(215, 32)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(205, 312)
        Me.Panel7.TabIndex = 91
        '
        'Panel8
        '
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 260)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(205, 52)
        Me.Panel8.TabIndex = 92
        '
        'LblD02
        '
        Me.LblD02.BackColor = System.Drawing.Color.Gainsboro
        Me.LblD02.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblD02.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblD02.Location = New System.Drawing.Point(3, 0)
        Me.LblD02.Name = "LblD02"
        Me.LblD02.Size = New System.Drawing.Size(221, 20)
        Me.LblD02.TabIndex = 91
        Me.LblD02.Text = "Entradas"
        Me.LblD02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Controls.Add(Me.LblD03)
        Me.Panel9.Location = New System.Drawing.Point(426, 32)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(205, 312)
        Me.Panel9.TabIndex = 93
        '
        'Panel10
        '
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 260)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(205, 52)
        Me.Panel10.TabIndex = 92
        '
        'LblD03
        '
        Me.LblD03.BackColor = System.Drawing.Color.Gainsboro
        Me.LblD03.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblD03.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblD03.Location = New System.Drawing.Point(3, 0)
        Me.LblD03.Name = "LblD03"
        Me.LblD03.Size = New System.Drawing.Size(221, 20)
        Me.LblD03.TabIndex = 91
        Me.LblD03.Text = "Entradas"
        Me.LblD03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Controls.Add(Me.LblD04)
        Me.Panel11.Location = New System.Drawing.Point(637, 32)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(205, 312)
        Me.Panel11.TabIndex = 93
        '
        'Panel12
        '
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel12.Location = New System.Drawing.Point(0, 260)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(205, 52)
        Me.Panel12.TabIndex = 92
        '
        'LblD04
        '
        Me.LblD04.BackColor = System.Drawing.Color.Gainsboro
        Me.LblD04.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblD04.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblD04.Location = New System.Drawing.Point(3, 0)
        Me.LblD04.Name = "LblD04"
        Me.LblD04.Size = New System.Drawing.Size(221, 20)
        Me.LblD04.TabIndex = 91
        Me.LblD04.Text = "Entradas"
        Me.LblD04.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.Panel14)
        Me.Panel13.Controls.Add(Me.LblD05)
        Me.Panel13.Location = New System.Drawing.Point(848, 32)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(205, 312)
        Me.Panel13.TabIndex = 93
        '
        'Panel14
        '
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel14.Location = New System.Drawing.Point(0, 260)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(205, 52)
        Me.Panel14.TabIndex = 92
        '
        'LblD05
        '
        Me.LblD05.BackColor = System.Drawing.Color.Gainsboro
        Me.LblD05.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblD05.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblD05.Location = New System.Drawing.Point(3, 0)
        Me.LblD05.Name = "LblD05"
        Me.LblD05.Size = New System.Drawing.Size(221, 20)
        Me.LblD05.TabIndex = 91
        Me.LblD05.Text = "Entradas"
        Me.LblD05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.Panel16)
        Me.Panel15.Controls.Add(Me.LblD06)
        Me.Panel15.Location = New System.Drawing.Point(1059, 32)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(205, 312)
        Me.Panel15.TabIndex = 94
        '
        'Panel16
        '
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel16.Location = New System.Drawing.Point(0, 260)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(205, 52)
        Me.Panel16.TabIndex = 92
        '
        'LblD06
        '
        Me.LblD06.BackColor = System.Drawing.Color.Gainsboro
        Me.LblD06.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblD06.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblD06.Location = New System.Drawing.Point(3, 0)
        Me.LblD06.Name = "LblD06"
        Me.LblD06.Size = New System.Drawing.Size(221, 20)
        Me.LblD06.TabIndex = 91
        Me.LblD06.Text = "Entradas"
        Me.LblD06.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.Panel18)
        Me.Panel17.Controls.Add(Me.LblD07)
        Me.Panel17.Location = New System.Drawing.Point(1270, 32)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(205, 312)
        Me.Panel17.TabIndex = 95
        '
        'Panel18
        '
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel18.Location = New System.Drawing.Point(0, 260)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(205, 52)
        Me.Panel18.TabIndex = 92
        '
        'LblD07
        '
        Me.LblD07.BackColor = System.Drawing.Color.Gainsboro
        Me.LblD07.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblD07.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblD07.Location = New System.Drawing.Point(3, 0)
        Me.LblD07.Name = "LblD07"
        Me.LblD07.Size = New System.Drawing.Size(221, 20)
        Me.LblD07.TabIndex = 91
        Me.LblD07.Text = "Entradas"
        Me.LblD07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(4, 353)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1469, 1)
        Me.Label1.TabIndex = 96
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(7, 367)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(624, 20)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Despesas fixas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(634, 367)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1, 328)
        Me.Label3.TabIndex = 98
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmCalendárioFinanceiro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1485, 737)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel17)
        Me.Controls.Add(Me.Panel15)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.PnnDia01)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCalendárioFinanceiro"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCalendárioFinanceiro"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.PnnDia01.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BttSalvarMarkup As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents PnnDia01 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents LblD01 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LblD02 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents LblD03 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents LblD04 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents LblD05 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents LblD06 As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents LblD07 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
