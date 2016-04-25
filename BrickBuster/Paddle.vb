Public Class Paddle
    Public x, y As Integer
    Public w, h As Integer
    Public color As Pen
    Public formh, formw As Integer
    Public spacev As Integer = 5 ' Spatiul pe verticala
    Public isMoving As Boolean = True
    Public caramida As Brick

    Public Sub New(ww As Integer, hh As Integer, fw As Integer, fh As Integer, p As Pen)
        w = ww
        h = hh
        formw = fw
        formh = fh
        color = p

        ' Centram paleta noastra si o punem cu 5 pixeli mai sus decat marginea de jos a ferestrei 
        x = (formw - w) / 2.0
        y = formh - h - spacev

        ' 'Caramida' corespunzatoare paletei noastre pe care o folosim la detectia coliziunii cu mingea
        caramida = New Brick(x, y, w, h, p, 0)
    End Sub

    Public Sub Draw(e As PaintEventArgs)
        Dim brush As New SolidBrush(color.Color)

        e.Graphics.FillRectangle(brush, x, y, w, h)
        e.Graphics.DrawRectangle(Pens.Black, x, y, w, h)
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
        If x >= formw - w Then
            x = formw - w
            isMoving = False
        End If
        If y >= formh Then
            y = formh - h
            isMoving = False
        End If
    End Sub

    ' Returneaza unghiul sub care se reflecta mingea atunci cand loveste paleta
    ' Cand paleta e centrata mingea se reflecta sub 90 grade indiferent de ce limita sau FOV am setat
    Public Function GetAngle(limit As Integer, fov As Single) As Single
        Dim minAngle = (Math.PI - fov) / 2

        If x < limit Or x > formw - limit Then Return minAngle

        Return (fov - Math.PI / 2.0) * (1.0 - (x + w / 2.0) / (formw / 2.0))
    End Function
End Class