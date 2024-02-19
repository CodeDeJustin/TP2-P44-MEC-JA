'************************************************
'***************** COLLÈGE ABC ******************
'*** PROGRAMME PERMETTANT DE FAIRE LA GESTION DES
'*** PROGRAMMES ET DES ÉTUDIANTS EN UTILISANT LA
'*** BASE DE DONNÉES EXISTANTE DU COLLÈGE
'***
'************************************************
'*** CETTE PROGRAMMATION CI-DESSOUS EST DÉDIÉE À
'*** LA FENÊTRE ENFANT CONCERNANT LA GESTION DES
'*** ÉTUDIANTS INSCRITS AU COLLÈGE ABC
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

Imports Microsoft.Data.SqlClient
Imports System.Text.RegularExpressions

Public Enum Action
    Create = 0
    Read = 1
    Update = 2
    Delete = 3
End Enum

Public Class frmGestionEtudiants

    ' DÉCLARATION DES VARIABLES
    Dim dataSet As New DataSet("tp_p44")
    Dim connexion As New SqlConnection(My.Settings.ConnectionString)

    Dim tblEtudiantsSqlCommand = New SqlCommand("SELECT * FROM T_Etudiants", connexion)
    Dim tblEtudiantsSqlInsertCommand = New SqlCommand("INSERT INTO T_Etudiants (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_adresse, etu_ville, etu_province, etu_telephone, etu_codepostal) VALUES (@etu_da, @pro_no, @etu_nom, @etu_prenom, @etu_sexe, @etu_adresse, @etu_ville, @etu_province, @etu_telephone, @etu_codepostal)", connexion)
    Dim tblEtudiantsSqlUpdateCommand = New SqlCommand("UPDATE T_etudiants SET etu_da = @etu_da, pro_no = @pro_no, etu_nom = @etu_nom, etu_prenom = @etu_prenom, etu_sexe = @etu_sexe, etu_adresse = @etu_adresse, etu_ville = @etu_ville, etu_province = @etu_province, etu_telephone = @etu_telephone, etu_codepostal = @etu_codepostal WHERE etu_da = @original_etu_da", connexion)
    Dim tblEtudiantsSqlDeleteCommand = New SqlCommand("DELETE FROM T_Etudiants WHERE etu_da=@etu_da", connexion)
    Dim daTblEtudiants = New SqlDataAdapter(tblEtudiantsSqlCommand)
    Private WithEvents bindSrcEtudiants As New BindingSource()
    ' ↑ NORMALEMENT ↑ : Dim bindSrcEtudiants = New BindingSource() NÉCESSAIRE À CAUSE DU LABEL DE LA CLASSE

    Dim errProv As New ErrorProvider()

    'PRODUCTION D'UN DICTIONNAIRE POUR LES PROVINCES CONTENUES DANS LE CANADA 
    Dim provinces As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer) From {
        {"Québec", 1},
        {"Ontario", 2},
        {"Manitoba", 3},
        {"Saskatchewan", 4},
        {"Alberta", 5},
        {"Colombie-Britannique", 6},
        {"Nouveau-Brunswick", 7},
        {"Nouvelle-Écosse", 8},
        {"Ile-Du-Prince-Edouard", 9},
        {"Terre-Neuve-Et_labrador", 10},
        {"Yukon", 11},
        {"Territoires-Du-Nord-Ouest", 12},
        {"Nunavut", 13}
    }

    Private Sub frmGestionEtudiants_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemplirDataGridViewEtudiants()
        RemplirComboBoxProgramme()
        RemplirComboBoxProvince()
        ConfigurerCommandUpdate()
        ConfigurerCommandInsert()
        ConfigurerCommandDelete()
        BarrerCommandes()
        MettreAJourLabelNavigateur()
        AjouterDataBindingsAuxControles()
    End Sub

    ' REMPLISSAGE DU DataGridView AVEC LES DONNÉES DES ÉTUDIANTS
    Private Sub RemplirDataGridViewEtudiants()
        Try
            daTblEtudiants.Fill(dataSet, "T_Etudiants")
            dataSet.Tables("T_Etudiants").PrimaryKey = New DataColumn() {dataSet.Tables("T_Etudiants").Columns("etu_da")}
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

    ' AFFICHAGE DES INFORMATIONS DE L'ÉTUDIANT SÉLECTIONNÉ DANS LES CONTRÔLES DU FORMULAIRE
    Private Sub AfficherEtudiantSelectionne()
        Try
            If dgvEtudiants.SelectedCells.Count > 0 AndAlso dgvEtudiants.SelectedCells(0).Value IsNot Nothing Then
                Dim etu_da As String = dgvEtudiants.SelectedCells(0).Value.ToString()

                Dim selectedRow As DataRow = dataSet.Tables("T_Etudiants").Rows.Find(etu_da)

                If selectedRow IsNot Nothing Then
                    txtDA.Text = selectedRow("etu_da").ToString()
                    cbProgramme.Text = selectedRow("pro_no").ToString()
                    txtNom.Text = selectedRow("etu_nom").ToString()
                    txtPrenom.Text = selectedRow("etu_prenom").ToString()
                    If selectedRow("etu_sexe").ToString() = "F" Then
                        rdbFeminin.Checked = True
                    Else
                        rdbMasculin.Checked = True
                    End If
                    txtAdresse.Text = selectedRow("etu_adresse").ToString()
                    txtVille.Text = selectedRow("etu_ville").ToString()
                    cbProvince.Text = selectedRow("etu_province").ToString()
                    mskTelephone.Text = selectedRow("etu_telephone").ToString()
                    mskCodePostal.Text = selectedRow("etu_codepostal").ToString()
                End If
            End If

        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    ' CRÉATION D'UN NOUVEL ÉTUDIANT
    Private Sub CreerEtudiant()
        Try
            Dim newRow As DataRow = dataSet.Tables("T_Etudiants").NewRow()

            newRow("etu_da") = txtDA.Text.Trim()
            newRow("pro_no") = cbProgramme.SelectedValue
            newRow("etu_nom") = txtNom.Text.Trim()
            newRow("etu_prenom") = txtPrenom.Text.Trim()
            newRow("etu_sexe") = If(rdbFeminin.Checked, "F", "M")
            newRow("etu_adresse") = txtAdresse.Text.Trim()
            newRow("etu_ville") = txtVille.Text.Trim()
            newRow("etu_province") = cbProvince.Text.Trim()
            newRow("etu_telephone") = mskTelephone.Text
            newRow("etu_codepostal") = mskCodePostal.Text

            dataSet.Tables("T_Etudiants").Rows.Add(newRow)

            daTblEtudiants.Update(dataSet, "T_Etudiants")
            dataSet.AcceptChanges()

            MessageBox.Show("1 étudiant(s) créé(s)")
            RemplirDataGridViewEtudiants()
            dgvEtudiants.ClearSelection()
            dgvEtudiants.Rows(dgvEtudiants.Rows.Count - 1).Selected = True

        Catch ex As SqlException
            MessageBox.Show("Erreur SQL: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' MODIFICATION D'UN ÉTUDIANT
    Private Sub ModifierEtudiant()
        Try
            Dim selectedRow As DataRow = dataSet.Tables("T_Etudiants").Rows.Find(txtDA.Text.Trim())

            selectedRow("pro_no") = cbProgramme.SelectedValue
            selectedRow("etu_nom") = txtNom.Text.Trim()
            selectedRow("etu_prenom") = txtPrenom.Text.Trim()
            selectedRow("etu_sexe") = If(rdbFeminin.Checked, "F", "M")
            selectedRow("etu_adresse") = txtAdresse.Text.Trim()
            selectedRow("etu_ville") = txtVille.Text.Trim()
            selectedRow("etu_province") = cbProvince.Text.Trim()
            selectedRow("etu_telephone") = mskTelephone.Text
            selectedRow("etu_codepostal") = mskCodePostal.Text

            bindSrcEtudiants.EndEdit()
            daTblEtudiants.Update(dataSet, "T_Etudiants")
            dataSet.AcceptChanges()

            MessageBox.Show("1 étudiant(s) modifié(s)")

            RemplirDataGridViewEtudiants()
            dgvEtudiants.ClearSelection()
            dgvEtudiants.Rows(dgvEtudiants.Rows.Count - 1).Selected = True

        Catch ex As SqlException
            MessageBox.Show("Erreur SQL: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' SUPPRESSION D'UN ÉTUDIANT
    ' SUPPRESSION D'UN ÉTUDIANT
    Private Sub SupprimerEtudiant()
        Try
            If dgvEtudiants.SelectedCells.Count > 0 Then
                Dim selectedRow As DataRow = dataSet.Tables("T_Etudiants").Rows.Find(dgvEtudiants.SelectedCells(0).Value)

                selectedRow.Delete()

                daTblEtudiants.Update(dataSet, "T_Etudiants")
                dataSet.AcceptChanges()

                MessageBox.Show("1 étudiant(s) supprimé(s)")
                RemplirDataGridViewEtudiants()
            Else
                MessageBox.Show("Veuillez sélectionner un étudiant à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As SqlException
            MessageBox.Show("Erreur SQL: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' AFFICHAGE DES INFORMATIONS DE L'ÉTUDIANT SÉLECTIONNÉ DANS LE DataGridView
    Private Sub dgvEtudiants_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEtudiants.SelectionChanged
        If dgvEtudiants.SelectedRows.Count > 0 Then
            Dim selectedRow As DataRowView = CType(bindSrcEtudiants.Current, DataRowView)

            txtDA.Text = selectedRow("etu_DA").ToString()
            cbProgramme.SelectedValue = selectedRow("pro_no").ToString()
            txtNom.Text = selectedRow("etu_nom").ToString()
            txtPrenom.Text = selectedRow("etu_prenom").ToString()

            If selectedRow("etu_sexe").ToString() = "F" Then
                rdbFeminin.Checked = True
            Else
                rdbMasculin.Checked = True
            End If

            txtAdresse.Text = selectedRow("etu_adresse").ToString()
            txtVille.Text = selectedRow("etu_ville").ToString()
            cbProvince.Text = selectedRow("etu_province").ToString()
            mskTelephone.Text = selectedRow("etu_telephone").ToString()
            mskCodePostal.Text = selectedRow("etu_codepostal").ToString()
        End If
    End Sub

    ' CONFIGURATION DE LA COMMANDE SQL POUR L'INSERTION D'UN NOUVEL ÉTUDIANT
    Private Sub ConfigurerCommandInsert()
        AjouterParametresCommand(tblEtudiantsSqlInsertCommand)
        daTblEtudiants.InsertCommand = tblEtudiantsSqlInsertCommand
    End Sub

    ' CONFIGURATION DE LA COMMANDE SQL POUR LA MISE À JOUR DES INFORMATIONS D'UN ÉTUDIANT
    Private Sub ConfigurerCommandUpdate()
        AjouterParametresCommand(tblEtudiantsSqlUpdateCommand)

        Dim paramOriginalEtuDa As SqlParameter = tblEtudiantsSqlUpdateCommand.Parameters.Add("@original_etu_da", SqlDbType.Int, 0, "etu_da")
        paramOriginalEtuDa.SourceVersion = DataRowVersion.Original

        daTblEtudiants.UpdateCommand = tblEtudiantsSqlUpdateCommand
    End Sub

    ' CONFIGURATION DE LA COMMANDE SQL POUR LA SUPPRESSION D'UN ÉTUDIANT
    Private Sub ConfigurerCommandDelete()
        tblEtudiantsSqlDeleteCommand.Parameters.Add("@etu_da", SqlDbType.Int, 0, "etu_da")
        daTblEtudiants.DeleteCommand = tblEtudiantsSqlDeleteCommand
    End Sub

    ' AJOUT DE LIAISONS DE DONNÉES AUX CONTRÔLES
    Private Sub AjouterDataBindingsAuxControles()
        ' Création des liaisons de données
        Dim bindings As New List(Of Binding) From {
        New Binding("Text", bindSrcEtudiants, "etu_da", True),
        New Binding("Text", bindSrcEtudiants, "pro_no", True),
        New Binding("Text", bindSrcEtudiants, "etu_nom", True),
        New Binding("Text", bindSrcEtudiants, "etu_prenom", True),
        New Binding("Text", bindSrcEtudiants, "etu_adresse", True),
        New Binding("Text", bindSrcEtudiants, "etu_ville", True),
        New Binding("Text", bindSrcEtudiants, "etu_province", True),
        New Binding("Text", bindSrcEtudiants, "etu_telephone", True),
        New Binding("Text", bindSrcEtudiants, "etu_codepostal", True)
    }
        'Ajout des liaisons de données aux contrôles
        txtDA.DataBindings.Add(bindings(0))
        cbProgramme.DataBindings.Add(bindings(1))
        txtNom.DataBindings.Add(bindings(2))
        txtPrenom.DataBindings.Add(bindings(3))
        txtAdresse.DataBindings.Add(bindings(4))
        txtVille.DataBindings.Add(bindings(5))
        cbProvince.DataBindings.Add(bindings(6))
        mskTelephone.DataBindings.Add(bindings(7))
        mskCodePostal.DataBindings.Add(bindings(8))
    End Sub

    ' AJOUT DES PARAMÈTRES AUX COMMANDES SQL
    Private Sub AjouterParametresCommand(cmd As SqlCommand)
        cmd.Parameters.AddRange(New SqlParameter() {
        New SqlParameter("@etu_da", SqlDbType.VarChar, 7, "etu_da"),
        New SqlParameter("@pro_no", SqlDbType.VarChar, 6, "pro_no"),
        New SqlParameter("@etu_nom", SqlDbType.VarChar, 20, "etu_nom"),
        New SqlParameter("@etu_prenom", SqlDbType.VarChar, 20, "etu_prenom"),
        New SqlParameter("@etu_sexe", SqlDbType.Char, 1, "etu_sexe"),
        New SqlParameter("@etu_adresse", SqlDbType.VarChar, 100, "etu_adresse"),
        New SqlParameter("@etu_ville", SqlDbType.VarChar, 50, "etu_ville"),
        New SqlParameter("@etu_province", SqlDbType.VarChar, 50, "etu_province"),
        New SqlParameter("@etu_telephone", SqlDbType.VarChar, 14, "etu_telephone"),
        New SqlParameter("@etu_codepostal", SqlDbType.VarChar, 7, "etu_codepostal")
    })
    End Sub

    ' ASSIGNATION DU NOUVEAU NUMÉRO D'ADMISSION (DA) À UN ÉTUDIANT
    Private Sub AssignerNouveauDA()
        Try
            Dim sqlCommand As New SqlCommand("SELECT MAX(etu_da) as last_da FROM T_etudiants", connexion)

            Dim da As New SqlDataAdapter(sqlCommand)
            Dim ds As New DataSet()

            da.Fill(ds, "LastDA")

            If ds.Tables("LastDA").Rows.Count > 0 AndAlso Not ds.Tables("LastDA").Rows(0).IsNull("last_da") Then
                Dim lastDA As Integer = ds.Tables("LastDA").Rows(0)("last_da")
                Dim newDA As Integer = lastDA + 1

                ' Vérifie si la valeur est déjà présente dans la table
                While dataSet.Tables("T_Etudiants").Rows.Contains(newDA)
                    newDA += 1
                End While

                txtDA.Text = newDA.ToString()
            Else
                txtDA.Text = "00000000"
            End If

        Catch ex As SqlException
            GestionMessageErreur("Exception SQL rencontrée: Number: " & ex.Number & " Message: " & ex.Message)
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    ' GESTION DE LA SAISIE DE CARACTÈRES DANS LE CHAMP DU NOM
    Private Sub txtNom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNom.KeyPress
        If Not TexteValide(e.KeyChar.ToString()) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' GESTION DE LA SAISIE DE CARACTÈRES DANS LE CHAMP DU PRÉNOM
    Private Sub txtPrenom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrenom.KeyPress
        If Not TexteValide(e.KeyChar.ToString()) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' GESTION DE LA SAISIE DE CARACTÈRES DANS LE CHAMP DE LA VILLE
    Private Sub txtVille_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not TexteValide(e.KeyChar.ToString()) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' GESTION DE LA SAISIE DE CARACTÈRES DANS LE CHAMP DE L'ADRESSE
    Private Sub txtAdresse_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVille.KeyPress
        If Not AdresseValide(e.KeyChar.ToString()) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' VÉRIFICATION DE LA VALIDITÉ DU TEXTE SAISI
    Private Function TexteValide(texte As String) As Boolean
        Dim regex As New Regex("^[a-zA-ZÀ-ÿ\s-]+$")
        Return regex.IsMatch(texte)
    End Function

    ' VÉRIFICATION DE LA VALIDITÉ DE L'ADRESSE SAISIE
    Private Function AdresseValide(adresse As String) As Boolean
        Dim regex As New Regex("^[a-zA-ZÀ-ÿ0-9\s\.,\-']+$")
        Return regex.IsMatch(adresse)
    End Function

    Private Sub GestionMessageErreur(errorMessage As String)
        MsgBox(errorMessage)
    End Sub

    ' REMPLISSAGE DU COMBOBOX AVEC LA LISTE DES PROGRAMMES
    Private Sub RemplirComboBoxProgramme()
        Dim sqlCommand As New SqlCommand("SELECT pro_no, pro_nom FROM T_programme", connexion)

        Try
            Dim da As New SqlDataAdapter(sqlCommand)
            Dim ds As New DataSet()
            da.Fill(ds, "Programmes")
            cbProgramme.ValueMember = "pro_no"
            cbProgramme.DisplayMember = "pro_no"
            cbProgramme.DataSource = ds.Tables("Programmes")

        Catch ex As SqlException
            GestionMessageErreur("Exception SQL rencontrée: Number: " & ex.Number & " Message: " & ex.Message)
        Catch ex As Exception
            GestionMessageErreur("Une erreur est survenue: " & ex.Message)
        End Try
    End Sub

    ' REMPLISSAGE DU COMBOBOX AVEC LA LISTE DES PROVINCES
    Private Sub RemplirComboBoxProvince()
        cbProvince.ValueMember = "Value"
        cbProvince.DisplayMember = "Key"
        cbProvince.DataSource = New BindingSource(provinces, Nothing)
    End Sub

    Private Sub ReinitialiserMessageErreur()
        errProv.SetError(txtDA, String.Empty)
        errProv.SetError(cbProgramme, String.Empty)
        errProv.SetError(txtPrenom, String.Empty)
        errProv.SetError(txtNom, String.Empty)
        errProv.SetError(txtAdresse, String.Empty)
        errProv.SetError(txtVille, String.Empty)
        errProv.SetError(cbProvince, String.Empty)
        errProv.SetError(mskCodePostal, String.Empty)
        errProv.SetError(mskTelephone, String.Empty)
        errProv.SetError(grpSexe, String.Empty)
    End Sub

    Private Sub btnNouveau_Click(sender As Object, e As EventArgs) Handles btnNouveau.Click
        DebarrerCommandes()
        btnOk.Tag = Action.Create
        ViderChamps()
        AssignerNouveauDA()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If errProv.GetError(cbProgramme) = "" AndAlso
    errProv.GetError(txtPrenom) = "" AndAlso
    errProv.GetError(txtNom) = "" AndAlso
    errProv.GetError(txtAdresse) = "" AndAlso
    errProv.GetError(txtVille) = "" AndAlso
    errProv.GetError(mskCodePostal) = "" AndAlso
    errProv.GetError(mskTelephone) = "" AndAlso
    errProv.GetError(grpSexe) = "" AndAlso
    errProv.GetError(cbProvince) = "" Then
            If btnOk.Tag = Action.Create Then
                CreerEtudiant()
            ElseIf btnOk.Tag = Action.Update Then
                ModifierEtudiant()
            End If
            BarrerCommandes()
            ReinitialiserMessageErreur()
        End If
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        BarrerCommandes()
        ViderChamps()
        ReinitialiserMessageErreur()
        If dgvEtudiants.SelectedRows.Count > 0 Then
            AfficherEtudiantSelectionne()
        End If
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click
        If dgvEtudiants.SelectedRows.Count > 0 Then
            DebarrerCommandes()
            btnOk.Tag = Action.Update
            ReinitialiserMessageErreur()
        Else
            MessageBox.Show("Veuillez sélectionner un étudiant à modifier.")
        End If
    End Sub

    Private Sub btnEnlever_Click(sender As Object, e As EventArgs) Handles btnEnlever.Click
        If dgvEtudiants.SelectedRows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Voulez-vous vraiment supprimer l'étudiant sélectionné de la liste ?", "Supprimer un étudiant", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                SupprimerEtudiant()
            End If
        Else
            MessageBox.Show("Veuillez sélectionner un étudiant à supprimer.")
        End If
        ReinitialiserMessageErreur()
    End Sub

    'GESTION DES BOUTONS DE NAVIGATION
    Private Sub btnPremier_Click(sender As Object, e As EventArgs) Handles btnPremier.Click
        bindSrcEtudiants.MoveFirst()
    End Sub

    Private Sub btnPrecedent_Click(sender As Object, e As EventArgs) Handles btnPrecedent.Click
        bindSrcEtudiants.MovePrevious()
    End Sub

    Private Sub btnSuivant_Click(sender As Object, e As EventArgs) Handles btnSuivant.Click
        bindSrcEtudiants.MoveNext()
    End Sub

    Private Sub btnDernier_Click(sender As Object, e As EventArgs) Handles btnDernier.Click
        bindSrcEtudiants.MoveLast()
    End Sub

    Private Sub bindSrcEtudiants_NumeroPosition(sender As Object, e As EventArgs) Handles bindSrcEtudiants.PositionChanged
        lblNavigateur.Text = String.Format("{0} de {1}", bindSrcEtudiants.Position + 1, bindSrcEtudiants.Count)
    End Sub

    Private Sub MettreAJourLabelNavigateur()
        bindSrcEtudiants_NumeroPosition(bindSrcEtudiants, New EventArgs())
    End Sub

    Private Sub ViderChamps()
        txtDA.Text = String.Empty
        cbProgramme.SelectedIndex = -1
        txtPrenom.Text = String.Empty
        txtNom.Text = String.Empty
        txtAdresse.Text = String.Empty
        txtVille.Text = String.Empty
        cbProvince.SelectedIndex = -1
        mskCodePostal.Text = String.Empty
        mskTelephone.Text = String.Empty
        rdbFeminin.Checked = False
        rdbMasculin.Checked = False
    End Sub

    Private Sub BarrerCommandes()
        btnOk.Enabled = False
        btnAnnuler.Enabled = False
        btnNouveau.Enabled = True
        btnModifier.Enabled = True
        btnEnlever.Enabled = True
        grpInscriptionEtudiant.Enabled = False
    End Sub

    Private Sub DebarrerCommandes()
        btnOk.Enabled = True
        btnAnnuler.Enabled = True
        btnNouveau.Enabled = False
        btnModifier.Enabled = False
        btnEnlever.Enabled = False
        grpInscriptionEtudiant.Enabled = True
    End Sub


    ' TOUTE LES VALIDATING - VALIDATED
    Private Sub cbProgramme_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbProgramme.Validating
        If cbProgramme.Text.Length < 1 Then
            e.Cancel = True
            errProv.SetError(cbProgramme, "Vous devez entrer le numéro de programme")
        End If
    End Sub

    Private Sub cbProgramme_Validated(sender As Object, e As EventArgs) Handles cbProgramme.Validated
        errProv.SetError(cbProgramme, "")
    End Sub

    Private Sub txtPrenom_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPrenom.Validating
        If txtPrenom.Text.Length < 1 Then
            e.Cancel = True
            errProv.SetError(txtPrenom, "Vous devez entrer le prénom")
        ElseIf Not TexteValide(txtPrenom.Text) Then
            e.Cancel = True
            errProv.SetError(txtPrenom, "Le prénom ne doit contenir que des lettres")
        End If
    End Sub

    Private Sub txtPrenom_Validated(sender As Object, e As EventArgs) Handles txtPrenom.Validated
        errProv.SetError(txtPrenom, "")
    End Sub

    Private Sub txtNom_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNom.Validating
        If txtNom.Text.Length < 1 Then
            e.Cancel = True
            errProv.SetError(txtNom, "Vous devez entrer le nom")
        ElseIf Not TexteValide(txtNom.Text) Then
            e.Cancel = True
            errProv.SetError(txtNom, "Le nom ne doit contenir que des lettres")
        End If
    End Sub

    Private Sub txtNom_Validated(sender As Object, e As EventArgs) Handles txtNom.Validated
        errProv.SetError(txtNom, "")
    End Sub

    Private Sub grpSexe_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grpSexe.Validating
        If Not rdbFeminin.Checked AndAlso Not rdbMasculin.Checked Then
            e.Cancel = True
            errProv.SetError(grpSexe, "Vous devez choisir le sexe de l'étudiant")
        End If
    End Sub

    Private Sub grpSexe_Validated(sender As Object, e As EventArgs) Handles grpSexe.Validated
        errProv.SetError(grpSexe, "")
    End Sub

    Private Sub txtAdresse_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAdresse.Validating
        If txtAdresse.Text.Length < 1 Then
            e.Cancel = True
            errProv.SetError(txtAdresse, "Vous devez entrer une adresse")
        ElseIf Not AdresseValide(txtAdresse.Text) Then
            e.Cancel = True
            errProv.SetError(txtAdresse, "L'adresse est invalide, elle ne doit contenir que des chiffres et des lettres")
        End If
    End Sub

    Private Sub txtAdresse_Validated(sender As Object, e As EventArgs) Handles txtAdresse.Validated
        errProv.SetError(txtAdresse, "")
    End Sub

    Private Sub txtVille_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtVille.Validating
        If txtVille.Text.Length < 1 Then
            e.Cancel = True
            errProv.SetError(txtVille, "Vous devez entrer une ville")
        ElseIf Not TexteValide(txtVille.Text) Then
            e.Cancel = True
            errProv.SetError(txtVille, "La ville est invalide, elle ne doit contenir que des lettres")
        End If
    End Sub

    Private Sub txtVille_Validated(sender As Object, e As EventArgs) Handles txtVille.Validated
        errProv.SetError(txtVille, "")
    End Sub

    Private Sub mskCodePostal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskCodePostal.Validating
        If mskCodePostal.MaskFull = False Then
            e.Cancel = True
            errProv.SetError(mskCodePostal, "Vous devez entrer un code postal valide")
        End If
    End Sub

    Private Sub mskCodePostal_Validated(sender As Object, e As EventArgs) Handles mskCodePostal.Validated
        errProv.SetError(mskCodePostal, "")
    End Sub

    Private Sub mskTelephone_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mskTelephone.Validating
        If Not mskTelephone.MaskFull Then
            e.Cancel = True
            errProv.SetError(mskTelephone, "Téléphone non valide! Vous devez entrer un numéro de téléphone complet.")
        End If
    End Sub

    Private Sub mskTelephone_Validated(sender As Object, e As EventArgs) Handles mskTelephone.Validated
        errProv.SetError(mskTelephone, "")
    End Sub

    Private Sub frmGestionEtudiants_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result As DialogResult = MessageBox.Show("Voulez-vous vraiment quitter le gestionnaire d'étudiant?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

End Class