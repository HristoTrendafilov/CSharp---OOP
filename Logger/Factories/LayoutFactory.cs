using LoggerUser.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerUser.Factories
{
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            var layoutType = type.ToLower();
            switch (layoutType)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                case "jsonlayout":
                    return new JsonLayout();
                default:
                    throw new ArgumentException("Invalid Layout");
            }
        }
    }
}
