Public Class frmEULA

    Private Sub frmEULA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.Rtf = My.Resources.doc_EULA
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("Unfortunately you cannot use this software without agreeing with the Terms of Use. Application will now close.", MsgBoxStyle.Information)
        Form1.NotifyIcon1.Visible = False
        End
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MyReg.SetDefaultValues()
        Me.Close()
    End Sub
End Class