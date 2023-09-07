using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AuxiliarSettings
{
    public static class JWTSettings
    {
        public static string SecretKey = "6ceccd7405ef4b00b2630009be568cfa";
        public static byte[] GenerateSecretByte() =>
            Encoding.ASCII.GetBytes(SecretKey);
    }
}
