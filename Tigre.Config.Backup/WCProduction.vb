Imports System.Xml


Class WCProduction
    Private _Server As String
    Private _DataBase As String
    Private _PathD As String
    Private _Mode As String
    Private _IntervalMinutes As Integer
    Private _ScheduledTime As DateTime
    Private _pathLOG As String
    Private _Exp As String
    Private _date2 As DateTime
    Private _Zip As Boolean
    Private _opZip As Integer


    Public Property Server As String
        Get
            Return _Server
        End Get
        Set(value As String)
            _Server = value
        End Set
    End Property

    Public Property DataBase As String
        Get
            Return _DataBase
        End Get
        Set(value As String)
            _DataBase = value
        End Set
    End Property

    Public Property PathD As String
        Get
            Return _PathD
        End Get
        Set(value As String)
            _PathD = value
        End Set
    End Property

    Public Property Mode As String
        Get
            Return _Mode
        End Get
        Set(value As String)
            _Mode = value
        End Set
    End Property

    Public Property IntervalMinutes As Integer
        Get
            Return _IntervalMinutes
        End Get
        Set(value As Integer)
            _IntervalMinutes = value
        End Set
    End Property

    Public Property ScheduledTime As DateTime
        Get
            Return _ScheduledTime
        End Get
        Set(value As DateTime)
            _ScheduledTime = value
        End Set
    End Property

    Public Property PathLog As String
        Get
            Return _pathLOG
        End Get
        Set(value As String)
            _pathLOG = value
        End Set
    End Property

    Public Property Exp As String
        Get
            Return _Exp
        End Get
        Set(value As String)
            _Exp = value
        End Set
    End Property

    Public Property date2 As DateTime
        Get
            Return _date2
        End Get
        Set(value As DateTime)
            _date2 = value
        End Set
    End Property

    Public Property Zip As Boolean
        Get
            Return _Zip
        End Get
        Set(value As Boolean)
            _Zip = value
        End Set
    End Property

    Public Property opZip As Integer
        Get
            Return _opZip
        End Get
        Set(value As Integer)
            _opZip = value
        End Set
    End Property



End Class

