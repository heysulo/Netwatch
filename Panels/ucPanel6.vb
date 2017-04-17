Imports Microsoft.Win32
Public Class ucPanel6
    Private Shared panelInstance As ucPanel6


    Public Shared Function GetInstance() As ucPanel6
        If (panelInstance Is Nothing) Then
            panelInstance = New ucPanel6
        End If
        Return panelInstance
    End Function
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        On Error Resume Next
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
        If CheckBox2.Checked = True Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "Netwatch", Application.ExecutablePath)
            Check(PictureBox2)
        Else
            key.DeleteValue("Netwatch", False)
            UnCheck(PictureBox2)
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        SwitchCheck(CheckBox2)
    End Sub

    Private Sub ucPanel6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SV As String
        SV = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "Netwatch", "default")
        If SV = "default" Then
            CheckBox2.Checked = False
        ElseIf SV = Application.ExecutablePath Then
            CheckBox2.Checked = True
        Else
            If MsgBox("Looks like the startup entry is obseleted. Do you want to update it ?", vbYesNo + MsgBoxStyle.Exclamation, "Startup ?") = vbYes Then
                CheckBox2.Checked = True
            End If
        End If
    End Sub
End Class
