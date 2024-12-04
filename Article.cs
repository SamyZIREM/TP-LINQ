using System.Text.Json.Serialization;

public class Article
{
    public string Designation { get; set; } 
    public double Prix { get; set; }       
    public int Quantite { get; set; }           
    public ArticleType Type { get; set; } 

    // Constructeur sans paramètres
    public Article() { }
    public Article(string designation, double prix, int quantite, ArticleType ArticleType)
    {
        Designation = designation;
        Prix = prix;
        Quantite = quantite;
        Type = ArticleType;
    }

    public void Afficher()
    {
        Console.WriteLine($"Nom: {Designation}, Prix: {Prix}€, Quantité: {Quantite}, Type: {Type}");
    }

    public void Ajouter(int quantite)
    {
        if (quantite > 0)
            Quantite += quantite;
    }

    public void Retirer(int quantite)
    {
        if (quantite > 0 && Quantite >= quantite)
            Quantite -= quantite;
    }
}
