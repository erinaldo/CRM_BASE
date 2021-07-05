Imports System.Net

Public Class FrmEntregar
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub BtnEntregar_Click(sender As Object, e As EventArgs) Handles BtnEntregar.Click

        'baixa do estoque

        Dim LqEstoque As New LqEstoqueLocalDataContext
        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        Dim _QtRest As Integer = 0

        For Each row As DataGridViewRow In DtLiberações.Rows

            Dim NomeEndereco As String = row.Cells(2).Value.ToString
            Dim IdEndereco As String = row.Cells(7).Value.ToString

            'atualiza quantidade no estoque
            Dim BuscaEndereco = From ende In LqEstoque.Armazenagem
                                Where ende.Endereco Like NomeEndereco
                                Select ende.Qt, ende.IdArmazenagem, ende.NF, ende.IdProduto, ende.IdFornecedor

            If NomeEndereco.StartsWith("temp") Then

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaFornecedor = From fornec In LqBase.Fornecedores
                                      Where fornec.IdFornecedor = BuscaEndereco.First.IdFornecedor.Remove(0, 2)
                                      Select fornec.Nome

                'busca o id do endereco

                'baixa armazenagem

                Dim QtdadeEstocada As Integer = BuscaEndereco.First.Qt
                Dim QtRetirar As Integer = row.Cells(1).Value

                Dim Retirado As Integer = 0

                If (QtdadeEstocada - (QtRetirar + _QtRest)) > 0 Then

                    Retirado = QtRetirar

                    'LqEstoque.AtualizaRetiradaarmazenagem(BuscaEndereco.First.IdArmazenagem, "1111-11-11", Today.TimeOfDay, Retirado, FrmPrincipal.IdUsuario)

                    'retira

                    'insere nf produto on line

                    'Dim baseUrl As String = "http://www.iarasoftware.com.br/create_item_nf.php?NumNF=" & BuscaEndereco.First.NF & " - " & BuscaFornecedor.First & "&IdProdutoInt=" & BuscaEndereco.First.IdProduto & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdSolicitacao=" & row.Cells(4).Value.ToString & "&QtSolicitado=" & Retirado & "&Descricao=" & row.Cells(0).Value

                    ''carrega informações no site

                    '' Chamada sincrona
                    'Dim syncClient = New WebClient()
                    'Dim content = syncClient.DownloadString(baseUrl)

                    'cria baixa do endereço

                    LqEstoque.InsereBaixaEstoque(BuscaEndereco.First.IdArmazenagem, Retirado, row.Cells(4).Value.ToString, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaEndereco.First.NF, BuscaEndereco.First.IdProduto)
                    LqEstoque.AtualizaRetiradaProdutosEstoque(row.Cells(4).Value.ToString, row.Cells(1).Value.ToString, True, Today.Date, Now.TimeOfDay)

                ElseIf (QtdadeEstocada - (QtRetirar + _QtRest)) = 0 Then

                    Retirado = QtRetirar

                    'LqEstoque.AtualizaRetiradaarmazenagem(BuscaEndereco.First.IdArmazenagem, Today.Date, Now.TimeOfDay, Retirado, FrmPrincipal.IdUsuario)


                    'Dim baseUrl As String = "http://www.iarasoftware.com.br/create_item_nf.php?NumNF=" & BuscaEndereco.First.NF & " - " & BuscaFornecedor.First & "&IdProdutoInt=" & BuscaEndereco.First.IdProduto & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdSolicitacao=" & row.Cells(4).Value.ToString & "&QtSolicitado=" & Retirado & "&Descricao=" & row.Cells(0).Value

                    ''carrega informações no site

                    '' Chamada sincrona
                    'Dim syncClient = New WebClient()
                    'Dim content = syncClient.DownloadString(baseUrl)

                    'cria baixa do endereço

                    LqEstoque.InsereBaixaEstoque(BuscaEndereco.First.IdArmazenagem, Retirado, row.Cells(4).Value.ToString, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaEndereco.First.NF, BuscaEndereco.First.IdProduto)
                    LqEstoque.AtualizaRetiradaProdutosEstoque(row.Cells(4).Value.ToString, row.Cells(1).Value.ToString, True, Today.Date, Now.TimeOfDay)

                ElseIf (QtdadeEstocada - (QtRetirar + _QtRest)) < 0 Then

                    Retirado = QtRetirar + (_QtRest * -1)

                    _QtRest = (QtdadeEstocada - Retirado)

                    'LqEstoque.AtualizaRetiradaarmazenagem(BuscaEndereco.First.IdArmazenagem, Today.Date, Now.TimeOfDay, Retirado, FrmPrincipal.IdUsuario)

                    'Dim baseUrl As String = "http://www.iarasoftware.com.br/create_item_nf.php?NumNF=" & BuscaEndereco.First.NF & " - " & BuscaFornecedor.First & "&IdProdutoInt=" & BuscaEndereco.First.IdProduto & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdSolicitacao=" & row.Cells(4).Value.ToString & "&QtSolicitado=" & Retirado & "&Descricao=" & row.Cells(0).Value

                    ''carrega informações no site

                    '' Chamada sincrona
                    'Dim syncClient = New WebClient()
                    'Dim content = syncClient.DownloadString(baseUrl)

                    'cria baixa do endereço

                    LqEstoque.InsereBaixaEstoque(BuscaEndereco.First.IdArmazenagem, Retirado, row.Cells(4).Value.ToString, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaEndereco.First.NF, BuscaEndereco.First.IdProduto)

                    LqEstoque.AtualizaRetiradaProdutosEstoque(row.Cells(4).Value.ToString, row.Cells(1).Value.ToString, True, Today.Date, Now.TimeOfDay)

                    'verifica se a baixa do estoque é possível

                End If

            Else

                'atualiza quantidade no estoque
                Dim BuscaEndereco0 = From ende In LqEstoque.Armazenagem
                                     Where ende.Endereco Like IdEndereco
                                     Select ende.Qt, ende.IdArmazenagem, ende.NF, ende.IdProduto, ende.IdFornecedor

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaFornecedor = From fornec In LqBase.Fornecedores
                                      Where fornec.IdFornecedor = BuscaEndereco0.First.IdFornecedor.Remove(0, 2)
                                      Select fornec.Nome

                'busca o id do endereco

                'baixa armazenagem

                Dim QtdadeEstocada As Integer = BuscaEndereco0.First.Qt
                Dim QtRetirar As Integer = row.Cells(1).Value

                Dim Retirado As Integer = 0

                If (QtdadeEstocada - (QtRetirar + _QtRest)) > 0 Then

                    Retirado = QtRetirar

                    'LqEstoque.AtualizaRetiradaarmazenagem(BuscaEndereco0.First.IdArmazenagem, "1111-11-11", Today.TimeOfDay, Retirado, FrmPrincipal.IdUsuario)

                    'retira

                    'insere nf produto on line

                    'Dim baseUrl As String = "http://www.iarasoftware.com.br/create_item_nf.php?NumNF=" & BuscaEndereco.First.NF & " - " & BuscaFornecedor.First & "&IdProdutoInt=" & BuscaEndereco.First.IdProduto & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdSolicitacao=" & row.Cells(4).Value.ToString & "&QtSolicitado=" & Retirado & "&Descricao=" & row.Cells(0).Value

                    ''carrega informações no site

                    '' Chamada sincrona
                    'Dim syncClient = New WebClient()
                    'Dim content = syncClient.DownloadString(baseUrl)

                    'cria baixa do endereço

                    LqEstoque.InsereBaixaEstoque(BuscaEndereco0.First.IdArmazenagem, Retirado, row.Cells(4).Value.ToString, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaEndereco0.First.NF, BuscaEndereco0.First.IdProduto)
                    LqEstoque.AtualizaRetiradaProdutosEstoque(row.Cells(4).Value.ToString, row.Cells(1).Value.ToString, True, Today.Date, Now.TimeOfDay)

                ElseIf (QtdadeEstocada - (QtRetirar + _QtRest)) = 0 Then

                    Retirado = QtRetirar

                    'LqEstoque.AtualizaRetiradaarmazenagem(BuscaEndereco0.First.IdArmazenagem, Today.Date, Now.TimeOfDay, Retirado, FrmPrincipal.IdUsuario)


                    'Dim baseUrl As String = "http://www.iarasoftware.com.br/create_item_nf.php?NumNF=" & BuscaEndereco.First.NF & " - " & BuscaFornecedor.First & "&IdProdutoInt=" & BuscaEndereco.First.IdProduto & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdSolicitacao=" & row.Cells(4).Value.ToString & "&QtSolicitado=" & Retirado & "&Descricao=" & row.Cells(0).Value

                    ''carrega informações no site

                    '' Chamada sincrona
                    'Dim syncClient = New WebClient()
                    'Dim content = syncClient.DownloadString(baseUrl)

                    'cria baixa do endereço

                    LqEstoque.InsereBaixaEstoque(BuscaEndereco0.First.IdArmazenagem, Retirado, row.Cells(4).Value.ToString, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaEndereco0.First.NF, BuscaEndereco0.First.IdProduto)
                    LqEstoque.AtualizaRetiradaProdutosEstoque(row.Cells(4).Value.ToString, row.Cells(1).Value.ToString, True, Today.Date, Now.TimeOfDay)
                    'atualiza solicitação do estoque
                    LqEstoque.AtualizaStatusEndereco(IdEndereco, False)

                ElseIf (QtdadeEstocada - (QtRetirar + _QtRest)) < 0 Then

                    Retirado = QtRetirar + (_QtRest * -1)

                    _QtRest = (QtdadeEstocada - Retirado)

                    'LqEstoque.AtualizaRetiradaarmazenagem(BuscaEndereco0.First.IdArmazenagem, Today.Date, Now.TimeOfDay, Retirado, FrmPrincipal.IdUsuario)

                    'Dim baseUrl As String = "http://www.iarasoftware.com.br/create_item_nf.php?NumNF=" & BuscaEndereco.First.NF & " - " & BuscaFornecedor.First & "&IdProdutoInt=" & BuscaEndereco.First.IdProduto & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdSolicitacao=" & row.Cells(4).Value.ToString & "&QtSolicitado=" & Retirado & "&Descricao=" & row.Cells(0).Value

                    ''carrega informações no site

                    '' Chamada sincrona
                    'Dim syncClient = New WebClient()
                    'Dim content = syncClient.DownloadString(baseUrl)

                    'cria baixa do endereço

                    LqEstoque.InsereBaixaEstoque(BuscaEndereco0.First.IdArmazenagem, Retirado, row.Cells(4).Value.ToString, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaEndereco0.First.NF, BuscaEndereco0.First.IdProduto)

                    LqEstoque.AtualizaRetiradaProdutosEstoque(row.Cells(4).Value.ToString, row.Cells(1).Value.ToString, True, Today.Date, Now.TimeOfDay)

                    'verifica se a baixa do estoque é possível
                    LqEstoque.AtualizaStatusEndereco(IdEndereco, False)

                End If

            End If

        Next

        'FrmDespachoSolicitações.Close()
        FrmSepararProduto.Close()

        'FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub DtLiberações_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtLiberações.CellContentClick

        'atualiza o grid

        DtLiberações.Rows(e.RowIndex).Cells(5).Value = ImageList1.Images(0)
        DtLiberações.Rows(e.RowIndex).Cells(6).Value = 1

        'verifica se ainda existem itens em aberto

        Dim C As Integer = 0

        For Each row As DataGridViewRow In DtLiberações.Rows

            If row.Cells(6).Value = 0 Then
                C += 1
            End If

        Next

        If C = 0 Then

            BtnEntregar.Enabled = True

        End If

    End Sub

    Private Sub FrmEntregar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class