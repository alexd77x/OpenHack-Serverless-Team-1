using System.Collections.Generic;
using System.IO;
using System.Net;
using BFYOC.Function.Data;

namespace BFYOC.Function.Providers
{
    public sealed class ProductRestProvider {
        

        public Product GetProduct(string productId)
        {
            string responseString = string.Empty;
            try{

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"https://serverlessohapi.azurewebsites.net/api/GetProduct?productId={productId}");
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    responseString = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }catch{
                return null;
            }
            if(string.IsNullOrEmpty(responseString))
                return null;
            Product result = null;
            
            try{
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(responseString);
            }catch{}

            return result;
        } 

        public List<Product> GetProducts()
        {
            string responseString = string.Empty;
            try{
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://serverlessohapi.azurewebsites.net/api/GetProducts");
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    responseString = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }catch{
                return null;
            }

            if(string.IsNullOrEmpty(responseString))
                return null;
            List<Product> result = null;
            
            try{
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(responseString);
            }catch{}
            
            return result;
        } 
    }
}