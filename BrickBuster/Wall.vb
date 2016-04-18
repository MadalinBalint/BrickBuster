Public Class Wall
    ' Variatia tipurilor de caramizi
    ' 50% = caramizi normale
    ' 50% = restul de caramizi, din care:
    '     - 2% - caramizi lipsa
    '     - 9% - caramizi cu HP=3
    '     - 2% - caramizi cu HP infinit
    '     - 2% - viata
    '     - 1% - minge mica
    '     - 1% - minge mare
    '     - 1% - paleta mica
    '     - 1% - paleta mare

    ' Tipuri de caramizi
    ' 0 - caramida obisnuita - HP=1
    ' 1 - nu exista (gol)
    ' 2 - caramida cu HP=3
    ' 3 - caramida cu HP=infinit
    ' 4 - viata
    ' 5 - minge mica 0.5x
    ' 6 - minge mare 2x
    ' 7 - paleta mica 0.25x
    ' 8 - paleta mare 1.5x
    Public Enum TipuriCaramizi As Integer
        NORMAL
        EMPTY
        TRIPLE
        INFINITE
        LIFE
        SMALL_BALL
        BIG_BALL
        SMALL_PADDLE
        BIG_PADDLE
    End Enum

    Private Function random(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static staticRandomGenerator As New System.Random
        Return staticRandomGenerator.Next(Min, Max + 1)
    End Function

    Public HP() As Integer = {1, 0, 3, Integer.MaxValue, 1, 1, 1, 1, 1}
    Public Points() As Integer = {100, 0, 150, 10, 500, 400, 300, 700, 600}
    Public Colors() As Pen = {Pens.LightGray, Pens.White, Pens.CadetBlue, Pens.Black, Pens.Red, Pens.Aqua, Pens.Azure, Pens.PaleVioletRed, Pens.PapayaWhip}
    Public Percentage() As Integer = {50, 2, 9, 2, 2, 1, 1, 1, 1}

    Public col, row As Integer
    Public matrixPozitie(,) As Brick  ' pozitia fiecarei caramizi pe ecran
    Public matrixType(,) As Integer  ' tipul fiecarei caramizi
    Public matrixHP(,) As Integer  ' de cate ori trebuie lovita fiecare caramida ca sa fie distrusa

    ' Dimensiunea unei caramizi
    Public brickw, brickh As Integer
    ' Spatiile pe orizontala si pe verticala intre caramizi
    Public spaceh, spacev As Integer

    Public Sub New(x As Integer, y As Integer, bw As Integer, bh As Integer, sh As Integer, sv As Integer)
        col = x
        row = y
        ReDim matrixPozitie(col, row)
        ReDim matrixType(col, row)
        ReDim matrixHP(col, row)

        brickw = bw
        brickh = bh
        spaceh = sh
        spacev = sv

        For j As Integer = 0 To row - 1
            For i As Integer = 0 To col - 1
                matrixType(i, j) = TipuriCaramizi.NORMAL
                matrixHP(i, j) = HP(matrixType(i, j))
                matrixPozitie(i, j) = New Brick(spaceh * (i + 1) + brickw * i, spacev * (j + 1) + brickh * j, brickw, brickh, Colors(matrixType(i, j)))
            Next
        Next

        ' Setam in mod aleatoriu caramizile speciale
        Dim total = row * col
        Dim nr, rnd As Integer
        Dim erow, ecol As Integer

        ' i = tipul caramizii speciale
        For i As Integer = 1 To Percentage.Length - 1
            nr = Percentage(i) * total / 100
            nr += 1
            For j As Integer = 0 To nr - 1
                rnd = random(0, total - 1)
                erow = rnd \ col
                ecol = rnd Mod col

                ' Evitam sa setam din nou o caramida speciala
                Do While matrixType(ecol, erow) > TipuriCaramizi.NORMAL
                    rnd = random(0, total - 1)
                    erow = rnd \ col
                    ecol = rnd Mod col
                Loop

                ' Setam proprietatile caramizilor speciale
                matrixType(ecol, erow) = i
                matrixHP(ecol, erow) = HP(i)
                matrixPozitie(ecol, erow).SetColor(Colors(i))
                matrixPozitie(ecol, erow).SetType(i)
            Next
        Next
    End Sub

    Public Sub Draw(e As PaintEventArgs)
        For j As Integer = 0 To row - 1
            For i As Integer = 0 To col - 1
                matrixPozitie(i, j).Draw(e)
            Next
        Next
    End Sub
End Class