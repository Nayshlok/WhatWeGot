CREATE TABLE [dbo].[Category]
(
	[CategoryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryName] VARCHAR(50) NOT NULL, 
    [CategoryDescription] VARCHAR(200) NOT NULL
)
