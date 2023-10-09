﻿CREATE TABLE Monasteries 
(
    [Id] INT PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [CountryCode] CHAR(2) NOT NULL FOREIGN KEY REFERENCES Countries(CountryCode)
)
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

--ALTER TABLE [Countries]
--ADD [IsDeleted] BIT

--UPDATE [Countries]
--SET [IsDeleted] = 0

UPDATE [Countries]
SET [IsDeleted] = 1
WHERE 
    [CountryCode] IN 
    (
        SELECT 
            [CR].[CountryCode] 
        FROM 
            [Countries] AS [C]
        JOIN 
            [CountriesRivers] AS [CR] ON [C].[CountryCode] = [CR].[CountryCode]
        GROUP BY 
            [CR].[CountryCode]
        HAVING 
            COUNT([CR].[RiverId]) > 3
    )

SELECT 
    [M].[Name] AS [Monastery], 
    [C].[CountryName] AS [Country]
FROM 
    [Monasteries] AS [M]
JOIN 
    [Countries] AS [C] ON [M].[CountryCode] = [C].[CountryCode]
WHERE 
    [C].[IsDeleted] = 0
ORDER BY 
    [M].[Name]