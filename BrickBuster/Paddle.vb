Public Class Paddle
    Public x, y As Integer
    Public w, h As Integer
    Public paddleColor As Pen
    Public clientHeight, clientWidth As Integer
    Public vSpace As Integer = 5 ' Spatiul pe verticala
    Public isMoving As Boolean = True
    Public caramida As Brick
    Public sizeMultiplier As Single ' Folosit in cazul POWERUP-urilor
    Public isVisible As Boolean = True ' Pt POWERUP-ul 'Paddle Destroyer'
    Public Sub New(ww As Integer, hh As Integer, fw As Integer, fh As Integer, p As Pen)
        w = ww
        h = hh
        clientWidth = fw
        clientHeight = fh
        paddleColor = p
        sizeMultiplier = 1.0

        ' Centram paleta noastra si o punem cu 5 pixeli mai sus decat marginea de jos a ferestrei 
        x = (clientWidth - w * sizeMultiplier) / 2.0
        y = clientHeight - h - vSpace

        ' 'Caramida' corespunzatoare paletei noastre pe care o folosim la detectia coliziunii cu mingea
        caramida = New Brick(x, y, w * sizeMultiplier, h, p, 0)
    End Sub

    Public Sub Draw(e As PaintEventArgs)
        If isVisible = False Then Return
        Dim brush As New SolidBrush(paddleColor.Color)

        e.Graphics.FillRectangle(brush, x, y, w * sizeMultiplier, h)
        e.Graphics.DrawRectangle(Pens.Black, x, y, w * sizeMultiplier, h)
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
        If x >= clientWidth - w * sizeMultiplier Then
            x = clientWidth - w * sizeMultiplier
            isMoving = False
        End If
        If y >= clientHeight Then
            y = clientHeight - h
            isMoving = False
        End If

        caramida = New Brick(x, y, w * sizeMultiplier, h, paddleColor, 0)
    End Sub
End Class