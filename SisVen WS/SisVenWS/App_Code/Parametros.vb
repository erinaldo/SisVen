Imports Microsoft.VisualBasic

Public Class Parametros

    Public Shared ReadOnly Property P_CONEXION As String
        Get
            Return "Data Source=" & ConfigurationManager.AppSettings("SERVIDOR") & ";Initial Catalog=SisVen;User ID=wikets;Password=software"
        End Get
    End Property


    Public Const P_ProductName = "SisVenWS"

    Public Shared P_VERSION As String = "1.0 - " & "20/09/2018 "
    Public Shared P_SERVIDOR As String = ConfigurationManager.AppSettings("SERVIDOR")

    'Public Shared P_CORREO As String = ConfigurationManager.AppSettings("CORREO") ' "avisos@juancondeza.cl"
    'Public Shared P_CONTRASENA As String = ConfigurationManager.AppSettings("CONTRASENA") ' "avisos1623"
    'Public Shared P_PUERTO As String = Val(ConfigurationManager.AppSettings("PUERTO")) '587
    'Public Shared P_HOST As String = ConfigurationManager.AppSettings("HOST") '"mail.juancondeza.cl"
    'Public Shared P_SSL As String = True
    'Public Shared P_TIMEOUT As Double = 5000
    'Public Shared P_IGNORAR_CERTIFICADOS As Boolean = True
    Public Shared P_IDKEY As String = "W1K3T5"

    Public Shared P_DIRECTORIO As String = ""
    Public Shared P_IVA As Double = 19

    'Param
    Public Shared P_DEMO_DTE As Boolean = CBool(Val(ConfigurationManager.AppSettings("ENVIO_AUTOMATICO")) = 1)
    Public Shared P_ENVIO_AUTOMATICO As Boolean = CBool(Val(ConfigurationManager.AppSettings("ENVIO_AUTOMATICO")) = 1)
    Public Shared P_RUTA As String = ConfigurationManager.AppSettings("RUTA")
    Public Shared P_CONTROL_STOCK As Boolean = CBool(Val(ConfigurationManager.AppSettings("CONTROL_STOCK")) = 1)


End Class
