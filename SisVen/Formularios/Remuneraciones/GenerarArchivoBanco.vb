Imports System.IO
Imports System.Collections.Generic

Public Class GenerarArchivoBanco
    Private Sub GenerarArchivoBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer, nMes As Integer

        For i = Year(Now) - 1 To Year(Now)
            cAño.Items.Add(i)
        Next i

        For i = 1 To 12
            cMes.Items.Add(Trim(MES(i)))
        Next i

        nMes = Month(Now)

        If nMes > 1 Then
            nMes = nMes - 1
        End If

        cAño.Text = Num(Year(Now))
        cMes.Text = Trim(MES(nMes))

        cFormato.Items.Add("BCI")
        cFormato.Items.Add("OfficeBanking")
        cFormato.Text = "BCI"

        cTipo.Items.Add(".CSV")
        cTipo.Items.Add(".TXT")
        cTipo.Items.Add(".XLS")

        If gClave = "W" Then
            cFormato.Text = "BCI"
            cTipo.Text = ".TXT"
        Else
            cFormato.Text = "OfficeBanking"
            cTipo.Text = ".CSV"
        End If

    End Sub

    Private Sub bGenerar_Click(sender As Object, e As EventArgs) Handles bGenerar.Click
        Dim Archivo As StreamWriter, Ruta As String, Registro As String, Separador As String
        Dim Datos As String, qRut As String, qDig As String
        Dim xAño As Integer, xMes As Integer, wGlosa As String

        xAño = Val(cAño.Text)
        xMes = cMes.SelectedIndex + 1

        Ruta = ""
        Datos = ""
        Separador = ""

        If Not ValidarCombo(cFormato) Then
            MsgError("Falta Formato Archivo del Banco")
            Exit Sub
        End If

        If Not ValidarCombo(cTipo) Then
            MsgError("Falta Tipo de Archivo a Generar")
            Exit Sub
        End If

        If cTipo.Text = ".XLS" Then
            Separador = vbTab
        End If
        If cTipo.Text = ".CSV" Then
            Separador = ";"
        End If
        If cTipo.Text = ".TXT" Then
            If gClave = "W" Then
                Separador = ";"
            Else
                Separador = ""
            End If
        End If

        If Pregunta("Desea Emitir Archivo para " & cFormato.Text) = False Then
            Exit Sub
        End If

        Call Auditoria(Me.Name, "Generar Archivo para Bancos", cAño.Text, cMes.Text)

        RmG = SQL("Select * from Sueldos where Año = " & Val(cAño.Text.Trim) & " and Mes = " & cMes.SelectedIndex + 1)
        If RmG.RecordCount = 0 Then
            MsgError("No hay Calculo de Sueldos para el Año:" & cAño.Text.Trim & "  Mes:" & cMes.Text.Trim)
            Exit Sub
        End If

        If cFormato.Text = "OfficeBanking" Then
            Ruta = Directorio_TXT + "\" + "OfficeBanking_" + Llena0(Now.Day, 2) + Llena0(Now.Month, 2) + Llena0(Now.Year, 4) + cTipo.Text
            Archivo = File.AppendText(Ruta)

            '1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            'Cta_origen  mon_origen  Cta_destino mon_destino Cod_banco   RUT benef.  nombre benef.                Mto Total   Glosa TEF                 Correo                  Glosa correo              Glosa Cartola Cliente   Glosa Cartola Beneficiario
            'XXXXXXX     CLP         XXXXXX      CLP         37          XXXXXXXXX   CARLOS ALFREDO AILEF VALDES  XXXXX       ABONO DE REMUNERACIONES   Ejemplo@santander.cl    ABONO DE REMUNERACIONES   Pago remuneraciones 1   Cancelado 1

            'Encabezado
            Registro = "Cuenta Origen" + Separador + "Moneda" + Separador + "Cuenta Destino" + Separador + "Moneda" + Separador + "Banco" + Separador + "Rut Beneficiario" + Separador + "Nombre Beneficiario" + Separador + "Monto" + Separador + "Glosa TEF" + Separador + "Correo" + Separador + "Glosa Correo" + Separador + "Glosa Cliente" + Separador + "Glosa Beneficiario"
            Archivo.Write(Registro + vbCrLf)

            While Not RmG.EOF
                If Buscar("Usuarios", "Usuario", RmG("Usuario").Value, "*") Then
                    If Val(Swap("Banco").Value) = 0 Then
                        'No tiene cuenta corriente
                    Else
                        wGlosa = "Pago Sueldo: " + Trim(Swap("NombreUsr").Value) + " " + MES(Val(xMes)) + " " + Num(xAño)

                        Registro = ""
                        If gClave = "W" Then
                            Registro = Registro + "66787150" + Separador                        ' Cuenta Origen
                        Else
                            Registro = Registro + "00000000" + Separador                        ' Cuenta Origen
                        End If
                        Registro = Registro + "CLP" + Separador                                 ' Moneda
                        Registro = Registro + Trim(Swap("CuentaCorriente").Value) + Separador         ' Cuenta Destino
                        Registro = Registro + "CLP" + Separador                                 ' Moneda
                        Registro = Registro + Llena0(Trim(Swap("Banco").Value), 3) + Separador        ' Codigo Banco
                        Registro = Registro + Replace(Formatea_Rut(Trim(Swap("Rut").Value)), "-", "") + Separador       ' Rut Beneficiario
                        Registro = Registro + Trim(Swap("NombreUsr").Value) + Separador               ' Nombre Beneficiario
                        Registro = Registro + Num(RmG("TLiquido").Value) + Separador                  ' Monto
                        Registro = Registro + wGlosa + Separador                                ' Glosa TEF
                        Registro = Registro + Swap("Correo").Value + Separador                        ' Correo
                        Registro = Registro + wGlosa + Separador                                ' Glosa Correo
                        Registro = Registro + wGlosa + Separador                                ' Glosa Cartola Wikets
                        Registro = Registro + wGlosa                                            ' Glosa Beneficiario

                        Archivo.Write(Registro + vbCrLf)
                    End If
                End If
                RmG.MoveNext()
            End While
            Archivo.Flush()
            Archivo.Close()
        End If

        If cFormato.Text = "BCI" Then
            Ruta = Directorio_TXT + "BCI_" + Llena0(Now.Day, 2) + Llena0(Now.Month, 2) + Llena0(Now.Year, 4) + cTipo.Text
            Archivo = File.AppendText(Ruta)

            'Cabecera
            'Registro = "Nº Cuenta de Cargo;Nº Cuenta de Destino;Banco Destino;Rut Beneficiario;Dig. Verif.;Beneficiario;Nombre Beneficiario;Monto Transferencia;Nro.Factura Boleta (1);Nº Orden de Compra(1);Tipo de Pago(2);Mensaje Destinatario (3);Email Destinatario(3);Cuenta Destino inscrita como(4)"
            'Archivo = File.AppendText(Ruta)

            While Not RmG.EOF
                If Buscar("Usuarios", "Usuario", RmG("Usuario").Value, "*") Then
                    If Val(Swap("Banco").Value) = 0 Then
                        'No tiene cuenta corriente
                    Else
                        wGlosa = "Sueldo " + MES(Val(xMes)) + " " + Num(xAño)

                        qRut = Trim(Swap("Rut").Value)
                        qRut = Replace(qRut, ".", "")
                        qRut = Replace(qRut, "-", "")
                        qRut = Mid(qRut, 1, Len(qRut) - 1)
                        qDig = UCase(Mid(Trim(Swap("Rut").Value), Len(Trim(Swap("Rut").Value)), 1))

                        Registro = ""
                        If gClave = "W" Then
                            Registro = Registro + "61991210" + Separador                            'Cuenta Origen
                        Else
                            Registro = Registro + "00000000" + Separador                            'Cuenta Origen
                        End If
                        Registro = Registro + Trim(Swap("CuentaCorriente").Value) + Separador             'Cuenta estino
                        Registro = Registro + Llena0(Val(Swap("Banco").Value), 3) + Separador             'Codigo del Banco
                        Registro = Registro + Llena0(qRut, 8) + Separador                           'Rut
                        Registro = Registro + qDig + Separador                                      'Digito Verificador
                        Registro = Registro + Formatea_Texto(Swap("NombreUsr").Value, 45) + Separador     'Nombre del Receptor
                        Registro = Registro + Num(RmG("TLiquido").Value) + Separador                      'Monto a pagar
                        Registro = Registro + "" + Separador                                        'N° Factura o Boleta
                        Registro = Registro + "" + Separador                                        'N° Orden de Compra
                        Registro = Registro + "REM" + Separador                                     'FAC:PAgo Factura   REM:REmuneraciones
                        Registro = Registro + Formatea_Texto(wGlosa, 30) + Separador                'Glosa
                        Registro = Registro + Mid(Swap("Correo").Value + Space(30), 1, 30) + Separador    'Email
                        Registro = Registro + Formatea_Texto(Swap("NombreUsr").Value, 25) + Separador     'Nombre de Cuenta

                        Archivo.Write(Registro + vbCrLf)
                    End If
                End If
                RmG.MoveNext()
            End While
            Archivo.Flush()
            Archivo.Close()
        End If

        Mensaje("Archivo Generado:" + vbCrLf + Ruta)

    End Sub

    Private Function Formatear_Rut(qRut As String) As String
        Formatear_Rut = qRut
        Formatear_Rut = Replace(Formatear_Rut, ".", "")
        Formatear_Rut = Replace(Formatear_Rut, "-", "")
        Formatear_Rut = Replace(Formatear_Rut, " ", "")

        Formatear_Rut = "000000000" + Formatear_Rut
        Formatear_Rut = Microsoft.VisualBasic.Strings.Right(Formatear_Rut, 10)
    End Function

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Me.Close()
    End Sub
End Class