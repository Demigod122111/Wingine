using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine
{
    public static class Time
    {
        public static double DeltaTime => Runner.App.dt;
    }
}
