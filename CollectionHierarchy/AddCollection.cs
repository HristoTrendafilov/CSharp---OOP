using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        protected List<string> collection;
        public AddCollection()
        {
            this.collection = new List<string>();
        }
        public virtual int Add(string element)
        {
            collection.Add(element);
            return this.collection.Count - 1;
        }
    }
}
