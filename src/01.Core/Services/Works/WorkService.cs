namespace Services.Works;

public class WorkService : IWorkService
{
    private readonly IWorkRepository _workRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WorkService(
        IWorkRepository workRepository,
        IUnitOfWork unitOfWork)
    {
        _workRepository = workRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Add(AddWorkDto dto)
    {
        var duplicateId = await _workRepository.IsExist(_ => _.Id == dto.Id);
        if (duplicateId)
        {
            throw new IdIsDuplicateException();
        }

        var work = new Work()
        {
            Id = dto.Id,
            Description = dto.Description,
            Icon = dto.Icon,
            Order = dto.Order,
            Title = dto.Title,
            ColumnLg = dto.ColumnLg
        };

        _workRepository.Add(work);
        
        await _unitOfWork.Save();
    }

    public async Task Update(UpdateWorkDto dto)
    {
        await ThrowExceptionWhenWorkNotFound(dto.Id);
        var work = new Work()
        {
            Id = dto.Id,
            Description = dto.Description,
            Icon = dto.Icon,
            Order = dto.Order,
            Title = dto.Title,
            ColumnLg = dto.ColumnLg
        };
        
        _workRepository.Update(work);
        await _unitOfWork.Save();
    }

    public async Task Delete(string id)
    {
        await ThrowExceptionWhenWorkNotFound(id);
        _workRepository.Delete(id);
        await _unitOfWork.Save();
    }

    private async Task ThrowExceptionWhenWorkNotFound(string id)
    {
        var isExists = await _workRepository.IsExist(_ => _.Id == id);
        if (!isExists)
        {
            throw new NotFoundException();
        }
    }
}