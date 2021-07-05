Public Class FrmNovoEstoque

    Dim LqCadastros As New DtCadastroDataContext

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If TxtDescrição.Text <> "" Then
            TxtCep.Enabled = True
        Else
            TxtCep.Enabled = False
            TxtCep.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttAddEndereço.Click

        FrmEndereço._CEP = TxtCep.Text
        FrmEndereço.FormOri = 1
        FrmEndereço.Show(Me)

    End Sub

    Private Sub TxtCep_TextChanged(sender As Object, e As EventArgs) Handles TxtCep.TextChanged
        LstIdEndereço.Items.Clear()
        CmbEndereço.Items.Clear()
        CmbEndereço.Text = ""

        If TxtCep.Text.Length >= 8 Then
            BttBuscaCep.Enabled = True
        Else
            BttBuscaCep.Enabled = False
        End If
    End Sub

    Public LstIdEndereço As New ListBox
    Public LstIdBairro As New ListBox

    Public LstIdPaisesTodos As New ListBox
    Public LstSiglaPais As New ListBox
    Public LstdescricaoPais As New ListBox

    Public LstIdCidadeTodos As New ListBox

    Public LstidEstadoTodos As New ListBox
    Public LstSiglaEstado As New ListBox
    Public LstdescricaoEstado As New ListBox

    Public LstIdBairroTodos As New ListBox

    Private Sub BttBuscaCep_Click(sender As Object, e As EventArgs) Handles BttBuscaCep.Click

        FNC = 0

        'LIMPA TODOS OS COMBOX

        CmbPais.Items.Clear()
        CmbEstado.Items.Clear()
        CmbCidade.Items.Clear()
        CmbBairro.Items.Clear()

        LstIdPaisesTodos.Items.Clear()
        LstidEstadoTodos.Items.Clear()
        LstIdCidadeTodos.Items.Clear()
        LstIdBairro.Items.Clear()
        LstdescricaoEstado.Items.Clear()
        LstSiglaEstado.Items.Clear()
        LstdescricaoPais.Items.Clear()
        LstSiglaPais.Items.Clear()

        CmbPais.Text = Nothing
        CmbEstado.Text = Nothing
        CmbCidade.Text = Nothing
        CmbBairro.Text = Nothing
        TxtNumero.Text = Nothing

        TxtNumero.Enabled = False
        CmbPais.Enabled = False
        CmbEstado.Enabled = False
        CmbCidade.Enabled = False
        CmbBairro.Enabled = False

        'busca pelo CEP

        Dim BuscaCep = From Cep In LqCadastros.Enderecos
                       Where Cep.CEP = TxtCep.Text
                       Select Cep.IdBairro, Cep.IdAbreviacao, Cep.IdEndereco, Cep.Descricao

        LstIdEndereço.Items.Clear()
        CmbEndereço.Items.Clear()

        For Each row In BuscaCep.ToList
            LstIdEndereço.Items.Add(row.IdEndereco)
            LstIdBairro.Items.Add(row.IdBairro)
            'busca descricao
            Dim Buscadescricao = From desc In LqCadastros.DescricaoLogradouros
                                 Where desc.IdDescricaoLog = row.IdAbreviacao
                                 Select desc.Abreviacao

            CmbEndereço.Items.Add(Buscadescricao.First & row.Descricao)
        Next

        'busca paises

        Dim BuscaPais = From pai In LqCadastros.Paises
                        Where pai.IdPais Like "*"
                        Select pai.Descricao, pai.Sigla, pai.IdPais

        LstIdPaisesTodos.Items.Clear()
        LstSiglaPais.Items.Clear()
        LstdescricaoPais.Items.Clear()
        CmbPais.Items.Clear()

        For Each row In BuscaPais.ToList

            LstIdPaisesTodos.Items.Add(row.IdPais)
            LstSiglaPais.Items.Add(row.Sigla)
            LstdescricaoPais.Items.Add(row.descricao)
            CmbPais.Items.Add(row.Sigla & " - " & row.descricao)

        Next

        If BuscaCep.Count = 0 Then

            CmbEndereço.Enabled = True
            BttAddEndereço.Enabled = True

            FrmEndereço._CEP = TxtCep.Text

            FrmEndereço.Show(Me)

        ElseIf BuscaCep.Count = 1 Then

            CmbEndereço.Enabled = False
            BttAddEndereço.Enabled = True

            CmbEndereço.SelectedIndex = 0

            'verifica se o bairro esta preenchido

            If LstIdBairro.Items(CmbEndereço.SelectedIndex).ToString = 0 Then
                CmbPais.Enabled = True
                BttAddPais.Enabled = True
            Else
                CmbPais.Enabled = False
                BttAddPais.Enabled = False
                CmbEstado.Enabled = False
                BttAddEstado.Enabled = False
                CmbCidade.Enabled = False
                BttAddCidade.Enabled = False
                CmbBairro.Enabled = False

                'seleciona o restante
                Dim BuscaBairro = From cid In LqCadastros.Bairro
                                  Where cid.IdBairro = Val(LstIdBairro.Items(CmbEndereço.SelectedIndex).ToString)
                                  Select cid.IdCidade, cid.Descricao, cid.IdBairro

                LstIdBairroTodos.Items.Clear()
                CmbBairro.Items.Clear()

                Dim _indexBairro As Integer

                For Each row In BuscaBairro.ToList
                    LstIdBairroTodos.Items.Add(row.IdBairro)
                    CmbBairro.Items.Add(row.descricao)

                    If row.IdBairro = BuscaBairro.First.IdBairro Then
                        _indexBairro = LstIdBairroTodos.Items.Count - 1
                    End If

                Next

                CmbBairro.SelectedIndex = _indexBairro

                'busca cidades

                Dim BuscaCidade = From cid In LqCadastros.Cidade
                                  Where cid.IdCidade Like "*"
                                  Select cid.IdEstado, cid.Descricao, cid.IdCidade

                LstIdCidadeTodos.Items.Clear()
                CmbCidade.Items.Clear()

                Dim _indexCid As Integer

                For Each row In BuscaCidade.ToList

                    LstIdCidadeTodos.Items.Add(row.IdCidade)
                    CmbCidade.Items.Add(row.descricao)

                    If row.IdCidade = BuscaBairro.First.IdCidade Then
                        _indexCid = LstIdCidadeTodos.Items.Count - 1
                    End If

                Next

                CmbCidade.SelectedIndex = _indexCid

                'busca Estados

                Dim BuscaEstado = From cid In LqCadastros.Estados
                                  Where cid.IdEstado Like "*"
                                  Select cid.IdPais, cid.Descricao, cid.Sigla, cid.IdEstado

                LstidEstadoTodos.Items.Clear()
                CmbEstado.Items.Clear()

                Dim _indexEst As Integer

                For Each row In BuscaEstado.ToList

                    LstidEstadoTodos.Items.Add(row.IdEstado)
                    CmbEstado.Items.Add(row.Sigla & " - " & row.descricao)

                    If row.IdEstado = BuscaCidade.First.IdEstado Then
                        _indexEst = LstidEstadoTodos.Items.Count - 1
                    End If

                Next

                CmbEstado.SelectedIndex = _indexEst

                Dim BuscaPaisTodos = From cid In LqCadastros.Paises
                                     Where cid.IdPais Like "*"
                                     Select cid.IdPais, cid.Descricao, cid.Sigla

                LstIdPaisesTodos.Items.Clear()
                CmbPais.Items.Clear()

                Dim _indexPais As Integer

                For Each row In BuscaPaisTodos.ToList

                    LstIdPaisesTodos.Items.Add(row.IdPais)
                    CmbPais.Items.Add(row.Sigla & " - " & row.descricao)

                    If row.IdPais = BuscaEstado.First.IdPais Then
                        _indexPais = LstIdPaisesTodos.Items.Count - 1
                    End If

                Next

                CmbPais.SelectedIndex = _indexPais

                TxtNumero.Enabled = True
                TxtNumero.Focus()

            End If

        ElseIf BuscaCep.Count > 1 Then

            CmbEndereço.Enabled = True
            BttAddEndereço.Enabled = True

        End If

        PopulaTreeview1()

    End Sub

    Public Sub PopulaTreeview1()
        'manda dados para o frmcadcolaboradores
        'carrega todos os estados
        Dim BuscaEstoque = From est In LqGeral.QuadraEstoque
                           Where est.IdEstoque Like "*"
                           Select est.IdQuadraEstoque, est.NomeMatriz

        TreeView1.Nodes.Clear()

        For Each row In BuscaEstoque.ToList
            TreeView1.Nodes.Add(row.IdQuadraEstoque & "." & row.NomeMatriz)
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes.Add("Parametro")
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(0).Nodes.Add(row.IdQuadraEstoque)
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(0).Nodes.Add(row.NomeMatriz)
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(0).Nodes.Add("e.X")
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(0).Nodes.Add("e.y")
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)
            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)

            TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes.Add("Ruas")

            'declara treenode

            Dim TrRua As TreeNode = TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(1)

            'busca ruas 

            Dim buscaRuas = From ru In LqGeral.RuaEstoque
                            Where ru.IdQuadra = row.IdQuadraEstoque
                            Select ru.IdRuaEstoque, ru.NomeMatriz

            For Each ruas In buscaRuas.ToList
                TrRua.Nodes.Add(ruas.IdRuaEstoque & "." & ruas.NomeMatriz)
                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes.Add("Parametro")
                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(0).Nodes.Add(ruas.IdRuaEstoque)
                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(0).Nodes.Add(ruas.NomeMatriz)
                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(0).Nodes.Add("e.X")
                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(0).Nodes.Add("e.y")
                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)
                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)

                TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes.Add("Predios")

                'declara treenode

                Dim TrPredio As TreeNode = TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(1)

                'busca ruas 

                Dim buscaPredios = From ru In LqGeral.PredioEstoque
                                   Where ru.IdRuaEstoque = ruas.IdRuaEstoque
                                   Select ru.IdPredioEstoque, ru.NomeMatriz

                For Each predio In buscaPredios.ToList
                    TrPredio.Nodes.Add(predio.IdPredioEstoque & "." & predio.NomeMatriz)
                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes.Add("Parametro")
                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(0).Nodes.Add(predio.IdPredioEstoque)
                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(0).Nodes.Add(predio.NomeMatriz)
                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(0).Nodes.Add("e.X")
                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(0).Nodes.Add("e.y")
                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)
                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)

                    TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes.Add("Andares")

                    'declara treenode

                    Dim TrAndar As TreeNode = TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(1)

                    'busca ruas 

                    Dim buscaAndar = From ru In LqGeral.AndarEstoque
                                     Where ru.IdPredioEstoqeu = predio.IdPredioEstoque
                                     Select ru.IdAndarEstoque, ru.NomeMatriz

                    For Each andar In buscaAndar.ToList
                        TrAndar.Nodes.Add(andar.IdAndarEstoque & "." & andar.NomeMatriz)
                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes.Add("Parametro")
                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(0).Nodes.Add(andar.IdAndarEstoque)
                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(0).Nodes.Add(andar.NomeMatriz)
                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(0).Nodes.Add("e.X")
                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(0).Nodes.Add("e.y")
                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)
                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)

                        TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes.Add("Endereços")

                        'declara treenode

                        Dim TrEndereço As TreeNode = TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(1)

                        'busca ruas 

                        Dim buscaEndereços = From ru In LqGeral.enderecoEstoque
                                             Where ru.IdAndarEstoque = andar.IdAndarEstoque
                                             Select ru.idenderecoEstoque, ru.NomeMatriz

                        For Each Endereço In buscaEndereços.ToList
                            TrEndereço.Nodes.Add(Endereço.idenderecoEstoque & "." & Endereço.NomeMatriz)
                            TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes.Add("Parametro")
                            TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes(0).Nodes.Add(Endereço.idenderecoEstoque)
                            TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes(0).Nodes.Add(Endereço.NomeMatriz)
                            TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes(0).Nodes.Add("e.X")
                            TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
                            TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes(0).Nodes(2).Nodes.Add(0)
                            TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes(0).Nodes.Add("e.y")
                            TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)
                            TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes(0).Nodes(3).Nodes.Add(0)

                        Next
                    Next
                Next
            Next
        Next

        DesenhaMapa()

        TreeView1.Visible = False

    End Sub

    Private Sub CmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPais.SelectedIndexChanged
        If CmbPais.Enabled = True Then
            'carrega todos os estados
            Dim BuscaEstados = From est In LqCadastros.Estados
                               Where est.IdPais = Val(LstIdPaisesTodos.Items(CmbPais.SelectedIndex).ToString)
                               Select est.IdEstado, est.Sigla, est.Descricao

            LstSiglaEstado.Items.Clear()
            LstdescricaoEstado.Items.Clear()
            CmbEstado.Items.Clear()
            LstidEstadoTodos.Items.Clear()

            For Each row In BuscaEstados.ToList
                LstidEstadoTodos.Items.Add(row.IdEstado)
                LstSiglaEstado.Items.Add(row.Sigla)
                LstdescricaoEstado.Items.Add(row.Descricao)
                CmbEstado.Items.Add(row.Sigla & " - " & row.Descricao)
            Next

            CmbEstado.Enabled = True
            BttAddEstado.Enabled = True

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BttAddEstado.Click
        FrmNovoEstado.FormOri = 1
        FrmNovoEstado.IdPais = Val(LstIdPaisesTodos.Items(CmbPais.SelectedIndex).ToString)
        FrmNovoEstado.Show(Me)
    End Sub

    Private Sub CmbEndereço_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEndereço.SelectedIndexChanged

    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEstado.SelectedIndexChanged
        If CmbEstado.Enabled = True Then
            'carrega todos os estados
            Dim BuscaEstados = From est In LqCadastros.Cidade
                               Where est.IdEstado = Val(LstidEstadoTodos.Items(CmbEstado.SelectedIndex).ToString)
                               Select est.IdCidade, est.Descricao

            CmbCidade.Items.Clear()
            LstIdCidadeTodos.Items.Clear()

            For Each row In BuscaEstados.ToList
                LstIdCidadeTodos.Items.Add(row.IdCidade)
                CmbCidade.Items.Add(row.Descricao)
            Next

            CmbCidade.Enabled = True
            BttAddCidade.Enabled = True

        End If
    End Sub

    Private Sub BttAddCidade_Click(sender As Object, e As EventArgs) Handles BttAddCidade.Click
        FrmNovaCidade.FormOri = 1
        FrmNovaCidade.IdEstado = Val(LstidEstadoTodos.Items(CmbEstado.SelectedIndex).ToString)
        FrmNovaCidade.Show(Me)
    End Sub

    Private Sub BttAddBairro_Click(sender As Object, e As EventArgs) Handles BttAddBairro.Click
        FrmNovoBairro.formori = 1
        FrmNovoBairro.IdCidade = Val(LstIdCidadeTodos.Items(CmbCidade.SelectedIndex).ToString)
        FrmNovoBairro.Show(Me)
    End Sub

    Private Sub CmbBairro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBairro.SelectedIndexChanged
        If CmbBairro.Enabled = True Then
            If CmbBairro.Items.Contains(CmbBairro.Text) Then
                Dim IDBairro As Integer = Val(LstIdBairroTodos.Items(CmbBairro.SelectedIndex).ToString)
                Dim IDEndereço As Integer = Val(LstIdEndereço.Items(CmbEndereço.SelectedIndex).ToString)

                LqCadastros.AtualizaBairroEndereco(IDBairro, IDEndereço)
                TxtNumero.Enabled = True
            Else
                TxtNumero.Text = Nothing
                TxtNumero.Enabled = False
            End If
        End If
    End Sub

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

        If TxtNumero.Text <> "" Then
            TxtComplemento.Enabled = True
            BttSalvar.Enabled = True

        Else
            TxtComplemento.Enabled = False
            TxtComplemento.Text = ""
            BttSalvar.Enabled = False

        End If

    End Sub

    Private Sub TxtCep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCep.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BttBuscaCep.PerformClick()
        End If
    End Sub


    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCidade.SelectedIndexChanged
        If CmbCidade.Enabled = True Then
            'carrega todos os estados
            Dim BuscaEstados = From est In LqCadastros.Bairro
                               Where est.IdCidade = Val(LstIdCidadeTodos.Items(CmbCidade.SelectedIndex).ToString)
                               Select est.IdBairro, est.Descricao

            CmbBairro.Items.Clear()
            LstIdBairroTodos.Items.Clear()

            For Each row In BuscaEstados.ToList
                LstIdBairroTodos.Items.Add(row.IdBairro)
                CmbBairro.Items.Add(row.Descricao)
            Next

            CmbBairro.Enabled = True
            BttAddBairro.Enabled = True
        End If
    End Sub

    Private Sub BttAddPais_Click(sender As Object, e As EventArgs) Handles BttAddPais.Click

        FrmNovoPais.Ori = 1
        FrmNovoPais.Show(Me)

    End Sub

    Dim LqGeral As New DtCadastroDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqGeral.InsereEstoque(TxtDescrição.Text, TxtCep.Text, LstIdEndereço.Items(CmbEndereço.SelectedIndex).ToString, CmbEndereço.Text, CmbBairro.Text, CmbCidade.Text, CmbEstado.Text, CmbPais.Text, TxtNumero.Text, TxtComplemento.Text)


    End Sub

    Private Sub FrmNovoEstoque_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public LstIdQuadra As New ListBox

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        FrmNovaQuadra.Show(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        FrmNovaQuadra.Show(Me)
    End Sub

    Private Sub CmbNomeMatrizQuadra_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub DesenhaMapa()

        'valida eixo y
        Dim Quadrasavaliadas As Integer = 0
        Dim AddAval As Decimal = 0
        Dim Linha As Integer = 1
        Dim PosXAval As Decimal = 0
        Dim PosyAval As Decimal = 0

        While Quadrasavaliadas < TreeView1.Nodes.Count

            'pinta o primeiro

            PosXAval += AddAval
            AddAval += (10) + 280
            Quadrasavaliadas += 1

            If PosXAval >= 280 * 4 Then
                Linha += 1
                PosXAval = 0
                AddAval = 0
            End If

        End While

        Dim PintarBitmap = New Bitmap(280 * 4, 300 * Linha)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.SlateGray, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot

        'cria fontes
        Dim drawFont_0 As New Font("Calibri", 10)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = 270
        Dim ValorQuadraUnitY As Decimal = 290

        'desenha 

        Dim PosX As Decimal = 0
        Dim Posy As Decimal = 0


        Dim QuadrasPintadas As Integer = 0

        Dim PrimeiraQuadra As Decimal = Posy - 25

        Dim Add As Decimal = 0

        While QuadrasPintadas < TreeView1.Nodes.Count

            'pinta o primeiro
            Pintura.DrawImage(My.Resources.estoque_terceirizado, (PosX + Add), Posy + 40, ValorQuadraUnitX, ValorQuadraUnitY - 40)
            Pintura.DrawRectangle(SlateGrayPen, (PosX + Add), Posy, ValorQuadraUnitX, ValorQuadraUnitY)
            Pintura.FillRectangle(New SolidBrush(Color.FromArgb(20, 255, 255, 255)), (PosX + Add), Posy, ValorQuadraUnitX, ValorQuadraUnitY)


            Pintura.DrawString(TreeView1.Nodes(QuadrasPintadas).Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.SlateGray), (PosX + Add) + 5, Posy + 5)

            TreeView1.Nodes(QuadrasPintadas).Nodes(0).Nodes(2).Nodes(0).Text = (PosX + Add)
            TreeView1.Nodes(QuadrasPintadas).Nodes(0).Nodes(2).Nodes(1).Text = (PosX + Add + ValorQuadraUnitX)
            TreeView1.Nodes(QuadrasPintadas).Nodes(0).Nodes(3).Nodes(0).Text = (Posy)
            TreeView1.Nodes(QuadrasPintadas).Nodes(0).Nodes(3).Nodes(1).Text = (Posy + ValorQuadraUnitY)

            Add += (10) + ValorQuadraUnitX

            QuadrasPintadas += 1

            If Add >= ValorQuadraUnitX * 4 Then
                Posy += 300
                Add = 0
            End If

        End While

        'div interno

        PicMapa.BackgroundImage = PintarBitmap

        PicMapa.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)

        PicMapa.Location = New Point(10, 10)

        Me.Cursor = Cursors.Arrow

    End Sub

    'desenha seleção

    Public Sub DesenhaSeleçãoQuadra()

        Dim PintarBitmap = New Bitmap(PicMapa.Width, PicMapa.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.Peru, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot

        'cria fontes
        Dim drawFont_0 As New Font("calibri", 14)
        Dim drawFont_1 As New Font("calibri", 10)
        Dim drawFont_2 As New Font("calibri", 18)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = 270
        Dim ValorQuadraUnitY As Decimal = 290

        Dim Ex As Decimal = TreeView1.SelectedNode.Nodes(0).Nodes(2).Nodes(0).Text
        Dim Ey As Decimal = TreeView1.SelectedNode.Nodes(0).Nodes(3).Nodes(0).Text

        Pintura.DrawImage(My.Resources.cargo_1_icon, Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, 255, 255, 255)), Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)

        'traz informações

        'nome da quadra

        Pintura.FillRectangle(New SolidBrush(Color.Peru), Ex, Ey, ValorQuadraUnitX, 30)
        Pintura.DrawString(TreeView1.SelectedNode.Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.WhiteSmoke), Ex + 5, Ey + 2)

        'Ruas

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex + 10, Ey + 40, ValorQuadraUnitX, 20)
        Pintura.DrawString("Ruas", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 15, Ey + 42)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 10, Ey + 40, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 85, Ey + 40, 175, 20)

        'Predios

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex + 10, Ey + 60, ValorQuadraUnitX, 20)
        Pintura.DrawString("Prédios", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 15, Ey + 62)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 10, Ey + 60, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 85, Ey + 60, 175, 20)

        'Pintura.DrawRectangle(SlateGrayPen, Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)

        'Andares

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex + 10, Ey + 80, ValorQuadraUnitX, 20)
        Pintura.DrawString("Andares", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 15, Ey + 82)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 10, Ey + 80, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 85, Ey + 80, 175, 20)

        'Endereços

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex + 10, Ey + 100, ValorQuadraUnitX, 20)
        Pintura.DrawString("Endereços", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 15, Ey + 102)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 10, Ey + 100, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 85, Ey + 100, 175, 20)

        'busca quantidade de ruas

        Dim BuscaRuas = From ru In LqGeral.RuaEstoque
                        Where ru.IdQuadra = TreeView1.SelectedNode.Nodes(0).Nodes(0).Text
                        Select ru.IdRuaEstoque

        If BuscaRuas.Count > 0 Then
            Pintura.DrawString(BuscaRuas.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 42)
        Else
            Pintura.DrawString("Nenhuma rua cadatrada", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 42)
        End If

        Dim Peso As Decimal
        Dim MT3 As Decimal

        Try

            Dim BuscaPredios = From ru In LqGeral.PredioEstoque
                               Where ru.IdRuaEstoque = BuscaRuas.First
                               Select ru.IdPredioEstoque

            Pintura.DrawString(BuscaPredios.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 62)

            'busca quantidade de andares

            Try
                Dim BuscaAndares = From ru In LqGeral.AndarEstoque
                                   Where ru.IdPredioEstoqeu = BuscaPredios.First
                                   Select ru.IdAndarEstoque

                Pintura.DrawString(BuscaAndares.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 82)

                'busca quantidade de andares

                Try

                    Dim BuscaEndereços = From ru In LqGeral.enderecoEstoque
                                         Where ru.IdAndarEstoque = BuscaAndares.First
                                         Select ru.idenderecoEstoque

                    Pintura.DrawString(BuscaEndereços.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 102)

                Catch mm As Exception

                    Pintura.DrawString("Nenhum endereço cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 102)

                End Try

            Catch mm As Exception
                Pintura.DrawString("Nenhum andar cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 82)
                Pintura.DrawString("Nenhum endereço cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 102)
            End Try

        Catch mm As Exception
            Pintura.DrawString("Nenhum prédio cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 62)
            Pintura.DrawString("Nenhum andar cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 82)
            Pintura.DrawString("Nenhum endereço cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 102)
        End Try

        Pintura.DrawImage(My.Resources.Triangle_ruler512_44215, Ex + 15, Ey + 130, 45, 45)
        Pintura.DrawImage(My.Resources.icons8_peso_kg_96, Ex + 15, Ey + 190, 50, 50)
        Pintura.DrawString(FormatNumber(MT3, NumDigitsAfterDecimal:=2), drawFont_2, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 145)
        Pintura.DrawString(FormatNumber(Peso, NumDigitsAfterDecimal:=2), drawFont_2, New SolidBrush(Color.SlateGray), Ex + 85, Ey + 202)

        'desenha menu inferior

        Pintura.DrawImage(My.Resources.add_1_icon, (Ex + ValorQuadraUnitX) - 30, (Ey + ValorQuadraUnitY) - 25, 20, 20)
        Pintura.DrawImage(My.Resources.DocumentEdit_40924, (Ex + ValorQuadraUnitX) - 60, (Ey + ValorQuadraUnitY) - 25, 20, 20)
        'Pintura.DrawImage(My.Resources._1485477118_rotation_right_78579, (Ex + 5), (Ey + ValorQuadraUnitY) - 25, 20, 20)

        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)

        PicMapa.Image = PintarBitmap

    End Sub

    Public Sub DesenhaSeleçãoRua()

        PicMapa.Image = Nothing

        Dim PintarBitmap = New Bitmap(PicMapa.Width, PicMapa.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.Peru, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot

        'cria fontes
        Dim drawFont_0 As New Font("calibri", 14)
        Dim drawFont_1 As New Font("calibri", 10)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = 250
        Dim ValorQuadraUnitY As Decimal = 250

        Dim Ex As Decimal = TreeView1.SelectedNode.Nodes(0).Nodes(2).Nodes(0).Text
        Dim Ey As Decimal = TreeView1.SelectedNode.Nodes(0).Nodes(3).Nodes(0).Text

        Pintura.DrawImage(My.Resources.estoque, Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, 255, 255, 255)), Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)

        'traz informações

        'nome da quadra

        Pintura.FillRectangle(New SolidBrush(Color.Peru), Ex, Ey, ValorQuadraUnitX, 30)
        Pintura.DrawString(TreeView1.SelectedNode.Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.WhiteSmoke), Ex + 5, Ey + 2)

        'Predios

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex, Ey + 40, ValorQuadraUnitX, 20)
        Pintura.DrawString("Prédios", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 5, Ey + 42)
        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey + 40, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 75, Ey + 40, 175, 20)

        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)

        'Andares

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex, Ey + 60, ValorQuadraUnitX, 20)
        Pintura.DrawString("Andares", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 5, Ey + 62)
        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey + 60, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 75, Ey + 60, 175, 20)

        'Endereços

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex, Ey + 80, ValorQuadraUnitX, 20)
        Pintura.DrawString("Endereços", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 5, Ey + 82)
        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey + 80, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 75, Ey + 80, 175, 20)

        Try

            Dim BuscaPredios = From ru In LqGeral.PredioEstoque
                               Where ru.IdRuaEstoque = TreeView1.SelectedNode.Nodes(0).Nodes(0).Text
                               Select ru.IdPredioEstoque

            Pintura.DrawString(BuscaPredios.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 42)

            'busca quantidade de andares

            Try
                Dim BuscaAndares = From ru In LqGeral.AndarEstoque
                                   Where ru.IdPredioEstoqeu = BuscaPredios.First
                                   Select ru.IdAndarEstoque

                Pintura.DrawString(BuscaAndares.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 62)

                'busca quantidade de andares

                Try

                    Dim BuscaEndereços = From ru In LqGeral.enderecoEstoque
                                         Where ru.IdAndarEstoque = BuscaAndares.First
                                         Select ru.idenderecoEstoque

                    Pintura.DrawString(BuscaEndereços.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 82)

                Catch mm As Exception

                    Pintura.DrawString("Nenhum endereço cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 82)

                End Try

            Catch mm As Exception
                Pintura.DrawString("Nenhum andar cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 62)
                Pintura.DrawString("Nenhum endereço cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 82)
            End Try

        Catch mm As Exception
            Pintura.DrawString("Nenhum prédio cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 42)
            Pintura.DrawString("Nenhum andar cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 62)
            Pintura.DrawString("Nenhum endereço cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 82)
        End Try

        Pintura.DrawImage(My.Resources.Triangle_ruler512_44215, Ex + 15, Ey + 120, 30, 30)
        Pintura.DrawImage(My.Resources.icons8_peso_kg_96, Ex + 15, Ey + 160, 35, 35)

        Pintura.DrawImage(My.Resources.add_1_icon, (Ex + ValorQuadraUnitX) - 30, (Ey + ValorQuadraUnitY) - 25, 20, 20)
        Pintura.DrawImage(My.Resources.DocumentEdit_40924, (Ex + ValorQuadraUnitX) - 60, (Ey + ValorQuadraUnitY) - 25, 20, 20)

        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)

        PicMapa.Image = PintarBitmap

    End Sub

    Public Sub DesenhaSeleçãoPredio()

        Dim PintarBitmap = New Bitmap(PicMapa.Width, PicMapa.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.Peru, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot

        'cria fontes
        Dim drawFont_0 As New Font("calibri", 14)
        Dim drawFont_1 As New Font("calibri", 10)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = 250
        Dim ValorQuadraUnitY As Decimal = 250

        Dim Ex As Decimal = TreeView1.SelectedNode.Nodes(0).Nodes(2).Nodes(0).Text
        Dim Ey As Decimal = TreeView1.SelectedNode.Nodes(0).Nodes(3).Nodes(0).Text

        Pintura.DrawImage(My.Resources.caixas_de_cartão_na_paleta_entregue_o_conceito_ícone_d_isolado_38186341, Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, 255, 255, 255)), Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)

        'traz informações

        'nome da quadra

        Pintura.FillRectangle(New SolidBrush(Color.Peru), Ex, Ey, ValorQuadraUnitX, 30)
        Pintura.DrawString(TreeView1.SelectedNode.Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.WhiteSmoke), Ex + 5, Ey + 2)

        'Predios

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex, Ey + 40, ValorQuadraUnitX, 20)
        Pintura.DrawString("Prédios", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 5, Ey + 42)
        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey + 40, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 75, Ey + 40, 175, 20)

        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)

        'Andares

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex, Ey + 60, ValorQuadraUnitX, 20)
        Pintura.DrawString("Andares", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 5, Ey + 62)
        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey + 60, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 75, Ey + 60, 175, 20)

        'Endereços

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 255, 255)), Ex, Ey + 80, ValorQuadraUnitX, 20)
        Pintura.DrawString("Endereços", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 5, Ey + 82)
        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey + 80, 75, 20)
        Pintura.DrawRectangle(SlateGrayPen, Ex + 75, Ey + 80, 175, 20)

        Try

            Dim BuscaPredios = From ru In LqGeral.PredioEstoque
                               Where ru.IdRuaEstoque = TreeView1.SelectedNode.Nodes(0).Nodes(0).Text
                               Select ru.IdPredioEstoque

            Pintura.DrawString(BuscaPredios.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 42)

            'busca quantidade de andares

            Try
                Dim BuscaAndares = From ru In LqGeral.AndarEstoque
                                   Where ru.IdPredioEstoqeu = BuscaPredios.First
                                   Select ru.IdAndarEstoque

                Pintura.DrawString(BuscaAndares.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 62)

                'busca quantidade de andares

                Try

                    Dim BuscaEndereços = From ru In LqGeral.enderecoEstoque
                                         Where ru.IdAndarEstoque = BuscaAndares.First
                                         Select ru.idenderecoEstoque

                    Pintura.DrawString(BuscaEndereços.Count, drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 82)

                Catch mm As Exception

                    Pintura.DrawString("Nenhum endereço cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 82)

                End Try

            Catch mm As Exception
                Pintura.DrawString("Nenhum andar cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 62)
                Pintura.DrawString("Nenhum endereço cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 82)
            End Try

        Catch mm As Exception
            Pintura.DrawString("Nenhum prédio cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 42)
            Pintura.DrawString("Nenhum andar cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 62)
            Pintura.DrawString("Nenhum endereço cadastrado", drawFont_1, New SolidBrush(Color.SlateGray), Ex + 75, Ey + 82)
        End Try

        Pintura.DrawImage(My.Resources.Triangle_ruler512_44215, Ex + 15, Ey + 120, 30, 30)
        Pintura.DrawImage(My.Resources.icons8_peso_kg_96, Ex + 15, Ey + 160, 35, 35)

        Pintura.DrawImage(My.Resources.add_1_icon, (Ex + ValorQuadraUnitX) - 30, (Ey + ValorQuadraUnitY) - 25, 20, 20)
        Pintura.DrawImage(My.Resources.DocumentEdit_40924, (Ex + ValorQuadraUnitX) - 60, (Ey + ValorQuadraUnitY) - 25, 20, 20)

        Pintura.DrawRectangle(SlateGrayPen, Ex, Ey, ValorQuadraUnitX, ValorQuadraUnitY)

        PicMapa.Image = PintarBitmap

    End Sub

    Private Sub PicMapa_Click(sender As Object, e As EventArgs) Handles PicMapa.Click

    End Sub

    Public FNC As Integer = 0
    Dim IDSel As Integer = 0
    Dim IDSelRua As Integer = 0
    Dim IDSelPredio As Integer = 0
    Dim IDSelAndar As Integer = 0
    Dim IDSelEndereço As Integer = 0

    Private Sub PicMapa_MouseClick(sender As Object, e As MouseEventArgs) Handles PicMapa.MouseClick

        PicS = PicMapa.Image

        Selecionado = True

        If FNC = 0 Then

            'procura no treeview

            For Each row As TreeNode In TreeView1.Nodes

                'verifica valor eixo inicial e final no x

                If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                    If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                        If e.X >= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 60 And e.X <= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 40 Then

                            If e.Y >= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 25 And e.Y <= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 5 Then
                                ChaveQuadraselecionada = row.Nodes(0).Nodes(0).Text
                                IDSel = row.Index

                                TreeView1.SelectedNode = row
                                FNC = 1
                                DesenhaRuas()

                            End If

                        ElseIf e.X >= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 30 And e.X <= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 10 Then

                            If e.Y >= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 25 And e.Y <= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 5 Then

                                PicMapa.Enabled = False

                                FrmNovaRuaEstoque.Chave = ChaveQuadraselecionada

                                FrmNovaRuaEstoque.Show(Me)

                            End If

                        End If

                    End If


                End If

            Next

        ElseIf FNC = 1 Then 'procura no treeview

            For Each row As TreeNode In TreeView1.Nodes(IDSel).Nodes(1).Nodes

                'verifica valor eixo inicial e final no x

                If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                    If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                        If e.X >= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 60 And e.X <= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 40 Then

                            If e.Y >= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 25 And e.Y <= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 5 Then

                                ChaveQuadraselecionada = row.Nodes(0).Nodes(0).Text
                                IDSelRua = row.Index

                                TreeView1.SelectedNode = row
                                BttAddPredios.Enabled = True

                                'desnha seleção

                                DesenhaPredios()

                            ElseIf e.X >= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 30 And e.X <= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 10 Then

                                If e.Y >= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 25 And e.Y <= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 5 Then

                                    PicMapa.Enabled = False

                                    FrmNovoPrédio.Chave = ChaveQuadraselecionada

                                    FrmNovoPrédio.Show(Me)

                                End If

                            End If

                        End If

                    End If

                End If

            Next

        ElseIf FNC = 2 Then 'procura no treeview

            For Each row As TreeNode In TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes

                'verifica valor eixo inicial e final no x

                If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                    If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                        ChaveQuadraselecionada = row.Nodes(0).Nodes(0).Text
                        IDSelPredio = row.Index

                        TreeView1.SelectedNode = row
                        BttAddPredios.Enabled = True

                        'desnha seleção

                        DesenhaSeleçãoPredio()

                    End If

                End If

            Next
        ElseIf FNC = 3 Then 'procura no treeview

            For Each row As TreeNode In TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(IDSelPredio).Nodes(1).Nodes

                'verifica valor eixo inicial e final no x

                If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                    If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                        ChaveQuadraselecionada = row.Nodes(0).Nodes(0).Text
                        IDSelAndar = row.Index

                        TreeView1.SelectedNode = row
                        BttAddPredios.Enabled = True

                        'desnha seleção

                        'DesenhaSeleçãoandar()

                    End If

                End If

            Next

        End If

        If FNC > 0 Then
            'abre ação
            If e.X >= (270 - 40) And e.X <= 270 Then
                If e.Y >= 295 - 40 And e.Y <= 295 Then
                    MsgBox("OK")
                End If
            End If

        End If
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs)

        If TreeView1.SelectedNode.Level = 0 Then
            DesenhaSeleçãoQuadra()
        End If
    End Sub

    Public Sub DesenhaRuas()

        'valida eixo y
        Dim Quadrasavaliadas As Integer = 0
        Dim AddAval As Decimal = 0
        Dim Linha As Integer = 1
        Dim PosXAval As Decimal = 0
        Dim PosyAval As Decimal = 0

        While Quadrasavaliadas < TreeView1.Nodes(IDSel).Nodes(1).Nodes.Count

            'pinta o primeiro

            PosXAval += AddAval
            AddAval += (10) + 280
            Quadrasavaliadas += 1

            If PosXAval >= 280 * 2 Then
                Linha += 1
                PosXAval = 0
                AddAval = 0
            End If

        End While

        PicMapa.Image = Nothing

        Dim PintarBitmap = New Bitmap(280 * 4, 290 + (270 * Linha))

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.Peru, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot
        ' Create pen.
        Dim SlateGrayPen1 As New Pen(Color.Peru, 0.5)
        SlateGrayPen1.DashStyle = Drawing2D.DashStyle.Dot
        'cria fontes
        Dim drawFont_0 As New Font("Calibri", 14)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = 250
        Dim ValorQuadraUnitY As Decimal = 290

        'desenha 

        Dim PosX As Decimal = 0
        Dim Posy As Decimal = 0

        'pinta painel
        Pintura.DrawImage(My.Resources.estoque_terceirizado, PosX, Posy + 40, 270, ValorQuadraUnitY - 40)
        Pintura.DrawRectangle(SlateGrayPen1, PosX, Posy, 270, ValorQuadraUnitY + 5)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(20, 255, 255, 255)), PosX, Posy, 270, ValorQuadraUnitY + 5)

        'nome da quadra

        Pintura.FillRectangle(New SolidBrush(Color.Peru), PosX, Posy, PintarBitmap.Width - 10, 25)
        Pintura.DrawString(TreeView1.Nodes(IDSel).Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.WhiteSmoke), PosX + 5, Posy + 2)

        Dim QuadrasPintadas As Integer = 0

        Dim Add As Decimal = 0

        PosX = 280
        Posy = 45

        While QuadrasPintadas < TreeView1.Nodes(IDSel).Nodes(1).Nodes.Count

            Pintura.FillRectangle(New SolidBrush(Color.Peru), (PosX + Add), Posy - 20, 10, 20)

            'pinta o primeiro
            Pintura.DrawImage(My.Resources.Inventory_PNG_Transparent_Image, (PosX + Add), Posy + 25, ValorQuadraUnitX, ValorQuadraUnitY - 65)
            Pintura.DrawRectangle(SlateGrayPen, (PosX + Add), Posy, ValorQuadraUnitX, ValorQuadraUnitY - 40)
            Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, 192, 138, 71)), (PosX + Add), Posy, ValorQuadraUnitX, ValorQuadraUnitY - 40)

            Pintura.DrawString(TreeView1.Nodes(IDSel).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.SlateGray), (PosX + Add) + 5, Posy + 5)

            TreeView1.Nodes(IDSel).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(2).Nodes(0).Text = (PosX + Add)
            TreeView1.Nodes(IDSel).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(2).Nodes(1).Text = (PosX + Add + ValorQuadraUnitX)
            TreeView1.Nodes(IDSel).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(3).Nodes(0).Text = (Posy)
            TreeView1.Nodes(IDSel).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(3).Nodes(1).Text = (Posy + ValorQuadraUnitY)

            Add += (10) + ValorQuadraUnitX

            QuadrasPintadas += 1

            If Add >= 280 * 2 Then
                Posy += 270
                Add = 0
            End If

        End While

        'div interno

        PicMapa.BackgroundImage = PintarBitmap

        PicMapa.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)
        PnnMapa.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)

        PicMapa.Location = New Point(10, 10)

        Me.Cursor = Cursors.Arrow

    End Sub

    Public Sub DesenhaPredios()

        'valida eixo y
        Dim Quadrasavaliadas As Integer = 0
        Dim AddAval As Decimal = 0
        Dim Linha As Integer = 1
        Dim PosXAval As Decimal = 0
        Dim PosyAval As Decimal = 0

        While Quadrasavaliadas < TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes.Count

            'pinta o primeiro

            PosXAval += AddAval
            AddAval += (10) + 280
            Quadrasavaliadas += 1

            If PosXAval >= 280 * 2 Then
                Linha += 1
                PosXAval = 0
                AddAval = 0
            End If

        End While

        PicMapa.Image = Nothing

        Dim PintarBitmap = New Bitmap(280 * 4, 290 + (270 * Linha))

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.Peru, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot
        ' Create pen.
        Dim SlateGrayPen1 As New Pen(Color.Peru, 0.5)
        SlateGrayPen1.DashStyle = Drawing2D.DashStyle.Dot
        'cria fontes
        Dim drawFont_0 As New Font("Calibri", 14)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = 250
        Dim ValorQuadraUnitY As Decimal = 290

        'desenha 

        Dim PosX As Decimal = 0
        Dim Posy As Decimal = 0

        'pinta painel
        Pintura.DrawImage(My.Resources.Inventory_PNG_Transparent_Image, PosX, Posy + 40, 270, ValorQuadraUnitY - 40)
        Pintura.DrawRectangle(SlateGrayPen1, PosX, Posy, 270, ValorQuadraUnitY + 5)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(20, 255, 255, 255)), PosX, Posy, 270, ValorQuadraUnitY + 5)

        'nome da quadra

        Pintura.FillRectangle(New SolidBrush(Color.Peru), PosX, Posy, PintarBitmap.Width - 10, 25)
        Pintura.DrawString(TreeView1.SelectedNode.Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.WhiteSmoke), PosX + 5, Posy + 2)

        Dim QuadrasPintadas As Integer = 0

        Dim Add As Decimal = 0

        PosX = 280
        Posy = 45

        While QuadrasPintadas < TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes.Count

            Pintura.FillRectangle(New SolidBrush(Color.Peru), (PosX + Add), Posy - 20, 10, 20)

            'pinta o primeiro
            Pintura.DrawImage(My.Resources.estoque, (PosX + Add), Posy + 25, ValorQuadraUnitX, ValorQuadraUnitY - 65)
            Pintura.DrawRectangle(SlateGrayPen, (PosX + Add), Posy, ValorQuadraUnitX, ValorQuadraUnitY - 40)
            Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, 192, 138, 71)), (PosX + Add), Posy, ValorQuadraUnitX, ValorQuadraUnitY - 40)

            Pintura.DrawString(TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.SlateGray), (PosX + Add) + 5, Posy + 5)

            TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(2).Nodes(0).Text = (PosX + Add)
            TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(2).Nodes(1).Text = (PosX + Add + ValorQuadraUnitX)
            TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(3).Nodes(0).Text = (Posy)
            TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(3).Nodes(1).Text = (Posy + ValorQuadraUnitY)

            Add += (10) + ValorQuadraUnitX

            QuadrasPintadas += 1

            If Add >= 280 * 2 Then
                Posy += 270
                Add = 0
            End If

        End While

        'div interno

        PicMapa.BackgroundImage = PintarBitmap

        PicMapa.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)
        PnnMapa.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)

        PicMapa.Location = New Point(10, 10)

        Me.Cursor = Cursors.Arrow

    End Sub


    Public Sub DesenhaAndares()

        'valida eixo y
        Dim Quadrasavaliadas As Integer = 0
        Dim AddAval As Decimal = 0
        Dim Linha As Integer = 1
        Dim PosXAval As Decimal = 0
        Dim PosyAval As Decimal = 0

        While Quadrasavaliadas < TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(IDSelPredio).Nodes(1).Nodes.Count

            'pinta o primeiro

            PosXAval += AddAval
            AddAval += (10) + 280
            Quadrasavaliadas += 1

            If PosXAval >= 280 * 2 Then
                Linha += 1
                PosXAval = 0
                AddAval = 0
            End If

        End While

        PicMapa.Image = Nothing

        Dim PintarBitmap = New Bitmap(280 * 4, 290 + (270 * Linha))

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.Peru, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot
        ' Create pen.
        Dim SlateGrayPen1 As New Pen(Color.Peru, 0.5)
        SlateGrayPen1.DashStyle = Drawing2D.DashStyle.Dot
        'cria fontes
        Dim drawFont_0 As New Font("Calibri", 14)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = 250
        Dim ValorQuadraUnitY As Decimal = 290

        'desenha 

        Dim PosX As Decimal = 0
        Dim Posy As Decimal = 0

        'pinta painel
        Pintura.DrawImage(My.Resources.estoque, PosX, Posy + 40, 270, ValorQuadraUnitY - 40)
        Pintura.DrawRectangle(SlateGrayPen1, PosX, Posy, 270, ValorQuadraUnitY + 5)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(20, 255, 255, 255)), PosX, Posy, 270, ValorQuadraUnitY + 5)

        'nome da quadra

        Pintura.FillRectangle(New SolidBrush(Color.Peru), PosX, Posy, PintarBitmap.Width - 10, 25)
        Pintura.DrawString(TreeView1.SelectedNode.Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.WhiteSmoke), PosX + 5, Posy + 2)

        Dim QuadrasPintadas As Integer = 0

        Dim Add As Decimal = 0

        PosX = 280
        Posy = 45

        While QuadrasPintadas < TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(IDSelPredio).Nodes(1).Nodes.Count

            Pintura.FillRectangle(New SolidBrush(Color.Peru), (PosX + Add), Posy - 20, 10, 20)

            'pinta o primeiro
            Pintura.DrawImage(My.Resources.caixas_de_cartão_na_paleta_entregue_o_conceito_ícone_d_isolado_38186341, (PosX + Add), Posy + 25, ValorQuadraUnitX, ValorQuadraUnitY - 65)
            Pintura.DrawRectangle(SlateGrayPen, (PosX + Add), Posy, ValorQuadraUnitX, ValorQuadraUnitY - 40)
            Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, 192, 138, 71)), (PosX + Add), Posy, ValorQuadraUnitX, ValorQuadraUnitY - 40)

            Pintura.DrawString(TreeView1.SelectedNode.Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(1).Text, drawFont_0, New SolidBrush(Color.SlateGray), (PosX + Add) + 5, Posy + 5)

            TreeView1.SelectedNode.Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(2).Nodes(0).Text = (PosX + Add)
            TreeView1.SelectedNode.Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(2).Nodes(1).Text = (PosX + Add + ValorQuadraUnitX)
            TreeView1.SelectedNode.Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(3).Nodes(0).Text = (Posy)
            TreeView1.SelectedNode.Nodes(1).Nodes(QuadrasPintadas).Nodes(0).Nodes(3).Nodes(1).Text = (Posy + ValorQuadraUnitY)

            Add += (10) + ValorQuadraUnitX

            QuadrasPintadas += 1

            If Add >= 280 * 2 Then
                Posy += 270
                Add = 0
            End If

        End While

        'div interno

        PicMapa.BackgroundImage = PintarBitmap

        PicMapa.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)
        PnnMapa.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)

        PicMapa.Location = New Point(10, 10)

        Me.Cursor = Cursors.Arrow

    End Sub

    Dim ChaveQuadraselecionada As Integer
    Private Sub BttNovaRua_Click(sender As Object, e As EventArgs) Handles BttNovaRua.Click

    End Sub

    Dim Selecionado As Boolean = False
    'desenha icones de ação

    Public Sub DesenhaComando()

        Dim PicT As Image = PicMapa.Image


        Dim PintarBitmap = New Bitmap(PicMapa.Width, PicMapa.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            ' Create pen.
            Dim SlateGrayPen As New Pen(Color.Peru, 0.5)
            SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot

            'cria fontes
            Dim drawFont_0 As New Font("calibri", 14)
            Dim drawFont_1 As New Font("calibri", 10)

            'valor de 1 quadra
            Dim ValorQuadraUnitX As Decimal = 270
            Dim ValorQuadraUnitY As Decimal = 295

            Dim Ex As Decimal = 0
            Dim Ey As Decimal = 0


        'desenha menu inferior

        Pintura.DrawImage(My.Resources.add_1_icon, (Ex + ValorQuadraUnitX) - 30, (Ey + ValorQuadraUnitY) - 25, 20, 20)
        Pintura.DrawImage(My.Resources.DocumentEdit_40924, (Ex + ValorQuadraUnitX) - 60, (Ey + ValorQuadraUnitY) - 25, 20, 20)
        Pintura.DrawImage(My.Resources.undo, (Ex + 5), (Ey + ValorQuadraUnitY) - 25, 20, 20)

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(20, 0, 0, 255)), Ex, Ey + 25, ValorQuadraUnitX, ValorQuadraUnitY - 20)

        'traz informações

        PicMapa.Image = PintarBitmap

    End Sub
    Private Sub PicMapa_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles PicMapa.MouseDoubleClick

        PicS = Nothing

        Selecionado = False

        If FNC = 0 Then
            'procura no treeview

            For Each row As TreeNode In TreeView1.Nodes

                'verifica valor eixo inicial e final no x

                If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                    If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                        TreeView1.SelectedNode = row
                        FNC = 1
                        DesenhaRuas()
                    End If

                End If

            Next

        ElseIf FNC = 1 Then
            'procura no treeview

            Dim P As Boolean = False

            If e.X >= 0 And e.X <= 270 Then

                If e.Y >= 0 And e.Y <= 270 Then

                    TreeView1.SelectedNode = TreeView1.Nodes(IDSel)
                    'ChaveQuadraselecionada = TreeView1.SelectedNode.Nodes(0).Nodes(0).Text
                    FNC = 0
                    PicMapa.Image = Nothing

                    Me.Cursor = Cursors.WaitCursor

                    P = True

                    DesenhaMapa()

                End If

            End If

            If P = False Then

                For Each row As TreeNode In TreeView1.Nodes(IDSel).Nodes(1).Nodes

                    'verifica se volta para o anterior

                    'verifica valor eixo inicial e final no x

                    If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                        If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                            TreeView1.SelectedNode = row
                            FNC = 2
                            DesenhaPredios()

                        End If

                    End If

                Next

            End If

        ElseIf FNC = 2 Then

            'procura no treeview

            Dim P As Boolean = False

            If e.X >= 0 And e.X <= 270 Then

                If e.Y >= 0 And e.Y <= 270 Then

                    TreeView1.SelectedNode = TreeView1.Nodes(IDSel)
                    ChaveQuadraselecionada = TreeView1.SelectedNode.Nodes(0).Nodes(0).Text

                    FNC = 1
                    PicMapa.Image = Nothing

                    Me.Cursor = Cursors.WaitCursor

                    P = True

                    DesenhaRuas()

                End If

            End If

            If P = False Then

                For Each row As TreeNode In TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes

                    'verifica se volta para o anterior

                    'verifica valor eixo inicial e final no x

                    If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                        If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                            TreeView1.SelectedNode = row
                            FNC = 3

                            DesenhaAndares()

                        End If

                    End If

                Next

            End If

        ElseIf FNC = 3 Then

            'procura no treeview

            Dim P As Boolean = False

            If e.X >= 0 And e.X <= 270 Then

                If e.Y >= 0 And e.Y <= 270 Then

                    TreeView1.SelectedNode = TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua)
                    ChaveQuadraselecionada = TreeView1.SelectedNode.Nodes(0).Nodes(0).Text

                    FNC = 2
                    PicMapa.Image = Nothing

                    Me.Cursor = Cursors.WaitCursor

                    P = True

                    DesenhaPredios()

                End If

            End If

            If P = False Then

                For Each row As TreeNode In TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(IDSelPredio).Nodes(1).Nodes

                    'verifica se volta para o anterior

                    'verifica valor eixo inicial e final no x

                    If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                        If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                            TreeView1.SelectedNode = row
                            FNC = 4

                            'DesenhaAndares()

                        End If

                    End If

                Next

            End If

        End If
    End Sub

    Private Sub BttAddPredios_Click(sender As Object, e As EventArgs) Handles BttAddPredios.Click


    End Sub

    Dim PicS As Image

    Dim M_EX As Integer
    Dim M_EY As Integer

    Private Sub PicMapa_MouseHover(sender As Object, e As EventArgs) Handles PicMapa.MouseHover


    End Sub

    Private Sub PicMapa_MouseMove(sender As Object, e As MouseEventArgs) Handles PicMapa.MouseMove

        M_EX = e.X
        M_EY = e.Y

        'condições do menu iniial

        If FNC > 0 Then

            If M_EX >= 0 And M_EX <= 270 Then

                If M_EY >= 0 And M_EY <= 295 Then

                    DesenhaComando()
                    If e.X >= (270 - 40) And e.X <= 270 Then
                        If e.Y >= 295 - 40 And e.Y <= 295 Then
                            Me.Cursor = Cursors.Hand
                        Else
                            Me.Cursor = Cursors.Arrow
                        End If

                    End If
                Else

                    PicMapa.Image = Nothing
                    Me.Cursor = Cursors.Arrow

                End If

            Else

                PicMapa.Image = Nothing
                Me.Cursor = Cursors.Arrow

            End If

        End If

        'condições do menu flutuante
        If FNC = 0 Then

            'procura no treeview

            For Each row As TreeNode In TreeView1.Nodes

                'verifica valor eixo inicial e final no x

                If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                    If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then
                        Me.Cursor = Cursors.Arrow

                        ChaveQuadraselecionada = row.Nodes(0).Nodes(0).Text
                        IDSel = row.Index

                        TreeView1.SelectedNode = row
                        BttNovaRua.Enabled = True

                        DesenhaSeleçãoQuadra()

                        If e.X >= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 60 And e.X <= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 40 Then

                            If e.Y >= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 25 And e.Y <= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 5 Then
                                'Pintura.DrawImage(My.Resources.add_1_icon, (Ex + ValorQuadraUnitX) - 30, (Ey + ValorQuadraUnitY) - 25, 20, 20)
                                'Pintura.DrawImage(My.Resources.DocumentEdit_40924, (Ex + ValorQuadraUnitX) - 60, (Ey + ValorQuadraUnitY) - 25, 20, 20)

                                Me.Cursor = Cursors.Hand
                            End If
                        ElseIf e.X >= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 30 And e.X <= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 10 Then

                            If e.Y >= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 25 And e.Y <= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 5 Then
                                Me.Cursor = Cursors.Hand
                            End If

                        End If

                    End If

                End If

            Next

        ElseIf FNC = 1 Then 'procura no treeview

            For Each row As TreeNode In TreeView1.Nodes(IDSel).Nodes(1).Nodes

                'verifica valor eixo inicial e final no x

                If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                    If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                        Me.Cursor = Cursors.Arrow

                        ChaveQuadraselecionada = row.Nodes(0).Nodes(0).Text
                        IDSelRua = row.Index

                        TreeView1.SelectedNode = row
                        BttAddPredios.Enabled = True

                        'desnha seleção

                        DesenhaSeleçãoRua()

                        If e.X >= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 60 And e.X <= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 40 Then

                            If e.Y >= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 25 And e.Y <= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 5 Then
                                'Pintura.DrawImage(My.Resources.add_1_icon, (Ex + ValorQuadraUnitX) - 30, (Ey + ValorQuadraUnitY) - 25, 20, 20)
                                'Pintura.DrawImage(My.Resources.DocumentEdit_40924, (Ex + ValorQuadraUnitX) - 60, (Ey + ValorQuadraUnitY) - 25, 20, 20)

                                Me.Cursor = Cursors.Hand
                            End If

                        ElseIf e.X >= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 30 And e.X <= (row.Nodes(0).Nodes(2).Nodes(1).Text) - 10 Then

                            If e.Y >= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 25 And e.Y <= (row.Nodes(0).Nodes(3).Nodes(1).Text) - 5 Then
                                Me.Cursor = Cursors.Hand
                            End If

                        End If
                    End If

                End If

            Next

        ElseIf FNC = 2 Then 'procura no treeview

            For Each row As TreeNode In TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes

                'verifica valor eixo inicial e final no x

                If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                    If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                        ChaveQuadraselecionada = row.Nodes(0).Nodes(0).Text
                        IDSelPredio = row.Index

                        TreeView1.SelectedNode = row
                        BttAddPredios.Enabled = True

                        'desnha seleção

                        DesenhaSeleçãoPredio()

                    End If

                End If

            Next
        ElseIf FNC = 3 Then 'procura no treeview

            For Each row As TreeNode In TreeView1.Nodes(IDSel).Nodes(1).Nodes(IDSelRua).Nodes(1).Nodes(IDSelPredio).Nodes(1).Nodes

                'verifica valor eixo inicial e final no x

                If e.X >= row.Nodes(0).Nodes(2).Nodes(0).Text And e.X <= row.Nodes(0).Nodes(2).Nodes(1).Text Then

                    If e.Y >= row.Nodes(0).Nodes(3).Nodes(0).Text And e.Y <= row.Nodes(0).Nodes(3).Nodes(1).Text Then

                        ChaveQuadraselecionada = row.Nodes(0).Nodes(0).Text
                        IDSelAndar = row.Index

                        TreeView1.SelectedNode = row
                        BttAddPredios.Enabled = True

                        'desnha seleção

                        'DesenhaSeleçãoandar()

                    End If

                End If

            Next

        End If


    End Sub
End Class