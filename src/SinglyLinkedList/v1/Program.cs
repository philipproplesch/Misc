using System;

namespace KataSinglyLinkedList
{
    // http://www.rethinkdb.com/blog/2010/06/will-the-real-programmers-please-stand-up/

    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new CustomList<string>();

            for (int i = 0; i < 100; i++)
            {
                var item = new CustomListItem<string>();
                item.Value = String.Concat("Item #", i);
                list.Add(item);
            }
            
            list.Reverse();
        }
    }
}