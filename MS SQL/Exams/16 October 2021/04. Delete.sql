DECLARE @adressesIds TABLE (Id INT)
INSERT INTO @adressesIds
SELECT Id FROM Addresses WHERE Country LIKE 'C%'

DECLARE @clientIds TABLE (Id INT)
INSERT INTO @clientIds
SELECT Id FROM Clients WHERE AddressId IN (SELECT * FROM @adressesIds)

DELETE FROM ClientsCigars WHERE ClientId IN (SELECT * FROM @clientIds)
DELETE FROM Clients WHERE AddressId IN (SELECT * FROM @adressesIds)
DELETE FROM Addresses WHERE Id IN (SELECT * FROM @adressesIds)