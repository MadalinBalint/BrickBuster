Public Class Paddle
    Public x, y As Integer ' Pozitia paletei
    Public w, h As Integer ' Dimensiunile paletei
    Public paddleColor As Pen ' Culoarea paletei
    Public clientHeight, clientWidth As Integer ' Dimensiunea ferestrei client
    Public vertSpace As Integer = 5 ' Spatiul pe verticala
    Public isMoving As Boolean = True ' Daca paleta se misca
    Public caramida As Brick
    Public sizeMultiplier As Single ' Folosit in cazul POWERUP-urilor
    Public isVisible As Boolean = True ' Pt POWERUP-ul 'Paddle Destroyer'

    ' Constructorul clasei Paddle
    Public Sub New(ww As Integer, hh As Integer, fw As Integer, fh As Integer, p As Pen)
        w = ww
        h = hh
        clientWidth = fw
        clientHeight = fh
        paddleColor = p
        sizeMultiplier = 1.0

        ' Centram paleta noastra si o punem cu 5 pixeli mai sus decat marginea de jos a ferestrei 
        x = (clientWidth - w * sizeMultiplier) / 2.0
        y = clientHeight - h - vertSpace

        ' 'Caramida' corespunzatoare paletei noastre pe care o folosim la detectia coliziunii cu mingea
        caramida = New Brick(x, y, w * sizeMultiplier, h, p, 0)
    End Sub

    ' Deseneaza paleta pe ecran
    Public Sub Draw(e As PaintEventArgs)
        If isVisible = False Then Return
        Dim brush As New SolidBrush(paddleColor.Color)

        e.Graphics.FillRectangle(brush, x, y, w * sizeMultiplier, h)
        e.Graphics.DrawRectangle(Pens.Black, x, y, w * sizeMultiplier, h)
    End Sub

    ' Miscam paleta pe ecran
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