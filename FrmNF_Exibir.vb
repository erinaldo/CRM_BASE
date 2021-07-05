Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class FrmNF_Exibir
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Public LstNf As New ListBox
    Public PointsImagens As New Point

    Dim ImagemEnc As Image

    Private Sub FrmNF_Exibir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim baseUrlImagemUs As String = "http://www.iarasoftware.com.br/" & LstNf.Items(0).ToString

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientImagemUs = New WebClient()
        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
        Dim streamUs As Stream = syncClientImagemUs.OpenRead(baseUrlImagemUs)

        Dim imgUs As Image = Image.FromStream(streamUs)
        ImagemEnc = imgUs

        PicNF.BackgroundImage = ImagemEnc
        PicNF.BackgroundImageLayout = ImageLayout.Zoom

        PicNF.Size = New Size(imgUs.Width, imgUs.Height)
        PointsImagens = New Point(imgUs.Width, imgUs.Height)

        'diminui tamanho para caber

        Dim Pctg As Decimal = 1

        While PicNF.Size.Width >= Panel3.Width - 20 Or PicNF.Size.Height >= Panel3.Height - 20

            PicNF.Size = New Size((imgUs.Width * Pctg), (imgUs.Height * Pctg))

            Pctg -= 1 / 100

        End While

        LblPctg.Text = (Pctg * 100) & "%"

        PicNF.Location = New Point((Panel3.Width / 2) - (PicNF.Size.Width / 2), (Panel3.Height / 2) - (PicNF.Size.Height / 2))


    End Sub

    Private Sub PicNF_MouseClick(sender As Object, e As MouseEventArgs) Handles PicNF.MouseClick

        PicNF.BackgroundImageLayout = ImageLayout.None

        Dim ValorZoom As Decimal = LblPctg.Text.Remove(LblPctg.Text.Length - 1, 1)
        Dim PctgFaltando As Decimal = 100
        PctgFaltando -= ValorZoom

        'MsgBox(PctgFaltando)

        LblMkX.Text = e.X
        LblMkY.Text = e.Y

        'aumenta até o maximo

        Dim X As Decimal = LblMkX.Text
        Dim Y As Decimal = LblMkY.Text

        Dim PcgtFlt As Decimal = FormatNumber(ValorZoom / 100, NumDigitsAfterDecimal:=1)

        'calcula com regra de tres

        Dim ValorCheio As Decimal = PicNF.Width
        Dim ValorPoint As Decimal = e.X - 23
        Dim Calculo As Decimal = (ValorPoint * 100) / ValorCheio

        'Y
        Dim ValorCheioY As Decimal = PicNF.Height
        Dim ValorPointY As Decimal = e.Y - 17
        Dim CalculoY As Decimal = (ValorPointY * 100) / ValorCheioY


        LblMkX.Text = FormatNumber(Calculo, NumDigitsAfterDecimal:=1)
        LblMkY.Text = FormatNumber(CalculoY, NumDigitsAfterDecimal:=1)

        'MsgBox(Calculo)

        Dim Image As Bitmap = New Bitmap(PicNF.Width, PicNF.Height)
        Dim Pintura = Graphics.FromImage(Image)

        Dim Image2 As Bitmap = New Bitmap(PicNF.Width, PicNF.Height)
        Dim Pintura2 = Graphics.FromImage(Image2)

        Dim Vlr01 As Decimal = e.X - 23
        Dim Vlr02 As Decimal = e.Y - 17

        Pintura.DrawImage(ImageList1.Images(0), Vlr01, Vlr02, 20, 40)

        Pintura2.DrawImage(ImagemEnc, 0, 0, PointsImagens.X * (ValorZoom / 100), PointsImagens.Y * (ValorZoom / 100))

        PicNF.Image = Image

        PicNF.BackgroundImage = Image2

        'Insere marcação da imagem

        TxtItemNf.Enabled = True

    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

        'amplia a imagem até 100

        If LblPctg.Text <> "100%" Then

            PicNF.BackgroundImageLayout = ImageLayout.None

            Dim Pctg As Decimal = LblPctg.Text.Remove(LblPctg.Text.Length - 1, 1) / 100

            Pctg += 5 / 100

            If Pctg > 1 Then

                Pctg = 1

            End If

            PicNF.Size = New Size((PointsImagens.X * Pctg), (PointsImagens.Y * Pctg))

            LblPctg.Text = (Pctg * 100) & "%"

            PicNF.Location = New Point((Panel3.Width / 2) - (PicNF.Size.Width / 2), (Panel3.Height / 2) - (PicNF.Size.Height / 2))

            Dim X As Decimal = LblMkX.Text
            Dim Y As Decimal = LblMkY.Text

            Dim Image As Bitmap = New Bitmap(PicNF.Width, PicNF.Height)
            Dim Pintura = Graphics.FromImage(Image)

            Dim Image2 As Bitmap = New Bitmap(PicNF.Width, PicNF.Height)
            Dim Pintura2 = Graphics.FromImage(Image2)

            Dim Vlr01 As Decimal = (PointsImagens.X * Pctg) * (X / 100)
            Dim Vlr02 As Decimal = (PointsImagens.Y * Pctg) * (Y / 100)

            Pintura.DrawImage(ImageList1.Images(0), Vlr01, Vlr02, 20, 40)

            Pintura2.DrawImage(ImagemEnc, 0, 0, PointsImagens.X * Pctg, PointsImagens.Y * Pctg)

            PicNF.Image = Image

            PicNF.BackgroundImage = Image2

        End If

    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click
        If LblPctg.Text <> "0%" Then

            PicNF.BackgroundImageLayout = ImageLayout.None

            Dim Pctg As Decimal = LblPctg.Text.Remove(LblPctg.Text.Length - 1, 1) / 100

            Pctg -= 5 / 100

            If Pctg < 0.05 Then

                Pctg = 0.05

            End If

            PicNF.Size = New Size((PointsImagens.X * Pctg), (PointsImagens.Y * Pctg))

            LblPctg.Text = (Pctg * 100) & "%"

            PicNF.Location = New Point((Panel3.Width / 2) - (PicNF.Size.Width / 2), (Panel3.Height / 2) - (PicNF.Size.Height / 2))


            Dim X As Decimal = LblMkX.Text / 100
            Dim Y As Decimal = LblMkY.Text / 100

            Dim Image As Bitmap = New Bitmap(PicNF.Width, PicNF.Height)
            Dim Pintura = Graphics.FromImage(Image)

            Dim Image2 As Bitmap = New Bitmap(PicNF.Width, PicNF.Height)
            Dim Pintura2 = Graphics.FromImage(Image2)

            Dim Vlr01 As Decimal = (PointsImagens.X * Pctg) * X
            Dim Vlr02 As Decimal = (PointsImagens.Y * Pctg) * Y

            Pintura.DrawImage(ImageList1.Images(0), Vlr01, Vlr02, 20, 40)

            Pintura2.DrawImage(ImagemEnc, 0, 0, PointsImagens.X * Pctg, PointsImagens.Y * Pctg)

            PicNF.Image = Image

            PicNF.BackgroundImage = Image2

        End If

    End Sub

    Private Sub TxtItemNf_TextChanged(sender As Object, e As EventArgs) Handles TxtItemNf.TextChanged
        If TxtItemNf.Text <> "" Then
            BtnValidar.Enabled = True
        Else
            BtnValidar.Enabled = False
        End If
    End Sub

    Private Sub BtnValidar_Click(sender As Object, e As EventArgs) Handles BtnValidar.Click

        FrmItemLaudo.LblItemNf.Text = TxtItemNf.Text

        Me.Close()

    End Sub

    Private Sub BtnSolicitarRevisao_Click(sender As Object, e As EventArgs) Handles BtnSolicitarRevisao.Click

        'Atualiza como ser revisado

        Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_item_laudo_revisar.php?ChaveOficina=" & FrmItemLaudo.LblChaveCliente.Text & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&IdItemLaudo=" & FrmItemLaudo.LblIdItemLaudo.Text
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim baseUrlSol As String = "http://www.iarasoftware.com.br/create_solicitacao_review.php?IdItemLaudo=" & FrmItemLaudo.LblIdItemLaudo.Text & "&ChaveOficina=" & FrmItemLaudo.LblChaveCliente.Text & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&NoSolicitador=" & 0 & "&IdNo=0" & "&FotoUsada=1" & "&FotoNova=1" & "&NotaFiscal=0" & "&Status=0" & "&Origem=" & 0 & "&DataSolicitacao=" & Today.Date & "&HoraSolicitacao=" & Now.TimeOfDay.ToString
        Dim syncClientSol = New WebClient()
        Dim contentSol = syncClientSol.DownloadString(baseUrlSol)

        FrmLaudos.DtFornecedores.SelectedCells(7).Value = "06:00:00"

        'inicia rotina do proximo item

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        LqOficina.AtualizaItemLaudoStatus(FrmItemLaudo.LblIdItemLaudo.Text, 2)

        'busca próximo item


        Dim BuscaIdLaudoExt = From ofi In LqOficina.LaudosTecnicos
                              Where ofi.IdLaudoExt = FrmItemLaudo.IdLaudo And ofi.Status = 0
                              Select ofi.IdLaudoTecnico, ofi.PlacaVeiculo, ofi.ModeloVeiculo, ofi.NomeCompleto, ofi.ChaveOficina

        FrmItemLaudo.LblNomeCliente.Text = BuscaIdLaudoExt.First.NomeCompleto & " (" & BuscaIdLaudoExt.First.PlacaVeiculo.ToUpper & " - " & BuscaIdLaudoExt.First.ModeloVeiculo & ")"
        FrmItemLaudo.LblChaveCliente.Text = BuscaIdLaudoExt.First.ChaveOficina

        FrmItemLaudo.LblIdLaudo.Text = FrmItemLaudo.IdLaudo

        Dim Parar As Boolean = False

        For Each row In BuscaIdLaudoExt.ToList

            If Parar = False Then

                Dim BuscaOficina = From ofi In LqOficina.ItemLaudosTecnicos
                                   Where ofi.IdLaudoTecnico = FrmItemLaudo.IdLaudo And ofi.IdItemExt > FrmItemLaudo.LblIdItemLaudo.Text
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

                        FrmItemLaudo.PicImagemNova.BackgroundImage = img


                        Dim baseUrlImagemUs As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcUsadaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagemUs = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim streamUs As Stream = syncClientImagemUs.OpenRead(baseUrlImagemUs)

                        Dim imgUs As Image = Image.FromStream(streamUs)

                        FrmItemLaudo.PicImagemUsada.BackgroundImage = imgUs

                        FrmItemLaudo.LblDescricaoDoItem.Text = BuscaOficina.First.DescricaoItem

                        Parar = True

                        FrmItemLaudo.LblNumNF.Text = BuscaOficina.First.NumNf
                        FrmItemLaudo.LblItemNf.Text = BuscaOficina.First.NumItemNF
                        FrmItemLaudo.LblIdItemLaudo.Text = BuscaOficina.First.IdItemExt

                        If FrmItemLaudo.LblNumNF.Text = 0 Then

                            FrmItemLaudo.BttNf.Enabled = False
                            FrmItemLaudo.BtnProximoItem.Enabled = False
                            FrmItemLaudo.LblItemNf.Text = ""
                            BtnSolicitarRevisao.Enabled = True

                        Else

                            FrmItemLaudo.BttNf.Enabled = True
                            FrmItemLaudo.BtnProximoItem.Enabled = False
                            BtnSolicitarRevisao.Enabled = True

                        End If

                    ElseIf BuscaOficina.First.Status = 2 Then

                        FrmItemLaudo.PicReview.Visible = True

                        Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcNovaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagem = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                        Dim img As Image = Image.FromStream(stream)

                        FrmItemLaudo.PicImagemNova.BackgroundImage = img


                        Dim baseUrlImagemUs As String = "http://www.iarasoftware.com.br/" & BuscaOficina.First.ImgPcUsadaUrl

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagemUs = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim streamUs As Stream = syncClientImagemUs.OpenRead(baseUrlImagemUs)

                        Dim imgUs As Image = Image.FromStream(streamUs)

                        FrmItemLaudo.PicImagemUsada.BackgroundImage = imgUs

                        FrmItemLaudo.LblDescricaoDoItem.Text = BuscaOficina.First.DescricaoItem

                        Parar = True

                        FrmItemLaudo.LblNumNF.Text = BuscaOficina.First.NumNf
                        FrmItemLaudo.LblItemNf.Text = BuscaOficina.First.NumItemNF
                        FrmItemLaudo.LblIdItemLaudo.Text = BuscaOficina.First.IdItemExt

                        If FrmItemLaudo.LblNumNF.Text = 0 Then

                            FrmItemLaudo.BttNf.Enabled = False
                            FrmItemLaudo.BtnProximoItem.Enabled = False
                            FrmItemLaudo.LblItemNf.Text = ""
                            FrmItemLaudo.BtnSolicitarRevisao.Enabled = True

                        Else

                            FrmItemLaudo.BttNf.Enabled = True
                            FrmItemLaudo.BtnProximoItem.Enabled = False
                            BtnSolicitarRevisao.Enabled = True

                        End If

                    End If

                End If

            End If

        Next

    End Sub
End Class