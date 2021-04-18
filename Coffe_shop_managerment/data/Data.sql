CREATE DATABASE Coffe_shop_managerment
GO
USE Coffe_shop_managerment
GO
--========================== CREATE TABLE ============================

--Account 
CREATE	TABLE account
(
	userName NVARCHAR(100) PRIMARY KEY ,
	displayName NVARCHAR(100) NOT NULL,
	passWords NVARCHAR(100) DEFAULT 1 ,
	gender NVARCHAR(100),
	DOB NVARCHAR(100) NOT NULL,
	email NVARCHAR(100) NOT NULL,
	mobie NVARCHAR(100) NOT NULL,
	addresss NVARCHAR(100) NOT NULL,
	typeAccount INT NOT NULL DEFAULT 1, --1: admin || 0: staff
)
GO

--Table Drinks
CREATE TABLE tableDrinks
(
	idTable INT PRIMARY KEY,
	nameTable NVARCHAR(100) NOT NULL DEFAULT N'The table has no name',
	statusTable NVARCHAR(100) NOT NULL DEFAULT N'empty'
)
GO

--Categories
CREATE TABLE categories
(
	idCategories INT PRIMARY KEY,
	nameTypes NVARCHAR(100) NOT NULL
)
GO

--Drinks
CREATE TABLE drinks
(
	idDrinks INT PRIMARY KEY,
	idCategories INT FOREIGN KEY (idCategories) REFERENCES dbo.categories
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	nameDrinks NVARCHAR(100) NOT NULL,
	price INT NOT NULL DEFAULT 0
)
GO

--Bills
CREATE TABLE bills
(
	idBills INT IDENTITY(1,1) PRIMARY KEY,
	idTable INT FOREIGN KEY (idTable) REFERENCES dbo.tableDrinks
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	--idStaff NVARCHAR(100) FOREIGN KEY (idStaff) REFERENCES dbo.account
	--ON UPDATE CASCADE
	--ON DELETE CASCADE,
	dateCheckOut DATE ,
	dateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	price INT NOT NULL DEFAULT 0,
	statusBill INT NOT NULL DEFAULT 0, --o: unpaid || 1: paid
	discount INT DEFAULT 0
)
GO


CREATE TABLE detailBills
(
	idDetail INT IDENTITY(1,1) PRIMARY KEY,
	idBill INT FOREIGN KEY (idBill) REFERENCES dbo.bills
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	idDrinks INT FOREIGN KEY (idDrinks) REFERENCES dbo.drinks
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	--price INT NOT NULL DEFAULT 0,
	countt INT NOT NULL DEFAULT 0,
)
GO

--========================== INSERT VALUE ============================
INSERT INTO dbo.account(userName,displayName,passWords,gender,email,mobie,addresss,typeAccount,DOB)
VALUES(N'ngoctan',N'Đoàn Ngọc Tân',N'1',N'Nam',N'doanngoctan971999@gmail.com',N'0799600962',N'Điện Bàn, Quảng Nam',1,N'09/07/1999')
INSERT INTO dbo.account(userName,displayName,passWords,gender,email,mobie,addresss,typeAccount,DOB)
VALUES(N'thaonguyen',N'Nguyễn Thị Thảo Nguyên',N'1',N'Nữ',N'thaonguyen99@gmail.com',N'0799600963',N'Sơn Trà, Đà Nẵng',1,N'08/07/1998')
INSERT INTO dbo.account(userName,displayName,passWords,gender,email,mobie,addresss,typeAccount,DOB)
VALUES(N'ducluong',N'Lê Đức Lương',N'1',N'Nam',N'leduocluong99@gmail.com',N'0799600462',N'Phong Điền, Nghệ An',1,N'12/02/1999')
INSERT INTO dbo.account(userName,displayName,passWords,gender,email,mobie,addresss,typeAccount,DOB)
VALUES(N'a',N'Nguyễn Văn A',N'1',N'Nam',N'nguyenvana99@gmail.com',N'0759600962',N'Điện Bàn, Quảng Nam',1,N'22/09/1999')
INSERT INTO dbo.account(userName,displayName,passWords,gender,email,mobie,addresss,typeAccount,DOB)
VALUES(N'b',N'Lê Thị B',N'1',N'Nữ',N'lethib97@gmail.com',N'0799604962',N'Thanh Khê, Đà Nẵng',0,N'01/01/1999')
INSERT INTO dbo.account(userName,displayName,passWords,gender,email,mobie,addresss,typeAccount,DOB)
VALUES(N'c',N'Lê Thị C',N'1',N'Nữ',N'lethic97@gmail.com',N'0799604965',N'Liên Chiểu, Đà Nẵng',0,N'01/04/1999')

