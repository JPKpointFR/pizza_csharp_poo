

using System.Linq;

namespace pizza
{
    public class Pizza
    {
        public string nom { get; protected set; }
        public float prix { get; protected set; }
        public bool vegetarienne { get; protected set; }
        public List<string> ingredients { get; protected set; }

        public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
            this.ingredients = ingredients;
        }

        public virtual void Afficher()
        {
            string badgeVeg = vegetarienne? " (V) - " : " - ";
            string nomAfficher = FormatFirstLetter(nom);
            var ingredientsAfficher = ingredients.Select(i => FormatFirstLetter(i)).ToList();

            Console.WriteLine(nomAfficher + badgeVeg + prix + "€" );
            Console.WriteLine(string.Join(", ", ingredientsAfficher));
            Console.WriteLine();


        }

        private static string FormatFirstLetter(string s)
        {
            if ((s == null) || (s.Length == 0))
            {
                return s;
            } 
            string nomMinuscules = s.ToLower();
            string nomMajuscules = s.ToUpper();

            string nomAfficher = nomMajuscules[0] + nomMinuscules[1..];

            return nomAfficher;
        }

    }
}