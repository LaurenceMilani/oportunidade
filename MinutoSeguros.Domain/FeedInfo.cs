using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutoSeguros.Domain
{
    public class FeedInfo
    {
        public Dictionary<string, List<FeedRecorrencia>> AvaliacaoPorNoticia { get; set; }
        public List<FeedRecorrencia> PalavrasMaisRecorres { get; set; }
        public List<RssFeedItem> Noticias { get; set; }
    }
}
