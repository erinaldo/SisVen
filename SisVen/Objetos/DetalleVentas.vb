Imports System.ComponentModel
Public Class DetalleVentas
    Public Property Fecha As DateTime
    <DisplayName("Tipo")>
    Public Property TipoDoc As String
    <DisplayName("Folio")>
    Public Property NumDoc As Decimal
    <DisplayName("CodPro")>
    Public Property Articulo As Decimal
    <DisplayName("Detalle")>
    Public Property Descripcion As String
    <DisplayName("Unidad")>
    Public Property Unidad As String
    <DisplayName("Cantidad")>
    Public Property Cantidad As Decimal
    <DisplayName("Valor")>
    Public Property PVenta As Decimal
    <DisplayName("Total")>
    Public Property Total As Decimal
End Class
