using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WSC2019_Module1.Object;

namespace WSC2019_Module1.Service
{
    public class AssetService
    {
        public static string tempUrl = "https://f37e-210-186-104-176.ngrok.io/Home/";


        private HttpClient client = new HttpClient();
        private List<AssetClass> assetClasses;
        private List<Temp> tempClasses;

        public async Task<List<AssetClass>> GetAssetListData(string dateFrom, string dateEnd, string asset, string dept, string searchText)
        {
            string url = string.Format(tempUrl + "getAssetRecordList?dateFrom={0}&dateEnd={1}&asset={2}&dept={3}&searchText={4}",
                    dateFrom, dateEnd, asset, dept, searchText);

            var response = await client.GetStringAsync(url);


            var _assetClasses = JsonConvert.DeserializeObject<List<AssetClass>>(response);
            assetClasses = new List<AssetClass>(_assetClasses);

            return assetClasses;
        }

        public async Task<List<Temp>> GetAssetID(string dept, string assetGroup)
        {
            string url = string.Format(tempUrl + "getAssetID?dept={0}&assetGroup={1}",
                    dept, assetGroup);

            var response = await client.GetStringAsync(url);

            var _assetClasses = JsonConvert.DeserializeObject<List<Temp>>(response);
            tempClasses = new List<Temp>(_assetClasses);

            return tempClasses;
        }

        
    }
}
