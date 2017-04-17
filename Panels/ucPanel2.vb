Public Class ucPanel2
    Private Shared panelInstance As ucPanel2


    Public Shared Function GetInstance() As ucPanel2
        If (panelInstance Is Nothing) Then
            panelInstance = New ucPanel2
        End If
        Return panelInstance
    End Function
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            MyReg.SetValue("HIDE", "1")
            Check(PictureBox1)
        Else
            MyReg.SetValue("HIDE", "0")
            UnCheck(PictureBox1)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            MyReg.SetValue("EVADE", "1")
            Check(PictureBox2)
        Else
            MyReg.SetValue("EVADE", "0")
            UnCheck(PictureBox2)
        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        SwitchCheck(CheckBox2)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        SwitchCheck(CheckBox1)
    End Sub

    Private Sub ucPanel2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Val(GetValue("EVADE", "1")) = 1 Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        If Val(GetValue("HIDE", "1")) = 1 Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
    End Sub
End Class
