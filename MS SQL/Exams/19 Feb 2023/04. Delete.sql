DECLARE @AddressIds TABLE (Id INT)
INSERT INTO @AddressIds
SELECT 
    Id
FROM 
    Addresses
WHERE 
    Town LIKE 'L%'

DECLARE @PublishersIds TABLE (Id INT)
INSERT INTO @PublishersIds
SELECT 
    Id
FROM 
    Publishers
WHERE 
    AddressId IN (SELECT * FROM @AddressIds)

DECLARE @BoardgamesIds TABLE (Id INT)
INSERT INTO @BoardgamesIds
SELECT 
    Id
FROM 
    Boardgames
WHERE 
    PublisherId IN (SELECT * FROM @PublishersIds)

DELETE FROM 
    CreatorsBoardgames
WHERE 
    BoardgameId IN (SELECT * FROM @BoardgamesIds)

DELETE FROM 
    Boardgames
WHERE 
    PublisherId IN (SELECT * FROM @PublishersIds)

DELETE FROM 
    Publishers
WHERE 
    AddressId IN (SELECT * FROM @AddressIds)

DELETE FROM 
    Addresses
WHERE 
    Id IN (SELECT * FROM @AddressIds)