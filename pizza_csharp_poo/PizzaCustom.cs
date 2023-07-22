using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizza;

namespace pizza_custom
{
  
    

        public class PizzaPersonnalisee : Pizza
        {

            static int nbPizzaPersnls = 0;
            

            public PizzaPersonnalisee() : base("Personnalisée", 5, false, null)
            {


                nbPizzaPersnls++;
                nom = "Personnalisée " + nbPizzaPersnls;







                ingredients = new List<string>();

                Console.Write("Saisis les ingrédients de ta pizza personalisée"+nbPizzaPersnls+" (ENTER pour terminer): ");

                string ingredient = Console.ReadLine();

                while (!string.IsNullOrEmpty(ingredient))
                {
                    if (ingredients.Contains(ingredient))
                    {
                        Console.WriteLine("ERREUR: Cet ingrédient est déja présent dans la pizza");
                    }
                    else
                    {
                        ingredients.Add(ingredient);
                        Console.WriteLine(string.Join(", ", ingredients));
                        Console.WriteLine();
                    }
                    ingredient = Console.ReadLine();
                }

                prix = 5 + ingredients.Count() * 1.50f;




        }



    }


    
}
