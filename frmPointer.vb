Public Class frmPointer
    Dim X As Integer
    Public LOX As Point
    Dim UP As Boolean

    Private Sub frmPointer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Me.Close()
    End Sub
    Private Sub frmPointer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity < 1 Then
            If Me.Opacity + 0.05 < 1 Then
                Me.Opacity += 0.05
            Else
                Timer1.Enabled = False
            End If
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If Me.Opacity > 0 Then
            If Me.Opacity - 0.2 > 0 Then
                Me.Opacity -= 0.2
            Else
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub


    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        Dim NL As Point = LOX
        If UP = True Then
            If X < 20 Then
                X = X + 2
            Else
                UP = False
            End If
        Else
            If X > 0 Then
                X = X - 2
            Else
                UP = True
            End If
        End If
        NL.Y = NL.Y + X
        Me.Location = NL
    End Sub
End Class