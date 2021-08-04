<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTab15_16
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvarProduto = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.DtCIDS = New System.Windows.Forms.DataGridView()
        Me.TxtDescricao = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.DtCIDS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(698, 27)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Tabela SST"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 385)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(698, 36)
        Me.PnnInferior.TabIndex = 77
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(624, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvarProduto)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(624, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(74, 36)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvarProduto
        '
        Me.BttSalvarProduto.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
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
        'DtCIDS
        '
        Me.DtCIDS.AllowUserToAddRows = False
        Me.DtCIDS.AllowUserToDeleteRows = False
        Me.DtCIDS.AllowUserToResizeColumns = False
        Me.DtCIDS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.DtCIDS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DtCIDS.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DtCIDS.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtCIDS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DtCIDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtCIDS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtCIDS.DefaultCellStyle = DataGridViewCellStyle5
        Me.DtCIDS.EnableHeadersVisualStyles = False
        Me.DtCIDS.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DtCIDS.Location = New System.Drawing.Point(16, 83)
        Me.DtCIDS.MultiSelect = False
        Me.DtCIDS.Name = "DtCIDS"
        Me.DtCIDS.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtCIDS.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DtCIDS.RowHeadersVisible = False
        Me.DtCIDS.RowHeadersWidth = 51
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.DtCIDS.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DtCIDS.RowTemplate.Height = 24
        Me.DtCIDS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtCIDS.Size = New System.Drawing.Size(671, 297)
        Me.DtCIDS.TabIndex = 258
        '
        'TxtDescricao
        '
        Me.TxtDescricao.BackColor = System.Drawing.Color.White
        Me.TxtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescricao.Enabled = False
        Me.TxtDescricao.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescricao.Location = New System.Drawing.Point(204, 46)
        Me.TxtDescricao.Name = "TxtDescricao"
        Me.TxtDescricao.Size = New System.Drawing.Size(483, 21)
        Me.TxtDescricao.TabIndex = 265
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(13, 50)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(185, 17)
        Me.Label54.TabIndex = 264
        Me.Label54.Text = "Descrição da situação geradora"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 420)
        Me.Panel1.TabIndex = 266
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(699, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 420)
        Me.Panel2.TabIndex = 267
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(700, 1)
        Me.Panel3.TabIndex = 268
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 421)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(700, 1)
        Me.Panel5.TabIndex = 269
        '
        'Column1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "Código"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = "Descrição"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'FrmTab15_16
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 422)
        Me.Controls.Add(Me.TxtDescricao)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.DtCIDS)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel5)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTab15_16"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTab15_16"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.DtCIDS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvarProduto As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents DtCIDS As DataGridView
    Friend WithEvents TxtDescricao As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
End Class
