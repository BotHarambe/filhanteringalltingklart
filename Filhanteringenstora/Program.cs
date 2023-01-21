
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filhanteringenstora
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            int Segment = 1;
            while (Segment != 0)
            {

                Console.WriteLine("Input File Nav");
                string filenav = Console.ReadLine();
                Console.WriteLine("Välj en segment");
                Console.WriteLine("1. du kollar vad som finns och om du vill ändra");
                Console.WriteLine("2. Skapa en lista med studenter");
                Console.WriteLine("3. Sortera namnen");
                Console.WriteLine("4. kolla om det går att läsa");
                Console.WriteLine("5. kollar filer");
                Console.WriteLine("6. skapa fil");
                Console.WriteLine("7. hitta längsta ordet");
                Console.WriteLine("8. hitta den mest använde bokstäven");
               

                Segment = Convert.ToInt32(Console.ReadLine());
                if (Segment == 1)
                {
                    Console.WriteLine(class1.firstseg(filenav));
                }
                if (Segment == 2)
                {
                    Console.WriteLine(class1.secondseg(filenav));
                }
                if (Segment == 3)
                {
                    Console.WriteLine(class1.thirdseg(filenav));
                }
                if (Segment == 4)
                {
                    Console.WriteLine(class1.fourthseg(filenav));
                }
                if (Segment == 5)
                {
                    Console.WriteLine(class1.fiveseg(filenav));
                }
                if (Segment == 6)
                {
                    Console.WriteLine("Skriv filtyp");
                    string filetype = Console.ReadLine();
                    Console.WriteLine(class1.sixseg(filenav, filetype));
                }
                if (Segment == 7)
                {
                    Console.WriteLine(class1.sevenseg(filenav));
                }
                if (Segment == 8)
                {
                    Console.WriteLine(class1.eigthseg(filenav));
                }

            }
        }
    }
}
    
