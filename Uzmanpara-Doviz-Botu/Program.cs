using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzmanpara_Doviz_Botu
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Title = "UzmanPara & BigPara Döviz Kuru Çeken Bot";
			
			Console.WriteLine("2 farklı siteden doviz kurlarına ulaşabilirsiniz.. " + "\n========================================");
			
			Console.WriteLine("UzmanPara [1]" + "\n" + "BigPara   [2]" + "\n============= ");
			Console.Write("Sayi Giriniz :: ");
			
			int sayi = Convert.ToInt32(Console.ReadLine());
			
			switch (sayi)
			{
				case 1:
					Console.WriteLine("\nUzmanPara'dan Döviz Bilgileri Çekiliyor...\n");
					UzmanParaDovizCek();
					break;
				case 2:
					Console.WriteLine("\nBigPara'dan Döviz Bilgileri Çekiliyor...\n");
					BigParaDovizCek();
					break;
				default:
					break;
			}
			Console.ReadLine();
		}

		private static void BigParaDovizCek()
		{
			try
			{
				var site = "https://bigpara.hurriyet.com.tr/doviz/";

				List<Doviz> DovizListesi = new List<Doviz>();

				HtmlWeb web = new HtmlWeb();
				HtmlDocument document = web.Load(site);

				var DovizXpath = "//div[@class='dovizBar mBot20']";
				var DovizX = document.DocumentNode.SelectNodes(DovizXpath);

				foreach (var Doviz in DovizX)
				{
					for (int i = 1; i <= 3; i++)
					{
						string DovizCinsi = Doviz.SelectSingleNode("./a[1]/span/span/text()").InnerText;
						string DovizAlis = Doviz.SelectSingleNode("./a[1]/span[2]/span[2]/text()").InnerText;
						string DovizSatis = Doviz.SelectSingleNode("./a[1]/span[3]/span[2]/text()").InnerText;

						DovizListesi.Add(new Doviz()
						{
							DovizAD = DovizCinsi,
							DovizAlis = DovizAlis,
							DovizSatis = DovizSatis
						});
					}
				}
				Console.WriteLine("======================");
				foreach (var Doviz in DovizListesi)
				{
					Console.WriteLine($"Döviz Cinsi :: {Doviz.DovizAD}");
					Console.WriteLine($"Döviz Alış  :: {Doviz.DovizAlis}");
					Console.WriteLine($"Döviz Satış :: {Doviz.DovizSatis}");
					Console.WriteLine("======================");
				}
			}
			catch (Exception mesaj)
			{
				Console.WriteLine(">>" + mesaj.Message);
			}
		}

		private static void UzmanParaDovizCek()
		{
			try
			{
				var site = "https://uzmanpara.milliyet.com.tr/doviz-kurlari/";

				List<Doviz> DovizListesi = new List<Doviz>();

				HtmlWeb web = new HtmlWeb();
				HtmlDocument document = web.Load(site);

				var DovizXpath = "//div[@class='borsaTop']";
				var DovizX = document.DocumentNode.SelectNodes(DovizXpath);

				foreach (var Doviz in DovizX)
				{
					for (int i = 2; i <= 4; i++)
					{
						string DovizCinsi = Doviz.SelectSingleNode("./div[" + i + "]/span/text()").InnerText;
						string DovizAlis = Doviz.SelectSingleNode("./div[" + i + "]/div[2]/div[1]/text()").InnerText;
						string DovizSatis = Doviz.SelectSingleNode("./div[" + i + "]/div[2]/div[2]/text()").InnerText;

						DovizListesi.Add(new Doviz()
						{
							DovizAD = DovizCinsi,
							DovizAlis = DovizAlis,
							DovizSatis = DovizSatis
						});
					}
				}
				Console.WriteLine("======================");
				foreach (var Doviz in DovizListesi)
				{
					Console.WriteLine($"Döviz Cinsi :: {Doviz.DovizAD}");
					Console.WriteLine($"Döviz Alış  :: {Doviz.DovizAlis}");
					Console.WriteLine($"Döviz Satış :: {Doviz.DovizSatis}");
					Console.WriteLine("======================");
				}
			}
			catch (Exception mesaj)
			{
				Console.WriteLine(">>" + mesaj.Message);
			}
		}
	}
}
