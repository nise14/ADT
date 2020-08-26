using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Modelos
{
    public class Programas
    {
            public int id { get; set; }
            public string url { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string language { get; set; }
            public string[] genres { get; set; }
            public string status { get; set; }
            public int runtime { get; set; }
            public string premiared { get; set; }
            public string image { get; set; }

    }
}
