'************************************************
'***************** COLLÈGE ABC ******************
'*** PROGRAMME PERMETTANT DE FAIRE LA GESTION DES
'*** PROGRAMMES ET DES ÉTUDIANTS EN UTILISANT LA
'*** BASE DE DONNÉES EXISTANTE DU COLLÈGE
'***
'************************************************
'*** CETTE PROGRAMMATION CI-DESSOUS EST DÉDIÉE À
'*** LA FENÊTRE PRINCIPALE LORS DE L'OUVERTURE DU
'*** PROGRAMME ET À LA GESTION DES FENÊTRES ENFANTS
'************************************************
'*** FAIT PAR:      Maryève Couture
'***                Justin Allard
'*** DATE:          2023-04-02
'*** RÉVISÉ PAR:
'*** DATE RÉVISION:
'************************************************

Public Class frmMain

    Private Sub mnuProgramme_Click(sender As Object, e As EventArgs) Handles mnuProgramme.Click, mnuProgramme.Click
        Dim gestionProgramme As frmGestionProgramme = FenetreEnfant(Of frmGestionProgramme)()
        If gestionProgramme Is Nothing Then
            gestionProgramme = New frmGestionProgramme
            gestionProgramme.MdiParent = Me
            gestionProgramme.Show()
        Else
            gestionProgramme.Focus()
        End If
    End Sub

    Private Sub mnuEtudiants_Click(sender As Object, e As EventArgs) Handles mnuEtudiants.Click
        Dim gestionEtudiants As frmGestionEtudiants = FenetreEnfant(Of frmGestionEtudiants)()
        If gestionEtudiants Is Nothing Then
            gestionEtudiants = New frmGestionEtudiants
            gestionEtudiants.MdiParent = Me
            gestionEtudiants.Show()
        Else
            gestionEtudiants.Focus()
        End If
    End Sub

    Private Sub mnuListeProgramme_Click(sender As Object, e As EventArgs) Handles mnuListeProgramme.Click
        Dim listeProgramme As frmListeDesProgrammes = FenetreEnfant(Of frmListeDesProgrammes)()
        If listeProgramme Is Nothing Then
            listeProgramme = New frmListeDesProgrammes
            listeProgramme.MdiParent = Me
            listeProgramme.Show()
        Else
            listeProgramme.Focus()
        End If
    End Sub

    Private Sub mnuListeEtudiants_Click(sender As Object, e As EventArgs) Handles mnuListeEtudiants.Click
        Dim listeEtudiants As frmListeDesEtudiants = FenetreEnfant(Of frmListeDesEtudiants)()
        If listeEtudiants Is Nothing Then
            listeEtudiants = New frmListeDesEtudiants
            listeEtudiants.MdiParent = Me
            listeEtudiants.Show()
        Else
            listeEtudiants.Focus()
        End If
    End Sub



    Private Sub mnuListeEtuParProg_Click(sender As Object, e As EventArgs) Handles mnuListeEtuParProg.Click
        Dim gestionEtudiants As frmListeEtuParProg = FenetreEnfant(Of frmListeEtuParProg)()
        If gestionEtudiants Is Nothing Then
            gestionEtudiants = New frmListeEtuParProg
            gestionEtudiants.MdiParent = Me
            gestionEtudiants.Show()
        Else
            gestionEtudiants.Focus()
        End If
    End Sub

    Private Function FenetreEnfant(Of F As Form)() As F
        For Each fEnfant As Form In Me.MdiChildren
            If TypeOf fEnfant Is F Then
                Return CType(fEnfant, F)
            End If
        Next
        Return Nothing
    End Function

    Private Sub mnuQuitter_Click(sender As Object, e As EventArgs) Handles mnuQuitter.Click
        Me.Close()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result As DialogResult = MessageBox.Show("Voulez-vous vraiment quitter l'application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

End Class
