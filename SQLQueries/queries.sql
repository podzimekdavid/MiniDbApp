use ShopDatabase

-- Full name
select CONCAT(Customers.Name, ' ', Customers.Surname)
from Customers;

-- Customer order count
select COUNT(*) as OrderCount, C.Email as CustomerEmail
from Orders
         join Customers C on C.Email = Orders.CustomerId
group by C.Email
order by OrderCount

-- Customer orders total price
select ROUND(SUM(ProductInOrders.Quantity * P.Price), 2)                             as TotalOrdersPrice,
       ROUND(SUM(ProductInOrders.Quantity * (P.Price + (P.Price / 100 * P.Tax))), 2) as TotalOrdersPriceWithTax,
       C.Email                                                                       as CustomerEmail
from ProductInOrders
         join Orders O on O.OrderId = ProductInOrders.OrderId
         join Customers C on C.Email = O.CustomerId
         join Products P on P.ProductId = ProductInOrders.ProductId
group by C.Email
order by TotalOrdersPrice

-- Customer average order price
select ROUND(SUM(ProductInOrders.Quantity * P.Price) / COUNT(distinct O.OrderId), 2) as AvgOrderPrice,
       ROUND(SUM(ProductInOrders.Quantity * (P.Price + (P.Price / 100 * P.Tax))) / COUNT(distinct O.OrderId),
             2)                                                                      as AvgOrderPriceWithTax,
       C.Email
from ProductInOrders
         join Orders O ON O.OrderId = ProductInOrders.OrderId
         join Customers C ON C.Email = O.CustomerId
         join Products P ON P.ProductId = ProductInOrders.ProductId
group by C.Email
order by AvgOrderPrice

-- Customer with more that 2 orders
select *
from (select COUNT(*) as OrderCount, C.Email as CustomerEmail
      from Orders
               join Customers C on C.Email = Orders.CustomerId
      group by C.Email) as CustomersOrders
where OrderCount > 2
order by OrderCount

-- Customer with more that 100 average order price
select *
from (select ROUND(SUM(ProductInOrders.Quantity * P.Price) / COUNT(distinct O.OrderId), 2) as AvgOrderPrice,
             C.Email
      from ProductInOrders
               join Orders O on O.OrderId = ProductInOrders.OrderId
               join Customers C on C.Email = O.CustomerId
               join Products P on P.ProductId = ProductInOrders.ProductId
      group by C.Email) as CustomerOrders
where AvgOrderPrice > 100
order by AvgOrderPrice
