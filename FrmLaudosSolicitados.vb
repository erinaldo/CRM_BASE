Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class FrmLaudosSolicitados
    Private Sub FrmLaudosSolicitados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca laudos possíveis

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim BuscaImagens = From img In LqOficina.ImagemVeiculosColetado
                           Where img.Descricao Like "IMG_REP_CNC - Final"
                           Select img.IdSolicitacao, img.IdVeiculo, img.IdCliente

        Dim PlacaList As New ListBox

        For Each row In BuscaImagens.ToList

            If Not PlacaList.Items.Contains(row.IdVeiculo & "-" & row.IdCliente) Then

                Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                                   Where veic.IdVeiculo = row.IdVeiculo
                                   Select veic.Placa, veic.Modelo

                If BuscaVeiculo.First.Modelo <> "" Then
                    'busca no servidor on line o status 

                    Dim baseUrlSolicitaLaudo As String = "http://www.iarasoftware.com.br/consulta_laudo.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdSolicitacaoInt=" & row.IdCliente

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientSolicitaLaudo = New WebClient()
                    Dim contentSolicitaLaudo = syncClientSolicitaLaudo.DownloadString(baseUrlSolicitaLaudo)
                    Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.LaudosEncontrados))(contentSolicitaLaudo)

                    Dim IdLaudoEnc As Integer = 0
                    Dim Status As String = ""

                    For Each rowLaudo In read.ToList

                        IdLaudoEnc = rowLaudo.IdLaudo
                        Status = rowLaudo.Status

                        If Status = 0 Then
                            DtFornecedores.Rows.Add(BuscaVeiculo.First.Placa.ToUpper, BuscaVeiculo.First.Modelo, row.IdSolicitacao, ImageList2.Images(6), ImageList2.Images(3), ImageList2.Images(5), "", row.IdVeiculo, "Aguardando aceite do analista.")
                        Else
                            DtFornecedores.Rows.Add(BuscaVeiculo.First.Placa.ToUpper, BuscaVeiculo.First.Modelo, row.IdSolicitacao, ImageList2.Images(3), ImageList2.Images(3), ImageList2.Images(5), "", row.IdVeiculo, "Solicitação encerrada. - (Chave do analista: " & rowLaudo.ChavePrestador & ")")
                        End If

                        If DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(8).Value = Nothing Then

                            Dim baseUrlSolR As String = "http://www.iarasoftware.com.br/consulta_solicitacao_review.php?IdItemLaudo=" & IdLaudoEnc & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&ChavePrestador=" & rowLaudo.ChavePrestador
                            Dim syncClientSolR = New WebClient()
                            Dim contentSolR = syncClientSolR.DownloadString(baseUrlSolR)

                            Dim readR = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Review))(contentSolR)

                            Dim IdLaudoEncR As Integer = 0

                            For Each rowIt In readR.ToList

                                Dim DataEncontrada As Date = rowIt.DataSolicitacao & " " & rowIt.HoraSolicitacao
                                Dim DataLimite As Date = Today.Date & " " & "06:00:00"
                                Dim SecPass As Integer = 0

                                If DataEncontrada >= DataLimite Then

                                    While DataEncontrada < Now

                                        SecPass += 1

                                        DataEncontrada = DataEncontrada.AddSeconds(1)

                                        If DataLimite.TimeOfDay.ToString <> "00:00:00" Then

                                            DataLimite = DataLimite.AddSeconds(-1)

                                            DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(8).Value = "Aguardando reenvio de informações"

                                            DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(3).Value = ImageList2.Images(0)
                                            DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(4).Value = ImageList2.Images(4)

                                        Else

                                            'DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(9).Value = ImageList2.Images(8)
                                            'DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(9).Value = "Solicitação expirada"

                                        End If

                                    End While

                                    DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(9).Value = DataLimite.TimeOfDay

                                Else

                                    DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(9).Value = "00:00:00"

                                    DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(3).Value = ImageList2.Images(8)
                                    DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(8).Value = "Solicitação expirada"

                                End If

                            Next

                        End If

                    Next

                    If IdLaudoEnc = 0 Then

                        DtFornecedores.Rows.Add(BuscaVeiculo.First.Placa.ToUpper, BuscaVeiculo.First.Modelo, row.IdSolicitacao, ImageList2.Images(0), ImageList2.Images(4), ImageList2.Images(5), "", row.IdVeiculo)

                    Else

                    End If

                End If

                PlacaList.Items.Add(row.IdVeiculo & "-" & row.IdCliente)

            End If

        Next

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub DtFornecedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellContentClick

        If DtFornecedores.Columns(e.ColumnIndex).Name = "ClmLerLaudo" Then

            Me.Cursor = Cursors.WaitCursor

            'Try

            Dim _IdVeiculo As Integer = DtFornecedores.Rows(e.RowIndex).Cells(7).Value

            If File.Exists("C:\Iara\Despejo\" & DtFornecedores.Rows(e.RowIndex).Cells(2).Value & "_" & DtFornecedores.Rows(e.RowIndex).Cells(0).Value & ".pdf") Then

                File.Delete("C:\Iara\Despejo\" & DtFornecedores.Rows(e.RowIndex).Cells(2).Value & "_" & DtFornecedores.Rows(e.RowIndex).Cells(0).Value & ".pdf")

            End If

            Dim linha As Decimal = 15
            Dim MargemEsq As Decimal = 10

            'verifica se informou valores para as caixas de texto
            'verifica se o arquivo ou pasta de destino existe
            If Not File.Exists("C:\Iara\Despejo\" & DtFornecedores.Rows(e.RowIndex).Cells(2).Value & "_" & DtFornecedores.Rows(e.RowIndex).Cells(0).Value & ".pdf") Then
                'Cria um documento PDF
                Dim pdf As PdfDocument = New PdfDocument
                'definindo informações do autor e palavras chaves
                pdf.Info.Author = "I.A.R.A."
                pdf.Info.Keywords = "PdfSharp, Exemplos, VB .NET"
                'informando a data de criação do documento
                pdf.Info.CreationDate = DateTime.Now
                ' informando o assunto
                pdf.Info.Subject = "Laudo Técnico: " & DtFornecedores.Rows(e.RowIndex).Cells(2).Value & "_" & DtFornecedores.Rows(e.RowIndex).Cells(0).Value
                'cria uma página vazia
                Dim pdfPage As PdfPage = pdf.AddPage
                'Cria um objeto XGraphics
                Dim graph As XGraphics = XGraphics.FromPdfPage(pdfPage)
                ' Desenha linhas cruzadas
                Dim pen As XPen = New XPen(XColor.FromArgb(100, 173, 190, 201), 1)
                Dim penItem As XPen = New XPen(XColor.FromName("SlateGray"), 0.5)

                'linhas do cabeçalho
                Dim Pt0 As Double = pdfPage.Width.Point - 95
                Dim Pt1 As Double = linha - 15
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

                graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                Dim Pt0_MC As Double = 90
                Dim Pt1_MC As Double = 160
                Dim Pt2_MC As Double = pdfPage.Width.Point - (90 * 2)
                Dim Pt3_MC As Double = pdfPage.Height.Point - (Pt1_MC * 2)

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)

                Dim PincelBrancoTransp As New XSolidBrush
                PincelBrancoTransp.Color = XColor.FromArgb(200, XColors.White)

                graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                'graph.DrawRectangle(New Brush(Color.FromArgb(0, 0, 0, 0), New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                'graph.DrawLine(pen, New XPoint(pdfPage.Width.Point, 0), New XPoint(0, pdfPage.Height.Point))
                'Desenha uma elipse
                'graph.DrawEllipse(pen, 3 * pdfPage.Width.Point / 10, 3 * pdfPage.Height.Point / 10, 2 * pdfPage.Width.Point / 5, 2 * pdfPage.Height.Point / 5)
                'Cria um objeto Font a partir de XFont
                Dim font As XFont = New XFont("Verdana", 8.25, XFontStyle.Regular)
                Dim fontItem As XFont = New XFont("Verdana", 6.25, XFontStyle.Regular)

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim LqOficina As New LqOficinaDataContext
                LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                Dim IdVeiculoFind As Integer = DtFornecedores.SelectedCells(7).Value

                Dim Buscaveiculo = From veic In LqOficina.Veiculos
                                   Where veic.IdVeiculo = IdVeiculoFind
                                   Select veic.IdCliente

                Dim BuscaCliente = From veic In LqBase.Clientes
                                   Where veic.IdClienteExt = Buscaveiculo.First
                                   Select veic.RazaoSocial_nome

                'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                graph.DrawString("Cliente.: " & BuscaCliente.First, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)
                graph.DrawString("Solicitação.: " & DtFornecedores.SelectedCells(2).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point - 100, pdfPage.Height.Point), XStringFormats.TopRight)

                linha += 15

                graph.DrawString("Placa do veículo.: " & DtFornecedores.SelectedCells(0).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Modelo do veículo.: " & DtFornecedores.SelectedCells(1).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                linha += 20

                Dim FimCabec As Double = linha

                linha += 20

                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                linha += 15

                'graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)
                graph.DrawString("Análise técnica", fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                'insere imagem conforme a categoria frontal

                linha += 25

                Dim imgCat01 As Image = My.Resources.VFrenteVetor
                Dim strmCat01 As MemoryStream = New MemoryStream()
                imgCat01.Save(strmCat01, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat01 As XImage = XImage.FromStream(strmCat01)

                Dim Pt0_Cat01 As Double = MargemEsq + 50
                Dim Pt1_Cat01 As Double = linha
                Dim Pt2_Cat01 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 120
                Dim Pt3_Cat01 As Double = 130

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                Dim PincelTitPrinc As New XSolidBrush
                PincelTitPrinc.Color = XColor.FromArgb(100, 138, 157, 181)

                graph.DrawRectangle(PincelTitPrinc, New XRect(MargemEsq - 5, linha - 5, ((pdfPage.Width.Point) - (MargemEsq)), 150))
                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat01, Pt0_Cat01 + 10, Pt1_Cat01 + 10, Pt2_Cat01 - 10, Pt3_Cat01 - 10)

                'busca a imagem frontal para o veiculo

                Dim BuscaImagemFrontalVeiculo = From veic In LqOficina.ImagemVeiculosColetado
                                                Where veic.Descricao Like "Frontal - Principal" And veic.IdVeiculo = _IdVeiculo
                                                Select veic.ImagemColetado, veic.IdVeiculo, veic.IdSolicitacao

                If BuscaImagemFrontalVeiculo.Count > 0 Then
                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = BuscaImagemFrontalVeiculo.First.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = Pt0_Cat01 + 10
                    Dim Pt1_Frontal As Double = Pt1_Cat01 - 10
                    Dim Pt2_Frontal As Double = 160
                    Dim Pt3_Frontal As Double = 160

                    graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_Frontal - 2, Pt1_Frontal - 2, Pt2_Frontal, Pt3_Frontal))
                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)

                End If

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15

                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim TotalSolucao As Integer = 0
                Dim TotalSolucaoComl As Integer = 0
                Dim Limite_pagina As Double = pdfPage.Height.Point - 40
                Dim PincelTitulo As New XSolidBrush

                If BuscaImagemFrontalVeiculo.Count > 0 Then

                    Dim buscaSolucao = From sol In LqOficina.ImagemVeiculosColetado
                                       Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Frontal - Avaliacao"
                                       Select sol.ImagemColetado, sol.IdImagemColetada, sol.idImagemColetadaExt

                    TotalSolucao = buscaSolucao.Count

                    Dim buscaSolucaoComplementar = From sol In LqOficina.ImagemVeiculosColetado
                                                   Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Frontal - Complementar"
                                                   Select sol.ImagemColetado, sol.IdImagemColetada, sol.idImagemColetadaExt

                    TotalSolucaoComl = buscaSolucaoComplementar.Count

                    graph.DrawString("Danos identificados.: " & buscaSolucao.Count + buscaSolucaoComplementar.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                    If buscaSolucao.Count > 0 Then

                        linha += 105

                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, 30))

                    End If

                    Dim TitPInt As Boolean = False

                    Dim Count_Frente As Integer = -1

                    For Each row In buscaSolucao.ToList

                        Count_Frente += 1

                        PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                        If linha + 105 >= Limite_pagina Then

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                            graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                            graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                            linha = pdfPage.Height.Point - 30

                            graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                            graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                            linha = 15

                            'pdf.AddPage()

                            pdfPage = pdf.AddPage()

                            graph = XGraphics.FromPdfPage(pdfPage)

                            graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                            graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                            'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                            'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                            graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                            graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                            'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )

                            'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                            graph.DrawString("Cliente.: " & BuscaCliente.First, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)
                            graph.DrawString("Solicitação.: " & DtFornecedores.SelectedCells(2).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point - 100, pdfPage.Height.Point), XStringFormats.TopRight)

                            linha += 15

                            graph.DrawString("Placa do veículo.: " & DtFornecedores.SelectedCells(0).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 15

                            graph.DrawString("Modelo do veículo.: " & DtFornecedores.SelectedCells(1).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 20

                            graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                            linha += 15

                            graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                            graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                            graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                            linha += 75

                        End If

                        If TitPInt = False Then

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                            TitPInt = True
                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                            graph.DrawString("Avaliação inicial", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                            graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                            graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                        Else

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                            graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                            graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                        End If

                        graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                        'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                        graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                        Dim arrImage() As Byte
                        Dim myMS As New System.IO.MemoryStream
                        arrImage = row.ImagemColetado.ToArray

                        For Each ar As Byte In arrImage
                            myMS.WriteByte(ar)
                        Next

                        Dim imgFrontal As Image = Image.FromStream(myMS)
                        Dim strmFrontal As MemoryStream = New MemoryStream()
                        imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                        Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                        Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                        Dim Pt1_Frontal As Double = linha
                        Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                        Dim Pt3_Frontal As Double = 100

                        graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                        graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                        linha += 15

                        graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                        linha += 35

                        Dim BuscaImagensSol = From sol In LqOficina.ImagemVeiculosColetado
                                              Where sol.Descricao Like "IMG_FT_PECA_NOVA - " & row.idImagemColetadaExt
                                              Select sol.ImagemColetado, sol.ImagemColetadoUrlFim

                        'graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Peças avariadas.: " & BuscaImagensSol.Count, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                        linha += 75

                        'If linha >= Limite_pagina Then

                        If linha + 105 >= Limite_pagina And Count_Frente < buscaSolucao.Count - 1 Then

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                            graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                            graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                            linha = pdfPage.Height.Point - 30

                            graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                            graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                            linha = 15

                            'pdf.AddPage()

                            pdfPage = pdf.AddPage()

                            graph = XGraphics.FromPdfPage(pdfPage)

                            graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                            graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                            'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                            'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                            graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                            graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                            'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                            graph.DrawString("Cliente.: " & BuscaCliente.First, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)
                            graph.DrawString("Solicitação.: " & DtFornecedores.SelectedCells(2).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point - 100, pdfPage.Height.Point), XStringFormats.TopRight)

                            linha += 15

                            graph.DrawString("Placa do veículo.: " & DtFornecedores.SelectedCells(0).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 15

                            graph.DrawString("Modelo do veículo.: " & DtFornecedores.SelectedCells(1).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 20

                            graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                            linha += 15

                            graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                            graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                            graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                            linha += 75

                        End If

                        'busca resolucoes 

                        Dim Count_Imagem As Integer = -1

                        MargemEsq += 34

                        Dim TitPIntImg As Boolean = False

                        For Each rowImg In BuscaImagensSol.ToList

                            Count_Imagem += 1

                            PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                            If linha + 105 >= Limite_pagina Then

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 40, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 30, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 20, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 10, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 3, 1, 3))

                                graph.DrawLine(pen, MargemEsq - 4 - 34, linha - 10, (MargemEsq + 0.5) - 34, linha)

                                graph.DrawLine(pen, MargemEsq + 5 - 34, linha - 10, (MargemEsq + 0.5) - 34, linha)


                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                                graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                                graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                                linha = pdfPage.Height.Point - 30

                                graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                                linha = 15

                                'pdf.AddPage()

                                pdfPage = pdf.AddPage()

                                graph = XGraphics.FromPdfPage(pdfPage)

                                graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                                graph.DrawRectangle(Pincel, New XRect(MargemEsq - 34, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq - 34), 60))

                                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                                graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                                graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                                'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                                graph.DrawString("Cliente.: " & BuscaCliente.First, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)
                                graph.DrawString("Solicitação.: " & DtFornecedores.SelectedCells(2).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point - 100, pdfPage.Height.Point), XStringFormats.TopRight)

                                linha += 15

                                graph.DrawString("Placa do veículo.: " & DtFornecedores.SelectedCells(0).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                                linha += 15

                                graph.DrawString("Modelo do veículo.: " & DtFornecedores.SelectedCells(1).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                                linha += 20

                                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                                linha += 15

                                graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)


                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 3, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha + 10, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha + 20, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha + 30, 1, 3))

                                graph.DrawLine(pen, MargemEsq - 4 - 34, linha, (MargemEsq + 0.5) - 34, linha - 10)

                                graph.DrawLine(pen, MargemEsq + 5 - 34, linha, (MargemEsq + 0.5) - 34, linha - 10)


                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                                graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                                graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                                linha += 75

                            End If

                            'busca descricao do item para a solucao

                            If TitPIntImg = False Then

                                If Count_Frente = 0 Then

                                    linha += 15

                                End If

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                                TitPIntImg = True
                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                                graph.DrawString("Peças em substituição", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                                graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                                graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))


                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 45, 1, 156))


                            Else

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                                graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                                graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))


                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 40, 1, 156))

                            End If

                            graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))

                            'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))

                            Dim arrImageAvaria() As Byte
                            Dim myMSAvaria As New System.IO.MemoryStream
                            arrImageAvaria = rowImg.ImagemColetado.ToArray

                            For Each ar As Byte In arrImageAvaria
                                myMSAvaria.WriteByte(ar)
                            Next

                            Dim imgAvaria As Image = Image.FromStream(myMSAvaria)
                            Dim strmAvaria As MemoryStream = New MemoryStream()
                            imgAvaria.Save(strmAvaria, System.Drawing.Imaging.ImageFormat.Png)
                            Dim xfotoAvaria As XImage = XImage.FromStream(strmAvaria)

                            Dim Pt0_Avaria As Double = MargemEsq + 64
                            Dim Pt1_Avaria As Double = linha + 20
                            Dim Pt2_Avaria As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 130
                            Dim Pt3_Avaria As Double = 90

                            graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_Avaria - 5, Pt1_Avaria - 5, Pt2_Avaria + 5, Pt3_Avaria + 5))

                            graph.DrawImage(xfotoAvaria, Pt0_Avaria, Pt1_Avaria, Pt2_Avaria, Pt3_Avaria)


                            Dim BuscaImagensSolUs = From sol In LqOficina.ImagemVeiculosColetado
                                                    Where sol.Descricao Like "IMG_FT_PECA_USADA - " & row.idImagemColetadaExt
                                                    Select sol.ImagemColetado, sol.ImagemColetadoUrlFim, sol.ImagemColetadoUrl, sol.IdSolicitacao

                            'busca a referecia no orcamento

                            Dim LqComercial As New LqComercialDataContext
                            LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

                            Dim BuscaComercial = From com In LqComercial.ProdutosOrcamento
                                                 Where com.IdImagemAval = row.idImagemColetadaExt And com.Tipo = True
                                                 Select com.IdProduto, com.IdSolicitacao

                            'busca o produto

                            Dim BuscaIdProduto = From prod In LqBase.Produtos
                                                 Where prod.IdProduto = BuscaComercial.First.IdProduto
                                                 Select prod.Descricao

                            Dim _Descricao As String

                            If BuscaIdProduto.Count = 0 Then

                                'busca Solicitacaocadastro

                                Dim BuscaSol = From sol In LqOficina.SolicitacaoCadastroPeca
                                               Where sol.IdSolicitacaoCadastro = BuscaComercial.First.IdSolicitacao
                                               Select sol.Descricao

                                _Descricao = BuscaSol.First

                            Else
                                _Descricao = BuscaIdProduto.First

                            End If

                            graph.DrawRectangle(PincelItemFoto, New XRect(MargemEsq + 30, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 30) * 2) - -5), 20))

                            graph.DrawString(_Descricao, fontItem, XBrushes.WhiteSmoke, New XRect(MargemEsq + 39, linha - 2, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131), XStringFormats.TopCenter)

                            Dim arrImageAvariaU() As Byte
                            Dim myMSAvariaU As New System.IO.MemoryStream
                            arrImageAvariaU = BuscaImagensSolUs.First.ImagemColetado.ToArray

                            For Each ar As Byte In arrImageAvariaU
                                myMSAvariaU.WriteByte(ar)
                            Next

                            Dim imgAvariaU As Image = Image.FromStream(myMSAvariaU)
                            Dim strmAvariaU As MemoryStream = New MemoryStream()
                            imgAvariaU.Save(strmAvariaU, System.Drawing.Imaging.ImageFormat.Png)
                            Dim xfotoAvariaU As XImage = XImage.FromStream(strmAvariaU)

                            Dim Pt0_AvariaU As Double = MargemEsq + 44 + ((((((pdfPage.Width.Point - 15))) / 2) - 2) - 120) + 64
                            Dim Pt1_AvariaU As Double = linha + 20
                            Dim Pt2_AvariaU As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 130
                            Dim Pt3_AvariaU As Double = 90

                            graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_AvariaU - 5, Pt1_AvariaU - 5, Pt2_AvariaU + 5, Pt3_AvariaU + 5))

                            graph.DrawImage(xfotoAvariaU, Pt0_AvariaU, Pt1_AvariaU, Pt2_AvariaU, Pt3_AvariaU)


                            linha += 15

                            'graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                            linha += 35

                            'graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                            linha += 15

                            'graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                            linha += 15

                            'graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                            linha += 75

                            'If linha >= Limite_pagina Then

                            If linha + 105 >= Limite_pagina And Count_Imagem < BuscaImagensSol.Count - 1 Then


                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 40, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 30, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 20, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 10, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 3, 1, 3))

                                graph.DrawLine(pen, MargemEsq - 4 - 34, linha - 10, (MargemEsq + 0.5) - 34, linha)

                                graph.DrawLine(pen, (MargemEsq - 34) + 5, linha - 10, (MargemEsq + 0.5) - 34, linha)


                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                                graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                                graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                                linha = pdfPage.Height.Point - 30

                                graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                                linha = 15

                                'pdf.AddPage()

                                pdfPage = pdf.AddPage()

                                graph = XGraphics.FromPdfPage(pdfPage)

                                graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                                graph.DrawRectangle(Pincel, New XRect(MargemEsq - 34, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq - 34), 60))

                                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                                graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                                graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                                'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                                graph.DrawString("Cliente.: " & BuscaCliente.First, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)
                                graph.DrawString("Solicitação.: " & DtFornecedores.SelectedCells(2).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point - 100, pdfPage.Height.Point), XStringFormats.TopRight)

                                linha += 15

                                graph.DrawString("Placa do veículo.: " & DtFornecedores.SelectedCells(0).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                                linha += 15

                                graph.DrawString("Modelo do veículo.: " & DtFornecedores.SelectedCells(1).Value, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                                linha += 20

                                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                                linha += 15

                                graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)


                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha - 3, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha + 10, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha + 20, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq - 34, linha + 30, 1, 3))

                                graph.DrawLine(pen, MargemEsq - 4 - 34, linha, (MargemEsq + 0.5) - 34, linha - 10)

                                graph.DrawLine(pen, MargemEsq + 5 - 34, linha, (MargemEsq + 0.5) - 34, linha - 10)


                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                                graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                                graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                                graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                                linha += 75

                            End If

                        Next
                        MargemEsq -= 34

                    Next

                    If TotalSolucaoComl > 0 Then

                        linha += 105

                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                    End If

                    For Each row In buscaSolucaoComplementar.ToList

                        PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                        If TitPInt = False Then

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                            TitPInt = True
                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                            graph.DrawString("Avaliação inicial", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                            graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                            graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                        Else

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                            graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                            graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                        End If

                        graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                        'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                        graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                        Dim arrImage() As Byte
                        Dim myMS As New System.IO.MemoryStream
                        arrImage = row.ImagemColetado.ToArray

                        For Each ar As Byte In arrImage
                            myMS.WriteByte(ar)
                        Next

                        Dim imgFrontal As Image = Image.FromStream(myMS)
                        Dim strmFrontal As MemoryStream = New MemoryStream()
                        imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                        Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                        Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                        Dim Pt1_Frontal As Double = linha
                        Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                        Dim Pt3_Frontal As Double = 100

                        graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                        graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                        linha += 15

                        graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                        linha += 35

                        graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                        linha += 75

                        'If linha >= Limite_pagina Then

                        If linha >= Limite_pagina Then


                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                            graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                            graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                            linha = pdfPage.Height.Point - 30

                            graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                            graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                            linha = 15

                            'pdf.AddPage()

                            pdfPage = pdf.AddPage()

                            graph = XGraphics.FromPdfPage(pdfPage)

                            graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                            graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                            'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                            'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                            graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                            graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                            'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                            'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 15

                            'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 15

                            'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 20

                            graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                            linha += 15

                            graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                            graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                            graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                            graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                            linha += 75

                        End If

                    Next

                    If buscaSolucao.Count = 0 And buscaSolucaoComplementar.Count = 0 Then

                        linha += 75
                        'desenha final

                        If linha + 105 >= Limite_pagina Then

                            linha = pdfPage.Height.Point - 30

                            graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                            graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                            linha = 15

                            'pdf.AddPage()

                            pdfPage = pdf.AddPage()

                            graph = XGraphics.FromPdfPage(pdfPage)

                            graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                            graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                            'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                            'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                            graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                            graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                            'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                            'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 15

                            'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 15

                            'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 20

                            graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                            linha += 15

                            graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                            linha += 65

                        Else

                            linha += 30

                        End If

                    End If

                Else

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                End If

                If linha + 105 >= Limite_pagina Then

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                    graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                    graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                    linha = pdfPage.Height.Point - 30

                    graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                    graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                    linha = 15

                    'pdf.AddPage()

                    pdfPage = pdf.AddPage()

                    graph = XGraphics.FromPdfPage(pdfPage)

                    graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                    'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                    'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                    graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                    graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                    'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                    'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                    linha += 15

                    'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                    linha += 15

                    'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                    linha += 20

                    graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                    linha += 15

                    graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                    graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                    graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                    graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                    linha += 75

                End If

                'procura solucoes asociadas a esta imagem

                Dim imgCat02 As Image = My.Resources.VtrasVetor
                Dim strmCat02 As MemoryStream = New MemoryStream()
                imgCat02.Save(strmCat02, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat02 As XImage = XImage.FromStream(strmCat02)

                Dim Pt0_Cat02 As Double = MargemEsq + 50
                Dim Pt1_Cat02 As Double = linha
                Dim Pt2_Cat02 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 120
                Dim Pt3_Cat02 As Double = 130

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                graph.DrawRectangle(PincelTitPrinc, New XRect(MargemEsq - 5, linha - 5, ((pdfPage.Width.Point) - (MargemEsq)), 150))

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))

                graph.DrawImage(xfotoCat02, Pt0_Cat02 + 10, Pt1_Cat02 + 10, Pt2_Cat02 - 10, Pt3_Cat02 - 10)

                Dim BuscaImagemTraseiraVeiculo = From veic In LqOficina.ImagemVeiculosColetado
                                                 Where veic.Descricao Like "Traseira - Principal" And veic.IdVeiculo = _IdVeiculo
                                                 Select veic.ImagemColetado, veic.IdVeiculo

                If BuscaImagemTraseiraVeiculo.Count > 0 Then
                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = BuscaImagemTraseiraVeiculo.First.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = Pt0_Cat02 + 10
                    Dim Pt1_Frontal As Double = Pt1_Cat02 - 10
                    Dim Pt2_Frontal As Double = 160
                    Dim Pt3_Frontal As Double = 160

                    graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_Frontal - 2, Pt1_Frontal - 2, Pt2_Frontal, Pt3_Frontal))
                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)

                End If

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoTras = From sol In LqOficina.ImagemVeiculosColetado
                                       Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Traseira - Avaliacao"
                                       Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarTras = From sol In LqOficina.ImagemVeiculosColetado
                                                   Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Traseira - Complementar"
                                                   Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoTras.Count + buscaSolucaoComplementarTras.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                If buscaSolucaoTras.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, 30))

                End If

                Dim TitPIntTras As Boolean = False

                TotalSolucaoComl = 0

                For Each row In buscaSolucaoTras.ToList

                    PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                    If TitPIntTras = False Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                        TitPIntTras = True
                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                        graph.DrawString("Avaliação inicial", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                    Else

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                        'linha anterior

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                    End If

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then


                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                Next

                If TotalSolucaoComl > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoComplementarTras.ToList

                    PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                    If TitPIntTras = False Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                        TitPIntTras = True
                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                        graph.DrawString("Avaliação inicial", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                    Else

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                    End If

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then


                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                Next

                If buscaSolucaoTras.Count = 0 And buscaSolucaoComplementarTras.Count = 0 Then

                    linha += 65

                    If linha + 105 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 65

                    Else

                        linha += 30

                    End If

                End If

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                Dim imgCat03 As Image = My.Resources.VLateEsq
                Dim strmCat03 As MemoryStream = New MemoryStream()
                imgCat03.Save(strmCat03, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat03 As XImage = XImage.FromStream(strmCat03)

                Dim Pt0_Cat03 As Double = MargemEsq + 10
                Dim Pt1_Cat03 As Double = linha + 20
                Dim Pt2_Cat03 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 20
                Dim Pt3_Cat03 As Double = 100

                graph.DrawRectangle(PincelTitPrinc, New XRect(MargemEsq - 5, linha - 5, ((pdfPage.Width.Point) - (MargemEsq)), 150))

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat03, Pt0_Cat03, Pt1_Cat03, Pt2_Cat03, Pt3_Cat03)

                Dim BuscaImagemLatEsqVeiculo = From veic In LqOficina.ImagemVeiculosColetado
                                               Where veic.Descricao Like "Lateral esquerda - Principal" And veic.IdVeiculo = _IdVeiculo
                                               Select veic.ImagemColetado, veic.IdVeiculo

                If BuscaImagemLatEsqVeiculo.Count > 0 Then

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = BuscaImagemLatEsqVeiculo.First.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = Pt0_Cat03 - 10
                    Dim Pt1_Frontal As Double = Pt1_Cat03 - 20
                    Dim Pt2_Frontal As Double = 290
                    Dim Pt3_Frontal As Double = 140

                    graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_Frontal - 2, Pt1_Frontal - 2, Pt2_Frontal, Pt3_Frontal))
                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)

                End If

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoLatEsq = From sol In LqOficina.ImagemVeiculosColetado
                                         Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Lateral esquerda - Avaliacao"
                                         Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarLatEsq = From sol In LqOficina.ImagemVeiculosColetado
                                                     Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Lateral esquerda - Complementar"
                                                     Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoLatEsq.Count + buscaSolucaoComplementarLatEsq.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                If buscaSolucaoLatEsq.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                Dim TitPIntLatEsq As Boolean = False

                TotalSolucaoComl = 0

                For Each row In buscaSolucaoLatEsq.ToList

                    PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                    If TitPIntLatEsq = False Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                        TitPIntLatEsq = True
                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                        graph.DrawString("Avaliação inicial", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                    Else

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                    End If

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then


                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                Next

                If buscaSolucaoComplementarLatEsq.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                TitPIntLatEsq = False

                For Each row In buscaSolucaoComplementarLatEsq.ToList

                    PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                    If TitPIntLatEsq = False Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                        TitPIntLatEsq = True
                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                        graph.DrawString("Avaliação complementar", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                    Else

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                    End If

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then


                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                Next

                If buscaSolucaoLatEsq.Count = 0 And buscaSolucaoComplementarLatEsq.Count = 0 Then

                    linha += 65

                    If linha + 105 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 65

                    Else

                        linha += 30

                    End If

                End If


                Dim imgCat04 As Image = My.Resources.VLatDir
                Dim strmCat04 As MemoryStream = New MemoryStream()
                imgCat04.Save(strmCat04, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat04 As XImage = XImage.FromStream(strmCat04)

                Dim Pt0_Cat04 As Double = MargemEsq + 10
                Dim Pt1_Cat04 As Double = linha + 20
                Dim Pt2_Cat04 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 20
                Dim Pt3_Cat04 As Double = 100

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                graph.DrawRectangle(PincelTitPrinc, New XRect(MargemEsq - 5, linha - 5, ((pdfPage.Width.Point) - (MargemEsq)), 150))

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat04, Pt0_Cat04, Pt1_Cat04, Pt2_Cat04, Pt3_Cat04)

                Dim BuscaImagemLatDirVeiculo = From veic In LqOficina.ImagemVeiculosColetado
                                               Where veic.Descricao Like "Lateral direita - Principal" And veic.IdVeiculo = _IdVeiculo
                                               Select veic.ImagemColetado, veic.IdVeiculo

                If BuscaImagemLatDirVeiculo.Count > 0 Then
                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = BuscaImagemLatDirVeiculo.First.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = Pt0_Cat04 - 10
                    Dim Pt1_Frontal As Double = Pt1_Cat04 - 20
                    Dim Pt2_Frontal As Double = 290
                    Dim Pt3_Frontal As Double = 140

                    graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_Frontal - 2, Pt1_Frontal - 2, Pt2_Frontal, Pt3_Frontal))
                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)

                End If

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoLatDir = From sol In LqOficina.ImagemVeiculosColetado
                                         Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Lateral direita - Avaliacao"
                                         Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarLatDir = From sol In LqOficina.ImagemVeiculosColetado
                                                     Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Lateral direita - Complementar"
                                                     Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoLatDir.Count + buscaSolucaoComplementarLatDir.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                If buscaSolucaoLatDir.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                Dim TitPIntLatDir As Boolean = False

                TotalSolucaoComl = 0

                Dim Count_LatDIr As Integer = -1

                For Each row In buscaSolucaoLatDir.ToList

                    Count_LatDIr += 1

                    PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                    If TitPIntLatDir = False Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                        TitPIntLatDir = True
                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                        graph.DrawString("Avaliação inicial", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                    Else

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                    End If

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina And Count_LatDIr < buscaSolucaoLatDir.Count - 1 Then


                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                Next

                If buscaSolucaoComplementarLatDir.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                TitPIntLatDir = False

                For Each row In buscaSolucaoComplementarLatDir.ToList

                    PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                    If TitPIntLatDir = False Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                        TitPIntTras = True
                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                        graph.DrawString("Avaliação complementar", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                    Else

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                    End If

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then


                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                Next

                If buscaSolucaoLatDir.Count = 0 And buscaSolucaoComplementarLatDir.Count = 0 Then

                    linha += 65

                    If linha + 105 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    Else

                        linha += 30

                    End If

                End If


                Dim imgCat05 As Image = My.Resources.VAcessorios
                Dim strmCat05 As MemoryStream = New MemoryStream()
                imgCat05.Save(strmCat05, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat05 As XImage = XImage.FromStream(strmCat05)

                Dim Pt0_Cat05 As Double = MargemEsq + 10
                Dim Pt1_Cat05 As Double = linha + 5
                Dim Pt2_Cat05 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 20
                Dim Pt3_Cat05 As Double = 120

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                graph.DrawRectangle(PincelTitPrinc, New XRect(MargemEsq - 5, linha - 5, ((pdfPage.Width.Point) - (MargemEsq)), 150))

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat05, Pt0_Cat05, Pt1_Cat05, Pt2_Cat05, Pt3_Cat05)

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoMecanicas = From sol In LqOficina.ImagemVeiculosColetado
                                            Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Funcionamento - Avaliacao"
                                            Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarMecanica = From sol In LqOficina.ImagemVeiculosColetado
                                                       Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Funcionamento - Complementar"
                                                       Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoMecanicas.Count + buscaSolucaoComplementarMecanica.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                If buscaSolucaoMecanicas.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                Dim TitPIntMecanica As Boolean = False

                TotalSolucaoComl = 0

                Dim Count_Mecanica As Integer = -1

                For Each row In buscaSolucaoMecanicas.ToList

                    Count_Mecanica += 1

                    PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                    If TitPIntMecanica = False Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                        TitPIntMecanica = True
                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                        graph.DrawString("Avaliação inicial", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                    Else

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                    End If

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))

                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina And Count_Mecanica < buscaSolucaoMecanicas.Count - 1 Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                Next

                If buscaSolucaoComplementarMecanica.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                TitPIntMecanica = False

                If buscaSolucaoMecanicas.Count = 0 And buscaSolucaoComplementarMecanica.Count = 0 Then

                    linha += 65

                    If linha + 105 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    Else

                        linha += 30

                    End If

                End If


                Dim imgCat06 As Image = My.Resources.VInteriorVetor1
                Dim strmCat06 As MemoryStream = New MemoryStream()
                imgCat06.Save(strmCat06, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat06 As XImage = XImage.FromStream(strmCat06)

                Dim Pt0_Cat06 As Double = MargemEsq + 10
                Dim Pt1_Cat06 As Double = linha + 5
                Dim Pt2_Cat06 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 20
                Dim Pt3_Cat06 As Double = 120

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                graph.DrawRectangle(PincelTitPrinc, New XRect(MargemEsq - 5, linha - 5, ((pdfPage.Width.Point) - (MargemEsq)), 150))

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat06, Pt0_Cat06, Pt1_Cat06, Pt2_Cat06, Pt3_Cat06)

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoInterior = From sol In LqOficina.ImagemVeiculosColetado
                                           Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Interior - Avaliacao"
                                           Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarInterior = From sol In LqOficina.ImagemVeiculosColetado
                                                       Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Interior - Complementar"
                                                       Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoInterior.Count + buscaSolucaoComplementarInterior.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                If buscaSolucaoInterior.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                Dim TitPIntInterior As Boolean = False

                TotalSolucaoComl = 0

                Dim Count_Interior As Integer = -1

                For Each row In buscaSolucaoInterior.ToList

                    Count_Interior += 1

                    PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                    If TitPIntInterior = False Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                        TitPIntInterior = True
                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                        graph.DrawString("Avaliação inicial", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                    Else

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                    End If

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina And Count_Interior < buscaSolucaoInterior.Count - 1 Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                Next

                If buscaSolucaoComplementarInterior.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                TitPIntInterior = False

                For Each row In buscaSolucaoComplementarInterior.ToList

                    PincelTitulo.Color = XColor.FromArgb(100, 138, 157, 181)

                    If TitPIntInterior = False Then

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 10))

                        TitPIntTras = True
                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 156))
                        graph.DrawString("Avaliação complementar", fontItem, XBrushes.Black, New XRect(MargemEsq + 39, linha - 30, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 20), XStringFormats.Center)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 125, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 120, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 120, 10, 10))

                    Else

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq + 34, linha - 20, (pdfPage.Width.Point) - (((MargemEsq + 34) * 2) - -5), 136))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 156))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 115, MargemEsq + 25, 1))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq + 30, linha + 110, 10, 10))

                        graph.DrawEllipse(PincelTitulo, New XRect(MargemEsq - 4, linha + 110, 10, 10))

                    End If

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))


                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 65

                    'If linha >= Limite_pagina Then

                    If linha + 105 >= Limite_pagina Then


                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 40, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 30, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha - 10, MargemEsq + 0.5, linha)

                        graph.DrawLine(pen, MargemEsq + 5, linha - 10, MargemEsq + 0.5, linha)


                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter)

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha - 3, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 10, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 20, 1, 3))

                        graph.DrawRectangle(PincelTitulo, New XRect(MargemEsq, linha + 30, 1, 3))

                        graph.DrawLine(pen, MargemEsq - 4, linha, MargemEsq + 0.5, linha - 10)

                        graph.DrawLine(pen, MargemEsq + 5, linha, MargemEsq + 0.5, linha - 10)

                        linha += 65

                    End If

                Next

                If buscaSolucaoInterior.Count = 0 And buscaSolucaoComplementarInterior.Count = 0 Then

                    linha += 65

                    If linha + 105 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        'graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        'graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    Else

                        linha += 30

                    End If

                End If


                'VARRE TODOS OS ENCONTRADOS

                'Finaliza

                linha = pdfPage.Height.Point - 30

                graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                'Salva o documento PDF

                pdf.Save("C:\Iara\Despejo\" & DtFornecedores.Rows(e.RowIndex).Cells(2).Value & "_" & DtFornecedores.Rows(e.RowIndex).Cells(0).Value & ".pdf")

                'MessageBox.Show("Arquivo   " + "C:\Iara\Despejo\" & LblNumOrcamento.Text & "_" & LblVersão.Text & ".pdf" + "   gerado com sucesso.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'abre o arquivo PDF e exibe 

                Process.Start("C:\Iara\Despejo\" & DtFornecedores.Rows(e.RowIndex).Cells(2).Value & "_" & DtFornecedores.Rows(e.RowIndex).Cells(0).Value & ".pdf")

            Else
                MessageBox.Show("O arquivo/diretório de destino não existe...", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.Cursor = Cursors.Arrow

            'Catch ex As Exception
            '    'captura erros
            '    MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try

        ElseIf DtFornecedores.Columns(e.ColumnIndex).Name = "ClmSolicitar" Then

            Me.Cursor = Cursors.WaitCursor

            FrmSolicitarLaudo.IdSolicitacao = DtFornecedores.SelectedCells(2).Value

            FrmSolicitarLaudo.Show(Me)

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        For Each row As DataGridViewRow In DtFornecedores.Rows

            If row.Cells(8).Value <> Nothing Then

                Dim VlrStatus As String = row.Cells(8).Value

                If Not VlrStatus.StartsWith("Solicitação encerrada.") Then

                    If Not VlrStatus.StartsWith("Aguardando aceite do analista.") Then

                        Dim _Chave As Date = FormatDateTime(Today.Date.ToString, vbShortDate) & " " & row.Cells(9).Value.ToString

                        If _Chave.TimeOfDay.ToString <> "00:00:00" Then

                            _Chave = _Chave.AddSeconds(-1)

                            row.Cells(9).Value = _Chave.TimeOfDay.ToString

                        End If

                    End If

                End If

            End If

        Next

    End Sub
End Class