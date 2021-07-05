Imports System.Xml

Public Class FrmProdutosNfRecebimento
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

    End Sub

    Dim ofd1 As New OpenFileDialog

    Public docXML As New XmlDocument

    Dim LqFinanceiro As New LqFinanceiroDataContext

    Private Sub BttImportar_Click(sender As Object, e As EventArgs) Handles BttImportar.Click

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro
        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        BttImportar.Visible = False

        'OpenFileDialog
        Me.ofd1.Multiselect = True
        Me.ofd1.Title = "Selecionar Arquivos"
        ofd1.InitialDirectory = "C:\"
        'filtra para exibir somente arquivos de imagens
        ofd1.Filter = "Texts (*.xml)|*.xml"
        ofd1.CheckFileExists = True
        ofd1.CheckPathExists = True
        ofd1.FilterIndex = 1
        ofd1.RestoreDirectory = True
        ofd1.ReadOnlyChecked = True
        ofd1.ShowReadOnly = True

        Dim Again As Boolean = False

        Dim dr As DialogResult = Me.ofd1.ShowDialog()
        If dr = System.Windows.Forms.DialogResult.OK Then

            docXML.Load(ofd1.FileName)

            Dim strRetorno As String = "",
                noPai As XmlElement,
                noFilho As XmlElement,
                noNeto As XmlElement,
                noBisneto As XmlElement,
                noTetra As XmlElement,
                nodelist As XmlNodeList = docXML.DocumentElement.ChildNodes

            DtEsperados.Rows.Clear()

            'verifica se nf já está inserida
            Dim _CNPJ As String = ""
            Dim _CepF As String = ""
            Dim NumeroNF As Integer = 0

            Dim _IdEndereço As Integer = 0
            Dim _Endereço As String = ""

            Dim _IdBairro As Integer = 0
            Dim _Bairro As String = ""

            Dim _Cidade As String = ""
            Dim _IdCidade As Integer = 0

            Dim _Estado As String = ""
            Dim _IdEstado As Integer = 0

            Dim _Pais As String = ""
            Dim _IdPais As Integer = 0

            Dim NomeFantasia As String = ""
            Dim _Fone As String = ""

            If Len(docXML.OuterXml) > 0 Then

                For Each noPai In nodelist 'Le os nós principais da NFe
                    If noPai.Name = "NFe" Then
                        For Each noFilho In noPai 'Lê os Nós secundários

                            If noFilho.Name = "infNFe" Then 'Se for o cabecalho da NFe

                                For Each noNeto In noFilho 'Lê as Tags da NFe
                                    If noNeto.Name = "ide" Then 'Verifica a identificação da NFe  
                                        For Each noBisneto In noNeto 'Verifica os valores da NFe   
                                            If noBisneto.Name = "nNF" Then
                                                TxtNf.Text = (noBisneto.InnerText)
                                                LblNumNf.Text = TxtNf.Text
                                                TxtNf.Visible = False
                                                LblNumNf.Visible = True
                                            ElseIf noBisneto.Name = "dhEmi" Then
                                                TxtDataEmissão.Text = (noBisneto.InnerText)
                                                LblDataEmissão.Text = TxtDataEmissão.Text
                                                LblDataEmissão.ForeColor = Color.SlateGray
                                                TxtDataEmissão.Visible = False
                                                LblDataEmissão.Visible = True
                                                CkNaoEnota.Visible = False
                                            ElseIf noBisneto.Name = "dhEmi" Then
                                                'TxtDataExpedição.Value = (noBisneto.InnerText)
                                            End If
                                        Next

                                    ElseIf noNeto.Name = "emit" Then 'Dados do Emitente da NFe   
                                        For Each noBisneto In noNeto
                                            'MsgBox(noBisneto.InnerText)
                                            If noBisneto.Name = "enderEmit" Then 'Dados do Endereço do emitente
                                                For Each noTetra In noBisneto
                                                    'verifica o cep
                                                    If noTetra.Name = "CEP" Then

                                                        _CepF = noTetra.InnerText

                                                    ElseIf noTetra.Name = "nro" Then

                                                        NumeroNF = noTetra.InnerText

                                                    End If
                                                    'dgvDadosDoEmitente.Rows.Add(noTetra.InnerText)
                                                Next
                                            ElseIf noBisneto.Name = "CNPJ" Then
                                                If LblCNPJ.Text <> "00.000.000/0000-00" Then
                                                    _CNPJ = noBisneto.InnerText
                                                Else

                                                    _CNPJ = noBisneto.InnerText

                                                    LblCNPJ.Text = noBisneto.InnerText
                                                    LblCNPJ.Text = LblCNPJ.Text.ToCharArray(0, 2) & "." &
                                                        LblCNPJ.Text.ToCharArray(2, 3) & "." &
                                                        LblCNPJ.Text.ToCharArray(5, 3) & "/" &
                                                        LblCNPJ.Text.ToCharArray(8, 4) & "-" &
                                                        LblCNPJ.Text.ToCharArray(12, 2)

                                                End If
                                            ElseIf noBisneto.Name = "xNome" Then
                                                LblRazaoSocial.Text = noBisneto.InnerText
                                            ElseIf noBisneto.Name = "IE" Then
                                                LblIE.Text = noBisneto.InnerText
                                            End If
                                        Next

                                    ElseIf noNeto.Name = "dest" Then 'Dados do Destinatário                                   
                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "enderDest" Then 'Dados do Endereço do emitente
                                                For Each noTetra In noBisneto
                                                    'dgvDadosDoDestinatario.Rows.Add(noTetra.InnerText)
                                                Next
                                            Else
                                                'dgvDadosDoDestinatario.Rows.Add(noBisneto.InnerText)
                                            End If
                                        Next

                                    ElseIf noNeto.Name = "transp" Then 'Dados da Transportadora
                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "transporta" Then
                                                For Each noTetra In noBisneto
                                                    'dgvTransportadora.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If

                                            If noBisneto.Name = "veicTransp" Then
                                                For Each noTetra In noBisneto
                                                    'dgvTransportadora.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If

                                            If noBisneto.Name = "vol" Then
                                                For Each noTetra In noBisneto
                                                    'dgvTransportadora.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If

                                        Next

                                    ElseIf noNeto.Name = "infAdic" Then 'Dados do Destinatário                                   
                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "obsCont" Then 'Dados do Endereço do emitente
                                                For Each noTetra In noBisneto
                                                    'dgvDadosAdicionais.Rows.Add(noTetra.InnerText)
                                                Next
                                            Else
                                                'dgvDadosAdicionais.Rows.Add(noBisneto.InnerText)
                                            End If
                                        Next

                                    ElseIf noNeto.Name = "cobr" Then 'Dados do Destinatário                                   
                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "fat" Then 'Dados da fatura
                                                For Each noTetra In noBisneto
                                                    'dgvCobrancas.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If
                                            If noBisneto.Name = "dup" Then 'Dados da duplicata
                                                For Each noTetra In noBisneto
                                                    'dgvCobrancas.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If
                                        Next

                                    ElseIf noNeto.Name = "total" Then
                                        For Each noBisneto In noNeto

                                            For Each noTetra In noBisneto
                                                If noTetra.Name = "ICMSTot" Then
                                                ElseIf noTetra.Name = "vICMS" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    Label19.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vBC" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblICMS.Text = FormatNumber(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vProd" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblProdutos.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vFrete" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorFrete.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vSeg" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorSeguro.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vDesc" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorDesconto.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vII" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblVII.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vPIS" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblPIS.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vCOFINS" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblCOFINS.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vOutro" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblOutros.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vNF" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorNf.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vTotTrib" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblTotalTributos.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vBCST" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblBaseSt.Text = FormatNumber(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vST" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorSt.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                End If
                                            Next

                                        Next

                                    ElseIf noNeto.Name = "entrega" Then 'Dados da Entrega
                                        For Each noBisneto In noNeto
                                            'dgvEntrega.Rows.Add(noBisneto.InnerText)
                                        Next

                                    ElseIf noNeto.Name = "det" Then 'Verifica os detalhes dos produtos

                                        Dim DEscricao As String = ""
                                        Dim Cod As String = ""
                                        Dim NCM As String = ""
                                        Dim EAN As String = ""
                                        Dim Qt As String = ""
                                        Dim ValorUnit As String = ""
                                        Dim IPI As String = "0"
                                        Dim ICMS As String = "0"
                                        Dim ICMS_ST As String = "0"
                                        Dim Desconto As String = "0"

                                        Dim Unidade As String = ""

                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "prod" Then 'Dados dos Produtos

                                                For Each noTetra In noBisneto

                                                    If noTetra.Name = "xProd" Then

                                                        DEscricao = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "cProd" Then

                                                        Cod = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "vDesc" Then

                                                        Desconto = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "qCom" Then

                                                        Qt = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "vProd" Then

                                                        ValorUnit = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "uCom" Then

                                                        Unidade = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "cEAN" Then

                                                        If noTetra.InnerText <> "SEM GTIN" Then
                                                            EAN = (noTetra.InnerText)
                                                        End If

                                                    ElseIf noTetra.Name = "NCM" Then

                                                        NCM = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "vICMSSTRet" Then

                                                        ICMS_ST = (noTetra.InnerText)

                                                    End If

                                                Next
                                            End If

                                            If noBisneto.Name = "ICMS" Then 'Dados do ICMS
                                                For Each noTetra In noBisneto
                                                    MsgBox(noTetra.InnerText)
                                                Next
                                            End If

                                        Next

                                        Qt = Qt.Replace(".", ",")

                                        Desconto = Desconto.Replace(".", ",")

                                        ValorUnit = ValorUnit.Replace(".", ",")

                                        Dim BuscaVinculoProduto = From prod In LqBase.VinculoProdutoFornecedor
                                                                  Where prod.IdForncedor Like LblCodFornec.Text And prod.CodFornecedor Like Cod
                                                                  Select prod.IdProduto

                                        Dim CodVinc As String = ""

                                        If BuscaVinculoProduto.Count > 0 Then

                                            CodVinc = BuscaVinculoProduto.First

                                        End If

                                        DtEsperados.Rows.Add(My.Resources.cargo_1_icon, CodVinc, Cod, DEscricao, NCM, EAN, Unidade, Qt, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), FormatCurrency(Desconto, NumDigitsAfterDecimal:=2), FormatCurrency(ValorUnit - Desconto, NumDigitsAfterDecimal:=2), FormatCurrency(IPI, NumDigitsAfterDecimal:=2), FormatCurrency(ICMS, NumDigitsAfterDecimal:=2), FormatCurrency(ICMS_ST, NumDigitsAfterDecimal:=2))

                                    End If
                                Next

                            End If
                        Next
                    Else
                        For Each noFilho In noPai 'Lê os Nós secundários
                            For Each noNeto In noFilho 'Lê as Tags da NFe
                                If noNeto.Name = "chNFe" Then
                                    LblChave.Text = noNeto.InnerText
                                End If
                            Next
                        Next
                    End If
                Next

                'verifica se nf já está inserida

                Dim BuscaNf = From nf In LqFinanceiro.NF_Entrada
                              Where nf.NumNF Like LblNumNf.Text
                              Select nf.IdFornecedor

                If BuscaNf.Count > 0 Then

                    If MsgBox("Essa nota fiscal já foi inserida no sistema.", MsgBoxStyle.OkOnly) = vbOK Then

                        Again = True

                        LimpaCampos()

                    End If

                Else

                    Again = False

                    Dim LstMeses As New ListBox

                    LstMeses.Items.Add("Jan")
                    LstMeses.Items.Add("Fev")
                    LstMeses.Items.Add("Mar")
                    LstMeses.Items.Add("Abr")
                    LstMeses.Items.Add("Mai")
                    LstMeses.Items.Add("Jun")
                    LstMeses.Items.Add("Jul")
                    LstMeses.Items.Add("Ago")
                    LstMeses.Items.Add("Set")
                    LstMeses.Items.Add("Out")
                    LstMeses.Items.Add("Nov")
                    LstMeses.Items.Add("Dez")

                    'busca CNPJ COMPAT 

                    Dim BuscaFornecedorCnpj = From doc In LqBase.Fornecedores
                                              Where doc.Doc Like _CNPJ
                                              Select doc.IdFornecedor, doc.Cep, doc.Bairro, doc.Estado, doc.Cidade, doc.IdEndereco, doc.Numero

                    If BuscaFornecedorCnpj.Count > 0 Then

                        If LblCodFornec.Text <> " " Then

                            If "I_" & BuscaFornecedorCnpj.First.IdFornecedor <> LblCodFornec.Text Then

                                MsgBox("Essa nota fiscal Não pertence a este fornecedor.", MsgBoxStyle.OkOnly)
                                LimpaCampos()

                            Else

                                Chart1.Series.Clear()

                                For Each row As DataGridViewRow In DtEsperados.Rows

                                    Dim LstValorProduto As New ListBox

                                    Dim LstProduto As New ListBox

                                    Dim MesSel As Date = Today.Date.AddMonths(-4)
                                    Dim AnoSel As Integer = MesSel.Year

                                    Dim _idProduto As Integer


                                Next

                            End If

                        Else

                            'carrega os dados do fornecedor

                            LblCodFornec.Text = BuscaFornecedorCnpj.First.IdFornecedor

                            Dim BuscaEndereco = From ende In LqBase.Enderecos
                                                Where ende.IdEndereco = BuscaFornecedorCnpj.First.IdFornecedor
                                                Select ende.Descricao, ende.IdBairro

                            LblEndereço.Text = BuscaEndereco.First.Descricao & ", " & NumeroNF & " - " &
                                " - " & BuscaFornecedorCnpj.First.Bairro & " - " & BuscaFornecedorCnpj.First.Cidade &
                                " - " & BuscaFornecedorCnpj.First.Estado

                        End If

                    Else

                        If LblCodFornec.Text <> " " Then

                            MsgBox("Essa nota fiscal Não pertence a este fornecedor.", MsgBoxStyle.OkOnly)
                            LimpaCampos()

                        Else
                            'busca cep

                            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                            'busca endereco

                            Dim buscaEndereco = From ende In LqBase.Enderecos
                                                Where ende.CEP = _CepF
                                                Select ende.IdEndereco, ende.Descricao, ende.IdBairro, ende.IdAbreviacao, ende.DescricaoLogradouros

                            If buscaEndereco.Count > 0 Then

                                _IdEndereço = buscaEndereco.First.IdEndereco

                                'busca abrviação 

                                Dim BuscaAbreviação = From abre In LqBase.DescricaoLogradouros
                                                      Where abre.IdDescricaoLog = buscaEndereco.First.IdAbreviacao
                                                      Select abre.Abreviacao

                                _Endereço = BuscaAbreviação.First & " " & buscaEndereco.First.Descricao

                                'busca bairro

                                Dim buscaBairro = From bai In LqBase.Bairro
                                                  Where bai.IdBairro = buscaEndereco.First.IdBairro
                                                  Select bai.Descricao, bai.IdCidade

                                _Bairro = buscaBairro.First.Descricao

                                'busca cidade 

                                Dim BuscaCidade = From cid In LqBase.Cidade
                                                  Where cid.IdCidade = buscaBairro.First.IdCidade
                                                  Select cid.IdEstado, cid.Descricao

                                _Cidade = BuscaCidade.First.Descricao

                                'busca estado

                                Dim BuscaEstado = From est In LqBase.Estados
                                                  Where est.IdEstado = BuscaCidade.First.IdEstado
                                                  Select est.IdPais, est.Sigla, est.Descricao

                                _Estado = BuscaEstado.First.Sigla & " - " & BuscaEstado.First.Descricao

                                _Pais = "Brasil"

                            Else

                                'Try
                                Me.Cursor = Cursors.WaitCursor

                                Dim ds As New DataSet()
                                Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", _CepF)
                                ds.ReadXml(xml)
                                _Endereço = ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString()
                                _Bairro = ds.Tables(0).Rows(0)("bairro").ToString()
                                _Cidade = ds.Tables(0).Rows(0)("cidade").ToString()
                                _Estado = ds.Tables(0).Rows(0)("uf").ToString()
                                _Pais = "Brasil"

                                'verfica tipo de logradouro

                                Dim BuscTipoLog = From log In LqBase.DescricaoLogradouros
                                                  Where log.Descricao Like ds.Tables(0).Rows(0)("tipo_logradouro").ToString()
                                                  Select log.IdDescricaoLog

                                Dim _IdDescricaoLog As Integer

                                If BuscTipoLog.Count > 0 Then

                                    _IdDescricaoLog = BuscTipoLog.First

                                Else

                                    LqBase.InsereDescricaoEndereco(ds.Tables(0).Rows(0)("tipo_logradouro").ToString(), ds.Tables(0).Rows(0)("tipo_logradouro").ToString())

                                    'verfica tipo de logradouro

                                    Dim BuscTipoLogA = From log In LqBase.DescricaoLogradouros
                                                       Where log.Descricao Like ds.Tables(0).Rows(0)("tipo_logradouro").ToString()
                                                       Select log.IdDescricaoLog

                                    _IdDescricaoLog = BuscTipoLogA.First

                                End If


                                'insere endereco

                                'verifica estado

                                Dim BuscaPais = From est In LqBase.Paises
                                                Where est.Descricao Like "Brasil"
                                                Select est.IdPais

                                If BuscaPais.Count > 0 Then
                                    'verifica a existencia do estado 

                                    Dim BuscaEstado = From est In LqBase.Estados
                                                      Where est.IdPais = BuscaPais.First And est.Descricao Like _Estado
                                                      Select est.IdEstado

                                    If BuscaEstado.Count > 0 Then
                                        'verifica a existencia do estado 

                                        Dim BuscaCidade = From est In LqBase.Cidade
                                                          Where est.IdEstado = BuscaEstado.First And est.Descricao Like _Cidade
                                                          Select est.IdCidade

                                        If BuscaCidade.Count > 0 Then
                                            'verifica a existencia do estado 

                                            Dim BuscaBairro = From est In LqBase.Bairro
                                                              Where est.IdCidade = BuscaCidade.First And est.Descricao Like _Bairro
                                                              Select est.IdBairro

                                            If BuscaBairro.Count > 0 Then
                                                'verifica a existencia do estado 

                                                Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                     Where est.IdBairro = BuscaBairro.First And est.Descricao Like _Endereço
                                                                     Select est.IdEndereco

                                                If Buscaloradouro.Count = 0 Then

                                                    LqBase.InsereEndereco(BuscaBairro.First, _Endereço, _CepF, _IdDescricaoLog)

                                                End If

                                            Else

                                                LqBase.InsereBairro(BuscaCidade.First, _Bairro)

                                                'verifica a existencia do estado 

                                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                                   Where est.IdCidade = BuscaCidade.First And est.Descricao Like _Cidade
                                                                   Select est.IdBairro

                                                If BuscaBairroA.Count > 0 Then
                                                    'verifica a existencia do estado 

                                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like _Endereço
                                                                         Select est.IdEndereco

                                                    If Buscaloradouro.Count = 0 Then

                                                        LqBase.InsereEndereco(BuscaBairroA.First, _Endereço, _CepF, _IdDescricaoLog)

                                                    End If

                                                End If

                                            End If

                                        Else


                                            LqBase.InsereCidade(BuscaEstado.First, _Cidade)

                                            'verifica a existencia do estado 

                                            Dim BuscaCidadeA = From est In LqBase.Cidade
                                                               Where est.IdEstado = BuscaEstado.First And est.Descricao Like _Cidade
                                                               Select est.IdCidade

                                            If BuscaCidadeA.Count > 0 Then

                                                LqBase.InsereBairro(BuscaCidadeA.First, _Bairro)

                                                'verifica a existencia do estado 

                                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                                   Where est.IdCidade = BuscaCidadeA.First And est.Descricao Like _Bairro
                                                                   Select est.IdBairro

                                                If BuscaBairroA.Count > 0 Then
                                                    'verifica a existencia do estado 

                                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like _Endereço
                                                                         Select est.IdEndereco

                                                    If Buscaloradouro.Count = 0 Then

                                                        LqBase.InsereEndereco(BuscaBairroA.First, _Endereço, _CepF, _IdDescricaoLog)

                                                    End If

                                                End If

                                            End If

                                        End If

                                    Else

                                        LqBase.InsereEstado(BuscaPais.First, _Estado, "", 0)

                                        'verifica a existencia do estado 

                                        Dim BuscaEstadoA = From est In LqBase.Estados
                                                           Where est.IdPais = BuscaPais.First And est.Descricao Like _Estado
                                                           Select est.IdEstado

                                        If BuscaEstadoA.Count > 0 Then

                                            LqBase.InsereCidade(BuscaEstadoA.First, _Cidade)

                                            'verifica a existencia do estado 

                                            Dim BuscaCidadeA = From est In LqBase.Cidade
                                                               Where est.IdEstado = BuscaEstadoA.First And est.Descricao Like _Cidade
                                                               Select est.IdCidade

                                            If BuscaCidadeA.Count > 0 Then

                                                LqBase.InsereBairro(BuscaCidadeA.First, _Bairro)

                                                'verifica a existencia do estado 

                                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                                   Where est.IdCidade = BuscaCidadeA.First And est.Descricao Like _Bairro
                                                                   Select est.IdBairro

                                                If BuscaBairroA.Count > 0 Then
                                                    'verifica a existencia do estado 

                                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like _Endereço
                                                                         Select est.IdEndereco

                                                    If Buscaloradouro.Count = 0 Then

                                                        LqBase.InsereEndereco(BuscaBairroA.First, _Endereço, _CepF, _IdDescricaoLog)

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                Else

                                    LqBase.InserePais("Brasil", "", 0)

                                    Dim BuscaPaisA = From est In LqBase.Paises
                                                     Where est.IdPais Like "Brasil"
                                                     Select est.IdPais

                                    If BuscaPaisA.Count > 0 Then

                                        'verifica a existencia do estado 

                                        Dim BuscaEstadoA = From est In LqBase.Estados
                                                           Where est.IdPais = BuscaPaisA.First And est.Descricao Like _Estado
                                                           Select est.IdEstado

                                        If BuscaEstadoA.Count > 0 Then

                                            LqBase.InsereCidade(BuscaEstadoA.First, _Cidade)

                                            'verifica a existencia do estado 

                                            Dim BuscaCidadeA = From est In LqBase.Cidade
                                                               Where est.IdEstado = BuscaEstadoA.First And est.Descricao Like _Cidade
                                                               Select est.IdCidade

                                            If BuscaCidadeA.Count > 0 Then

                                                LqBase.InsereBairro(BuscaCidadeA.First, _Bairro)

                                                'verifica a existencia do estado 

                                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                                   Where est.IdCidade = BuscaCidadeA.First And est.Descricao Like _Bairro
                                                                   Select est.IdBairro

                                                If BuscaBairroA.Count > 0 Then
                                                    'verifica a existencia do estado 

                                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like _Endereço
                                                                         Select est.IdEndereco

                                                    If Buscaloradouro.Count = 0 Then

                                                        LqBase.InsereEndereco(BuscaBairroA.First, _Endereço, _CepF, _IdDescricaoLog)

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                                Me.Cursor = Cursors.Arrow

                            End If

                            LqBase.InsereNovoFornecedor(_CNPJ, LblRazaoSocial.Text, _CepF, _IdEndereço, NumeroNF, "", 0, _Bairro, 0, _Cidade, 0, _Estado, 0, _Pais, _Fone, NomeFantasia, False, True, False, False, LblIE.Text)

                        End If

                    End If

                End If

            End If

        Else

            Me.Close()

        End If

        'limpa campos

        If Again = True Then

            If PressAg = False Then

                PressAg = True

                BttImportarAgain.Visible = True

                BttImportarAgain.PerformClick()

            End If

        End If

    End Sub

    Dim PressAg As Boolean = False

    Public Sub LimpaCampos()

        DtEsperados.Rows.Clear()

        LblNumNf.Text = ""

        LblValorNf.Text = "R$ 0,00"

        LblProdutos.Text = "R$ 0,00"

        LblDataEmissão.Text = ""

        LblChave.Text = ""

    End Sub

    Dim LqEstoque As New LqEstoqueLocalDataContext

    Dim LqBase As New DtCadastroDataContext

    Private Sub CkNaoEnota_CheckedChanged(sender As Object, e As EventArgs) Handles CkNaoEnota.CheckedChanged

        If CkNaoEnota.Checked = True Then

            TxtNf.Text = "CF_"
            BttImportar.Enabled = False

            TxtNf.Focus()
            TxtNf.SelectionStart = 3

        Else

            TxtNf.Text = ""
            BttImportar.Enabled = True

        End If

    End Sub

    Private Sub TxtNf_TextChanged(sender As Object, e As EventArgs) Handles TxtNf.TextChanged

        If CkNaoEnota.Checked = True Then

            If Not TxtNf.Text.StartsWith("CF_") Then
                TxtNf.Text = "CF_"
                TxtNf.SelectionStart = 3
            End If

            If TxtNf.Text.Length <= 3 Then

                TxtNf.Text = "CF_"
                TxtNf.SelectionStart = 3

                TxtDataEmissão.Enabled = False
                TxtDataEmissão.Text = ""

            Else

                TxtDataEmissão.Enabled = True

            End If

        Else

            TxtDataEmissão.Enabled = True

        End If

        If TxtNf.Visible = True Then

            LblNumNf.Text = TxtNf.Text

        End If

    End Sub

    Public LstIgnorar As New ListBox

    Private Sub TxtDataEmissão_TextChanged(sender As Object, e As EventArgs) Handles TxtDataEmissão.TextChanged

        If TxtDataEmissão.Text.Length = 8 Then

            TxtValorDocumento.Enabled = True
            TxtValorDocumento.Focus()

        Else

            TxtValorDocumento.Enabled = False
            TxtValorDocumento.Text = "R$ 0,00"

        End If

    End Sub

    Private Sub TxtValorDocumento_TextChanged(sender As Object, e As EventArgs) Handles TxtValorDocumento.TextChanged

        If TxtValorDocumento.Visible = True Then

            If TxtValorDocumento.Text = "" Then

                ClmExcluir.Visible = False

                BttAddProduto.Visible = False

                LblValorNf.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                DtEsperados.Rows.Clear()

            ElseIf TxtValorDocumento.Text <> "" Then

                Dim Vlr As Decimal = TxtValorDocumento.Text

                ClmExcluir.Visible = True

                BttAddProduto.Visible = True

                LblValorNf.Text = FormatCurrency(Vlr, NumDigitsAfterDecimal:=2)

            End If

        End If

    End Sub

    Private Sub TxtDataEmissão_GotFocus(sender As Object, e As EventArgs) Handles TxtDataEmissão.GotFocus

        If TxtDataEmissão.Text <> "" Then

            Dim Valor As Integer = TxtDataEmissão.Text.Length
            TxtDataEmissão.SelectionStart = Valor

        Else

            TxtDataEmissão.SelectionStart = 0

        End If

    End Sub

    Private Sub TxtValorDocumento_GotFocus(sender As Object, e As EventArgs) Handles TxtValorDocumento.GotFocus

        TxtValorDocumento.Text = FormatNumber(TxtValorDocumento.Text, NumDigitsAfterDecimal:=2)
        LblValorNf.Text = TxtValorDocumento.Text

        TxtValorDocumento.SelectAll()

    End Sub

    Private Sub TxtValorDocumento_LostFocus(sender As Object, e As EventArgs) Handles TxtValorDocumento.LostFocus

        Try

            TxtValorDocumento.Text = FormatCurrency(TxtValorDocumento.Text, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("O valor inserido é invalido.", vbOKOnly)
            TxtValorDocumento.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub BttAddProduto_Click(sender As Object, e As EventArgs) Handles BttAddProduto.Click

        'busca itens solicitados para este fornecedor

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaSolicitacoes = From sol In LqFinanceiro.SolicitacoesCompraFinanceiro
                                Where sol.Recebido = False
                                Select sol.IdCotacao, sol.Qt, sol.IdProduto, sol.IdSolicitacaoCad, sol.IdSolicitacaoCompra

        For Each item0 In BuscaSolicitacoes.ToList

            'busca cotacoes

            Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                           Where cot.IdCotacao = item0.IdCotacao
                           Select cot.IdFornecedor, cot.ValorCotado, cot.IdSolicitacaoCad, cot.IdProduto

            If BuscaCot.First.IdFornecedor = LblCodFornec.Text Then

                If BuscaCot.First.IdProduto <> 0 Then

                    Dim BuscaProduto = From prod In LqBase.Produtos
                                       Where prod.IdProduto = BuscaCot.First.IdProduto
                                       Select prod.Descricao

                    FrmRecebimentoEsperado.DtEsperados.Rows.Add(False, BuscaCot.First.IdProduto, BuscaProduto.First, item0.Qt, item0.IdSolicitacaoCompra)

                Else

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                       Where prod.IdSolicitacaoCadastro = BuscaCot.First.IdSolicitacaoCad
                                       Select prod.Descricao

                    FrmRecebimentoEsperado.DtEsperados.Rows.Add(False, "S" & BuscaCot.First.IdSolicitacaoCad, BuscaProduto.First, item0.Qt, item0.IdSolicitacaoCompra)

                End If

            End If

        Next

        Dim LstSeleciona As New ListBox

        For Each row As DataGridViewRow In FrmRecebimentoEsperado.DtEsperados.Rows

            For Each row2 As DataGridViewRow In DtEsperados.Rows

                If row.Cells(1).Value = row2.Cells(1).Value Then

                    row.Cells(0).Value = True

                End If

            Next

        Next

        'apaga

        Dim LstApaga As New ListBox

        For Each row As DataGridViewRow In FrmRecebimentoEsperado.DtEsperados.Rows

            For Each row2 As DataGridViewRow In DtEsperados.Rows

                If row.Cells(1).Value = row2.Cells(1).Value Then

                    LstApaga.Items.Add(row2.Index)

                End If

            Next

        Next

        For i As Integer = LstApaga.Items.Count - 1 To 0 Step -1

            Dim ValorInt As Integer = LstApaga.Items(i).ToString
            Dim Rw As DataGridViewRow = DtEsperados.Rows(ValorInt)

            DtEsperados.Rows.Remove(Rw)

        Next

        FrmRecebimentoEsperado.Show(Me)

    End Sub

    Private Sub DtEsperados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtEsperados.CellContentClick

        If DtEsperados.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            DtEsperados.Rows.RemoveAt(e.RowIndex)

        ElseIf DtEsperados.Columns(e.ColumnIndex).Name = "ClmArmazenar" Then

            If DtEsperados.Rows(e.RowIndex).Cells(14).Value = Nothing Then

                If Not DtEsperados.Rows(e.RowIndex).Cells(1).Value.ToString.StartsWith("S") Then

                    Me.Cursor = Cursors.WaitCursor

                    'verifica itens não vinculads

                    FrmReceberMercadoria.LblTitulo.Text = "Lista de items"

                    FrmReceberMercadoria.CmbItensSolicitados.Visible = True
                    FrmReceberMercadoria.LblItemSel.Visible = False

                    FrmReceberMercadoria.LblCodFornec.Text = DtEsperados.Rows(e.RowIndex).Cells(2).Value
                    FrmReceberMercadoria.LblDescriçãoItem.Text = DtEsperados.Rows(e.RowIndex).Cells(3).Value
                    FrmReceberMercadoria.LblNCM.Text = DtEsperados.Rows(e.RowIndex).Cells(4).Value
                    FrmReceberMercadoria.LblEan.Text = DtEsperados.Rows(e.RowIndex).Cells(5).Value
                    FrmReceberMercadoria.LblValorUnitário.Text = DtEsperados.Rows(e.RowIndex).Cells(8).Value

                    FrmReceberMercadoria.NumericUpDown1.Maximum = DtEsperados.Rows(e.RowIndex).Cells(7).Value

                    'valida controle de validade

                    Dim BuscaControle = From controle In LqBase.Produtos
                                        Where controle.IdProduto = DtEsperados.Rows(e.RowIndex).Cells(1).Value.ToString
                                        Select controle.ControleValidade, controle.Markup

                    'liga solicitaçãoes

                    FrmReceberMercadoria.Show(Me)

                    FrmReceberMercadoria._IdProduto = DtEsperados.Rows(e.RowIndex).Cells(1).Value.ToString

                    FrmReceberMercadoria.RdbNovo.Enabled = True
                    FrmReceberMercadoria.RdbRecon.Enabled = True
                    FrmReceberMercadoria.RdbUsado.Enabled = True

                    If DtEsperados.Rows(e.RowIndex).Cells(1).Value.ToString <> "" Then

                        'seleciona o item no combobox

                        For i As Integer = 0 To FrmReceberMercadoria.LstIdItens.Items.Count - 1 Step 1

                            If FrmReceberMercadoria.LstIdItens.Items(i).ToString = DtEsperados.Rows(e.RowIndex).Cells(1).Value Then

                                FrmReceberMercadoria.CmbItensSolicitados.SelectedIndex = i

                                FrmReceberMercadoria.LblTitulo.Text = "Item vinculado"
                                FrmReceberMercadoria.CmbItensSolicitados.Visible = False
                                FrmReceberMercadoria.LblItemSel.Visible = True
                                FrmReceberMercadoria.LblItemSel.Text = FrmReceberMercadoria.CmbItensSolicitados.Items(i).ToString
                                LstIgnorar.Items.Add(FrmReceberMercadoria.LstIdItens.Items(i).ToString)

                            End If

                        Next

                    Else

                        If FrmReceberMercadoria.CmbItensSolicitados.Items.Count = 0 Then

                            FrmReceberMercadoria.LblTitulo.Text = "descricao"

                            FrmReceberMercadoria.CmbItensSolicitados.Visible = False
                            FrmReceberMercadoria.LblItemSel.Visible = True


                        End If

                    End If

                    FrmProduto.Index = e.RowIndex

                    'popula NCM

                    FrmProduto.TxtNCM.Text = DtEsperados.Rows(e.RowIndex).Cells(4).Value
                    FrmProduto.TxtCodBarras.Text = DtEsperados.Rows(e.RowIndex).Cells(5).Value

                    Me.Cursor = Cursors.Arrow

                Else

                    If DtEsperados.Rows(e.RowIndex).Cells(2).Value <> Nothing Then

                        'cadastra produto

                        If MsgBox("Este item ainda não teve seu cadastro finalizado, irei direcioná-lo para o término do registro.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                            Dim IdSol As Integer = DtEsperados.Rows(e.RowIndex).Cells(1).Value.ToString.Remove(0, 1)

                            'busca partnumber

                            Dim LqOficina As New LqOficinaDataContext
                            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                            Dim BuscaSolicitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                                    Where sol.IdSolicitacaoCadastro = IdSol
                                                    Select sol.Markup, sol.PartNumber, sol.IdCodExt, sol.IdCategoria, sol.IdSubCategoria, sol.Fabricante

                            FrmProduto.Receb = True

                            FrmProduto.CodSol = IdSol

                            FrmProduto.Index = e.RowIndex

                            FrmProduto.Markup = BuscaSolicitacoes.First.Markup


                            Dim BuscaFabricanteCadastrado = From cat In LqBase.Fabricantes
                                                            Where cat.Fabricante Like BuscaSolicitacoes.First.Fabricante
                                                            Select cat.Fabricante, cat.IdFabricante

                            If BuscaFabricanteCadastrado.Count > 0 Then

                                Dim BuscaFabricantes = From fab In LqBase.Fabricantes
                                                       Where fab.IdFabricante Like "*"
                                                       Select fab.IdFabricante, fab.Fabricante

                                FrmProduto.LstIdFabricante.Items.Clear()
                                FrmProduto.CmbFabricante.Items.Clear()

                                For Each item In BuscaFabricantes.ToList

                                    FrmProduto.LstIdFabricante.Items.Add(item.IdFabricante)
                                    FrmProduto.CmbFabricante.Items.Add(item.Fabricante)

                                Next

                            Else

                                'insere novo fabricante 

                                LqBase.Inserefabricante(BuscaSolicitacoes.First.Fabricante)

                                '

                                Dim BuscaFabricantes = From fab In LqBase.Fabricantes
                                                       Where fab.IdFabricante Like "*"
                                                       Select fab.IdFabricante, fab.Fabricante

                                FrmProduto.LstIdFabricante.Items.Clear()
                                FrmProduto.CmbFabricante.Items.Clear()

                                For Each item In BuscaFabricantes.ToList

                                    FrmProduto.LstIdFabricante.Items.Add(item.IdFabricante)
                                    FrmProduto.CmbFabricante.Items.Add(item.Fabricante)

                                Next

                            End If

                            FrmProduto.CmbFabricante.SelectedItem = BuscaSolicitacoes.First.Fabricante

                            'popula NCM

                            FrmProduto.TxtNCM.Text = DtEsperados.Rows(e.RowIndex).Cells(4).Value
                                FrmProduto.TxtCodBarras.Text = DtEsperados.Rows(e.RowIndex).Cells(5).Value
                                FrmProduto.TxtDescrição.Text = DtEsperados.Rows(e.RowIndex).Cells(3).Value
                                FrmProduto.TxtCodFabricante.Text = BuscaSolicitacoes.First.PartNumber
                                FrmProduto.LblCodExterno.Text = BuscaSolicitacoes.First.IdCodExt

                            FrmProduto.CmbCategoria.Enabled = True

                            Dim BuscaCategorias = From cat In LqBase.CategoriasProdutos
                                                      Where cat.IdCategoriaProduto Like "*"
                                                      Select cat.Descricao, cat.IdCategoriaProduto

                                FrmProduto.LstIdCategoria.Items.Clear()

                                For Each item In BuscaCategorias.ToList

                                    FrmProduto.LstIdCategoria.Items.Add(item.IdCategoriaProduto)
                                FrmProduto.CmbCategoria.Items.Add(item.Descricao)

                                If BuscaSolicitacoes.First.IdCategoria = item.IdCategoriaProduto Then
                                    FrmProduto.CmbCategoria.SelectedItem = item.Descricao
                                    FrmProduto.CmbCategoria.Enabled = True

                                End If

                            Next


                            Dim BuscaCategoriaPorId = From cat In LqBase.CategoriasProdutos
                                                          Where cat.IdCategoriaProduto = BuscaSolicitacoes.First.IdCategoria
                                                          Select cat.Descricao, cat.IdCategoriaProduto

                            FrmProduto.CmbCategoria.Enabled = True
                            FrmProduto.CmbCategoria.SelectedItem = BuscaCategoriaPorId.First

                                Dim BuscaSubCategorias = From cat In LqBase.SubCategoriasProduto
                                                         Where cat.IdCategoria = BuscaSolicitacoes.First.IdCategoria
                                                         Select cat.Descricao, cat.IdSubCategoria

                                FrmProduto.LstIdSubCategorias.Items.Clear()

                                For Each item In BuscaSubCategorias.ToList

                                    FrmProduto.LstIdSubCategorias.Items.Add(item.IdSubCategoria)
                                    FrmProduto.CmbSubcategoria.Items.Add(item.Descricao)

                                If BuscaSolicitacoes.First.IdSubCategoria = item.IdSubCategoria Then
                                    FrmProduto.CmbSubcategoria.SelectedItem = item.Descricao
                                    FrmProduto.CmbSubcategoria.Enabled = True

                                End If

                            Next

                                Dim BuscaSubCategoriaPorId = From cat In LqBase.SubCategoriasProduto
                                                             Where cat.IdCategoria = BuscaSolicitacoes.First.IdCategoria
                                                             Select cat.Descricao, cat.IdSubCategoria

                            'FrmProduto.CmbSubcategoria.Enabled = False
                            FrmProduto.CmbSubcategoria.SelectedItem = BuscaSubCategoriaPorId.First.Descricao

                            FrmProduto.CmbFabricante.Enabled = True
                            FrmProduto.BttAddFabricante.Enabled = True

                            'cria vinculos com o fornecedor que esta vinculando

                            FrmProduto.DtVinculoFornec.Rows.Add(LblCodFornec.Text.Remove(0, 2), LblRazaoSocial.Text, DtEsperados.Rows(e.RowIndex).Cells(2).Value)

                                'Busca vinculos

                                Dim BuscaVinculoModelo = From modelo In LqOficina.AssociaçãoPeçaModelo
                                                         Where modelo.IdSolicitaçãoCad = IdSol
                                                         Select modelo.IdModeloVeic

                                For Each item In BuscaVinculoModelo.ToList

                                    Dim BuscaModelo = From modelo In LqOficina.Modelos
                                                      Where modelo.IdModelo = item
                                                      Select modelo.Modelo, modelo.IdFabricante

                                    Dim BuscaFabricante = From fab In LqOficina.FabricantesVeiculo
                                                          Where fab.Idfabricante = BuscaModelo.First.IdFabricante
                                                          Select fab.Fabricante

                                    FrmProduto.DtVinculoExterno.Rows.Add("Oficina", BuscaModelo.First.Modelo, 0, True, My.Resources.Cancel_40972, BuscaFabricante.First)

                                Next

                                Me.Cursor = Cursors.Arrow

                                FrmProduto.Show(Me)

                            End If

                        Else

                        MsgBox("É necessário inserir um código para vincular este produto a este fornecedor." & Chr(13) & "Insira a identificação do fornecedor e tente novamente", MsgBoxStyle.OkOnly)
                        DtEsperados.FirstDisplayedCell = DtEsperados.Rows(e.RowIndex).Cells(0)

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub FrmProdutosNfRecebimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BttImportarAgain_Click(sender As Object, e As EventArgs) Handles BttImportarAgain.Click

        BttImportarAgain.Visible = False

        'OpenFileDialog
        Me.ofd1.Multiselect = True
        Me.ofd1.Title = "Selecionar Arquivos"
        ofd1.InitialDirectory = "C:\"
        'filtra para exibir somente arquivos de imagens
        ofd1.Filter = "Texts (*.xml)|*.xml"
        ofd1.CheckFileExists = True
        ofd1.CheckPathExists = True
        ofd1.FilterIndex = 1
        ofd1.RestoreDirectory = True
        ofd1.ReadOnlyChecked = True
        ofd1.ShowReadOnly = True

        Dim Again As Boolean = False

        Dim dr As DialogResult = Me.ofd1.ShowDialog()
        If dr = System.Windows.Forms.DialogResult.OK Then

            docXML.Load(ofd1.FileName)

            Dim strRetorno As String = "",
                noPai As XmlElement,
                noFilho As XmlElement,
                noNeto As XmlElement,
                noBisneto As XmlElement,
                noTetra As XmlElement,
                nodelist As XmlNodeList = docXML.DocumentElement.ChildNodes

            DtEsperados.Rows.Clear()

            'verifica se nf já está inserida
            Dim _CNPJ As String = ""
            Dim _CepF As String = ""
            Dim NumeroNf As Integer = 0

            Dim _IdEndereço As Integer = 0
            Dim _Endereço As String = ""
            Dim _Bairro As String = ""
            Dim _Cidade As String = ""
            Dim _Estado As String = ""
            Dim _Pais As String = ""

            Dim NomeFantasia As String = ""
            Dim _Fone As String = ""

            If Len(docXML.OuterXml) > 0 Then

                For Each noPai In nodelist 'Le os nós principais da NFe
                    If noPai.Name = "NFe" Then
                        For Each noFilho In noPai 'Lê os Nós secundários

                            If noFilho.Name = "infNFe" Then 'Se for o cabecalho da NFe

                                For Each noNeto In noFilho 'Lê as Tags da NFe
                                    If noNeto.Name = "ide" Then 'Verifica a identificação da NFe  
                                        For Each noBisneto In noNeto 'Verifica os valores da NFe   
                                            If noBisneto.Name = "nNF" Then
                                                TxtNf.Text = (noBisneto.InnerText)
                                                LblNumNf.Text = TxtNf.Text
                                                TxtNf.Visible = False
                                                LblNumNf.Visible = True
                                            ElseIf noBisneto.Name = "dhEmi" Then
                                                TxtDataEmissão.Text = (noBisneto.InnerText)
                                                LblDataEmissão.Text = TxtDataEmissão.Text
                                                LblDataEmissão.ForeColor = Color.SlateGray
                                                TxtDataEmissão.Visible = False
                                                LblDataEmissão.Visible = True
                                                CkNaoEnota.Visible = False
                                            ElseIf noBisneto.Name = "dhEmi" Then
                                                'TxtDataExpedição.Value = (noBisneto.InnerText)
                                            End If
                                        Next

                                    ElseIf noNeto.Name = "emit" Then 'Dados do Emitente da NFe   
                                        For Each noBisneto In noNeto
                                            'MsgBox(noBisneto.InnerText)
                                            If noBisneto.Name = "enderEmit" Then 'Dados do Endereço do emitente
                                                For Each noTetra In noBisneto
                                                    'verifica o cep
                                                    If noTetra.Name = "CEP" Then

                                                        _CepF = noTetra.InnerText

                                                    ElseIf noTetra.Name = "nro" Then

                                                        NumeroNF = noTetra.InnerText

                                                    End If
                                                    'dgvDadosDoEmitente.Rows.Add(noTetra.InnerText)
                                                Next
                                            ElseIf noBisneto.Name = "CNPJ" Then
                                                If LblCNPJ.Text <> "00.000.000/0000-00" Then
                                                    _CNPJ = noBisneto.InnerText
                                                Else

                                                    _CNPJ = noBisneto.InnerText

                                                    LblCNPJ.Text = noBisneto.InnerText
                                                    LblCNPJ.Text = LblCNPJ.Text.ToCharArray(0, 2) & "." &
                                                        LblCNPJ.Text.ToCharArray(2, 3) & "." &
                                                        LblCNPJ.Text.ToCharArray(5, 3) & "/" &
                                                        LblCNPJ.Text.ToCharArray(8, 4) & "-" &
                                                        LblCNPJ.Text.ToCharArray(12, 2)

                                                End If
                                            ElseIf noBisneto.Name = "xNome" Then
                                                LblRazaoSocial.Text = noBisneto.InnerText
                                            ElseIf noBisneto.Name = "xFant" Then
                                                NomeFantasia = noBisneto.InnerText
                                            ElseIf noBisneto.Name = "fone" Then
                                                _Fone = noBisneto.InnerText
                                            ElseIf noBisneto.Name = "IE" Then
                                                LblIE.Text = noBisneto.InnerText
                                            End If

                                        Next

                                    ElseIf noNeto.Name = "dest" Then 'Dados do Destinatário                                   
                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "enderDest" Then 'Dados do Endereço do emitente
                                                For Each noTetra In noBisneto
                                                    'dgvDadosDoDestinatario.Rows.Add(noTetra.InnerText)
                                                Next
                                            Else
                                                'dgvDadosDoDestinatario.Rows.Add(noBisneto.InnerText)
                                            End If
                                        Next

                                    ElseIf noNeto.Name = "transp" Then 'Dados da Transportadora
                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "transporta" Then
                                                For Each noTetra In noBisneto
                                                    'dgvTransportadora.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If

                                            If noBisneto.Name = "veicTransp" Then
                                                For Each noTetra In noBisneto
                                                    'dgvTransportadora.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If

                                            If noBisneto.Name = "vol" Then
                                                For Each noTetra In noBisneto
                                                    'dgvTransportadora.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If

                                        Next

                                    ElseIf noNeto.Name = "infAdic" Then 'Dados do Destinatário                                   
                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "obsCont" Then 'Dados do Endereço do emitente
                                                For Each noTetra In noBisneto
                                                    'dgvDadosAdicionais.Rows.Add(noTetra.InnerText)
                                                Next
                                            Else
                                                'dgvDadosAdicionais.Rows.Add(noBisneto.InnerText)
                                            End If
                                        Next

                                    ElseIf noNeto.Name = "cobr" Then 'Dados do Destinatário                                   
                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "fat" Then 'Dados da fatura
                                                For Each noTetra In noBisneto
                                                    'dgvCobrancas.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If
                                            If noBisneto.Name = "dup" Then 'Dados da duplicata
                                                For Each noTetra In noBisneto
                                                    'dgvCobrancas.Rows.Add(noTetra.InnerText)
                                                Next
                                            End If
                                        Next

                                    ElseIf noNeto.Name = "total" Then
                                        For Each noBisneto In noNeto

                                            For Each noTetra In noBisneto
                                                If noTetra.Name = "ICMSTot" Then
                                                ElseIf noTetra.Name = "vICMS" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    Label19.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vBC" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblICMS.Text = FormatNumber(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vProd" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblProdutos.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vFrete" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorFrete.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vSeg" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorSeguro.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vDesc" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorDesconto.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vII" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblVII.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vPIS" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblPIS.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vCOFINS" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblCOFINS.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vOutro" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblOutros.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vNF" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorNf.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vTotTrib" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblTotalTributos.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vBCST" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblBaseSt.Text = FormatNumber(Valor, NumDigitsAfterDecimal:=2)

                                                ElseIf noTetra.Name = "vST" Then

                                                    Dim Valor As String = noTetra.InnerText
                                                    Valor = Valor.Replace(".", ",")

                                                    LblValorSt.Text = FormatCurrency(Valor, NumDigitsAfterDecimal:=2)

                                                End If
                                            Next

                                        Next

                                    ElseIf noNeto.Name = "entrega" Then 'Dados da Entrega
                                        For Each noBisneto In noNeto
                                            'dgvEntrega.Rows.Add(noBisneto.InnerText)
                                        Next

                                    ElseIf noNeto.Name = "det" Then 'Verifica os detalhes dos produtos

                                        Dim DEscricao As String = ""
                                        Dim Cod As String = ""
                                        Dim NCM As String = ""
                                        Dim EAN As String = ""
                                        Dim Qt As String = ""
                                        Dim ValorUnit As String = ""
                                        Dim IPI As String = "0"
                                        Dim ICMS As String = "0"
                                        Dim ICMS_ST As String = "0"
                                        Dim Desconto As String = "0"

                                        Dim Unidade As String = ""

                                        For Each noBisneto In noNeto
                                            If noBisneto.Name = "prod" Then 'Dados dos Produtos

                                                For Each noTetra In noBisneto

                                                    If noTetra.Name = "xProd" Then

                                                        DEscricao = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "cProd" Then

                                                        Cod = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "vDesc" Then

                                                        Desconto = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "qCom" Then

                                                        Qt = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "vProd" Then

                                                        ValorUnit = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "uCom" Then

                                                        Unidade = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "cEAN" Then

                                                        If noTetra.InnerText <> "SEM GTIN" Then
                                                            EAN = (noTetra.InnerText)
                                                        End If

                                                    ElseIf noTetra.Name = "NCM" Then

                                                        NCM = (noTetra.InnerText)

                                                    ElseIf noTetra.Name = "vICMSSTRet" Then

                                                        ICMS_ST = (noTetra.InnerText)

                                                    End If

                                                Next
                                            End If

                                            If noBisneto.Name = "ICMS" Then 'Dados do ICMS
                                                For Each noTetra In noBisneto
                                                    MsgBox(noTetra.InnerText)
                                                Next
                                            End If

                                        Next

                                        Qt = Qt.Replace(".", ",")

                                        Desconto = Desconto.Replace(".", ",")

                                        ValorUnit = ValorUnit.Replace(".", ",")

                                        Dim BuscaVinculoProduto = From prod In LqBase.VinculoProdutoFornecedor
                                                                  Where prod.IdForncedor Like LblCodFornec.Text And prod.CodFornecedor Like Cod
                                                                  Select prod.IdProduto

                                        Dim CodVinc As String = ""

                                        If BuscaVinculoProduto.Count > 0 Then

                                            CodVinc = BuscaVinculoProduto.First

                                        End If

                                        DtEsperados.Rows.Add(My.Resources.cargo_1_icon, CodVinc, Cod, DEscricao, NCM, EAN, Unidade, Qt, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), FormatCurrency(Desconto, NumDigitsAfterDecimal:=2), FormatCurrency(ValorUnit - Desconto, NumDigitsAfterDecimal:=2), FormatCurrency(IPI, NumDigitsAfterDecimal:=2), FormatCurrency(ICMS, NumDigitsAfterDecimal:=2), FormatCurrency(ICMS_ST, NumDigitsAfterDecimal:=2))

                                    End If
                                Next

                            End If
                        Next
                    Else
                        For Each noFilho In noPai 'Lê os Nós secundários
                            For Each noNeto In noFilho 'Lê as Tags da NFe
                                If noNeto.Name = "chNFe" Then
                                    LblChave.Text = noNeto.InnerText
                                End If
                            Next
                        Next
                    End If
                Next

                'verifica se nf já está inserida

                Dim BuscaNf = From nf In LqFinanceiro.NF_Entrada
                              Where nf.NumNF Like LblNumNf.Text
                              Select nf.IdFornecedor

                If BuscaNf.Count > 0 Then

                    If MsgBox("Essa nota fiscal já foi inserida no sistema.", MsgBoxStyle.OkOnly) = vbOK Then

                        Again = True

                        LimpaCampos()

                    End If

                Else

                    Dim LstMeses As New ListBox

                    LstMeses.Items.Add("Jan")
                    LstMeses.Items.Add("Fev")
                    LstMeses.Items.Add("Mar")
                    LstMeses.Items.Add("Abr")
                    LstMeses.Items.Add("Mai")
                    LstMeses.Items.Add("Jun")
                    LstMeses.Items.Add("Jul")
                    LstMeses.Items.Add("Ago")
                    LstMeses.Items.Add("Set")
                    LstMeses.Items.Add("Out")
                    LstMeses.Items.Add("Nov")
                    LstMeses.Items.Add("Dez")

                    'busca CNPJ COMPAT 

                    Dim BuscaFornecedorCnpj = From doc In LqBase.Fornecedores
                                              Where doc.Doc Like _CNPJ
                                              Select doc.IdFornecedor, doc.IdEndereco, doc.Bairro, doc.Estado, doc.Cidade

                    If BuscaFornecedorCnpj.Count > 0 Then

                        If LblCodFornec.Text <> " " Then

                            If "I_" & BuscaFornecedorCnpj.First.IdFornecedor <> LblCodFornec.Text Then

                                MsgBox("Essa nota fiscal Não pertence a este fornecedor.", MsgBoxStyle.OkOnly)
                                LimpaCampos()

                            Else

                                Chart1.Series.Clear()

                                For Each row As DataGridViewRow In DtEsperados.Rows

                                    Dim LstValorProduto As New ListBox

                                    Dim LstProduto As New ListBox

                                    Dim MesSel As Date = Today.Date.AddMonths(-4)
                                    Dim AnoSel As Integer = MesSel.Year

                                    Dim _idProduto As Integer

                                    If row.Cells(1).Value <> "" Then

                                        _idProduto = row.Cells(1).Value

                                        Dim BuscaProduto = From prod In LqBase.Produtos
                                                           Where prod.IdProduto = _idProduto
                                                           Select prod.Descricao

                                        Chart1.Series.Add(BuscaProduto.First)

                                        While MesSel.Month & AnoSel <= Today.Month & Today.Year

                                            Dim BuscaArmazenagem = From arm In LqEstoque.Armazenagem
                                                                   Where arm.IdProduto = _idProduto And arm.DataEntrada.Value.Month.ToString & arm.DataEntrada.Value.Year.ToString Like MesSel.Month & AnoSel
                                                                   Select arm.DataEntrada, arm.ValorUnit
                                                                   Order By ValorUnit Ascending

                                            MesSel = MesSel.AddMonths(1)
                                            AnoSel = MesSel.Year

                                            If BuscaArmazenagem.Count > 0 Then

                                                LstProduto.Items.Add(LstMeses.Items(MesSel.Month).ToString & "/" & AnoSel)
                                                LstValorProduto.Items.Add(BuscaArmazenagem.First.ValorUnit)

                                            Else

                                                LstProduto.Items.Add(LstMeses.Items(MesSel.Month).ToString & "/" & AnoSel)
                                                LstValorProduto.Items.Add(0)

                                            End If

                                        End While

                                        'popula gráfico

                                        Chart1.Series(Chart1.Series.Count - 1).Points.DataBindXY(LstProduto.Items, LstValorProduto.Items)

                                    End If

                                Next

                            End If

                        Else

                            'carrega os dados do fornecedor

                            LblCodFornec.Text = BuscaFornecedorCnpj.First.IdFornecedor

                            Dim BuscaEndereco = From ende In LqBase.Enderecos
                                                Where ende.IdEndereco = BuscaFornecedorCnpj.First.IdEndereco
                                                Select ende.Descricao, ende.IdBairro

                            LblEndereço.Text = BuscaEndereco.First.Descricao & ", " & NumeroNf & " - " &
                                " - " & BuscaFornecedorCnpj.First.Bairro & " - " & BuscaFornecedorCnpj.First.Cidade &
                                " - " & BuscaFornecedorCnpj.First.Estado

                        End If

                    Else

                        If LblCodFornec.Text <> " " Then

                            MsgBox("Essa nota fiscal Não pertence a este fornecedor.", MsgBoxStyle.OkOnly)
                            LimpaCampos()

                        Else
                            'busca cep

                            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                            'busca endereco

                            Dim buscaEndereco = From ende In LqBase.Enderecos
                                                Where ende.CEP = _CepF
                                                Select ende.IdEndereco, ende.Descricao, ende.IdBairro, ende.IdAbreviacao, ende.DescricaoLogradouros

                            If buscaEndereco.Count > 0 Then

                                _IdEndereço = buscaEndereco.First.IdEndereco

                                'busca abrviação 

                                Dim BuscaAbreviação = From abre In LqBase.DescricaoLogradouros
                                                      Where abre.IdDescricaoLog = buscaEndereco.First.IdAbreviacao
                                                      Select abre.Abreviacao

                                _Endereço = BuscaAbreviação.First & " " & buscaEndereco.First.Descricao

                                'busca bairro

                                Dim buscaBairro = From bai In LqBase.Bairro
                                                  Where bai.IdBairro = buscaEndereco.First.IdBairro
                                                  Select bai.Descricao, bai.IdCidade

                                _Bairro = buscaBairro.First.Descricao

                                'busca cidade 

                                Dim BuscaCidade = From cid In LqBase.Cidade
                                                  Where cid.IdCidade = buscaBairro.First.IdCidade
                                                  Select cid.IdEstado, cid.Descricao

                                _Cidade = BuscaCidade.First.Descricao

                                'busca estado

                                Dim BuscaEstado = From est In LqBase.Estados
                                                  Where est.IdEstado = BuscaCidade.First.IdEstado
                                                  Select est.IdPais, est.Sigla, est.Descricao

                                _Estado = BuscaEstado.First.Sigla & " - " & BuscaEstado.First.Descricao

                                _Pais = "Brasil"

                            Else

                                'Try
                                Me.Cursor = Cursors.WaitCursor

                                Dim ds As New DataSet()
                                Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", _CepF)
                                ds.ReadXml(xml)
                                _Endereço = ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString()
                                _Bairro = ds.Tables(0).Rows(0)("bairro").ToString()
                                _Cidade = ds.Tables(0).Rows(0)("cidade").ToString()
                                _Estado = ds.Tables(0).Rows(0)("uf").ToString()
                                _Pais = "Brasil"

                                'verfica tipo de logradouro

                                Dim BuscTipoLog = From log In LqBase.DescricaoLogradouros
                                                  Where log.Descricao Like ds.Tables(0).Rows(0)("tipo_logradouro").ToString()
                                                  Select log.IdDescricaoLog

                                Dim _IdDescricaoLog As Integer

                                If BuscTipoLog.Count > 0 Then

                                    _IdDescricaoLog = BuscTipoLog.First

                                Else

                                    LqBase.InsereDescricaoEndereco(ds.Tables(0).Rows(0)("tipo_logradouro").ToString(), ds.Tables(0).Rows(0)("tipo_logradouro").ToString())

                                    'verfica tipo de logradouro

                                    Dim BuscTipoLogA = From log In LqBase.DescricaoLogradouros
                                                       Where log.Descricao Like ds.Tables(0).Rows(0)("tipo_logradouro").ToString()
                                                       Select log.IdDescricaoLog

                                    _IdDescricaoLog = BuscTipoLogA.First

                                End If


                                'insere endereco

                                'verifica estado

                                Dim BuscaPais = From est In LqBase.Paises
                                                Where est.Descricao Like "Brasil"
                                                Select est.IdPais

                                If BuscaPais.Count > 0 Then
                                    'verifica a existencia do estado 

                                    Dim BuscaEstado = From est In LqBase.Estados
                                                      Where est.IdPais = BuscaPais.First And est.Descricao Like _Estado
                                                      Select est.IdEstado

                                    If BuscaEstado.Count > 0 Then
                                        'verifica a existencia do estado 

                                        Dim BuscaCidade = From est In LqBase.Cidade
                                                          Where est.IdEstado = BuscaEstado.First And est.Descricao Like _Cidade
                                                          Select est.IdCidade

                                        If BuscaCidade.Count > 0 Then
                                            'verifica a existencia do estado 

                                            Dim BuscaBairro = From est In LqBase.Bairro
                                                              Where est.IdCidade = BuscaCidade.First And est.Descricao Like _Bairro
                                                              Select est.IdBairro

                                            If BuscaBairro.Count > 0 Then
                                                'verifica a existencia do estado 

                                                Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                     Where est.IdBairro = BuscaBairro.First And est.Descricao Like _Endereço
                                                                     Select est.IdEndereco

                                                If Buscaloradouro.Count = 0 Then

                                                    LqBase.InsereEndereco(BuscaBairro.First, _Endereço, _CepF, _IdDescricaoLog)

                                                End If

                                            Else

                                                LqBase.InsereBairro(BuscaCidade.First, _Bairro)

                                                'verifica a existencia do estado 

                                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                                   Where est.IdCidade = BuscaCidade.First And est.Descricao Like _Cidade
                                                                   Select est.IdBairro

                                                If BuscaBairroA.Count > 0 Then
                                                    'verifica a existencia do estado 

                                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like _Endereço
                                                                         Select est.IdEndereco

                                                    If Buscaloradouro.Count = 0 Then

                                                        LqBase.InsereEndereco(BuscaBairroA.First, _Endereço, _CepF, _IdDescricaoLog)

                                                    End If

                                                End If

                                            End If

                                        Else


                                            LqBase.InsereCidade(BuscaEstado.First, _Cidade)

                                            'verifica a existencia do estado 

                                            Dim BuscaCidadeA = From est In LqBase.Cidade
                                                               Where est.IdEstado = BuscaEstado.First And est.Descricao Like _Cidade
                                                               Select est.IdCidade

                                            If BuscaCidadeA.Count > 0 Then

                                                LqBase.InsereBairro(BuscaCidadeA.First, _Bairro)

                                                'verifica a existencia do estado 

                                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                                   Where est.IdCidade = BuscaCidadeA.First And est.Descricao Like _Bairro
                                                                   Select est.IdBairro

                                                If BuscaBairroA.Count > 0 Then
                                                    'verifica a existencia do estado 

                                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like _Endereço
                                                                         Select est.IdEndereco

                                                    If Buscaloradouro.Count = 0 Then

                                                        LqBase.InsereEndereco(BuscaBairroA.First, _Endereço, _CepF, _IdDescricaoLog)

                                                    End If

                                                End If

                                            End If

                                        End If

                                    Else

                                        LqBase.InsereEstado(BuscaPais.First, _Estado, "", 0)

                                        'verifica a existencia do estado 

                                        Dim BuscaEstadoA = From est In LqBase.Estados
                                                           Where est.IdPais = BuscaPais.First And est.Descricao Like _Estado
                                                           Select est.IdEstado

                                        If BuscaEstadoA.Count > 0 Then

                                            LqBase.InsereCidade(BuscaEstadoA.First, _Cidade)

                                            'verifica a existencia do estado 

                                            Dim BuscaCidadeA = From est In LqBase.Cidade
                                                               Where est.IdEstado = BuscaEstadoA.First And est.Descricao Like _Cidade
                                                               Select est.IdCidade

                                            If BuscaCidadeA.Count > 0 Then

                                                LqBase.InsereBairro(BuscaCidadeA.First, _Bairro)

                                                'verifica a existencia do estado 

                                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                                   Where est.IdCidade = BuscaCidadeA.First And est.Descricao Like _Bairro
                                                                   Select est.IdBairro

                                                If BuscaBairroA.Count > 0 Then
                                                    'verifica a existencia do estado 

                                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like _Endereço
                                                                         Select est.IdEndereco

                                                    If Buscaloradouro.Count = 0 Then

                                                        LqBase.InsereEndereco(BuscaBairroA.First, _Endereço, _CepF, _IdDescricaoLog)

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                Else

                                    LqBase.InserePais("Brasil", "", 0)

                                    Dim BuscaPaisA = From est In LqBase.Paises
                                                     Where est.IdPais Like "Brasil"
                                                     Select est.IdPais

                                    If BuscaPaisA.Count > 0 Then

                                        'verifica a existencia do estado 

                                        Dim BuscaEstadoA = From est In LqBase.Estados
                                                           Where est.IdPais = BuscaPaisA.First And est.Descricao Like _Estado
                                                           Select est.IdEstado

                                        If BuscaEstadoA.Count > 0 Then

                                            LqBase.InsereCidade(BuscaEstadoA.First, _Cidade)

                                            'verifica a existencia do estado 

                                            Dim BuscaCidadeA = From est In LqBase.Cidade
                                                               Where est.IdEstado = BuscaEstadoA.First And est.Descricao Like _Cidade
                                                               Select est.IdCidade

                                            If BuscaCidadeA.Count > 0 Then

                                                LqBase.InsereBairro(BuscaCidadeA.First, _Bairro)

                                                'verifica a existencia do estado 

                                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                                   Where est.IdCidade = BuscaCidadeA.First And est.Descricao Like _Bairro
                                                                   Select est.IdBairro

                                                If BuscaBairroA.Count > 0 Then
                                                    'verifica a existencia do estado 

                                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like _Endereço
                                                                         Select est.IdEndereco

                                                    If Buscaloradouro.Count = 0 Then

                                                        LqBase.InsereEndereco(BuscaBairroA.First, _Endereço, _CepF, _IdDescricaoLog)

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                                Me.Cursor = Cursors.Arrow

                            End If

                            LqBase.InsereNovoFornecedor(_CNPJ, LblRazaoSocial.Text, _CepF, _IdEndereço, NumeroNf, "", 0, _Bairro, 0, _Cidade, 0, _Estado, 0, _Pais, _Fone, NomeFantasia, False, True, False, False, LblIE.Text)

                        End If

                    End If

                End If

            End If

        Else

            Me.Close()

        End If

        'limpa campos

        If Again = True Then

            BttImportar.Visible = True
            BttImportar.PerformClick()

        End If

    End Sub

    Private Sub DtEsperados_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DtEsperados.CellFormatting

    End Sub

    Private Sub TxtDataEmissão_Click(sender As Object, e As EventArgs) Handles TxtDataEmissão.Click

        If TxtDataEmissão.Text <> "" Then

            Dim Valor As Integer = TxtDataEmissão.Text.Length
            TxtDataEmissão.SelectionStart = Valor

        Else

            TxtDataEmissão.SelectionStart = 0

        End If

    End Sub

    Private Sub TxtDataEmissão_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtDataEmissão.MaskInputRejected

    End Sub
End Class



