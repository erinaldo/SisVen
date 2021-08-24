Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Imports Parametros
Imports DTE
Imports System.Web.Compilation

Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports System.Runtime.CompilerServices

Public Class Funciones

    Public Shared PatronEmail As New Regex("^[a-zA-Z0-9-]*(.[a-zA-Z0-9-]+)*(.[a-zA-Z0-9-]+)*(.[a-zA-Z0-9-]+)@[a-zA-Z0-9-]+(.[a-zA-Z0-9-]+)*(.[a-zA-Z]{2,4})$")


    Public Shared Function ValidarRut(ByRef wRut As String) As Boolean

        wRut = FormatoRut(wRut)
        wRut = wRut.PadLeft(12, "0")

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

    Public Shared Function FechaTexto(ByVal wFecha As DateTime) As String
        Return wFecha.Day.ToString.PadLeft(2, "0") & "/" & wFecha.Month.ToString.PadLeft(2, "0") & "/" & wFecha.Year
    End Function

    Public Shared Function FormatoRut(wRut As String) As String
        wRut = wRut.Replace(".", "")

        If Not wRut.Contains("-") Then
            Dim wVerificador = wRut.Substring(wRut.Length - 1)
            Dim wLargoRut = wRut.Length - 1
            wRut = wRut.Substring(0, wLargoRut) & "-" & wVerificador
        End If

        Dim Forma = wRut.Split("-")
        If wRut.Contains("-") And Forma(1) = "" Then
            Dim wIndiceSeparador = wRut.IndexOf("-")
            Dim wVerificador = Forma(0).Substring(wIndiceSeparador - 1)
            Return FormatoRut(Forma(0).Substring(0, wIndiceSeparador - 1) & "-" & wVerificador)
            Exit Function
        End If

        Dim SinVerificador = Format(Val(Forma(0)), "###,###")
        Dim wComp = SinVerificador & "-" & Forma(1)

        wRut = wComp

        If wComp.Trim.Length = 11 Then
            Dim rutval = wComp.Trim
            rutval = rutval.PadLeft(12, "0")
            wRut = rutval
        End If

        Return wRut
    End Function

    Public Shared Sub Log(wCliente As Integer, wEx As Exception, wErrores As List(Of String), wMetodo As String)
        Dim wLogCON As New SqlConnection(P_CONEXION)

        wLogCON.Open()

        Dim wExcep As New SqlCommand("INSERT INTO Log VALUES(@Mensaje,@Fecha,@Cliente)", wLogCON)
        wExcep.Parameters.AddWithValue("@Mensaje", wMetodo & ": " & wEx.ToString)
        wExcep.Parameters.AddWithValue("@Fecha", Now)
        wExcep.Parameters.AddWithValue("@Cliente", wCliente)
        wExcep.ExecuteNonQuery()

        GuardarUltimoEvento(wCliente, "Error en Procedimiento - " & wMetodo & " Cliente :" & wCliente & " Excepción: " & wEx.ToString, "")

        For Each wErr As String In wErrores

            wLogCON = New SqlConnection(P_CONEXION)
            wLogCON.Open()

            Dim wMSG As New SqlCommand("INSERT INTO Log VALUES(@Mensaje,@Fecha,@Cliente)", wLogCON)
            wMSG.Parameters.AddWithValue("@Mensaje", wMetodo & ": " & wErr)
            wMSG.Parameters.AddWithValue("@Fecha", Now)
            wMSG.Parameters.AddWithValue("@Cliente", wCliente)
            wMSG.ExecuteNonQuery()

            GuardarUltimoEvento(wCliente, "Error en Procedimiento - " & wMetodo & " Cliente :" & wCliente & " Error: " & wEx.ToString, "")
        Next

        wLogCON.Close()
        SqlConnection.ClearPool(wLogCON)
    End Sub

    Public Shared Sub LogTxt(ByVal wFuncion As String, ByVal wRegistro As String)
        Try
            Dim wPath As String = "D:/Wikets" 'Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            wPath += "/LogWebService.txt"

            If Not File.Exists(wPath) Then
                File.Create(wPath).Close()

                Using wWriter = New StreamWriter(wPath)
                    wWriter.WriteLine(DateTime.Now.ToString() & vbTab & wFuncion & vbTab & wRegistro)
                    wWriter.Close()
                End Using
            ElseIf File.Exists(wPath) Then

                Using wWriter = New StreamWriter(wPath, True)
                    wWriter.WriteLine(DateTime.Now.ToString() & vbTab & wFuncion & vbTab & wRegistro)
                    wWriter.Close()
                End Using
            End If

        Catch __unusedException1__ As Exception
        End Try
    End Sub


    Public Shared Function Num(ByVal wObj As Object) As Decimal
        If wObj Is Nothing Then
            Return 0
        Else
            Return Val(wObj)
        End If
    End Function

    Public Shared Function ValidarNum(ByRef wCampo As Decimal, ByVal wOpcional As Boolean, Optional ByVal wPredeterminado As Decimal = 0) As Boolean
        If Not wOpcional And wCampo = wPredeterminado Then Return False
        If wCampo = 0 And wOpcional Then
            wCampo = wPredeterminado
        End If
        Return True
    End Function


    Public Shared Function ValidarEmail(ByRef wEmail As String) As Boolean
        wEmail = wEmail.Trim
        If wEmail = "" Then Return False
        Return PatronEmail.IsMatch(wEmail)
    End Function

    Public Shared Function ValidarTexto(ByRef wCampo As String, ByVal wLargo As Integer, ByVal wOpcional As Boolean,
                                 Optional ByVal wPredeterminado As String = "") As Boolean
        wCampo = Trim(wCampo)

        If wCampo = "" And Not wOpcional Then
            Return False
        End If
        If wCampo.Length > wLargo Then Return False
        If wCampo = "" And wOpcional Then
            wCampo = wPredeterminado
        End If
        Return True
    End Function

    Public Shared Function FormatoCaracteres(wTexto As String, Optional wLargo As Integer = 0) As String
        Dim Car As String, i As Integer, Texto_Resultado As String

        Dim wContenido = UCase(Trim(wTexto))
        wContenido = Replace(wContenido, "Á", "A")
        wContenido = Replace(wContenido, "Ä", "A")
        wContenido = Replace(wContenido, "É", "E")
        wContenido = Replace(wContenido, "Í", "I")
        wContenido = Replace(wContenido, "Ó", "O")
        wContenido = Replace(wContenido, "Ö", "O")
        wContenido = Replace(wContenido, "Ú", "U")
        wContenido = Replace(wContenido, "Ü", "U")
        wContenido = Replace(wContenido, "Ñ", "N")
        wContenido = Replace(wContenido, "²", "2")
        wContenido = Replace(wContenido, "º", "")
        wContenido = Replace(wContenido, "°", "")
        wContenido = Replace(wContenido, "°", "")
        wContenido = Replace(wContenido, "°", "")
        wContenido = Replace(wContenido, "º", "")
        wContenido = Replace(wContenido, "ª", "")
        wContenido = Replace(wContenido, "ª", "")
        wContenido = Replace(wContenido, "%", "")
        wContenido = Replace(wContenido, "$", "")
        wContenido = Replace(wContenido, "&", "")
        wContenido = Replace(wContenido, "*", "")
        wContenido = Replace(wContenido, "^", "")
        wContenido = Replace(wContenido, "~", "")
        wContenido = Replace(wContenido, "#", "")
        wContenido = Replace(wContenido, Chr(34), "")
        wContenido = Replace(wContenido, Chr(39), "")
        wContenido = Replace(wContenido, Chr(96), "")
        wContenido = Replace(wContenido, Chr(176), "")
        wContenido = Replace(wContenido, Chr(186), "")

        Texto_Resultado = ""
        'Sacar los caracteres no imprimibles despues de la limpieza de letras
        For i = 1 To Len(wContenido)
            Car = Mid(wContenido, i, 1)
            If Asc(Car) < 32 Or Asc(Car) > 122 Then
                'Eliminar si no es Imprimible
                Car = ""
            End If

            Car = Cambia_Car(Car, 34)   '"
            Car = Cambia_Car(Car, 35)   '#
            Car = Cambia_Car(Car, 39)   ''
            Car = Cambia_Car(Car, 58)   ':
            Car = Cambia_Car(Car, 59)   ';
            'Car = Cambia_Car(Car, 64)   '@
            Car = Cambia_Car(Car, 94)   '^
            Car = Cambia_Car(Car, 96)   '´
            Car = Cambia_Car(Car, 60)   '<
            Car = Cambia_Car(Car, 61)   '=
            Car = Cambia_Car(Car, 62)   '>

            Texto_Resultado = Texto_Resultado + Car
        Next i

        If wLargo > 0 Then
            Return Mid(Texto_Resultado + Space(wLargo), 1, wLargo).Trim
        Else
            Return Trim(Texto_Resultado)
        End If

    End Function

    Public Shared Sub GuardarUltimoEvento(ByVal wCliente As Double, ByVal wEvento As String, ByVal wQuery As String)

        Try
            Dim wLogCON As New SqlConnection(P_CONEXION)
            wLogCON.Open()

            Dim wExcep As New SqlCommand("INSERT INTO LogIntegraciones (Fecha, Integracion, Version, Cliente, " &
                                         "Servidor, Conexion, Evento, Query, Local) VALUES(@Fecha, @Integracion, @Version, @Cliente, " &
                                         "@Servidor, @Conexion, @Evento, @Query, @Local) ", wLogCON)

            wExcep.Parameters.AddWithValue("@Fecha", Now)
            wExcep.Parameters.AddWithValue("@Integracion", P_ProductName)
            wExcep.Parameters.AddWithValue("@Version", P_VERSION)
            wExcep.Parameters.AddWithValue("@Cliente", wCliente)
            wExcep.Parameters.AddWithValue("@Servidor", P_SERVIDOR)
            wExcep.Parameters.AddWithValue("@Conexion", P_CONEXION)
            wExcep.Parameters.AddWithValue("@Evento", wEvento.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " "))
            wExcep.Parameters.AddWithValue("@Query", wQuery)
            wExcep.Parameters.AddWithValue("@Local", 0)


            wExcep.ExecuteNonQuery()
            wLogCON.Close()

            SqlConnection.ClearPool(wLogCON)

        Catch ex As Exception
            'Log(0, ex.ToString, "GuardarEvento")
        End Try

    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Public Shared Function DeserializarXML(Of t)(xml As String) As t
        Try

            Dim xs As New XmlSerializer(GetType(t))
            Dim memoryStream As New MemoryStream(StringToUTF8ByteArray(xml))
            Dim xmlTextWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)
            Return DirectCast(xs.Deserialize(memoryStream), t)


        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Shared Function StringToUTF8ByteArray(stringVal As String) As [Byte]()
        Dim encoding As New UTF8Encoding()
        Dim byteArray As Byte() = encoding.GetBytes(stringVal)
        Return byteArray
    End Function

    Public Shared Function Descripta(ByVal pCadena As String) As String
        Dim Descriptado As String
        Dim X As Integer, AUX As String

        pCadena = Trim(pCadena)
        Descriptado = ""
        AUX = " "
        For X = 1 To Len(pCadena)
            AUX = Mid(pCadena, X, 1)

            Descriptado = Descriptado + Chr((Asc(AUX) / 2) - 2)
        Next X
        Return Descriptado
    End Function

    Public Shared Function Truncate(ByRef wTexto As String, wLargoMaximo As Integer) As String
        If String.IsNullOrEmpty(wTexto) Then
            wTexto = ""
        End If
        wTexto = If(wTexto.Length <= wLargoMaximo, wTexto, Middle(wTexto, 0, wLargoMaximo, "Truncate"))
        Return wTexto
    End Function


    Public Shared Function Middle(ByVal wTexto As String, wInicio As Integer, wLargo As Integer, ByVal wCampo As String) As String
        Try
            Return wTexto.Substring(wInicio, wLargo)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Shared Function DiferencialDias(wFechaInicio As Date, wFechaActual As Date) As String

        Dim wDiaActual = DatePart("d", wFechaActual)
        Dim wMesActual = DatePart("m", wFechaActual)
        Dim wAñoActual = DatePart("yyyy", wFechaActual)
        '**************************************'
        Dim wDiaInicio = DatePart("d", wFechaInicio)
        Dim wMesInicio = DatePart("m", wFechaInicio)
        Dim wAñoInicio = DatePart("yyyy", wFechaInicio)

        Dim wDiasDelMes = 0
        Dim wMes = wMesInicio - 1

        ' si el mes es febrero
        If (wMes = 2) Then   ' *
            If ((wAñoActual / 4 = 0 And wAñoActual / 100.0! = 0) Or wAñoActual / 400 = 0) Then
                wDiasDelMes = 29
            Else
                wDiasDelMes = 28
            End If
        ElseIf (wMes <= 7) Then  '*
            If (wMes = 0) Then
                wDiasDelMes = 31
            ElseIf (wMes / 2 = 0) Then
                wDiasDelMes = 30
            Else
                wDiasDelMes = 31
            End If

        ElseIf (wMes > 7) Then
            If (wMes / 2 = 0) Then
                wDiasDelMes = 31
            Else
                wDiasDelMes = 30
            End If
        End If
        Dim wMeses, wDias, wAños

        If Not ((wAñoInicio > wAñoActual) Or (wAñoInicio = wAñoActual And wMesInicio > wMesActual) Or (wAñoInicio = wAñoActual And wMesInicio = wMesActual And wDiaInicio > wDiaActual)) Then
            If (wMesInicio <= wMesActual) Then
                wAños = wAñoActual - wAñoInicio

                If (wDiaInicio <= wDiaActual) Then
                    wMeses = wMesActual - wMesInicio
                    wDias = wDiaActual - wDiaInicio
                Else
                    If (wMesActual = wMesInicio) Then
                        wAños = wAños - 1
                    End If
                    wMeses = (wMesActual - wMesInicio - 1 + 12) / 12
                    wDias = wDiasDelMes - (wDiaInicio - wDiaActual)
                End If
            Else
                wAños = wAñoActual - wAñoInicio - 1

                If (wDiaInicio > wDiaActual) Then
                    wMeses = wMesActual - wMesInicio - 1 + 12
                    wDias = wDiasDelMes - (wDiaInicio - wDiaActual)
                Else
                    wMeses = wMesActual - wMesInicio + 12
                    wDias = wDiaActual - wDiaInicio
                End If
            End If

        End If '*
        DiferencialDias = If(wDias = 0, 0, 31 - wDias)
        Return DiferencialDias

    End Function
End Class