INSERT INTO dbo.categories(idCategories,nameTypes)
VALUES(0,N'Đồ uống có gas')
INSERT INTO dbo.categories(idCategories,nameTypes)
VALUES(1,N'Đồ uống có ancol')
INSERT INTO dbo.categories(idCategories,nameTypes)
VALUES(2,N'Cafe')
INSERT INTO dbo.categories(idCategories,nameTypes)
VALUES(3,N'Trà sữa')
INSERT INTO dbo.categories(idCategories,nameTypes)
VALUES(4,N'Nước uống luxury')
INSERT INTO dbo.categories(idCategories,nameTypes)
VALUES(5,N'Nước uống bình thường')
INSERT INTO dbo.categories(idCategories,nameTypes)
VALUES(6,N'Rượu ngoại')
INSERT INTO dbo.categories(idCategories,nameTypes)
VALUES(7,N'Other')

INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(1,0,N'Coca-Cola',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(2,0,N'Pepsi',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(3,0,N'Sprite',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(4,0,N'Mirinda',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(5,0,N'7-Up',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(6,1,N'Bia tươi',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(7,1,N'Heineken ',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(8,1,N'Tiger',15000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(9,1,N'huda',15000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(10,1,N'Bia 333',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(11,2,N'Cafe đen đá không đường',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(13,2,N'Cafe sữa',10000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(14,2,N'Bạc xĩu',20000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(15,2,N'Capuchino',20000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(16,3,N'Sữa tươi trân châu đường đen',40000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(17,3,N'Trà sữa thái xanh',30000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(18,3,N'Trà sữa truyền thống',45000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(19,3,N'Trà sữa đặc biệt',50000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(20,4,N'Nước ép thập cẩm',15000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(21,4,N'Nước ép nguyên liệu sạch',15000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(22,4,N'Nước trái cây đặc biệt',30000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(23,5,N'Nước lọc',5000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(24,5,N'Trà đá ',5000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(25,5,N'Nước đậu xanh',5000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(26,6,N'Martell Blue Swift',2500000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(27,6,N'Hennessy VS EOY VAP',980000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(28,7,N'Khăn giấy',12000)
INSERT INTO dbo.drinks(idDrinks,idCategories,nameDrinks,price)
VALUES(29,7,N'Tăm',1000)

INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(0,N'Bàn 00',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(1,N'Bàn 01',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(2,N'Bàn 02',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(3,N'Bàn 03',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(4,N'Bàn 04',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(5,N'Bàn 05',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(6,N'Bàn 06',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(7,N'Bàn 07',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(8,N'Bàn 08',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(9,N'Bàn 09',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(10,N'Bàn 10',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(11,N'Bàn 11',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(12,N'Bàn 12',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(13,N'Bàn 13',N'Trống')
INSERT INTO dbo.tableDrinks(idTable,nameTable,statusTable)
VALUES(14,N'Bàn 14',N'Trống')


--========================== CREATE PROC ============================
-- USE_GETLISTACCOUNT
CREATE PROC USE_GetListAccount
@UserName nvarchar(100) 
AS 
BEGIN 
	SELECT userName AS N'Tên đăng nhập', displayName AS N'Tên hiển thị',
	passWords AS N'Mật khẩu',
	gender AS N'Giới tính', DOB AS N'Ngày tháng năm sinh',
	email AS N'Địa chỉ email', mobie AS N'Số điện thoại',
	addresss  AS N'Địa chỉ'
	FROM dbo.account
	WHERE userName = @Username
END
GO

--USE_GetAccountByUserName
CREATE PROC USE_GetAccountByUserName
@UserName nvarchar(100) 
AS 
BEGIN 
	SELECT userName AS N'Tên đăng nhập', displayName AS N'Tên hiển thị',
	passWords AS N'Mật khẩu', gender AS N'Giới tính',
	DOB AS N'Ngày tháng năm sinh',email AS N'Địa chỉ email',
	mobie AS N'Số điện thoại', addresss  AS N'Địa chỉ' 
	FROM dbo.account 
	WHERE userName = @Username
END
GO

--USP_GetListBillDate
CREATE PROC USP_GetListBillDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT nameTable AS N'Tên bàn',price AS N'Tổng tiền',dateCheckIn  AS N'Ngày vào',dateCheckOut AS N'Ngày ra'
	FROM dbo.bills INNER JOIN dbo.tableDrinks
	ON tableDrinks.idTable = bills.idTable
	WHERE dateCheckIn >= @checkIn
	AND dateCheckOut <= @checkOut AND statusBill=1
END
GO

--USP_Login
CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE userName = @userName AND passWords = @passWord
END
GO

--USP_UpdateAccount
Create  proc USP_UpdateAccount
@userName NVARCHAR(100),@displayName NVARCHAR(100),@passWord NVARCHAR(100),@newPassword NVARCHAR(100)
AS
BEGIN
	
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.account WHERE USERName = @userName And passWords = @password
	IF (@isRightPass =1)
	BEGIN
		IF (@newPassword=Null Or @newPassword = '')
		BEGIN 
			UPDATE dbo.account SET displayName = @displayName where UserName = @userName
		END
		ELSE
		UPDATE dbo.account SET displayName = @displayName,passWords= @newPassword where userName = @userName
		END
END
GO

--USP_GetTableList
create proc [dbo].[USP_GetTableList]
as select * from dbo.tableDrinks
GO

--USP_InsertBill
CREATE proc [dbo].[USP_InsertBill]
@idTable int
as 
Begin
	INSERT INTO dbo.bills
(dateCheckIn,dateCheckOut,idTable,statusBill,discount)
VALUES 
(GETDATE(),
NULL,
@idTable,
0,
0
)
END
GO

--USP_InsertBillDetail
CREATE proc [dbo].[USP_InsertBillDetail]
@idBill int, @idDrinks int, @countt int
as 
Begin
	declare @isExistBillDetail int
	declare @drinkCount int=1
	select @isExistBillDetail = idDetail, @drinkCount = countt from dbo.detailBills where idBill = @idBill and idDrinks = @idDrinks
	if(@isExistBillDetail >0)
	Begin
		declare @newCount int = @drinkCount + @countt
		IF(@newCount > 0)
		BEGIN
			UPDATE detailBills SET countt = @newCount Where idDetail = @isExistBillDetail
		END
		ELSE
		BEGIN
			DELETE detailBills Where idBill = @idBill AND idDrinks = @idDrinks --idDetail = @isExistBillDetail
		END
	end
	else
	BEGIN
		IF(@countt <= 0)
		BEGIN
			return 1;
		END
	ELSE
	BEGIN
		INSERT INTO detailBills(idBill,idDrinks,countt)
		VALUES(@idBill,@idDrinks,@countt)
	END
 END
END
GO

--USP_SwitchTabel
CREATE PROC [dbo].[USP_SwitchTabel]
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = idBills FROM dbo.bills WHERE idTable = @idTable2 AND statusBill = 0
	SELECT @idFirstBill = idBills FROM dbo.bills WHERE idTable = @idTable1 AND statusBill = 0
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.bills
		        ( dateCheckIn ,
		          dateCheckOut ,
		          idTable ,
		          statusBill
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(idBills) FROM dbo.bills WHERE idTable = @idTable1 AND statusBill = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.detailBills WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.bills
		        ( dateCheckIn ,
		          dateCheckOut ,
		          idTable ,
		          statusBill
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(idBills) FROM dbo.bills WHERE idTable = @idTable2 AND statusBill = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.detailBills WHERE idBill = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT idBill INTO IDBillDetailTable FROM dbo.detailBills WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.detailBills SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.detailBills SET idBill = @idFirstBill WHERE idBill IN (SELECT * FROM IDBillDetailTable)
	
	DROP TABLE IDBillDetailTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.tableDrinks SET statusTable = N'Trống' WHERE idTable = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.tableDrinks SET statusTable = N'Trống' WHERE idTable = @idTable1
END
GO

--UTG_UpdateBillDetail
create TRIGGER UTG_UpdateBillDetail
ON dbo.detailBills FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.bills WHERE idBills = @idBill AND statusBill = 0
	
	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.detailBills WHERE idBill = @idBill
	
	IF (@count > 0)
	BEGIN
	
		PRINT @idTable
		PRINT @idBill
		PRINT @count
		
		UPDATE dbo.tableDrinks SET statusTable = N'Có người' WHERE idTable = @idTable		
		
	END		
	ELSE
	BEGIN
		PRINT @idTable
		PRINT @idBill
		PRINT @count
	UPDATE dbo.tableDrinks SET statusTable = N'Trống' WHERE idTable = @idTable	
	end
END
GO

--UTG_UpdateBill
CREATE TRIGGER UTG_UpdateBill
ON dbo.bills FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBills FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.bills WHERE idBills = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.bills WHERE idTable = @idTable AND statusBill = 0
	
	IF (@count = 0)
		UPDATE dbo.tableDrinks SET statusTable = N'Trống' WHERE idTable = @idTable
END
GO