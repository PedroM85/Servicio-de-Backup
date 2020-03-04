Imports System.Xml


Class WCProduction
    Public Server As String
    Public DataBase As String
    Public PathD As String
    Public Mode As String
    Public IntervalMinutes As Integer
    Public ScheduledTime As DateTime
    Public pathLOG As String
    Public Exp As String
    Public date2 As DateTime
    Public Zip As Boolean
    Public opZip As Integer

    Public Property mServer As String
        Get
            mServer = Server
        End Get
        Set(value As String)
            Server = value
        End Set
    End Property

    Public Property mDataBase As String
        Get
            mDataBase = DataBase
        End Get
        Set(value As String)
            DataBase = value
        End Set
    End Property

    Public Property mPathD As String
        Get
            mPathD = PathD
        End Get
        Set(value As String)
            PathD = value
        End Set
    End Property

    Public Property mMode As String
        Get
            mMode = Mode
        End Get
        Set(value As String)
            Mode = value
        End Set
    End Property

    Public Property mIntervalMinutes As Integer
        Get
            mIntervalMinutes = IntervalMinutes
        End Get
        Set(value As Integer)
            IntervalMinutes = value
        End Set
    End Property

    Public Property mScheduledTime As DateTime
        Get
            mScheduledTime = ScheduledTime
        End Get
        Set(value As DateTime)
            ScheduledTime = value
        End Set
    End Property

    Public Property mPathLog As String
        Get
            mPathLog = pathLOG
        End Get
        Set(value As String)
            pathLOG = value
        End Set
    End Property

    Public Property mExp As String
        Get
            mExp = Exp
        End Get
        Set(value As String)
            Exp = value
        End Set
    End Property

    Public Property mdate2 As DateTime
        Get
            mdate2 = date2
        End Get
        Set(value As DateTime)
            date2 = value
        End Set
    End Property

    Public Property mZip As Boolean
        Get
            mZip = Zip
        End Get
        Set(value As Boolean)
            Zip = value
        End Set
    End Property

    Public Property mopZip As Integer
        Get
            mopZip = opZip
        End Get
        Set(value As Integer)
            opZip = value
        End Set
    End Property
End Class

