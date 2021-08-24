Imports System.Xml.Serialization
Imports Microsoft.VisualBasic


<XmlRoot(ElementName:="Listado")>
Public Class ListadoDocumentos
    <XmlElement(ElementName:="Documentos")>
    Public Property Documentos As List(Of DatosDocumento)
End Class


<XmlRoot(ElementName:="Documentos")>
Public Class DatosDocumento

    <XmlElement(ElementName:="Fecha")>
    Public Property Fecha As DateTime
    <XmlElement(ElementName:="TipoDoc")>
    Public Property TipoDoc As String

    <XmlElement(ElementName:="NumDoc")>
    Public Property NumDoc As Double

    <XmlElement(ElementName:="Cliente")>
    Public Property Cliente As Double
    <XmlElement(ElementName:="NombreCliente")>
    Public Property NombreCliente As String
    <XmlElement(ElementName:="RutCliente")>
    Public Property RutCliente As String
    <XmlElement(ElementName:="IVA")>
    Public Property IVA As Double
    <XmlElement(ElementName:="Neto")>
    Public Property Neto As Double
    <XmlElement(ElementName:="Total")>
    Public Property Total As Double

End Class


