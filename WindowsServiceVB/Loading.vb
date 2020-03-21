Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Public Class Loading
    Inherits WCProduction


    Public Ruta As String = (Application.StartupPath & "\EwaveBackup.xml")




    Public Sub RutaFile(ByVal FileRuta As String)

        mLogFile = New LogFile(FileRuta, "EwaveBackup")
        mLogFile.BeginLog()
    End Sub

    Protected mLogFile As LogFile

    Public Sub Loadvariable()
        Try

            If System.IO.File.Exists(Ruta) = True Then

                Dim wcProductions As New List(Of WCProduction)
                Dim reader As XmlReader = XmlReader.Create(Ruta)
                While (Not reader.EOF)
                    If reader.Name <> "wcproduction" Then
                        reader.ReadToFollowing("wcproduction")
                    End If
                    If Not reader.EOF Then
                        Dim xwcProduction As XElement = XElement.ReadFrom(reader)
                        Dim wcproduction As New WCProduction
                        wcProductions.Add(wcproduction)




                        If IsNothing(xwcProduction.Element("Server")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'Server!'")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("Server")) Then
                                Logfile.LogEvent(" El archivo de configuracion tiene el parametro 'Server' Vacio! ")
                                End
                            Else
                                Server = xwcProduction.Element("Server")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("DataBase")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'DataBase!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("DataBase")) Then
                                Logfile.LogEvent(" El archivo de configuracion tiene el parametro 'DataBase' Vacio! ")
                                End
                            Else
                                DataBase = xwcProduction.Element("DataBase")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("PathD")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'PathD!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("PathD")) Then
                                Logfile.LogEvent(" El archivo de configuracion tiene el parametro 'PathD' Vacio! ")
                                End
                            Else
                                PathD = xwcProduction.Element("PathD")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("Mode")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'Mode!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("Mode")) Then
                                Logfile.LogEvent(" El archivo de configuracion tiene el parametro 'Mode' Vacio! ")
                                End
                            Else
                                Mode = xwcProduction.Element("Mode")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("IntervalMinutes")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'IntervalMinutes!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("IntervalMinutes")) Then
                                Logfile.LogEvent(" El archivo de configuracion tiene el parametro 'IntervalMinutes' Vacio! ")
                                End
                            Else
                                IntervalMinutes = xwcProduction.Element("IntervalMinutes")
                                If IntervalMinutes = 0 Then
                                    IntervalMinutes = 1
                                Else
                                    IntervalMinutes = xwcProduction.Element("IntervalMinutes")
                                End If

                            End If
                        End If

                        If IsNothing(xwcProduction.Element("ScheduledTime")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'ScheduledTime!' ")

                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("ScheduledTime")) Then
                                Logfile.LogEvent(" El archivo de configuracion tiene el parametro 'ScheduledTime' Vacio! ")

                                End
                            Else
                                Dim odatah As DateTime = xwcProduction.Element("ScheduledTime")
                                odatah = Format(odatah, "HH:mm:ss")
                                ScheduledTime = odatah
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("pathLOG")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'pathLOG!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("pathLOG")) Then
                                Logfile.LogEvent(" El archivo de configuracion tiene el parametro 'pathLOG' Vacio! ")
                                End
                            Else
                                PathLog = xwcProduction.Element("pathLOG")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("Exp")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'Exp!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("Exp")) Then
                                Logfile.LogEvent(" El archivo de configuracion tiene el parametro 'Exp' Vacio! ")
                                End
                            Else
                                Exp = xwcProduction.Element("Exp")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("Zip")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'Zip!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("Zip")) Then
                                Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'Zip!' ")
                                End
                            Else
                                Zip = xwcProduction.Element("Zip")
                            End If
                        End If

                        If IsNothing(xwcProduction.Element("opZip")) Then
                            Logfile.LogEvent(" El archivo de configuracion no tiene el parametro 'opZip!' ")
                            End
                        Else
                            If String.IsNullOrEmpty(xwcProduction.Element("opZip")) Then
                                Logfile.LogEvent(" El archivo de configuracion tiene el parametro 'opZip' Vacio! ")
                                End
                            Else
                                opZip = xwcProduction.Element("opZip")
                            End If
                        End If

                    End If

                End While
            Else
                Logfile.LogEvent(" El archivo de configuración no existe.! Ejecutar EwaveBackupUI.")

                End
            End If
        Catch ex As Exception
            Logfile.LogEvent("Error del config: " + ex.Message)
        End Try


    End Sub

    Public Property Logfile() As LogFile
        Get
            Return mLogFile
        End Get
        Set(value As LogFile)
            mLogFile = value
        End Set
    End Property

End Class
