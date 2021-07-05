Imports System.Net
Imports Newtonsoft.Json

Public Class FrmLaudos
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub FrmLaudos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Public Sub CarregaInicio()

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim BuscaOficina = From ofi In LqOficina.LaudosTecnicos
                           Where ofi.IdFaturamento = 0 And ofi.Status = 0 And ofi.Faturado = 0
                           Select ofi.ChaveOficina, ofi.IdLaudoExt, ofi.IdLaudoTecnico, ofi.DataSolicitacao, ofi.HoraSolicitacao, ofi.NomeCompleto, ofi.Status, ofi.PlacaVeiculo, ofi.ModeloVeiculo

        For Each row In BuscaOficina.ToList

            If row.Status = 0 Then

                DtFornecedores.Rows.Add(row.IdLaudoExt, FormatDateTime(row.DataSolicitacao, DateFormat.ShortDate), FormatDateTime(row.HoraSolicitacao.ToString, DateFormat.LongTime), row.NomeCompleto & " - (Placa.: " & row.PlacaVeiculo.ToUpper & " Modelo.: " & row.ModeloVeiculo & ")", ImageList2.Images(4), ImageList2.Images(0), "")

                'busca os items e verifica se tem review

                Dim BuscasSolReview = From sol In LqOficina.ItemLaudosTecnicos
                                      Where sol.Status = 2 And sol.IdLaudoTecnico = row.IdLaudoExt
                                      Select sol.IdItemExt, sol.ChaveOficina, sol.IdLaudoTecnico

                If BuscasSolReview.Count > 0 Then

                    Dim baseUrlSol As String = "http://www.iarasoftware.com.br/consulta_solicitacao_review.php?IdItemLaudo=" & BuscasSolReview.First.IdItemExt & "&ChaveOficina=" & BuscasSolReview.First.ChaveOficina & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text
                    Dim syncClientSol = New WebClient()
                    Dim contentSol = syncClientSol.DownloadString(baseUrlSol)

                    Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Review))(contentSol)

                    Dim IdLaudoEnc As Integer = 0

                    For Each rowIt In read.ToList

                        Dim DataEncontrada As Date = rowIt.DataSolicitacao & " " & rowIt.HoraSolicitacao
                        Dim DataLimite As Date = Today.Date & " " & "06:00:00"
                        Dim SecPass As Integer = 0

                        While DataEncontrada < Now

                            SecPass += 1

                            DataEncontrada = DataEncontrada.AddSeconds(1)

                            If DataLimite.TimeOfDay.ToString <> "00:00:00" Then

                                DataLimite = DataLimite.AddSeconds(-1)

                                DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(6).Value = "Aguardando reenvio de informações"

                            Else

                                DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(5).Value = ImageList2.Images(8)
                                DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(6).Value = "Solicitação expirada"

                            End If

                        End While

                        DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(7).Value = DataLimite.TimeOfDay

                    Next

                End If

                'verifica se existem solicitacoes no node principal

                If DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(7).Value = Nothing Then

                    Dim baseUrlSolR As String = "http://www.iarasoftware.com.br/consulta_solicitacao_review.php?IdItemLaudo=" & row.IdLaudoExt & "&ChaveOficina=" & row.ChaveOficina & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text
                    Dim syncClientSolR = New WebClient()
                    Dim contentSolR = syncClientSolR.DownloadString(baseUrlSolR)

                    Dim readR = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Review))(contentSolR)

                    Dim IdLaudoEncR As Integer = 0

                    For Each rowIt In readR.ToList

                        Dim DataEncontrada As Date = rowIt.DataSolicitacao & " " & rowIt.HoraSolicitacao
                        Dim DataLimite As Date = Today.Date & " " & "06:00:00"
                        Dim SecPass As Integer = 0

                        If DataEncontrada >= DataLimite Then

                            While DataEncontrada < Now

                                SecPass += 1

                                DataEncontrada = DataEncontrada.AddSeconds(1)

                                If DataLimite.TimeOfDay.ToString <> "00:00:00" Then

                                    DataLimite = DataLimite.AddSeconds(-1)

                                    DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(6).Value = "Aguardando reenvio de informações"

                                Else

                                    DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(5).Value = ImageList2.Images(8)
                                    DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(6).Value = "Solicitação expirada"

                                End If

                            End While

                            DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(7).Value = DataLimite.TimeOfDay

                        Else

                            DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(7).Value = "00:00:00"

                            DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(5).Value = ImageList2.Images(8)
                            DtFornecedores.Rows(DtFornecedores.Rows.Count - 1).Cells(6).Value = "Solicitação expirada"

                        End If


                    Next

                End If

            ElseIf row.Status = 2 Then

                'busca ultimo review

                DtFornecedores.Rows.Add(row.IdLaudoExt, FormatDateTime(row.DataSolicitacao, DateFormat.ShortDate), FormatDateTime(row.HoraSolicitacao.ToString, DateFormat.LongTime), row.NomeCompleto & " - (Placa.: " & row.PlacaVeiculo.ToUpper & " Modelo.: " & row.ModeloVeiculo & ")", ImageList2.Images(4), ImageList2.Images(0), "Aguardando documentação")

            End If

        Next

        If BuscaOficina.Count = 0 Then

            If MsgBox("Não há solicitações Not momento.", vbOKOnly) Then

                FrmPrincipal.CarregaDashboard()

                Me.Close()

            End If

        End If

    End Sub

    Private Sub DtFornecedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellContentClick

        If DtFornecedores.Columns(e.ColumnIndex).Name = "ClmAbrir" Then

            FrmItemLaudo.IdLaudo = DtFornecedores.Rows(e.RowIndex).Cells(0).Value

            FrmItemLaudo.Show(Me)

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        For Each row As DataGridViewRow In DtFornecedores.Rows

            If row.Cells(7).Value <> Nothing Then
                Dim _Chave As Date = FormatDateTime(Today.Date.ToString, vbShortDate) & " " & row.Cells(7).Value.ToString

                If _Chave.TimeOfDay.ToString <> "00:00:00" Then

                    _Chave = _Chave.AddSeconds(-1)

                    row.Cells(7).Value = _Chave.TimeOfDay.ToString

                End If
            End If

        Next

    End Sub
End Class