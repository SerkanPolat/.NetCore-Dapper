using System.Data.SqlClient;
using System;
using Dapper;
using System.Data;
using System.Collections.Generic;

namespace DapperExample
{
    class Program
    {
        public const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                                 Initial Catalog=DapperDB;Integrated Security=True;
                                                 Connect Timeout=30;Encrypt=False;
                                                 TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                                 MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            //Dapper genisletmeli metod
            //conn.Execute("INSERT INTO Ogrenciler values('Serkan')");
            //conn.Execute("INSERT INTO Ogrenciler values(@sa)", new { sa = "serkan" });
            /*conn.Execute("INSERT INTO Ogrenciler values(@ad)", new []{
                new {Ad="Kadir"},
                new {Ad="Baris"},
                new {Ad="Salih"}
                });
            */
            /*conn.Execute("UPDATE Ogrenciler set Ad='SerkanGuncellendi' WHERE Id=3");
            conn.Execute("UPDATE Ogrenciler set Ad=@ad WHERE Id=@id", new { ad = "Salih Guncelleniyor", id = 6 });

            conn.Execute("DELETE FROM Ogrenciler WHERE Id=@id", new { id = 1 });

            conn.Execute("DELETE FROM Ogrenciler WHERE Id=@id", new[] {
            new {id=1},
            new {id=2}
            });

            // Store Procedure Kullanimi
            conn.Execute("Up_OgrenciEkle", new { ad = "Proc" },commandType:System.Data.CommandType.StoredProcedure);
            */

            /*var reader = conn.ExecuteReader("SELECT * FROM Ogrenciler");
            while (reader.Read())
            {
                Console.WriteLine(reader["Ad"]);
            }*/

            /*
            conn.Execute("INSERT INTO Dersler VALUES(@ad)",new[]
            {
                new {ad ="Matematik"},
                new {ad ="Fizik"},
                new {ad ="Cografya"},
                new {ad ="Turkce"},
                new {ad ="Programlama"},

            });
            
            conn.Execute("INSERT INTO OgrenciDers values(@OgrenciId,@DersId)", new[]
            {
                new{OgrenciId=3,DersId=1},
                new{OgrenciId=3,DersId=2},
                new{OgrenciId=3,DersId=3},
                new{OgrenciId=6,DersId=4},
                new{OgrenciId=7,DersId=2},
                new{OgrenciId=4,DersId=3},
                new{OgrenciId=4,DersId=4},
                new{OgrenciId=5,DersId=4},
                new{OgrenciId=5,DersId=2},
                new{OgrenciId=9,DersId=2},
                new{OgrenciId=9,DersId=4},
                new{OgrenciId=6,DersId=2},
                new{OgrenciId=3,DersId=4},
            });
            */

            //Ogrenci ve OgrenciDers giricek Ogrenci Cikacak Ilk 2 parametre girer 3.parametre cikis;
            Dictionary<int, Ogrenciler> data = new Dictionary<int,Ogrenciler>();
            conn.Query<Ogrenciler,Dersler, bool>("SELECT Ogrenciler.*,Dersler.* FROM Ogrenciler INNER JOIN OgrenciDers on Ogrenciler.Id= OgrenciDers.OgrenciId INNER JOIN Dersler ON OgrenciDers.DersId=Dersler.Id", (ogr,Ders) =>
            {
				if (data.ContainsKey(ogr.Id))
				{
                    data[ogr.Id].Dersler.Add(Ders);
				}
				else
				{
                    data.Add(ogr.Id, ogr);
                    ogr.Dersler.Add(Ders);
                }
                return true;
            });


            conn.Query<Ogrenciler>("SELECT * FROM Ogrenciler");
            

            Console.WriteLine("Islem Tamam");
        }
    }
}
