Public Class FrmVinculoFornecedor
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvarProduto.Click

        'Vincula fornecedor ao produto

        Me.Close()

    End Sub

    Public LstIdFornecedor As New ListBox

    'ccarega todos os fornecedores
    Public Sub Fornecedores()

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaFornecedores = From fornec In LqBase.Fornecedores
                                Where fornec.IdFornecedor Like "*"
                                Select fornec.Nome, fornec.Apelido, fornec.IdFornecedor

        For Each row In BuscaFornecedores.ToList

            LstIdFornecedor.Items.Add(row.IdFornecedor)
            CmbFornecedores.Items.Add(row.Nome & " - " & row.Apelido)

        Next

        If CmbFornecedores.Items.Count = 0 Then
            If MsgBox("Não existem fornecedores cadastrados no sistema, você pode realizar o vinculo a este item assim que der entrada no estoque com a nota fiscal para o fornecedor desejado. ;)", MsgBoxStyle.OkOnly) Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub CmbFornecedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFornecedores.SelectedIndexChanged

        If CmbFornecedores.Items.Contains(CmbFornecedores.Text) Then

            TxtCodFabricante.Enabled = True
            BttSrc.Enabled = True

        Else

            TxtCodFabricante.Text = ""
            TxtSRC.Text = ""
            BttSrc.Enabled = False

        End If

    End Sub

    Private Sub FrmVinculoFornecedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Fornecedores()

    End Sub

    Private Sub TxtCodFabricante_TextChanged(sender As Object, e As EventArgs) Handles TxtCodFabricante.TextChanged

        If TxtCodFabricante.Text <> "" Then
            BttSalvarProduto.Enabled = True
        Else
            BttSalvarProduto.Enabled = False
        End If

    End Sub
End Class