namespace Project.core.Queries.GetCategories
{
    public class GetCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GetCategoryResponse(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
