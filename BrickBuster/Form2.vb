Imports System.ComponentModel
Public Class Form2
    ' Incarcam tabela cu scorurile stocate in fisierul de configuratie si le sortam
    Public Sub TabelaScoruri()
        Dim n = Form1.settings.scoreboard.Count
        Dim s As String
        Dim i As Integer
        Dim separator() As String = {","}
        Dim rezultat() As String

        ' Stergem toate intrarile din tabela de scoruri
        tabelScoruri.Rows.Clear()

        ' Scriem tabela cu scoruri
        If n > 0 Then
            For i = 0 To n - 1
                s = Form1.settings.scoreboard(i)

                rezultat = s.Split(separator, StringSplitOptions.RemoveEmptyEntries)

                If rezultat.Length = 3 Then
                    tabelScoruri.Rows.Add(rezultat(0), CInt(rezultat(1)), rezultat(2))
                End If
            Next
        End If

        ' Sortam tabelul dupa scorul jucatorului 
        Dim newColumn = tabelScoruri.Columns(1)
        tabelScoruri.Sort(newColumn, ListSortDirection.Descending)
    End Sub

    ' Butonul Ok
    Private Sub btnScoreboardOk_Click(sender As Object, e As EventArgs) Handles btnScoreboardOk.Click
        Me.Close()
    End Sub

    ' Afisam tabela de scoruri la pornirea form-ului
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabelaScoruri()
    End Sub
End Class