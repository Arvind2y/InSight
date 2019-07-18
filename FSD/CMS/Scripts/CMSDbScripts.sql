
USE CMSDB
GO;

CREATE TABLE Customers
(
	CustomerId		Int identity (1,1) PRIMARY KEY ,
	Name	Varchar(100),
	Address	Varchar(200),
	Dob			datetime,
	Salary		decimal
)

ALTER PROCEDURE AddCustomers
(
	  @Name	Varchar(100)
	, @Address	Varchar(200)
	, @DOB			datetime
	, @Salary		decimal
)
As
BEGIN
	INSERT INTO Customers(Name, Address, Dob, Salary)
	VALUES(@Name, @Address, @DOB, @Salary)
END


CREATE PROCEDURE spUpdateCustomer
(
	@custId INT
	, @Name		VARCHAR(100)
	, @Address	VARCHAR(200)
	, @DOB		DATETIME
	, @Salary	DECIMAL
)
As
BEGIN
	UPDATE Customers SET Name=@Name, Address=@Address, Dob=@DOB, Salary=@Salary
	WHERE CustomerId=@custId
END

--INSERT INTO Customers(Name, Address, Dob, Salary)
--VALUES ('Kumar', 'Delhi', '04/12/1985', 30000)

CREATE PROCEDURE GetAllCustomers
AS
BEGIN
	SELECT [CustomerId]
		  ,[Name]
		  ,[Address]
		  ,[Dob]
		  ,[Salary]
	  FROM [dbo].[Customers]
 
 END
GO

CREATE PROCEDURE GetCustomerById
(@custId int)
AS
BEGIN
	SELECT [CustomerId]
		  ,[Name]
		  ,[Address]
		  ,[Dob]
		  ,[Salary]
	  FROM [dbo].[Customers]
	  where CustomerId=@custId
 
 END
GO


CREATE PROCEDURE spDeleteCustomer (@custId int)
AS
BEGIN
	DELETE FROM Customers WHERE CustomerId= @custId
END


select * from Customers

CREATE PROCEDURE GetCustomerByDate
(@dob date)
AS
BEGIN
	SELECT [CustomerId]
		  ,[Name]
		  ,[Address]
		  ,[Dob]
		  ,[Salary]
	  FROM [dbo].[Customers]
	  where dob>=@dob
 
 END
GO

GetCustomerByDate '1985-03-12 10:20:00.000'

CREATE PROCEDURE  [dbo].[USP_XMLInsert]
(
@xmlx xml
)
AS
BEGIN
SET NOCOUNT ON;
      --INSERT INTO Tbl_Customer
      SELECT
      Customer.value('(Name/text())[1]','NVARCHAR(50)') as Name , TAG
      Customer.value('(City/text())[1]','NVARCHAR(50)') as City, TAG
      Customer.value('(IndustryType/text())[1]','NVARCHAR(50)') as IndustryType –TAG
      FROM
      @xmlx.nodes('//Customer')AS TEMPTABLE(Customer)

END



'<ROOT> 
<Price propertyid="362" startdate="16/06/2011" enddate="25/06/2011" weeklyrate="120" orderseq="1"</Price>
 <Price propertyid="362" startdate="26/06/2011" enddate="08/07/2011" weeklyrate="140" orderseq="2"</Price>
</ROOT>'

ALTER PROCEDURE [dbo].[InsertShortTermPrice]

@xmlDoc varchar(MAX)
AS
declare @hDoc int
BEGIN TRANSACTION

EXEC sp_xml_PrepareDocument @hDoc OUT, @XMLDoc
INSERT INTO shortTerm_pricelist
SELECT propertyid,startdate,enddate,weeklyrate,orderseq
SELECT
	x.item.value('@propertyid[1]', 'Bigint') AS propertyid,
	x.item.value('@startdate[1]', 'Datetime') AS startdate,
	x.item.value('@enddate[1]', 'Datetime') AS enddate,
	x.item.value('@weeklyrate[1]', 'Bigint') AS weeklyrate,
	x.item.value('@orderseq[1]', 'Bigint') AS orderseq
FROM @hDoc.nodes('//Record/Price') AS x(item)
 

COMMIT TRANSACTION


declare @sql xml 
set @sql = '<row> 
  <ID_Cota>162986</ID_Cota>
  <ID_Taxa_Plano>1000</ID_Taxa_Plano>
  <ID_Plano_Venda>1020</ID_Plano_Venda>
  <ID_Pessoa>18522</ID_Pessoa>
</row>'

select s.n.value('(ID_Cota)[1]', 'int') as ID_Cota
        ,s.n.value('(ID_Taxa_Plano)[1]', 'int') as ID_Taxa_Plano
        ,s.n.value('(ID_Plano_Venda)[1]', 'int') as ID_Plano_Venda
        ,s.n.value('(ID_Pessoa)[1]', 'int') as ID_Pessoa
from @sql.nodes('/row') as s(n)


WITH    xml_string
AS      (
        SELECT val = CAST('<row><ID_Cota>162986</ID_Cota><ID_Taxa_Plano>1000</ID_Taxa_Plano><ID_Taxa_Venda>1020</ID_Taxa_Venda><ID_Pessoa>18522</ID_Pessoa></row><row><ID_Cota>162986</ID_Cota><ID_Taxa_Plano>1000</ID_Taxa_Plano><ID_Taxa_Venda>1020</ID_Taxa_Venda><ID_Pessoa>18522</ID_Pessoa></row>' AS XML)
        )
SELECT  val
--INTO    ST_Registro_Del
FROM    xml_string;

-- run from the table here:
SELECT  --val,
        ID_Cota       = (val).value('(/row/ID_Cota[1])', 'INT'),
        ID_Taxa_Plano = (val).value('(/row/ID_Taxa_Plano[1])', 'INT'),
        ID_Taxa_Venda = (val).value('(/row/ID_Taxa_Venda[1])', 'INT'),
        ID_Pessoa     = (val).value('(/row/ID_Pessoa[1])', 'INT')
FROM    ST_Registro_Del

DECLARE @myDoc xml  
DECLARE @ProdID int  
SET @myDoc = '<Root>  
<ProductDescription ProductID="1" ProductName="Road Bike">  
<Features>  
  <Warranty>1 year parts and labor</Warranty>  
  <Maintenance>3 year parts and labor extended maintenance is available</Maintenance>  
</Features>  
</ProductDescription>  
</Root>'  
  

  SELECT CatalogDescription.value('             
    declare namespace PD="https://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription";             
       (/PD:ProductDescription/@ProductModelID)[1]', 'int') AS Result             
FROM Production.ProductModel             
WHERE CatalogDescription IS NOT NULL             
ORDER BY Result desc           


SET @ProdID =  @myDoc.value('(/Root/ProductDescription/@ProductID)[1]', 'int' )  
SELECT @ProdID  