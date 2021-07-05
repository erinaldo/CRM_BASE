Imports System.Net

Public Class FrmTodosServicos
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        FrmCadSeviçosvb.Show(Me)

    End Sub

    Private Sub FrmTodosServicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Public Sub CarregaInicio()

        DtBddIARA.Rows.Clear()

        'busca serviços cadastrados

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaServico = From serv In LqBase.Servicos
                           Where serv.IdServico Like "*"
                           Select serv.IdServico, serv.Descricao, serv.TME, serv.VlrVeda, serv.IdServicoInt

        For Each row In BuscaServico.ToList

            Dim BuscaColaboradorServico = From serv In LqBase.ProfissionalServico
                                          Where serv.IdServico = row.IdServico
                                          Select serv.IdServico

            DtBddIARA.Rows.Add(row.IdServico, row.Descricao, row.TME, BuscaColaboradorServico.Count, FormatCurrency(row.VlrVeda, NumDigitsAfterDecimal:=2), row.IdServicoInt, ImageList1.Images(0))

        Next
    End Sub
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub DtBddIARA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBddIARA.CellContentClick

        If DtBddIARA.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            If MsgBox("Deseja realmente apagar esse serviço?" & Chr(13) & "Lembre-se se este serviço foi utlizado em algum arquivo, a exclusão não será possível", vbInformation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim IdServico As Integer = DtBddIARA.Rows(e.RowIndex).Cells(0).Value
                Dim IdServicoExt As Integer = DtBddIARA.Rows(e.RowIndex).Cells(5).Value

                LqBase.DeletaServico(IdServico)

                Dim baseUrl As String = "http://www.iarasoftware.com.br/deleta_servico_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdServico=" & IdServicoExt

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)

                CarregaInicio()

            End If

        End If

    End Sub

    Private Sub DtBddIARA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBddIARA.CellDoubleClick

        'busca dados do servico selecionado

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim Id As Integer = DtBddIARA.SelectedCells(0).Value
        Dim BuscaDados = From serv In LqBase.Servicos
                         Where serv.IdServico = Id
                         Select serv.Descricao, serv.TME, serv.IdServico, serv.IdServicoInt

        FrmCadSeviçosvb.TxtDescrição.Text = BuscaDados.First.Descricao
        FrmCadSeviçosvb.TxtTME.Text = FormatDateTime(BuscaDados.First.TME.ToString, DateFormat.ShortTime)

        FrmCadSeviçosvb._IdInterno = BuscaDados.First.IdServico
        FrmCadSeviçosvb._IdExterno = BuscaDados.First.IdServicoInt

        'busca profissinais 

        Dim BuscaProfissionais = From prof In LqBase.ProfissionalServico
                                 Where prof.IdServico = BuscaDados.First.IdServico
                                 Select prof.Qtdade, prof.IdProfissional

        For Each row In BuscaProfissionais.ToList

            Dim BuscaProfissional = From prof In LqBase.Cargos
                                    Where prof.IdCargo = row.IdProfissional
                                    Select prof.Descricao

            FrmCadSeviçosvb.DtProdutos.Rows.Add(row.IdProfissional, BuscaProfissional.First, row.Qtdade, My.Resources.Cancel_40972)

        Next

        FrmCadSeviçosvb.Show(Me)

    End Sub
End Class