using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Config();
        }

        static void Config()
        {
            Al.Config.Sample s = new Al.Config.Sample();
            s.setSample();
            s.getSample();
        }
    }
}
