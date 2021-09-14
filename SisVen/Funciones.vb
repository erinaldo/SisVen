'Wikets     = W
'MultiBike  = M
'GiantCold  = G

Option Strict Off
Option Explicit On

Imports ADODB
Imports System.IO
Imports System.Threading
Imports System.Reflection
Imports System.Globalization
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization

Module Funciones
    Public Const CHECK As String = "-1"
    Public Const UNCHECK As String = "0"
    Public Const W_SELECCIONAR As String = "Seleccionar"
    Public Const c_Empresa As String = "Wikets Software"
    Public Const c_Sistema As String = "SisVen"
    Public Const Version As String = "1.56 14/09/2021"

    Public gProgramador As Boolean = False
    Public gMonoLocal As Boolean = True
    Public ADMINISTRADOR As Boolean
    Public SQL_QUERY As String
    Public P_CONEXION As String

    Public G_IVA As Double
    Public G_UF As Double
    Public G_DOLAR As Double
    Public G_UF_MES As Double
    Public G_UTM As Double

    'Colores
    Public C_ROJO = Color.FromArgb(255, 99, 115)
    Public C_AMARILLO = Color.FromArgb(255, 220, 69)
    Public C_AMARILLO_CELDA = Color.FromArgb(255, 222, 144)
    Public C_SOLOLECTURA = Color.FromArgb(220, 230, 235)
    Public C_VERDE = Color.FromArgb(135, 255, 115)
    Public C_TITULO = Color.FromArgb(29, 73, 140)
    Public C_CELESTE = Color.FromArgb(115, 214, 255)
    Public C_VERDE_CLARO = Color.FromArgb(210, 255, 132)
    Public C_BLANCO = Color.White
    Public C_VIOLETA = Color.FromArgb(155, 162, 255)
    Public C_GRISAZUL = Color.FromArgb(212, 232, 248) '(202, 224, 248) '(223, 227, 232)
    Public C_GRIS = Color.FromArgb(222, 232, 232)

    Public C_NARANJO = Color.FromArgb(255, 179, 149)
    Public C_NARANJO_TXT = Color.FromArgb(83, 0, 2)


    Public C_FUENTE_AZUL = Color.FromArgb(29, 73, 140)
    Public C_FUENTE_AZUL_2 = Color.FromArgb(15, 41, 100)
    Public C_FUENTE_VERDE = Color.FromArgb(0, 64, 0)
    Public C_FUENTE_AMARILLO = Color.FromArgb(64, 51, 0)
    Public C_FUENTE_ROJO = Color.FromArgb(64, 0, 0)

    Public C_CELDA_SEL = Color.FromArgb(108, 201, 255)

    Public PR_ENTRAR = "ENTRAR"
    Public PR_MODIFICAR = "MODIFICAR"
    Public PR_ELIMINAR = "ELIMINAR"
    Public PR_IMPRIMIR = "IMPRIMIR"
    Public PR_GUARDAR = "GUARDAR"
    Public PR_INGRESAR = "INGRESAR"
    Public PR_CONSULTAR = "CONSULTAR"

    Public F_CAMBIAR_LOCAL As Boolean = False
    Public F_CAMBIO_SERVIDOR As Boolean = False
    'Bases de Datos 
    Public miBd As New Connection 'Base de datos
    Public gDemo As Boolean = False

    Public OTR As New Recordset  'OTRepuestos
    Public Swap As New Recordset 'Tabla de Consultas temporales
    Public Paso As New Recordset 'Tabla de Consultas temporales
    Public Art As New Recordset  'Articulos
    Public Ven As New Recordset  'Ventas
    Public Caj As New Recordset  'Caja
    Public Bar As New Recordset  'tabla codigos de Barra
    Public MvG As New Recordset  'Tabla de movimientos generales
    Public MvD As New Recordset  'Tabla de movimientos destalles
    Public Bod As New Recordset  'Bodegas
    Public Par As New Recordset  'Parametros
    Public Sis As New Recordset  'Sistema
    Public Usr As New Recordset  'Usuarios
    Public Uni As New Recordset  'Unidad
    Public Acc As New Recordset  'Accesos
    Public Per As New Recordset  'Permisos de Usuarios
    Public Loc As New Recordset  'Locales
    Public Aud As New Recordset  'Auditoria
    Public Dat As New Recordset  'Datos
    Public Cli As New Recordset  'Cliente
    Public Ciu As New Recordset  'Ciudad
    Public Com As New Recordset  'Comuna
    Public Est As New Recordset  'Estado
    Public FPG As New Recordset  'Formas de Pago
    Public Tip As New Recordset  'Tipos

    Public Cor As New Recordset  'Correlativo
    Public POS As New Recordset  'POS
    Public Inv As New Recordset  'Inventario
    Public Fami As New Recordset 'Familias
    Public SubF As New Recordset 'Sub Familias
    Public Movi As New Recordset 'Movimiento
    Public Doc As New Recordset  'Documentos
    Public TDo As New Recordset  'Tipos Documentos
    Public Mov As New Recordset  'Movimientos
    Public Mot As New Recordset  'Motivos
    Public Eve As New Recordset  'Evento
    Public Stk As New Recordset  'Stocks
    Public Trk As New Recordset  'Tracking 
    Public TkG As New Recordset  'Ticket General
    Public TkD As New Recordset  'Ticket Detalle
    Public Arc As New Recordset  'Archivo
    Public Ped As New Recordset  'Pedido
    Public FPa As New Recordset  'Formas de Pago
    Public Abo As New Recordset  'Abonos
    Public DocG As New Recordset 'Documento General
    Public DocD As New Recordset 'Documento Detalle
    Public DocP As New Recordset 'Documento Pago  
    Public OT As New Recordset   'OT
    Public TEC As New Recordset ' Tecnico
    Public RmD As New Recordset  'Remuneraciones Detalle
    Public EvR As New Recordset  'Evento Remuneraciones
    Public RmG As New Recordset  ' Remuneraciones General
    Public ATC As New Recordset  'Atencion
    Public TDR As New Recordset  'Tipo Documento Referencia


    Public Demo As Boolean
    Public Edicion As String

    Public MaxDouble As Double = 999999999999999 '15 dígitos / Máximo para evitar notación científica en conversión

    Public P_SERVIDOR As String
    Public P_SISTEMA As String
    Public P_DBASE As String
    Public P_NOMBRE As String
    Public P_VERSION As String
    Public P_EMPRESA As String
    Public P_CLAVE As String
    Public P_POS As String
    Public P_CAJA As String

    Public wListado As String
    Public ValorIP As String
    Public TipoEncontrado As String 'De que tipo encontro el articulo por codigo o por barra
    Public gClave As String
    Public gCantidad As Double
    Public gIVA As Double
    Public Programador As Boolean
    Public Resultado As Short
    Public Respuesta As Object
    Public Directorio As String     'directorio de base de datos
    Public Directorio_Carga As String ' Direcotorio de los archivos de carga
    Public Lineas As Short
    Public Lin As Integer
    Public wVisorReporte As String

    Public UsuarioActual As String  'Usuario actual del sistema
    Public ClienteUsuarioActual As String
    Public NombreUsuarioActual As String   'Nombre del Usuario Actual
    Public ClienteLocalActual As String
    Public FantasiaClienteLocal As String
    Public ModulosUsuario As List(Of String)
    Public LocalUsuario As String
    Public LocalActual As String            'Empresa Actual
    Public BodegaActual As Double           'Local Actual
    Public NombreLocalActual As String
    Public AccesoUsuario As Double
    Public IvaGlobal As Double
    Public UFGlobal As Double
    Public UTMGlobal As Double
    Public DescripcionArticulo As String
    Public UnidadMedida As String

    Public Fecha_Trabajo As Date
    Public Empresa As String
    Public Modulo As String
    Public ModuloReporte As String
    Public Ubicacion As Short
    Public ConectaReporte As String
    Public Modo As String
    Public strSQL As String
    Public Maximo As Short
    Public Documento As String
    Public Principal As Boolean
    Public Emision As Boolean
    Public Temporizador As Short
    Public AjusteGlobal As String
    Public TraspasoGlobal As String
    Public QRY As String
    Public Tipo As String ' para menu movimiento.
    Public Mostrar As Boolean
    Public wParametroBuscar As String
    Public POSActual As Integer
    Public CajaActual As Integer
    Public FiltroArt As String

    Public gLocal As Double
    Public gTipoDoc As String
    Public gNumero As Double
    Public gTipoCopia As List(Of Double)

    Public Supervisor As Boolean
    Public Todos_los_Locales As Integer
    Public Doc_Electronicos As Boolean

    Public ReintentosInterbloqueo As Integer
    Public gFormulario As String 'Nombre Fantasia
    Public key13 As New KeyPressEventArgs(Convert.ToChar(13)) 'llamar el Enter

    Public Function Parametros() As Boolean
        Try
            P_CLAVE = My.Settings.CLAVE
            P_SERVIDOR = My.Settings.SERVIDOR
            P_DBASE = My.Settings.DBASE
            P_CAJA = Val(My.Settings.CAJA)
            P_POS = Val(My.Settings.POS)
            P_CONEXION = String.Format(My.Settings.CONEXION, P_SERVIDOR, P_DBASE)
            POSActual = P_POS
            CajaActual = P_CAJA

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub SaveJson(json As String, archivo As String)

        Dim wPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Directory.CreateDirectory(wPath)
        wPath &= "/Log_" + archivo + ".json"
        Try
            File.WriteAllText(wPath, json)
        Catch ex As Exception
        End Try

    End Sub

