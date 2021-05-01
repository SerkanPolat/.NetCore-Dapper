using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample
{
	public class Ogrenciler
	{
		public Ogrenciler()
		{
			Dersler = new List<Dersler>();
		}
		public int Id { get; set; }
		public string Ad { get; set; }
		public List<Dersler> Dersler { get; set; }
	}
}
