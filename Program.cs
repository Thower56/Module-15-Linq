using ExperimentationsLINQ;

internal class Program
{
    private static void Main(string[] args)
    {
        System.Console.WriteLine("-----------------1----------------------");
        ObjectDumper.Write(Identite(15));
        
        Func<int,int> fctIdentite_V01 = (int x) => x;
        System.Console.WriteLine("-----------------2----------------------");
        ObjectDumper.Write(fctIdentite_V01(10));

        System.Console.WriteLine("-----------------3----------------------");
        System.Console.WriteLine("Le carre est: " + Carre(2.0));

        System.Console.WriteLine("-----------------4----------------------");
        Func<double, double> fctCarre_V01 = (double x) => x * x ;
        ObjectDumper.Write(fctCarre_V01(5.0));

        System.Console.WriteLine("-----------------5----------------------");
        Func<int,int,int> fctAddition_V01 = (int x, int y) => x + y;
        ObjectDumper.Write(fctAddition_V01(10, 20));

        System.Console.WriteLine("-----------------6----------------------");
        System.Console.WriteLine("La resultat est : " + Multiplication(5,10));

        System.Console.WriteLine("-----------------7----------------------");
        Func<int, int, double> fctMultiplication_V01 = (int x, int y) => x * y;
        ObjectDumper.Write(fctMultiplication_V01(3,12));

        System.Console.WriteLine("-----------------8----------------------");
        Func<int,int,int> fctAddition_V02 = (x, y) => x + y;
        ObjectDumper.Write(fctAddition_V02(8,8));

        System.Console.WriteLine("-----------------9----------------------");
        ObtenirElement01_SyntaxeRequete_v01();

        System.Console.WriteLine("-----------------10----------------------");
        ObtenirSousListeCategorieCondiments_SyntaxeRequete_v01();

        System.Console.WriteLine("-----------------11----------------------");
        ObtenirElement01_SyntaxeMethode_v01();

        System.Console.WriteLine("-----------------12----------------------");
        ObtenirSousListeCategorieCondiments_SyntaxeMethode_v01();

        System.Console.WriteLine("-----------------13----------------------");
        ObtenirSousListePrixSupp100_SyntaxeRequete_v01();

        System.Console.WriteLine("-----------------14----------------------");
        ObtenirSousListePrixSupp100_SyntaxeMethode_v01();

        System.Console.WriteLine("-----------------15----------------------");
        ObtenirElement01_SyntaxeRequete_v02();
        System.Console.WriteLine("-----------------16----------------------");
        ObtenirListeNomsProduits_SyntaxeRequete_v01();
    }

    // --------------------------------------------#Chercher un produit par ID#-------------------------------------------------------------------
    private static void ObtenirElement01_SyntaxeRequete_v01()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = from produit in produits
                        where produit.ProductID == 12
                        select produit;
        
        ObjectDumper.Write(resultat);
    }

    private static void ObtenirElement01_SyntaxeMethode_v01()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = produits.Where(p => p.ProductID == 12);

        ObjectDumper.Write(resultat);
    }
    // --------------------------------------------#Chercher un produit par Category#-------------------------------------------------------------------
    private static void ObtenirSousListeCategorieCondiments_SyntaxeRequete_v01()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = from produit in produits 
                        where produit.Category == "Condiments"
                        select produit;

        ObjectDumper.Write(resultat);
    }

    private static void ObtenirSousListeCategorieCondiments_SyntaxeMethode_v01()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = produits.Where(p => p.Category == "Condiments");

        ObjectDumper.Write(resultat);
    }
    // --------------------------------------------#Chercher un produit par Prix#-------------------------------------------------------------------
    private static void ObtenirSousListePrixSupp100_SyntaxeRequete_v01()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = from produit in produits
                        where produit.UnitPrice >= 100.0000m
                        select produit;

        ObjectDumper.Write(resultat);
    }
    private static void ObtenirSousListePrixSupp100_SyntaxeMethode_v01()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = produits.Where(p => p.UnitPrice >= 100.0000m);

        ObjectDumper.Write(resultat);
    }
    // ------------------------------------#Chercher UN seul (si multiple) produit par ID avec un default#-------------------------------------------------------------------
    private static void ObtenirElement01_SyntaxeRequete_v02()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = (from produit in produits
                        where produit.ProductID == 12
                        select produit).SingleOrDefault();
        
        ObjectDumper.Write(resultat);
    }

    private static void ObtenirElement01_SyntaxeMethode_v02()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = produits.Where(p => p.ProductID == 12).SingleOrDefault();
        
        ObjectDumper.Write(resultat);
    }

    // --------------------------------------------#Chercher UN seul (si multiple) produit par ID#-------------------------------------------------------------------
    
    private static void ObtenirElement01_SyntaxeRequete_v02Bis()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = (from produit in produits
                        where produit.ProductID == 12
                        select produit).Single();
        
        ObjectDumper.Write(resultat);
    }

    private static void ObtenirElement01_SyntaxeMethode_v02Bis()
    {
        var produits = DonneesLINQ.CreateProductList();
        var resultat = produits.Where(p => p.ProductID == 12).Single();
        
        ObjectDumper.Write(resultat);
    }

    // --------------------------------------------#Retour tout les noms des produits#-------------------------------------------------------------------

    private static void ObtenirListeNomsProduits_SyntaxeRequete_v01()
    {
        var produits = DonneesLINQ.CreateProductList();
        var categories = from produit in produits
                        select produit.ProductName;

        ObjectDumper.Write(categories);
    }
    private static void ObtenirListeNomsProduits_SyntaxeMethode_v01()
    {
        var produits = DonneesLINQ.CreateProductList();
        var categories = produits.Select(p => p.ProductName);

        ObjectDumper.Write(categories);
    }

    private static int Identite(int val)
    {
        return val;
    }

    public static double Carre(double x)
    {
        return x * x;
    }

    public static double Multiplication(int x, int y)
    {
        return x * y;
    }
}