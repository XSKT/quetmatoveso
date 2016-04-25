using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XSKtWEBSERVICE.Models;
using Newtonsoft.Json;
using XSKtWEBSERVICE.Common;

namespace XSKtWEBSERVICE.Controllers
{
    public class AuthorizationController : ApiController
    {
        // GET api/authorization
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/authorization/5
        public ResultToken Get(string key)
        {
            ResultAuthe resultAutho = new ResultAuthe();
            resultAutho.Key = key;
            foreach (string item in arry)
            {
                if (item.Equals(key))
                {
                    resultAutho.Result = true;
                    break;
                }
            }
            
            ResultToken result = new ResultToken();
            result.Token=DecryptAndEcryptData.Encrypt(JsonConvert.SerializeObject(resultAutho), DecryptAndEcryptData.GetConfigEncrytKey(), DecryptAndEcryptData.IsHashEncryptDecryptEnable());
            return result;
        }

        // POST api/authorization
        public void Post([FromBody]string value)
        {
        }

        // PUT api/authorization/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/authorization/5
        public void Delete(int id)
        {
        }

string[] arry = new string[]{

         "WzVhbXVv/C26L9wKsU25SKiQPvKX4F/c",
         "WzVhbXVv/C26L9wKsU25SE1dXMaPawie",
         "WzVhbXVv/C26L9wKsU25SGyX8Qd+YvFn",
         "WzVhbXVv/C26L9wKsU25SF3KaIQDNRfY",
         "WzVhbXVv/C26L9wKsU25SDJtHz+Wk2Cb",
         "WzVhbXVv/C26L9wKsU25SOzTvFdA1yZQ",
         "WzVhbXVv/C26L9wKsU25SIC5r/yayx1x",
         "WzVhbXVv/C26L9wKsU25SNo/oCcotCiO",
         "WzVhbXVv/C26L9wKsU25SIPdIHr8SLXp",
         "WzVhbXVv/C26L9wKsU25SMBTXrSfRWJA",
         "WzVhbXVv/C26L9wKsU25SPLwbOC6DzaM",
         "WzVhbXVv/C26L9wKsU25SMY72cw0rEzK",
         "WzVhbXVv/C26L9wKsU25SNIqTjkMKGz6",
         "WzVhbXVv/C26L9wKsU25SB7eLIpPMp6q",
         "WzVhbXVv/C26L9wKsU25SAjig0SjnjHV",
         "WzVhbXVv/C26L9wKsU25SM+aLdj/NV2C",
         "WzVhbXVv/C26L9wKsU25SNk/tuuSFW1m",
         "WzVhbXVv/C26L9wKsU25SC0p5DpTx85K",
         "WzVhbXVv/C26L9wKsU25SKj1naH+c7c6",
         "WzVhbXVv/C26L9wKsU25SGIpORRxwRWz",
         "WzVhbXVv/C26L9wKsU25SNYOQmRIg4Sg"
     };

    }
}
