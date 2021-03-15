create database TruYumFinal
use TruYumFinal

create table Category (
CategoryId int PRIMARY KEY IDENTITY,
Name varchar(30))

create table MenuItem(
MenuItemId int PRIMARY KEY IDENTITY,
Name varchar(30) NOT NULL,
Price float NOT NULL,
Active BIT NOT NULL,
DateOfLaunch datetime NOT NULL,
CategoryId int NOT NULL,
FreeDelivery BIT NOT NULL,
FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
)
ALTER TABLE MenuItem
ADD UNIQUE (Name);

create table Cart(
CartId int PRIMARY KEY IDENTITY,
MenuItemId int NOT NULL,
FOREIGN KEY (MenuItemId) REFERENCES MenuItem(MenuItemId)
)

SELECT * from Cart;
SELECT * from MenuItem;
SELECT * from Category;

insert into Category(Name) values ('Main Course'), ('Starters'), ('Snacks'), ('Dessert')