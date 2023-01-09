using FirstDemoCSAngular.Models;

namespace FirstDemoCSAngular.Models;

public class NewModelsDTO
{
    public long _id { get; set; }
    public DateTime _date { get; set; }
    public string? _summary { get; set; }

    public NewModelsDTO(NewModel newModel) 
    {
        _id = newModel.Id;
        _date = newModel.Date;
        _summary = newModel.Summary;
    } 
}