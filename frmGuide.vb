Public Class frmGuide
    Dim Page As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Page < 7 Then
            Page = Page + 1
            Navigator()
        End If


    End Sub

    Sub Navigator()
        Label3.Text = Page

        Select Case Page
            Case 1
                Button2.Enabled = False
                Button1.Enabled = True
                Button1.Text = "Next >"
                Panel1.Controls.Clear()
                Panel1.Controls.Add(ucPanel1.GetInstance())
            Case 2
                Button2.Enabled = True
                Button1.Text = "Next >"
                Button1.Enabled = True
                Panel1.Controls.Clear()
                Panel1.Controls.Add(ucPanel2.GetInstance())
            Case 3
                Button2.Enabled = True
                Button1.Enabled = True
                Button1.Text = "Next >"
                Panel1.Controls.Clear()
                Panel1.Controls.Add(ucPanel3.GetInstance())
            Case 4
                Button2.Enabled = True
                Button1.Enabled = True
                Button1.Text = "Next >"
                Panel1.Controls.Clear()
                Panel1.Controls.Add(ucPanel4.GetInstance())
            Case 5
                Button2.Enabled = True
                Button1.Enabled = True
                Button1.Text = "Next >"
                Panel1.Controls.Clear()
                Panel1.Controls.Add(ucPanel5.GetInstance())
            Case 6
                Button2.Enabled = True
                Button1.Enabled = True
                Button1.Text = "Finish"
                Panel1.Controls.Clear()
                Panel1.Controls.Add(ucPanel6.GetInstance())
            Case 7
                Form1.NotifyIcon1.Visible = False
                Application.Restart()
        End Select

    End Sub

    Private Sub frmGuide_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Controls.Clear()
        Panel1.Controls.Add(ucPanel1.GetInstance())
        Page = 1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Page > 0 Then
            Page = Page - 1
            Navigator()
        End If
    End Sub

  
End Class