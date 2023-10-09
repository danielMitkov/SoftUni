SELECT 
    [CU].[CurrencyCode], 
    [CU].[Description] AS [Currency],
    COUNT([C].[CountryCode]) AS [NumberOfCountries]
FROM 
    [Currencies] AS [CU]
LEFT JOIN 
    [Countries] AS [C] ON [C].[CurrencyCode] = [CU].[CurrencyCode]
GROUP BY 
    [CU].[CurrencyCode],
    [CU].[Description]
ORDER BY 
    [NumberOfCountries] DESC, 
    [CU].[Description]