using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_Hacktoberfest_C_Sharp
{
    public class ApiCalls
    {
        public async Task<DictionaryModel> LoadDictionary()
        {
            string url = "https://api.dictionaryapi.dev/api/v2/entries/en/";

            using (HttpResponseMessage response = await DictionaryAPI.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DictionaryModel dictionary = await response.Content.ReadAsAsync<DictionaryModel>();

                    return dictionary;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
