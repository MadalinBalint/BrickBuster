Public Class Paddle
    Public x, y As Integer
    Public w, h As Integer
    Public color As Pen
    Public formh, formw As Integer

    Public Sub New(ww As Integer, hh As Integer, fw As Integer, fh As Integer, p As Pen)
        w = ww
        h = hh
        formw = fw
        formh = fh
        color = p
        x = (formw - w) / 2
        y = formh - h - 40 - 10
    End Sub

    Public Sub Draw(e As PaintEventArgs)
        Dim brush As New SolidBrush(color.Color)

        e.Graphics.FillRectangle(brush, x, y, w, h)
        e.Graphics.DrawRectangle(Pens.Black, x, y, w, h)
    End Sub

    Public Sub Move(xx As Integer, yy As Integer)
        x += xx
        y += yy

        ' Verficam daca paleta noastra nu iese din ecranul jocului
        If x < 0 Then x = 0
        If y < 0 Then y = 0
        If x >= formw - w - 15 Then x = formw - w - 15
        If y >= formh Then y = formh - h
    End Sub
End Class