using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Console
{
    class TeorVer
    {
        public static ulong Fact(ulong n)
        {
            ulong f = 1, k = 1;
            while (k <=n)
            {
                f *= k; k++;
            }
            return f;
        }
        public static int Fact(int n)
        {
            int f = 1, k = 1;
            while (k <= n)
            {
                f *= k; k++;
            }
            return f;
        }
        static ulong A(ulong k, ulong n)
        {
            ulong f = 1; k++;
            while (k <= n)
            {
                f *= k; k++;
            }
            return f;
        }
        static ulong C(ulong k, ulong n)
        {
            if (k == n)
                return 1;
            if (k > n)
                return 0;
            return A(n-k, n) / Fact(k);
        }
        public static (ulong, ulong) Baes(int n, int m, int s, int k)
        {
            if (m > n || k > s)
                return (0, 0);
            return (C(Convert.ToUInt64(k), Convert.ToUInt64(s))*C(Convert.ToUInt64(m -k), 
                Convert.ToUInt64(n -s)),C(Convert.ToUInt64(m), Convert.ToUInt64(n)));
        }

        public static double Bernulli(int n, int k, float q)
        {
            if (k > n)
                return 0;
            return C(Convert.ToUInt64(k), Convert.ToUInt64(k)) * Math.Pow(q, k) * Math.Pow(1 - q, n - k);
        }
    }
}
