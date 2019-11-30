using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerUser.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Format 
            => @"{{
  ""log"": {{
    ""date"": {0},
    ""level"": {1},
    ""messege"": {2}
  }}
}}";
    }
}
