Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Public Class FrmPrincipal

    Public IdUsuario As Integer = 8

    Private Sub QuadroDeColaboradoresToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CadastrosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FrmCadColaboradores.Show(Me)
    End Sub

    Private Sub EncerrarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Public IdCliente As Integer = 1

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.Text &= My.Application.Deployment.CurrentVersion.ToString

        LblRH.Size = New Size(FlowLayoutPanel1.Width, LblRH.Height)

        PnnRH.Size = New Size(FlowLayoutPanel1.Width, PnnRH.Height)
        PnnComercial.Size = New Size(FlowLayoutPanel1.Width, PnnComercial.Height)

        FlowLayoutPanel1.VerticalScroll.Visible = True

        DashOperação.Dock = DockStyle.Fill
        DashOperação.Visible = True
        Panel48.Size = New Size(DashOperação.Width, DashOperação.Height)

        PnnStg001.Size = New Size(Panel48.Width / 4, PnnStg001.Height)
        PnnStg002.Size = New Size(Panel48.Width / 4, PnnStg002.Height)
        PnnStg003.Size = New Size(Panel48.Width / 4, PnnStg003.Height)
        'PnnStg004.Size = New Size(Panel48.Width / 5, PnnStg004.Height)
        PnnStg005.Size = New Size(Panel48.Width / 4, PnnStg005.Height)

        FrmLogin.Visible = False

        'CarregaDashboard()

    End Sub

    Dim LqOficina As New LqOficinaDataContext

    Public Tuto As Boolean = True

    Dim LstStatusLista As New ListBox

    Dim LstStatusPlacas As New ListBox

    Dim LstDatasReg As New ListBox

    Dim LstStatusString As New ListBox

    Public RazaoSocial As String
    Public CNPJ As String
    Public Endereco As String
    Public Telefone As String
    Public Email As String
    Public IE As String
    Public Numero As String
    Public Complemento As String
    Public NomeFantasia As String

    Public Sub CarregaDashboard()

        If Timer2.Enabled = False Then
            Timer2.Enabled = True
            EsperaC = 15
            Me.Cursor = Cursors.WaitCursor

            'limpa alert

            TtFinanceiro.Image = Nothing
            TtFinanceiro.TextAlign = ContentAlignment.MiddleLeft
            CotaçõesToolStripMenuItem.Image = Nothing
            RecebimentoToolStripMenuItem1.Image = Nothing
            EmitirNFSToolStripMenuItem.Image = Nothing
            GestãoDeMarkupToolStripMenuItem.Image = Nothing
            PagamentosCimValidaçãoDeValoresToolStripMenuItem.Image = Nothing
            PagamentosCimValidaçãoDeValoresToolStripMenuItem.Enabled = False
            ExpediçãoToolStripMenuItem.Image = Nothing
            ExpediçãoToolStripMenuItem.Enabled = False

            TtEstoque.Image = Nothing
            TtEstoque.TextAlign = ContentAlignment.MiddleLeft
            ToolStripMenuItem1.Image = Nothing
            RecebimentoToolStripMenuItem.Image = Nothing

            'TtEstoque.Enabled = False
            'ToolStripMenuItem1.Enabled = False
            RecebimentoToolStripMenuItem.Enabled = False

            TtOficina.Image = Nothing
            TtOficina.TextAlign = ContentAlignment.MiddleLeft
            LaudosPericiaisToolStripMenuItem.Image = Nothing

            TtOficina.Enabled = True
            LaudosPericiaisToolStripMenuItem.Enabled = False

            ToolStripDropDownButton1.Image = Nothing
            ToolStripDropDownButton1.TextAlign = ContentAlignment.MiddleLeft
            ToolStripMenuItem11.Image = Nothing

            ToolStripDropDownButton1.Enabled = False
            ToolStripMenuItem11.Enabled = False

            TtComercial.Image = Nothing
            TtComercial.TextAlign = ContentAlignment.MiddleLeft
            ToolStripMenuItem2.Image = Nothing

            TtComercial.Enabled = False
            ToolStripMenuItem2.Enabled = False

            If Application.OpenForms.OfType(Of FrmSinc)().Count() = 0 Then

                FrmSinc.Show(Me)
                FrmSinc.Focus()

                Me.Refresh()

            End If

            'FrmSinc.Refresh()


            FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Iniciando paramentros de leitura", "", "", Nothing)

            'FrmSinc.Refresh()

            valOpc = 0

            'carrega imagem do ususario

            Dim baseUrlImagemUsuario As String = "http://www.iarasoftware.com.br/consulta_dados_usuario_local.php?ChaveOficina=" & LblChaveEnc.Text & "&IdUsuario=" & IdUsuario

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientImagemUsuario = New WebClient()
            Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

            Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.DadosUsuario))(contentImagemUsuario)

            LblCargo.Text = readImagemUsuario.Item(0).Cargo

            If readImagemUsuario.Item(0).UrlImagem <> "" Then

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & readImagemUsuario.Item(0).UrlImagem

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                PicSelf.BackgroundImage = img

            End If

            'Try

            Dim baseUrl As String = "http://www.iarasoftware.com.br/read_todos_processos_local.php?ChaveOficina=" & LblChaveEnc.Text

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

            FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Realizando busca nos servidores internos", "", "", Nothing)

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            'FrmSinc.Refresh()

            LstStatusLista.Items.Clear()
            LstDatasReg.Items.Clear()
            LstStatusPlacas.Items.Clear()
            LstStatusString.Items.Clear()

            Dim BuscaOficina = From veic In LqOficina.Vistorias
                               Where veic.NivelReq = 0
                               Select veic.IdTecnico, veic.Recebida, veic.Concluido, veic.DataSolicitação, veic.IdVeiculo, veic.DataVistoria, veic.DataInicioVistoria


            Dim DDMes As New ListBox
            Dim Pos
            'popula no grid

            Dim Conc As Integer
            Dim Espera As Integer
            Dim Realizando As Integer

            Dim DesmConc As Integer
            Dim DesmEspera As Integer
            Dim DesmRealizando As Integer

            Dim FunilariaConc As Integer
            Dim FunilariaEspera As Integer
            Dim FunilariaRealizando As Integer

            Dim EntregaConc As Integer
            Dim EntregaEspera As Integer
            Dim EntregaRealizando As Integer

            Dim LstConc As New ListBox
            Dim LstEspera As New ListBox

            Dim LstConcDesm As New ListBox
            Dim LstEsperaDesm As New ListBox

            Dim LstConcFunil As New ListBox
            Dim LstEsperaFunil As New ListBox

            Dim LstConcEntrega As New ListBox
            Dim LstEsperaEntrega As New ListBox

            Dim TodosVeiculos As New ListBox

            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Veiculos))(content)

            DtPatio.Rows.Clear()

            LqOficina.Connection.ConnectionString = ConnectionStringOficina

            Dim TodosVeiculosValor As New ListBox


            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

            FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Lendo dados obtidos", 0, read.Count, Nothing)

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()


            Realizando = 0
            Espera = 0
            Conc = 0
            DesmRealizando = 0
            DesmEspera = 0
            DesmConc = 0

            Dim CT As Double = 10 / read.Count

            For Each row In read.ToList

                If Not TodosVeiculos.Items.Contains(row.Placa.ToUpper) Then

                    If row.Status < 2 Then

                        TodosVeiculos.Items.Add(row.Placa.ToUpper)
                        DtPatio.Rows.Add(row.IdVeiculo, row.Placa.ToUpper, row.Modelo, row.Fabricante, My.Resources.alert_icon_icons_com_52395, "", row.Tipo & "-" & row.Status, row.IdSolicitacao, row.IdCliente)

                    End If

                End If

                'procura se item esta na lsita de inseridos

                If Not TodosVeiculosValor.Items.Contains(row.Placa & "-" & row.Tipo & "-" & row.Status) Then

                    TodosVeiculosValor.Items.Add(row.Placa & "-" & row.Tipo & "-" & row.Status)

                    Dim IndexTrav As Integer = -1

                    For i As Integer = 0 To TodosVeiculos.Items.Count - 1

                        If TodosVeiculos.Items(i).ToString = row.Placa.ToUpper Then

                            Dim DataInicioEnc As Date = row.DataInicio.ToString

                            Dim DataTerminoEnc As Date = row.DataInicio.ToString

                            Dim DataControle As Date = Today.Date.AddYears(-1)

                            If DataInicioEnc.Date > DataControle Then

                                If row.Tipo = 0 Then

                                    'DtPatio.Rows(i).Cells(4).Value = ImageList1.Images(1)

                                    If row.Status < 2 Then

                                        If row.Status = 0 Then

                                            Realizando += 1

                                        ElseIf row.Status = 1 Then

                                            'Espera += 1

                                            LstEspera.Items.Add(DataInicioEnc.Day)
                                            LstConc.Items.Add(0)

                                            LstStatusLista.Items.Add(0)
                                            LstDatasReg.Items.Add(DataInicioEnc.Date)
                                            LstStatusPlacas.Items.Add(row.Placa)
                                            LstStatusString.Items.Add("Aguardando entrada na oficina")
                                            '

                                        End If

                                    End If

                                ElseIf row.Tipo = 1 Then

                                    'DtPatio.Rows(i).Cells(4).Value = ImageList1.Images(1)

                                    If row.Status < 2 Then

                                        If row.Status = 0 Then

                                            Espera += 1

                                            LstEspera.Items.Add(DataInicioEnc.Day)
                                            LstConc.Items.Add(DataTerminoEnc.Day)

                                            LstStatusLista.Items.Add(1)
                                            LstDatasReg.Items.Add(DataInicioEnc.Date)
                                            LstStatusPlacas.Items.Add(row.Placa)
                                            LstStatusString.Items.Add("Recebendo veículo")
                                            'TodosVeiculosValor.Items.Add(row.Placa & "-" & row.Tipo & "-" & row.Status)

                                        ElseIf row.Status = 1 Then

                                            Conc += 1
                                            'DesmEspera += 1
                                            LstEsperaDesm.Items.Add(DataInicioEnc.Day)
                                            LstConcDesm.Items.Add(0)

                                            LstStatusLista.Items.Add(2)
                                            LstDatasReg.Items.Add(DataInicioEnc.Date)
                                            LstStatusPlacas.Items.Add(row.Placa)
                                            LstStatusString.Items.Add("Aguardando desmonte para reparos")
                                            'TodosVeiculosValor.Items.Add(row.Placa & "-" & row.Tipo & "-" & row.Status)

                                        End If

                                    End If

                                ElseIf row.Tipo = 2 Then

                                    If Not TodosVeiculosValor.Items.Contains(row.Placa & "-1-1") Then

                                        DtPatio.Rows(i).Cells(4).Value = ImageList1.Images(0)

                                    Else

                                        DtPatio.Rows(i).Cells(4).Value = ImageList1.Images(5)

                                    End If

                                    If row.Status < 2 Then

                                        'verifica 

                                        If row.Status = 0 Then

                                            'DesmRealizando += 1

                                            LstEsperaDesm.Items.Add(DataInicioEnc.Day)
                                            LstConcDesm.Items.Add(0)

                                            LstStatusLista.Items.Add(3)
                                            LstDatasReg.Items.Add(DataInicioEnc.Date)
                                            LstStatusPlacas.Items.Add(row.Placa)

                                            ' TodosVeiculosValor.Items.Add(row.Placa & "-" & row.Tipo & "-" & row.Status)

                                            Dim Valida As Boolean = False

                                            If TodosVeiculosValor.Items.Contains(row.Placa & "-3-50") Then

                                                Valida = True

                                                LstStatusString.Items.Add("Aguardando desmonte do veículo")

                                            ElseIf TodosVeiculosValor.Items.Contains(row.Placa & "-3-60") Then

                                                Valida = True

                                                LstStatusString.Items.Add("Desmontando concluído")

                                            End If

                                            If Valida = False Then

                                                LstStatusString.Items.Add("Realizando desmontes necessários")

                                            End If

                                        ElseIf row.Status = 1 Then

                                            DesmConc += 1

                                            LstEsperaDesm.Items.Add(0)
                                            LstConcDesm.Items.Add(DataInicioEnc.Day)

                                            LstStatusLista.Items.Add(3)
                                            LstDatasReg.Items.Add(DataInicioEnc.Date)
                                            LstStatusPlacas.Items.Add(row.Placa)
                                            LstStatusString.Items.Add("Desmontando Concluído")
                                            ' TodosVeiculosValor.Items.Add(row.Placa & "-" & row.Tipo & "-" & row.Status)

                                            'Else

                                        End If

                                    End If

                                ElseIf row.Tipo = 3 Then

                                    'DtPatio.Rows(i).Cells(4).Value = ImageList1.Images(5)

                                    'verifica se o veículo já esta no patio

                                    ' If TodosVeiculosValor.Items.Contains(row.Placa & "-1-1") Then

                                    If row.Status < 2 Then

                                        If row.Status = 0 Then

                                            DesmConc += 1
                                            FunilariaEspera += 1

                                            LstEsperaDesm.Items.Add(DataInicioEnc.Day)
                                            LstConcDesm.Items.Add(DataTerminoEnc.Day)

                                            LstStatusLista.Items.Add(4)
                                            LstDatasReg.Items.Add(DataInicioEnc.Date)
                                            LstStatusPlacas.Items.Add(row.Placa)
                                            LstStatusString.Items.Add("Desmonte concluído")
                                            'TodosVeiculosValor.Items.Add(row.Placa & "-" & row.Tipo & "-" & row.Status)

                                        End If

                                    ElseIf row.Status = 50 Then

                                        DesmEspera += 1

                                        LstEsperaFunil.Items.Add(DataInicioEnc.Day)
                                        LstConcFunil.Items.Add(DataTerminoEnc.Day)

                                        LstStatusLista.Items.Add(6)
                                        LstDatasReg.Items.Add(DataInicioEnc.Date)
                                        LstStatusPlacas.Items.Add(row.Placa)
                                        LstStatusString.Items.Add("Desmonte em espera")
                                        TodosVeiculosValor.Items.Add(row.Placa & "-" & row.Tipo & "-" & row.Status)

                                    ElseIf row.Status = 60 Then

                                        DesmRealizando += 1

                                        LstEsperaFunil.Items.Add(DataInicioEnc.Day)
                                        LstConcFunil.Items.Add(DataTerminoEnc.Day)

                                        LstStatusLista.Items.Add(6)
                                        LstDatasReg.Items.Add(DataInicioEnc.Date)
                                        LstStatusPlacas.Items.Add(row.Placa)
                                        LstStatusString.Items.Add("Desmonte sendo realizado")
                                        TodosVeiculosValor.Items.Add(row.Placa & "-" & row.Tipo & "-" & row.Status)

                                    End If

                                    ' End If

                                ElseIf row.Tipo = 4 Then

                                    DtPatio.Rows(i).Cells(4).Value = ImageList1.Images(3)

                                    If row.Status < 2 Then

                                        If TodosVeiculosValor.Items.Contains(row.Placa & "-3-1") Then

                                            If row.Status = 0 Then

                                                FunilariaConc += 1
                                                EntregaEspera += 1
                                                'EntregaRealizando += 1

                                                LstEsperaEntrega.Items.Add(DataInicioEnc.Day)
                                                LstConcEntrega.Items.Add(0)

                                                LstStatusLista.Items.Add(7)
                                                LstDatasReg.Items.Add(DataInicioEnc.Date)
                                                LstStatusPlacas.Items.Add(row.Placa)
                                                LstStatusString.Items.Add("Entregando veículo")
                                                'TodosVeiculosValor.Items.Add(row.Placa & "-" & row.Tipo & "-" & row.Status)

                                            End If

                                        End If

                                    Else

                                        Dim DataControleEntrega As Date = "01/" & Today.Month & "/" & Today.Year

                                        If DataInicioEnc >= DataControleEntrega Then

                                            EntregaConc += 1

                                            LstStatusLista.Items.Add(8)
                                            LstDatasReg.Items.Add(DataInicioEnc.Date)
                                            LstStatusPlacas.Items.Add(row.Placa)
                                            LstStatusString.Items.Add("Veículo entregue")

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    Next

                End If

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1


                FrmSinc.ProgressBar1.Value += CT

                FrmSinc.Refresh()

            Next

            LblConcluido.Text = Conc
            LblEspera.Text = Espera
            LblAndamento.Text = Realizando

            LblDesmonteEspera.Text = DesmEspera
            LblDemRealiz.Text = DesmRealizando
            LblDesmonteConcluido.Text = DesmConc

            LblFunilEspera.Text = FunilariaEspera
            LblFunilAndamento.Text = FunilariaRealizando
            LblFunilConc.Text = FunilariaConc

            LblAguardandoEntrega.Text = EntregaEspera
            LblEntregando.Text = EntregaRealizando
            LblEntregues.Text = EntregaConc


            'carrega solicitações de cadasto de markup

            LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro
            LqBase.Connection.ConnectionString = ConnectionStringBase

            FrmNotifficação.DtProdutos.Rows.Clear()

            Dim LqComercial As New LqComercialDataContext
            LqComercial.Connection.ConnectionString = ConnectionStringComercial

            Dim BuscaComercial = From com In LqComercial.Orcamentos
                                 Where com.ValorRecebido = True And com.NfEmitida = False
                                 Select com.IdOrcamento, com.IdCliente

            If BuscaComercial.Count > 0 Then

                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                EmitirNFSToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395

                TtFinanceiro.Enabled = True
                EmitirNFSToolStripMenuItem.Enabled = True

            End If

            'busca solicitações de estoque

            Dim LqEstoque As New LqEstoqueLocalDataContext

            LqEstoque.Connection.ConnectionString = ConnectionStringEstoqueLocal

            Dim BuscaSolicitaçõesEstoque = From est In LqEstoque.SolicitacaoProdutosEstoque
                                           Where est.Status = False
                                           Select est.Qtdade, est.IdProduto, est.IdSolicitacaoCad

            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

            FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Carregando solicitações internas 1-3", 0, BuscaSolicitaçõesEstoque.Count, Nothing)

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            For Each row In BuscaSolicitaçõesEstoque.ToList

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                'FrmSinc.Refresh()

                If row.IdProduto <> 0 Then

                    'verifica se ja foi inseirdo na lista

                    Dim BuscadescricaoProduto = From prod In LqBase.Produtos
                                                Where prod.IdProduto = row.IdProduto
                                                Select prod.Descricao

                    Dim Str As String = "O produto " & BuscadescricaoProduto.First & " foi solicitado ao estoque."

                    Dim _Index As Integer = -1

                    Dim QtIndex As Integer = 0

                    For Each dtr As DataGridViewRow In FrmNotifficação.DtProdutos.Rows
                        If dtr.Cells(0).Value.ToString.StartsWith(Str) Then
                            _Index = dtr.Index
                            QtIndex = dtr.Cells(1).Value.ToString + 1
                        End If
                    Next

                    If _Index = -1 Then
                        FrmNotifficação.DtProdutos.Rows.Add(Str & " (visto 1 vez.)", 1)
                    Else
                        FrmNotifficação.DtProdutos.Rows(_Index).Cells(0).Value = (Str & " (visto " & QtIndex & " vezes.)")
                        FrmNotifficação.DtProdutos.Rows(_Index).Cells(1).Value = (QtIndex)
                    End If

                Else

                    'verifica se ja foi inseirdo na lista

                    Dim Buscadescricao = From desc In LqOficina.SolicitacaoCadastroPeca
                                         Where desc.IdSolicitacaoCadastro = row.IdSolicitacaoCad
                                         Select desc.Descricao, desc.IdCodCad

                    Dim Str As String = ""

                    If Buscadescricao.Count > 0 Then
                        If Buscadescricao.First.IdCodCad <> 0 Then

                            Dim BuscadescricaoProduto = From prod In LqBase.Produtos
                                                        Where prod.IdProduto = Buscadescricao.First.IdCodCad
                                                        Select prod.Descricao

                            Str = "O produto " & BuscadescricaoProduto.First & " foi solicitado ao estoque."
                        Else
                            Str = "O produto " & Buscadescricao.First.Descricao & " (cadastro pendente) foi solicitado ao estoque."
                        End If
                    End If

                    Dim _Index As Integer = -1

                    Dim QtIndex As Integer = 0

                    For Each dtr As DataGridViewRow In FrmNotifficação.DtProdutos.Rows
                        If dtr.Cells(0).Value.ToString.StartsWith(Str) Then
                            _Index = dtr.Index
                            QtIndex = dtr.Cells(1).Value.ToString + 1
                        End If
                    Next

                    If _Index = -1 Then
                        FrmNotifficação.DtProdutos.Rows.Add(Str & " (visto 1 vez.)", 1)
                    Else
                        FrmNotifficação.DtProdutos.Rows(_Index).Cells(0).Value = (Str & " (visto " & QtIndex & " vezes.)")
                        FrmNotifficação.DtProdutos.Rows(_Index).Cells(1).Value = (QtIndex)
                    End If

                End If

            Next


            'bubsca solicitaões de cadastro

            Dim BuscaSolicitacaoCadastro = From sol In LqOficina.SolicitacaoCadastroPeca
                                           Where sol.IdCodCad = 0
                                           Select sol.Descricao

            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

            FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Carregando solicitações internas 3-3", 0, BuscaSolicitacaoCadastro.Count, Nothing)


            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            For Each row In BuscaSolicitacaoCadastro.ToList

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                'FrmSinc.Refresh()

                Dim Str As String = "O produto " & BuscaSolicitacaoCadastro.First & " foi inserido e esta aguardando seu cadastro."

                Dim _Index As Integer = -1

                Dim QtIndex As Integer = 0

                For Each dtr As DataGridViewRow In FrmNotifficação.DtProdutos.Rows
                    If dtr.Cells(0).Value.ToString.StartsWith(Str) Then
                        _Index = dtr.Index
                        QtIndex = dtr.Cells(1).Value.ToString + 1
                    End If
                Next

                If _Index = -1 Then
                    FrmNotifficação.DtProdutos.Rows.Add(Str & " (visto 1 vez.)", 1)
                Else
                    FrmNotifficação.DtProdutos.Rows(_Index).Cells(0).Value = (Str & " (visto " & QtIndex & " vezes.)")
                    FrmNotifficação.DtProdutos.Rows(_Index).Cells(1).Value = (QtIndex)
                End If

            Next

            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

            FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Obtendo informações do servidor remoto", "", "", Nothing)


            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            'bubsca solicitaões de cadastro

            Dim DataOri As Date = "1111-11-11"

            Dim BUscaSolicitacaoMarkupProdutos = From sol In LqBase.Produtos
                                                 Where sol.Markup = 0
                                                 Select sol.IdProduto

            Dim BUscaSolicitacaoMarkupServiços = From sol In LqBase.Servicos
                                                 Where sol.Markup = 0
                                                 Select sol.IdServico

            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

            FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Carregando solicitações financeiras", 0, BUscaSolicitacaoMarkupProdutos.Count + BUscaSolicitacaoMarkupServiços.Count, Nothing)


            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            For Each row In BUscaSolicitacaoMarkupProdutos.ToList

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                'FrmSinc.Refresh()

            Next

            For Each row In BUscaSolicitacaoMarkupServiços.ToList

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                'FrmSinc.Refresh()

            Next

            If BUscaSolicitacaoMarkupProdutos.Count > 0 Then

                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                GestãoDeMarkupToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
                GestãoDeMarkupToolStripMenuItem.Enabled = True

            End If

            If BUscaSolicitacaoMarkupServiços.Count > 0 Then

                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                GestãoDeMarkupToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
                GestãoDeMarkupToolStripMenuItem.Enabled = True

            End If

            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

            FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Lendo solicitações do caixa", "", "", Nothing)

            'FrmSinc.Refresh()

            Dim BuscaOrçamentos = From orc In LqComercial.Orcamentos
                                  Where orc.Aprovado = True And orc.ValorRecebido = False
                                  Select orc.IdOrcamento, orc.IdCliente, orc.DataAprov, orc.ValorRecebido

            If BuscaOrçamentos.Count > 0 Then

                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                RecebimentoToolStripMenuItem1.Image = My.Resources.alert_icon_icons_com_52395
                RecebimentoToolStripMenuItem1.Enabled = True

            End If

            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

            FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Obtendo informações do servidor remoto", "", "", Nothing)


            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            'renderiza painel

            PnnPainelInferior.Size = New Size(PnnPainelInferior.Width, ((Me.Height - (PnnSuperior.Height + PnnPainelInferior.Height)) + PnnPainelInferior.Height) - 50)

            Dim GuardaIndex As Integer = FrmSinc.DtProdutos.Rows.Count - 1

            'Consultas iniciais

            VerificaUsuários()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VeirificaBancos()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaClientes()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaImagens()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaServicosNaoCadastrado()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            ProcuraProdutosNaoCadastrados()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaComercial()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaSolicitaçõesCotação()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaOrdemDeCompra_separacao()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaREcebimentos()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            verificaLiberacao()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaEngenharia()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaEngenhariaSolicitada()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaMarkup()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaLaudosSolicitar()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaFuncoesColaboradores()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaColaboradores()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaPagamentos()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            AfericaoValores()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaCotacaoOnLine()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            CarregaExpedicao()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            VerificaAtualCotac()

            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            UpPrecosProdutos()


            FrmSinc.ProgressBar1.Value += 1

            FrmSinc.Refresh()

            'desenha valores
            Popula_Grafico()

            FrmSinc.DtProdutos.Rows(GuardaIndex).Cells(0).Value = My.Resources.check_ok_accept_apply_1582


            FrmSinc.ProgressBar1.Value = 100

            FrmSinc.Refresh()

            LblUltimaAtualizacao.Text = "Sinc.: " & Now

            'Catch ex As Exception

            '    LblUltimaAtualizacao.Text = "Erro ao sincronizar com o servidor remoto"

            'End Try

            Me.WindowState = FormWindowState.Maximized

            'Me.Dispose()

            FrmSinc.Close()

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Public Sub VerificaAtualCotac()

        'atuliza item on line se houver

        LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro

        Dim BuscaCotacoes = From cot In LqFinanceiro.Cotacoes
                            Where cot.Comprado = False And cot.DataCotacao.Value.Date >= Today.Date.AddDays(-7)
                            Select cot.ValorCotado, cot.Markup, cot.IdProduto, cot.IdSolicitacaoCad

        For Each row In BuscaCotacoes.ToList

            If row.Markup > 0 Then

                If row.IdProduto <> 0 Then
                    Dim Vlr As Decimal = row.ValorCotado + (row.ValorCotado * (row.Markup / 100))

                    Dim baseUrl_Atualiza As String = "http://www.iarasoftware.com.br/atualiza_valor_cotacao_online.php?ChaveOficina=" & LblChaveEnc.Text & "&IdProdutoInterno=" & row.IdProduto & "&Valor=" & Vlr.ToString.Replace(",", ".")
                    Dim syncAtualiza = New WebClient()
                    Dim content_item_Atualiza = syncAtualiza.DownloadString(baseUrl_Atualiza)
                Else
                    Dim Vlr As Decimal = row.ValorCotado + (row.ValorCotado * (row.Markup / 100))

                    Dim baseUrl_Atualiza As String = "http://www.iarasoftware.com.br/atualiza_valor_cotacao_online.php?ChaveOficina=" & LblChaveEnc.Text & "&IdProdutoInterno=" & row.IdSolicitacaoCad & "&Valor=" & Vlr.ToString.Replace(",", ".")
                    Dim syncAtualiza = New WebClient()
                    Dim content_item_Atualiza = syncAtualiza.DownloadString(baseUrl_Atualiza)
                End If

            End If

        Next

    End Sub
    Public Sub VerificaPagamentos()

        ToolStripMenuItem5.Image = Nothing

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro

        Dim BuscaOrçamentos = From orc In LqFinanceiro.BalanceteFinanceiro
                              Where orc.Tipo = False And orc.DataBaixa = "1111-11-11" And orc.Vencimento <= Today.AddDays(10)
                              Select orc.Status, orc.IdVinculo, orc.Descricao, orc.IdFormaPg, orc.Valor, orc.Vencimento, orc.Identificador, orc.IdItemBalancete

        If BuscaOrçamentos.Count > 0 Then

            TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
            TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
            ToolStripMenuItem5.Image = My.Resources.alert_icon_icons_com_52395
            ToolStripMenuItem5.Enabled = True

        End If

    End Sub

    Public Sub VeirificaBancos()
        Dim baseUrl As String = "http://www.iarasoftware.com.br/lista_bancos.php"

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Bancos))(content)

        LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Obtendo informações dos bancos na base de dados", 0, read.Count, Nothing)

        FrmSinc.Refresh()

        If LqFinanceiro.Bancos.ToList.Count <> read.Count Then

            For Each row In read.ToList

                Dim _value As String = row.value

                Dim buscaBanco = From bcn In LqFinanceiro.Bancos
                                 Where bcn.value Like _value
                                 Select bcn.label, bcn.value

                If buscaBanco.Count = 0 Then

                    LqFinanceiro.InsereNovoBanco(row.value, row.label)

                End If

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                FrmSinc.Refresh()

            Next

        End If

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

    End Sub
    Public Sub CarregaExpedicao()

        Dim C As Integer = 0

        'busca itens do pedido 

        Dim baseUrlItens As String = "http://www.iarasoftware.com.br/consulta_itens_pedido_expedicao.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientItens = New WebClient()
        Dim contentItens = syncClientItens.DownloadString(baseUrlItens)

        Dim readItens = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Expedicao))(contentItens)

        For Each it In readItens.ToList

            Dim Status As String = ""
            Dim DataInicio As Date = it.DataSolicitacao & " " & it.HoraSolicitacao
            Dim UltimoStatus As Date
            Dim diasUltimo As Integer = 0
            Dim horasUltimo As Integer = 0
            Dim minutosUltimo As Integer = 0
            Dim segundosUltimo As Integer = 0

            If it.Status = 1 Then
                Status = "Aguardando confirmação de estoque"
                UltimoStatus = it.DataFinanceiroLib & " " & it.HoraFinanceiroLib
            ElseIf it.Status = 2 Then
                Status = "Aguardando separação de estoque"
                UltimoStatus = it.DataEstoqueValidado & " " & it.HoraEstoqueValidado
            ElseIf it.Status = 3 Then
                Status = "Aguardando coleta/retirada"
                UltimoStatus = it.DataSeparacao & " " & it.HoraSeparacao
            ElseIf it.Status = 4 Then
                Status = "Coletado, pedido sendo transportado"
                UltimoStatus = it.DataColeta & " " & it.HoraColeta
            ElseIf it.Status = 5 Then
                Status = "Pedido Entregue"
                UltimoStatus = it.DataColeta & " " & it.HoraColeta
            End If

            If it.Status < 5 Then
                C += 1
            End If

        Next

        If C > 0 Then

            TtEstoque.Image = My.Resources.alert_icon_icons_com_52395
            TtEstoque.TextAlign = ContentAlignment.MiddleRight
            ExpediçãoToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
            ExpediçãoToolStripMenuItem.Enabled = True
            TtEstoque.BackColor = Color.Gainsboro

            TtEstoque.Enabled = True
            ExpediçãoToolStripMenuItem.Enabled = True

        End If

    End Sub

    Public Sub ProcuraProdutosNaoCadastrados()

        'FrmSinc.Show()
        FrmSinc.Focus()

        'Me.Refresh()

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_produtos_base_local.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Produtos))(content)

        Dim BuscaSolicitacoesCad = From sol In LqOficina.SolicitacaoCadastroPeca
                                   Where sol.IdCodCad Like "*"
                                   Select sol.IdCodExt, sol.IdCodCad

        For Each row In read.ToList

            Dim IdFabricante_Enc As Integer = 0

            Dim IdModelo_Enc As Integer = 0

            Dim IdCategoria_enc As Integer = 0

            Dim IdSubCategoria_enc As Integer = 0

            Try
                Dim BuscaCategoria = From cad In LqBase.CategoriasProdutos
                                     Where cad.Descricao Like row.Categoria
                                     Select cad.IdCategoriaProduto

                If BuscaCategoria.Count = 0 Then
                    'cadastra fabircante para o veiculo
                    LqBase.InsereCategoriaProduto(row.Categoria)

                    Dim BuscaCategoriaNew = From cad In LqBase.CategoriasProdutos
                                            Where cad.Descricao Like row.Categoria
                                            Select cad.IdCategoriaProduto

                    IdCategoria_enc = BuscaCategoriaNew.First
                Else
                    IdCategoria_enc = BuscaCategoria.First
                End If
            Catch ex As Exception
                MsgBox(ex.Message & "-Fabricante")
            End Try

            Try
                Dim BuscaSubcategoriaCadastrado = From cad In LqBase.SubCategoriasProduto
                                                  Where cad.IdCategoria = IdCategoria_enc And cad.Descricao Like row.SubCAtegoria
                                                  Select cad.IdSubCategoria

                If BuscaSubcategoriaCadastrado.Count = 0 Then
                    'cadastra fabircante para o veiculo
                    LqBase.InsereSubcategoriaProduto(IdCategoria_enc, row.SubCAtegoria)

                    Dim BuscaSubCategoriaCadastrado_New = From cad In LqBase.SubCategoriasProduto
                                                          Where cad.IdCategoria = IdCategoria_enc And cad.Descricao Like row.SubCAtegoria
                                                          Select cad.IdSubCategoria

                    IdSubCategoria_enc = BuscaSubCategoriaCadastrado_New.First
                Else
                    IdSubCategoria_enc = BuscaSubcategoriaCadastrado.First
                End If

            Catch ex As Exception
                MsgBox(ex.Message & "-Modelo")
            End Try

            Try
                Dim BuscaFabricanteCadastrado = From cad In LqOficina.FabricantesVeiculo
                                                Where cad.Fabricante Like row.FabricanteVeic
                                                Select cad.Idfabricante



                If BuscaFabricanteCadastrado.Count = 0 Then
                    'cadastra fabircante para o veiculo
                    LqOficina.InsereFabricanteModelo(row.FabricanteVeic, Nothing)

                    Dim BuscaFabricanteCadastrado_New = From cad In LqOficina.FabricantesVeiculo
                                                        Where cad.Fabricante Like row.FabricanteVeic
                                                        Select cad.Idfabricante

                    IdFabricante_Enc = BuscaFabricanteCadastrado_New.First
                Else
                    IdFabricante_Enc = BuscaFabricanteCadastrado.First
                End If
            Catch ex As Exception
                MsgBox(ex.Message & "-Fabricante")
            End Try

            Try
                Dim BuscaModeloCadastrado = From cad In LqOficina.Modelos
                                            Where cad.IdFabricante = IdFabricante_Enc And cad.Modelo Like row.ModeloVeic & " " & row.AnoFab
                                            Select cad.IdModelo

                If BuscaModeloCadastrado.Count = 0 Then
                    'cadastra fabircante para o veiculo
                    LqOficina.InsereModeloVeiculo(IdFabricante_Enc, row.ModeloVeic, row.AnoFab, row.AnoMod)

                    Dim BuscaModeloCadastrado_New = From cad In LqOficina.Modelos
                                                    Where cad.IdFabricante = IdFabricante_Enc And cad.Modelo Like row.ModeloVeic & " " & row.AnoFab
                                                    Select cad.IdModelo

                    IdModelo_Enc = BuscaModeloCadastrado_New.First
                Else
                    IdModelo_Enc = BuscaModeloCadastrado.First
                End If

            Catch ex As Exception
                MsgBox(ex.Message & "-Modelo")
            End Try

            Dim IdProdutoConf As Integer = row.IdProdutoInterno
            Dim _IdCodExt As Integer = row.IdProdutoEst

            Dim Cadastrar As Boolean = True

            For Each linha In BuscaSolicitacoesCad.ToList

                If linha.IdCodExt = _IdCodExt And linha.IdCodCad <> 0 Then
                    Cadastrar = False
                End If

            Next

            'verifica se item ja consta como produto

            Dim BuscaProduto = From prod In LqBase.Produtos
                               Where prod.IdProdutoExt = _IdCodExt
                               Select prod.IdProduto

            If BuscaProduto.Count > 0 Then
                Cadastrar = False
            End If

            If Cadastrar = True Then

                Dim BuscaSolicitacoesCad_2 = From sol In LqOficina.SolicitacaoCadastroPeca
                                             Where sol.IdCodCad = 0 And sol.IdCodExt = _IdCodExt
                                             Select sol.IdCodExt, sol.IdCodCad, sol.Markup

                If BuscaSolicitacoesCad_2.Count = 0 Then

                    'cria associação
                    LqOficina.InsereSolicitacaoCadastroPeca(row.CodFabricante, row.Descricao, 0, Today.Date, Now.TimeOfDay, False, 0, Now.Date, Today.TimeOfDay, 0, IdCategoria_enc, IdSubCategoria_enc, IdModelo_Enc, 0, _IdCodExt, 0, row.Fabricante)
                    Dim VerificaCodAss = From cod In LqOficina.SolicitacaoCadastroPeca
                                         Where cod.IdCodExt = row.IdProdutoEst
                                         Select cod.IdSolicitacaoCadastro

                    'cria associação com o modelo 
                    LqOficina.InsereAssociacaoPecaModelo(0, VerificaCodAss.First, IdModelo_Enc)

                    'cria solicitacao de cotação para o item
                    LqFinanceiro.InsereNovaCotacao(IdUsuario, Today.Date, Now.TimeOfDay, 0, VerificaCodAss.First, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0)

                    'atualiza IdExterno

                    Dim baseUrl_Atualiza As String = "http://www.iarasoftware.com.br/atualiza_produtos_local.php?IdProdutoEst=" & row.IdProdutoEst & "&ChaveOficina=" & LblChaveEnc.Text & "&Descricao=" & row.Descricao & "&Categoria=" & row.Categoria & "&SubCAtegoria=" & row.SubCAtegoria & "&Fabricante=" & row.Fabricante & "&IdProdutoINterno=S" & LqOficina.SolicitacaoCadastroPeca.ToList.Last.IdSolicitacaoCadastro
                    Dim syncAtualiza = New WebClient()
                    Dim content_item_Atualiza = syncAtualiza.DownloadString(baseUrl_Atualiza)

                    'insere a solicitação no banco interno para cadastro
                    If IdProdutoConf = 0 Then

                        TtEstoque.Image = My.Resources.alert_icon_icons_com_52395
                        TtEstoque.TextAlign = ContentAlignment.MiddleRight
                        ToolStripMenuItem1.Image = My.Resources.alert_icon_icons_com_52395
                        TtEstoque.BackColor = Color.Gainsboro

                        TtEstoque.Enabled = True
                        ToolStripMenuItem1.Enabled = True

                    End If


                End If

            End If

        Next

        'verifica solicitacoes

        Dim BuscaSolicitacoesCad_Todas = From sol In LqOficina.SolicitacaoCadastroPeca
                                         Where sol.IdCodCad = 0
                                         Select sol.IdCodExt, sol.IdCodCad

        If BuscaSolicitacoesCad_Todas.Count > 0 Then

            TtEstoque.Image = My.Resources.alert_icon_icons_com_52395
            TtEstoque.TextAlign = ContentAlignment.MiddleRight
            ToolStripMenuItem1.Image = My.Resources.alert_icon_icons_com_52395
            TtEstoque.BackColor = Color.Gainsboro

            TtEstoque.Enabled = True
            ToolStripMenuItem1.Enabled = True

        End If

    End Sub

    Public Sub VerificaSolicitaçõesCotação()

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro

        Dim BuscaCotacoes = From cot In LqFinanceiro.Cotacoes
                            Where cot.IdCotador = 0
                            Select cot.IdCotacao

        If BuscaCotacoes.Count > 0 Then

            TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
            TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
            CotaçõesToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
            TtFinanceiro.BackColor = Color.Gainsboro
            CotaçõesToolStripMenuItem.Enabled = True

        End If

    End Sub

    Public Sub VerificaFuncoesColaboradores()

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_funcoes_todos_local.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Funcoes))(content)

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Lendo funções de trabalho.", "0", read.Count, Nothing)

        FrmSinc.Refresh()

        For Each row In read.ToList

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = ConnectionStringBase

            If row.IdVinculoFuncao = 0 Then

                'insere nova função
                Dim Remuneracao As Decimal = row.RemuneracaoPaga.Replace(".", ",")
                LqBase.InsereNovoCargo(row.DescricaoFuncao, Remuneracao, 0, True, False, 20, row.IdFuncao)

                'atualiza o IdInserido
                Dim BuscaUltimo = From bs In LqBase.Cargos
                                  Where bs.Descricao Like row.DescricaoFuncao
                                  Select bs.IdCargo
                                  Order By IdCargo Descending

                If BuscaUltimo.Count > 0 Then
                    Dim baseUrlAtualiza As String = "http://www.iarasoftware.com.br/atualiza_vinculo_funcao_colaborador.php?ChaveOficina=" & LblChaveEnc.Text & "&IdFuncao=" & row.IdFuncao & "&IdVinculoFuncao=" & BuscaUltimo.First

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientAtualiza = New WebClient()
                    Dim contentAtualiza = syncClientAtualiza.DownloadString(baseUrlAtualiza)
                Else

                End If

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                    FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                    FrmSinc.Refresh()

                End If

        Next

    End Sub

    Public Sub VerificaColaboradores()

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_usuarios_todos_local.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Colaboradores))(content)

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Lendo colaboradores.", "0", read.Count, Nothing)

        FrmSinc.Refresh()

        For Each row In read.ToList

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = ConnectionStringBase

            If row.IdVinculoExt = 0 Then

                'insere nova função

                LqBase.InsereColaborador(row.NomeCompleto, row.Documento, "", "", "", "", 0, "", 0, "", "", "", "", "", "", row.Celular, row.email, "", "", "", "", "", "", Nothing, 0, row.Cargo, 0, "", row.IdUsuario, 0, "", 0, "", "", "", False, "", "")

                'atualiza o IdInserido
                Dim BuscaUltimo = From bs In LqBase.Funcionarios
                                  Where bs.NomeCompleto Like row.NomeCompleto
                                  Select bs.IdFuncionario

                Dim baseUrlAtualiza As String = "http://www.iarasoftware.com.br/atualiza_vinculo_colaborador_local.php?ChaveOficina=" & LblChaveEnc.Text & "&IdUsuario=" & row.IdUsuario & "&IdVinculoExt=" & BuscaUltimo.First

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientAtualiza = New WebClient()
                Dim contentAtualiza = syncClientAtualiza.DownloadString(baseUrlAtualiza)

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                FrmSinc.Refresh()

            End If

        Next

    End Sub

    Public Sub VerificaLaudosSolicitar()

        'busca laudos possíveis

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = ConnectionStringOficina

        Dim BuscaImagens = From img In LqOficina.ImagemVeiculosColetado
                           Where img.Descricao Like "IMG_REP_CNC - Final"
                           Select img.IdSolicitacao, img.IdVeiculo, img.Descricao, img.ImagemColetadoUrlFim, img.IdCliente

        Dim PlacaList As New ListBox

        Dim ExibirAlerta As Integer = 0

        For Each row In BuscaImagens.ToList

            If Not PlacaList.Items.Contains(row.IdVeiculo & "-" & row.IdCliente) Then

                PlacaList.Items.Add(row.IdVeiculo & "-" & row.IdCliente)

                Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                                   Where veic.IdVeiculo = row.IdVeiculo
                                   Select veic.Placa, veic.Modelo

                If BuscaVeiculo.First.Modelo <> "" Then
                    'busca no servidor on line o status 

                    Dim baseUrlSolicitaLaudo As String = "http://www.iarasoftware.com.br/consulta_laudo.php?ChaveOficina=" & LblChaveEnc.Text & "&IdSolicitacaoInt=" & row.IdCliente

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

                            'ExibirAlerta += 1

                            Dim baseUrlSolR As String = "http://www.iarasoftware.com.br/consulta_solicitacao_review.php?IdItemLaudo=" & IdLaudoEnc & "&ChaveOficina=" & LblChaveEnc.Text & "&ChavePrestador=" & rowLaudo.ChavePrestador
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

                                            ExibirAlerta += 1

                                        Else

                                            'DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(9).Value = ImageList2.Images(8)
                                            'DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(9).Value = "Solicitação expirada"

                                        End If

                                    End While

                                Else

                                    ExibirAlerta += 1

                                End If

                            Next

                        End If

                    Next

                    If IdLaudoEnc = 0 Then
                        ExibirAlerta += 1
                    Else

                    End If

                End If

            End If

        Next

        If ExibirAlerta > 0 Then

            TtOficina.Image = My.Resources.alert_icon_icons_com_52395
            TtOficina.TextAlign = ContentAlignment.MiddleRight
            LaudosPericiaisToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
            LaudosPericiaisToolStripMenuItem.Enabled = True

        End If

    End Sub
    Public Sub VerificaOrdemDeCompra_separacao()

        ComprasToolStripMenuItem.Image = Nothing
        TtFinanceiro.BackColor = Color.Gainsboro

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_ordem_compra.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.OrcamentoAprovado))(content)

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Ordens de compra", 0, read.Count, Nothing)

        FrmSinc.Refresh()

        Try

            ' Cria o serializados Json e trata a resposta
            Dim serializer As New DataContractJsonSerializer(GetType(Classe_Veiculos_Oficina.OrcamentoAprovado))
            Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                ' deserializa o objeto JSON usando o tipo de dados
                Dim weatherData = DirectCast(serializer.ReadObject(ms), Classe_Veiculos_Oficina.OrcamentoAprovado)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        'valida informaçoes

        Dim LqEstoque As New LqEstoqueLocalDataContext

        LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro

        LqBase.Connection.ConnectionString = ConnectionStringBase

        LqEstoque.Connection.ConnectionString = ConnectionStringEstoqueLocal

        For Each row In read.ToList

            'Busca codigo interno

            Dim IdProdutoRead As Integer = row.IdItem

            Dim BuscaSolicitacoGerada = From sol In LqEstoque.SolicitacaoProdutosEstoque
                                        Where sol.Status = False And sol.IdCodExterno = 0
                                        Select sol.IdSolicitacao

            If BuscaSolicitacoGerada.Count = 0 Then

                Dim BuscaProduto = From prod In LqBase.Produtos
                                   Where prod.IdProdutoExt = IdProdutoRead
                                   Select prod.IdProduto

                Dim COUNT As Integer = BuscaProduto.Count

                If BuscaProduto.Count > 0 Then

                    'verifica se o item possui estoque

                    Dim BuscaEstoqueItem = From Item In LqEstoque.Armazenagem
                                           Where Item.IdProduto = BuscaProduto.First
                                           Select Item.Qt

                    Dim QtEstoque As Decimal = 0

                    For Each it In BuscaEstoqueItem.ToList
                        QtEstoque += it
                    Next

                    If QtEstoque = 0 Then

                        'verifica se o item já foi solicitado

                        Dim BuscaSolicitaco = From Item In LqFinanceiro.SolicitacoesCompraFinanceiro
                                              Where Item.IdProduto = BuscaProduto.First And Item.IdAutorizador = 0
                                              Select Item.IdAutorizador

                        If BuscaSolicitaco.Count = 0 Then

                            'bate no banco e verifica se item já foi autorzado mas não foi comprado

                            Dim BuscaSolicitacoComprado = From Item In LqFinanceiro.SolicitacoesCompraFinanceiro
                                                          Where Item.IdProduto = BuscaProduto.First And Item.IdAutorizador > 0 And Item.NF = 0
                                                          Select Item.IdAutorizador

                            If BuscaSolicitacoComprado.Count = 0 Then

                                'Verifica se há uma solicitação de cotação para o item

                                Dim BuscaEstoque = From est In LqFinanceiro.Cotacoes
                                                   Where est.IdProduto = BuscaProduto.First And est.IdCotador = 0
                                                   Select est.IdSolicitacaoCad

                                Dim IDCotacao As Integer = 0

                                If BuscaEstoque.Count > 0 Then
                                    IDCotacao = BuscaEstoque.First
                                End If
                                'Insere nova solicitação de Compra

                                Dim Qtdade As Integer = row.Qt

                                LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(BuscaProduto.First, Qtdade, IDCotacao, Now.Date, Now.TimeOfDay, IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, 0)

                                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                                FrmSinc.Refresh()

                                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                                ComprasToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
                                TtFinanceiro.BackColor = Color.Gainsboro
                                ComprasToolStripMenuItem.Enabled = True

                            End If


                        End If

                    End If

                ElseIf BuscaProduto.Count = 0 Then

                    'insere como solicitacao

                    Dim BuscaSolicitacaoCad = From prod In LqOficina.SolicitacaoCadastroPeca
                                              Where prod.IdCodExt = IdProdutoRead
                                              Select prod.IdSolicitacaoCadastro

                    'bate no banco e verifica se item já foi autorzado mas não foi comprado

                    Dim BuscaSolicitacoComprado = From Item In LqFinanceiro.SolicitacoesCompraFinanceiro
                                                  Where Item.IdSolicitacaoCad = BuscaSolicitacaoCad.First And Item.IdAutorizador > 0 And Item.NF = 0
                                                  Select Item.IdAutorizador

                    If BuscaSolicitacoComprado.Count = 0 Then

                        If BuscaSolicitacaoCad.Count > 0 Then

                            'verifica se o item já foi solicitado

                            Dim BuscaSolicitaco = From Item In LqFinanceiro.SolicitacoesCompraFinanceiro
                                                  Where Item.IdSolicitacaoCad = BuscaSolicitacaoCad.First And Item.IdAutorizador = 0
                                                  Select Item.IdAutorizador, Item.Qt, Item.IdSolicitacaoCompra

                            If BuscaSolicitaco.Count = 0 Then

                                'Verifica se há uma solicitação de cotação para o item

                                Dim BuscaEstoque = From est In LqFinanceiro.Cotacoes
                                                   Where est.IdSolicitacaoCad = BuscaSolicitacaoCad.First And est.IdCotador = 0
                                                   Select est.IdSolicitacaoCad

                                Dim IDCotacao As Integer = 0

                                If BuscaEstoque.Count > 0 Then
                                    IDCotacao = BuscaEstoque.First
                                End If
                                'Insere nova solicitação de Compra

                                Dim Qtdade As Integer = row.Qt

                                LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(0, Qtdade, IDCotacao, Now.Date, Now.TimeOfDay, IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, BuscaSolicitacaoCad.First)

                                Dim UltimoId As Integer = LqFinanceiro.SolicitacoesCompraFinanceiro.ToList.Last.IdSolicitacaoCompra

                                'qtualiza ID solicitacao on line

                                Dim baseUrlAtualizaItem As String = "http://www.iarasoftware.com.br/atualiza_solicitacao_produto_local.php?ChaveOficina=" & LblChaveEnc.Text & "&IdItemOrcamento=" & row.IdItemOrcamento & "&IdVincSolicitacao=" & UltimoId

                                'carrega informações no site

                                ' Chamada sincrona
                                Dim syncClientAtualizaItem = New WebClient()
                                Dim contentAtualizaItem = syncClientAtualizaItem.DownloadString(baseUrlAtualizaItem)

                                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                                FrmSinc.Refresh()

                                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                                ComprasToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
                                TtFinanceiro.BackColor = Color.Gainsboro
                                ComprasToolStripMenuItem.Enabled = True

                            Else

                                'atualiza quantidade solicitada

                                Dim Qtdade As Integer = row.Qt
                                Dim Qt As Decimal = BuscaSolicitaco.First.Qt
                                Dim Res As Integer = 0
                                Res = Qtdade + Qt

                                LqFinanceiro.AtualizaSolicitacaoQtCompraProdutos(BuscaSolicitaco.First.IdSolicitacaoCompra, Res)
                                'qtualiza ID solicitacao on line

                                Dim baseUrlAtualizaItem As String = "http://www.iarasoftware.com.br/atualiza_solicitacao_produto_local.php?ChaveOficina=" & LblChaveEnc.Text & "&IdItemOrcamento=" & row.IdItemOrcamento & "&IdVincSolicitacao=" & BuscaSolicitaco.First.IdSolicitacaoCompra

                                'carrega informações no site

                                ' Chamada sincrona
                                Dim syncClientAtualizaItem = New WebClient()
                                Dim contentAtualizaItem = syncClientAtualizaItem.DownloadString(baseUrlAtualizaItem)

                                FrmSinc.Refresh()

                            End If

                        End If

                    End If

                End If

            Else

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                FrmSinc.Refresh()

            End If

        Next

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

        'busca solicitacaoes de compra em aberto

        Dim BuscaSolicitacaoCompraIt = From sol In LqFinanceiro.SolicitacoesCompraFinanceiro
                                       Where sol.IdAutorizador = 0
                                       Select sol.IdSolicitacaoCad

        If BuscaSolicitacaoCompraIt.Count > 0 Then

            If TtFinanceiro.TextAlign = ContentAlignment.MiddleLeft Then
                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
            End If

            ComprasToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
            TtFinanceiro.BackColor = Color.Gainsboro
            ComprasToolStripMenuItem.Enabled = True

        Else

            ComprasToolStripMenuItem.Image = Nothing
            ComprasToolStripMenuItem.Enabled = False

        End If


    End Sub

    Private Sub VerificaREcebimentos()

        Dim BuscaCompras = From cmp In LqFinanceiro.SolicitacoesCompraFinanceiro
                           Where cmp.IdAutorizador > 0 And cmp.Recebido = False
                           Select cmp.IdCotacao, cmp.Qt, cmp.DataAutorizacao

        If BuscaCompras.Count > 0 Then

            TtEstoque.Image = My.Resources.alert_icon_icons_com_52395
            TtEstoque.TextAlign = ContentAlignment.MiddleRight
            RecebimentoToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395

            TtEstoque.Enabled = True
            RecebimentoToolStripMenuItem.Enabled = True

        End If

    End Sub

    Private Sub VerificaServicosNaoCadastrado()

        'busca orcamentos abertos 

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_servicos_ncad.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        'Try

        'Dim arquivoJson = JObject.Parse(content)

        ' Cria o serializados Json e trata a resposta
        Dim serializer As New DataContractJsonSerializer(GetType(Classe_Veiculos_Oficina.Servicos))
            Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                ' deserializa o objeto JSON usando o tipo de dados
                Dim weatherData = DirectCast(serializer.ReadObject(ms), Classe_Veiculos_Oficina.Servicos)

                'Return weatherData
            End Using
        'Catch ex As Exception
        '    Throw ex
        'End Try

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Servicos))(content)

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Solicitação de cadastro de novo serviço", 0, read.Count, Nothing)

        FrmSinc.Refresh()

        'insere e compara os dados

        For Each row In read.ToList

            'cadastra o servico no banco de dados e atualiza no cloud

            Dim _TME As Date = Today.Date & " 00:00:00"
            _TME = _TME.AddMinutes(row.TMA)

            LqBase.InsereNovoServico(row.Descricao, _TME.TimeOfDay, True, 0, 0, row.VlrSugerido.Replace(".", ","), "", 0, 0, row.IdServico)

            Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

            FrmSinc.Refresh()

            'Busca ultimo Id
            Dim BuscaUltimo = From serv In LqBase.Servicos
                              Where serv.IdServicoInt = row.IdServico
                              Select serv.IdServico

            Dim UltimoId As String = BuscaUltimo.First

            'atualiza catalogo online

            Dim baseUrl_Update As String = "http://www.iarasoftware.com.br/atualiza_codservico_int.php?ChaveOficina=" & LblChaveEnc.Text & "&IdServicoInt=" & UltimoId & "&IdServico=" & row.IdServico

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient_Update = New WebClient()
            Dim content_Update = syncClient_Update.DownloadString(baseUrl_Update)

        Next

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

    End Sub

    Private Sub VerificaUsuários()

        'verifica lista de clientes e atualiza ou cria

        Dim baseUrl As String = "http://www.iarasoftware.com.br/read_usuarios_local.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.UsuariosColetados))(content)

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Usuários", 0, read.Count, Nothing)

        FrmSinc.Refresh()

        Try

            ' Cria o serializados Json e trata a resposta
            Dim serializer As New DataContractJsonSerializer(GetType(Classe_Veiculos_Oficina.UsuariosColetados))
            Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                ' deserializa o objeto JSON usando o tipo de dados
                Dim weatherData = DirectCast(serializer.ReadObject(ms), Classe_Veiculos_Oficina.UsuariosColetados)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        LqBase.Connection.ConnectionString = ConnectionStringBase

        For Each row In read.ToList

            LqBase.InsereColaborador(row.NomeCompleto, row.Documento, "", "", "", "", 0, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", Nothing, 0, row.Cargo, 0, "", row.IdUsuario, 0, "", 0, "", "", "", False, "", "")

            Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

            FrmSinc.Refresh()


            Dim BuscaUltimoId = From ult In LqBase.Funcionarios
                                Where ult.IdFuncionario Like "*"
                                Select ult.IdFuncionario
                                Order By IdFuncionario Descending

            Dim UltimoID As Integer = BuscaUltimoId.First

            'atualiza cloud

            Dim baseUrl_atualiza As String = "http://www.iarasoftware.com.br/atualiza_idusuariointerno_local.php?ChaveOficina=" & LblChaveEnc.Text & "&IdUsuario=" & row.IdUsuario & "&IdVinculoExt=" & BuscaUltimoId.First

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient_atualiza = New WebClient()
            Dim content_atualiza = syncClient_atualiza.DownloadString(baseUrl_atualiza)

        Next

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

    End Sub

    Private Sub VerificaClientes()

        'verifica lista de clientes e atualiza ou cria

        Dim baseUrl As String = "http://www.iarasoftware.com.br/read_clientes_local.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Clientes))(content)

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Clientes", 0, read.Count, Nothing)

        FrmSinc.Refresh()

        Try

            ' Cria o serializados Json e trata a resposta
            Dim serializer As New DataContractJsonSerializer(GetType(Classe_Veiculos_Oficina.Clientes))
            Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                ' deserializa o objeto JSON usando o tipo de dados
                Dim weatherData = DirectCast(serializer.ReadObject(ms), Classe_Veiculos_Oficina.Clientes)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        LqBase.Connection.ConnectionString = ConnectionStringBase

        For Each row In read.ToList

            Dim TipoPersona As Boolean

            If row.Doc.Length = 11 Then
                TipoPersona = True
            Else
                TipoPersona = False
            End If

            LqBase.InsereCliente(row.NomeCliente, row.Doc, "", TipoPersona, row.cep, 0, "", row.numero, row.complemento, "", "", "", "", row.celular, row.celular, row.email, row.IdClienteN, "")

            Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

            FrmSinc.Refresh()

            Dim UltimoID As Integer = LqBase.Clientes.ToList.Last.IdCliente

            'atualiza cloud

            Dim baseUrl_atualiza As String = "http://www.iarasoftware.com.br/atualiza_idclienteinterno_local.php?ChaveOficina=" & LblChaveEnc.Text & "&IdClienteInterno=" & UltimoID & "&Doc=" & row.Doc

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient_atualiza = New WebClient()
            Dim content_atualiza = syncClient_atualiza.DownloadString(baseUrl_atualiza)

        Next

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

    End Sub

    Private Declare Function URLDownloadToFile Lib "urlmon" _
                       Alias "URLDownloadToFileA" (ByVal pCaller As Long,
                       ByVal szURL As String, ByVal szFileName As String,
                       ByVal dwReserved As Long, ByVal lpfnCB As Long) As Long

    Private Sub VerificaEngenharia()

        Dim baseUrlSolicitaLaudo As String = "http://www.iarasoftware.com.br/consulta_laudo_todos.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientSolicitaLaudo = New WebClient()
        Dim contentSolicitaLaudo = syncClientSolicitaLaudo.DownloadString(baseUrlSolicitaLaudo)
        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Laudos))(contentSolicitaLaudo)

        Dim LstLaudos As New ListBox

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Verificando laudos a serem solicitados", 0, read.Count, Nothing)

        FrmSinc.Refresh()

        For Each row In read.ToList

            LstLaudos.Items.Add(row.IdLaudo)

            Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1
            FrmSinc.Refresh()

        Next

        If LstLaudos.Items.Count > 0 Then

            TtOficina.Image = My.Resources.alert_icon_icons_com_52395
            TtOficina.TextAlign = ContentAlignment.MiddleRight
            LaudosPericiaisToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
            LaudosPericiaisToolStripMenuItem.Enabled = True

        End If

        'verifica laudos no sistema

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = ConnectionStringOficina

        Dim BuscaImagens = From img In LqOficina.ImagemVeiculosColetado
                           Where img.ImagemColetadoUrlFim.ToString.Length > 0
                           Select img.IdSolicitacao, img.IdVeiculo

        Dim PlacaList As New ListBox

        For Each row In BuscaImagens.ToList

            If Not PlacaList.Items.Contains(row.IdVeiculo & "-" & row.IdSolicitacao) Then

                Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                                   Where veic.IdVeiculo = row.IdVeiculo
                                   Select veic.Placa, veic.Modelo

                'busca no servidor on line o status 

                Dim baseUrlSolicitaLaudoTodos As String = "http://www.iarasoftware.com.br/consulta_laudo.php?ChaveOficina=" & LblChaveEnc.Text & "&IdSolicitacaoInt=" & row.IdSolicitacao

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientSolicitaLaudoTodos = New WebClient()
                Dim contentSolicitaLaudoTodos = syncClientSolicitaLaudoTodos.DownloadString(baseUrlSolicitaLaudoTodos)
                Dim readTodos = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.LaudosEncontrados))(contentSolicitaLaudoTodos)

                Dim IdLaudoEnc As Integer = 0
                Dim Status As String = ""

                For Each rowLaudo In readTodos.ToList

                    IdLaudoEnc = rowLaudo.IdLaudo
                    Status = rowLaudo.Status

                Next

                If IdLaudoEnc = 0 Then

                    TtOficina.Image = My.Resources.alert_icon_icons_com_52395
                    TtOficina.TextAlign = ContentAlignment.MiddleRight
                    LaudosPericiaisToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
                    LaudosPericiaisToolStripMenuItem.Enabled = True

                Else

                    If Status = 0 Then

                    End If

                End If

                PlacaList.Items.Add(row.IdVeiculo & "-" & row.IdSolicitacao)

            End If

        Next


        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

    End Sub
    Private Sub VerificaEngenhariaSolicitada()

        Dim baseUrlSolicitaLaudo As String = "http://www.iarasoftware.com.br/consulta_laudo_avaliar.php?ChavePrestador=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientSolicitaLaudo = New WebClient()
        Dim contentSolicitaLaudo = syncClientSolicitaLaudo.DownloadString(baseUrlSolicitaLaudo)
        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Laudos))(contentSolicitaLaudo)

        Dim LstLaudos As New ListBox

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Verificando laudos a serem avaliados", 0, read.Count, Nothing)

        FrmSinc.Refresh()

        For Each row In read.ToList

            LstLaudos.Items.Add(row.IdLaudo)

            'verifica se item existe no banco

            Dim BuscaLaudos = From lau In LqOficina.LaudosTecnicos
                              Where lau.IdLaudoExt = row.IdLaudo
                              Select lau.IdLaudoTecnico

            If BuscaLaudos.Count = 0 Then

                'cadastra no banco de dados local os dados da imagem e do laudo solicitado

                Dim HoraSolicitacaoEnc As Date = row.DataSolicitacao & " " & row.HoraSolicitacao

                LqOficina.InsereNovoLaudoTecnico(LblChaveEnc.Text, row.NomeCliente, row.Doc, Today.Date, Now.TimeOfDay, row.DataSolicitacao, HoraSolicitacaoEnc.TimeOfDay, "1111-11-11", Today.TimeOfDay, False, False, 0, row.IdLaudo, row.PlacaVeiculo, row.ModeloVeiculo)

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1
                FrmSinc.Refresh()

                'insere item do laudo

                Dim baseUrlSolicitaItemLaudo As String = "http://www.iarasoftware.com.br/consulta_itens_laudos_tecnicos.php?ChavePrestador=" & LblChaveEnc.Text & "&ChaveOficina=" & row.ChaveOficina & "&IdLaudo=" & row.IdLaudo

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientSolicitaItemLaudo = New WebClient()
                Dim contentSolicitaItemLaudo = syncClientSolicitaItemLaudo.DownloadString(baseUrlSolicitaItemLaudo)
                Dim readItem = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItemsLaudos))(contentSolicitaItemLaudo)

                For Each row0 In readItem.ToList

                    'cadastra no banco de dados local os dados da imagem e do laudo solicitado

                    LqOficina.InsereNovoItemLaudoTecnico(row.IdLaudo, row0.DescricaoItem, 0, row.ChaveOficina, LblChaveEnc.Text, row0.ImgPcUsadaUrl, row0.ImgPcNovaUrl, row0.IdItemLaudo, row0.NumNf, row0.ItemNF, row0.IdFornecedor)

                Next

            Else

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1
                FrmSinc.Refresh()

                'atualiza numero da nota fiscal

                Dim baseUrlSolicitaItemLaudo As String = "http://www.iarasoftware.com.br/consulta_itens_laudos_tecnicos.php?ChavePrestador=" & LblChaveEnc.Text & "&ChaveOficina=" & row.ChaveOficina & "&IdLaudo=" & row.IdLaudo

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientSolicitaItemLaudo = New WebClient()
                Dim contentSolicitaItemLaudo = syncClientSolicitaItemLaudo.DownloadString(baseUrlSolicitaItemLaudo)
                Dim readItem = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItemsLaudos))(contentSolicitaItemLaudo)

                For Each row0 In readItem.ToList

                    'cadastra no banco de dados local os dados da imagem e do laudo solicitado

                    LqOficina.AtualizaNfLaudo(row0.IdItemLaudo, row0.NumNf)

                Next

            End If

        Next

        If LstLaudos.Items.Count > 0 Then

            ToolStripDropDownButton1.Image = My.Resources.alert_icon_icons_com_52395
            ToolStripDropDownButton1.TextAlign = ContentAlignment.MiddleRight
            ToolStripMenuItem11.Image = My.Resources.alert_icon_icons_com_52395
            ToolStripMenuItem11.Enabled = True

        End If

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

    End Sub
    Private Sub VerificaImagens()

        'verifica lista de clientes e atualiza ou cria

        Dim baseUrl As String = "http://www.iarasoftware.com.br/read_imagens_local.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ImagensVeiculo))(content)

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Imagens encontradas", 0, read.Count, Nothing)

        FrmSinc.Refresh()

        Try

            ' Cria o serializados Json e trata a resposta
            Dim serializer As New DataContractJsonSerializer(GetType(Classe_Veiculos_Oficina.ImagensVeiculo))
            Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                ' deserializa o objeto JSON usando o tipo de dados
                Dim weatherData = DirectCast(serializer.ReadObject(ms), Classe_Veiculos_Oficina.ImagensVeiculo)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        LqBase.Connection.ConnectionString = ConnectionStringBase

        LqOficina.Connection.ConnectionString = ConnectionStringOficina

        For Each row In read.ToList

            'verifica se o veiculo existe no banco de dados

            Dim BuscaIdVeiculo = From veic In LqOficina.Veiculos
                                 Where veic.IdVeiculoExt = row.IdVeiculo
                                 Select veic.IdVeiculo

            Dim _IdVeiculo As Integer

            If BuscaIdVeiculo.Count > 0 Then
                _IdVeiculo = BuscaIdVeiculo.First
            Else
                'cadastra um novo veiculo para o cliente

                Dim BuscaFabricante = From fab In LqOficina.FabricantesVeiculo
                                      Where fab.Fabricante Like row.Fabricante
                                      Select fab.Idfabricante

                Dim _IdFabricante As Integer = 0
                If BuscaFabricante.Count > 0 Then
                    _IdFabricante = BuscaFabricante.First
                Else
                    'cadastra fabricante
                    LqOficina.InsereFabricanteModelo(row.Fabricante, Nothing)
                    _IdFabricante = LqOficina.FabricantesVeiculo.ToList.Last.Idfabricante
                End If

                Dim BuscaModelos = From fab In LqOficina.Modelos
                                   Where fab.IdFabricante = _IdFabricante And fab.Modelo Like row.Modelo
                                   Select fab.IdModelo

                Dim _IdModelo As Integer = 0
                If BuscaModelos.Count > 0 Then
                    _IdModelo = BuscaModelos.First
                Else
                    'cadastra fabricante
                    LqOficina.InsereModeloVeiculo(_IdFabricante, row.Modelo, "", "")
                    _IdModelo = LqOficina.Modelos.ToList.Last.IdModelo
                End If

                Dim BuscaCor = From fab In LqOficina.CorModelo
                               Where fab.IdModelo = _IdModelo And fab.Cor Like row.Cor
                               Select fab.IdModelo

                Dim _IdCor As Integer = 0
                If BuscaCor.Count > 0 Then
                    _IdCor = BuscaCor.First
                Else
                    'cadastra fabricante
                    LqOficina.InsereCorFabricante(_IdModelo, row.Cor)
                    _IdCor = LqOficina.CorModelo.ToList.Last.IdCor
                End If

                Dim _IdCliente As Integer = row.IdCliente

                Dim Ano As Integer = 0

                If row.AnoMod <> "" Then
                    Ano = row.AnoMod
                End If

                LqOficina.InsereNovoVeiculo(_IdCliente, row.Placa, _IdFabricante, row.Fabricante, _IdModelo, row.Modelo _
                                            , 0, row.Versao, "", row.Chassi, Ano, Ano, _IdCor, row.Cor, row.IdVeiculo)

                _IdVeiculo = LqOficina.Veiculos.ToList.Last.IdVeiculo

            End If

            'busca imagem e atualiza na base

            If row.ImgFim <> "ND" Then
                Dim baseUrlImagemFim As String = "http://www.iarasoftware.com.br/" & row.ImgFim

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagemFim = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim streamFim As Stream = syncClientImagemFim.OpenRead(baseUrlImagemFim)

                Dim imgFim As Image = Image.FromStream(streamFim)

                'atualiza vinculo on line
                Dim arrImageFim() As Byte
                Dim strImageFim As String
                Dim myMsFim As New IO.MemoryStream
                '5rt3w6e5,gq6KL
                If Not IsNothing(imgFim) Then
                    imgFim.Save(myMsFim, imgFim.RawFormat)
                    arrImageFim = myMsFim.GetBuffer
                    strImageFim = "?"
                Else
                    arrImageFim = Nothing
                    strImageFim = "NULL"
                End If

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & row.lcl_arq

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                'atualiza vinculo on line
                Dim arrImage() As Byte
                Dim strImage As String
                Dim myMs As New IO.MemoryStream
                '5rt3w6e5,gq6KL
                If Not IsNothing(img) Then
                    img.Save(myMs, img.RawFormat)
                    arrImage = myMs.GetBuffer
                    strImage = "?"
                Else
                    arrImage = Nothing
                    strImage = "NULL"
                End If
                'insere image do veículo no banco local

                LqOficina.InsereImagemColetada(row.Categoria & " - " & row.Subcateogira, row.lcl_arq, arrImage, row.ImgFim, arrImageFim, _IdVeiculo, row.IdSolicitacao, row.IdCliente, row.IdImagemVeiculo)

            Else

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & row.lcl_arq

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                'atualiza vinculo on line
                Dim arrImage() As Byte
                Dim strImage As String
                Dim myMs As New IO.MemoryStream
                '5rt3w6e5,gq6KL
                If Not IsNothing(img) Then
                    img.Save(myMs, img.RawFormat)
                    arrImage = myMs.GetBuffer
                    strImage = "?"
                Else
                    arrImage = Nothing
                    strImage = "NULL"
                End If
                'insere image do veículo no banco local

                LqOficina.InsereImagemColetada(row.Categoria & " - " & row.Subcateogira, row.lcl_arq, arrImage, "", Nothing, _IdVeiculo, row.IdSolicitacao, row.IdCliente, row.IdImagemVeiculo)

            End If

            Dim _IdImagemInserida As Integer = LqOficina.ImagemVeiculosColetado.ToList.Last.IdImagemColetada

            'atualiza vinculo

            Dim baseUrlAtualiza As String = "http://www.iarasoftware.com.br/atualiza_idimagemveiculo_desk.php?ChaveOficina=" & LblChaveEnc.Text & "&IdImagemVeiculo=" & row.IdImagemVeiculo & "&IdVinculoInt=" & _IdImagemInserida

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientAtualiza = New WebClient()
            Dim contentAtualiza = syncClientAtualiza.DownloadString(baseUrlAtualiza)

            '

            Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

            FrmSinc.Refresh()

        Next

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

    End Sub
    Private Sub VerificaMarkup()


        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = ConnectionStringBase

        Dim BuscaProdutos = From prod In LqBase.Produtos
                            Where prod.IdProduto Like "*"
                            Select prod.IdProduto, prod.Descricao, prod.Fabricante, prod.Markup

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Verificando markup", 0, BuscaProdutos.Count, Nothing)

        FrmSinc.Refresh()

        For Each row In BuscaProdutos.ToList

            If row.Markup = 0 Then

                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                GestãoDeMarkupToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
                GestãoDeMarkupToolStripMenuItem.Enabled = True

            End If

            Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

            FrmSinc.Refresh()

        Next

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = ConnectionStringOficina

        Dim BuscaSolicitacoes = From prod In LqOficina.SolicitacaoCadastroPeca
                                Where prod.IdCodCad = 0
                                Select prod.IdSolicitacaoCadastro, prod.Descricao, prod.Markup, prod.Fabricante

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Verificando markup (Solicitações de cadastro)", 0, BuscaSolicitacoes.Count, Nothing)

        FrmSinc.Refresh()

        For Each row In BuscaSolicitacoes.ToList

            If row.Markup = 0 Then

                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                GestãoDeMarkupToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
                GestãoDeMarkupToolStripMenuItem.Enabled = True

            End If

            Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

            FrmSinc.Refresh()

        Next

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()
    End Sub

    Private Sub UpPrecosProdutos()

        'busca orcamentos abertos 

        Dim _IdProduto As String = 0
        Dim _ValorFinal As String = 0

        LqBase.Connection.ConnectionString = ConnectionStringBase

        Dim BuscaProdutos = From prod In LqBase.Produtos
                            Where prod.IdProduto Like "*"
                            Select prod.IdProdutoExt, prod.Markup, prod.IdProduto

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Sincronizando valores", 0, BuscaProdutos.Count, Nothing)

        FrmSinc.Refresh()

        For Each row In BuscaProdutos.ToList

            'busca armazenagem

            Dim LqEstoque As New LqEstoqueLocalDataContext
            LqEstoque.Connection.ConnectionString = ConnectionStringEstoqueLocal

            Dim BuscaArmaz = From arm In LqEstoque.Armazenagem
                             Where arm.IdProduto = row.IdProduto
                             Select arm.ValorRevenda, arm.Endereco, arm.Qt

            If BuscaArmaz.Count > 0 Then
                For Each linha In BuscaArmaz.ToList

                    Dim BuscaNomeEndereco = From ende In LqEstoque.EnderecoEstoqueLocal
                                            Where ende.NomeEndereco Like linha.Endereco
                                            Select ende.IdEndereco

                    If BuscaNomeEndereco.Count > 0 Then

                        Dim BuscaBaixa = From bai In LqEstoque.BaixaEndereco
                                         Where bai.IdEndereco = BuscaNomeEndereco.First
                                         Select bai.Qt

                        Dim qtInicio As Integer = linha.Qt

                        For Each linha1 In BuscaBaixa.ToList

                            qtInicio -= linha1

                        Next

                        If qtInicio > 0 Then
                            'manda o valor do produto 
                            _ValorFinal = linha.ValorRevenda
                        End If

                    Else

                        Dim BuscaBaixa = From bai In LqEstoque.BaixaEndereco
                                         Where bai.IdEndereco = linha.Endereco
                                         Select bai.Qt

                        Dim qtInicio As Integer = linha.Qt

                        For Each linha1 In BuscaBaixa.ToList

                            qtInicio -= linha1

                        Next

                        If qtInicio > 0 Then
                            'manda o valor do produto 
                            _ValorFinal = linha.ValorRevenda
                        End If

                    End If

                Next
            Else
                'busca cotação do item
                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro

                Dim BuscaCotacao = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdProduto = row.IdProduto
                                   Select cot.ValorCotado

                Dim _ValorRevenda As Decimal = BuscaCotacao.First + (BuscaCotacao.First * (row.Markup / 100))

                _ValorFinal = _ValorRevenda
            End If

            Dim baseUrl As String = "http://www.iarasoftware.com.br/up_preco_item_orc_zero.php?ChaveOficina=" & LblChaveEnc.Text & "&IdItem=" & row.IdProdutoExt & "&VlrUnit=" & _ValorFinal.Replace(",", ".") & "&TipoDoItem=produto"

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            Dim _Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = _Qt + 1

            FrmSinc.Refresh()

        Next

        'busca solicitacoes de cadastro

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = ConnectionStringOficina

        Dim BuscaProdutosSol = From prod In LqOficina.SolicitacaoCadastroPeca
                               Where prod.IdCodCad = 0
                               Select prod.IdCodExt, prod.Markup, prod.IdSolicitacaoCadastro

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Sincronizando valores (Solicitações de cadastro", 0, BuscaProdutos.Count, Nothing)

        FrmSinc.Refresh()

        For Each row In BuscaProdutosSol.ToList

            'busca armazenagem

            'busca cotação do item
            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro

            Dim BuscaCotacao = From cot In LqFinanceiro.Cotacoes
                               Where cot.IdSolicitacaoCad = row.IdSolicitacaoCadastro
                               Select cot.ValorCotado

            Dim _ValorRevenda As Decimal = BuscaCotacao.First + (BuscaCotacao.First * (row.Markup / 100))

            _ValorFinal = _ValorRevenda

            Dim baseUrl As String = "http://www.iarasoftware.com.br/up_preco_item_orc_zero.php?ChaveOficina=" & LblChaveEnc.Text & "&IdItem=" & row.IdCodExt & "&VlrUnit=" & _ValorFinal.Replace(",", ".") & "&TipoDoItem=produto"

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

            FrmSinc.Refresh()

        Next

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

    End Sub

    Private Sub VerificaCotacaoOnLine()

        'procura solicitacao on line

        Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_todas_solicitacoes_online.php?ChaveOficina=" & LblChaveEnc.Text
        Dim sync = New WebClient()
        Dim content_item = sync.DownloadString(baseUrl_item)

        Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.SolicitacaoCadExt))(content_item)

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Sincronizando valores (Solicitações de cadastro", 0, read0.Count, Nothing)

        FrmSinc.Refresh()

        If read0.Count > 0 Then

            For Each row In read0.ToList

                Dim DataCotacao As Date = row.DataCotacao
                Dim DataSolicitacao As Date = row.DataSolicitacaoCotacao & " " & row.HoraSolicitacaoCotacao

                If DataCotacao <> "11/11/1111" Then

                    If DataCotacao.AddDays(7) < Today.Date Then

                        'apaga a solicitacao do banco de dados

                        Dim baseUrl_Apaga As String = "http://www.iarasoftware.com.br/apaga_solicitacao_cotacao.php?ChaveOficina=" & LblChaveEnc.Text & "&IdItem=" & row.IdItem
                        Dim syncApaga = New WebClient()
                        Dim content_item_Apaga = syncApaga.DownloadString(baseUrl_Apaga)

                    ElseIf DataCotacao.AddDays(7) >= Today.Date Then

                        LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro
                        LqBase.Connection.ConnectionString = ConnectionStringBase

                        Dim LqOficina As New LqOficinaDataContext
                        LqOficina.Connection.ConnectionString = ConnectionStringOficina

                        'insere nova solicitacao no sistma

                        If row.IdProdutoInterno.StartsWith("S") Then

                            Dim BuscaMarkup = From mkp In LqOficina.SolicitacaoCadastroPeca
                                              Where mkp.IdSolicitacaoCadastro = row.IdProdutoInterno.Remove(0, 1)
                                              Select mkp.Markup

                            'busca solicitacao de cotacao ja existente

                            Dim BuscaSolicitacao = From sol In LqFinanceiro.Cotacoes
                                                   Where sol.IdSolicitacaoCad = row.IdProdutoInterno.Remove(0, 1)
                                                   Select sol.IdCotacao

                            If BuscaSolicitacao.Count = 0 Then
                                LqFinanceiro.InsereNovaCotacao(0, DataSolicitacao.Date, DataSolicitacao.TimeOfDay, 0, row.IdProdutoInterno.Remove(0, 1), 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, BuscaMarkup.First, 0)

                                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                                CotaçõesToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
                                TtFinanceiro.BackColor = Color.Gainsboro
                                CotaçõesToolStripMenuItem.Enabled = True

                            End If

                        Else

                            Dim BuscaMarkup = From mkp In LqBase.Produtos
                                              Where mkp.IdProduto = row.IdProdutoInterno
                                              Select mkp.Markup


                            'busca solicitacao de cotacao ja existente

                            Dim BuscaSolicitacao = From sol In LqFinanceiro.Cotacoes
                                                   Where sol.IdProduto = row.IdProdutoInterno
                                                   Select sol.IdCotacao

                            If BuscaSolicitacao.Count = 0 Then
                                LqFinanceiro.InsereNovaCotacao(0, DataSolicitacao.Date, DataSolicitacao.TimeOfDay, row.IdProdutoInterno, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, BuscaMarkup.First, 0)
                            End If

                        End If

                    End If

                End If

                Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1

                FrmSinc.Refresh()

            Next

        End If

        FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0).Value = My.Resources.check_ok_accept_apply_1582

        FrmSinc.Refresh()

    End Sub

    Private Sub VerificaComercial()

        'busca orcamentos abertos 

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_orcamento_aberto_local.php?ChaveOficina=" & LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Orcamentos))(content)

        FrmSinc.DtProdutos.Rows.Add(My.Resources.alert_icon_icons_com_52395, "Orçamentos para sincronizar", 0, read.Count, Nothing)

        Dim GuardaIndex As Integer = FrmSinc.DtProdutos.Rows.Count - 1

        'FrmSinc.Refresh()

        Dim Aprovados As Integer = 0
        Dim Perdido As Integer = 0
        Dim Aberto As Integer = 0

        For Each row In read.ToList

            Dim Aprovacao As Integer = row.Aprovacao

            Dim DateFormated As Date
            Dim DateFormatedAprovado As Date

            Dim IncioMes As Date = "01/" & Today.Month & "/" & Today.Year

            'Try
            If row.DataOrcamento <> "" Then
                DateFormated = row.DataOrcamento
            Else
                DateFormated = "1111-11-11"
            End If

            If row.DataAprovacao = "" Then
                DateFormatedAprovado = Today.Date
            Else
                DateFormatedAprovado = row.DataAprovacao
            End If

            If Aprovacao = "1" Then

                'verifica se o orcamento já foi inserido 

                Dim LqComercial As New LqComercialDataContext
                LqComercial.Connection.ConnectionString = ConnectionStringComercial

                Dim BuscaorcamentoCodExt = From cod In LqComercial.Orcamentos
                                           Where cod.IdCorOrcamentoExt = row.IdOrcamento
                                           Select cod.IdOrcamento

                If BuscaorcamentoCodExt.Count = 0 Then

                    If row.NomeCliente <> "" Then
                        'insere no bdd
                        Dim BuscaClienteDoc = From doc In LqBase.Clientes
                                              Where doc.CPF_CNPJ Like row.NomeCliente
                                              Select doc.IdCliente

                        LqComercial.InsereNovoOrcamento(IdUsuario, IdUsuario, DateFormated, Now.TimeOfDay, DateFormated, Now.TimeOfDay, BuscaClienteDoc.First, row.IdVeiculo, False, "1111-11-11", Today.TimeOfDay, 0, 0, 0, row.IdOrcamento, False, False, 0, "1111-11-11")
                        'insere no balancete para o recebimento

                        Dim UltimoId As Integer = LqComercial.Orcamentos.ToList.Last.IdOrcamento

                        'atualiza orçamento externo

                        Dim baseUrl_AtualizaOrc As String = "http://www.iarasoftware.com.br/atualiza_cod_orcamento_interno.php?ChaveOficina=" & LblChaveEnc.Text & "&IdOrcamento=" & row.IdOrcamento & "&IdOrcamentoVinc=" & UltimoId
                        Dim syncClient_AtualizaOrc = New WebClient()
                        Dim content_AtualizaOrc = syncClient_AtualizaOrc.DownloadString(baseUrl_AtualizaOrc)

                        'busca os itens do orçamento

                        Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_itens_orcamento_desk.php?ChaveOficina=" & LblChaveEnc.Text & "&IdOrcamento=" & row.IdOrcamento
                        Dim syncClient_item = New WebClient()
                        Dim content_item = syncClient_item.DownloadString(baseUrl_item)

                        Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItemOrcamentos))(content_item)


                        'le os campos e insere os itens solicitados
                        For Each row_Item In read0.ToList

                            Dim Tipo As Boolean

                            If row_Item.TipoDoItem = "produto" Then

                                'verifica solicitacao de cadastro

                                Dim BuscaSolicitacao = From solicitacoes In LqOficina.SolicitacaoCadastroPeca
                                                       Where solicitacoes.IdCodExt = row_Item.IdItem
                                                       Select solicitacoes.IdSolicitacaoCadastro, solicitacoes.IdCodCad

                                If BuscaSolicitacao.Count > 0 Then

                                    Tipo = True

                                    Dim VlrStr As String = row_Item.VlrUnit
                                    Dim DescStr As String = row_Item.VlrDesconto

                                    Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                                    Dim Desc As Decimal = DescStr.Replace(".", ",")

                                    'verifica o código interno é valido

                                    If BuscaSolicitacao.First.IdCodCad > 0 Then

                                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacao.First.IdCodCad, UltimoId, row_Item.Qt, 1, Vlr, Desc, Today.Date _
                                                                 , Tipo, row_Item.IdImagemAval, row_Item.IdImagemAval)

                                    Else


                                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacao.First.IdSolicitacaoCadastro, 0, UltimoId, row_Item.Qt, 1, Vlr, Desc, Today.Date _
                                                                    , Tipo, row_Item.IdImagemAval, row_Item.IdImagemAval)

                                    End If

                                    Dim Qt_it As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                                    FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt_it + 1

                                Else

                                    Dim BuscaProduto = From prod In LqBase.Produtos
                                                       Where prod.IdProdutoExt = row_Item.IdItem
                                                       Select prod.IdProduto

                                    Tipo = True

                                    Dim VlrStr As String = row_Item.VlrUnit
                                    Dim DescStr As String = row_Item.VlrDesconto

                                    Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                                    Dim Desc As Decimal = DescStr.Replace(".", ",")

                                    'verifica o código interno é valido

                                    LqComercial.InsereNovoItemOrcamento(0, BuscaProduto.First, UltimoId, row_Item.Qt, 1, Vlr, Desc, Today.Date _
                                                                 , Tipo, row_Item.IdImagemAval, row_Item.IdImagemAval)


                                    Dim Qt_it As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                                    FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt_it + 1

                                End If

                            Else

                                Tipo = False

                                'verifica o código interno é valido

                                'busca id interno do servico

                                Dim BuscaIdServico = From serv In LqBase.Servicos
                                                     Where serv.IdServicoInt = row_Item.IdItem
                                                     Select serv.IdServico

                                LqComercial.InsereNovoItemOrcamento(0, BuscaIdServico.First, UltimoId, row_Item.Qt, 1, row_Item.VlrUnit, row_Item.VlrDesconto, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                            End If

                        Next

                    End If

                Else

                    'atualiza dados do orcamento

                    'busca os itens do orçamento

                    Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_itens_orcamento_desk.php?ChaveOficina=" & LblChaveEnc.Text & "&IdOrcamento=" & row.IdOrcamento
                    Dim syncClient_item = New WebClient()
                    Dim content_item = syncClient_item.DownloadString(baseUrl_item)

                    Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItemOrcamentos))(content_item)

                    Dim BuscaOrcamentoInt = From orc In LqComercial.Orcamentos
                                            Where orc.IdCorOrcamentoExt = row.IdOrcamento
                                            Select orc.IdOrcamento

                    Dim BuscaUltimo = From orc In LqComercial.ProdutosOrcamento
                                      Where orc.IdOrcamento = BuscaOrcamentoInt.First
                                      Select orc.Versao
                                      Order By Versao Descending

                    Dim _VersaoEnc As Integer = 1

                    If BuscaUltimo.Count > 0 Then

                        _VersaoEnc = BuscaUltimo.First
                        Dim _IdOrcamento As Integer = BuscaOrcamentoInt.First

                        LqComercial.DeletaItensOrcamento(_IdOrcamento, _VersaoEnc)

                    End If

                    'le os campos e insere os itens solicitados
                    For Each row_Item In read0.ToList

                        Dim Tipo As Boolean

                        If row_Item.TipoDoItem = "produto" Then

                            'verifica solicitacao de cadastro

                            Dim BuscaSolicitacao = From solicitacoes In LqOficina.SolicitacaoCadastroPeca
                                                   Where solicitacoes.IdCodExt = row_Item.IdItem
                                                   Select solicitacoes.IdSolicitacaoCadastro, solicitacoes.IdCodCad

                            If BuscaSolicitacao.Count > 0 Then

                                Tipo = True

                                Dim VlrStr As String = row_Item.VlrUnit
                                Dim DescStr As String = row_Item.VlrDesconto

                                Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                                Dim Desc As Decimal = DescStr.Replace(".", ",")

                                'verifica o código interno é valido

                                If BuscaSolicitacao.First.IdCodCad > 0 Then

                                    LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacao.First.IdCodCad, BuscaorcamentoCodExt.First, row_Item.Qt, _VersaoEnc, Vlr, Desc, Today.Date _
                                                                     , Tipo, row_Item.IdImagemAval, row_Item.IdImagemAval)

                                Else

                                    LqComercial.InsereNovoItemOrcamento(BuscaSolicitacao.First.IdSolicitacaoCadastro, 0, BuscaorcamentoCodExt.First, row_Item.Qt, _VersaoEnc, Vlr, Desc, Today.Date _
                                                                        , Tipo, row_Item.IdImagemAval, row_Item.IdImagemAval)

                                End If

                                Dim Qt_it As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt_it + 1

                            Else

                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                   Where prod.IdProdutoExt = row_Item.IdItem
                                                   Select prod.IdProduto

                                Tipo = True

                                Dim VlrStr As String = row_Item.VlrUnit
                                Dim DescStr As String = row_Item.VlrDesconto

                                Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                                Dim Desc As Decimal = DescStr.Replace(".", ",")

                                'verifica o código interno é valido

                                LqComercial.InsereNovoItemOrcamento(0, BuscaProduto.First, BuscaorcamentoCodExt.First, row_Item.Qt, 1, Vlr, Desc, Today.Date _
                                                                 , Tipo, row_Item.IdImagemAval, row_Item.IdImagemAval)


                                Dim Qt_it As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
                                FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt_it + 1

                            End If

                        Else

                            Tipo = False

                            'verifica o código interno é valido

                            'busca id interno do servico

                            Dim BuscaIdServico = From serv In LqBase.Servicos
                                                 Where serv.IdServicoInt = row_Item.IdItem
                                                 Select serv.IdServico

                            LqComercial.InsereNovoItemOrcamento(0, BuscaIdServico.First, BuscaorcamentoCodExt.First, row_Item.Qt, _VersaoEnc, row_Item.VlrUnit, row_Item.VlrDesconto, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                        End If

                    Next

                End If

                If row.ValorTotal > 0 Then
                    Aberto += 1
                End If

            ElseIf Aprovacao = 0 Then

                    Dim LqComercial As New LqComercialDataContext
                    LqComercial.Connection.ConnectionString = ConnectionStringComercial

                    Dim BuscaorcamentoCodExt = From cod In LqComercial.Orcamentos
                                               Where cod.IdCorOrcamentoExt = row.IdOrcamento
                                               Select cod.IdOrcamento

                    If BuscaorcamentoCodExt.Count = 0 Then

                        'insere no bdd

                        Dim Data As Date = DateFormatedAprovado

                        If Data = "11/11/1111" Then
                            Data = Today.Date
                        End If

                        'insere no bdd
                        Dim BuscaClienteDoc = From doc In LqBase.Clientes
                                              Where doc.CPF_CNPJ Like row.NomeCliente
                                              Select doc.IdCliente

                        LqComercial.InsereNovoOrcamento(IdUsuario, IdUsuario, DateFormated, Now.TimeOfDay, DateFormated, Now.TimeOfDay, BuscaClienteDoc.First, row.IdVeiculo, True, Data, Today.TimeOfDay, 0, 0, 0, row.IdOrcamento, False, False, 0, "1111-11-11")

                        Dim UltimoId As Integer = LqComercial.Orcamentos.ToList.Last.IdOrcamento

                        'atualiza orçamento externo

                        Dim baseUrl_AtualizaOrc As String = "http://www.iarasoftware.com.br/atualiza_cod_orcamento_interno.php?ChaveOficina=" & LblChaveEnc.Text & "&IdOrcamento=" & row.IdOrcamento & "&IdOrcamentoVinc=" & UltimoId
                        Dim syncClient_AtualizaOrc = New WebClient()
                        Dim content_AtualizaOrc = syncClient_AtualizaOrc.DownloadString(baseUrl_AtualizaOrc)

                        'busca os itens do orçamento

                        Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_itens_orcamento_desk.php?ChaveOficina=" & LblChaveEnc.Text & "&IdOrcamento=" & row.IdOrcamento
                        Dim syncClient_item = New WebClient()
                        Dim content_item = syncClient_item.DownloadString(baseUrl_item)

                        Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItemOrcamentos))(content_item)

                        Dim VlrTtal As Decimal = 0

                        'le os campos e insere os itens solicitados
                        For Each row_Item In read0.ToList

                            Dim Tipo As Boolean

                            Dim _IdSolicitacao As Integer

                            Dim Quantidade As Integer = row_Item.Qt

                            If row_Item.TipoDoItem = "produto" Then

                                'verifica solicitacao de cadastro

                                Dim BuscaSolicitacao = From solicitacoes In LqOficina.SolicitacaoCadastroPeca
                                                       Where solicitacoes.IdCodExt = row_Item.IdItem
                                                       Select solicitacoes.IdSolicitacaoCadastro, solicitacoes.IdCodCad

                                Tipo = True

                                Dim VlrStr As String = row_Item.VlrUnit
                                Dim DescStr As String = row_Item.VlrDesconto

                                Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                                Dim Desc As Decimal = DescStr.Replace(".", ",")

                                'verifica o código interno é valido

                                If BuscaSolicitacao.First.IdCodCad > 0 Then

                                    LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacao.First.IdCodCad, UltimoId, Quantidade, 1, Vlr, Desc, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                                    'cria as solicitaçoes de separaçao

                                    Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                                    LqEstoqueLocal.Connection.ConnectionString = ConnectionStringEstoqueLocal

                                    'verifica se já existe a solicitaçao pra este produto

                                    Dim BuscaEstoque = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                       Where est.Destino Like "ORC_" & UltimoId And est.IdProduto = BuscaSolicitacao.First.IdCodCad
                                                       Select est.IdSolicitacao

                                    If BuscaEstoque.Count = 0 Then
                                        LqEstoqueLocal.InsereNovaSolicitacaoProdutoEstoque(BuscaSolicitacao.First.IdCodCad, Quantidade, "ORC_" & UltimoId, Today.Date, Now.TimeOfDay, IdUsuario, "1111-11-11", Today.TimeOfDay, 0, False, False, 0, "1111-11-11", Today.TimeOfDay, row_Item.IdItem)
                                    End If

                                    'insere solicitante do produto com a data respectiva

                                    VlrTtal += row_Item.Qt * (row_Item.VlrUnit.Replace(".", ",") - row_Item.VlrDesconto)

                                Else

                                    LqComercial.InsereNovoItemOrcamento(BuscaSolicitacao.First.IdSolicitacaoCadastro, 0, UltimoId, Quantidade, 1, Vlr, Desc, Today.Date _
                                                                    , Tipo, 0, row_Item.IdImagemAval)

                                    Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                                    LqEstoqueLocal.Connection.ConnectionString = ConnectionStringEstoqueLocal

                                    Dim BuscaEstoque = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                       Where est.Destino Like "ORC_" & UltimoId And est.IdSolicitacaoCad
                                                       Select est.IdSolicitacao

                                    If BuscaEstoque.Count = 0 Then
                                        LqEstoqueLocal.InsereNovaSolicitacaoProdutoEstoque(0, Quantidade, "ORC_" & UltimoId, Today.Date, Now.TimeOfDay, IdUsuario, "1111-11-11", Today.TimeOfDay, 0, False, False, BuscaSolicitacao.First.IdSolicitacaoCadastro, "1111-11-11", Today.TimeOfDay, row_Item.IdItem)
                                    End If

                                    VlrTtal += row_Item.Qt * (row_Item.VlrUnit.Replace(".", ",") - row_Item.VlrDesconto)

                                End If

                            Else

                                Tipo = False

                                Dim VlrStr As String = row_Item.VlrUnit
                                Dim DescStr As String = row_Item.VlrDesconto

                                Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                                Dim Desc As Decimal = DescStr.Replace(".", ",")

                                'verifica o código interno é valido

                                'busca id interno do servico

                                Dim BuscaIdServico = From serv In LqBase.Servicos
                                                     Where serv.IdServicoInt = row_Item.IdItem
                                                     Select serv.IdServico

                                LqComercial.InsereNovoItemOrcamento(0, BuscaIdServico.First, UltimoId, Quantidade, 1, Vlr, Desc, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                                VlrTtal += row_Item.Qt * (row_Item.VlrUnit.Replace(".", ",") - row_Item.VlrDesconto)

                            End If

                        Next

                    Else

                        'atualiza para finalizado

                        LqComercial.AtualizaAprovacaoOrçamento(BuscaorcamentoCodExt.First, True, Today.Date, Now.TimeOfDay, IdUsuario)

                        'apaga todos os itens do orçamento e reinsere

                        LqComercial.DeletaItensOrcamento(BuscaorcamentoCodExt.First, 1)

                        Dim LqEstoque As New LqEstoqueLocalDataContext
                        LqEstoque.Connection.ConnectionString = ConnectionStringEstoqueLocal

                        'LqEstoque.DeletaSolicitacoesEstoque("ORC_" & BuscaorcamentoCodExt.First)

                        'reconstroi

                        'busca os itens do orçamento

                        Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_itens_orcamento_desk.php?ChaveOficina=" & LblChaveEnc.Text & "&IdOrcamento=" & row.IdOrcamento
                        Dim syncClient_item = New WebClient()
                        Dim content_item = syncClient_item.DownloadString(baseUrl_item)

                        Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItemOrcamentos))(content_item)

                        Dim VlrTtal As Decimal = 0

                        'le os campos e insere os itens solicitados
                        For Each row_Item In read0.ToList

                            Dim Tipo As Boolean

                            Dim IdSolicitacao As Integer

                            Dim Quantidade As Integer = row_Item.Qt

                            If row_Item.TipoDoItem = "produto" Then

                                'verifica solicitacao de cadastro

                                Dim BuscaSolicitacao = From solicitacoes In LqOficina.SolicitacaoCadastroPeca
                                                       Where solicitacoes.IdCodExt = row_Item.IdItem
                                                       Select solicitacoes.IdSolicitacaoCadastro, solicitacoes.IdCodCad

                                Tipo = True

                                Dim VlrStr As String = row_Item.VlrUnit
                                Dim DescStr As String = row_Item.VlrDesconto

                                Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                                Dim Desc As Decimal = DescStr.Replace(".", ",")

                                'verifica o código interno é valido

                                If BuscaSolicitacao.Count > 0 Then
                                    If BuscaSolicitacao.First.IdCodCad > 0 Then

                                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacao.First.IdCodCad, BuscaorcamentoCodExt.First, Quantidade, 1, Vlr, row_Item.VlrDesconto, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                                        'cria as solicitaçoes de separaçao

                                        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                                        LqEstoqueLocal.Connection.ConnectionString = ConnectionStringEstoqueLocal

                                        'verifica se ja foi solicitado ao estoque

                                        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                                Where est.Destino Like "ORC_" & BuscaorcamentoCodExt.First And est.IdProduto = BuscaSolicitacao.First.IdCodCad
                                                                Select est.IdCodExterno

                                        If BuscaEstoqueLocal.Count = 0 Then
                                            LqEstoqueLocal.InsereNovaSolicitacaoProdutoEstoque(BuscaSolicitacao.First.IdCodCad, Quantidade, "ORC_" & BuscaorcamentoCodExt.First, Today.Date, Now.TimeOfDay, IdUsuario, "1111-11-11", Today.TimeOfDay, 0, False, False, 0, "1111-11-11", Today.TimeOfDay, row_Item.IdItem)
                                        End If

                                        'insere solicitante do produto com a data respectiva

                                        VlrTtal += row_Item.Qt * (row_Item.VlrUnit.Replace(".", ",") - row_Item.VlrDesconto)

                                    Else

                                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacao.First.IdSolicitacaoCadastro, 0, BuscaorcamentoCodExt.First, Quantidade, 1, Vlr, row_Item.VlrDesconto, Today.Date _
                                                                    , Tipo, 0, row_Item.IdImagemAval)

                                        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                                        LqEstoqueLocal.Connection.ConnectionString = ConnectionStringEstoqueLocal

                                        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                                Where est.Destino Like "ORC_" & BuscaorcamentoCodExt.First And est.IdProduto = BuscaSolicitacao.First.IdCodCad
                                                                Select est.IdCodExterno

                                        If BuscaEstoqueLocal.Count = 0 Then

                                            LqEstoqueLocal.InsereNovaSolicitacaoProdutoEstoque(0, Quantidade, "ORC_" & BuscaorcamentoCodExt.First, Today.Date, Now.TimeOfDay, IdUsuario, "1111-11-11", Today.TimeOfDay, 0, False, False, BuscaSolicitacao.First.IdSolicitacaoCadastro, "1111-11-11", Today.TimeOfDay, row_Item.IdItem)

                                        End If

                                        VlrTtal += row_Item.Qt * (row_Item.VlrUnit.Replace(".", ",") - row_Item.VlrDesconto)

                                    End If
                                Else

                                    Dim BuscaProduto = From prod In LqBase.Produtos
                                                       Where prod.IdProdutoExt = row_Item.IdItem
                                                       Select prod.IdProduto

                                    LqComercial.InsereNovoItemOrcamento(0, BuscaProduto.First, BuscaorcamentoCodExt.First, Quantidade, 1, Vlr, row_Item.VlrDesconto, Today.Date _
                                                            , Tipo, 0, row_Item.IdImagemAval)

                                    'cria as solicitaçoes de separaçao

                                    Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                                    LqEstoqueLocal.Connection.ConnectionString = ConnectionStringEstoqueLocal

                                    'verifica se ja foi solicitado ao estoque

                                    Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                            Where est.Destino Like "ORC_" & BuscaorcamentoCodExt.First And est.IdProduto = BuscaProduto.First
                                                            Select est.IdCodExterno

                                    If BuscaEstoqueLocal.Count = 0 Then
                                        LqEstoqueLocal.InsereNovaSolicitacaoProdutoEstoque(BuscaProduto.First, Quantidade, "ORC_" & BuscaorcamentoCodExt.First, Today.Date, Now.TimeOfDay, IdUsuario, "1111-11-11", Today.TimeOfDay, 0, False, False, 0, "1111-11-11", Today.TimeOfDay, row_Item.IdItem)
                                    End If

                                    'insere solicitante do produto com a data respectiva

                                    VlrTtal += row_Item.Qt * (row_Item.VlrUnit.Replace(".", ",") - row_Item.VlrDesconto)

                                End If

                            Else

                                Tipo = False

                                'busca servico cadastrado

                                Dim BuscaServico = From serv In LqBase.Servicos
                                                   Where serv.IdServico

                                'verifica o código inerno é valido

                                LqComercial.InsereNovoItemOrcamento(0, row_Item.IdItem, BuscaorcamentoCodExt.First, Quantidade, 1, row_Item.VlrUnit, row_Item.VlrDesconto, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                                VlrTtal += row_Item.Qt * (row_Item.VlrUnit.Replace(".", ",") - row_Item.VlrDesconto)

                            End If

                        Next

                    End If

                ElseIf Aprovacao = 2 Then

                    Dim LqComercial As New LqComercialDataContext
                LqComercial.Connection.ConnectionString = ConnectionStringComercial

                Dim BuscaorcamentoCodExt = From cod In LqComercial.Orcamentos
                                           Where cod.IdCorOrcamentoExt = row.IdOrcamento
                                           Select cod.IdOrcamento

                If BuscaorcamentoCodExt.Count = 0 Then

                    'insere no bdd

                    Dim Data As Date = DateFormatedAprovado

                    If Data = "11/11/1111" Then
                        Data = Today.Date
                    End If

                    'insere no bdd
                    Dim BuscaClienteDoc = From doc In LqBase.Clientes
                                          Where doc.CPF_CNPJ Like row.NomeCliente
                                          Select doc.IdCliente

                    LqComercial.InsereNovoOrcamento(IdUsuario, IdUsuario, DateFormated, Now.TimeOfDay, DateFormated, Now.TimeOfDay, BuscaClienteDoc.First, row.IdVeiculo, False, Data, Today.TimeOfDay, 0, 0, 0, row.IdOrcamento, False, False, 0, "1111-11-11")

                    Dim UltimoId As Integer = LqComercial.Orcamentos.ToList.Last.IdOrcamento

                    'atualiza orçamento externo

                    Dim baseUrl_AtualizaOrc As String = "http://www.iarasoftware.com.br/atualiza_cod_orcamento_interno.php?ChaveOficina=" & LblChaveEnc.Text & "&IdOrcamento=" & row.IdOrcamento & "&IdOrcamentoVinc=" & UltimoId
                    Dim syncClient_AtualizaOrc = New WebClient()
                    Dim content_AtualizaOrc = syncClient_AtualizaOrc.DownloadString(baseUrl_AtualizaOrc)

                    'busca os itens do orçamento

                    Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_itens_orcamento_desk.php?ChaveOficina=" & LblChaveEnc.Text & "&IdOrcamento=" & row.IdOrcamento
                    Dim syncClient_item = New WebClient()
                    Dim content_item = syncClient_item.DownloadString(baseUrl_item)

                    Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItemOrcamentos))(content_item)

                    'le os campos e insere os itens solicitados
                    For Each row_Item In read0.ToList

                        Dim Tipo As Boolean

                        If row_Item.TipoDoItem = "produto" Then

                            'verifica solicitacao de cadastro

                            Dim BuscaSolicitacao = From solicitacoes In LqOficina.SolicitacaoCadastroPeca
                                                   Where solicitacoes.IdCodExt = row_Item.IdItem
                                                   Select solicitacoes.IdSolicitacaoCadastro, solicitacoes.IdCodCad

                            Tipo = True

                            Dim VlrStr As String = row_Item.VlrUnit
                            Dim DescStr As String = row_Item.VlrDesconto

                            Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                            Dim Desc As Decimal = DescStr.Replace(".", ",")

                            'verifica o código interno é valido

                            If BuscaSolicitacao.First.IdCodCad > 0 Then

                                LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacao.First.IdCodCad, UltimoId, row_Item.Qt, 1, Vlr, row_Item.VlrDesconto, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                            Else


                                LqComercial.InsereNovoItemOrcamento(BuscaSolicitacao.First.IdSolicitacaoCadastro, 0, UltimoId, row_Item.Qt, 1, Vlr, row_Item.VlrDesconto, Today.Date _
                                                                    , Tipo, 0, row_Item.IdImagemAval)

                            End If

                        Else

                            Tipo = False

                            Dim VlrStr As String = row_Item.VlrUnit
                            Dim DescStr As String = row_Item.VlrDesconto

                            Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                            Dim Desc As Decimal = DescStr.Replace(".", ",")

                            'verifica o código interno é valido

                            LqComercial.InsereNovoItemOrcamento(0, row_Item.IdItem, UltimoId, row_Item.Qt, 1, vlr, row_Item.VlrDesconto, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                        End If

                    Next

                Else

                    'atualiza para finalizado

                    LqComercial.AtualizaAprovacaoOrçamento(BuscaorcamentoCodExt.First, False, Today.Date, Now.TimeOfDay, IdUsuario)

                    'apaga todos os itens do orçamento e reinsere

                    LqComercial.DeletaItensOrcamento(BuscaorcamentoCodExt.First, 1)

                    Dim LqEstoque As New LqEstoqueLocalDataContext
                    LqEstoque.Connection.ConnectionString = ConnectionStringEstoqueLocal

                    'reconstroi

                    'busca os itens do orçamento

                    Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_itens_orcamento_desk.php?ChaveOficina=" & LblChaveEnc.Text & "&IdOrcamento=" & row.IdOrcamento
                    Dim syncClient_item = New WebClient()
                    Dim content_item = syncClient_item.DownloadString(baseUrl_item)

                    Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItemOrcamentos))(content_item)

                    'le os campos e insere os itens solicitados
                    For Each row_Item In read0.ToList

                        Dim Tipo As Boolean

                        Dim IdSolicitacao As Integer

                        Dim Quantidade As Integer = row_Item.Qt

                        If row_Item.TipoDoItem = "produto" Then

                            'verifica solicitacao de cadastro

                            Dim BuscaSolicitacao = From solicitacoes In LqOficina.SolicitacaoCadastroPeca
                                                   Where solicitacoes.IdCodExt = row_Item.IdItem
                                                   Select solicitacoes.IdSolicitacaoCadastro, solicitacoes.IdCodCad

                            Tipo = True

                            'verifica o código interno é valido

                            Dim VlrStr As String = row_Item.VlrUnit
                            Dim DescStr As String = row_Item.VlrDesconto

                            Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                            Dim Desc As Decimal = DescStr.Replace(".", ",")

                            If BuscaSolicitacao.First.IdCodCad > 0 Then

                                LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacao.First.IdCodCad, BuscaorcamentoCodExt.First, Quantidade, 1, Vlr, Desc, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                                'cria as solicitaçoes de separaçao

                                Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                                LqEstoqueLocal.Connection.ConnectionString = ConnectionStringEstoqueLocal

                                'insere solicitante do produto com a data respectiva


                            Else

                                LqComercial.InsereNovoItemOrcamento(BuscaSolicitacao.First.IdSolicitacaoCadastro, 0, BuscaorcamentoCodExt.First, Quantidade, 1, Vlr, Desc, Today.Date _
                                                                    , Tipo, 0, row_Item.IdImagemAval)

                                Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                                LqEstoqueLocal.Connection.ConnectionString = ConnectionStringEstoqueLocal

                            End If

                        Else

                            Dim VlrStr As String = row_Item.VlrUnit
                            Dim DescStr As String = row_Item.VlrDesconto

                            Dim Vlr As Decimal = VlrStr.Replace(".", ",")
                            Dim Desc As Decimal = DescStr.Replace(".", ",")

                            Tipo = False

                            'verifica o código interno é valido

                            LqComercial.InsereNovoItemOrcamento(0, row_Item.IdItem, BuscaorcamentoCodExt.First, Quantidade, 1, Vlr, Desc, Today.Date _
                                                                , Tipo, 0, row_Item.IdImagemAval)

                        End If

                    Next

                End If

            End If


            Dim Qt As Integer = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value
            FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(2).Value = Qt + 1
            FrmSinc.DtProdutos.FirstDisplayedCell = FrmSinc.DtProdutos.Rows(FrmSinc.DtProdutos.Rows.Count - 1).Cells(0)

            'Me.Refresh()

            'Catch ex As Exception
            '    DateFormated = "11/11/1111"
            '    MsgBox("Erro na data")
            'End Try

            Dim DataControle As Date = "11/11/1111"

            If DateFormated > DataControle Then
                If DateFormated >= IncioMes Then

                End If
            End If

        Next

        FrmSinc.DtProdutos.Rows(GuardaIndex).Cells(0).Value = My.Resources.check_ok_accept_apply_1582
        FrmSinc.DtProdutos.FirstDisplayedCell = FrmSinc.DtProdutos.Rows(GuardaIndex).Cells(0)

        Me.Refresh()

        If Aberto > 0 Then

            TtComercial.Image = My.Resources.alert_icon_icons_com_52395
            TtComercial.TextAlign = ContentAlignment.MiddleRight
            ToolStripMenuItem2.Image = My.Resources.alert_icon_icons_com_52395
            TtComercial.BackColor = Color.Gainsboro

            TtComercial.Enabled = True
            ToolStripMenuItem2.Enabled = True

        End If

    End Sub
    Private Sub verificaLiberacao()

        Dim LqEstoque As New LqEstoqueLocalDataContext

        LqEstoque.Connection.ConnectionString = ConnectionStringEstoqueLocal
        LqBase.Connection.ConnectionString = ConnectionStringBase

        Dim BuscaSolicitações = From sol In LqEstoque.SolicitacaoProdutosEstoque
                                Where sol.Status = False
                                Select sol.IdProduto, sol.Qtdade, sol.DataSol, sol.Destino, sol.IdSolicitacao, sol.IdSolicitacaoCad

        If BuscaSolicitações.Count > 0 Then

            TtEstoque.Image = My.Resources.alert_icon_icons_com_52395
            TtEstoque.TextAlign = ContentAlignment.MiddleRight
            LiberaçãoDeProdutosToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395

            TtEstoque.Enabled = True
            LiberaçãoDeProdutosToolStripMenuItem.Enabled = True

        End If

        Dim BuscaLiberados = From sol In LqEstoque.SolicitacaoProdutosEstoque
                             Where sol.Status = True And sol.Ret = False
                             Select sol.Ret, sol.IdProduto, sol.Qtdade, sol.DataSol, sol.Destino, sol.IdSolicitacao, sol.IdSolicitacaoCad, sol.IdSolicitante

        If BuscaLiberados.Count > 0 Then

            TtEstoque.Image = My.Resources.alert_icon_icons_com_52395
            TtEstoque.TextAlign = ContentAlignment.MiddleRight
            LiberaçãoDeProdutosToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395

            TtEstoque.Enabled = True
            LiberaçãoDeProdutosToolStripMenuItem.Enabled = True

        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        Timer1.Enabled = False

        FrmComercial.Show(Me)

    End Sub

    Private Sub ToolStripMenuItem1_Click_2(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmTodosProdutos.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub RecebimentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecebimentoToolStripMenuItem.Click
        Timer1.Enabled = False

        FrmRecebimentoCarga.Show(Me)
    End Sub

    Private Sub EntradaDeVeículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradaDeVeículoToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmEntradaVeículo.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ParceirosComerciaisToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Me.Cursor = Cursors.WaitCursor
        FrmParceirosComerciais.Show(Me)
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub FlowLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles DashOperação.Paint

    End Sub

    Private Sub FlowLayoutPanel3_Click(sender As Object, e As EventArgs) Handles DashOperação.Click
        CarregaDashboard()
    End Sub

    Private Sub DtPatio_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtPatio.CellContentClick

    End Sub

    Public Sub Popula_Grafico()

        If DtPatio.Rows.Count > 0 Then

            Dim BuscaOficina = From veic In LqOficina.Vistorias
                               Where veic.IdVeiculo = Val(DtPatio.SelectedCells(0).Value)
                               Select veic.DataInicioVistoria, veic.IdTecnico, veic.Recebida, veic.Concluido, veic.DataSolicitação, veic.IdVeiculo, veic.DataVistoria, veic.NivelReq

            Dim LstStatus As New ListBox
            Dim LstDatas As New ListBox

            Dim StatusAtual As String = "Aguardando posicionamento"

            For Each item In BuscaOficina.ToList

                If item.NivelReq = 0 Then

                    If item.Concluido = False Then

                        If item.Recebida = True Then

                            LstStatus.Items.Add("Solicitação de vistoria")
                            LstDatas.Items.Add(item.DataSolicitação)

                            'verifica se inicio a vistoria

                            If item.DataInicioVistoria.Value.Date <> "1111-11-11" Then

                                LstStatus.Items.Add("Vistoria iniciada")
                                LstDatas.Items.Add(item.DataInicioVistoria.Value.Date)


                            End If

                        End If

                    Else

                        LstStatus.Items.Add("Soliitação de vistoria")
                        LstDatas.Items.Add(item.DataSolicitação.Value.Date)

                        LstStatus.Items.Add("Vistoria iniciada")
                        LstDatas.Items.Add(item.DataInicioVistoria.Value.Date)

                        LstStatus.Items.Add("Vistoria concluida")
                        LstDatas.Items.Add(item.DataVistoria.Value.Date)

                        StatusAtual = "Aguardando desmonte"

                    End If

                ElseIf item.NivelReq = 1 Then

                    If item.Concluido = False Then

                        LstStatus.Items.Add("Solicitação de desmonte")
                        LstDatas.Items.Add(item.DataSolicitação)

                        'verifica se inicio a vistoria

                        If item.DataInicioVistoria.Value.Date <> "1111-11-11" Then

                            LstStatus.Items.Add("Desmonte iniciada")
                            LstDatas.Items.Add(item.DataInicioVistoria.Value.Date)

                            StatusAtual = "Aguardando término do desmonte"

                        Else

                            StatusAtual = "Aguardando desmonte"

                        End If

                    Else

                        LstStatus.Items.Add("Solicitação de desmonte")
                        LstDatas.Items.Add(item.DataSolicitação.Value.Date)

                        LstStatus.Items.Add("Desmonte iniciado")
                        LstDatas.Items.Add(item.DataInicioVistoria.Value.Date)

                        LstStatus.Items.Add("Desmonte concluido")
                        LstDatas.Items.Add(item.DataVistoria.Value.Date)

                        StatusAtual = "Aguardando reparos"

                    End If

                ElseIf item.NivelReq = 2 Then

                    If item.Concluido = False Then

                        LstStatus.Items.Add("Solicitação de reparos")
                        LstDatas.Items.Add(item.DataSolicitação)

                        'verifica se inicio a vistoria

                        If item.DataInicioVistoria.Value.Date <> "1111-11-11" Then

                            LstStatus.Items.Add("Desmonte iniciada")
                            LstDatas.Items.Add(item.DataInicioVistoria.Value.Date)

                            StatusAtual = "Aguardando término dos reparos"

                        Else

                            StatusAtual = "Aguardando reparos"

                        End If

                    Else

                        LstStatus.Items.Add("Solicitação de reparos")
                        LstDatas.Items.Add(item.DataSolicitação.Value.Date)

                        LstStatus.Items.Add("Reparos iniciados")
                        LstDatas.Items.Add(item.DataInicioVistoria.Value.Date)

                        LstStatus.Items.Add("Eeparos concluídos")
                        LstDatas.Items.Add(item.DataVistoria.Value.Date)

                        StatusAtual = "Aguardando entrega do veiculo"

                    End If

                End If

            Next

            'carrega lista para o selecionado

            For i As Integer = 0 To LstStatusPlacas.Items.Count - 1

                If LstStatusPlacas.Items(i).ToString.ToUpper = DtPatio.SelectedCells(1).Value Then
                    LstStatus.Items.Add(LstStatusLista.Items(i).ToString)
                    Dim DataVal As Date = LstDatasReg.Items(i).ToString
                    LstDatas.Items.Add(DataVal)
                    StatusAtual = LstStatusString.Items(i).ToString
                End If

            Next

            'renderiza painel

            'popula grafico de evolução

            Dim IndexTrav As Integer = -1
            Dim Trava As Boolean = False
            For i As Integer = 0 To LstStatusPlacas.Items.Count - 1

                If LstStatusPlacas.Items(i).ToString = DtPatio.SelectedCells(1).Value Then

                    If Trava = False Then
                        Trava = True
                        IndexTrav = i
                    End If

                End If

            Next

            Chart3.BackColor = Color.WhiteSmoke
            Chart3.ChartAreas(0).BackColor = Color.Gainsboro
            Chart3.IsSoftShadows = True

            Chart3.Series.Clear()
            Chart3.Series.Add("Linha do tempo")
            Chart3.Series(0).YValueType = DataVisualization.Charting.ChartValueType.Date

            Dim xEntradas2() As Decimal = {5, 10, 7}
            'define os valoes do eixo x - nome dos paises
            Dim yEntradas2() As String = {"EMQ-7740", "FXQ-9163", "BMW-7713"}

            'desenha dias do mes

            'Dim DiasMes As Integer
            'Dim Inicio As Date = LstDatasReg.Items(IndexTrav).ToString
            'Dim Termino As Date = Today.Date.AddMonths(1)

            'While Inicio < Termino
            '    DiasMes += 1
            '    Inicio = Inicio.AddDays(1)
            'End While

            'publica limite na serie 0

            With Chart3

                .ChartAreas(0).Area3DStyle.Enable3D = True

                .ChartAreas(0).Area3DStyle.Inclination = 0
                .ChartAreas(0).Area3DStyle.Perspective = 0
                .ChartAreas(0).Area3DStyle.Rotation = 0
                .Legends(0).Docking = DataVisualization.Charting.Docking.Bottom
                .Legends(0).Alignment = StringAlignment.Far
                .Legends(0).BackColor = Color.WhiteSmoke
                .ChartAreas(0).BackColor = Color.Transparent


                .ChartAreas(0).AxisX.MajorGrid.LineColor = Color.SlateGray
                .ChartAreas(0).AxisX.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
                .ChartAreas(0).AxisX.LineColor = Color.SlateGray
                .ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.SlateGray
                .ChartAreas(0).AxisX.LabelStyle.Font = New Font("Calibri", 6, FontStyle.Bold)

                .ChartAreas(0).AxisX.Title = StatusAtual
                .ChartAreas(0).AxisX.TitleAlignment = StringAlignment.Near
                .ChartAreas(0).AxisX.TitleFont = New Font("Calibri", 12, FontStyle.Bold)
                .ChartAreas(0).AxisX.TitleForeColor = Color.DarkRed

                .ChartAreas(0).AxisX.TextOrientation = DataVisualization.Charting.TextOrientation.Horizontal

                .Titles.Clear()
                .Titles.Add("Veículo - " & DtPatio.SelectedCells(1).Value.ToString)
                .Titles(0).Font = New Font("Calibri", 12, FontStyle.Bold)
                .Titles(0).ForeColor = Color.SlateGray
                .Titles(0).Docking = DataVisualization.Charting.Docking.Left


                .ChartAreas(0).AxisY.MajorGrid.LineColor = Color.SlateGray
                .ChartAreas(0).AxisY.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
                .ChartAreas(0).AxisY.LineColor = Color.SlateGray
                .ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.SlateGray
                .ChartAreas(0).AxisY.LabelStyle.Font = New Font("Calibri", 6, FontStyle.Bold)
                .ChartAreas(0).AxisY.IsStartedFromZero = True
                '.ChartAreas(0).AxisY.Title = "Datas"
                '.ChartAreas(0).AxisY.TitleForeColor = Color.SlateGray
                '.ChartAreas(0).AxisY.TitleFont = New Font("Calibri", 8, FontStyle.Bold)

                '.ChartAreas(0).AxisX.Maximum = TodosVeiculos.Items.Count
                .ChartAreas(0).AxisX.Minimum = 1
                .ChartAreas(0).AxisX.Interval = 1

                For i As Integer = .Series.Count - 1 To 0 Step -1

                    .Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Line
                    .Series(i).LabelForeColor = Color.DarkSlateGray

                Next

                'arruma orientador
                '.Series(.Series.Count - 1).Color = Color.Transparent

                'busca veículos q só deram entrada no sistema

                '.Series(0).Points.DataBindXY(LstEspera.Items, xEntradas2)1
                .Series(0).Points.DataBindXY(LstStatus.Items, LstDatas.Items)

                ' .Series(1).Points.DataBindXY(TodosVeiculos.Items, LstEspera.Items)

            End With

        Else

            'popula grafico de evolução

            Chart3.BackColor = Color.WhiteSmoke
            Chart3.ChartAreas(0).BackColor = Color.Gainsboro
            Chart3.IsSoftShadows = True

            Chart3.Series.Clear()
            Chart3.Series.Add("Entrada no sistema")


            Dim xEntradas2() As Decimal = {5, 10, 7}
            'define os valoes do eixo x - nome dos paises
            Dim yEntradas2() As String = {"EMQ-7740", "FXQ-9163", "BMW-7713"}

            'desenha dias do mes

            Dim DiasMes As Integer
            Dim Inicio As Date = "01/" & Today.Month & "/" & Today.Year
            Dim Termino As Date = Inicio.AddMonths(1)

            While Inicio < Termino
                DiasMes += 1
                Inicio = Inicio.AddDays(1)
            End While

            'publica limite na serie 0

            Dim lstDias As New ListBox

            For i As Integer = 1 To 0 Step -1
                lstDias.Items.Add(DiasMes)
            Next

            With Chart3

                .ChartAreas(0).Area3DStyle.Enable3D = True

                .ChartAreas(0).Area3DStyle.Inclination = 0
                .ChartAreas(0).Area3DStyle.Perspective = 0
                .ChartAreas(0).Area3DStyle.Rotation = 0
                .Legends(0).Docking = DataVisualization.Charting.Docking.Bottom
                .Legends(0).Alignment = StringAlignment.Far
                .Legends(0).BackColor = Color.WhiteSmoke
                .ChartAreas(0).Name = "Não há veículos inseridos no sistema"
                .ChartAreas(0).BackColor = Color.Transparent

                .ChartAreas(0).AxisX.MajorGrid.LineColor = Color.SlateGray
                .ChartAreas(0).AxisX.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
                .ChartAreas(0).AxisX.LineColor = Color.SlateGray
                .ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.SlateGray
                .ChartAreas(0).AxisX.LabelStyle.Font = New Font("Calibri", 8, FontStyle.Bold)
                .ChartAreas(0).AxisX.Title = "Veículos"

                .ChartAreas(0).AxisY.MajorGrid.LineColor = Color.SlateGray
                .ChartAreas(0).AxisY.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
                .ChartAreas(0).AxisY.LineColor = Color.SlateGray
                .ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.SlateGray
                .ChartAreas(0).AxisY.LabelStyle.Font = New Font("Calibri", 8, FontStyle.Bold)
                .ChartAreas(0).AxisY.IsStartedFromZero = True
                .ChartAreas(0).AxisY.Title = "Dias da semana"

                .ChartAreas(0).AxisY.Maximum = DiasMes
                .ChartAreas(0).AxisY.Minimum = 1
                .ChartAreas(0).AxisY.Interval = 1

                '.ChartAreas(0).AxisX.Maximum = TodosVeiculos.Items.Count
                .ChartAreas(0).AxisX.Minimum = 1
                .ChartAreas(0).AxisX.Interval = 1

                For i As Integer = .Series.Count - 1 To 0 Step -1

                    .Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Bar
                    .Series(i).LabelForeColor = Color.DarkSlateGray

                Next

                'arruma orientador
                .Series(.Series.Count - 1).Color = Color.Transparent

                'busca veículos q só deram entrada no sistema

                '.Series(0).Points.DataBindXY(LstEspera.Items, xEntradas2)1
                '.Series(0).Points.DataBindXY(TodosVeiculos.Items, LstConc.Items)

                '.Series(1).Points.DataBindXY(TodosVeiculos.Items, LstEspera.Items)

            End With

        End If

        'habilita o timer

        Timer1.Enabled = True

    End Sub
    Private Sub DtPatio_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtPatio.CellClick

        Popula_Grafico()

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles LblDesmonteEspera.Click

    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles TTRh.Click

    End Sub

    Private Sub LblEspera_Click(sender As Object, e As EventArgs) Handles LblEspera.Click

        If LblEspera.BackColor = Color.WhiteSmoke Then

            PInta_Label_WhiteSomke()

            LblEspera.BackColor = Color.DarkOrange
            LblEspera.ForeColor = Color.FloralWhite

            'busca somente os veiculos q estão na espera


            Dim BuscaOficina = From veic In LqOficina.Vistorias
                               Where veic.NivelReq = 0 And veic.Recebida = False
                               Select veic.IdTecnico, veic.Recebida, veic.Concluido, veic.DataSolicitação, veic.IdVeiculo, veic.DataVistoria


            'popula no grid

            Dim Conc As Integer
            Dim Espera As Integer
            Dim Realizando As Integer

            Dim LstConc As New ListBox
            Dim LstEspera As New ListBox

            Dim TodosVeiculos As New ListBox

            DtPatio.Rows.Clear()

            For Each row In BuscaOficina.ToList
                'Busca Plca 

                Dim BuscaPlaca = From pla In LqOficina.Veiculos
                                 Where pla.IdVeiculo = row.IdVeiculo
                                 Select pla.Placa, pla.Modelo, pla.Fabricante

                TodosVeiculos.Items.Add(BuscaPlaca.First.Placa.ToUpper)

                DtPatio.Rows.Add(row.IdVeiculo, BuscaPlaca.First.Placa.ToUpper.ToCharArray(0, 3) & "-" & BuscaPlaca.First.Placa.ToUpper.ToCharArray(3, 4), BuscaPlaca.First.Fabricante, BuscaPlaca.First.Modelo, "")

                If row.Recebida = False Then
                    Espera += 1

                    LstEspera.Items.Add(0)
                    LstConc.Items.Add(0)

                ElseIf row.Recebida = True Then
                    If row.Concluido = False Then
                        Realizando += 1

                        LstEspera.Items.Add(row.DataSolicitação.Value.Day)
                        LstConc.Items.Add(0)

                    Else
                        Conc += 1

                        LstEspera.Items.Add(row.DataSolicitação.Value.Day)
                        LstConc.Items.Add(row.DataVistoria.Value.Day)

                    End If
                End If
            Next

            'LblConcluido.Text = Conc
            LblEspera.Text = Espera
            'LblAndamento.Text = Realizando

            'renderiza painel

            PnnPainelInferior.Size = New Size(PnnPainelInferior.Width, ((Me.Height - (PnnSuperior.Height + PnnPainelInferior.Height)) + PnnPainelInferior.Height) - 50)

            Popula_Grafico()

        Else

            LblEspera.BackColor = Color.WhiteSmoke

            LblEspera.ForeColor = Color.DarkGoldenrod

            CarregaDashboard()

        End If

    End Sub

    Private Sub LblAndamento_Click(sender As Object, e As EventArgs) Handles LblAndamento.Click

        If LblAndamento.BackColor = Color.WhiteSmoke Then

            PInta_Label_WhiteSomke()

            LblAndamento.BackColor = Color.DarkOrange
            LblAndamento.ForeColor = Color.FloralWhite

            'busca somente os veiculos q estão na espera


            Dim BuscaOficina = From veic In LqOficina.Vistorias
                               Where veic.NivelReq = 0 And veic.Recebida = True And veic.Concluido = False
                               Select veic.IdTecnico, veic.Recebida, veic.Concluido, veic.DataSolicitação, veic.IdVeiculo, veic.DataVistoria


            'popula no grid

            Dim Conc As Integer
            Dim Espera As Integer
            Dim Realizando As Integer

            Dim LstConc As New ListBox
            Dim LstEspera As New ListBox

            Dim TodosVeiculos As New ListBox

            DtPatio.Rows.Clear()

            For Each row In BuscaOficina.ToList
                'Busca Plca 

                Dim BuscaPlaca = From pla In LqOficina.Veiculos
                                 Where pla.IdVeiculo = row.IdVeiculo
                                 Select pla.Placa, pla.Modelo, pla.Fabricante

                TodosVeiculos.Items.Add(BuscaPlaca.First.Placa.ToUpper)

                DtPatio.Rows.Add(row.IdVeiculo, BuscaPlaca.First.Placa.ToUpper.ToCharArray(0, 3) & "-" & BuscaPlaca.First.Placa.ToUpper.ToCharArray(3, 4), BuscaPlaca.First.Fabricante, BuscaPlaca.First.Modelo, "")

                If row.Recebida = False Then
                    Espera += 1

                    LstEspera.Items.Add(0)
                    LstConc.Items.Add(0)

                ElseIf row.Recebida = True Then
                    If row.Concluido = False Then
                        Realizando += 1

                        LstEspera.Items.Add(row.DataSolicitação.Value.Day)
                        LstConc.Items.Add(0)

                    Else
                        Conc += 1

                        LstEspera.Items.Add(row.DataSolicitação.Value.Day)
                        LstConc.Items.Add(row.DataVistoria.Value.Day)

                    End If
                End If
            Next

            LblAndamento.Text = Realizando

            'renderiza painel

            PnnPainelInferior.Size = New Size(PnnPainelInferior.Width, ((Me.Height - (PnnSuperior.Height + PnnPainelInferior.Height)) + PnnPainelInferior.Height) - 50)

            Popula_Grafico()

        Else

            LblAndamento.BackColor = Color.WhiteSmoke

            LblAndamento.ForeColor = Color.DarkGoldenrod

            CarregaDashboard()

        End If

    End Sub

    Public Sub PInta_Label_WhiteSomke()

        LblConcluido.BackColor = Color.WhiteSmoke
        LblAndamento.BackColor = Color.WhiteSmoke
        LblEspera.BackColor = Color.WhiteSmoke

        LblConcluido.ForeColor = Color.DarkGreen
        LblAndamento.ForeColor = Color.SlateGray
        LblEspera.ForeColor = Color.DarkGoldenrod

    End Sub
    Private Sub LblConcluido_Click(sender As Object, e As EventArgs) Handles LblConcluido.Click

        If LblConcluido.BackColor = Color.WhiteSmoke Then

            PInta_Label_WhiteSomke()

            LblConcluido.BackColor = Color.DarkOrange
            LblConcluido.ForeColor = Color.FloralWhite

            'busca somente os veiculos q estão na espera


            Dim BuscaOficina = From veic In LqOficina.Vistorias
                               Where veic.NivelReq = 0 And veic.Recebida = True And veic.Concluido = True
                               Select veic.IdTecnico, veic.Recebida, veic.Concluido, veic.DataSolicitação, veic.IdVeiculo, veic.DataVistoria


            'popula no grid

            Dim Conc As Integer
            Dim Espera As Integer
            Dim Realizando As Integer

            Dim DesmonteConc As Integer
            Dim DesmonteEspera As Integer
            Dim DesmonteRealizando As Integer

            Dim LstConc As New ListBox
            Dim LstEspera As New ListBox

            Dim TodosVeiculos As New ListBox

            DtPatio.Rows.Clear()

            For Each row In BuscaOficina.ToList
                'Busca Plca 

                Dim BuscaPlaca = From pla In LqOficina.Veiculos
                                 Where pla.IdVeiculo = row.IdVeiculo
                                 Select pla.Placa, pla.Modelo, pla.Fabricante

                TodosVeiculos.Items.Add(BuscaPlaca.First.Placa.ToUpper)

                DtPatio.Rows.Add(row.IdVeiculo, BuscaPlaca.First.Placa.ToUpper.ToCharArray(0, 3) & "-" & BuscaPlaca.First.Placa.ToUpper.ToCharArray(3, 4), BuscaPlaca.First.Fabricante, BuscaPlaca.First.Modelo, "")

                If row.Recebida = False Then
                    Espera += 1

                    LstEspera.Items.Add(0)
                    LstConc.Items.Add(0)

                ElseIf row.Recebida = True Then
                    If row.Concluido = False Then
                        Realizando += 1

                        LstEspera.Items.Add(row.DataSolicitação.Value.Day)
                        LstConc.Items.Add(0)

                    Else
                        Conc += 1

                        LstEspera.Items.Add(row.DataSolicitação.Value.Day)
                        LstConc.Items.Add(row.DataVistoria.Value.Day)

                    End If

                End If

            Next

            LblConcluido.Text = Conc

            'renderiza painel

            PnnPainelInferior.Size = New Size(PnnPainelInferior.Width, ((Me.Height - (PnnSuperior.Height + PnnPainelInferior.Height)) + PnnPainelInferior.Height) - 50)

            Popula_Grafico()

        Else

            LblConcluido.BackColor = Color.WhiteSmoke

            LblConcluido.ForeColor = Color.DarkGoldenrod

            CarregaDashboard()

        End If

    End Sub

    Public _Ip As String = "169.254.0.0"
    Public _IpIara As String = "169.254.0.0"

    Public _Instancia As String = ""
    Public _portaSQL As Integer = 0

    Public ConnectionStringBase As String
    Public ConnectionStringComercial As String
    Public ConnectionStringEstoqueDistribuidorOnLine As String
    Public ConnectionStringEstoqueLocal As String
    Public ConnectionStringFinanceiro As String
    Public ConnectionStringIARA As String
    Public ConnectionStringOficina As String
    Public ConnectionStringTrabalhista As String

    Public ConnectionStringTransportePrestadorOnline As String

    Private Function PointPlus(ByVal OP() As Point, ByVal AP As Point)
        'Adds a point to an existing point array
        If OP Is Nothing Then
            ReDim OP(0)
            OP(0) = AP
        Else
            ReDim Preserve OP(OP.Length)
            OP(OP.Length - 1) = AP
        End If
        Return OP
    End Function

    Private Sub DtPatio_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtPatio.CellDoubleClick

        Me.Cursor = Cursors.WaitCursor
        Timer1.Enabled = False

        FrmNovoStudioAvaliacao.LblStagio.Text = DtPatio.SelectedCells(6).Value
        FrmNovoStudioAvaliacao.LblNumSoluçãoN.Text = DtPatio.SelectedCells(7).Value
        FrmNovoStudioAvaliacao.IdCliente = DtPatio.SelectedCells(8).Value
        FrmNovoStudioAvaliacao.IdVeiculo = DtPatio.SelectedCells(0).Value

        FrmNovoStudioAvaliacao.LblPlacaN.Text = DtPatio.SelectedCells(2).Value
        FrmNovoStudioAvaliacao.LblPlaca.Text = DtPatio.SelectedCells(1).Value

        'procura dados 

        LqOficina.Connection.ConnectionString = ConnectionStringOficina

        Dim _IdVeiculo As Integer = DtPatio.SelectedCells(0).Value
        Dim BuscaOficina = From ofi In LqOficina.Veiculos
                           Where ofi.IdVeiculoExt = _IdVeiculo
                           Select ofi.Fabricante, ofi.Modelo, ofi.AnoFab, ofi.AnoMod

        If BuscaOficina.Count > 0 Then

            FrmNovoStudioAvaliacao.FabricanteVeic = BuscaOficina.First.Fabricante
            FrmNovoStudioAvaliacao.ModeloVeic = BuscaOficina.First.Modelo
            FrmNovoStudioAvaliacao.AnoFab = BuscaOficina.First.AnoFab
            FrmNovoStudioAvaliacao.AnoMod = BuscaOficina.First.AnoMod

        End If

        'manda informaçoes do veículo
        FrmNovoStudioAvaliacao.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub TxtFilroPlaca_TextChanged(sender As Object, e As EventArgs)

        Dim Crit As String = ""

        If Crit.Length > 3 Then
            Crit = Crit.ToCharArray(0, 3) & "-" & Crit.ToCharArray(3, Crit.Length - 3)
        End If

        For Each row As DataGridViewRow In DtPatio.Rows
            row.Visible = True
        Next

        Dim Sel As Boolean = False

        For Each row As DataGridViewRow In DtPatio.Rows

            If row.Cells(1).Value.ToString.Contains(Crit) Then
                row.Visible = True
                If Sel = False Then
                    row.Selected = True
                    Sel = False
                End If
            Else
                row.Visible = False
            End If

        Next

    End Sub

    Private Sub ExpandirFluxoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpandirFluxoToolStripMenuItem.Click

        FrmFluxo.Show(Me)

    End Sub

    Private Sub FrmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If FrmCadColaboradores.primeiro = False Then
            'End
        End If

    End Sub

    Private Sub PnnEncerrar_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PnnEncerrar_Click(sender As Object, e As EventArgs)

        End

    End Sub

    Private Sub Panel49_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel49_Click(sender As Object, e As EventArgs)

        End

    End Sub

    Private Sub BtnOperacional_Click(sender As Object, e As EventArgs) Handles BtnOperacional.Click

        PintaTodos()

        CarregaDashboard()

        DashOperação.Dock = DockStyle.Fill
        DashOperação.Visible = True

        BtnOperacional.BackColor = Color.WhiteSmoke
        BtnOperacional.ForeColor = Color.FromArgb(255, 0, 43, 72)

        'desabilita

        DashEstoque.Visible = False
        DashFinanceiro.Visible = False
        DashCompras.Visible = False

    End Sub

    Public Sub PintaTodos()

        BtnEstoque.BackColor = Color.Gainsboro
        BtnEstoque.ForeColor = Color.SlateGray

        BtnOperacional.BackColor = Color.Gainsboro
        BtnOperacional.ForeColor = Color.SlateGray

        BtnFinanceiro.BackColor = Color.Gainsboro
        BtnFinanceiro.ForeColor = Color.SlateGray

        BtnCompras.BackColor = Color.Gainsboro
        BtnCompras.ForeColor = Color.SlateGray

    End Sub
    Private Sub BtnEstoque_Click(sender As Object, e As EventArgs) Handles BtnEstoque.Click

        PintaTodos()

        CarregaEstoque()

        DashEstoque.Dock = DockStyle.Fill
        DashEstoque.Visible = True

        BtnEstoque.BackColor = Color.WhiteSmoke
        BtnEstoque.ForeColor = Color.FromArgb(255, 0, 43, 72)

        'desabilita

        DashOperação.Visible = False
        DashFinanceiro.Visible = False
        DashCompras.Visible = False

    End Sub

    Public Sub CarregaEstoque()

        'busca solicitações de cadastro

        Dim BuscaCad = From cad In LqOficina.SolicitacaoCadastroPeca
                       Where cad.IdCodCad = 0
                       Select cad.IdSolicitacaoCadastro

        LblCadastroProdutos.Text = BuscaCad.Count

    End Sub

    Dim LqFinanceiro As New LqFinanceiroDataContext

    Public Sub CarregaCompra()

        'busca solicitações de cadastro

        Dim BuscaCad = From cad In LqFinanceiro.Cotacoes
                       Where cad.IdCotador = 0
                       Select cad.IdComprador

        LblCotaçõesPendentes.Text = BuscaCad.Count

    End Sub
    Public Sub CarregaFinanceiro()

    End Sub
    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub BtnFinanceiro_Click(sender As Object, e As EventArgs) Handles BtnFinanceiro.Click

        PintaTodos()

        CarregaFinanceiro()

        DashFinanceiro.Dock = DockStyle.Fill
        DashFinanceiro.Visible = True

        BtnFinanceiro.BackColor = Color.WhiteSmoke
        BtnFinanceiro.ForeColor = Color.FromArgb(255, 0, 43, 72)

        'desabilita

        DashOperação.Visible = False
        DashEstoque.Visible = False
        DashCompras.Visible = False

    End Sub

    Private Sub BtnCompras_Click(sender As Object, e As EventArgs) Handles BtnCompras.Click

        PintaTodos()

        CarregaCompra()

        DashCompras.Dock = DockStyle.Fill
        DashCompras.Visible = True

        BtnCompras.BackColor = Color.WhiteSmoke
        BtnCompras.ForeColor = Color.FromArgb(255, 0, 43, 72)

        'desabilita

        DashOperação.Visible = False
        DashEstoque.Visible = False
        DashFinanceiro.Visible = False

    End Sub

    Private Sub Label66_Click(sender As Object, e As EventArgs) Handles LblCotaçõesPendentes.Click

    End Sub

    Private Sub Panel51_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel51_Click(sender As Object, e As EventArgs)

        End

    End Sub

    Private Sub LblCadastroProdutos_Click(sender As Object, e As EventArgs) Handles LblCadastroProdutos.Click

        Me.Cursor = Cursors.AppStarting

        If LblCadastroProdutos.Text <> 0 Then

            'verifica se há solicitação de cadastro de peça

            Dim Oficina = From ofc In LqOficina.SolicitacaoCadastroPeca
                          Where ofc.IdCodCad = 0
                          Select ofc.DataSol, ofc.HoraSol, ofc.IdSolicitante, ofc.Descricao, ofc.IdSolicitacaoCadastro, ofc.PartNumber

            FrmSolicitaçõesCadastro.DtProdutos.Rows.Clear()

            For Each row In Oficina.ToList

                'busca associação

                Dim BuscaAssociação = From ass In LqOficina.VinculoProdutoModelo
                                      Where ass.IdSolicitacaoCad = row.IdSolicitacaoCadastro
                                      Select ass.IdModeloVeic, ass.IdVersaoVeiculo

                If BuscaAssociação.Count > 0 Then
                    'busca associação ao modelo do veiculo

                    Dim BuscaMOdelo = From mode In LqOficina.Modelos
                                      Where mode.IdModelo = BuscaAssociação.First.IdModeloVeic
                                      Select mode.Modelo, mode.IdFabricante

                    Dim BuscaVersão = From ver In LqOficina.VersaoModelos
                                      Where ver.Idversao = BuscaAssociação.First.IdModeloVeic
                                      Select ver.Versao, ver.Potencia, ver.Cilindrada, ver.Cambio, ver.Combustivel

                    Dim BUscaFabricante = From fab In LqOficina.FabricantesVeiculo
                                          Where fab.Idfabricante = BuscaMOdelo.First.IdFabricante
                                          Select fab.Fabricante

                    FrmSolicitaçõesCadastro.DtProdutos.Rows.Add(row.IdSolicitacaoCadastro, row.PartNumber, row.Descricao, BUscaFabricante.First & " " & BuscaMOdelo.First.Modelo & " - " & BuscaVersão.First.Versao & " " & FormatNumber(BuscaVersão.First.Potencia, NumDigitsAfterDecimal:=1) & ", " & BuscaVersão.First.Combustivel & " (" & BuscaVersão.First.Cambio & ")", FormatDateTime(row.DataSol, DateFormat.ShortDate), FormatDateTime(row.HoraSol.ToString, DateFormat.ShortTime))

                End If

            Next

            If FrmSolicitaçõesCadastro.DtProdutos.Rows.Count = 0 Then
                If Application.OpenForms.OfType(Of FrmProduto)().Count() = 0 Then
                    'adiciona nos vinculos
                    FrmProduto.Show(Me)
                End If
            Else
                If Application.OpenForms.OfType(Of FrmSolicitaçõesCadastro)().Count() = 0 Then
                    FrmSolicitaçõesCadastro.Show(Me)
                End If
            End If

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Dim LqBase As New DtCadastroDataContext

    Private Sub CotaçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CotaçõesToolStripMenuItem.Click

        LqBase.Connection.ConnectionString = ConnectionStringBase
        LqOficina.Connection.ConnectionString = ConnectionStringOficina

        Me.Cursor = Cursors.WaitCursor

        'carrega todas as cotações

        Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                            Where cot.IdCotador = 0
                            Select cot.IdSolicitacaoCad, cot.IdProduto, cot.Qt

        If BuscaCotações.Count > 0 Then

            'popula grid

            Dim LstItemPopulado As New ListBox

            For Each row In BuscaCotações.ToList

                If row.IdSolicitacaoCad <> 0 Then

                    If Not LstItemPopulado.Items.Contains("S" & row.IdSolicitacaoCad) Then

                        LstItemPopulado.Items.Add("S" & row.IdSolicitacaoCad)

                        'verifica se na lista ele já foi inserido

                        Dim Index As Integer = -1

                        Dim Buscadescricao = From desc In LqOficina.SolicitacaoCadastroPeca
                                             Where desc.IdSolicitacaoCadastro = row.IdSolicitacaoCad
                                             Select desc.Descricao, desc.IdCodCad, desc.IdSolicitacaoCadastro, desc.PartNumber

                        Dim BuscaAssociação = From ass In LqOficina.VinculoProdutoModelo
                                              Where ass.IdSolicitacaoCad = Buscadescricao.First.IdSolicitacaoCadastro
                                              Select ass.IdModeloVeic, ass.IdVersaoVeiculo

                        If BuscaAssociação.Count > 0 Then

                            'busca associação ao modelo do veiculo

                            Dim BuscaMOdelo = From mode In LqOficina.Modelos
                                              Where mode.IdModelo = BuscaAssociação.First.IdModeloVeic
                                              Select mode.Modelo, mode.IdFabricante

                            Dim BuscaVersão = From ver In LqOficina.VersaoModelos
                                              Where ver.Idversao = BuscaAssociação.First.IdModeloVeic
                                              Select ver.Versao, ver.Potencia, ver.Cilindrada, ver.Cambio, ver.Combustivel

                            Dim BUscaFabricante = From fab In LqOficina.FabricantesVeiculo
                                                  Where fab.Idfabricante = BuscaMOdelo.First.IdFabricante
                                                  Select fab.Fabricante

                            FrmCotações.DtItensBDD.Rows.Add(FrmCotações.ImageList1.Images(0), "S_" & row.IdSolicitacaoCad, Buscadescricao.First.Descricao & " (Item não cadastrado) - Assoc.: " & BUscaFabricante.First & " " & BuscaMOdelo.First.Modelo & " " & BuscaVersão.First.Versao & " " & FormatNumber(BuscaVersão.First.Potencia, NumDigitsAfterDecimal:=1), "Oficina", BuscaMOdelo.First.Modelo, BuscaVersão.First.Versao & " " & FormatNumber(BuscaVersão.First.Potencia, NumDigitsAfterDecimal:=1) & ", " & BuscaVersão.First.Combustivel & " (" & BuscaVersão.First.Cambio & ")", Buscadescricao.First.PartNumber, row.Qt)
                            FrmCotações.DtCotFinal.Rows.Add(FrmCotações.ImageList1.Images(0), "S_" & row.IdSolicitacaoCad, Buscadescricao.First.Descricao & " (Item não cadastrado) - Assoc.: " & BUscaFabricante.First & " " & BuscaMOdelo.First.Modelo & " " & BuscaVersão.First.Versao & " " & FormatNumber(BuscaVersão.First.Potencia, NumDigitsAfterDecimal:=1), "Oficina", BuscaMOdelo.First.Modelo, BuscaVersão.First.Versao & " " & FormatNumber(BuscaVersão.First.Potencia, NumDigitsAfterDecimal:=1) & ", " & BuscaVersão.First.Combustivel & " (" & BuscaVersão.First.Cambio & ")", Buscadescricao.First.PartNumber, row.Qt)

                        Else

                            FrmCotações.DtItensBDD.Rows.Add(FrmCotações.ImageList1.Images(0), "S_" & row.IdSolicitacaoCad, Buscadescricao.First.Descricao & " (Item não cadastrado)", "Oficina", "", "", Buscadescricao.First.PartNumber, row.Qt)
                            FrmCotações.DtCotFinal.Rows.Add(FrmCotações.ImageList1.Images(0), "S_" & row.IdSolicitacaoCad, Buscadescricao.First.Descricao & " (Item não cadastrado)", "Oficina", "", "", Buscadescricao.First.PartNumber, row.Qt)

                        End If

                    Else

                        'busca já populados e ajusta s valores

                        For Each rowPop As DataGridViewRow In FrmCotações.DtItensBDD.Rows

                            If rowPop.Cells(1).Value = "S_" & row.IdSolicitacaoCad Then

                                Dim VAlorEnc As Integer = rowPop.Cells(7).Value
                                rowPop.Cells(6).Value = row.Qt + VAlorEnc

                            End If

                        Next

                    End If

                Else

                    If Not LstItemPopulado.Items.Contains(row.IdProduto) Then

                        LstItemPopulado.Items.Add(row.IdProduto)

                        Dim Buscadescricao = From desc In LqBase.Produtos
                                             Where desc.IdProduto = row.IdProduto
                                             Select desc.Descricao, desc.CodFabricante, desc.Fabricante

                        If Buscadescricao.Count > 0 Then

                            Dim BuscaAssociação = From ass In LqOficina.AssociaçãoPeçaModelo
                                                  Where ass.IdCodProd = row.IdProduto
                                                  Select ass.IdModeloVeic, ass.IdAssociacaoPecaModelo

                            If BuscaAssociação.Count > 0 Then

                                'busca associação ao modelo do veiculo

                                Dim BuscaMOdelo = From mode In LqOficina.Modelos
                                                  Where mode.IdModelo = BuscaAssociação.First.IdModeloVeic
                                                  Select mode.Modelo, mode.IdFabricante, mode.AnoModelo, mode.Combustivel

                                Dim BuscaFabricante = From fab In LqOficina.FabricantesVeiculo
                                                      Where fab.Idfabricante = BuscaMOdelo.First.IdFabricante
                                                      Select fab.Fabricante

                                Dim PN As String = "ND"

                                If Buscadescricao.First.CodFabricante <> "" Then
                                    PN = Buscadescricao.First.CodFabricante
                                End If

                                FrmCotações.DtItensBDD.Rows.Add(FrmCotações.ImageList1.Images(0), row.IdProduto, Buscadescricao.First.Descricao, "Oficina", BuscaMOdelo.First.Modelo, "", PN, row.Qt, BuscaFabricante.First, BuscaMOdelo.First.Modelo, BuscaMOdelo.First.AnoModelo, BuscaMOdelo.First.Combustivel)
                                FrmCotações.DtCotFinal.Rows.Add(FrmCotações.ImageList1.Images(0), row.IdProduto, Buscadescricao.First.Descricao, "Oficina", BuscaMOdelo.First.Modelo, "", PN, row.Qt)

                            Else

                                Dim PN As String = "ND"

                                If Buscadescricao.First.CodFabricante <> "" Then
                                    PN = Buscadescricao.First.CodFabricante
                                End If

                                FrmCotações.DtItensBDD.Rows.Add(FrmCotações.ImageList1.Images(0), row.IdProduto, Buscadescricao.First.Descricao, "Oficina", "ND", "", PN, row.Qt)
                                FrmCotações.DtCotFinal.Rows.Add(FrmCotações.ImageList1.Images(0), row.IdProduto, Buscadescricao.First.Descricao, "Oficina", "ND", "", PN, row.Qt)

                            End If

                        Else

                            Dim BuscadescricaoSolicitacao = From desc In LqOficina.SolicitacaoCadastroPeca
                                                            Where desc.IdSolicitacaoCadastro = row.IdSolicitacaoCad
                                                            Select desc.Descricao, desc.PartNumber

                            Dim BuscaAssociação = From ass In LqOficina.AssociaçãoPeçaModelo
                                                  Where ass.IdSolicitaçãoCad = row.IdSolicitacaoCad
                                                  Select ass.IdModeloVeic, ass.IdAssociacaoPecaModelo

                            If BuscaAssociação.Count > 0 Then

                                'busca associação ao modelo do veiculo

                                Dim BuscaMOdelo = From mode In LqOficina.Modelos
                                                  Where mode.IdModelo = BuscaAssociação.First.IdModeloVeic
                                                  Select mode.Modelo, mode.IdFabricante

                                FrmCotações.DtItensBDD.Rows.Add(FrmCotações.ImageList1.Images(0), row.IdProduto, BuscadescricaoSolicitacao.First.Descricao, "Oficina", BuscaMOdelo.First.Modelo, "", BuscadescricaoSolicitacao.First.PartNumber, row.Qt)
                                FrmCotações.DtCotFinal.Rows.Add(FrmCotações.ImageList1.Images(0), row.IdProduto, BuscadescricaoSolicitacao.First.Descricao, "Oficina", BuscaMOdelo.First.Modelo, "", BuscadescricaoSolicitacao.First.PartNumber, row.Qt)

                            Else

                                FrmCotações.DtItensBDD.Rows.Add(FrmCotações.ImageList1.Images(0), row.IdProduto, BuscadescricaoSolicitacao.First.Descricao, "Oficina", "ND", "", BuscadescricaoSolicitacao.First.PartNumber, row.Qt)
                                FrmCotações.DtCotFinal.Rows.Add(FrmCotações.ImageList1.Images(0), row.IdProduto, BuscadescricaoSolicitacao.First.Descricao, "Oficina", "ND", "", BuscadescricaoSolicitacao.First.PartNumber, row.Qt)

                            End If

                        End If

                    Else

                            'busca já populados e ajusta s valores

                            For Each rowPop As DataGridViewRow In FrmCotações.DtItensBDD.Rows

                            If rowPop.Cells(1).Value.ToString = row.IdProduto Then

                                Dim ValorAt As Integer = rowPop.Cells(7).Value
                                ValorAt += row.Qt

                            End If

                        Next

                    End If

                End If

            Next

            Dim LqEstoqueOnLine As New LqEstoqueIaraDataContext
            LqEstoqueOnLine.Connection.ConnectionString = ConnectionStringEstoqueDistribuidorOnLine

            Dim _indiceMelhorValor As New ListBox
            Dim _indiceMelhorEntrega As New ListBox

            Dim _MelhorValor As Decimal = 1000000000000000
            Dim _MelhorEntrega As Decimal = 1000000000000000

            'seleciona e aplica 

            For Each rowIni As DataGridViewRow In FrmCotações.DtItensBDD.Rows

                _MelhorValor = 1000000000000000
                _MelhorEntrega = 1000000000000000

                '       

                Dim ValorPartNumber As String = rowIni.Cells(6).Value.ToString

                Dim BuscaCardapio = From card In LqEstoqueOnLine.CardapioIProdutosARA
                                    Where card.PartNumber Like ValorPartNumber And card.IdClienteIARA <> IdCliente And card.QtdadePublicada > 0 And card.PartNumber <> ""
                                    Select card.PartNumber, card.Descricao, card.IdClienteIARA, card.ValorUnitario, card.PrazoEntrega, card.IdItemEstoqueIARA, card.QtdadePublicada

                FrmCotações.DtBddIARA.Rows.Clear()

                Dim Selecionados As Integer = 0

                Try

                    For Each row In BuscaCardapio.ToList

                        If row.QtdadePublicada > 0 Then

                            'Busca Imagens

                            Dim BuscaImagens = From Img In LqEstoqueOnLine.ImagensProdutosIara
                                               Where Img.Idproduto = row.IdItemEstoqueIARA
                                               Select Img.Imagem

                            Dim ImgProduto As Image = My.Resources.untitled_n

                            'Poipula primeira imagem encontrada

                            If BuscaImagens.Count > 0 Then

                                Dim arrImage() As Byte
                                Dim myMS As New IO.MemoryStream
                                arrImage = BuscaImagens.First.ToArray

                                For Each ar As Byte In arrImage
                                    myMS.WriteByte(ar)
                                Next

                                ImgProduto = Image.FromStream(myMS)

                            End If

                            FrmCotações.DtBddIARA.Rows.Add(ImgProduto, row.IdClienteIARA, row.IdItemEstoqueIARA, row.Descricao, "100%", row.PartNumber, FormatCurrency(row.ValorUnitario, NumDigitsAfterDecimal:=2), row.PrazoEntrega, 0, FrmCotações.ImageList1.Images(5))

                            'procura a quantidade de itens cotados para este forneedor

                            Dim C0 As Integer = 0
                            Dim C1 As Integer = 0

                            For Each row1 As DataGridViewRow In FrmCotações.DtResumo.Rows

                                If row1.Cells(0).Value = row.IdClienteIARA And row1.Cells(1).Value = row.IdItemEstoqueIARA Then

                                    C0 += 1

                                End If

                                If row1.Cells(0).Value = row.IdClienteIARA Then

                                    C1 += 1

                                End If

                            Next

                            If C0 > 0 Then

                                FrmCotações.DtBddIARA.Rows(FrmCotações.DtBddIARA.Rows.Count - 1).Cells(8).Value = C0

                                FrmCotações.DtBddIARA.Rows(FrmCotações.DtBddIARA.Rows.Count - 1).Cells(9).Value = FrmCotações.ImageList1.Images(4)

                                Selecionados += 1

                            End If

                            FrmCotações.DtBddIARA.Rows(FrmCotações.DtBddIARA.Rows.Count - 1).Cells(8).Value = C1

                        Else

                            'verifica compatibilidade encontrada


                        End If

                    Next

                Catch ex As Exception

                    FrmCotações.LblOffLine.Visible = True

                End Try


                If Selecionados = FrmCotações.DtBddIARA.Rows.Count Then

                    'PictureBox1.BackgroundImage = My.Resources.ligado

                    FrmCotações.VerificaPossibilidadeAnalise()

                Else

                    'PictureBox1.BackgroundImage = My.Resources.desligado

                End If

                If FrmCotações.DtBddIARA.Rows.Count > 1 Then
                    FrmCotações.LblOcorrencias.Text = "Selecionar as " & FrmCotações.DtBddIARA.Rows.Count & " correspondências."
                ElseIf FrmCotações.DtBddIARA.Rows.Count = 1 Then
                    FrmCotações.LblOcorrencias.Text = "Selecionar a correspondência encontrada."
                ElseIf FrmCotações.DtBddIARA.Rows.Count = 0 Then
                    FrmCotações.LblOcorrencias.Text = "Nenhuma correspondência encontrada."
                End If


                For Each row As DataGridViewRow In FrmCotações.DtBddIARA.Rows

                    'seleciona toodos os itens

                    Dim LstRemover As New ListBox

                    For Each row1 As DataGridViewRow In FrmCotações.DtResumo.Rows

                        If row1.Cells(1).Value = row.Cells(2).Value Then

                            LstRemover.Items.Add(row1.Index)

                        End If

                    Next

                    For Each row1 In LstRemover.Items

                        Dim DtSel As DataGridViewRow = FrmCotações.DtResumo.Rows(row1.ToString)

                        FrmCotações.DtResumo.Rows.Remove(DtSel)

                    Next

                    row.Cells(9).Value = FrmCotações.ImageList1.Images(4)

                    FrmCotações.DtResumo.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, rowIni.Cells(1).Value, rowIni.Cells(2).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value)

                Next

                'verifica se existe no resumo

                Dim R As Integer = 0

                For Each row As DataGridViewRow In FrmCotações.DtResumo.Rows

                    If row.Cells(2).Value = rowIni.Cells(1).Value Then

                        R += 1

                    End If

                Next

                If R > 0 Then
                    rowIni.Cells(0).Value = FrmCotações.ImageList1.Images(1)
                End If

            Next

            FrmCotações.VerificaPossibilidadeAnalise()

            If FrmCotações._Analisar = True Then

                FrmCotações.TabControl1.SelectedIndex = 2

            End If

            'pinta melhor valor

            'varre resumo

            For Each rowini As DataGridViewRow In FrmCotações.DtItensBDD.Rows

                _MelhorValor = 1000000000000000
                _MelhorEntrega = 1000000000000000

                For Each row As DataGridViewRow In FrmCotações.DtResumo.Rows

                    If rowini.Cells(1).Value = row.Cells(2).Value Then

                        Dim ValorEnc As Decimal = row.Cells(5).Value

                        If ValorEnc < _MelhorValor Then

                            'pinta os que forem para este perfil

                            For Each rowa As DataGridViewRow In FrmCotações.DtResumo.Rows

                                If rowini.Cells(1).Value = rowa.Cells(2).Value Then

                                    rowa.Cells(5).Style.Font = New Font("Calibri", 8.25)
                                    rowa.Cells(0).Style.Font = New Font("Calibri", 8.25)
                                    rowa.Cells(3).Style.Font = New Font("Calibri", 8.25)

                                    rowa.Cells(5).Style.ForeColor = Color.DarkSlateGray
                                    rowa.Cells(0).Style.ForeColor = Color.DarkSlateGray
                                    rowa.Cells(3).Style.ForeColor = Color.DarkSlateGray

                                    rowa.DefaultCellStyle.BackColor = Color.WhiteSmoke

                                End If

                            Next

                            _MelhorValor = ValorEnc

                            row.Cells(5).Style.Font = New Font("Calibri", 10)
                            row.Cells(0).Style.Font = New Font("Calibri", 10)
                            row.Cells(3).Style.Font = New Font("Calibri", 10)

                            row.Cells(5).Style.ForeColor = Color.DarkGreen
                            row.Cells(0).Style.ForeColor = Color.DarkGreen
                            row.Cells(3).Style.ForeColor = Color.DarkGreen

                            row.DefaultCellStyle.BackColor = Color.MintCream

                        End If

                    End If

                Next

            Next

            'popula fornecedores

            Dim LstIdfornecedoresPopulados As New ListBox

            Dim LstfornecedoresPopulados As New ListBox
            Dim LstValoresPopulados As New ListBox
            Dim LstMenorPreço As New ListBox

            Dim MenorPreço As Decimal = 1000000000000000

            'preenche concorrencia

            Dim _indexMenorPreço As Integer = 0

            For Each row1 As DataGridViewRow In FrmCotações.DtResumo.Rows

                If FrmCotações.DtItensBDD.Rows(0).Cells(1).Value = row1.Cells(2).Value Then

                    LstfornecedoresPopulados.Items.Add("Fornec.: " & row1.Cells(0).Value)
                    FrmCotações.CmbFornecedores.Items.Add("Fornec.: " & row1.Cells(0).Value)
                    LstIdfornecedoresPopulados.Items.Add(row1.Cells(0).Value)
                    FrmCotações._IdFornecedores.Items.Add(row1.Cells(0).Value)
                    LstValoresPopulados.Items.Add(FormatCurrency(row1.Cells(5).Value, NumDigitsAfterDecimal:=2))

                    If MenorPreço > row1.Cells(5).Value Then

                        MenorPreço = row1.Cells(5).Value

                        'limpa lista

                        LstMenorPreço.Items.Clear()

                        For i As Integer = 0 To LstfornecedoresPopulados.Items.Count - 2

                            LstMenorPreço.Items.Add(0)

                        Next

                        LstMenorPreço.Items.Add(MenorPreço)
                        _indexMenorPreço = LstMenorPreço.Items.Count - 1

                    ElseIf MenorPreço <= row1.Cells(5).Value Then

                        LstMenorPreço.Items.Add(0)

                    End If

                End If

            Next

            FrmCotações.ChConcorrencia.Series(0).Points.DataBindXY(LstfornecedoresPopulados.Items, LstValoresPopulados.Items)
            FrmCotações.ChConcorrencia.Series(1).Points.DataBindXY(LstfornecedoresPopulados.Items, LstMenorPreço.Items)

            Me.Cursor = Cursors.Arrow

            If FrmCotações.CmbFornecedores.Items.Count > 0 Then
                FrmCotações.CmbFornecedores.SelectedIndex = _indexMenorPreço
            End If

            'FrmCotações.TabControl2.SelectedIndex = 1

            FrmCotações.NmQtSolicitada.Minimum = FrmCotações.DtItensBDD.SelectedCells(7).Value
            FrmCotações.NmQtSolicitada.Value = FrmCotações.DtItensBDD.SelectedCells(7).Value

            Me.Cursor = Cursors.Arrow

            FrmCotações.Show(Me)

        Else

            MsgBox("Não há solicitações no momento.", MsgBoxStyle.OkOnly)

            Me.Cursor = Cursors.Arrow

        End If

        Timer1.Enabled = False

    End Sub

    Dim valOpc As Integer = 1

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        LblHoraLocal.Text = "Hora certa.: " & Now

        If valOpc = 120 Then

            LblUltimaAtualizacao.Text = valOpc

            CarregaDashboard()

        Else

            LblUltimaAtualizacao.Text = valOpc

            valOpc += 1

        End If

    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem.Click

        Timer1.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        ComprasFinanceiro.Show(Me)
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub OrçamentosToolStripMenuItem_Click(sender As Object, e As EventArgs)

        FrmNovoORçamento.Show(Me)

    End Sub

    Private Sub TtAdministrarEstoque_Click(sender As Object, e As EventArgs) Handles TtAdministrarEstoque.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        FrmAdminEstoqueNovo.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub LiberaçãoDeProdutosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiberaçãoDeProdutosToolStripMenuItem.Click

        Timer1.Enabled = False
        FrmDespachoSolicitações.Show(Me)

    End Sub

    Private Sub TesteToolStripMenuItem_Click(sender As Object, e As EventArgs)

        FrmNovoStudioAvaliacao.Show(Me)

    End Sub

    Private Sub ServiosCadastradosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiosCadastradosToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmTodosServicos.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub FerramentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FerramentasToolStripMenuItem1.Click

        FrmNovaFerramenta.Show(Me)

    End Sub

    Private Sub QuadroOperacionalToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        EntradaDeVeículoToolStripMenuItem.PerformClick()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Timer1.Enabled = False

        FrmConfiguracaoEscolhavb.Show(Me)

    End Sub

    Private Sub FrmPrincipal_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        End

    End Sub

    Private Sub FrmPrincipal_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

        'Timer1.Enabled = False

    End Sub

    Private Sub FrmPrincipal_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

        'Timer1.Enabled = True
        FrmNotifficação.Visible = False

    End Sub

    Private Sub GestãoDeMarkupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestãoDeMarkupToolStripMenuItem.Click

        Timer1.Enabled = False
        FrmListaMarkup.Show(Me)

    End Sub

    Private Sub ReceberPagamentosToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

        Timer1.Enabled = False
        FrmBalancete.Show(Me)

    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click

        Timer1.Enabled = False
        FrmApontamentosFinanceiros.Show(Me)

    End Sub

    Private Sub RecebimentoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RecebimentoToolStripMenuItem1.Click

        LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = ConnectionStringComercial

        Dim BuscaLancamento = From lanc In LqComercial.Orcamentos
                              Where lanc.ValorRecebido = False And lanc.IdOrcamento <> 0
                              Select lanc.Aprovado

        If BuscaLancamento.Count > 0 Then
            Me.Timer1.Enabled = False
            FrmCaixa.Show(Me)
        Else
            If MsgBox("Não existem recebimentos esperados até o momento.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Pagamentos esperados") Then
                CarregaDashboard()
            End If
        End If

    End Sub

    Private Sub EmitirNFSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmitirNFSToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        FrmEmitirNFS.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub FrmPrincipal_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

    End Sub

    Private Sub FrmPrincipal_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp

        valOpc = 1

    End Sub

    Private Sub LaudosPericiaisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaudosPericiaisToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        FrmLaudosSolicitados.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        FrmLaudos.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ColaboradoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColaboradoresToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        FrmListaColaboradores.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Public Sub AfericaoValores()

        'busca solicitacoes de averiguacao

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = ConnectionStringFinanceiro

        Dim FimMes As Date = "01/" & Today.Month & "/" & Today.Year

        FimMes = FimMes.AddMonths(1)
        FimMes = FimMes.AddDays(-1)

        Dim BuscaAveriguacao = From aver In LqFinanceiro.AferirPagamentos
                               Where aver.Aferido = False And aver.DataInicioAlerta < FimMes
                               Select aver.IdAferir, aver.IdBalanecete

        For Each row In BuscaAveriguacao.ToList

            Dim BuscaBalancete = From bal In LqFinanceiro.BalanceteFinanceiro
                                 Where bal.IdItemBalancete = row.IdBalanecete And bal.Status = False And bal.Valor = 0
                                 Select bal.Descricao, bal.Vencimento

            If BuscaBalancete.Count > 0 Then

                TtFinanceiro.Image = My.Resources.alert_icon_icons_com_52395
                TtFinanceiro.TextAlign = ContentAlignment.MiddleRight
                PagamentosCimValidaçãoDeValoresToolStripMenuItem.Image = My.Resources.alert_icon_icons_com_52395
                PagamentosCimValidaçãoDeValoresToolStripMenuItem.Enabled = True

            End If

        Next

    End Sub
    Private Sub FunçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FunçõesToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        FrmListaFuncao.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub EquipesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipesToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        FrmEquipeOperacional.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ConsltarNotasFiscaisRecebidasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsltarNotasFiscaisRecebidasToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        Nf_Recebidas.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        FrmPagamento.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub PagamentosCimValidaçãoDeValoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagamentosCimValidaçãoDeValoresToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False
        FrmConfirmacaoValor.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Me.Cursor = Cursors.WaitCursor

        valOpc = 0

        Timer1.Enabled = False

        CarregaDashboard()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub OrdemDeCompraToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OrdemDeCompraToolStripMenuItem1.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmOtasOrdensCompra.Categoria = "Insumos - Comercial"
        FrmOtasOrdensCompra.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub OrdemDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdemDeCompraToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmOtasOrdensCompra.Categoria = "Insumos - Oficina"

        FrmOtasOrdensCompra.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub OrdemDeCompraToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles OrdemDeCompraToolStripMenuItem3.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmOtasOrdensCompra.Categoria = "Insumos - Engenharia"

        FrmOtasOrdensCompra.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub OrdemDeCompraToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OrdemDeCompraToolStripMenuItem2.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmOtasOrdensCompra.Categoria = "Insumos - Financeiro"

        FrmOtasOrdensCompra.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub OrdemDeCompraToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles OrdemDeCompraToolStripMenuItem5.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmOtasOrdensCompra.Categoria = "Insumos - RH"

        FrmOtasOrdensCompra.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub OrdemDeCompraToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles OrdemDeCompraToolStripMenuItem4.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmOtasOrdensCompra.Categoria = "Estoque"

        FrmOtasOrdensCompra.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub AcompanharPedidosOnlineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcompanharPedidosOnlineToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmCompraOnline.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ExpediçãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpediçãoToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmExpedicao.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ConfiguraçõesDoFISCOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraçõesDoFISCOToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        Fisco.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub PrestadoresDeServiçoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrestadoresDeServiçoToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmNovoFornecedor.CkFornecedorInsumo.Enabled = False
        FrmNovoFornecedor.CkFornecedorInsumo.Checked = False
        FrmNovoFornecedor.CkTransportadora.Enabled = True
        FrmNovoFornecedor.CkTransportadora.Checked = False
        FrmNovoFornecedor.CkComissionado.Enabled = True
        FrmNovoFornecedor.CkComissionado.Checked = False
        FrmNovoFornecedor.CkComissionado.Enabled = True
        FrmNovoFornecedor.CkComissionado.Checked = False

        FrmNovoFornecedor.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ListaDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmListaClientes.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmRiscos.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmAcessoriaTrabalhista.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ESocialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ESocialToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmSST.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Dim EsperaC As Integer = 0
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If EsperaC = 0 Then
            Timer2.Enabled = False
        Else
            EsperaC -= 1
        End If

    End Sub

    Private Sub S22010ComunicaçãoDeAcidenteDeTrabalhoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles S22010ComunicaçãoDeAcidenteDeTrabalhoToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        Form2210.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub AbrirPainelEmissorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirPainelEmissorToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Timer1.Enabled = False

        FrmESocial.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub
End Class

