<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListeDesProgrammes
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
        dgvProgrammes = New DataGridView()
        CType(dgvProgrammes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvProgrammes
        ' 
        dgvProgrammes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvProgrammes.BackgroundColor = Color.FromArgb(CByte(133), CByte(164), CByte(167))
        dgvProgrammes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProgrammes.Location = New Point(12, 12)
        dgvProgrammes.Name = "dgvProgrammes"
        dgvProgrammes.ReadOnly = True
        dgvProgrammes.RowTemplate.Height = 25
        dgvProgrammes.Size = New Size(635, 482)
        dgvProgrammes.TabIndex = 0
        ' 
        ' frmListeDesProgrammes
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(47), CByte(134), CByte(88))
        ClientSize = New Size(659, 506)
        Controls.Add(dgvProgrammes)
        Name = "frmListeDesProgrammes"
        Text = "Liste des programmes"
        CType(dgvProgrammes, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvProgrammes As DataGridView
    Friend WithEvents mnuStripListeDesProgrammes As MenuStrip
End Class
