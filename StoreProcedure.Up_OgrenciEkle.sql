CREATE PROC Up_OgrenciEkle(

	@Ad nvarchar(50)
)
as
begin
INSERT INTO Ogrenciler values(@ad)
end