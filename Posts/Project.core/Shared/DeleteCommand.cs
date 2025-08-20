namespace Project.core.Shared
{
    public class DeleteCommand : ICommand<int>
    {
        public int Id { get; set; }

        public DeleteCommand(int id)
        {
            Id = id;
        }
    }
}
