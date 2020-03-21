Imports System.IO

Public Class fileruta

    Dim file As FileStream
    Dim filestream As StreamWriter

    Private mPath As String
    Private mNameFile As String

    Dim mLogIsActive As Boolean = False


    Public Sub New(ByVal Path As String, ByVal NameFile As String)
        Me.Path = Path
        Me.NameFile = NameFile

    End Sub




    Public Property Path As String
        Get
            Return mPath
        End Get
        Set(value As String)
            Try
                If value.Substring(value.Length - 1, 1) = "\" Then
                    mPath = value
                Else
                    mPath = value & "\"
                End If
                If Not Directory.Exists(mPath) Then
                    mPath = ""
                    mLogIsActive = False
                Else
                    mLogIsActive = True
                End If
            Catch oEx As Exception
                mLogIsActive = False
            End Try
        End Set
    End Property

    Public WriteOnly Property NameFile As String
        Set(ByVal value As String)
            mNameFile = value
        End Set
    End Property
End Class
