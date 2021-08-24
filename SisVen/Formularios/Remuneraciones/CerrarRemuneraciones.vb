Public Class CerrarRemuneraciones
    Const T_ID = 0
    Const T_MARCA = 1
    Const T_USUARIO = 2
    Const T_MONTO = 3
    Const T_MODO = 4

    Const M_EFE = "EFECTIVO"
    Const M_DEP = "DEPÓSITO"
    Const M_NOC = "NO CANCELADA"
    Const M_PEN = "PENDIENTE"
    Const M_BLA = ""
    Private Sub CerrarRemuneraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = Year(Now()) - 1 To Year(Now())
            cAño.Items.Add(Val(i))
        Next i

        For i = 1 To 12
            cMes.Items.Add(MES(i))
        Next i

        cAño.Text = Year(Now())
        cMes.Text = Trim(MES(Month(Now())))
        Titulos()
        Auditoria(Me.Text, PR_INGRESAR, "", 0)
    End Sub
    Sub Titulos()

        xTabla.Clear()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 5

        xTabla.Cols(T_ID).Caption = "ID"
        xTabla.Cols(T_MARCA).Caption = "Entregado"
        xTabla.Cols(T_USUARIO).Caption = "Funcionario"
        xTabla.Cols(T_MONTO).Caption = "Sueldo Líquido"
        xTabla.Cols(T_MODO).Caption = "Modo Pago"

        xTabla.Cols(T_ID).Width = 0
        xTabla.Cols(T_MARCA).Width = 100
        xTabla.Cols(T_USUARIO).Width = 350
        xTabla.Cols(T_MONTO).Width = 140
        xTabla.Cols(T_MODO).Width = 140

        xTabla.Cols(T_MARCA).DataType = GetType(Boolean)
    End Sub

    Private Sub bMostrar_Click(sender As Object, e As EventArgs) Handles bMostrar.Click
        Titulos()

        RmG = SQL("Select * from Sueldos where Cancelado = 0 and Año =" & Val(cAño.Text) & " and Mes = " & Val(cMes.SelectedIndex + 1) & " And estado = 0")
        While Not RmG.EOF
            DoEvents()
            xTabla.AddItem("")
            xTabla.SetData(xTabla.Rows.Count - 1, T_MARCA, CHECK)
            xTabla.SetData(xTabla.Rows.Count - 1, T_ID, RmG.Fields("Id").Text)

            If Buscar("Usuarios", "Usuario", RmG.Fields("Usuario").Text) Then
                xTabla.SetData(xTabla.Rows.Count - 1, T_USUARIO, Swap.Fields("NombreUsr").Text.Trim)
            End If
            xTabla.SetData(xTabla.Rows.Count - 1, T_MONTO, Val(RmG.Fields("TLiquido").Text))

            If Buscar("FPagos", "FPago", RmG.Fields("ModoPago").Text) Then
                xTabla.SetData(xTabla.Rows.Count - 1, T_MODO, Swap.Fields("DescFPago").Text)
            End If
            RmG.MoveNext()
        End While

    End Sub

    Public Function SacaModo(mModo As String) As String
        If mModo = "" Then
            Return ""
        End If

        If mModo = "E" Then
            Return M_EFE
        End If
        If mModo = "D" Then
            Return M_DEP
        End If
        If mModo = "P" Then
            Return M_PEN
        End If
        If mModo = "N" Then
            Return M_NOC
        End If
        If mModo = "" Or mModo = " " Then
            Return M_BLA
        End If

        Return ""
    End Function

    Private Sub xTabla_Click(sender As Object, e As EventArgs) Handles xTabla.Click
        If xTabla.Col = T_MARCA Then
            Dim wCheck = Not (xTabla.GetData(xTabla.Row, T_MARCA))
            xTabla.SetData(xTabla.Row, T_MARCA, wCheck)
        End If
    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        cAño.Text = Year(Now())
        cMes.Text = Trim(MES(Month(Now())))
        Titulos()
        cAño.Focus()
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        Dim F1 As Date
        Dim F2 As Date

        If Pregunta("Desea Cerrar Remuneraciones para Personal Marcado") = False Then
            Exit Sub
        End If

        For i = 1 To xTabla.Rows.Count - 1
            If xTabla.GetData(i, T_MARCA) = CHECK Then
                RmG = SQL("Select * from Sueldos where Id = " + xTabla.GetData(i, T_ID))
                If RmG.RecordCount > 0 Then
                    RmG.Fields("Estado").Value = 1        'CERRAR
                    RmG.Fields("Cancelado").Value = True
                    RmG.Fields("ModoPago").Value = BuscarCampo("fPagos", "fPago", "DescFPago", xTabla.GetData(i, T_MODO))
                    RmG.Fields("FechaPago").Value = Now
                    RmG.Fields("UsuarioPago").Value = UsuarioActual
                    RmG.Update()

                    F1 = IniFecha(1, "01/01/2000")
                    F2 = IniFecha(2, CDate("01/" & cMes.SelectedIndex + 1 & "/" & cAño.SelectedIndex + 1))
                    RmD = SQL("Update Sueldos_Detalles Set Estado = 1 Where Fecha >= '01/01/2000'" &
                              " And Fecha <= '" & FormatDateTime(F2, DateFormat.ShortDate) & "' and Estado = 0 and Usuario = '" & RmG.Fields("Usuario").Text & "'")
                Else
                    MsgError("Error en Remuneración N° " & (xTabla.GetData(i, T_ID)))
                End If
            End If
        Next i

        MsgBox("Proceso Finalizado")
        Auditoria(Me.Text, PR_GUARDAR, "", 0)
        Titulos()
        cAño.Focus()
    End Sub

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub
End Class