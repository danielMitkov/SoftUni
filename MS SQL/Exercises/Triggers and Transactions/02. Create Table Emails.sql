CREATE TRIGGER tr_createEmailOnNewLog
ON [Logs] FOR INSERT 
AS 
INSERT INTO [NotificationEmails] VALUES
(
    (SELECT [AccountId] FROM inserted),

    (SELECT CONCAT_WS
    (
        ' ', 
        'Balance change for account:', 
        [AccountId]
    ) 
    FROM inserted),

    (SELECT CONCAT_WS
    (
        ' ', 
        'On', 
        GETDATE(), 
        'your balance was changed from', 
        [OldSum], 
        'to', 
        [NewSum]
    ) 
    FROM inserted)
)