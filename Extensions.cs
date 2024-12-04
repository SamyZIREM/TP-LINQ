using System;
using System.Collections.Generic;

public static class Extensions
{
    // Méthode d'extension pour afficher tous les articles d'une collection
    public static void AfficherTous(this IEnumerable<Article> articles)
    {
        foreach (var article in articles)
        {
            article.Afficher();  
            Console.WriteLine();  
        }
    }
}
