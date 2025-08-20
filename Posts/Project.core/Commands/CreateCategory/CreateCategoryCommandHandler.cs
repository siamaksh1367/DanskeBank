using AutoMapper;
using Project.core.Shared;
using Project.dal.Generic;
using Project.dal.Models;

namespace Project.core.Commands.CreateCategory
{
    public sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = _mapper.Map<Category>(request);
            var addedCategory = await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<CreateCategoryResponse>(addedCategory);

        }
    }

}
