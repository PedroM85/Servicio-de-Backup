Imports System.Xml
Imports System.Windows.Forms

Module Createrbase



    Public Sub Create()
        Dim settings As New XmlWriterSettings()
        settings.Indent = True

        Dim XmlWrt As XmlWriter = XmlWriter.Create(Application.StartupPath & "\Ewavebackup.xml", settings)

        With XmlWrt
            .WriteStartDocument()
            .WriteComment("Configuración para backup.")
            'write el directorio
            .WriteStartElement("wcproduction")


            .WriteComment("Nombre del Server de DB.")
            .WriteStartElement("Server")
            .WriteString("Defaults")
            .WriteEndElement()

            .WriteComment("Nombre de la Base de Datos a Backup.")
            .WriteStartElement("DataBase")
            .WriteString("Defaults")
            .WriteEndElement()

            .WriteComment("Directorio para guardar Backup.")
            .WriteStartElement("PathD")
            .WriteString("Defaults")
            .WriteEndElement()

            .WriteComment("Modo de Backup.")
            .WriteStartElement("Mode")
            .WriteString("Defaults")
            .WriteEndElement()

            .WriteComment("Intervalo de guardado x Minutos.")
            .WriteStartElement("IntervalMinutes")
            .WriteString("1")
            .WriteEndElement()

            .WriteComment("Intervalo de guardado x Horas.")
            .WriteStartElement("ScheduledTime")
            .WriteString("00:00")
            .WriteEndElement()

            .WriteComment("Ubicación para el registro de eventos.")
            .WriteStartElement("pathLOG")
            .WriteString("Defaults")
            .WriteEndElement()

            .WriteComment("Tiempo de Expiracion de la base de datos.")
            .WriteStartElement("Exp")
            .WriteString("3")
            .WriteEndElement()

            .WriteEndDocument()

            .Close()

        End With

    End Sub

End Module
