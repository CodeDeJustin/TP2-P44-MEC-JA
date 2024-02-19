USE Master
GO
if exists(SELECT Name from master..sysdatabases WHERE Name LIKE 'tp_p44')
BEGIN
	print '***********************************************************************************************'
	print 'Suppression de la base de données tp_p44 existante...'
	print '***********************************************************************************************'
	Drop Database tp_p44
END


/* *********************************************************************************************** */
print ' '
print '***********************************************************************************************'
print 'Création de la base de données tp_p44 en cours...'
print '***********************************************************************************************'
GO



Create Database tp_p44
GO
USE tp_p44
GO


/*********************** T_programme **************************************/
Create Table T_programme
(
	[pro_no] 		 Varchar(6) 	NOT NULL PRIMARY KEY, 
	[pro_nom] 		 varchar(50) 	NOT NULL, 
	[pro_nbr_unites] 	 float 		NOT NULL, 
	[pro_nbr_heures] 	 int 
)

/*********************** T_etudiants **************************************/
Create Table T_etudiants
(
	[etu_da] 		 varchar(7) 	 	NOT NULL PRIMARY KEY, 
	[pro_no] 		 Varchar(6) 		NOT NULL,
	[etu_nom] 		 varchar(20) 		NOT NULL, 
	[etu_prenom] 	 varchar(20) 		NOT NULL, 
	[etu_sexe]		 char(1),
	[etu_adresse] 	 varchar(100),
	[etu_ville] 	 varchar(50)		Default ('Chicoutimi'),
	[etu_province] 	 varchar(50)		Default ('Québec'),
	[etu_telephone]    varchar(14),
	[etu_codepostal]   varchar(7)
)


GO


/********************** FORMATS DE SAISIE  ***************************/
ALTER TABLE [T_etudiants]
 ADD CONSTRAINT [Telephone_Masque] CHECK (etu_telephone LIKE '([0-9][0-9][0-9]) [0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]')
ALTER TABLE [T_etudiants]
 ADD CONSTRAINT [CodePostal_Masque] CHECK ([etu_CodePostal] LIKE '[A-Z][0-9][A-Z]-[0-9][A-Z][0-9]')
ALTER TABLE [T_etudiants]
 ADD CONSTRAINT [Sexe_ck] CHECK ([etu_sexe] in ('M','F'))
GO


/********************** INTÉGRITÉ RÉFÉRENTIELLE **********************/
ALTER TABLE [T_etudiants] 
 ADD CONSTRAINT [FK_pro_no001] foreign key ([pro_no]) references [T_programme]([pro_no])

GO



/* *********************************************************************************************** */
print ' '
print '***********************************************************************************************'
print 'Ajout d`enregistrements de base...'
print '***********************************************************************************************'
GO

print ' '
print '***********************************************************************************************'
print 'Ajout de T_programme...'
print '***********************************************************************************************'
GO
insert into [T_programme] (pro_no,pro_nom, pro_nbr_unites, pro_nbr_heures) VALUES ('LEA.1A', 'Programmeur analyste', 53.66, 1575)
insert into [T_programme] (pro_no,pro_nom, pro_nbr_unites, pro_nbr_heures) VALUES ('LEA.1B', 'Gestion de réseaux', 53.66, 1575)
GO
print ' '
print '***********************************************************************************************'
print 'Ajout de T_etudiants...'
print '***********************************************************************************************'
GO
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234560', 'LEA.1A', 'Tremblay','Robert','M','55 rue de l`esperanto',  default, default , '(418) 882-0011','G1H-8Y3')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234561', 'LEA.1A', 'Tremblay','Suzanne','F','1055 Racine',  'LaBaie', default , '(418) 882-1234','G7H-2Y3')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234562', 'LEA.1A', 'Simard','Nicole','F','33 Bégin',  'jonquière', default , '(418) 544-1292','G7H-2R5')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234563', 'LEA.1A', 'Potvin','Michel','M','44 rue des sapins',  default, default , '(418) 549-1244','G7H-8X8')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234564', 'LEA.1A', 'Gagnon','Pierre','M','525 des perdrix',  'Alma', default , '(418) 678-1111','G4H-4F3')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234565', 'LEA.1B', 'Gagnon','Paul','M','22 des prés',  default, default , '(418) 532-2222','G3A-2S3')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234566', 'LEA.1B', 'Gagné','Nicole','F','467 de la réserve',  'Alma', default , '(418) 555-3333','G4H-4T5')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234567', 'LEA.1B', 'Ferland','Martine','F','234 de la montagne',  default, default , '(417) 547-4444','G6H-9J9')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234568', 'LEA.1B', 'Côté','Benoit','M','1200 du pont',  'Alma', default , '(417) 333-5555','H0H-3D3')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234569', 'LEA.1B', 'Bouchard','Alain','M','77 des peupliers',  'LaBaie', default , '(418) 544-8888','X1H-2W2')
insert into [T_etudiants] (etu_da, pro_no, etu_nom, etu_prenom, etu_sexe, etu_Adresse, etu_Ville, etu_province, etu_telephone, etu_CodePostal) VALUES ('1234570', 'LEA.1B', 'Bouchard','Jean','M','999 des roses',  'LaBaie', default , '(418) 544-8899','R5R-7Y6')

GO



Select 'Base de données tp_p44 créée'
print ' '
print '***********************************************************************************************'
print 'Base de données tp_p44 créée...'
print '***********************************************************************************************'
GO