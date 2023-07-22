using Newtonsoft.Json;
using pizza;
using pizza_custom;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System;
using System.Net;

namespace projet_pizza
{

    class Program
    {

        static List<Pizza> GetPizzaFromCode()
        {
            var pizzas = new List<Pizza>() {
                new Pizza("4fromages", 15, true, new List<string>{"emmental", "cantal", "Gouda"}),
                new Pizza("Barbacue", 1, true, new List<string>{"Tomate", "Viande", "Merguez"}),
                new Pizza("Margarita", 5, false, new List<string>{"Emmental", "Tomate", "Persil"}),
                new Pizza("Kebab", 51, true, new List<string>{"Viande", "Poulet", "Tomate"}),
                };

            return pizzas;
        }

        static List<Pizza> GetPizzaFromFile(string filename)
        {

            string pizzasJson = null;
            try
            {
                pizzasJson = File.ReadAllText(filename);
            }
            catch
            {
                Console.WriteLine("Erreur de lecture du fichier: " + filename);
                return null;
            }
            List<Pizza> pizzas = null;
            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzasJson);
            }
            catch
            {
                Console.WriteLine("Erreur: les données json ne sont pas valide");
                return null;
            }
            return pizzas;
        }

        static List<Pizza> GetPizzaFromUrl(string url)
        {
            string pizzasJson = null;
            List<Pizza> pizzas = null;
            var WebClient = new WebClient();
            try
            {
                pizzasJson = WebClient.DownloadString(url);
            }
            catch
            {
                Console.WriteLine("Erreur url où réseau: "+ url);
                return null;
            }
            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzasJson);
            }
            catch
            {
                Console.WriteLine("Erreur: les données json ne sont pas valide");
                return null;
            }
            return pizzas;
        }


        static string GenerateJsonFile(List<Pizza> pizzas, string filename)
        {
            string JsonPizzas = null;
            try
            {
                JsonPizzas = JsonConvert.SerializeObject(pizzas);
            }
            catch
            {
                Console.WriteLine("Erreur de serialisation");
            };

            File.WriteAllText(filename, JsonPizzas);

            return "Fichier Json générer avec succes";
        }

        










        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string filename = "pizzas.json";
            string url = "https://codeavecjonathan.com/res/pizzas2.json";

            List<Pizza> pizzas = GetPizzaFromUrl(url);
            //var g = GenerateJsonFile(pizzas, filename);
            //Console.WriteLine(g);
            //List<Pizza> pizzas = GetPizzaFromCode();


            if (pizzas != null)
            {
                foreach (var p in pizzas)
                {
                    new Pizza(p.nom, p.prix, p.vegetarienne, p.ingredients);
                }

                pizzas = pizzas.OrderBy(p => p.prix).ToList();

                Pizza pizzaPrixMin = pizzas[0];
                Pizza pizzaPrixMax = pizzas[0];

                foreach (var pizza in pizzas)
                {
                    if (pizza.prix < pizzaPrixMin.prix)
                    {
                        pizzaPrixMin = pizza;
                    }
                    if (pizza.prix > pizzaPrixMax.prix)
                    {
                        pizzaPrixMax = pizza;
                    }

                }
                foreach (var pizza in pizzas)
                {
                    pizza.Afficher();
                }

                Console.WriteLine();
                Console.WriteLine("La pizza la plus chère est: ");
                pizzaPrixMax.Afficher();
                Console.WriteLine("La pizza la plus moin est: ");
                pizzaPrixMin.Afficher();
                Console.WriteLine();
            }
            
          
        }
    }

}





