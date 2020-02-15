using System;
namespace PCServ.Helpers
{
    public static class TokenHelper
    {
        public static string Generate(int repeat, int length)
        {
            string token = "";
            for(int i = 0; i < repeat; i++)
            {
                Guid g = Guid.NewGuid();
                string tokenPart = Convert.ToBase64String(g.ToByteArray());
                token += tokenPart.Replace("=", "").Replace("+", "").Replace(" ", "").Replace("/", "");
            }

            if(token.Length > length)
            {
                token = token.Substring(0, length);
            }
            return token;
        }
    }
}
