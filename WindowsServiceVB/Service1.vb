Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common
Imports System.Globalization


Public Class Service1
    Dim oApp As WCProduction = New WCProduction
    Private Schedular As System.Threading.Timer
    Dim WindowsService As String = (Application.StartupPath & "\EwaveBackup.xml")
    'Variables
    



    Protected Overrides Sub OnStart(ByVal args() As String)
        Try

            Loadvariable()

            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO] " + globalVariables.AppName + " starting ")
            Me.ScheduleService()
        Catch ex As Exception
            Me.WriteToFile(ex.Message)
        End Try
        

    End Sub

    Protected Overrides Sub OnStop()
        Try
            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [ERROR] " + globalVariables.AppName + " arrested ")
            Me.Schedular.Dispose()
        Catch ex As Exception
            Me.WriteToFile(ex.Message)
        End Try
  
    End Sub

    Public Sub ScheduleService()
        Try
            Dim scheduledTime As DateTime = DateTime.MinValue
            Dim date1 As DateTime = DateTime.Now.ToString("HH:mm:ss")
            Schedular = New System.Threading.Timer(New TimerCallback(AddressOf SchedularCallback))


            'Informacion del tipo de backup
            Me.WriteToFile((Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO] " + globalVariables.AppName + " Backup mode: ") & oApp.Mode))

            'Set the Default Time.


            If oApp.Mode.ToUpper() = "DAILY" Then
                'Get the Scheduled Time from AppSettings.
                Try
                    'get to infor from configurate file                    
                    scheduledTime = oApp.mScheduledTime.ToString("yyyy-MM-dd HH:mm:ss")

                    Dim date3 As DateTime = DateTime.Now.ToString("yyyy-MM-dd")
                    'Me.WriteToFile(date3)
                    scheduledTime = date3 + " " & scheduledTime
                    'Me.WriteToFile(scheduledTime + "a")

                    If DateTime.Now > scheduledTime Then
                        'If Scheduled Time is passed set Schedule for the next day.
                        scheduledTime = scheduledTime.AddDays(1)
                        '  Me.WriteToFile(scheduledTime + "en la suma")
                        Backup()
                        deleteoldbackup()

                    End If
                Catch ex As Exception
                    Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [Error] " + ex.Message + "in db " + oApp.mDataBase)
                    End
                End Try

            End If

            If oApp.Mode.ToUpper() = "INTERVAL" Then
                'Get the Interval in Minutes from Config
                Try
                    scheduledTime = DateTime.Now.AddMinutes(oApp.mIntervalMinutes).ToString("yyyy-MM-dd HH:mm:ss")
                    '   WriteToFile(scheduledTime)
                 
                    If DateTime.Now < scheduledTime Then

                        ' scheduledTime = scheduledTime.AddMinutes(oApp.mIntervalMinutes)
                        Backup()
                        deleteoldbackup()

                    End If
                    'oApp.date2 = scheduledTime

                    'End If
                Catch ex As Exception
                    Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [Error] " + ex.Message + "in db " + oApp.mDataBase)
                    End
                End Try


            End If

            ' WriteToFile(scheduledTime + " Ante de la resta")
            Dim timeSpan As TimeSpan = scheduledTime.Subtract(DateTime.Now)
            Dim schedule As String = String.Format("{0} day(s) {1} hour(s) {2} minute(s) {3} seconds(s)", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds)
            Me.WriteToFile((DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO]" + " Scheduled to run after: ") & schedule)

            'Get the difference in Minutes between the Scheduled and Current Time.
            Dim dueTime As Integer = Convert.ToInt32(timeSpan.TotalMilliseconds)
            'Change the Timer's Due Time.
            Schedular.Change(dueTime, Timeout.Infinite)



        Catch ex As Exception
            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [Error] " + "Error en el mode de configuración. Daily ó Interval. " + ex.Message)

            'Stop the Windows Service.
            Using serviceController As New System.ServiceProcess.ServiceController("SimpleService")
                serviceController.[Stop]()
            End Using
        End Try
    End Sub

    Private Sub SchedularCallback(e As Object)
        Try
            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO] " + globalVariables.AppName + " Log: ")
            Me.ScheduleService()
        Catch ex As Exception
            Me.WriteToFile(ex.Message)
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
            Else
                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO] " + ": El archivo de configuración no existe.! Ejecutar EwaveBackupUI.")
                End

            End If
        Catch ex As Exception
            Me.WriteToFile("Error del config: " + ex.Message)
        End Try


    End Sub

    Private Sub FileZip()
        Try
            Dim DateNow = String.Format("_db_{0:yyyy-MM-dd}", DateTime.Now)

            Dim nombrestring As String = oApp.DataBase + DateNow
            Dim Directory As String = oApp.PathD + nombrestring + ".bak"

            Dim Directoryzip As String = oApp.PathD + nombrestring + ".zip"

            If System.IO.File.Exists(Directory) = True Then

                Using archive As ZipArchive = ZipFile.Open(Directoryzip, ZipArchiveMode.Update)
                    If oApp.opZip = "0" Then
                        archive.CreateEntryFromFile(Directory, nombrestring + ".bak", CompressionLevel.NoCompression)
                    ElseIf oApp.opZip = "1" Then
                        archive.CreateEntryFromFile(Directory, nombrestring + ".bak", CompressionLevel.Fastest)
                    ElseIf oApp.opZip = "2" Then
                        archive.CreateEntryFromFile(Directory, nombrestring + ".bak", CompressionLevel.Optimal)
                    End If
                End Using

                deleteNow()

            End If
        Catch ex As Exception
            Me.WriteToFile("Error realizando la comprension: " + ex.Message)
        End Try
        

    End Sub
    Private Sub deleteNow()
        Try
            Dim DateNow = String.Format("_db_{0:yyyy-MM-dd}.bak", DateTime.Now)

            Dim nombrestring As String = oApp.DataBase + DateNow
            Dim Directory As String = oApp.PathD + nombrestring

            If System.IO.File.Exists(Directory) = True Then
                System.IO.File.Delete(Directory)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub deleteoldbackup()
        Try
            Dim oldfiles As DateTime = Date.Now
            oldfiles = oldfiles.AddDays(-oApp.Exp).ToString
            Dim oldfilesnew = String.Format("_db_{0:yyyy-MM-dd}.bak", oldfiles)
            Dim nombrestrnig As String
            nombrestrnig = oApp.DataBase + oldfilesnew
            Dim Directory As String = oApp.PathD + nombrestrnig

            If System.IO.File.Exists(Directory) = True Then
                System.IO.File.Delete(Directory)
                Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO] " + globalVariables.AppName + " " + oApp.DataBase + " backup olds delete successfully: " + nombrestrnig)
            End If


        Catch ex As Exception
            Me.WriteToFile("Error al eliminar archivo: " + ex.Message)
        End Try
    End Sub

    Private Sub Backup()
        Try

            Dim DateNow = String.Format("_db_{0:yyyy-MM-dd}.bak", DateTime.Now)
            Dim server = New Server(oApp.Server)
            Dim bkdir = oApp.PathD
            Dim Rutalog As String = oApp.pathLOG
            Dim Database As String = oApp.DataBase

            Dim dbs = server.Databases()

            Dim DBObject = server.Databases(Database)
            Dim dbBackup = New Backup()
            dbBackup.Action = BackupActionType.Database
            dbBackup.Database = Database


            If oApp.Mode.ToUpper = "DAILY" Then
                Try
                    If oApp.Zip = True Then
                        If IO.File.Exists(bkdir + Database + DateNow) Then
                            IO.File.Delete(bkdir + Database + DateNow)
                            dbBackup.Devices.AddDevice(bkdir + Database + DateNow, DeviceType.File)
                            dbBackup.SqlBackup(server)
                            FileZip()
                        Else
                            dbBackup.Devices.AddDevice(bkdir + Database + DateNow, DeviceType.File)
                            dbBackup.SqlBackup(server)
                            FileZip()
                        End If
                    Else
                        If IO.File.Exists(bkdir + Database + DateNow) Then
                            IO.File.Delete(bkdir + Database + DateNow)
                            dbBackup.Devices.AddDevice(bkdir + Database + DateNow, DeviceType.File)
                            dbBackup.SqlBackup(server)
                        Else
                            dbBackup.Devices.AddDevice(bkdir + Database + DateNow, DeviceType.File)
                            dbBackup.SqlBackup(server)
                        End If
                    End If
                Catch ex As Exception

                End Try

            ElseIf oApp.Mode.ToUpper = "INTERVAL" Then
                Try
                    If oApp.Zip = True Then
                        If IO.File.Exists(bkdir + Database + DateNow) = True Then
                            IO.File.Delete(bkdir + Database + DateNow)
                            dbBackup.Devices.AddDevice(bkdir + Database + DateNow, DeviceType.File)
                            dbBackup.SqlBackup(server)
                            FileZip()
                        Else
                            dbBackup.Devices.AddDevice(bkdir + Database + DateNow, DeviceType.File)
                            dbBackup.SqlBackup(server)
                            FileZip()
                        End If
                    Else
                        If IO.File.Exists(bkdir + Database + DateNow) = True Then
                            IO.File.Delete(bkdir + Database + DateNow)
                            dbBackup.Devices.AddDevice(bkdir + Database + DateNow, DeviceType.File)
                            dbBackup.SqlBackup(server)
                        Else
                            dbBackup.Devices.AddDevice(bkdir + Database + DateNow, DeviceType.File)
                            dbBackup.SqlBackup(server)
                        End If
                    End If
                Catch ex As Exception

                End Try

            End If


            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO] " + globalVariables.AppName + " " + oApp.DataBase + " backup successfully completed: " + oApp.PathD)
        Catch ex As Exception
            Me.WriteToFile("Error en el Backup: " + ex.Message)
        End Try
       
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
    '#If DEBUG Then
    '            Protected Sub OnDebug()
    '                Debugger.Launch()
    '                OnStart(Nothing)
    '            End Sub
    '#End If

End Class
