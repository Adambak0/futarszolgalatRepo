namespace Futarszolgalat.Models
{
    public class Gyogyszer
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Tipus { get; set; }
        public string Hatoanyag { get; set; }
        public bool Venykoteles { get; set; }
        public bool Raktaron { get; set; }
        public string Gyarto { get; set; }

        public Gyogyszer()
        {

        }

        public Gyogyszer(string sor)
        {
            string[] tomb = sor.Split(";");

            Nev = tomb[0];
            Tipus = tomb[1];
            Hatoanyag = tomb[2];
            Venykoteles = Convert.ToBoolean(Convert.ToInt32(tomb[3]));
            Raktaron = Convert.ToBoolean(Convert.ToInt32(tomb[4]));
            Gyarto = tomb[5];
        }
    }
}
