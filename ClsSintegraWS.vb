Public Class ClsSintegraWS
    Public Class CnaePrincipal
        Public Property Code As String
        Public Property Text As String
    End Class

    Public Class Ibge
        Public Property Codigo_municipio As String
        Public Property Codigo_uf As String
    End Class

    Public Class Root
        Public Property Code As String
        Public Property Status As String
        Public Property Message As String
        Public Property Nome_empresarial As String
        Public Property Cnpj As String
        Public Property Inscricao_estadual As String
        Public Property Tipo_inscricao As String
        Public Property Data_situacao_cadastral As String
        Public Property Situacao_cnpj As String
        Public Property Situacao_ie As String
        Public Property Nome_fantasia As String
        Public Property Data_inicio_atividade As String
        Public Property Regime_tributacao As String
        Public Property Informacao_ie_como_destinatario As String
        Public Property Porte_empresa As String
        Public Property Cnae_principal As CnaePrincipal
        Public Property Data_fim_atividade As String
        Public Property Uf As String
        Public Property Municipio As String
        Public Property Logradouro As String
        Public Property Complemento As String
        Public Property Cep As String
        Public Property Numero As String
        Public Property Bairro As String
        Public Property Ibge As Ibge
    End Class

End Class
