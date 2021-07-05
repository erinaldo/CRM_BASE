Public Class FrmGestaoMarkup
    Private Sub FrmGestaoMarkup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Carrega todos os produtos

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        Dim BuscaProdutos = From Prod In LqBase.Produtos
                            Where Prod.IdProduto Like "*"
                            Select Prod.VendaDireta, Prod.Reaproveitamento, Prod.Markup, Prod.Descricao, Prod.Categoria, Prod.SubCategoria, Prod.Fabricante, Prod.IdProduto, Prod.CodFabricante, Prod.DisponivelOnLine, Prod.ControleValidade

        For Each row In BuscaProdutos.ToList

            If row.VendaDireta = True Or row.Reaproveitamento = True Then
                'Busca dados no estoque

                Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                       Where arm.IdProduto = row.IdProduto
                                       Select arm.Qt, arm.ValorUnit, arm.ValorRevenda, arm.DataEntrada
                                       Order By DataEntrada Descending

                Dim _MenorPreçp As Decimal = 1000000000000000
                Dim _Qt As Integer = 0
                Dim VlrRevenda As Decimal = 0

                Dim _DataEntrada As Date = "1111-11-11
"
                For Each it In BuscaArmazenagem.ToList

                    _Qt += it.Qt

                    If it.ValorUnit < _MenorPreçp Then

                        _MenorPreçp = it.ValorUnit

                    End If

                    If _DataEntrada = "1111-11-11"

                        _DataEntrada = it.DataEntrada 
                        VlrRevenda = it.ValorRevenda 

                    End If

                Next

                Dim IARA As String = ""

                If row.DisponivelOnLine = True Then

                    IARA = "Sim"

                Else

                    IARA = "Não"

                End If

                Dim Validade As String = ""

                If row.ControleValidade = True Then

                    Validade = "Sim"

                Else

                    Validade = "Não"

                End If

                Dim BuscaImagens = From Img In LqBase.ImagemProduto
                                   Where Img.IdProduto = row.IdProduto
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

                If _MenorPreçp = 1000000000000000 then
                    _MenorPreçp = 0
                End If

                DtBddIARA.Rows.Add(ImgProduto, row.IdProduto, row.Descricao, _Qt, FormatCurrency(_MenorPreçp, NumDigitsAfterDecimal:=2), FormatPercent(row.Markup / 100, NumDigitsAfterDecimal:=2), FormatCurrency(VlrRevenda, NumDigitsAfterDecimal:=2))

                If row.Markup = 0 Then

                    DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).DefaultCellStyle.BackColor = Color.PeachPuff
                    DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Chocolate

                Else

                    DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).DefaultCellStyle.BackColor = Color.WhiteSmoke
                    DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.SlateGray
                    DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(5).Style.Font = New Font("Calibri", 12)

                End If

            End If

        Next

        'BuscaSolicitaóes da oficina

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim BuscaOficina = From prod In LqOficina.SolicitacaoCadastroPeca
                           Where prod.IdCodCad = 0
                           Select prod.Descricao, prod.Markup, prod.IdSolicitacaoCadastro

        For Each row In BuscaOficina.ToList

            Dim ImgProduto As Image = My.Resources.untitled_n
            Dim IARA As String = ""
            Dim VlrRevenda As Decimal = 0

            'Busca ultima cotação

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                           Where cot.IdSolicitacaoCad = row.IdSolicitacaoCadastro
                           Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                           Order By DataCotacao Descending

            Dim Mkp As Decimal = 0
            Dim VlrCot As Decimal = 0

            If BuscaCot.Count > 0 Then
                VlrRevenda += BuscaCot.First.ValorCotado
                VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                Mkp = BuscaCot.First.Markup / 100
                VlrCot = BuscaCot.First.ValorCotado
            End If

            DtBddIARA.Rows.Add(ImgProduto, "S" & row.IdSolicitacaoCadastro, row.Descricao, 0, FormatCurrency(VlrCot, NumDigitsAfterDecimal:=2), FormatPercent(Mkp, NumDigitsAfterDecimal:=2), FormatCurrency(VlrRevenda, NumDigitsAfterDecimal:=2))

            If row.Markup = 0 Then

                DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).DefaultCellStyle.BackColor = Color.PeachPuff
                DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Chocolate

            Else

                DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).DefaultCellStyle.BackColor = Color.WhiteSmoke
                DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.SlateGray
                DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(5).Style.Font = New Font("Calibri", 12)

            End If

        Next

        'Busca serviócs

        Dim BuscaServico = From serv In LqBase.Servicos
                           Where serv.IdServico Like "*"
                           Select serv.IdServico, serv.VlrCusto, serv.VlrVeda, serv.Markup, serv.Descricao, serv.TME

        For Each it In BuscaServico.ToList

            DtServiços.Rows.Add(it.IdServico, it.Descricao, FormatDateTime(BuscaServico.First.TME.ToString, DateFormat.ShortTime), FormatCurrency(it.VlrCusto, NumDigitsAfterDecimal:=2), FormatPercent(it.Markup / 100, NumDigitsAfterDecimal:=2), FormatCurrency(it.VlrVeda, NumDigitsAfterDecimal:=2))

            If it.Markup = 0 Then

                DtServiços.Rows(DtServiços.Rows.Count - 1).DefaultCellStyle.BackColor = Color.PeachPuff
                DtServiços.Rows(DtServiços.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Chocolate

            Else

                DtServiços.Rows(DtServiços.Rows.Count - 1).DefaultCellStyle.BackColor = Color.WhiteSmoke
                DtServiços.Rows(DtServiços.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.SlateGray
                DtServiços.Rows(DtServiços.Rows.Count - 1).Cells(4).Style.Font = New Font("Calibri", 12)

            End If

        Next

    End Sub

    Private Sub DtBddIARA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBddIARA.CellContentClick

    End Sub

    Private Sub DtBddIARA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBddIARA.CellDoubleClick

        FrmMarkupInserir.LblCodigo.Text = DtBddIARA.Rows(e.RowIndex).Cells(1).Value
        FrmMarkupInserir.LblDescrição.Text = DtBddIARA.Rows(e.RowIndex).Cells(2).Value

        Dim CodStr As String = DtBddIARA.Rows(e.RowIndex).Cells(1).Value

        If Not CodStr.StartsWith("S") Then

            Dim Cod As Integer = CodStr

            'Busca dimensões

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaDimensões = From dime In LqBase.Produtos
                                 Where dime.IdProduto = Cod
                                 Select dime.Largura, dime.Altura, dime.Profundidade, dime.Peso

            Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
            LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

            Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                   Where arm.IdProduto = Cod
                                   Select arm.Qt, arm.ValorUnit, arm.DataEntrada
                                   Order By DataEntrada Descending

            FrmMarkupInserir.LblTamamnho.Text = "A.:" & FormatNumber(BuscaDimensões.First.Altura, NumDigitsAfterDecimal:=0) & "mm - L.:" & FormatNumber(BuscaDimensões.First.Largura, NumDigitsAfterDecimal:=0) & "mm - P.:" & FormatNumber(BuscaDimensões.First.Profundidade, NumDigitsAfterDecimal:=0) & "mm - Kg.:" & FormatNumber(BuscaDimensões.First.Peso, NumDigitsAfterDecimal:=3)
            FrmMarkupInserir.BttSalvarMarkupCot.Visible = False
            FrmMarkupInserir.BttPular.Visible = False

            If BuscaArmazenagem.Count > 0 Then

                FrmMarkupInserir.LblAquisicao.Text = FormatCurrency(BuscaArmazenagem.First.ValorUnit, NumDigitsAfterDecimal:=2)

            End If

        Else

            CodStr = CodStr.Remove(0, 1)

            Dim Cod As Integer = CodStr

            'Busca cotações

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaCotação = From arm In LqFinanceiro.Cotacoes
                               Where arm.IdSolicitacaoCad = Cod
                               Select arm.Qt, arm.ValorCotado, arm.DataCotacao
                               Order By DataCotacao Descending

            FrmMarkupInserir.LblTamamnho.Text = "Não definido"
            FrmMarkupInserir.BttSalvarMarkupCot.Visible = False
            FrmMarkupInserir.BttPular.Visible = False

            If BuscaCotação.Count > 0 Then

                FrmMarkupInserir.LblAquisicao.Text = FormatCurrency(BuscaCotação.First.ValorCotado, NumDigitsAfterDecimal:=2)

            End If


        End If

        Dim MArkup As String = DtBddIARA.Rows(e.RowIndex).Cells(5).Value
        MArkup = MArkup.Replace("%", "")

        FrmMarkupInserir.TxtMarkup.Value = MArkup
        FrmMarkupInserir.BttSalvarMarkup.Visible = True

        FrmMarkupInserir.Show(Me)

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.Timer1.Enabled = True
        Me.Close()

    End Sub

    Private Sub DtServiços_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtServiços.CellContentClick

    End Sub

    Private Sub DtServiços_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtServiços.CellDoubleClick

        FrmMarkupInserirServiço.LblCodigo.Text = DtServiços.Rows(e.RowIndex).Cells(0).Value
        FrmMarkupInserirServiço.LblDescrição.Text = DtServiços.Rows(e.RowIndex).Cells(1).Value

        'BuscaOperacional envolvido

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim IdServiço As Integer = DtServiços.Rows(e.RowIndex).Cells(0).Value

        Dim BuscaCargoServico = From serv In LqBase.ProfissionalServico
                                Where serv.IdServico = IdServiço
                                Select serv.IdProfissional

        Dim Salario As Decimal = 0

        For Each row In BuscaCargoServico.ToList

            Dim BuscaProfissional = From prof In LqBase.Cargos
                                    Where prof.IdCargo = BuscaCargoServico.First
                                    Select prof.RemuneracaoBase, prof.RemHR

            If BuscaProfissional.First.RemHR = True Then

                Dim RemMensal As Decimal = BuscaProfissional.First.RemuneracaoBase * 220

                If Salario < RemMensal Then

                    Salario = RemMensal

                End If

            Else


                If Salario < BuscaProfissional.First.RemuneracaoBase Then

                    Salario = BuscaProfissional.First.RemuneracaoBase

                End If

            End If

        Next

        'calcula valor por minuto e multiplica pelo tempo solicitado

        Dim SalMin As Decimal = (Salario / 220) / 60

        Dim HrTme As String = DtServiços.SelectedCells(2).Value.ToString.ToCharArray(0, 2)
        Dim MinTme As String = DtServiços.SelectedCells(2).Value.ToString.ToCharArray(3, 2)

        Dim TmeTot As Integer = (HrTme * 60) + MinTme

        FrmMarkupInserirServiço.LblAquisicao.Text = FormatCurrency(TmeTot * SalMin, NumDigitsAfterDecimal:=2)


        Dim MArkup As String = DtServiços.Rows(e.RowIndex).Cells(5).Value
        MArkup = MArkup.Replace("%", "")

        FrmMarkupInserirServiço.TxtMarkup.Value = MArkup
        FrmMarkupInserirServiço.Show(Me)

    End Sub
End Class