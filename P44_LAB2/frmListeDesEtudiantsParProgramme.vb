'************************************************
'***************** COLLÈGE ABC ******************
'*** PROGRAMME PERMETTANT DE FAIRE LA GESTION DES
'*** PROGRAMMES ET DES ÉTUDIANTS EN UTILISANT LA
'*** BASE DE DONNÉES EXISTANTE DU COLLÈGE
'***
'************************************************
'*** CETTE PROGRAMMATION CI-DESSOUS EST DÉDIÉE À
'*** LA FENÊTRE ENFANT CONCERNANT LA LISTE DES
'*** ÉTUDIANTS PAR PROGRAMME
'*** 
'************************************************
'*** FAIT PAR:      Maryève Couture
'***                Justin Allard
'*** DATE:          2023-05-14
'*** RÉVISÉ PAR:
'*** DATE RÉVISION:
'************************************************

Imports System.IO
Imports Microsoft.Data.SqlClient

Public Class frmListeEtuParProg

    ' INITIALISATION DES VARIABLES ET OBJETS
    Dim dataSet As New DataSet("tp_p44")
    Dim connexion As New SqlConnection(My.Settings.ConnectionString)
    Dim tblEtuParProgSqlCommand = New SqlCommand("SELECT T_Programme.pro_no, T_Programme.Pro_nom, T_Etudiants.etu_da, T_Etudiants.etu_nom, T_Etudiants.etu_prenom FROM T_Programme INNER JOIN T_Etudiants ON T_Programme.pro_no = T_Etudiants.pro_no ORDER BY T_Programme.pro_no", connexion)
    Dim daTblEtuParProg = New SqlDataAdapter(tblEtuParProgSqlCommand)
    Dim bindSrcEtuParProg = New BindingSource()

    ' CHARGEMENT DU FORMULAIRE
    Private Sub frmListeEtuParProg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemplirDataGridViewEtuParProg()
    End Sub

    ' REMPLISSAGE DU DATAGRIDVIEW AVEC LES DONNÉES DES ÉTUDIANTS PAR PROGRAMME
    Private Sub RemplirDataGridViewEtuParProg()
        Try
            daTblEtuParProg.Fill(dataSet, "EtudiantsParProgramme")

            dgvEtuParProg.AutoGenerateColumns = True
            bindSrcEtuParProg.DataSource = dataSet
            bindSrcEtuParProg.DataMember = "EtudiantsParProgramme"
            dgvEtuParProg.DataSource = bindSrcEtuParProg

            dgvEtuParProg.Columns("pro_no").HeaderText = "Numéro du programme"
            dgvEtuParProg.Columns("Pro_nom").HeaderText = "Nom du programme"
            dgvEtuParProg.Columns("etu_da").HeaderText = "DA de l'étudiant"
            dgvEtuParProg.Columns("etu_nom").HeaderText = "Nom de l'étudiant"
            dgvEtuParProg.Columns("etu_prenom").HeaderText = "Prénom de l'étudiant"

        Catch ex As SqlException
            MessageBox.Show("Erreur SQL: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'GESTION D'EXPORTATION
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            ' Définir le contexte de licence pour EPPlus
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial

            Dim sfd As New SaveFileDialog()

            sfd.Filter = "CSV (*.csv)|*.csv|Excel (*.xlsx)|*.xlsx"
            sfd.FileName = "Output"

            If sfd.ShowDialog() = DialogResult.OK Then
                If Path.GetExtension(sfd.FileName).ToLower() = ".csv" Then
                    ' Exporter en CSV
                    Using sw As New StreamWriter(File.OpenWrite(sfd.FileName), New System.Text.UTF8Encoding(True))
                        Dim columnHeaders = From column As DataGridViewColumn In dgvEtuParProg.Columns.Cast(Of DataGridViewColumn)()
                                            Select EscapeCsvField(column.HeaderText)
                        sw.WriteLine(String.Join(",", columnHeaders))

                        For Each row As DataGridViewRow In dgvEtuParProg.Rows.Cast(Of DataGridViewRow)()
                            If Not row.IsNewRow Then
                                Dim fields = From cell As DataGridViewCell In row.Cells.Cast(Of DataGridViewCell)()
                                             Select EscapeCsvField(If(cell.Value IsNot Nothing, cell.Value.ToString(), String.Empty))
                                sw.WriteLine(String.Join(",", fields))
                            End If
                        Next
                    End Using
                ElseIf Path.GetExtension(sfd.FileName).ToLower() = ".xlsx" Then
                    ' Exporter en Excel
                    Using package As New OfficeOpenXml.ExcelPackage()
                        Dim worksheet = package.Workbook.Worksheets.Add("Sheet1")

                        For i = 0 To dgvEtuParProg.ColumnCount - 1
                            worksheet.Cells(1, i + 1).Value = dgvEtuParProg.Columns(i).HeaderText
                        Next

                        For i = 0 To dgvEtuParProg.Rows.Count - 1
                            For j = 0 To dgvEtuParProg.Columns.Count - 1
                                worksheet.Cells(i + 2, j + 1).Value = If(dgvEtuParProg.Rows(i).Cells(j).Value IsNot Nothing, dgvEtuParProg.Rows(i).Cells(j).Value.ToString(), String.Empty)
                            Next
                        Next

                        package.SaveAs(New FileInfo(sfd.FileName))
                    End Using
                End If

                MessageBox.Show("Exportation terminée avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function EscapeCsvField(field As String) As String
        If field.Contains(",") Or field.Contains("""") Then
            field = field.Replace("""", """""")  ' Double up any double-quotes
            field = """" & field & """"  ' Encase the entire field in double-quotes
        End If

        Return field
    End Function

    ' GESTION DE LA FERMETURE DU FORMULAIRE
    Private Sub frmListeEtuParProg_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dim result As DialogResult = MessageBox.Show("Voulez-vous vraiment quitter la liste des étudiants par programme?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.No Then
                e.Cancel = True
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class