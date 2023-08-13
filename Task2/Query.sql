SELECT TOP 3
    s.[id] AS stid,
    s.[Name],
    AVG(ss.[Grade]) AS AvgGrade
FROM
    [dbo].[Students] s
INNER JOIN
    [dbo].[stsub] ss ON s.[id] = ss.[stid]
GROUP BY
    s.[id], s.[Name]
HAVING
    AVG(ss.[Grade]) > 5
ORDER BY
    AvgGrade DESC;
