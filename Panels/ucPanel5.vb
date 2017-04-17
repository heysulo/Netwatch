Imports System.Text
Imports System.Net
Imports System.IO

Public Class ucPanel5
    Private Shared panelInstance As ucPanel5

    Public Shared Function GetInstance() As ucPanel5
        If (panelInstance Is Nothing) Then
            panelInstance = New ucPanel5
        End If
        Return panelInstance
    End Function

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Process.Start("https://www.internetvas.slt.lk/SLTVasPortal-war/register/register.jsp")
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        MsgBox(Label4.Text, MsgBoxStyle.Information)
    End Sub

    Private Sub ucPanel5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Username As String = MyReg.GetValue("JUN", Nothing)
        Dim Password As String = MyReg.GetValue("JPW", Nothing)
        If MyReg.GetValue("SLT", "0") = "1" Then
            CheckBox7.Checked = True
        Else
            CheckBox7.Checked = False
        End If
        If Username <> Nothing Then
            txtUserName.Text = TextDecrypt(Username)
        End If
        If Password <> Nothing Then
            txtPassword.Text = TextDecrypt(Password)
        End If


    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If isInternetAvailable(True) = False Then
            MsgBox("I cannot reach the SLT website right now. Maybe you are not connected to the internet or the SLT web site is temporarily unavailable. Please go to settings and try again later", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim CookieJar As New CookieContainer
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes("j_username=" & txtUserName.Text & "&j_password=" & B3.HtMLize(txtPassword.Text))
        Dim request As HttpWebRequest = WebRequest.Create("https://www.internetvas.slt.lk/SLTVasPortal-war/login/j_security_check")
        request.Method = "POST"
        request.AllowAutoRedirect = True
        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        request.ContentLength = byteArray.Length
        request.KeepAlive = True
        request.ContentType = "application/x-www-form-urlencoded"
        request.Host = "www.internetvas.slt.lk"
        request.Referer = "https://www.internetvas.slt.lk/SLTVasPortal-war/login/login.jsp"
        request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.3) Gecko/20100401 Firefox/4.0 (.NET CLR 3.5.30729)"
        request.CookieContainer = CookieJar
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As HttpWebResponse = request.GetResponse()
        CookieJar.Add(response.Cookies)
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        reader.Close()
        dataStream.Close()
        response.Close()

        Dim request2 As HttpWebRequest = DirectCast(WebRequest.Create("https://www.internetvas.slt.lk/SLTVasPortal-war/application/GetProfile"), HttpWebRequest)
        request2.CookieContainer = CookieJar
        Dim response2 As HttpWebResponse = DirectCast(request2.GetResponse(), HttpWebResponse)
        Dim reader2 As New StreamReader(response2.GetResponseStream())
        Dim theusercp2 As String = reader2.ReadToEnd
        If theusercp2.StartsWith("{" & Chr(34) & "downlink" & Chr(34) & ":") = True Then
            If CheckBox7.Checked = True Then
                Form1.SLTCheck = True
                MyReg.SetValue("SLT", "1")
            Else
                Form1.SLTCheck = False
                MyReg.SetValue("SLT", "0")
            End If
            MyReg.SetValue("PEAKET", Val(TextBox1.Text))
            MyReg.SetValue("TOTALET", Val(TextBox2.Text))
            MyReg.SetValue("JUN", TextEncrypt(txtUserName.Text))
            MyReg.SetValue("JPW", TextEncrypt(txtPassword.Text))
            MsgBox("SLT Data usage settings saved!", MsgBoxStyle.Information)
        Else
            MsgBox("Login credentials appears to be invalid!", MsgBoxStyle.Exclamation)
        End If
    End Sub

   

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        SwitchCheck(CheckBox7)
    End Sub

    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = True Then
            Check(PictureBox3)
        Else
            UnCheck(PictureBox3)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = Math.Round(Val(TextBox1.Text))
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox2.Text = Math.Round(Val(TextBox2.Text))
    End Sub
End Class
