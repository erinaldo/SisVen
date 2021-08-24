Imports System.Xml.Serialization
Imports Microsoft.VisualBasic


<XmlRoot(ElementName:="Detalle")>
Public Class Detalle
    <XmlElement(ElementName:="DetalleDocumento")>
    Public Property DetalleDocumento As List(Of DetalleDocumento)
End Class

<XmlRoot(ElementName:="DetalleDocumento")>
Public Class DetalleDocumento

    <XmlElement(ElementName:="Articulo")>
    Public Property Articulo As String
    <XmlElement(ElementName:="Descripcion")>
    Public Property Descripcion As String
    <XmlElement(ElementName:="Cantidad")>
    Public Property Cantidad As Double
    <XmlElement(ElementName:="PrecioVenta")>
    Public Property PrecioVenta As Double
    <XmlElement(ElementName:="IVA")>
    Public Property IVA As Double
    <XmlElement(ElementName:="Neto")>
    Public Property Neto As Double
    <XmlElement(ElementName:="Total")>
    Public Property Total As Double

End Class
