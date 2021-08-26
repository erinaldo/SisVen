Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports ClosedXML.Excel

Public Class ExcelWorkbookService

    Public Shared Function GenerateExcel(Of TElement) _
        (elementList As List(Of TElement), workBookName As String,
         Optional columnList As List(Of String) = Nothing, Optional columnsExclude As List(Of Integer) = Nothing) As MemoryStream

        Dim excelStream = New MemoryStream

        Dim workbook As New XLWorkbook
        Dim workSheet As IXLWorksheet = workbook.Worksheets.Add(workBookName)

        Dim Pre_propertyList = GetType(TElement).GetProperties().ToList()
        Dim propertyList As New List(Of PropertyInfo)

        For Each item In Pre_propertyList

            Dim NameAttribute As DisplayNameAttribute = CType(Attribute.GetCustomAttribute(item,
                                    GetType(DisplayNameAttribute)), DisplayNameAttribute)
            If NameAttribute IsNot Nothing Then
                propertyList.Add(item)
            End If
        Next

        If columnList Is Nothing Then
            CreateColumnHeaders(propertyList, workSheet, columnsExclude)
        Else
            AddColumnHeaders(columnList, workSheet, columnsExclude)
        End If

        CreateWorksheetData(propertyList, elementList, workSheet, columnsExclude)

        workSheet.Columns.AdjustToContents()
        workbook.SaveAs(excelStream)

        Return excelStream
    End Function

    Private Shared Sub CreateWorksheetData(Of TElement)(propertyList As List(Of PropertyInfo),
                                                  elementList As List(Of TElement),
                                                  worksheet As IXLWorksheet,
                                                 Optional columnsExclude As List(Of Integer) = Nothing)

        Dim properties As New List(Of PropertyInfo)

        Dim column = 0

        For Each prop In propertyList
            column += 1
            If columnsExclude IsNot Nothing AndAlso columnsExclude.Contains(column - 1) Then Continue For
            properties.Add(prop)
        Next

        Dim row = 2

        For Each element In elementList

            column = 0
            For Each propertyInfo In properties
                column += 1

                Dim value = propertyInfo.GetValue(element, Nothing)

                worksheet.Cell(row, column).Value = value
                With worksheet.Cell(row, column).Style.Border
                    .RightBorder = XLBorderStyleValues.Thin
                    .LeftBorder = XLBorderStyleValues.Thin
                    .BottomBorder = XLBorderStyleValues.Thin
                    .TopBorder = XLBorderStyleValues.Thin
                End With

            Next propertyInfo

            row += 1
        Next element
    End Sub

    Private Shared Sub CreateColumnHeaders(propertyList As List(Of PropertyInfo), workSheet As IXLWorksheet, Optional columnsExclude As List(Of Integer) = Nothing)



        Dim properties As New List(Of PropertyInfo)

        Dim column = 0

        For Each prop In propertyList
            column += 1
            If columnsExclude IsNot Nothing AndAlso columnsExclude.Contains(column - 1) Then Continue For
            properties.Add(prop)
        Next

        column = 0

        For Each propertyInfo In properties
            column += 1

            Dim excelColumn As IXLColumn = workSheet.Column(column)


            workSheet.Cell(1, column).Value = propertyInfo.Name
            Dim NameAttribute As DisplayNameAttribute = CType(Attribute.GetCustomAttribute(propertyInfo, GetType(DisplayNameAttribute)), DisplayNameAttribute)

            If NameAttribute IsNot Nothing Then
                workSheet.Cell(1, column).Value = NameAttribute.DisplayName
            End If


            workSheet.Cell(1, column).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
            workSheet.Cell(1, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            workSheet.Cell(1, column).Style.Fill.BackgroundColor = XLColor.LightGreen
            workSheet.Cell(1, column).Style.Font.Bold = True

            workSheet.Cell(1, column).Style.Border.RightBorder = XLBorderStyleValues.Thin
            workSheet.Cell(1, column).Style.Border.LeftBorder = XLBorderStyleValues.Thin
            workSheet.Cell(1, column).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            workSheet.Cell(1, column).Style.Border.TopBorder = XLBorderStyleValues.Thin

        Next

    End Sub


    Private Shared Sub AddColumnHeaders(columnList As List(Of String), workSheet As IXLWorksheet, Optional columnsExclude As List(Of Integer) = Nothing)

        Dim columns As New List(Of String)

        Dim column = 0

        For Each col In columnList
            column += 1
            If columnsExclude IsNot Nothing AndAlso columnsExclude.Contains(column - 1) Then Continue For
            columns.Add(col)
        Next

        column = 0
        For Each columnName In columns
            column += 1

            Dim excelColumn As IXLColumn = workSheet.Column(column)

            workSheet.Cell(1, column).Value = columnName

            workSheet.Cell(1, column).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
            workSheet.Cell(1, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            workSheet.Cell(1, column).Style.Fill.BackgroundColor = XLColor.LightGreen
            workSheet.Cell(1, column).Style.Font.Bold = True

            workSheet.Cell(1, column).Style.Border.RightBorder = XLBorderStyleValues.Thin
            workSheet.Cell(1, column).Style.Border.LeftBorder = XLBorderStyleValues.Thin
            workSheet.Cell(1, column).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            workSheet.Cell(1, column).Style.Border.TopBorder = XLBorderStyleValues.Thin

        Next

    End Sub

End Class
