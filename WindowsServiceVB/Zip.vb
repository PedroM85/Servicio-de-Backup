Imports System.IO.Compression

Public Class Zip
    Private Sub FileZip(ByVal oapp As Object)
        Try
            Dim DateNow = String.Format("_db_{0:yyyy-MM-dd}", DateTime.Now)

            Dim nombrestring As String = oapp.DataBase + DateNow
            Dim Directory As String = oapp.PathD + nombrestring + ".bak"

            Dim Directoryzip As String = oapp.PathD + nombrestring + ".zip"

            If System.IO.File.Exists(Directory) = True Then

                Using archive As ZipArchive = ZipFile.Open(Directoryzip, ZipArchiveMode.Update)
                    If oapp.opZip = "0" Then
                        archive.CreateEntryFromFile(Directory, nombrestring + ".bak", CompressionLevel.NoCompression)
                    ElseIf oapp.opZip = "1" Then
                        archive.CreateEntryFromFile(Directory, nombrestring + ".bak", CompressionLevel.Fastest)
                    ElseIf oapp.opZip = "2" Then
                        archive.CreateEntryFromFile(Directory, nombrestring + ".bak", CompressionLevel.Optimal)
                    End If
                End Using

                'deleteNow()

            End If
        Catch ex As Exception
            'Me.WriteToFile("Error realizando la comprension: " + ex.Message)
        End Try


    End Sub

End Class
