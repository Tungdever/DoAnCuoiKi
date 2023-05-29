Create table tblMain
(
MainID int Primary key identity,
aDate date,
aTime Varchar(50),
TableName varchar(50),
WaiterName varchar(50),
Status varchar(15),
orderType varchar(20),
total float,
received float,
change float
)

Create Table tblDetails
(
DetailID int Primary key identity,
MainID int,
proID int,
qty int,
price float,
amount float,
)