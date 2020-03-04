Imports System.IO
Imports System.Xml
Imports System.Xml.Linq
Imports System.Threading

Enum Intervalos
    Daily
    Interval
End Enum

Public Class FrmMain
    Dim oApp As WCProduction = New WCProduction
    Dim WindowsService As String = (Application.StartupPath & "\EwaveBackup.xml")

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbInterval.DataSource = [Enum].GetValues(GetType(Intervalos))
        Desactive()
        Try
            If System.IO.File.Exists(Application.StartupPath & "\EwaveBackup.xml") = True Then

                'carga()
                Loadvariable()

            Else
                Create()
                'carga()
                Loadvariable()
            End If


        Catch ex As Exception

            If ex.Message = "Root element is missing." = True Then
                MsgBox("Error al inicializar: Archivo de configuración vacio!")
                Me.Close()
            ElseIf ex.Message = "Data at the root level is invalid. Line 1, position 1." = True Then
                MsgBox("Error al inicializar: Archivo de configuración errado!")
                Me.Close()
            End If
            MsgBox("Error al inicializar: " & ex.Message)
        End Try



    End Sub

    Private Sub Loadvariable()
        Try
            If System.IO.File.Exists(Application.StartupPath & "\Ewavebackup.xml") = True Then


                Dim wcProductions As New List(Of WCProduction)
                Dim reader As XmlReader = XmlReader.Create(WindowsService)
                While (Not reader.EOF)
                    If reader.Name <> "wcproduction" Then
                        reader.ReadToFollowing("wcproduction")
                    End If
                    If Not reader.EOF Then
                        Dim xwcProduction As XElement = XElement.ReadFrom(reader)
                        Dim wcproduction As New WCProduction
                        wcProductions.Add(wcproduction)




                        If IsNothing(xwcProduction.Element("Server")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'Server!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("Server")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'Server' Vacio! ")
                                End
                            Else
                                oApp.Server = xwcProduction.Element("Server")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("DataBase")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'DataBase!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("DataBase")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'DataBase' Vacio! ")
                                End
                            Else
                                oApp.DataBase = xwcProduction.Element("DataBase")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("PathD")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'PathD!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("PathD")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'PathD' Vacio! ")
                                End
                            Else
                                oApp.PathD = xwcProduction.Element("PathD")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("Mode")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'Mode!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("Mode")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'Mode' Vacio! ")
                                End
                            Else
                                oApp.Mode = xwcProduction.Element("Mode")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("IntervalMinutes")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'IntervalMinutes!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("IntervalMinutes")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'IntervalMinutes' Vacio! ")
                                End
                            Else
                                oApp.IntervalMinutes = xwcProduction.Element("IntervalMinutes")
                                If oApp.IntervalMinutes = 0 Then
                                    oApp.IntervalMinutes = 1
                                Else
                                    oApp.IntervalMinutes = xwcProduction.Element("IntervalMinutes")
                                End If

                            End If
                        End If

                        If IsNothing(xwcProduction.Element("ScheduledTime")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'ScheduledTime!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("ScheduledTime")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'ScheduledTime' Vacio! ")
                                End
                            Else
                                Dim odatah As DateTime = xwcProduction.Element("ScheduledTime")
                                odatah = Format(odatah, "HH:mm:ss")
                                oApp.mScheduledTime = odatah
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("pathLOG")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'pathLOG!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("pathLOG")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'pathLOG' Vacio! ")
                                End
                            Else
                                oApp.pathLOG = xwcProduction.Element("pathLOG")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("Exp")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'Exp!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("Exp")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'Exp' Vacio! ")
                                End
                            Else
                                oApp.Exp = xwcProduction.Element("Exp")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("Zip")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'Zip!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("Zip")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'Zip' Vacio! ")
                                End
                            Else
                                oApp.Zip = xwcProduction.Element("Zip")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("opZip")) Then
                            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion no tiene el parametro 'opZip!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("opZip")) Then
                                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR]" + " El archivo de configuracion tiene el parametro 'opZip' Vacio! ")
                                End
                            Else
                                oApp.opZip = xwcProduction.Element("opZip")
                            End If
                        End If
                    End If

                End While

                reader.Close()

                txtServer.Text = oApp.Server
                txtDataBase.Text = oApp.DataBase
                txtPathD.Text = oApp.PathD
                cmbInterval.Text = oApp.Mode
                txtMinutos.Text = oApp.IntervalMinutes
                txtDaily.Text = oApp.ScheduledTime
                txtPathLog.Text = oApp.pathLOG
                txtExp.Text = oApp.Exp
                If oApp.Zip = True Then
                    chkComprimir.Checked = True
                    If oApp.opZip = "0" Then
                        rbtNormal.Checked = True
                    ElseIf oApp.opZip = "1" Then
                        rbtHigh.Checked = True
                    ElseIf oApp.opZip = "2" Then
                        rbtMaximum.Checked = True
                    End If
                Else
                    chkComprimir.Checked = False
                End If


            Else
                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO] " + ": El archivo de configuración no existe.! Ejecutar EwaveBackupUI.")
                End

            End If

           

        Catch ex As Exception
            Me.WriteToFile("Error del config: " + ex.Message)
        End Try


    End Sub

    Public Sub Create()
        Dim settings As New XmlWriterSettings()
        settings.Indent = True

        Dim XmlWrt As XmlWriter = XmlWriter.Create(Application.StartupPath & "\EwaveBackup.xml", settings)

        With XmlWrt
            .WriteStartDocument()
            .WriteComment("Configuración para backup.")
            'write el directorio
            .WriteStartElement("wcproduction")


            .WriteComment("Nombre del Server de DB.")
            .WriteStartElement("Server")
            .WriteString("Local")
            .WriteEndElement()

            .WriteComment("Nombre de la Base de Datos a Backup.")
            .WriteStartElement("DataBase")
            .WriteString("model")
            .WriteEndElement()

            .WriteComment("Directorio para guardar Backup.")
            .WriteStartElement("PathD")
            .WriteString("C:\BackupBases\")
            .WriteEndElement()

            .WriteComment("Modo de Backup.")
            .WriteStartElement("Mode")
            .WriteString("Interval")
            .WriteEndElement()

            .WriteComment("Intervalo de guardado x Minutos.")
            .WriteStartElement("IntervalMinutes")
            .WriteString("5")
            .WriteEndElement()

            .WriteComment("Intervalo de guardado x Horas.")
            .WriteStartElement("ScheduledTime")
            .WriteString("23:59")
            .WriteEndElement()

            .WriteComment("Ubicación para el registro de eventos.")
            .WriteStartElement("pathLOG")
            .WriteString("C:\EwaveBackup\EwaveBackupLog.txt")
            .WriteEndElement()

            .WriteComment("Tiempo de Expiracion de la base de datos.")
            .WriteStartElement("Exp")
            .WriteString("15")
            .WriteEndElement()

            .WriteComment("Activo para comprimir el archivo.")
            .WriteStartElement("Zip")
            .WriteString("False")
            .WriteEndElement()

            .WriteComment("tipo de compresion para el archivo.")
            .WriteStartElement("opZip")
            If chkComprimir.Checked = True Then
                If rbtNormal.Checked = True Then
                    .WriteString("0")
                End If
                If rbtHigh.Checked = True Then
                    .WriteString("1")
                End If
                If rbtMaximum.Checked = True Then
                    .WriteString("2")
                End If
            Else
                .WriteString("0")
            End If

            .WriteEndElement()

            .WriteEndDocument()

            .Close()
            .Dispose()
        End With

        MessageBox.Show("Archivo de configuración base creado", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Sub Desactive()
        txtServer.Enabled = False
        txtPathLog.Enabled = False
        txtDataBase.Enabled = False
        txtPathD.Enabled = False
        cmbInterval.Enabled = False
        txtDaily.Enabled = False
        txtMinutos.Enabled = False
        btnSave.Visible = False
        btnSearch.Enabled = False
        btnsearch1.Enabled = False
        txtExp.Enabled = False
        chkComprimir.Enabled = False
        rbtMaximum.Enabled = False
        rbtHigh.Enabled = False
        rbtNormal.Enabled = False

    End Sub
    Public Sub Active()
        txtServer.Enabled = True
        txtDataBase.Enabled = True
        txtPathD.Enabled = False
        txtPathLog.Enabled = False
        cmbInterval.Enabled = True
        txtDaily.Enabled = True
        txtMinutos.Enabled = True
        btnSearch.Enabled = True
        btnsearch1.Enabled = True
        txtExp.Enabled = True
        chkComprimir.Enabled = True
        rbtMaximum.Enabled = True
        rbtNormal.Enabled = True
        rbtHigh.Enabled = True
    End Sub


    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Active()
        btnModify.Visible = False
        btnSave.Visible = True


    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Me.Dispose()
        End
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Desactive()
        btnModify.Visible = True
        btnSave.Visible = False


        Try

            Dim settings As New XmlWriterSettings()
            settings.Indent = True

            Dim WindowsService As String = (Application.StartupPath & "\EwaveBackup.xml")
            Dim Save As XmlWriter = XmlWriter.Create(WindowsService, settings)

            With Save
                .WriteStartDocument()
                .WriteComment("Configuración para backup.")
                'write el directorio
                .WriteStartElement("wcproduction")


                .WriteComment("Nombre del Server de DB.")
                .WriteStartElement("Server")
                .WriteString(txtServer.Text.Trim)
                .WriteEndElement()

                .WriteComment("Nombre de la Base de Datos a Backup.")
                .WriteStartElement("DataBase")
                .WriteString(txtDataBase.Text.Trim)
                .WriteEndElement()

                .WriteComment("Directorio para guardar Backup.")
                .WriteStartElement("PathD")
                .WriteString(txtPathD.Text.Trim)
                .WriteEndElement()

                .WriteComment("Modo de Backup.")
                .WriteStartElement("Mode")
                .WriteString(cmbInterval.Text.Trim)
                .WriteEndElement()

                .WriteComment("Intervalo de guardado x Minutos.")
                .WriteStartElement("IntervalMinutes")
                .WriteString(txtMinutos.Text.Trim)
                .WriteEndElement()

                .WriteComment("Intervalo de guardado x Horas.")
                .WriteStartElement("ScheduledTime")
                .WriteString(txtDaily.Text.Trim)
                .WriteEndElement()

                .WriteComment("Ubicación para el registro de eventos.")
                .WriteStartElement("pathLOG")
                .WriteString(txtPathLog.Text.Trim)
                .WriteEndElement()

                .WriteComment("Tiempo de Expiracion de la base de datos.")
                .WriteStartElement("Exp")
                .WriteString(txtExp.Text.Trim)
                .WriteEndElement()

                .WriteComment("Comando para comprimir el archivo.")
                .WriteStartElement("Zip")
                .WriteString(chkComprimir.Checked)
                .WriteEndElement()

                .WriteComment("tipo de compresion para el archivo.")
                .WriteStartElement("opZip")
                If chkComprimir.Checked = True Then
                    If rbtNormal.Checked = True Then
                        .WriteString("0")
                    End If
                    If rbtHigh.Checked = True Then
                        .WriteString("1")
                    End If
                    If rbtMaximum.Checked = True Then
                        .WriteString("2")
                    End If
                Else
                    .WriteString("0")
                End If
                '.WriteString(chkComprimir.Checked)
                .WriteEndElement()

                .WriteEndDocument()

                .Close()
                .Dispose()
            End With
            If System.IO.File.Exists(txtDataBase.Text + "LOG.txt") = False Then
                Using writer As New StreamWriter(Application.StartupPath & "\" + txtDataBase.Text + "LOG.txt", True)
                    writer.Close()
                End Using
            End If
        Catch ex As Exception
            MsgBox("Error al guardar: " & ex.Message)
        End Try

    End Sub

    Private Sub cmbInterval_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbInterval.SelectedItem.ToString = "Interval" Then
            txtMinutos.Visible = True
            lblMinutos.Visible = True
            txtDaily.Visible = False
            lblDaily.Visible = False
        ElseIf cmbInterval.SelectedItem.ToString = "Daily" Then
            txtMinutos.Visible = False
            lblMinutos.Visible = False
            txtDaily.Visible = True
            lblDaily.Visible = True
        End If
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        With Me.fbPath
            .Description = "Seleciona ubicacion del backup!"
            .ShowDialog()

            If .SelectedPath.Length > 0 Then
                Me.txtPathD.Text = .SelectedPath.ToString + "\"
            End If
        End With
    End Sub

    Private Sub btnsearch1_Click(sender As Object, e As EventArgs)

        With Me.fbPath
            .Description = "Seleciona ubicacion del LOG!"
            .ShowDialog()

            If .SelectedPath.Length > 0 Then
                Me.txtPathLog.Text = .SelectedPath.ToString + "\"
            End If
        End With
    End Sub

    Private Sub txtServer_LostFocus(sender As Object, e As EventArgs)
        txtServer.Text.Trim()
    End Sub

    Private Sub WriteToFile(text As String)
        'Directorio del backup 
        Try
            If System.IO.File.Exists(Application.StartupPath & "\" + oApp.DataBase + "LOG.txt") = True Then
                Using writer As New StreamWriter(Application.StartupPath & "\" + oApp.DataBase + "LOG.txt", True)
                    writer.WriteLine(String.Format(text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ")))
                    writer.Close()
                End Using
            Else
                Using writer As New StreamWriter(Application.StartupPath & "\LogTemporal.txt", True)
                    writer.WriteLine(String.Format(text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ")))
                    writer.Close()
                End Using
            End If
        Catch ex As Exception

            If ex.Message.Trim = "Could not find file '" + (WindowsService) & "'." = True Then
                MsgBox("Create configuration file first.")
            End If

        End Try

    End Sub

    Private Sub btnsearch1_Click_1(sender As Object, e As EventArgs) Handles btnsearch1.Click
        With Me.fbPath
            .Description = "Seleciona ubicacion del LOG!"
            .ShowDialog()

            If .SelectedPath.Length > 0 Then
                Me.txtPathLog.Text = .SelectedPath.ToString + "\"
            End If
        End With
    End Sub

    

    Private Sub chkComprimir_Click(sender As Object, e As EventArgs) Handles chkComprimir.Click
        Try

            If chkComprimir.Checked = True Then
                rbtHigh.Checked = True
                rbtMaximum.Enabled = True
                rbtNormal.Enabled = True
                rbtHigh.Enabled = True
            Else
                rbtMaximum.Enabled = False
                rbtNormal.Enabled = False
                rbtHigh.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        With Me.fbPath
            .Description = "Seleciona ubicacion del backup!"
            .ShowDialog()

            If .SelectedPath.Length > 0 Then
                Me.txtPathD.Text = .SelectedPath.ToString + "\"
            End If
        End With
    End Sub

  

    Private Sub cmbInterval_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbInterval.SelectedIndexChanged
        If cmbInterval.SelectedItem.ToString = "Interval" Then
            txtMinutos.Visible = True
            lblMinutos.Visible = True
            txtDaily.Visible = False
            lblDaily.Visible = False
        ElseIf cmbInterval.SelectedItem.ToString = "Daily" Then
            txtMinutos.Visible = False
            lblMinutos.Visible = False
            txtDaily.Visible = True
            lblDaily.Visible = True
        End If
    End Sub
End Class