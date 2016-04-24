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

    ' Pozitia mingii fata de o caramida pe verticala
    Public Function RelativeVertPos(caramida As Brick) As PozitieMinge
        If caramida.y <= y Then Return PozitieMinge.JOS
        If caramida.y + caramida.h >= y Then Return PozitieMinge.SUS
        Console.WriteLine("y=" & caramida.y & ", h=" & caramida.h)
        Console.WriteLine("minge y=" & y)
    End Function

    ' Pozitia mingii fata de o caramida pe orizontala
    Public Function RelativeHorizPos(caramida As Brick) As PozitieMinge
        If caramida.x <= x Then Return PozitieMinge.DREAPTA
        If caramida.x + caramida.w >= x Then Return PozitieMinge.STANGA
        Console.WriteLine("x=" & caramida.x & ", w=" & caramida.w)
        Console.WriteLine("minge x=" & x)
    End Function

    ' Reflecta bila atunci cand intalneste un obstacol
    Public Sub Bounce(paleta As Paddle, caramizi As List(Of Brick), perete As Wall)
        ' Reflexie caramizi
        Dim c = caramizi.Count
        Dim b As Brick
        Dim vpos, hpos As PozitieMinge

        If c > 0 Then
            c = 1
            For i As Integer = 0 To c - 1
                b = caramizi(i)
                vpos = RelativeVertPos(b)
                hpos = RelativeHorizPos(b)

                If y <= b.y + b.h And vpos = PozitieMinge.JOS Then
                    y = b.y + b.h
                    angle = Math.PI - angle
                    Console.WriteLine("Metoda 4")
                ElseIf y >= b.y - radius And vpos = PozitieMinge.SUS Then
                    y = 2 * (b.y - radius) - y
                    angle = Math.PI - angle
                    Console.WriteLine("Metoda 3")
                ElseIf x >= b.x - radius And hpos = PozitieMinge.DREAPTA Then
                    x = 2 * (b.x - radius) - x
                    angle = -angle
                    Console.WriteLine("Metoda 1")
                ElseIf x <= b.x + b.w And hpos = PozitieMinge.STANGA Then
                    x = b.x + b.w
                    angle = -angle
                    Console.WriteLine("Metoda 2")
                End If

                perete.HitBrick(b.position, 1)
                Threading.Thread.Sleep(50)

            Next
        End If

        ' Reflexie paleta
        If y >= paleta.y - radius Then
            If x >= paleta.x And x <= paleta.x + paleta.w Then
                y = 2 * (paleta.y - radius) - y
                angle = Math.PI - angle

                ' Variem putin unghiul si in functie de pozitia mingii fata de centrul paletei cu 10 grade
                If x >= paleta.x And x <= paleta.x + paleta.w \ 2 - 15 Then
                    angle = angle - Math.PI / 18.0
                End If

                If x >= paleta.x + paleta.w \ 2 + 15 And x <= paleta.x + paleta.w Then
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