Public Class Paddle
    Public x, y As Integer
    Public w, h As Integer
    Public color As Pen
    Public formh, formw As Integer
    Public spacev As Integer = 5 ' Spatiul pe verticala
    Public isMoving As Boolean = True
    Public caramida As Brick
    Public multiplier As Single ' Folosit in cazul POWERUP-urilor
    Public visible As Boolean = True ' Pt POWERUP-ul 'Paddle Destroyer'
    Public Sub New(ww As Integer, hh As Integer, fw As Integer, fh As Integer, p As Pen)
        w = ww
        h = hh
        formw = fw
        formh = fh
        color = p
        multiplier = 1.0

        ' Centram paleta noastra si o punem cu 5 pixeli mai sus decat marginea de jos a ferestrei 
        x = (formw - w * multiplier) / 2.0
        y = formh - h - spacev

        ' 'Caramida' corespunzatoare paletei noastre pe care o folosim la detectia coliziunii cu mingea
        caramida = New Brick(x, y, w * multiplier, h, p, 0)
    End Sub

    Public Sub Draw(e As PaintEventArgs)
        If visible = False Then Return
        Dim brush As New SolidBrush(color.Color)

        e.Graphics.FillRectangle(brush, x, y, w * multiplier, h)
        e.Graphics.DrawRectangle(Pens.Black, x, y, w * multiplier, h)
    End Sub

    Public Sub Move(xx As Integer, yy As Integer)
        x += xx
        y += yy

        isMoving = True

        ' Verficam daca paleta noastra nu iese din ecranul jocului
        If x < 0 Then
            x = 0
            isMoving = False
        End If
        If y < 0 Then
            y = 0
            isMoving = False
        End If
        If x >= formw - w * multiplier Then
            x = formw - w * multiplier
            isMoving = False
        End If
        If y >= formh Then
            y = formh - h
            isMoving = False
        End If

        caramida = New Brick(x, y, w * multiplier, h, color, 0)
    End Sub
End Class