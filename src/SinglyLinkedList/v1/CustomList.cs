namespace KataSinglyLinkedList
{
    public class CustomList<T>
    {
        private CustomListItem<T> _firstItem;
        private CustomListItem<T> _lastItem;
        private int _count;
        
        /// <summary>
        /// Stores an item in a linked list.
        /// [PP]
        /// </summary>
        /// <param name="listItem">The item which should be stored.</param>
        public void Add(CustomListItem<T> listItem)
        {
            // If the first item is inserted, it is the first and the last at the same time :)
            // [PP]
            if (_firstItem == null && _lastItem == null)
            {
                _firstItem = listItem;
                _lastItem = listItem;
            }
            else
            {
                _lastItem.Next = listItem;
                _lastItem = listItem;
            }

            _count++;
        }

        /// <summary>
        /// Gets the number of stored items.
        /// [PP]
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _count;
        }

        /// <summary>
        /// Reverses the items.
        /// [PP]
        /// </summary>
        public void Reverse()
        {
            // Check if there is something to reverse.
            // [PP]
            if (_firstItem == null || _firstItem.Next == null)
                return;

            _lastItem = _firstItem;

            CustomListItem<T> previousItem = null;
            CustomListItem<T> currentItem = _firstItem;
            CustomListItem<T> nextItem = _firstItem.Next;

            while (currentItem != null)
            {
                currentItem.Next = previousItem;

                if (nextItem == null)
                    break;

                previousItem = currentItem;
                currentItem = nextItem;
                nextItem = nextItem.Next;
            }

            _firstItem = currentItem;
        }
    }
}