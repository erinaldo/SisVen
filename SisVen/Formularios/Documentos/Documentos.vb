Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class Documentos
    Const T_ID = 0
    Const T_ARTICULO = 1
    Const T_DESCRIPCION = 2
    Const T_UNIDAD = 3
    Const T_BARRA = 4
    Const T_CANTIDAD = 5
    Const T_NETO = 6
    Const T_PVENTA = 7
    Const T_SUBTOTAL = 8
    Const T_IVA = 9
    Const T_EXE = 10
    Const T_MIN = 11
    Const T_BEB = 12
    Const T_VIN = 13
    Const T_CER = 14
    Const T_LIC = 15
    Const T_CAR = 16
    Const T_HAR = 17
    Const T_TAB = 18
    Const T_FEP = 19
    Const T_LOG = 20
    Const T_OTRO = 21

    Dim xGlosa As String

    Dim BodegaParcial As Integer
    Dim ConPagos As Boolean = False
    Dim ModoBodega As String = 0
    Dim Por_WebService As Boolean = False

    Private Sub WinDeco1_Load(sender As Object, e As EventArgs) Handles WinDeco1.Load

    End Sub

    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        Dim xFPago As String, xTipoDoc As String, xMotivo As String, FacGui As Boolean
        Dim wTipoDocR As String

        xTipoDoc = ""
        If Buscar("TipoDoc", "DescTipoDoc", cTipoDoc.Text) Then
            xTipoDoc = Swap.Fields("TipoDoc").Value
            ModoBodega = Swap("Modo").Value
            ConPagos = Swap("Pagos").Value
        Else
            MsgError("Error en Tipo de Documento")
            cTipoDoc.Focus()
            Exit Sub
        End If
        If cTipoDocRef.Text.ToString.Trim <> "" Then
            If Buscar("TipoDoc", "DescTipoDoc", cTipoDocRef.Text) Then
                wTipoDocR = Swap.Fields("TipoDoc").Value
            Else
                MsgError("Error en Tipo de Documento Referencia")
                Exit Sub
            End If
        Else
            wTipoDocR = ""
        End If
        If Val(xNumero.Text) = 0 Then
            MsgError("Falta Número del Documento")
            Exit Sub
        End If
        If xRut.Text = "__.___.___-_" Or Trim(xNombre.Text) = "" Then
            MsgError("Falta Cliente")
            Exit Sub
        End If
        If Buscar("FPagos", "DescFPago", cFPago.Text) Then
            xFPago = Swap("FPago").Value
        Else
            MsgError("Error en Forma de Pago")
            Exit Sub
        End If
        If xNombre.Text = "" Then
            MsgError("Error en Rut/Cliente")
            Exit Sub
        End If

        If xTabla.Rows.Count - 1 = 0 Then
            MsgError("Falta Detalle")
            Exit Sub
        End If
        If Val(xTotal.Text) = 0 Then
            MsgError("Documento no puede tener valor 0")
            Exit Sub
        End If

        'Validar Stocks
        Dim HayStock As Boolean
        For i = 1 To xTabla.Rows.Count - 1

            If xTabla.GetData(i, T_CANTIDAD) = 0 Then
                MsgError("Artículo sin Cantidad: " + Num(xTabla.GetData(i, T_ARTICULO)) + vbCrLf + xTabla.GetData(i, T_DESCRIPCION))
                Exit Sub
            End If

            HayStock = Validar_Stocks(BodegaActual, xTabla.GetData(i, T_ARTICULO), xTabla.GetData(i, T_CANTIDAD))
            If Not HayStock Then
                MsgError("No hay stock para el Artículo: " + Num(xTabla.GetData(i, T_ARTICULO)) + vbCrLf + xTabla.GetData(i, T_DESCRIPCION))
                Exit Sub
            End If
        Next


        If ValidarDeuda Then
            Exit Sub
        End If

        If Trim(xVendedor.Text) = "" Or Trim(xNomVen.Text) = "" Then
            MsgError("Falta Vendedor")
            xVendedor.Focus()
            Exit Sub
        End If

        xMotivo = "X"
        If xTipoDoc = "GD" Or xTipoDoc = "NC" Or xTipoDoc = "ND" Then
            If cMotivo.Text.Trim = "" Then
                MsgError(cTipoDoc.Text.Trim + " debe especificar un motivo")
                cMotivo.Focus()
                Exit Sub
            End If

            Swap = SQL("Select * from  Motivos where DescMotivo = '" + cMotivo.Text + "' and TipoDoc = '" + xTipoDoc + "'")
                If Swap.RecordCount > 0 Then
                xMotivo = Swap("Motivo").Value
            Else
                MsgError("Motivo de " + cTipoDoc.Text.Trim + " incorrecto.")
                cMotivo.Focus()
                Exit Sub
            End If
        End If

        'Correlativo
        xNumero.Text = Correlativo(1, LocalActual, xTipoDoc, xFecha.Value, 0, True)
        If Val(xNumero.Text) = 0 Then
            MsgError("Error no hay correlativos disponibles, imposible emitir documento")
            Exit Sub
        End If

        'Verificar Documento Repetido
        DocG = SQL("Select * from DocumentosG where Local=" + Num(LocalActual) + " and TipoDoc = '" + xTipoDoc + "' and Numero =" + Num(xNumero.Text))
        If DocG.RecordCount > 0 Then
            MsgError("El Documento ya fue Ingresado en el Sistema" + vbCrLf + "intente nuevamente.")
            Exit Sub
        End If

        If xVendedor.Text = "" Then xVendedor.Text = UsuarioActual

        Aceptar.Enabled = False
        Cursor  = Cursors.WaitCursor
        DoEvents()

        '--------------------------------------
        'Si el Documento requiere pagos...
        If xFPago <> "V" Then
            'Se crea un registro con un pago pendiente
            'Si se declara varias formas de pago ira al modulo de pago y no este

            DocP = SQL("Select Top 1 * from DocumentosP")
            DocP.AddNew()
            DocP("Local").Value = LocalActual
            DocP("TipoDoc").Value = xTipoDoc
            DocP("Numero").Value = Val(xNumero.Text)
            DocP("TipoDoc").Value = xTipoDoc
            DocP("Numero").Value = Val(xNumero.Text)
            DocP("Fecha").Value = xFecha.Value
            DocP("Cliente").Value = Val(xCliente.Text)
            DocP("Vendedor").Value = Trim(xVendedor.Text)
            DocP("FPago").Value = Trim(xFPago)
            If xFPago = "E" Then
                DocP("Estado").Value = "C"
                DocP("FechaPago").Value = Now.Date
                DocP("FechaCanc").Value = Now.Date
                DocP("Obs").Value = "PAGO EFECTIVO"
            Else
                DocP("Estado").Value = "P"
                DocP("FechaPago").Value = DateAdd("m", 1, CDate(xFecha.Value))
                DocP("FechaCanc").Value = CDate("01/01/2000")
                DocP("Obs").Value = ""
            End If
            DocP("NumeroPago").Value = 0
            DocP("Cuenta").Value = ""
            DocP("Banco").Value = "000"
            DocP("Titular").Value = ""
            DocP("Monto").Value = CDbl(xTotal.Text)
            DocP("Usuario").Value = UsuarioActual
            DocP.Update()
        Else
            'NO DESARROLLADO AUN EL MODULO DE PAGOS 
            'Se va al modulo de ingreso de pagos
            'If ConPagos Then
            'With ModuloFPagos
            '    .Show
            '    .xNumero = xNumero
            '    .xTipoDoc = cTipoDoc.Text
            '    .xFPago = cFPago.Text
            '    .xCliente = xCliente.Text
            '    .xFecha = xFecha.Value
            '    .xNombre = xNombre
            '    .xVendedor = xVendedor
            '    .xMonto = xTotal
            'End With

            'Me.Enabled = False
            '    While Me.Enabled = False
            '        DoEvents()
            '    End While

            '    'Verificar que se le hayan hecho los pagos
            '    DocP = SQL("Select * from DocumentosP where Local=" + Num(LocalActual) + " and TipoDoc = '" + xTipoDoc + "' and Numero =" + Num(xNumero.Text))
            '    If DocP.RecordCount = 0 Then
            '        MsgError("No se registraron pagos, documento no registrado.")
            '        Exit Sub
            '    End If
            'End If
        End If
        '--------------------------------------

        DocG.AddNew()
        DocG("Local").Value = LocalActual
        DocG("TipoDoc").Value = xTipoDoc
        DocG("Numero").Value = Val(xNumero.Text)
        'Por ahora no usar Ticket como referencia
        'If cTipoDocRef.Text.ToString.Trim = "Ticket" Then
        'DocG("Ticket").Value = Val(xNumDocRef.Text)
        'End If
        DocG("Ticket").Value = 0
        DocG("Electronica").Value = oElectronica.Checked
        DocG("Fecha").Value = xFecha.Value
        DocG("Estado").Value = "A"
        DocG("Bodega").Value = BodegaActual
        DocG("Cliente").Value = Val(xCliente.Text)
        DocG("Rut").Value = xRut.Text
        DocG("Aprobado").Value = True
        DocG("FPago").Value = xFPago
        DocG("Observaciones").Value = Trim(xObs.Text)
        DocG("Usuario").Value = UsuarioActual
        DocG("Vendedor").Value = xVendedor.Text
        DocG("SubTotal").Value = CDbl(xSubTotal.Text)
        DocG("Descuento").Value = CDbl(xDescuento.Text)
        If cTipoDocRef.Text.ToString.Trim = "Orden de Compra" Then
            DocG("OC").Value = Trim(xNumDocRef.Text)
        End If
        DocG("Motivo").Value = xMotivo
        DocG("Neto").Value = CDbl(xNeto.Text)
        DocG("IVA").Value = CDbl(xIVA.Text)
        DocG("iMIN").Value = Val(xMIN.Text)
        DocG("iBEB").Value = Val(xBEB.Text)
        DocG("iVIN").Value = Val(xVIN.Text)
        DocG("iCER").Value = Val(xCER.Text)
        DocG("iLIC").Value = Val(xLIC.Text)
        DocG("iCAR").Value = Val(xCAR.Text)
        DocG("iHAR").Value = Val(xHAR.Text)
        DocG("iTAB").Value = Val(xTAB.Text)
        DocG("iFEP").Value = Val(xFEP.Text)
        'DocG("iLOG").Value = Val(xlog.Text)
        DocG("Total").Value = CDbl(xTotal.Text)

        If Trim(wTipoDocR) = "" Then
            DocG("TipoDocReferencia").Value = ""
            DocG("NumDocReferencia").Value = 0
            DocG("FechaDocReferencia").Value = CDate("01/01/2000")
        Else
            DocG("TipoDocReferencia").Value = wTipoDocR
            DocG("NumDocReferencia").Value = Val(xNumDocRef.Text)
            DocG("FechaDocReferencia").Value = CDate(xFechaDocRef.Text)
        End If
        DocG("RutTransporte").Value = "00.000.000-0"
        DocG("NombreTransporte").Value = ""
        DocG("RutChofer").Value = "00.000.000-0"
        DocG("NombreChofer").Value = ""
        DocG("PatenteMovil").Value = ""
        DocG("DTE").Value = FE_EsElectronica
        DocG("Status_DTE").Value = 0
        DocG("StockTraspasado").Value = 0

        DocG.Update()

        FacGui = False
        DocD = SQL("Select * from DocumentosD")
        For i = 1 To xTabla.Rows.Count - 1
            DocD.AddNew()
            DocD("Local").Value = LocalActual
            DocD("TipoDoc").Value = xTipoDoc
            DocD("Numero").Value = Val(xNumero.Text)
            DocD("Articulo").Value = xTabla.GetData(i, T_ARTICULO)
            DocD("Cantidad").Value = xTabla.GetData(i, T_CANTIDAD)
            DocD("Neto").Value = xTabla.GetData(i, T_NETO)
            DocD("IVA").Value = xTabla.GetData(i, T_IVA)
            DocD("PVenta").Value = xTabla.GetData(i, T_PVENTA)
            If Trim(xTabla.GetData(i, T_ARTICULO)) = "0" Then
                DocD("Glosa").Value = xTabla.GetData(i, T_DESCRIPCION)
                FacGui = True
            End If
            DocD.Update()

            'Actualizar Stocks
            If Trim(xTabla.GetData(i, T_ARTICULO)) <> "0" Then
                Stocks(Trim(xTabla.GetData(i, T_ARTICULO)), Val(BodegaActual), Val(LocalActual), CDbl(xTabla.GetData(i, T_CANTIDAD)), ModoBodega)
                Dim wBodD = SQL("SELECT * FROM Bodegas  WHERE Local = " & LocalActual & " AND Despacho = 1")
                'If wBodD.RecordCount > 0 Then
                '    Stocks(Trim(xTabla.GetData(i, T_ARTICULO)), Val(wBodD.Fields("Bodega").Text), Val(LocalActual), CDbl(xTabla.GetData(i, T_CANTIDAD)), "+")
                'End If
            End If
        Next i

        If xTipoDoc = "F" Then
            'Actualizar Ventas
            Ven = SQL("Select Top 1 * from Ventas")
            Ven.AddNew()
            Ven("Ticket").Value = Val(xNumDocRef.Text)
            Ven("Fecha").Value = Now
            Ven("Usuario").Value = xVendedor.Text
            Ven("Local").Value = LocalActual
            Ven("Caja").Value = CajaActual
            Ven("TipoDoc").Value = xTipoDoc
            Ven("NumDoc").Value = Val(xNumero.Text)
            Ven("FPago").Value = xFPago
            Ven("SubTotal").Value = CDbl(xNeto.Text)
            Ven("Descuento").Value = CDbl(xDescuento.Text)
            Ven("Total").Value = CDbl(xTotal.Text)
            Ven.Update()
        End If

        'Marcar Guias como Facturadas
        If FacGui Then
            'Swap = SQL("Update DocumentosG set Factura=" + Num(xNumero.Text) + " where Factura=0 and Fecha>='" + Format(F1.value, "dd/mm/yyyy") + "' and Fecha<='" + Format(F2, "dd/mm/yyyy") + "' and Cliente=" + Num(xCliente) + " and TipoDoc = 'G' and Estado ='A'")
        End If

        'Facturación Electrónica
        Try
            'Parametrizar con datos del Local
            If Not Parametros_DTE(LocalActual) Then
                Aceptar.Enabled = True
                Cursor = Cursors.Arrow
                MsgError("Error al sacar parámetros del Local.")
            Else
                If FE_EsElectronica Then
                    If Es_Electronico(xTipoDoc) Then
                        DocG.Fields("DTE").Value = True
                        'Generar TED
                        Dim TED_Generado As Boolean = False
                        If Por_WebService Then
                            'WEBSERVICE
                            Dim WS = New SisVenWS1.Service
                            Dim wDT = WS.EmitirTED(1, ClienteLocalActual, LocalActual, xTipoDoc, Val(xNumero.Text))
                            If Val(wDT.Rows(0).Item(0)) = 1 Then '1 = Operación Exitosa
                                Dim wXML = wDT.Rows(0).Item(2)
                                'TED Generado correctamente.
                                TED_Generado = True
                                If Not Crear_TED(LocalActual, xTipoDoc, Val(xNumero.Text)) Then
                                    MsgError("Error al grabar TED en disco")
                                End If
                            Else
                                MsgError("Error generando TED: " & wDT.Rows(0).Item(1)) 'Item1 tiene el mensaje de error.                    
                            End If
                        Else
                            Buscar("Clientes", "Cliente", Val(xCliente.Text))
                            If Not Generar_TED(LocalActual, xTipoDoc, Val(xNumero.Text), DocG.Fields("Fecha").Value, Rut_DTE(DocG.Fields("Rut").Text), Formatea_Texto(Swap.Fields("Nombre").Text), DocG.Fields("Total").Value, xTabla.GetData(1, T_DESCRIPCION)) Then
                                Aceptar.Enabled = True
                                Cursor = Cursors.Arrow
                                MsgError("Error al generar TED.")
                            Else
                                TED_Generado = True
                            End If
                        End If

                        'Envio al DTE                        
                        If TED_Generado Then
                            If Emitir_DTE(LocalActual, xTipoDoc, Val(xNumero.Text)) Then
                                Aceptar.Enabled = True
                                Cursor = Cursors.Arrow
                                'Mensaje eliminado por ser innecesario
                                'Mensaje("Documento enviado a SII exitosamente.")
                            Else
                                Aceptar.Enabled = True
                                Cursor = Cursors.Arrow
                                MsgError("Error al enviar documento a SII.")
                            End If
                        End If
                    Else
                        DocG.Fields("DTE").Value = False
                    End If

                    DocG.Update()
                End If
            End If

        Catch ex As Exception
            Aceptar.Enabled = True
            Cursor = Cursors.Arrow
            MsgError("Error al generar DTE, revise el documento en portal DTE.")
        End Try

        Aceptar.Enabled = True
        Cursor = Cursors.Arrow
        Mensaje(cTipoDoc.Text + " N° " + Num(xNumero.Text) + " Ingresada.")

        Funciones.gTipoCopia = New List(Of Double)
        Funciones.gTipoCopia.Add(1)
        Funciones.gTipoCopia.Add(2)
        Funciones.gTipoCopia.Add(3)

        Imprimir_Documento(Val(LocalActual), xTipoDoc, Val(xNumero.Text), cTipoDoc.Text, True)

        xTipoDoc = cTipoDoc.Text
        Limpia(True)
        cTipoDoc.Text = xTipoDoc
        Auditoria(Me.Text, PR_GUARDAR, "", 0)
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Agregar_Articulo
    End Sub

    Private Sub Agregar_Articulo(Optional qAutomatico As Boolean = False)
        Dim xBarra As String

        If gClave = "W" Then
            If Trim(xArticulo.Text) = "" Then
                xArticulo.Text = "0"
            End If
        End If

        xArticulo.Focus()
        xArticulo_Cargar()

        If Trim(xDescripcion.Text) <> "" Then
            Art = SQL("Select * from Articulos where Articulo = '" & Trim(xArticulo.Text) & "'")
            If Art.RecordCount = 0 Then
                MsgError("Articulo no encontrado")
                Exit Sub
            End If
            If Art("Estado").Value = "X" Then
                MsgError("Articulo Bloqueado")
                Exit Sub
            End If
            If Esta_en_Tabla(xArticulo.Text) = 0 Then
                xTabla.AddItem("")
                Lin = xTabla.Rows.Count - 1
                xTabla.SetData(Lin, T_ID, "")
                xTabla.SetData(Lin, T_ARTICULO, Trim(Art("Articulo").Value))
                xTabla.SetData(Lin, T_DESCRIPCION, Trim(xDescripcion.Text))
                If gClave = "W" Then
                    'Automatización de Glosa
                    If Trim(Art("Articulo").Value) = "0" And Lin = 1 Then
                        xDescripcion.Text = xGlosa
                        xDescripcion.Text = Replace(xDescripcion.Text, "%", UCase(MES(Now.Month)) & " " & Now.Year)  'Mes de la Factura
                        xDescripcion.Text = Replace(xDescripcion.Text, "#", IIf(Now.Month = 1, UCase(MES(12)), UCase(MES(Now.Month - 1))) & " " & IIf(Now.Month = 1, Now.Year - 1, Now.Year))
                        xDescripcion.Text = Replace(xDescripcion.Text, "&", Now.Date)
                        xTabla.SetData(Lin, T_DESCRIPCION, Trim(xDescripcion.Text))
                    End If
                End If
                xTabla.SetData(Lin, T_UNIDAD, Trim(Art("Unidad").Value))
                xBarra = ""
                Bar = SQL("Select Top 1 Barra from Barras where Articulo = '" & xArticulo.Text & "'")
                If Bar.RecordCount > 0 Then
                    xBarra = Trim(Bar("Barra").Value)
                End If
                xTabla.SetData(Lin, T_BARRA, xBarra)
                xTabla.SetData(Lin, T_CANTIDAD, 1)
                If xArticulo.Text = "0" Then
                    xTabla.SetData(Lin, T_NETO, 0)
                    xTabla.SetData(Lin, T_PVENTA, 0)
                Else
                    'Cálculo cuando el valor del artículo viene con IVA
                    'xTabla.SetData(Lin, T_PVENTA, Art.Fields("PVenta").Value)
                    'xTabla.SetData(Lin, T_NETO, Saca_Neto(Art.Fields("PVenta").Value))

                    'Cálculo cuando el valor del artículo es Neto
                    xTabla.SetData(Lin, T_PVENTA, PVenta(Art.Fields("PVenta").Value))
                    xTabla.SetData(Lin, T_NETO, Art.Fields("PVenta").Value)
                End If
                xTabla.SetData(Lin, T_SUBTOTAL, 0)
                Calcular_Total()
                Limpiar_Articulo()
                xTabla.Focus()

                If gClave = "W" Then
                    xTabla.Col = T_DESCRIPCION
                    If xTabla.GetData(Lin, T_DESCRIPCION) = "." Then
                        xTabla.SetData(Lin, T_DESCRIPCION, "SERVICIOS INFORMATICOS")
                    End If
                Else
                    xTabla.Col = T_CANTIDAD
                End If
                If Not qAutomatico Then
                    xTabla.Row = Lin
                    xTabla_Click()
                End If
            Else
                MsgError("Articulo ya Ingresado")
            End If
        End If

    End Sub

    Private Sub bBuscarCli_Click(sender As Object, e As EventArgs) Handles bBuscarCli.Click
        Modulo = "Documentos"
        BuscarClientes.Show()
        BuscarClientes.BringToFront()
    End Sub

    Private Sub bProcesarDoc_Click(sender As Object, e As EventArgs) Handles bProcesarDoc.Click

        'TICKET
        If cTipoDocRef.Text = "Ticket" Then
            If Val(xNumDocRef.Text) > 0 Then
                TkG = SQL("Select * from TikGen where Ticket = " + Num(xNumDocRef.Text))
                If TkG.RecordCount > 0 Then
                    If TkG("Estado").Value = "E" Or TkG("Estado").Value = "V" Then
                        If CDate(Format(TkG("Fecha"), "dd/mm/yyyy")) = xFecha.Value Then
                            Cargar_Ticket()
                        Else
                            MsgError("Ticket fuera de fecha")
                            Exit Sub
                        End If
                    Else
                        MsgError("Ticket No se puede usar")
                        Exit Sub
                    End If
                Else
                    MsgError("Ticket No Encontrado")
                    Exit Sub
                End If
            End If
            Exit Sub
        End If

        'OTROS DOCUMENTOS
        Titulos()

        If xNumDocRef.Text = "" Then
            MsgError("Falta Número de Documento")
            Exit Sub
        End If

        TDo = SQL("Select TipoDoc From TipoDoc Where DescTipoDoc like '%" & Trim(cTipoDocRef.Text) & "%'")
        If TDo.EOF Then
            MsgError("Tipo de documento referencia incorrecto")
            Exit Sub
        End If

        DocG = SQL("Select Numero, Fecha, Cliente from DocumentosG where Numero=" & Num(xNumDocRef.Text) & " and Local = " & Num(LocalActual) &
                   " and TipoDoc = '" & TDo.Fields("TipoDoc").Value.ToString & "' and Estado = 'A'")
        If DocG.RecordCount > 0 Then
            xCliente.Text = DocG.Fields("Cliente").Value
            Sacar_Cliente()
            If xNombre.Text.Trim = "" Then
                Exit Sub
            End If
            DocD = SQL("Select * from DocumentosD where Numero=" & Num(xNumDocRef.Text) & " and Local = " & Num(LocalActual) &
                   " and TipoDoc = '" & TDo.Fields("TipoDoc").Value.ToString & "'")
            If DocD.RecordCount = 0 Then
                MsgError("Error en detalle de documento referencia")
                Exit Sub
            End If
            xFechaDocRef.Value = DocG.Fields("Fecha").Value
            While Not DocD.EOF
                xArticulo.Text = DocD.Fields("Articulo").Value
                Agregar_Articulo(True)
                Lin = xTabla.Rows.Count - 1
                If DocD.Fields("Glosa").Value.ToString.Trim <> "" Then
                    xTabla.SetData(Lin, T_DESCRIPCION, DocD.Fields("Glosa").Value.ToString.Trim)
                End If
                xTabla.SetData(Lin, T_CANTIDAD, Trim(DocD.Fields("Cantidad").Value))
                xTabla.SetData(Lin, T_NETO, Trim(DocD.Fields("Neto").Value))
                Call Calcular_Total()
                DocD.MoveNext()
            End While


            If cTipoDocRef.Text = "Cotización" Then
                Agregar.Enabled = False
                bEliminar.Enabled = False
                BuscarArt.Enabled = False
                bLimpiarArt.Enabled = False
                xArticulo.Enabled = False
                xDescripcion.Enabled = False
                xCliente.Enabled = False
                bBuscarCli.Enabled = False
                bCrearCli.Enabled = False
            Else
                Agregar.Enabled = True
                xCliente.Enabled = True
                bEliminar.Enabled = True
                BuscarArt.Enabled = True
                bLimpiarArt.Enabled = True
                xArticulo.Enabled = True
                xDescripcion.Enabled = True
                bBuscarCli.Enabled = True
                bCrearCli.Enabled = True
            End If
        Else
            MsgError("No se Encontró Documento Referencia")
        End If
        xArticulo.Focus()
    End Sub

    Private Sub bCrearCli_Click(sender As Object, e As EventArgs) Handles bCrearCli.Click
        ManCliente.Show()
        ManCliente.xCliente.Text = xCliente.Text
        ManCliente.Focus()
    End Sub

    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        If xTabla.Row > 0 Then
            If Pregunta("¿Desea Eliminar Artículo:" & vbCrLf & xTabla.GetData(xTabla.Row, T_DESCRIPCION) & "?") Then
                xTabla.RemoveItem(xTabla.Row)
                Calcular_Total()
                xArticulo.Focus()
            End If
        End If
    End Sub

    Private Sub bLimpiarArt_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bLimpiarArt.Click
        Limpiar_Articulo()
    End Sub

    Private Sub Limpiar_Articulo()
        xArticulo.Text = ""
        xDescripcion.Text = ""
        xArticulo.Focus()
    End Sub


    Private Sub BuscarArt_Click(sender As Object, e As EventArgs) Handles BuscarArt.Click
        Modulo = "Documentos"
        'FiltroArt = EmpresaActual
        BuscarArticulos.Show()
    End Sub
    Private Sub cTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoDoc.SelectedIndexChanged
        Call Saca_Corr()

        TDo = SQL("Select * from TipoDoc where DescTipoDoc = '" + cTipoDoc.Text + "'")
        If TDo.RecordCount > 0 Then
            xTipoDoc.Text = TDo("TipoDoc").Value
        Else
            cTipoDoc.Text = ""
            xTipoDoc.Text = ""
        End If

        cMotivo.Items.Clear()
        If xTipoDoc.Text = "GD" Or xTipoDoc.Text = "NC" Or xTipoDoc.Text = "ND" Then
            Swap = SQL("Select * from Motivos where TipoDoc = '" + xTipoDoc.Text.Trim + "' Order By DescMotivo")
            If Swap.RecordCount > 0 Then
                While Not Swap.EOF
                    cMotivo.Items.Add(Trim(Swap("DescMotivo").Value))
                    Swap.MoveNext()
                End While
            End If
        End If
        cMotivo.Text = ""

        'Ver Documentos Referencia
        cTipoDocRef.Items.Clear()
        cTipoDocRef.Items.Add("")
        If cTipoDoc.Text <> "" Then
            TDR = SQL("Select * from DocumentosRef where TipoDoc = '" + xTipoDoc.Text + "'")
            If TDR.RecordCount > 0 Then
                While Not TDR.EOF
                    TDo = SQL("Select * from TipoDoc where TipoDoc = '" + TDR("TipoDocRef").Value + "'")
                    If TDo.RecordCount > 0 Then
                        cTipoDocRef.Items.Add(Trim(TDo("DescTipoDoc").Value))
                    End If
                    TDR.MoveNext()
                End While
            End If
        End If
        xNumero.Text = Correlativo(0, LocalActual, xTipoDoc.Text, xFecha.Value, 0, True)

        'Factura Exenta
        If xTipoDoc.Text = "FE" Then
            xIVA.BackColor = Color.Red
        Else
            xIVA.BackColor = xNeto.BackColor
        End If
    End Sub

    Private Sub Documentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()

        Respuesta = ""
        cTipoDoc.Items.Clear()
        TDo = SQL("Select * from TipoDoc Order by DescTipoDoc")
        If TDo.RecordCount > 0 Then
            While Not TDo.EOF
            DoEvents()
            cTipoDoc.Items.Add(Trim(TDo("DescTipoDoc").Value))
            If gClave = "W" Then
                If cTipoDoc.Text = "" Then
                    If TDo("TipoDoc").Value = "FV" Then
                            Respuesta = Trim(TDo("DescTipoDoc").Value)
                        End If
                End If
            End If
            TDo.MoveNext()
            End While
        End If
        cTipoDoc.Text = Respuesta

        cFPago.Items.Clear()
        FPa = SQL("Select * from FPagos Order by DescFPago")
        While Not FPa.EOF
            DoEvents()
            cFPago.Items.Add(Trim(FPa("DescFPago").Value))
            If gClave = "W" Then
                If FPa("FPago").Value = "C" Then
                    cFPago.Text = Trim(FPa("DescFPago").Value)
                End If
            End If
            FPa.MoveNext()
        End While

        cFPago.Text = "Efectivo"

        xVendedor.Text = UsuarioActual

        xFecha.Value = Now.Date
        Loc = SQL("Select NombreLocal from Locales where Local = " + LocalActual.ToString)
        If Loc.RecordCount > 0 Then
            xLocal.Text = Loc.Fields("NombreLocal").Value
        Else
            xLocal.Text = ""
        End If

        If Not Supervisor Then
            xVendedor.Text = ""
            xVendedor.Enabled = True
            xVendedor.ReadOnly = False
        Else
            xVendedor.Text = UsuarioActual
        End If
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Limpia
    End Sub
    Private Sub Limpia(Optional wForzar As Boolean = False)
        If Not wForzar Then
            If xTabla.Rows.Count > 1 Then
                If Not Pregunta("¿Desea Limpiar Datos?") Then
                    Exit Sub
                End If
            End If
        End If

        xFecha.Value = Now.Date
        xNumero.Text = ""
        cTipoDoc.Text = ""
        cFPago.Text = "CHEQUE"
        xRut.Text = "__.___.___-_"
        xNombre.Text = ""
        xArticulo.Text = ""
        xDescripcion.Text = ""
        xObs.Text = ""
        xGlosa = ""
        Titulos()
        xSubTotal.Text = 0
        xDescuento.Text = 0
        xNeto.Text = 0
        xIVA.Text = 0
        xTotal.Text = 0
        xNumDocRef.Text = ""
        oElectronica.Checked = True

        xFEP.Text = 0
        xHAR.Text = 0
        xCAR.Text = 0
        xTAB.Text = 0
        xMIN.Text = 0
        xBEB.Text = 0
        xCER.Text = 0
        xVIN.Text = 0
        xLIC.Text = 0

        If Not Supervisor Then
            xVendedor.Text = ""
            xVendedor.Enabled = True
            xVendedor.ReadOnly = False
        Else
            xVendedor.Text = UsuarioActual
        End If

        xNumDocRef.Text = ""
        cTipoDocRef.Text = ""
        xFechaDocRef.Value = "01/01/2000"
        xCliente.Text = ""
        xDireccion.Text = ""
        nLineas.Text = 0
        cTipoDocRef.Text = ""
        Calcular_Total()
        Agregar.Enabled = True
        bEliminar.Enabled = True
        BuscarArt.Enabled = True
        bLimpiarArt.Enabled = True
        xArticulo.Enabled = True
        xDescripcion.Enabled = True
        xCliente.Enabled = True
        bBuscarCli.Enabled = True
        bCrearCli.Enabled = True
        xFechaDocRef.Enabled = False

        xNumero.Text = Correlativo(0, LocalActual, xTipoDoc.Text, xFecha.Value, 0, True)
    End Sub

    Private Sub Salir_Click(sender As Object, e As EventArgs) Handles Salir.Click
        Me.Close()
    End Sub

    Private Sub Documentos_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If xTabla.Rows.Count - 1 > 0 Then
            If Not Pregunta("¿Desea Salir?") Then
                e.Cancel = 1
            End If
        End If
    End Sub

    Private Sub xArticulo_TextChanged(sender As Object, e As EventArgs) Handles xArticulo.TextChanged

    End Sub

    Sub Titulos()
        xTabla.Redraw = True

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 22

        xTabla.SetData(0, T_ID, "Id")
        xTabla.SetData(0, T_ARTICULO, "Artículo")
        xTabla.SetData(0, T_DESCRIPCION, "Descripción")
        xTabla.SetData(0, T_UNIDAD, "Unidad")
        xTabla.SetData(0, T_BARRA, "Barra")
        xTabla.SetData(0, T_CANTIDAD, "Cantidad")
        xTabla.SetData(0, T_NETO, "Precio Neto")
        xTabla.SetData(0, T_PVENTA, "Precio Venta")
        xTabla.SetData(0, T_SUBTOTAL, "SubTotal")

        xTabla.SetData(0, T_IVA, "IVA")
        xTabla.SetData(0, T_EXE, "EXE")
        xTabla.SetData(0, T_MIN, "MIN")
        xTabla.SetData(0, T_BEB, "BEB")
        xTabla.SetData(0, T_VIN, "VIN")
        xTabla.SetData(0, T_CER, "CER")
        xTabla.SetData(0, T_LIC, "LIC")
        xTabla.SetData(0, T_CAR, "CAR")
        xTabla.SetData(0, T_HAR, "HAR")
        xTabla.SetData(0, T_TAB, "TAB")
        xTabla.SetData(0, T_FEP, "FEP")
        xTabla.SetData(0, T_LOG, "LOG")
        xTabla.SetData(0, T_OTRO, "OTRO")

        xTabla.Cols(T_ID).Width = 0
        xTabla.Cols(T_ARTICULO).Width = 100
        xTabla.Cols(T_DESCRIPCION).Width = 280
        xTabla.Cols(T_UNIDAD).Width = 80
        xTabla.Cols(T_BARRA).Width = 0
        xTabla.Cols(T_CANTIDAD).Width = 100
        xTabla.Cols(T_NETO).Width = 100
        xTabla.Cols(T_SUBTOTAL).Width = 100

        xTabla.Cols(T_IVA).Width = 0
        xTabla.Cols(T_EXE).Width = 0
        xTabla.Cols(T_MIN).Width = 0
        xTabla.Cols(T_BEB).Width = 0
        xTabla.Cols(T_VIN).Width = 0
        xTabla.Cols(T_CER).Width = 0
        xTabla.Cols(T_LIC).Width = 0
        xTabla.Cols(T_CAR).Width = 0
        xTabla.Cols(T_HAR).Width = 0
        xTabla.Cols(T_TAB).Width = 0
        xTabla.Cols(T_FEP).Width = 0
        xTabla.Cols(T_LOG).Width = 0
        xTabla.Cols(T_OTRO).Width = 0

        xTabla.Cols(T_ID).TextAlign = TextAlignEnum.LeftCenter
        xTabla.Cols(T_ARTICULO).TextAlign = TextAlignEnum.LeftCenter
        xTabla.Cols(T_DESCRIPCION).TextAlign = TextAlignEnum.LeftCenter
        xTabla.Cols(T_UNIDAD).TextAlign = TextAlignEnum.LeftCenter
        xTabla.Cols(T_BARRA).TextAlign = TextAlignEnum.LeftCenter
        xTabla.Cols(T_CANTIDAD).TextAlign = TextAlignEnum.RightCenter
        xTabla.Cols(T_NETO).TextAlign = TextAlignEnum.RightCenter
        xTabla.Cols(T_PVENTA).TextAlign = TextAlignEnum.RightCenter
        xTabla.Cols(T_SUBTOTAL).TextAlign = TextAlignEnum.RightCenter

        xTabla.Cols(T_CANTIDAD).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_NETO).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_PVENTA).TextAlignFixed = TextAlignEnum.RightCenter
        xTabla.Cols(T_SUBTOTAL).TextAlignFixed = TextAlignEnum.RightCenter

    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        If e.KeyChar = vbCr Then
            xArticulo_Cargar()
        End If
    End Sub

    Sub xArticulo_Cargar()
        If Trim(xArticulo.Text) <> "" Then
            xArticulo.Text = BuscaBarra(xArticulo.Text)
            If Trim(xArticulo.Text) = "" Then
                MsgError("Artículo No Existe")
                bLimpiarArt_Click()
            Else
                Art = SQL("Select * from Articulos where Articulo = '" & Trim(xArticulo.Text) & "'")
                If Art.RecordCount > 0 Then
                    xDescripcion.Text = Trim(Art("Descripcion").Value)
                    Agregar.Focus()
                Else
                    MsgError("Artículo No Encontrado")
                    Call bLimpiarArt_Click()
                End If
            End If
        End If
    End Sub

    Private Sub xFEPP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xFEP.KeyPress
        If e.KeyChar = vbCr Then
            Calcular_Total()
        End If
    End Sub

    Private Sub xMIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMIN.KeyPress
        If e.KeyChar = vbCr Then
            Calcular_Total()
        End If
    End Sub

    Private Sub xCER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMIN.KeyPress
        If e.KeyChar = vbCr Then
            Calcular_Total()
        End If
    End Sub

    Private Sub xVIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMIN.KeyPress
        If e.KeyChar = vbCr Then
            Calcular_Total()
        End If
    End Sub

    Private Sub xLIC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMIN.KeyPress
        If e.KeyChar = vbCr Then
            Calcular_Total()
        End If
    End Sub

    Private Sub xCAR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMIN.KeyPress
        If e.KeyChar = vbCr Then
            Calcular_Total()
        End If
    End Sub

    Private Sub xIHA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMIN.KeyPress
        If e.KeyChar = vbCr Then
            Calcular_Total()
        End If
    End Sub

    Private Sub xTAB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMIN.KeyPress
        If e.KeyChar = vbCr Then
            Calcular_Total()
        End If
    End Sub

    Private Sub xCliente_TextChanged(sender As Object, e As EventArgs) Handles xCliente.TextChanged

    End Sub

    Private Sub xBEB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMIN.KeyPress
        If e.KeyChar = vbCr Then
            Calcular_Total()
        End If
    End Sub

    Private Sub xCliente_GotFocus(sender As Object, e As EventArgs) Handles xCliente.GotFocus
        xCliente.SelectAll()
    End Sub

    Private Sub xDescuento_TextChanged(sender As Object, e As EventArgs) Handles xDescuento.TextChanged
        Call Calcular_Total()
    End Sub

    Private Sub xNumero_TextChanged(sender As Object, e As EventArgs) Handles xNumero.TextChanged

    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        If e.KeyChar = vbCr Then
            Sacar_Cliente
        End If
    End Sub

    Private Sub Sacar_Cliente()

        If Val(xCliente.Text) > 0 Then
            If Buscar("Clientes", "Cliente", xCliente.Text) Then
                Cli = Swap
                xRut.Text = Cli("Rut").Value
                xNombre.Text = Cli("Nombre").Value
                xDireccion.Text = Trim(Cli("Direccion").Value)
                xCiudad.Text = Saca_Ciudad(Cli.Fields("Ciudad").Value)
                xComuna.Text = Saca_Comuna(Cli.Fields("Comuna").Value)
                cFPago.Text = BuscarCampo("FPagos", "DescFpago", "FPago", Cli("FPago").Value)
                xGlosa = Cli("Glosa").Value.ToString.Trim
            Else
                MsgError("Cliente no Existe")
                xNombre.Text = ""
                xRut.Text = "__.___.___-_"
                xDireccion.Text = ""
                xCiudad.Text = ""
                xComuna.Text = ""
                xGlosa = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub xNumero_LostFocus(sender As Object, e As EventArgs) Handles xNumero.LostFocus
        Try
            If Val(xNumero.Text) > 0 Then
                If Buscar("TipoDoc", "DescTipoDoc", cTipoDoc.Text) Then
                    xTipoDoc.Text = Swap("TipoDoc").Value
                    ModoBodega = Swap("Modo").Value
                    ConPagos = Swap("Pagos").Value
                Else
                    MsgError("Error en Tipo de Documento")
                    Exit Sub
                End If
                DocG = SQL("Select * from DocumentosG where Local=" + Num(LocalActual) + " and TipoDoc = '" + xTipoDoc.Text + "' and Numero =" + Num(xNumero.Text))
                If DocG.RecordCount > 0 Then
                    MsgError("El Documento ya fue Ingresado en el Sistema")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub xRut_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles xRut.MaskInputRejected

    End Sub

    Private Sub xNumDocRef_GotFocus(sender As Object, e As EventArgs) Handles xNumDocRef.GotFocus
        xNumDocRef.SelectAll()
    End Sub

    Private Sub xTabla_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles xTabla.Click
        Try
            If xTabla.GetData(xTabla.Row, T_ARTICULO) = "0" Then
                If xTabla.Col = T_CANTIDAD Or xTabla.Col = T_NETO Or xTabla.Col = T_DESCRIPCION Then
                    xTabla.StartEditing()
                End If
            Else
                If xTabla.Col = T_CANTIDAD Then
                    xTabla.StartEditing()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub xRut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xRut.KeyPress
        If e.KeyChar = vbCr Then
            If xRut.Text <> "__.___.___-_" Then
                If Buscar("Clientes", "Rut", xRut.Text) Then
                    xNombre.Text = Swap("Nombre").Value
                Else
                    MsgError("Cliente no Existe")
                    xNombre.Text = ""
                    xRut.Text = "__.___.___-_"
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub xTabla_AfterEdit(sender As Object, e As RowColEventArgs) Handles xTabla.AfterEdit
        If xTabla.Col <> T_DESCRIPCION Then
            If Not IsNumeric(xTabla.GetData(xTabla.Row, xTabla.Col)) Then
                MsgError("Cantidad Incorrecta")
                xTabla.SetData(xTabla.Row, xTabla.Col, 0)
                Exit Sub
            End If
            If Not Validar_Stocks(BodegaActual, xTabla.GetData(xTabla.Row, T_ARTICULO), xTabla.GetData(xTabla.Row, T_CANTIDAD)) Then
                MsgError("No hay Stock")
                Exit Sub
            End If
            If xTabla.Col = T_NETO And xTabla.GetData(xTabla.Row, T_ARTICULO) = "0" Then
                xTabla.SetData(xTabla.Row, T_PVENTA, Math.Round(xTabla.GetData(xTabla.Row, T_NETO) * (1 + (gIVA / 100)), 0))
            End If
            Call Calcular_Total()
        Else
            xTabla.Col = T_NETO
        End If
        nLineas.Text = xTabla.Rows.Count - 1
    End Sub

    Private Sub xTabla_BeforeEdit(sender As Object, e As RowColEventArgs) Handles xTabla.BeforeEdit

    End Sub

    Sub Calcular_Total()
        Dim Total As Double, iLineas As Integer
        Dim wSubTotal As Double

        If xIVA.Text = "" Then xIVA.Text = 0

        xImpuestos.Text = Val(xFEP.Text) + Val(xTAB.Text) + Val(xMIN.Text) + Val(xBEB.Text) + Val(xVIN.Text) + Val(xCER.Text) + Val(xLIC.Text) + Val(xCAR.Text) + Val(xHAR.Text)

        Total = 0 : iLineas = 0
        For i = 1 To xTabla.Rows.Count - 1
            If Not IsNumeric(xTabla.GetData(i, T_CANTIDAD)) Then
                MsgError("Cantidad Incorrecta")
                xTabla.SetData(i, T_CANTIDAD, 0)
            End If
            Try
                If xTabla.GetData(i, T_CANTIDAD) = "" Then xTabla.SetData(i, T_CANTIDAD, 0)
                If xTabla.GetData(i, T_NETO) = "" Then xTabla.SetData(i, T_NETO, 0)
                If xTabla.GetData(i, T_SUBTOTAL) = "" Then xTabla.SetData(i, T_SUBTOTAL, 0)
            Catch ex As Exception
            End Try

            wSubTotal = Math.Round(xTabla.GetData(i, T_CANTIDAD) * xTabla.GetData(i, T_NETO), 0, MidpointRounding.AwayFromZero)

            If wSubTotal > MaxDouble Then
                MsgError("El SubTotal es demasiado alto, se debe ajustar el Precio o la Cantidad del Artículo:   " & xTabla.GetData(i, T_DESCRIPCION))
                xTabla.SetData(i, T_NETO, 1)
                i -= 1
                Continue For
            End If

            xTabla.SetData(i, T_SUBTOTAL, Math.Round(xTabla.GetData(i, T_CANTIDAD) * xTabla.GetData(i, T_NETO), 3))
            If xTipoDoc.Text = "FE" Or (xTipoDocRef.Text = "FE" And (xTipoDoc.Text = "NC" Or xTipoDoc.Text = "ND")) Then  'Factura Exenta
                xTabla.SetData(i, T_IVA, 0)
            Else
                xTabla.SetData(i, T_IVA, Math.Round((gIVA / 100) * wSubTotal, 0, MidpointRounding.AwayFromZero))
            End If
            Total = Total + CDbl(xTabla.GetData(i, T_SUBTOTAL))
            iLineas = iLineas + 1
        Next i

        xSubTotal.Text = Math.Round(Total, 0)
        If xDescuento.Text = "" Then xDescuento.Text = 0
        If xImpuestos.Text = "" Then xImpuestos.Text = 0
        xNeto.Text = Math.Round(Total - CDbl(xDescuento.Text), 0)

        'Faturas Exentas o Anulacion de ellas por NC o ND no llevan IVA
        If xTipoDoc.Text = "FE" Or (xTipoDocRef.Text = "FE" And (xTipoDoc.Text = "NC" Or xTipoDoc.Text = "ND")) Then  'Factura Exenta
            xIVA.Text = 0
        Else
            xIVA.Text = Math.Round(xNeto.Text * (gIVA / 100))
        End If
        xTotal.Text = CDbl(xNeto.Text) + CDbl(xIVA.Text) + CDbl(xImpuestos.Text)

        'Formatear Texto
        'xSubTotal.Text = Format(xSubTotal.Text, "###,###,##0")
        'xDescuento.Text = Format(xDescuento.Text, "###,###,##0")
        'xNeto.Text = Format(xNeto.Text, "###,###,##0")
        'xIVA.Text = Format(xIVA.Text, "###,###,##0")
        'xImpuestos.Text = Format(xImpuestos.Text, "###,###,##0")
        'xTotal.Text = Format(xTotal.Text, "###,###,##0")

        nLineas.Text = iLineas.ToString
    End Sub

    Private Sub xTabla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xTabla.KeyPress
        If e.KeyChar = vbCr Then
            If xTabla.Col = T_CANTIDAD Or xTabla.Col = T_NETO Then
                xTabla.StartEditing()
            End If
        End If
        If e.KeyChar = "*" Then
            xArticulo.Focus()
        End If
    End Sub

    Private Sub xTabla_KeyPressEdit(sender As Object, e As KeyPressEditEventArgs) Handles xTabla.KeyPressEdit
        If e.KeyChar = vbCr Then
            If xTabla.Col = T_CANTIDAD Then
                If Val(xTabla.GetData(xTabla.Row, T_NETO)) > 0 Then
                    'xArticulo.focus
                Else
                    xTabla.Col = T_NETO
                    SendKeys("{ENTER}")
                End If
            End If
        End If

    End Sub

    Function Esta_en_Tabla(tArticulo As Object) As Integer
        Esta_en_Tabla = 0
        For i = 1 To xTabla.Rows.Count - 1
            If Trim(xTabla.GetData(i, T_ARTICULO)) = Trim(tArticulo) And Val(tArticulo) <> 0 Then
                Esta_en_Tabla = i
            End If
        Next i
    End Function

    Sub Saca_Corr()
        If Trim(cTipoDoc.Text) = "" Then
            xNumero.Text = 0
        Else
            Swap = SQL("Select * from TipoDoc where DescTipoDoc = '" + Trim(cTipoDoc.Text) + "'")
            If Swap.RecordCount > 0 Then
                Cor = SQL("Select Correlativo from Correlativos  Where Local = " + Num(LocalActual) + " and Caja = " + Num(CajaActual) + " and TipoDoc = '" + Swap("TipoDoc").Value + "'")
                If Cor.RecordCount > 0 Then
                    xNumero.Text = Cor("Correlativo").Value
                Else
                    xNumero.Text = 0
                End If
            Else
                xNumero.Text = 0
            End If
        End If
    End Sub

    Private Sub xVendedor_TextChanged(sender As Object, e As EventArgs) Handles xVendedor.TextChanged
        If Trim(xVendedor.Text) = "" Then
            xNomVen.Text = ""
            BodegaParcial = BodegaActual
            Exit Sub
        End If
        If Buscar("Usuarios", "Usuario", Trim(xVendedor.Text), "NombreUsr,Bodega") Then
            xNomVen.Text = Trim(Swap("NombreUsr").Value)
        Else
            xNomVen.Text = ""
        End If
        BodegaParcial = BodegaActual
    End Sub

    Sub Cargar_Ticket()
        Dim Suma_Abonos As Double

        Titulos()

        Suma_Abonos = 0
        xTotal.Text = 0
        xSubTotal.Text = 0
        xDescuento .text= 0

        If Val(xNumDocRef.Text) = 0 Then
            Exit Sub
        End If

        TkD = SQL("Select * from TikDet where Ticket = " + Num(xNumDocRef.Text))
        If TkD.RecordCount > 0 Then
            While Not TkD.EOF
                xTabla.AddItem("")
                Lin = xTabla.Rows.Count - 1
                xTabla.SetData(Lin, T_ID, "")
                xTabla.SetData(Lin, T_ARTICULO, Trim(TkD("Articulo").Value))
                Art = SQL("Select * from Articulos where Articulo = '" + Trim(TkD("Articulo").Value) + "'")
                If Art.RecordCount > 0 Then
                    xTabla.SetData(Lin, T_DESCRIPCION, Trim(Art("Descripcion").Value))
                End If
                xTabla.SetData(Lin, T_UNIDAD, Trim(Art("Unidad").Value))
                xTabla.SetData(Lin, T_BARRA, Trim(TkD("Barra").Value))
                xTabla.SetData(Lin, T_CANTIDAD, CDbl(TkD("Cantidad").Value))
                xTabla.SetData(Lin, T_NETO, Saca_Neto(TkD("PVenta").Value))
                xTabla.SetData(Lin, T_SUBTOTAL, CDbl(xTabla.GetData(Lin, T_CANTIDAD)) * CDbl(xTabla.GetData(Lin, T_NETO)))
                bLimpiarArt_Click()
                xTabla.Focus()
                xTabla.Row = Lin
                xTabla.Col = T_CANTIDAD
                xTabla_Click()

                TkD.MoveNext()
            End While
        End If

        Suma_Abonos = 0
        Abo = SQL("Select Sum(Total) as Abonado, sum(Descuento) as Descuentos from Ventas where Ticket = " + Num(xNumDocRef.Text))
        If Abo.RecordCount > 0 Then
            If Not IsDBNull(Abo("Abonado").Value) Then
                Suma_Abonos = Abo("Abonado").Value
                xDescuento.Text = Format(Suma_Abonos, "###,###,###")
            End If
            If Not IsDBNull(Abo("Descuentos")) Then
                xDescuento.Text = Abo("Descuentos").Value
            End If
        End If
        xTabla.Focus()
        SendKeys("{ENTER}")
        Calcular_Total()

    End Sub

    Private Sub xVendedor_GotFocus(sender As Object, e As EventArgs) Handles xVendedor.GotFocus
        xVendedor.SelectAll()
    End Sub

    Public Function ValidarDeuda() As Boolean
        If xCliente.Text <> "" Then
            If cFPago.Text = "Crédito" Then
                If cTipoDoc.Text = "Factura de Venta" Then
                    Dim wDeuda, wPagado, wCredito, wSaldo, wTotalDeuda, wCupo As Double
                    Dim wCupos As String
                    'Sacar Credito Cliente
                    Cli = SQL("Select CupoMax From Clientes Where Cliente=" & Val(xCliente.Text) & "")
                    wCredito = Cli.Fields("CupoMax").Value
                    If wCredito > 0 Then
                        'Sacar Total de Deuda
                        Mov = SQL("Select Coalesce(SUM(Total),0) as Deuda From Documentosg " &
                                  " where Cliente=" & Val(xCliente.Text) & " and " &
                                  " FPago='Cr' and TipoDoc='F'")
                        wDeuda = Mov.Fields("Deuda").Value
                        'Sacar Total Pagado
                        Doc = SQL("Select Coalesce(SUM(Monto),0) as Pagado From DocumentosP " &
                                  " Where Cliente=" & Val(xCliente.Text) & " and TipoDoc='F' and FPago='Cr'")
                        wPagado = Doc.Fields("Pagado").Value
                        wSaldo = wDeuda - wPagado
                        wTotalDeuda = wSaldo + Val(xTotal.Text)
                        wCupo = wCredito - wSaldo

                        If wCupo < 0 Then
                            wCupos = 0
                        Else
                            wCupos = Format(wCupo, "###,###,###")
                        End If

                        If wTotalDeuda > wCredito Then
                            MsgError("No se generará Factura de Venta al Cliente actual." & vbCrLf &
                                  "El Cliente cuenta con una deuda de $" & Format(wSaldo, "###,###,###") & vbCrLf &
                                  "Saldo Disponible a Favor de $" & wCupos)
                            ValidarDeuda = True
                            Exit Function
                        End If
                    End If

                End If
            End If
        End If
        ValidarDeuda = False
    End Function

    Private Sub xArticulo_Leave(sender As Object, e As EventArgs) Handles xArticulo.Leave

    End Sub

    Private Sub cTipoDocRef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoDocRef.SelectedIndexChanged
        xFechaDocRef.Enabled = False
        TDo = SQL("Select * from TipoDoc where DescTipoDoc = '" + cTipoDocRef.Text + "'")
        If TDo.RecordCount > 0 Then
            xTipoDocRef.Text = TDo("TipoDoc").Value
            If TDo("TipoDoc").Value = "OC" Then
                xFechaDocRef.Enabled = True
            End If
        Else
            cTipoDocRef.Text = ""
            xTipoDocRef.Text = ""
        End If
    End Sub

    Private Sub bDirectorio_Click(sender As Object, e As EventArgs) Handles bDirectorio.Click
        Abrir_Documento(Directorio_PDF)
    End Sub

    Private Sub xTabla_BeforeResizeColumn(sender As Object, e As RowColEventArgs) Handles xTabla.BeforeResizeColumn

    End Sub
End Class