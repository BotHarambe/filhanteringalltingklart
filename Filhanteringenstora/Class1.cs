using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace Filhanteringenstora
{
    class Class1
    {

            public string ReadFile(string file)
            {
                StreamReader Reader = new StreamReader(file);
                string ReadFile = Reader.ReadToEnd();
                Reader.Close();
                return ReadFile;
            }
            public string WriteFile(string file, string text)
            {
                StreamWriter Writer = new StreamWriter(file);
                Writer.WriteLine(text);
                Writer.Close();
                return "Filen har skrivit om";
            }
            public string firstseg(string filenav)
            {
                Class1 MainClass = new Class1();

                string Read = MainClass.ReadFile(filenav);
                Console.WriteLine(Read);
                Console.WriteLine("skulle du vilja ändra? (ja or nej)");
                try
                {
                    string Edit = Console.ReadLine().ToUpper();
                    if (Edit != "NO")
                    {
                        Console.WriteLine("1 = allting? 2 = fortsätta ändra");
                        try
                        {

                            int OverallOrContinue = Convert.ToInt32(Console.ReadLine());
                            if (OverallOrContinue == 1)
                            {
                                Console.WriteLine("Du vill ändra allting ajt ajt");
                                Console.WriteLine("skriv det du vill då");
                                string Overall = Console.ReadLine();
                                MainClass.WriteFile(filenav, Overall);
                                return "Klart";
                            }
                            if (OverallOrContinue == 2)
                            {
                                Console.WriteLine("Du har bestämt har forsätta ändra");
                                Console.WriteLine("skriv det du vill");
                                string Continue = Console.ReadLine();
                                MainClass.WriteFile(filenav, Read + Continue);
                                return "klart";
                            }
                            else
                            {
                                Console.WriteLine("Du skrev fel skriv igen");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Du skrev fel skriv igen");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("fel skriven");
                }
                return ("slutet");

            }
            public string secondseg(string filenav)
            {
                List<string> name = new List<string>();
                Console.WriteLine("Skriv hur många studenter du vill lägga till");
                int StudentAmmount = Convert.ToInt32(Console.ReadLine());
                int AmmountRan = 0;
                while (AmmountRan != StudentAmmount)
                {
                    Console.WriteLine("Skriv in " + AmmountRan + (")"));
                    name.Add(Console.ReadLine());
                    AmmountRan++;
                }
                StreamWriter Writer = new StreamWriter(filenav);
                for (int i = 0; i < name.Count; i++)
                {
                    Writer.WriteLine(name[i]);
                }
                Writer.Close();
                StreamReader Reader = new StreamReader(filenav);
                string Result = Reader.ReadToEnd();
                Reader.Close();
                try
                {
                    Console.WriteLine("din nurvande fil är : \n" + Result);
                }
                catch
                {
                    return "du failde allting kom igen gör om";
                }
                return Result;
            }
            public string thirdseg(string filenav)
            {
                List<string> list = new List<string>();
                StreamReader Reader = new StreamReader(filenav);
                while (!Reader.EndOfStream)
                {
                    string line = Reader.ReadLine();
                    list.Add(line);
                }
                Reader.Close();
                list.Sort();
                StreamWriter streamWriter = new StreamWriter(filenav);
                foreach (string s in list)
                {
                    streamWriter.WriteLine(s);
                }
                streamWriter.Close();
                return "namnen har blivit sorterad";
            }

            public string fourthseg(string filenav)
            {
                string Result;
                try
                {
                    StreamReader Reader = new StreamReader(filenav);
                    Result = Reader.ReadToEnd();
                    Reader.Close();
                }
                catch
                {
                    return "kan inte läsa denna fil";
                }
                return "filen fungerade att läsa \n" + Result;
            }
            public string fiveseg(string filenav)
            {
                string[] Dir = Directory.GetFiles(filenav);
                Console.WriteLine("Nuvarnde filer i mappen");
                for (int i = 0; i < Dir.Count(); i++)
                {
                    Console.WriteLine(Dir[i]);
                }
                return " ";
            }
            public string sixseg(string filenav, string filetype)
            {
                string[] Dir = Directory.GetFiles(filenav);
                for (int i = 0; i < Dir.Count(); i++)
                {
                    if (Dir[i].EndsWith(filetype))
                    {
                        Console.WriteLine(Dir[i]);
                    }
                }
                return " ";
            }
        public string sevenseg(string filenav)
        {
            if (string.IsNullOrEmpty(filenav) || !File.Exists(filenav))
            {
                return "Filen hittades inte";
            }
            StreamReader Reader = new StreamReader(filenav);
            var lines = new List<string>();
            var splitted = new List<string[]>();
            string line;
            while ((line = Reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            Reader.Close();
            for (int i = 0; i < lines.Count; i++)
            {
                try
                {
                    splitted.Add(lines[i].Split(' '));
                }
                catch
                {
                    splitted.Add(new string[] { lines[i] });
                }
            }
            int ctr = 0;
            string word = "";
            foreach (string[] s in splitted)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].Length > ctr)
                    {
                        word = s[i];
                        ctr = s[i].Length;
                    }
                }
            }
            return "längsta ordet är " + word;
        }
        public string eigthseg(string filenav)
            {
                Dictionary<char, int> letterCounts = new Dictionary<char, int>();

                // läser filen
                using (StreamReader reader = new StreamReader(filenav))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        
                        foreach (char c in line)
                        {
                        // ignorera mellanslag och tecken
                        if (!char.IsLetter(c))
                            {
                                continue;
                            }
                        
                        char lowercaseChar = char.ToLower(c);
                        // lägger till bokstaven i ordboken eller öka antalet om det redan finns
                        if (letterCounts.ContainsKey(lowercaseChar))
                            {
                                letterCounts[lowercaseChar]++;
                            }
                            else
                            {
                                letterCounts.Add(lowercaseChar, 1);
                            }
                        }
                    }
                }
                // får bokstaven mest använden
                char mostCommonLetter = (char)letterCounts.OrderByDescending(x => x.Value).First().Key;
                return "Den mest använda bokstaven är " + mostCommonLetter;
            }

        }
    }

