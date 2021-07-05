Imports System.Net
Imports Newtonsoft.Json

Public Class FrmEnderecosEncontradosExpedicao
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'emite cotação e compra por divergencia de estoque


    End Sub

    Public IdPedido As Integer
    Public IdItemPedido As Integer
    Public ChaveOficina As String

    Public TipoForm As Integer = 0

    Private Sub BttLiberarEntregador_Click(sender As Object, e As EventArgs) Handles BttLiberarEntregador.Click

        If TipoForm = 0 Then

            'valida produto encontrado

            'busca itens do pedido 

            Dim baseUrlItens As String = "http://www.iarasoftware.com.br/atualiza_item_pedido_expedicao.php?ChaveOficina=" & ChaveOficina & "&IdItemPedido=" & IdItemPedido
            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientItens = New WebClient()
            Dim contentItens = syncClientItens.DownloadString(baseUrlItens)

            Dim readItens = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentItens & "]")

            Dim Encerra As Boolean = False

            If readItens.Count > 0 Then

                If readItens.Item(0).Create = "OK" Then

                    Encerra = True

                Else

                    MsgBox("Houve um erro na autorização dos dados no servidor, tente novamente!", MsgBoxStyle.OkOnly)

                End If

            Else

                MsgBox("Houve um erro na autorização dos dados no servidor, tente novamente!", MsgBoxStyle.OkOnly)

            End If

            'atualiza item pedido

            If Encerra = True Then

                'busca itens do pedido 

                Dim baseUrlGeral As String = "http://www.iarasoftware.com.br/update_status_expedicao.php?ChaveOficina=" & ChaveOficina & "&IdPedido=" & IdPedido & "&DataEstoqueValidado=" & Today.Date & "&HoraEstoqueValidado=" & Now.TimeOfDay.ToString
                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientGeral = New WebClient()
                Dim contentGeral = syncClientGeral.DownloadString(baseUrlGeral)

                Dim readGeral = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentGeral & "]")

                If readGeral.Count > 0 Then

                    If readGeral.Item(0).Create = "OK" Then

                        FrmExpedicao.CarregaExpedicao()
                        FrmExpedicao.Timer1.Enabled = True

                        Me.Close()

                    Else

                        MsgBox("Houve um erro na autorização dos dados no servidor, tente novamente!", MsgBoxStyle.OkOnly)

                    End If

                Else

                    MsgBox("Houve um erro na autorização dos dados no servidor, tente novamente!", MsgBoxStyle.OkOnly)

                End If

            End If

        ElseIf TipoForm = 1 Then

            'busca itens do pedido 

            Dim baseUrlGeral As String = "http://www.iarasoftware.com.br/update_status_expedicao_separacao.php?ChaveOficina=" & ChaveOficina & "&IdPedido=" & IdPedido & "&DataSeparacao=" & Today.Date & "&HoraSeparacao=" & Now.TimeOfDay.ToString
            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientGeral = New WebClient()
            Dim contentGeral = syncClientGeral.DownloadString(baseUrlGeral)

            Dim readGeral = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentGeral & "]")

            If readGeral.Count > 0 Then

                If readGeral.Item(0).Create = "OK" Then

                    FrmExpedicao.CarregaExpedicao()
                    FrmExpedicao.Timer1.Enabled = True

                    Me.Close()

                Else

                    MsgBox("Houve um erro na autorização dos dados no servidor, tente novamente!", MsgBoxStyle.OkOnly)

                End If

            Else

                MsgBox("Houve um erro na autorização dos dados no servidor, tente novamente!", MsgBoxStyle.OkOnly)

            End If

        End If

    End Sub
End Class