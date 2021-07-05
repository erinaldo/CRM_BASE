Public Class FrmNacionalidade
    Dim lqCadastro As New DtCadastroDataContext
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub BttAddPais_Click(sender As Object, e As EventArgs) Handles BttAddPais.Click
        FrmNovoPais.ShowDialog()
    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If TxtDescrição.Text <> "" Then
            CmbPais.Enabled = True
            BttAddPais.Enabled = True
        Else
            CmbPais.Enabled = False
            BttAddPais.Enabled = False
            CmbPais.Text = ""
        End If
    End Sub

    Public LstIdPaises As New ListBox
    Public Lstdescricao As New ListBox
    Public lstSigla As New ListBox

    Private Sub FrmNacionalidade_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lqCadastro.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'carrega paises
        Dim BuscaPaises = From pa In lqCadastro.Paises
                          Where pa.IdPais Like "*"
                          Select pa.Descricao, pa.IdPais, pa.Sigla

        LstIdPaises.Items.Clear()
        Lstdescricao.Items.Clear()
        lstSigla.Items.Clear()
        CmbPais.Items.Clear()

        For Each row In BuscaPaises.ToList
            LstIdPaises.Items.Add(row.IdPais)
            Lstdescricao.Items.Add(row.descricao)
            lstSigla.Items.Add(row.Sigla)
            CmbPais.Items.Add(row.Sigla & " - " & row.descricao)
        Next
    End Sub

    Private Sub CmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPais.SelectedIndexChanged

        If CmbPais.Items.Contains(CmbPais.Text) Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If

    End Sub

    Dim LqCadastros As New DtCadastroDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnConcluir_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        lqCadastro.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'salva nacionalidade

        lqCadastro.InsereNacionalidade(TxtDescrição.Text, LstIdPaises.Items(CmbPais.SelectedIndex).ToString, Lstdescricao.Items(CmbPais.SelectedIndex).ToString)

        'manda cadastro pro form inicial

        'busca nacionalidades

        Dim BuscaNac = From nac In LqCadastros.Nacionalidades
                       Where nac.IdNacionalidade Like "*"
                       Select nac.Nacionalidade, nac.IdNacionalidade

        FrmCadColaboradores.LstIdNacionalidades.Items.Clear()
        FrmCadColaboradores.CmbNacionalidade.Items.Clear()

        For Each row In BuscaNac.ToList

            FrmCadColaboradores.LstIdNacionalidades.Items.Add(row.IdNacionalidade)
            FrmCadColaboradores.CmbNacionalidade.Items.Add(row.Nacionalidade)

        Next

        FrmCadColaboradores.CmbNacionalidade.SelectedItem = TxtDescrição.Text

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub
End Class