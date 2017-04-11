using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.RefreshTokenModel
{
    public class ApplicationTypes
    {
        public enum AppTypes
        {
            JavaScript = 0,
            NativeConfidential = 1
        };
    }
}