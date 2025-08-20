using AutoMapper;
using Project.core.Shared;
using Project.dal.Generic;

namespace Project.core.Queries.GetTags
{
    public class GetTagsQueryHandler : IQueryHandler<GetTagsQuery, IEnumerable<GetTagResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTagsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetTagResponse>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _unitOfWork.Tags.GetAllAsync();
            return _mapper.Map<IEnumerable<GetTagResponse>>(tags);
        }
    }
}
