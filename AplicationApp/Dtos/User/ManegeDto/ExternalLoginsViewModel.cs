﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AplicationApp.Dtos
{
    public class ExternalLoginsDto
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }


        public bool ShowRemoveButton { get; set; }

        public string StatusMessage { get; set; }
    }
}
