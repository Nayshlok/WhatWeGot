CREATE TABLE [dbo].[Ledger]
(
	[ItemID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ItemName] VARCHAR(50) NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [EventDate] DATE NOT NULL, 
    [LastUpdated] DATE NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Ledger_category] FOREIGN KEY (CategoryId) REFERENCES [Category]([CategoryId])
)
