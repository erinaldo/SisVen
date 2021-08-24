Public Class Consulta_Atencion
    Const T_FECHA As Integer = 0
    Const T_PACIENTE As Integer = 1
    Const T_PRESTACION As Integer = 2
    Const T_FINANCIADOR As Integer = 3
    Const T_ESTADO As Integer = 4

    Sub Titulos()
        xTabla.Rows.Count = 1
        xTabla.Cols.Count = 5
        xTabla.Cols(T_FECHA).Width = 40
        xTabla.Cols(T_PACIENTE).Width = 40
        xTabla.Cols(T_PRESTACION).Width = 40
        xTabla.Cols(T_FINANCIADOR).Width = 40
        xTabla.Cols(T_ESTADO).Width = 40

        xTabla.Cols(T_FECHA).Caption = "Fecha"
        xTabla.Cols(T_PACIENTE).Caption = "Paciente"
        xTabla.Cols(T_PRESTACION).Caption = "Prestación"
        xTabla.Cols(T_FINANCIADOR).Caption = "Financiador"
        xTabla.Cols(T_ESTADO).Caption = "Estado"
        xTabla.AjustarColumnas
    End Sub
    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Close()
    End Sub

    Private Sub Consulta_Atencion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Titulos()
    End Sub
End Class