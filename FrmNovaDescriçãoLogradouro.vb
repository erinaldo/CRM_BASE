Public Class FrmNovadescriçãoLogradouro
    Private Sub TxtAbreviacao_TextChanged(sender As Object, e As EventArgs) Handles TxtAbreviação.TextChanged
        If TxtAbreviação.Text <> "" Then
            TxtDescrição.Enabled = True
        Else
            TxtDescrição.Enabled = False
            TxtDescrição.Text = ""
        End If
    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If TxtDescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Public formOri As Integer
    Dim LqGeral As New DtCadastroDataContext
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click
        'salva

        LqGeral.InsereDescricaoEndereco(TxtDescrição.Text, TxtAbreviação.Text)

        If formOri = 0 Then

            'popula no form novo endereço

            'busca abreviação

            Dim BuscaDescrições = From desc In LqGeral.DescricaoLogradouros
                                  Where desc.IdDescricaoLog Like "*"
                                  Select desc.Abreviacao, desc.Descricao, desc.IdDescricaoLog

            FrmEndereço.LstIddescricao.Items.Clear()
            FrmEndereço.LstAbreviação.Items.Clear()
            FrmEndereço.Lstdescricao.Items.Clear()
            FrmEndereço.CmbAbreviação.Items.Clear()

            For Each row In BuscaDescrições.ToList
                FrmEndereço.LstIddescricao.Items.Add(row.IdDescricaoLog)
                FrmEndereço.LstAbreviação.Items.Add(row.Abreviacao)
                FrmEndereço.Lstdescricao.Items.Add(row.Descricao)
                FrmEndereço.CmbAbreviação.Items.Add(row.Abreviacao & " - " & row.Descricao)
            Next

            FrmEndereço.CmbAbreviação.SelectedItem = TxtAbreviação.Text & " - " & TxtDescrição.Text

            Me.Close()

        End If

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub
End Class