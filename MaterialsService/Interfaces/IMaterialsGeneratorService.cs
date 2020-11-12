using MaterialsService.Models;

namespace MaterialsService.Interfaces
{
	public interface IMaterialsGeneratorService
	{
		string CreateWidget<T>(T widget) where T : WidgetBase;
	}
}