using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine
{
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class Multiline : Attribute
    {
        readonly int defaultSize;

        public Multiline(int defaultSize = 80)
        {
            this.defaultSize = defaultSize;
        }

        public int DefaultSize
        {
            get { return defaultSize; }
        }

    }

    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class Header : Attribute
    {
        readonly string text;

        public Header(string text)
        {
            this.text = text;
        }

        public string Text
        {
            get { return text; }
        }

    }

    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class HideInInspector : Attribute
    {
        public HideInInspector()
        {

        }
    }

    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class ExtendColor : Attribute
    {
        public ExtendColor()
        {

        }
    }
}
