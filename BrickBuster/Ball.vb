Imports System.Drawing.Drawing2D
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
    Public mxx, myy, r As Single

    Public speed As Double ' Factorul de viteza al bilei (x1.0)
    Public angle As Double ' Unghiul sub care se misca bila (radiani)
    Public width, height As Integer ' Dimensiunea ferestrei in interiorul careia se misca bila
    Public isMoving As Boolean = False ' Atunci cand se afla in miscare
    Public stopped As Boolean = False ' Atunci cand atinge partea de jos a ecranului
    Public multiplier As Single ' Folosit in cazul POWERUP-urilor

    ' Constructorul pentru clasa Ball
    Public Sub New(rr As Integer, fw As Integer, fh As Integer, p As Pen)
        radius = rr
        culoare = p
        angle = Math.PI
        speed = 4.0
        width = fw
        height = fh
        multiplier = 1.0
        r = rr / 2.0 ' Valoarea adevarata
    End Sub

    ' Setarea pozitiei initiale a bilei
    Public Sub SetPosition(xx As Integer, yy As Integer)
        x = xx
        y = yy
        mxx = x + r * multiplier
        myy = y + r * multiplier
    End Sub

    ' Misca bila conform unghiului si vitezei
    Public Sub Move()
        x += Math.Sin(angle) * speed
        y -= Math.Cos(angle) * speed

        mxx = x + r * multiplier
        myy = y + r * multiplier
    End Sub

    Public Function BrickBallAngle(caramida As Brick) As Single
        Dim dx = mxx - caramida.mx
        Dim dy = -(myy - caramida.my)
        Dim angle = Math.Atan2(dy, dx) * (180.0 / Math.PI)
        If angle < 0.0 Then angle = -angle
        Console.WriteLine("Unghi = " & angle)

        Return angle
    End Function

    ' Pozitia mingii fata de o caramida
    ' Lasam cate +/- 5 grade de libertate fata de jumatatile de diagonala, pentru cazul in care lovim coltul caramizii
    Public Function RelativePosition(caramida As Brick) As PozitieMinge
        Dim angle = BrickBallAngle(caramida)

        If angle >= caramida.angle + 5 And angle <= 180 - caramida.angle - 5 Then Return PozitieMinge.SUS
        If angle >= 180 - caramida.angle + 5 And angle <= 180 + caramida.angle - 5 Then Return PozitieMinge.STANGA
        If angle >= 180 + caramida.angle + 5 And angle <= 360 - caramida.angle - 5 Then Return PozitieMinge.JOS
        If angle >= 360 - caramida.angle + 5 Or angle <= caramida.angle - 5 Then Return PozitieMinge.DREAPTA

        ' In caz ca lovim colturile
        If angle > caramida.angle - 5 And angle < caramida.angle + 5 Then Return PozitieMinge.COLT_DREAPTA_SUS
        If angle > 180 - caramida.angle - 5 And angle < 180 - caramida.angle + 5 Then Return PozitieMinge.COLT_STANGA_SUS
        If angle > 180 + caramida.angle - 5 And angle < 180 + caramida.angle + 5 Then Return PozitieMinge.COLT_STANGA_JOS
        If angle > 360 - caramida.angle - 5 And angle < 360 - caramida.angle + 5 Then Return PozitieMinge.COLT_DREAPTA_JOS

        Return PozitieMinge.INTERIOR
    End Function

    ' Reflecta bila atunci cand intalneste un obstacol
    Public Sub Bounce(paleta As Paddle, caramizi As List(Of Brick), perete As Wall)
        ' Reflexie caramizi
        Dim c = caramizi.Count
        Dim b As Brick
        Dim pos As PozitieMinge
        Dim reflectat As Boolean = False
        Dim a As Single

        If c > 0 Then
            For i As Integer = 0 To c - 1
                b = caramizi(i)
                pos = RelativePosition(b)
                a = BrickBallAngle(b)
                Console.WriteLine(b.position & "," & pos.ToString)
                If reflectat = False Then
                    If pos = PozitieMinge.JOS Then
                        angle = Math.PI - angle
                        reflectat = True
                        Console.WriteLine("Metoda 4 " & pos.ToString)
                    ElseIf pos = PozitieMinge.SUS Then
                        angle = Math.PI - angle
                        reflectat = True
                        Console.WriteLine("Metoda 3 " & pos.ToString)
                    ElseIf pos = PozitieMinge.DREAPTA Then
                        angle = -angle
                        reflectat = True
                        Console.WriteLine("Metoda 1 " & pos.ToString)
                    ElseIf pos = PozitieMinge.STANGA Then
                        angle = -angle
                        reflectat = True
                        Console.WriteLine("Metoda 2 " & pos.ToString)
                    Else
                        angle = a * 2.0 * Math.PI / 180.0 - angle

                        reflectat = True
                        Console.WriteLine("Fara metoda = " & pos.ToString)
                    End If
                End If

                perete.HitBrick(b.position, 1)
                My.Computer.Audio.Play(My.Resources.Boing, AudioPlayMode.Background)
            Next
            Return
        End If

        ' Reflexie paleta
        If perete.Intersection(Me, paleta.caramida, New PointF(paleta.caramida.mx, paleta.caramida.my)) Then
            y = 2 * (paleta.y - radius * multiplier) - y
            a = BrickBallAngle(paleta.caramida)
            'angle = Math.PI - angle
            angle = -angle + Math.PI + (Math.PI / 2.0 - a * Math.PI / 180.0) / 4.0

            My.Computer.Audio.Play(My.Resources.Ricochet, AudioPlayMode.Background)
            Return
        End If

        ' Reflexie perete
        If x >= width - radius * multiplier Then
            x = 2 * (width - radius * multiplier) - x
            angle = -angle
            My.Computer.Audio.Play(My.Resources.Glass, AudioPlayMode.Background)
        ElseIf x <= 0 Then
            x = 0
            angle = -angle
            My.Computer.Audio.Play(My.Resources.Glass, AudioPlayMode.Background)
        ElseIf y >= height - radius * multiplier Then
            y = 2 * (height - radius * multiplier) - y
            angle = Math.PI - angle
            My.Computer.Audio.Play(My.Resources.Fanfare, AudioPlayMode.Background)
            stopped = True
            Return
        ElseIf y <= 0 Then
            y = 0
            angle = Math.PI - angle
            My.Computer.Audio.Play(My.Resources.Glass, AudioPlayMode.Background)
        End If

    End Sub

    ' Deseneaza bila pe ecran
    Sub Draw(e As PaintEventArgs)
        Dim brush As New SolidBrush(culoare.Color)

        e.Graphics.FillEllipse(brush, x, y, radius * multiplier, radius * multiplier)
        e.Graphics.DrawEllipse(Pens.DarkSlateGray, x, y, radius * multiplier, radius * multiplier)
    End Sub
End Class