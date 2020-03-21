Imports System.IO

Public Class LogFile

    Dim mLogFile As FileStream
    Dim mLogStream As StreamWriter

    Private mPath As String
    Private mNameFile As String

    Dim mLogIsActive As Boolean = False

    Dim mPrintOriginOption As Boolean = True

    Const Init As String = "---------------------------------------"


    Public Sub New(ByVal Path As String, ByVal NameFile As String)
        Me.Path = Path
        Me.NameFile = NameFile

    End Sub
    Private Function GetOrigin() As String
        If Me.mPrintOriginOption = True Then
            Dim st As New Diagnostics.StackTrace(False)
            Dim sf As Diagnostics.StackFrame = st.GetFrame(2)
            Dim method As Reflection.MethodBase = sf.GetMethod

            Return String.Format("[{0}.{1}] ", method.DeclaringType.Name, method.Name)
        Else
            Return String.Empty
        End If

    End Function

    Public Sub LogEvent(ByVal Message As String)
        If mLogIsActive = True Then
            Message = GetDateTimeInfo() & GetOrigin() & Message
            ' CheckAndBackup()
            mLogStream.WriteLine(Message)
            mLogStream.Flush()
        End If
    End Sub

    Public Sub BeginLog()
        If mLogIsActive = True Then
            OpenLogFile()
            mLogStream.WriteLine(Init)
        End If
    End Sub

    Private Sub OpenLogFile()
        mLogFile = New FileStream(Path & mNameFile, FileMode.Append)
        mLogStream = New StreamWriter(mLogFile)
    End Sub
    Public Sub EndLog()
        If mLogIsActive = True Then
            'mLogStream.WriteLine(Separator)
            CloseLogFile()
        End If
    End Sub
    Private Sub CloseLogFile()
        mLogStream.Close()
        mLogFile.Close()
        mLogStream = Nothing
        mLogFile = Nothing
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
            mNameFile = value & ".log"
        End Set
    End Property

    Public Sub LogWrite(ByVal Message As String)

        Message = GetDateTimeInfo() & Message
        MsgBox(Message)


    End Sub


    Private Function GetDateTimeInfo() As String
        Dim ret As String

        ret = Date.Today.ToShortDateString + " " + Now.ToString("HH:mm:ss") + " "

        Return ret
    End Function
End Class
