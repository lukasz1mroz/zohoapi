using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ZCRMSDK.CRM.Library.Setup.RestClient;
using ZCRMSDK.OAuth.Client;
using ZCRMSDK.OAuth.Contract;

namespace zohotest
{
    public class Program
    {

    //       TODO
	//- Autentykacja Shoplo: 
	//	○ Signature?
	//		§ Czy jest potrzebna do webhooks?
	//	○ Webhook
	//		§ Stworzenie + test
	//		§ Webhook -> input do metody ZohoService
	//		§ Dopracowanie use case
	//- Jak połączyć z dowolnym Zoho?
	//		§ Proces Oauth
	//		§ Automatyzacja w program cs


        // Insert data in dict from input

        public static Dictionary<string, string> config = new Dictionary<string, string>()
                {
                    { "client_id", "1000.ICQ49FRVX8OA18JMH0VA1U52LDZK7R" },
                    { "client_secret", "3ba06d6571cbc804e32c9809a4d39f9da317eb80c7" },
                    { "persistence_handler_class","ZCRMSDK.OAuth.ClientApp.ZohoOAuthInMemoryPersistence, ZCRMSDK" },
                    { "access_type", "offline" },
                    { "redirect_uri","https://localhost:44303/" },
                    { "apiBaseUrl","https://www.zohoapis.eu" },
                    { "iamURL","https://accounts.zoho.eu" },
                    { "currentUserEmail","lukasz1mroz@gmail.com" }
                };

        public static void Main(string[] args)
        {
            ZCRMRestClient.Initialize(config);
            ZohoOAuthClient client = ZohoOAuthClient.GetInstance();
            string refreshToken = "1000.e2facf5e81488b25451eef2958fef5e5.2cd91733e6db5147dbe4662cac73edc3";
            string userMailId = "lukasz1mroz@gmail.com";
            ZohoOAuthTokens tokens = client.GenerateAccessTokenFromRefreshToken(refreshToken, userMailId);
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
