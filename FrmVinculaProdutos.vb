Public Class FrmVinculaProdutos
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Public IdProduto As Integer
    Private Sub FrmVinculaProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LstExclusao As New ListBox

        For Each row As DataGridViewRow In FrmProduto.DtProdutosVinculados.Rows

            LstExclusao.Items.Add(row.Cells(1).Value)

        Next

        LstExclusao.Items.Add(IdProduto)

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaServicos = From serv In LqBase.Produtos
                            Where serv.IdProduto Like "*"
                            Select serv.IdProduto, serv.Descricao, serv.Categoria, serv.SubCategoria

        For Each row In BuscaServicos.ToList

            If Not LstExclusao.Items.Contains(row.IdProduto) Then

                DtProdutos.Rows.Add(False, row.IdProduto, row.Descricao, row.Categoria, row.SubCategoria, 0)

            End If

        Next

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

        If DtProdutos.Columns(e.ColumnIndex).Name = "ClmQt" Then

            If DtProdutos.Rows(e.RowIndex).Cells(0).Value <> True Then

                If MsgBox("Não é possível alterar a quantidade de um item não selecionado, deseja selecionar o item?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    DtProdutos.Rows(e.RowIndex).Cells(0).Value = True
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.DarkSlateGray
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.WhiteSmoke
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.DarkSlateGray
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke

                Else

                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.WhiteSmoke
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.DarkSlateGray
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.Gainsboro
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.DarkSlateGray
                    DtProdutos.Rows(e.RowIndex).Cells(5).Value = 0
                End If

            Else

                If DtProdutos.Rows(e.RowIndex).Cells(5).Value = 0 Then
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.AntiqueWhite
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.Chocolate
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.AntiqueWhite
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.Chocolate
                Else
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.DarkSlateGray
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.WhiteSmoke
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.DarkSlateGray
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                End If

            End If

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmSel" Then

            If DtProdutos.Rows(e.RowIndex).Cells(0).Value = True Then
                DtProdutos.Rows(e.RowIndex).Cells(0).Value = False
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.WhiteSmoke
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.DarkSlateGray
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.Gainsboro
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.DarkSlateGray
                DtProdutos.Rows(e.RowIndex).Cells(5).Value = 0
            Else
                DtProdutos.Rows(e.RowIndex).Cells(0).Value = True
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.DarkSlateGray
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.WhiteSmoke
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.DarkSlateGray
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke

                If DtProdutos.Rows(e.RowIndex).Cells(5).Value = 0 Then
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.AntiqueWhite
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.Chocolate
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.AntiqueWhite
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.Chocolate
                Else
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.DarkSlateGray
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.WhiteSmoke
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.DarkSlateGray
                    DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                End If

            End If

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'salva e vincula os servicos

        For Each row As DataGridViewRow In DtProdutos.Rows

            If row.Cells(0).Value = True Then

                FrmProduto.DtProdutosVinculados.Rows.Add(0, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, FrmProduto.ImageList1.Images(1))

            End If

        Next

        Me.Close()

    End Sub

    Private Sub DtProdutos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellEndEdit
        If DtProdutos.Rows(e.RowIndex).Cells(0).Value = True Then
            If DtProdutos.Rows(e.RowIndex).Cells(5).Value = 0 Then
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.AntiqueWhite
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.Chocolate
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.AntiqueWhite
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.Chocolate
            Else
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.DarkSlateGray
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.WhiteSmoke
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.DarkSlateGray
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
            End If
        End If
    End Sub
End Class