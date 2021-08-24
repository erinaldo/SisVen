Imports System.Drawing
Imports System.Windows.Forms

Namespace Styles

    Class CustomRenderer
        Inherits ToolStripProfessionalRenderer
        Public Sub New()
            MyBase.New(New ColorTable())
        End Sub
    End Class

    Class ColorTable
        Inherits ProfessionalColorTable
        Public Overrides ReadOnly Property ButtonSelectedHighlight() As Color
            Get
                Return ButtonSelectedGradientMiddle
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonSelectedHighlightBorder() As Color
            Get
                Return ButtonSelectedBorder
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonPressedHighlight() As Color
            Get
                Return ButtonPressedGradientMiddle
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonPressedHighlightBorder() As Color
            Get
                Return ButtonPressedBorder
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonCheckedHighlight() As Color
            Get
                Return ButtonCheckedGradientMiddle
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonCheckedHighlightBorder() As Color
            Get
                Return ButtonSelectedBorder
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonPressedBorder() As Color
            Get
                Return ButtonSelectedBorder
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonSelectedBorder() As Color
            Get
                Return Color.FromArgb(255, 23, 73, 149)
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonCheckedGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 147, 215, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonCheckedGradientMiddle() As Color
            Get
                Return Color.FromArgb(255, 51, 164, 247)
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonCheckedGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 72, 173, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonSelectedGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 95, 146, 203)
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonSelectedGradientMiddle() As Color
            Get
                Return Color.FromArgb(255, 95, 146, 203)
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonSelectedGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 95, 146, 203)
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonPressedGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 51, 164, 247)
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonPressedGradientMiddle() As Color
            Get
                Return Color.FromArgb(255, 51, 164, 247)
            End Get
        End Property
        Public Overrides ReadOnly Property ButtonPressedGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 147, 215, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property CheckBackground() As Color
            Get
                Return Color.FromArgb(255, 174, 225, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property CheckSelectedBackground() As Color
            Get
                Return Color.FromArgb(255, 89, 181, 249)
            End Get
        End Property
        Public Overrides ReadOnly Property CheckPressedBackground() As Color
            Get
                Return Color.FromArgb(255, 89, 181, 249)
            End Get
        End Property
        Public Overrides ReadOnly Property GripDark() As Color
            Get
                Return Color.FromArgb(255, 111, 157, 217)
            End Get
        End Property
        Public Overrides ReadOnly Property GripLight() As Color
            Get
                Return Color.FromArgb(255, 255, 255, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 233, 238, 238)
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
            Get
                Return Color.FromArgb(255, 233, 238, 238)
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 233, 238, 238)
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginRevealedGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 233, 238, 238)
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginRevealedGradientMiddle() As Color
            Get
                Return Color.FromArgb(255, 233, 238, 238)
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginRevealedGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 233, 238, 238)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuStripGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 153, 186, 223)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuStripGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 202, 221, 244)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelected() As Color
            Get
                Return Color.FromArgb(255, 27, 214, 50)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemBorder() As Color
            Get
                Return Color.FromArgb(255, 23, 73, 140)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuBorder() As Color
            Get
                Return Color.FromArgb(255, 101, 147, 207)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelectedGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 133, 181, 239)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelectedGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 87, 147, 227)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemPressedGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 226, 239, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemPressedGradientMiddle() As Color
            Get
                Return Color.FromArgb(255, 190, 215, 247)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemPressedGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 153, 191, 240)
            End Get
        End Property
        Public Overrides ReadOnly Property RaftingContainerGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 255, 255, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property RaftingContainerGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 255, 255, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property SeparatorDark() As Color
            Get
                Return Color.FromArgb(255, 157, 201, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property SeparatorLight() As Color
            Get
                Return Color.FromArgb(255, 255, 255, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property StatusStripGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 227, 239, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property StatusStripGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 177, 211, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripBorder() As Color
            Get
                Return Color.FromArgb(255, 111, 157, 217)
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
            Get
                Return Color.FromArgb(255, 246, 246, 246)
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 202, 221, 244)
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripGradientMiddle() As Color
            Get
                Return Color.FromArgb(255, 190, 209, 232)
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 153, 186, 223)
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripContentPanelGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 215, 232, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripContentPanelGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 111, 157, 217)
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripPanelGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 191, 219, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripPanelGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 191, 219, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property OverflowButtonGradientBegin() As Color
            Get
                Return Color.FromArgb(255, 215, 232, 255)
            End Get
        End Property
        Public Overrides ReadOnly Property OverflowButtonGradientMiddle() As Color
            Get
                Return Color.FromArgb(255, 167, 204, 251)
            End Get
        End Property
        Public Overrides ReadOnly Property OverflowButtonGradientEnd() As Color
            Get
                Return Color.FromArgb(255, 111, 157, 217)
            End Get
        End Property
    End Class
End Namespace
