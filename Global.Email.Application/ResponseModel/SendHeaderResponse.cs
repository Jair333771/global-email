using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Email.Application.ResponseModel
{
    public class SendHeaderResponse
    {
        public string ByName { get; set; }
        public string ByEmail { get; set; }
        public int? SnComplete { get; set; }
        public bool? SnMassive { get; set; }
    }
}