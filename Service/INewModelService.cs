using FirstDemoCSAngular.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstDemoCSAngular.Service;

public interface INewModelService
{
    Task<List<NewModelsDTO>> getAllNewModels();
    Task<NewModelsDTO> getNewModelById(long id);
    Task<NewModelsDTO> createNewModel(NewModel newModel);
    Task<NewModelsDTO> updateNewModel(long id, NewModelsDTO newModelsDTO);
    Task<int> deleteNewModel(long id);
}