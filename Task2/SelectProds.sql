WITH CTE_Prods (productid, datetime)
AS
(
	SELECT productid, MIN(datetime)
	FROM Sales
	GROUP BY productid
)

SELECT s.productid, COUNT(p.customerid)
FROM Sales s
INNER JOIN CTE_Prods p ON s.productid = p.productid AND p.datetime = s.datetime
GROUP BY s.productid
