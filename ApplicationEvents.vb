Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            If e.IsNetworkAvailable = True Then
                If Form1.AutoDact = True Then
                    Form1.AutoDact = False
                    Form1.ActivateNetwatch(True)
                End If

                If Form1.IP <> B3.GetIPAddress Then
                    Form1.IP = GetIPAddress()
                    B3.UpdateCountry()
                    If Form1.bg_UpdateChecker.IsBusy = False Then
                        Form1.bg_UpdateChecker.RunWorkerAsync()
                    End If
                    If Form1.bg_RemoteB3.IsBusy = False Then
                        Form1.bg_RemoteB3.RunWorkerAsync()
                    End If
                End If
            Else
                If Form1.AutoDact = False And Form1.isDact = False Then
                    Form1.AutoDact = True
                    Form1.DeactivareNetwatch(True)
                End If

            End If
        End Sub
    End Class


End Namespace