#Region "MENSAJES"

    Public Sub MsgError(ByVal wError As String)
        MessageBox.Show(wError, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub Mensaje(ByVal wMensaje As String)
        MessageBox.Show(wMensaje, "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Function Msg_Cancela(ByVal wMensaje As String) As Boolean
        If MessageBox.Show(wMensaje, "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = vbYes Then
            Msg_Cancela = True
        Else
            Msg_Cancela = False
        End If
    End Function

    Public Sub Advertencia(ByVal wMensaje As String)
        MessageBox.Show(wMensaje, "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Function PreguntaAdvertencia(ByVal wMensaje As String) As Boolean
        Respuesta = MessageBox.Show(wMensaje, "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Respuesta = vbYes Then
            PreguntaAdvertencia = True
        Else
            PreguntaAdvertencia = False
        End If
    End Function

    Public Function Pregunta(ByVal wMensaje As String) As Boolean
        Respuesta = MessageBox.Show(wMensaje, "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Respuesta = vbYes Then
            Pregunta = True
        Else
            Pregunta = False
        End If
    End Function


#End Region

#Region "INICIALIZACIÓN"
    Public Function Abrir() As Boolean
        Dim wBases As String = "SisVen"

        If P_DBASE <> "" Then
            wBases = P_DBASE
        End If
        If P_SERVIDOR = "25.12.227.182" Then
            wBases = "Wikets"
            P_DBASE = "Wikets"
        End If
        If gDemo Then wBases = "Demo" + wBases

        'Abrir Bases de Datos Principales
        Try
            miBd = CreateObject("ADODB.Connection")
            ConectaReporte = "DRIVER={SQL Server};SERVER=" & P_SERVIDOR & ";UID=wikets;PWD=software;DATABASE=" & wBases
            miBd.ConnectionString = ConectaReporte
            miBd.CommandTimeout = 3000
            miBd.CursorLocation = ADODB.CursorLocationEnum.adUseServer
            miBd.Open()
            Abrir = True
        Catch ex As Exception
            MsgError(("No se pudo Conectar con la Base de Datos."))
            Abrir = False
        End Try

    End Function

#End Region

#Region "BASE DE DATOS"
    Function SQL(ByRef wString As String, Optional wSoloConsulta As Boolean = False) As Recordset
        Dim wSql As New Recordset
        SQL_QUERY = wString

        Try
            If wSoloConsulta Then
                miBd.CursorLocation = CursorLocationEnum.adUseClient
                wSql.Open(wString, miBd, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Else
                miBd.CursorLocation = CursorLocationEnum.adUseServer
                wSql.Open(wString, miBd, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            End If

            SQL = wSql
        Catch Err As Exception
            If Msg_Cancela("Error en Consulta SQL:" + vbCrLf + vbCrLf + wString + vbCrLf + " Tipo Error:" + Err.Message.ToString + vbCrLf + "¿Desea Continuar?") Then
                If Pregunta("¿Desea intentar reestablecer la conexión?") Then
                    Abrir()
                    Return SQL(wString)
                Else
                    SQL = Nothing
                    Throw
                End If
            Else
                End
            End If
        End Try
    End Function

    Function SQL_FilasAfectadas(ByRef wString As String) As Double
        Dim wSql As New Recordset
        Dim wFilasAfectadas As Double
        Try
            wSql.Open(wString, miBd, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
            miBd.Execute(wString, wFilasAfectadas)
            Return wFilasAfectadas
        Catch Err As Exception
            If Msg_Cancela("Error en Consulta SQL:" + vbCrLf + vbCrLf + wString + vbCrLf + " Tipo Error:" + Err.Message.ToString + vbCrLf + "¿Desea Continuar?") Then
                End
            Else
                Return 0
            End If
        End Try
    End Function

    Function UPDATE(ByRef wTabla As String, ByVal wCampoCambiar As String, ByVal wNuevoValor As String, ByVal wCampo As String, ByVal wClave As String) As Boolean
        Dim wUpd As Recordset
        Dim wQuery As String = ""
        Try
            wQuery = "UPDATE " & wTabla & " SET " & wCampoCambiar & " = '" & wNuevoValor & "' " &
                     "WHERE " & wCampo & " = '" & wClave & "'"
            wUpd = SQL(wQuery)
            UPDATE = True
        Catch ex As Exception
            MsgError("Error en Consulta SQL:" + vbCrLf + vbCrLf + wQuery + vbCrLf + " Tipo Error:" + ex.Message.ToString + vbCrLf)
            UPDATE = False
        End Try
    End Function

    Public Function BuscarBase(ByVal sTabla As String, ByRef sCampo As String, ByRef sClave As String, Optional ByRef sColumnas As String = "*", Optional ByRef sOrden As String = "", Optional ByRef sAscDes As String = "") As Boolean
        BuscarBase = False
        Try
            If Trim(sClave) = "" Or Trim(sTabla) = "" Then
                BuscarBase = False
                Exit Function
            End If
            If IsDBNull(sColumnas) Then
                sColumnas = "*"
            End If
            If Trim(sColumnas) = "" Then
                sColumnas = "*"
            End If
            If IsDBNull(sOrden) Then
                sOrden = ""
            End If

            If Trim(sOrden) <> "" Then
                If IsDBNull(sAscDes) Then
                    sAscDes = "ASC"
                End If
                If sAscDes = "+" Then sAscDes = "ASC"
                If sAscDes = "-" Then sAscDes = "DESC"
                Swap = New Recordset
                strSQL = "SELECT " + sColumnas + " FROM " + sTabla + " WHERE " & sCampo & "='" & Trim(sClave) & "'" & " ORDER BY " & Trim(sOrden) & " " + sAscDes + " "
                Swap.Open(strSQL, miBd, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
            Else
                sOrden = sCampo
                Swap = New Recordset
                strSQL = "SELECT " + sColumnas + " FROM " + sTabla + " WHERE " & sCampo & "='" & Trim(sClave) & "'"
                Swap.Open(strSQL, miBd, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
            End If

            BuscarBase = Not Swap.EOF

            Exit Function

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Function

    Public Function Buscar(ByRef sTabla As String, ByRef sCampo As String, ByRef sClave As String, Optional ByRef sColumnas As String = " * ", Optional ByRef sOrden As String = "", Optional ByRef sAscDes As String = "") As Boolean
        Buscar = False
        Try
            If Trim(sClave) = "" Or Trim(sTabla) = "" Then
                Buscar = False
                Exit Function
            End If
            If IsDBNull(sColumnas) Then
                sColumnas = " * "
            End If
            If Trim(sColumnas) = "" Then
                sColumnas = " * "
            End If
            If IsDBNull(sOrden) Then
                sOrden = ""
            End If

            If Trim(sOrden) <> "" Then
                If IsDBNull(sAscDes) Then
                    sAscDes = "ASC"
                End If
                If sAscDes = "+" Then sAscDes = "ASC"
                If sAscDes = "-" Then sAscDes = "DESC"
                Swap = New Recordset
                strSQL = "SELECT " + sColumnas + " FROM " + sTabla + " WHERE " & sCampo & "='" & Trim(sClave) & "'" & " ORDER BY " & Trim(sOrden) & " " + sAscDes + " "
                Swap.Open(strSQL, miBd, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
            Else
                sOrden = sCampo
                Swap = New Recordset
                strSQL = "SELECT " + sColumnas + " FROM " + sTabla + " WHERE " & sCampo & "='" & Trim(sClave) & "'"
                '                Swap.Open(strSQL, miBd, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)

                Swap = SQL(strSQL)
            End If

            If Not Swap.EOF Then
                Buscar = True
            Else
                Buscar = False
            End If
            Exit Function

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Function
    Function BuscaDocumento(ByVal wDescTipoDoc As String) As String
        If Buscar("TipoDoc", "DescTipoDoc", wDescTipoDoc.Trim) Then
            Return Swap.Fields("TipoDoc").Text
        End If
        Return ""
    End Function

    Function BuscaNombreDocumento(ByVal wTipoDoc As String) As String
        If Buscar("TipoDoc", "TipoDoc", wTipoDoc.Trim) Then
            Return Swap.Fields("DescTipoDoc").Text
        End If
        Return ""
    End Function

    Public Sub Auditoria(Optional ByVal wProceso As String = "", Optional ByVal wEvento As String = "", Optional ByVal wDato As String = "", Optional ByVal wValor As String = "0")
        Dim wUsuario As String = ""
        If IsDBNull(UsuarioActual) Then wUsuario = "" Else wUsuario = UsuarioActual

        Try
            Aud = SQL("SELECT TOP 1 * FROM Auditoria")
            Aud.AddNew()
            Aud.Fields("Lugar").Value = "PC"
            Aud.Fields("Fecha").Value = Now
            Aud.Fields("Hora").Value = Format(Now, "hh:mm:ss")
            Aud.Fields("Local").Value = LocalActual
            Aud.Fields("Usuario").Value = wUsuario
            Aud.Fields("Proceso").Value = wProceso
            Aud.Fields("Evento").Value = wEvento
            Aud.Fields("Dato").Value = wDato
            Aud.Fields("Valor").Value = wValor
            Aud.Update()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Tracking(ByVal wPaquete As String, ByVal wArticulo As Double, ByVal wFecha As Date, ByVal wEvento As String,
        ByVal wUsuario As String, ByVal wLocal As Double, ByVal wBodega As Double, ByVal wTipoDoc As String, ByVal wNumDoc As Double,
        ByVal wCliente As Double, ByVal wLlamada As Double, ByVal wMovil As String, ByVal wChofer As String, ByVal wOt As Double,
        ByVal wFechaaRealizar As Date, ByVal wtop As Double, ByVal wObs As String, ByVal wCantidad As Double, ByVal wUbicacion As String)

        Trk = SQL("SELECT TOP 1 * FROM Tracking")
        Trk.AddNew()
        Trk.Fields("Paquete").Value = wPaquete
        Trk.Fields("Articulo").Value = wArticulo
        Trk.Fields("Fecha").Value = wFecha
        Trk.Fields("Evento").Value = wEvento
        Trk.Fields("Cantidad").Value = wCantidad
        Trk.Fields("Usuario").Value = wUsuario
        Trk.Fields("Local").Value = wLocal
        Trk.Fields("Bodega").Value = wBodega
        Trk.Fields("TipoDoc").Value = wTipoDoc
        Trk.Fields("NumDoc").Value = wNumDoc
        Trk.Fields("Cliente").Value = wCliente
        Trk.Fields("LLAMADA").Value = wLlamada
        Trk.Fields("Movil").Value = Trim(wMovil)
        Trk.Fields("Chofer").Value = Trim(wChofer)
        Trk.Fields("OT").Value = wOt
        Trk.Fields("FechaaRealizar").Value = wFechaaRealizar
        Trk.Fields("OP").Value = wtop
        Trk.Fields("Obs").Value = wObs
        Trk.Fields("Ubicacion").Value = wUbicacion
        Trk.Update()
    End Sub
    Public Sub LimpiarTextos(ByVal wForm As Object)
        Dim wControl As Control
        For Each wControl In wForm.Controls
            If (wControl.HasChildren) Then
                LimpiarTextos(wControl)
            Else
                If (TypeOf wControl Is TextBox) Then
                    wControl.Text = ""
                End If
            End If
        Next
    End Sub

    Public Sub LimpiarCampos(ByVal wForm As Object)
        For Each wControl In wForm.Controls
            If (wControl.HasChildren) Then
                LimpiarCampos(wControl)
            Else
                If (TypeOf wControl Is TextBox) Then
                    wControl.Text = ""
                End If
                If (TypeOf wControl Is ComboBox) Then
                    If wControl.Items.Count > 0 Then
                        wControl.SelectedIndex = 0
                    End If
                End If
                If (TypeOf wControl Is CheckBox) Then
                    wControl.Checked = False
                End If
            End If
        Next

    End Sub
#End Region

#Region "UTILITARIOS"

    Public Function May(ByRef xAsc As Short) As Short
        May = Asc(UCase(Chr(xAsc)))
    End Function


    Public Function PuntoAcoma(ByRef wAscii As Short) As Short
        If wAscii = 46 Then
            PuntoAcoma = 44
        Else
            PuntoAcoma = wAscii
        End If
    End Function


    Public Function Descripta(ByRef pCadena As String) As String
        Dim Descriptado As String
        Dim X As Integer, AUX As String

        pCadena = Trim(pCadena)
        Descriptado = ""
        AUX = " "
        For X = 1 To Len(pCadena)
            AUX = Mid(pCadena, X, 1)

            Descriptado = Descriptado + Chr((Asc(AUX) / 2) - 2)
        Next X
        Descripta = Descriptado
    End Function

    Public Function Encripta(ByRef KeyAscii As Short) As Integer
        'Encripta la clave del usuario
        If (KeyAscii >= 91 And KeyAscii <= 122) Then
            KeyAscii = KeyAscii + Asc("A") - Asc("a")
        End If

        If Chr(KeyAscii) = "ñ" Then
            KeyAscii = Asc("Ñ")
        End If

        KeyAscii = ((KeyAscii + 2) * 2)
        If KeyAscii > 255 Then
            KeyAscii = KeyAscii - 255
        End If
        Encripta = KeyAscii
    End Function

    Public Function Crypt(ByRef pCadena As String) As String
        Dim Descriptado As String, AUX As String
        Dim X As Integer

        pCadena = Trim(pCadena)
        Descriptado = ""
        AUX = " "
        For X = 1 To Len(pCadena)
            AUX = Mid(pCadena, X, 1)
            Descriptado = Descriptado + Chr((Asc(AUX) + 2) * 2)
        Next X
        Crypt = Descriptado
    End Function

    Public Function Press_Tecla(ByRef Tecla As Short) As Short
        If Tecla >= 91 And Tecla <= 122 Then Tecla = Tecla + Asc("A") - Asc("a")
        If Chr(Tecla) = "ñ" Then Tecla = Asc("Ñ")
        If Tecla = Asc(".") Then Tecla = Asc(",")
        If Tecla = 13 Then
            Tecla = 0
            System.Windows.Forms.SendKeys.Send("{TAB}")
        End If
        Press_Tecla = Tecla
    End Function

    Function Num(ByRef wNumero As String) As String
        Num = Val(wNumero).ToString.Trim
    End Function

    Public Sub SendKeys(ByVal wTecla As String)
        System.Windows.Forms.SendKeys.Send(wTecla)

    End Sub
    Public Sub DoEvents()
        Application.DoEvents()
    End Sub




#End Region

#Region "FECHA - HORA"

    Function FechaHasta(ByVal wFecha As DateTime) As Date
        Return New DateTime(wFecha.Year, wFecha.Month, wFecha.Day, 23, 59, 59)
    End Function

    Function FechaDesde(ByVal wFecha As DateTime) As Date
        Return New DateTime(wFecha.Year, wFecha.Month, wFecha.Day, 0, 0, 0)
    End Function

    Public Function IniFinFecha(ByVal wModo As Integer, ByVal wFecha As DateTime, Optional ByVal wMesesAdicionales As Integer = 0) As DateTime
        'Fecha con el primer o último día del mes incluido en la fecha ingresada (igual que IniFecha pero devuelve DateTime)
        IniFinFecha = CDate("01/01/3000")
        Select Case wModo
            Case 1 'Inicial
                Return FechaDesde(New DateTime(wFecha.Year, wFecha.Month + wMesesAdicionales, 1))
            Case 2 'Final
                Return FechaHasta(New DateTime(wFecha.Year, wFecha.Month + wMesesAdicionales, 1).AddMonths(1).AddDays(-1))
        End Select
    End Function

    Public Function IniFecha(ByVal fModo As Integer, ByVal fDate As Date) As Date
        Dim fMesActual As Integer, j As Integer, fPaso As String

        IniFecha = fDate
        fPaso = ""
        If Not IsDate(fDate) Then
            IniFecha = fDate
            Exit Function
        End If

        fMesActual = Month(fDate)

        ' Fecha Inicial y Final segun el mes
        If fModo = 1 Then
            fPaso = "01/" + Trim(Str(fMesActual)) + "/" + Trim(Str(Year(fDate)))
        End If
        If fModo = 2 Then
            For j = 31 To 28 Step -1
                DoEvents()
                fPaso = Trim(Str(j)) + "/" + Trim(Str(fMesActual)) + "/" + Trim(Str(Year(fDate)))
                If IsDate(fPaso) Then
                    Exit For
                End If
            Next j
        End If
        IniFecha = CDate(fPaso)
    End Function

    Function HoraEnDecimal(ByVal wHora As String) As Double
        'La hora se ajusto a 2 decimales para coincidir con el calculo del sistema antiguo.
        HoraEnDecimal = Math.Round(CDbl(Mid(wHora, 1, 2)) + ((CDbl(Mid(wHora, 4, 2)) * 100) / 60) / 100, 2)
    End Function


    Function MES(ByRef nMes As Short) As String
        MES = ""

        If nMes = 1 Then
            MES = "Enero"
        End If
        If nMes = 2 Then
            MES = "Febrero"
        End If
        If nMes = 3 Then
            MES = "Marzo"
        End If
        If nMes = 4 Then
            MES = "Abril"
        End If
        If nMes = 5 Then
            MES = "Mayo"
        End If
        If nMes = 6 Then
            MES = "Junio"
        End If
        If nMes = 7 Then
            MES = "Julio"
        End If
        If nMes = 8 Then
            MES = "Agosto"
        End If
        If nMes = 9 Then
            MES = "Septiembre"
        End If
        If nMes = 10 Then
            MES = "Octubre"
        End If
        If nMes = 11 Then
            MES = "Noviembre"
        End If
        If nMes = 12 Then
            MES = "Diciembre"
        End If

        If nMes = 0 Then
            MES = "Diciembre"
        End If
        If nMes = 13 Then
            MES = "Enero"
        End If

    End Function

    Public Function Saca_Hora(ByVal zFecha As Date) As String
        Saca_Hora = Formato_Texto(Hour(zFecha).ToString, "N", 2) + ":" + Formato_Texto(Minute(zFecha).ToString, "N", 2)
    End Function

    Public Function Forma_Fecha(ByVal wFecha As String) As String
        Dim wAno As String, wMes As String, wDia As String, qfecha As String

        wAno = Mid(wFecha, 1, 4)
        wMes = Mid(wFecha, 5, 2)
        wDia = Mid(wFecha, 7, 2)

        qfecha = wDia + "/" + wMes + "/" + wAno

        Forma_Fecha = qfecha
    End Function

    Public Function Fecha_Crystal(ByVal wFecha As Date) As String
        Dim wAno As String, wMes As String, wDia As String

        wAno = wFecha.Year.ToString.Trim
        wMes = wFecha.Month.ToString.Trim
        wDia = wFecha.Day.ToString.Trim

        Fecha_Crystal = " Date(" + wAno + "," + wMes + "," + wDia + ")"
    End Function

    Public Function Fecha_Corta(wFecha As Date, Optional wModo As Integer = 0) As String
        Dim wAno As String, wMes As String, wDia As String

        'Modo 0 = dd/mm/aaaa
        'Modo 1 = aaaa/mm/dd

        wAno = wFecha.Year.ToString.Trim
        wMes = wFecha.Month.ToString.Trim
        wDia = wFecha.Day.ToString.Trim

        If wModo = 0 Then
            Fecha_Corta = wDia + "/" + wMes + "/" + wAno
        Else
            Fecha_Corta = wAno + "/" + wMes + "/" + wDia
        End If
    End Function


#End Region

#Region "FORMATO"

    Function ConcatenarTexto(ByVal wLista As List(Of String), ByVal wSeparador As String)
        Return Concatenar(wLista.ToArray, wSeparador)
    End Function

    Function ConcatenarNum(ByVal wLista As List(Of Decimal), ByVal wSeparador As String)
        Return Concatenar(wLista.Select(Function(wNum) wNum.ToString()).ToArray(), wSeparador)
    End Function

    Function Concatenar(ByVal wLista As IEnumerable(Of Object), ByVal wSeparador As String)
        Return wLista.Select(Function(wItem) wItem.ToString).
            Aggregate(Function(wActual, wAnterior) wActual & wSeparador & wAnterior)
    End Function

    Function Concatenar(ByVal wRs As Recordset, ByVal wSeparador As String)
        Dim wLista As New List(Of String)
        wLista.AddRange(Enumerable.Cast(Of Object)(wRs.GetRows).Select(Function(item As Object) item.ToString()))
        Return ConcatenarTexto(wLista, wSeparador)
    End Function

    Public Function Forma_Cta(ByVal wCta As String) As String
        Dim qCta As String

        qCta = Mid(wCta, 2, 3) + "." + Mid(wCta, 5, 3) + "." + Mid(wCta, 8, 3) + "/" + Mid(wCta, 11, 2)

        Forma_Cta = qCta
    End Function

    Public Function Forma_Rut(ByVal wRut As String, ByVal wDig As String) As String
        Dim qRut As String

        qRut = Mid(wRut, 1, 2) + "." + Mid(wRut, 3, 3) + "." + Mid(wRut, 6, 3) + "-" + Mid(wRut, 10, 1)

        Forma_Rut = qRut
    End Function

    Public Function Formatea_Numero(ByVal wDato As Double, ByVal wLargo As Integer, Optional wCeros As Boolean = False) As String
        If wCeros Then
            Formatea_Numero = "                    "
        Else
            Formatea_Numero = "00000000000000000000"
        End If
        Formatea_Numero += Num(wDato)
        Formatea_Numero = Right(Formatea_Numero, wLargo)
    End Function

    Public Function Formatea_Fecha(ByVal wFecha As Date) As String
        Formatea_Fecha = Formatea_Numero(wFecha.Day, 2) + "/" + Formatea_Numero(wFecha.Month, 2) + "/" + Formatea_Numero(wFecha.Year, 4)
    End Function

    Public Function Formatea_Rut(ByVal wRut As String, Optional wModo As Integer = 0) As String
        'Formato Modo=0  12345678-9         Modo=1  12.345.678-9
        Formatea_Rut = Trim(wRut)
        Formatea_Rut = Replace(Formatea_Rut, ".", "")
        Formatea_Rut = Replace(Formatea_Rut, " ", "")
        Formatea_Rut = "000000000000" + Formatea_Rut
        Formatea_Rut = Right(Formatea_Rut, 10)
        If wModo <> 0 Then
            Formatea_Rut = Mid(Formatea_Rut, 1, 2) + "." + Mid(Formatea_Rut, 3, 3) + "." + Mid(Formatea_Rut, 6, 3) + "-" + Mid(Formatea_Rut, 10, 1)
        End If
    End Function

    Public Function Formato_Texto(ByVal wTexto As Object, ByVal wTipo As String, ByVal wLargo As Integer) As String
        Formato_Texto = ""
        If wTipo = "C" Then
            Formato_Texto = Mid(Trim(wTexto) + Space(1000), 1, wLargo)
        End If
        If wTipo = "N" Then
            Formato_Texto = Right("00000000000000000000" + Trim(Str(Val(wTexto))), wLargo)
        End If
    End Function

    Public Function Formatea_Caracteres(ByVal wTexto As String, ByVal wLargo As Integer) As String
        Dim Car As String, i As Integer

        Formatea_Caracteres = ""
        For i = 1 To Len(wTexto)
            Car = UCase(Mid(wTexto, i, 1))
            Select Case Car
                Case Car = "Ñ" : Car = "N"
                Case Car = "Á" : Car = "A"
                Case Car = "É" : Car = "E"
                Case Car = "Í" : Car = "I"
                Case Car = "Ó" : Car = "O"
                Case Car = "Ú" : Car = "U"
                Case Asc(Car) > 126
                    Car = ""
            End Select

            Formatea_Caracteres = Formatea_Caracteres + Car
        Next
        Formatea_Caracteres = Formatea_Caracteres + Space(200)
        Formatea_Caracteres = Left(Formatea_Caracteres, wLargo).Trim
    End Function

#End Region

#Region "VALIDACIONES"


    Public Sub ValidarDigitos(ByRef sender As Object, Optional ByVal wPosicionesDecimales As Integer = 3)
        If sender Is Nothing Then Exit Sub
        Dim wTextBox As TextBox = DirectCast(sender, TextBox)
        Trim(wTextBox.Text)
        If wTextBox.Text <> "" AndAlso Not wTextBox.Text = "0" Then
            Dim wValor As Double = Val(wTextBox.Text.Replace(",", ".")).ToString
            wValor.Validar(wPosicionesDecimales)
            wTextBox.Text = If(wValor = 0, "", wValor)
        End If
    End Sub

    Public Sub ValidarDigitos(ByRef e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub ValidarDigitosDecimal(ByRef e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "," Then
            e.Handled = False
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Function RutVacio(wRut As String) As Boolean
        If wRut.Trim = "" Or wRut = "00.000.000-0" Or wRut.ToString.Trim = ".   .   -" Or wRut = " .   .   - " Or wRut = " .   .   -" Or wRut = ".   .   - " Or wRut = "__.___.___-_" Then
            RutVacio = True
        Else
            RutVacio = False
        End If
    End Function

    Public Function ValidarRut(ByRef wRut As String) As Boolean
        Dim Final As Double, Resul As Double, Tot As Double, Dig As String
        Dim r1 As Integer, r2 As Integer, r3 As Integer, r4 As Integer, r5 As Integer, r6 As Integer, r7 As Integer, r8 As Integer

        r1 = Val(Mid(wRut, 1, 1)) * 3
        r2 = Val(Mid(wRut, 2, 1)) * 2
        r3 = Val(Mid(wRut, 4, 1)) * 7
        r4 = Val(Mid(wRut, 5, 1)) * 6
        r5 = Val(Mid(wRut, 6, 1)) * 5
        r6 = Val(Mid(wRut, 8, 1)) * 4
        r7 = Val(Mid(wRut, 9, 1)) * 3
        r8 = Val(Mid(wRut, 10, 1)) * 2
        Dig = UCase(Mid(wRut, 12, 1))

        Tot = r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8

        Resul = Tot Mod 11
        Final = 11 - Resul
        If Dig = "0" Then Dig = "11"
        If Dig = "K" Then Dig = "10"
        Dig = Val(Dig)

        If Final = Dig Then
            ValidarRut = True
        Else
            ValidarRut = False
        End If

    End Function

    Public Function ValidarCliente(ByVal wCliente As Double) As Boolean
        If Buscar("Clientes", "Cliente", wCliente) Then
            Cli = Swap
            Return True
        Else
            Return False
        End If
    End Function

#End Region

#Region "LOGÍSTICA"





    Public Function CorrelativoOla() As Double
        Dim wNum As Double
        Dim wTipoDoc As String = ""
        Dim OLA As Recordset

        Swap = SQL("SELECT TipoDoc FROM TipoDoc WHERE DescTipoDoc = 'Ola'")
        If Swap.RecordCount = 1 Then wTipoDoc = Swap.Fields("TipoDoc").Text

        OLA = SQL("SELECT TOP 1 * FROM Correlativos WHERE Documento = 'Ola' ORDER BY Id Desc")
        If OLA.RecordCount > 0 Then
            wNum = OLA.Fields("Numero").Value
        Else
            OLA.AddNew()
            OLA.Fields("TipoDoc").Value = wTipoDoc
            OLA.Fields("Documento").Value = "Ola"
        End If
        CorrelativoOla = wNum + 1
        OLA.Fields("Numero").Value = CorrelativoOla
        OLA.Update()
    End Function



    Public Function CorrelativoMovimiento() As Double
        Dim wNum As Double
        Dim wDato As Recordset
        wDato = SQL("SELECT TOP 1 * FROM MovGen Order by Movimiento Desc")
        If wDato.RecordCount > 0 Then
            wDato.MoveLast()
            wNum = wDato.Fields("Movimiento").Value
            CorrelativoMovimiento = wNum + 1
        Else
            CorrelativoMovimiento = wNum + 1
        End If
    End Function







#End Region

#Region "FUNCIONES FLEXGRID"

    <Extension()>
    Public Sub AgregarColumna(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wTituloColumna As String, ByVal wNombreColumna As String)
        xTabla.Cols.Count += 1
        xTabla.Cols(xTabla.Cols.Count - 1).Caption = wTituloColumna
        xTabla.Cols(xTabla.Cols.Count - 1).Name = wNombreColumna
        xTabla.Cols(xTabla.Cols.Count - 1).Width = 10
    End Sub

    <Extension()>
    Public Sub AjustarColumnas(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid)
        For col As Integer = 0 To xTabla.Cols.Count - 1

            If xTabla.Cols(col).Width > 0 Then
                xTabla.AutoSizeCol(col)
            Else
                xTabla.Cols(col).Width = 0
            End If
        Next col
    End Sub


    Public Sub CopiarSeleccion(ByRef xTabla As C1.Win.C1FlexGrid.C1FlexGrid)
        Dim wClip, wRow, wData As String
        Dim wSel = xTabla.Selection
        wClip = ""
        If wSel.TopRow < 1 Or wSel.BottomRow < 1 Then Exit Sub

        For r As Integer = wSel.TopRow To wSel.BottomRow
            wRow = ""
            For c As Integer = wSel.LeftCol To wSel.RightCol
                If xTabla.Cols(c).Width = 0 Then Continue For
                If xTabla.GetData(r, c) Is Nothing Then
                    Continue For
                End If
                wData = xTabla.GetData(r, c).ToString
                If wData = "False" Or wData = "True" Then
                    Continue For
                End If
                wRow += wData + vbTab
            Next
            wClip += wRow.Trim + vbCrLf
        Next
        Clipboard.SetText(wClip)
    End Sub

    Public Sub MostrarMenuCopiar(ByRef xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByRef wUbicacion As Point, ByRef mMenu As ContextMenuStrip, ByRef bCopiar As ToolStripMenuItem)
        Dim wData As String
        Dim wHit As C1.Win.C1FlexGrid.HitTestInfo = xTabla.HitTest(wUbicacion)
        xTabla.Row = wHit.Row
        xTabla.Col = wHit.Column

        If xTabla.Row < 1 Then Exit Sub
        If xTabla.GetData(xTabla.Row, xTabla.Col) Is Nothing Then
            wData = ""
        Else
            wData = xTabla.GetData(xTabla.Row, xTabla.Col).ToString.Trim
            If wData = "True" Or wData = "False" Then
                wData = ""
            End If
        End If
        If wData <> "" Then
            bCopiar.Text = "Copiar " & wData.Trim.Substring(0, If(wData.Length > 22, 22, wData.Length))
            bCopiar.Tag = wData.Trim
            mMenu.Show(xTabla, wHit.Point)
        End If
    End Sub

    <Extension>
    Public Sub QuitarFilasValorIgual(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wColumna As Integer, ByVal wValor As Object)
        Dim wValorCelda As String
        If wColumna >= xTabla.Cols.Count Then
            Exit Sub
        End If
        For wFila As Integer = xTabla.Rows.Count - 1 To 1 Step -1
            If xTabla.GetData(wFila, wColumna) Is Nothing Then
                wValorCelda = ""
            Else
                wValorCelda = xTabla.GetData(wFila, wColumna).ToString.Trim
            End If
            If wValorCelda = wValor.ToString.Trim Then xTabla.RemoveItem(wFila)
        Next wFila
    End Sub

    <Extension>
    Public Function ContarFilasValorIgual(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wColumna As Integer, ByVal wValor As Object) As Double
        Dim wCantidad As Double
        Dim wValorCelda As String

        If wColumna >= xTabla.Cols.Count Then
            Return -1
        End If
        For fila As Integer = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(fila, wColumna) Is Nothing Then
                wValorCelda = ""
            Else
                wValorCelda = xTabla.GetData(fila, wColumna).ToString.Trim
            End If
            If wValorCelda = wValor.ToString.Trim Then wCantidad += 1
        Next fila
        Return wCantidad
    End Function




    <Extension>
    Public Function SumarValoresColumna(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wColumna As Integer) As Double
        Dim wValorCelda, wSuma As Double

        If wColumna >= xTabla.Cols.Count Then
            Return 0
        End If
        For fila As Integer = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(fila, wColumna) Is Nothing Then
                wValorCelda = 0
            Else
                wValorCelda = Val(xTabla.GetData(fila, wColumna).ToString)
            End If
            wSuma += wValorCelda
        Next fila

        Return wSuma
    End Function

    <Extension>
    Public Function CuentaValoresDiferentes(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wColumna As Integer) As Integer
        Dim wListaValores As New List(Of String)
        If wColumna >= xTabla.Cols.Count Then
            Return -1
        End If
        For fila As Integer = 1 To xTabla.Rows.Count - 1
            Dim valor = ""

            If xTabla.GetData(fila, wColumna) IsNot Nothing Then
                valor = xTabla.GetData(fila, wColumna).ToString.Trim
            End If

            If Not wListaValores.Contains(valor) Then
                wListaValores.Add(valor)
            End If
        Next fila
        Return wListaValores.Count
    End Function


    <Extension>
    Public Function ValoresDiferentes(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wColumna As Integer) As List(Of String)
        Dim wValorCelda As String
        Dim wListaValores As New List(Of String)

        If wColumna >= xTabla.Cols.Count Then
            Return wListaValores
        End If
        For fila As Integer = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(fila, wColumna) Is Nothing Then
                wValorCelda = ""
            Else
                wValorCelda = xTabla.GetData(fila, wColumna).ToString.Trim
            End If
            If Not wListaValores.Contains(wValorCelda) Then
                wListaValores.Add(wValorCelda)
            End If
        Next fila
        Return wListaValores

    End Function

    <Extension>
    Public Function ToDecimal(wLista As List(Of String)) As List(Of Decimal)
        Dim wListaDec As New List(Of Decimal)
        For Each wItem In wLista
            wListaDec.Add(Val(wItem))
        Next
        Return wListaDec
    End Function

    <Extension>
    Public Function ToDouble(wLista As List(Of String)) As List(Of Double)
        Dim wListaDec As New List(Of Double)
        For Each wItem In wLista
            wListaDec.Add(Val(wItem))
        Next
        Return wListaDec
    End Function



    <Extension>
    Public Function ColumnaContieneValor(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wColumna As Integer, ByVal wValor As Object) As Boolean
        For wFila As Integer = 1 To xTabla.Rows.Count - 1
            Dim xValor = xTabla.GetData(wFila, wColumna).ToString
            If xValor = wValor.ToString Then Return True
        Next wFila
        Return False
    End Function


    <Extension>
    Public Function ContieneValoresIguales(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wColumna As Integer, ByVal wValor As Object) As Boolean
        If xTabla.CuentaValoresDiferentes(wColumna) = 1 Then
            If xTabla.GetData(1, wColumna) = wValor Then Return True
        End If
        Return False
    End Function

    <Extension>
    Public Function IndiceColumna(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wNombreColumna As String)
        For Each wColumna As C1.Win.C1FlexGrid.Column In xTabla.Cols
            If wColumna.Caption.Equals(wNombreColumna) Then
                Return wColumna.Index
            End If
        Next
        Return -1
    End Function

    <Extension()>
    Public Function EsCeldaTipo(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, wFila As Integer, wCol As Integer, ByVal wTipo As Type)
        Dim estilo = xTabla.GetCellStyle(wFila, wCol)
        Try
            If estilo.DataType Is wTipo Then Return True
        Catch ex As NullReferenceException
            Return False
        End Try
        Return False
    End Function

    <Extension()>
    Public Sub HabilitarCheck(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wFila As Integer, ByVal wCol As Integer)
        Dim estilo As C1.Win.C1FlexGrid.CellStyle
        estilo = xTabla.Styles.Add("Check_" & wFila.ToString)
        estilo.DataType = GetType(Boolean)
        xTabla.SetCellStyle(wFila, wCol, estilo)
    End Sub

    <Extension()>
    Public Sub DeshabilitarCheck(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wFila As Integer, ByVal wCol As Integer)
        Dim estilo As C1.Win.C1FlexGrid.CellStyle
        estilo = xTabla.Styles.Add("Check_" & wFila.ToString)
        estilo.DataType = GetType(String)
        xTabla.SetCellStyle(wFila, wCol, estilo)
        xTabla.SetData(wFila, wCol, "")
    End Sub

    <Extension()>
    Public Sub FuenteBordeCelda(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wFila As Integer, ByVal wCol As Integer, ByVal wFondo As Color, ByVal wBorde As Color, ByVal wColor As Color, ByVal wBold As Boolean)
        Dim fuente As C1.Win.C1FlexGrid.CellStyle
        fuente = xTabla.Styles.Add("CellFontBorder_" & wColor.ToString & wFila)
        fuente.Font = New Font(fuente.Font.FontFamily, fuente.Font.Size, If(wBold, FontStyle.Bold, FontStyle.Regular))
        fuente.ForeColor = wColor
        fuente.BackColor = wFondo
        fuente.Border.Color = wBorde
        fuente.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Raised
        xTabla.SetCellStyle(wFila, wCol, fuente)
    End Sub

    <Extension()>
    Public Sub FuenteCelda(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wFila As Integer, ByVal wFondo As Color, ByVal wColor As Color, ByVal wBold As Boolean)
        Dim fuente As C1.Win.C1FlexGrid.CellStyle
        fuente = xTabla.Styles.Add("CellFont_" & wColor.ToString)
        fuente.Font = New Font(fuente.Font.FontFamily, fuente.Font.Size, If(wBold, FontStyle.Bold, FontStyle.Regular))
        fuente.ForeColor = wColor
        fuente.BackColor = wFondo

        For wCol As Integer = 0 To xTabla.Cols.Count - 1
            xTabla.SetCellStyle(wFila, wCol, fuente)
        Next

    End Sub

    <Extension()>
    Public Sub FuenteCelda(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wFila As Integer, ByVal wFondo As Color, ByVal wColor As Color)
        Dim fuente As C1.Win.C1FlexGrid.CellStyle
        fuente = xTabla.Styles.Add("CellFont_" & wColor.ToString)
        fuente.Font = New Font(fuente.Font.FontFamily, fuente.Font.Size, If(fuente.Font.Bold, FontStyle.Bold, FontStyle.Regular))
        fuente.ForeColor = wColor
        fuente.BackColor = wFondo

        For wCol As Integer = 0 To xTabla.Cols.Count - 1
            xTabla.SetCellStyle(wFila, wCol, fuente)
        Next

    End Sub

    <Extension()>
    Public Sub FuenteCelda(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wFila As Integer, ByVal wCol As Integer, ByVal wFondo As Color, ByVal wColor As Color, ByVal wBold As Boolean)
        Dim fuente As C1.Win.C1FlexGrid.CellStyle
        fuente = xTabla.Styles.Add("CellFont_" & wColor.ToString)
        fuente.Font = New Font(fuente.Font.FontFamily, fuente.Font.Size, If(wBold, FontStyle.Bold, FontStyle.Regular))
        fuente.ForeColor = wColor
        fuente.BackColor = wFondo
        xTabla.SetCellStyle(wFila, wCol, fuente)
    End Sub

    <Extension()>
    Public Sub FuenteCelda(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wFila As Integer, ByVal wCol As Integer, ByVal wFondo As Color, ByVal wColor As Color, ByVal wFont As FontFamily, ByVal wSize As Single, ByVal wBold As Boolean)
        Dim fuente As C1.Win.C1FlexGrid.CellStyle
        fuente = xTabla.Styles.Add("CellFont_" & wColor.ToString)
        fuente.Font = New Font(wFont, wSize, If(wBold, FontStyle.Bold, FontStyle.Regular))
        fuente.ForeColor = wColor
        fuente.BackColor = wFondo
        xTabla.SetCellStyle(wFila, wCol, fuente)
    End Sub

    <Extension()>
    Public Sub FondoCelda(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wFila As Integer, ByVal wCol As Integer, ByVal wFondo As Color)
        Dim fondo As C1.Win.C1FlexGrid.CellStyle
        fondo = xTabla.Styles.Add("CellBackColor_" & wFondo.ToString)
        fondo.BackColor = wFondo
        xTabla.SetCellStyle(wFila, wCol, fondo)
    End Sub

    <Extension()>
    Public Sub FondoCelda(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wFila As Integer, ByVal wFondo As Color)
        Dim fondo As C1.Win.C1FlexGrid.CellStyle
        fondo = xTabla.Styles.Add("CellBackColor_" & wFondo.ToString)
        fondo.BackColor = wFondo
        For col As Integer = 0 To xTabla.Cols.Count - 1
            xTabla.SetCellStyle(wFila, col, fondo)
        Next col
    End Sub

    <Extension()>
    Public Function BuscarFila(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, wTexto As String, wColumna As Integer, Optional wInicio As Integer = 0) As Integer

        For wFila As Integer = wInicio To xTabla.Rows.Count - 1
            If xTabla.GetData(wFila, wColumna).ToString.ToLower.QuitarTildes.Contains(wTexto.ToLower.QuitarTildes) Then
                Return wFila
                Exit Function
            End If
        Next
        Return -1
    End Function

#End Region

#Region "EXTENSION"

    <Extension()>
    Public Function Validar(ByRef wValor As Double, Optional ByVal wPosicionesDecimales As Integer = 3)
        Try
            wValor = Decimal.Round(wValor, wPosicionesDecimales, MidpointRounding.AwayFromZero)
            If wValor > MaxDouble Then wValor = MaxDouble
        Catch ex As OverflowException
            wValor = MaxDouble
        End Try
        Return wValor
    End Function

    <Extension()>
    Public Function Truncate(ByRef wTexto As String, wLargoMaximo As Integer) As String
        If String.IsNullOrEmpty(wTexto) Then
            wTexto = ""
        End If
        wTexto = If(wTexto.Length <= wLargoMaximo, wTexto, wTexto.Substring(0, wLargoMaximo))
        Return wTexto
    End Function

    <Extension()>
    Public Function Text(ByVal field As ADODB.Field) As String
        Try
            Return field.Value.ToString.Trim
        Catch ex As Exception
            Return ""
        End Try
    End Function

    <Extension()>
    Public Sub NextControl(wBase As Control, wControl As Object)
        wBase.SelectNextControl(wControl, True, True, True, True)
    End Sub

#End Region

#Region "OTROS - REVISAR"


    Public Function BuscarItem(ByVal Parent As MenuStrip, wNombre As String) As ToolStripMenuItem
        Dim wItem As ToolStripMenuItem
        Dim wSubItem As ToolStripMenuItem
        For Each wItem In Parent.Items.OfType(Of ToolStripMenuItem)

            If TypeOf wItem IsNot ToolStripMenuItem Then Continue For

            If wItem.Name = wNombre Then
                Return wItem
            End If
            If wItem.HasDropDownItems Then
                wSubItem = BuscarItem(wItem, wNombre)
                If wSubItem IsNot Nothing Then Return wSubItem
            End If
        Next
        Return Nothing
    End Function

    Public Function BuscarItem(ByVal Parent As ToolStripMenuItem, wNombre As String) As ToolStripMenuItem
        Dim wItem As ToolStripMenuItem
        Dim wSubItem As ToolStripMenuItem
        For Each wItem In Parent.DropDownItems.OfType(Of ToolStripMenuItem)

            If TypeOf wItem IsNot ToolStripMenuItem Then Continue For

            If wItem.Name = wNombre Then
                Return wItem
            End If
            If wItem.HasDropDownItems Then
                wSubItem = BuscarItem(wItem, wNombre)
                If wSubItem IsNot Nothing Then Return wSubItem
            End If
        Next
        Return Nothing
    End Function

    <Extension()>
    Function QuitarTildes(ByVal wTexto As String) As String

        wTexto = Replace(wTexto, "Á", "A")
        wTexto = Replace(wTexto, "É", "E")
        wTexto = Replace(wTexto, "Í", "I")
        wTexto = Replace(wTexto, "Ó", "O")
        wTexto = Replace(wTexto, "Ú", "U")

        wTexto = Replace(wTexto, "á", "a")
        wTexto = Replace(wTexto, "é", "e")
        wTexto = Replace(wTexto, "í", "i")
        wTexto = Replace(wTexto, "ó", "o")
        wTexto = Replace(wTexto, "ú", "u")

        If wTexto Is Nothing Then wTexto = ""
        Return wTexto
    End Function

    Function Busca_Directorio(ByRef wDirectorio As String) As Boolean
        Dim fs As Object
        'Verifica si un directorio existe
        fs = CreateObject("Scripting.FileSystemObject")
        Busca_Directorio = fs.FolderExists(wDirectorio)
    End Function

    Function Busca_Archivo(ByRef wArchivo As String) As Boolean
        Dim fs As Object
        'Verifica si un archivo existe
        fs = CreateObject("Scripting.FileSystemObject")
        Busca_Archivo = fs.fileExists(wArchivo)
    End Function

    Public Function BuscaBarra(qDato As Object) As String
        On Error Resume Next
        Dim wDato As String = ""
        Dim vPeso As Integer

        If String.IsNullOrEmpty(qDato) Then
            BuscaBarra = ""
            Exit Function
        End If

        vPeso = 0
        wDato = Trim(qDato)
        If Trim(wDato) = "" Then
            BuscaBarra = ""
            Exit Function
        End If

        DescripcionArticulo = ""
        UnidadMedida = ""


        ' Buscar por Articulo
        If Buscar("Articulos", "Articulo", Trim(wDato), "Articulo,Descripcion,Unidad", "") Then
            BuscaBarra = Trim(Swap.Fields("Articulo").Value)
            DescripcionArticulo = Trim(Swap.Fields("Descripcion").Value)
            If Not String.IsNullOrEmpty(Swap.Fields("Unidad").Value) Then
                UnidadMedida = Trim(Swap.Fields("Unidad").Value)
            End If

            gCantidad = 1
            TipoEncontrado = "Articulo"
        Else
            ' Buscar por Codigos Pesables
            If (Mid(wDato, 1, 2) = "24" Or Mid(wDato, 1, 2) = "25") And Len(wDato) = 13 Then
                If Val(Mid(wDato, 3, 5)) > 0 Then
                    If Buscar("Articulos", "Articulo", Val(Mid(wDato, 3, 5)), "Articulo,Descripcion,Unidad", "") Then
                        BuscaBarra = Trim(Swap.Fields("Articulo").Value)
                        DescripcionArticulo = Trim(Swap.Fields("Descripcion").Value)
                        UnidadMedida = Trim(Swap.Fields("Unidad").Value)
                        TipoEncontrado = "Corto"
                        gCantidad = Trim(Mid(wDato, 8, 2)) + "," + Trim(Mid(wDato, 10, 3))
                    Else
                        BuscaBarra = ""
                    End If
                End If
            Else
                ' Buscar en Codigos Anexos
                Bar = SQL("SELECT * FROM Barras WHERE Barra='" + Trim(wDato) + "'")
                If Bar.RecordCount > 0 Then
                    wDato = Bar.Fields("Articulo").Value.ToString.Trim
                    If Buscar("Articulos", "Articulo", Trim(wDato), "Articulo,Descripcion,Unidad", "") Then
                        BuscaBarra = Trim(Swap.Fields("Articulo").Value)
                        DescripcionArticulo = Trim(Swap.Fields("Descripcion").Value)
                        UnidadMedida = Trim(Swap.Fields("Unidad").Value)
                        gCantidad = Swap.Fields("Unidades").Value
                        TipoEncontrado = "Barra"
                    Else
                        BuscaBarra = ""
                    End If
                Else
                    BuscaBarra = ""
                End If
            End If
        End If
    End Function




#End Region

    Sub Parametrizar_Sistema()
        P_SISTEMA = "SisVen"
        P_SISTEMA = "SisVen"
        P_VERSION = "0.00"
        P_EMPRESA = "Wikets"
        P_CLAVE = ""
        G_IVA = 19

        Try
            Par = SQL("Select Top 1 * from Parametros")

            P_SISTEMA = Par.Fields("Sistema").Value.ToString.Trim
            P_NOMBRE = "SisVen"
            P_VERSION = Version
            P_EMPRESA = Par.Fields("Empresa").Value
            P_CLAVE = Par.Fields("Clave").Value
            G_IVA = Par("IVA").Value

        Catch ex As Exception
            MsgError("Error al parametrizar sistema")
        End Try
    End Sub

    Function Llena0(xNume, xLar) As String 'FUERA!!!!!!???????? 
        Dim wNum As String, Lar As Integer

        If IsDBNull(xNume) Then
            xNume = 0
        End If
        wNum = "00000000000000000000"
        Lar = Len(Trim(xNume))
        wNum = wNum + Trim(xNume)
        Lar = Len(wNum)
        Llena0 = Mid(wNum, Lar - xLar + 1, xLar)
    End Function

    Public Function GenerarTrackID() As String

        Return "TXT" &
                Now.Year &
                Now.Month.ToString().PadLeft(2, "0") &
                Now.Day.ToString().PadLeft(2, "0") &
                Now.Hour.ToString().PadLeft(2, "0") &
                Now.Minute.ToString().PadLeft(2, "0") &
                Now.Second.ToString().PadLeft(2, "0")
    End Function

    Public Function RoundedRectangle(r As Rectangle, radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        Dim d As Integer = radius * 2

        path.AddLine(r.Left + d, r.Top, r.Right - d, r.Top)
        path.AddArc(Rectangle.FromLTRB(r.Right - d, r.Top, r.Right, r.Top + d), -90, 90)
        path.AddLine(r.Right, r.Top + d, r.Right, r.Bottom - d)
        path.AddArc(Rectangle.FromLTRB(r.Right - d, r.Bottom - d, r.Right, r.Bottom), 0, 90)
        path.AddLine(r.Right - d, r.Bottom, r.Left + d, r.Bottom)
        path.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - d, r.Left + d, r.Bottom), 90, 90)
        path.AddLine(r.Left, r.Bottom - d, r.Left, r.Top + d)
        path.AddArc(Rectangle.FromLTRB(r.Left, r.Top, r.Left + d, r.Top + d), 180, 90)
        path.CloseFigure()

        Return path

    End Function

    Public Function Validar_Stocks(wBodega As Integer, wArticulo As Double, wCantidad As Double) As Boolean
        If wBodega = 0 Or wArticulo = 0 Or wCantidad = 0 Then
            Return True
        End If
        Stk = SQL("Select * from Stocks where Bodega=" + Num(wBodega) + " and Articulo=" + Num(wArticulo))
        If Stk.RecordCount = 0 Then
            Return False
        End If
        If Stk.Fields("Stock").Value >= wCantidad Then
            Return True
        End If
        Return False
    End Function

    Public Function ObtenerListado(wTabla As String, wCampo As String, Optional wFiltro As String = " 1=1 ") As String()

        Ciu = SQL("SET NOCOUNT ON DECLARE @Valor VarChar(MAX) = ''     " &
                "SELECT @Valor =  " &
                "CASE WHEN @Valor = '' " &
                "THEN COALESCE(rtrim(" & wCampo & "), '') " &
                "ELSE @Valor + COALESCE('~' + rtrim(" & wCampo & "), '') " &
                "END " &
                "FROM (SELECT Distinct " & wCampo & " FROM " & wTabla & " WHERE " & wFiltro & " ) Tab " &
                "SELECT @Valor as Valor")

        Return Ciu.GetString.Split("~").ToList().Select(Function(x) x.Trim).OrderBy(Function(x) x).ToArray

    End Function


    Public Function ObtenerListado(wTabla As String, wCampo1 As String, wCampo2 As String, wCaracter As String, Optional wFiltro As String = " 1=1 ") As String()
        Dim wCampo = wCampo1 & " + ' " & wCaracter & " ' + " & wCampo2

        Paso = SQL("SET NOCOUNT ON DECLARE @Valor VarChar(MAX) = ''     " &
                "SELECT @Valor =  " &
                "CASE WHEN @Valor = '' " &
                "THEN COALESCE(rtrim(" & wCampo1 & "), '') " &
                "ELSE @Valor + COALESCE(',' + rtrim(" & wCampo1 & "), '') " &
                "END " &
                "FROM (SELECT Distinct CAST(" & wCampo1 & " AS VARCHAR) " & " + ' " & wCaracter & " ' + CAST(" & wCampo2 & " AS VARCHAR) AS " & wCampo1 &
                " FROM " & wTabla & " WHERE " & wFiltro & " ) Tab " &
                "SELECT @Valor as Valor")

        Return Paso.GetString.Split(",").ToList().Select(Function(x) x.Trim).OrderBy(Function(x) x).ToArray
    End Function

    <Extension()>
    Public Function SelectItem(ByRef wCombobox As ComboBox, wTabla As String, wCampo As String, wValor As String, wItem As String) As Boolean
        Dim VAL = SQL("SELECT TOP 1 " & wItem & " AS Texto FROM " & wTabla & " WHERE " & wCampo & " = '" & wValor & "'")
        If VAL.RecordCount > 0 Then
            wCombobox.SelectedItem = VAL.Fields("Texto").Text
            Return True
        Else
            wCombobox.SelectedIndex = -1
            Return False
        End If
    End Function

    <Extension()>
    Public Function GetValue(ByRef wCombobox As ComboBox, wTabla As String, wCampo As String, wCampoValor As String) As String
        Dim VAL = SQL("SELECT TOP 1 " & wCampoValor & " AS Texto FROM " & wTabla & " WHERE " & wCampo & " = '" & wCombobox.Text.Trim & "'")
        If VAL.RecordCount > 0 Then
            Return VAL.Fields("Texto").Text
        Else
            Return ""
        End If
    End Function
    <Extension()>
    Public Sub AgregarItems(ByRef wCombobox As ComboBox, wTabla As String, wCampo As String, Optional wFiltro As String = "1=1")
        Dim wLista = ObtenerListado(wTabla, wCampo, wFiltro)
        For Each wItem In wLista
            wCombobox.Items.Add(wItem.Trim)
        Next
    End Sub

    <Extension()>
    Public Function SelectItem(ByRef wTextBox As TextBox, wTabla As String, wCampo As String, wValor As String, wText As String)
        Dim VAL = SQL("SELECT TOP 1 " & wText & " AS Texto FROM " & wTabla & " WHERE " & wCampo & " = '" & wValor & "'")
        If VAL.RecordCount > 0 Then
            wTextBox.Text = VAL.Fields("Texto").Text
            Return True
        Else
            wTextBox.Clear()
            Return False
        End If
    End Function

    <Extension()>
    Public Sub LoadItems(ByRef wCombobox As ComboBox, wTabla As String, wCampo As String, Optional wFiltro As String = "1=1")
        wCombobox.Items.Clear()
        wCombobox.Items.Add("")
        Dim wLista = ObtenerListado(wTabla, wCampo, wFiltro)
        For Each wItem In wLista
            wCombobox.Items.Add(wItem.Trim)
        Next
    End Sub

    <Extension()>
    Public Sub LoadItems(ByRef wCombobox As ComboBox, wTabla As String, wCampo1 As String, wCampo2 As String, wCaracter As String, Optional wFiltro As String = "1=1")
        wCombobox.Items.Clear()
        Dim wLista = ObtenerListado(wTabla, wCampo1, wCampo2, wCaracter, wFiltro)
        For Each wItem In wLista
            wCombobox.Items.Add(wItem.Trim)
        Next
    End Sub

    <Extension>
    Public Sub LoadCombobox(ByRef wCombobox As ComboBox, wTabla As String, wCampoBusqueda As String, wValorBuscado As String, Optional wFiltro As String = Nothing, Optional wOrden As String = Nothing)
        Dim Lista As New Dictionary(Of String, String)
        Dim VAL = SQL("SELECT " & wCampoBusqueda & "," & wValorBuscado & " FROM " & wTabla & " " & wFiltro & "" & wOrden)

        Lista.Add(W_SELECCIONAR, 0)

        While Not VAL.EOF
            Lista.Add(VAL.Fields(wValorBuscado).Text.Trim, VAL.Fields(wCampoBusqueda).Text.Trim)
            VAL.MoveNext()
        End While

        wCombobox.ValueMember = "Value"
        wCombobox.DisplayMember = "Key"
        wCombobox.DataSource = Lista.ToArray

        If Trim(UCase(wTabla)) = "LOCALES" Then
            If gMonoLocal Then
                VAL.MoveFirst()
                wCombobox.Text = VAL("NombreLocal").Value.ToString.Trim
            End If
        End If

    End Sub
    <Extension>
    Public Sub LoadComboGrilla(ByRef wCombobox As ComboBox, wtabla As String, wDisplayMenber As String, wValueMenber As String, Optional wFiltro As String = Nothing)
        Dim Lista As New Dictionary(Of String, String)
        Dim VAL = SQL("SELECT " & wDisplayMenber & "," & wValueMenber & " FROM " & wtabla & " " & wFiltro & "")

        Try
            While Not VAL.EOF
                Lista.Add(VAL.Fields(wValueMenber).Text.Trim, VAL.Fields(wDisplayMenber).Text.Trim)
                VAL.MoveNext()
            End While
        Catch ex As Exception
        End Try

        wCombobox.ValueMember = "Value"
        wCombobox.DisplayMember = "Key"
        wCombobox.DataSource = Lista.ToArray
    End Sub
    <Extension>
    Public Sub AñosMes(ByVal wCombobox As ComboBox, ByVal wTipo As String)
        Dim wFila = 1
        Dim wLista As New Dictionary(Of String, String)
        wLista.Add(W_SELECCIONAR, 0)

        If wTipo = "A" Then
            wLista.Add(Year(Now()), 1)
            wLista.Add(Year(Now()) - 1, 2)
        ElseIf wTipo = "M" Then
            Dim datetimeFormat = Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat
            For Each wMes In datetimeFormat.MonthNames()
                If wFila = 13 Then Exit For
                wLista.Add(wMes.ToUpper, wFila)
                wFila += 1
            Next
        End If

        wCombobox.ValueMember = "Value"
        wCombobox.DisplayMember = "Key"
        wCombobox.DataSource = wLista.ToArray
    End Sub
    Public Function ValidarCombo(wCombobox As ComboBox) As Boolean
        If wCombobox.Text <> W_SELECCIONAR And wCombobox.Text <> "" Then
            Return True
        End If
        If wCombobox.Items.Count = 0 Then
            Return False
        End If
        wCombobox.SelectedIndex = 0
        Return False
    End Function
    Public Sub DrawRoundedRectangle(graphics As Graphics, rectangle As Rectangle, pen As Pen, radius As Integer)
        If graphics Is Nothing Then
            Throw New ArgumentNullException("graphics")
        End If

        Dim mode As Drawing2D.SmoothingMode = graphics.SmoothingMode
        graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Using path As Drawing2D.GraphicsPath = RoundedRectangle(rectangle, radius)
            graphics.DrawPath(pen, path)
        End Using
        graphics.SmoothingMode = mode
    End Sub
    <Extension()>
    Public Sub NextControl(ByVal wOrigen As KeyPressEventArgs, wDestino As Control)
        If wOrigen.KeyChar = vbCr Then
            wDestino.Focus()
        End If
    End Sub
    <Extension>
    Public Sub NextControl(ByRef WOrigen As KeyEventArgs, ByRef WDestino As Control)
        If WOrigen.KeyCode = Keys.Enter Then
            WDestino.Focus()
        End If
    End Sub

    Public Function SiguienteCorrelativo(ByVal wTabla As String) As Double
        Dim Cor = SQL("SELECT (IDENT_CURRENT('" & wTabla & "') + IDENT_INCR('" & wTabla & "')) AS Correlativo")
        If Cor.RecordCount > 0 Then
            Return Cor.Fields("CORRELATIVO").Value
        Else
            Return 0
        End If
    End Function
    <Extension>
    Public Function indiceNombreColumna(ByVal xTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wNombreColumna As String)
        For Each wColumna As C1.Win.C1FlexGrid.Column In xTabla.Cols
            If wColumna.Name.Equals(wNombreColumna) Then
                Return wColumna.Index
            End If
        Next
        Return -1
    End Function
    Function SQLEscalar(ByRef wString As String, Optional wSoloConsulta As Boolean = False) As String
        Dim wSql As New Recordset
        SQL_QUERY = wString

        Try

ReintentoInterbloqueo:

            Try
                If wSoloConsulta Then
                    miBd.CursorLocation = CursorLocationEnum.adUseClient
                    'miBd.CursorLocation = CursorLocationEnum.adUseServer
                    wSql.Open(wString, miBd, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                Else
                    miBd.CursorLocation = CursorLocationEnum.adUseServer
                    wSql.Open(wString, miBd, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
                End If
                ReintentosInterbloqueo = 0
            Catch ex As Exception
                ReintentosInterbloqueo += 1
                If ReintentosInterbloqueo = 3 Then
                    MsgError("Hubo un error de interbloqueo o de sintaxis en una consulta. Se abortará la operación.")

                    End
                End If
                Abrir()
                Thread.Sleep(50)
                GoTo ReintentoInterbloqueo
            End Try

            SQLEscalar = ""

            If wSql.RecordCount > 0 Then
                SQLEscalar = wSql.Fields(0).Value
            End If

        Catch Err As Exception
            If Msg_Cancela("Error en Consulta SQL:" + vbCrLf + vbCrLf + wString + vbCrLf + " Tipo Error:" + Err.Message.ToString + vbCrLf + "¿Desea Continuar?") Then
                If Pregunta("¿Desea intentar reestablecer la conexión?") Then
                    Abrir()
                    Return SQLEscalar(wString)
                Else
                    SQLEscalar = Nothing
                    Throw
                End If
            Else
                End
            End If
        End Try
    End Function
    Public Function ValidarEliminar(ByVal wCampo As String, ByVal wClave As String, ByVal wTabla As String) As Boolean

        Dim tablas = SQL("SELECT  sysobjects.name AS table_name FROM sysobjects INNER JOIN syscolumns ON sysobjects.id = syscolumns.id " &
                         "INNER JOIN systypes ON syscolumns.xtype = systypes.xtype WHERE (sysobjects.xtype = 'U')  and " &
                         "(UPPER(syscolumns.name) = upper('" & wCampo & "'))")

        While Not tablas.EOF
            If tablas.Fields("table_name").Text <> wTabla Then
                Dim val = SQL("SELECT " & wCampo & " FROM " & tablas.Fields("table_name").Text & " WHERE " & wCampo & " = '" & wClave & "'")
                If val.RecordCount > 0 Then
                    Return True
                    Exit Function
                End If
            End If
            tablas.MoveNext()
        End While
        Return False
    End Function

    Private ReadOnly onValidating As MethodInfo = GetType(Control).GetMethod("OnValidating", BindingFlags.Instance Or BindingFlags.NonPublic)
    Private ReadOnly onValidated As MethodInfo = GetType(Control).GetMethod("OnValidated", BindingFlags.Instance Or BindingFlags.NonPublic)
    Public Property ConfigurationManager As Object

    <System.Runtime.CompilerServices.Extension>
    Public Function Validate(control As Control) As Boolean
        Dim e As New CancelEventArgs()
        onValidating.Invoke(control, New Object() {e})
        If e.Cancel Then
            Return False
        End If
        onValidated.Invoke(control, New Object() {EventArgs.Empty})
        Return True
    End Function
    Public Function ImagenArray(ByVal wImagen As Image) As Array
        Dim msQr As New MemoryStream
        Dim arrQr() As Byte
        wImagen.Save(msQr, wImagen.RawFormat)
        arrQr = msQr.GetBuffer
        Return arrQr
    End Function
    Public Function ArrayImagen(ByVal wArray As Array) As Image
        Dim MatrizImagen() As Byte = CType(wArray, Byte())
        Dim ImagenMemoria As New IO.MemoryStream(MatrizImagen)
        Return Image.FromStream(ImagenMemoria)
        'Imagen.Image = Image.FromStream(ImagenMemoria)
    End Function

    Public Function PoneCorr(cLocal As Integer, cPOS As Integer, cTipoDoc As String) As Double
        Cor = SQL("Select * from Correlativos where Local = " + Num(cLocal) + " and Caja = " + Num(cPOS) + " and TipoDoc = '" + cTipoDoc + "'")
        If Cor.RecordCount = 0 Then
            Cor.AddNew()
            Cor("Local").Value = cLocal
            Cor("Caja").Value = cPOS
            Cor("TipoDoc").Value = cTipoDoc
            Cor("Correlativo").Value = 1
            Cor.Update()
            PoneCorr = 1
        Else
            PoneCorr = Cor("Correlativo").Value
            Cor("Correlativo").Value = Cor("Correlativo").Value + 1
            Cor.Update()
        End If
    End Function

    Public Function Correlativo(wModo As Integer, cLocal As Integer, cTipoDoc As String, wFecha As Date, Optional cCaja As Integer = 0, Optional wMensaje As Boolean = False) As Double
        'Modos: 0=Consulta un correlativo,  1=Consulta y setea un Correlativo
        Correlativo = 0
        Cor = SQL("Select * from Correlativos where Local = " + Num(cLocal) + " and TipoDoc = '" + cTipoDoc + "' and Caja = " + Num(cCaja))
        If Cor.RecordCount = 0 Then
            If wMensaje Then
                MsgError("No existe correlativo para" + vbCrLf + "Local: " + Num(cLocal) + vbCrLf + "Documento: " + cTipoDoc)
            End If
            Exit Function
        Else
            If CDate(wFecha) < CDate(Cor.Fields("FechaCAF").Value) Then
                If wMensaje Then
                    MsgError("Fecha del Documento fuera del rango permitido en CAF")
                End If
                Exit Function
            End If
            If Cor("Correlativo").Value < Cor.Fields("Inicial").Value Or Cor("Correlativo").Value > Cor.Fields("Final").Value Then
                If wMensaje Then
                    MsgError("Correlativo Fuera de Rango" + vbCrLf + "Local: " + Num(cLocal) + vbCrLf + "Documento: " + cTipoDoc)
                End If
                Exit Function
            End If
            Correlativo = Cor("Correlativo").Value
            If wModo = 1 Then
                Cor("Correlativo").Value = Cor("Correlativo").Value + 1
                Cor.Update()
            End If
        End If
    End Function
    Public Function SacaUltimo(ByVal wTabla As String, ByVal wClave As String) As Double
        Swap = SQL("SELECT TOP 1(" & wClave & " + 1) AS ID FROM " & wTabla & " T1 " &
                   "WHERE NOT EXISTS (SELECT * FROM " & wTabla & " T2  " &
                   "WHERE T1." & wClave & " + 1 = T2." & wClave & ") " &
                   "ORDER BY ID ASC")
        If Swap.RecordCount <> 1 Then
            Return 0
        Else
            Return Val(Swap.Fields("ID").Value)
        End If
    End Function
    Function CambiaCorrelativo(cLocal As Integer, cCaja As Integer, cTipoDoc As String) As Double
        Dim nCorr As String

        nCorr = "0"
        Cor = SQL("Select Correlativo from Correlativos  Where Local = " + Num(cLocal) + " and Caja = " + Num(cCaja) + " and TipoDoc = '" + cTipoDoc + "'")
        If Cor.RecordCount > 0 Then
            nCorr = Cor("Correlativo").Value
        End If

        nCorr = InputBox("Cambio de Correlativo - Caja: " + Num(cCaja), "Correlativo:", nCorr)
        If Val(nCorr) = 0 Then
            MsgError("No se cambió el correlativo.")
        Else
            Cor = SQL("Update Correlativos Set Correlativo = " + Num(nCorr) + " Where Local = " + Num(cLocal) + " and Caja = " + Num(cCaja) + " and TipoDoc = '" + cTipoDoc + "'")
            Mensaje("Correlativo Actualizado" + vbCrLf + Num(nCorr))
        End If
        CambiaCorrelativo = Val(nCorr)
    End Function

    Function Stocks(sArticulo As String, sBodega As Double, sLocal As Double, sCantidad As Double, sModo As String) As Double

        If sModo <> "+" And sModo <> "-" And sModo <> "=" Then
            MsgError("Error en Modo de Actualización de Stock")
            Return 0
        End If

        Stk = SQL("Select * from Stocks where Articulo = '" + sArticulo + "' and Bodega = " + Num(sBodega) + " and Local = " + Num(sLocal))
        If Stk.RecordCount = 0 Then
            If sModo = "=" Then
                Return 0
            End If
            Stk.AddNew()
            Stk("Articulo").Value = Trim(sArticulo)
            Stk("Bodega").Value = sBodega

            Stk("Local").Value = sLocal
            If sModo = "+" Then
                Stk("Stock").Value = sCantidad
            Else
                Stk("Stock").Value = sCantidad * -1
            End If
            Stk("StockMin").Value = 0
            Stk("StockMax").Value = 10000
            Stk.Update()
        Else
            If sModo = "=" Then
                Return Stk("Stock").Value
            End If
            If sModo = "+" Then
                Stk = SQL("Update Stocks Set Stock = Stock + " + Num(sCantidad) + " where Articulo = '" + sArticulo + "' and Bodega = " + Num(sBodega) + " and Local = " + Num(sLocal))
            Else
                Stk = SQL("Update Stocks Set Stock = Stock - " + Num(sCantidad) + " where Articulo = '" + sArticulo + "' and Bodega = " + Num(sBodega) + " and Local = " + Num(sLocal))
            End If
        End If

        Return 0
    End Function

    Function Saca_PVenta(pMayorista As Boolean) As Double
        On Error GoTo SaleSPV
        If pMayorista Then
            Saca_PVenta = Math.Round(Art("PVenta").Value, 2)
        Else
            Saca_PVenta = Art("PVenta").Value
        End If
        Exit Function
SaleSPV:
        Saca_PVenta = 0
    End Function

    Function Saca_Ciudad(wCiudad As String) As String
        Dim cBuscar As New ADODB.Recordset
        If wCiudad = "" Then
            Return ""
        End If
        cBuscar = SQL("Select NombreCiudad from Ciudades where Ciudad = '" + wCiudad + "'")
        If cBuscar.RecordCount > 0 Then
            Saca_Ciudad = cBuscar.Fields("NombreCiudad").Text
        Else
            Saca_Ciudad = wCiudad
        End If
    End Function

    Function Saca_Comuna(wComuna As String) As String
        Dim cBuscar As New ADODB.Recordset
        If wComuna = "" Then
            Return ""
        End If
        cBuscar = SQL("Select NombreComuna from Comunas where Comuna = '" + wComuna + "'")
        If cBuscar.RecordCount > 0 Then
            Saca_Comuna = cBuscar.Fields("NombreComuna").Text
        Else
            Saca_Comuna = wComuna
        End If
    End Function

    Function Saca_Neto(pPrecio As Double) As Double
        'Esta Funcion no calcula los impuestos por ahora
        Saca_Neto = Math.Round(pPrecio / (1 + (gIVA / 100)), 2)
    End Function
    Function PVenta(pPrecio As Double) As Double
        PVenta = Math.Round(pPrecio * (1 + (gIVA / 100)), 0)
    End Function

    Public Sub CrearStock(ByVal wArticulo As String, ByVal wLocal As String, ByVal wBodega As String, ByVal wstock As Double)
        If wArticulo <> "" AndAlso wLocal <> "" And wBodega <> "" Then
            Stk = SQL("SELECT * FROM Stocks WHERE Articulo ='" & wArticulo & "' AND Bodega= " & wBodega & " and Local = " & wLocal & "")
            If Stk.RecordCount = 0 Then
                Stk.AddNew()
                Stk.Fields("Articulo").Value = wArticulo
                Stk.Fields("Bodega").Value = wBodega
                Stk.Fields("Local").Value = wLocal
                Stk.Fields("stockmin").Value = 0
                Stk.Fields("StockMax").Value = 100
                Stk.Fields("Stock").Value = wstock
                Stk.Update()
            End If
        End If
    End Sub

    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = ""
        Dim entero As String = ""
        Dim dec As String = ""
        Dim flag As String = ""

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or
                      (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
                       Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & "con " & dec
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function

    Public Sub BotonRedondo(ByVal gBoton As Button, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim gUbicacionBoton As New System.Drawing.Drawing2D.GraphicsPath
        Dim gNuevoBorde As Rectangle = gBoton.ClientRectangle

        gNuevoBorde.Inflate(-10, -10)
        gNuevoBorde.Inflate(1, 1)
        gUbicacionBoton.AddEllipse(gNuevoBorde)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim p As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(p, gUbicacionBoton)
        gBoton.Region = New System.Drawing.Region(gUbicacionBoton)
        gBoton.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Public Function ObtenerPrimerDiaSemana(ByVal wFecha As DateTime) As DateTime
        Dim wInfoRegion As CultureInfo = CultureInfo.InvariantCulture
        Dim wDiaActual As DayOfWeek = wInfoRegion.Calendar.GetDayOfWeek(wFecha)
        Dim wMatrizDia() As Integer = {6, 0, 1, 2, 3, 4, 5}
        Return wFecha.Subtract(New TimeSpan(wMatrizDia(wDiaActual), 0, 0, 0))
    End Function
    Public Function ObtenerMes(ByVal wMeses As Integer) As String
        Dim wFechaActual As DateTime = DateTime.Today
        ObtenerMes = DateAdd(DateInterval.Month, wMeses, wFechaActual).ToShortDateString()
        Return ObtenerMes
    End Function
    Public Function ObtenerDia(ByVal wDia As Integer, ByVal wFecha As DateTime) As String
        ObtenerDia = DateAdd(DateInterval.Day, wDia, wFecha).ToShortDateString()
        Return ObtenerDia
    End Function

    Function DiaSemana(ByVal wNumeroDia As Integer, ByVal wFecha As Date) As String
        DiaSemana = ""
        Dim wFechaActual As String = ObtenerDia(IIf(wNumeroDia = 0, 7, wNumeroDia - 1), wFecha)
        Select Case wNumeroDia
            Case 0
                DiaSemana = wFechaActual & vbCrLf & " Domingo"
            Case 1
                DiaSemana = wFechaActual & vbCrLf & " Lunes"
            Case 2
                DiaSemana = wFechaActual & vbCrLf & " Martes"
            Case 3
                DiaSemana = wFechaActual & vbCrLf & " Miércoles"
            Case 4
                DiaSemana = wFechaActual & vbCrLf & " Jueves"
            Case 5
                DiaSemana = wFechaActual & vbCrLf & " Viernes"
            Case 6
                DiaSemana = wFechaActual & vbCrLf & " Sabado"
            Case 7
                DiaSemana = wFechaActual & vbCrLf & " Domingo"
            Case Else
                DiaSemana = wFechaActual & vbCrLf & " Lunes"
        End Select
        Return DiaSemana
    End Function
    Public Sub RedimenzionarTabla(ByVal wTabla As C1.Win.C1FlexGrid.C1FlexGrid, ByVal wDiasHabiles() As String)
        Dim wTamañoGrilla As Integer = wTabla.Width
        wTamañoGrilla = wTamañoGrilla - 60
        wTamañoGrilla = wTamañoGrilla / wDiasHabiles.Count
        For i = 1 To wDiasHabiles.Count
            wTabla.Cols(i).Width = wTamañoGrilla
        Next
    End Sub

    Public Sub AbrirDirectorio(ByVal wDireccion As String)
        Dim WScript As Object
        Dim wExplorador As String = "%windir%\explorer.exe /select,"
        WScript = CreateObject("WScript.Shell")
        WScript.Run(wExplorador & Chr(34) & wDireccion & Chr(34))
        WScript = Nothing
    End Sub

    Public Function Descripcion_Motivo(qTipoDoc As String, qMotivo As String) As String
        Descripcion_Motivo = ""
        Mot = SQL("Select DescMotivo from Motivos WHERE Motivo ='" + qMotivo.ToString.Trim + "' And TipoDoc = '" + qTipoDoc + "'")
        If Mot.RecordCount > 0 Then
            Descripcion_Motivo = Mid(Mot.Fields("DescMotivo").Value.ToString.Trim, 1, 50)
        End If
    End Function

    Public Sub Imprimir_Documento(qLocal As Double, qTipoDoc As String, qNumero As Double, Optional qTitulo As String = "", Optional qVisible As Boolean = True)
        Dim VisorImpresion As New VisorReportes
        Try
            gLocal = qLocal
            gTipoDoc = qTipoDoc
            gNumero = qNumero

            Modulo = IIf(qVisible, "", "0")
            ModuloReporte = "ImprimirDocumentos"
            VisorImpresion.WinDeco1.TituloVentana = qTitulo
            VisorImpresion.Show()
        Catch ex As Exception
            MsgError("No se pudo imprimir documento.")
        End Try
    End Sub

    Public Function Abrir_Documento(wArchivo As String) As Boolean
        Dim exeArchivo As New ProcessStartInfo
        Dim Proceso As New Process
        exeArchivo.FileName = wArchivo
        Try
            Proceso = Process.Start(exeArchivo)
            Abrir_Documento = True
        Catch Ex As Exception
            Abrir_Documento = False
            MsgError("Error al abrir archivo:" + vbCrLf + wArchivo + vbCrLf + Ex.Message)
        End Try
    End Function

    Public Function Retorna_TipoBodega(wLocal As Double, wTipo As String) As Double
        'P=Principal  D=Despacho
        Dim wFiltro As String = ""
        Retorna_TipoBodega = 0
        Select Case wTipo.Trim
            Case "P"
                wFiltro = "Principal=1"
            Case "D"
                wFiltro = "Despacho=1"
            Case Else
                wFiltro = "Principal=1"
        End Select

        Paso = SQL("Select Bodega from Bodegas where Local = " + Num(wLocal) + " and " + wFiltro)
        If Paso.RecordCount > 0 Then
            Retorna_TipoBodega = Paso("Bodega").Value
        End If
    End Function

    Function Generar_Documento_ZPL(wLocal As Double, wTipoDoc As String, wNumero As Double, wModo As Integer) As String
        Dim wLinea As Integer, wArticulo As String, wUnidades As Double

        'Modos:  0=Sin Referencias, 1=Copia Cliente, 2=Control Tributario, 3=Cedible

        Generar_Documento_ZPL = ""
        Par = SQL("Select Top 1 * from Parametros")
        DocG = SQL("Select * from DocumentosG where Local=" + Num(wLocal) + " and TipoDoc='" + wTipoDoc + "' and Numero =" + Num(wNumero))
        If DocG.RecordCount = 0 Then
            MsgError("Documento No Encontrado")
            Exit Function
        End If
        DocD = SQL("Select * from DocumentosD where Local=" + Num(wLocal) + " and TipoDoc='" + wTipoDoc + "' and Numero =" + Num(wNumero))
        If DocG.RecordCount = 0 Then
            MsgError("Detalle de Documento No Encontrado")
            Exit Function
        End If
        Cli = SQL("Select * from Clientes where Cliente=" + Num(DocG("Cliente").Value))
        If Cli.RecordCount = 0 Then
            MsgError("Error en Cliente del Documento")
            Exit Function
        End If
        Doc = SQL("Select * from TipoDoc where TipoDoc='" + DocG("TipoDoc").Value + "'")
        If Doc.RecordCount = 0 Then
            MsgError("Tipo de Documento No Encontrado")
            Exit Function
        End If


        Generar_Documento_ZPL += "^XA" + vbCrLf
        Generar_Documento_ZPL += "^PRD" + vbCrLf
        Generar_Documento_ZPL += "^FOI" + vbCrLf
        Generar_Documento_ZPL += "^LH0,0" + vbCrLf

        'Logo y Membrete
        Generar_Documento_ZPL += "^FO280,00^GB260,100,5^FS" + vbCrLf
        Generar_Documento_ZPL += "^FB300,1,,C,0^A0N20,20^FO260,20^FDRUT: " + FE_Rut_Emisor + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^FB300,1,,C,0^A0N20,20^FO260,45^FD" + Nombre_Documento(DocG("TipoDoc").Value) + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO370,70^FDN^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N10,10^FO382,65^FDo^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO460,70,1^FD" + Num(DocG("Numero").Value) + "^FS" + vbCrLf

        Generar_Documento_ZPL += "^A0N40,40^FO10,10^FD" + Par("Fantasia").Value.trim + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N15,15^FO10,50^FD" + Par("Slogan").Value.trim + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N25,25^FO10,115^FD" + FE_Razon_Social + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,140^FD" + FE_Giro + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,160^FD" + FE_Direccion + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,180^FD" + FE_Comuna + ", " + FE_Ciudad + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,200^FD" + Par("EMail").Value.trim + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO320,200^FD" + Par("Telefonos").Value.trim + "^FS" + vbCrLf

        Generar_Documento_ZPL += "^FO10,225^GB620,1,1^FS" + vbCrLf

        'Datos del Receptor
        Generar_Documento_ZPL += "^A0N20,20^FO10,240^FDFecha Emision:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO370,240^FDF.Pago:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,260^FDSenores:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,280^FDR.U.T.:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO370,280^FDVendedor:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,300^FDGiro:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,320^FDDireccion:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,340^FDCiudad:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO370,340^FDComuna:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,360^FDCorreo:^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO370,360^FDTelefonos:^FS" + vbCrLf

        Generar_Documento_ZPL += "^A0N20,20^FO130,240^FD" + Format(DocG("Fecha").Value, "dd/MM/yyyy") + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO450,240^FD" + BuscarCampo("FPagos", "DescFPago", "FPago", DocG("FPago").Value) + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO130,260^FD" + Cli("Nombre").Value.trim + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO130,280^FD" + Cli("Rut").Value + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO450,280^FD" + DocG("Vendedor").Value.trim + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO130,300^FD" + Cli("Giro").Value.trim + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO130,320^FD" + Cli("Direccion").Value.trim + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO130,340^FD" + BuscarCampo("Comunas", "NombreComuna", "Comuna", Cli("Comuna").Value) + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO450,340^FD" + BuscarCampo("Ciudades", "NombreCiudad", "Ciudad", Cli("Ciudad").Value) + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO130,360^FD" + Cli("EMail").Value.trim + "^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO450,360^FD" + Cli("Telefonos").Value.trim + "^FS" + vbCrLf

        Generar_Documento_ZPL += "^FO10,380^GB620,1,1^FS" + vbCrLf

        'Titulos de Articulos
        Generar_Documento_ZPL += "^FO10,390^GB620,1,1^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO10,400^FDArticulo^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO300,400,1^FDCantidad^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO420,400,1^FDP.Unitario^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO540,400,1^FDTotal^FS" + vbCrLf

        Generar_Documento_ZPL += "^FO10,420^GB620,1,1^FS" + vbCrLf

        'Detalles de Articulos        
        wLinea = 430
        wUnidades = 0
        While Not DocD.EOF
            If Trim(DocD("Glosa").Value.trim <> "") Then
                wArticulo = DocD("Glosa").Value.trim
            Else
                wArticulo = BuscarCampo("Articulos", "Descripcion", "Articulo", DocD("Articulo").Value)
            End If
            Generar_Documento_ZPL += "^A0N20,20^FO10," + Num(wLinea) + "^FD" + wArticulo + "^FS" + vbCrLf
            Generar_Documento_ZPL += "^A0N20,20^FO300," + Num(wLinea + 20) + ",1^FD" + Format(DocD("Cantidad").Value, "###,###,##0.00") + "^FS" + vbCrLf
            Generar_Documento_ZPL += "^A0N20,20^FO420," + Num(wLinea + 20) + ",1^FD" + Format(DocD("Neto").Value, "###,###,##0.00") + "^FS" + vbCrLf
            Generar_Documento_ZPL += "^A0N20,20^FO540," + Num(wLinea + 20) + ",1^FD" + Format(DocD("Cantidad").Value * DocD("Neto").Value, "###,###,##0.00") + "^FS" + vbCrLf
            wLinea += 40
            wUnidades += DocD("Cantidad").Value
            DocD.MoveNext()
        End While

        'Totales
        wLinea += 40
        Generar_Documento_ZPL += "^FO10," + Num(wLinea) + "^GB620,1,1^FS" + vbCrLf
        wLinea += 10
        If gClave = "G" Then
            Generar_Documento_ZPL += "^A0N20,20^FO10," + Num(wLinea) + "^FDTotal Cajas:  " & wUnidades & "^FS" + vbCrLf
        End If
        Generar_Documento_ZPL += "^A0N20,20^FO350," + Num(wLinea) + "^FDNETO $^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO540," + Num(wLinea) + ",1^FD" + Format(DocG("Neto").Value, "###,###,###") + "^FS" + vbCrLf
        wLinea += 20
        Generar_Documento_ZPL += "^A0N20,20^FO350," + Num(wLinea) + "^FDIVA $^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO540," + Num(wLinea) + ",1^FD" + Format(DocG("IVA").Value, "###,###,###") + "^FS" + vbCrLf
        wLinea += 20
        Generar_Documento_ZPL += "^A0N20,20^FO350," + Num(wLinea) + "^FDTOTAL $^FS" + vbCrLf
        Generar_Documento_ZPL += "^A0N20,20^FO540," + Num(wLinea) + ",1^FD" + Format(DocG("Total").Value, "###,###,###") + "^FS" + vbCrLf

        'Referencias
        If DocG("NumDocReferencia").Value > 0 Then
            wLinea += 40
            Generar_Documento_ZPL += "^A0N20,20^FO10," & wLinea & "^FDDOCUMENTO REFERENCIA:^FS"
            wLinea += 20
            Generar_Documento_ZPL += "^A0N20,20^FO10," & wLinea & "^FD" & BuscarCampo("TipoDoc", "DescTipoDoc", "TipoDoc", DocG("TipoDocReferencia").Value).trim & ":  " & DocG("NumDocReferencia").Value & "  del  " & Format(DocG("FechaDocReferencia").Value, "dd/MM/yyyy") & "^FS"
            wLinea += 20
            Generar_Documento_ZPL += "^A0N20,20^FO10," & wLinea & "^FDMOTIVO: " & BuscarCampo("Motivos", "DescMotivo", "Motivo", DocG("Motivo").Value) & "^FS"
        End If

        'Modo
        If wModo > 0 Then
            If wModo = 1 Then
                'No se imprime nada cuando la copia es para cliente
            End If
            If wModo = 2 Then
                wLinea += 40
                Generar_Documento_ZPL += "^A0N20,20,25^FO530," & wLinea & ",1^FD   ^FS"
            End If
            If wModo = 3 Then
                wLinea += 40
                Generar_Documento_ZPL += "^FO10," & wLinea & "^GB520,180,1^FS"
                wLinea += 120
                Generar_Documento_ZPL += "^FO10," & wLinea & "^GB520,1,1^FS"
                wLinea -= 110
                Generar_Documento_ZPL += "^A0N20,20^FO20," & wLinea & "^FDNombre:^FS"
                wLinea += 15
                Generar_Documento_ZPL += "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5
                Generar_Documento_ZPL += "^A0N20,20^FO20," & wLinea & "^FDRUT:^FS"
                wLinea += 15
                Generar_Documento_ZPL += "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5
                Generar_Documento_ZPL += "^A0N20,20^FO20," & wLinea & "^FDFecha:^FS"
                wLinea += 15
                Generar_Documento_ZPL += "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5
                Generar_Documento_ZPL += "^A0N20,20^FO20," & wLinea & "^FDRecinto:^FS"
                wLinea += 15
                Generar_Documento_ZPL += "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5
                Generar_Documento_ZPL += "^A0N20,20^FO20," & wLinea & "^FDFirma:^FS"
                wLinea += 15
                Generar_Documento_ZPL += "^FO100," & wLinea & "^GB420,1,1^FS"
                wLinea += 5

                wLinea += 20
                Generar_Documento_ZPL += "^A0N10,10^FO20," & wLinea & "^FDEl acuse de recibo que se declara en este acto, de acuerdo a lo dispuesto en las letra b) del Art. 4   , y la ^FS"
                wLinea -= 5
                Generar_Documento_ZPL += "^A0N6,6^FO447," & wLinea & "^FDo^FS"
                wLinea += 20
                Generar_Documento_ZPL += "^A0N10,10^FO20," & wLinea & "^FDletra c) del Art. 5   de la Ley 19.983, acredita que la entrega de mercaderias o servicio(s) prestado(s) ^FS"
                wLinea -= 5
                Generar_Documento_ZPL += "^A0N6,6^FO92," & wLinea & "^FDo^FS"
                wLinea += 20
                Generar_Documento_ZPL += "^A0N10,10^FO20," & wLinea & "^FDha(n) sido recibido(s).^FS"
                wLinea += 30
                Generar_Documento_ZPL += "^A0N20,20,25^FO530," & wLinea & ",1^FDCEDIBLE^FS"
            End If
        End If

        'Timbre Electronico
        wLinea += 40
        Generar_Documento_ZPL += "^BY2,3" + vbCrLf
        Generar_Documento_ZPL += "^FO50," + Num(wLinea) + "^B7N,2,5,,83,N" + vbCrLf
        Generar_Documento_ZPL += "^FD" + DocG("TED").Value + "^FS" + vbCrLf
        wLinea += 190
        Generar_Documento_ZPL += "^A0N15,15^FO200," + Num(wLinea) + "^FDTimbre electronico SII^FS" + vbCrLf
        wLinea += 15
        Generar_Documento_ZPL += "^A0N15,15^FO100," + Num(wLinea) + "^FDRes. " + Num(FE_NResolucion) + " de " + Format(FE_FResolucion, "dd/MM/yyyy") + " - Verifique documento: www.sii.cl^FS" + vbCrLf
        Generar_Documento_ZPL += "^XZ" + vbCrLf


    End Function

    Function Generar_Stocks_ZPL(wBodega As Double) As String
        Dim wLinea As Integer

        Generar_Stocks_ZPL = ""
        If wBodega = 0 Then
            MsgError("Falta Bodega a Consultar")
            Exit Function
        End If

        Stk = SQL("Select * from Stocks where Bodega = " & wBodega & " and Articulo <> '0' Order By Local, Bodega, Articulo")
        If Stk.RecordCount = 0 Then
            MsgError("Articulos no encontrados para la Bodega especificada")
            Exit Function
        End If

        Generar_Stocks_ZPL &= "^XA" & vbCrLf
        Generar_Stocks_ZPL &= "^PRD" & vbCrLf
        Generar_Stocks_ZPL &= "^FOI" & vbCrLf
        Generar_Stocks_ZPL &= "^LH0, 0" & vbCrLf

        Generar_Stocks_ZPL &= "^A0N40,40^FO10,10^FDLISTADO DE STOCKS^FS"
        Generar_Stocks_ZPL &= "^A0N20,20^FO540,20,1^FD" & Format(Now.Date, "dd/MM/yyyy") & "^FS"

        Generar_Stocks_ZPL &= "^FO10,50^GB620,1,1^FS"
        Generar_Stocks_ZPL &= "^A0N20,20^FO10,60^FDArticulo^FS"
        Generar_Stocks_ZPL &= "^A0N20,20^FO100,60^FDDescripcion^FS"
        Generar_Stocks_ZPL &= "^A0N20,20^FO460,60,1^FDU.M.^FS"
        Generar_Stocks_ZPL &= "^A0N20,20^FO540,60,1^FDStock^FS"

        Generar_Stocks_ZPL &= "^FO10,80^GB620,1,1^FS"

        'Detalles de Articulos        
        wLinea = 90
        While Not Stk.EOF
            Art = SQL("Select Articulo, Descripcion, Unidad from Articulos where Articulo = '" & Stk("Articulo").Value & "'")
            If Art.RecordCount > 0 Then
                Generar_Stocks_ZPL += "^A0N20,20^FO10," & wLinea & "^FD" & Art("Articulo").Value & "^FS"
                Generar_Stocks_ZPL += "^A0N20,20^FO100," & wLinea & "^FD" & Art("Descripcion").Value & "^FS"
                Generar_Stocks_ZPL += "^A0N20,20^FO460," & wLinea & ",1^FD" & BuscarCampo("Unidades", "DescUnidad", "Unidad", Art("Unidad").Value) & "^FS"
                Generar_Stocks_ZPL += "^A0N20,20^FO540," & wLinea & ",1^FD" & Format(Stk("Stock").Value, "###,###,##0.00") & "^FS"

                wLinea += 20
            End If
            Stk.MoveNext()
        End While

        Generar_Stocks_ZPL += "^FO10," + Num(wLinea) + "^GB620,1,1^FS" + vbCrLf
        Generar_Stocks_ZPL += "^XZ" + vbCrLf

    End Function

    Function Generar_Lista_ZPL() As String
        Dim wLinea As Integer

        Generar_Lista_ZPL = ""

        Generar_Lista_ZPL &= "^XA" & vbCrLf
        Generar_Lista_ZPL &= "^PRD" & vbCrLf
        Generar_Lista_ZPL &= "^FOI" & vbCrLf
        Generar_Lista_ZPL &= "^LH0, 0" & vbCrLf

        Generar_Lista_ZPL &= "^A0N40,40^FO10,10^FDLISTADO DE PRECIOS^FS"
        Generar_Lista_ZPL &= "^A0N20,20^FO540,20,1^FD" & Format(Now.Date, "dd/MM/yyyy") & "^FS"

        Generar_Lista_ZPL &= "^FO10,50^GB620,1,1^FS"
        Generar_Lista_ZPL &= "^A0N20,20^FO10,60^FDArticulo^FS"
        Generar_Lista_ZPL &= "^A0N20,20^FO100,60^FDDescripcion^FS"
        Generar_Lista_ZPL &= "^A0N20,20^FO460,60,1^FDU.M.^FS"
        Generar_Lista_ZPL &= "^A0N20,20^FO540,60,1^FDP.Venta^FS"

        Generar_Lista_ZPL &= "^FO10,80^GB620,1,1^FS"

        'Detalles de Articulos        
        Art = SQL("Select Articulo, Descripcion, Unidad, PVenta from Articulos where Articulo <> '0' Order by Descripcion")
        If Art.RecordCount > 0 Then
            wLinea = 90
            While Not Art.EOF
                Generar_Lista_ZPL += "^A0N20,20^FO10," & wLinea & "^FD" & Art("Articulo").Value & "^FS"
                Generar_Lista_ZPL += "^A0N20,20^FO100," & wLinea & "^FD" & Art("Descripcion").Value & "^FS"
                Generar_Lista_ZPL += "^A0N20,20^FO460," & wLinea & ",1^FD" & BuscarCampo("Unidades", "DescUnidad", "Unidad", Art("Unidad").Value) & "^FS"
                Generar_Lista_ZPL += "^A0N20,20^FO540," & wLinea & ",1^FD" & Format(Art("PVenta").Value, "###,###,##0") & "^FS"

                wLinea += 20
                Art.MoveNext()
            End While
        End If
        Generar_Lista_ZPL += "^FO10," + Num(wLinea) + "^GB620,1,1^FS" + vbCrLf
        Generar_Lista_ZPL += "^XZ" + vbCrLf

    End Function

    Public Function Nombre_Documento(wTipoDoc As String) As String
        Dim Tde As New ADODB.Recordset
        Nombre_Documento = wTipoDoc
        Tde = SQL("Select * from TipoDoc where TipoDoc = '" & wTipoDoc.Trim & "'")
        If Tde.RecordCount > 0 Then
            If Tde("Electronica").Value Then
                If Tde("Nombre_Documento").Text = "" Then
                    Nombre_Documento = Tde("DescTipoDoc").Text
                Else
                    Nombre_Documento = Tde("Nombre_Documento").Text
                End If
            Else
                Nombre_Documento = Tde("DescTipoDoc").Text
            End If
        End If
    End Function

    Public Function Primera_Linea(wLocal As Double, wTipoDoc As String, wNumero As Double) As String
        Dim wArticulo As String = "", wPrimeraLinea As String = ""
        Paso = SQL("Select Articulo, Glosa from DocumentosD where Local = " & wLocal & " and TipoDoc = '" & wTipoDoc & "' and Numero = " & wNumero)
        If Paso.RecordCount > 0 Then
            wPrimeraLinea = "ARTICULO"
            While Not Paso.EOF
                Art = SQL("Select * from Articulos WHERE Articulo = '" + Paso.Fields("Articulo").Value.ToString + "'")
                If Art.RecordCount > 0 Then
                    If wArticulo = "" Then wArticulo = Art.Fields("Descripcion").Value
                    If Not IsDBNull(Paso.Fields("Glosa").Value) Then
                        If Trim(Paso.Fields("Glosa").Value) <> "" Then
                            wArticulo = Trim(Mid(Paso.Fields("Glosa").Value, 1, 80))
                        End If
                    End If
                    If wPrimeraLinea = "ARTICULO" Then
                        wPrimeraLinea = Trim(Mid(Formatea_Texto(wArticulo), 1, 80))
                        wArticulo = wPrimeraLinea
                    End If
                End If
                Paso.MoveNext()
            End While
        End If
        Primera_Linea = wPrimeraLinea
    End Function

    Public Function DeserializarXML(Of t)(xml As String) As t
        Try
            Dim xs As New XmlSerializer(GetType(t))
            Dim memoryStream As New MemoryStream(StringToUTF8ByteArray(xml))
            Dim xmlTextWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)
            Return DirectCast(xs.Deserialize(memoryStream), t)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ByteArrayToUTF8String(characters As Byte()) As String
        Dim encoding As New UTF8Encoding()
        Dim constructedString As String = encoding.GetString(characters)
        Return (constructedString)
    End Function

    Public Function StringToUTF8ByteArray(stringVal As String) As [Byte]()
        Dim encoding As New UTF8Encoding()
        Dim byteArray As Byte() = encoding.GetBytes(stringVal)
        Return byteArray
    End Function

    Public Function Acceso_Usuario(wUsuario As String) As Integer
        Dim qACC As New ADODB.Recordset
        qACC = SQL("Select Acceso from Usuarios where Usuario = '" + wUsuario + "'")
        If qACC.RecordCount > 0 Then
            Acceso_Usuario = qACC("Acceso").Value
        Else
            Acceso_Usuario = 0
        End If
    End Function

    Public Function BuscarCampo(ByVal wTabla As String, wCampoRetorno As String, wCampoBusqueda As String, wDatoaBuscar As String, Optional wFiltro As String = "") As String
        Try
            Dim yBuscar As New ADODB.Recordset
            yBuscar = SQL("SELECT " & wCampoRetorno & " FROM " & wTabla & " WHERE " & wCampoBusqueda & " = '" & wDatoaBuscar & "'" + If(wFiltro.Trim = "", "", " and " + wFiltro))
            If yBuscar.RecordCount > 0 Then
                Return yBuscar(wCampoRetorno).Value.ToString.Trim
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Module



