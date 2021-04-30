using System;

namespace ClassLibraryIntegratieOOP.Models
{
    public static class Extensions
    {
        public static bool ToBool(this string s)
        {
            bool result = false;
            if (s.ToLower()=="true")
            {
                result = true;
            }
            else if(s.ToLower() =="false")
            {
                result = false;
            }
            else
            {
                throw new Exception("Cannot convert string to boolean because input is neither 'true' nor 'false'!");
            }
            return result;
        }
    }
}
