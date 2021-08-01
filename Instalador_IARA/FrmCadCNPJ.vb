Public Class FrmCadCNPJ
    Private Sub TxtIp_TextChanged(sender As Object, e As EventArgs) Handles TxtRazaoSocial.TextChanged

        If TxtRazaoSocial.Text <> "" Then

            TxtNomeFantasia.Enabled = True

        Else

            TxtNomeFantasia.Enabled = False
            TxtNomeFantasia.Text = ""

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MsgBox("Não será possível iniciar o sistema sem uma chave de licensa, deseja realmente sair?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            End

        End If

    End Sub

    Private Sub TxtNomeFantasia_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeFantasia.TextChanged

        If TxtNomeFantasia.Text <> "" Then

            BttSolicitar.Enabled = True

        Else

            TxtNomeFantasia.Enabled = False
            TxtNomeFantasia.Text = ""

        End If

    End Sub

    Private Sub PnnInferior_Paint(sender As Object, e As PaintEventArgs) Handles PnnInferior.Paint

    End Sub

    Public _Cnpj As String

    Private Sub BttSolicitar_Click(sender As Object, e As EventArgs) Handles BttSolicitar.Click

        'busca licensas no banco da iara

        Dim ConecctionServer As String = "Data Source=191.13.16.201\SQLEXPRESS, 14333;Initial Catalog= IARA;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

        Dim LqIara As New LqIaraDataContext

        LqIara.Connection.ConnectionString = ConecctionServer

        LqIara.InsereNovoClienteIara(TxtRazaoSocial.Text, False, _Cnpj, 0, TxtEndereco.Text, TxtBairro.Text, TxtCidade.Text, TxtEstado.Text, TxtPais.Text, TxtCep.Text, TxtCelular.Text, TxtCelular.Text, ChWhatts.CheckState, TxtNome.Text, TxtCelular.Text, TxtEmail.Text)

        Dim BuscaCnpj = From cnpj In LqIara.ClientesJv
                        Where cnpj.DOCJv Like _Cnpj
                        Select cnpj.IdClienteJv, cnpj.NomeCompletoJv

        If BuscaCnpj.Count > 0 Then

            'Busca chave

            Dim LstLetras As New ListBox

            LstLetras.Items.Add("A0")
            LstLetras.Items.Add("B0")
            LstLetras.Items.Add("C0")
            LstLetras.Items.Add("D0")
            LstLetras.Items.Add("E0")
            LstLetras.Items.Add("F0")
            LstLetras.Items.Add("G0")
            LstLetras.Items.Add("H0")
            LstLetras.Items.Add("I0")
            LstLetras.Items.Add("J0")

            LstLetras.Items.Add("1A")
            LstLetras.Items.Add("1B")
            LstLetras.Items.Add("1C")
            LstLetras.Items.Add("1D")
            LstLetras.Items.Add("1E")
            LstLetras.Items.Add("1F")
            LstLetras.Items.Add("1G")
            LstLetras.Items.Add("1H")
            LstLetras.Items.Add("1I")
            LstLetras.Items.Add("1J")

            LstLetras.Items.Add("A2")
            LstLetras.Items.Add("B2")
            LstLetras.Items.Add("C2")
            LstLetras.Items.Add("D2")
            LstLetras.Items.Add("E2")
            LstLetras.Items.Add("F2")
            LstLetras.Items.Add("G2")
            LstLetras.Items.Add("H2")
            LstLetras.Items.Add("I2")
            LstLetras.Items.Add("J2")

            LstLetras.Items.Add("3A")
            LstLetras.Items.Add("3B")
            LstLetras.Items.Add("3C")
            LstLetras.Items.Add("3D")
            LstLetras.Items.Add("3E")
            LstLetras.Items.Add("3F")
            LstLetras.Items.Add("3G")
            LstLetras.Items.Add("3H")
            LstLetras.Items.Add("3I")
            LstLetras.Items.Add("3J")

            LstLetras.Items.Add("A4")
            LstLetras.Items.Add("B4")
            LstLetras.Items.Add("C4")
            LstLetras.Items.Add("D4")
            LstLetras.Items.Add("E4")
            LstLetras.Items.Add("F4")
            LstLetras.Items.Add("G4")
            LstLetras.Items.Add("H4")
            LstLetras.Items.Add("I4")
            LstLetras.Items.Add("J4")

            LstLetras.Items.Add("5A")
            LstLetras.Items.Add("5B")
            LstLetras.Items.Add("5C")
            LstLetras.Items.Add("5D")
            LstLetras.Items.Add("5E")
            LstLetras.Items.Add("5F")
            LstLetras.Items.Add("5G")
            LstLetras.Items.Add("5H")
            LstLetras.Items.Add("5I")
            LstLetras.Items.Add("5J")

            Dim _Chave As String = LstLetras.Items(Today.Date.Day).ToString & LstLetras.Items(Now.TimeOfDay.Seconds).ToString & LstLetras.Items(Val(Today.Year.ToString.ToCharArray(2, 2))).ToString & LstLetras.Items(Now.Minute).ToString & LstLetras.Items(Today.Month).ToString & LstLetras.Items(Now.Hour).ToString

            LqIara.InsereNovaChaveIara(BuscaCnpj.First.IdClienteJv, 0, _Chave, 90, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, "", True)

            Form1.LblChave.Text = _Chave


            Dim BuscaChave = From chave In LqIara.ChavesIara
                             Where chave.IdClienteIara = BuscaCnpj.First.IdClienteJv
                             Select chave.NumeroDaChaveIara, chave.ValidadeDiasIara, chave.DataAtivacaoIara, chave.DataLiberacaoIara, chave.IdChaveIara


            Form1._idCliente = BuscaCnpj.First.IdClienteJv
            Form1._idChave = BuscaChave.First.IdChaveIara

            Form1.LblChave.Text = BuscaChave.First.NumeroDaChaveIara
            Form1.LblTelefone.Text = BuscaChave.First.ValidadeDiasIara

            Form1.LblRazaoSocial.Text = BuscaCnpj.First.NomeCompletoJv

            If BuscaChave.First.DataAtivacaoIara <> "1111-11-11" Then
                Dim InicioContagem As Date = BuscaChave.First.DataAtivacaoIara

                Form1.LblEmail.Text = FormatDateTime(BuscaChave.First.DataAtivacaoIara.Value.AddDays(BuscaChave.First.ValidadeDiasIara), DateFormat.ShortDate)

            Else

                Form1.LblEmail.Text = "Ferramenta não ativada."

            End If

            'busca valor de licensa

            Dim BuscaProduto = From prod In LqIara.ProdutosJV
                               Where prod.IdProdutoJV Like "*"
                               Select prod.DescricaoJV, prod.Modulo, prod.VlrDesk, prod.VlrMobile, prod.IdProdutoJV

            For Each row In BuscaProduto.ToList

                If row.Modulo = "Estoque" Then

                    Form1.LblVlrUnitDeskEst.Text = FormatCurrency(row.VlrDesk, NumDigitsAfterDecimal:=2)
                    Form1.LblVlrUnitMobEst.Text = FormatCurrency(row.VlrMobile, NumDigitsAfterDecimal:=2)

                ElseIf row.Modulo = "Oficina" Then

                    Form1.LblVlrUnitDeskOfi.Text = FormatCurrency(row.VlrDesk, NumDigitsAfterDecimal:=2)
                    Form1.LblVlrUnitMobOfi.Text = FormatCurrency(row.VlrMobile, NumDigitsAfterDecimal:=2)

                End If

            Next

            Me.Close()

        End If


    End Sub
End Class