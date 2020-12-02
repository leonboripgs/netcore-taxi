using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ApiUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private string baseUrl;

        [TestInitialize]
        public void start() {
            baseUrl = "http://localhost:49526";
        }

        [TestMethod]
        public void TestApiOnline()
        {
            var result = Get($"{baseUrl}/api/test");
            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestCreateUsuario()
        {
            var usuario = new
            {
                Nombre = "Wilson",
                ApellidoPaterno = "Alcocer",
                ApellidoMaterno = "Flores",
                IdEntidad = "31",
                IdMunicipio = "050",
                Telefono = "9991878520",
                FechaNacimiento = new DateTime(1983, 10, 19),
                Imagen = ImageToBase64($@"c:\avatar.jpg")
            };

            var result = Post($"{baseUrl}/api/catalogo/Usuario", JsonConvert.SerializeObject(usuario));
            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestCreateCuentaConductorAsync()
        {
            var usuario = new
            {
                Nombre = "Wilson",
                ApellidoPaterno = "Alcocer",
                ApellidoMaterno = "Flores",
                IdEntidad = "31",
                IdMunicipio = "050",
                Telefono = "9991878521",
                FechaNacimiento = new DateTime(1983, 10, 19),
                Imagen = ImageToBase64($@"c:\avatar.jpg")
            };

            var cuenta = new {
                usuario,
                password = "x",
                email = "walcocer@gmail.com"
            };

            Console.WriteLine(JsonConvert.SerializeObject(cuenta));

            //var result = Post($"{baseUrl}/api/catalogo/conductor/cuenta", JsonConvert.SerializeObject(cuenta));            
            //Console.WriteLine(result);
        }

        public string Post(string url, string value)
        {
            var request = WebRequest.Create(url);
            var byteData = Encoding.UTF8.GetBytes(value);
            request.ContentType = "application/json";
            request.Method = "POST";

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteData, 0, byteData.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return $"{response.StatusCode}: {responseString}";
            }
            catch (WebException e)
            {
                throw new Exception($"{e.Status}: {e.Message}");
            }
        }

        public string Get(string url)
        {
            var request = WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return $"{response.StatusCode}: {responseString}";
            }
            catch (WebException e)
            {
                throw new Exception($"{e.Status}: {e.Message}");
            }
        }

        public string ImageToBase64(string path)
        {
            var file = File.ReadAllBytes(path);
            return Convert.ToBase64String(file);
        }
    }
}
