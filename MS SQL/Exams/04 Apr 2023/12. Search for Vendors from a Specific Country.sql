CREATE PROC usp_SearchByCountry(@country VARCHAR(10))
AS 
BEGIN 
    SELECT 
        V.[Name] AS Vendor,
        V.NumberVAT AS VAT,
        CONCAT(A.StreetName, ' ', A.StreetNumber) AS [Street Info],
        CONCAT(A.City, ' ', A.PostCode) AS [City Info]
    FROM 
        Countries AS C
    JOIN 
        Addresses AS A ON C.Id = A.CountryId
    JOIN 
        Vendors AS V ON V.AddressId = A.Id
    WHERE 
        C.[Name] = @country
    ORDER BY 
        V.[Name],
        A.City
END
