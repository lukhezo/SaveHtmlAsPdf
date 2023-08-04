using Microsoft.AspNetCore.Mvc;
using System;

namespace Rotativa.AspNetCore
{
    public class UrlAsPdf : AsPdfResultBase
    {
        private readonly string _url;

        public UrlAsPdf(string url)
        {
            _url = url ?? string.Empty;
        }

        protected override string GetUrl(ActionContext context)
        {
            string urlLower = _url.ToLower();
            if (urlLower.StartsWith("http://") || urlLower.StartsWith("https://"))
                return _url;

            string url = String.Format("{0}://{1}{2}", context.HttpContext.Request.Scheme, context.HttpContext.Request.Host, _url);
            return url;
        }
    }
}
