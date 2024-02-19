'************************************************
'***************** COLLÈGE ABC ******************
'*** PROGRAMME PERMETTANT DE FAIRE LA GESTION DES
'*** PROGRAMMES ET DES ÉTUDIANTS EN UTILISANT LA
'*** BASE DE DONNÉES EXISTANTE DU COLLÈGE
'***
'************************************************
'*** CETTE PROGRAMMATION CI-DESSOUS EST DÉDIÉE À
'*** LA FENÊTRE ENFANT CONCERNANT LA LISTE DES
'*** ÉTUDIANTS
'*** 
'************************************************
'*** FAIT PAR:      Maryève Couture
'***                Justin Allard
'*** DATE:          2023-XX-XX
'*** RÉVISÉ PAR:
'*** DATE RÉVISION:
'************************************************

Imports System.Text.RegularExpressions
Imports Microsoft.Data.SqlClient


Public Class frmListeDesEtudiants

    ' DÉCLARATION DES VARIABLES
    Dim dataSet As New DataSet("tp_p44")
    Dim connexion As New SqlConnection(My.Settings.ConnectionString)

    Dim tblEtudiantsSqlCommand = New SqlCommand("SELECT * FROM T_Etudiants", connexion)
    Dim daTblEtudiants = New SqlDataAdapter(tblEtudiantsSqlCommand)
    Dim bindSrcEtudiants = New BindingSource()

    ' CHARGEMENT DU FORMULAIRE
    Private Sub frmListeDesEtudiants_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemplirDataGridViewEtudiants()
    End Sub

    ' REMPLISSAGE DU DATAGRIDVIEW AVEC LES DONNÉES DES ÉTUDIANTS
    Private Sub RemplirDataGridViewEtudiants()
        Try
            daTblEtudiants.Fill(dataSet, "T_Etudiants")

            dgvEtudiants.AutoGenerateColumns = True
            bindSrcEtudiants.DataSource = dataSet
            bindSrcEtudiants.DataMember = "T_Etudiants"
            dgvEtudiants.DataSource = bindSrcEtudiants

            Dim enteteColonne As String() = {"DA de l'étudiant", "Numéro du programme", "Nom de l'étudiant", "Prénom de l'étudiant", "Sexe", "Adresse", "Ville", "Province", "Téléphone", "Code postal"}

            For i As Integer = 0 To enteteColonne.Length - 1
                dgvEtudiants.Columns(i).HeaderText = enteteColonne(i)
            Next

        Catch ex As SqlException
            MessageBox.Show("Erreur SQL: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' RECHERCHE D'ÉTUDIANTS PAR FILTRE
    Private Sub RechercherEtudiants()
        Try
            Dim filter As String = String.Empty
            Dim rechercheBox As TextBox() = {txtRechercheDA, txtRechercheNom, txtRecherchePrenom, txtRechercheAdresse}
            Dim nomColonne As String() = {"etu_da", "etu_nom", "etu_prenom", "etu_adresse"}

            For i As Integer = 0 To rechercheBox.Length - 1
                Dim value As String = rechercheBox(i).Text.Trim()
                If Not String.IsNullOrEmpty(value) Then
                    If Not String.IsNullOrEmpty(filter) Then filter &= " AND "
                    filter &= $"{nomColonne(i)} LIKE '%{value}%'"
                End If
            Next

            bindSrcEtudiants.Filter = filter
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' GESTION DU TEXTE SAISI DANS LES CHAMPS DE RECHERCHE
    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRechercheDA.KeyPress, txtRechercheNom.KeyPress, txtRecherchePrenom.KeyPress, txtRechercheAdresse.KeyPress
        Try
            If sender Is txtRechercheDA AndAlso (Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            ElseIf sender Is txtRechercheAdresse AndAlso (Not AdresseValide(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            ElseIf sender IsNot txtRechercheDA AndAlso sender IsNot txtRechercheAdresse AndAlso (Not TexteValide(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' MISE À JOUR DE LA LISTE DES ÉTUDIANTS EN FONCTION DU TEXTE SAISI
    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtRechercheDA.TextChanged, txtRechercheNom.TextChanged, txtRecherchePrenom.TextChanged, txtRechercheAdresse.TextChanged
        Try
            Dim textBox As TextBox = CType(sender, TextBox)

            If (sender Is txtRechercheDA AndAlso (textBox.Text.Length <= 7 AndAlso IsNumeric(textBox.Text) OrElse String.IsNullOrEmpty(textBox.Text))) _
            OrElse (sender Is txtRechercheAdresse AndAlso (AdresseValide(textBox.Text) OrElse String.IsNullOrEmpty(textBox.Text))) _
            OrElse (sender IsNot txtRechercheDA AndAlso sender IsNot txtRechercheAdresse AndAlso (TexteValide(textBox.Text) OrElse String.IsNullOrEmpty(textBox.Text))) Then

                RechercherEtudiants()
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' VALIDATION DU TEXTE SAISI
    Private Function TexteValide(c As Char) As Boolean
        Try
            Dim regex As New Regex("^[a-zA-ZÀ-ÿ\s-]$")
            Return regex.IsMatch(c)
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' VALIDATION DE L'ADRESSE SAISIE
    Private Function AdresseValide(c As Char) As Boolean
        Try
            Dim regex As New Regex("^[a-zA-ZÀ-ÿ0-9\s\.,\-']$")
            Return regex.IsMatch(c)
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' GESTION DE LA FERMETURE DU FORMULAIRE
    Private Sub frmListeDesEtudiants_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dim result As DialogResult = MessageBox.Show("Voulez-vous vraiment quitter la liste des programmes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.No Then
                e.Cancel = True
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
