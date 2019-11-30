using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerUser.Layouts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
