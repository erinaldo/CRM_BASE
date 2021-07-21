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
                SignXmlFile("Example.xml", "SignedExample.xml", Key)
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

        Public Shared Sub SignXmlFile(ByVal FileName As String, ByVal SignedFileName As String, ByVal Key As RSA)
            Dim doc As XmlDocument = New XmlDocument()
            doc.PreserveWhitespace = False
            doc.Load(New XmlTextReader(FileName))
            'trata dados DOC
            Dim signedXml As SignedXml = New SignedXml(doc)
            signedXml.SigningKey = Key
            Dim reference As Reference = New Reference()
            reference.Uri = ""
            Dim env As XmlDsigEnvelopedSignatureTransform = New XmlDsigEnvelopedSignatureTransform()
            reference.AddTransform(env)
            signedXml.AddReference(reference)
            Dim keyInfo As KeyInfo = New KeyInfo()
            keyInfo.AddClause(New RSAKeyValue(CType(Key, RSA)))
            signedXml.KeyInfo = keyInfo
            signedXml.ComputeSignature()
            Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, True))

            If TypeOf doc.FirstChild Is XmlDeclaration Then
                doc.RemoveChild(doc.FirstChild)
            End If

            Dim xmltw As XmlTextWriter = New XmlTextWriter(SignedFileName, New UTF8Encoding(False))
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


