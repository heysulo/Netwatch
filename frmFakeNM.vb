Public Class frmFakeNM
#Region " Global Variables "
    Dim Point As New System.Drawing.Point()
    Dim X, Y As Integer
    Dim Done As Boolean
    Dim didMoved As Boolean
#End Region

#Region " GUI "


    Private Sub frmFakeNM_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        frmSettings.IncCord = Me.Location
        Done = True
        If frmPointer.Visible = True Then
            frmPointer.Close()
        End If
        Me.Close()
    End Sub

    Private Sub Form_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If e.Location.Y < 50 Then
            If e.Button = MouseButtons.Left Then
                Point = Control.MousePosition
                Point.X = Point.X - (X)
                Point.Y = Point.Y - (Y)
                If Point.Y < 10 Then
                    Point.Y = 0
                ElseIf Point.Y > (My.Computer.Screen.WorkingArea.Height - 32) Then
                    Point.Y = (My.Computer.Screen.WorkingArea.Height - 22)
                End If
                If didMoved = False Then
                    didMoved = True
                    Me.BackgroundImage = My.Resources.bg_fakeSAVE
                End If
                Me.Location = Point
            End If
        End If

    End Sub

    Private Sub Form_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
        If Y < 5 Then
            Y = 0
        End If
    End Sub

#End Region
    Private Sub frmFakeNM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showFake()
        Me.Height = 22
    End Sub

    Private Sub frmFakeNM_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Me.Text = Me.Location.ToString
        
    End Sub

    Private Sub frmFakeNM_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        showFake()
    End Sub

    Private Sub frmFakeNM_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        If frmPointer.Visible = True And frmPointer.Timer3.Enabled = False Then
            frmPointer.Timer1.Enabled = False
            frmPointer.Timer3.Enabled = True
        End If
    End Sub

    Private Sub showFake()
        Dim SLOC As Point
        Dim IMG As Bitmap
        If Done = True Then
            Exit Sub
        End If
        If frmPointer.Visible = True Then
            With frmPointer
                .Timer1.Enabled = False
                .Timer3.Enabled = False
                .Opacity = 1
                Exit Sub
            End With
        End If
        IMG = My.Resources.bg_arrow
        SLOC = Me.Location
        If (SLOC.Y + 325) > My.Computer.Screen.WorkingArea.Height Then
            SLOC.Y = SLOC.Y - 325
            IMG.RotateFlip(RotateFlipType.RotateNoneFlipY)
            frmPointer.Show()
            frmPointer.Location = SLOC
            frmPointer.BackgroundImage = IMG
            frmPointer.LOX = SLOC
            frmPointer.Timer4.Enabled = True
        Else

            SLOC.Y += 25
            frmPointer.Show()
            frmPointer.BackgroundImage = IMG
            Form1.Location = SLOC
            frmPointer.LOX = SLOC
            frmPointer.Timer4.Enabled = True
        End If
    End Sub
End Class