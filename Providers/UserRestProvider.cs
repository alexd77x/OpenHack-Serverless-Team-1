using System.IO;
using System.Net;
using BFYOC.Function.Data;
using System.Collections.Generic;

namespace BFYOC.Function.Providers
{
    public sealed class UserRestProvider {

        
        public User GetUser(string userId)
        {
            string responseString = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"https://serverlessohapi.azurewebsites.net/api/GetUser?userId={userId}");
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
            User result = null;
            
            try{
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(responseString);
            }catch{}

            return result;
        } 

        public List<User> GetUsers()
        {
            string responseString = string.Empty;
            try{

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://serverlessohapi.azurewebsites.net/api/GetUsers");
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
            List<User> result = null;
            
            try{
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(responseString);
            }catch{}

            return result;
        } 
    }
}