Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Xml


Public Class ProjectInstaller

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        Me.ServiceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.ServiceProcessInstaller1.Username = Nothing
        Me.ServiceProcessInstaller1.Password = Nothing
        'Add initialization code after the call to InitializeComponent


    End Sub
    Protected Overrides Sub OnAfterInstall(savedState As IDictionary)
        MyBase.OnAfterInstall(savedState)

        'The following code starts the services after it is installed.
        Using serviceController As New System.ServiceProcess.ServiceController(ServiceInstaller1.ServiceName)
            serviceController.Start()
        End Using
    End Sub

End Class
