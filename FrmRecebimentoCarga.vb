Imports System.Net
Imports Newtonsoft.Json

Public Class FrmRecebimentoCarga
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Dim LqFinanceiro As New LqFinanceiroDataContext
    Dim LqBase As New DtCadastroDataContext
    Dim LqIara As New LqJarbesDataContext

    Private Sub FrmRecebimentoCarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Public Sub CarregaInicio()

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        LqIara.Connection.ConnectionString = FrmPrincipal.ConnectionStringIARA

        Dim BuscaCompras = From cmp In LqFinanceiro.SolicitacoesCompraFinanceiro
                           Where cmp.IdAutorizador > 0 And cmp.Recebido = False
                           Select cmp.IdCotacao, cmp.Qt, cmp.DataAutorizacao

        Dim LstFornecedores As New ListBox
        Dim itens As Integer = 0

        DtEsperados.Rows.Clear()

        For Each row In BuscaCompras.ToList

            Dim BuscaCotacao = From cot In LqFinanceiro.Cotacoes
                               Where cot.IdCotacao = row.IdCotacao
                               Select cot.IdFornecedor, cot.ValorCotado, cot.IdProduto, cot.IdSolicitacaoCad, cot.PrazoEntrega

            'If Not LstFornecedores.Items.Contains(BuscaCotacao.First.IdFornecedor) Then

            itens += 1

                Dim CodFornec As Integer

                CodFornec = BuscaCotacao.First.IdFornecedor.Remove(0, 2)

                Dim CNPJ As String
                Dim Razao As String

                If BuscaCotacao.First.IdFornecedor.StartsWith("I_") Then

                    Dim BuscaFornecedor = From fornec In LqBase.Fornecedores
                                          Where fornec.IdFornecedor = CodFornec
                                          Select fornec.Apelido, fornec.Nome, fornec.Doc

                    CNPJ = BuscaFornecedor.First.Doc
                    Razao = BuscaFornecedor.First.Nome

                Else

                    'busca pedido on line

                    'pinta a posiçao do status

                    Dim baseUrlPg As String = "http://www.iarasoftware.com.br/consulta_dados_fornecedor.php?ChaveOficina=" & BuscaCotacao.First.IdFornecedor

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientPg = New WebClient()
                    Dim contentPg = syncClientPg.DownloadString(baseUrlPg)

                    Dim readPg = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.DadosFornecedor))(contentPg)

                    CNPJ = readPg.Item(0).Doc
                    Razao = readPg.Item(0).Razao

                End If

            Dim DataEntrega As Date = row.DataAutorizacao

            Dim IdPedido As String = "ND"

            Dim LqComercial As New LqComercialDataContext
            LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

            Dim BuscaPedido = From com In LqComercial.PedidoOnLine
                              Where com.IdCotacao = row.IdCotacao
                              Select com.IdItemExterno

            If BuscaPedido.Count > 0 Then

                IdPedido = BuscaPedido.First

            End If

            DtEsperados.Rows.Add(BuscaCotacao.First.IdFornecedor, CNPJ, Razao, FormatCurrency(BuscaCotacao.First.ValorCotado * row.Qt, NumDigitsAfterDecimal:=2), FormatDateTime(row.DataAutorizacao, DateFormat.ShortDate), itens, FormatDateTime(DataEntrega.AddDays(BuscaCotacao.First.PrazoEntrega), DateFormat.ShortDate), My.Resources.mailbox_message_received_2_icon, IdPedido)

            LstFornecedores.Items.Add(BuscaCotacao.First.IdFornecedor)

            'Else

            '    For Each RowBusca As DataGridViewRow In DtEsperados.Rows

            '        If RowBusca.Cells(0).Value = BuscaCotacao.First.IdFornecedor Then

            '            itens += 1

            '            Dim ValorEncontrado As Decimal = RowBusca.Cells(3).Value

            '            RowBusca.Cells(3).Value = FormatCurrency(ValorEncontrado + (BuscaCotacao.First.ValorCotado * row.Qt))
            '            RowBusca.Cells(5).Value = itens

            '        End If

            '    Next

            'End If

        Next

        If DtEsperados.Rows.Count = 0 Then

            If MsgBox("Sem recebimento esperado no momento.", vbOKOnly) = MsgBoxResult.Ok Then

                FrmPrincipal.CarregaDashboard()

                Me.Close()

            End If

        End If

    End Sub

    Public QtSefaz As Integer = 0
    Private Sub DtEsperados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtEsperados.CellContentClick

        If DtEsperados.Columns(e.ColumnIndex).Name = "ClmImportar" Then

            If QtSefaz = 0 Then

                If DtEsperados.Rows(e.RowIndex).Cells(0).Value.StartsWith("I_") Then

                    If MsgBox("Não foi encontrado nenhum documento no orgão emissor, deseja importa-la de um arquivo?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Entrada de NF") = MsgBoxResult.No Then

                        FrmProdutosNfRecebimento.LblCNPJ.Text = DtEsperados.Rows(e.RowIndex).Cells(1).Value

                        'busca dados do fornecedor

                        Dim CodFornec As Integer

                        CodFornec = DtEsperados.Rows(e.RowIndex).Cells(0).Value.Remove(0, 2)

                        If DtEsperados.Rows(e.RowIndex).Cells(0).Value.StartsWith("I_") Then

                            Dim BuscaFornecedor = From fornec In LqBase.Fornecedores
                                                  Where fornec.IdFornecedor = CodFornec
                                                  Select fornec.Apelido, fornec.Nome, fornec.Doc, fornec.IdEndereco

                            FrmProdutosNfRecebimento.LblRazaoSocial.Text = BuscaFornecedor.First.Nome

                            'busca endereço cadastrado

                            Dim BuscaEndereço = From ende In LqBase.Enderecos
                                                Where ende.IdEndereco = BuscaFornecedor.First.IdEndereco
                                                Select ende.DescricaoLogradouros, ende.Descricao, ende.IdBairro, ende.CEP

                            Dim BuscaBairro = From bairro In LqBase.Bairro
                                              Where bairro.IdBairro = BuscaEndereço.First.IdBairro
                                              Select bairro.IdCidade, bairro.Descricao

                            Dim BuscaCidade = From Cid In LqBase.Cidade
                                              Where Cid.IdCidade = BuscaBairro.First.IdCidade
                                              Select Cid.IdEstado, Cid.Descricao

                            Dim BuscaEstado = From est In LqBase.Estados
                                              Where est.IdEstado = BuscaCidade.First.IdEstado
                                              Select est.IdPais, est.Sigla, est.Descricao

                            Dim BuscaPais = From pais In LqBase.Paises
                                            Where pais.IdPais = BuscaEstado.First.IdPais
                                            Select pais.Sigla, pais.Descricao

                            FrmProdutosNfRecebimento.LblEndereço.Text = BuscaEndereço.First.CEP & " - " & BuscaEndereço.First.Descricao & ", " & BuscaBairro.First.Descricao & ", " & BuscaCidade.First.Descricao & " - " & BuscaEstado.First.Sigla & " (" & BuscaEstado.First.Descricao & ") - " & BuscaPais.First.Sigla & " (" & BuscaPais.First.Descricao & ")"
                            FrmProdutosNfRecebimento.LblCodFornec.Text = DtEsperados.Rows(e.RowIndex).Cells(0).Value

                            'insere os produtos que foram designados para esta nota fiscal

                            Dim BuscaProdutosFornecedor

                            FrmProdutosNfRecebimento.BttImportar.Visible = False
                            FrmProdutosNfRecebimento.BttImportarAgain.Visible = False

                            FrmProdutosNfRecebimento.TxtDataEmissão.Visible = True
                            FrmProdutosNfRecebimento.TxtValorDocumento.Visible = True
                            FrmProdutosNfRecebimento.TxtNf.Visible = True

                            FrmProdutosNfRecebimento.LblDataEmissão.Visible = False
                            'FrmProdutosNfRecebimento.TxtValorDocumento.Visible = True
                            FrmProdutosNfRecebimento.LblNumNf.Visible = False

                            FrmProdutosNfRecebimento.TxtValorDocumento.Visible = True
                            FrmProdutosNfRecebimento.LblValorNfLanc.Visible = False

                            FrmProdutosNfRecebimento.CkNaoEnota.Visible = True

                        Else

                            'consulta dados do emissor no banco centralizado

                            'busca pedido on line

                            'pinta a posiçao do status

                            Dim baseUrlPg As String = "http://www.iarasoftware.com.br/consulta_dados_fornecedor.php?ChaveOficina=" & DtEsperados.Rows(e.RowIndex).Cells(0).Value

                            'carrega informações no site

                            ' Chamada sincrona
                            Dim syncClientPg = New WebClient()
                            Dim contentPg = syncClientPg.DownloadString(baseUrlPg)

                            Dim readPg = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.DadosFornecedor))(contentPg)

                            FrmProdutosNfRecebimento.LblCodFornec.Text = DtEsperados.Rows(e.RowIndex).Cells(0).Value
                            FrmProdutosNfRecebimento.LblRazaoSocial.Text = readPg.Item(0).Razao
                            FrmProdutosNfRecebimento.LblIE.Text = readPg.Item(0).inscricao

                            Dim Endereço As String = readPg.Item(0).Cep & " "

                            Me.Cursor = Cursors.WaitCursor

                            Dim ds As New DataSet()
                            Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", readPg.Item(0).Cep)
                            ds.ReadXml(xml)
                            Endereço &= ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString() & ", " & readPg.Item(0).Numero & " (" & readPg.Item(0).Complemento & ") - "
                            Endereço &= ds.Tables(0).Rows(0)("bairro").ToString() & " - "
                            Endereço &= ds.Tables(0).Rows(0)("cidade").ToString() & " - "
                            Endereço &= ds.Tables(0).Rows(0)("uf").ToString() & " - "
                            Endereço &= "Brasil"

                            FrmProdutosNfRecebimento.LblEndereço.Text = Endereço

                            FrmProdutosNfRecebimento.TxtNf.Visible = False
                            FrmProdutosNfRecebimento.LblNumNf.Visible = True
                            FrmProdutosNfRecebimento.LblNumNf.Text = "00"

                            FrmProdutosNfRecebimento.TxtDataEmissão.Visible = False
                            FrmProdutosNfRecebimento.LblDataEmissão.Visible = True
                            FrmProdutosNfRecebimento.LblDataEmissão.Text = Today.Date

                            FrmProdutosNfRecebimento.TxtValorDocumento.Visible = False
                            FrmProdutosNfRecebimento.LblValorNfLanc.Visible = True
                            FrmProdutosNfRecebimento.LblValorNfLanc.Text = "R$ 0,00"

                            FrmProdutosNfRecebimento.CkNaoEnota.Visible = False

                            FrmProdutosNfRecebimento.BttImportar.Visible = False
                            FrmProdutosNfRecebimento.BttImportarAgain.Visible = False

                            'busca itens do pedido 

                            Dim baseUrlItens As String = "http://www.iarasoftware.com.br/consulta_itens_pedido.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdPedido=" & DtEsperados.Rows(e.RowIndex).Cells(8).Value & "&ChaveFornecedor=" & DtEsperados.Rows(e.RowIndex).Cells(0).Value

                            'carrega informações no site

                            ' Chamada sincrona
                            Dim syncClientItens = New WebClient()
                            Dim contentItens = syncClientItens.DownloadString(baseUrlItens)

                            Dim readItens = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentItens)

                            If readItens.Count > 0 Then
                                Dim ChaveEntregador As String = readItens.Item(0).Id
                                FrmProdutosNfRecebimento.BttLiberarEntregador.Enabled = False

                                If Not ChaveEntregador.StartsWith("RET") Then
                                    If Not ChaveEntregador.StartsWith("ENT") Then
                                        If Not ChaveEntregador.StartsWith("AGN") Then
                                            FrmProdutosNfRecebimento.BttLiberarEntregador.Enabled = True
                                        End If
                                    End If
                                End If
                            End If

                        End If

                        Me.Cursor = Cursors.Arrow

                        FrmProdutosNfRecebimento.Show(Me)

                    Else

                        FrmProdutosNfRecebimento.LblCNPJ.Text = DtEsperados.Rows(e.RowIndex).Cells(1).Value

                        'busca dados do fornecedor

                        Dim CodFornec As Integer

                        CodFornec = DtEsperados.Rows(e.RowIndex).Cells(0).Value.Remove(0, 2)

                        If DtEsperados.Rows(e.RowIndex).Cells(0).Value.StartsWith("I_") Then

                            Dim BuscaFornecedor = From fornec In LqBase.Fornecedores
                                                  Where fornec.IdFornecedor = CodFornec
                                                  Select fornec.Apelido, fornec.Nome, fornec.Doc, fornec.IdEndereco

                            FrmProdutosNfRecebimento.LblRazaoSocial.Text = BuscaFornecedor.First.Nome

                            'busca endereço cadastrado

                            Dim BuscaEndereço = From ende In LqBase.Enderecos
                                                Where ende.IdEndereco = BuscaFornecedor.First.IdEndereco
                                                Select ende.DescricaoLogradouros, ende.Descricao, ende.IdBairro, ende.CEP

                            Dim BuscaBairro = From bairro In LqBase.Bairro
                                              Where bairro.IdBairro = BuscaEndereço.First.IdBairro
                                              Select bairro.IdCidade, bairro.Descricao

                            Dim BuscaCidade = From Cid In LqBase.Cidade
                                              Where Cid.IdCidade = BuscaBairro.First.IdCidade
                                              Select Cid.IdEstado, Cid.Descricao

                            Dim BuscaEstado = From est In LqBase.Estados
                                              Where est.IdEstado = BuscaCidade.First.IdEstado
                                              Select est.IdPais, est.Sigla, est.Descricao

                            Dim BuscaPais = From pais In LqBase.Paises
                                            Where pais.IdPais = BuscaEstado.First.IdPais
                                            Select pais.Sigla, pais.Descricao

                            FrmProdutosNfRecebimento.LblEndereço.Text = BuscaEndereço.First.CEP & " - " & BuscaEndereço.First.Descricao & ", " & BuscaBairro.First.Descricao & ", " & BuscaCidade.First.Descricao & " - " & BuscaEstado.First.Sigla & " (" & BuscaEstado.First.Descricao & ") - " & BuscaPais.First.Sigla & " (" & BuscaPais.First.Descricao & ")"
                            FrmProdutosNfRecebimento.LblCodFornec.Text = DtEsperados.Rows(e.RowIndex).Cells(0).Value

                        Else

                            'Dim BuscaIara = From iara In LqIara.ClientesJv
                            '                Where iara.IdClienteJv = CodFornec
                            '                Select iara.NomeCompletoJv, iara.DOCJv, iara.EnderecoJv

                            'FrmProdutosNfRecebimento.LblRazaoSocial.Text = BuscaIara.First.NomeCompletoJv
                            'FrmProdutosNfRecebimento.LblEndereço.Text = BuscaIara.First.EnderecoJv
                            'FrmProdutosNfRecebimento.LblCodFornec.Text = DtEsperados.Rows(e.RowIndex).Cells(0).Value

                        End If

                        FrmProdutosNfRecebimento.BttImportar.Visible = True

                        FrmProdutosNfRecebimento.TxtDataEmissão.Visible = False
                        FrmProdutosNfRecebimento.TxtValorDocumento.Visible = False
                        FrmProdutosNfRecebimento.TxtNf.Visible = False

                        FrmProdutosNfRecebimento.LblDataEmissão.Visible = True
                        FrmProdutosNfRecebimento.ClmExcluir.Visible = True
                        'FrmProdutosNfRecebimento.TxtValorDocumento.Visible = True
                        FrmProdutosNfRecebimento.LblNumNf.Visible = True

                        FrmProdutosNfRecebimento.CkNaoEnota.Visible = False

                        FrmProdutosNfRecebimento.Show(Me)

                        FrmProdutosNfRecebimento.BttImportar.PerformClick()

                    End If

                Else

                    'busca dados internos do pedido
                    'consulta dados da emissao da nf

                    If DtEsperados.Rows(e.RowIndex).Cells(8).Value <> "ND" Then
                        Dim baseUrl_Carga As String = "http://www.iarasoftware.com.br/consulta_nfe_pedido.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&ChaveFornecedor=" & DtEsperados.Rows(e.RowIndex).Cells(0).Value.ToString & "&IdPedido=" & DtEsperados.Rows(e.RowIndex).Cells(8).Value.ToString
                        Dim syncCarga = New WebClient()
                        Dim content_item_Carga = syncCarga.DownloadString(baseUrl_Carga)
                    End If

                End If

            End If

        End If

    End Sub

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        If QtSefaz = 0 Then

            If MsgBox("Não foi encontrado nenhum documento no orgão emissor, deseja importa-la de um arquivo?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Entrada de NF") = MsgBoxResult.No Then

                FrmProdutosNfRecebimento.BttImportar.Visible = False
                FrmProdutosNfRecebimento.TxtDataEmissão.Visible = True
                FrmProdutosNfRecebimento.TxtValorDocumento.Visible = True
                FrmProdutosNfRecebimento.TxtNf.Visible = True

                FrmProdutosNfRecebimento.LblDataEmissão.Visible = False
                FrmProdutosNfRecebimento.ClmExcluir.Visible = True

                'FrmProdutosNfRecebimento.TxtValorDocumento.Visible = True
                FrmProdutosNfRecebimento.LblNumNf.Visible = False

                FrmProdutosNfRecebimento.CkNaoEnota.Visible = True

                FrmProdutosNfRecebimento.Show(Me)

            Else

                FrmProdutosNfRecebimento.BttImportar.Visible = True

                FrmProdutosNfRecebimento.TxtDataEmissão.Visible = False
                FrmProdutosNfRecebimento.TxtValorDocumento.Visible = False
                FrmProdutosNfRecebimento.TxtNf.Visible = False

                FrmProdutosNfRecebimento.LblDataEmissão.Visible = True
                FrmProdutosNfRecebimento.ClmExcluir.Visible = False
                'FrmProdutosNfRecebimento.TxtValorDocumento.Visible = True
                FrmProdutosNfRecebimento.LblNumNf.Visible = True

                FrmProdutosNfRecebimento.CkNaoEnota.Visible = False

                FrmProdutosNfRecebimento.Show(Me)

                FrmProdutosNfRecebimento.BttImportar.PerformClick()

            End If

        End If

    End Sub
End Class
