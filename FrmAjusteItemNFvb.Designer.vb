<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjusteItemNFvb
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
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbCST = New System.Windows.Forms.ComboBox()
        Me.CmbCFOP = New System.Windows.Forms.ComboBox()
        Me.TxtNCM = New System.Windows.Forms.TextBox()
        Me.TxtEAN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PnnInferior.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(769, 26)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Ajuste da nota fiscal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel6)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 254)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(769, 36)
        Me.PnnInferior.TabIndex = 58
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(683, 5)
        Me.Panel6.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BtnOk)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(683, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(86, 36)
        Me.Panel12.TabIndex = 28
        '
        'BtnOk
        '
        Me.BtnOk.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BtnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnOk.FlatAppearance.BorderSize = 0
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.Location = New System.Drawing.Point(13, 8)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(18, 19)
        Me.BtnOk.TabIndex = 29
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(52, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(18, 19)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 290)
        Me.Panel1.TabIndex = 59
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(770, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 290)
        Me.Panel2.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 17)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "CST"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 17)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "CFOP"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 17)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "NCM"
        '
        'CmbCST
        '
        Me.CmbCST.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCST.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCST.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbCST.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCST.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbCST.FormattingEnabled = True
        Me.CmbCST.Location = New System.Drawing.Point(12, 135)
        Me.CmbCST.Name = "CmbCST"
        Me.CmbCST.Size = New System.Drawing.Size(743, 25)
        Me.CmbCST.TabIndex = 143
        '
        'CmbCFOP
        '
        Me.CmbCFOP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCFOP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCFOP.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmbCFOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCFOP.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.CmbCFOP.FormattingEnabled = True
        Me.CmbCFOP.Location = New System.Drawing.Point(12, 76)
        Me.CmbCFOP.Name = "CmbCFOP"
        Me.CmbCFOP.Size = New System.Drawing.Size(743, 25)
        Me.CmbCFOP.TabIndex = 144
        '
        'TxtNCM
        '
        Me.TxtNCM.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtNCM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNCM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNCM.Enabled = False
        Me.TxtNCM.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNCM.Location = New System.Drawing.Point(12, 197)
        Me.TxtNCM.MaxLength = 8
        Me.TxtNCM.Name = "TxtNCM"
        Me.TxtNCM.Size = New System.Drawing.Size(231, 21)
        Me.TxtNCM.TabIndex = 150
        '
        'TxtEAN
        '
        Me.TxtEAN.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtEAN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEAN.Enabled = False
        Me.TxtEAN.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtEAN.Location = New System.Drawing.Point(258, 197)
        Me.TxtEAN.Name = "TxtEAN"
        Me.TxtEAN.Size = New System.Drawing.Size(497, 21)
        Me.TxtEAN.TabIndex = 152
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(255, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 17)
        Me.Label5.TabIndex = 151
        Me.Label5.Text = "EAN"
        '
        'FrmAjusteItemNFvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(771, 290)
        Me.Controls.Add(Me.TxtEAN)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtNCM)
        Me.Controls.Add(Me.CmbCFOP)
        Me.Controls.Add(Me.CmbCST)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmAjusteItemNFvb"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAjusteItemNFvb"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CmbCST As ComboBox
    Friend WithEvents CmbCFOP As ComboBox
    Friend WithEvents TxtNCM As TextBox
    Friend WithEvents TxtEAN As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnOk As Button
End Class
