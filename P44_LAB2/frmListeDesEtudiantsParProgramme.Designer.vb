<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListeEtuParProg
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
        dgvEtuParProg = New DataGridView()
        btnExport = New Button()
        CType(dgvEtuParProg, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvEtuParProg
        ' 
        dgvEtuParProg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvEtuParProg.BackgroundColor = Color.FromArgb(CByte(131), CByte(158), CByte(203))
        dgvEtuParProg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEtuParProg.Location = New Point(12, 67)
        dgvEtuParProg.Name = "dgvEtuParProg"
        dgvEtuParProg.ReadOnly = True
        dgvEtuParProg.RowTemplate.Height = 25
        dgvEtuParProg.Size = New Size(696, 426)
        dgvEtuParProg.TabIndex = 0
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnExport.Location = New Point(12, 12)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(113, 45)
        btnExport.TabIndex = 2
        btnExport.Text = "Exporter"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' frmListeEtuParProg
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(44), CByte(67), CByte(105))
        ClientSize = New Size(720, 505)
        Controls.Add(btnExport)
        Controls.Add(dgvEtuParProg)
        Name = "frmListeEtuParProg"
        Text = "Liste des étudiants par programme"
        CType(dgvEtuParProg, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvEtuParProg As DataGridView
    Friend WithEvents btnExport As Button
End Class
