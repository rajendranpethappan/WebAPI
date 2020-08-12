Create DataBase CategoryDB
GO

Use CategoryDB 
GO

Create table Category(
	ID int primary key identity,
	CategoryName nvarchar(50))

Go

Insert into Category values ('Soap')
Insert into Category values ('Drinks')
GO


CREATE TABLE SubCategory (
    ID int primary key identity,    
    CategoryId int FOREIGN KEY REFERENCES Category(ID),
	SubCategoryName nvarchar(50)
);
GO

Insert into SubCategory values (1,'BathSoap')
Insert into SubCategory values (1,'WashingSoap')
Insert into SubCategory values (2,'HotDrinks')
Insert into SubCategory values (2,'CoolDrinks')
Go

CREATE TABLE Item (
    ID int primary key identity,    
    SubCategoryId int FOREIGN KEY REFERENCES SubCategory(ID),
	ItemName nvarchar(50),
	ItemDescription nvarchar(50),
);
GO

Insert into Item values (1,'Hamam','Hamam Soap')
Insert into Item values (2,'Rin','Rin soap')
Insert into Item values (1,'Rexona','Rexona Soap')
Insert into Item values (2,'SurfExcel','SurfExcel Soap')
Insert into Item values (1,'Hamam','Hamam Sample Soap')
Insert into Item values (2,'Rin','Rin Washing Soap')
Insert into Item values (1,'Rexona','Rexona Sample Soap')
Insert into Item values (1,'Tea','Hot Tea')
Insert into Item values (2,'Sprite','Cool Sprite')
Insert into Item values (1,'Coffee','Hot Coffee')
Insert into Item values (2,'Co-Cola','Cool Co-Cola')
Insert into Item values (1,'Soup','Hot Soup')
Insert into Item values (2,'Pepsi','Cocl Pepsi')

Go

