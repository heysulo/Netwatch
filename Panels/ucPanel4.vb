Public Class ucPanel4
    Private Shared panelInstance As ucPanel4


    Public Shared Function GetInstance() As ucPanel4
        If (panelInstance Is Nothing) Then
            panelInstance = New ucPanel4
        End If
        Return panelInstance
    End Function
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            MyReg.SetValue("MINIG", "1")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            MyReg.SetValue("MINIG", "0")
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        RadioButton2.Checked = True
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        RadioButton1.Checked = True
    End Sub

    Private Sub ucPanel4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MyReg.GetValue("MINIG", "1") = "1" Then
            RadioButton2.Checked = True
        Else
            RadioButton1.Checked = True
        End If
    End Sub
End Class
