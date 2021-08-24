Public Class ManArticulos
    Dim wFamilia, wSubFamilia, wUnidad As String

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        LimpiarCampos()
        xArticulo.Clear()
        xArticulo.Focus()
    End Sub
    Sub LimpiarCampos()
        xSKU.Clear()
        xDescripcion.Clear()
        xCosto.Clear()
        xPrecioVenta.Clear()
        oExento.Checked = False
        xIva.Clear()
        xMinerales.Clear()
        xBebidas.Clear()
        xPetroleo.Clear()
        xTabaco.Clear()
        xVinos.Clear()
        xLicores.Clear()
        xHarina.Clear()
        xCarne.Clear()
        xUnidad.Clear()
        xFamilia.Clear()
        xSubfamilia.Clear()
        cUnidad.SelectedIndex = -1
        cFamilia.SelectedIndex = -1
        cSubFamilia.SelectedIndex = -1
        cEstado.SelectedIndex = -1
        xArticulo.Tag = ""
    End Sub
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Close()
    End Sub

    Private Sub ManArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cUnidad.LoadItems("Unidades", "DescUnidad")
        cUnidad.SelectedIndex = 0
        cFamilia.LoadItems("Familias", "DescFamilia")
        cFamilia.SelectedIndex = 0
        cEstado.LoadItems("Estados", "DescEstado", " Tipo='A'")
        cEstado.SelectedIndex = 0
        Auditoria(Text, "Ingresó", "", 0)
    End Sub

    Private Sub xUnidad_Validating(sender As Object, e As EventArgs) Handles xUnidad.Validating
        If Trim(xUnidad.Text) = "" Then
            cUnidad.SelectedIndex = -1
            Exit Sub
        End If
        'If xUnidad.Tag = Trim(xUnidad.Text) Then Exit Sub

        Uni = SQL("SELECT DescUnidad FROM Unidades WHERE Unidad='" & Trim(xUnidad.Text) & "'")
        If Uni.EOF Then
            MsgError("La Unidad Ingresada no Existe")
            xUnidad.Clear()
            cUnidad.SelectedIndex = -1
            Exit Sub
        End If
        wUnidad = Uni.Fields("DescUnidad").Text
        cUnidad.Text = wUnidad
        cUnidad.Tag = wUnidad
        xUnidad.Tag = Trim(xUnidad.Text)
    End Sub

    Private Sub xFamilia_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xFamilia.Validating
        If Trim(xFamilia.Text) = "" Then
            cFamilia.SelectedIndex = -1
            Exit Sub
        End If
        ValidarDigitos(sender)
        ' If xFamilia.Tag = Val(xFamilia.Text) Then Exit Sub

        Fami = SQL("SELECT DescFamilia FROM Familias WHERE Familia='" & Val(xFamilia.Text) & "'")
        If Fami.EOF Then
            MsgError("La Familia Ingresada no Existe")
            xFamilia.Clear()
            cFamilia.SelectedIndex = -1
            xSubfamilia.Clear()
            cSubFamilia.Items.Clear()
            Exit Sub
        End If
        wFamilia = Fami.Fields("DescFamilia").Text
        cFamilia.Text = wFamilia
        cFamilia.Tag = wFamilia
        xFamilia.Tag = Val(xFamilia.Text)
        cSubFamilia.LoadItems("SubFamilias", "DescSubFamilia", " Familia=" & Val(xFamilia.Text) & "")
        cSubFamilia.SelectedIndex = 0
    End Sub

    Private Sub xSubFamilia_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xSubfamilia.Validating
        If Trim(xSubfamilia.Text) = "" Then
            cSubFamilia.SelectedIndex = -1
            Exit Sub
        End If
        ValidarDigitos(sender)
        'If xSubfamilia.Tag = Val(xSubfamilia.Text) Then Exit Sub

        Fami = SQL("SELECT DescSubFamilia FROM SubFamilias WHERE SubFamilia='" & Val(xSubfamilia.Text) & "'")
        If Fami.EOF Then
            MsgError("La SubFamilia Ingresada no Existe")
            xSubfamilia.Clear()
            cSubFamilia.SelectedIndex = -1
            Exit Sub
        End If
        wSubFamilia = Fami.Fields("DescSubFamilia").Text
        cSubFamilia.Text = wSubFamilia
        cSubFamilia.Tag = wSubFamilia
        xSubfamilia.Tag = Val(xFamilia.Text)
    End Sub
    Private Sub cUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cUnidad.SelectedIndexChanged
        If Trim(cUnidad.Text) = "" Then
            xUnidad.Clear()
            Exit Sub
        End If
        Uni = SQL("SELECT Unidad FROM Unidades WHERE DescUnidad='" & Trim(cUnidad.Text) & "'")
        If Uni.EOF Then
            MsgError("La Unidad Seleccionada no está Disponible")
            cUnidad.LoadItems("Unidades", "DescUnidad")
            cUnidad.SelectedIndex = 0
            Exit Sub
        End If
        wUnidad = Uni.Fields("Unidad").Text
        xUnidad.Text = wUnidad
        xUnidad.Tag = wUnidad
        cUnidad.Tag = Trim(cUnidad.Text)
    End Sub

    Private Sub cFamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cFamilia.SelectedIndexChanged
        If Trim(cFamilia.Text) = "" Then
            xFamilia.Clear()
            Exit Sub
        End If
        Fami = SQL("SELECT Familia FROM Familias WHERE DescFamilia='" & Trim(cFamilia.Text) & "'")
        If Fami.EOF Then
            MsgError("La Familia Seleccionada no está Disponible")
            cFamilia.LoadItems("Familias", "DescFamilia")
            cFamilia.SelectedIndex = 0
            Exit Sub
        End If
        wFamilia = Fami.Fields("Familia").Text
        xFamilia.Text = wFamilia
        xFamilia.Tag = wFamilia
        cFamilia.Tag = Trim(cFamilia.Text)
        cSubFamilia.LoadItems("SubFamilias", "DescSubFamilia", " Familia=" & Val(xFamilia.Text) & "")
        cSubFamilia.SelectedIndex = 0

    End Sub

    Private Sub cSubFamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cSubFamilia.SelectedIndexChanged
        If Trim(cSubFamilia.Text) = "" Then
            xSubfamilia.Clear()
            Exit Sub
        End If
        Fami = SQL("SELECT SubFamilia FROM SubFamilias WHERE DescSubFamilia='" & Trim(cSubFamilia.Text) & "'")
        If Fami.EOF Then
            MsgError("La Sub Familia Seleccionada no está Disponible")
            cSubFamilia.LoadItems("SubFamilias", "DescSubFamilia", " Familia=" & Val(xFamilia.Text) & "")
            cSubFamilia.SelectedIndex = 0
            Exit Sub
        End If
        wSubFamilia = Fami.Fields("SubFamilia").Text
        xSubfamilia.Text = wSubFamilia
        xSubfamilia.Tag = wSubFamilia
        cSubFamilia.Tag = Trim(cSubFamilia.Text)
    End Sub

    Private Sub cEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cEstado.SelectedIndexChanged
        If Trim(cEstado.Text) = "" Then
            Exit Sub
        End If
        Est = SQL("SELECT Estado FROM Estados WHERE DescEstado='" & Trim(cEstado.Text) & "' and Tipo='A'")
        If Est.EOF Then
            MsgError("El Estado Seleccionado no está Disponible")
            cEstado.LoadItems("Estados", "DescEstado", " Tipo='A'")
            cEstado.SelectedIndex = 0
            Exit Sub
        End If
        cEstado.Tag = Est.Fields("Estado").Text
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        If Trim(xArticulo.Text) = "" Then
            MsgError("Debe ingresar un Artículo")
            xArticulo.Focus()
            Exit Sub
        End If
        If Trim(xDescripcion.Text) = "" Then
            MsgError("Debe ingresar una Descripción")
            xDescripcion.Focus()
            Exit Sub
        End If
        If Trim(xUnidad.Text) = "" Or Trim(cUnidad.Text) = "" Then
            MsgError("Debe ingresar una Unidad")
            xUnidad.Focus()
            Exit Sub
        End If
        If Trim(xFamilia.Text) = "" Or Trim(cFamilia.Text) = "" Then
            MsgError("Debe ingresar un tipo de Familia")
            xFamilia.Focus()
            Exit Sub
        End If
        If Trim(xSubfamilia.Text) = "" Or Trim(cSubFamilia.Text) = "" Then
            MsgError("Debe ingresar una Sub Familia")
            xSubfamilia.Focus()
            Exit Sub
        End If
        If Val(xCosto.Text) < 0 Then
            MsgError("Debe ingresar un Costo")
            xCosto.Focus()
            Exit Sub
        End If
        If Val(xPrecioVenta.Text) < 0 Then
            MsgError("Debe ingresar un Precio de Venta")
            xPrecioVenta.Focus()
            Exit Sub
        End If
        If Trim(cEstado.Text) = "" Then
            MsgError("Debe ingresar un Estado para el Artículo")
            cEstado.Focus()
            Exit Sub
        End If

        If xSKU.Text.Trim <> "" Then
            Dim wSKU = SQL("SELECT * FROM Articulos WHERE SKU = '" & xSKU.Text.Trim & "'")
            If wSKU.RecordCount > 0 Then
                If wSKU.Fields("Articulo").Text <> xArticulo.Text.Trim Then
                    MsgError("El SKU indicado pertenece a otro Artículo")
                    Exit Sub
                End If
            End If
        End If

        Dim wMensaje As String
        Art = SQL("SELECT * FROM Articulos WHERE Articulo = '" & Trim(xArticulo.Text) & "'")
        If Art.EOF Then
            Art.AddNew()
            wMensaje = "Artículo creado correctamente"
            Auditoria(Text, "Creó Artículo", "", 0)
        Else
            wMensaje = "Artículo modificado correctamente"
            Auditoria(Text, "Modificó Artículo", "", 0)
        End If

        Art.Fields("Articulo").Value = Trim(xArticulo.Text)
        Art.Fields("SKU").Value = Trim(xSKU.Text)
        Art.Fields("Descripcion").Value = Trim(xDescripcion.Text)
        Art.Fields("Unidad").Value = Trim(xUnidad.Text)
        Art.Fields("Familia").Value = xFamilia.Tag
        Art.Fields("SubFamilia").Value = xSubfamilia.Tag
        Art.Fields("Costo").Value = Val(xCosto.Text)
        Art.Fields("PVenta").Value = Val(xPrecioVenta.Text)
        Art.Fields("Estado").Value = cEstado.Tag
        Art.Fields("iIVA").Value = Val(xIva.Text)
        Art.Fields("iEXE").Value = oExento.Checked
        Art.Fields("iMIN").Value = Val(xMinerales.Text)
        Art.Fields("iBEB").Value = Val(xBebidas.Text)
        Art.Fields("iVIN").Value = Val(xVinos.Text)
        Art.Fields("iCER").Value = Val(xCervezas.Text)
        Art.Fields("iLIC").Value = Val(xLicores.Text)
        Art.Fields("iCAR").Value = Val(xCarne.Text)
        Art.Fields("iHAR").Value = Val(xHarina.Text)
        Art.Fields("iTAB").Value = Val(xTabaco.Text)
        Art.Fields("iFEP").Value = Val(xPetroleo.Text)
        Art.Fields("iLOG").Value = Val(xLogistica.Text)
        Art.Update()

        Mensaje(wMensaje)
        LimpiarCampos()
        xArticulo.Clear()
        xArticulo.Focus()
    End Sub


    Private Sub bEliminar_Click(sender As Object, e As EventArgs) Handles bEliminar.Click
        If Trim(xArticulo.Text) = "" Then
            MsgError("No hay un Artículo cargado")
            xArticulo.Focus()
            Exit Sub
        End If
        Art = SQL("SELECT Articulo FROM Articulos WHERE Articulo='" & Trim(xArticulo.Text) & "'")
        If Art.EOF Then
            MsgError("El Artículo ingresado no existe")
            LimpiarCampos()
            xArticulo.Clear()
            xArticulo.Focus()
            Exit Sub
        End If
        Art = SQL("SELECT TOP 1 Articulo FROM DocumentosD WHERE Articulo='" & Trim(xArticulo.Text) & "'")
        If Art.EOF Then
            If Pregunta("¿Desea eliminar este Artículo?") Then
                SQL("DELETE Articulos WHERE Articulo='" & Trim(xArticulo.Text) & "'")
                Auditoria(Text, "Eliminó Artículo", "", 0)
                Mensaje("Artículo eliminado correctamente")
                LimpiarCampos()
                xArticulo.Clear()
                xArticulo.Focus()
            End If
        Else
            MsgError("No se Puede eliminar este Artículo, Se encuentra utilizado en otra Tabla")
            Exit Sub
        End If
    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xUnidad.KeyPress, xDescripcion.KeyPress, xArticulo.KeyPress
        If e.KeyChar = vbCr Then
            NextControl(sender)
        End If
    End Sub

    Private Sub xOtro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xVinos.KeyPress, xTabaco.KeyPress, xPetroleo.KeyPress, xLicores.KeyPress, xIva.KeyPress, xHarina.KeyPress, xCarne.KeyPress, xBebidas.KeyPress
        ValidarDigitosDecimal(e)
        If e.KeyChar = vbCr Then
            NextControl(sender)
        End If
    End Sub

    Private Sub xOtro_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xVinos.Validating, xTabaco.Validating, xPetroleo.Validating, xLicores.Validating, xIva.Validating, xHarina.Validating, xCarne.Validating, xBebidas.Validating
        ValidarDigitos(sender, 2)
    End Sub

    Private Sub xCosto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xPrecioVenta.Validating, xCosto.Validating
        ValidarDigitos(sender)
    End Sub

    Private Sub xSubfamilia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xSubfamilia.KeyPress, xPrecioVenta.KeyPress, xFamilia.KeyPress, xCosto.KeyPress
        ValidarDigitos(e)
        If e.KeyChar = vbCr Then
            NextControl(sender)
        End If
    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        Modulo = "MantenedorArticulo"
        BuscarArticulos.ShowDialog()
    End Sub

    Private Sub bNuevo_Click(sender As Object, e As EventArgs) Handles bNuevo.Click
        Dim wArt = SQL("SELECT TOP 1 Articulo FROM Articulos WHERE (Articulo <> 'S') AND (Articulo <> '0') AND (Articulo <> '9999') Order By Articulo Desc")
        If wArt.RecordCount = 1 Then
            xArticulo.Text = Val(wArt.Fields("Articulo").Text) + 1
        Else
            xArticulo.Text = 1
        End If
    End Sub

    Sub LlenarEstado(ByVal wEstado As String)
        Est = SQL("SELECT DescEstado FROM Estados WHERE Estado='" & wEstado & "' AND Tipo='A'")
        If Est.EOF Then
            MsgError("El Estado no está disponible")
            Exit Sub
        End If
        cEstado.Text = Est.Fields("DescEstado").Text
    End Sub

    Public Sub xArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xArticulo.Validating
        If Trim(xArticulo.Text) = "" Then Exit Sub
        If xArticulo.Tag = Trim(xArticulo.Text) Then Exit Sub
        xArticulo.Tag = Trim(xArticulo.Text)
        Art = SQL("SELECT * FROM Articulos WHERE Articulo='" & Trim(xArticulo.Text) & "'")
        If Art.EOF Then
            LimpiarCampos()
            Exit Sub
        End If

        xArticulo.Text = Art.Fields("Articulo").Text
        xDescripcion.Text = Art.Fields("Descripcion").Text
        xSKU.Text = Art.Fields("SKU").Text
        xUnidad.Text = Art.Fields("Unidad").Text
        xUnidad_Validating(Nothing, Nothing)
        xFamilia.Text = Art.Fields("Familia").Text
        xFamilia_Validating(Nothing, Nothing)
        xSubfamilia.Text = Art.Fields("SubFamilia").Text
        xSubFamilia_Validating(Nothing, Nothing)
        xCosto.Text = Art.Fields("Costo").Text
        xPrecioVenta.Text = Art.Fields("PVenta").Text
        LlenarEstado(Art.Fields("Estado").Text)
        xIva.Text = Art.Fields("iIVA").Text
        oExento.Checked = Art.Fields("iEXE").Value
        xMinerales.Text = Art.Fields("iMIN").Text
        xBebidas.Text = Art.Fields("iBEB").Text
        xVinos.Text = Art.Fields("iVIN").Text
        xCervezas.Text = Art.Fields("iCER").Text
        xLicores.Text = Art.Fields("iLIC").Text
        xCarne.Text = Art.Fields("iCAR").Text
        xHarina.Text = Art.Fields("iHAR").Text
        xTabaco.Text = Art.Fields("iTAB").Text
        xPetroleo.Text = Art.Fields("iFEP").Text
        xLogistica.Text = Art.Fields("iLOG").Text

    End Sub
End Class