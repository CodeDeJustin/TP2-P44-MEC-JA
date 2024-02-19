<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestionProgramme
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
        gpBxProgramme = New GroupBox()
        mskNombreHeures = New MaskedTextBox()
        mskNombreUnites = New MaskedTextBox()
        mskNumeroProgramme = New MaskedTextBox()
        txtNomProgramme = New TextBox()
        lblNombreHeure = New Label()
        lblNombreUnites = New Label()
        lblNomProgramme = New Label()
        lblNumeroProgramme = New Label()
        btnNouveau = New Button()
        btnOK = New Button()
        btnAnnuler = New Button()
        btnModifier = New Button()
        btnEnlever = New Button()
        dgvProgramme = New DataGridView()
        dgvEtudiantsParProgrammes = New DataGridView()
        gpBxProgramme.SuspendLayout()
        CType(dgvProgramme, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvEtudiantsParProgrammes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' gpBxProgramme
        ' 
        gpBxProgramme.Controls.Add(mskNombreHeures)
        gpBxProgramme.Controls.Add(mskNombreUnites)
        gpBxProgramme.Controls.Add(mskNumeroProgramme)
        gpBxProgramme.Controls.Add(txtNomProgramme)
        gpBxProgramme.Controls.Add(lblNombreHeure)
        gpBxProgramme.Controls.Add(lblNombreUnites)
        gpBxProgramme.Controls.Add(lblNomProgramme)
        gpBxProgramme.Controls.Add(lblNumeroProgramme)
        gpBxProgramme.Location = New Point(13, 12)
        gpBxProgramme.Margin = New Padding(4)
        gpBxProgramme.Name = "gpBxProgramme"
        gpBxProgramme.Padding = New Padding(4)
        gpBxProgramme.Size = New Size(454, 200)
        gpBxProgramme.TabIndex = 0
        gpBxProgramme.TabStop = False
        gpBxProgramme.Text = "Programme"
        ' 
        ' mskNombreHeures
        ' 
        mskNombreHeures.Location = New Point(216, 141)
        mskNombreHeures.Name = "mskNombreHeures"
        mskNombreHeures.Size = New Size(212, 26)
        mskNombreHeures.TabIndex = 7
        ' 
        ' mskNombreUnites
        ' 
        mskNombreUnites.Location = New Point(216, 104)
        mskNombreUnites.Name = "mskNombreUnites"
        mskNombreUnites.Size = New Size(212, 26)
        mskNombreUnites.TabIndex = 6
        ' 
        ' mskNumeroProgramme
        ' 
        mskNumeroProgramme.Location = New Point(216, 34)
        mskNumeroProgramme.Mask = ">LLL.0L"
        mskNumeroProgramme.Name = "mskNumeroProgramme"
        mskNumeroProgramme.Size = New Size(212, 26)
        mskNumeroProgramme.TabIndex = 5
        ' 
        ' txtNomProgramme
        ' 
        txtNomProgramme.Location = New Point(216, 69)
        txtNomProgramme.Name = "txtNomProgramme"
        txtNomProgramme.Size = New Size(212, 26)
        txtNomProgramme.TabIndex = 4
        ' 
        ' lblNombreHeure
        ' 
        lblNombreHeure.Location = New Point(7, 141)
        lblNombreHeure.Name = "lblNombreHeure"
        lblNombreHeure.Size = New Size(181, 26)
        lblNombreHeure.TabIndex = 3
        lblNombreHeure.Text = "Nbr heures :"
        ' 
        ' lblNombreUnites
        ' 
        lblNombreUnites.Location = New Point(7, 104)
        lblNombreUnites.Name = "lblNombreUnites"
        lblNombreUnites.Size = New Size(181, 26)
        lblNombreUnites.TabIndex = 2
        lblNombreUnites.Text = "Nbr d'unités :"
        ' 
        ' lblNomProgramme
        ' 
        lblNomProgramme.Location = New Point(7, 69)
        lblNomProgramme.Name = "lblNomProgramme"
        lblNomProgramme.Size = New Size(181, 26)
        lblNomProgramme.TabIndex = 1
        lblNomProgramme.Text = "Nom du Programme :"
        ' 
        ' lblNumeroProgramme
        ' 
        lblNumeroProgramme.Location = New Point(7, 34)
        lblNumeroProgramme.Name = "lblNumeroProgramme"
        lblNumeroProgramme.Size = New Size(181, 26)
        lblNumeroProgramme.TabIndex = 0
        lblNumeroProgramme.Text = "No : "
        ' 
        ' btnNouveau
        ' 
        btnNouveau.Location = New Point(474, 22)
        btnNouveau.Name = "btnNouveau"
        btnNouveau.Size = New Size(121, 33)
        btnNouveau.TabIndex = 3
        btnNouveau.Text = "Nouveau"
        btnNouveau.UseVisualStyleBackColor = True
        ' 
        ' btnOK
        ' 
        btnOK.Enabled = False
        btnOK.Location = New Point(474, 61)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(121, 33)
        btnOK.TabIndex = 4
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' btnAnnuler
        ' 
        btnAnnuler.Enabled = False
        btnAnnuler.Location = New Point(474, 100)
        btnAnnuler.Name = "btnAnnuler"
        btnAnnuler.Size = New Size(121, 33)
        btnAnnuler.TabIndex = 5
        btnAnnuler.Text = "Annuler"
        btnAnnuler.UseVisualStyleBackColor = True
        ' 
        ' btnModifier
        ' 
        btnModifier.Location = New Point(474, 139)
        btnModifier.Name = "btnModifier"
        btnModifier.Size = New Size(121, 33)
        btnModifier.TabIndex = 6
        btnModifier.Text = "Modifier"
        btnModifier.UseVisualStyleBackColor = True
        ' 
        ' btnEnlever
        ' 
        btnEnlever.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnEnlever.Location = New Point(474, 178)
        btnEnlever.Name = "btnEnlever"
        btnEnlever.Size = New Size(121, 33)
        btnEnlever.TabIndex = 7
        btnEnlever.Text = "Enlever"
        btnEnlever.UseVisualStyleBackColor = False
        ' 
        ' dgvProgramme
        ' 
        dgvProgramme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProgramme.Location = New Point(13, 219)
        dgvProgramme.Name = "dgvProgramme"
        dgvProgramme.RowTemplate.Height = 25
        dgvProgramme.Size = New Size(650, 343)
        dgvProgramme.TabIndex = 8
        ' 
        ' dgvEtudiantsParProgrammes
        ' 
        dgvEtudiantsParProgrammes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEtudiantsParProgrammes.Location = New Point(669, 12)
        dgvEtudiantsParProgrammes.Name = "dgvEtudiantsParProgrammes"
        dgvEtudiantsParProgrammes.RowTemplate.Height = 25
        dgvEtudiantsParProgrammes.Size = New Size(1007, 550)
        dgvEtudiantsParProgrammes.TabIndex = 9
        ' 
        ' frmGestionProgramme
        ' 
        AutoScaleDimensions = New SizeF(10F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SlateGray
        ClientSize = New Size(1688, 574)
        Controls.Add(dgvEtudiantsParProgrammes)
        Controls.Add(dgvProgramme)
        Controls.Add(btnEnlever)
        Controls.Add(btnModifier)
        Controls.Add(btnAnnuler)
        Controls.Add(btnOK)
        Controls.Add(btnNouveau)
        Controls.Add(gpBxProgramme)
        Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Margin = New Padding(4)
        Name = "frmGestionProgramme"
        Text = "Gestion des programmes"
        WindowState = FormWindowState.Maximized
        gpBxProgramme.ResumeLayout(False)
        gpBxProgramme.PerformLayout()
        CType(dgvProgramme, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvEtudiantsParProgrammes, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents gpBxProgramme As GroupBox
    Friend WithEvents mskNombreHeures As MaskedTextBox
    Friend WithEvents mskNombreUnites As MaskedTextBox
    Friend WithEvents mskNumeroProgramme As MaskedTextBox
    Friend WithEvents txtNomProgramme As TextBox
    Friend WithEvents lblNombreHeure As Label
    Friend WithEvents lblNombreUnites As Label
    Friend WithEvents lblNomProgramme As Label
    Friend WithEvents lblNumeroProgramme As Label
    Friend WithEvents btnNouveau As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents btnModifier As Button
    Friend WithEvents btnEnlever As Button
    Friend WithEvents dgvProgramme As DataGridView
    Friend WithEvents dgvEtudiantsParProgrammes As DataGridView
End Class
