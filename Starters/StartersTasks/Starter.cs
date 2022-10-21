using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartersTasks
{
    internal class Starter
    {
        public bool Is2Power(int num)
        {
            if(num ==1) return false;
            while (num > 1)
            {
                if (num % 2 != 0) return false;
                num /= 2;
            }

            return true;
        }

        public string ReverseMe(string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                char c = chars[i];
                chars[i] = chars[j];
                chars[j] = c;
            }
            return new string(chars);

            //return (string)str.ToArray().Reverse();
        }

        public string ReplicateMe(string str, int count)
        {
            string result = null;
            for (int i = 0; i < count; i++)
                result += str;
            return result;
        }

        public void OddNumbers()
        {
            for(int i = 0; i <= 100; i++)
                if(i%2==1) Console.WriteLine(i);
        }
    }
}
