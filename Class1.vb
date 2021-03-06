Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml
Imports System.ServiceModel
Imports System.Text
Imports System.Xml
Imports CRM_BASE.WebReference

Namespace SignVerify

    Public Class SignVerifyEnvelope
        Public Shared Sub Main(ByVal args As String())
            Try
                Dim Key As RSA = RSA.Create()
                CreateSomeXml("Example.xml")
                Console.WriteLine("New XML file created.")
                Dim X509 As X509Certificate

                'SignXmlFile("Example.xml", "SignedExample.xml", Key, X509, "")
                Console.WriteLine("XML file signed.")
                Console.WriteLine("Verifying signature...")
                Dim result As Boolean = VerifyXmlFile("SignedExample.xml")

                If result Then
                    Console.WriteLine("The XML signature is valid.")
                Else
                    Console.WriteLine("The XML signature is not valid.")
                End If

            Catch e As CryptographicException
                Console.WriteLine(e.Message)
            End Try
        End Sub

        Public Shared Sub SignXmlFile(ByVal FileName As String, ByVal SignedFileName As String, ByVal KeyX509 As X509Certificate2, ByVal ID As String, ByVal QuemAciona As String)
            Dim doc As XmlDocument = New XmlDocument()
            doc.PreserveWhitespace = False
            doc.Load(New XmlTextReader(FileName))
            'trata dados DOC
            Dim signedXml As SignedXml = New SignedXml(doc)
            signedXml.SigningKey = KeyX509.GetRSAPrivateKey
            'Dim _ID As String = doc.DocumentElement.Attributes.GetNamedItem("Id").InnerText
            'signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA256Url

            Dim reference As Reference = New Reference()
            reference.Uri = ""
            Dim env As XmlDsigEnvelopedSignatureTransform = New XmlDsigEnvelopedSignatureTransform()
            reference.AddTransform(env)
            'signedXml.AddReference(reference)
            Dim cn14 As XmlDsigC14NTransform = New XmlDsigC14NTransform
            reference.AddTransform(cn14)
            'reference.DigestMethod = SignedXml.XmlDsigRSASHA256Url
            signedXml.AddReference(reference)

            Dim keyInfo As KeyInfo = New KeyInfo()
            signedXml.KeyInfo.AddClause(New KeyInfoX509Data(KeyX509))
            'signedXml.KeyInfo = keyInfo

            signedXml.ComputeSignature()

            Dim xmlSignature As XmlElement = doc.CreateElement("Signature", "http://www.w3.org/2000/09/xmldsig#")
            Dim xmlSignedInfo As XmlElement = signedXml.SignedInfo.GetXml()
            Dim xmlKeyInfo As XmlElement = signedXml.KeyInfo.GetXml()
            Dim xmlSignatureValue As XmlElement = doc.CreateElement("SignatureValue", xmlSignature.NamespaceURI)
            Dim signBase64 As String = Convert.ToBase64String(signedXml.Signature.SignatureValue)
            Dim text As XmlText = doc.CreateTextNode(signBase64)
            xmlSignatureValue.AppendChild(text)
            xmlSignature.AppendChild(doc.ImportNode(xmlSignedInfo, True))
            xmlSignature.AppendChild(xmlSignatureValue)
            xmlSignature.AppendChild(doc.ImportNode(xmlKeyInfo, True))

            'verifica quem acionou o evento

            If QuemAciona = "S2210" Then
                Dim evento = doc.GetElementsByTagName("eSocial", "http://www.esocial.gov.br/schema/evt/evtCAT/v_S_01_00_00")
                evento(0).AppendChild(xmlSignature)
            ElseIf QuemAciona = "S2220" Then
                Dim evento = doc.GetElementsByTagName("eSocial", "http://www.esocial.gov.br/schema/evt/evtMonit/v_S_01_00_00")
                evento(0).AppendChild(xmlSignature)
            End If

            doc.RemoveChild(doc.FirstChild)

            'verifica se assinatura é valida no xsd

            Dim xmltw As XmlTextWriter = New XmlTextWriter(SignedFileName, New UTF8Encoding(True))
            doc.WriteTo(xmltw)
            xmltw.Close()

        End Sub

        Public Shared Function VerifyXmlFile(ByVal Name As String) As Boolean
            Dim xmlDocument As XmlDocument = New XmlDocument()
            xmlDocument.PreserveWhitespace = True
            xmlDocument.Load(Name)
            Dim signedXml As SignedXml = New SignedXml(xmlDocument)
            Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")
            signedXml.LoadXml(CType(nodeList(0), XmlElement))
            Return signedXml.CheckSignature()
        End Function

        Public Shared Sub CreateSomeXml(ByVal FileName As String)
            Dim document As XmlDocument = New XmlDocument()
            Dim node As XmlNode = document.CreateNode(XmlNodeType.Element, "", "MyElement", "samples")
            node.InnerText = "Example text to be signed."
            document.AppendChild(node)
            Dim xmltw As XmlTextWriter = New XmlTextWriter(FileName, New UTF8Encoding(False))
            document.WriteTo(xmltw)
            xmltw.Close()
        End Sub

    End Class

End Namespace


