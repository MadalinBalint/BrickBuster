Public Class Paddle
    Public x, y As Integer
    Public w, h As Integer
    Public color As Pen
    Public formh, formw As Integer
    Public spacev As Integer = 5 ' Spatiul pe verticala

    Public Sub New(ww As Integer, hh As Integer, fw As Integer, fh As Integer, p As Pen)
        w = ww
        h = hh
        formw = fw
        formh = fh
        color = p

        ' Centram paleta noastra si o punem cu 5 pixeli mai sus decat marginea de jos a ferestrei 
        x = (formw - w) / 2
        y = formh - h - spacev
    End Sub

    Public Sub Draw(e As PaintEventArgs)
        Dim brush As New SolidBrush(color.Color)

        e.Graphics.FillRectangle(brush, x, y, w, h)
        e.Graphics.DrawRectangle(Pens.WhiteSmoke, x, y, w, h)
    End Sub

    Public Sub Move(xx As Integer, yy As Integer)
        x += xx
        y += yy

        ' Verficam daca paleta noastra nu iese din ecranul jocului
        If x < 0 Then x = 0
        If y < 0 Then y = 0
        If x >= formw - w Then x = formw - w
        If y >= formh Then y = formh - h
    End Sub
End Class