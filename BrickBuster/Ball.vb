Public Class Ball
    Public x, y As Integer ' Pozitia bilei
    Public radius As Integer ' Raza bilei
    Public culoare As Pen ' Culoarea bilei

    Public speed As Double ' Factorul de viteza al bilei (x1.0)
    Public angle As Double ' Unghiul sub care se misca bila (radiani)
    Public width, height As Integer ' Dimensiunea ferestrei in interiorul careia se misca bila
    Public isMoving As Boolean = False ' Atunci cand se afla in miscare
    Public stopped As Boolean = False ' Atunci cand atinge partea de jos a ecranului

    ' Constructorul pentru clasa Ball
    Public Sub New(r As Integer, fw As Integer, fh As Integer, p As Pen)
        radius = r
        culoare = p
        angle = Math.PI / 4
        speed = 4.0
        width = fw
        height = fh
    End Sub

    ' Setarea pozitiei initiale a bilei
    Public Sub SetPosition(xx As Integer, yy As Integer)
        x = xx
        y = yy
    End Sub

    ' Misca bila conform unghiului si vitezei
    Public Sub Move()
        x += Math.Sin(angle) * speed
        y -= Math.Cos(angle) * speed
    End Sub

    ' Reflecta bila atunci cand intalneste un obstacol
    Public Sub Bounce()
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
    End Sub

    ' Deseneaza bila pe ecran
    Sub Draw(e As PaintEventArgs)
        Dim brush As New SolidBrush(culoare.Color)
        'Dim gray As New SolidBrush(Color.LightGray)

        ' Umbra mingii
        'e.Graphics.FillEllipse(gray, x + 3, y + 2 + 5, radius + 2, radius - 5)

        ' Mingea propriu-zisa
        e.Graphics.FillEllipse(brush, x, y, radius, radius)
        e.Graphics.DrawEllipse(Pens.DarkSlateGray, x, y, radius, radius)
    End Sub
End Class