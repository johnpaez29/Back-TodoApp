namespace ToDoServiceApp.DataService.DataConection
{
    public interface ITodoListItemRepository<T>
    {
        IEnumerable<T> GetItemsById(int id);

        void Add(T item);

        void Delete(T item);
    }
}
