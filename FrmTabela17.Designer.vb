<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTabela17
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtDescricao = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.DtCIDS = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BttSalvarProduto = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        CType(Me.DtCIDS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtDescricao
        '
        Me.TxtDescricao.BackColor = System.Drawing.Color.White
        Me.TxtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescricao.Enabled = False
        Me.TxtDescricao.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescricao.Location = New System.Drawing.Point(176, 41)
        Me.TxtDescricao.Name = "TxtDescricao"
        Me.TxtDescricao.Size = New System.Drawing.Size(370, 21)
        Me.TxtDescricao.TabIndex = 273
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(9, 45)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(112, 17)
        Me.Label54.TabIndex = 272
        Me.Label54.Text = "Descrição da lesão"
        '
        'DtCIDS
        '
        Me.DtCIDS.AllowUserToAddRows = False
        Me.DtCIDS.AllowUserToDeleteRows = False
        Me.DtCIDS.AllowUserToResizeColumns = False
        Me.DtCIDS.AllowUserToResizeRows = False
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Calibri", 10.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.DtCIDS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15
        Me.DtCIDS.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DtCIDS.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtCIDS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.DtCIDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtCIDS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtCIDS.DefaultCellStyle = DataGridViewCellStyle19
        Me.DtCIDS.EnableHeadersVisualStyles = False
        Me.DtCIDS.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DtCIDS.Location = New System.Drawing.Point(11, 74)
        Me.DtCIDS.MultiSelect = False
        Me.DtCIDS.Name = "DtCIDS"
        Me.DtCIDS.ReadOnly = True
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtCIDS.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.DtCIDS.RowHeadersVisible = False
        Me.DtCIDS.RowHeadersWidth = 51
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.DtCIDS.RowsDefaultCellStyle = DataGridViewCellStyle21
        Me.DtCIDS.RowTemplate.Height = 24
        Me.DtCIDS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtCIDS.Size = New System.Drawing.Size(535, 277)
        Me.DtCIDS.TabIndex = 271
        '
        'Column1
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle17
        Me.Column1.HeaderText = "Código"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle18
        Me.Column2.HeaderText = "Descrição"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 389)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(561, 32)
        Me.PnnInferior.TabIndex = 270
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(504, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvarProduto)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(504, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(57, 32)
        Me.Panel12.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(561, 23)
        Me.Label1.TabIndex = 269
        Me.Label1.Text = "Tabela SST"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Panel1.Location = New System.Drawing.Point(562, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 420)
        Me.Panel1.TabIndex = 274
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Panel2.Location = New System.Drawing.Point(0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 420)
        Me.Panel2.TabIndex = 275
        '
        'BttSalvarProduto
        '
        Me.BttSalvarProduto.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvarProduto.FlatAppearance.BorderSize = 0
        Me.BttSalvarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvarProduto.Location = New System.Drawing.Point(8, 8)
        Me.BttSalvarProduto.Name = "BttSalvarProduto"
        Me.BttSalvarProduto.Size = New System.Drawing.Size(14, 17)
        Me.BttSalvarProduto.TabIndex = 29
        Me.BttSalvarProduto.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(32, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(14, 17)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Panel3.Location = New System.Drawing.Point(0, 421)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(563, 1)
        Me.Panel3.TabIndex = 276
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(563, 1)
        Me.Panel5.TabIndex = 277
        '
        'FrmTabela17
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 422)
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
        Me.Name = "FrmTabela17"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTabela17"
        CType(Me.DtCIDS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtDescricao As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents DtCIDS As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvarProduto As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
End Class
