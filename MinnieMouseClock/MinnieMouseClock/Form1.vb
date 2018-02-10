Public Class Form1
    Private drag As Boolean
    Private mousex As Integer
    Private mousey As Integer

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If drag = True Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        drag = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TransparencyKey = Color.Red
        Me.BackColor = Color.Red
        Timer1.Interval = 1000
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Refresh()
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim g = e.Graphics
        Dim canvasWidth = PictureBox1.Width
        Dim canvasHeight = PictureBox1.Height
        Dim centerX = canvasWidth / 2
        Dim centerY = canvasHeight / 2
        Dim diameter = Math.Min(canvasWidth, canvasHeight) - 2
        Dim radius = diameter / 2
        Dim currentTime = Now.TimeOfDay
        Dim hourPen As New Pen(Color.HotPink, 8)
        Dim minutePen As New Pen(Color.Blue, 6)
        Dim secondPen As New Pen(Color.Purple, 4)

        g.TranslateTransform(centerX, centerY)

        ' Draw the hours hand
        Dim hourAngle = currentTime.TotalMinutes / 2
        g.RotateTransform(hourAngle)
        g.DrawLine(hourPen, Point.Empty, New Point(0, -(radius * 2 / 3)))

        ' Draw the minutes hand
        Dim minuteAngle = currentTime.Minutes * 6
        g.RotateTransform(minuteAngle)
        g.DrawLine(minutePen, Point.Empty, New Point(0, -(radius * 4 / 5)))

        ' Draw the seconds hand
        Dim secondAngle = currentTime.Seconds * 6
        g.RotateTransform(secondAngle)
        g.DrawLine(secondPen, Point.Empty, New Point(0, -(radius)))

    End Sub

    Private Sub PictureBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        Application.Exit()
    End Sub
End Class
