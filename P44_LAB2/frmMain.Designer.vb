<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        mnuGestion = New MenuStrip()
        mnuGestionMain = New ToolStripMenuItem()
        mnuProgramme = New ToolStripMenuItem()
        mnuEtudiants = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        mnuQuitter = New ToolStripMenuItem()
        mnuRapport = New ToolStripMenuItem()
        mnuListeProgramme = New ToolStripMenuItem()
        mnuListeEtudiants = New ToolStripMenuItem()
        mnuListeEtuParProg = New ToolStripMenuItem()
        mnuGestion.SuspendLayout()
        SuspendLayout()
        ' 
        ' mnuGestion
        ' 
        mnuGestion.Items.AddRange(New ToolStripItem() {mnuGestionMain, mnuRapport})
        mnuGestion.Location = New Point(0, 0)
        mnuGestion.Name = "mnuGestion"
        mnuGestion.Size = New Size(1904, 24)
        mnuGestion.TabIndex = 0
        mnuGestion.Text = "MenuStrip1"' 
        ' mnuGestionMain
        ' 
        mnuGestionMain.DropDownItems.AddRange(New ToolStripItem() {mnuProgramme, mnuEtudiants, ToolStripMenuItem1, mnuQuitter})
        mnuGestionMain.Name = "mnuGestionMain"
        mnuGestionMain.Size = New Size(59, 20)
        mnuGestionMain.Text = "Gestion"' 
        ' mnuProgramme
        ' 
        mnuProgramme.Name = "mnuProgramme"
        mnuProgramme.Size = New Size(145, 22)
        mnuProgramme.Text = "Programmes "' 
        ' mnuEtudiants
        ' 
        mnuEtudiants.Name = "mnuEtudiants"
        mnuEtudiants.Size = New Size(145, 22)
        mnuEtudiants.Text = "Étudiants"' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(142, 6)
        ' 
        ' mnuQuitter
        ' 
        mnuQuitter.Name = "mnuQuitter"
        mnuQuitter.Size = New Size(145, 22)
        mnuQuitter.Text = "Quitter"' 
        ' mnuRapport
        ' 
        mnuRapport.DropDownItems.AddRange(New ToolStripItem() {mnuListeProgramme, mnuListeEtudiants, mnuListeEtuParProg})
        mnuRapport.Name = "mnuRapport"
        mnuRapport.Size = New Size(66, 20)
        mnuRapport.Text = "Rapports"' 
        ' mnuListeProgramme
        ' 
        mnuListeProgramme.Name = "mnuListeProgramme"
        mnuListeProgramme.Size = New Size(257, 22)
        mnuListeProgramme.Text = "Liste des Programmes"' 
        ' mnuListeEtudiants
        ' 
        mnuListeEtudiants.Name = "mnuListeEtudiants"
        mnuListeEtudiants.Size = New Size(257, 22)
        mnuListeEtudiants.Text = "Liste des étudiants"' 
        ' mnuListeEtuParProg
        ' 
        mnuListeEtuParProg.Name = "mnuListeEtuParProg"
        mnuListeEtuParProg.Size = New Size(257, 22)
        mnuListeEtuParProg.Text = "Liste des étudiants par programme"' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1904, 1041)
        Controls.Add(mnuGestion)
        IsMdiContainer = True
        MainMenuStrip = mnuGestion
        Name = "frmMain"
        Text = "Gestion"
        mnuGestion.ResumeLayout(False)
        mnuGestion.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents mnuGestion As MenuStrip
    Friend WithEvents mnuGestionMain As ToolStripMenuItem
    Friend WithEvents mnuProgramme As ToolStripMenuItem
    Friend WithEvents mnuEtudiants As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuQuitter As ToolStripMenuItem
    Friend WithEvents mnuRapport As ToolStripMenuItem
    Friend WithEvents mnuListeProgramme As ToolStripMenuItem
    Friend WithEvents mnuListeEtudiants As ToolStripMenuItem
    Friend WithEvents mnuListeEtuParProg As ToolStripMenuItem
End Class
