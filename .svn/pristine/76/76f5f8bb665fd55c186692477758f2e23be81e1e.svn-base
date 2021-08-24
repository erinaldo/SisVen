


Imports System.IO
Imports System.Net
Imports System.Xml.Serialization

Public Class ValoresIndicadores
    Public UF As Double
    Public UF_MES As Double
    Public Dolar As Double
    Public UTM As Double
End Class

Public Class Indicadores

    Public Const G_APIKEY As String = "aaecc233275abcbcfd4e7403370166cd78f0c697"

    Public Shared Function GetIndicadorSBIF(ByVal URL As String) As String
        Dim request = CType(WebRequest.Create(URL), HttpWebRequest)
        request.Method = "GET"
        request.UserAgent = "Wikets"
        request.Accept = "application/xml"
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Dim content = String.Empty
        Dim result = request.GetResponse()

        Using response = CType(result, HttpWebResponse)

            Using stream = response.GetResponseStream()

                Using sr = New StreamReader(stream)
                    content = sr.ReadToEnd()
                End Using
            End Using
        End Using

        Return content
    End Function

    Public Shared Function GetDolar() As IndicadoresFinancieros
        Dim URL = "https://api.sbif.cl/api-sbifv3/recursos_api/dolar?apikey=" & G_APIKEY & "&formato=xml"
        Dim respuesta = GetIndicadorSBIF(URL)
        Return DeserializarXML(Of IndicadoresFinancieros)(respuesta)
    End Function

    Public Shared Function GetUTM() As IndicadoresFinancieros
        Dim URL = "https://api.sbif.cl/api-sbifv3/recursos_api/utm?apikey=" & G_APIKEY & "&formato=xml"
        Dim respuesta = GetIndicadorSBIF(URL)
        Return DeserializarXML(Of IndicadoresFinancieros)(respuesta)
    End Function

    Public Shared Function GetUF(ByVal Optional Fecha As DateTime? = Nothing) As IndicadoresFinancieros
        Dim URL = ""

        If Fecha Is Nothing Then
            URL = "https://api.sbif.cl/api-sbifv3/recursos_api/uf?apikey=" & G_APIKEY & "&formato=xml"
        Else
            Dim year = Fecha.Value.Year.ToString().PadLeft(4, "0"c)
            Dim month = Fecha.Value.Month.ToString().PadLeft(2, "0"c)
            Dim day = Fecha.Value.Day.ToString().PadLeft(2, "0"c)
            URL = "https://api.sbif.cl/api-sbifv3/recursos_api/uf/" & year & "/" + month & "/dias/" + day & "?apikey=" + G_APIKEY & "&formato=xml"
        End If

        Dim respuesta = GetIndicadorSBIF(URL)
        Return DeserializarXML(Of IndicadoresFinancieros)(respuesta)
    End Function
End Class

<XmlRoot(ElementName:="UTM", [Namespace]:="http://api.sbif.cl")>
Public Class UTM
    <XmlElement(ElementName:="Fecha", [Namespace]:="http://api.sbif.cl")>
    Public Property Fecha As String
    <XmlElement(ElementName:="Valor", [Namespace]:="http://api.sbif.cl")>
    Public Property Valor As String
End Class

<XmlRoot(ElementName:="UTMs", [Namespace]:="http://api.sbif.cl")>
Public Class UTMs
    <XmlElement(ElementName:="UTM", [Namespace]:="http://api.sbif.cl")>
    Public Property UTM As UTM
End Class

<XmlRoot(ElementName:="Dolar", [Namespace]:="http://api.sbif.cl")>
Public Class Dolar
    <XmlElement(ElementName:="Fecha", [Namespace]:="http://api.sbif.cl")>
    Public Property Fecha As String
    <XmlElement(ElementName:="Valor", [Namespace]:="http://api.sbif.cl")>
    Public Property Valor As String
End Class

<XmlRoot(ElementName:="Dolares", [Namespace]:="http://api.sbif.cl")>
Public Class Dolares
    <XmlElement(ElementName:="Dolar", [Namespace]:="http://api.sbif.cl")>
    Public Property Dolar As Dolar
End Class

<XmlRoot(ElementName:="UF", [Namespace]:="http://api.sbif.cl")>
Public Class UF
    <XmlElement(ElementName:="Fecha", [Namespace]:="http://api.sbif.cl")>
    Public Property Fecha As String
    <XmlElement(ElementName:="Valor", [Namespace]:="http://api.sbif.cl")>
    Public Property Valor As String
End Class

<XmlRoot(ElementName:="UFs", [Namespace]:="http://api.sbif.cl")>
Public Class UFs
    <XmlElement(ElementName:="UF", [Namespace]:="http://api.sbif.cl")>
    Public Property UF As UF
End Class

<XmlRoot(ElementName:="IndicadoresFinancieros", [Namespace]:="http://api.sbif.cl")>
Public Class IndicadoresFinancieros
    <XmlElement(ElementName:="UFs", [Namespace]:="http://api.sbif.cl")>
    Public Property UFs As UFs
    <XmlElement(ElementName:="UTMs", [Namespace]:="http://api.sbif.cl")>
    Public Property UTMs As UTMs
    <XmlElement(ElementName:="TABs", [Namespace]:="http://api.sbif.cl")>
    Public Property TABs As String
    <XmlElement(ElementName:="IPCs", [Namespace]:="http://api.sbif.cl")>
    Public Property IPCs As String
    <XmlElement(ElementName:="Dolares", [Namespace]:="http://api.sbif.cl")>
    Public Property Dolares As Dolares
    <XmlElement(ElementName:="Euros", [Namespace]:="http://api.sbif.cl")>
    Public Property Euros As String
    <XmlElement(ElementName:="TMCs", [Namespace]:="http://api.sbif.cl")>
    Public Property TMCs As String
    <XmlElement(ElementName:="Perfiles", [Namespace]:="http://api.sbif.cl")>
    Public Property Perfiles As String
    <XmlAttribute(AttributeName:="xsi", [Namespace]:="http://www.w3.org/2000/xmlns/")>
    Public Property Xsi As String
    <XmlAttribute(AttributeName:="SchemaVersion")>
    Public Property SchemaVersion As String
    <XmlAttribute(AttributeName:="schemaLocation", [Namespace]:="http://www.w3.org/2001/XMLSchema-instance")>
    Public Property SchemaLocation As String
    <XmlAttribute(AttributeName:="xmlns")>
    Public Property Xmlns As String
End Class
