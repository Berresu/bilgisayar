using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Program;

namespace ConsoleApp1
{
    internal class Program
    {
        public class Hafiza
        {
            public int HafizaBoyutu { get; set; }

            public Hafiza(int hafizaBoyutu)
            {
                HafizaBoyutu = hafizaBoyutu;
                Console.WriteLine("Hafıza Boyutu Seçildi.");
            }

            ~Hafiza()
            {
                Console.WriteLine("Hafıza Yok Edildi.");
            }
        }

        public class Islemci
        {
            public string IslemciModeli { get; set; }

            public Islemci(string islemciModeli)
            {
                IslemciModeli = islemciModeli;
                Console.WriteLine("İşlemci Modeli Seçildi.");
            }

            ~Islemci()
            {
                Console.WriteLine("İşlemci Seçimi İptal Edildi.");
            }
        }

        public class Bilgisayar
        {
            public Hafiza Hafiza { get; private set; }
            public Islemci Islemci { get; private set; }
            public string BilgisayarMarkasi { get; set; }

            public Bilgisayar(string bilgisayarMarkasi, int hafizaBoyutu, string islemciModeli)
            {
                BilgisayarMarkasi = bilgisayarMarkasi;
                Hafiza = new Hafiza(hafizaBoyutu);
                Islemci = new Islemci(islemciModeli);
            }

            ~Bilgisayar()
            {
                Console.WriteLine("Bilgisayar Markası Seçimi İptal Edildi.");
                Hafiza = null;
                Islemci = null; 
            }

            public void BilgileriGoster()
            {
                Console.WriteLine($"Bilgisayar Markası: {BilgisayarMarkasi}, İşlemci Modeli: {Islemci.IslemciModeli}, Hafıza Boyutu: {Hafiza.HafizaBoyutu}");
            }
        }

        public class CompositionOrnek
        {
            public static void Main(string[] args)
            {
                Bilgisayar hp = new Bilgisayar("HP", 64, "Intel i7");
                hp.BilgileriGoster();

                hp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Console.WriteLine("\nProgram Sonlandı...");
            }
        }
    }
}
