Public Class FrmNovoVinculoParental
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BttAddEndereço_Click(sender As Object, e As EventArgs) Handles BttAddDocumento.Click
        FrmNovoDocumento.Show(Me)
    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If TxtDescrição.Text <> "" Then
            CmbDocumento.Enabled = True
            BttAddDocumento.Enabled = True
            BttSalvar.Enabled = True
        Else
            CmbDocumento.Enabled = False
            BttAddDocumento.Enabled = False
            BttSalvar.Enabled = False
            CmbDocumento.Text = ""
        End If
    End Sub

    Public LstIdDocumento As New ListBox
    Public LstSigla As New ListBox
    Public Lstdescricao As New ListBox

    Dim LqGeral As New DtCadastroDataContext

    Private Sub FrmNovoVinculoParental_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LqGeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'busca documentos
        Dim BuscaDocs = From doc In LqGeral.Documentos
                        Where doc.IdDocumento Like "*"
                        Select doc.Descricao, doc.IdDocumento, doc.Mascara, doc.Sigla

        LstIdDocumento.Items.Clear()
        LstSigla.Items.Clear()
        Lstdescricao.Items.Clear()
        CmbDocumento.Items.Clear()

        For Each row In BuscaDocs.ToList

            LstIdDocumento.Items.Add(row.IdDocumento)
            LstSigla.Items.Add(row.Sigla)
            Lstdescricao.Items.Add(row.descricao)
            CmbDocumento.Items.Add(row.Sigla & " - " & row.descricao)

        Next

    End Sub

    Private Sub CmbDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDocumento.SelectedIndexChanged
        If CmbDocumento.Items.Contains(CmbDocumento.Text) Then
            BttInsereNaLista.Enabled = True
        Else
            BttInsereNaLista.Enabled = False
        End If
    End Sub

    Dim LstIdDocumentoInserido As New ListBox

    Private Sub BttInsereNaLista_Click(sender As Object, e As EventArgs) Handles BttInsereNaLista.Click

        ListBox1.Items.Add(CmbDocumento.Text)
        LstIdDocumentoInserido.Items.Add(LstIdDocumento.Items(CmbDocumento.SelectedIndex).ToString)

        CmbDocumento.Text = ""

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub BtnConcluir_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'salva 

        LqGeral.InsereVinculoParental(TxtDescrição.Text)

        'verifica qual o ID

        Dim BuscaVinculo = From vin In LqGeral.VinculosParentais
                           Where vin.Descricao Like TxtDescrição.Text
                           Select vin.IDVinculoParentesco

        'varre a lista e insere os documentos a serem solicitados

        For Each item In LstIdDocumentoInserido.Items

            LqGeral.InsereVinculoParental_Documento(BuscaVinculo.First, item.ToString)

        Next

        'busca todos os vinculos

        Dim BuscaTodosVinculo = From vin In LqGeral.VinculosParentais
                                Where vin.IDVinculoParentesco Like "*"
                                Select vin.Descricao, vin.IDVinculoParentesco

        FrmCadColaboradores.LstIdVinculosParentais.Items.Clear()
        FrmCadColaboradores.CmbVinculo.Items.Clear()

        For Each row In BuscaTodosVinculo.ToList
            FrmCadColaboradores.LstIdVinculosParentais.Items.Add(row.IDVinculoParentesco)
            FrmCadColaboradores.CmbVinculo.Items.Add(row.Descricao)
        Next

        FrmCadColaboradores.CmbVinculo.SelectedItem = TxtDescrição.Text

        Me.Close()

    End Sub
End Class