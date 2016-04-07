/* Ime baze: ZadaciDB */
CREATE PROCEDURE [dbo].[InsertZadatak]
(
 @Start DATETIME,
 @Naslov NVARCHAR(50),
 @Opis NVARCHAR(300),
 @Status BIT,
 @Kraj DATETIME
)
AS
Begin
insert into Zadaci(Start, Naslov, Opis, Status,Kraj)values(@Start, @Naslov, @Opis, @Status, @Kraj)
END
