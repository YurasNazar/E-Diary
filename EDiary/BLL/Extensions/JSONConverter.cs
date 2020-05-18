using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Extensions
{
    public static class JSONConverter
    {
        public static string Encode(Object obj)
        {
            return JsonConvert.SerializeObject(obj) as String;
        }
    }
}
