Public Class FrmNovoMapa

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor

        FrmAcessoriaTrabalhista.CarregaInicio()

        Me.Cursor = Cursors.Arrow

        Me.Close()

    End Sub

    Private Sub TxtCPF_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCPF.MaskInputRejected

    End Sub

    Dim LstNome As New ListBox
    Dim LstIdSetores As New ListBox
    Dim LstEsq As New ListBox
    Dim LstDown As New ListBox

    Dim IdCliente As Integer

    Public Sub PintaSetores()

        N0Sel = False
        PicSetores.Image = Nothing
        LstNome.Items.Clear()
        LstIdSetores.Items.Clear()
        LstEsq.Items.Clear()
        LstDown.Items.Clear()

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim CNPJ As String = TxtCPF.Text.ToCharArray(0, 2) & "." & TxtCPF.Text.ToCharArray(2, 3) & "." & TxtCPF.Text.ToCharArray(5, 3) & "/" & TxtCPF.Text.ToCharArray(8, 4) & "-" & TxtCPF.Text.ToCharArray(12, 2)

        Dim BuscaCLienteCNPJ = From doc In LqBase.Clientes
                               Where doc.CPF_CNPJ Like CNPJ
                               Select doc.IdCliente, doc.RazaoSocial_nome, doc.Apelido, doc.Telefone, doc.Celular, doc.Email

        If BuscaCLienteCNPJ.Count > 0 Then

            BttSetores.Enabled = True
            BttFunções.Enabled = True

            IdCliente = BuscaCLienteCNPJ.First.IdCliente
            LblNomeCompleto.Text = BuscaCLienteCNPJ.First.RazaoSocial_nome
            LblApelido.Text = BuscaCLienteCNPJ.First.Apelido

            LblTelefone.Text = BuscaCLienteCNPJ.First.Telefone
            LblCelular.Text = BuscaCLienteCNPJ.First.Celular
            LblEmail.Text = BuscaCLienteCNPJ.First.Email

            'pinta os setores no mapa abaixo

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim BuscaSetores = From _set In LqTrabalhista.SetoresClientes
                               Where _set.IdCliente = BuscaCLienteCNPJ.First.IdCliente
                               Select _set.NomeSetor, _set.CorSetor, _set.IdSetorCliente

            Dim H As Integer = 921
            Dim V As Integer = (140) * BuscaSetores.Count

            Dim PintarBitmap = New Bitmap(H, V)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Dim Esq As Integer = 1
            Dim Down As Integer = 1

            LstIdSetores.Items.Clear()
            LstDown.Items.Clear()
            LstIdSetores.Items.Clear()
            LstNome.Items.Clear()

            For Each row In BuscaSetores.ToList

                Me.Cursor = Cursors.AppStarting

                Dim str As String = row.CorSetor
                Dim separador As String = "."
                Dim palavras As String() = str.Split(separador)
                Dim LstPalavras As New ListBox
                Dim palavra As String

                For Each palavra In palavras
                    LstPalavras.Items.Add(palavra)
                Next

                Dim Red As Integer = LstPalavras.Items(0).ToString
                Dim Green As Integer = LstPalavras.Items(1).ToString
                Dim Blue As Integer = LstPalavras.Items(2).ToString

                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(255, Color.SlateGray)), Esq - 1, Down - 1, 302, 132)
                LstIdSetores.Items.Add(row.IdSetorCliente)
                LstEsq.Items.Add(Esq - 1)
                LstDown.Items.Add(Down - 1)
                LstNome.Items.Add(row.NomeSetor)

                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(255, Color.WhiteSmoke)), Esq, Down, 300, 130)

                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Red, Green, Blue)), Esq, Down + 34, 300, 89)

                'Pintura.FillRectangle(New SolidBrush(Color.FromArgb(255, Color.SlateGray)), Esq + 9, Down, 12, 130)

                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Red, Green, Blue)), Esq + 10, Down, 10, 130)

                'desenha informações do titulo

                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.SlateGray)), Esq, Down, 300, 20)

                Pintura.DrawString(row.NomeSetor, New Font("Calibri", 12), New SolidBrush(Color.WhiteSmoke), Esq + 30, Down + 1)

                'desenha indicadores
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.SlateGray)), Esq + 140, Down + 35, 150, 40)
                Pintura.DrawString("Riscos", New Font("Calibri", 12), New SolidBrush(Color.WhiteSmoke), Esq + 140, Down + 36)

                Dim BuscaRisco = From rsc In LqTrabalhista.RiscosSetores
                                 Where rsc.IdSetor = row.IdSetorCliente
                                 Select rsc.IdRisco

                Pintura.DrawString(BuscaRisco.Count, New Font("Calibri", 16), New SolidBrush(Color.WhiteSmoke), Esq + 140, Down + 36 + 16)

                Dim BuscaFuncao = From rsc In LqTrabalhista.FuncoesClientesSetores
                                  Where rsc.IdSetorCliente = row.IdSetorCliente
                                  Select rsc.IdFuncao

                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.SlateGray)), Esq + 140, Down + 80, 150, 40)
                Pintura.DrawString("Funções", New Font("Calibri", 12), New SolidBrush(Color.WhiteSmoke), Esq + 140, Down + 81)
                Pintura.DrawString(BuscaFuncao.Count, New Font("Calibri", 16), New SolidBrush(Color.WhiteSmoke), Esq + 140, Down + 81 + 16)

                Esq += 310

                If Esq > (310 * 3) Then

                    Esq = 0
                    Down += 140

                End If

                Me.Cursor = Cursors.WaitCursor

            Next

            PicSetores.BackgroundImage = PintarBitmap

        Else

            BttSetores.Enabled = False
            BttFunções.Enabled = False

            PicSetores.BackgroundImage = Nothing
            PicSetores.Image = Nothing

            LblNomeCompleto.Text = ""
            LblApelido.Text = ""

            LblTelefone.Text = ""
            LblCelular.Text = ""
            LblEmail.Text = ""

        End If

        Me.Cursor = Cursors.Arrow

    End Sub
    Private Sub TxtCPF_TextChanged(sender As Object, e As EventArgs) Handles TxtCPF.TextChanged

        If TxtCPF.Text.Length = 14 Then

            Me.Cursor = Cursors.WaitCursor

            PintaSetores()

            Me.Cursor = Cursors.Arrow

        Else

            BttSetores.Enabled = False
            BttFunções.Enabled = False

            PicSetores.BackgroundImage = Nothing
            PicSetores.Image = Nothing

            LblNomeCompleto.Text = ""
            LblApelido.Text = ""

            LblTelefone.Text = ""
            LblCelular.Text = ""
            LblEmail.Text = ""

        End If

    End Sub

    Private Sub PicSetores_Click(sender As Object, e As EventArgs) Handles PicSetores.Click

    End Sub

    Public N0Sel As Boolean = False
    Public XTr As Integer = 0
    Public YTr As Integer = 0

    Public IdSelcionado As Integer = 0


    Private Sub PicSetores_MouseClick(sender As Object, e As MouseEventArgs) Handles PicSetores.MouseClick

        'verifica a posiçao do mouse

        If N0Sel = False Then

            PicSetores.Image = Nothing
            IdSelcionado = -1
            XTr = 0
            YTr = 0

            For i As Integer = 0 To LstIdSetores.Items.Count - 1

                N0Sel = True

                Dim EsP As Integer = LstEsq.Items(i).ToString
                If EsP <= e.X And EsP + 300 >= e.X Then

                    Dim DP As Integer = LstDown.Items(i).ToString
                    If DP <= e.Y And DP + 130 >= e.Y Then

                        XTr = EsP
                        YTr = DP
                        IdSelcionado = LstIdSetores.Items(i).ToString

                        Dim H As Integer = 921
                        Dim V As Integer = (140) * LstIdSetores.Items.Count

                        Dim PintarBitmap = New Bitmap(H, V)

                        Dim Pintura = Graphics.FromImage(PintarBitmap)

                        Dim Es As Integer = LstEsq.Items(i).ToString
                        Dim D As Integer = LstDown.Items(i).ToString

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.DarkOrange)), Es, D, 300, 130)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), Es, D + 24, 300, 124)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.SlateGray)), Es, D, 300, 20)

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), Es, D + 30, 300, 25)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), Es, D + 62, 300, 25)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), Es, D + 94, 300, 25)

                        Pintura.DrawString(LstNome.Items(i).ToString, New Font("Calibri", 12), New SolidBrush(Color.WhiteSmoke), Es + 30, D + 1)

                        Pintura.DrawImage(My.Resources.Cancel_40972, Es + 30, D + 30, 25, 25)
                        Pintura.DrawString("Remover ou invalidar setor", New Font("Calibri", 12), New SolidBrush(Color.SlateGray), Es + 70, D + 32)

                        Pintura.DrawImage(My.Resources.DocumentEdit_40924, Es + 32, D + 62, 25, 25)
                        Pintura.DrawString("Editar índices", New Font("Calibri", 12), New SolidBrush(Color.SlateGray), Es + 70, D + 65)

                        Pintura.DrawImage(My.Resources.kisspng_computer_icons_clip_art_sbi_po_exam_evaluation_ico_fabsdrive_school_management_system_principal_da_5b66314b5b13d5_6202905015334239473731, Es + 32 - 5, D + 92, 32, 29)
                        Pintura.DrawString("Análisar", New Font("Calibri", 12), New SolidBrush(Color.SlateGray), Es + 70, D + 97)

                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkOrange), 1), Es, D, 300, 130)

                        PicSetores.Image = PintarBitmap

                    End If

                End If

            Next

        Else

            N0Sel = False

            For i As Integer = 0 To LstIdSetores.Items.Count - 1

                Dim EsP_0 As Integer = XTr
                If EsP_0 <= e.X And EsP_0 + 300 >= e.X Then

                    Dim DP_0 As Integer = YTr
                    If DP_0 <= e.Y And DP_0 + 130 >= e.Y Then
                        N0Sel = True
                    End If

                End If

            Next

            If N0Sel = False Then

                PicSetores.Image = Nothing

            End If

            Dim Valido As Boolean = False

            Dim EsP As Integer = XTr

            If N0Sel = True Then
                If EsP <= e.X And EsP + 300 >= e.X Then

                    Dim DP As Integer = YTr
                    If DP + 30 <= e.Y And DP + 55 >= e.Y Then

                        Valido = True

                        If MsgBox("Tem certeza que deseja remover este cliente, lembre-se, se ele possuir histórico de atividade no sistema, o mesmo não poderá ser removido." & Chr(13) & "Deseja realmente prosseguir?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                            'remove da lista

                            Dim LqTrabalhista As New LqTrabalhistaDataContext
                            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

                            LqTrabalhista.DeletaSetorCliente(IdSelcionado)
                            'traz informaçoes novas

                            PicSetores.Image = Nothing

                            PintaSetores()

                            Me.Cursor = Cursors.Arrow

                        End If

                    ElseIf DP + 62 <= e.Y And DP + 62 + 25 >= e.Y Then

                        Valido = True

                        Me.Cursor = Cursors.WaitCursor

                        FrmNovoSetorCliente.IdCliente = IdCliente
                        FrmNovoSetorCliente.IdSetor = IdSelcionado

                        'carrega informações do cliente

                        Dim LqTrabalhista As New LqTrabalhistaDataContext
                        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

                        Dim IdSetor As Integer = IdSelcionado

                        Dim ConsultaBase = From bas In LqTrabalhista.SetoresClientes
                                           Where bas.IdCliente = IdCliente And bas.IdSetorCliente = IdSetor
                                           Select bas.NomeSetor, bas.CorSetor

                        FrmNovoSetorCliente.TxtNomeSetor.Text = ConsultaBase.First.NomeSetor

                        'abre o form

                        FrmNovoSetorCliente.IdCliente = IdCliente
                        FrmNovoSetorCliente.IdSetor = IdSetor

                        Dim Contexto As String = ConsultaBase.First.CorSetor

                        Dim str As String = Contexto
                        Dim separador As String = "."
                        Dim palavras As String() = str.Split(separador)
                        Dim LstPalavras As New ListBox
                        Dim palavra As String

                        For Each palavra In palavras
                            LstPalavras.Items.Add(palavra)
                        Next

                        Dim Red As Integer = LstPalavras.Items(0).ToString
                        Dim Green As Integer = LstPalavras.Items(1).ToString
                        Dim Blue As Integer = LstPalavras.Items(2).ToString

                        FrmNovoSetorCliente.Red = Red
                        FrmNovoSetorCliente.Green = Green
                        FrmNovoSetorCliente.Blue = Blue

                        FrmNovoSetorCliente.PnnCor.BackColor = Color.FromArgb(255, Red, Green, Blue)
                        FrmNovoSetorCliente.Show(Me)

                        Me.Cursor = Cursors.Arrow

                    ElseIf DP + 94 <= e.Y And DP + 94 + 29 >= e.Y Then

                        Me.Cursor = Cursors.WaitCursor

                        FrmAnaliseAcessoria.IdSetor = IdSelcionado

                        FrmAnaliseAcessoria.Show(Me)

                        Me.Cursor = Cursors.Arrow

                    End If

                End If
            End If

        End If

    End Sub

    Private Sub BttSetores_Click(sender As Object, e As EventArgs) Handles BttSetores.Click

        Me.Cursor = Cursors.WaitCursor

        FrmNovoSetorCliente.IdCliente = IdCliente
        FrmNovoSetorCliente.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BttFunções_Click(sender As Object, e As EventArgs) Handles BttFunções.Click

        Me.Cursor = Cursors.WaitCursor

        FrmNovaFuncaoCliente.IdCliente = IdCliente
        FrmNovaFuncaoCliente.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub TxtCPF_Click(sender As Object, e As EventArgs) Handles TxtCPF.Click

        If TxtCPF.Text <> "" Then

            Dim Valor As Integer = TxtCPF.Text.Length
            TxtCPF.SelectionStart = Valor

        Else

            TxtCPF.SelectionStart = 0

        End If

    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click

    End Sub
End Class