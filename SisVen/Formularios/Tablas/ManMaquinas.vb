Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions
Imports ClosedXML.Excel

Public Class ManMaquinas

    Private Sub ManMaquinas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cUbicacion.Items.Add("")
        cUbicacion.Items.Add("Centro de Distribución")
        cUbicacion.Items.Add("Cliente")
        cUbicacion.Items.Add("Taller de Reparaciones")

        cEstado.Items.Add("")
        cEstado.Items.Add("Activa")
        cEstado.Items.Add("Extraviada")

        Limpiar()
        bGuardar.Text = "Guardar"
        xID.Focus()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub bNuevo_Click(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles bNuevo.Click
        Try
            Limpiar_Datos()
            xID.Focus()
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Sub Limpiar_Datos()
        xID.Clear()
        xMarca.Clear()
        xModelo.Clear()
        cUbicacion.Text = ""
        xCliente.Clear()
        xNombre.Clear()
        xRut.Clear()
        xSucursal.Clear()
        xGarantia.Clear()
        xGuia.Clear()
        dFechaA.Value = CDate("01/01/2000")
        xTerritorio.Clear()
        cEstado.Text = ""
        dFechaR.Value = CDate("01/01/2000")
        xCliente.Enabled = True

        If cUbicacion.Text = "Centro de Distribución" Then
            lFecha.Text = "Fecha de Llegada"
        End If
        If cUbicacion.Text = "Cliente" Then
            lFecha.Text = "Fecha de Llegada"
        End If
        If cUbicacion.Text = "Taller de Reparaciones" Then
            lFecha.Text = "Fecha de Envío"
        End If
    End Sub

    Private Sub xID_KeyPress(Optional sender As Object = Nothing, Optional e As KeyPressEventArgs = Nothing) Handles xID.KeyPress
        e.NextControl(xMarca)
    End Sub

    Private Sub xID_Validating(sender As Object, e As CancelEventArgs) Handles xID.Validating
        If xID.Text.Trim = "" Then Exit Sub

        Try
            Dim mq = SQL("SELECT * FROM Maquinas WHERE ID = '" & xID.Text & "'")
            If mq.RecordCount > 0 Then
                xMarca.Text = mq.Fields("Marca").Text.Trim
                xModelo.Text = mq.Fields("Modelo").Text.Trim
                cUbicacion.Text = mq.Fields("Ubicacion").Text.Trim
                If mq.Fields("Ubicacion").Value = 1 Then
                    cUbicacion.Text = "Centro de Distribución"
                End If
                If mq.Fields("Ubicacion").Value = 2 Then
                    cUbicacion.Text = "Cliente"
                End If
                If mq.Fields("Ubicacion").Value = 3 Then
                    cUbicacion.Text = "Taller de Reparaciones"
                End If
                xCliente.Text = mq.Fields("Cliente").Text.Trim
                Dim cl = SQL("SELECT Nombre,Rut FROM Clientes WHERE Cliente = " & xCliente.Text)
                If cl.RecordCount > 0 Then
                    xNombre.Text = cl.Fields("Nombre").Text.Trim
                    xRut.Text = cl.Fields("Rut").Text.Trim
                    xSucursal.Text = cl.Fields("Glosa").Text.Trim
                Else
                    xCliente.Text = ""
                    xNombre.Text = ""
                    xRut.Text = ""
                    xSucursal.Text = ""
                End If
                xGarantia.Text = mq.Fields("Garantia").Text.Trim
                xGuia.Text = mq.Fields("Guia").Text.Trim
                dFechaA.Text = mq.Fields("FechaAsignacion").Text.Trim
                xTerritorio.Text = mq.Fields("Territorio").Text.Trim
                If mq.Fields("Estado").Value = 0 Then
                    cEstado.Text = "Activa"
                End If
                If mq.Fields("Estado").Value = 1 Then
                    cEstado.Text = "Extraviada"
                End If
                dFechaR.Text = mq.Fields("FechaRecuperacion").Text.Trim
                bGuardar.Text = "Modificar"
            Else
                If Pregunta("¿Máquina Nueva?") Then
                    Dim wSwap As String = xID.Text
                    bNuevo_Click()
                    xID.Text = wSwap
                    xMarca.Focus()
                    bGuardar.Text = "Guardar"
                Else
                    MsgError("Máquina no encontrada")
                    bNuevo_Click()
                    xMarca.Focus()
                    bGuardar.Text = "Guardar"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        If xID.Text = "" Then
            MsgError("Falta ID Máquina")
            xID.Focus()
            Exit Sub
        End If
        If xMarca.Text = "" Then
            MsgError("Falta Marca")
            xMarca.Focus()
            Exit Sub
        End If
        If xModelo.Text = "" Then
            MsgError("Falta Modelo")
            xModelo.Focus()
            Exit Sub
        End If
        If cUbicacion.Text.Trim = "" Then
            MsgError("Falta Ubicación")
            cUbicacion.Focus()
            Exit Sub
        End If

        If xTerritorio.Text.Trim = "" Then
            MsgError("Falta Territorio")
            xTerritorio.Focus()
            Exit Sub
        End If
        If cEstado.Text.Trim = "" Then
            MsgError("Falta Estado")
            cEstado.Focus()
            Exit Sub
        End If

        If cUbicacion.Text = "Cliente" Then
            If xCliente.Text.Trim = "" Or xNombre.Text = "" Then
                MsgError("Falta Cliente")
                xCliente.Focus()
                Exit Sub
            End If
            If xGarantia.Text.Trim = "" Then
                MsgError("Falta Garantía")
                xGarantia.Focus()
                Exit Sub
            End If
            If Not IsNumeric(xGarantia.Text) Then
                MsgError("Número de Garantía Incorrecto")
                xGarantia.Focus()
                Exit Sub
            End If
            If xGuia.Text.Trim = "" Then
                MsgError("Falta Guía")
                xGuia.Focus()
                Exit Sub
            End If
            If Not IsNumeric(xGuia.Text) Then
                MsgError("Número de Guía Incorrecto")
                xGuia.Focus()
                Exit Sub
            End If
        End If

        Dim xUbicacion As Integer = 0
        If cUbicacion.Text = "Centro de Distribución" Then
            xUbicacion = 1
        End If
        If cUbicacion.Text = "Cliente" Then
            xUbicacion = 2
        End If
        If cUbicacion.Text = "Taller de Reparaciones" Then
            xUbicacion = 3
        End If

        Dim xEstado As Integer = 0
        If cEstado.Text.Trim = "Activa" Then
            xEstado = 0
        End If
        If cEstado.Text.Trim = "Extraviada" Then
            xEstado = 1
        End If

        If xCliente.Text = "" Then xCliente.Text = "0"
        If xGarantia.Text = "" Then xGarantia.Text = "0"
        If xGuia.Text = "" Then xGuia.Text = "0"

        If bGuardar.Text = "Guardar" Then
            SQL("INSERT INTO MAQUINAS (ID, Marca, Modelo, Ubicacion, Cliente, Sucursal, Garantia, Guia, FechaAsignacion, Territorio, Estado, FechaRecuperacion) VALUES ('" & xID.Text.Trim & "','" & xMarca.Text.Trim & "','" & xModelo.Text.Trim & "'," & xUbicacion & "," & xCliente.Text.Trim & ",'" & xSucursal.Text.Trim & "'," & xGarantia.Text.Trim & "," & xGuia.Text.Trim & ",'" & Format(dFechaA.Value, "dd/MM/yyyy") & "','" & xTerritorio.Text.Trim & "'," & xEstado & ",'" & Format(dFechaR.Value, "dd/MM/yyyy") & "')")
            MsgBox("Máquina agregada correctamente")
            Auditoria(Me.Text, PR_GUARDAR, "", 0)
        Else
            SQL("UPDATE MAQUINAS SET Marca = '" & xMarca.Text.Trim & "', Modelo = '" & xModelo.Text.Trim & "', Ubicacion = " & xUbicacion & ", Cliente = " & xCliente.Text.Trim & ", Sucursal = '" & xSucursal.Text.Trim & "', Garantia = " & xGarantia.Text.Trim & ", Guia = " & xGuia.Text.Trim & ", FechaAsignacion = '" & Format(dFechaA.Value, "dd/MM/yyyy") & "', Territorio = '" & xTerritorio.Text.Trim & "', Estado = " & xEstado & ", FechaRecuperacion = '" & Format(dFechaR.Value, "dd/MM/yyyy") & "' WHERE Id = " & xID.Text & "")
            MsgBox("Máquina modificada correctamente")
            Auditoria(Me.Text, PR_MODIFICAR, "", 0)
        End If
        Limpiar()
    End Sub

    Private Sub Limpiar()
        Limpiar_Datos()

        bGuardar.Text = "Guardar"
        xID.Focus()
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub
    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        Try
            If IsNumeric(xID.Text) Then
                SQL("DELETE FROM Maquinas WHERE ID = " & xID.Text.Trim)
                MsgBox("Máquina Eliminada")
                Auditoria(Me.Text, PR_ELIMINAR, "", 0)
                Limpiar()
            End If
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
    End Sub

    Private Sub xDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMarca.KeyPress
        e.NextControl(bGuardar)
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Dim wQuery = "SELECT * FROM Maquinas Order by ID"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Modelo", Me, "Maquinas", xID)
    End Sub

    Private Sub bBuscarCli_Click(sender As Object, e As EventArgs) Handles bBuscarCli.Click
        Modulo = "ManMaquinas"
        BuscarClientes.Show()
        BuscarClientes.BringToFront()
    End Sub

    Private Sub xID_TextChanged(sender As Object, e As EventArgs) Handles xID.TextChanged

    End Sub

    Private Sub cUbicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cUbicacion.SelectedIndexChanged
        If cUbicacion.Text = "Centro de Distribución" Then
            lFecha.Text = "Fecha de Llegada"
        End If
        If cUbicacion.Text = "Cliente" Then
            lFecha.Text = "Fecha de Llegada"
        End If
        If cUbicacion.Text = "Taller de Reparaciones" Then
            lFecha.Text = "Fecha de Envío"
        End If

        If cUbicacion.Text = "Cliente" Or cUbicacion.Text = "" Then
            xCliente.Enabled = True
            xSucursal.Enabled = True
            xGarantia.Enabled = True
            xGuia.Enabled = True
        Else
            xCliente.Enabled = False
            xSucursal.Enabled = False
            xGarantia.Enabled = False
            xGuia.Enabled = False
            xCliente.Text = ""
            xNombre.Text = ""
            xRut.Text = ""
            xSucursal.Text = ""
            xGarantia.Text = ""
            xGuia.Text = ""
        End If
    End Sub

    Private Sub xCliente_TextChanged(sender As Object, e As EventArgs) Handles xCliente.TextChanged

    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        If e.KeyChar = vbCr Then
            Verificar_Cliente()
        End If
    End Sub

    Sub Verificar_Cliente()
        If xCliente.Text.Trim = "" Or xCliente.Text.Trim = "0" Then
            xCliente.Text = ""
            xNombre.Text = ""
            xRut.Text = ""
            xSucursal.Text = ""
            Exit Sub
        End If
        Dim cl = SQL("SELECT Nombre,Rut FROM Clientes WHERE Cliente = " & xCliente.Text)
        If cl.RecordCount > 0 Then
            xNombre.Text = cl.Fields("Nombre").Text.Trim
            xRut.Text = cl.Fields("Rut").Text.Trim
            xSucursal.Text = cl.Fields("Glosa").Text.Trim
        Else
            xCliente.Text = ""
            xNombre.Text = ""
            xRut.Text = ""
            xSucursal.Text = ""
        End If
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As CancelEventArgs) Handles xCliente.Validating
        Verificar_Cliente()
    End Sub


End Class