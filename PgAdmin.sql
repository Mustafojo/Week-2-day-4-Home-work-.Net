create table Customers
(
	CustomerId serial primary key,
	FullName varchar,
	Email varchar,
	Address varchar
);

create table Products
(
	ProductId serial primary key,
	ProductName varchar,
	Price decimal,
	StockQuantity int
);

create table Orders
(
	OrderId serial primary key,
	CustomerId int references Customers(CustomerId),
	Data date,
	Amount decimal
);

create table OrderDetails
(
	OrderDetailId serial primary key,
	OrderId int references Orders(OrderId),
	ProductId int references Products(ProductId),
	Quantity int,
	UnitPrice decimal
);





