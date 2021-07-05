Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports Newtonsoft.Json

Public Class FrmNovaFuncao
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TxtDescricao_TextChanged(sender As Object, e As EventArgs) Handles TxtDescricao.TextChanged

        If TxtDescricao.Text <> "" Then
            TxtRemuneracao.Enabled = True
            CkComissao.Enabled = True
        Else
            TxtRemuneracao.Enabled = False
            TxtRemuneracao.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
            CkComissao.Enabled = False
            CkComissao.Checked = False

        End If

    End Sub

    Private Sub TxtRemuneracao_TextChanged(sender As Object, e As EventArgs) Handles TxtRemuneracao.TextChanged

        If TxtRemuneracao.Text <> "" Then

            Dim VlrRem As Decimal = TxtRemuneracao.Text

            If VlrRem > 0 Then

                RdbMensal.Enabled = True
                RdbHora.Enabled = True

            End If

        End If

    End Sub

    Private Sub RdbMensal_CheckedChanged(sender As Object, e As EventArgs) Handles RdbMensal.CheckedChanged

        If RdbHora.Checked = True Or RdbMensal.Checked = True Then
            TxtDiaFechamento.Enabled = True
            BttSalvar.Enabled = True
        Else
            TxtDiaFechamento.Value = 20
            TxtDiaFechamento.Enabled = False
            BttSalvar.Enabled = False
        End If

    End Sub

    Public _IdFuncao As Integer = 0
    Public _IdInterno As Integer = 0

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        If _IdInterno = 0 Then

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim Sel As Boolean = False
            Dim Sel2 As Boolean = True

            If RdbMensal.Checked = True Then
                Sel = True
                Sel2 = False
            End If

            LqBase.InsereNovoCargo(TxtDescricao.Text, TxtRemuneracao.Text, TxtVlrComissao.Value, Sel, Sel2, TxtDiaFechamento.Value, 0)

            Dim UltimoId As Integer = LqBase.Cargos.ToList.Last.IdCargo

            _IdInterno = UltimoId

        Else

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim Sel As Boolean = False
            Dim Sel2 As Boolean = True

            If RdbMensal.Checked = True Then
                Sel = True
                Sel2 = False
            End If

            LqBase.AtualizaCargo(TxtDescricao.Text, TxtRemuneracao.Text, TxtVlrComissao.Value, Sel, Sel2, TxtDiaFechamento.Value, _IdInterno, _IdFuncao)

        End If

        'insere cargo no banco externo

        Dim Remuneracao As String = FormatNumber(TxtRemuneracao.Text, NumDigitsAfterDecimal:=2)
        Remuneracao = Remuneracao.Replace(".", "")

        Dim baseUrl As String = "http://www.iarasoftware.com.br/create_funcao_colaborador_local.php?DescricaoFuncao=" & TxtDescricao.Text & "&RemuneracaoPaga=" & Remuneracao.Replace(",", ".") & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdFuncao=" & _IdFuncao & "&IdVinculoFuncao=" & _IdInterno

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        ' Cria o serializados Json e trata a resposta
        Dim serializer As New DataContractJsonSerializer(GetType(Classe_Veiculos_Oficina.Create))
        Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
            ' deserializa o objeto JSON usando o tipo de dados
            Dim weatherData = DirectCast(serializer.ReadObject(ms), Classe_Veiculos_Oficina.Create)
            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

            If read.Count > 0 Then

                _IdFuncao = read.Item(0).Id

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim Sel As Boolean = False
                Dim Sel2 As Boolean = True

                If RdbMensal.Checked = True Then
                    Sel = True
                    Sel2 = False
                End If

                LqBase.AtualizaCargo(TxtDescricao.Text, TxtRemuneracao.Text, TxtVlrComissao.Value, Sel, Sel2, TxtDiaFechamento.Value, _IdInterno, _IdFuncao)

                FrmListaFuncao.CarregaInicio()

                Dim BuscaCargos = From carg In LqBase.Cargos
                                  Where carg.IdCargo Like "*"
                                  Select carg.RemuneracaoBase, carg.Descricao, carg.IdCargo

                FrmCadColaboradores.LstIdCargo.Items.Clear()
                FrmCadColaboradores.LstRemuneracao.Items.Clear()
                FrmCadColaboradores.CmbFuncao.Items.Clear()

                For Each row In BuscaCargos.ToList
                    FrmCadColaboradores.LstIdCargo.Items.Add(row.IdCargo)
                    FrmCadColaboradores.LstRemuneracao.Items.Add(row.RemuneracaoBase)
                    FrmCadColaboradores.CmbFuncao.Items.Add(row.Descricao)
                Next

                FrmCadColaboradores.CmbFuncao.SelectedIndex = FrmCadColaboradores.CmbFuncao.Items.Count - 1

                Me.Close()

            Else

            End If

            'Return weatherData
        End Using

        'atualiza endereco interno


    End Sub

    Private Sub CkComissao_CheckedChanged(sender As Object, e As EventArgs) Handles CkComissao.CheckedChanged

        If CkComissao.Checked = True Then
            TxtVlrComissao.Enabled = True
        Else
            TxtVlrComissao.Enabled = False
            TxtVlrComissao.Value = 0
        End If

    End Sub

    Private Sub FrmNovaFuncao_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca dados da funçao epopula pra edicao

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaFuncoes = From fun In LqBase.Cargos
                           Where fun.IdCargo = _IdInterno
                           Select fun.Fechamento, fun.IdCargo, fun.Descricao, fun.RemuneracaoBase, fun.IdExterno, fun.RemMensal, fun.RemHR, fun.ComVenda

        If BuscaFuncoes.Count > 0 Then

            TxtDescricao.Text = BuscaFuncoes.First.Descricao
            TxtRemuneracao.Text = FormatCurrency(BuscaFuncoes.First.RemuneracaoBase, NumDigitsAfterDecimal:=2)

            If BuscaFuncoes.First.ComVenda > 0 Then
                CkComissao.Checked = True
            End If

            TxtVlrComissao.Value = BuscaFuncoes.First.ComVenda
            RdbMensal.Checked = BuscaFuncoes.First.RemMensal
            RdbHora.Checked = BuscaFuncoes.First.RemHR
            TxtDiaFechamento.Value = BuscaFuncoes.First.Fechamento

        End If

    End Sub

    Private Sub TxtRemuneracao_GotFocus(sender As Object, e As EventArgs) Handles TxtRemuneracao.GotFocus

        TxtRemuneracao.Text = FormatNumber(TxtRemuneracao.Text, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub TxtRemuneracao_LostFocus(sender As Object, e As EventArgs) Handles TxtRemuneracao.LostFocus

        If TxtRemuneracao.Text = "" Then
            TxtRemuneracao.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
        End If

        TxtRemuneracao.Text = FormatCurrency(TxtRemuneracao.Text, NumDigitsAfterDecimal:=2)

    End Sub
End Class