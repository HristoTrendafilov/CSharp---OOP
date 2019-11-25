using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public int Used => this.collection.Count;
        public override string Remove()
        {
            var itemToRemove = this.collection[0];
            this.collection.RemoveAt(0);
            return itemToRemove;
        }
    }
}
