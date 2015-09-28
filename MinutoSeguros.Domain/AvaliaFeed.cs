using MinutoSeguros.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MinutoSeguros.Domain
{


    

    public class AvaliaFeed
    {

        
        /// <summary>
        /// Geral:
        /// O seu programa deverá avaliar quais as dez principais palavras abordadas nesses tópicos e qual o número de vezes que elas aparecem. 
        /// 
        /// Também deverá exibir a quantidade de palavras (chave acima) por tópico. Além disso, deverão ser removidos os artigos e preposições nessa análise.
        /// </summary>
        public AvaliaFeed()
        {                     
        }


        public FeedInfo Avaliar(List<RssFeedItem> feed)
        {
            
            Dictionary<string, List<FeedRecorrencia>> oDicKPI = new Dictionary<string, List<FeedRecorrencia>>();
            
            var listatotal = new List<string>();
            foreach (var item in feed)
            {
                StringBuilder sbTextoParaAnalise = new StringBuilder();
                sbTextoParaAnalise.Append(item.Titulo).Append(item.Conteudo);
                
                
                var filtroNaoRelevantes = RemoverCaracteresNaoRelevantes(sbTextoParaAnalise.ToString().ToLower());
                var filtro = RemoverPalavras(filtroNaoRelevantes, Parametro.PalavrasGeral);
                
                var split = SplitPalavras(filtro, " ");                
                var recorrencias = ListarRecorrencia(split).Take(10).ToList();
                
                listatotal.AddRange(split);
                oDicKPI.Add(item.Titulo, recorrencias);
                
            }
           
            var lstMaisRecorrentes = ListarRecorrencia(listatotal).Take(10).ToList();


            FeedInfo feedInfo = new FeedInfo();
                     

            feedInfo.AvaliacaoPorNoticia = oDicKPI;
            feedInfo.PalavrasMaisRecorres = lstMaisRecorrentes;
            feedInfo.Noticias = feed;
            return feedInfo;
            
        }
       
        public List<FeedRecorrencia> ListarRecorrencia(List<string> lstSplit)
        {
            var retornoAgrupado =
            lstSplit.GroupBy(g => g)            
            .Select(a => new FeedRecorrencia() { Palavra = a.Key, Recorrencia = a.Count()  })
            .OrderByDescending(o => o.Recorrencia)            
            .ToList();
            return retornoAgrupado;
            
        }

        public List<string> SplitPalavras(string texto, string separador)
        {
            Regex reg = new Regex(separador);
            var split = reg.Split(texto);
            return split.ToList();
        }

        public string RemoverPalavras(string texto, List<string> filtro)
        {
            string textoFiltrado = string.Empty;

            //Remover Palavras
            Regex reg = new Regex("(\\s\\b" + string.Join("\\b|\\s\\b", filtro.Distinct()) + "//b)");           
            textoFiltrado = reg.Replace(texto, string.Empty);
            
            return textoFiltrado;
        }

        public string RemoverCaracteresNaoRelevantes(string texto)
        {
            string textoFiltrado = string.Empty;
                        
            Regex reg = new Regex("<[^>]*>");            
            Regex reg2 = new Regex("[,\\.\\:]\\B");
            Regex reg3 = new Regex("[\t\n\r\f\v]");
                        
            textoFiltrado = reg.Replace(texto, string.Empty);
            textoFiltrado = reg2.Replace(textoFiltrado, string.Empty);
            textoFiltrado = reg3.Replace(textoFiltrado, string.Empty);

            return textoFiltrado;
        }


    }

}



