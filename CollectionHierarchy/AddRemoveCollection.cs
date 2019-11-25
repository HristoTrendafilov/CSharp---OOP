using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public virtual string Remove()
        {
            var itemToRemove = this.collection.Last();
            collection.RemoveAt(collection.Count - 1);
            return itemToRemove;
        }
        public override int Add(string element)
        {
            this.collection.Insert(0, element);
            return 0;
        }
    }
}
