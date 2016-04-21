Public Class Ball
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
        speed = 4.0
        width = fw
        height = fh
        r = rr / 2.0 ' Valoarea adevarata
    End Sub

    ' Setarea pozitiei initiale a bilei
    Public Sub SetPosition(xx As Integer, yy As Integer)
        x = xx
        y = yy
        mx = x + radius / 2
        my = y + radius / 2
    End Sub

    ' Misca bila conform unghiului si vitezei
    Public Sub Move()
        x += Math.Sin(angle) * speed
        y -= Math.Cos(angle) * speed

        mx = x + r
        my = y + r
    End Sub

    ' Reflecta bila atunci cand intalneste un obstacol
    Public Sub Bounce(paleta As Paddle)
        ' Reflexie paleta
        If y >= paleta.y - radius Then
            If x >= paleta.x And x <= paleta.x + paleta.w Then
                y = 2 * (paleta.y - radius) - y
                angle = Math.PI - angle
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