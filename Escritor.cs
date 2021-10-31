using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3TP6
{
    class Escritor
    {
        public int id { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int dni { get; set; }
        public List<Libro> libros { get; set; }
    }
}
