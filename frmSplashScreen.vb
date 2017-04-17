Public Class frmSplashScreen
    Public CS_DROPSHADOW As Int32 = &H20000

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams

        Get
            Dim parameters As CreateParams = MyBase.CreateParams
            parameters.ClassStyle += CS_DROPSHADOW
            Return parameters
        End Get

    End Property
  
    Private Sub frmSplashScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class