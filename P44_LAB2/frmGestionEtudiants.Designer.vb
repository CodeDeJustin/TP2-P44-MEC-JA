<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestionEtudiants
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        gbBoutons = New GroupBox()
        btnEnlever = New Button()
        btnModifier = New Button()
        btnAnnuler = New Button()
        btnOk = New Button()
        btnNouveau = New Button()
        grpInscriptionEtudiant = New GroupBox()
        grpSexe = New GroupBox()
        rdbMasculin = New RadioButton()
        rdbFeminin = New RadioButton()
        cbProgramme = New ComboBox()
        lblProgramme = New Label()
        cbProvince = New ComboBox()
        mskTelephone = New MaskedTextBox()
        mskCodePostal = New MaskedTextBox()
        lblVille = New Label()
        lblCP = New Label()
        txtVille = New TextBox()
        txtAdresse = New TextBox()
        txtNom = New TextBox()
        txtPrenom = New TextBox()
        txtDA = New TextBox()
        lblProvince = New Label()
        lblTelephone = New Label()
        lblAdresse = New Label()
        lblNom = New Label()
        lblPrenom = New Label()
        lblDA = New Label()
        dgvEtudiants = New DataGridView()
        grpNavigateur = New GroupBox()
        lblNavigateur = New Label()
        btnDernier = New Button()
        btnSuivant = New Button()
        btnPrecedent = New Button()
        btnPremier = New Button()
        gbBoutons.SuspendLayout()
        grpInscriptionEtudiant.SuspendLayout()
        grpSexe.SuspendLayout()
        CType(dgvEtudiants, ComponentModel.ISupportInitialize).BeginInit()
        grpNavigateur.SuspendLayout()
        SuspendLayout()
        ' 
        ' gbBoutons
        ' 
        gbBoutons.Controls.Add(btnEnlever)
        gbBoutons.Controls.Add(btnModifier)
        gbBoutons.Controls.Add(btnAnnuler)
        gbBoutons.Controls.Add(btnOk)
        gbBoutons.Controls.Add(btnNouveau)
        gbBoutons.Location = New Point(675, -2)
        gbBoutons.Margin = New Padding(3, 2, 3, 2)
        gbBoutons.Name = "gbBoutons"
        gbBoutons.Padding = New Padding(3, 2, 3, 2)
        gbBoutons.Size = New Size(101, 219)
        gbBoutons.TabIndex = 7
        gbBoutons.TabStop = False
        ' 
        ' btnEnlever
        ' 
        btnEnlever.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnEnlever.Enabled = False
        btnEnlever.Location = New Point(6, 170)
        btnEnlever.Margin = New Padding(3, 2, 3, 2)
        btnEnlever.Name = "btnEnlever"
        btnEnlever.Size = New Size(89, 35)
        btnEnlever.TabIndex = 4
        btnEnlever.Text = "Enlever"
        btnEnlever.UseVisualStyleBackColor = False
        ' 
        ' btnModifier
        ' 
        btnModifier.Enabled = False
        btnModifier.Location = New Point(6, 131)
        btnModifier.Margin = New Padding(3, 2, 3, 2)
        btnModifier.Name = "btnModifier"
        btnModifier.Size = New Size(89, 35)
        btnModifier.TabIndex = 3
        btnModifier.Text = "Modifier"
        btnModifier.UseVisualStyleBackColor = True
        ' 
        ' btnAnnuler
        ' 
        btnAnnuler.Enabled = False
        btnAnnuler.Location = New Point(6, 92)
        btnAnnuler.Margin = New Padding(3, 2, 3, 2)
        btnAnnuler.Name = "btnAnnuler"
        btnAnnuler.Size = New Size(89, 35)
        btnAnnuler.TabIndex = 2
        btnAnnuler.Text = "Annuler"
        btnAnnuler.UseVisualStyleBackColor = True
        ' 
        ' btnOk
        ' 
        btnOk.Enabled = False
        btnOk.Location = New Point(6, 53)
        btnOk.Margin = New Padding(3, 2, 3, 2)
        btnOk.Name = "btnOk"
        btnOk.Size = New Size(89, 35)
        btnOk.TabIndex = 1
        btnOk.Text = "Ok"
        btnOk.UseVisualStyleBackColor = True
        ' 
        ' btnNouveau
        ' 
        btnNouveau.Location = New Point(6, 14)
        btnNouveau.Margin = New Padding(3, 2, 3, 2)
        btnNouveau.Name = "btnNouveau"
        btnNouveau.Size = New Size(89, 35)
        btnNouveau.TabIndex = 0
        btnNouveau.Text = "Nouveau"
        btnNouveau.UseVisualStyleBackColor = True
        ' 
        ' grpInscriptionEtudiant
        ' 
        grpInscriptionEtudiant.Controls.Add(grpSexe)
        grpInscriptionEtudiant.Controls.Add(cbProgramme)
        grpInscriptionEtudiant.Controls.Add(lblProgramme)
        grpInscriptionEtudiant.Controls.Add(cbProvince)
        grpInscriptionEtudiant.Controls.Add(mskTelephone)
        grpInscriptionEtudiant.Controls.Add(mskCodePostal)
        grpInscriptionEtudiant.Controls.Add(lblVille)
        grpInscriptionEtudiant.Controls.Add(lblCP)
        grpInscriptionEtudiant.Controls.Add(txtVille)
        grpInscriptionEtudiant.Controls.Add(txtAdresse)
        grpInscriptionEtudiant.Controls.Add(txtNom)
        grpInscriptionEtudiant.Controls.Add(txtPrenom)
        grpInscriptionEtudiant.Controls.Add(txtDA)
        grpInscriptionEtudiant.Controls.Add(lblProvince)
        grpInscriptionEtudiant.Controls.Add(lblTelephone)
        grpInscriptionEtudiant.Controls.Add(lblAdresse)
        grpInscriptionEtudiant.Controls.Add(lblNom)
        grpInscriptionEtudiant.Controls.Add(lblPrenom)
        grpInscriptionEtudiant.Controls.Add(lblDA)
        grpInscriptionEtudiant.Enabled = False
        grpInscriptionEtudiant.Location = New Point(1, -2)
        grpInscriptionEtudiant.Margin = New Padding(3, 2, 3, 2)
        grpInscriptionEtudiant.Name = "grpInscriptionEtudiant"
        grpInscriptionEtudiant.Padding = New Padding(3, 2, 3, 2)
        grpInscriptionEtudiant.Size = New Size(668, 219)
        grpInscriptionEtudiant.TabIndex = 4
        grpInscriptionEtudiant.TabStop = False
        grpInscriptionEtudiant.Text = "Étudiant"
        ' 
        ' grpSexe
        ' 
        grpSexe.Controls.Add(rdbMasculin)
        grpSexe.Controls.Add(rdbFeminin)
        grpSexe.Location = New Point(98, 128)
        grpSexe.Name = "grpSexe"
        grpSexe.Size = New Size(108, 86)
        grpSexe.TabIndex = 23
        grpSexe.TabStop = False
        grpSexe.Text = "Sexe"
        ' 
        ' rdbMasculin
        ' 
        rdbMasculin.AutoSize = True
        rdbMasculin.Location = New Point(6, 47)
        rdbMasculin.Name = "rdbMasculin"
        rdbMasculin.Size = New Size(73, 19)
        rdbMasculin.TabIndex = 1
        rdbMasculin.TabStop = True
        rdbMasculin.Text = "Masculin"
        rdbMasculin.UseVisualStyleBackColor = True
        ' 
        ' rdbFeminin
        ' 
        rdbFeminin.AutoSize = True
        rdbFeminin.Location = New Point(6, 22)
        rdbFeminin.Name = "rdbFeminin"
        rdbFeminin.Size = New Size(68, 19)
        rdbFeminin.TabIndex = 0
        rdbFeminin.TabStop = True
        rdbFeminin.Text = "Féminin"
        rdbFeminin.UseVisualStyleBackColor = True
        ' 
        ' cbProgramme
        ' 
        cbProgramme.DropDownStyle = ComboBoxStyle.DropDownList
        cbProgramme.FlatStyle = FlatStyle.Flat
        cbProgramme.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        cbProgramme.FormattingEnabled = True
        cbProgramme.Location = New Point(98, 41)
        cbProgramme.Margin = New Padding(3, 2, 3, 2)
        cbProgramme.Name = "cbProgramme"
        cbProgramme.Size = New Size(220, 23)
        cbProgramme.TabIndex = 21
        ' 
        ' lblProgramme
        ' 
        lblProgramme.Location = New Point(2, 38)
        lblProgramme.Name = "lblProgramme"
        lblProgramme.Size = New Size(90, 25)
        lblProgramme.TabIndex = 22
        lblProgramme.Text = "NoProgramme"
        lblProgramme.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' cbProvince
        ' 
        cbProvince.DropDownStyle = ComboBoxStyle.DropDownList
        cbProvince.FlatStyle = FlatStyle.Flat
        cbProvince.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        cbProvince.FormattingEnabled = True
        cbProvince.Location = New Point(428, 69)
        cbProvince.Margin = New Padding(3, 2, 3, 2)
        cbProvince.Name = "cbProvince"
        cbProvince.Size = New Size(220, 23)
        cbProvince.TabIndex = 1
        ' 
        ' mskTelephone
        ' 
        mskTelephone.Location = New Point(428, 124)
        mskTelephone.Margin = New Padding(3, 2, 3, 2)
        mskTelephone.Mask = "(999) 000-0000"
        mskTelephone.Name = "mskTelephone"
        mskTelephone.PromptChar = " "c
        mskTelephone.Size = New Size(220, 23)
        mskTelephone.TabIndex = 20
        ' 
        ' mskCodePostal
        ' 
        mskCodePostal.Location = New Point(428, 96)
        mskCodePostal.Margin = New Padding(3, 2, 3, 2)
        mskCodePostal.Mask = ">L0L-0L0"
        mskCodePostal.Name = "mskCodePostal"
        mskCodePostal.PromptChar = " "c
        mskCodePostal.Size = New Size(220, 23)
        mskCodePostal.TabIndex = 19
        ' 
        ' lblVille
        ' 
        lblVille.Location = New Point(332, 41)
        lblVille.Name = "lblVille"
        lblVille.Size = New Size(90, 25)
        lblVille.TabIndex = 5
        lblVille.Text = "Ville"
        lblVille.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblCP
        ' 
        lblCP.Location = New Point(332, 97)
        lblCP.Name = "lblCP"
        lblCP.Size = New Size(90, 25)
        lblCP.TabIndex = 6
        lblCP.Text = "Code postal"
        lblCP.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' txtVille
        ' 
        txtVille.Location = New Point(428, 41)
        txtVille.Margin = New Padding(3, 2, 3, 2)
        txtVille.Name = "txtVille"
        txtVille.Size = New Size(220, 23)
        txtVille.TabIndex = 14
        ' 
        ' txtAdresse
        ' 
        txtAdresse.Location = New Point(428, 13)
        txtAdresse.Margin = New Padding(3, 2, 3, 2)
        txtAdresse.Name = "txtAdresse"
        txtAdresse.Size = New Size(220, 23)
        txtAdresse.TabIndex = 13
        ' 
        ' txtNom
        ' 
        txtNom.Location = New Point(96, 95)
        txtNom.Margin = New Padding(3, 2, 3, 2)
        txtNom.Name = "txtNom"
        txtNom.Size = New Size(220, 23)
        txtNom.TabIndex = 12
        ' 
        ' txtPrenom
        ' 
        txtPrenom.Location = New Point(96, 68)
        txtPrenom.Margin = New Padding(3, 2, 3, 2)
        txtPrenom.Name = "txtPrenom"
        txtPrenom.Size = New Size(220, 23)
        txtPrenom.TabIndex = 11
        ' 
        ' txtDA
        ' 
        txtDA.Enabled = False
        txtDA.Location = New Point(96, 14)
        txtDA.Margin = New Padding(3, 2, 3, 2)
        txtDA.Name = "txtDA"
        txtDA.Size = New Size(220, 23)
        txtDA.TabIndex = 10
        ' 
        ' lblProvince
        ' 
        lblProvince.Location = New Point(332, 69)
        lblProvince.Name = "lblProvince"
        lblProvince.Size = New Size(90, 25)
        lblProvince.TabIndex = 8
        lblProvince.Text = "Province"
        lblProvince.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblTelephone
        ' 
        lblTelephone.Location = New Point(332, 122)
        lblTelephone.Name = "lblTelephone"
        lblTelephone.Size = New Size(90, 25)
        lblTelephone.TabIndex = 7
        lblTelephone.Text = "Telephone"
        lblTelephone.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblAdresse
        ' 
        lblAdresse.Location = New Point(332, 11)
        lblAdresse.Name = "lblAdresse"
        lblAdresse.Size = New Size(90, 25)
        lblAdresse.TabIndex = 4
        lblAdresse.Text = "Adresse"
        lblAdresse.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblNom
        ' 
        lblNom.Location = New Point(0, 93)
        lblNom.Name = "lblNom"
        lblNom.Size = New Size(90, 25)
        lblNom.TabIndex = 3
        lblNom.Text = "Nom"
        lblNom.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblPrenom
        ' 
        lblPrenom.Location = New Point(6, 68)
        lblPrenom.Name = "lblPrenom"
        lblPrenom.Size = New Size(90, 25)
        lblPrenom.TabIndex = 2
        lblPrenom.Text = "Prénom"
        lblPrenom.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblDA
        ' 
        lblDA.Location = New Point(2, 13)
        lblDA.Name = "lblDA"
        lblDA.Size = New Size(90, 25)
        lblDA.TabIndex = 1
        lblDA.Text = "ID"
        lblDA.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' dgvEtudiants
        ' 
        dgvEtudiants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEtudiants.Location = New Point(12, 222)
        dgvEtudiants.Name = "dgvEtudiants"
        dgvEtudiants.ReadOnly = True
        dgvEtudiants.RowTemplate.Height = 25
        dgvEtudiants.Size = New Size(1081, 372)
        dgvEtudiants.TabIndex = 8
        ' 
        ' grpNavigateur
        ' 
        grpNavigateur.Controls.Add(lblNavigateur)
        grpNavigateur.Controls.Add(btnDernier)
        grpNavigateur.Controls.Add(btnSuivant)
        grpNavigateur.Controls.Add(btnPrecedent)
        grpNavigateur.Controls.Add(btnPremier)
        grpNavigateur.Location = New Point(782, 3)
        grpNavigateur.Name = "grpNavigateur"
        grpNavigateur.Size = New Size(311, 113)
        grpNavigateur.TabIndex = 9
        grpNavigateur.TabStop = False
        grpNavigateur.Text = "Navigateur"
        ' 
        ' lblNavigateur
        ' 
        lblNavigateur.Location = New Point(78, 57)
        lblNavigateur.Name = "lblNavigateur"
        lblNavigateur.Size = New Size(146, 23)
        lblNavigateur.TabIndex = 4
        lblNavigateur.Text = "1 de ..."
        lblNavigateur.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnDernier
        ' 
        btnDernier.Location = New Point(230, 19)
        btnDernier.Name = "btnDernier"
        btnDernier.Size = New Size(70, 30)
        btnDernier.TabIndex = 3
        btnDernier.Text = ">>"
        btnDernier.UseVisualStyleBackColor = True
        ' 
        ' btnSuivant
        ' 
        btnSuivant.Location = New Point(154, 19)
        btnSuivant.Name = "btnSuivant"
        btnSuivant.Size = New Size(70, 30)
        btnSuivant.TabIndex = 2
        btnSuivant.Text = ">"
        btnSuivant.UseVisualStyleBackColor = True
        ' 
        ' btnPrecedent
        ' 
        btnPrecedent.Location = New Point(78, 19)
        btnPrecedent.Name = "btnPrecedent"
        btnPrecedent.Size = New Size(70, 30)
        btnPrecedent.TabIndex = 1
        btnPrecedent.Text = "<"
        btnPrecedent.UseVisualStyleBackColor = True
        ' 
        ' btnPremier
        ' 
        btnPremier.Location = New Point(6, 19)
        btnPremier.Name = "btnPremier"
        btnPremier.Size = New Size(70, 30)
        btnPremier.TabIndex = 0
        btnPremier.Text = "<<"
        btnPremier.UseVisualStyleBackColor = True
        ' 
        ' frmGestionEtudiants
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(1105, 606)
        Controls.Add(grpNavigateur)
        Controls.Add(dgvEtudiants)
        Controls.Add(gbBoutons)
        Controls.Add(grpInscriptionEtudiant)
        Name = "frmGestionEtudiants"
        Text = "Gestion des étudiants"
        gbBoutons.ResumeLayout(False)
        grpInscriptionEtudiant.ResumeLayout(False)
        grpInscriptionEtudiant.PerformLayout()
        grpSexe.ResumeLayout(False)
        grpSexe.PerformLayout()
        CType(dgvEtudiants, ComponentModel.ISupportInitialize).EndInit()
        grpNavigateur.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents gbBoutons As GroupBox
    Friend WithEvents btnEnlever As Button
    Friend WithEvents btnModifier As Button
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents btnNouveau As Button
    Friend WithEvents grpInscriptionEtudiant As GroupBox
    Friend WithEvents cbProvince As ComboBox
    Friend WithEvents mskTelephone As MaskedTextBox
    Friend WithEvents mskCodePostal As MaskedTextBox
    Friend WithEvents lblVille As Label
    Friend WithEvents lblCP As Label
    Friend WithEvents txtVille As TextBox
    Friend WithEvents txtAdresse As TextBox
    Friend WithEvents txtNom As TextBox
    Friend WithEvents txtPrenom As TextBox
    Friend WithEvents txtDA As TextBox
    Friend WithEvents lblProvince As Label
    Friend WithEvents lblTelephone As Label
    Friend WithEvents lblAdresse As Label
    Friend WithEvents lblNom As Label
    Friend WithEvents lblPrenom As Label
    Friend WithEvents lblDA As Label
    Friend WithEvents cbProgramme As ComboBox
    Friend WithEvents lblProgramme As Label
    Friend WithEvents grpSexe As GroupBox
    Friend WithEvents rdbMasculin As RadioButton
    Friend WithEvents rdbFeminin As RadioButton
    Friend WithEvents dgvEtudiants As DataGridView
    Friend WithEvents grpNavigateur As GroupBox
    Friend WithEvents btnDernier As Button
    Friend WithEvents btnSuivant As Button
    Friend WithEvents btnPrecedent As Button
    Friend WithEvents btnPremier As Button
    Friend WithEvents lblNavigateur As Label
End Class
