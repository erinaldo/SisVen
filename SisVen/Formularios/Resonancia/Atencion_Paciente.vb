Imports System.IO
Imports C1.Win.C1FlexGrid

Public Class Atencion_Paciente

    Const T_ELIMINAR As Integer = 0
    Const T_LINK As Integer = 1
    Const T_OBSERVACION As Integer = 2

    Sub Titulos()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 3
        xTabla.Cols(T_ELIMINAR).Width = 40
        xTabla.Cols(T_LINK).Width = 40
        xTabla.Cols(T_OBSERVACION).Width = 40
        xTabla.Cols(T_ELIMINAR).Caption = " "
        xTabla.Cols(T_LINK).Caption = "Link"
        xTabla.Cols(T_OBSERVACION).Caption = "Observación"
        xTabla.AjustarColumnas
    End Sub
    Private Sub Atencion_Paciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()
        xRut.Text = "19.121.307-6"
    End Sub

    Private Sub bAdjuntar_Click(sender As Object, e As EventArgs) Handles bAdjuntar.Click
        oDialogo.Multiselect = True
        oDialogo.FileName = ""
        oDialogo.ShowDialog()
        Dim wSeleccionados() As String = oDialogo.FileNames
        Dim wRepetido As Boolean
        For Each wDireccion In wSeleccionados
            wRepetido = False
            For i = 1 To xTabla.Rows.Count - 1
                If wDireccion = xTabla.GetData(i, T_LINK) Then
                    wRepetido = True
                    Exit For
                End If
            Next
            If Not wRepetido And wDireccion <> "" Then
                xTabla.AddItem("")
                xTabla.SetData(xTabla.Rows.Count - 1, T_LINK, wDireccion)
                xTabla.SetCellImage(xTabla.Rows.Count - 1, T_ELIMINAR, My.Resources.delete)
                xTabla.AjustarColumnas
            End If
        Next

    End Sub

    Private Sub bCerrar_Click(sender As Object, e As EventArgs) Handles bCerrar.Click
        Close()
    End Sub

    Private Sub xTabla_DoubleClick(sender As Object, e As EventArgs) Handles xTabla.DoubleClick
        If xTabla.Rows.Count - 1 = 0 Then Exit Sub
        If xTabla.ColSel = T_LINK Then
            Dim wDireccion As String = xTabla.GetData(xTabla.RowSel, T_LINK)
            'Proceso Directo Seria 
            'Process.Start(wDireccion)
            AbrirDirectorio(wDireccion)
        ElseIf xTabla.ColSel = T_ELIMINAR Then
            If Pregunta("¿Desea quitar este item de la lista?") Then
                xTabla.RemoveItem(xTabla.RowSel)
            End If
        ElseIf xTabla.ColSel = T_OBSERVACION Then
            xTabla.StartEditing(xTabla.RowSel, T_OBSERVACION)
        End If
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        If xTabla.Rows.Count - 1 = 0 Then Exit Sub
        Dim wDirectorio As String = My.Settings.P_RUTA_ARCHIVOS & "\" & Trim(xRut.Text)
        If Not Directory.Exists(wDirectorio) Then
            Directory.CreateDirectory(wDirectorio)
        End If
        For i = 1 To xTabla.Rows.Count - 1
            Dim wArchivoActual As String = xTabla.GetData(i, T_LINK)
            Dim wNombreArchivo As String = Path.GetFileName(wArchivoActual)
            Dim wDirectorioArchivoNuevo As String = wDirectorio & "\" & wNombreArchivo
            If Not Directory.Exists(wDirectorioArchivoNuevo) Then
                My.Computer.FileSystem.CopyFile(wArchivoActual, wDirectorioArchivoNuevo, True)
            End If
        Next
        Mensaje("Datos Copiados en la Carpeta")
    End Sub

    Private Sub xTabla_AfterEdit(sender As Object, e As RowColEventArgs) Handles xTabla.AfterEdit
        xTabla.AjustarColumnas
    End Sub
End Class