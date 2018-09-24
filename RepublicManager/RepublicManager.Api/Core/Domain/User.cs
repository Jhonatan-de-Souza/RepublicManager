using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RepublicManager.Api.Core.Domain
{
    public class User 
    {
        public string UserId { get; set; }
        public string AccessKey { get; set; }
    }
}
