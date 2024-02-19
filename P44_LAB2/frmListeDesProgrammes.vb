'************************************************
'***************** COLLÈGE ABC ******************
'*** PROGRAMME PERMETTANT DE FAIRE LA GESTION DES
'*** PROGRAMMES ET DES ÉTUDIANTS EN UTILISANT LA
'*** BASE DE DONNÉES EXISTANTE DU COLLÈGE
'***
'************************************************
'*** CETTE PROGRAMMATION CI-DESSOUS EST DÉDIÉE À
'*** LA FENÊTRE ENFANT CONCERNANT LA LISTE DES
'*** PROGRAMMES
'***
'************************************************
'*** FAIT PAR:      Maryève Couture
'***                Justin Allard
'*** DATE:          2023-XX-XX
'*** RÉVISÉ PAR:
'*** DATE RÉVISION:
'************************************************

Imports Microsoft.Data.SqlClient

Public Class frmListeDesProgrammes

    ' INITIALISATION DES VARIABLES
    Dim dataSet As New DataSet("tp_p44")
    Dim connexion As New SqlConnection(My.Settings.ConnectionString)

    Dim tblProgrammesSqlCommand = New SqlCommand("SELECT * FROM T_Programme", connexion)
    Dim daTblProgrammes = New SqlDataAdapter(tblProgrammesSqlCommand)
    Dim bindSrcProgrammes = New BindingSource()

    ' CHARGEMENT DU FORMULAIRE
    Private Sub frmListeDesProgrammes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemplirDataGridViewProgrammes()
    End Sub

    ' REMPLISSAGE DU DATAGRIDVIEW AVEC LES DONNÉES DES PROGRAMMES
    Private Sub RemplirDataGridViewProgrammes()
        Try
            daTblProgrammes.Fill(dataSet, "T_Programme")

            dgvProgrammes.AutoGenerateColumns = True
            bindSrcProgrammes.DataSource = dataSet
            bindSrcProgrammes.DataMember = "T_Programme"
            dgvProgrammes.DataSource = bindSrcProgrammes

            Dim enteteColonne As String() = {"Numéro du programme", "Nom du programme", "Nombre d'unités", "Nombre d'heures"}

            For i As Integer = 0 To enteteColonne.Length - 1
                dgvProgrammes.Columns(i).HeaderText = enteteColonne(i)
            Next

        Catch ex As SqlException
            MessageBox.Show("Erreur SQL: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' GESTION DE LA FERMETURE DU FORMULAIRE
    Private Sub frmListeDesProgrammes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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