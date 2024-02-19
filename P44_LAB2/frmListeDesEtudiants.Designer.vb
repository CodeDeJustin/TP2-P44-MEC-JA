<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListeDesEtudiants
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
        dgvEtudiants = New DataGridView()
        grpRecherche = New GroupBox()
        txtRechercheAdresse = New TextBox()
        txtRecherchePrenom = New TextBox()
        txtRechercheNom = New TextBox()
        txtRechercheDA = New TextBox()
        lblRechercheAdresse = New Label()
        lblRecherchePrenom = New Label()
        lblRechercheNom = New Label()
        lblRechercheDA = New Label()
        CType(dgvEtudiants, ComponentModel.ISupportInitialize).BeginInit()
        grpRecherche.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvEtudiants
        ' 
        dgvEtudiants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvEtudiants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEtudiants.Location = New Point(15, 161)
        dgvEtudiants.Margin = New Padding(4)
        dgvEtudiants.Name = "dgvEtudiants"
        dgvEtudiants.ReadOnly = True
        dgvEtudiants.RowTemplate.Height = 25
        dgvEtudiants.Size = New Size(1360, 628)
        dgvEtudiants.TabIndex = 0
        ' 
        ' grpRecherche
        ' 
        grpRecherche.Controls.Add(txtRechercheAdresse)
        grpRecherche.Controls.Add(txtRecherchePrenom)
        grpRecherche.Controls.Add(txtRechercheNom)
        grpRecherche.Controls.Add(txtRechercheDA)
        grpRecherche.Controls.Add(lblRechercheAdresse)
        grpRecherche.Controls.Add(lblRecherchePrenom)
        grpRecherche.Controls.Add(lblRechercheNom)
        grpRecherche.Controls.Add(lblRechercheDA)
        grpRecherche.ForeColor = SystemColors.ButtonHighlight
        grpRecherche.Location = New Point(15, 17)
        grpRecherche.Margin = New Padding(4)
        grpRecherche.Name = "grpRecherche"
        grpRecherche.Padding = New Padding(4)
        grpRecherche.Size = New Size(1360, 136)
        grpRecherche.TabIndex = 1
        grpRecherche.TabStop = False
        grpRecherche.Text = "Recherche Étudiants"
        ' 
        ' txtRechercheAdresse
        ' 
        txtRechercheAdresse.Location = New Point(904, 87)
        txtRechercheAdresse.Margin = New Padding(4)
        txtRechercheAdresse.Name = "txtRechercheAdresse"
        txtRechercheAdresse.Size = New Size(200, 29)
        txtRechercheAdresse.TabIndex = 7
        ' 
        ' txtRecherchePrenom
        ' 
        txtRecherchePrenom.Location = New Point(904, 34)
        txtRecherchePrenom.Margin = New Padding(4)
        txtRecherchePrenom.Name = "txtRecherchePrenom"
        txtRecherchePrenom.Size = New Size(200, 29)
        txtRecherchePrenom.TabIndex = 6
        ' 
        ' txtRechercheNom
        ' 
        txtRechercheNom.Location = New Point(336, 87)
        txtRechercheNom.Margin = New Padding(4)
        txtRechercheNom.Name = "txtRechercheNom"
        txtRechercheNom.Size = New Size(200, 29)
        txtRechercheNom.TabIndex = 5
        ' 
        ' txtRechercheDA
        ' 
        txtRechercheDA.Location = New Point(336, 35)
        txtRechercheDA.Margin = New Padding(4)
        txtRechercheDA.Name = "txtRechercheDA"
        txtRechercheDA.Size = New Size(200, 29)
        txtRechercheDA.TabIndex = 4
        ' 
        ' lblRechercheAdresse
        ' 
        lblRechercheAdresse.ForeColor = SystemColors.ButtonHighlight
        lblRechercheAdresse.Location = New Point(716, 83)
        lblRechercheAdresse.Margin = New Padding(4, 0, 4, 0)
        lblRechercheAdresse.Name = "lblRechercheAdresse"
        lblRechercheAdresse.Size = New Size(180, 35)
        lblRechercheAdresse.TabIndex = 3
        lblRechercheAdresse.Text = "Recherche par Adresse: "
        lblRechercheAdresse.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblRecherchePrenom
        ' 
        lblRecherchePrenom.ForeColor = SystemColors.ButtonHighlight
        lblRecherchePrenom.Location = New Point(716, 31)
        lblRecherchePrenom.Margin = New Padding(4, 0, 4, 0)
        lblRecherchePrenom.Name = "lblRecherchePrenom"
        lblRecherchePrenom.Size = New Size(180, 35)
        lblRecherchePrenom.TabIndex = 2
        lblRecherchePrenom.Text = "Recherche par prénom:"
        lblRecherchePrenom.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblRechercheNom
        ' 
        lblRechercheNom.ForeColor = SystemColors.ButtonHighlight
        lblRechercheNom.Location = New Point(178, 83)
        lblRechercheNom.Margin = New Padding(4, 0, 4, 0)
        lblRechercheNom.Name = "lblRechercheNom"
        lblRechercheNom.Size = New Size(150, 35)
        lblRechercheNom.TabIndex = 1
        lblRechercheNom.Text = "Recherche par nom:"
        lblRechercheNom.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblRechercheDA
        ' 
        lblRechercheDA.ForeColor = SystemColors.ButtonHighlight
        lblRechercheDA.Location = New Point(178, 32)
        lblRechercheDA.Margin = New Padding(4, 0, 4, 0)
        lblRechercheDA.Name = "lblRechercheDA"
        lblRechercheDA.Size = New Size(150, 35)
        lblRechercheDA.TabIndex = 0
        lblRechercheDA.Text = "Recherche par DA:"
        lblRechercheDA.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' frmListeDesEtudiants
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        ClientSize = New Size(1391, 806)
        Controls.Add(grpRecherche)
        Controls.Add(dgvEtudiants)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Margin = New Padding(4)
        Name = "frmListeDesEtudiants"
        Text = "Liste Des Etudiants"
        CType(dgvEtudiants, ComponentModel.ISupportInitialize).EndInit()
        grpRecherche.ResumeLayout(False)
        grpRecherche.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvEtudiants As DataGridView
    Friend WithEvents grpRecherche As GroupBox
    Friend WithEvents lblRechercheAdresse As Label
    Friend WithEvents lblRecherchePrenom As Label
    Friend WithEvents lblRechercheNom As Label
    Friend WithEvents lblRechercheDA As Label
    Friend WithEvents txtRechercheAdresse As TextBox
    Friend WithEvents txtRecherchePrenom As TextBox
    Friend WithEvents txtRechercheNom As TextBox
    Friend WithEvents txtRechercheDA As TextBox
End Class
