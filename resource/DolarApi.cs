using dolar_api.model;
using System.Net.Http.Headers;

namespace dolar_api.resource
{
    public class DolarApi //dentro de la clase hacemos el metodo para obtener la cotiz del dolar
    {
        public async Task<string> ObtenerCotizacion() //task: lista que devuelve un json
        {
            string responseBody = string.Empty; //variable para almacenar rta de la API

            using (var client = new HttpClient()) //este using inicializa el cliente HTTP
            {
                client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/blue");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode(); //si la solicitud no fue exitosa lanza una excepcion
                responseBody = response.Content.ReadAsStringAsync().Result;
            }
            return responseBody; //respuesta tipo string

        }


        public async Task<string> ObtenerCotizacionEspecifica(Currency currency)
        {

            string responseBody = string.Empty; //var para guardar la rta, se inicia vacia
            using (var client = new HttpClient())
            {
                switch (currency.Code.ToUpper())
                {
                    case "BOLSA":
                        client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/bolsa");
                        break;

                    case "BLUE":
                        client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/blue");
                        break;

                    case "CRIPTO":
                        client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/cripto");
                        break;

                    default:
                        throw new ArgumentException("error en el tipo de cotizacion");
                }

                client.DefaultRequestHeaders.Accept.Clear(); //para limpiar los encabezados
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //define el encabezado para esperar JSON

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress); //realiza la solicitud get a la url seleccionada

                response.EnsureSuccessStatusCode(); //lanza una excepcion  si la solicitud no fue exitosa
                responseBody = response.Content.ReadAsStringAsync().Result; //lee y almacena el contenido de la rta de forma asincronica



            }

            return responseBody; //retorna el cuerpo de la rta en formato JSON

        }

    }

}
 
