CREATE TRIGGER tr_logSumChange
ON [Accounts] FOR UPDATE 
AS 
INSERT INTO [Logs] VALUES 
(
    (SELECT [Id] FROM inserted),
    (SELECT [Balance] FROM deleted),
    (SELECT [Balance] FROM inserted)
)