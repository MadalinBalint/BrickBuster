Imports System.Drawing.Drawing2D
Public Class Brick
    Public x, y As Integer
    Public w, h As Integer
    Public centerX, centerY As Single
    Public type As Integer
    Public brickColor As Pen
    Public position As Integer
    Public angle As Single

    Public Sub New(xx As Integer, yy As Integer, ww As Integer, hh As Integer, p As Pen, pos As Integer)
        w = ww
        h = hh
        x = xx
        y = yy
        brickColor = p
        position = pos
        centerX = x + w / 2.0
        centerY = y + h / 2.0

        Dim dx = (x + w) - centerX
        Dim dy = -(y - centerY)
        angle = Math.Atan2(dy, dx) * (180.0 / Math.PI)
        If angle < 0.0 Then angle = -angle
        'Console.WriteLine("Unghi caramida = " & angle)
    End Sub

    Public Sub SetType(t As Integer)
        type = t
    End Sub

    Public Sub SetColor(c As Pen)
        brickColor = c
    End Sub

    Public Sub Draw(e As PaintEventArgs)
        ' Daca e o caramida goala nu o desenam
        If type = Wall.TipuriCaramizi.EMPTY Then Return

        Dim brush As New SolidBrush(brickColor.Color)
        Dim linGrBrush As New LinearGradientBrush(New Point(x, y), New Point(x + w, y + h), Color.WhiteSmoke, brickColor.Color)
        linGrBrush.SetSigmaBellShape(1)
        Dim pen As New Pen(linGrBrush)


        e.Graphics.FillRectangle(linGrBrush, x, y, w, h)
        e.Graphics.DrawRectangle(Pens.Black, x, y, w, h)
    End Sub
End Class