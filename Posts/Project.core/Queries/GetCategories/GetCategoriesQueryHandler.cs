using AutoMapper;
using Project.core.Shared;
using Project.dal.Generic;

namespace Project.core.Queries.GetCategories
{
    public sealed class GetAllQueryHandler : IQueryHandler<GetCategoriesQuery, IEnumerable<GetCategoryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return _mapper.Map<IEnumerable<GetCategoryResponse>>(categories);
        }
    }

}
