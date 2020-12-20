/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO Conditions AS Target
USING (VALUES
        (1, 'Nauja'),
        (2, 'Dėvėta'),
        (3, 'Sena')
)
AS Source (Id, Name)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name) 
VALUES (Name);

MERGE INTO Duties AS Target
USING (VALUES
        (1, 'Ūkvedys'),
        (2, 'Administratorius')
)
AS Source (Id, Name)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name) 
VALUES (Name);

MERGE INTO Statuses AS Target
USING (VALUES
        (1, 'Laukiama'),
        (2, 'Patvirtinta'),
        (3, 'Atšaukta')
)
AS Source (Id, Name)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name) 
VALUES (Name);

MERGE INTO Genres AS Target
USING (VALUES
        (1, 'Nuotykiai'),
        (2, 'Biografija'),
        (3, 'Fantastika'),
        (4, 'Romanas'),
        (5, 'Drama'),
        (6, 'Apysaka'),
        (7, 'Legenda'),
        (8, 'Padavimas')
)
AS Source (Id, Name)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name) 
VALUES (Name);