select * from ProductTable

select ProductInStocks from ProductTable order by ProductInStocks desc
select MAX(ProductInStocks) from ProductTable
select MAX(ProductInStocks) from ProductTable where ProductInStocks<(select MAX(productInStocks) from ProductTable)