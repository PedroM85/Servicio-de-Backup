Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml
Imports Microsoft.SqlServer.Management.Smo


Public Class SystemBa
    Public oApp As Loading


    Private Schedular As System.Threading.Timer
    'Dim Parts As Integer = 0

    Public Sub New()

        oApp = New Loading

        oApp.Loadvariable()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)

        Try



            'Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO] " + globalVariables.AppName + " starting ")

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
                    scheduledTime = oApp.ScheduledTime.ToString("yyyy-MM-dd HH:mm:ss")

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
                        deleteoldbackupzip()

                    End If
                Catch ex As Exception
                    Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [Error] " + ex.Message + "in db " + oApp.DataBase)
                    End
                End Try

            End If

            If oApp.Mode.ToUpper() = "INTERVAL" Then
                'Get the Interval in Minutes from Config
                Try
                    scheduledTime = DateTime.Now.AddMinutes(oApp.IntervalMinutes).ToString("yyyy-MM-dd HH:mm:ss")
                    '   WriteToFile(scheduledTime)

                    If DateTime.Now < scheduledTime Then

                        ' scheduledTime = scheduledTime.AddMinutes(oApp.mIntervalMinutes)
                        Backup()
                        deleteoldbackup()
                        deleteoldbackupzip()

                    End If
                    'oApp.date2 = scheduledTime

                    'End If
                Catch ex As Exception
                    Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [Error] " + ex.Message + "in db " + oApp.DataBase)
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

#Region "Variable"



#End Region

#Region "Delete"


    'Private Sub deleteNow()
    '    Try
    '        Dim DateNow = String.Format("_db_{0:yyyy-MM-dd}.bak", DateTime.Now)

    '        Dim nombrestring As String = oApp.DataBase + DateNow
    '        Dim Directory As String = oApp.PathD + nombrestring

    '        If System.IO.File.Exists(Directory) = True Then
    '            System.IO.File.Delete(Directory)
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#Region "DeleteBackup"
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

#End Region

#Region "Deletebackupzip"

    Private Sub deleteoldbackupzip()
        Try
            Dim oldfiles As DateTime = Date.Now
            oldfiles = oldfiles.AddDays(-oApp.Exp).ToString
            Dim oldfilesnew = String.Format("_db_{0:yyyy-MM-dd}.zip", oldfiles)
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

#End Region

#Region "Backup"

    Private Sub Backup()
        Try

            Dim DateNow = String.Format("_db_{0:yyyy-MM-dd}.bak", DateTime.Now)
            Dim server = New Server(oApp.Server)
            Dim bkdir = oApp.PathD
            Dim Rutalog As String = oApp.PathLog

            Dim a As String = oApp.DataBase

            Dim dbBackup = New Backup()
            dbBackup.Action = BackupActionType.Database
            dbBackup.Database = oApp.DataBase

            If IO.File.Exists(bkdir + a + DateNow) Then
                IO.File.Delete(bkdir + a + DateNow)
                dbBackup.Devices.AddDevice(bkdir + a + DateNow, DeviceType.File)
                dbBackup.SqlBackup(server)
                'FileZip()
            Else
                dbBackup.Devices.AddDevice(bkdir + a + DateNow, DeviceType.File)
                dbBackup.SqlBackup(server)
                'FileZip()
            End If

            'If oApp.Mode.ToUpper = "DAILY" Then
            '    Try
            '        If oApp.Zip = True Then
            '            If IO.File.Exists(bkdir + Part1 + DateNow) Then
            '                IO.File.Delete(bkdir + Part1 + DateNow)
            '                dbBackup.Devices.AddDevice(bkdir + Part1 + DateNow, DeviceType.File)
            '                dbBackup.SqlBackup(server)
            '                FileZip()
            '            Else
            '                dbBackup.Devices.AddDevice(bkdir + Part1 + DateNow, DeviceType.File)
            '                dbBackup.SqlBackup(server)
            '                FileZip()
            '            End If
            '        Else
            '            If IO.File.Exists(bkdir + Part1 + DateNow) Then
            '                IO.File.Delete(bkdir + Part1 + DateNow)
            '                dbBackup.Devices.AddDevice(bkdir + Part1 + DateNow, DeviceType.File)
            '                dbBackup.SqlBackup(server)
            '            Else
            '                dbBackup.Devices.AddDevice(bkdir + Part1 + DateNow, DeviceType.File)
            '                dbBackup.SqlBackup(server)
            '            End If
            '        End If
            '    Catch ex As Exception

            '    End Try

            'ElseIf oApp.Mode.ToUpper = "INTERVAL" Then
            '    Try

            '        If oApp.Zip = True Then
            '            If IO.File.Exists(bkdir + Part1 + DateNow) = True Then
            '                Me.WriteToFile("antes de eliminar " + bkdir + Part1 + DateNow)
            '                IO.File.Delete(bkdir + Part1 + DateNow)
            '                dbBackup.Devices.AddDevice(bkdir + Part1 + DateNow, DeviceType.File)
            '                Me.WriteToFile("Despues de eliminar " + bkdir + Part1 + DateNow)
            '                dbBackup.SqlBackup(server)
            '                FileZip()
            '            Else
            '                dbBackup.Devices.AddDevice(bkdir + Part1 + DateNow, DeviceType.File)
            '                dbBackup.SqlBackup(server)
            '                FileZip()
            '            End If
            '        Else
            '            If IO.File.Exists(bkdir + Part1 + DateNow) = True Then
            '                IO.File.Delete(bkdir + Part1 + DateNow)
            '                dbBackup.Devices.AddDevice(bkdir + Part1 + DateNow, DeviceType.File)
            '                dbBackup.SqlBackup(server)
            '            Else
            '                dbBackup.Devices.AddDevice(bkdir + Part1 + DateNow, DeviceType.File)
            '                dbBackup.SqlBackup(server)
            '            End If
            '        End If
            '    Catch ex As Exception

            '    End Try
            'End If
            'Next




            Me.WriteToFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + " [INFO] " + globalVariables.AppName + " " + oApp.DataBase + " backup successfully completed: " + oApp.PathD)
        Catch ex As Exception
            Me.WriteToFile("Error en el Backup: " + ex.Message)
        End Try

    End Sub
#End Region

    Private Sub WriteToFile(text As String)
        'Directorio del backup 
        Dim a As String = oApp.DataBase
        Dim Parts() As String = Split(a, ",")

        Try
            ' For Each Part1 In Parts
            'If System.IO.File.Exists(Application.StartupPath & "\" + Part1 + "LOG.log") = True Then
            Using writer As New StreamWriter(Application.StartupPath & "\" + a + "LOG.log", True)
                writer.WriteLine(String.Format(text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ")))
                writer.Close()
            End Using
            '    Else
            Using writer As New StreamWriter(Application.StartupPath & "\LogTemporal.log", True)
                writer.WriteLine(String.Format(text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ")))
                writer.Close()
            End Using
            '   End If
            ' Next
        Catch ex As Exception

            'If ex.Message.Trim = "Could not find file '" + (WindowsService) & "'." = True Then
            '    MsgBox("Create configuration file first.")
            'End If

        End Try

    End Sub
#If DEBUG Then
    Protected Sub OnDebug()
        Debugger.Launch()
        OnStart(Nothing)
    End Sub
#End If

End Class
