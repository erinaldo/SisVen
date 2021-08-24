Imports System
Imports System.IO
Imports System.Collections

Public Class CargaCAF
    Dim wRut As String
    Dim wTipoDoc As Integer
    Dim wInicial As Long
    Dim wFinal As Long
    Dim wFecha As String

    Private Sub CargaCAF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Function LeeXML() As String
        Dim wArchivo As New StreamReader(xArchivo.Text)

        LeeXML = ""
        Try
            LeeXML = wArchivo.ReadToEnd
            wArchivo.Close()
        Catch ex As Exception
            MsgError("Error al leer archivo")
        End Try
    End Function

    Private Function ObtieneDatos_CAF(ByVal wXML As String) As Boolean
        Dim wDato As String

        wDato = "" : wRut = "" : wTipoDoc = 0 : wInicial = 0 : wFinal = 0
        Try
            wDato = Mid(wXML, (InStr(wXML, "<RE>") + 4), (InStr(wXML, "</RE>") - (InStr(wXML, "<RE>") + 4)))
            wRut = Mid(wDato, 1, (Len(wDato) - 8)) + "." + Mid(wDato, (Len(wDato) - 7), 3) + "." + Mid(wDato, (Len(wDato) - 4), 5)
            wDato = Mid(wXML, (InStr(wXML, "<TD>") + 4), (InStr(wXML, "</TD>") - (InStr(wXML, "<TD>") + 4)))
            wTipoDoc = Val(wDato)
            wDato = Mid(wXML, (InStr(wXML, "<D>") + 3), (InStr(wXML, "</D>") - (InStr(wXML, "<D>") + 3)))
            wInicial = Val(wDato)
            wDato = Mid(wXML, (InStr(wXML, "<H>") + 3), (InStr(wXML, "</H>") - (InStr(wXML, "<H>") + 3)))
            wFinal = Val(wDato)
            wDato = Mid(wXML, (InStr(wXML, "<FA>") + 4), (InStr(wXML, "</FA>") - (InStr(wXML, "<FA>") + 4)))
            wFecha = Trim(wDato)
            ObtieneDatos_CAF = True
        Catch ex As Exception
            ObtieneDatos_CAF = False
        End Try
    End Function

    Private Function guardaXML(ByVal wXML As String, ByVal wLocal As Integer) As Boolean
        Dim wDocumento As String

        guardaXML = True

        Doc = SQL("Select * from TipoDoc WHERE Cod_SII = " + Num(wTipoDoc))
        If Doc.RecordCount = 0 Then
            MsgError("Código Documento Fiscal No Encontrado")
            guardaXML = False
            Exit Function
        End If

        wDocumento = Trim(Doc.Fields("TipoDoc").Value)

        Try
            FileCopy(xArchivo.Text, (Directorio_CAF + "\" + wDocumento + Llena0(wLocal, 2) + ".xml"))
        Catch ex As Exception
            MsgError("Error al copiar archivo a carpeta CAF")
            guardaXML = False
            Exit Function
        End Try

        Try
            Cor = SQL("SELECT * FROM Correlativos WHERE Local = " + Num(wLocal) + " AND TipoDoc = '" + wDocumento + "'")
            If Cor.RecordCount = 0 Then
                Cor.AddNew()
                Cor.Fields("Local").Value = wLocal
                Cor.Fields("Caja").Value = 0
                Cor.Fields("TipoDoc").Value = wDocumento
                Cor.Fields("Correlativo").Value = wInicial
                Cor.Fields("Inicial").Value = wInicial
                Cor.Fields("Final").Value = wFinal
                Cor.Fields("FechaCAF").Value = CDate(wFecha)
                Cor.Fields("CAF").Value = wXML
                Cor.Update()
            Else
                While Not Cor.EOF
                    DoEvents()
                    If Cor.Fields("Caja").Value = 0 Then
                        If Cor.Fields("Correlativo").Value < wInicial Then
                            Cor.Fields("Correlativo").Value = wInicial
                        End If
                    End If
                    Cor.Fields("Inicial").Value = wInicial
                    Cor.Fields("Final").Value = wFinal
                    Cor.Fields("FechaCAF").Value = CDate(wFecha)
                    Cor.Fields("CAF").Value = wXML
                    Cor.Update()
                    Cor.MoveNext()
                End While
            End If
            Cor.Close()

            xStatus.Text = xStatus.Text + "Local: (" & Num(wLocal) & ")  " & wRut & "  " & BuscarCampo("Locales", "RazonLocal", "RutLocal", wRut) & vbCrLf
            xStatus.Text = xStatus.Text + "Documento: (" + wDocumento + ") " & BuscarCampo("TipoDoc", "DescTipoDoc", "TipoDoc", wDocumento) & vbCrLf
            xStatus.Text = xStatus.Text + "Correlativos: " & wInicial & " al " & wFinal & "  Fecha: " & wFecha & vbCrLf
            xStatus.Text = xStatus.Text + "Destino: " + Directorio_CAF & "\" & wDocumento & Llena0(wLocal, 2) & ".xml" & vbCrLf
            xStatus.Text = xStatus.Text + "CAF CARGADO CORRECTAMENTE." & vbCrLf
            xStatus.Text = xStatus.Text + "------------------------------------------------------------------------------" & vbCrLf
        Catch ex As Exception
            guardaXML = False
        End Try
    End Function

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Dim wXML As String, qLocal As Double, qError As Boolean

        If Not System.IO.File.Exists(xArchivo.Text) Then
            MsgError("No se pudo abrir archivo:" + vbCrLf + xArchivo.Text)
            Exit Sub
        End If

        wXML = LeeXML()
        If wXML.Trim = "" Then
            MsgError("Archivo sin datos, no se puede procesar")
            Exit Sub
        End If

        qLocal = 9999
        qError = False

        If ObtieneDatos_CAF(wXML) Then
            Loc = SQL("SELECT Local, RutLocal FROM Locales Order by RutLocal")
            While Not Loc.EOF
                DoEvents()
                If Loc.Fields("RutLocal").Value = wRut Then
                    qError = guardaXML(wXML, Loc.Fields("Local").Value)
                    If qLocal = 9999 Then qLocal = Loc.Fields("Local").Value
                End If
                Loc.MoveNext()
            End While

            If qLocal <> 9999 Then
                qError = Not Enviar_CAF_DTE(qLocal, xArchivo.Text)
            End If
            If qError Then
                Mensaje("Folios CAF No se cargaron correctamente.  Revise la información en la ventana de eventos.")
            Else
                Mensaje("Folios CAF Cargados.")
            End If
            Auditoria(Text, "Carga de CAF", "", "")

            xArchivo.Text = ""
        End If
    End Sub

    Private Sub bCargar_Click(sender As Object, e As EventArgs) Handles bCargar.Click
        xStatus.Text = ""

        cdCAF.Filter = "CAF (*.xml)|*.xml"
        cdCAF.DefaultExt = "xml"
        cdCAF.FileName = ""
        cdCAF.Title = "Seleccione el archivo CAF"
        cdCAF.ShowDialog()
        xArchivo.Text = cdCAF.FileName

    End Sub

    Function Enviar_CAF_DTE(wLocal As Integer, wArchivo As String) As Boolean
        'Parametrizar FE con datos del Local

        Enviar_CAF_DTE = True

        If Not Parametros_DTE(wLocal) Then
            xStatus.Text = xStatus.Text + "No pudo parametrizarse el DTE.  Favor cargar CAF manualmente desde el DTE." + vbCrLf
            Enviar_CAF_DTE = False
            Exit Function
        End If

        'Llamando al servicio del BOX
        Dim servicio As DTEBoxCliente.Servicio
        servicio = New DTEBoxCliente.Servicio(FE_DTE, FE_Llave)

        Dim resultado As DTEBoxCliente.ResultadoServicio
        Dim AmbienteDTE As DTEBoxCliente.Ambiente
        AmbienteDTE = CType(FE_Ambiente, DTEBoxCliente.Ambiente)

        'resultado = servicio.EnviarCAF(FE_Ambiente, wArchivo)
        resultado = servicio.EnviarCAF(AmbienteDTE, wArchivo)

        If (resultado.Estado = 0) Then
            xStatus.Text = xStatus.Text + "El CAF se envió satisfactoriamente al DTE." + vbCrLf
        Else
            xStatus.Text = xStatus.Text + "No pudo enviarse el CAF al DTE o CAF ya cargado anteriormente.  Favor cargarlo manualmente desde el DTE." + vbCrLf
            Enviar_CAF_DTE = False
        End If
    End Function
End Class