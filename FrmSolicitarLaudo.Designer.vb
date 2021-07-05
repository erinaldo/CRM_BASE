<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitarLaudo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CkUsarInterna = New System.Windows.Forms.CheckBox()
        Me.DtFornecedores = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BttOk = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rt0 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ClmSolicitar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.DtFornecedores, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(698, 24)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Solicitar laudos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel9)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 388)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(698, 34)
        Me.PnnInferior.TabIndex = 69
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(625, 5)
        Me.Panel9.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttOk)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(625, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(73, 34)
        Me.Panel12.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(699, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 422)
        Me.Panel1.TabIndex = 70
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 422)
        Me.Panel2.TabIndex = 71
        '
        'CkUsarInterna
        '
        Me.CkUsarInterna.AutoSize = True
        Me.CkUsarInterna.Checked = True
        Me.CkUsarInterna.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkUsarInterna.Enabled = False
        Me.CkUsarInterna.Location = New System.Drawing.Point(16, 48)
        Me.CkUsarInterna.Name = "CkUsarInterna"
        Me.CkUsarInterna.Size = New System.Drawing.Size(152, 21)
        Me.CkUsarInterna.TabIndex = 72
        Me.CkUsarInterna.Text = "Usar engenharia local"
        Me.CkUsarInterna.UseVisualStyleBackColor = True
        '
        'DtFornecedores
        '
        Me.DtFornecedores.AllowUserToAddRows = False
        Me.DtFornecedores.AllowUserToDeleteRows = False
        Me.DtFornecedores.AllowUserToResizeColumns = False
        Me.DtFornecedores.AllowUserToResizeRows = False
        Me.DtFornecedores.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtFornecedores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtFornecedores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtFornecedores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtFornecedores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtFornecedores.ColumnHeadersHeight = 20
        Me.DtFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DtFornecedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column1, Me.Column6, Me.Column3, Me.Column10, Me.Rt0, Me.ClmSolicitar, Me.Column7})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtFornecedores.DefaultCellStyle = DataGridViewCellStyle2
        Me.DtFornecedores.EnableHeadersVisualStyles = False
        Me.DtFornecedores.Location = New System.Drawing.Point(13, 108)
        Me.DtFornecedores.MultiSelect = False
        Me.DtFornecedores.Name = "DtFornecedores"
        Me.DtFornecedores.ReadOnly = True
        Me.DtFornecedores.RowHeadersVisible = False
        Me.DtFornecedores.RowHeadersWidth = 51
        Me.DtFornecedores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtFornecedores.RowTemplate.Height = 30
        Me.DtFornecedores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DtFornecedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtFornecedores.Size = New System.Drawing.Size(671, 274)
        Me.DtFornecedores.TabIndex = 107
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(13, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(671, 24)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Engenheiros disponíveis"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BttOk
        '
        Me.BttOk.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttOk.FlatAppearance.BorderSize = 0
        Me.BttOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttOk.Location = New System.Drawing.Point(10, 8)
        Me.BttOk.Name = "BttOk"
        Me.BttOk.Size = New System.Drawing.Size(16, 18)
        Me.BttOk.TabIndex = 29
        Me.BttOk.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(41, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(16, 18)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Nome do responsável pela avaliação"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "C.R.E.A."
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Cpf / Cnpj"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        Me.Column6.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Espera"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.Width = 75
        '
        'Column10
        '
        Me.Column10.HeaderText = "Real."
        Me.Column10.MinimumWidth = 6
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 125
        '
        'Rt0
        '
        Me.Rt0.HeaderText = ""
        Me.Rt0.MinimumWidth = 6
        Me.Rt0.Name = "Rt0"
        Me.Rt0.ReadOnly = True
        Me.Rt0.Width = 90
        '
        'ClmSolicitar
        '
        Me.ClmSolicitar.HeaderText = "Solicitar"
        Me.ClmSolicitar.MinimumWidth = 6
        Me.ClmSolicitar.Name = "ClmSolicitar"
        Me.ClmSolicitar.ReadOnly = True
        Me.ClmSolicitar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ClmSolicitar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ClmSolicitar.Width = 75
        '
        'Column7
        '
        Me.Column7.HeaderText = "ChavePrestador"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        Me.Column7.Width = 125
        '
        'FrmSolicitarLaudo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 422)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtFornecedores)
        Me.Controls.Add(Me.CkUsarInterna)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSolicitarLaudo"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSolicitarLaudo"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.DtFornecedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BttOk As Button
    Friend WithEvents CkUsarInterna As CheckBox
    Friend WithEvents DtFornecedores As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Rt0 As DataGridViewImageColumn
    Friend WithEvents ClmSolicitar As DataGridViewImageColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
End Class
