using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutoSeguros.Domain
{
    public class Parametro
    {

        public static string UrlFeed = @"http://www.minutoseguros.com.br/blog/feed/";
        public static string UrlFeedLocal = "Arquivo\\feed.xml";

        public static List<string> PreposicoesEssenciais = new List<string>
        {
            "por",
            "para",
            "perante",            
            "ante",
            "até",
            "após",
            "de",
            "desde",
            "em",
            "entre",
            "com",
            "contra",
            "sem",
            "sob",
            "sobre",
            "trás",
            "e",
            "que"
        };

        public static List<string> PreposicoesAcidentais = new List<string>
        {
            "afora",
            "fora",
            "exceto",
            "salvo",
            "malgrado",
            "durante",
            "mediante",
            "segundo",
            "menos"
        };


        public static List<string> PreposicoesPrepositivas = new List<string>
        {
            "ao",
            "aonde",
            "do",
            "neste",
            "à",
            "acerca de",
            "a fim de",
            "apesar de",
            "através de",
            "de acordo com",
            "em vez de",
            "junto de",
            "para com",
            "à procura de",
            "à busca de",
            "à distância de",
            "além de",
            "antes de",
            "depois de",
            "à maneira de",
            "junto de",
            "junto a",
            "por","pelo","pela","pelos","pelas"
        };

        public static List<string> Artigos = new List<string>
        {
            "o","a","os","as","um","uns","uma","umas","ao","à","aos","às","de","do","da","dos","das"
            ,"dum","duma","duns","dumas","em","no","na","nos","nas","num","numa","nuns","numas" 
        };

        


        public static List<string> PalavrasGeral = ObterPalavrasGeral();
        

        private static List<string> ObterPalavrasGeral()
        {
            List<string> ret = new List<string>();
            ret.AddRange(PreposicoesEssenciais);
            ret.AddRange(PreposicoesAcidentais);
            ret.AddRange(PreposicoesPrepositivas);
            ret.AddRange(Artigos);
            return ret;
        }


    }

}



