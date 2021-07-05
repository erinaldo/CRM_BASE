Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports Newtonsoft.Json

Public Class FrmItemLaudo
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Public IdLaudo As Integer

    Private Sub FrmItemLaudo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim BuscaIdLaudoExt = From ofi In LqOficina.LaudosTecnicos
                              Where ofi.IdLaudoExt = IdLaudo And ofi.Status = 0
                              Select ofi.IdLaudoTecnico, ofi.PlacaVeiculo, ofi.ModeloVeiculo, ofi.NomeCompleto, ofi.ChaveOficina

        LblNomeCliente.Text = BuscaIdLaudoExt.First.NomeCompleto & " (" & BuscaIdLaudoExt.First.PlacaVeiculo.ToUpper & " - " & BuscaIdLaudoExt.First.ModeloVeiculo & ")"
        LblChaveCliente.Text = BuscaIdLaudoExt.First.ChaveOficina

        LblIdLaudo.Text = IdLaudo

        Dim Parar As Boolean = False

        For Each row In BuscaIdLaudoExt.ToList

            If Parar = False Then

                Dim BuscaOficina = From ofi In LqOficina.ItemLaudosTecnicos
                                   Where ofi.IdLaudoTecnico = IdLaudo
                                   Select ofi.ImgPcNovaUrl, ofi.ImgPcUsadaUrl, ofi.Status, ofi.IdItemLaudoTecnico, ofi.DescricaoItem, ofi.NumNf, ofi.NumItemNF, ofi.IdItemExt, ofi.idfornecedor
                                   Order By IdItemLaudoTecnico Descending

                If BuscaOficina.Count > 0 Then

                    If BuscaOficina.First.Status = 0 Then

                        Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcNovaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagem = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                        Dim img As Image = Image.FromStream(stream)

                        PicImagemNova.BackgroundImage = img


                        Dim baseUrlImagemUs As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcUsadaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagemUs = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim streamUs As Stream = syncClientImagemUs.OpenRead(baseUrlImagemUs)

                        Dim imgUs As Image = Image.FromStream(streamUs)

                        PicImagemUsada.BackgroundImage = imgUs

                        LblDescricaoDoItem.Text = BuscaOficina.First.DescricaoItem

                        Parar = True

                        LblNumNF.Text = BuscaOficina.First.NumNf
                        LblItemNf.Text = BuscaOficina.First.NumItemNF
                        LblIdItemLaudo.Text = BuscaOficina.First.IdItemExt
                        LblCodFornecedor.Text = BuscaOficina.First.idfornecedor

                        If LblNumNF.Text = 0 Then

                            BttNf.Enabled = False
                            BtnProximoItem.Enabled = False
                            LblItemNf.Text = ""
                            BtnSolicitarRevisao.Enabled = True

                        Else

                            BttNf.Enabled = True
                            BtnProximoItem.Enabled = False
                            BtnSolicitarRevisao.Enabled = True

                        End If

                    ElseIf BuscaOficina.First.Status = 2 Then

                        PicReview.Visible = True

                        Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcNovaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagem = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                        Dim img As Image = Image.FromStream(stream)

                        PicImagemNova.BackgroundImage = img


                        Dim baseUrlImagemUs As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcUsadaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagemUs = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim streamUs As Stream = syncClientImagemUs.OpenRead(baseUrlImagemUs)

                        Dim imgUs As Image = Image.FromStream(streamUs)

                        PicImagemUsada.BackgroundImage = imgUs

                        LblDescricaoDoItem.Text = BuscaOficina.First.DescricaoItem

                        Parar = True

                        LblNumNF.Text = BuscaOficina.First.NumNf
                        LblItemNf.Text = BuscaOficina.First.NumItemNF
                        LblIdItemLaudo.Text = BuscaOficina.First.IdItemExt
                        LblCodFornecedor.Text = BuscaOficina.First.idfornecedor

                        If LblNumNF.Text = 0 Then

                            BttNf.Enabled = False
                            BtnProximoItem.Enabled = False
                            LblItemNf.Text = ""
                            BtnSolicitarRevisao.Enabled = True

                        Else

                            BttNf.Enabled = True
                            BtnProximoItem.Enabled = False
                            BtnSolicitarRevisao.Enabled = True

                        End If

                    End If

                Else

                    Parar = True

                    If MsgBox("Nenhum item pode ser analisado no momento, existem informações pendentes. O cliente acaba de ser notificado, e tem um prazo de 6 horas uteis para responder ou o pedido será cancelado.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                        Dim baseUrlSol As String = "http://www.iarasoftware.com.br/create_solicitacao_review.php?IdItemLaudo=" & IdLaudo & "&ChaveOficina=" & LblChaveCliente.Text & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&NoSolicitador=" & 0 & "&IdNo=0" & "&FotoUsada=0" & "&FotoNova=0" & "&NotaFiscal=0" & "&Status=0" & "&Origem=" & 1 & "&DataSolicitacao=" & Today.Date & "&HoraSolicitacao=" & Now.TimeOfDay.ToString
                        Dim syncClientSol = New WebClient()
                        Dim contentSol = syncClientSol.DownloadString(baseUrlSol)

                        FrmLaudos.DtFornecedores.SelectedCells(7).Value = "06:00:00"

                        Me.Close()

                    End If

                End If

            End If

        Next

        If Parar = False Then

            If MsgBox("Todos os itens solicitados foram avaliados.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                Me.Close()

            End If


        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttNf.Click

        'busca na base de documentos do cliente se arquivo esta disponivel

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_nf_item_laudo.php?ChaveOficina=" & LblChaveCliente.Text & "&IdItemLaudo=" & LblIdItemLaudo.Text
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Try

            'Dim arquivoJson = JObject.Parse(content)

            ' Cria o serializados Json e trata a resposta
            Dim serializer As New DataContractJsonSerializer(GetType(Classe_Veiculos_Oficina.ImagemNF))
            Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                ' deserializa o objeto JSON usando o tipo de dados
                Dim weatherData = DirectCast(serializer.ReadObject(ms), Classe_Veiculos_Oficina.ImagemNF)

                'Return weatherData
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ImagemNF))(content)

        Dim LstItemsEncontrados As New ListBox

        If read.Count > 0 Then

            For Each row In read.ToList

                If row.ImagemNF = "ND" Then
                    MsgBox("Não foi encontrado nenhum arquivo para esta nota fiscal", MsgBoxStyle.OkOnly)
                Else
                    LstItemsEncontrados.Items.Add(row.ImagemNF)
                    FrmNF_Exibir.LstNf.Items.Add(row.ImagemNF)
                End If

            Next

            If LstItemsEncontrados.Items.Count > 0 Then

                FrmNF_Exibir.LblDescricao.Text = LblDescricaoDoItem.Text
                FrmNF_Exibir.Show(Me)

            End If

        Else

            MsgBox("Não foi encontrado nenhum arquivo para esta nota fiscal", MsgBoxStyle.OkOnly)

        End If

        'carrega informações no site

        ' Chamada sincrona
        'Dim syncClientImagem = New WebClient()
        ''syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
        'Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

        'Dim img As Image = Image.FromStream(stream)


    End Sub

    Private Sub BtnProximoItem_Click(sender As Object, e As EventArgs) Handles BtnProximoItem.Click

        'Atualiza como aprovado

        Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_aprovacao_item_laudo.php?ChaveOficina=" & LblChaveCliente.Text & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&IdItemLaudo=" & LblIdItemLaudo.Text
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim Lqoficina As New LqOficinaDataContext
        Lqoficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Lqoficina.AtualizaItemLaudoStatus(LblIdItemLaudo.Text, 1)

        'busca próximo item

        Dim BuscaIdLaudoExt = From ofi In Lqoficina.LaudosTecnicos
                              Where ofi.IdLaudoExt = IdLaudo And ofi.Status = 0
                              Select ofi.IdLaudoTecnico, ofi.PlacaVeiculo, ofi.ModeloVeiculo, ofi.NomeCompleto, ofi.ChaveOficina

        LblNomeCliente.Text = BuscaIdLaudoExt.First.NomeCompleto & " (" & BuscaIdLaudoExt.First.PlacaVeiculo.ToUpper & " - " & BuscaIdLaudoExt.First.ModeloVeiculo & ")"
        LblChaveCliente.Text = BuscaIdLaudoExt.First.ChaveOficina

        LblIdLaudo.Text = IdLaudo

        Dim Parar As Boolean = False

        For Each row In BuscaIdLaudoExt.ToList

            If Parar = False Then

                Dim BuscaOficina = From ofi In Lqoficina.ItemLaudosTecnicos
                                   Where ofi.IdLaudoTecnico = IdLaudo
                                   Select ofi.ImgPcNovaUrl, ofi.ImgPcUsadaUrl, ofi.Status, ofi.IdItemLaudoTecnico, ofi.DescricaoItem, ofi.NumNf, ofi.NumItemNF, ofi.IdItemExt, ofi.IdFornecedor
                                   Order By IdItemLaudoTecnico Descending

                If BuscaOficina.Count > 0 Then

                    If BuscaOficina.First.Status = 0 Then

                        Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcNovaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagem = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                        Dim img As Image = Image.FromStream(stream)

                        PicImagemNova.BackgroundImage = img


                        Dim baseUrlImagemUs As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcUsadaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagemUs = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim streamUs As Stream = syncClientImagemUs.OpenRead(baseUrlImagemUs)

                        Dim imgUs As Image = Image.FromStream(streamUs)

                        PicImagemUsada.BackgroundImage = imgUs

                        LblDescricaoDoItem.Text = BuscaOficina.First.DescricaoItem

                        Parar = True

                        LblNumNF.Text = BuscaOficina.First.NumNf
                        LblItemNf.Text = BuscaOficina.First.NumItemNF
                        LblIdItemLaudo.Text = BuscaOficina.First.IdItemExt
                        LblCodFornecedor.Text = BuscaOficina.First.idfornecedor

                        If LblNumNF.Text = 0 Then

                            BttNf.Enabled = False
                            BtnProximoItem.Enabled = False
                            LblItemNf.Text = ""
                            BtnSolicitarRevisao.Enabled = True

                        Else

                            BttNf.Enabled = True
                            BtnProximoItem.Enabled = False
                            BtnSolicitarRevisao.Enabled = True

                        End If

                    ElseIf BuscaOficina.First.Status = 2 Then

                        PicReview.Visible = True

                        Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcNovaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagem = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                        Dim img As Image = Image.FromStream(stream)

                        PicImagemNova.BackgroundImage = img


                        Dim baseUrlImagemUs As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcUsadaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagemUs = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim streamUs As Stream = syncClientImagemUs.OpenRead(baseUrlImagemUs)

                        Dim imgUs As Image = Image.FromStream(streamUs)

                        PicImagemUsada.BackgroundImage = imgUs

                        LblDescricaoDoItem.Text = BuscaOficina.First.DescricaoItem

                        Parar = True

                        LblNumNF.Text = BuscaOficina.First.NumNf
                        LblItemNf.Text = BuscaOficina.First.NumItemNF
                        LblIdItemLaudo.Text = BuscaOficina.First.IdItemExt
                        LblCodFornecedor.Text = BuscaOficina.First.idfornecedor

                        If LblNumNF.Text = 0 Then

                            BttNf.Enabled = False
                            BtnProximoItem.Enabled = False
                            LblItemNf.Text = ""
                            BtnSolicitarRevisao.Enabled = True

                        Else

                            BttNf.Enabled = True
                            BtnProximoItem.Enabled = False
                            BtnSolicitarRevisao.Enabled = True

                        End If

                    End If

                Else

                    Parar = True

                    If MsgBox("Nenhum item pode ser analisado no momento, existem informações pendentes. O cliente acaba de ser notificado, e tem um prazo de 6 horas uteis para responder ou o pedido será cancelado.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                        Dim baseUrlSol As String = "http://www.iarasoftware.com.br/create_solicitacao_review.php?IdItemLaudo=" & IdLaudo & "&ChaveOficina=" & LblChaveCliente.Text & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&NoSolicitador=" & 0 & "&IdNo=0" & "&FotoUsada=0" & "&FotoNova=0" & "&NotaFiscal=0" & "&Status=0" & "&Origem=" & 1 & "&DataSolicitacao=" & Today.Date & "&HoraSolicitacao=" & Now.TimeOfDay.ToString
                        Dim syncClientSol = New WebClient()
                        Dim contentSol = syncClientSol.DownloadString(baseUrlSol)

                        FrmLaudos.DtFornecedores.SelectedCells(7).Value = "06:00:00"

                        Me.Close()

                    End If

                End If

            End If

        Next

        If Parar = False Then

            If MsgBox("Todos os itens solicitados foram avaliados.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                'atualiza laudos
                'atualiza_aprovacao_laudo

                Dim baseUrlFim As String = "http://www.iarasoftware.com.br/atualiza_aprovacao_laudo.php?ChaveOficina=" & LblChaveCliente.Text & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&IdLaudo=" & IdLaudo & "&DataEntrega=" & Today.Date & "&HoraEntrega=" & Now.TimeOfDay.ToString
                Dim syncClientFim = New WebClient()
                Dim contentFim = syncClientFim.DownloadString(baseUrlFim)

                'atualiza no banco interno

                If LblChaveCliente.Text = FrmPrincipal.LblChaveEnc.Text Then

                    'atualiza o fim marcando faturado 

                    Lqoficina.AtualizaLaudoStatus_interno(IdLaudo, 1)

                End If

                'atualiza inicial

                Me.Close()

            End If

        End If


    End Sub

    Private Sub BtnSolicitarRevisao_Click(sender As Object, e As EventArgs) Handles BtnSolicitarRevisao.Click

        'Atualiza como ser revisado

        Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_item_laudo_revisar.php?ChaveOficina=" & LblChaveCliente.Text & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&IdItemLaudo=" & LblIdItemLaudo.Text
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim baseUrlSol As String = "http://www.iarasoftware.com.br/create_solicitacao_review.php?IdItemLaudo=" & LblIdItemLaudo.Text & "&ChaveOficina=" & LblChaveCliente.Text & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&NoSolicitador=" & 0 & "&IdNo=0" & "&FotoUsada=0" & "&FotoNova=0" & "&NotaFiscal=0" & "&Status=0" & "&Origem=" & 0 & "&DataSolicitacao=" & Today.Date & "&HoraSolicitacao=" & Now.TimeOfDay.ToString
        Dim syncClientSol = New WebClient()
        Dim contentSol = syncClientSol.DownloadString(baseUrlSol)

        FrmLaudos.DtFornecedores.SelectedCells(7).Value = "06:00:00"

        'inicia rotina do proximo item

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        LqOficina.AtualizaItemLaudoStatus(LblIdItemLaudo.Text, 2)

        'busca próximo item


        Dim BuscaIdLaudoExt = From ofi In LqOficina.LaudosTecnicos
                              Where ofi.IdLaudoExt = IdLaudo And ofi.Status = 0
                              Select ofi.IdLaudoTecnico, ofi.PlacaVeiculo, ofi.ModeloVeiculo, ofi.NomeCompleto, ofi.ChaveOficina

        LblNomeCliente.Text = BuscaIdLaudoExt.First.NomeCompleto & " (" & BuscaIdLaudoExt.First.PlacaVeiculo.ToUpper & " - " & BuscaIdLaudoExt.First.ModeloVeiculo & ")"
        LblChaveCliente.Text = BuscaIdLaudoExt.First.ChaveOficina

        LblIdLaudo.Text = IdLaudo

        Dim Parar As Boolean = False

        For Each row In BuscaIdLaudoExt.ToList

            If Parar = False Then

                Dim BuscaOficina = From ofi In LqOficina.ItemLaudosTecnicos
                                   Where ofi.IdLaudoTecnico = IdLaudo And ofi.IdItemExt > LblIdItemLaudo.Text
                                   Select ofi.ImgPcNovaUrl, ofi.ImgPcUsadaUrl, ofi.Status, ofi.IdItemLaudoTecnico, ofi.DescricaoItem, ofi.NumNf, ofi.NumItemNF, ofi.IdItemExt
                                   Order By IdItemLaudoTecnico Descending

                If BuscaOficina.Count > 0 Then

                    If BuscaOficina.First.Status = 0 Then

                        Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcNovaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagem = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                        Dim img As Image = Image.FromStream(stream)

                        PicImagemNova.BackgroundImage = img


                        Dim baseUrlImagemUs As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcUsadaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagemUs = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim streamUs As Stream = syncClientImagemUs.OpenRead(baseUrlImagemUs)

                        Dim imgUs As Image = Image.FromStream(streamUs)

                        PicImagemUsada.BackgroundImage = imgUs

                        LblDescricaoDoItem.Text = BuscaOficina.First.DescricaoItem

                        Parar = True

                        LblNumNF.Text = BuscaOficina.First.NumNf
                        LblItemNf.Text = BuscaOficina.First.NumItemNF
                        LblIdItemLaudo.Text = BuscaOficina.First.IdItemExt

                        If LblNumNF.Text = 0 Then

                            BttNf.Enabled = False
                            BtnProximoItem.Enabled = False
                            LblItemNf.Text = ""
                            BtnSolicitarRevisao.Enabled = True

                        Else

                            BttNf.Enabled = True
                            BtnProximoItem.Enabled = False
                            BtnSolicitarRevisao.Enabled = True

                        End If

                    ElseIf BuscaOficina.First.Status = 2 Then

                        PicReview.Visible = True

                        Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcNovaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagem = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                        Dim img As Image = Image.FromStream(stream)

                        PicImagemNova.BackgroundImage = img


                        Dim baseUrlImagemUs As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcUsadaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagemUs = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim streamUs As Stream = syncClientImagemUs.OpenRead(baseUrlImagemUs)

                        Dim imgUs As Image = Image.FromStream(streamUs)

                        PicImagemUsada.BackgroundImage = imgUs

                        LblDescricaoDoItem.Text = BuscaOficina.First.DescricaoItem

                        Parar = True

                        LblNumNF.Text = BuscaOficina.First.NumNf
                        LblItemNf.Text = BuscaOficina.First.NumItemNF
                        LblIdItemLaudo.Text = BuscaOficina.First.IdItemExt

                        If LblNumNF.Text = 0 Then

                            BttNf.Enabled = False
                            BtnProximoItem.Enabled = False
                            LblItemNf.Text = ""
                            BtnSolicitarRevisao.Enabled = True

                        Else

                            BttNf.Enabled = True
                            BtnProximoItem.Enabled = False
                            BtnSolicitarRevisao.Enabled = True

                        End If

                    End If

                End If

            End If

        Next

        If Parar = False Then

            If MsgBox("Nenhum item pode ser análisado no momento, existem arquivos ausentes. O cliente acaba de ser notificado, e tem um prazo de 6 horas uteis para responder ou o pedido será cancelado.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                Me.Close()

            End If

        End If

    End Sub

    Private Sub LblItemNf_Click(sender As Object, e As EventArgs) Handles LblItemNf.Click

    End Sub

    Private Sub LblItemNf_TextChanged(sender As Object, e As EventArgs) Handles LblItemNf.TextChanged

        If LblItemNf.Text <> 0 Then
            BtnProximoItem.Enabled = True
        Else
            BtnProximoItem.Enabled = False
        End If

    End Sub
End Class