DECLARE @prizeIds TABLE (Id INT)
INSERT INTO @prizeIds
SELECT 
    Id
FROM 
    BonusPrizes
WHERE 
    [Name] = 'Sleeping bag'

DELETE FROM 
    TouristsBonusPrizes
WHERE 
    BonusPrizeId IN (SELECT * FROM @prizeIds)

DELETE FROM 
    BonusPrizes
WHERE 
    Id IN (SELECT * FROM @prizeIds)