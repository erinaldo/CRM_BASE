<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVinculoModeloProduto
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
        Me.CmbFabricantes = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.CmbModelos = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvarProduto = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbAnoFab = New System.Windows.Forms.ComboBox()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(408, 26)
        Me.LblTitulo.TabIndex = 69
        Me.LblTitulo.Text = "Vinculo de modelo a produto"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbFabricantes
        '
        Me.CmbFabricantes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbFabricantes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbFabricantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbFabricantes.FormattingEnabled = True
        Me.CmbFabricantes.Location = New System.Drawing.Point(14, 61)
        Me.CmbFabricantes.Name = "CmbFabricantes"
        Me.CmbFabricantes.Size = New System.Drawing.Size(379, 23)
        Me.CmbFabricantes.TabIndex = 72
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Gainsboro
        Me.Label29.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label29.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label29.Location = New System.Drawing.Point(10, 39)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(382, 19)
        Me.Label29.TabIndex = 71
        Me.Label29.Text = "Escolha um fabricante"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbModelos
        '
        Me.CmbModelos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbModelos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbModelos.Enabled = False
        Me.CmbModelos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbModelos.FormattingEnabled = True
        Me.CmbModelos.Location = New System.Drawing.Point(14, 125)
        Me.CmbModelos.Name = "CmbModelos"
        Me.CmbModelos.Size = New System.Drawing.Size(379, 23)
        Me.CmbModelos.TabIndex = 74
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(10, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(382, 19)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Escolha um modelo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(0, 238)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(408, 36)
        Me.PnnInferior.TabIndex = 77
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(334, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvarProduto)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(334, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(74, 36)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvarProduto
        '
        Me.BttSalvarProduto.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvarProduto.Enabled = False
        Me.BttSalvarProduto.FlatAppearance.BorderSize = 0
        Me.BttSalvarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvarProduto.Location = New System.Drawing.Point(10, 8)
        Me.BttSalvarProduto.Name = "BttSalvarProduto"
        Me.BttSalvarProduto.Size = New System.Drawing.Size(18, 19)
        Me.BttSalvarProduto.TabIndex = 29
        Me.BttSalvarProduto.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(42, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(18, 19)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(10, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(382, 19)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Ano de produçao e modelo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbAnoFab
        '
        Me.CmbAnoFab.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbAnoFab.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbAnoFab.Enabled = False
        Me.CmbAnoFab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbAnoFab.FormattingEnabled = True
        Me.CmbAnoFab.Location = New System.Drawing.Point(14, 188)
        Me.CmbAnoFab.Name = "CmbAnoFab"
        Me.CmbAnoFab.Size = New System.Drawing.Size(379, 23)
        Me.CmbAnoFab.TabIndex = 79
        '
        'FrmVinculoModeloProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 274)
        Me.Controls.Add(Me.CmbAnoFab)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.CmbModelos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbFabricantes)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.LblTitulo)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmVinculoModeloProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmVinculoModeloProduto"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents CmbFabricantes As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents CmbModelos As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvarProduto As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents CmbAnoFab As ComboBox
End Class
