Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml
Imports Newtonsoft.Json
Imports PdfSharp.Drawing
Imports PdfSharp.Drawing.BarCodes
Imports PdfSharp.Pdf

Public Class FrmEmitirNovaNF
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Public CLienteSimples As Boolean = True

    Public _IdOrcamento As Integer

    Dim TipoCertificado As String = "A1"
    Dim InscricaoMunic As Integer = "12345678"
    Dim RegimeTrib As Integer = "1"
    Dim Numero As String = FrmPrincipal.Numero
    Dim Cmplemento As String = FrmPrincipal.Complemento
    Dim Cep As String = FrmPrincipal.Endereco
    Dim Email As String = FrmPrincipal.Email
    Dim Telefone As String = FrmPrincipal.Telefone

    Public Sub CarregaDadosEmissor()

    End Sub
    Public Sub EmiteDanfe()

        Me.Cursor = Cursors.AppStarting

        Dim CNPJ As String = ""
        Dim xNome As String = ""
        Dim Chave As String = "32191105570714000825550010059146621133082968"
        Dim NaturezaOPE As String = "Venda de produtos de terceiro"
        Dim Protocolo As String = Now.ToString
        Dim InscricaoEstadual As String = FrmPrincipal.IE
        Dim FormaPg As String = ""
        Dim BCCalculoICMS As String = 0
        Dim VlrICMS As String = 0
        Dim BCCalculoICMS_ST As String = 0
        Dim VlrICMS_ST As String = 0
        Dim BCPIS As String = 0
        Dim VlrFrete As String = 0
        Dim VlrSeguro As String = 0
        Dim VlrProdutos As String = 0
        Dim Desconto As String = 0
        Dim outrasDespesas As String = 0
        Dim VlrIPI As String = 0
        Dim VlrCofins As String = 0
        Dim VlrNF As String = 0

        'Cria um documento PDF
        Dim pdf As PdfDocument = New PdfDocument
        'definindo informações do autor e palavras chaves
        pdf.Info.Author = "I.A.R.A."
        pdf.Info.Keywords = "PdfSharp, Exemplos, VB .NET"
        'informando a data de criação do documento
        pdf.Info.CreationDate = DateTime.Now
        ' informando o assunto
        pdf.Info.Subject = "Orçamento número: teste"
        'cria uma página vazia
        Dim pdfPage As PdfPage = pdf.AddPage
        'Cria um objeto XGraphics
        Dim graph As XGraphics = XGraphics.FromPdfPage(pdfPage)
        ' Desenha linhas cruzadas
        Dim pen As XPen = New XPen(XColor.FromArgb(160, XColors.SlateGray), 1)
        Dim penItem As XPen = New XPen(XColor.FromName("SlateGray"), 0.5)

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim IdOrcamento As Integer = _IdOrcamento

        Dim BuscaComercial = From com In LqComercial.Orcamentos
                             Where com.IdOrcamento = IdOrcamento
                             Select com.IdCliente

        Dim buscaItensOrcamento = From orc In LqComercial.ProdutosOrcamento
                                  Where orc.IdOrcamento = IdOrcamento
                                  Select orc.IdProduto, orc.ValorUnit, orc.Qtdade, orc.Tipo, orc.IdSolicitacao

        Dim _ServicosISSQN As Boolean

        For Each row In buscaItensOrcamento.ToList

            If row.Tipo = False Then

                _ServicosISSQN = True

            End If

        Next

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'busca dados do cliente

        Dim BuscaCliente = From cli In LqBase.Clientes
                           Where cli.IdCliente = BuscaComercial.First
                           Select cli.Telefone, cli.RazaoSocial_nome, cli.CPF_CNPJ, cli.CEP, cli.Numero, cli.Complemento, cli.RG_IE, cli.Email

        Dim nomeRazao_Transp As String = BuscaCliente.First.RazaoSocial_nome
        Dim _Email As String = BuscaCliente.First.Email

        If TipoCertificado = "A3" Then

            _Email = ""

        End If

        'cria nota fiscal

        pen.DashStyle = XDashStyle.Dot

        Dim Linha As Double = 10
        Dim MargemEsq As Double = 0
        Dim MArgemDir As Double = 0

        'linhas do cabeçalho
        Dim Pt0 As Double = pdfPage.Width.Point - 95
        Dim Pt1 As Double = Linha - 15
        Dim Pt2 As Double = 100
        Dim Pt3 As Double = 85

        Dim img As Image = My.Resources.LogoIaraTrsnp
        Dim strm As MemoryStream = New MemoryStream()
        img.Save(strm, System.Drawing.Imaging.ImageFormat.Png)
        Dim xfoto As XImage = XImage.FromStream(strm)

        Dim imgMcD As Image = My.Resources.whatsapp_image_2020_09_10_at_16_41_44
        Dim strmMcD As MemoryStream = New MemoryStream()
        imgMcD.Save(strmMcD, System.Drawing.Imaging.ImageFormat.Png)
        Dim xfotoMcD As XImage = XImage.FromStream(strmMcD)

        Dim Pincel As New XSolidBrush
        Pincel.Color = XColor.FromArgb(100, 229, 229, 229)
        Dim PincelItemFoto As New XSolidBrush
        PincelItemFoto.Color = XColor.FromArgb(150, 0, 0, 0)

        'busca numero da ultima NF emitida

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim _NumNf As Integer = 0
        Dim _Serie As Integer = 0

        Dim BuscaNf = From nf In LqFinanceiro.NF_Saida
                      Where nf.NumNF Like "*"
                      Select nf.NumNF, nf.Serie
                      Order By NumNF Descending

        Dim TipoFrete As Boolean = False

        If BuscaNf.Count = 0 Then
            'verifica no certificado
            _NumNf = 1
            _Serie = 1
        Else
            _NumNf = BuscaNf.First.NumNF + 1
            _Serie = BuscaNf.First.Serie
        End If

        Dim ValorProd As Decimal = 0

        For Each row In buscaItensOrcamento.ToList
            If row.Tipo = True Then
                ValorProd += row.ValorUnit * row.Qtdade
            End If
        Next

        'calcula impostos e imprime na nota

        Dim AliquotaICMS As Decimal = LblIcms.Text / 100
        Dim AliquotaICMS_ST As Decimal = LblICMSST.Text / 100
        Dim AliquotaIPI As Decimal = LblIPI.Text / 100

        VlrProdutos = ValorProd

        Dim MVA As Decimal = 18 / 100

        'calcula ICMS

        BCCalculoICMS = VlrFrete + VlrSeguro + VlrIPI + VlrProdutos

        VlrICMS = BCCalculoICMS * AliquotaICMS

        BCCalculoICMS_ST = ((VlrFrete + VlrSeguro + VlrIPI + VlrProdutos + outrasDespesas) - Desconto) * (1 + MVA)

        VlrICMS_ST = (BCCalculoICMS_ST * AliquotaICMS_ST) - VlrICMS

        VlrIPI = (VlrProdutos + VlrFrete) * AliquotaIPI

        Dim AliquotaPIS As Decimal = 6.5 / 100

        BCPIS = VlrProdutos * (AliquotaPIS / 100)

        'busca endereco

        Dim _Endereco As String = FrmPrincipal.Endereco & " - "

        'busca dados do 
        Dim ds As New DataSet()
        Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", FrmPrincipal.Endereco)
        ds.ReadXml(xml)
        _Endereco &= " " & ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString() & ", " & FrmPrincipal.Numero & "(" & FrmPrincipal.Complemento & ")"
        _Endereco &= ", " & ds.Tables(0).Rows(0)("bairro").ToString()
        _Endereco &= ", " & ds.Tables(0).Rows(0)("cidade").ToString()
        _Endereco &= ", " & ds.Tables(0).Rows(0)("uf").ToString()

        Dim _EnderecoInd As String = FrmPrincipal.Endereco & " - "

        'busca dados do 
        Dim dsInd As New DataSet()
        Dim xmlInd As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", BuscaCliente.First.CEP)
        dsInd.ReadXml(xmlInd)
        _EnderecoInd = dsInd.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & dsInd.Tables(0).Rows(0)("logradouro").ToString() & ", " & BuscaCliente.First.Numero & "(" & BuscaCliente.First.Complemento & ")"

        'cria nova nf
        Dim Antt As String = ""
        Dim PlacaVeiculo As String = TxtPlaca.Text

        Dim strUf As String = LblUF.Text
        Dim separadorUf() As Char = ","
        ' Separa string baseado no delimitador
        Dim palavrasUf As String() = strUf.Split(separadorUf)
        Dim LstResultadoUf As New ListBox

        ' Percorremos as palavras da strings separadas exibindo-as no ListBox
        LstResultadoUf.Items.Clear()
        Dim palavraUf As String
        For Each palavraUf In palavrasUf
            LstResultadoUf.Items.Add(palavraUf)
        Next

        Dim UfVeiculo As String = ""

        If LstResultadoUf.Items.Count > 1 Then
            UfVeiculo = LstResultadoUf.Items(1).ToString.Remove(0, 1)
        End If

        Dim Cpf_Cnpj_Transp As String = ""

        If CmbTransportadores.Enabled = True Then
            Cpf_Cnpj_Transp = LstDocTrans.Items(CmbTransportadores.SelectedIndex).ToString()
        End If

        Dim endereco_Transp As String = ""

        If CmbTransportadores.Enabled = True Then
            endereco_Transp = LstEnderecoTrans.Items(CmbTransportadores.SelectedIndex).ToString
        End If

        Dim municipio_Transp As String = ""

        If CmbTransportadores.Enabled = True Then
            municipio_Transp = LstMunicioTrans.Items(CmbTransportadores.SelectedIndex).ToString
        End If

        Dim uf_Transp As String = ""

        If CmbTransportadores.Enabled = True Then
            uf_Transp = LstUfTrans.Items(CmbTransportadores.SelectedIndex).ToString
        End If

        Dim inscricao_estadual_transp As String = ""

        If CmbTransportadores.Enabled = True Then
            inscricao_estadual_transp = Ie.Items(CmbTransportadores.SelectedIndex).ToString
        End If

        Dim _qtdade As String = buscaItensOrcamento.Count
        Dim especie As String = CmbEspecie.Text
        Dim marca As String = ""

        If TxtPlaca.Enabled = True Then
            marca = MarcaVeiculo
        End If

        Dim numeracao As String = ""
        Dim PesoBruto As String = 0
        Dim PesoLiquido As String = 0
        Dim InscricaoMunicipal As String = ""
        Dim VlrServico As String = 0
        Dim BCISSQN As String = 0
        Dim VlrISSQN As String = 0
        Dim Observacos As String = ""


        'cria documento xml
        Dim writer As New XmlTextWriter("C:\Iara\NFE-DANFE\" & Chave & ".xml", Encoding.UTF8)

        'inicia o documento xml

        writer.WriteStartDocument()

        'escreve o elmento raiz


        writer.WriteStartElement("Envio", ”http://www.portalfiscal.inf.br/nfe”)

        'Escreve os sub-elementos

        writer.WriteElementString("ModeloDocumento", "NFe")
        writer.WriteElementString("Versao", "4.0")
        writer.WriteElementString("ChaveParceiro", "")
        writer.WriteElementString("ChaveAcesso", "")
        writer.WriteElementString("Imprimir", "")
        writer.WriteElementString("ApelidoImpressora", "")
        writer.WriteElementString("ImprimirDuasVias", "N")

        writer.WriteStartElement("Parametros")
        writer.WriteElementString("ApelidoLogomarca", "")

        writer.WriteEndElement()

        writer.WriteStartElement("ide")

        'Escreve os sub-elementos

        Dim fusoHorario As TimeZone = TimeZone.CurrentTimeZone

        writer.WriteElementString("cNF", "")
        writer.WriteElementString("cUF", UFEmissor)
        writer.WriteElementString("natOp", NaturezaOPE)
        writer.WriteElementString("mod", "")
        writer.WriteElementString("serie", _Serie)
        writer.WriteElementString("nNF", _NumNf)
        writer.WriteElementString("dhEmi", Today.Year.ToString & "-" & Today.Month.ToString & "-" & Today.Day.ToString & "T" & FormatDateTime(Now.TimeOfDay.ToString, DateFormat.LongTime))
        writer.WriteElementString("fusoHorario", fusoHorario.GetUtcOffset(Now).ToString)
        writer.WriteElementString("dhSaiEnt", "")
        writer.WriteElementString("tpNf", "1")
        writer.WriteElementString("idDest", "2")
        writer.WriteElementString("indFinal", "1")
        writer.WriteElementString("indPres", "1")
        writer.WriteElementString("indIntermed", "")

        'busca na url o codigo do municipio

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_codigo_municipio.php?UF=" & UFEmissor
        Dim sync = New WebClient()
        Dim content_item = sync.DownloadString(baseUrl)

        Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.CodMun))(content_item)

        writer.WriteElementString("cMunFg", read0.Item(0).CodUf)
        writer.WriteElementString("tpImp", "1")
        writer.WriteElementString("tpEmis", "1")
        writer.WriteElementString("tpAmb", "2")
        writer.WriteElementString("xJust", "")
        writer.WriteElementString("dhCont", "")
        writer.WriteElementString("finNFe", "1")
        writer.WriteElementString("EmailArquivos", _Email)

        'tereceiro nivel

        writer.WriteStartElement("NFRef")

        'quarto nível

        writer.WriteStartElement("NFRefItem")

        writer.WriteElementString("refNFe", "")
        writer.WriteElementString("cUF_refNFE", "")
        writer.WriteElementString("AAMM", "")
        writer.WriteElementString("CNPJ", "")
        writer.WriteElementString("CPF", "")
        writer.WriteElementString("mod_refNFE", "")
        writer.WriteElementString("serie_refNFE", "")
        writer.WriteElementString("nNF_refNFE", "")
        writer.WriteElementString("IE_refNFP", "")
        writer.WriteElementString("RefCte", "")
        writer.WriteElementString("mod_refECF", "")
        writer.WriteElementString("nECF_refECF", "")
        writer.WriteElementString("nCOO_refECF", "")

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteEndElement()

        'desenha emit

        writer.WriteStartElement("emit")

        Dim _CNPJF As String = FrmPrincipal.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "")
        If _CNPJF.Length = 14 Then
            writer.WriteElementString("CNPJ_emit", BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("/", "").Replace("-", ""))

            writer.WriteElementString("xNome", BuscaCliente.First.RazaoSocial_nome)
            writer.WriteElementString("xFant", "")

        Else
            writer.WriteElementString("CPF_emit", BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", ""))

            writer.WriteElementString("xNome", BuscaCliente.First.RazaoSocial_nome)
            writer.WriteElementString("xFant", "")

        End If

        If _ServicosISSQN = True Then
            writer.WriteElementString("IM", InscricaoMunic)
            writer.WriteElementString("CNAE", "")

        Else
            writer.WriteElementString("IM", "")
            writer.WriteElementString("CNAE", "")

        End If

        writer.WriteElementString("IE", InscricaoEstadual.Replace(".", ""))
        writer.WriteElementString("IEST", "")
        writer.WriteElementString("CRT", RegimeTrib)

        writer.WriteStartElement("enderEmit")

        writer.WriteElementString("xLgr", ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString())
        writer.WriteElementString("nro", Numero)
        writer.WriteElementString("xCpl", Cmplemento)
        writer.WriteElementString("xBairro", ds.Tables(0).Rows(0)("bairro").ToString())
        writer.WriteElementString("cMun", read0.Item(0).CodUf)
        writer.WriteElementString("xMun", ds.Tables(0).Rows(0)("cidade").ToString())
        writer.WriteElementString("UF", UFEmissor)
        writer.WriteElementString("CEP", Cep)
        writer.WriteElementString("cPais", "1058")
        writer.WriteElementString("xPais", "Brasil")
        writer.WriteElementString("fone", Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""))
        writer.WriteElementString("Email", Email)

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteStartElement("dest")

        If BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", "").Length = 14 Then
            writer.WriteElementString("CNPJ_dest", BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""))
        Else
            writer.WriteElementString("CPF_dest", BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""))
        End If

        writer.WriteElementString("xNome_dest", BuscaCliente.First.RazaoSocial_nome)
        writer.WriteElementString("IE_dest", BuscaCliente.First.RG_IE)
        writer.WriteElementString("ISUF", "")
        writer.WriteElementString("indIEDest", "1")
        writer.WriteElementString("IM_dest", "")

        writer.WriteStartElement("enderDest")

        writer.WriteElementString("nro_dest", BuscaCliente.First.Numero)
        writer.WriteElementString("xCpl_dest", BuscaCliente.First.Complemento)
        writer.WriteElementString("xBairro_dest", dsInd.Tables(0).Rows(0)("bairro").ToString())
        writer.WriteElementString("xEmail_dest", BuscaCliente.First.Email)
        writer.WriteElementString("xLgr_dest", dsInd.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & dsInd.Tables(0).Rows(0)("logradouro").ToString())
        writer.WriteElementString("xPais_dest", "Brasil")

        Dim baseUrl_Dest As String = "http://www.iarasoftware.com.br/consulta_codigo_municipio.php?UF=" & UfDestinatario
        Dim sync_Dest = New WebClient()
        Dim content_item_Dest = sync_Dest.DownloadString(baseUrl_Dest)

        Dim read0_Dest = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.CodMun))(content_item_Dest)

        writer.WriteElementString("cMun_dest", read0_Dest.Item(0).CodUf)
        writer.WriteElementString("xMun_dest", dsInd.Tables(0).Rows(0)("cidade").ToString())
        writer.WriteElementString("UF_dest", UfDestinatario)
        writer.WriteElementString("CEP_dest", BuscaCliente.First.CEP)
        writer.WriteElementString("cPais_dest", "Brasil")
        writer.WriteElementString("fone_dest", BuscaCliente.First.Telefone)

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteStartElement("retirada")

        If _CNPJF.Replace(".", "").Replace("-", "").Replace("/", "").Length = 14 Then
            writer.WriteElementString("CNPJ_ret", _CNPJF.Replace(".", "").Replace("-", "").Replace("/", ""))
        Else
            writer.WriteElementString("CPF_ret", _CNPJF.Replace(".", "").Replace("-", "").Replace("/", ""))
        End If

        writer.WriteElementString("xLgr_ret", ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & dsInd.Tables(0).Rows(0)("logradouro").ToString())
        writer.WriteElementString("nro_ret", Numero)
        writer.WriteElementString("xCpl_ret", Cmplemento)
        writer.WriteElementString("xBairro_ret", ds.Tables(0).Rows(0)("bairro").ToString())
        writer.WriteElementString("xMun_ret", ds.Tables(0).Rows(0)("cidade").ToString())
        writer.WriteElementString("cMun_ret", read0.Item(0).CodUf)
        writer.WriteElementString("UF_ret", UfDestinatario)

        writer.WriteEndElement()

        writer.WriteStartElement("entrega")

        If BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", "").Length = 14 Then
            writer.WriteElementString("CNPJ_entr", BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""))
        Else
            writer.WriteElementString("CPF_entr", BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""))
        End If

        writer.WriteElementString("xLgr_entr", dsInd.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & dsInd.Tables(0).Rows(0)("logradouro").ToString())
        writer.WriteElementString("nro_entr", BuscaCliente.First.Numero)
        writer.WriteElementString("xCpl_entr", BuscaCliente.First.Complemento)
        writer.WriteElementString("xBairro_entr", dsInd.Tables(0).Rows(0)("bairro").ToString())
        writer.WriteElementString("cMun_entr", read0_Dest.Item(0).CodUf)
        writer.WriteElementString("xMun_entr", dsInd.Tables(0).Rows(0)("cidade").ToString())
        writer.WriteElementString("UF_entr", UfDestinatario)

        writer.WriteEndElement()

        writer.WriteStartElement("autXML")

        writer.WriteElementString("autXMLItem", "")

        If BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", "").Length = 14 Then
            writer.WriteElementString("CNPJ_aut", BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""))
        Else
            writer.WriteElementString("CPF_aut", BuscaCliente.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""))
        End If

        writer.WriteEndElement()

        writer.WriteStartElement("det")

        writer.WriteStartElement("detItem")

        writer.WriteElementString("infADProd", "")

        writer.WriteStartElement("prod")

        'LqFinanceiro.Insere_nf_saida(_NumNf, _Serie, False, Chave, NaturezaOPE, Protocolo,
        '                             InscricaoEstadual, "", FrmPrincipal.CNPJ,
        '                             FrmPrincipal.RazaoSocial, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString() & ", " & FrmPrincipal.Numero & "(" & FrmPrincipal.Complemento & ")",
        '                             ds.Tables(0).Rows(0)("bairro").ToString(), FrmPrincipal.Endereco,
        '                             "1111-11-11", dsInd.Tables(0).Rows(0)("cidade").ToString(), BuscaCliente.First.Telefone,
        '                             dsInd.Tables(0).Rows(0)("uf").ToString(), "", BuscaCliente.First.RG_IE, Today.TimeOfDay,
        '                             FormaPg, BCCalculoICMS, VlrICMS, BCCalculoICMS_ST, VlrICMS_ST, BCPIS,
        '                             VlrProdutos, VlrFrete, VlrSeguro, Desconto, outrasDespesas, VlrIPI,
        '                             VlrCofins, VlrNF, nomeRazao_Transp, TipoFrete, Antt, PlacaVeiculo, UfVeiculo,
        '                             Cpf_Cnpj_Transp, endereco_Transp, municipio_Transp, uf_Transp, inscricao_estadual_transp,
        '                             _qtdade, especie, marca, numeracao, PesoBruto, PesoLiquido, InscricaoMunicipal, VlrServico,
        '                             BCISSQN, VlrISSQN, Observacos, "O_" & IdOrcamento)

        'pinta cabeçalho

        Dim Pt0_RC As Double = 15
        Dim Pt1_RC As Double = Linha
        Dim Pt2_RC As Double = pdfPage.Width.Point - (15 * 2) - 98
        Dim Pt3_RC As Double = (15 * 1)

        Dim font_Tit0 As XFont = New XFont("Verdana", 6.25, XFontStyle.Regular)
        Dim font_Tit0R As XFont = New XFont("Verdana", 4.25, XFontStyle.Bold)
        Dim font_Tit1R As XFont = New XFont("Verdana", 4.25, XFontStyle.Regular)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_RC, Pt1_RC, Pt2_RC + 1, Pt3_RC))
        graph.DrawString("Recebemos de " & FrmPrincipal.RazaoSocial & " os produtos constantes na nota fiscal indicada ao lado.", font_Tit0, XBrushes.SlateGray, New XRect(17, Linha + 3, Pt2_RC, Linha), XStringFormats.TopLeft)
        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_RC, Pt1_RC + 16, 100, Pt3_RC + 5))
        graph.DrawString("Data do recebimento", font_Tit0R, XBrushes.SlateGray, New XRect(17, Linha + 1 + 16, Pt2_RC, Linha), XStringFormats.TopLeft)
        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_RC + 100 + 1, Pt1_RC + 15 + 1, Pt2_RC - 100, Pt3_RC + 5))
        graph.DrawString("Certificação e assinatura do recebedor", font_Tit0R, XBrushes.SlateGray, New XRect(17 + 100 + 1, Linha + 1 + 15 + 1, Pt2_RC - 100, Linha), XStringFormats.TopLeft)
        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_RC + 100 + (Pt2_RC - 100) + 2, Pt1_RC, 96, Pt3_RC + 21))

        Dim font_Tit As XFont = New XFont("Verdana", 10.25, XFontStyle.Regular)
        Dim fontDT As XFont = New XFont("Verdana", 5.5, XFontStyle.Regular)

        graph.DrawString("NFe", font_Tit, XBrushes.SlateGray, New XRect(Pt0_RC + 100 + (Pt2_RC - 100) + 2, Pt1_RC, 96, Pt3_RC), XStringFormats.TopCenter)
        graph.DrawString("Nº.: " & _NumNf, fontDT, XBrushes.SlateGray, New XRect(Pt0_RC + 100 + (Pt2_RC - 100) + 8, Pt1_RC + 15, 96, 10), XStringFormats.TopLeft)
        graph.DrawString("SERIE.: " & _Serie, fontDT, XBrushes.SlateGray, New XRect(Pt0_RC + 100 + (Pt2_RC - 100) + 8, Pt1_RC + 25, 96, 10), XStringFormats.TopLeft)

        Linha += 40

        graph.DrawLine(pen, 0, Linha, pdfPage.Width.Point, Linha)
        '
        Linha += 5

        Dim Pt0_CB As Double = 15
        Dim Pt1_CB As Double = Linha
        Dim Pt2_CB As Double = pdfPage.Width.Point - (15 * 2) - 258
        Dim Pt3_CB As Double = (15 * 7) - 5


        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_CB, Pt1_CB, Pt2_CB, Pt3_CB))
        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_CB + Pt2_CB + 1, Pt1_CB, 100, Pt3_CB))
        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_CB + Pt2_CB + 1 + 100 + 1, Pt1_CB, 156, Pt3_CB))

        'margem cabeçalho

        Dim MargemCBEsq As Double = 130
        Linha += 5

        'insere dados do emissor

        'desenha logotipo
        Dim imgCat06 As Image = My.Resources.logotipo_950x350px
        Dim strmCat06 As MemoryStream = New MemoryStream()
        imgCat06.Save(strmCat06, System.Drawing.Imaging.ImageFormat.Png)
        Dim xfotoCat06 As XImage = XImage.FromStream(strmCat06)

        graph.DrawImage(xfotoCat06, 30, Linha + 10, 80, 80)

        'valida pela web
        Dim font As XFont = New XFont("Verdana", 4.25, XFontStyle.Regular)
        Dim fontTT0 As XFont = New XFont("Verdana", 4, XFontStyle.Bold)

        Dim _CNPJ As String = FrmPrincipal.CNPJ

        graph.DrawString(FrmPrincipal.NomeFantasia, font_Tit, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha, Pt2_CB, Linha), XStringFormats.TopLeft)

        graph.DrawString("Razão social", fontTT0, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 20, Pt2_CB, Linha), XStringFormats.TopLeft)
        graph.DrawString(FrmPrincipal.RazaoSocial, font, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 24, Pt2_CB, Linha), XStringFormats.TopLeft)

        Dim str As String = _Endereco
        Dim separador As String = " "
        Dim palavras As String() = str.Split(separador)
        Dim LstPalavras As New ListBox
        Dim palavra As String

        Dim C As Integer = 0
        Dim CT As Integer = 45
        graph.DrawString("Endereço: ", fontTT0, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 48, Pt2_CB, Linha + 10), XStringFormats.TopLeft)

        'Ambiente de homologação
        Dim font_Homol As XFont = New XFont("Verdana", 24, XFontStyle.Regular)

        graph.DrawString("Documento sem valor,", font_Homol, XBrushes.Red, New XRect(0, -35, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center)
        graph.DrawString("criado em ambiente", font_Homol, XBrushes.Red, New XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center)
        graph.DrawString("de homologação", font_Homol, XBrushes.Red, New XRect(0, 35, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center)

        Dim Inicio As Decimal = Linha + 52

        Dim StringEnd As String = ""

        For Each palavra In palavras

            If C + palavra.Length + 1 < CT Then

                C += palavra.Length + 1
                StringEnd &= palavra & " "

            Else

                StringEnd &= palavra & " "

                graph.DrawString(StringEnd, font, XBrushes.SlateGray, New XRect(MargemCBEsq, Inicio, 120, 15), XStringFormats.TopLeft)

                Inicio += 7
                C = 0
                StringEnd = ""

            End If

        Next

        graph.DrawString(StringEnd, font, XBrushes.SlateGray, New XRect(MargemCBEsq, Inicio, 120, 15), XStringFormats.TopLeft)

        graph.DrawString("Telefone", fontTT0, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 78, Pt2_CB, Linha), XStringFormats.TopLeft)
        graph.DrawString(FrmPrincipal.Telefone, font, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 82, Pt2_CB, Linha), XStringFormats.TopLeft)

        graph.DrawString("E-mail", fontTT0, XBrushes.SlateGray, New XRect(MargemCBEsq + 80, Linha + 78, Pt2_CB, Linha), XStringFormats.TopLeft)
        graph.DrawString(FrmPrincipal.Email, font, XBrushes.SlateGray, New XRect(MargemCBEsq + 80, Linha + 82, Pt2_CB, Linha), XStringFormats.TopLeft)

        MargemCBEsq = Pt0_CB + Pt2_CB + 1

        'desenha logotipo NFE
        Dim imgNF As Image = My.Resources.NFEImage
        Dim strmNF As MemoryStream = New MemoryStream()
        imgNF.Save(strmNF, System.Drawing.Imaging.ImageFormat.Png)
        Dim xfotoNF As XImage = XImage.FromStream(strmNF)

        graph.DrawImage(xfotoNF, MargemCBEsq + 25, Linha + 30, 50, 60)
        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_CB + Pt2_CB + 1 + 4, Pt1_CB + 56, 92, Pt3_CB - 60))

        graph.DrawString("DANFE", font_Tit, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha, 100, 10), XStringFormats.TopCenter)
        graph.DrawString("Documento Auxiliar da", font, XBrushes.SlateGray, New XRect(MargemCBEsq + 1, Linha + 15, 100, 10), XStringFormats.TopCenter)
        graph.DrawString("Nota Fiscal Eletrônica", font, XBrushes.SlateGray, New XRect(MargemCBEsq + 1, Linha + 25, 100, 10), XStringFormats.TopCenter)

        graph.DrawString("1 - Saída", fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6, Linha + 55, 100, 10), XStringFormats.TopLeft)
        graph.DrawString("0 - Entrada", fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6, Linha + 65, 100, 10), XStringFormats.TopLeft)
        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(MargemCBEsq + 1 + 6 + 66, Pt1_CB + 56 + 4, 17, Pt3_CB - 83))
        graph.DrawString("1", font_Tit, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6 + 66, Pt1_CB + 56 + 4, 17, 17), XStringFormats.Center)
        graph.DrawString("Nº.: " & _NumNf, fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6, Linha + 76, 100, 10), XStringFormats.TopLeft)

        Dim Pag As Integer = 1
        Dim Linha0 As Integer = 0
        Dim PagAtual As Integer = 1

        For Each row In buscaItensOrcamento.ToList

            If Linha0 = 21 Then

                Linha0 = 0
                Pag += 1

            Else

                Linha0 += 1

            End If

        Next

        graph.DrawString("Pag " & PagAtual & " de " & Pag, fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq - 10, Linha + 76, 100, 10), XStringFormats.TopRight)
        graph.DrawString("SERIE.: " & _Serie, fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6, Linha + 83, 100, 10), XStringFormats.TopLeft)

        'controle do fisco

        graph.DrawString("Controle do FISCO", font_Tit, XBrushes.SlateGray, New XRect(Pt0_CB + Pt2_CB + 1 + 100 + 1, Linha, 156, 10), XStringFormats.TopCenter)
        graph.DrawString("Consulta de autenticidade no portal da NF-e", fontTT0, XBrushes.SlateGray, New XRect(Pt0_CB + Pt2_CB + 1 + 100 + 1, Linha + 79, 156, 10), XStringFormats.TopCenter)
        graph.DrawString("www.nfe.fazenda.gov.br/portal ou site da SEFAZ autorizada", fontTT0, XBrushes.SlateGray, New XRect(Pt0_CB + Pt2_CB + 1 + 100 + 1, Linha + 84, 156, 10), XStringFormats.TopCenter)

        Dim bc25 As Code3of9Standard = New Code3of9Standard("ISABEL123", New XSize(146, 30))
        bc25.Text = Chave
        bc25.Size = New XSize(130, 30)
        bc25.TextLocation = TextLocation.Below
        graph.DrawBarCode(bc25, XBrushes.SlateGray, font_Tit1R, New XPoint(Pt0_CB + Pt2_CB + 1 + 100 + 1 + 5 + 10, Linha + 30))
        bc25.Direction = CodeDirection.RightToLeft

        Linha += Pt3_CB

        Dim Pt0_DC As Double = 15
        Dim Pt1_DC As Double = Linha
        Dim Pt2_DC As Double = pdfPage.Width.Point - (15 * 2) - 157
        Dim Pt3_DC As Double = (15 * 1)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Pt1_DC, Pt2_DC, Pt3_DC))

        graph.DrawString("Natureza da operação", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Pt1_DC + 2, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(NaturezaOPE, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Pt1_DC + 7, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1, Pt1_DC, 156, Pt3_DC))

        graph.DrawString("Protocolo", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 1 + 2, Pt1_DC + 2, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(Protocolo, font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 1 + 2, Pt1_DC + 7, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Pt1_DC + 16, 130, Pt3_DC))

        graph.DrawString("Inscrição estadual", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Pt1_DC + 2 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(InscricaoEstadual, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Pt1_DC + 7 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 131, Pt1_DC + 16, 130, Pt3_DC))

        graph.DrawString("Inscrição estadual do Subs. Trib.", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 133, Pt1_DC + 2 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 133, Pt1_DC + 7 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 262, Pt1_DC + 16, 146, Pt3_DC))

        graph.DrawString("CNPJ", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 264, Pt1_DC + 2 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(_CNPJ, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 264, Pt1_DC + 7 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 262 + 147, Pt1_DC + 16, 156, Pt3_DC))

        graph.DrawString("Chave de acesso da NF-e para consulta de autenticidade no site", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 264 + 145, Pt1_DC + 2 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(Chave, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 264 + 145, Pt1_DC + 7 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

        Linha += 35

        graph.DrawString("Destinatário - Remetente", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

        Linha += 7

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC, Pt3_DC))

        graph.DrawString("Nome completo/Razão social", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(BuscaCliente.First.RazaoSocial_nome, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1, Linha, 94, Pt3_DC))

        graph.DrawString("CPF/CNPJ", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3, Linha + 2, 94, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(BuscaCliente.First.CPF_CNPJ, font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3, Linha + 7, 94, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1 + 97, Linha, 59, Pt3_DC))

        graph.DrawString("Data da emissão", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(Today.Date, font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

        Linha += 16

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC - 151, Pt3_DC))

        graph.DrawString("Endereço", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 101, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(_EnderecoInd, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 101, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 150), Linha, 150, Pt3_DC))

        graph.DrawString("Bairro", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150), Linha + 2, 150, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(dsInd.Tables(0).Rows(0)("bairro").ToString(), font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150), Linha + 7, 150, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 150) + 151, Linha, 94, Pt3_DC))

        graph.DrawString("CEP", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151, Linha + 2, 94, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(BuscaCliente.First.CEP, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151, Linha + 7, 94, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1 + 97, Linha, 59, Pt3_DC))

        graph.DrawString("Data da saída", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(Today.Date, font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

        Linha += 16

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC - 251, Pt3_DC))

        graph.DrawString("Município", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 251, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(dsInd.Tables(0).Rows(0)("cidade").ToString(), font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 251, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250), Linha, 99, Pt3_DC))

        graph.DrawString("Telefone", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 250), Linha + 2, 99, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(BuscaCliente.First.Telefone, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 250), Linha + 7, 99, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100, Linha, 59, Pt3_DC))

        graph.DrawString("UF", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(ds.Tables(0).Rows(0)("uf").ToString(), font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 60, Linha, 90, Pt3_DC))

        graph.DrawString("Indicador I.E.", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60, Linha + 2, 90, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60, Linha + 7, 90, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 60 + 91, Linha, 94, Pt3_DC))

        graph.DrawString("RG/IE", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91, Linha + 2, 94, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(BuscaCliente.First.RG_IE, font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91, Linha + 7, 94, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1 + 97, Linha, 59, Pt3_DC))

        graph.DrawString("Hora da saída", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatDateTime(Now.TimeOfDay.ToString, DateFormat.ShortTime), font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

        Linha += 16

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC))

        graph.DrawString("Formas de pagamento", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 251, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormaPg, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 251, Pt3_DC), XStringFormats.TopLeft)

        Linha += 20

        graph.DrawString("Calculo do imposto", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

        Linha += 7

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, 80, Pt3_DC))

        graph.DrawString("Base calculo ICMS", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatNumber(BCCalculoICMS, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 81, Linha, 80, Pt3_DC))

        graph.DrawString("Valor ICMS", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 81, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(VlrICMS, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 81, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 162, Linha, 80, Pt3_DC))

        graph.DrawString("Base calculo ICMS subst.", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 162, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatNumber(BCCalculoICMS_ST, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 162, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 243, Linha, 80, Pt3_DC))

        graph.DrawString("Valor ICMS subst.", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 243, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(VlrICMS_ST, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 243, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 324, Linha, 84, Pt3_DC))

        graph.DrawString("Total do PIS", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 324, Linha + 2, 84, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(BCPIS, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 324, Linha + 7, 84, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 89, Linha, 156, Pt3_DC))

        graph.DrawString("Valor total dos produtos", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91, Linha + 2, 154, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(ValorProd, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91, Linha + 7, 153, Pt3_DC), XStringFormats.TopRight)

        Linha += 16

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, 80, Pt3_DC))

        graph.DrawString("Valor do frete", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(VlrFrete, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 81, Linha, 80, Pt3_DC))

        graph.DrawString("Valor do seguro", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 81, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(VlrSeguro, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 81, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 162, Linha, 80, Pt3_DC))

        graph.DrawString("Desconto", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 162, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(Desconto, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 162, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 243, Linha, 80, Pt3_DC))

        graph.DrawString("Outras despesas", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 243, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(outrasDespesas, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 243, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 324, Linha, 84, Pt3_DC))

        graph.DrawString("Valor do IPI", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 324, Linha + 2, 84, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(VlrIPI, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 324, Linha + 7, 84, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 409, Linha, 84, Pt3_DC))

        graph.DrawString("Valor da COFINS", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 409, Linha + 2, 84, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(VlrCofins, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 409, Linha + 7, 84, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 89 + 85, Linha, 71, Pt3_DC))

        graph.DrawString("Valor total da NF", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91 + 84, Linha + 2, 71, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(VlrNF, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91 + 84, Linha + 7, 69, Pt3_DC), XStringFormats.TopRight)

        Linha += 20

        graph.DrawString("Transportador/Volumes transportados", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

        Linha += 7

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC - 166, Pt3_DC))

        graph.DrawString("Nome/Razão Social", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 166, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(nomeRazao_Transp, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 166, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165), Linha, 130, Pt3_DC))

        graph.DrawString("Frete", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165), Linha + 2, 130, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(CmbTransporteModo.SelectedItem.ToString, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165), Linha + 7, 130, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165) + 131, Linha, 34, Pt3_DC))

        graph.DrawString("Cod. ANTT", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165) + 131, Linha + 2, 34, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(Antt, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165) + 131, Linha + 7, 34, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 45, Linha, 59, Pt3_DC))

        graph.DrawString("Placa do veículo", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(PlacaVeiculo, font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 45 + 60, Linha, 24, Pt3_DC))

        graph.DrawString("UF", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47 + 60, Linha + 2, 24, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(UfVeiculo, font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47 + 60, Linha + 7, 24, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 45 + 60 + 25, Linha, 71, Pt3_DC))

        graph.DrawString("CPF/CNPJ", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47 + 60 + 25, Linha + 2, 71, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(Cpf_Cnpj_Transp, font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47 + 60 + 25, Linha + 7, 71, Pt3_DC), XStringFormats.TopLeft)

        Linha += 16

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC - 166, Pt3_DC))

        graph.DrawString("Endereço", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 165, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(endereco_Transp, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 165, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165), Linha, 165, Pt3_DC))

        graph.DrawString("Município", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165), Linha + 2, 165, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(municipio_Transp, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165), Linha + 7, 165, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 150) + 151, Linha, 29, Pt3_DC))

        graph.DrawString("UF", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151, Linha + 2, 29, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(uf_Transp, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151, Linha + 7, 29, Pt3_DC), XStringFormats.TopLeft)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 150) + 151 + 30, Linha, 126, Pt3_DC))

        graph.DrawString("Inscrição Estadual", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151 + 30, Linha + 2, 126, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(inscricao_estadual_transp, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151 + 30, Linha + 7, 126, Pt3_DC), XStringFormats.TopLeft)

        Linha += 16

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, 80, Pt3_DC))

        graph.DrawString("Quantidade", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(buscaItensOrcamento.Count, font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 81, Linha, 80, Pt3_DC))

        graph.DrawString("Espécie", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 81, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(especie, font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 81, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 162, Linha, 160, Pt3_DC))

        graph.DrawString("Marca", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 162, Linha + 2, 160, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(marca, font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 162, Linha + 7, 160, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 323, Linha, 85, Pt3_DC))

        graph.DrawString("Numeração", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 323, Linha + 2, 85, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(numeracao, font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 323, Linha + 7, 85, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 409, Linha, 84, Pt3_DC))

        graph.DrawString("Peso Bruto", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 409, Linha + 2, 84, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatNumber(PesoBruto, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 409, Linha + 7, 84, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 494, Linha, 71, Pt3_DC))

        graph.DrawString("Peso Líquido", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 494, Linha + 2, 71, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatNumber(PesoLiquido, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 494, Linha + 7, 71, Pt3_DC), XStringFormats.TopRight)

        Linha += 20

        graph.DrawString("Itens da nota fiscal", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

        Linha += 7

        'desenha quadro back
        Dim fontTTITN As XFont = New XFont("Verdana", 4.25, XFontStyle.Bold)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC + 157, (Pt3_DC * 21) + 4))

        Dim Stop_line As Decimal = Linha

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2, Linha + 2, 50, Pt3_DC))

        graph.DrawString("Código", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 50, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50, Linha + 2, 160, Pt3_DC))

        graph.DrawString("Descrição do produto/serviço", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50, Linha + 2, 160, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160, Linha + 2, 50, Pt3_DC))

        graph.DrawString("NCMSH", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160, Linha + 2, 50, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC))

        If CLienteSimples = False Then
            graph.DrawString("CST", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC), XStringFormats.Center)
        Else
            graph.DrawString("CSOSN", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC), XStringFormats.Center)
        End If

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25, Linha + 2, 25, Pt3_DC))

        graph.DrawString("CFOP", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25, Linha + 2, 20, Pt3_DC))

        graph.DrawString("UN", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25, Linha + 2, 20, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25 + 20, Linha + 2, 25, Pt3_DC))

        graph.DrawString("Qtde", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25 + 20, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 - 5, Linha + 2, 30, Pt3_DC))

        graph.DrawString("Vlr Unit.", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 - 5, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 25, Linha + 2, 35, Pt3_DC))

        graph.DrawString("Vlr Total", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 25, Linha + 2, 35, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 60, Linha + 2, 30, Pt3_DC))

        graph.DrawString("BC ICMS", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 60, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 90, Linha + 2, 30, Pt3_DC))

        graph.DrawString("Vlr ICMS", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 90, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 120, Linha + 2, 30, Pt3_DC))

        graph.DrawString("Vlr IPI", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 120, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 150, Linha + 2, 25, Pt3_DC))

        graph.DrawString("% ICMS", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 150, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 175, Linha + 2, 25, Pt3_DC))

        graph.DrawString("% IPI", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 175, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

        Linha += 15

        Dim fontTTITN_0 As XFont = New XFont("Verdana", 4.25, XFontStyle.Regular)

        Linha0 = 0

        For Each row As DataGridViewRow In DtProdutos.Rows

            Dim _IdProduto As Integer = row.Cells(0).Value
            Dim _Descricao As String = row.Cells(1).Value
            Dim _CST As String = row.Cells(4).Value
            Dim _CFOP As String = row.Cells(5).Value
            Dim _Qt As String = row.Cells(8).Value
            Dim _ValorUnit As String = row.Cells(6).Value

            Dim BuscaIdProduto = From prod In LqBase.Produtos
                                 Where prod.IdProduto = _IdProduto
                                 Select prod.IdProduto, prod.Descricao, prod.NCM, prod.UnVenda, prod.CodBarras

            If BuscaIdProduto.Count > 0 Then

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2, Linha + 2, 50, Pt3_DC))

                graph.DrawString(BuscaIdProduto.First.IdProduto, fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 50, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50, Linha + 2, 160, Pt3_DC))

                graph.DrawString(BuscaIdProduto.First.Descricao, fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50, Linha + 2, 160, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160, Linha + 2, 50, Pt3_DC))

                graph.DrawString(BuscaIdProduto.First.NCM, fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160, Linha + 2, 50, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC))

                graph.DrawString(_CST, fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25, Linha + 2, 25, Pt3_DC))

                graph.DrawString(_CFOP, fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25, Linha + 2, 20, Pt3_DC))

                Dim strUn As String = BuscaIdProduto.First.UnVenda
                Dim separadorUn() As Char = "-"
                ' Separa string baseado no delimitador
                Dim palavrasUn As String() = strUn.Split(separadorUn)

                graph.DrawString(palavrasUn.First.Remove(palavrasUn.First.ToLower.Length - 1, 1), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25, Linha + 2, 20, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25 + 20, Linha + 2, 25, Pt3_DC))

                graph.DrawString(FormatNumber(_Qt, NumDigitsAfterDecimal:=0), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25 + 20, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 - 5, Linha + 2, 30, Pt3_DC))

                graph.DrawString(FormatNumber(_ValorUnit, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 - 5, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 25, Linha + 2, 35, Pt3_DC))

                graph.DrawString(FormatNumber(_Qt * _ValorUnit, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 25, Linha + 2, 35, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 60, Linha + 2, 30, Pt3_DC))

                graph.DrawString(FormatNumber(AliquotaICMS, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 60, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 90, Linha + 2, 30, Pt3_DC))

                Dim _ICMS As Decimal = 0

                _ICMS = (_Qt * _ValorUnit) * (AliquotaICMS / 100)

                graph.DrawString(FormatNumber(_ICMS, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 90, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 120, Linha + 2, 30, Pt3_DC))

                Dim _IPI As Decimal = 0

                _IPI = (_Qt * _ValorUnit) * (AliquotaIPI / 100)

                graph.DrawString(FormatNumber(_IPI, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 120, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 150, Linha + 2, 25, Pt3_DC))

                Dim _VLRICMS As Decimal = 0

                _VLRICMS = (AliquotaICMS / 100)

                graph.DrawString(FormatPercent(_VLRICMS, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 150, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 175, Linha + 2, 25, Pt3_DC))

                Dim _VLRIPI As Decimal = 0

                _VLRIPI = (AliquotaIPI / 100)

                graph.DrawString(FormatPercent(_VLRIPI, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 175, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

            Else

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2, Linha + 2, 50, Pt3_DC))

                graph.DrawString("", fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 50, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50, Linha + 2, 160, Pt3_DC))

                graph.DrawString("Teste em ambiente de homolagação", fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50, Linha + 2, 160, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160, Linha + 2, 50, Pt3_DC))

                graph.DrawString("001004025210", fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160, Linha + 2, 50, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC))

                graph.DrawString(_CST, fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25, Linha + 2, 25, Pt3_DC))

                graph.DrawString(_CFOP, fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25, Linha + 2, 20, Pt3_DC))

                graph.DrawString("UN", fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25, Linha + 2, 20, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25 + 20, Linha + 2, 25, Pt3_DC))

                graph.DrawString(FormatNumber(_Qt, NumDigitsAfterDecimal:=0), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25 + 20, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 - 5, Linha + 2, 30, Pt3_DC))

                graph.DrawString(FormatNumber(_ValorUnit, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 - 5, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 25, Linha + 2, 35, Pt3_DC))

                graph.DrawString(FormatNumber(_Qt * _ValorUnit, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 25, Linha + 2, 35, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 60, Linha + 2, 30, Pt3_DC))

                graph.DrawString(FormatNumber(AliquotaICMS, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 60, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 90, Linha + 2, 30, Pt3_DC))

                Dim _ICMS As Decimal = 0

                _ICMS = (_Qt * _ValorUnit) * (AliquotaICMS / 100)

                graph.DrawString(FormatNumber(_ICMS, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 90, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 120, Linha + 2, 30, Pt3_DC))

                Dim _IPI As Decimal = 0

                _IPI = (_Qt * _ValorUnit) * (AliquotaIPI / 100)

                graph.DrawString(FormatNumber(_IPI, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 120, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 150, Linha + 2, 25, Pt3_DC))

                Dim _VLRICMS As Decimal = 0

                _VLRICMS = (AliquotaICMS / 100)

                graph.DrawString(FormatPercent(_VLRICMS, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 150, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 175, Linha + 2, 25, Pt3_DC))

                Dim _VLRIPI As Decimal = 0

                _VLRIPI = (AliquotaIPI / 100)

                graph.DrawString(FormatPercent(_VLRIPI, NumDigitsAfterDecimal:=2), fontTTITN_0, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 175, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

            End If

            Dim _EAN As String = BuscaIdProduto.First.CodBarras
            Dim _NCM As String = BuscaIdProduto.First.NCM

            If _EAN = "" Then
                _EAN = "SEM GTIN"
            End If

            writer.WriteElementString("cProd", BuscaIdProduto.First.IdProduto)
            writer.WriteElementString("cEAN", _EAN)
            writer.WriteElementString("xProd", BuscaIdProduto.First.Descricao)
            writer.WriteElementString("NCM", _NCM)
            writer.WriteElementString("EXTIPI", "")
            writer.WriteElementString("CFOP", _CFOP)
            writer.WriteElementString("uCOM", BuscaIdProduto.First.UnVenda.Remove(3, BuscaIdProduto.First.UnVenda.Length - 3).Replace(" ", "").ToUpper)
            writer.WriteElementString("qCOM", _Qt)
            writer.WriteElementString("vUnCom", FormatNumber(_ValorUnit, NumDigitsAfterDecimal:=2))
            writer.WriteElementString("vProd", FormatNumber(_ValorUnit * _Qt, NumDigitsAfterDecimal:=2))
            writer.WriteElementString("cEANTrib", _EAN)
            writer.WriteElementString("uTrib", BuscaIdProduto.First.UnVenda.Remove(3, BuscaIdProduto.First.UnVenda.Length - 3).Replace(" ", "").ToUpper)
            writer.WriteElementString("qTrib", _Qt)
            writer.WriteElementString("vUnTrib", FormatNumber(_ValorUnit, NumDigitsAfterDecimal:=2))
            writer.WriteElementString("vFrete", "")
            writer.WriteElementString("vSeg", "")
            writer.WriteElementString("vDesc", "")
            writer.WriteElementString("vOutro_item", "")

            If DtProdutos.Rows.Count = 1 Then
                writer.WriteElementString("indTot", "1")
            Else
                writer.WriteElementString("indTot", "0")
            End If

            writer.WriteElementString("nTipoItem", "0")
            writer.WriteElementString("dProd", "0")
            writer.WriteElementString("xPed_item", "")
            writer.WriteElementString("nItemPed", "")
            writer.WriteElementString("nFCI", "")
            writer.WriteElementString("nRECOPI", "")
            writer.WriteElementString("CEST", "")
            writer.WriteElementString("indEscala", "")
            writer.WriteElementString("CNPJFab", "")
            writer.WriteElementString("cBenef", "")

            writer.WriteStartElement("NVEs")

            writer.WriteStartElement("NVEsItem")

            writer.WriteElementString("cNVE", "")

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteStartElement("detDI")

            writer.WriteStartElement("detDIItem")

            writer.WriteElementString("nDI", "")
            writer.WriteElementString("nDI", "")
            writer.WriteElementString("dDi", "")
            writer.WriteElementString("xLocDesemb", "")
            writer.WriteElementString("UFDesemb", "")
            writer.WriteElementString("cExportador", "")
            writer.WriteElementString("dDesemb", "")
            writer.WriteElementString("tpViaTransp", "")
            writer.WriteElementString("vAFRMM", "")
            writer.WriteElementString("tpIntermedio", "")
            writer.WriteElementString("CNPJ_adq", "")
            writer.WriteElementString("UFTerceiro", "")

            writer.WriteStartElement("detAdicoes")

            writer.WriteStartElement("detAdicoesItem")

            writer.WriteElementString("nAdicao", "")
            writer.WriteElementString("nSeqAdic", "")
            writer.WriteElementString("cFabricante", "")
            writer.WriteElementString("vDescDI", "")
            writer.WriteElementString("nDrawAdicoes", "")

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteStartElement("detExport")

            writer.WriteStartElement("exportInd")

            writer.WriteElementString("nDraw", "")

            writer.WriteStartElement("exportInd")

            writer.WriteElementString("nRE", "")
            writer.WriteElementString("chNFe", "")
            writer.WriteElementString("qExport", "")

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteStartElement("veicProd")

            writer.WriteElementString("tpOp", "")
            writer.WriteElementString("chassi", "")
            writer.WriteElementString("cCor", "")
            writer.WriteElementString("xCor", "")
            writer.WriteElementString("pot", "")
            writer.WriteElementString("cilin", "")
            writer.WriteElementString("PesoL", "")
            writer.WriteElementString("PesoB", "")
            writer.WriteElementString("nSerie", "")
            writer.WriteElementString("tpComb", "")
            writer.WriteElementString("nMotor", "")
            writer.WriteElementString("CMT", "")
            writer.WriteElementString("dist", "")
            writer.WriteElementString("anoMod", "")
            writer.WriteElementString("anoFab", "")
            writer.WriteElementString("tpPint", "")
            writer.WriteElementString("tpVeic", "")
            writer.WriteElementString("espVeic", "")
            writer.WriteElementString("condVeic", "")
            writer.WriteElementString("cMod", "")
            writer.WriteElementString("cCorDENATRAN", "")
            writer.WriteElementString("lota", "")
            writer.WriteElementString("tpRest", "")

            writer.WriteEndElement()

            writer.WriteStartElement("med")

            writer.WriteStartElement("medItem")

            writer.WriteElementString("vPMC", "")
            writer.WriteElementString("cProdANVISA", "")

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteStartElement("arma")

            writer.WriteStartElement("armaItem")

            writer.WriteElementString("tpArma", "")
            writer.WriteElementString("nSerie_arma", "")
            writer.WriteElementString("nCano", "")
            writer.WriteElementString("descr", "")

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteStartElement("comb")

            writer.WriteElementString("cProdANP", "")
            writer.WriteElementString("CODIF", "")
            writer.WriteElementString("qTemp", "")
            writer.WriteElementString("Ufcons", "")
            writer.WriteElementString("descANP", "")
            writer.WriteElementString("pGLP", "")
            writer.WriteElementString("pGNn", "")
            writer.WriteElementString("pGNi", "")
            writer.WriteElementString("vPart", "")

            writer.WriteStartElement("CIDE")

            writer.WriteElementString("qBCprod", "")
            writer.WriteElementString("vAliqProd", "")
            writer.WriteElementString("vCIDE", "")

            writer.WriteEndElement()

            writer.WriteStartElement("Encerrante")

            writer.WriteElementString("nBico", "")
            writer.WriteElementString("nBomba", "")
            writer.WriteElementString("nTanque", "")
            writer.WriteElementString("vEncerranteIni", "")
            writer.WriteElementString("vEncerranteFim", "")

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteStartElement("Rastro")

            writer.WriteStartElement("RastroItem")

            writer.WriteElementString("nLote", "")
            writer.WriteElementString("qLote", "")
            writer.WriteElementString("dFab", "")
            writer.WriteElementString("dVal", "")
            writer.WriteElementString("cAgreg", "")

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteStartElement("imposto")

            writer.WriteElementString("vTotTrib", "")

            writer.WriteStartElement("ICMS")

            writer.WriteElementString("orig", "0")
            writer.WriteElementString("CST", _CST)
            writer.WriteElementString("modBC", "")
            writer.WriteElementString("vBC", FormatNumber(BCCalculoICMS, NumDigitsAfterDecimal:=2))
            writer.WriteElementString("pICMS", FormatNumber(AliquotaICMS * 100, NumDigitsAfterDecimal:=0))
            writer.WriteElementString("vICMS_icms", VlrICMS)
            writer.WriteElementString("modBCST", "")
            writer.WriteElementString("pMVAST", "")
            writer.WriteElementString("pRedBCST", "")
            writer.WriteElementString("vBCST", "")
            writer.WriteElementString("vBCSTRet", "")
            writer.WriteElementString("modBCST", "")
            writer.WriteElementString("pICMSST", "")
            writer.WriteElementString("vICMSST_icms", "")
            writer.WriteElementString("vICMSSTRet", "")
            writer.WriteElementString("pRedBC", "")
            writer.WriteElementString("motDesICMS", "")
            writer.WriteElementString("vICMSDeson", "")
            writer.WriteElementString("vICMSOp", "")
            writer.WriteElementString("pDif", "")
            writer.WriteElementString("vICMSDif", "")
            writer.WriteElementString("pBCOp", "")
            writer.WriteElementString("UFST", "")
            writer.WriteElementString("vBCSTDest", "")
            writer.WriteElementString("vICMSSTDest_icms", "")
            writer.WriteElementString("pCredSN", "")
            writer.WriteElementString("vCredICMSSN", "")
            writer.WriteElementString("pFCP", "")
            writer.WriteElementString("vFCP", "")
            writer.WriteElementString("vBCFCP", "")
            writer.WriteElementString("vBCFCPST", "")
            writer.WriteElementString("pFCPST", "")
            writer.WriteElementString("vFCPST", "")
            writer.WriteElementString("pST", "")
            writer.WriteElementString("vBCFCPSTRet", "")
            writer.WriteElementString("pFCPSTRet", "")
            writer.WriteElementString("vFCPSTRet", "")

            writer.WriteEndElement()

            writer.WriteStartElement("IPI")

            If AliquotaIPI > 0 Then
                writer.WriteElementString("clEnq", "")
                writer.WriteElementString("CNPJProd", "")
                writer.WriteElementString("cSelo", "")
                writer.WriteElementString("qSelo", "")
                writer.WriteElementString("cEnq", "")

                writer.WriteStartElement("CSTIPI")

                writer.WriteElementString("CST_IPI", "")
                writer.WriteElementString("vBC_IPI", "")
                writer.WriteElementString("qUnid_IPI", "")
                writer.WriteElementString("vUnid_IPI", "")
                writer.WriteElementString("pIPI", "")
                writer.WriteElementString("vIPI", "")

            Else
                writer.WriteElementString("clEnq", "")
                writer.WriteElementString("CNPJProd", "")
                writer.WriteElementString("cSelo", "")
                writer.WriteElementString("qSelo", "")
                writer.WriteElementString("cEnq", "")

                writer.WriteStartElement("CSTIPI")

                writer.WriteElementString("CST_IPI", "")
                writer.WriteElementString("vBC_IPI", BCCalculoICMS)
                writer.WriteElementString("qUnid_IPI", _Qt)
                writer.WriteElementString("vUnid_IPI", _ValorUnit)
                writer.WriteElementString("pIPI", AliquotaIPI)
                writer.WriteElementString("vIPI", VlrIPI)

            End If


            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteStartElement("II")

            writer.WriteElementString("vBC_imp", "")
            writer.WriteElementString("vDespAdu", "")
            writer.WriteElementString("vII", "")
            writer.WriteElementString("vIOF", "")

            writer.WriteEndElement()

            writer.WriteStartElement("PIS")

            writer.WriteElementString("CST_pis", "")
            writer.WriteElementString("vBC_pis", "")
            writer.WriteElementString("pPIS", "")
            writer.WriteElementString("vPIS", "")
            writer.WriteElementString("qBCprod_pis", "")
            writer.WriteElementString("vAliqProd_pis", "")

            writer.WriteEndElement()

            writer.WriteStartElement("PISST")

            writer.WriteElementString("vBC_pis_ST", "")
            writer.WriteElementString("pPIS_ST", "")
            writer.WriteElementString("qBCprod_pis_ST", "")
            writer.WriteElementString("vAliqProd_pis_ST", "")
            writer.WriteElementString("qBCprod_pis", "")
            writer.WriteElementString("vPIS_ST", "")

            writer.WriteEndElement()

            writer.WriteStartElement("COFINS")

            writer.WriteElementString("CST_cofins", "")
            writer.WriteElementString("vBC_cofins", "")
            writer.WriteElementString("pCOFINS", "")
            writer.WriteElementString("vCOFINS", "")
            writer.WriteElementString("qBCProd_cofins", "")
            writer.WriteElementString("vAliqProd_cofins", "")

            writer.WriteEndElement()

            writer.WriteStartElement("COFINSST")

            writer.WriteElementString("vBC_cofins_ST", "")
            writer.WriteElementString("pCOFINS_cofins_ST", "")
            writer.WriteElementString("qBCProd_cofins_ST", "")
            writer.WriteElementString("vAliqProd_cofins_ST", "")
            writer.WriteElementString("vCOFINS_cofins_ST", "")

            writer.WriteEndElement()

            writer.WriteStartElement("ISSQN")

            writer.WriteElementString("vBC_issqn", "")
            writer.WriteElementString("vAliq", "")
            writer.WriteElementString("vISSQN", "")
            writer.WriteElementString("cMunFg_issqn", "")
            writer.WriteElementString("cListServ", "")
            writer.WriteElementString("vDeducao", "")
            writer.WriteElementString("vOutro_issqn", "")
            writer.WriteElementString("vDescIncond", "")
            writer.WriteElementString("vDescCond", "")
            writer.WriteElementString("indISSRet", "")
            writer.WriteElementString("vISSRet", "")
            writer.WriteElementString("indISS", "")
            writer.WriteElementString("cServico", "")
            writer.WriteElementString("cMun_issqn", "")
            writer.WriteElementString("cPais_issqn", "")
            writer.WriteElementString("nProcesso", "")
            writer.WriteElementString("indIncentivo", "")

            writer.WriteEndElement()

            writer.WriteStartElement("ICMSUFDest")

            writer.WriteElementString("vBCUFDest", "")
            writer.WriteElementString("pFCPUFDest", "")
            writer.WriteElementString("pICMSUFDest", "")
            writer.WriteElementString("pICMSInter", "")
            writer.WriteElementString("pICMSInterPart", "")
            writer.WriteElementString("vFCPUFDest", "")
            writer.WriteElementString("vICMSUFDest", "")
            writer.WriteElementString("vDescIncond", "")
            writer.WriteElementString("vICMSUFRemet", "")
            writer.WriteElementString("vBCFCPUFDest", "")

            writer.WriteEndElement()

            writer.WriteEndElement()

            writer.WriteStartElement("impostoDevol")

            writer.WriteElementString("pDevol", "")

            writer.WriteStartElement("IPIDevol")

            writer.WriteElementString("vIPIDevol", "")

            writer.WriteEndElement()

            writer.WriteEndElement()

            Linha += 15

            If Linha0 = 21 Then

                Linha = Stop_line + ((Pt3_DC * 21) + 4)

                Linha += 5

                graph.DrawString("Calculo do ISSQN", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

                Linha += 7

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, 140, Pt3_DC))

                graph.DrawString("Inscrição Municipal", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 140, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, 140, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 141, Linha, 140, Pt3_DC))

                graph.DrawString("Valor total dos serviços", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 141, Linha + 2, 140, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(FormatCurrency(0, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 140, Linha + 7, 140, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 141 + 141, Linha, 140, Pt3_DC))

                graph.DrawString("Base de cálculo do ISSQN", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 141 + 141, Linha + 2, 140, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(FormatNumber(0, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 140 + 140, Linha + 7, 140, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 141 + 141 + 141, Linha, 142, Pt3_DC))

                graph.DrawString("Valor do ISSQN", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 141 + 141 + 141, Linha + 2, 142, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(FormatCurrency(0, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 140 + 140 + 142, Linha + 7, 142, Pt3_DC), XStringFormats.TopRight)

                Linha += 20

                graph.DrawString("Dados adicionais", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

                Linha += 7

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, (pdfPage.Width.Point / 2) - 16, Pt3_DC * 5))

                graph.DrawString("Observações", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, (pdfPage.Width.Point / 2) - 16, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, (pdfPage.Width.Point / 2) - 16, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (pdfPage.Width.Point / 2) - 15, Linha, (pdfPage.Width.Point / 2) - 15, Pt3_DC * 5))

                graph.DrawString("Reservado ao FISCO", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (pdfPage.Width.Point / 2) - 13, Linha + 2, (pdfPage.Width.Point / 2) - 15, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + (pdfPage.Width.Point / 2) - 13, Linha + 7, (pdfPage.Width.Point / 2) - 15, Pt3_DC), XStringFormats.TopRight)

                Linha += 25

                graph.DrawString(Now.ToString, fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC + (15 * 3)), XStringFormats.BottomRight)
                graph.DrawString("Obtenha o arquivo digital em www.iarasoftware.com.br/nfe", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC + (15 * 3)), XStringFormats.BottomLeft)

                Linha += 7

                Linha0 = 0
                PagAtual += 1

                Linha = 10

                pdfPage = pdf.AddPage()

                graph = XGraphics.FromPdfPage(pdfPage)

                'desenha cabeçalhos

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_RC, Pt1_RC, Pt2_RC + 1, Pt3_RC))
                graph.DrawString("Recebemos de " & FrmPrincipal.RazaoSocial & " os produtos constantes na nota fiscal indicada ao lado.", font_Tit0, XBrushes.SlateGray, New XRect(17, Linha + 3, Pt2_RC, Linha), XStringFormats.TopLeft)
                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_RC, Pt1_RC + 16, 100, Pt3_RC + 5))
                graph.DrawString("Data do recebimento", font_Tit0R, XBrushes.SlateGray, New XRect(17, Linha + 1 + 16, Pt2_RC, Linha), XStringFormats.TopLeft)
                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_RC + 100 + 1, Pt1_RC + 15 + 1, Pt2_RC - 100, Pt3_RC + 5))
                graph.DrawString("Certificação e assinatura do recebedor", font_Tit0R, XBrushes.SlateGray, New XRect(17 + 100 + 1, Linha + 1 + 15 + 1, Pt2_RC - 100, Linha), XStringFormats.TopLeft)
                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_RC + 100 + (Pt2_RC - 100) + 2, Pt1_RC, 96, Pt3_RC + 21))

                graph.DrawString("NFe", font_Tit, XBrushes.SlateGray, New XRect(Pt0_RC + 100 + (Pt2_RC - 100) + 2, Pt1_RC, 96, Pt3_RC), XStringFormats.TopCenter)
                graph.DrawString("Nº.: " & _NumNf, fontDT, XBrushes.SlateGray, New XRect(Pt0_RC + 100 + (Pt2_RC - 100) + 8, Pt1_RC + 15, 96, 10), XStringFormats.TopLeft)
                graph.DrawString("SERIE.: " & _Serie, fontDT, XBrushes.SlateGray, New XRect(Pt0_RC + 100 + (Pt2_RC - 100) + 8, Pt1_RC + 25, 96, 10), XStringFormats.TopLeft)

                Linha += 40

                graph.DrawLine(pen, 0, Linha, pdfPage.Width.Point, Linha)
                '
                Linha += 5

                Pt0_CB = 15
                Pt1_CB = Linha
                Pt2_CB = pdfPage.Width.Point - (15 * 2) - 258
                Pt3_CB = (15 * 7) - 5


                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_CB, Pt1_CB, Pt2_CB, Pt3_CB))
                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_CB + Pt2_CB + 1, Pt1_CB, 100, Pt3_CB))
                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), XBrushes.White, New XRect(Pt0_CB + Pt2_CB + 1 + 100 + 1, Pt1_CB, 156, Pt3_CB))

                'margem cabeçalho

                MargemCBEsq = 130
                Linha += 5

                'insere dados do emissor

                'desenha logotipo
                imgCat06 = My.Resources.logotipo_950x350px
                strmCat06 = New MemoryStream()
                imgCat06.Save(strmCat06, System.Drawing.Imaging.ImageFormat.Png)
                xfotoCat06 = XImage.FromStream(strmCat06)

                graph.DrawImage(xfotoCat06, 30, Linha + 10, 80, 80)

                _CNPJ = FrmPrincipal.CNPJ

                graph.DrawString(FrmPrincipal.NomeFantasia, font_Tit, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha, Pt2_CB, Linha), XStringFormats.TopLeft)

                _Endereco = FrmPrincipal.Endereco & " - "

                'busca dados do 
                ds = New DataSet()
                xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", FrmPrincipal.Endereco)
                ds.ReadXml(xml)
                _Endereco &= " " & ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString() & ", " & FrmPrincipal.Numero & "(" & FrmPrincipal.Complemento & ")"
                _Endereco &= ", " & ds.Tables(0).Rows(0)("bairro").ToString()
                _Endereco &= ", " & ds.Tables(0).Rows(0)("cidade").ToString()
                _Endereco &= ", " & ds.Tables(0).Rows(0)("uf").ToString()

                graph.DrawString("Razão social", fontTT0, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 20, Pt2_CB, Linha), XStringFormats.TopLeft)
                graph.DrawString(FrmPrincipal.RazaoSocial, font, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 24, Pt2_CB, Linha), XStringFormats.TopLeft)

                str = _Endereco

                C = 0
                CT = 45
                graph.DrawString("Endereço: ", fontTT0, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 48, Pt2_CB, Linha + 10), XStringFormats.TopLeft)

                Inicio = Linha + 52

                StringEnd = ""

                For Each palavra In palavras

                    If C + palavra.Length + 1 < CT Then

                        C += palavra.Length + 1
                        StringEnd &= palavra & " "

                    Else

                        StringEnd &= palavra & " "

                        graph.DrawString(StringEnd, font, XBrushes.SlateGray, New XRect(MargemCBEsq, Inicio, 120, 15), XStringFormats.TopLeft)

                        Inicio += 7
                        C = 0
                        StringEnd = ""

                    End If

                Next

                graph.DrawString(StringEnd, font, XBrushes.SlateGray, New XRect(MargemCBEsq, Inicio, 120, 15), XStringFormats.TopLeft)

                graph.DrawString("Telefone", fontTT0, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 78, Pt2_CB, Linha), XStringFormats.TopLeft)
                graph.DrawString(FrmPrincipal.Telefone, font, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha + 82, Pt2_CB, Linha), XStringFormats.TopLeft)

                graph.DrawString("E-mail", fontTT0, XBrushes.SlateGray, New XRect(MargemCBEsq + 80, Linha + 78, Pt2_CB, Linha), XStringFormats.TopLeft)
                graph.DrawString(FrmPrincipal.Email, font, XBrushes.SlateGray, New XRect(MargemCBEsq + 80, Linha + 82, Pt2_CB, Linha), XStringFormats.TopLeft)

                MargemCBEsq = Pt0_CB + Pt2_CB + 1

                'desenha logotipo NFE
                imgNF = My.Resources.NFEImage
                strmNF = New MemoryStream()
                imgNF.Save(strmNF, System.Drawing.Imaging.ImageFormat.Png)
                xfotoNF = XImage.FromStream(strmNF)

                graph.DrawImage(xfotoNF, MargemCBEsq + 25, Linha + 30, 50, 60)
                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_CB + Pt2_CB + 1 + 4, Pt1_CB + 56, 92, Pt3_CB - 60))

                graph.DrawString("DANFE", font_Tit, XBrushes.SlateGray, New XRect(MargemCBEsq, Linha, 100, 10), XStringFormats.TopCenter)
                graph.DrawString("Documento Auxiliar da", font, XBrushes.SlateGray, New XRect(MargemCBEsq + 1, Linha + 15, 100, 10), XStringFormats.TopCenter)
                graph.DrawString("Nota Fiscal Eletrônica", font, XBrushes.SlateGray, New XRect(MargemCBEsq + 1, Linha + 25, 100, 10), XStringFormats.TopCenter)

                graph.DrawString("1 - Saída", fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6, Linha + 55, 100, 10), XStringFormats.TopLeft)
                graph.DrawString("0 - Entrada", fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6, Linha + 65, 100, 10), XStringFormats.TopLeft)
                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(MargemCBEsq + 1 + 6 + 66, Pt1_CB + 56 + 4, 17, Pt3_CB - 83))
                graph.DrawString("1", font_Tit, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6 + 66, Pt1_CB + 56 + 4, 17, 17), XStringFormats.Center)
                graph.DrawString("Nº.: " & _NumNf, fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6, Linha + 76, 100, 10), XStringFormats.TopLeft)

                graph.DrawString("Pag " & PagAtual & " de " & Pag, fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq - 10, Linha + 76, 100, 10), XStringFormats.TopRight)
                graph.DrawString("SERIE.: " & _Serie, fontDT, XBrushes.SlateGray, New XRect(MargemCBEsq + 1 + 6, Linha + 83, 100, 10), XStringFormats.TopLeft)

                'controle do fisco

                graph.DrawString("Controle do FISCO", font_Tit, XBrushes.SlateGray, New XRect(Pt0_CB + Pt2_CB + 1 + 100 + 1, Linha, 156, 10), XStringFormats.TopCenter)
                graph.DrawString("Consulta de autenticidade no portal da NF-e", fontTT0, XBrushes.SlateGray, New XRect(Pt0_CB + Pt2_CB + 1 + 100 + 1, Linha + 79, 156, 10), XStringFormats.TopCenter)
                graph.DrawString("www.nfe.fazenda.gov.br/portal ou site da SEFAZ autorizada", fontTT0, XBrushes.SlateGray, New XRect(Pt0_CB + Pt2_CB + 1 + 100 + 1, Linha + 84, 156, 10), XStringFormats.TopCenter)

                bc25 = New Code3of9Standard("ISABEL123", New XSize(146, 30))
                bc25.Text = "32191105570714000825550010059146621133082968"
                bc25.Size = New XSize(130, 30)
                bc25.TextLocation = TextLocation.Below
                graph.DrawBarCode(bc25, XBrushes.SlateGray, font_Tit1R, New XPoint(Pt0_CB + Pt2_CB + 1 + 100 + 1 + 5 + 10, Linha + 30))
                bc25.Direction = CodeDirection.RightToLeft

                Linha += Pt3_CB

                Pt0_DC = 15
                Pt1_DC = Linha
                Pt2_DC = pdfPage.Width.Point - (15 * 2) - 157
                Pt3_DC = (15 * 1)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Pt1_DC, Pt2_DC, Pt3_DC))

                graph.DrawString("Natureza da operação", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Pt1_DC + 2, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("Venda de produtos de terceiro", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Pt1_DC + 7, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1, Pt1_DC, 156, Pt3_DC))

                graph.DrawString("Protocolo", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 1 + 2, Pt1_DC + 2, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(Now.ToString, font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 1 + 2, Pt1_DC + 7, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Pt1_DC + 16, 130, Pt3_DC))

                graph.DrawString("Inscrição estadual", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Pt1_DC + 2 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(FrmPrincipal.IE, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Pt1_DC + 7 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 131, Pt1_DC + 16, 130, Pt3_DC))

                graph.DrawString("Inscrição estadual do Subs. Trib.", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 133, Pt1_DC + 2 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 133, Pt1_DC + 7 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 262, Pt1_DC + 16, 146, Pt3_DC))

                graph.DrawString("CNPJ", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 264, Pt1_DC + 2 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(_CNPJ, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 264, Pt1_DC + 7 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 262 + 147, Pt1_DC + 16, 156, Pt3_DC))

                graph.DrawString("Chave de acesso da NF-e para consulta de autenticidade no site", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 264 + 145, Pt1_DC + 2 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("Documento sem valor fiscal", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 264 + 145, Pt1_DC + 7 + 16, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

                Linha += 35

                graph.DrawString("Destinatário - Remetente", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

                Linha += 7

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC, Pt3_DC))

                graph.DrawString("Nome completo/Razão social", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(BuscaCliente.First.RazaoSocial_nome, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1, Linha, 94, Pt3_DC))

                graph.DrawString("CPF/CNPJ", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3, Linha + 2, 94, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(BuscaCliente.First.CPF_CNPJ, font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3, Linha + 7, 94, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1 + 97, Linha, 59, Pt3_DC))

                graph.DrawString("Data da emissão", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(Today.Date, font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

                Linha += 16

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC - 151, Pt3_DC))

                _EnderecoInd = FrmPrincipal.Endereco & " - "

                'busca dados do 
                dsInd = New DataSet()
                xmlInd = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", BuscaCliente.First.CEP)
                dsInd.ReadXml(xmlInd)
                _EnderecoInd = ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString() & ", " & BuscaCliente.First.Numero & "(" & BuscaCliente.First.Complemento & ")"


                graph.DrawString("Endereço", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 101, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(_EnderecoInd, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 101, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 150), Linha, 150, Pt3_DC))

                graph.DrawString("Bairro", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150), Linha + 2, 150, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(ds.Tables(0).Rows(0)("bairro").ToString(), font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150), Linha + 7, 150, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 150) + 151, Linha, 94, Pt3_DC))

                graph.DrawString("CEP", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151, Linha + 2, 94, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(BuscaCliente.First.CEP, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151, Linha + 7, 94, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1 + 97, Linha, 59, Pt3_DC))

                graph.DrawString("Data da saída", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(Today.Date, font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

                Linha += 16

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC - 251, Pt3_DC))

                graph.DrawString("Município", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 251, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(ds.Tables(0).Rows(0)("cidade").ToString(), font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 251, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250), Linha, 99, Pt3_DC))

                graph.DrawString("Telefone", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 250), Linha + 2, 99, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(BuscaCliente.First.Telefone, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 250), Linha + 7, 99, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100, Linha, 59, Pt3_DC))

                graph.DrawString("UF", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(ds.Tables(0).Rows(0)("uf").ToString(), font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 60, Linha, 90, Pt3_DC))

                graph.DrawString("Indicador I.E.", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60, Linha + 2, 90, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60, Linha + 7, 90, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 60 + 91, Linha, 94, Pt3_DC))

                graph.DrawString("RG/IE", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91, Linha + 2, 94, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(BuscaCliente.First.RG_IE, font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91, Linha + 7, 94, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + Pt2_DC + 1 + 97, Linha, 59, Pt3_DC))

                graph.DrawString("Hora da saída", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(FormatDateTime(Now.TimeOfDay.ToString, DateFormat.ShortTime), font, XBrushes.SlateGray, New XRect(Pt0_DC + Pt2_DC + 3 + 97, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

                Linha += 16

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC))

                graph.DrawString("Formas de pagamento", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 251, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 251, Pt3_DC), XStringFormats.TopLeft)

                Linha += 20

                graph.DrawString("Calculo do imposto", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

                Linha += 7

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, 80, Pt3_DC))

                graph.DrawString("Base calculo ICMS", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 81, Linha, 80, Pt3_DC))

                graph.DrawString("Valor ICMS", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 81, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("R$ 0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 81, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 162, Linha, 80, Pt3_DC))

                graph.DrawString("Base calculo ICMS subst.", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 162, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 162, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 243, Linha, 80, Pt3_DC))

                graph.DrawString("Valor ICMS subst.", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 243, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("R$ 0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 243, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 324, Linha, 84, Pt3_DC))

                graph.DrawString("Total do PIS", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 324, Linha + 2, 84, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("R$ 0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 324, Linha + 7, 84, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 89, Linha, 156, Pt3_DC))

                ValorProd = 0

                For Each row0 In buscaItensOrcamento.ToList
                    If row0.Tipo = True Then
                        ValorProd += row0.ValorUnit * row0.Qtdade
                    End If
                Next

                graph.DrawString("Valor total dos produtos", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91, Linha + 2, 154, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(FormatCurrency(ValorProd, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91, Linha + 7, 153, Pt3_DC), XStringFormats.TopRight)

                Linha += 16

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, 80, Pt3_DC))

                graph.DrawString("Valor do frete", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("R$ 0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 81, Linha, 80, Pt3_DC))

                graph.DrawString("Valor do seguro", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 81, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("R$ 0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 81, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 162, Linha, 80, Pt3_DC))

                graph.DrawString("Desconto", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 162, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("R$ 0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 162, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 243, Linha, 80, Pt3_DC))

                graph.DrawString("Outras despesas", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 243, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("R$ 0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 243, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 324, Linha, 84, Pt3_DC))

                graph.DrawString("Valor do IPI", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 324, Linha + 2, 84, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("R$ 0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 324, Linha + 7, 84, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 409, Linha, 84, Pt3_DC))

                graph.DrawString("Valor da COFINS", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 409, Linha + 2, 84, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("R$ 0,00", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 409, Linha + 7, 84, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 89 + 85, Linha, 71, Pt3_DC))

                graph.DrawString("Valor total da NF", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91 + 84, Linha + 2, 71, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(FormatCurrency(ValorProd, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 250) + 100 + 2 + 60 + 91 + 84, Linha + 7, 69, Pt3_DC), XStringFormats.TopRight)

                Linha += 20

                graph.DrawString("Transportador/Volumes transportados", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

                Linha += 7

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC - 166, Pt3_DC))

                graph.DrawString("Nome/Razão Social", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 166, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 166, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165), Linha, 120, Pt3_DC))

                graph.DrawString("Frete", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165), Linha + 2, 120, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(CmbTransporteModo.SelectedItem.ToString, font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165), Linha + 7, 120, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165) + 121, Linha, 44, Pt3_DC))

                graph.DrawString("Cod. ANTT", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165) + 121, Linha + 2, 44, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165) + 121, Linha + 7, 44, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 45, Linha, 59, Pt3_DC))

                graph.DrawString("Placa do veículo", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47, Linha + 2, 59, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47, Linha + 7, 59, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 45 + 60, Linha, 24, Pt3_DC))

                graph.DrawString("UF", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47 + 60, Linha + 2, 24, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47 + 60, Linha + 7, 24, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 45 + 60 + 25, Linha, 71, Pt3_DC))

                graph.DrawString("CPF/CNPJ", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47 + 60 + 25, Linha + 2, 71, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + (Pt2_DC - 165) + 121 + 47 + 60 + 25, Linha + 7, 71, Pt3_DC), XStringFormats.TopLeft)

                Linha += 16

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC - 166, Pt3_DC))

                graph.DrawString("Endereço", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, Pt2_DC - 165, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 7, Pt2_DC - 165, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 165), Linha, 165, Pt3_DC))

                graph.DrawString("Município", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 165), Linha + 2, 165, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 116550), Linha + 7, 165, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 150) + 151, Linha, 29, Pt3_DC))

                graph.DrawString("UF", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151, Linha + 2, 29, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151, Linha + 7, 29, Pt3_DC), XStringFormats.TopLeft)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (Pt2_DC - 150) + 151 + 30, Linha, 126, Pt3_DC))

                graph.DrawString("Inscrição Estadual", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151 + 30, Linha + 2, 126, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + (Pt2_DC - 150) + 151 + 30, Linha + 7, 126, Pt3_DC), XStringFormats.TopLeft)

                Linha += 16

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, 80, Pt3_DC))

                graph.DrawString("Quantidade", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString(buscaItensOrcamento.Count, font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 81, Linha, 80, Pt3_DC))

                graph.DrawString("Espécie", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 81, Linha + 2, 80, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("Caixas", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 81, Linha + 7, 80, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 162, Linha, 160, Pt3_DC))

                graph.DrawString("Marca", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 162, Linha + 2, 160, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 162, Linha + 7, 160, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 323, Linha, 85, Pt3_DC))

                graph.DrawString("Numeração", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 323, Linha + 2, 85, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 323, Linha + 7, 85, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 409, Linha, 84, Pt3_DC))

                graph.DrawString("Peso Bruto", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 409, Linha + 2, 84, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 409, Linha + 7, 84, Pt3_DC), XStringFormats.TopRight)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 494, Linha, 71, Pt3_DC))

                graph.DrawString("Peso Líquido", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 494, Linha + 2, 71, Pt3_DC), XStringFormats.TopLeft)
                graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 494, Linha + 7, 71, Pt3_DC), XStringFormats.TopRight)

                Linha += 20

                graph.DrawString("Itens da nota fiscal", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

                Linha += 7

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, Pt2_DC + 157, (Pt3_DC * 21) + 4))

                Stop_line = Linha

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2, Linha + 2, 50, Pt3_DC))

                graph.DrawString("Código", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 50, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50, Linha + 2, 160, Pt3_DC))

                graph.DrawString("Descrição do produto/serviço", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50, Linha + 2, 160, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160, Linha + 2, 50, Pt3_DC))

                graph.DrawString("NCMSH", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160, Linha + 2, 50, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC))

                If CLienteSimples = False Then
                    graph.DrawString("CST", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC), XStringFormats.Center)
                Else
                    graph.DrawString("CSONS", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50, Linha + 2, 25, Pt3_DC), XStringFormats.Center)
                End If

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25, Linha + 2, 25, Pt3_DC))

                graph.DrawString("CFOP", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25, Linha + 2, 20, Pt3_DC))

                graph.DrawString("UN", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25, Linha + 2, 20, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25 + 20, Linha + 2, 25, Pt3_DC))

                graph.DrawString("Qtde", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 50 + 160 + 50 + 25 + 25 + 20, Linha + 2, 25, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 - 5, Linha + 2, 30, Pt3_DC))

                graph.DrawString("Vlr Unit.", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 - 5, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 25, Linha + 2, 35, Pt3_DC))

                graph.DrawString("Vlr Total", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 25, Linha + 2, 35, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 60, Linha + 2, 30, Pt3_DC))

                graph.DrawString("BC ICMS", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 60, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 90, Linha + 2, 30, Pt3_DC))

                graph.DrawString("Vlr ICMS", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 90, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 120, Linha + 2, 30, Pt3_DC))

                graph.DrawString("Vlr IPI", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 120, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 150, Linha + 2, 30, Pt3_DC))

                graph.DrawString("% ICMS", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 150, Linha + 2, 30, Pt3_DC), XStringFormats.Center)

                graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 362 + 180, Linha + 2, 20, Pt3_DC))

                graph.DrawString("% IPI", fontTTITN, XBrushes.SlateGray, New XRect(Pt0_DC + 362 + 180, Linha + 2, 20, Pt3_DC), XStringFormats.Center)

                Linha += 15

            Else

                Linha0 += 1

            End If

        Next

        Linha = Stop_line + ((Pt3_DC * 21) + 4)

        Linha += 5

        graph.DrawString("Calculo do ISSQN", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

        Linha += 7

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, 140, Pt3_DC))

        graph.DrawString("Inscrição Municipal", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, 140, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(InscricaoMunicipal, font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, 140, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 141, Linha, 140, Pt3_DC))

        graph.DrawString("Valor total dos serviços", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 141, Linha + 2, 140, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(VlrServico, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 140, Linha + 7, 140, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 141 + 141, Linha, 140, Pt3_DC))

        graph.DrawString("Base de cálculo do ISSQN", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 141 + 141, Linha + 2, 140, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatNumber(BCISSQN, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 140 + 140, Linha + 7, 140, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + 141 + 141 + 141, Linha, 142, Pt3_DC))

        graph.DrawString("Valor do ISSQN", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2 + 141 + 141 + 141, Linha + 2, 142, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(FormatCurrency(VlrISSQN, NumDigitsAfterDecimal:=2), font, XBrushes.SlateGray, New XRect(Pt0_DC - 2 + 140 + 140 + 142, Linha + 7, 142, Pt3_DC), XStringFormats.TopRight)

        Linha += 20

        graph.DrawString("Dados adicionais", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC), XStringFormats.TopCenter)

        Linha += 7

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC, Linha, (pdfPage.Width.Point / 2) - 16, Pt3_DC * 5))

        graph.DrawString("Observações", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + 2, Linha + 2, (pdfPage.Width.Point / 2) - 16, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString(Observacos, font, XBrushes.SlateGray, New XRect(Pt0_DC - 2, Linha + 7, (pdfPage.Width.Point / 2) - 16, Pt3_DC), XStringFormats.TopRight)

        graph.DrawRectangle(New XPen(XColor.FromArgb(120, XColors.SlateGray), 0.5), New XSolidBrush(XColor.FromArgb(160, XColors.White)), New XRect(Pt0_DC + (pdfPage.Width.Point / 2) - 15, Linha, (pdfPage.Width.Point / 2) - 15, Pt3_DC * 5))

        graph.DrawString("Reservado ao FISCO", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC + (pdfPage.Width.Point / 2) - 13, Linha + 2, (pdfPage.Width.Point / 2) - 15, Pt3_DC), XStringFormats.TopLeft)
        graph.DrawString("", font, XBrushes.SlateGray, New XRect(Pt0_DC + (pdfPage.Width.Point / 2) - 13, Linha + 7, (pdfPage.Width.Point / 2) - 15, Pt3_DC), XStringFormats.TopRight)

        Linha += 25

        graph.DrawString(Now.ToString, fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC + (15 * 3)), XStringFormats.BottomRight)
        graph.DrawString("Obtenha o arquivo digital em www.iarasoftware.com.br/nfe", fontTT0, XBrushes.SlateGray, New XRect(Pt0_DC, Linha, Pt2_DC + 157, Pt3_DC + (15 * 3)), XStringFormats.BottomLeft)


        pdf.Save("C:\Iara\NFE-DANFE\" & _NumNf & ".pdf")

        'termina XML

        writer.WriteEndElement()

        writer.WriteStartElement("total")

        writer.WriteStartElement("ICMStot")

        writer.WriteElementString("vBC_ttlnfe", "")
        writer.WriteElementString("vICMS_ttlnfe", "")
        writer.WriteElementString("vICMSDeson_ttlnfe", "")
        writer.WriteElementString("vBCST_ttlnfe", "")
        writer.WriteElementString("vST_ttlnfe", "")
        writer.WriteElementString("vProd_ttlnfe", "")
        writer.WriteElementString("vFrete_ttlnfe", "")
        writer.WriteElementString("vSeg_ttlnfe", "")
        writer.WriteElementString("vDesc_ttlnfe", "")
        writer.WriteElementString("vII_ttlnfe", "")
        writer.WriteElementString("vIPI_ttlnfe", "")
        writer.WriteElementString("vPIS_ttlnfe", "")
        writer.WriteElementString("vCOFINS_ttlnfe", "")
        writer.WriteElementString("vOutro", "")
        writer.WriteElementString("vNF", "")
        writer.WriteElementString("vTotTrib_ttlnfe", "")
        writer.WriteElementString("vFCPUFDest_ttlnfe", "")
        writer.WriteElementString("vICMSUFDest_ttlnfe", "")
        writer.WriteElementString("vICMSUFRemet_ttlnfe", "")
        writer.WriteElementString("vFCP_ttlnfe", "")
        writer.WriteElementString("vFCPST_ttlnfe", "")
        writer.WriteElementString("vFCPSTRet_ttlnfe", "")
        writer.WriteElementString("vIPIDevol_ttlnfe", "")

        writer.WriteEndElement()

        writer.WriteStartElement("ISSQNtot")

        writer.WriteElementString("vServ", "")
        writer.WriteElementString("vBC_ttlnfe_iss", "")
        writer.WriteElementString("vISS", "")
        writer.WriteElementString("vPIS_servttlnfe", "")
        writer.WriteElementString("vCOFINS_servttlnfe", "")
        writer.WriteElementString("dCompet", "")
        writer.WriteElementString("vDeducao_servttlnfe", "")
        writer.WriteElementString("vDescIncond_servttlnfe", "")
        writer.WriteElementString("vDescCond_servttlnfe", "")
        writer.WriteElementString("vISSRet_servttlnfe", "")
        writer.WriteElementString("cRegTrib", "")

        writer.WriteEndElement()

        writer.WriteStartElement("retTrib")

        writer.WriteElementString("vRetPIS", "")
        writer.WriteElementString("vRetCOFINS_servttlnfe", "")
        writer.WriteElementString("vRetCSLL", "")
        writer.WriteElementString("vBCIRRF", "")
        writer.WriteElementString("vIRRF", "")
        writer.WriteElementString("vBCRetPrev", "")
        writer.WriteElementString("vRetPrev", "")

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteStartElement("transp")

        writer.WriteElementString("modFrete", "")
        writer.WriteElementString("balsa", "")

        writer.WriteStartElement("transporta")

        writer.WriteElementString("CNPJ_transp", "")
        writer.WriteElementString("xNome_transp", "")
        writer.WriteElementString("IE_transp", "")
        writer.WriteElementString("xEnder", "")
        writer.WriteElementString("xMun_transp", "")
        writer.WriteElementString("UF_transp", "")

        writer.WriteEndElement()

        writer.WriteStartElement("retTransp")

        writer.WriteElementString("vServ_transp", "")
        writer.WriteElementString("vBCRet", "")
        writer.WriteElementString("pICMSRet", "")
        writer.WriteElementString("vICMSRet", "")
        writer.WriteElementString("CFOP_transp", "")
        writer.WriteElementString("cMunFG_transp", "")

        writer.WriteEndElement()

        writer.WriteStartElement("veicTransp")

        writer.WriteElementString("placa", "")
        writer.WriteElementString("UF_veictransp", "")
        writer.WriteElementString("RNTC", "")

        writer.WriteEndElement()

        writer.WriteStartElement("reboque")

        writer.WriteStartElement("reboqueItem")

        writer.WriteElementString("placa_rebtransp", "")
        writer.WriteElementString("UF_rebtransp", "")
        writer.WriteElementString("RNTC_rebtransp", "")

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteStartElement("vol")

        writer.WriteStartElement("volItem")

        writer.WriteElementString("qVol", "")
        writer.WriteElementString("esp", "")
        writer.WriteElementString("marca", "")
        writer.WriteElementString("nVol", "")
        writer.WriteElementString("pesoL_transp", "")
        writer.WriteElementString("pesoB_transp", "")

        writer.WriteStartElement("lacres")

        writer.WriteStartElement("lacresItem")

        writer.WriteElementString("nLacre", "")

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteStartElement("cobr")

        writer.WriteStartElement("fat")

        writer.WriteElementString("nFat", "")
        writer.WriteElementString("vOrig", "")
        writer.WriteElementString("vDesc_cob", "")
        writer.WriteElementString("vLiq", "")

        writer.WriteEndElement()

        writer.WriteStartElement("dup")

        writer.WriteStartElement("dupItem")

        writer.WriteElementString("nDup", "")
        writer.WriteElementString("dVenc", "")
        writer.WriteElementString("vDup", "")

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteStartElement("pag")

        writer.WriteStartElement("pagItem")

        writer.WriteElementString("tPag", "")
        writer.WriteElementString("vPag", "")

        writer.WriteStartElement("card")

        writer.WriteElementString("tipoIntegracao", "")
        writer.WriteElementString("CNPJ_card", "")
        writer.WriteElementString("tBand", "")
        writer.WriteElementString("cAut", "")

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteElementString("vTroco", "")

        writer.WriteStartElement("infAdic")
        writer.WriteStartElement("infAdFisco")
        writer.WriteEndElement()
        writer.WriteStartElement("infCpl")
        writer.WriteEndElement()
        writer.WriteStartElement("obsCont")
        writer.WriteStartElement("obsContItem")
        writer.WriteElementString("xCampo", "")
        writer.WriteElementString("xTexto", "")
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("procRef")
        writer.WriteStartElement("procRefItem")
        writer.WriteElementString("nProc", "")
        writer.WriteElementString("indProc", "")
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteEndElement()

        writer.WriteStartElement("infSuplem")
        writer.WriteElementString("qrCode", "")
        writer.WriteElementString("urlChave", "")
        writer.WriteEndElement()

        writer.WriteStartElement("exporta")
        writer.WriteElementString("UFEmbarq", "")
        writer.WriteElementString("xLocEmbarq", "")
        writer.WriteElementString("xLocDespacho", "")
        writer.WriteEndElement()

        writer.WriteStartElement("compra")
        writer.WriteElementString("xNEmp", "")
        writer.WriteElementString("xPed", "")
        writer.WriteElementString("xCont", "")
        writer.WriteEndElement()

        writer.WriteStartElement("cana")
        writer.WriteElementString("safra", "")
        writer.WriteElementString("ref", "")
        writer.WriteElementString("qTotMes", "")
        writer.WriteElementString("qTotAnt", "")
        writer.WriteElementString("qTotGer", "")
        writer.WriteElementString("vFor", "")
        writer.WriteElementString("vTotDed", "")
        writer.WriteElementString("vLiqFor", "")
        writer.WriteStartElement("canaDiario")
        writer.WriteStartElement("DiarioItem")
        writer.WriteElementString("dia", "")
        writer.WriteElementString("qtde", "")
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("canaDeducoes")
        writer.WriteStartElement("DeducoesItem")
        writer.WriteElementString("xDed", "")
        writer.WriteElementString("vDed", "")
        writer.WriteEndElement()
        writer.WriteEndElement()

        writer.WriteEndElement()

        ' encerra o elemento raiz

        writer.WriteEndElement()

        'Escreve o XML para o arquivo e fecha o objeto escritor

        writer.Close()

        'Process.Start("C:\Iara\NFE-DANFE\teste.pdf")

    End Sub

    Private Sub BttLiberarEntregador_Click(sender As Object, e As EventArgs) Handles BttEmitirNfFiscal.Click

        Me.Cursor = Cursors.AppStarting

        EmiteDanfe()

        FrmEmitirNFS.CarregaInicio()

        'carrega inciais
        Me.Close()

        Me.Cursor = Cursors.Arrow

    End Sub

    Public UFEmissor As String
    Public UfDestinatario As String

    Private Sub FrmEmitirNovaNF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'preenche modos de transpote

        CmbTransporteModo.Items.Add("0 – Contratação do Frete por conta do Remetente (CIF)")
        CmbTransporteModo.Items.Add("1 – Contratação do Frete por conta do Destinatário (FOB)")
        CmbTransporteModo.Items.Add("2 – Contratação do Frete por conta de Terceiros")
        CmbTransporteModo.Items.Add("3 – Transporte Próprio por conta do Remetente")
        CmbTransporteModo.Items.Add("4 – Transporte Próprio por conta do Destinatário")
        CmbTransporteModo.Items.Add("9 – Sem Ocorrência de Transporte")

        CmbTransporteModo.SelectedIndex = 5

        If CmbTransporteModo.SelectedItem.ToString.StartsWith("0") Or CmbTransporteModo.ToString.StartsWith("3") Then
            'habilita para escolher a transportadora

        End If

        'preenche os dados iniciais

        LblCnpj.Text = FrmPrincipal.CNPJ
        LblRazao.Text = FrmPrincipal.RazaoSocial
        LblIE.Text = FrmPrincipal.IE
        'busca dados do 

        Dim _Endereco As String = FrmPrincipal.Endereco & " - "

        'busca dados do 
        Dim ds As New DataSet()
        Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", FrmPrincipal.Endereco)
        ds.ReadXml(xml)
        _Endereco &= " " & ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString() & ", " & FrmPrincipal.Numero & "(" & FrmPrincipal.Complemento & ")"
        _Endereco &= ", " & ds.Tables(0).Rows(0)("bairro").ToString()
        _Endereco &= ", " & ds.Tables(0).Rows(0)("cidade").ToString()
        _Endereco &= ", " & ds.Tables(0).Rows(0)("uf").ToString()

        UFEmissor = ds.Tables(0).Rows(0)("uf").ToString()

        LblEndereco.Text = _Endereco

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim IdOrcamento As Integer = _IdOrcamento

        Dim BuscaComercial = From com In LqComercial.Orcamentos
                             Where com.IdOrcamento = IdOrcamento
                             Select com.IdCliente

        Dim buscaItensOrcamento = From orc In LqComercial.ProdutosOrcamento
                                  Where orc.IdOrcamento = IdOrcamento
                                  Select orc.IdProduto, orc.ValorUnit, orc.Qtdade, orc.Tipo, orc.DescontoUnit

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        For Each row In buscaItensOrcamento.ToList

            Dim BuscaDadosProduto = From prod In LqBase.Produtos
                                    Where prod.IdProduto = row.IdProduto
                                    Select prod.Descricao, prod.NCM, prod.CodBarras

            DtProdutos.Rows.Add(row.IdProduto, BuscaDadosProduto.First.Descricao, BuscaDadosProduto.First.NCM, BuscaDadosProduto.First.CodBarras, "", "", FormatCurrency(row.ValorUnit, NumDigitsAfterDecimal:=2), FormatCurrency(row.DescontoUnit, NumDigitsAfterDecimal:=2), row.Qtdade, FormatCurrency(row.Qtdade * (row.ValorUnit - row.DescontoUnit), NumDigitsAfterDecimal:=2))

        Next

        'busca dados do cliente

        Dim BuscaCliente = From cli In LqBase.Clientes
                           Where cli.IdCliente = BuscaComercial.First
                           Select cli.Telefone, cli.RazaoSocial_nome, cli.CPF_CNPJ, cli.CEP, cli.Numero, cli.Complemento, cli.RG_IE

        LblCnpj_Cpf_Destinatário.Text = BuscaCliente.First.CPF_CNPJ
        LblRazaoSocial_Nome.Text = BuscaCliente.First.RazaoSocial_nome
        LblInscricaoEstadualIe.Text = BuscaCliente.First.RG_IE

        Dim _EnderecoInd As String = FrmPrincipal.Endereco & " - "

        'busca dados do 
        Dim dsInd As New DataSet()
        Dim xmlInd As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", BuscaCliente.First.CEP)
        dsInd.ReadXml(xmlInd)
        _EnderecoInd &= dsInd.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & dsInd.Tables(0).Rows(0)("logradouro").ToString() & ", " & BuscaCliente.First.Numero & "(" & BuscaCliente.First.Complemento & ")"
        _EnderecoInd &= ", " & dsInd.Tables(0).Rows(0)("bairro").ToString()
        _EnderecoInd &= ", " & dsInd.Tables(0).Rows(0)("cidade").ToString()
        _EnderecoInd &= ", " & dsInd.Tables(0).Rows(0)("uf").ToString()

        UfDestinatario = dsInd.Tables(0).Rows(0)("uf").ToString()

        LblEnderecoDestinatario.Text = _EnderecoInd

        If CLienteSimples = True Then
            Column5.HeaderText = "CSOSN"
        End If
    End Sub

    Dim LstDocTrans As New ListBox
    Dim LstEnderecoTrans As New ListBox
    Dim LstMunicioTrans As New ListBox
    Dim LstUfTrans As New ListBox
    Dim Ie As New ListBox

    Private Sub CmbTransporteModo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTransporteModo.SelectedIndexChanged

        CmbTransportadores.Enabled = False
        CmbTransportadores.Text = ""
        LblCnpjTranp.Text = ""
        LblEnderecoTransp.Text = ""
        LblRGIETransp.Text = ""

        If CmbTransporteModo.SelectedItem.ToString.StartsWith("0") Then

            'habilita para escolher a transportadora
            CmbTransportadores.Enabled = True

            'busca transportadoras 

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaBase = From bas In LqBase.Fornecedores
                            Where bas.Beneficiario = True
                            Select bas.Doc, bas.Nome, bas.Cep, bas.Numero, bas.Compl, bas.IE

            CmbTransportadores.Items.Clear()
            LstDocTrans.Items.Clear()
            LstEnderecoTrans.Items.Clear()
            LstMunicioTrans.Items.Clear()
            LstUfTrans.Items.Clear()
            Ie.Items.Clear()

            For Each row In BuscaBase.ToList

                CmbTransportadores.Items.Add(row.Nome)
                LstDocTrans.Items.Add(row.Doc)
                Ie.Items.Add(row.IE)

                Dim _EnderecoInd As String = row.Cep & " - "

                'busca dados do 
                Dim dsInd As New DataSet()
                Dim xmlInd As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", row.Cep)
                dsInd.ReadXml(xmlInd)
                _EnderecoInd = dsInd.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & dsInd.Tables(0).Rows(0)("logradouro").ToString() & ", " & BuscaBase.First.Numero & "(" & BuscaBase.First.Compl & ")"

                LstEnderecoTrans.Items.Add(_EnderecoInd)
                LstMunicioTrans.Items.Add(dsInd.Tables(0).Rows(0)("bairro").ToString())
                LstUfTrans.Items.Add(dsInd.Tables(0).Rows(0)("uf").ToString())

            Next

        ElseIf CmbTransporteModo.SelectedItem.ToString.StartsWith("3") Then

            'habilita para escolher a transportadora

            CmbTransportadores.Items.Clear()

            CmbTransportadores.Items.Add(FrmPrincipal.RazaoSocial)
            LstDocTrans.Items.Add(FrmPrincipal.CNPJ)
            Ie.Items.Add(FrmPrincipal.IE)

            Dim _EnderecoInd As String = FrmPrincipal.Endereco & " - "

            'busca dados do 
            Dim dsInd As New DataSet()
            Dim xmlInd As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", FrmPrincipal.Endereco)
            dsInd.ReadXml(xmlInd)
            _EnderecoInd = dsInd.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & dsInd.Tables(0).Rows(0)("logradouro").ToString() & ", " & FrmPrincipal.Numero & "(" & FrmPrincipal.Complemento & ")"

            LstEnderecoTrans.Items.Add(_EnderecoInd)
            LstMunicioTrans.Items.Add(dsInd.Tables(0).Rows(0)("bairro").ToString())
            LstUfTrans.Items.Add(dsInd.Tables(0).Rows(0)("uf").ToString())
            CmbTransportadores.SelectedIndex = 0

            CmbTransportadores.Enabled = False

        End If

    End Sub

    Private Sub CmbTransportadores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTransportadores.SelectedIndexChanged

        If CmbTransportadores.Items.Contains(CmbTransportadores.Text) Then

            LblCnpjTranp.Text = LstDocTrans.Items(CmbTransportadores.SelectedIndex).ToString
            LblEnderecoTransp.Text = LstEnderecoTrans.Items(CmbTransportadores.SelectedIndex).ToString
            LblRGIETransp.Text = Ie.Items(CmbTransportadores.SelectedIndex).ToString
            CmbSeguradora.Enabled = True
            CmbSeguradora.SelectedIndex = 0

            TxtPlaca.Enabled = True

        Else

            CmbSeguradora.Text = ""
            CmbSeguradora.Enabled = False

            LblCnpjTranp.Text = ""
            LblEnderecoTransp.Text = ""
            LblRGIETransp.Text = ""

            TxtPlaca.Enabled = False
            TxtPlaca.Text = ""
            LblUF.Text = ""

        End If

    End Sub

    Private Sub CmbSeguradora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSeguradora.SelectedIndexChanged

        If CmbSeguradora.Items.Contains(CmbSeguradora.Text) Then

            If CmbSeguradora.Text <> "Sem seguro" Then
                TxtValorSeguro.Enabled = True
            End If

        Else

            TxtValorSeguro.Enabled = False
            TxtValorSeguro.Text = "R$ 0,00"

        End If

    End Sub

    Dim MarcaVeiculo As String

    Private Sub TxtPlaca_TextChanged(sender As Object, e As EventArgs) Handles TxtPlaca.TextChanged

        'busca a placa do veiculo

        If TxtPlaca.Text.Length = 7 Then

            'busca no rest

            Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_placa_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Placa=" & TxtPlaca.Text

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.DadosVeiculo))("[" & content & "]")

            If read.Count > 0 Then

                LblModeloVeiculo.Text = read.Item(0).Modelo
                LblUF.Text = read.Item(0).Location
                MarcaVeiculo = read.Item(0).CarMake.CurrentTextValue
                Me.Cursor = Cursors.Arrow

            End If

            CmbEspecie.Enabled = True

        Else

            LblUF.Text = ""
            LblModeloVeiculo.Text = ""
            CmbEspecie.Enabled = False
            CmbEspecie.Text = ""

        End If

    End Sub

    Private Sub CmbTransportadores_TextChanged(sender As Object, e As EventArgs) Handles CmbTransportadores.TextChanged

        If CmbTransportadores.Text = "" Then

            CmbSeguradora.Text = ""
            CmbSeguradora.Enabled = False

            LblCnpjTranp.Text = ""
            LblEnderecoTransp.Text = ""
            LblRGIETransp.Text = ""

            TxtPlaca.Enabled = False
            TxtPlaca.Text = ""
            LblUF.Text = ""

        End If

    End Sub

    Private Sub CmbSeguradora_TextChanged(sender As Object, e As EventArgs) Handles CmbSeguradora.TextChanged

        If CmbSeguradora.Text = "" Then

            If CmbSeguradora.Text = "Sem seguro" Then

                TxtValorSeguro.Enabled = False
                TxtValorSeguro.Text = "R$ 0,00"

            End If

        End If

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

    End Sub

    Private Sub DtProdutos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellDoubleClick

        Me.Cursor = Cursors.AppStarting

        FrmAjusteItemNFvb.IdProduto = DtProdutos.SelectedCells(0).Value
        FrmAjusteItemNFvb.TxtNCM.Text = DtProdutos.SelectedCells(2).Value
        FrmAjusteItemNFvb.TxtEAN.Text = DtProdutos.SelectedCells(3).Value

        If FrmAjusteItemNFvb.TxtNCM.Text = "" Then
            FrmAjusteItemNFvb.TxtNCM.Enabled = True
        End If
        If FrmAjusteItemNFvb.TxtEAN.Text = "" Then
            FrmAjusteItemNFvb.TxtEAN.Enabled = True
        End If

        FrmAjusteItemNFvb.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub
End Class