Imports SisVen

Public Class Movimientos
    Implements iFormulario
    Const T_ELIMINAR = 0
    Const T_ARTICULO = 1
    Const T_DESCRIPCION = 2
    Const T_BARRA = 3
    Const T_CANTIDAD = 4
    Const T_PUNITARIO = 5
    Const T_TOTAL = 6
    Dim AjusteGlobal As String
    Public Sub CargarRegistro(ByVal wControl As Control, ByVal wValor As String) Implements iFormulario.CargarRegistro
        wControl.Text = wValor
        wControl.Validate
    End Sub
    Private Sub Movimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombobox(cMovimientos, "TipoMov", "TipoMov", "DescTipo", " Where Visible=1 ORDER BY DescTipo")
        LoadCombobox(cBodegas, "Bodegas", "Bodega", "NombreBodega")
        LoadCombobox(cTipoDoc, "TipoDoc", "TipoDoc", "DescTipoDoc", " ORDER BY DescTipoDoc")
        LoadCombobox(cResponsable, "Usuarios", "usuario", "NombreUsr", " ORDER BY NombreUsr")
        xMovimiento.Text = SiguienteCorrelativo("MovGen")
        Titulos()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Sub CorrelativoMov()
        Cor = SQL("Select Top 1 Movimiento from MovGen Order by Movimiento Desc")
        If Cor.RecordCount = 0 Then
            xMovimiento.Text = 1
        Else
            xMovimiento.Text = Cor.Fields("Movimiento").Text + 1
        End If
    End Sub

    Private Sub bBuscarC_Click(sender As Object, e As EventArgs) Handles bBuscarC.Click
        Dim wQuery As String
        wQuery = "SELECT Cliente as 'Cliente', Nombre as 'Nombre' From Clientes"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Cliente", Me, "Clientes", xCliente)
    End Sub

    Private Sub bBuscarA_Click(sender As Object, e As EventArgs) Handles bBuscarA.Click
        Dim wQuery As String
        wQuery = "SELECT Articulo as 'Artículo', Descripcion as 'Descripción' From Articulos"
        Buscador.Show()
        Buscador.Configurar(wQuery, "Descripcion", Me, "Artículos", xArticulo)
    End Sub

    Private Sub xCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCliente.KeyPress
        ValidarDigitos(e)
        e.NextControl(xDocumento)
    End Sub

    Private Sub xCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xCliente.Validating
        If xCliente.Text.Trim <> "" Then
            Cli = SQL("SELECT Nombre FROM Clientes WHERE Cliente = '" & xCliente.Text.Trim & "'")
            If Cli.RecordCount > 0 Then
                xNombre.Text = Cli.Fields("Nombre").Text
            Else
                MsgError("Cliente no encontrado")
                xCliente.Clear()
                xCliente.Focus()
            End If
        End If
    End Sub

    Private Sub xDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xDocumento.KeyPress
        ValidarDigitos(e)
        e.NextControl(cTipoDoc)
    End Sub

    Private Sub xArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xArticulo.KeyPress
        e.NextControl(bCargar)
    End Sub

    Private Sub cMovimientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cMovimientos.SelectedIndexChanged
        If ValidarCombo(cMovimientos) Then
            cBodegas.Focus()
        End If
    End Sub

    Private Sub cBodegas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBodegas.SelectedIndexChanged
        If ValidarCombo(cBodegas) Then
            xCliente.Focus()
        End If
    End Sub

    Private Sub cTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoDoc.SelectedIndexChanged
        If ValidarCombo(cTipoDoc) Then
            cResponsable.Focus()
        End If
    End Sub

    Private Sub cResponsable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cResponsable.SelectedIndexChanged
        If ValidarCombo(cResponsable) Then
            xArticulo.Focus()
        End If
    End Sub

    Private Sub xArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles xArticulo.Validating
        If xArticulo.Text.Trim <> "" Then
            Art = SQL("SELECT Descripcion FROM Articulos WHERE Articulo = '" & xArticulo.Text.Trim & "'")
            If Art.RecordCount > 0 Then
                xDescripcion.Text = Art.Fields("Descripcion").Text
                xCantidad.Focus()
            Else
                MsgError("Artículo no encontrado")
                xArticulo.Clear()
                xDescripcion.Focus()
                xArticulo.Focus()
            End If
        End If
    End Sub
    Sub Titulos()

        xTabla.Redraw = False

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 7

        xTabla.Cols(T_ELIMINAR).Width = 70
        xTabla.Cols(T_ARTICULO).Width = 90
        xTabla.Cols(T_DESCRIPCION).Width = 308
        xTabla.Cols(T_BARRA).Width = 100
        xTabla.Cols(T_CANTIDAD).Width = 80
        xTabla.Cols(T_PUNITARIO).Width = 80
        xTabla.Cols(T_TOTAL).Width = 80

        xTabla.Cols(T_ELIMINAR).Caption = "Eliminar"
        xTabla.Cols(T_ARTICULO).Caption = "Artículo"
        xTabla.Cols(T_DESCRIPCION).Caption = "Descripción"
        xTabla.Cols(T_BARRA).Caption = "Barra"
        xTabla.Cols(T_CANTIDAD).Caption = "Cantidad"
        xTabla.Cols(T_PUNITARIO).Caption = "P.Unitario"
        xTabla.Cols(T_TOTAL).Caption = "Total"
        xTabla.Cols(T_ELIMINAR).ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
        xTabla.Redraw = True
    End Sub

    Private Sub bCargar_Click(sender As Object, e As EventArgs) Handles bCargar.Click
        If xArticulo.Text.Trim <> "" Then
            If xCantidad.Text.Trim <> "" Then
                Art = SQL("SELECT A.Articulo, A.Descripcion, A.PVenta FROM Articulos A " &
                      " WHERE A.Articulo = '" & xArticulo.Text.Trim & "'")

                If Art.RecordCount > 0 Then
                    xTabla.AddItem("")
                    xTabla.SetCellImage(xTabla.Rows.Count - 1, T_ELIMINAR, My.Resources.remove_table)
                    xTabla.SetData(xTabla.Rows.Count - 1, T_ARTICULO, Art.Fields("Articulo").Text)
                    xTabla.SetData(xTabla.Rows.Count - 1, T_DESCRIPCION, Art.Fields("Descripcion").Text)
                    'xTabla.SetData(xTabla.Rows.Count - 1, T_BARRA, Art.Fields("Barra").Text)
                    xTabla.SetData(xTabla.Rows.Count - 1, T_CANTIDAD, xCantidad.Text.Trim)
                    xTabla.SetData(xTabla.Rows.Count - 1, T_PUNITARIO, Art.Fields("PVenta").Text)
                    xTabla.SetData(xTabla.Rows.Count - 1, T_TOTAL,
                    Val(xTabla.GetData(xTabla.Rows.Count - 1, T_CANTIDAD)) * Val(xTabla.GetData(xTabla.Rows.Count - 1, T_PUNITARIO)))

                    xArticulo.Clear()
                    xDescripcion.Clear()
                    xCantidad.Clear()
                    xArticulo.Focus()
                Else
                    MsgError("Artículo no encontrado")
                    xArticulo.Clear()
                    xDescripcion.Clear()
                    xArticulo.Focus()
                End If
            Else
                MsgError("La cantidad debe ser mayor a 0")
                xCantidad.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub xCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xCantidad.KeyPress
        ValidarDigitos(e)
        e.NextControl(bCargar)
    End Sub

    Private Sub bAceptar_Click(sender As Object, e As EventArgs) Handles bAceptar.Click
        If ValidarCombo(cMovimientos) = False Then
            MsgError("Debe ingresar tipo de movimiento")
            cMovimientos.Focus()
            Exit Sub
        End If
        If ValidarCombo(cBodegas) = False Then
            MsgError("Debe ingresar Bodega")
            cBodegas.Focus()
            Exit Sub
        End If
        If xCliente.Text.Trim = "" Then
            MsgError("Debe ingresar Cliente")
            xCliente.Focus()
            Exit Sub
        End If
        If xDocumento.Text.Trim = "" Then
            MsgError("Debe ingresar numero de documento")
            xDocumento.Focus()
            Exit Sub
        End If
        If ValidarCombo(cTipoDoc) = False Then
            MsgError("Debe ingresar tipo documento")
            cTipoDoc.Focus()
            Exit Sub
        End If
        If ValidarCombo(cResponsable) = False Then
            MsgError("Debe indicar personal responsable")
            cResponsable.Focus()
            Exit Sub
        End If
        If xTabla.Rows.Count - 1 = 0 Then
            MsgError("Debe ingresar artículos al movimiento")
            xArticulo.Focus()
            Exit Sub
        End If

        Verificar()

        MvG = SQL("SELECT TOP 1 * FROM MovGen")
        MvG.AddNew()
        MvG.Fields("Fecha").Value = dFecha.Value
        MvG.Fields("Hora").Value = Saca_Hora(dFecha.Value)
        MvG.Fields("TipoMov").Value = cMovimientos.SelectedValue
        MvG.Fields("Local").Value = BuscarCampo("Bodegas", "Local", "bodega", cBodegas.SelectedValue)
        MvG.Fields("Bodega").Value = cBodegas.SelectedValue
        MvG.Fields("Destino").Value = 0
        MvG.Fields("Usuario").Value = UsuarioActual
        MvG.Fields("Estado").Value = "E"
        MvG.Fields("TipoDoc").Value = cTipoDoc.SelectedValue
        MvG.Fields("NumDoc").Value = xDocumento.Text.Trim
        MvG.Fields("Cliente").Value = xCliente.Text.Trim
        MvG.Fields("ObsTra").Value = xObservacion.Text.Trim
        MvG.Fields("Total").Value = Totales()
        MvG.Fields("Responsable").Value = cResponsable.SelectedValue
        MvG.Update()

        For i = 1 To xTabla.Rows.Count - 1
            MvD = SQL("Select Top 1 * from MovDet")
            MvD.AddNew()
            MvD.Fields("Movimiento").Value = xMovimiento.Text.Trim
            MvD.Fields("Fecha").Value = Now
            MvD.Fields("TipoMov").Value = cMovimientos.SelectedValue
            MvD.Fields("Articulo").Value = Trim(xTabla.GetData(i, T_ARTICULO))
            MvD.Fields("Barra").Value = xTabla.GetData(i, T_BARRA)
            MvD.Fields("Cantidad").Value = CDbl(xTabla.GetData(i, T_CANTIDAD))
            MvD.Fields("Precio").Value = Val(xTabla.GetData(i, T_PUNITARIO))
            MvD.Update()

            'Actualizar Stocks
            Stocks(Trim(xTabla.GetData(i, T_ARTICULO)), Val(cBodegas.SelectedValue),
                            BuscarCampo("Bodegas", "Local", "bodega", cBodegas.SelectedValue),
                            CDbl(xTabla.GetData(i, T_CANTIDAD)), AjusteGlobal)
        Next

        MsgBox("Movimiento N° " & xMovimiento.Text & " Registrado")

        If Pregunta("¿Desea imprimir movimiento?") = True Then
            Imprimir()
        End If
        Auditoria(Me.Text, PR_GUARDAR, "", 0)
        Limpiar()
        xMovimiento.Text = SiguienteCorrelativo("MovGen")
        cMovimientos.Focus()
    End Sub
    Private Function Totales() As Double
        Dim wTotal As Double
        For i = 1 To xTabla.Rows.Count - 1
            wTotal += xTabla.GetData(i, T_TOTAL)
        Next
        Return wTotal
    End Function
    Private Sub Verificar()
        If Buscar("TipoMov", "DescTipo", cMovimientos.Text, "*", "") Then
            TraspasoGlobal = Swap.Fields("TipoMov").Value
            AjusteGlobal = Swap.Fields("Ajuste").Value
        End If

        Bod = SQL("Select Bodega from Bodegas where NombreBodega = '" & Trim(cBodegas.Text) & "' and Local = " & Num(LocalActual))
        If Bod.RecordCount > 0 Then
            BodegaActual = Bod.Fields("Bodega").Value
        Else
            MsgError("Falta Bodega")
            Exit Sub
        End If

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        Limpiar()
        cMovimientos.Focus()
        xMovimiento.Text = SiguienteCorrelativo("MovGen")
    End Sub
    Sub Limpiar()
        LimpiarCampos(Me)
        Titulos()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
    Sub Imprimir()

        Dim wQuery = "Select MG.Movimiento,TM.DescTipo, MG.Fecha,L.Local,L.NombreLocal,B.Bodega,B.NombreBodega,UR.NombreUsr as UsrResponsable,UC.NombreUsr as UsrCreador,E.DescEstado," &
                     " TD.DescTipoDoc,MG.Numdoc,C.Nombre,MG.ObsTra,A.Articulo,A.Descripcion,MD.Barra,MD.Cantidad,MD.Precio" &
                     " FROM MovGen MG" &
                     " JOIN TipoMov TM ON MG.TipoMov = TM.TipoMov" &
                     " JOIN Locales L ON MG.Local = L.Local" &
                     " JOIN Bodegas B ON MG.Bodega = B.Bodega" &
                     " JOIN Usuarios UR ON MG.Responsable = UR.Usuario" &
                     " JOIN Usuarios UC ON MG.Usuario = UC.Usuario" &
                     " JOIN Estados E ON MG.Estado = E.Estado and E.Tipo = 'V'" &
                     " JOIN TipoDoc TD ON MG.TipoDoc = TD.TipoDoc" &
                     " JOIN Clientes C ON MG.Cliente = C.Cliente" &
                     " JOIN MovDet MD ON MG.Movimiento = MD.Movimiento" &
                     " JOIN Articulos A ON MD.Articulo = A.Articulo WHERE MG.Movimiento = '" & xMovimiento.Text.Trim & "'"

        Dim wReporte As New ReporteMovimiento
        Dim Lista = New List(Of MovimientoReporte)
        Dim ListParametros = New List(Of ParametrosReporte)

        Par = SQL("SELECT * FROM Parametros")
        If Par.RecordCount = 1 Then ListParametros.Add(New ParametrosReporte With {.Logo = Par.Fields("Logo1").Value})

        Swap = SQL(wQuery)
        While Not Swap.EOF
            Lista.Add(New MovimientoReporte With {.Movimiento = Swap.Fields("Movimiento").Text,
                                                  .TipoMov = Swap.Fields("DescTipo").Text,
                                                  .Fecha = Swap.Fields("Fecha").Text,
                                                  .Local = Swap.Fields("Local").Text,
                                                  .NombreLocal = Swap.Fields("NombreLocal").Text,
                                                  .Bodega = Swap.Fields("Bodega").Text,
                                                  .NombreBodega = Swap.Fields("NombreBodega").Text,
                                                  .UsuarioC = Swap.Fields("UsrResponsable").Text,
                                                  .UsuarioR = Swap.Fields("UsrCreador").Text,
                                                  .Estado = Swap.Fields("DescEstado").Text,
                                                  .TipoDoc = Swap.Fields("DescTipoDoc").Text,
                                                  .NumDoc = Swap.Fields("NumDoc").Text,
                                                  .Cliente = Swap.Fields("Nombre").Text,
                                                  .Observacion = Swap.Fields("ObsTra").Text,
                                                  .Articulo = Swap.Fields("Articulo").Text,
                                                  .Descripcion = Swap.Fields("Descripcion").Text,
                                                  .Barra = Swap.Fields("Barra").Text,
                                                  .Cantidad = Swap.Fields("Cantidad").Text,
                                                  .PVenta = Swap.Fields("Precio").Text})
            Swap.MoveNext()
        End While

        If Lista.Count > 0 Then
            wReporte.Database.Tables(0).SetDataSource(Lista)
            wReporte.Database.Tables(1).SetDataSource(ListParametros)
            wReporte.PrintToPrinter(1, False, 0, 0)
        Else
            Mensaje("No se encuentran datos para la selección indicada")
            Close()
        End If
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Col = T_ELIMINAR Then
            xTabla.RemoveItem(xTabla.Row)
        End If
    End Sub
End Class