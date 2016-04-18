Public Class Ball
    Dim x, y As Integer
    Dim r As Integer
    Dim color As Pen

    Dim speed As Double
    Dim angle As Double

    Public Sub New(radius As Integer, p As Pen)
        r = radius
        color = p
        angle = Math.PI / 4
        speed = 5.0
    End Sub

    Public Sub SetPosition(xx As Integer, yy As Integer)
        x = xx
        y = yy
    End Sub

    Public Sub Move()
        x += Math.Sin(angle) * speed
        y -= Math.Cos(angle) * speed
    End Sub

    Sub Draw(e As PaintEventArgs)
        Dim brush As New SolidBrush(color.Color)

        e.Graphics.FillEllipse(brush, x, y, r, r)
        e.Graphics.DrawEllipse(Pens.DarkSlateGray, x, y, r, r)
    End Sub
End Class