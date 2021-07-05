Imports System.Net

Public Class FrmColaboradoresClientes
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Public Sub CarregaInicio()

        DtProdutos.Rows.Clear()

        'cria linq 

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaTrabalhista = From Trab In LqTrabalhista.ColaboradoresCliente
                               Where Trab.IdCliente = IdCliente
                               Select Trab.DocColaborador, Trab.DescricaoFuncao, Trab.IdColaboradorCliente, Trab.IdFuncao, Trab.NomeColaborador, Trab.Remuneracao

        For Each row In BuscaTrabalhista.ToList

            DtProdutos.Rows.Add(row.IdColaboradorCliente, row.DocColaborador, row.NomeColaborador, row.DescricaoFuncao, ImageList1.Images(0), ImageList1.Images(1))

        Next

    End Sub
    Public IdCliente As Integer

    Private Sub FrmColaboradoresClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaInicio()
    End Sub

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        Me.Cursor = Cursors.WaitCursor

        FrmNovoColaboradorCliente.IdCliente = IdCliente
        FrmNovoColaboradorCliente.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

        If DtProdutos.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            If MsgBox("Tem certeza que deseja remover este colaborador, lembre-se, se ele possuir histórico de atividade no sistema, o mesmo não poderá ser removido." & Chr(13) & "Deseja realmente prosseguir?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                'remove da lista

                Dim LqTrabalhista As New LqTrabalhistaDataContext
                LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

                Dim IdCliente As Integer = DtProdutos.Rows(e.RowIndex).Cells(0).Value

                LqTrabalhista.DeletaColaboradorCliente(IdCliente)

                CarregaInicio()

            End If

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmEditar" Then

            Me.Cursor = Cursors.WaitCursor

            'carrega informações do cliente

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim IdColaborador As Integer = DtProdutos.Rows(e.RowIndex).Cells(0).Value

            Dim ConsultaBase = From bas In LqTrabalhista.ColaboradoresCliente
                               Where bas.IdCliente = IdCliente And bas.IdColaboradorCliente = IdColaborador
                               Select bas.GrupoTrab, bas.CatTrab, bas.RG_IE, bas.Telefone, bas.Personalidade, bas.NomeColaborador, bas.DocColaborador, bas.NomeFantasia, bas.Num, bas.Celular, bas.Cmpl, bas.CEP, bas.Email, bas.Remuneracao, bas.DataAdmissao, bas.DataDesligamento, bas.DescricaoFuncao

            FrmNovoColaboradorCliente.IdCliente = IdCliente

            FrmNovoColaboradorCliente.TxtNomeCompleto.Text = ConsultaBase.First.NomeColaborador

            If ConsultaBase.First.Personalidade = False Then

                FrmNovoColaboradorCliente.RdbJuridica.Checked = True

            Else

                FrmNovoColaboradorCliente.RdbFisica.Checked = True

            End If

            Dim Cnpj As String = ConsultaBase.First.DocColaborador.Replace(".", "").Replace("-", "").Replace("/", "")
            FrmNovoColaboradorCliente.TxtApelido.Text = ConsultaBase.First.NomeFantasia
            FrmNovoColaboradorCliente.TxtCPF.Text = Cnpj
            FrmNovoColaboradorCliente.TxtCPF.Text = Cnpj
            FrmNovoColaboradorCliente.TxtIE.Text = ""

            If ConsultaBase.First.Personalidade = False Then
                If ConsultaBase.First.RG_IE = "Isento" Then
                    FrmNovoColaboradorCliente.TxtIE.Text = "Isento"
                    FrmNovoColaboradorCliente.Ckisento.Checked = True
                Else
                    FrmNovoColaboradorCliente.TxtIE.Text = ConsultaBase.First.RG_IE
                End If
            Else
                FrmNovoColaboradorCliente.TxtIE.Text = ConsultaBase.First.RG_IE
            End If

            FrmNovoColaboradorCliente.TxtCep.Text = ConsultaBase.First.CEP
            FrmNovoColaboradorCliente.TxtNumero.Text = ConsultaBase.First.Num
            FrmNovoColaboradorCliente.TxtComplemento.Text = ConsultaBase.First.Cmpl

            FrmNovoColaboradorCliente.TxtTelefone.Text = ConsultaBase.First.Telefone
            FrmNovoColaboradorCliente.TxtCelular.Text = ConsultaBase.First.Celular
            FrmNovoColaboradorCliente.TxtEmail.Text = ConsultaBase.First.Email

            'seta indicador para atualizar

            FrmNovoColaboradorCliente.IdCliente = IdCliente
            FrmNovoColaboradorCliente.IdColaboradorCliente = IdColaborador

            FrmNovoColaboradorCliente.TxtRemuneracao.Text = FormatCurrency(ConsultaBase.First.Remuneracao, NumDigitsAfterDecimal:=2)

            'seleciona na lista

            FrmNovoColaboradorCliente.NomeFuncao = ConsultaBase.First.DescricaoFuncao

            FrmNovoColaboradorCliente.TxttAdmissao.Value = ConsultaBase.First.DataAdmissao

            FrmNovoColaboradorCliente.CkDsligamento.Visible = True

            'abre o form

            FrmNovoColaboradorCliente.Show(Me)

            'seleciona dados e-social

            If ConsultaBase.First.GrupoTrab <> "" Then

                FrmNovoColaboradorCliente.CkVinculo.Checked = True

                FrmNovoColaboradorCliente.CmbGrupo.SelectedItem = (ConsultaBase.First.GrupoTrab)

                FrmNovoColaboradorCliente.CmbCategoriaTrabalhador.SelectedItem = (ConsultaBase.First.CatTrab)

            Else

                FrmNovoColaboradorCliente.CkVinculo.Checked = False
                FrmNovoColaboradorCliente.TxtNumeroMatricula.Enabled = True

                FrmNovoColaboradorCliente.TxtNumeroMatricula.Text = ConsultaBase.First.CatTrab

            End If

            Me.Cursor = Cursors.Arrow

        End If

    End Sub
End Class