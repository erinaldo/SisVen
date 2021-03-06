Option Strict Off
Option Explicit On
Imports System.Collections.Generic
Imports System.IO

Friend Class Menu_Principal
    Inherits System.Windows.Forms.Form

    Dim wSeleccionado As String = ""
    Private Sub SiToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mSi.Click
        If Not Pregunta("?Desea salir de SisVen?") Then
            Exit Sub
        End If
        End
    End Sub

    Private Sub Menu_Principal_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Pregunta("?Desea salir de SisVen?") Then
            e.Cancel = True
        Else
            End
        End If
    End Sub
    Private Sub CargarLocales()
        cLocal.Text = ""
        cLocal.Items.Clear()
        Swap = SQL("SELECT NombreLocal,Local FROM Locales WHERE Local <> 0 Order by Local")
        If Swap.RecordCount > 0 Then
            While Not Swap.EOF
                cLocal.Items.Add(Swap.Fields("Local").Text & " ~ " & Swap.Fields("NombreLocal").Text)
                If cLocal.Text = "" Then
                    cLocal.Text = Swap.Fields("Local").Text & " ~ " & Swap.Fields("NombreLocal").Text
                    LocalActual = Swap("Local").Value
                    NombreLocalActual = Swap("NombreLocal").Value.ToString.Trim
                End If
                Swap.MoveNext()
            End While
            If Swap.RecordCount = 1 Then
                gMonoLocal = True
            Else
                gMonoLocal = False
            End If
            If Buscar("Locales", "Nombrelocal", NombreLocalActual, "*", "") Then
                cLocal.SelectedItem = (Swap.Fields("Local").Text & " ~ " & Swap.Fields("NombreLocal").Text)
            Else
                cLocal.Text = "Local No Reconocido"
            End If
        End If
    End Sub
    Private Sub Menu_Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolStripManager.Renderer = New Styles.CustomRenderer()
        Abrir()
        Visible = True
        DoEvents()
    End Sub

    Sub Mostrar_Parametros(Optional wModo As Boolean = True)
        Try
            Cursor = Cursors.WaitCursor

            CargarLocales()
            Parametrizar_Sistema()
            Parametros_DTE(LocalActual)

            Par = SQL("Select Top 1 * from Parametros")

            lUsuario.Text = NombreUsuarioActual
            lVersion.Text = Version
            lConexion.Text = "SQL " & P_SERVIDOR
            lLocal.Text = NombreLocalActual
            lBases.Text = P_DBASE
            lDTE.Text = FE_IP
            lAmbiente.Text = IIf(Demo, "DEMO", IIf(FE_Ambiente = "80", "Producci?n", "Homologaci?n"))
            gClave = P_CLAVE
            gIVA = Par.Fields("IVA").Value
            IvaGlobal = Par.Fields("IVA").Text

            BodegaActual = Retorna_TipoBodega(LocalActual, "P")
            lBodega.Text = BuscarCampo("Bodegas", "NombreBodega", "Bodega", BodegaActual)

            Loc = SQL("Select Local from Locales")
            If Loc.RecordCount = 1 Then gMonoLocal = 1 Else gMonoLocal = False

            If Buscar("Locales", "Nombrelocal", NombreLocalActual, "*", "") Then
                cLocal.SelectedItem = (Swap.Fields("Local").Text & " ~ " & Swap.Fields("NombreLocal").Text.Trim)
            Else
                cLocal.Text = "Local No Reconocido"
            End If
            cLocal.Enabled = (LocalUsuario = 0 Or AccesoUsuario = 9)

            cServidores.Visible = Programador
            If cServidores.Visible Then
                CargarServidores(wModo)
            End If
            'AplicarPermisosUsuario()

            Try
                LogoEmpresa.Visible = False
                LogoEmpresa.Visible = True
                Par = SQL("Select * from Parametros")
                Dim MatrizImagen() As Byte = CType(Par.Fields("Logo1").Value, Byte())
                Dim ImagenMemoria As New IO.MemoryStream(MatrizImagen)
                LogoEmpresa.Image = Image.FromStream(ImagenMemoria)
            Catch ex As Exception
            End Try

            If UsuarioActual = "PED" Then
                mMantenci?nDePOS.Visible = True
                mManLocal.Visible = True
            Else
                mMantenci?nDePOS.Visible = False
                mManLocal.Visible = False
            End If

            If AccesoUsuario = 9 Then
                bZebra.Visible = True
                cLocal.Visible = True
                cServidores.Visible = True
            Else
                bZebra.Visible = False
                cLocal.Visible = False
                cServidores.Visible = False
            End If

            'Visualizaci?n Normal
            mMenuVentas.Visible = True
            mMenuOT.Visible = True
            mMenuRemuneraciones.Visible = True
            mManIsapres.Visible = True
            mManAFP.Visible = True
            mManEventosRem.Visible = True
            mManUf.Visible = True
            mArt?culos.Visible = True

            bVenta.Visible = True


            'Visualizaci?n Paramterizada segun implementaci?n
            If gClave = "G" Then
                mMenuVentas.Visible = False
                mMenuOT.Visible = False
                mMenuRemuneraciones.Visible = False
                bVenta.Visible = False
                mManIsapres.Visible = False
                mManAFP.Visible = False
                mManEventosRem.Visible = False
                mManUf.Visible = True
                mArt?culos.Visible = False
            End If
            If gClave = "W" Then
                mMenuRemuneraciones.Visible = True
                mManIsapres.Visible = True
                mManAFP.Visible = True
                mManEventosRem.Visible = True
                mManUf.Visible = True
            End If

            Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgError("Error al parametrizar Local")
        End Try
    End Sub
    Private Class ListServidores
        Public Property Servidor As String
        Public Property NombreServidor As String
    End Class
    Sub CargarServidores(Optional wSwitch As Boolean = True)

        Dim wServidores = SQL("SELECT * FROM SERVIDORES")
        Dim wListaServidores As New List(Of ListServidores)

        While Not wServidores.EOF
            wListaServidores.Add(New ListServidores With {.Servidor = wServidores.Fields("IP").Text,
                                                          .NombreServidor = wServidores.Fields("Nombre").Text & " ~ " & wServidores.Fields("IP").Text})
            wServidores.MoveNext()
        End While
        RemoveHandler cServidores.SelectedIndexChanged, AddressOf cServidores_SelectedIndexChanged
        If wListaServidores.Any Then
            cServidores.ValueMember = "Servidor"
            cServidores.DisplayMember = "NombreServidor"
            cServidores.DataSource = wListaServidores
            cServidores.SelectedValue = P_SERVIDOR
        Else
            cServidores.Items.Add(P_SERVIDOR)
            cServidores.Text = P_SERVIDOR
        End If
        AddHandler cServidores.SelectedIndexChanged, AddressOf cServidores_SelectedIndexChanged


        'wSeleccionado = cServidores.Text
        'Paso = SQL("SELECT * FROM Servidores")
        'cServidores.Items.Clear()
        'While Not Paso.EOF
        '    cServidores.Items.Add(Paso.Fields("Nombre").Text & " ~ " & Paso.Fields("IP").Text)
        '    If wSwitch Then
        '        If Paso("IP").Value.ToString.Trim = P_SERVIDOR Then
        '            cServidores.Text = Paso.Fields("Nombre").Text & " ~ " & P_SERVIDOR
        '        End If
        '    End If
        '    Paso.MoveNext()
        'End While
        'If Not wSwitch Then
        '    If wSeleccionado.Trim <> "" Then
        '        cServidores.Text = wSeleccionado
        '    End If
        'End If
    End Sub

    Private Sub ComboLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cLocal.SelectedIndexChanged
        If cLocal.Text <> "" Then
            Dim wLocal As String
            wLocal = cLocal.Text.Replace(" ~ ", "")
            Loc = SQL("SELECT  local,NombreLocal FROM locales  WHERE CAST(local as varchar)+nombrelocal='" & wLocal & "'")
            If Loc.EOF = False Then
                LocalActual = Loc.Fields("Local").Text
                NombreLocalActual = Loc.Fields("NombreLocal").Text
            End If
        End If
        lLocal.Text = NombreLocalActual
    End Sub

    Private Sub cServidores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cServidores.SelectedIndexChanged
        If cServidores.Text <> "" Then
            P_SERVIDOR = cServidores.SelectedValue
            If Not Abrir() Then
                Exit Sub
            End If
            lConexion.Text = "SQL " & cServidores.SelectedValue
            Mostrar_Parametros(False)
        End If
    End Sub


    Private Sub Imagen_Click(sender As Object, e As EventArgs) Handles LogoEmpresa.Click
        Dim BuscarImagen As OpenFileDialog = New OpenFileDialog()

        Try
            If Programador Then
                If Pregunta("?Deseas Cambiar el Logo?") Then
                    BuscarImagen.Title = "Imagen a Subir (4x2 cm. aprox.)"
                    BuscarImagen.InitialDirectory = Application.LocalUserAppDataPath
                    BuscarImagen.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif"
                    BuscarImagen.RestoreDirectory = True
                    If BuscarImagen.ShowDialog() = DialogResult.OK Then
                        Par = SQL("Select Top 1 * from Parametros")
                        If Par.RecordCount > 0 Then
                            Par.Fields("Logo1").Value = Leer_JPG(BuscarImagen.FileName)
                            Par.Update()
                        Else
                            MsgError("Error al leer par?metros del sistema")
                        End If
                    End If

                    'Mostrar Imagen Guardada
                    LogoEmpresa.Visible = True
                    Par = SQL("Select * from Parametros")
                    Dim MatrizImagen() As Byte = CType(Par.Fields("Logo1").Value, Byte())
                    Dim ImagenMemoria As New IO.MemoryStream(MatrizImagen)
                    LogoEmpresa.Image = Image.FromStream(ImagenMemoria)
                End If
            End If
        Catch ex As Exception
            MsgError("Error al Cargar imagen" + vbCrLf + ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub PruebasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Pruebas.Show()
    End Sub

    Private Sub mManArt_Click(sender As Object, e As EventArgs) Handles mManArticulo.Click
        ManArticulos.Show()
        ManArticulos.BringToFront()
    End Sub

    Private Sub IngresoDeDocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mIngresoDeDocumentos.Click
        Documentos.Show()
    End Sub

    Private Sub mManFamilia_Click(sender As Object, e As EventArgs) Handles mManFamilia.Click
        ManFamilia.Show()
        ManFamilia.BringToFront()
    End Sub
    Private Sub mManDoc_Click(sender As Object, e As EventArgs) Handles mManDocmentos.Click
        ManTipoDoc.Show()
        ManTipoDoc.BringToFront()
    End Sub

    Private Sub mManMovimiento_Click(sender As Object, e As EventArgs) Handles mManMovimiento.Click
        ManTipoMov.Show()
        ManTipoMov.BringToFront()
    End Sub

    Private Sub mManCliente_Click(sender As Object, e As EventArgs) Handles mManCliente.Click
        ManCliente.Show()
        ManCliente.BringToFront()
    End Sub
    Private Sub mManBod_Click(sender As Object, e As EventArgs) Handles mManBodega.Click
        ManBodega.Show()
        ManBodega.BringToFront()
    End Sub

    Private Sub mManCiudades_Click(sender As Object, e As EventArgs) Handles mManCiudades.Click
        ManCiudades.Show()
        ManCiudades.BringToFront()
    End Sub

    Private Sub mManEstados_Click(sender As Object, e As EventArgs) Handles mManEstados.Click
        ManEstados.Show()
        ManEstados.BringToFront()
    End Sub

    Private Sub mManEventos_Click(sender As Object, e As EventArgs) Handles mManEventosRem.Click
        ManEventosRem.Show()
        ManEventosRem.BringToFront()
    End Sub

    Private Sub Mantenci?nDeAccesosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mMantenci?nDeAccesos.Click
        ManAccesos.Show()
        ManAccesos.BringToFront()
    End Sub
    Private Sub VentaSucursalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mVentaSucursal.Click
        VentaSucursal.Show()
        VentaSucursal.BringToFront()
    End Sub
    Private Sub Mntenci?nDeAFPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mManAFP.Click
        ManAFPs.Show()
        ManAFPs.BringToFront()
    End Sub

    Private Sub M?duloDePagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mControlPagos.Click
        ControlPagos.Show()
        ControlPagos.BringToFront()
    End Sub

    Private Sub Mantenci?nDeSubFamiliasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mMantenci?nDeSubFamilias.Click
        ManSubFamilia.Show()
        ManSubFamilia.BringToFront()
    End Sub

    Private Sub mManUnidadesMedidas_Click(sender As Object, e As EventArgs) Handles mManUnidadesMedidas.Click
        ManUnidades.Show()
        ManUnidades.BringToFront()
    End Sub

    Private Sub mManCorrelativo_Click(sender As Object, e As EventArgs) Handles mManCorrelativo.Click
        ManCorrelativos.Show()
        ManCorrelativos.BringToFront()
    End Sub

    Private Sub mManUsuarios_Click(sender As Object, e As EventArgs) Handles mManUsuarios.Click
        ManUsuarios.Show()
        ManUsuarios.BringToFront()
    End Sub

    Private Sub Mantenci?nDeLocalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mManLocal.Click
        ManLocales.Show()
        ManLocales.BringToFront()
    End Sub

    Private Sub ListaDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListaDePrecios.Click
        ListadoPrecios.Show()
        ListadoPrecios.BringToFront()
    End Sub

    Private Sub ListadoDeArt?culosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeArt?culos.Click
        ListadoArticulos.Show()
        ListadoArticulos.BringToFront()
    End Sub

    Private Sub ListadoDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeClientes.Click
        ListadoClientes.Show()
        ListadoClientes.BringToFront()
    End Sub

    Private Sub ListadoDeBodegasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeBodegas.Click
        ListadoBodegas.Show()
        ListadoBodegas.BringToFront()
    End Sub
    Private Sub TransformarArt?culoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mTransformarArt?culo.Click
        TransformarArticulo.Show()
        TransformarArticulo.BringToFront()
    End Sub

    Private Sub MovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mMovimientos.Click
        Movimientos.Show()
        Movimientos.BringToFront()
    End Sub

    Private Sub ListadoDeStocksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeStocks.Click
        ListadoStock.Show()
        ListadoStock.BringToFront()
    End Sub

    Private Sub ListadoDeTomaDeInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeTomaDeInventario.Click
        ListadoTomaInventario.Show()
        ListadoTomaInventario.BringToFront()
    End Sub

    Private Sub ModificarStocksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mModificarStocks.Click
        ModificarStock.Show()
        ModificarStock.BringToFront()
    End Sub

    Private Sub ImprimirMovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mImprimirMovimientos.Click
        ImprimirMovimiento.Show()
        ImprimirMovimiento.BringToFront()
    End Sub

    Private Sub mConsultaTipoDoc_Click(sender As Object, e As EventArgs) Handles mConsultaTipoDoc.Click
        LLamarConsultas("Tipo de Documentos", "TipoDocumento")
    End Sub
    Private Sub LLamarConsultas(wTitulo As String, wLista As String)
        For Each gForm In My.Application.OpenForms
            If gForm.text = "SisVen - Consulta de " & wTitulo Then
                gForm.BringToFront()
                Exit Sub
            End If
        Next

        Dim wForm As New ConsultaTabla
        wForm.WinDeco1.Titulo.Text = "Consulta de " & wTitulo
        wForm.Text = "SisVen - Consulta de " & wTitulo
        wListado = wLista
        wForm.Show()
        wForm.BringToFront()
    End Sub

    Private Sub mConsulta_Familia_Click(sender As Object, e As EventArgs) Handles mConsulta_Familia.Click
        LLamarConsultas("Familias", "Familias")
    End Sub

    Private Sub mConsulta_Eventos_Click(sender As Object, e As EventArgs) Handles mConsulta_Eventos.Click
        LLamarConsultas("Eventos de Remuneraci?n", "Eventos")
    End Sub

    Private Sub mConsulta_Unidades_Medidas_Click(sender As Object, e As EventArgs) Handles mConsulta_Unidades_Medidas.Click
        LLamarConsultas("Unidades de Medida", "Unidades")
    End Sub

    Private Sub mConsulta_de_Bodegas_Click(sender As Object, e As EventArgs) Handles mConsulta_de_Bodegas.Click
        LLamarConsultas("Bodegas", "Bodegas")
    End Sub

    Private Sub mConsulta_Correlativos_Click(sender As Object, e As EventArgs) Handles mConsulta_Correlativos.Click
        LLamarConsultas("Correlativos", "Correlativos")
    End Sub

    Private Sub mConsulta_de_Tipo_de_Movimientos_Click(sender As Object, e As EventArgs) Handles mConsulta_de_Tipo_de_Movimientos.Click
        LLamarConsultas("Tipo de Movimientos", "TipoMovimiento")
    End Sub

    Private Sub mConsulta_Formas_Pago_Click(sender As Object, e As EventArgs) Handles mConsulta_Formas_Pago.Click
        LLamarConsultas("Forma de Pagos", "FormaPagos")
    End Sub

    Private Sub mConsulta_Estados_Click(sender As Object, e As EventArgs) Handles mConsulta_Estados.Click
        LLamarConsultas("Estados", "Estados")
    End Sub

    Private Sub mConsulta_Usuarios_Click(sender As Object, e As EventArgs) Handles mConsulta_Usuarios.Click
        LLamarConsultas("Usuarios", "Usuarios")
    End Sub

    Private Sub mConsulta_Accesos_Click(sender As Object, e As EventArgs) Handles mConsulta_Accesos.Click
        LLamarConsultas("Accesos", "Accesos")
    End Sub

    Private Sub mConsulta_Ciudades_Click(sender As Object, e As EventArgs) Handles mConsulta_Ciudades.Click
        LLamarConsultas("Ciudades", "Ciudades")
    End Sub

    Private Sub mConsulta_Articulos_Click(sender As Object, e As EventArgs) Handles mConsulta_Articulos.Click
        LLamarConsultas("Art?culos", "Articulos")
    End Sub

    Private Sub IngresoDeOTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mIngresoDeOT.Click
        IngresoOT.Show()
        IngresoOT.BringToFront()
    End Sub

    Private Sub ListadosDeMovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadosDeMovimientos.Click
        ListadoMovimientos.Show()
        ListadoMovimientos.BringToFront()
    End Sub

    Private Sub Cr?ditosDePersonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mCr?ditosDePersonal.Click
        CreditoPersona.Show()
        CreditoPersona.BringToFront()
    End Sub

    Private Sub IngresoDeEventosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mIngresoDeEventos.Click
        IngresoEventosRem.Show()
        IngresoEventosRem.BringToFront()
    End Sub

    Private Sub CalculoDeRemuneracionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mCalculoDeRemuneraciones.Click
        CalculoRem.Show()
        CalculoRem.BringToFront()
    End Sub

    Private Sub AnularEventosDeRemuneracionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mAnularEventosDeRemuneraciones.Click
        AnularEventoRem.Show()
        AnularEventoRem.BringToFront()
    End Sub

    Private Sub CierreDeRemuneracionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mCierreDeRemuneraciones.Click
        CerrarRemuneraciones.Show()
        CerrarRemuneraciones.BringToFront()
    End Sub

    Private Sub ImprimirLiquidaci?nDeSueldosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mImprimirLiquidaci?nDeSueldos.Click
        ImprimirLiquidaciones.Show()
        ImprimirLiquidaciones.BringToFront()
    End Sub

    Private Sub ImprimirPlanillaDeRemuneracionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mImprimirPlanillaDeRemuneraciones.Click
        ImprimirPlanillaRem.Show()
        ImprimirPlanillaRem.BringToFront()
    End Sub

    Private Sub ImprimirEventosDeRemuneracionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mImprimirEventosDeRemuneraciones.Click
        ImprimirEventosRem.Show()
        ImprimirEventosRem.BringToFront()
    End Sub

    Private Sub ConsultaDeVentasConBoletasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mConsultaDeVentasConBoletas.Click
        ConsultaVentaBoleta.Show()
        ConsultaVentaBoleta.BringToFront()
    End Sub

    Private Sub ConsultaDeDescuentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mConsultaDeDescuentos.Click
        ConsultaDescuento.Show()
        ConsultaDescuento.BringToFront()
    End Sub

    Private Sub mConsultaAuditoria_Click(sender As Object, e As EventArgs) Handles mConsultaAuditoria.Click
        ConsultaAuditoria.Show()
        ConsultaAuditoria.BringToFront()
    End Sub

    Private Sub ConsultaDeDocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mConsultaDeDocumentos.Click
        ConsultaDocumento.Show()
        ConsultaDocumento.BringToFront()
    End Sub

    Private Sub ListadoDeCiudadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeCiudades.Click
        ListadoCiudades.Show()
        ListadoCiudades.BringToFront()
    End Sub

    Private Sub ListadoDeEstadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeEstados.Click
        ListadoEstados.Show()
        ListadoEstados.BringToFront()
    End Sub

    Private Sub ListadosDeFamiliaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadosDeFamilia.Click
        ListadoFamilias.Show()
        ListadoFamilias.BringToFront()
    End Sub

    Private Sub ListadoDeFormaDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeFormaDePago.Click
        ListadoFPago.Show()
        ListadoFPago.BringToFront()
    End Sub

    Private Sub ListadoDeTipoMovimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeTipoMovimiento.Click
        ListadoTipoMov.Show()
        ListadoTipoMov.BringToFront()
    End Sub

    Private Sub ListadoDeUnidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeUnidades.Click
        ListadoUnidades.Show()
        ListadoUnidades.BringToFront()
    End Sub

    Private Sub ListadoDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mListadoDeUsuarios.Click
        ListadoUsuarios.Show()
        ListadoUsuarios.BringToFront()
    End Sub

    Private Sub Anulaci?nDeDocumentosToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        AnularDocumento.Show()
        AnularDocumento.BringToFront()
    End Sub

    Private Sub ConsultaDeOTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mConsultaDeOT.Click
        ConsultaOT.Show()
        ConsultaOT.BringToFront()
    End Sub

    Private Sub Anulaci?nDeOTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mAnulaci?nDeOT.Click
        AnularOT.Show()
        AnularOT.BringToFront()
    End Sub

    Private Sub RepuestoParaOTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mRepuestoParaOT.Click
        ConsultaRepuestosOT.Show()
        ConsultaRepuestosOT.BringToFront()
    End Sub

    Private Sub ServicioT?cnicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mServicioT?cnico.Click
        ServicioTecnico.Show()
        ServicioTecnico.BringToFront()
    End Sub

    Private Sub RepuestosPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mRepuestosPendientes.Click
        Abastecimiento.Show()
        Abastecimiento.BringToFront()
    End Sub

    Private Sub Impresi?nDeDocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mImpresi?nDeDocumentos.Click
        ImprimirDocumentos.Show()
        ImprimirDocumentos.BringToFront()
    End Sub

    Private Sub PermisosAUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mPermisos.Click
        ManPermisos.Show()
        ManPermisos.BringToFront()
    End Sub

    Private Sub AplicarPermisosUsuario()

        Try

            Dim ItemsVisibles As New List(Of ToolStripMenuItem)
            Dim MenusVisibles As New List(Of ToolStripMenuItem)

            'Obtener listado de m?dulos habilitados.
            Per = SQL("Select Modulo, M.Menu, (SELECT COUNT(*) FROM PermisosUsuario " &
               " R WHERE R.Modulo = M.Modulo And Usuario = '" & UsuarioActual & "') " &
               " AS 'Habilitado' FROM Modulos M")

            'Mostrar m?dulos habilitados / Ocultar y desactivar m?dulos deshabilitados
            While Not Per.EOF
                Dim wMenuItem As String = Per.Fields("Menu").Text

                Dim wHabilitado = (Per.Fields("Habilitado").Value = 1)
                'Console.WriteLine(wMenuItem.Substring(0, 1).ToLower)
                Select Case wMenuItem.Substring(0, 1).ToLower
                    Case "m" 'Men? - Item
                        Dim wItem As ToolStripMenuItem = BuscarItem(Barra, wMenuItem)

                        If Not wHabilitado Then
                            If wItem IsNot Nothing Then wItem.Visible = False : wItem.Enabled = False
                        Else
                            If wItem IsNot Nothing Then
                                ItemsVisibles.Add(wItem)
                                wItem.Visible = True : wItem.Enabled = True
                            End If
                        End If
                    Case "b" 'Bot?n
                        Dim wBoton As Button = BuscarBoton(Me, wMenuItem)
                        If Not wHabilitado Then
                            If wBoton IsNot Nothing Then wBoton.Visible = False : wBoton.Enabled = False
                        Else
                            If wBoton IsNot Nothing Then wBoton.Visible = True : wBoton.Enabled = True
                        End If
                    'Funcionalidades
                    Case "f"
                        Select Case wMenuItem
                            Case "fCambiarLocal"
                                F_CAMBIAR_LOCAL = wHabilitado
                            Case "fCambiarServidor"
                                F_CAMBIO_SERVIDOR = wHabilitado
                        End Select
                End Select

                Per.MoveNext()
            End While



            'Determinar menus que contienen ?tems habilitados.
            For Each wItem As ToolStripMenuItem In ItemsVisibles
                While wItem.OwnerItem IsNot Nothing
                    wItem = wItem.OwnerItem
                    If MenusVisibles.Contains(wItem) Then Continue While
                    MenusVisibles.Add(wItem)
                    If wItem.Visible Then Continue While
                End While
                If wItem.OwnerItem Is Nothing And Not MenusVisibles.Contains(wItem) Then
                    MenusVisibles.Add(wItem)
                End If
                DoEvents()
            Next

            'Remover separadores continuos.
            For Each wMenu As ToolStripMenuItem In MenusVisibles
                Dim wSeparadorAnterior As Boolean = False

                Dim wSubItems As New List(Of ToolStripItem)

                For Each wItem As ToolStripItem In wMenu.DropDownItems
                    wSubItems.Add(wItem)
                Next

                wSubItems = wSubItems.Where(Function(x) x.Enabled = True).ToList

                Dim wIndice As Integer = 0
                For Each wSubItem As ToolStripItem In wSubItems
                    wIndice += 1

                    If wSubItem.Text <> "" Then 'Not wSubItem.GetType Is GetType(ToolStripSeparator)
                        wSeparadorAnterior = False
                        Continue For
                    End If

                    If wSeparadorAnterior Then
                        wSubItems(wIndice - 2).Visible = False : wSubItems(wIndice - 2).Enabled = False
                    End If

                    wSeparadorAnterior = True
                    If wIndice = wSubItems.Count Or wIndice = 1 Then
                        wSubItem.Visible = False : wSubItem.Enabled = False
                    End If

                Next

                wSubItems = wSubItems.Where(Function(x) x.Enabled = True).ToList
                If wSubItems.Count > 0 AndAlso wSubItems(0).Text = "" Then
                    wSubItems(0).Enabled = False : wSubItems(0).Visible = False
                End If

                DoEvents()
            Next

            'Ocultar Menus que no tienen Items habilitados
            For Each wItem As ToolStripMenuItem In MenusVisibles
                If wItem.DropDownItems.Count > 0 Then
                    Dim wMostrar As Boolean = False
                    For Each wSubItem As ToolStripItem In wItem.DropDownItems
                        If wSubItem.Text <> "" And wSubItem.Enabled Then
                            wMostrar = True
                            Exit For
                        End If
                    Next
                    wItem.Visible = wMostrar : wItem.Enabled = wMostrar
                End If
                DoEvents()
            Next

        Catch ex As Exception
        End Try
    End Sub
    Public Function BuscarBoton(ByVal Parent As Control, wNombre As String) As Button
        Dim wControles As Control() = Parent.Controls.Find(wNombre, True)
        If wControles.Any Then
            Return DirectCast(Parent.Controls.Find(wNombre, True)(0), Button)
        End If
        Return Nothing
    End Function

    Private Sub mAcercaDe_Click(sender As Object, e As EventArgs) Handles mAcercaDe.Click
        Acerca.ShowDialog()
    End Sub

    Private Sub bDocumentos_Click(sender As Object, e As EventArgs) Handles bDocumentos.Click
        Documentos.Show()
        Documentos.BringToFront()
    End Sub

    Private Sub bPagos_Click(sender As Object, e As EventArgs) Handles bPagos.Click
        ControlPagos.Show()
        ControlPagos.BringToFront()
    End Sub

    Private Sub bMovimientos_Click(sender As Object, e As EventArgs) Handles bMovimientos.Click
        Movimientos.Show()
        Movimientos.BringToFront()
    End Sub

    Private Sub bVenta_Click(sender As Object, e As EventArgs) Handles bVenta.Click
        VentaSucursal.Show()
        VentaSucursal.BringToFront()
    End Sub

    Private Sub Menu_Principal_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Barra.Focus()
    End Sub

    Private Sub CargaDeArchivosCAFDeSIIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mCargaDeArchivosCAFDeSII.Click
        CargaCAF.Show()
    End Sub

    Private Sub Env?oDTEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mEnv?oDTE.Click
        EnviarDTE.Show()
    End Sub

    Private Sub Anulai?nDeDocumentosElectr?nicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mAnulaionDeDocumentosElectronicos.Click
        AnularDocumentoElectronico.Show()
    End Sub

    Private Sub Anulaci?nDeDocumentosNoElectr?nicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mAnulacionDeDocumentosNoElectronicos.Click
        AnularDocumento.Show()
    End Sub

    Private Sub mGenerarArchivoParaBancos_Click(sender As Object, e As EventArgs) Handles mGenerarArchivoParaBancos.Click
        GenerarArchivoBanco.Show()
    End Sub

    Private Sub ConsultarDocumentosAlDTEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mConsultarDocumentosAlDTE.Click
        ConsultarDTE.Show()
    End Sub

    Private Sub Mantenci?nDePOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mMantenci?nDePOS.Click
        ManPOS.Show()
    End Sub

    Private Sub CuadraturaDeCajasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mCuadraturaDeCajas.Click
        CuadraturaCaja.Show()
        CuadraturaCaja.BringToFront()
    End Sub

    Private Sub ControlDTEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mControlDTE.Click
        ControlDTE_Emitidos.Show()
        ControlDTE_Emitidos.BringToFront()
    End Sub

    Private Sub StocksPorDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mStocksPorDocumento.Click
        StockPorDocumento.Show()
        StockPorDocumento.BringToFront()
    End Sub

    Private Sub bZebra_Click(sender As Object, e As EventArgs) Handles bZebra.Click
        Dim wZPL As String
        wZPL = Generar_Documento_ZPL(1, "FV", 92, 2)
        wZPL = Generar_Stocks_ZPL(1)
        wZPL = Generar_Lista_ZPL()
    End Sub

    Private Sub bCuadraturaCajas_Click(sender As Object, e As EventArgs) Handles bCuadraturaCajas.Click
        CuadraturaCaja.Show()
        CuadraturaCaja.BringToFront()
    End Sub

    Private Sub bMovimientoStockDocumento_Click(sender As Object, e As EventArgs) Handles bMovimientoStockDocumento.Click
        StockPorDocumento.Show()
        StockPorDocumento.BringToFront()
    End Sub

    Private Sub MovimientoDeStocksPOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientoDeStocksPOSToolStripMenuItem.Click
        MovimientoStockPOS.Show()
        MovimientoStockPOS.BringToFront()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub CuadraturaDeCajasToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CuadraturaDeCajasToolStripMenuItem.Click
        CuadraturaCaja.Show()
        CuadraturaCaja.BringToFront()
    End Sub

    Private Sub TestWS_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub ControlDTEProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDTEProveedoresToolStripMenuItem.Click
        ControlDTE_Proveedores.Show()
        ControlDTE_Proveedores.BringToFront()
    End Sub

    Private Sub mManUf_Click(sender As Object, e As EventArgs) Handles mManUf.Click
        ManUF.Show()
        ManUF.BringToFront()
    End Sub

    Private Sub ContadoresDTEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContadoresDTEToolStripMenuItem.Click
        ContadoresDTE.Show()
    End Sub

    Private Sub Menu_Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Cursor = Cursors.WaitCursor
        Mostrar_Parametros()
        IndicadoresBGW.RunWorkerAsync()
        DoEvents()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub IndicadoresBGW_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles IndicadoresBGW.RunWorkerCompleted
        Dim valores As ValoresIndicadores = e.Result

        If valores Is Nothing Then Return
        Dim G_UTM = valores.UTM
        Dim G_DOLAR = valores.Dolar
        Dim G_UF = valores.UF
        Dim G_UF_MES = valores.UF_MES

        Dim UF = SQL("SELECT TOP 1 UF, A?o, Mes, UTM FROM UFs WHERE A?o = '" & Now.Year & "' AND  Mes = '" & Now.Month & "'")
        If UF.RecordCount = 0 Then
            UF.AddNew()
            UF.Fields("A?o").Value = Now.Year
            UF.Fields("Mes").Value = Now.Month
        End If
        UF.Fields("UF").Value = G_UF_MES
        UF.Fields("UTM").Value = G_UTM
        UF.Update()
    End Sub

    Private Sub IndicadoresBGW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles IndicadoresBGW.DoWork
        Try

            Dim Valores As New ValoresIndicadores

            Valores.UTM = Val(Indicadores.GetUTM().UTMs.UTM.Valor.Replace(".", ""))
            Valores.Dolar = Val(Indicadores.GetDolar().Dolares.Dolar.Valor.Replace(".", "").Replace(",", "."))
            Valores.UF = Val(Indicadores.GetUF().UFs.UF.Valor.Replace(".", "").Replace(",", "."))
            Dim lastday = New DateTime(Now.Year, Now.Month, DateTime.DaysInMonth(Now.Year, Now.Month))
            Valores.UF_MES = Val(Indicadores.GetUF(lastday).UFs.UF.Valor.Replace(".", "").Replace(",", "."))

            e.Result = Valores

        Catch ex As Exception
            e.Result = Nothing
        End Try

    End Sub

    Private Sub Mantenci?nDeM?quinasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Mantenci?nDeM?quinasToolStripMenuItem.Click
        ManMaquinas.Show()
        ManMaquinas.BringToFront()
    End Sub

    Private Sub Generaci?nDeArchivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Generaci?nDeArchivosToolStripMenuItem.Click
        GeneracionArchivos.Show()
        GeneracionArchivos.BringToFront()
    End Sub

    Private Sub bGenerar_Click(sender As Object, e As EventArgs) Handles bGenerar.Click
        GeneracionArchivos.Show()
        GeneracionArchivos.BringToFront()
    End Sub
End Class