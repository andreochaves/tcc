using Nancy.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuestAdventure.Service
{
	public class QuestService
	{
		string url = "https://c07c-2804-e80-41d-1a00-b87d-a70f-3bdf-debd.ngrok-free.app/Quest/api/";

		public async Task<HttpResponseMessage> GetResponse(string endpoint)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage getData = await client.GetAsync(endpoint);
				return getData;
			}
		}

		public async Task<HttpResponseMessage> PostResponse(string endpoint,string registro,Object obj)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(url+endpoint);
				var serializer = new JavaScriptSerializer();
				var json = serializer.Serialize(obj);
				var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
				var result = await client.PostAsync(registro.ToLower(), stringContent);
				return result;
			}
		}

		public async Task<HttpResponseMessage> PutResponse(string endpoint, int registro, Object obj)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(url + endpoint);
				var serializer = new JavaScriptSerializer();
				var json = serializer.Serialize(obj);
				var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
				var result = await client.PutAsync(registro.ToString(), stringContent);
				return result;
			}
		}

		public async Task<HttpResponseMessage> DeleteResponse(string endpoint,string id)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(url+endpoint);
				HttpResponseMessage getData = await client.DeleteAsync(id);
				return getData;
			}
		}
	}
}
