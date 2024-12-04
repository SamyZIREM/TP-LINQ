using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO; 

class Program
{
    static void Main(string[] args)
    {
        // Etape 1 : Initialisation d'une liste d'Articles
        List<Article> Articles = new List<Article>
        {
            new Article("Pomme", 2.5, 50, ArticleType.Alimentaire),
            new Article("Savon", 3.2, 30, ArticleType.Droguerie),
            new Article("T-shirt", 15.0, 20, ArticleType.Habillement)
        };

        // Affichage des Articles
        Console.WriteLine("Liste des Articles :");
        foreach (var Article in Articles)
        {
            Article.Afficher(); // Appelle la méthode Afficher de Article
            Console.WriteLine(); // Ligne vide pour la lisibilité
        }
         //---------------------------------------------------------------
         // Etape 2: Lister tous les Articles de type "Alimentaire"
        var ArticlesAlimentaire = Articles.Where(a => a.Type == ArticleType.Alimentaire).ToList();
        Console.WriteLine("Articles de type 'Alimentaire' :");
        foreach (var Article in ArticlesAlimentaire)
        {
            Article.Afficher();
        }
        Console.WriteLine();

        //  Etape 2: Trier les Articles par prix décroissant
        var ArticlesTries = Articles.OrderByDescending(a => a.Prix).ToList();
        Console.WriteLine("Articles triés par prix décroissant :");
        foreach (var Article in ArticlesTries)
        {
            Article.Afficher();
        }
        Console.WriteLine();

        //  Etape 2: Calculer le stock total de tous les Articles
        var stockTotal = Articles.Sum(a => a.Quantite);
        Console.WriteLine($"Le stock total de tous les Articles est : {stockTotal} Articles");

        // Etape 2 : Création d'une liste contenant des objets Article et autres 
        // Créer une collection contenant des objets de différents types
        var collectionMixte = new List<object>
        {
            new Article("Pomme", 2.5, 50, ArticleType.Alimentaire),
            new Article("Savon", 3.2, 30, ArticleType.Droguerie),
            "Un simple texte",    // Type String 
            1234,                 // Entier
            new Article("T-shirt", 15.0, 20, ArticleType.Habillement)
        };

        // Utiliser l'opérateur OfType pour extraire uniquement les objets de type Article
        var articles = collectionMixte.OfType<Article>().ToList();

        // Afficher les articles extraits
        Console.WriteLine("Articles extraits :");
        foreach (var article in articles)
        {
            article.Afficher();
        }
        //---------------------------------------------------------
        //Etape 2 : // Créer une collection contenant des articles
        var collectionArticles = new List<Article>
        {
            new Article("Pomme", 2.5, 50, ArticleType.Alimentaire),
            new Article("Savon", 3.2, 30, ArticleType.Droguerie),
            new Article("T-shirt", 15.0, 20, ArticleType.Habillement)
        };

        // Projection avec des types anonymes : conserver uniquement le nom et le prix
        var articlesProjection = collectionArticles
            .Select(article => new
            {
                Nom = article.Designation,
                Prix = article.Prix
            })
            .ToList();

        // Afficher les articles projetés (les types anonymes)
        Console.WriteLine("Articles avec projection :");
        foreach (var item in articlesProjection)
        {
            Console.WriteLine($"Nom: {item.Nom}, Prix: {item.Prix}€");
        }

        //-----------------------------------------------------------
        //Etape 3: // Reprise de collectionArticles définie à l'étape 2 

        // Test de la méthode d'extension AfficherTous()
        Console.WriteLine("Affichage de tous les articles :");
        collectionArticles.AfficherTous();

        //------------------------------------------------------------------
        // Calcul de la valeur totale du stock en utilisant une expression lambda
        var valeurTotale = collectionArticles
            .Sum(article => article.Prix * article.Quantite); 
        Console.WriteLine($"Valeur totale du stock : {valeurTotale}€");

        //-------------------------------------------------------------------
        //Etape 4: // Sérialisation de la liste d'articles en JSON
        string jsonString = JsonSerializer.Serialize(collectionArticles, new JsonSerializerOptions { WriteIndented = true });

        // Affichage du JSON dans la console pour vérifier
        Console.WriteLine(jsonString);

        // Exportation du JSON vers un fichier
        string filePath = "C://Users//Administrateur//Desktop//Cours_M2//C# & .NET//articles.json";
        File.WriteAllText(filePath, jsonString);  // Sauvegarde dans le fichier articles.json

        Console.WriteLine($"\nLes articles ont été exportés vers le fichier : {filePath}");

        //-------------------------------------------------------------------
        // 4. Désérialisation JSON : Charger les articles depuis le fichier JSON
            Console.WriteLine("Chargement des articles depuis le fichier JSON...");
            try
            {
                if (File.Exists(filePath))
                {
                    string JsonString = File.ReadAllText(filePath);
                    List<Article> articlesImportes = JsonSerializer.Deserialize<List<Article>>(JsonString);

                    // Affichage des articles importés
                    Console.WriteLine("Articles importés :");
                    if (articlesImportes != null)
                    {
                        foreach (var article in articlesImportes)
                        {
                            article.Afficher();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Le fichier {filePath} n'existe pas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement : {ex.Message}");
            }
    }

        


}
