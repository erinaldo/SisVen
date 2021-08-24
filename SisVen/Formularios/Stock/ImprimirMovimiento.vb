Imports System.ComponentModel

Public Class ImprimirMovimiento
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        xMovimiento.Clear()
        xMovimiento.Focus()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click

        If xMovimiento.Text.Trim <> "" Then
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
            wQuery = wQuery
            ModuloReporte = "ListadoMovimiento"
            VisorReportes.VisorParametros(wQuery, wReporte)
            VisorReportes.WinDeco1.TituloVentana = "Listado de Movimiento"
            VisorReportes.Show()
            Auditoria(Me.Text, PR_IMPRIMIR, "", 0)
        Else
            MsgError("Debe ingresar numero de movimiento")
            xMovimiento.Focus()
        End If
    End Sub

    Private Sub ImprimirMovimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub

    Private Sub xMovimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles xMovimiento.KeyPress
        ValidarDigitos(e)
    End Sub

    Private Sub xMovimiento_Validating(sender As Object, e As CancelEventArgs) Handles xMovimiento.Validating
        bImprimir.Focus()
    End Sub
End Class