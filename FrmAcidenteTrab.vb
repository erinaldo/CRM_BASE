Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml

Public Class FrmAcidenteTrab

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub


    Public Sub EmiteDocumento(ByVal Evento As String)

        'monta arquivo xml

        Dim Persona As String = "2 - CPF"
        Dim PersonaSel As Integer = 2

        If LstDoc.Items(CmbColaboradores.SelectedIndex).ToString.Length = 11 Then
            Persona = "2 - CPF"
            PersonaSel = 2
        Else
            Persona = "1 - CNPJ"
            PersonaSel = 1
        End If

        Dim Doc As String

        If PersonaSel = 2 Then

            Doc = "000" & LstDoc.Items(CmbColaboradores.SelectedIndex).ToString

        Else

            'verifica os inicios

            Dim Valid As String = LstDoc.Items(CmbColaboradores.SelectedIndex).ToString

            If Valid.StartsWith("1015") Or Valid.StartsWith("1040") Or Valid.StartsWith("1074") Or Valid.StartsWith("1163") Then

                Doc = LstDoc.Items(CmbColaboradores.SelectedIndex).ToString

            ElseIf Not Valid.StartsWith("1015") And Not Valid.StartsWith("1040") And Not Valid.StartsWith("1074") And Not Valid.StartsWith("1163") Then

                Doc = "000" & LstDoc.Items(CmbColaboradores.SelectedIndex).ToString.ToCharArray(0, 8)

            End If

        End If

        Dim Mes As Integer = Today.Month

        If Mes.ToString.Length = 1 Then

            Mes = "0" & Mes

        End If

        Dim Dia As Integer = Today.Day

        If Dia.ToString.Length = 1 Then

            Dia = "0" & Dia

        End If

        Dim Hora As Integer = Now.Hour

        If Hora.ToString.Length = 1 Then

            Hora = "0" & Hora

        End If

        Dim Minuto As Integer = Now.Minute

        If Minuto.ToString.Length = 1 Then

            Minuto = "0" & Minuto

        End If

        Dim Segundo As Integer = Now.Second

        If Segundo.ToString.Length = 1 Then

            Segundo = "0" & Segundo

        End If

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim IdSocial As String = LqTrabalhista.ESocial.ToList.Last.IdESocial

        If IdSocial.ToString.Length = 1 Then

            IdSocial = "0000" & IdSocial

        ElseIf IdSocial.ToString.Length = 2 Then

            IdSocial = "000" & IdSocial

        ElseIf IdSocial.ToString.Length = 3 Then

            IdSocial = "00" & IdSocial

        ElseIf IdSocial.ToString.Length = 4 Then

            IdSocial = "0" & IdSocial

        End If


        Dim Identificacao As String = "ID" & PersonaSel & Doc & Today.Year & Mes & Dia & Hora & Minuto & Segundo & IdSocial

        'cria documento xml
        Dim writer As New XmlTextWriter("C:\Iara\ESocial\" & Identificacao & ".xml", Encoding.UTF8)

        'replace 
        ''> (sinal de maior) &gt; 
        ''< (sinal de menor) &lt; 
        ''& (e comercial) &amp;
        ''> (sinal de maior) &gt; 
        ''< (sinal de menor) &lt; 
        ''& (e comercial) &amp;

        'inicia o documento xml

        writer.WriteStartDocument()

        'escreve o elmento raiz

        writer.WriteStartElement("eSocial", "http://www.esocial.gov.br/schema/evt/evt" & Evento & "/v1_0_0")

        writer.WriteStartElement("evt" & Evento)

        writer.WriteElementString("Id", Evento)
        writer.WriteElementString("versao", "1.0")

        writer.WriteStartElement("ideEvento")

        writer.WriteElementString("tpAmb", "8")
        writer.WriteElementString("procEmi", "1")
        writer.WriteElementString("verProc", "1.0.0")

        writer.WriteEndElement()

        writer.WriteStartElement("ideEmpregador")


        writer.WriteElementString("tpInsc", Persona)
        writer.WriteElementString("nrInsc", Doc)

        writer.WriteEndElement()

        writer.WriteStartElement("infoXXX")

        writer.WriteEndElement()

        writer.WriteElementString("Signature", Identificacao)

        writer.WriteEndElement()

        'Escreve o XML para o arquivo e fecha o objeto escritor

        writer.Close()

        'assina o xml

        'selecionar certificado

        SelecionarCertificado("C:\Iara\ESocial\" & Identificacao & ".xml", Identificacao)

    End Sub
    Dim ObjCertificadoX509 As New X509Certificate2
    Dim GetCerificateX509 As New X509Store("MY", StoreLocation.CurrentUser)
    Dim objColecaoCertificadosX509 As New X509Certificate2Collection

    Private Sub AssinarDocumentoXML(ByVal ArqXmlAssinar As String, ByVal TagXml As String, ByVal StrSercialCertifiado As String, ByVal StrIdentificacao As String)

        'Try

        'assina com o certificado selecionados

        ObjCertificadoX509 = objColecaoCertificadosX509.Item(0)

        Dim DocXML As New XmlDocument()

        DocXML.PreserveWhitespace = False
        DocXML.Load(ArqXmlAssinar)

        Dim signedXml As New Xml.SignedXml(DocXML)

        signedXml.SigningKey = ObjCertificadoX509.PrivateKey

        Dim Referencia As New Xml.Reference()
        Referencia.Uri = TagXml

        Dim env As New XmlDsigEnvelopedSignatureTransform

        Referencia.AddTransform(env)

        Dim c14 As New XmlDsigC14NTransform

        Referencia.AddTransform(c14)

        signedXml.AddReference(Referencia)

        Dim KeyInfo As New KeyInfo

        KeyInfo.AddClause(New KeyInfoX509Data(ObjCertificadoX509))

        signedXml.KeyInfo = KeyInfo

        Try

            signedXml.ComputeSignature()

            Dim XmlDigitalSignature As XmlElement
            XmlDigitalSignature = signedXml.GetXml()

            DocXML.DocumentElement.AppendChild(DocXML.ImportNode(XmlDigitalSignature, True))

            Dim EscreverXML As New StreamWriter(ArqXmlAssinar)
            EscreverXML.Write(DocXML.OuterXml)
            EscreverXML.Close()

            If DocXML.GetElementsByTagName(TagXml).Count = 1 Then
                'MsgBox("Existe")
            End If
            'fecha o form

            FrmColaboradoresClientes.CarregaInicio()

            Process.Start("C:\Iara\ESocial\" & StrIdentificacao & ".xml")

            Me.Close()

        Catch ex As Exception

            MsgBox("Certificado não suportado!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro de certificado")
            Process.Start("C:\Iara\ESocial\" & StrIdentificacao & ".xml")

        End Try


        'Catch ex As Exception

        '    MsgBox(ex.Message)

        'End Try

    End Sub

    Private Sub SelecionarCertificado(ByVal ArqXmlAssinar As String, ByVal StrIdentificacao As String)

        'Try

        GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        objColecaoCertificadosX509 = X509Certificate2UI.SelectFromCollection(GetCerificateX509.Certificates,
"Certificado(s) dísponível(is)", "Selecione o certificado.", X509SelectionFlag.SingleSelection)

        If objColecaoCertificadosX509.Count > 0 Then

            AssinarDocumentoXML(ArqXmlAssinar, "Signature", objColecaoCertificadosX509.Item(0).SerialNumber.ToString, StrIdentificacao)

        End If

        'Catch ex As Exception

        '    MsgBox(ex.Message)

        'End Try

    End Sub

    Dim LstDoc As New ListBox
    Dim LstIdCliente As New ListBox

    Private Sub FrmAcidenteTrab_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca todos os clientes

        Dim Lqtrabalhista As New LqTrabalhistaDataContext
        Lqtrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista
        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaClientes = From cli In LqBase.Clientes
                            Where cli.IdCliente Like "*"
                            Select cli.CPF_CNPJ, cli.RazaoSocial_nome, cli.IdCliente

        For Each row In BuscaClientes.ToList

            CmbClientes.Items.Add("CPF/CNPJ: " & row.CPF_CNPJ & " - Nome/Razão Social: " & row.RazaoSocial_nome)
            LstIdCliente.Items.Add(row.IdCliente)

        Next

    End Sub

    Dim LstDocColaborador As New ListBox
    Dim LstIdColaborador As New ListBox

    Private Sub CmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbClientes.SelectedIndexChanged

        'busca colaboradores

        'busca todos os clientes

        Dim Lqtrabalhista As New LqTrabalhistaDataContext
        Lqtrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaClientes = From cli In Lqtrabalhista.ColaboradoresCliente
                            Where cli.IdCliente = LstIdCliente.Items(CmbClientes.SelectedIndex).ToString
                            Select cli.DocColaborador, cli.NomeColaborador, cli.IdColaboradorCliente

        CmbColaboradores.Items.Clear()
        LstIdColaborador.Items.Clear()

        For Each row In BuscaClientes.ToList

            CmbColaboradores.Items.Add("CPF/CNPJ: " & row.DocColaborador & " - Nome/Razão Social: " & row.NomeColaborador)
            LstIdColaborador.Items.Add(row.IdColaboradorCliente)

        Next

    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click

    End Sub
End Class