using FirstDemoCSAngular.Context;
using FirstDemoCSAngular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstDemoCSAngular.Service;

public class NewModelServiceImpl : INewModelService
{
    private readonly NewContext _context;

    public NewModelServiceImpl(NewContext context)
    {
        _context = context;
    }

    public async Task<NewModelsDTO> createNewModel(NewModel newModel)
    {
        Random r = new Random();

        var newItem = new NewModel 
        {
            Date = newModel.Date,
            Summary = newModel.Summary,
            PinCode = r.Next(1000, 9999)
        };

        _context.NewModels.Add(newItem);
        await _context.SaveChangesAsync();

        return CreateNewModelsDTO(newItem);
    }

    public async Task<int> deleteNewModel(long id)
    {
        var newModel = await _context.NewModels.FindAsync(id);
        if (newModel == null)
        {
            return -1;
        }

        _context.NewModels.Remove(newModel);
        await _context.SaveChangesAsync();
        return 1;
    }

    public async Task<List<NewModelsDTO>> getAllNewModels()
    {
        return await _context.NewModels.Select(x => CreateNewModelsDTO(x)).ToListAsync();
    }

    public async Task<NewModelsDTO> getNewModelById(long id)
    {
        var newModel = await _context.NewModels.FindAsync(id);
        if (newModel == null)
        {
            return null;
        }

        return CreateNewModelsDTO(newModel);
    }

    public async Task<NewModelsDTO> updateNewModel(long id, NewModelsDTO newModelsDTO)
    {
        if (id != newModelsDTO._id)
        {
            throw new InvalidDataException("Id and newModel id don't match up!");
        }

        var _newModel = await _context.NewModels.FindAsync(id);
        if (_newModel == null)
        {
            return null;
        }

        _newModel.Date = newModelsDTO._date;
        _newModel.Summary = newModelsDTO._summary;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!NewModelItemExists(id))
        {
            return null;
        }

        return CreateNewModelsDTO(_newModel);
    }

    private bool NewModelItemExists(long id)
    {
        return _context.NewModels.Any(e => e.Id == id);
    }

    private static NewModelsDTO CreateNewModelsDTO(NewModel newModel) =>
       new NewModelsDTO(newModel);
}