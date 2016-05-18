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
    Public ballColor As Pen ' Culoarea bilei
    Public centerX, centerY, r As Single ' Centrul bilei

    Public speed As Double ' Factorul de viteza al bilei (x1.0)
    Public angle As Double ' Unghiul sub care se misca bila (radiani)
    Public clientWidth, clientHeight As Integer ' Dimensiunea ferestrei in interiorul careia se misca bila
    Public isMoving As Boolean = False ' Atunci cand se afla in miscare
    Public isSticky As Boolean = False ' Pt POWERUP-ul 'Sticky Ball'
    Public isStopped As Boolean = False ' Atunci cand atinge partea de jos a ecranului
    Public sizeMultiplier As Single ' Folosit in cazul POWERUP-urilor
    Public speedMultiplier As Single ' Folosit in cazul POWERUP-urilor

    ' Constructorul pentru clasa Ball
    Public Sub New(rr As Integer, fw As Integer, fh As Integer, p As Pen)
        radius = rr
        ballColor = p
        angle = Math.PI / 2.0
        speed = 4.0
        clientWidth = fw
        clientHeight = fh
        sizeMultiplier = 1.0
        speedMultiplier = 1.0
        r = rr / 2.0 ' Valoarea adevarata
    End Sub

    ' Setarea pozitiei initiale a bilei
    Public Sub SetPosition(xx As Integer, yy As Integer)
        x = xx
        y = yy
        centerX = x + r * sizeMultiplier * Form1.settings.difficultySizeMultiplier
        centerY = y + r * sizeMultiplier * Form1.settings.difficultySizeMultiplier
    End Sub

    ' Misca bila conform unghiului si vitezei
    Public Sub Move()
        x += Math.Sin(angle) * speed * speedMultiplier * Form1.settings.difficultySpeedMultiplier
        y += Math.Cos(angle) * speed * speedMultiplier * Form1.settings.difficultySpeedMultiplier

        centerX = x + r * sizeMultiplier * Form1.settings.difficultySizeMultiplier
        centerY = y + r * sizeMultiplier * Form1.settings.difficultySizeMultiplier
    End Sub

    ' Calculeaza unghiul dintre centrul bilei si centrul caramizii in grade
    Public Function BrickBallAngle(caramida As Brick) As Single
        Dim dx = centerX - caramida.centerX
        Dim dy = -(centerY - caramida.centerY)
        Dim angle = Math.Atan2(dy, dx) * (180.0 / Math.PI)
        If angle < 0.0 Then angle = -angle

        Return angle
    End Function

    ' Pozitia mingii fata de o caramida
    Public Function RelativePosition(caramida As Brick) As PozitieMinge
        Dim angle = BrickBallAngle(caramida)

        If angle >= caramida.angle And angle <= 180 - caramida.angle Then Return PozitieMinge.SUS
        If angle > 180 - caramida.angle And angle <= 180 + caramida.angle Then Return PozitieMinge.STANGA
        If angle > 180 + caramida.angle And angle <= 360 - caramida.angle Then Return PozitieMinge.JOS
        If angle > 360 - caramida.angle Or angle < caramida.angle Then Return PozitieMinge.DREAPTA
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
                        Console.WriteLine("Metoda 4 " & pos.ToString & ", unghi=" & a)
                    ElseIf pos = PozitieMinge.SUS Then
                        angle = Math.PI - angle
                        reflectat = True
                        Console.WriteLine("Metoda 3 " & pos.ToString & ", unghi=" & a)
                    ElseIf pos = PozitieMinge.DREAPTA Then
                        angle = -angle
                        reflectat = True
                        Console.WriteLine("Metoda 1 " & pos.ToString & ", unghi=" & a)
                    ElseIf pos = PozitieMinge.STANGA Then
                        angle = -angle
                        reflectat = True
                        Console.WriteLine("Metoda 2 " & pos.ToString & ", unghi=" & a)
                    End If
                End If

                perete.HitBrick(b.position, 1)
            Next
            'Return
        End If

        ' Reflexie paleta
        If perete.Intersection(Me, paleta.caramida, New PointF(paleta.caramida.centerX, paleta.caramida.centerY)) And paleta.isVisible Then
            If isSticky = True Then
                isMoving = False
                Return
            End If

            y = 2 * (paleta.y - radius * sizeMultiplier * Form1.settings.difficultySizeMultiplier) - y
            angle = Math.PI - angle - Math.PI / 180.0 * (x - paleta.caramida.centerX)

            If Form1.settings.soundfx Then My.Computer.Audio.Play(My.Resources.Ricochet, AudioPlayMode.Background)
            Console.WriteLine("Reflexie paleta: unghi=" & angle * 180.0 / Math.PI)
        End If

        ' Reflexie perete
        If x >= clientWidth - radius * sizeMultiplier * Form1.settings.difficultySizeMultiplier Then
            x = 2 * (clientWidth - radius * sizeMultiplier * Form1.settings.difficultySizeMultiplier) - x
            angle = -angle
            Console.WriteLine("Reflexie perete: Metoda 4a")
            If Form1.settings.soundfx Then My.Computer.Audio.Play(My.Resources.Boing, AudioPlayMode.Background)
        ElseIf x <= 0 Then
            x = 0
            angle = -angle
            Console.WriteLine("Reflexie perete: Metoda 3a")
            If Form1.settings.soundfx Then My.Computer.Audio.Play(My.Resources.Boing, AudioPlayMode.Background)
        ElseIf y >= clientHeight - radius * sizeMultiplier * Form1.settings.difficultySizeMultiplier Then
            y = 2 * (clientHeight - radius * sizeMultiplier * Form1.settings.difficultySizeMultiplier) - y
            angle = Math.PI - angle
            Console.WriteLine("Reflexie perete: Metoda 2a")
            If Form1.settings.soundfx Then My.Computer.Audio.Play(My.Resources.Fanfare, AudioPlayMode.Background)
            isStopped = True
            Return
        ElseIf y <= perete.menuSpace Then
            y = perete.menuSpace
            angle = Math.PI - angle
            Console.WriteLine("Reflexie perete: Metoda 1a")
            If Form1.settings.soundfx Then My.Computer.Audio.Play(My.Resources.Boing, AudioPlayMode.Background)
        End If
    End Sub

    ' Deseneaza bila pe ecran
    Sub Draw(e As PaintEventArgs)
        Dim brush As New SolidBrush(ballColor.Color)

        e.Graphics.FillEllipse(brush, x, y, radius * sizeMultiplier * Form1.settings.difficultySizeMultiplier, radius * sizeMultiplier * Form1.settings.difficultySizeMultiplier)
        e.Graphics.DrawEllipse(Pens.DarkSlateGray, x, y, radius * sizeMultiplier * Form1.settings.difficultySizeMultiplier, radius * sizeMultiplier * Form1.settings.difficultySizeMultiplier)
    End Sub
End Class