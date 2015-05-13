using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Class
{
    public class SearchModel
    {
        public Dictionary<string, object> Dic { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
