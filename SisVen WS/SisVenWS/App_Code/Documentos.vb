Imports Microsoft.VisualBasic

Partial Public Class DocumentosG
    Implements ICloneable

    Private Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Function Clonar() As DocumentosG
        Return Me.Clone()
    End Function
End Class

Partial Public Class DocumentosP
    Implements ICloneable

    Private Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Function Clonar() As DocumentosP
        Return Me.Clone()
    End Function
End Class

Partial Public Class DocumentosD
    Implements ICloneable

    Private Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Function Clonar() As DocumentosD
        Return Me.Clone()
    End Function
End Class

Partial Public Class Ventas
    Implements ICloneable

    Private Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone()
    End Function

    Public Function Clonar() As Ventas
        Return Me.Clone()
    End Function
End Class
