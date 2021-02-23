using AdvisementManagerWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AdvisementManagerWebApp.Utility
{
    public interface IClientStorageManager
    {
        void Store(string key, string value);
    }
    public class CookieManager : IClientStorageManager
    {
        readonly ApplicationDbContext context;
        public CookieManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Store(string key, string value)
        {
            //context.GetHttpContext().Response.Cookies.Append(key, value);
        }
    }
}
