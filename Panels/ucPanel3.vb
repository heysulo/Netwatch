Public Class ucPanel3
    Private Shared panelInstance As ucPanel3


    Public Shared Function GetInstance() As ucPanel3
        If (panelInstance Is Nothing) Then
            panelInstance = New ucPanel3
        End If
        Return panelInstance
    End Function
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        MyReg.SetValue("VBLIMIT", NumericUpDown2.Value)
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            MyReg.SetValue("LIMITED", "1")
            Check(PictureBox2)
        Else
            MyReg.SetValue("LIMITED", "0")
            UnCheck(PictureBox2)
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        SwitchCheck(CheckBox2)
    End Sub

    Private Sub ucPanel3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Val(GetValue("LIMITED", "0")) = 1 Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
        NumericUpDown2.Value = Val(GetValue("VBLIMIT", "1"))
    End Sub
End Class
