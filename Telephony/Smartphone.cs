using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    class Smartphone : ICalling, IBrowsing
    {
        private List<string> phoneNumbers;
        private List<string> sites;

        public Smartphone(List<string> phoneNumbers, List<string> sites)
        {
            this.phoneNumbers = phoneNumbers;
            this.sites = sites;
        }

        public string GetNumbers()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                if (phoneNumbers[i].Any(char.IsLetter))
                {
                    sb.AppendLine("Invalid number!");
                }
                else
                {
                    sb.AppendLine($"Calling... {phoneNumbers[i]}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string GetSites()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < sites.Count; i++)
            {
                if (sites[i].Any(char.IsDigit))
                {
                   sb.AppendLine("Invalid URL!");
                }
                else
                {
                    sb.AppendLine($"Browsing: {sites[i]}!");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
