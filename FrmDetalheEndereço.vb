Public Class FrmDetalheEndereço

    Public IdEndereco As Integer

    Private Sub FrmDetalheEndereço_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaBaixas()

    End Sub

    Dim Baixados As Integer = 0

    Public Sub CarregaBaixas()

        Dim LqEstoque As New LqEstoqueLocalDataContext
        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        Dim BuscaBaixas = From bai In LqEstoque.BaixaEndereco
                          Where bai.IdEndereco = IdEndereco And bai.NumNf Like LblNumNf.Text
                          Select bai.Qt, bai.DataBaixa, bai.HoraBaixa, bai.IdEnderecoBaixa, bai.IdUsuarioBaixa

        DtBaixas.Rows.Clear()

        For Each row In BuscaBaixas.ToList

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaNomeBaixa = From bai In LqBase.Funcionarios
                                 Where bai.IdExterno = row.IdUsuarioBaixa
                                 Select bai.NomeCompleto, bai.Cargo

            If BuscaNomeBaixa.Count > 0 Then
                DtBaixas.Rows.Add(row.IdEnderecoBaixa, BuscaNomeBaixa.First.NomeCompleto & " (" & BuscaNomeBaixa.First.Cargo & ")", FormatDateTime(row.DataBaixa, DateFormat.ShortDate), FormatDateTime(row.HoraBaixa.ToString, DateFormat.LongTime), row.Qt)
            Else
                DtBaixas.Rows.Add(row.IdEnderecoBaixa, "Não foi possível encontrar o usuário na base local", FormatDateTime(row.DataBaixa, DateFormat.ShortDate), FormatDateTime(row.HoraBaixa.ToString, DateFormat.LongTime), row.Qt)
            End If

            Baixados += row.Qt

        Next

        If LblCod.Text <> "" Then
            Dim QtDisponivel As Integer = TxtQtdadeDisponivel.Text
            TxtQtdadeDisponivel.Text = QtDisponivel - Baixados
            If QtDisponivel - Baixados > 0 Then
                BtnMovimentar.Enabled = True
            Else
                BtnMovimentar.Enabled = False
            End If
        Else
            BtnMovimentar.Enabled = False
        End If

    End Sub
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub BttDeclinarOrc_Click(sender As Object, e As EventArgs) Handles BtnMovimentar.Click

        FrmEnderecosDisponiveis.IdProduto = LblCod.Text
        FrmEnderecosDisponiveis.IdEndereco = IdEndereco
        FrmEnderecosDisponiveis.TxtQtdadeMovimentar.Maximum = TxtQtdadeDisponivel.Text
        FrmEnderecosDisponiveis.Show(Me)

    End Sub
End Class