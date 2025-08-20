using AutoMapper;
using Project.core.Shared;
using Project.dal.Generic;

namespace Project.core.Commands.UpdateCategory
{
    public sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, UpdateCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetAsync(request.Id);
            category.Name = request.Name;
            category.Description = request.Description;
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<UpdateCategoryResponse>(category);
        }
    }

}
