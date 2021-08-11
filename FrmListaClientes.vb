Imports System.Net

Public Class FrmListaClientes

    Public Ori As Integer = 0

    Private Sub FrmListaClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaInicio()
    End Sub

    Public Sub CarregaInicio()

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaCliente = From Cli In LqBase.Clientes
                           Where Cli.IdCliente Like "*" And Cli.TipoPersonalidade = True
                           Select Cli.RazaoSocial_nome, Cli.CPF_CNPJ, Cli.IdCliente

        DtProdutos.Rows.Clear()

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        For Each row In BuscaCliente.ToList

            'busca setores cadastrados

            Dim BuscaSetores = From setor In LqTrabalhista.SetoresClientes
                               Where setor.IdCliente = row.IdCliente
                               Select setor.NomeSetor

            'busca funções

            Dim BuscaFuncoes = From func In LqTrabalhista.FuncoesClientes
                               Where func.IdCliente = row.IdCliente
                               Select func.IdFuncaoCliente, func.Descricao

            DtProdutos.Rows.Add(row.IdCliente, row.CPF_CNPJ, row.RazaoSocial_nome, BuscaSetores.Count, BuscaFuncoes.Count, ImageList1.Images(0), ImageList1.Images(1), ImageList1.Images(3))

        Next

    End Sub
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        Me.Cursor = Cursors.WaitCursor

        FrmClientes.Leitura = True

        FrmClientes.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

        If DtProdutos.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            If MsgBox("Tem certeza que deseja remover este cliente, lembre-se, se ele possuir histórico de atividade no sistema, o mesmo não poderá ser removido." & Chr(13) & "Deseja realmente prosseguir?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                'remove da lista

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim IdCliente As Integer = DtProdutos.Rows(e.RowIndex).Cells(0).Value

                LqBase.DeletaCliente(IdCliente)

                'apaga da base on-line

                Dim baseUrl As String = "http://www.iarasoftware.com.br/deleta_cliente.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdCliente=" & IdCliente

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)

                'traz informaçoes novas

                CarregaInicio()

            End If

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmEditar" Then

            Me.Cursor = Cursors.WaitCursor

            'carrega informações do cliente

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim IdCliente As Integer = DtProdutos.Rows(e.RowIndex).Cells(0).Value

            Dim ConsultaBase = From bas In LqBase.Clientes
                               Where bas.IdCliente = IdCliente
                               Select bas.Telefone, bas.Apelido, bas.CPF_CNPJ, bas.RazaoSocial_nome, bas.TipoPersonalidade, bas.RG_IE, bas.CEP, bas.Celular, bas.Numero, bas.Complemento, bas.Email

            FrmClientes.IdCliente = IdCliente

            FrmClientes.TxtNomeCompleto.Text = ConsultaBase.First.RazaoSocial_nome

            If ConsultaBase.First.TipoPersonalidade = True Then

                FrmClientes.RdbJuridica.Checked = True

            Else

                FrmClientes.RdbFisica.Checked = True

            End If

            Dim Cnpj As String = ConsultaBase.First.CPF_CNPJ.Replace(".", "").Replace("-", "").Replace("/", "")
            FrmClientes.TxtApelido.Text = ConsultaBase.First.Apelido
            FrmClientes.TxtCPF.Text = Cnpj
            FrmClientes.TxtCPF.Text = Cnpj
            FrmClientes.TxtIE.Text = ConsultaBase.First.RG_IE

            If ConsultaBase.First.RG_IE = "Isento" Then
                FrmClientes.TxtIE.Text = "Isento"
                FrmClientes.Ckisento.Checked = True
            End If

            FrmClientes.TxtCPF.Enabled = False
            FrmClientes.TxtIE.Enabled = False

            FrmClientes.Leitura = True

            FrmClientes.TxtCep.Text = ConsultaBase.First.CEP
            FrmClientes.TxtNumero.Text = ConsultaBase.First.Numero
            FrmClientes.TxtComplemento.Text = ConsultaBase.First.Complemento

            'seta indicador para atualizar

            FrmClientes.IdCliente = IdCliente

            'abre o form

            FrmClientes.Show(Me)

            Me.Cursor = Cursors.Arrow

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmEsocial" Then

            Me.Cursor = Cursors.WaitCursor

            FrmESocial.Show(Me)

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Private Sub DtProdutos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellDoubleClick

        If Ori = 1 Then

            Me.Cursor = Cursors.WaitCursor

            Dim IdCliente As Integer = DtProdutos.Rows(e.RowIndex).Cells(0).Value

            FrmColaboradoresClientes.IdCliente = IdCliente

            FrmColaboradoresClientes.Show(Me)

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class