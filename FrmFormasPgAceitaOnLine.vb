Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class FrmFormasPgAceitaOnLine
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        ComprasFinanceiro.VerificaValores()
        Me.Close()

    End Sub

    Public ChaveFornecedor As String
    Private Sub FrmFormasPgAceitaOnLine_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim baseUrlImagemUsuario As String = "http://www.iarasoftware.com.br/consulta_formas_pg_on_line.php?ChaveOficina=" & ChaveFornecedor

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientImagemUsuario = New WebClient()
        Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

        Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.FormasPgAceitaOnline))(contentImagemUsuario)

        For Each frmpg In readImagemUsuario.ToList

            Dim D_M As Boolean = True
            If frmpg.TipoIntervalo = 0 Then
                D_M = True
            Else
                D_M = False
            End If

            Dim AVista As Boolean = True
            If frmpg.A_Vista = 0 Then
                AVista = True
            Else
                AVista = False
            End If


            Dim baseUrlBandeira As String = "http://www.iarasoftware.com.br/bandeiras_cartoes.php"

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientBandeira = New WebClient()

            ' Chamada sincrona
            Dim contentBandeira = syncClientBandeira.DownloadString(baseUrlBandeira)

            Dim readBandeira = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.BandeiraCartao))(contentBandeira)

            Dim Img As Image = My.Resources.dollars_98561

            For Each read In readBandeira.ToList
                If frmpg.Bandeira.ToLower = read.name.ToLower Then

                    Try

                        Dim baseUrlImagem As String = read.image_url

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientImagem = New WebClient()
                        'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                        Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                        Img = Image.FromStream(stream)

                    Catch ex As Exception

                    End Try

                End If
            Next

            DtFornecedores.Rows.Add(ChaveFornecedor, "", frmpg.Descricao, Img, frmpg.Parcela _
                                    , frmpg.Intervalo, frmpg.IdFormaPgAceitaOnline, frmpg.Ag, frmpg.Conta, frmpg.Cartao, frmpg.TipoCartao, frmpg.Bandeira, frmpg.A_Vista, frmpg.TipoIntervalo)

        Next

    End Sub

    Private Sub DtFornecedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellContentClick

    End Sub

    Private Sub DtFornecedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellDoubleClick

        'declara valores da forma de pagamento de saida
        FrmNovaFormaPgSaida.TxtDescrição.Text = DtFornecedores.SelectedCells(2).Value
        FrmNovaFormaPgSaida.TxtDescrição.Enabled = False

        If DtFornecedores.SelectedCells(9).Value = 0 Then

            FrmNovaFormaPgSaida.CkCartao.Checked = True
            FrmNovaFormaPgSaida.CkCartao.Enabled = False

            If DtFornecedores.SelectedCells(10).Value = 0 Then

                FrmNovaFormaPgSaida.RdbDebito.Checked = True
                FrmNovaFormaPgSaida.RdbDebito.Enabled = False

            Else

                FrmNovaFormaPgSaida.RdbCredito.Checked = True
                FrmNovaFormaPgSaida.RdbCredito.Enabled = False

            End If

            'seleciona a bandeira do cartao

            FrmNovaFormaPgSaida.CmbBandeira.SelectedItem = DtFornecedores.SelectedCells(11).Value

        Else

            FrmNovaFormaPgSaida.CkCartao.Checked = False
            FrmNovaFormaPgSaida.CkCartao.Enabled = False

        End If

        If DtFornecedores.SelectedCells(12).Value = 0 Then

            FrmNovaFormaPgSaida.CkAvista.Checked = True
            FrmNovaFormaPgSaida.CkAvista.Enabled = False

        Else

            FrmNovaFormaPgSaida.CkAvista.Checked = False
            FrmNovaFormaPgSaida.CkAvista.Enabled = False

        End If

        FrmNovaFormaPgSaida.TxtParcelas.Value = DtFornecedores.SelectedCells(4).Value
        FrmNovaFormaPgSaida.TxtIntervalo.Value = DtFornecedores.SelectedCells(5).Value

        If DtFornecedores.SelectedCells(13).Value = 0 Then

            FrmNovaFormaPgSaida.RdbDia.Checked = True
            FrmNovaFormaPgSaida.RdbDia.Enabled = False

        Else

            FrmNovaFormaPgSaida.RdbMeses.Checked = True
            FrmNovaFormaPgSaida.RdbMeses.Enabled = False

        End If

        FrmNovaFormaPgSaida.Show(Me)

    End Sub
End Class