using FirstDemoCSAngular.Models;
using FirstDemoCSAngular.Service;
using Microsoft.AspNetCore.Mvc;

namespace FirstDemoCSAngular.Controllers;

[ApiController]
// [Route("[controller]")]
public class NewModelController : Controller
{
    private readonly ILogger<NewModelController> _logger;
    private readonly INewModelService _iNewModelService;

    public NewModelController(ILogger<NewModelController> logger, INewModelService iNewModelService)
    {
        _logger = logger;
        _iNewModelService = iNewModelService;
    }

    [HttpGet]
    public async Task<ActionResult<List<NewModelsDTO>>> Get()
    {
        return await _iNewModelService.getAllNewModels();
    }

    [HttpGet("{id")]
    public async Task<ActionResult<NewModelsDTO>> Get(long id)
    {
        var newModelsDTO = await _iNewModelService.getNewModelById(id);

         if (newModelsDTO == null)
        {
            return NotFound();
        }

        return newModelsDTO;
    }

    [HttpPost]
    public async Task<ActionResult<NewModelsDTO>> Post(NewModel newModel)
    {
        var newModelsDTO = await _iNewModelService.createNewModel(newModel);

        return CreatedAtAction(
            nameof(Get),
            new { id = newModelsDTO._id },
            newModelsDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<NewModelsDTO>> Post(long id, NewModelsDTO newModelsDTO)
    {
        if (id != newModelsDTO._id)
        {
            return BadRequest();
        }

        var _newModelsDTO = await _iNewModelService.updateNewModel(id, newModelsDTO);

        if (_newModelsDTO == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var status = await _iNewModelService.deleteNewModel(id);
        if (status == -1)
        {
            return NotFound();
        }

        return NoContent();
    }
}