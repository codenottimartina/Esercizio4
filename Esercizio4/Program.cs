//convertitore numeri romani: il software chiede all'utente di inserire un numero intero, fra 1 e 1000.
//Dopo l'inserimento di un numero valido, stampa a video il numero convertito in numero romano.
//esempi di input/output

//1 = I
//2 = II
//3 = III
//4 = IV
//5 = V
//6 = VI
//7 = VII
//8 = VIII
//9 = IX
//10 = X
//11 = XI
//..etc..
//19 = XIX
//20 = XX
//30 = XXX
//40 = XL
//41 = XLI
//42 = XLII
//..etc..
//50 = L
//60 = LX
//70 = LXX
//80 = LXXX
//90 = XC
//91 = XCI
//100 = C

//using System.Diagnostics;

//string stringaAcquisita;
//int numeroAcquisito;
//string numeroConvertito = "";
//int count = 0;
//do
//{
//    if (count > 0)
//    {
//        Console.WriteLine("importo inserito non valido");
//    }
//    Console.WriteLine("Inserisci un numero da 1 a 1000");
//    stringaAcquisita = Console.ReadLine();
//    count++;
//}
//while (!Int32.TryParse(stringaAcquisita, out numeroAcquisito) || numeroAcquisito > 1000 || numeroAcquisito < 1);

//Console.WriteLine("Numero inserito: " + numeroAcquisito);
//List<string> numeriRomani = new List<string>()
//{
//    "I", "V", "X", "L", "C", "D", "M"
//};

//var div10 = 100;
//var posLettera = 4;
//while(numeroAcquisito > 0)
//{
//    if(numeroAcquisito == 1000)
//    {
//        numeroConvertito = numeriRomani[6];
//        break;
//    }

//    var num = numeroAcquisito / div10;
//    numeroAcquisito %= div10;

//    if(num == 9)
//    {
//        numeroConvertito += numeriRomani[posLettera] + numeriRomani[posLettera + 2];
//        num -= 9;
//    }
//    else if(num >= 5)
//    {
//        numeroConvertito += numeriRomani[posLettera+1];
//        num -= 5;
//    }
//    else if(num == 4)
//    {
//        numeroConvertito += numeriRomani[posLettera] + numeriRomani[posLettera+1];
//        num -= 4;
//    }
//    numeroConvertito += string.Concat(Enumerable.Repeat(numeriRomani[posLettera], num));
//    div10 /= 10;
//    posLettera -= 2;
//}

//Console.WriteLine("Numero convertito: " + numeroConvertito);

//var dictValoriCorrispondenze = new Dictionary<int, string>();

//dictValoriCorrispondenze[1] = "I";
//dictValoriCorrispondenze[4] = "IV";
//dictValoriCorrispondenze[5] = "V";
//dictValoriCorrispondenze[9] = "IX";
//dictValoriCorrispondenze[10] = "X";
//dictValoriCorrispondenze[40] = "XL";
//dictValoriCorrispondenze[50] = "L";
//dictValoriCorrispondenze[90] = "XC";
//dictValoriCorrispondenze[100] = "C";
//dictValoriCorrispondenze[400] = "CD";
//dictValoriCorrispondenze[500] = "D";
//dictValoriCorrispondenze[900] = "CM";
//dictValoriCorrispondenze[1000] = "M";

//int resto = numeroAcquisito;

//string risultato = "";

//while(resto > 0)
//{
//    var valMassimo = Utils.GetValoreMassimoFromDict(resto, dictValoriCorrispondenze);

//    resto -= valMassimo;

//    risultato += dictValoriCorrispondenze[valMassimo];
//}

//Console.WriteLine(risultato);
//Console.ReadLine();

//public static class Utils
//{
//    public static int GetValoreMassimoFromDict(int resto, Dictionary<int, string> dictValori)
//    {
//        foreach(var kvp in dictValori.Reverse())
//        {
//            if (kvp.Key <= resto)
//            {
//                return kvp.Key;
//            }
//        }

//        throw new Exception("c'è qualcosa che è andato storto..");
//    }
//}

var impostaFiltroSuPrimaLetteraNomeUgualeAP = true;

var studenti = new List<Studente>()
{
    new Studente()
    {
        Nome = "pippo",
        Eta = 12,
        DataNascita = DateTime.Now.AddDays(-320)
    },
    new Studente()
    {
        Nome = "pluto",
        Eta = 21,
        DataNascita = DateTime.Now.AddDays(-180)
    },
    new Studente()
    {
        Nome = "paperino",
        Eta = 34,
        DataNascita = DateTime.Now.AddDays(-3220)
    },
    new Studente()
    {
        Nome = "minni",
        Eta = 6,
        DataNascita = DateTime.Now.AddDays(-10)
    },
    new Studente()
    {
        Nome = "topolino",
        Eta = 19,
        DataNascita = DateTime.Now.AddDays(-280)
    },
};

var studentiFiltrati = studenti
    .Where(m => m.Eta > 10);

if (impostaFiltroSuPrimaLetteraNomeUgualeAP)
    studentiFiltrati = studentiFiltrati.Where(m => m.Nome != null && m.Nome.Substring(0, 1).ToUpper() == "P");

var counterIdIscrizioni = 0;

var iscrizioni = studentiFiltrati.Select(studente =>
{
    var toReturn = new IscrizioneStudente();
    toReturn.IdIscrizione = counterIdIscrizioni++;
    toReturn.Soggetto = studente;

    return toReturn;
});

foreach(var iscrizione in iscrizioni)
{
    Console.WriteLine("Id. iscrizione: " + iscrizione.IdIscrizione + " - nome stud. " + iscrizione.Soggetto.Nome);
}

Console.ReadLine();

    //.ToList();

public class Studente
{
    private string _nome = null;

    public string Nome { get 
        { 
            return _nome; 
        } 
        set 
        { 
            _nome = value; 
        } 
    }
    public int Eta { get; set; }
    public DateTime DataNascita { get; set; }
}

public class IscrizioneStudente
{
    public Studente Soggetto { get; set; }
    public int IdIscrizione { get; set; }
}