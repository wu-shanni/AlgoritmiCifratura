using System;

namespace Cifrari
{
    public class Cesare
    {
        public string Elabora(string messaggio, int k, bool decifra)
        {
            if (decifra) k = -k;
            string risultato = "";

            foreach (char c in messaggio)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    int valore = (c - baseChar + k) % 26;
                    if (valore < 0) valore += 26;
                    risultato += (char)(valore + baseChar);
                }
                else
                {
                    risultato += c;
                }
            }
            return risultato;
        }
    }



    public class Rot13
    {
        public string Elabora(string messaggio)
        {
            Cesare cesare = new Cesare();
            return cesare.Elabora(messaggio, 13, false);
        }
    }



    public class Vigenere
    {
        public string Elabora(string messaggio, string chiave, bool decifra)
        {
            if (string.IsNullOrEmpty(chiave)) chiave = "A";
            string risultato = "";
            int chiaveIndex = 0;

            foreach (char c in messaggio)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    char kChar = chiave[chiaveIndex % chiave.Length];
                    int kShift = char.ToUpper(kChar) - 'A';

                    if (decifra) kShift = -kShift;

                    int valore = (c - baseChar + kShift) % 26;
                    if (valore < 0) valore += 26;

                    risultato += (char)(valore + baseChar);
                    chiaveIndex++;
                }
                else
                {
                    risultato += c;
                }
            }
            return risultato;
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci la frase da cifrare o decifrare: \t");
            string messaggio = Console.ReadLine();

            Console.WriteLine("\nScegli l'algoritmo:");
            Console.WriteLine("1. Cifrario di Cesare");
            Console.WriteLine("2. ROT13");
            Console.WriteLine("3. Cifrario di Vigenère");
            Console.Write("Scelta (1, 2 o 3): ");
            string algoritmo = Console.ReadLine();

            string risultato = "";

            if (algoritmo == "1")
            {
                Console.Write("Inserisci la chiave K (numero intero): \t");
                int k = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("1. Cifrare\n2. Decifrare");
                Console.Write("Scelta operazione (1 o 2): ");
                bool decifra = (Console.ReadLine() == "2");

                Cesare cesare = new Cesare();
                risultato = cesare.Elabora(messaggio, k, decifra);
            }
            else if (algoritmo == "2")
            {
                Rot13 rot13 = new Rot13();
                risultato = rot13.Elabora(messaggio);
            }
            else if (algoritmo == "3")
            {
                Console.Write("Inserisci la chiave K (parola, es. CIAO): \t");
                string chiave = Console.ReadLine();

                Console.WriteLine("1. Cifrare\n2. Decifrare");
                Console.Write("Scelta operazione (1 o 2): ");
                bool decifra = (Console.ReadLine() == "2");

                4               Vigenere vigenere = new Vigenere();
                risultato = vigenere.Elabora(messaggio, chiave, decifra);
            }
            else
            {
                Console.WriteLine("\nScelta non valida!");
                return;
            }

            Console.WriteLine("\nRisultato: " + risultato);
        }
    }
}