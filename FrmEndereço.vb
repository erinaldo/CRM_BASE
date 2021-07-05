Public Class FrmEndereço

    Public LstIddescricao As New ListBox
    Public LstAbreviação As New ListBox
    Public Lstdescricao As New ListBox

    Private Sub BttAddNacionalidade_Click(sender As Object, e As EventArgs) Handles BttAddNacionalidade.Click
        FrmNovaDescriçãoLogradouro.Show(Me)
    End Sub

    Dim LqGeral As New DtCadastroDataContext

    Private Sub FrmEndereço_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca abreviação

        Dim BuscaDescrições = From desc In LqGeral.descricaoLogradouros
                              Where desc.IddescricaoLog Like "*"
                              Select desc.abreviacao, desc.descricao, desc.IddescricaoLog

        LstIddescricao.Items.Clear()
        LstAbreviação.Items.Clear()
        Lstdescricao.Items.Clear()
        CmbAbreviação.Items.Clear()

        For Each row In BuscaDescrições.ToList
            LstIddescricao.Items.Add(row.IddescricaoLog)
            LstAbreviação.Items.Add(row.abreviacao)
            Lstdescricao.Items.Add(row.descricao)
            CmbAbreviação.Items.Add(row.abreviacao & " - " & row.descricao)

        Next
    End Sub

    Public FormOri As Integer
    Public _CEP As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'insere

        LqGeral.InsereEndereco(0, TxtDescrição.Text, _CEP, LstIddescricao.Items(CmbAbreviação.SelectedIndex).ToString)

        If FormOri = 0 Then

            'busca pelo CEP

        ElseIf FormOri = 1 Then

            'busca pelo CEP

            Dim BuscaCep = From Cep In LqGeral.Enderecos
                           Where Cep.CEP = _CEP
                           Select Cep.IdBairro, Cep.IdAbreviacao, Cep.IdEndereco, Cep.Descricao

            FrmNovoEstoque.LstIdEndereço.Items.Clear()
            FrmNovoEstoque.CmbEndereço.Items.Clear()

            For Each row In BuscaCep.ToList
                FrmNovoEstoque.LstIdEndereço.Items.Add(row.IdEndereco)
                'busca descricao
                Dim Buscadescricao = From desc In LqGeral.DescricaoLogradouros
                                     Where desc.IdDescricaoLog = row.IdAbreviacao
                                     Select desc.Abreviacao

                FrmNovoEstoque.CmbEndereço.Items.Add(Buscadescricao.First & row.descricao)

            Next

            FrmNovoEstoque.CmbEndereço.SelectedItem = LstAbreviação.Items(CmbAbreviação.SelectedIndex).ToString & txtdescrição.Text

            If BuscaCep.Count = 0 Then

                FrmNovoEstoque.CmbEndereço.Enabled = True
                FrmNovoEstoque.BttAddEndereço.Enabled = True

            ElseIf BuscaCep.Count = 1 Then

                FrmNovoEstoque.CmbEndereço.Enabled = False
                FrmNovoEstoque.BttAddEndereço.Enabled = True

            ElseIf BuscaCep.Count > 1 Then

                FrmNovoEstoque.CmbEndereço.Enabled = True
                FrmNovoEstoque.BttAddEndereço.Enabled = True

            End If
        End If

        Me.Close()

    End Sub

    Private Sub CmbAbreviação_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAbreviação.SelectedIndexChanged

        If CmbAbreviação.Items.Contains(CmbAbreviação.Text) Then
            txtdescrição.Enabled = True
        Else
            txtdescrição.Enabled = False
            txtdescrição.Text = ""
        End If
    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub
End Class