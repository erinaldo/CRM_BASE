<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTodosServicos
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTodosServicos))
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttAprovarOrc = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DtBddIARA = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmExcluir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.DtBddIARA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(905, 26)
        Me.LblTitulo.TabIndex = 39
        Me.LblTitulo.Text = "Serviços cadastrados"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.LblIdVistoria)
        Me.PnnInferior.Controls.Add(Me.LblIdSolução)
        Me.PnnInferior.Controls.Add(Me.LblIdmarca)
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Controls.Add(Me.BttAprovarOrc)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 638)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(905, 36)
        Me.PnnInferior.TabIndex = 40
        '
        'LblIdVistoria
        '
        Me.LblIdVistoria.AutoSize = True
        Me.LblIdVistoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdVistoria.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdVistoria.Location = New System.Drawing.Point(181, 5)
        Me.LblIdVistoria.Name = "LblIdVistoria"
        Me.LblIdVistoria.Size = New System.Drawing.Size(15, 17)
        Me.LblIdVistoria.TabIndex = 48
        Me.LblIdVistoria.Text = "0"
        Me.LblIdVistoria.Visible = False
        '
        'LblIdSolução
        '
        Me.LblIdSolução.AutoSize = True
        Me.LblIdSolução.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdSolução.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdSolução.Location = New System.Drawing.Point(166, 5)
        Me.LblIdSolução.Name = "LblIdSolução"
        Me.LblIdSolução.Size = New System.Drawing.Size(15, 17)
        Me.LblIdSolução.TabIndex = 47
        Me.LblIdSolução.Text = "0"
        Me.LblIdSolução.Visible = False
        '
        'LblIdmarca
        '
        Me.LblIdmarca.AutoSize = True
        Me.LblIdmarca.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdmarca.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdmarca.Location = New System.Drawing.Point(151, 5)
        Me.LblIdmarca.Name = "LblIdmarca"
        Me.LblIdmarca.Size = New System.Drawing.Size(15, 17)
        Me.LblIdmarca.TabIndex = 46
        Me.LblIdmarca.Text = "0"
        Me.LblIdmarca.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(151, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(706, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(857, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(48, 36)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(15, 9)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(18, 19)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BttAprovarOrc
        '
        Me.BttAprovarOrc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAprovarOrc.Dock = System.Windows.Forms.DockStyle.Left
        Me.BttAprovarOrc.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttAprovarOrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAprovarOrc.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttAprovarOrc.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttAprovarOrc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttAprovarOrc.Location = New System.Drawing.Point(0, 0)
        Me.BttAprovarOrc.Name = "BttAprovarOrc"
        Me.BttAprovarOrc.Size = New System.Drawing.Size(151, 36)
        Me.BttAprovarOrc.TabIndex = 49
        Me.BttAprovarOrc.Text = "Novo serviço"
        Me.BttAprovarOrc.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 674)
        Me.Panel1.TabIndex = 41
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(906, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 674)
        Me.Panel2.TabIndex = 42
        '
        'DtBddIARA
        '
        Me.DtBddIARA.AllowUserToAddRows = False
        Me.DtBddIARA.AllowUserToDeleteRows = False
        Me.DtBddIARA.AllowUserToResizeColumns = False
        Me.DtBddIARA.AllowUserToResizeRows = False
        Me.DtBddIARA.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtBddIARA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtBddIARA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtBddIARA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtBddIARA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtBddIARA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtBddIARA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.ClmExcluir})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtBddIARA.DefaultCellStyle = DataGridViewCellStyle2
        Me.DtBddIARA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DtBddIARA.EnableHeadersVisualStyles = False
        Me.DtBddIARA.GridColor = System.Drawing.Color.Gainsboro
        Me.DtBddIARA.Location = New System.Drawing.Point(1, 26)
        Me.DtBddIARA.MultiSelect = False
        Me.DtBddIARA.Name = "DtBddIARA"
        Me.DtBddIARA.ReadOnly = True
        Me.DtBddIARA.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtBddIARA.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DtBddIARA.RowHeadersVisible = False
        Me.DtBddIARA.RowHeadersWidth = 50
        Me.DtBddIARA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DtBddIARA.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DtBddIARA.RowTemplate.Height = 120
        Me.DtBddIARA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtBddIARA.ShowCellErrors = False
        Me.DtBddIARA.ShowCellToolTips = False
        Me.DtBddIARA.ShowEditingIcon = False
        Me.DtBddIARA.ShowRowErrors = False
        Me.DtBddIARA.Size = New System.Drawing.Size(905, 612)
        Me.DtBddIARA.TabIndex = 60
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cod"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Descrição do serviço"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Tempo de Execução"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "Qt quadro"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 125
        '
        'Column5
        '
        Me.Column5.HeaderText = "Valor de revenda"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 125
        '
        'Column6
        '
        Me.Column6.HeaderText = "IdExterno"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        Me.Column6.Width = 125
        '
        'ClmExcluir
        '
        Me.ClmExcluir.HeaderText = ""
        Me.ClmExcluir.MinimumWidth = 6
        Me.ClmExcluir.Name = "ClmExcluir"
        Me.ClmExcluir.ReadOnly = True
        Me.ClmExcluir.Width = 50
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Cancel_40972.png")
        '
        'FrmTodosServicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 674)
        Me.Controls.Add(Me.DtBddIARA)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTodosServicos"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTodosServicos"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        CType(Me.DtBddIARA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttAprovarOrc As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DtBddIARA As DataGridView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents ClmExcluir As DataGridViewImageColumn
End Class
