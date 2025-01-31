create table Customers
(
    Email   nvarchar(450) not null
        constraint PK_Customers
            primary key,
    Name    nvarchar(max) not null,
    Surname nvarchar(max) not null
)
    go

create table Orders
(
    OrderId    uniqueidentifier not null
        constraint PK_Orders
            primary key,
    CustomerId nvarchar(450)    not null
        constraint FK_Orders_Customers_CustomerId
            references Customers
            on delete cascade,
    Created    datetime2        not null
)
    go

create index IX_Orders_CustomerId
    on Orders (CustomerId)
    go

create table Products
(
    ProductId uniqueidentifier not null
        constraint PK_Products
            primary key,
    Name      nvarchar(max)    not null,
    Price     decimal(18, 2)   not null,
    Tax       decimal(18, 2)   not null
)
    go

create table ProductInOrders
(
    OrderId   uniqueidentifier not null
        constraint FK_ProductInOrders_Orders_OrderId
            references Orders
            on delete cascade,
    ProductId uniqueidentifier not null
        constraint FK_ProductInOrders_Products_ProductId
            references Products
            on delete cascade,
    Quantity  int              not null,
    constraint PK_ProductInOrders
        primary key (OrderId, ProductId)
)
    go

create index IX_ProductInOrders_ProductId
    on ProductInOrders (ProductId)
    go


