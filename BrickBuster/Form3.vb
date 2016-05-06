Public Class Form3
    Dim diff As Boolean = True
    Private Sub btnOptionsOk_Click(sender As Object, e As EventArgs) Handles btnOptionsOk.Click
        ' In caz ca stergem numele jucatorului din greseala
        If tbPlayer.Text.Length > 0 Then Form1.settings.player = tbPlayer.Text
        If Form1.settings.player.Length <= 0 Then Form1.settings.player = "Player"

        If rbOn.Checked = True Then Form1.settings.soundfx = True Else Form1.settings.soundfx = False

        If rbHard.Checked = True Then
            Form1.settings.hard = True
            Form1.settings.medium = False
            Form1.settings.easy = False
            Form1.settings.difficulty = "Hard"
        ElseIf rbMedium.Checked = True Then
            Form1.settings.hard = False
            Form1.settings.medium = True
            Form1.settings.easy = False
            Form1.settings.difficulty = "Medium"
        Else
            Form1.settings.hard = False
            Form1.settings.medium = False
            Form1.settings.easy = True
            Form1.settings.difficulty = "Easy"
        End If

        If cbKeyboard.Checked = True Then Form1.settings.keyboard = True Else Form1.settings.keyboard = False

        If cbMouse.Checked = True Then Form1.settings.mouse = True Else Form1.settings.mouse = False

        Form1.settings.Save()

        Me.Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbPlayer.Text = Form1.settings.player

        If Form1.settings.soundfx Then rbOn.Checked = True Else rbOff.Checked = True

        ' Blocam setarile de dificultate daca jocul este inceput
        If Form1.isGameStarted Then diff = False Else diff = True
        rbEasy.Enabled = diff
        rbMedium.Enabled = diff
        rbHard.Enabled = diff

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

    Private Sub cbKeyboard_CheckedChanged(sender As Object, e As EventArgs) Handles cbKeyboard.CheckedChanged
        ' Nu putem dezactiva ambele optiuni, trebuie sa avem macar un tip de input pt joc
        If cbKeyboard.Checked = False Then
            If cbMouse.Checked = False Then cbMouse.Checked = True
        End If
    End Sub

    Private Sub cbMouse_CheckedChanged(sender As Object, e As EventArgs) Handles cbMouse.CheckedChanged
        ' Nu putem dezactiva ambele optiuni, trebuie sa avem macar un tip de input pt joc
        If cbMouse.Checked = False Then
            If cbKeyboard.Checked = False Then cbKeyboard.Checked = True
        End If
    End Sub
End Class