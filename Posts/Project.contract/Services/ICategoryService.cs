using Project.core.Commands.CreateCategory;
using Project.core.Commands.DeleteCategory;
using Project.core.Commands.UpdateCategory;

namespace Project.contract.Services
{
    public interface ICategoryService
    {
        HttpRequestBuilder CreateCategory(CreateCategoryCommand createCategoryCommand);
        HttpRequestBuilder UpdateCategory(UpdateCategoryCommand updateCategoryCommand);
        HttpRequestBuilder GetAllCategories();
        HttpRequestBuilder DeleteCategory(DeleteCategoryCommand deleteCategoryCommand);
    }

    public class CategoryService : ICategoryService
    {
        private const string EndPoint = "/api/categories";
        private readonly HttpRequestBuilder _requestBuilder;

        public CategoryService(HttpRequestBuilder requestBuilder)
        {
            _requestBuilder = requestBuilder;
            _requestBuilder.AssignEndpoint(EndPoint);
        }
        public HttpRequestBuilder CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            return _requestBuilder.SetMethod(HttpMethod.Post)
                .SetJsonContent<CreateCategoryCommand>(createCategoryCommand);
        }
        public HttpRequestBuilder UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            return _requestBuilder.SetMethod(HttpMethod.Put)
                .SetJsonContent<UpdateCategoryCommand>(updateCategoryCommand)
                .AppendEndpoint("categories/" + updateCategoryCommand.Id.ToString());
        }
        public HttpRequestBuilder DeleteCategory(DeleteCategoryCommand deleteCategoryCommand)
        {
            return _requestBuilder.SetMethod(HttpMethod.Delete).AppendEndpoint($"categories/{deleteCategoryCommand.Id}");
        }
        public HttpRequestBuilder GetAllCategories()
        {
            return _requestBuilder.SetMethod(HttpMethod.Get);
        }
    }

}
