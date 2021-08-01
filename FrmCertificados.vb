Imports System.Security.Cryptography.X509Certificates

Public Class FrmCertificados
    Private Sub FrmCertificados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LblCNPJEmitente.Text = FrmPrincipal.CNPJ
        LblRazaoSocial.Text = FrmPrincipal.RazaoSocial
        LblTelefone.Text = FrmPrincipal.Telefone
        LblEmail.Text = FrmPrincipal.Email

        'busca dados salvo do serial

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaCertificado = From cert In LqBase.BASE_CERTIFICADO
                               Where cert.SERIAL_CERT Like "*"
                               Select cert.RAZAO, cert.SERIAL_CERT

        If BuscaCertificado.Count > 0 Then

            'lista todos os certificados e compara com o numero serial

            GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

            For Each item In GetCerificateX509.Certificates

                If item.SerialNumber = (BuscaCertificado.First.SERIAL_CERT) Then

                    LblSerialNumber.Text = BuscaCertificado.First.SERIAL_CERT

                    Me.Cursor = Cursors.WaitCursor

                    Dim Subject As String = item.Subject

                    'retorna informações do certificado, ira vincular a chave no banco
                    'le informações do subject

                    Dim separador As String = ","
                    Dim palavras As String() = Subject.Split(separador)
                    Dim LstPalavras As New ListBox
                    Dim palavra As String

                    For Each palavra In palavras
                        LstPalavras.Items.Add(palavra)
                        If palavra.StartsWith("CN") Then
                            'separa tag CN por espaço em branco
                            Dim separador_CN As String = " "
                            Dim palavras_CN As String() = palavra.Split(separador_CN)
                            Dim palavra_CN As String

                            For Each palavra_CN In palavras_CN

                                If Not palavra_CN.Contains(":") Then
                                    LblNomeTitular.Text &= palavra_CN & " "
                                Else
                                    'separa documentos
                                    Dim separador_DOC As String = ":"
                                    Dim palavras_DOC As String() = palavra_CN.Split(separador_DOC)
                                    Dim palavra_DOC As String
                                    Dim LstDOCS As New ListBox

                                    For Each palavra_DOC In palavras_DOC
                                        LstDOCS.Items.Add(palavra_DOC)
                                    Next

                                    LblCPF.Text = LstDOCS.Items(0).ToString
                                    LblCNPJ.Text = LstDOCS.Items(1).ToString

                                End If

                            Next

                        Else

                            If palavra.Contains("OU=RFB") Then
                                LblTipoCErt.Text = palavra
                            End If
                            If palavra.Contains("O=") Then
                                LblCertificador.Text = palavra
                            End If
                        End If

                    Next

                    LblNomeTitular.Text = LblNomeTitular.Text.Remove(0, 4)
                    Dim TipoCert As String = LblTipoCErt.Text '.Remove(0, 5)


                    If LblCertificador.Text.Contains("ICP-Brasil") Then

                        LblTipoCErt.Text = TipoCert.Remove(0, 8)
                        LblCertificador.Text = LblCertificador.Text.Remove(0, 3)
                        'LblSerialNumber.Text = objColecaoCertificadosX509.Item(0).SerialNumber

                    Else

                        MsgBox("Este certificado não é um certificado ICP-Brasil válido.", vbOKOnly)

                        LblNomeTitular.Text = ""
                        LblTipoCErt.Text = ""
                        LblCertificador.Text = ""
                        LblSerialNumber.Text = ""
                        LblCPF.Text = ""
                        LblCNPJ.Text = ""

                    End If

                    Me.Cursor = Cursors.Arrow

                End If

            Next

        End If

    End Sub

    Dim ObjCertificadoX509 As New X509Certificate2
    Dim GetCerificateX509 As New X509Store("MY", StoreLocation.CurrentUser)
    Dim objColecaoCertificadosX509 As New X509Certificate2Collection

    Private Sub BttProcurarCertificado_Click(sender As Object, e As EventArgs) Handles BttProcurarCertificado.Click

        Me.Cursor = Cursors.AppStarting

        GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        objColecaoCertificadosX509 = X509Certificate2UI.SelectFromCollection(GetCerificateX509.Certificates,
"Certificado(s) dísponível(is)", "Selecione o certificado.", X509SelectionFlag.SingleSelection)

        LblNomeTitular.Text = ""

        If objColecaoCertificadosX509.Count > 0 Then

            Me.Cursor = Cursors.WaitCursor

            Dim Subject As String = objColecaoCertificadosX509.Item(0).Subject

            'retorna informações do certificado, ira vincular a chave no banco
            'le informações do subject

            Dim separador As String = ","
            Dim palavras As String() = Subject.Split(separador)
            Dim LstPalavras As New ListBox
            Dim palavra As String

            For Each palavra In palavras
                LstPalavras.Items.Add(palavra)
                If palavra.StartsWith("CN") Then
                    'separa tag CN por espaço em branco
                    Dim separador_CN As String = " "
                    Dim palavras_CN As String() = palavra.Split(separador_CN)
                    Dim palavra_CN As String

                    For Each palavra_CN In palavras_CN

                        If Not palavra_CN.Contains(":") Then
                            LblNomeTitular.Text &= palavra_CN & " "
                        Else
                            'separa documentos
                            Dim separador_DOC As String = ":"
                            Dim palavras_DOC As String() = palavra_CN.Split(separador_DOC)
                            Dim palavra_DOC As String
                            Dim LstDOCS As New ListBox

                            For Each palavra_DOC In palavras_DOC
                                LstDOCS.Items.Add(palavra_DOC)
                            Next

                            LblCPF.Text = LstDOCS.Items(0).ToString
                            LblCNPJ.Text = LstDOCS.Items(1).ToString

                        End If

                    Next

                Else

                    If palavra.Contains("OU=RFB") Then
                        LblTipoCErt.Text = palavra
                    End If
                    If palavra.Contains("O=") Then
                        LblCertificador.Text = palavra
                    End If
                End If

            Next

            LblNomeTitular.Text = LblNomeTitular.Text.Remove(0, 3)
            Dim TipoCert As String = LblTipoCErt.Text '.Remove(0, 5)


            If LblCertificador.Text.Contains("ICP-Brasil") Then

                LblTipoCErt.Text = TipoCert.Remove(0, 8)
                LblCertificador.Text = LblCertificador.Text.Remove(0, 3)
                LblSerialNumber.Text = objColecaoCertificadosX509.Item(0).SerialNumber

            Else

                MsgBox("Este certificado não é um certificado ICP-Brasil válido.", vbOKOnly)

                LblNomeTitular.Text = ""
                LblTipoCErt.Text = ""
                LblCertificador.Text = ""
                LblSerialNumber.Text = ""
                LblCPF.Text = ""
                LblCNPJ.Text = ""

            End If

            Me.Cursor = Cursors.Arrow

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click

        Me.Cursor = Cursors.WaitCursor

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        LqBase.insereSerialNumberCertificado(0, FrmPrincipal.CNPJ.Replace(".", "").Replace("-", "").Replace("/", ""), FrmPrincipal.RazaoSocial, LblSerialNumber.Text)

        'atualiza chave no banco

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

End Class