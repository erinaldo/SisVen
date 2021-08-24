Public Class ConsultarDTE

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        Me.Close()
    End Sub

    Private Sub ConsultarDTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loc = SQL("Select NombreLocal from Locales WHERE FElectronica = 1 Order by Local")
        While Not Loc.EOF
            cLocal.Items.Add(Loc.Fields("NombreLocal").Value.ToString.Trim)
            If gMonoLocal Then
                cLocal.Text = Loc("NombreLocal").Value
            End If
            Loc.MoveNext()
        End While

        Doc = SQL("Select DescTipoDoc from TipoDoc WHERE Cod_SII > 0 Order by DescTipoDoc")
        While Not Doc.EOF
            cTipoDoc.Items.Add(Doc.Fields("DescTipoDoc").Value.ToString.Trim)
            Doc.MoveNext()
        End While
    End Sub


    Private Sub bConsultar_Click(sender As Object, e As EventArgs) Handles bConsultar.Click
        Consultar_Datos()
    End Sub

    Sub Consultar_Datos()
        Dim wLocal As Double, wTipoDoc As String, wRut As String

        xStatus.Text = ""
        DoEvents()

        If cLocal.Text.Trim = "" Then
            MsgError("Falta Local")
            Exit Sub
        End If
        If cTipoDoc.Text.Trim = "" Then
            MsgError("Falta Tipo Documento")
            Exit Sub
        End If
        If Val(xNumero.Text.Trim) = 0 Then
            MsgError("Falta Número de Documento")
            Exit Sub
        End If

        Loc = SQL("Select * from Locales WHERE NombreLocal = '" + cLocal.Text.Trim + "'")
        If Loc.RecordCount > 0 Then
            wLocal = Loc.Fields("Local").Value
        Else
            MsgError("Local Incorrecto")
            Exit Sub
        End If

        Doc = SQL("Select * from TipoDoc WHERE DescTipoDoc = '" + cTipoDoc.Text.Trim + "'")
        If Doc.RecordCount > 0 Then
            wTipoDoc = Doc.Fields("TipoDoc").Value.ToString.Trim
        Else
            MsgError("Tipo Documento Incorrecto")
            Exit Sub
        End If

        DocG = SQL("Select * from DocumentosG WHERE Local = " + Num(wLocal) + " and TipoDoc = '" + wTipoDoc + "' and Numero = " + Num(xNumero.Text))
        If DocG.RecordCount = 0 Then
            MsgError("Documento no encontrado")
            Exit Sub
        End If
        DocD = SQL("Select * from DocumentosD WHERE Local = " + Num(wLocal) + " and TipoDoc = '" + wTipoDoc + "' and Numero = " + Num(xNumero.Text))
        If DocG.RecordCount = 0 Then
            MsgError("Detalles del Documento no encontrados")
            Exit Sub
        End If

        Cli = SQL("Select * from Clientes WHERE Cliente = " + Num(DocG.Fields("Cliente").Value))
        If Cli.RecordCount = 0 Then
            MsgError("Cliente del documento no encontrado")
            Exit Sub
        End If
        wRut = Cli("Rut").Value

        'Parametrizar FE con datos del Local
        If Not Parametros_DTE(wLocal) Then
            MsgError("Error al sacar parámetros del Local")
            Exit Sub
        End If

        'Dim apiURL As String
        'Dim apiAuth As String
        'apiURL = FE_DTE
        'apiAuth = FE_Llave


        ''Llamada al servicio

        'Dim ambiente As DTEBoxCliente.Ambiente
        'ambiente = DTEBoxCliente.Ambiente.Produccion

        'Dim grupo As DTEBoxCliente.GrupoBusqueda
        'grupo = DTEBoxCliente.GrupoBusqueda.Emitidos

        'Dim rut As String
        'rut = "76235899-9"
        'Dim tipoDocumento As DTEBoxCliente.TipoDocumento
        'tipoDocumento = DTEBoxCliente.TipoDocumento.TIPO_33
        'Dim folio As Long
        'folio = 1077



        'Dim service As DTEBoxCliente.Servicio
        'service = New DTEBoxCliente.Servicio(apiURL, apiAuth)

        'Dim resultado As DTEBoxCliente.ResultadoEstadoFiscal
        'resultado = service.EstadoFiscal(ambiente, grupo, rut, tipoDocumento, folio)

        ''Fin Llamada al servicio

        ''Procesar resultado

        ''Resultado de la operación (OK: Exitosa, Error: No exitosa)
        'If (resultado.ResultadoServicio.Estado = DTEBoxCliente.EstadoResultado.Ok) Then
        '    'Usar los datos que viene en el resultado de la llamada

        '    'Estado:
        '    '0: si el documento fue autorizado
        '    '1: si la resolución del SII está pendiente
        '    '2: si el documento fue autorizado, pero con observaciones o reparos
        '    '9: si el documento fue rechazado
        '    Dim estado As String
        '    estado = resultado.Estado
        '    Mensaje(estado.ToString)
        '    'TrackId que entregó el SII con la autorización del documento.
        '    Dim idSeguimiento As String
        '    idSeguimiento = resultado.IdSeguimiento
        '    Mensaje(idSeguimiento.ToString)
        '    'Comentarios asociados al estado de autorización.
        '    Dim comentarios As String
        '    comentarios = resultado.Comentarios
        '    Mensaje(comentarios.ToString)
        '    'Código de usuario a partir de aquí
        'Else 'Si la operación no fue exitosa

        '    'Descripción del error en caso que la operación no fuese exitosa
        '    Dim description As String
        '    description = resultado.ResultadoServicio.Descripcion
        '    Mensaje(description.ToString)
        'End If


        xStatus.Text = ""
        xStatus.Text += "Estado:" + Consultar_DTE(1, wRut, wTipoDoc, Val(xNumero.Text)) + vbCrLf
        xStatus.Text += "ID Seguimiento: " + Consultar_DTE(2, wRut, wTipoDoc, Val(xNumero.Text)) + vbCrLf
        xStatus.Text += "Observaciones: " + Consultar_DTE(3, wRut, wTipoDoc, Val(xNumero.Text)) + vbCrLf

    End Sub
    Private Sub WinDeco1_Load(sender As Object, e As EventArgs) Handles WinDeco1.Load

    End Sub
End Class