using System;

namespace VariantTwo.Event_Args
{
    public class CollectionChangeResult : EventArgs
    {
        public string FullName { get; }
        public int Index { get; }

        public CollectionChangeResult(string fullName, int index)
        {
            FullName = fullName;
            Index = index;
        }
    }
}
