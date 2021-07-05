Public Class FrmEntradaVeiculo
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim LqPrestador As New LqPrestadorDataContext
    Dim LqJarves As New LqJarbesDataContext

    Public _Placa As String

    Public _IdPrestador As Integer

    Private Sub BttBuscarRg_Click(sender As Object, e As EventArgs) Handles BttBuscarRg.Click

        'busca nos prestadores

        'verifica se existe pedido para entregar

        Dim BuscaPedidosTransp = From trans In LqPrestador.PedidosTransp
                                 Where trans.IdClienteEntrega = FrmPrincipal.IdCliente And trans.DataEntrega = "11-11-1111"
                                 Select trans.IdPrestador, trans.IdVeiculo, trans.IdPedido

        TxtNomeCompleto.Text = Nothing
        TxtCelular.Text = Nothing
        TxtEmail.Text = Nothing
        TxtPlaca.Text = Nothing
        TxtModelo.Text = Nothing

        TxtNomeCompleto.Enabled = False

        LblPedido.Visible = False

        For Each row In BuscaPedidosTransp.ToList
            'busca dados do prestador e compara com o rg preenchido

            Dim BUscaRG = From trans In LqJarves.ClientesJv
                          Where trans.IdClienteJv = row.IdPrestador
                          Select trans.RG_IEJv, trans.NomeCompletoJv, trans.CelularJv, trans.EmailJv

            If BUscaRG.First.RG_IEJv.ToString.ToLower = TxtRg.Text.ToLower Then

                'verifica se o item transportado é o mesmo da placa identificada pelo sistema

                Dim BuscaItem = From it In LqPrestador.ItemsTransportados
                                Where it.descricao Like _Placa And it.IdPedido = row.IdPedido
                                Select it.NF

                If BuscaItem.Count > 0 Then

                    TxtNomeCompleto.Text = BUscaRG.First.NomeCompletoJv
                    TxtCelular.Text = BUscaRG.First.CelularJv
                    TxtEmail.Text = BUscaRG.First.EmailJv

                    'verifica veiculo que deveria estar realizando a entrega

                    Dim BuscaVeiculo = From trans In LqPrestador.VeiculosPrest
                                       Where trans.IdVeiculoPrest = row.IdVeiculo
                                       Select trans.PlacaPrest, trans.ModeloPrest

                    TxtPlaca.Text = BuscaVeiculo.First.PlacaPrest
                    TxtModelo.Text = BuscaVeiculo.First.ModeloPrest

                    LblPedido.Visible = True
                    LblPedido.Text = row.IdPedido

                    _IdPrestador = row.IdPrestador

                    'busca cheklist do prestador

                    BttBuscarCliente.Enabled = True

                Else

                    BttBuscarCliente.Enabled = False

                    'verifica na base interna

                    Dim BuscaPRestadorInterno = From prest In LqOficina.Prestadores_Entrega
                                                Where prest.RG Like TxtRg.Text
                                                Select prest.IdPrestJv, prest.NomeCompleto, prest.CelularN, prest.Email, prest.Placa

                    If BuscaPRestadorInterno.Count > 0 Then

                        'carrega no base dados atualizados


                        'buscaprestador externo

                        Dim BusvaNOBddJv = From jv In LqJarves.ClientesJv
                                           Where jv.IdClienteJv = BuscaPRestadorInterno.First.IdPrestJv
                                           Select jv.CelularJv, jv.EmailJv

                        If BusvaNOBddJv.Count > 0 Then

                            'verifica veiculo que deveria estar realizando a entrega

                            Dim BuscaVeiculo = From trans In LqPrestador.Logins
                                               Where trans.IdPrestador = BuscaPRestadorInterno.First.IdPrestJv
                                               Select trans.IdVeiculo


                            TxtNomeCompleto.Text = BuscaPRestadorInterno.First.NomeCompleto
                            TxtCelular.Text = BuscaPRestadorInterno.First.CelularN
                            TxtEmail.Text = BuscaPRestadorInterno.First.Email

                            'verifica veiculo que deveria estar realizando a entrega

                            Dim BuscaVeiculop = From trans In LqPrestador.VeiculosPrest
                                                Where trans.IdVeiculoPrest = BuscaVeiculo.First
                                                Select trans.PlacaPrest, trans.ModeloPrest

                            TxtPlaca.Text = BuscaVeiculop.First.PlacaPrest
                            TxtModelo.Text = BuscaVeiculop.First.ModeloPrest

                            LblPedido.Visible = False

                            _IdPrestador = BuscaPRestadorInterno.First.IdPrestJv

                            BttBuscarCliente.Enabled = True

                        Else

                            TxtNomeCompleto.Text = BuscaPRestadorInterno.First.NomeCompleto
                            TxtCelular.Text = BuscaPRestadorInterno.First.CelularN
                            TxtEmail.Text = BuscaPRestadorInterno.First.Email
                            TxtPlaca.Text = BuscaPRestadorInterno.First.Placa
                            TxtModelo.Text = "Modelo não identificado"

                            LblPedido.Visible = False

                        End If

                    End If

                End If

            End If

        Next

        'verifica cadastro no bdd

        If TxtNomeCompleto.Text = "" Then

            'busca no banco de dados do jarves

            Dim BusvaNOBddJv = From jv In LqJarves.ClientesJv
                               Where jv.RG_IEJv Like TxtRg.Text
                               Select jv.CelularJv, jv.EmailJv, jv.IdClienteJv, jv.NomeCompletoJv

            If BusvaNOBddJv.Count > 0 Then

                'verifica veiculo que deveria estar realizando a entrega

                Dim BuscaVeiculo = From trans In LqPrestador.Logins
                                   Where trans.IdPrestador = BusvaNOBddJv.First.IdClienteJv
                                   Select trans.IdVeiculo


                TxtNomeCompleto.Text = BusvaNOBddJv.First.NomeCompletoJv
                TxtCelular.Text = BusvaNOBddJv.First.CelularJv
                TxtEmail.Text = BusvaNOBddJv.First.EmailJv

                'verifica veiculo que deveria estar realizando a entrega

                Dim BuscaVeiculop = From trans In LqPrestador.VeiculosPrest
                                    Where trans.IdVeiculoPrest = BuscaVeiculo.First
                                    Select trans.PlacaPrest, trans.ModeloPrest

                TxtPlaca.Text = BuscaVeiculop.First.PlacaPrest
                TxtModelo.Text = BuscaVeiculop.First.ModeloPrest

                LblPedido.Visible = False

                _IdPrestador = BusvaNOBddJv.First.IdClienteJv

                BttBuscarCliente.Enabled = True

            Else

                BttBuscarCliente.Enabled = False
                TxtNomeCompleto.Enabled = True

            End If

        End If


    End Sub

    Private Sub TxtRg_TextChanged(sender As Object, e As EventArgs) Handles TxtRg.TextChanged

        If TxtRg.Text.Length > 7 Then
            BttBuscarRg.Enabled = True
        Else

            BttBuscarRg.Enabled = False

            TxtNomeCompleto.Text = ""
            TxtNomeCompleto.Enabled = False

        End If

    End Sub

    Private Sub MaskedTextBox2_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCelular.MaskInputRejected

    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Dim LqBase As New DtCadastroDataContext

    Public _IdVeiculo As Integer
    Public _IdCliente As Integer

    Private Sub BttBuscarCliente_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtRg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtRg.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BttBuscarRg.PerformClick()
        End If

    End Sub

    Private Sub TxtNomeCompleto_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeCompleto.TextChanged

        If TxtNomeCompleto.Enabled = True Then

            If TxtNomeCompleto.Text <> "" Then

                TxtCelular.Enabled = True

            Else

                TxtCelular.Text = Nothing
                TxtCelular.Enabled = False

            End If

        End If

    End Sub

    Private Sub TxtEmail_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtEmail.MaskInputRejected

    End Sub

    Private Sub TxtPlaca_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtPlaca.MaskInputRejected

    End Sub

    Private Sub TxtPlaca_TextChanged(sender As Object, e As EventArgs) Handles TxtPlaca.TextChanged

        If TxtPlaca.Enabled = True Then

            If TxtPlaca.Text <> "" Then

                TxtModelo.Enabled = True

            Else

                TxtModelo.Text = Nothing
                TxtModelo.Enabled = False

            End If

        End If

    End Sub

    Private Sub TxtModelo_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtModelo.MaskInputRejected

    End Sub

    Private Sub TxtCelular_TextChanged(sender As Object, e As EventArgs) Handles TxtCelular.TextChanged

        If TxtCelular.Enabled = True Then

            If TxtCelular.Text <> "" Then

                TxtEmail.Enabled = True

            Else

                TxtEmail.Text = Nothing
                TxtEmail.Enabled = False

            End If

        End If

    End Sub

    Private Sub TxtEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtEmail.TextChanged

        If TxtEmail.Enabled = True Then

            If TxtEmail.Text <> "" Then

                TxtPlaca.Enabled = True

            Else

                TxtPlaca.Text = Nothing
                TxtPlaca.Enabled = False

            End If

        End If

    End Sub

    Private Sub TxtModelo_TextChanged(sender As Object, e As EventArgs) Handles TxtModelo.TextChanged

        If TxtModelo.Enabled = True Then

            If TxtModelo.Text <> "" Then

                BttBuscarCliente.Enabled = True

            Else

                BttBuscarCliente.Enabled = False

            End If

        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RdbProprietario.CheckedChanged

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        If RdbPrestador.Checked = True Then

            TxtRg.Text = ""
            TxtRg.Enabled = True

            BttBuscarCliente.Enabled = False

        Else

            TxtRg.Text = ""
            TxtRg.Enabled = False

            'busca dados do cliente

            Dim BuscaCliente = From cli In LqOficina.Veiculos
                               Where cli.IdVeiculo = _IdVeiculo
                               Select cli.IdCliente

            'busca dados 

            Dim BuscaDados = From cli In LqBase.Clientes
                             Where cli.IdCliente = BuscaCliente.First
                             Select cli.RazaoSocial_nome, cli.Email, cli.Celular, cli.RG_IE

            TxtNomeCompleto.Text = BuscaDados.First.RazaoSocial_nome
            TxtCelular.Text = BuscaDados.First.Celular
            TxtEmail.Text = BuscaDados.First.Email
            TxtRg.Text = BuscaDados.First.RG_IE

            BttBuscarCliente.Enabled = True

        End If

    End Sub

    Private Sub FrmEntradaVeiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        FrmNovoORçamento.Show(FrmPrincipal)

    End Sub

    Private Sub PicAvaliações_Click(sender As Object, e As EventArgs) Handles PicAvaliações.Click

    End Sub

    Private Sub PicAvaliações_MouseMove(sender As Object, e As MouseEventArgs) Handles PicAvaliações.MouseMove

        Dim X_int As Integer = PicAvaliações.Width
        Dim Y_int As Integer = PicAvaliações.Height

        Dim PintarBitmap1 = New Bitmap(X_int, Y_int)

        Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

        'varre o treeview

        For Each row As TreeNode In TrAvaliações.Nodes

            Dim _X As Decimal = row.Nodes(0).Text
            Dim _Y As Decimal = row.Nodes(1).Text
            Dim _SizeX As Decimal = row.Nodes(2).Text
            Dim _SizeY As Decimal = row.Nodes(3).Text

            'verifica 

            If _X <= e.X And _X + _SizeX >= e.X Then

                'varre categorias

                For Each row1 As TreeNode In row.Nodes(4).Nodes

                    Dim _X1 As Decimal = row1.Nodes(0).Nodes(2).Text
                    Dim _Y1 As Decimal = row1.Nodes(0).Nodes(3).Text
                    Dim _SizeX1 As Decimal = 65
                    Dim _SizeY1 As Decimal = 30

                    If _X1 <= e.X And _X1 + _SizeX1 >= e.X Then

                        If _Y1 <= e.Y And _Y1 + _SizeY1 >= e.Y Then

                            Dim Draw As Boolean = False

                            If Draw = False Then
                                'pinta o titulo

                                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.OrangeRed)), _X + (_SizeX - 180), _Y - 10, _SizeX - 190, 25)
                                Pintura1.DrawString(row1.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), _X + (_SizeX - 170), _Y - 5)

                                Pintura1.DrawLine(New Pen(New SolidBrush(Color.OrangeRed), 1), _X1 + _SizeX1, _Y1 + _SizeY1, _X + _SizeX + 5, _Y1 + _SizeY1)
                                Pintura1.DrawLine(New Pen(New SolidBrush(Color.OrangeRed), 1), _X + _SizeX + 5, _Y1 + _SizeY1, _X + _SizeX + 5, _Y + 15)

                                Pintura1.FillEllipse(New SolidBrush(Color.FromArgb(230, Color.SlateGray)), _X + _SizeX, _Y + 10, 10, 10)
                                Pintura1.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(180, Color.OrangeRed)), 1), _X + _SizeX, _Y + 10, 10, 10)

                                Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(180, Color.SlateGray)), 1), _X + (_SizeX - 180), _Y - 10, _SizeX - 190, 25)

                            End If

                            For i As Integer = 0 To row1.Nodes.Count - 1

                                Dim _X2 As Decimal = row1.Nodes(i).Nodes(0).Text
                                Dim _Y2 As Decimal = row1.Nodes(i).Nodes(1).Text

                                If Draw = False Then

                                    Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(180, Color.SlateGray)), 1), _X1, _Y1, _SizeX1, _SizeY1)
                                    Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.OrangeRed)), _X1, _Y1, _SizeX1, _SizeY1)

                                    Pintura1.FillEllipse(New SolidBrush(Color.FromArgb(180, Color.OrangeRed)), _SizeX1 + _X1 - 5, _Y1 - 5, 10, 10)
                                    Pintura1.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(180, Color.SlateGray)), 1), _SizeX1 + _X1 - 5, _Y1 - 5, 10, 10)
                                    Draw = True

                                End If

                                Pintura1.DrawLine(New Pen(New SolidBrush(Color.FromArgb(180, Color.OrangeRed)), 1), _SizeX1 + _X1, _Y1, _X2, _Y2)
                                Pintura1.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(180, Color.OrangeRed)), 1), _X2, _Y2, 15, 15)
                                Pintura1.FillEllipse(New SolidBrush(Color.FromArgb(180, Color.OrangeRed)), _X2 - 5, _Y2 - 5, 10, 10)
                                Pintura1.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(180, Color.SlateGray)), 1), _X2 - 5, _Y2 - 5, 10, 10)

                            Next

                        End If

                        End If

                Next

            End If

        Next

        PicAvaliações.Image = PintarBitmap1

    End Sub

    Dim _IdCategoria As Integer = 0
    Dim _IdSubCategoria As Integer = 0

    Private Sub PicAvaliações_MouseClick(sender As Object, e As MouseEventArgs) Handles PicAvaliações.MouseClick

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim X_int As Integer = PicAvaliações.Width
        Dim Y_int As Integer = PicAvaliações.Height

        Dim PintarBitmap1 = New Bitmap(X_int, Y_int)

        Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

        'varre o treeview

        For Each row As TreeNode In TrAvaliações.Nodes

            Dim _X As Decimal = row.Nodes(0).Text
            Dim _Y As Decimal = row.Nodes(1).Text
            Dim _SizeX As Decimal = row.Nodes(2).Text
            Dim _SizeY As Decimal = row.Nodes(3).Text

            'verifica 

            If _X <= e.X And _X + _SizeX >= e.X Then

                'varre categorias

                For Each row1 As TreeNode In row.Nodes(4).Nodes

                    Dim _IdMarca As Integer = row.Text
                    Dim _X1 As Decimal = row1.Nodes(0).Nodes(2).Text
                    Dim _Y1 As Decimal = row1.Nodes(0).Nodes(3).Text

                    Dim _SizeX1 As Decimal = 65
                    Dim _SizeY1 As Decimal = 30

                    If _X1 <= e.X And _X1 + _SizeX1 >= e.X Then

                        If _Y1 <= e.Y And _Y1 + _SizeY1 >= e.Y Then

                            Dim NumSolucao As Integer = 0

                            'insere nova solução

                            'verifica se existem orçamentos em aberto

                            Dim BuscaOrcamento = From orc In LqComercial.Orcamentos
                                                 Where orc.IdCliente = _IdCliente And orc.IdVeiculo = _IdVeiculo And orc.Aprovado = False
                                                 Select orc.IdOrcamento
                                                 Order By IdOrcamento Descending

                            If BuscaOrcamento.Count = 0 Then

                                LqComercial.InsereNovoOrcamento(FrmPrincipal.IdUsuario, 0, "1111/11/11", Today.TimeOfDay, Today.Date, Now.TimeOfDay, _IdCliente, _IdVeiculo, False, "1111/11/11", Today.TimeOfDay, 0, NumSolucao, 0, 0, False, False, 0, "1111-11-11")

                                'busca ID do Orçamento

                                Dim BuscaOrcamentoNOvo = From orc In LqComercial.Orcamentos
                                                         Where orc.IdCliente = _IdCliente And orc.IdVeiculo = _IdVeiculo
                                                         Select orc.IdOrcamento
                                                         Order By IdOrcamento Descending

                                FrmNovoORçamento.LblNumOrcamento.Text = BuscaOrcamentoNOvo.First

                            Else

                                FrmNovoORçamento.LblNumOrcamento.Text = BuscaOrcamento.First

                            End If

                            'verifica marcas no evento click

                            Dim buscaImagem = From img In LqOficina.ImagemRespostaCklist
                                              Where img.IdImagemProcesso = _IdMarca
                                              Select img.Titulo, img.IdProcesso

                            Dim Contexto As String = BuscaImagem.First.Titulo

                            Dim str As String = Contexto
                            Dim separador As String = ","
                            Dim palavras As String() = str.Split(separador)
                            Dim LstPalavras As New ListBox
                            Dim palavra As String

                            For Each palavra In palavras
                                LstPalavras.Items.Add(palavra)
                            Next

                            Dim _categoria As String = LstPalavras.Items(0).ToString
                            Dim _SubCategoria As String = LstPalavras.Items(1).ToString

                            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                            'aponta categoria e subcategoria de itens

                            Dim BuscaCategoria = From Cat In LqBase.CategoriasProdutos
                                                 Where Cat.Descricao Like _categoria
                                                 Select Cat.Descricao, Cat.IdCategoriaProduto

                            For Each row0 In BuscaCategoria.ToList

                                FrmNovoORçamento.CmbCategoria.Items.Add(row0.Descricao)
                                FrmNovoORçamento.LstIdCategoria.Items.Add(row0.IdCategoriaProduto)

                            Next

                            FrmNovoORçamento.CmbCategoria.SelectedIndex = 0
                            FrmNovoORçamento.CmbSubCategoria.SelectedItem = _SubCategoria

                            'desabilita campos para edição

                            FrmNovoORçamento.CmbCategoria.Enabled = False
                            FrmNovoORçamento.CmbSubCategoria.Enabled = False

                            'busca dados do cliente

                            Dim BuscaCliente = From cli In LqOficina.Veiculos
                                               Where cli.IdVeiculo = _IdVeiculo
                                               Select cli.IdCliente, cli.IdModelo, cli.IdVersao

                            Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                 Where orc.IdVeiculo = _IdVeiculo
                                                 Select orc.IdOrcamento, orc.IdCliente, orc.DataOrc, orc.Aprovado, orc.DataAprov

                            FrmNovoORçamento.Show(Me)

                            Dim _IdOrçamento As Integer = BuscaOrçamento.First.IdOrcamento

                            Dim _Versao As Integer = 0

                            Dim _TotalVersap As Decimal
                            Dim LstValoresVErsao As New ListBox
                            Dim LstDataVersao As New ListBox

                            'popula associação

                            Dim LqFinanceiro As New LqFinanceiroDataContext
                            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                            Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                            LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                            'busca dados 

                            Dim BuscaDados = From cli In LqBase.Clientes
                                             Where cli.IdCliente = BuscaCliente.First.IdCliente
                                             Select cli.RazaoSocial_nome, cli.Email, cli.Celular, cli.RG_IE, cli.CPF_CNPJ

                            FrmNovoORçamento.TxtCNPJ.Text = BuscaDados.First.CPF_CNPJ
                            FrmNovoORçamento.TxtCNPJ.Enabled = False
                            FrmNovoORçamento.LblRazãoSocial.Text = BuscaDados.First.RazaoSocial_nome


                            For Each rowOrc In BuscaOrçamento.ToList

                                Dim BuscaProdutos = From orc In LqComercial.ProdutosOrcamento
                                                    Where orc.IdOrcamento = rowOrc.IdOrcamento
                                                    Select orc.Tipo, orc.IdProduto, orc.IdSolicitacao, orc.ValorUnit, orc.DescontoUnit, orc.IdProdutoOrcamento, orc.Qtdade, orc.Versao, orc.DataVersao

                                For Each rowOrc1 In BuscaProdutos.ToList

                                    If rowOrc1.Tipo = True Then

                                        'edita o parent

                                        If rowOrc1.ValorUnit = 0 Then

                                            'busca cotação

                                            If rowOrc1.IdSolicitacao = 0 Then

                                                Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                                    Where cot.IdProduto = rowOrc1.IdProduto
                                                                    Select cot.ValorCotado, cot.DataCotacao
                                                                    Order By DataCotacao Descending

                                                If _Versao <> rowOrc1.Versao Then

                                                    FrmNovoORçamento.VerOrc = rowOrc1.Versao

                                                    _Versao = rowOrc1.Versao

                                                    FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                                    FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                    FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(rowOrc1.DataVersao, DateFormat.ShortDate)

                                                    'apaga todos os selecionados anteriormente

                                                    For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                        rowLimpa.Cells(0).Value = False
                                                        rowLimpa.Cells(9).Value = 0
                                                        rowLimpa.Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                                                        rowLimpa.Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                                                    Next

                                                    _TotalVersap = 0

                                                    'atualiza selecionado

                                                End If

                                                Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                                If BuscaCotações.Count > 0 Then

                                                    'insere no treeview

                                                    If rowOrc1.IdProduto <> 0 Then

                                                        Dim BuscaProduto = From prod In LqBase.Produtos
                                                                           Where prod.IdProduto = rowOrc1.IdProduto
                                                                           Select prod.Descricao

                                                        TrProdutos.Nodes.Add(rowOrc1.IdProduto & " - " & BuscaProduto.First)
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) & " x " & rowOrc1.Qtdade & " = " & FormatCurrency(BuscaCotações.First.ValorCotado * rowOrc1.Qtdade, NumDigitsAfterDecimal:=2))

                                                        For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                            If rowProduto.Cells(1).Value.ToString = rowOrc1.IdProduto.ToString And rowOrc1.Versao = _Versao Then

                                                                rowProduto.Cells(0).Value = True

                                                                rowProduto.Cells(7).Value = FormatCurrency((BuscaCotações.First.ValorCotado), NumDigitsAfterDecimal:=2)

                                                                rowProduto.Cells(9).Value = FormatNumber(rowOrc1.Qtdade, NumDigitsAfterDecimal:=0)

                                                                rowProduto.Cells(11).Value = FormatPercent(rowOrc1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                                Dim Desconto As String = rowProduto.Cells(11).Value
                                                                Desconto = Desconto.Replace("%", "")

                                                                Dim Vl_Desconto As Decimal = Desconto

                                                                rowProduto.Cells(12).Value = FormatCurrency(((BuscaCotações.First.ValorCotado - (BuscaCotações.First.ValorCotado * (Vl_Desconto / 100))) * rowOrc1.Qtdade), NumDigitsAfterDecimal:=2)

                                                                _TotalVersap += rowProduto.Cells(12).Value

                                                                LstValoresVErsao.Items.Add(_TotalVersap)
                                                                LstDataVersao.Items.Add(rowOrc1.DataVersao)

                                                            End If

                                                        Next

                                                    Else


                                                        Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                                           Where prod.IdSolicitacaoCadastro = rowOrc1.IdSolicitacao
                                                                           Select prod.Descricao

                                                        TrProdutos.Nodes.Add("S" & rowOrc1.IdSolicitacao & " - " & BuscaProduto.First)
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) & " x " & rowOrc1.Qtdade & " = " & FormatCurrency(BuscaCotações.First.ValorCotado * rowOrc1.Qtdade, NumDigitsAfterDecimal:=2))

                                                        For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                            If rowProduto.Cells(1).Value = rowOrc1.IdProduto And rowOrc1.Versao = _Versao Then

                                                                rowProduto.Cells(0).Value = True

                                                                rowProduto.Cells(7).Value = FormatCurrency((BuscaCotações.First.ValorCotado), NumDigitsAfterDecimal:=2)

                                                                rowProduto.Cells(9).Value = FormatNumber(rowOrc1.Qtdade, NumDigitsAfterDecimal:=0)

                                                                rowProduto.Cells(11).Value = FormatPercent(rowOrc1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                                Dim Desconto As String = rowProduto.Cells(11).Value
                                                                Desconto = Desconto.Replace("%", "")

                                                                Dim Vl_Desconto As Decimal = Desconto

                                                                rowProduto.Cells(12).Value = FormatCurrency(((BuscaCotações.First.ValorCotado - (BuscaCotações.First.ValorCotado * (Vl_Desconto / 100))) * rowOrc1.Qtdade), NumDigitsAfterDecimal:=2)

                                                                _TotalVersap += rowProduto.Cells(12).Value

                                                                LstValoresVErsao.Items.Add(_TotalVersap)
                                                                LstDataVersao.Items.Add(rowOrc1.DataVersao)

                                                            End If

                                                        Next

                                                    End If

                                                End If

                                            Else

                                                Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                                    Where cot.IdSolicitacaoCad = rowOrc1.IdSolicitacao
                                                                    Select cot.ValorCotado, cot.DataCotacao
                                                                    Order By DataCotacao Descending

                                                If _Versao <> rowOrc1.Versao Then

                                                    FrmNovoORçamento.VerOrc = rowOrc1.Versao

                                                    _Versao = rowOrc1.Versao

                                                    FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                                    FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                    FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(rowOrc1.DataVersao, DateFormat.ShortDate)

                                                    'apaga todos os selecionados anteriormente

                                                    For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                        rowLimpa.Cells(0).Value = False
                                                        rowLimpa.Cells(9).Value = 0
                                                        rowLimpa.Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                                                        rowLimpa.Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                                                    Next

                                                    _TotalVersap = 0

                                                    'atualiza selecionado

                                                End If

                                                Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                                If BuscaCotações.Count > 0 Then

                                                    'insere no treeview

                                                    If rowOrc1.IdProduto <> 0 Then

                                                        Dim BuscaProduto = From prod In LqBase.Produtos
                                                                           Where prod.IdProduto = rowOrc1.IdProduto
                                                                           Select prod.Descricao

                                                        TrProdutos.Nodes.Add(rowOrc1.IdProduto & " - " & BuscaProduto.First)
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) & " x " & rowOrc1.Qtdade & " = " & FormatCurrency(BuscaCotações.First.ValorCotado * rowOrc1.Qtdade, NumDigitsAfterDecimal:=2))

                                                        For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                            If rowProduto.Cells(1).Value = rowOrc1.IdProduto And rowOrc1.Versao = _Versao Then

                                                                rowProduto.Cells(0).Value = True

                                                                rowProduto.Cells(7).Value = FormatCurrency((BuscaCotações.First.ValorCotado), NumDigitsAfterDecimal:=2)

                                                                rowProduto.Cells(9).Value = FormatNumber(rowOrc1.Qtdade, NumDigitsAfterDecimal:=0)

                                                                rowProduto.Cells(11).Value = FormatPercent(rowOrc1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                                Dim Desconto As String = rowProduto.Cells(11).Value
                                                                Desconto = Desconto.Replace("%", "")

                                                                Dim Vl_Desconto As Decimal = Desconto

                                                                rowProduto.Cells(12).Value = FormatCurrency(((BuscaCotações.First.ValorCotado - (BuscaCotações.First.ValorCotado * (Vl_Desconto / 100))) * rowOrc1.Qtdade), NumDigitsAfterDecimal:=2)

                                                                _TotalVersap += rowProduto.Cells(12).Value

                                                                LstValoresVErsao.Items.Add(_TotalVersap)
                                                                LstDataVersao.Items.Add(rowOrc1.DataVersao)

                                                            End If

                                                        Next

                                                    Else

                                                        Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                                           Where prod.IdSolicitacaoCadastro = rowOrc1.IdSolicitacao
                                                                           Select prod.Descricao

                                                        TrProdutos.Nodes.Add("S" & rowOrc1.IdSolicitacao & " - " & BuscaProduto.First)
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) & " x " & rowOrc1.Qtdade & " = " & FormatCurrency(BuscaCotações.First.ValorCotado * rowOrc1.Qtdade, NumDigitsAfterDecimal:=2))

                                                        For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                            If rowProduto.Cells(1).Value.ToString = "S" & rowOrc1.IdSolicitacao.ToString And rowOrc1.Versao = _Versao Then

                                                                rowProduto.Cells(0).Value = True

                                                                rowProduto.Cells(7).Value = FormatCurrency((BuscaCotações.First.ValorCotado), NumDigitsAfterDecimal:=2)

                                                                rowProduto.Cells(9).Value = FormatNumber(rowOrc1.Qtdade, NumDigitsAfterDecimal:=0)

                                                                rowProduto.Cells(11).Value = FormatPercent(rowOrc1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                                Dim Desconto As String = rowProduto.Cells(11).Value
                                                                Desconto = Desconto.Replace("%", "")

                                                                Dim Vl_Desconto As Decimal = Desconto

                                                                rowProduto.Cells(12).Value = FormatCurrency(((BuscaCotações.First.ValorCotado - (BuscaCotações.First.ValorCotado * (Vl_Desconto / 100))) * rowOrc1.Qtdade), NumDigitsAfterDecimal:=2)

                                                                _TotalVersap += rowProduto.Cells(12).Value

                                                                LstValoresVErsao.Items.Add(_TotalVersap)
                                                                LstDataVersao.Items.Add(rowOrc1.DataVersao)

                                                            End If

                                                        Next

                                                    End If

                                                End If

                                            End If

                                        Else

                                            If rowOrc1.IdSolicitacao = 0 Then

                                                'busca estoque

                                                Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                                                       Where arm.IdProduto = rowOrc1.IdProduto
                                                                       Select arm.Qt, arm.ValorUnit

                                                If BuscaArmazenagem.Count = 0 Then

                                                    Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                                        Where cot.IdProduto = rowOrc1.IdProduto
                                                                        Select cot.ValorCotado, cot.DataCotacao
                                                                        Order By DataCotacao Descending

                                                    If _Versao <> rowOrc1.Versao Then

                                                        FrmNovoORçamento.VerOrc = rowOrc1.Versao

                                                        _Versao = rowOrc1.Versao

                                                        FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                                        FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                        FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(rowOrc1.DataVersao, DateFormat.ShortDate)

                                                        'apaga todos os selecionados anteriormente

                                                        For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                            rowLimpa.Cells(0).Value = False

                                                        Next

                                                        _TotalVersap = 0

                                                        'atualiza selecionado

                                                    End If

                                                    Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                                    If BuscaCotações.Count > 0 Then

                                                        'insere no treeview

                                                        Dim BuscaProduto = From prod In LqBase.Produtos
                                                                           Where prod.IdProduto = rowOrc1.IdProduto
                                                                           Select prod.Descricao

                                                        TrProdutos.Nodes.Add(rowOrc1.IdProduto & " - " & BuscaProduto.First)
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) & " x " & rowOrc1.Qtdade & " = " & FormatCurrency(BuscaCotações.First.ValorCotado * rowOrc1.Qtdade, NumDigitsAfterDecimal:=2))

                                                        For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                            If rowProduto.Cells(1).Value = rowOrc1.IdProduto And rowOrc1.Versao = _Versao Then

                                                                rowProduto.Cells(0).Value = True

                                                                rowProduto.Cells(7).Value = FormatCurrency((BuscaCotações.First.ValorCotado), NumDigitsAfterDecimal:=2)

                                                                rowProduto.Cells(9).Value = FormatNumber(rowOrc1.Qtdade, NumDigitsAfterDecimal:=0)

                                                                rowProduto.Cells(11).Value = FormatPercent(rowOrc1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                                Dim Desconto As String = rowProduto.Cells(11).Value
                                                                Desconto = Desconto.Replace("%", "")

                                                                Dim Vl_Desconto As Decimal = Desconto

                                                                rowProduto.Cells(12).Value = FormatCurrency(((BuscaCotações.First.ValorCotado - (BuscaCotações.First.ValorCotado * (Vl_Desconto / 100))) * rowOrc1.Qtdade), NumDigitsAfterDecimal:=2)

                                                                _TotalVersap += rowProduto.Cells(12).Value

                                                                LstValoresVErsao.Items.Add(_TotalVersap)
                                                                LstDataVersao.Items.Add(rowOrc1.DataVersao)

                                                            End If

                                                        Next

                                                    End If

                                                End If

                                            End If

                                        End If

                                    Else

                                        If rowOrc1.ValorUnit = 0 Then

                                            'busca cotação

                                            Dim BuscaProduto = From prod In LqBase.Servicos
                                                               Where prod.IdServico = rowOrc1.IdProduto
                                                               Select prod.Descricao, prod.VlrVeda

                                            If _Versao <> rowOrc1.Versao Then

                                                FrmNovoORçamento.VerOrc = rowOrc1.Versao

                                                _Versao = rowOrc1.Versao

                                                FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                                FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(rowOrc1.DataVersao, DateFormat.ShortDate)

                                                'apaga todos os selecionados anteriormente

                                                For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    rowLimpa.Cells(0).Value = False
                                                    rowLimpa.Cells(9).Value = 0
                                                    rowLimpa.Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                                                    rowLimpa.Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                                                Next

                                                _TotalVersap = 0

                                                'atualiza selecionado

                                            End If

                                            Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                            'insere no treeview

                                            If rowOrc1.IdProduto <> 0 Then

                                                TrProdutos.Nodes.Add(rowOrc1.IdProduto & " - " & BuscaProduto.First.Descricao & " (Serviço)")
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaProduto.First.VlrVeda, NumDigitsAfterDecimal:=2) & " x " & rowOrc1.Qtdade & " = " & FormatCurrency(BuscaProduto.First.VlrVeda * rowOrc1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtServiços.Rows

                                                    If rowProduto.Cells(1).Value = rowOrc1.IdProduto And rowOrc1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(3).Value = FormatCurrency((BuscaProduto.First.VlrVeda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(5).Value = FormatNumber(rowOrc1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(7).Value = FormatPercent(rowOrc1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(7).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(8).Value = FormatCurrency(((BuscaProduto.First.VlrVeda - (BuscaProduto.First.VlrVeda * (Vl_Desconto / 100))) * rowOrc1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(8).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(rowOrc1.DataVersao)

                                                    End If

                                                Next

                                            End If

                                        Else

                                            If rowOrc1.IdSolicitacao = 0 Then

                                                'busca estoque

                                                Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                                                       Where arm.IdProduto = rowOrc1.IdProduto
                                                                       Select arm.Qt, arm.ValorUnit

                                                If BuscaArmazenagem.Count = 0 Then

                                                    Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                                        Where cot.IdProduto = rowOrc1.IdProduto
                                                                        Select cot.ValorCotado, cot.DataCotacao
                                                                        Order By DataCotacao Descending

                                                    If _Versao <> rowOrc1.Versao Then

                                                        FrmNovoORçamento.VerOrc = rowOrc1.Versao

                                                        _Versao = rowOrc1.Versao

                                                        FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                                        FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                        FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(rowOrc1.DataVersao, DateFormat.ShortDate)

                                                        'apaga todos os selecionados anteriormente

                                                        For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                            rowLimpa.Cells(0).Value = False

                                                        Next

                                                        _TotalVersap = 0

                                                        'atualiza selecionado

                                                    End If

                                                    Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                                    If BuscaCotações.Count > 0 Then

                                                        'insere no treeview

                                                        Dim BuscaProduto = From prod In LqBase.Produtos
                                                                           Where prod.IdProduto = rowOrc1.IdProduto
                                                                           Select prod.Descricao

                                                        TrProdutos.Nodes.Add(rowOrc1.IdProduto & " - " & BuscaProduto.First)
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) & " x " & rowOrc1.Qtdade & " = " & FormatCurrency(BuscaCotações.First.ValorCotado * rowOrc1.Qtdade, NumDigitsAfterDecimal:=2))

                                                        For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                            If rowProduto.Cells(1).Value = rowOrc1.IdProduto And rowOrc1.Versao = _Versao Then

                                                                rowProduto.Cells(0).Value = True

                                                                rowProduto.Cells(7).Value = FormatCurrency((BuscaCotações.First.ValorCotado), NumDigitsAfterDecimal:=2)

                                                                rowProduto.Cells(9).Value = FormatNumber(rowOrc1.Qtdade, NumDigitsAfterDecimal:=0)

                                                                rowProduto.Cells(11).Value = FormatPercent(rowOrc1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                                Dim Desconto As String = rowProduto.Cells(11).Value
                                                                Desconto = Desconto.Replace("%", "")

                                                                Dim Vl_Desconto As Decimal = Desconto

                                                                rowProduto.Cells(12).Value = FormatCurrency(((BuscaCotações.First.ValorCotado - (BuscaCotações.First.ValorCotado * (Vl_Desconto / 100))) * rowOrc1.Qtdade), NumDigitsAfterDecimal:=2)

                                                                _TotalVersap += rowProduto.Cells(12).Value

                                                                LstValoresVErsao.Items.Add(_TotalVersap)
                                                                LstDataVersao.Items.Add(rowOrc1.DataVersao)

                                                            End If

                                                        Next

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                Next

                            Next

                            If FrmNovoORçamento.TrResumo.Nodes.Count > 0 Then
                                FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ExpandAll()
                            Else
                                FrmNovoORçamento.VerOrc = 1
                                FrmNovoORçamento.LblVersão.Text = 1

                                FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & FrmNovoORçamento.VerOrc)
                            End If

                            Dim Total As Decimal = 0
                            Dim DescontoTotal As Decimal = 0
                            Dim ValorFInal As Decimal = 0

                            Dim C As Integer = 0

                            For Each rowOrc2 As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                Dim valorUnit As Decimal = rowOrc2.Cells(7).Value
                                Dim Qt As Decimal = rowOrc2.Cells(9).Value
                                Dim Desconto As String = rowOrc2.Cells(11).Value
                                Desconto = Desconto.Replace("%", "")

                                Dim Vl_Desconto As Decimal = Desconto

                                If rowOrc2.Cells(0).Value = True Then
                                    Total += valorUnit * Qt
                                End If

                                DescontoTotal += (valorUnit * (Desconto / 100)) * Qt

                                ValorFInal += (valorUnit - (valorUnit * (Desconto / 100))) * Qt

                                If rowOrc2.Cells(0).Value = True And rowOrc2.Cells(7).Value = 0 Then
                                    C += 1
                                End If

                            Next

                            FrmNovoORçamento.LblSubtotal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
                            FrmNovoORçamento.LblDescontos.Text = FormatCurrency(DescontoTotal, NumDigitsAfterDecimal:=2)
                            FrmNovoORçamento.LblValorTotal.Text = FormatCurrency(ValorFInal, NumDigitsAfterDecimal:=2)

                            'popula chart

                            Dim LstX As New ListBox
                            Dim LstY As New ListBox

                            For i As Integer = 0 To LstDataVersao.Items.Count - 1

                                If Not LstY.Items.Contains(LstDataVersao.Items(i).ToString) Then

                                    Dim Para As Boolean = False

                                    For i1 As Integer = i To (LstDataVersao.Items.Count - 1)

                                        If LstDataVersao.Items(i).ToString <> LstDataVersao.Items(i1).ToString Then

                                            If Para = False Then

                                                Para = True

                                                If i1 < LstDataVersao.Items.Count - 1 Then
                                                    LstX.Items.Add(LstValoresVErsao.Items(i1 - 1).ToString)
                                                    LstY.Items.Add(FormatDateTime(LstDataVersao.Items(i1).ToString, DateFormat.ShortDate))

                                                ElseIf i1 = LstDataVersao.Items.Count - 1 Then
                                                    LstX.Items.Add(LstValoresVErsao.Items(i1).ToString)
                                                    LstY.Items.Add(FormatDateTime(LstDataVersao.Items(i1).ToString, DateFormat.ShortDate))

                                                End If

                                            End If

                                        End If

                                    Next

                                End If

                            Next

                            FrmNovoORçamento.LblVersão.Text = FrmNovoORçamento.VerOrc

                            'Busca formas de pagamento

                            Dim _Contatotal As Decimal = 0
                            Dim BuscaFormasPg = From orc In LqComercial.FormasPGOrcamento
                                                Where orc.IdOrcamento = FrmNovoORçamento.LblNumOrcamento.Text And orc.IdVersao = FrmNovoORçamento.LblVersão.Text
                                                Select orc.IdForma, orc.Pc, orc.Valor, orc.Vencimento

                            For Each rowOrc2 In BuscaFormasPg.ToList

                                Dim BuscaDescricao = From orc In LqFinanceiro.FormasPgEntrada
                                                     Where orc.IdFormasPgEntrada = rowOrc2.IdForma
                                                     Select orc.Descricao

                                FrmNovoORçamento.DtFormas.Rows.Add(rowOrc2.IdForma, BuscaDescricao.First, rowOrc2.Pc, FormatCurrency(rowOrc2.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(rowOrc2.Vencimento, DateFormat.ShortDate), My.Resources.Delete_80_icon_icons_com_57340)
                                _Contatotal += rowOrc2.Valor

                            Next

                            If C = 0 Then
                                FrmNovoORçamento.BttDeclinarOrc.Enabled = True
                            Else
                                FrmNovoORçamento.BttDeclinarOrc.Enabled = False
                            End If

                            If _Contatotal >= ValorFInal And ValorFInal > 0 Then
                                FrmNovoORçamento.BttAprovarOrc.Enabled = True
                                FrmNovoORçamento.CmbFormasPgEntrada.Enabled = False
                            ElseIf _Contatotal <= ValorFInal Or ValorFInal = 0 Then
                                FrmNovoORçamento.BttAprovarOrc.Enabled = False
                                FrmNovoORçamento.CmbFormasPgEntrada.Enabled = True
                            End If

                            'FrmNovoORçamento.ChTimeline.Series(0).Points.DataBindXY(LstY.Items, LstX.Items)

                            FrmNovoORçamento.Edita = True

                            FrmNovoORçamento.IdMarca = row1.Nodes(0).Nodes(4).Text

                        End If

                    End If

                Next

            End If

        Next

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles BttBuscarCliente.Click

        LqOficina.InsereNovaVistoriaVeiculo(_IdVeiculo, _IdCliente, "1111-11-11", Today.TimeOfDay, 0, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, False, 1, Today.TimeOfDay, "1111-11-11")

        FrmRespostaChecklist.Button1.Visible = False

        'insere no banco de dados o prestador, caso ele já não exista no sistema
        'buscaPrestador no sistema

        Dim BuscaPRestador = From prest In LqOficina.Prestadores_Entrega
                             Where prest.IdPrestJv = _IdPrestador
                             Select prest.NomeCompleto

        If BuscaPRestador.Count = 0 Then
            LqOficina.InserePrestadorEntrega(TxtNomeCompleto.Text, TxtPlaca.Text, 1, TxtRg.Text, _IdPrestador, TxtEmail.Text, TxtCelular.Text)
        End If

        'libera o prestador

        'busca dados do olaborador, e exige autenticação

        Frmvalidar._IdPrestador = _IdPrestador
        Frmvalidar._IdVeiculo = _IdVeiculo
        Frmvalidar._IdCliente = _IdCliente
        Frmvalidar._IdProcesso = LblProcesso.Text
        Frmvalidar._Placa = _Placa

        Frmvalidar.Show()

    End Sub
End Class