using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Comunication.Response
{
    public class ResponseBooksJson
    {
        public ResponsePaginationJson Pagination { get; set; } = default!;
        public List<ResponseBookJson> Books { get; set; } = [];
    }
}
