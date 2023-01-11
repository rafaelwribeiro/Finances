using FinancesAPI.Api.Contracts;
using FinancesAPI.Domain;
using FinancesAPI.Infra.Repositories;
using Mapster;

namespace FinancesAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryReadContract> CreateAsync(CategoryCreateContract contract)
    {
        var category = await _categoryRepository.CreateAsync(contract.Adapt<Category>());
        return category.Adapt<CategoryReadContract>();
    }

    public async Task Delete(int id)
    {
        var entity = await _categoryRepository.GetAsync(id);
        await _categoryRepository.DeleteAsync(entity);
    }

    public async Task<IEnumerable<CategoryReadContract>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Adapt<IEnumerable<CategoryReadContract>>();
    }

    public async Task<CategoryReadContract> GetAsync(int id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return category.Adapt<CategoryReadContract>();
    }

    public async Task Update(CategoryUpdateContract contract)
    {
        var entity = await _categoryRepository.GetAsync(contract.Id);
        entity.Adapt(contract);
        await _categoryRepository.DeleteAsync(entity);
    }
}