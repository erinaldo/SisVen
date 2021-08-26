Imports System.ComponentModel
Public Class CabeceraVentas
    Public Property Cliente As Decimal
    <DisplayName("Tipo Documento")>
    Public Property TipoDoc As String
    <DisplayName("Nº Folio")>
    Public Property NumDoc As String
    <DisplayName("FecEmi")>
    Public Property FechaEmi As Date
    <DisplayName("FecVen")>
    Public Property FechaVen As Date
    <DisplayName("CondPago")>
    Public Property FPago As String
    <DisplayName("Código Vendedor")>
    Public Property Vendedor As String
    <DisplayName("RUT Cliente")>
    Public Property Rut As String
    <DisplayName("Razón Social Cliente")>
    Public Property Nombre As String
    <DisplayName("Comuna Dirección Cliente")>
    Public Property Comuna As String
    <DisplayName("Ciudad Dirección Cliente")>
    Public Property Ciudad As String
    <DisplayName("Giro Cliente")>
    Public Property Giro As String
    <DisplayName("Fonos Cliente")>
    Public Property Telefonos As String
    <DisplayName("Afecto")>
    Public Property Neto As String
    <DisplayName("IVA")>
    Public Property IVA As String
    <DisplayName("ImpAdic")>
    Public Property Adicionales As String
    <DisplayName("Total")>
    Public Property Total As String
    <DisplayName("Código Bodega")>
    Public Property Bodega As String
    <DisplayName("Sigla Distribuidor")>
    Public Property Fantasia As String
    <DisplayName("Codigo de Sucursal")>
    Public Property Sucursal As String
    <DisplayName("Direccion de Sucursal")>
    Public Property DireccionSuc As String
    <DisplayName("Comuna de Sucursal")>
    Public Property ComunaSuc As String
    <DisplayName("Ciudad de Sucursal")>
    Public Property CiudadSuc As String
    <DisplayName("Direccion Casa Matriz")>
    Public Property Direccion As String
    <DisplayName("Nombre Vendedor")>
    Public Property NombreVendedor As String
End Class
