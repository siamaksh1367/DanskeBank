using AutoMapper;
using Project.core.Shared;
using Project.dal.Generic;

namespace Project.core.Queries.GetComments
{
    public class GetCommentResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }

    public sealed class GetCommentsQueryHandler : IQueryHandler<GetCommentsQuery, IEnumerable<GetCommentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCommentResponse>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _unitOfWork.Comments.FindAsync(x => x.PostId == request.PostId);
            return _mapper.Map<IEnumerable<GetCommentResponse>>(comments);
        }
    }
}
