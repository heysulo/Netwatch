
Public Class ucPanel1
    Private Shared panelInstance As ucPanel1


    Public Shared Function GetInstance() As ucPanel1
        If (panelInstance Is Nothing) Then
            panelInstance = New ucPanel1
        End If
        Return panelInstance
    End Function
End Class
