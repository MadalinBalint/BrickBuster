Public Class Ball
    ' Pozitia mingii fata de caramida
    Public Enum PozitieMinge As Integer
        SUS
        JOS
        STANGA
        DREAPTA
        COLT_STANGA_SUS
        COLT_DREAPTA_SUS
        COLT_STANGA_JOS
        COLT_DREAPTA_JOS
        INTERIOR
    End Enum

    Public x, y As Integer ' Pozitia bilei din coltul stanga sus
    Public radius As Integer ' Raza bilei
    Public culoare As Pen ' Culoarea bilei
    Public mx, my, r As Single

    Public speed As Double ' Factorul de viteza al bilei (x1.0)
    Public angle As Double ' Unghiul sub care se misca bila (radiani)
    Public width, height As Integer ' Dimensiunea ferestrei in interiorul careia se misca bila
    Public isMoving As Boolean = False ' Atunci cand se afla in miscare
    Public stopped As Boolean = False ' Atunci cand atinge partea de jos a ecranului

    ' Constructorul pentru clasa Ball
    Public Sub New(rr As Integer, fw As Integer, fh As Integer, p As Pen)
        radius = rr
        culoare = p
        angle = Math.PI / 4.0
        speed = 3.0
        width = fw
        height = fh
        r = rr / 2.0 ' Valoarea adevarata
    End Sub

    ' Setarea pozitiei initiale a bilei
    Public Sub SetPosition(xx As Integer, yy As Integer)
        x = xx
        y = yy
        mx = x + r
        my = y + r
    End Sub

    ' Misca bila conform unghiului si vitezei
    Public Sub Move()
        x += Math.Sin(angle) * speed
        y -= Math.Cos(angle) * speed

        mx = x + r
        my = y + r
    End Sub

    ' Pozitia mingii fata de o caramida
    ' Lasam cate +/- 5 grade de libertate fata de jumatatile de diagonala, pentru cazul in care lovim coltul caramizii
    Public Function RelativePosition(caramida As Brick) As PozitieMinge
        'Console.WriteLine("y=" & caramida.y & ", h=" & caramida.h)
        'Console.WriteLine("minge y=" & y)
        Dim dx = mx - caramida.mx
        Dim dy = -(my - caramida.my)
        Dim angle = (Math.Atan2(dy, dx)) * (180.0 / Math.PI)
        If angle < 0.0 Then angle = -angle
        Console.WriteLine("Unghi = " & angle)

        If angle >= caramida.angle + 5 And angle <= 180 - caramida.angle - 5 Then Return PozitieMinge.SUS
        If angle >= 180 - caramida.angle + 5 And angle <= 180 + caramida.angle - 5 Then Return PozitieMinge.STANGA
        If angle >= 180 + caramida.angle + 5 And angle <= 360 - caramida.angle - 5 Then Return PozitieMinge.JOS
        If angle >= 360 - caramida.angle + 5 Or angle <= caramida.angle - 5 Then Return PozitieMinge.DREAPTA

        ' In caz ca lovim colturile
        'If angle >= caramida.angle + 5 And angle <= 180 - caramida.angle - 5 Then Return PozitieMinge.SUS

        Return PozitieMinge.INTERIOR
    End Function

    ' Reflecta bila atunci cand intalneste un obstacol
    Public Sub Bounce(paleta As Paddle, caramizi As List(Of Brick), perete As Wall)
        ' Reflexie caramizi
        Dim c = caramizi.Count
        Dim b As Brick
        Dim pos As PozitieMinge

        If c > 0 Then
            c = 1
            For i As Integer = 0 To c - 1
                b = caramizi(i)
                pos = RelativePosition(b)

                If pos = PozitieMinge.JOS Then
                    angle = Math.PI - angle
                    Console.WriteLine("Metoda 4 " & pos.ToString)
                ElseIf pos = PozitieMinge.SUS Then
                    angle = Math.PI - angle
                    Console.WriteLine("Metoda 3 " & pos.ToString)
                ElseIf pos = PozitieMinge.DREAPTA Then
                    angle = -angle
                    Console.WriteLine("Metoda 1 " & pos.ToString)
                ElseIf pos = PozitieMinge.STANGA Then
                    angle = -angle
                    Console.WriteLine("Metoda 2 " & pos.ToString)
                End If

                perete.HitBrick(b.position, 1)
                'Threading.Thread.Sleep(50)
            Next
        End If

        ' Reflexie paleta
        If y >= paleta.y - radius Then
            If x >= paleta.x And x <= paleta.x + paleta.w Then
                y = 2 * (paleta.y - radius) - y
                angle = Math.PI - angle

                ' Variem putin unghiul si in functie de pozitia mingii fata de centrul paletei cu 10 grade
                If x >= paleta.x And x <= paleta.x + paleta.w \ 2 - 10 Then
                    angle = angle - Math.PI / 18.0
                End If

                If x >= paleta.x + paleta.w \ 2 + 10 And x <= paleta.x + paleta.w Then
                    angle = angle + Math.PI / 18.0
                End If
            End If
        End If

        ' Reflexie perete
        If x >= width - radius Then
            x = 2 * (width - radius) - x
            angle = -angle
        ElseIf x <= 0 Then
            x = 0
            angle = -angle
        ElseIf y >= height - radius Then
            y = 2 * (height - radius) - y
            angle = Math.PI - angle
            stopped = True
        ElseIf y <= 0 Then
            y = 0
            angle = Math.PI - angle
        End If

        mx = x + r
        my = y + r
    End Sub

    ' Deseneaza bila pe ecran
    Sub Draw(e As PaintEventArgs)
        Dim brush As New SolidBrush(culoare.Color)

        e.Graphics.FillEllipse(brush, x, y, radius, radius)
        e.Graphics.DrawEllipse(Pens.DarkSlateGray, x, y, radius, radius)
    End Sub
End Class