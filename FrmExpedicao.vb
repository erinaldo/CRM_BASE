Imports System.Net
Imports Newtonsoft.Json

Public Class FrmExpedicao
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub FrmExpedicao_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaExpedicao()

    End Sub

    Dim MkTmp As Date
    Dim MkTmp2 As Date

    Public Sub CarregaExpedicao()

        DtEsperados.Rows.Clear()

        'busca itens do pedido 

        Dim baseUrlItens As String = "http://www.iarasoftware.com.br/consulta_itens_pedido_expedicao.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientItens = New WebClient()
        Dim contentItens = syncClientItens.DownloadString(baseUrlItens)

        Dim readItens = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Expedicao))(contentItens)

        For Each it In readItens.ToList

            Dim Status As String = ""
            Dim DataInicio As Date = it.DataSolicitacao & " " & it.HoraSolicitacao
            Dim UltimoStatus As Date
            Dim diasUltimo As Integer = 0
            Dim horasUltimo As Integer = 0
            Dim minutosUltimo As Integer = 0
            Dim segundosUltimo As Integer = 0

            If it.Status = 1 Then
                Status = "Aguardando confirmação de estoque"
                UltimoStatus = it.DataFinanceiroLib & " " & it.HoraFinanceiroLib
            ElseIf it.Status = 2 Then
                Status = "Aguardando separação de estoque"
                UltimoStatus = it.DataEstoqueValidado & " " & it.HoraEstoqueValidado
            ElseIf it.Status = 3 Then
                Status = "Aguardando coleta/retirada"
                UltimoStatus = it.DataSeparacao & " " & it.HoraSeparacao
            ElseIf it.Status = 4 Then
                Status = "Coletado, pedido sendo transportado"
                UltimoStatus = it.DataColeta & " " & it.HoraColeta
            ElseIf it.Status = 5 Then
                Status = "Pedido Entregue"
                UltimoStatus = it.DataColeta & " " & it.HoraColeta
            End If

            If it.Status < 5 Then

                Dim DataGravada As Date = UltimoStatus

                If Status <> "" Then

                    Dim dias As Integer = 0
                    Dim Horas As Integer = 0
                    Dim Minutos As Integer = 0
                    Dim Segundos As Integer = 0

                    Dim Tempo As Date

                    Tempo = DataInicio
                    MkTmp = DataInicio
                    MkTmp2 = UltimoStatus

                    Dim Agora As Date = Now

                    If Tempo <= Agora Then
                        While Tempo.AddDays(1) < Agora
                            Tempo = Tempo.AddDays(1)
                            dias += 1
                        End While
                    End If
                    If Tempo.AddHours(1) <= Agora Then
                        While Tempo.AddHours(1) < Agora
                            Tempo = Tempo.AddHours(1)
                            Horas += 1
                        End While
                    End If
                    If Tempo <= Agora Then
                        While Tempo.AddMinutes(1) < Agora
                            Tempo = Tempo.AddMinutes(1)
                            Minutos += 1
                        End While
                    End If
                    If Tempo <= Agora Then
                        While Tempo.AddSeconds(1) < Agora
                            Tempo = Tempo.AddSeconds(1)
                            Segundos += 1
                        End While
                    End If


                    If UltimoStatus <= Agora Then
                        While UltimoStatus.AddDays(1) < Agora
                            UltimoStatus = UltimoStatus.AddDays(1)
                            diasUltimo += 1
                        End While
                    End If
                    If UltimoStatus.AddHours(1) <= Agora Then
                        While UltimoStatus.AddHours(1) < Agora
                            UltimoStatus = UltimoStatus.AddHours(1)
                            horasUltimo += 1
                        End While
                    End If
                    If UltimoStatus <= Agora Then
                        While UltimoStatus.AddMinutes(1) < Agora
                            UltimoStatus = UltimoStatus.AddMinutes(1)
                            minutosUltimo += 1
                        End While
                    End If
                    If UltimoStatus <= Agora Then
                        While UltimoStatus.AddSeconds(1) < Agora
                            UltimoStatus = UltimoStatus.AddSeconds(1)
                            segundosUltimo += 1
                        End While
                    End If

                    Dim ModoRetira As String = ""

                    If it.ChaveEntregador.StartsWith("RET") Then

                        ModoRetira = "Retirada pelo cliente"

                    ElseIf it.ChaveEntregador.StartsWith("ENT") Then
                        'insere coleta

                        'gera a chave da coleta
                        Dim ChaveColeta As String

                        'busca itens do pedido 

                        Dim baseUrlCreateColeta As String = "http://www.iarasoftware.com.br/create_coleta_pedido.php?ChaveColeta=" & ChaveColeta & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&ChavePrestador=" & "&DataColeta=1111-11-11&HoraColeta=00:00:00&DataEntrega=1111-11-11&HoraEntrega=00:00:00&KmRodado=0&Validador=ND&IdPedido=" & it.IdPedido

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientCreateColeta = New WebClient()
                        Dim contentCreateColeta = syncClientCreateColeta.DownloadString(baseUrlCreateColeta)

                        Dim readCreateColeta = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentCreateColeta & "]")

                    ElseIf Not it.ChaveEntregador.StartsWith("PRN") And Not it.ChaveEntregador.StartsWith("ENT") And Not it.ChaveEntregador.StartsWith("RET") Then
                        ModoRetira = it.ChaveEntregador
                    ElseIf it.ChaveEntregador.StartsWith("PRN") Then

                        'busca itens do pedido 

                        Dim baseUrlCreateColeta As String = "http://www.iarasoftware.com.br/consulta_coleta_pedido.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdPedido=" & it.IdPedido

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientCreateColeta = New WebClient()
                        Dim contentCreateColeta = syncClientCreateColeta.DownloadString(baseUrlCreateColeta)

                        Dim readCreateColeta = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ColetaPedido))(contentCreateColeta)

                        If readCreateColeta.Count > 0 Then

                            If readCreateColeta.Item(0).ChavePrestador <> "" Then
                                ModoRetira = readCreateColeta.Item(0).ChavePrestador
                            Else
                                ModoRetira = "Procurando entregador..."

                            End If

                        Else

                            ModoRetira = "Erro na aquisiçao do numero da coleta"

                        End If

                    End If

                    DtEsperados.Rows.Add(it.ChaveOficina, it.NomeCliente, it.IdProdutoExt, 0,
                                 it.Descricao, it.Qtdade, Status, it.Status, it.IdPedido,
                                 it.IdItemPedido, diasUltimo & " dia(s), " & horasUltimo & " hora(s), " & minutosUltimo & " minuto(s)," & segundosUltimo & " segundo(s).",
                                 dias & " dia(s), " & Horas & " hora(s), " & Minutos & " minuto(s)," & Segundos & " segundo(s)." _
                                 , DataInicio.ToString, DataGravada.ToString, ModoRetira)

                End If

            End If

        Next

        'carrega as solicitações on line

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

    End Sub

    Dim Val As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Val = 3 Then
            CarregaExpedicao()
            Val = 0
        Else
            Val += 1
        End If

    End Sub

    Private Sub DtEsperados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtEsperados.CellContentClick

    End Sub

    Private Sub DtEsperados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtEsperados.CellDoubleClick

        If DtEsperados.Rows(e.RowIndex).Cells(7).Value = 1 Then

            Timer1.Enabled = False

            FrmEnderecosEncontradosExpedicao.TipoForm = 0

            FrmEnderecosEncontradosExpedicao.IdPedido = DtEsperados.Rows(e.RowIndex).Cells(8).Value
            FrmEnderecosEncontradosExpedicao.IdItemPedido = DtEsperados.Rows(e.RowIndex).Cells(9).Value
            FrmEnderecosEncontradosExpedicao.ChaveOficina = DtEsperados.Rows(e.RowIndex).Cells(0).Value

            FrmEnderecosEncontradosExpedicao.Show(Me)

        ElseIf DtEsperados.Rows(e.RowIndex).Cells(7).Value = 2 Then

            Timer1.Enabled = False

            FrmEnderecosEncontradosExpedicao.TipoForm = 1
            FrmEnderecosEncontradosExpedicao.IdPedido = DtEsperados.Rows(e.RowIndex).Cells(8).Value
            FrmEnderecosEncontradosExpedicao.IdItemPedido = DtEsperados.Rows(e.RowIndex).Cells(9).Value
            FrmEnderecosEncontradosExpedicao.ChaveOficina = DtEsperados.Rows(e.RowIndex).Cells(0).Value

            FrmEnderecosEncontradosExpedicao.Show(Me)

        ElseIf DtEsperados.Rows(e.RowIndex).Cells(7).Value = 3 Then

            'solicita entregador

            FrmEntregaExpedicao.Show(Me)

        End If

    End Sub

    Dim SegundosAdd As Integer = 0
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        For Each it As DataGridViewRow In DtEsperados.Rows

            Dim dias As Integer = 0
            Dim Horas As Integer = 0
            Dim Minutos As Integer = 0
            Dim Segundos As Integer = 0

            Dim diasUltimo As Integer = 0
            Dim HorasUltimo As Integer = 0
            Dim MinutosUltimo As Integer = 0
            Dim SegundosUltimo As Integer = 0

            Dim Tempo0 As Date = it.Cells(12).Value
            Dim Tempo1 As Date = it.Cells(13).Value

            Dim Agora As Date = Now

            If Tempo0 <= Agora Then
                While Tempo0.AddDays(1) < Agora
                    Tempo0 = Tempo0.AddDays(1)
                    dias += 1
                End While
            End If
            If Tempo0.AddHours(1) <= Agora Then
                While Tempo0.AddHours(1) < Agora
                    Tempo0 = Tempo0.AddHours(1)
                    Horas += 1
                End While
            End If
            If Tempo0 <= Agora Then
                While Tempo0.AddMinutes(1) < Agora
                    Tempo0 = Tempo0.AddMinutes(1)
                    Minutos += 1
                End While
            End If
            If Tempo0 <= Agora Then
                While Tempo0.AddSeconds(1) < Agora
                    Tempo0 = Tempo0.AddSeconds(1)
                    Segundos += 1
                End While
            End If


            If Tempo1 <= Agora Then
                While Tempo1.AddDays(1) < Agora
                    Tempo1 = Tempo1.AddDays(1)
                    diasUltimo += 1
                End While
            End If
            If Tempo1.AddHours(1) <= Agora Then
                While Tempo1.AddHours(1) < Agora
                    Tempo1 = Tempo1.AddHours(1)
                    horasUltimo += 1
                End While
            End If
            If Tempo1 <= Agora Then
                While Tempo1.AddMinutes(1) < Agora
                    Tempo1 = Tempo1.AddMinutes(1)
                    minutosUltimo += 1
                End While
            End If
            If Tempo1 <= Agora Then
                While Tempo1.AddSeconds(1) < Agora
                    Tempo1 = Tempo1.AddSeconds(1)
                    segundosUltimo += 1
                End While
            End If

            it.Cells(10).Value = diasUltimo & " dia(s), " & HorasUltimo & " hora(s), " & MinutosUltimo & " minuto(s)," & SegundosUltimo & " segundo(s)."
            it.Cells(11).Value = dias & " dia(s), " & Horas & " hora(s), " & Minutos & " minuto(s)," & Segundos & " segundo(s)."

        Next

    End Sub
End Class