using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab3TP6
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Replace("bin\\Debug", "");

            Gestor gestor = new Gestor();
            List<Escritor> escritores = gestor.ConsultaEscritores();
            EscribirJsonFile(escritores, path + "/JSONFile.json");

            LeerJSONFromURL();
        }

        public static void EscribirJsonFile(List<Escritor> escritores, string pathFile)
        {
            string jsonFile = JsonConvert.SerializeObject(escritores.ToArray(), Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(pathFile, jsonFile);
        }

        public static void LeerJSONFromURL()
        {

            var url = "https://randomuser.me/api/?results=10";

            WebClient wc = new WebClient();
            string usuariosFuente = wc.DownloadString(url);

            var informacion = JsonConvert.DeserializeObject<Informacion>(usuariosFuente);
            var usuarios = informacion.results;

            foreach (Result usuario in usuarios)
            {
                Console.WriteLine("First name: " + usuario.name.first);
                Console.WriteLine("Last name: " + usuario.name.last);
                Console.WriteLine("Username: " + usuario.login.username);    
                Console.WriteLine("Password: " + usuario.login.password);
                Console.WriteLine("-----------------------------\n\n");
            }
        }
    }
}
