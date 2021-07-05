Imports System.IO
Imports PdfSharp.Drawing
Imports PdfSharp.Drawing.BarCodes
Imports PdfSharp.Pdf

Public Class FrmEmitirNFS
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Public Sub CarregaInicio()

        Me.Cursor = Cursors.WaitCursor

        DtCotFinal.Rows.Clear()

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim BuscaComercial = From com In LqComercial.Orcamentos
                             Where com.ValorRecebido = True And com.NfEmitida = False
                             Select com.IdOrcamento, com.IdCliente

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        For Each row In BuscaComercial.ToList

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaCliente = From cli In LqBase.Clientes
                               Where cli.IdCliente = row.IdCliente
                               Select cli.RazaoSocial_nome

            'verifica se NF foi emitida

            Dim BuscaNf = From nf In LqFinanceiro.NF_Saida
                          Where nf.Vinculo Like "O_" & row.IdOrcamento
                          Select nf.NumNF, nf.Serie, nf.DataAutSefaz, nf.DataEmissao

            If BuscaNf.Count = 0 Then
                DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCliente.First, "Aguardando emissão da NF", "", ImageList2.Images(0), "", ImageList2.Images(0), "", ImageList2.Images(0))
            Else

                Dim NumNf As String = BuscaNf.First.NumNF

                If NumNf.Length = 1 Then

                    NumNf = "000.00" & NumNf

                ElseIf NumNf.Length = 2 Then

                    NumNf = "000.0" & NumNf

                ElseIf NumNf.Length = 3 Then

                    NumNf = "000." & NumNf

                ElseIf NumNf.Length = 4 Then

                    NumNf = "00" & NumNf.ToCharArray(0, 1) & "." & NumNf.ToCharArray(1, 3)

                ElseIf NumNf.Length = 5 Then

                    NumNf = "0" & NumNf.ToCharArray(0, 2) & "." & NumNf.ToCharArray(2, 3)

                ElseIf NumNf.Length = 6 Then

                    NumNf = NumNf.ToCharArray(0, 3) & "." & NumNf.ToCharArray(3, 3)

                End If

                If BuscaNf.First.DataAutSefaz <> "1111-11-11" Then

                    'verifica resposta sefaz

                    DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCliente.First, "Nota fiscal emitida, o documento está disponível para consultas", NumNf, ImageList2.Images(0), FormatDateTime(BuscaNf.First.DataAutSefaz, DateFormat.ShortDate), ImageList2.Images(1), FormatDateTime(BuscaNf.First.DataEmissao, DateFormat.ShortDate), ImageList2.Images(1))

                Else

                    DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCliente.First, "Nota fiscal aguardando autorização do sefaz", NumNf, ImageList2.Images(1), "", ImageList2.Images(2), FormatDateTime(BuscaNf.First.DataEmissao, DateFormat.ShortDate), ImageList2.Images(1))

                End If

            End If

        Next

        If DtCotFinal.Rows.Count > 0 Then
            Timer1.Enabled = True
        End If

        Me.Cursor = Cursors.Arrow

    End Sub
    Private Sub FrmEmitirNFS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Private Sub DtCotFinal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellContentClick

        If DtCotFinal.Columns(e.ColumnIndex).Name = "ClmEmitir" Then

            If DtCotFinal.Rows(e.RowIndex).Cells(4).Value = "" Then
                Me.Cursor = Cursors.AppStarting

                'abre o form com a danfe preenchida

                FrmEmitirNovaNF._IdOrcamento = DtCotFinal.SelectedCells(0).Value
                FrmEmitirNovaNF.Show(Me)

                Me.Cursor = Cursors.Arrow

            Else

                MsgBox("A nota fiscal ja foi emitida.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Nota emitida")

            End If

        End If

    End Sub


    Private Sub DtCotFinal_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellDoubleClick

        'FrmEmitirNF.Show(Me)

    End Sub

    Dim C As Integer = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If C = 15 Then

            CarregaInicio()

        End If

    End Sub

End Class