namespace KataSinglyLinkedList
{
    public class CustomListItem<T>
    {
        public T Value { get; set; }
        public CustomListItem<T> Next { get; set; }
    }
}