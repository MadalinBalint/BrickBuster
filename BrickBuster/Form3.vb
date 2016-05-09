Public Class Form3
    ' Blocam setarile de dificultate daca jocul este inceput
    Dim difficultySettings As Boolean = True

    ' Butonul Ok
    Private Sub btnOptionsOk_Click(sender As Object, e As EventArgs) Handles btnOptionsOk.Click
        Dim dificultate As String

        ' In caz ca stergem numele jucatorului din greseala
        If tbPlayer.Text.Length > 0 Then Form1.settings.player = tbPlayer.Text
        If Form1.settings.player.Length <= 0 Then Form1.settings.player = "Player"

        If rbOn.Checked = True Then Form1.settings.soundfx = True Else Form1.settings.soundfx = False

        If rbHard.Checked = True Then
            dificultate = "Hard"
        ElseIf rbMedium.Checked = True Then
            dificultate = "Medium"
        Else
            dificultate = "Easy"
        End If

        Form1.settings.SetDifficulty(dificultate)

        If cbKeyboard.Checked = True Then Form1.settings.keyboard = True Else Form1.settings.keyboard = False
        If cbMouse.Checked = True Then Form1.settings.mouse = True Else Form1.settings.mouse = False

        Form1.settings.Save()

        Me.Close()
    End Sub

    ' Setam form-ul cu optiunile din fisierul de configuratie
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbPlayer.Text = Form1.settings.player

        If Form1.settings.soundfx Then rbOn.Checked = True Else rbOff.Checked = True

        ' Blocam setarile de dificultate daca jocul este inceput
        If Form1.isGameStarted Then difficultySettings = False Else difficultySettings = True
        rbEasy.Enabled = difficultySettings
        rbMedium.Enabled = difficultySettings
        rbHard.Enabled = difficultySettings

        If Form1.settings.easy Then
            rbEasy.Checked = True
        ElseIf Form1.settings.medium Then
            rbMedium.Checked = True
        ElseIf Form1.settings.hard Then
            rbHard.Checked = True
        End If

        cbKeyboard.Checked = Form1.settings.keyboard
        cbMouse.Checked = Form1.settings.mouse
    End Sub

    ' Checkbox Keyboard
    Private Sub cbKeyboard_CheckedChanged(sender As Object, e As EventArgs) Handles cbKeyboard.CheckedChanged
        ' Nu putem dezactiva ambele optiuni, trebuie sa avem macar un tip de input pt joc
        If cbKeyboard.Checked = False Then
            If cbMouse.Checked = False Then cbMouse.Checked = True
        End If
    End Sub

    ' Checkbox Mouse
    Private Sub cbMouse_CheckedChanged(sender As Object, e As EventArgs) Handles cbMouse.CheckedChanged
        ' Nu putem dezactiva ambele optiuni, trebuie sa avem macar un tip de input pt joc
        If cbMouse.Checked = False Then
            If cbKeyboard.Checked = False Then cbKeyboard.Checked = True
        End If
    End Sub
End Class