Public Class FrmVincularServicos
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmVincularServicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LstExclusao As New ListBox

        For Each row As DataGridViewRow In FrmProduto.DtServicos.Rows

            LstExclusao.Items.Add(row.Cells(1).Value)

        Next

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaServicos = From serv In LqBase.Servicos
                            Where serv.IdServico Like "*"
                            Select serv.IdServico, serv.Descricao

        For Each row In BuscaServicos.ToList

            If Not LstExclusao.Items.Contains(row.IdServico) Then

                Dim BuscaProfissionais = From prof In LqBase.ProfissionalServico
                                         Where prof.IdServico = row.IdServico
                                         Select prof.IdProfissional

                Dim Profissionais As String
                Dim C As Integer = 0

                For Each row0 In BuscaProfissionais.ToList

                    Dim BuscaNomeProfissional = From prof In LqBase.Cargos
                                                Where prof.IdCargo = row0
                                                Select prof.Descricao

                    Profissionais &= BuscaNomeProfissional.First

                    If C < BuscaProfissionais.Count - 1 Then

                        Profissionais &= "/"

                    End If

                Next

                DtProdutos.Rows.Add(False, row.IdServico, row.Descricao, Profissionais)

            End If

        Next

    End Sub


    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

        If DtProdutos.Columns(e.ColumnIndex).Name = "ClmSel" Then

            If DtProdutos.Rows(e.RowIndex).Cells(0).Value = True Then
                DtProdutos.Rows(e.RowIndex).Cells(0).Value = False
            Else
                DtProdutos.Rows(e.RowIndex).Cells(0).Value = True
            End If

        End If

    End Sub

    Private Sub Panel12_Paint(sender As Object, e As PaintEventArgs) Handles Panel12.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'salva e vincula os servicos

        For Each row As DataGridViewRow In DtProdutos.Rows

            If row.Cells(0).Value = True Then

                FrmProduto.DtServicos.Rows.Add(0, row.Cells(1).Value, row.Cells(2).Value, FrmProduto.ImageList1.Images(1))

            End If

        Next

        Me.Close()

    End Sub
End Class