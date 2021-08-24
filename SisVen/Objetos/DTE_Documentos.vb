Public Class DTE_Documentos
    Implements ICloneable

    Private Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Function Clonar() As DTE_Documentos
        Return Me.Clone()
    End Function
    Public Property Local As String = ""
    Public Property RutLocal As String = ""
    Public Property NombreLocal As String = ""
    Public Property RazonLocal As String = ""
    Public Property GiroLocal As String = ""
    Public Property DireccionLocal As String = ""
    Public Property CiudadLocal As String = ""
    Public Property ComunaLocal As String = ""
    Public Property EmailLocal As String = ""
    Public Property FonoLocal As String = ""
    Public Property Horarios As String = ""
    Public Property SII As String = ""
    Public Property BancoDeposito As String = ""
    Public Property CuentaDeposito As String = ""
    Public Property RutDeposito As String = ""
    Public Property TitularDeposito As String = ""
    Public Property CorreoDeposito As String = ""
    Public Property TipoDoc As String = ""
    Public Property DescTipoDoc As String = ""
    Public Property Numero As Double = 0
    Public Property Fecha As Date = Now
    Public Property Cliente As Double = 0
    Public Property Rut As String = ""
    Public Property Nombre As String = ""
    Public Property Direccion As String = ""
    Public Property Giro As String = ""
    Public Property Ciudad As String = ""
    Public Property Comuna As String = ""
    Public Property Telefono As String = ""
    Public Property Contacto As String = ""
    Public Property Correo As String = ""

    Public Property FPago As String = ""
    Public Property OC As String = ""
    Public Property Motivo As String = ""
    Public Property TipoDocRef As String = ""
    Public Property DescTipoDocRef As String = ""
    Public Property NumTipoDocRef As String = ""
    Public Property FechaTipoDocRef As String = ""
    Public Property Observaciones As String = ""

    Public Property Articulo As String = ""
    Public Property Descripcion As String = ""
    Public Property Glosa As String = ""
    Public Property Barra As String = ""
    Public Property Unidad As String = ""
    Public Property Cantidad As Double = 0
    Public Property Precio As Double = 0
    Public Property PVenta As Double = 0

    Public Property Neto As Double = 0
    Public Property Descuento As Double = 0
    Public Property IVA As Double = 0
    Public Property Total As Double = 0

    Public Property Firma As Image
    Public Property Logo As Image
    Public Property NResolucion As Double = 0
    Public Property FResolucion As Date = Now
    Public Property Grupo As Double

End Class
