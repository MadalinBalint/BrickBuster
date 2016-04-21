Public Class Brick
    Public x, y As Integer
    Public w, h As Integer
    Public type As Integer
    Public color As Pen
    Public position As Integer
    Public Sub New(xx As Integer, yy As Integer, ww As Integer, hh As Integer, p As Pen, pos As Integer)
        w = ww
        h = hh
        x = xx
        y = yy
        color = p
        position = pos
    End Sub

    Public Sub SetType(t As Integer)
        type = t
    End Sub

    Public Sub SetColor(c As Pen)
        color = c
    End Sub

    Public Sub Draw(e As PaintEventArgs)
        ' Daca e o caramida goala nu o desenam
        If type = Wall.TipuriCaramizi.EMPTY Then Return

        Dim brush As New SolidBrush(color.Color)

        e.Graphics.FillRectangle(brush, x, y, w, h)
        e.Graphics.DrawRectangle(Pens.Black, x, y, w, h)
    End Sub
End Class