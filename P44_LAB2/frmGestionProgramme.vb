'************************************************
'***************** COLLÈGE ABC ******************
'*** PROGRAMME PERMETTANT DE FAIRE LA GESTION DES
'*** PROGRAMMES ET DES ÉTUDIANTS EN UTILISANT LA
'*** BASE DE DONNÉES EXISTANTE DU COLLÈGE
'***
'************************************************
'*** CETTE PROGRAMMATION CI-DESSOUS EST DÉDIÉE À
'*** LA FENÊTRE ENFANT CONCERNANT LA GESTION DES
'*** PROGRAMMES SCOLAIRES DU COLLÈGE ABC
'************************************************
'*** FAIT PAR:      Maryève Couture
'***                Justin Allard
'*** DATE:          2023-04-02
'***
'*** RÉVISÉ PAR:    Maryève Couture
'***                Justin Allard
'*** DATE RÉVISION: 2023-05-14
'*** SUJET RÉV.:    PASSER DU MODE CONNECTÉ
'***                AU MODE DÉCONNECTÉ
'************************************************

Imports System.Globalization
Imports Microsoft.Data.SqlClient

Public Enum ActionCRUD
    Read = 0
    Create = 1
    Update = 2
    Delete = 3
End Enum

Public Class frmGestionProgramme

    ' DÉCLARATION DES VARIABLES
    Dim dataSet As New DataSet("tp_p44")
    Dim connexion As New SqlConnection(My.Settings.ConnectionString)

    Dim tblProgrammesSqlCommand = New SqlCommand("SELECT * FROM T_Programme ORDER BY pro_no")
    Dim tblProgrammesSqlInsertCommand = New SqlCommand("INSERT INTO T_Programme (pro_no, pro_nom, pro_nbr_unites, pro_nbr_heures) VALUES (@pro_no, @pro_nom, @pro_nbr_unites, @pro_nbr_heures)")
    Dim tblProgrammesSqlUpdateCommand = New SqlCommand("UPDATE T_Programme SET pro_nom = @pro_nom, pro_nbr_unites = @pro_nbr_unites, pro_nbr_heures = @pro_nbr_heures WHERE pro_no = @original_pro_no")
    Dim tblProgrammesSqlDeleteCommand = New SqlCommand("DELETE FROM T_Programme WHERE pro_no = @pro_no")
    Dim daTblProgrammes = New SqlDataAdapter(tblProgrammesSqlCommand)
    Private WithEvents bindSrcProgrammes As New BindingSource()

    Dim errProv As New ErrorProvider()

    Private Sub frmGestionProgramme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemplirDataGridViewProgramme()
        RemplirDataSetEtudiants()
        BarrerCommandes(btnOK, btnAnnuler, gpBxProgramme)
        ColonneAffichageDataGridViewEtudiants()
    End Sub

    ' REMPLIR LE DATA GRID VIEW AVEC DES DONNÉES DE PROGRAMME
    Private Sub RemplirDataGridViewProgramme()
        Try
            If Not dataSet.Tables.Contains("T_Programme") Then
                dataSet.Tables.Add("T_Programme")
            End If

            daTblProgrammes.SelectCommand.Connection = connexion
            dataSet.Tables("T_Programme").Clear()
            daTblProgrammes.Fill(dataSet.Tables("T_Programme"))
            bindSrcProgrammes.DataSource = dataSet.Tables("T_Programme")
            dgvProgramme.DataSource = bindSrcProgrammes
            dgvProgramme.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        Catch ex As SqlException
            GestionMessageErreur("Exception SQL rencontrée: Number: " & ex.Number & " Message: " & ex.Message)
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    ' AFFICHER LES DÉTAILS DU PROGRAMME SÉLECTIONNÉ
    Private Sub AfficherProgrammeSelectionne()
        If dgvProgramme.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvProgramme.SelectedRows(0)

            mskNumeroProgramme.Text = Convert.ToString(selectedRow.Cells("pro_no").Value)
            txtNomProgramme.Text = Convert.ToString(selectedRow.Cells("pro_nom").Value)
            mskNombreUnites.Text = Convert.ToString(selectedRow.Cells("pro_nbr_unites").Value)
            mskNombreHeures.Text = Convert.ToString(selectedRow.Cells("pro_nbr_heures").Value)
        End If
    End Sub

    ' CRÉER UN NOUVEAU PROGRAMME
    Private Sub CreerProgramme()
        Try
            Dim dtProgramme As New DataTable
            Using tempAdapter As New SqlDataAdapter("SELECT pro_no FROM T_programme", connexion)
                tempAdapter.Fill(dtProgramme)
            End Using

            Dim keyExists As Integer = dtProgramme.Select("pro_no = '" & mskNumeroProgramme.Text.Replace(",", ".") & "'").Length

            If keyExists > 0 Then
                MessageBox.Show("Le numéro de programme existe déjà. Veuillez entrer un autre numéro.")
            Else
                Dim newRow As DataRow = dataSet.Tables("T_Programme").NewRow()
                newRow("pro_no") = mskNumeroProgramme.Text.Replace(",", ".")
                newRow("pro_nom") = txtNomProgramme.Text.Trim()

                Dim nbrUnites As Double
                Dim culture As CultureInfo = CultureInfo.InvariantCulture
                If Double.TryParse(mskNombreUnites.Text, NumberStyles.Any, culture, nbrUnites) Then
                    newRow("pro_nbr_unites") = nbrUnites
                Else
                    MessageBox.Show("Le nombre d'unités n'est pas dans un format correct.")
                    Return
                End If

                Dim nbrHeures As Double
                If Double.TryParse(mskNombreHeures.Text, NumberStyles.Any, culture, nbrHeures) Then
                    newRow("pro_nbr_heures") = nbrHeures
                Else
                    MessageBox.Show("Le nombre d'heures n'est pas dans un format correct.")
                    Return
                End If

                dataSet.Tables("T_Programme").Rows.Add(newRow)

                tblProgrammesSqlInsertCommand.Parameters.Add("@pro_no", SqlDbType.VarChar, 6, "pro_no")
                tblProgrammesSqlInsertCommand.Parameters.Add("@pro_nom", SqlDbType.VarChar, 50, "pro_nom")
                tblProgrammesSqlInsertCommand.Parameters.Add("@pro_nbr_unites", SqlDbType.Float, 8, "pro_nbr_unites")
                tblProgrammesSqlInsertCommand.Parameters.Add("@pro_nbr_heures", SqlDbType.Int, 4, "pro_nbr_heures")

                daTblProgrammes.InsertCommand = tblProgrammesSqlInsertCommand
                daTblProgrammes.InsertCommand.Connection = connexion
                daTblProgrammes.Update(dataSet.Tables("T_Programme"))

                MessageBox.Show("Le nouveau programme a été créé !")
                ' RemplirDataGridViewProgramme() ' Ne pas remplir à nouveau le DataGridView
                dgvProgramme.Rows(dgvProgramme.RowCount - 1).Selected = True
            End If
        Catch ex As SqlException
            GestionMessageErreur("Exception SQL rencontrée: Number: " & ex.Number & " Message: " & ex.Message)
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    ' MODIFIER LE PROGRAMME SÉLECTIONNÉ
    Private Sub ModifierProgramme()
        Try
            If dgvProgramme.SelectedRows.Count > 0 Then
                Dim rowIndex As Integer = dgvProgramme.SelectedRows(0).Index
                Dim selectedRow As DataRow = dataSet.Tables("T_Programme").Rows(rowIndex)

                Dim original_pro_no As String = selectedRow("pro_no").ToString()

                selectedRow("pro_no") = mskNumeroProgramme.Text
                selectedRow("pro_nom") = txtNomProgramme.Text.Trim()
                selectedRow("pro_nbr_unites") = Convert.ToDouble(mskNombreUnites.Text.Replace(".", ","))
                selectedRow("pro_nbr_heures") = Convert.ToDouble(mskNombreHeures.Text.Replace(".", ","))

                tblProgrammesSqlUpdateCommand.Parameters.AddWithValue("@original_pro_no", original_pro_no)
                tblProgrammesSqlUpdateCommand.Parameters.Add("@pro_no", SqlDbType.VarChar, 6, "pro_no")
                tblProgrammesSqlUpdateCommand.Parameters.Add("@pro_nom", SqlDbType.VarChar, 50, "pro_nom")
                tblProgrammesSqlUpdateCommand.Parameters.Add("@pro_nbr_unites", SqlDbType.Float, 8, "pro_nbr_unites")
                tblProgrammesSqlUpdateCommand.Parameters.Add("@pro_nbr_heures", SqlDbType.Int, 4, "pro_nbr_heures")

                daTblProgrammes.UpdateCommand = tblProgrammesSqlUpdateCommand
                daTblProgrammes.UpdateCommand.Connection = connexion
                daTblProgrammes.Update(dataSet.Tables("T_Programme"))

                MessageBox.Show("Les modifications ont été apportées avec succès")
                RemplirDataGridViewProgramme()
                dgvProgramme.Rows(rowIndex).Selected = True
            Else
                MessageBox.Show("Veuillez sélectionner un programme à modifier.")
            End If
        Catch ex As SqlException
            GestionMessageErreur("Exception SQL rencontrée: Number: " & ex.Number & " Message: " & ex.Message)
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    ' SUPPRIMER LE PROGRAMME SÉLECTIONNÉ
    Private Sub SupprimerProgramme()
        If dgvProgramme.SelectedRows.Count > 0 Then
            Dim rowIndex As Integer = dgvProgramme.SelectedRows(0).Index
            Dim pro_no As String = dgvProgramme.SelectedRows(0).Cells("pro_no").Value.ToString()

            dataSet.Tables("T_Programme").Rows(rowIndex).Delete()

            tblProgrammesSqlDeleteCommand.Parameters.AddWithValue("@pro_no", pro_no)
            daTblProgrammes.DeleteCommand = tblProgrammesSqlDeleteCommand
            daTblProgrammes.DeleteCommand.Connection = connexion
            daTblProgrammes.Update(dataSet.Tables("T_Programme"))

            MessageBox.Show("Programme supprimé")
            RemplirDataGridViewProgramme()
        Else
            MessageBox.Show("Veuillez sélectionner un programme à supprimer.")
        End If
    End Sub

    ' GESTION DU CHANGEMENT DE SÉLECTION DANS LE DGV PROGRAMME
    Private Sub dgvProgramme_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProgramme.SelectionChanged
        dgvEtudiantsParProgrammes.Rows.Clear()

        If dgvProgramme.SelectedRows.Count > 0 Then
            Dim selectedCell As DataGridViewCell = dgvProgramme.SelectedRows(0).Cells("pro_no")

            If selectedCell.Value IsNot Nothing Then
                Dim pro_no As String = selectedCell.Value.ToString()
                AjouterInformationsDataGridViewEtudiants(pro_no)
                AfficherProgrammeSelectionne()
            End If
        End If
    End Sub

    ' REMPLIR LE DATASET AVEC LES ÉTUDIANTS
    Private Sub RemplirDataSetEtudiants()
        Try
            Dim tblEtudiantsSqlCommand = New SqlCommand("SELECT * FROM T_Etudiants")
            Dim daTblEtudiants = New SqlDataAdapter(tblEtudiantsSqlCommand)
            tblEtudiantsSqlCommand.Connection = connexion
            dataSet.Tables.Add("T_Etudiants")
            daTblEtudiants.Fill(dataSet.Tables("T_Etudiants"))
        Catch ex As SqlException
            GestionMessageErreur("Exception SQL rencontrée: Number: " & ex.Number & " Message: " & ex.Message)
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    'AJOUTER DES INFORMATIONS DANS LE DGV ÉTUDIANTS
    Private Sub AjouterInformationsDataGridViewEtudiants(pro_no As String)
        dgvEtudiantsParProgrammes.Rows.Clear()

        Dim etudiantsParProgrammeTable As New DataTable()
        Dim etudiantsFiltres = dataSet.Tables("T_Etudiants").Select("pro_no = '" & pro_no & "'")

        For Each etudiant In etudiantsFiltres
            dgvEtudiantsParProgrammes.Rows.Add(etudiant("etu_da"), etudiant("pro_no"), etudiant("etu_nom"), etudiant("etu_prenom"), etudiant("etu_sexe"), etudiant("etu_adresse"), etudiant("etu_ville"), etudiant("etu_province"), etudiant("etu_telephone"), etudiant("etu_codepostal"))
        Next
    End Sub

    ' CONFIGURER L'AFFICHAGE DES COLONNES DU DGV ÉTUDIANTS
    Private Sub ColonneAffichageDataGridViewEtudiants()
        Try
            With dgvEtudiantsParProgrammes
                .Columns.Clear()
                .Columns.Add("etu_da", "DA")
                .Columns.Add("pro_no", "Programme")
                .Columns.Add("etu_nom", "Nom")
                .Columns.Add("etu_prenom", "Prenom")
                .Columns.Add("etu_sexe", "Sexe")
                .Columns.Add("etu_adresse", "Adresse")
                .Columns.Add("etu_ville", "Ville")
                .Columns.Add("etu_province", "Province")
                .Columns.Add("etu_telephone", "Telephone")
                .Columns.Add("etu_codepostal", "Code Postal")
            End With
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    ' COMMANDER LA REQUÊTE SQL POUR CHERCHER LA LISTE D'ÉTUDIANTS
    Private Sub SqlCommandeChercherListeEtudiants(pro_no As String)
        Dim etudiantsParProgrammeTable As New DataTable()
        Try
            connexion.Open()
            Dim etudiantsParProgrammeCommand = New SqlCommand("SELECT * FROM T_Etudiants WHERE pro_no = @pro_no", connexion)
            etudiantsParProgrammeCommand.Parameters.AddWithValue("@pro_no", pro_no)

            Dim etudiantsParProgrammeAdapter = New SqlDataAdapter(etudiantsParProgrammeCommand)
            etudiantsParProgrammeAdapter.Fill(etudiantsParProgrammeTable)

        Catch ex As SqlException
            GestionMessageErreur("Exception SQL rencontrée: Number: " & ex.Number & " Message: " & ex.Message)
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        Finally
            connexion.Close()
        End Try
    End Sub

    ' AFFICHER LE GROUPE BOX PROGRAMME
    Private Sub AfficherGroupeBoxProgramme()
        If dgvProgramme.SelectedRows.Count > 0 Then
            Dim colonneSelectionne = dgvProgramme.SelectedRows(0)
            mskNumeroProgramme.Text = colonneSelectionne.Cells("pro_no").Value.ToString()
            txtNomProgramme.Text = colonneSelectionne.Cells("pro_nom").Value.ToString()
            mskNombreUnites.Text = colonneSelectionne.Cells("pro_unites").Value.ToString()
            mskNombreHeures.Text = colonneSelectionne.Cells("pro_heures").Value.ToString()
        End If
    End Sub

    ' EFFACER LE GROUPE BOX PROGRAMME
    Private Sub EffacerGroupeBoxProgramme()
        mskNumeroProgramme.Clear()
        txtNomProgramme.Clear()
        mskNombreHeures.Clear()
        mskNombreUnites.Clear()
    End Sub

    ' GESTION DU BOUTON "NOUVEAU"
    Private Sub btnNouveau_Click(sender As Object, e As EventArgs) Handles btnNouveau.Click
        EffacerGroupeBoxProgramme()
        btnOK.Tag = ActionCRUD.Create
        BarrerCommandes(btnModifier, btnEnlever, btnNouveau)
        DebarrerCommandes(btnOK, btnAnnuler, gpBxProgramme)
        mskNumeroProgramme.Enabled = True
    End Sub

    ' GESTION DU BOUTON "OK"
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If btnOK.Tag = ActionCRUD.Create Then
                CreerProgramme()
            ElseIf btnOK.Tag = ActionCRUD.Update Then
                ModifierProgramme()
            End If
            BarrerCommandes(btnOK, btnAnnuler, gpBxProgramme)
            DebarrerCommandes(btnNouveau, btnEnlever, btnModifier)
            EffacerGroupeBoxProgramme()
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    ' GESTION DU BOUTON "ANNULER"
    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Try
            EffacerGroupeBoxProgramme()
            BarrerCommandes(btnOK, btnAnnuler, gpBxProgramme)
            DebarrerCommandes(btnNouveau, btnModifier, btnEnlever)
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    ' GESTION DU BOUTON "MODIFIER"
    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click
        Try
            If dgvProgramme.SelectedRows.Count > 0 Then
                mskNumeroProgramme.Enabled = False
                btnOK.Tag = ActionCRUD.Update
                BarrerCommandes(btnNouveau, btnEnlever)
                DebarrerCommandes(btnAnnuler, btnOK, gpBxProgramme)
            Else
                MessageBox.Show("Veuillez sélectionner le programme à modifier !")
            End If
        Catch ex As SqlException
            GestionMessageErreur("Exception SQL rencontrée: Number: " & ex.Number & " Message: " & ex.Message)
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        Finally
            connexion.Close()
        End Try
    End Sub

    ' GESTION DU BOUTON "ENLEVER"
    Private Sub btnEnlever_Click(sender As Object, e As EventArgs) Handles btnEnlever.Click
        If dgvProgramme.SelectedRows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le programme sélectionné?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                SupprimerProgramme()
            End If
        Else
            MessageBox.Show("Veuillez sélectionner un programme à supprimer.")
        End If
    End Sub

    Private Sub DebarrerCommandes(ParamArray ctrls() As Control)
        For Each ctrl In ctrls
            ctrl.Enabled = True
        Next
    End Sub

    Private Sub BarrerCommandes(ParamArray ctrls() As Control)
        For Each ctrl In ctrls
            ctrl.Enabled = False
        Next
    End Sub

    Private Sub GestionMessageErreur(errorMessage As String)
        MsgBox(errorMessage)
    End Sub

    Private Sub txtNomProgramme_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomProgramme.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub mskNombreHeures_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskNombreHeures.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub mskNombreUnites_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskNombreUnites.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "," Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmGestionProgramme_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result As DialogResult = MessageBox.Show("Voulez-vous vraiment quitter le gestionnaire de programme?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

End Class