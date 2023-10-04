SELECT 
    SUM([Host].[DepositAmount] - [Guest].[DepositAmount]) AS [SumDifference] 
FROM 
    [WizzardDeposits] AS [Host] 
JOIN 
    [WizzardDeposits] AS [Guest] ON [Host].[Id] + 1 = [Guest].[Id] 