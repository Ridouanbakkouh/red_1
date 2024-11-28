namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        // Dades rebudes
        var comandes = File.ReadAllLines(@"/home/xavier/RiderProjects/ConsoleApp1/ConsoleApp1/tokage.txt");
        Console.WriteLine("Quants cotxes vermells");
        var cotxesVermells = int.Parse(Console.ReadLine());
        Console.WriteLine("Quants cotxes grocs");
        var cotxesgrocs = int.Parse(Console.ReadLine());;
        
        // Calcular dades
        var totalCotxes = cotxesVermells + cotxesgrocs;
        var QueNecessito = new Dictionary<string, int>();
        QueNecessito.Add("carrosseria-groga", cotxesgrocs);
        QueNecessito.Add("carrosseria-vermella", cotxesVermells);
        QueNecessito.Add("vidres", totalCotxes);
        QueNecessito.Add("parafangs", 2 * totalCotxes);
        QueNecessito.Add("rodes", 4* totalCotxes);
        
        var QueTinc = new Dictionary<string, int>();
        QueTinc.Add("carrosseria-groga", 0);
        QueTinc.Add("carrosseria-vermella", 0);
        QueTinc.Add("vidres", 0);
        QueTinc.Add("parafangs", 0);
        QueTinc.Add("rodes", 0);

        var numeroDeComandes = 0;
        
        // 
        var i = 0;
        while (!TincProusPeces(QueNecessito, QueTinc) && i < comandes.Length)
        {
            var liniaActual = comandes[i];
            if (liniaActual.StartsWith("Comanda"))
            {
                numeroDeComandes++;
            }
            else
            {
                var contingut = liniaActual.Split(" ");
                var ok = int.TryParse(contingut[0], out var quantitat);
                var peca = contingut[1];
                QueTinc[peca] = QueTinc[peca] + quantitat;
            }
            
            i++;
        }

        if (TincProusPeces(QueNecessito, QueTinc))
        {
            Console.WriteLine($"Calien {numeroDeComandes} comandes");
        }
        else
        {
            Console.WriteLine("Fes més comandes");
        }
    }

    private static bool TincProusPeces(Dictionary<string, int> queNecessito, Dictionary<string, int> queTinc)
    {
        return queTinc["vidres"] >= queNecessito["vidres"] &&
               queTinc["parafangs"] >= queNecessito["parafangs"] &&
               queTinc["rodes"] >= queNecessito["rodes"] &&
               queTinc["carrosseria-groga"] >= queNecessito["carrosseria-groga"] &&
               queTinc["carrosseria-vermella"] >= queNecessito["carrosseria-vermella"];
    }
}