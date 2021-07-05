Public Class FrmNovoSetorCliente
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        'salva setor do cliente

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        If IdSetor = 0 Then
            LqTrabalhista.InsereSetorCliente(IdCliente, TxtNomeSetor.Text, Red & "." & Green & "." & Blue)
            IdSetor = LqTrabalhista.SetoresClientes.ToList.Last.IdSetorCliente
        End If

        LqTrabalhista.DeletaRiscoSetor(IdSetor)

        'varre a lista de funçoes e cria vinculos

        For Each row As DataGridViewRow In DtRiscos.Rows
            If row.Cells(1).Value = True Then

                LqTrabalhista.InsereRiscoSetor(row.Cells(0).Value, IdSetor)

            End If

        Next

        'apaga lista anterior

        LqTrabalhista.DeletaFuncoesSetor(IdSetor)

        'varre a lista de riscos e cria vinculos

        For Each row As DataGridViewRow In DtFuncoesCliente.Rows

            If row.Cells(1).Value = True Then
                LqTrabalhista.InsereFuncaoSetorCliente(row.Cells(0).Value, IdCliente, IdSetor, row.Cells(2).Value)
            End If

        Next

        If Application.OpenForms.OfType(Of FrmSetoresClientes)().Count() > 0 Then

            FrmSetoresClientes.CarregaInicio()

        ElseIf Application.OpenForms.OfType(Of FrmNovoMapa)().Count() > 0 Then

            FrmNovoMapa.PicSetores.Image = Nothing

            FrmNovoMapa.PintaSetores()

            FrmNovoMapa.Cursor = Cursors.Arrow

        End If

        Me.Close()

    End Sub

    Public IdCliente As Integer
    Public IdSetor As Integer

    Public Red As Integer = 0
    Public Blue As Integer = 255
    Public Green As Integer = 255

    Private Sub FrmNovoSetorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca ultima cor

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaSetor = From setor In LqTrabalhista.SetoresClientes
                         Where setor.IdCliente = IdCliente
                         Select setor.CorSetor, setor.IdSetorCliente
                         Order By IdSetorCliente Descending

        Dim Acrescentar As Integer = 101

        If IdSetor = 0 Then
            If BuscaSetor.Count = 0 Then

                Red += Acrescentar
                PnnCor.BackColor = Color.FromArgb(Red, Green, Blue)

            Else

                Dim Contexto As String = BuscaSetor.First.CorSetor

                Dim str As String = Contexto
                Dim separador As String = "."
                Dim palavras As String() = str.Split(separador)
                Dim LstPalavras As New ListBox
                Dim palavra As String

                For Each palavra In palavras
                    LstPalavras.Items.Add(palavra)
                Next

                Red = LstPalavras.Items(0).ToString
                Green = LstPalavras.Items(1).ToString
                Blue = LstPalavras.Items(2).ToString

                If Red < Green Then

                    Red += Acrescentar

                    If Red > 255 Then
                        Green = Red - 255
                        Red = 255
                    End If

                End If

                If Green < Blue Then

                    Green += Acrescentar

                    If Green > 255 Then
                        Blue = Green - 255
                        Green = 255
                    End If

                End If

                If Blue < Red Then

                    Blue += Acrescentar

                    If Blue > 255 Then
                        Red = Blue - 255
                        Blue = 255
                    End If

                End If

                Dim NovaCor As Color = Color.FromArgb(255, Red, Green, Blue)

                PnnCor.BackColor = NovaCor

            End If
        End If

        'busca funções

        Dim BuscaFuncoes = From func In LqTrabalhista.FuncoesClientes
                           Where func.IdCliente = IdCliente
                           Select func.IdFuncaoCliente, func.Descricao

        For Each it In BuscaFuncoes.ToList

            'verifica se existe na lista

            Dim BuscaLista = From lst In LqTrabalhista.FuncoesClientesSetores
                             Where lst.IdSetorCliente = IdSetor And lst.IdFuncao = it.IdFuncaoCliente
                             Select lst.IdFuncao

            If BuscaLista.Count = 0 Then
                DtFuncoesCliente.Rows.Add(it.IdFuncaoCliente, False, it.Descricao)
            Else
                DtFuncoesCliente.Rows.Add(it.IdFuncaoCliente, True, it.Descricao)
            End If

        Next

        Dim BuscaRiscos = From func In LqTrabalhista.Riscos
                          Where func.IdRisco Like "*"
                          Select func.IdRisco, func.Descricao

        For Each it In BuscaRiscos.ToList

            'verifica se existe na lista

            Dim BuscaLista = From lst In LqTrabalhista.RiscosSetores
                             Where lst.IdSetor = IdSetor And lst.IdRisco = it.IdRisco
                             Select lst.IdRiscoSetor

            If BuscaLista.Count = 0 Then
                DtRiscos.Rows.Add(it.IdRisco, False, it.Descricao)
            Else
                DtRiscos.Rows.Add(it.IdRisco, True, it.Descricao)
            End If

        Next
    End Sub

    Private Sub DtFuncoesCliente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFuncoesCliente.CellContentClick

        If DtFuncoesCliente.Columns(e.ColumnIndex).Name = "ClmCheckFuncao" Then

            If DtFuncoesCliente.Rows(e.RowIndex).Cells(1).Value = True Then
                DtFuncoesCliente.Rows(e.RowIndex).Cells(1).Value = False
            Else
                DtFuncoesCliente.Rows(e.RowIndex).Cells(1).Value = True
            End If

        End If

    End Sub

    Private Sub DtRiscos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtRiscos.CellContentClick

        If DtRiscos.Columns(e.ColumnIndex).Name = "ClmCheckRisco" Then

            If DtRiscos.Rows(e.RowIndex).Cells(1).Value = True Then
                DtRiscos.Rows(e.RowIndex).Cells(1).Value = False
            Else
                DtRiscos.Rows(e.RowIndex).Cells(1).Value = True
            End If

        End If

    End Sub
End Class