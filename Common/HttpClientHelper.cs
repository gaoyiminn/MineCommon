using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class HttpClientHelper
    {

        private static HttpClient _HttpClient = null;
        static HttpClientHelper()
        {
            _HttpClient = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip });
        }
        public static HttpClient GetHttpClient()
        {
            return _HttpClient;
        }

        public static string SendGetRequest(string url)
        {
            var response = _HttpClient.GetAsync(url).Result;//拿到异步结果
            Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
                                                    //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
            return response.Content.ReadAsStringAsync().Result;
        }

        public static string SendPostRequest(string url, Dictionary<string, string> dic)
        {
            var content = new FormUrlEncodedContent(dic);
            var response = _HttpClient.PostAsync(url, content).Result;
            //Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
            return response.Content.ReadAsStringAsync().Result;
        }

        public static string SendPutRequest(string url, Dictionary<string, string> dic)
        {
            var content = new FormUrlEncodedContent(dic);
            var response = _HttpClient.PutAsync(url, content).Result;
            //Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
            return response.Content.ReadAsStringAsync().Result;
        }

        public static string SendDeleteRequest(string url, Dictionary<string, string> dic)
        {
            var content = new FormUrlEncodedContent(dic);
            var response = _HttpClient.DeleteAsync(url).Result;
            //Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
            return response.Content.ReadAsStringAsync().Result;
        }


        #region HttpClient Get
        /// <summary>
        /// HttpClient实现Get请求
        /// </summary>
        private string GetClient()
        {
            //string url = "http://localhost:8088/api/users/GetUserByName?username=superman";
            //string url = "http://localhost:8088/api/users/GetUserByID?id=1";
            //string url = "http://localhost:8088/api/users/GetUserByNameId?userName=Superman&id=1";
            //string url = "http://localhost:8088/api/users/Get";
            //string url = "http://localhost:8088/api/users/GetUserByModel?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            string url = "http://localhost:8088/api/users/GetUserByModelUri?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            //string url = "http://localhost:8088/api/users/GetUserByModelSerialize?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "http://localhost:8088/api/users/GetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "http://localhost:8088/api/users/NoGetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            var handler = new HttpClientHandler();//{ AutomaticDecompression = DecompressionMethods.GZip };

            using (var http = new HttpClient(handler))
            {
                var response = http.GetAsync(url).Result;//拿到异步结果
                Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        #endregion

        #region HttpWebRequest实现Get请求
        /// <summary>
        /// HttpWebRequest实现Get请求
        /// </summary>
        private string GetWebQuest()
        {
            //string url = "http://localhost:8088/api/users/GetUserByName?username=superman";
            //string url = "http://localhost:8088/api/users/GetUserByID?id=1";
            //string url = "http://localhost:8088/api/users/GetUserByNameId?userName=Superman&id=1";
            //string url = "http://localhost:8088/api/users/Get";
            //string url = "http://localhost:8088/api/users/GetUserByModel?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            //string url = "http://localhost:8088/api/users/GetUserByModelUri?UserID=11&UserName=Eleven&UserEmail=57265177%40qq.com";
            string url = "http://localhost:8088/api/users/GetUserByModelSerialize?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "http://localhost:8088/api/users/GetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";
            //string url = "http://localhost:8088/api/users/NoGetUserByModelSerializeWithoutGet?userString=%7B%22UserID%22%3A%2211%22%2C%22UserName%22%3A%22Eleven%22%2C%22UserEmail%22%3A%2257265177%40qq.com%22%7D";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 30 * 1000;

            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        #endregion

        #region HttpClient实现Post请求
        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        private string PostClient()
        {
            //string url = "http://localhost:8088/api/users/register";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "http://localhost:8088/api/users/RegisterNoKey";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "http://localhost:8088/api/users/RegisterUser";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"UserID","11" },
            //    {"UserName","Eleven" },
            //    {"UserEmail","57265177@qq.com" },
            //};

            string url = "http://localhost:8088/api/users/RegisterObject";
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"User[UserID]","11" },
                {"User[UserName]","Eleven" },
                {"User[UserEmail]","57265177@qq.com" },
                {"Info","this is muti model" }
            };

            HttpClientHandler handler = new HttpClientHandler();
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(dic);
                var response = http.PostAsync(url, content).Result;
                Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
                return response.Content.ReadAsStringAsync().Result;
            }

        }
        #endregion

        #region  HttpWebRequest实现post请求
        /// <summary>
        /// HttpWebRequest实现post请求
        /// </summary>
        private string PostWebQuest()
        {
            //string url = "http://localhost:8088/api/users/register";
            //var postData = "1";

            //string url = "http://localhost:8088/api/users/RegisterNoKey";
            //var postData = "1";

            var user = new
            {
                UserID = "11",
                UserName = "Eleven",
                UserEmail = "57265177@qq.com"
            };
            //string url = "http://localhost:8088/api/users/RegisterUser";
            //var postData = JsonHelper.ObjectToString(user);

            var userOther = new
            {
                User = user,
                Info = "this is muti model"
            };
            string url = "http://localhost:8088/api/users/RegisterObject";
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(userOther);

            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;//设置30s的超时
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "POST";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
        #endregion

        #region HttpClient实现Put请求
        /// <summary>
        /// HttpClient实现Put请求
        /// </summary>
        private string PutClient()
        {
            string url = "http://localhost:8088/api/users/RegisterPut";
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"","1" }
            };

            //string url = "http://localhost:8088/api/users/RegisterNoKeyPut";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "http://localhost:8088/api/users/RegisterUserPut";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"UserID","11" },
            //    {"UserName","Eleven" },
            //    {"UserEmail","57265177@qq.com" },
            //};

            //string url = "http://localhost:8088/api/users/RegisterObjectPut";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"User[UserID]","11" },
            //    {"User[UserName]","Eleven" },
            //    {"User[UserEmail]","57265177@qq.com" },
            //    {"Info","this is muti model" }
            //};

            HttpClientHandler handler = new HttpClientHandler();
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(dic);
                var response = http.PutAsync(url, content).Result;
                Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
                return response.Content.ReadAsStringAsync().Result;
            }

        }
        #endregion

        #region  HttpWebRequest实现put请求
        /// <summary>
        /// HttpWebRequest实现put请求
        /// </summary>
        private string PutWebQuest()
        {
            //string url = "http://localhost:8088/api/users/registerPut";
            //var postData = "1";

            //string url = "http://localhost:8088/api/users/RegisterNoKeyPut";
            //var postData = "1";

            var user = new
            {
                UserID = "11",
                UserName = "Eleven",
                UserEmail = "57265177@qq.com"
            };
            //string url = "http://localhost:8088/api/users/RegisterUserPut";
            //var postData = JsonHelper.ObjectToString(user);

            var userOther = new
            {
                User = user,
                Info = "this is muti model"
            };
            string url = "http://localhost:8088/api/users/RegisterObjectPut";
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(userOther);

            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;//设置30s的超时
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "PUT";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
        #endregion

        #region HttpClient实现Delete请求
        /// <summary>
        /// HttpClient实现Put请求
        /// 没放入数据
        /// </summary>
        private string DeleteClient()
        {
            string url = "http://localhost:8088/api/users/RegisterDelete/1";
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"","1" }
            };

            //string url = "http://localhost:8088/api/users/RegisterNoKeyDelete";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"","1" }
            //};

            //string url = "http://localhost:8088/api/users/RegisterUserDelete";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"UserID","11" },
            //    {"UserName","Eleven" },
            //    {"UserEmail","57265177@qq.com" },
            //};

            //string url = "http://localhost:8088/api/users/RegisterObjectDelete";
            //Dictionary<string, string> dic = new Dictionary<string, string>()
            //{
            //    {"User[UserID]","11" },
            //    {"User[UserName]","Eleven" },
            //    {"User[UserEmail]","57265177@qq.com" },
            //    {"Info","this is muti model" }
            //};

            HttpClientHandler handler = new HttpClientHandler();
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(dic);
                var response = http.DeleteAsync(url).Result;
                Console.WriteLine(response.StatusCode); //确保HTTP成功状态值
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        #endregion

        #region  HttpWebRequest实现put请求
        /// <summary>
        /// HttpWebRequest实现put请求
        /// </summary>
        private string DeleteWebQuest()
        {
            //string url = "http://localhost:8088/api/users/registerDelete";
            //var postData = "1";

            //string url = "http://localhost:8088/api/users/RegisterNoKeyDelete";
            //var postData = "1";

            var user = new
            {
                UserID = "11",
                UserName = "Eleven",
                UserEmail = "57265177@qq.com"
            };
            //string url = "http://localhost:8088/api/users/RegisterUserDelete";
            //var postData = JsonHelper.ObjectToString(user);

            var userOther = new
            {
                User = user,
                Info = "this is muti model"
            };
            string url = "http://localhost:8088/api/users/RegisterObjectDelete";
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(userOther);

            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000;//设置30s的超时
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36";
            request.ContentType = "application/json";
            request.Method = "Delete";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            postStream.Close();

            string result = "";
            using (var res = request.GetResponse() as HttpWebResponse)
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
        #endregion


    }
}
