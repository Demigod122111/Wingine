using System;

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

    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class Space : Attribute
    {
        readonly int spacing;

        public Space(int spacing)
        {
            this.spacing = spacing;
        }

        public int Spacing
        {
            get { return spacing; }
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

    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class ActionButton : Attribute
    {
        readonly object[] args;
        readonly bool reloadInspector;

        public ActionButton(bool reloadInspector = false, params object[] args)
        {
            this.args = args;
            this.reloadInspector = reloadInspector;
        }

        public object[] Arguments
        {
            get { return args; }
        }

        public bool ReloadInspector
        {
            get { return reloadInspector; }
        }
    }

    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class Range : Attribute
    {
        readonly double min;
        readonly double max;

        public Range(double min = int.MinValue, double max = int.MaxValue)
        {
            this.min = min;
            this.max = max;
        }

        public double Min
        {
            get { return min; }
        }

        public double Max
        {
            get { return max; }
        }

    }
}
