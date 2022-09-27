using TrisoleRed.Services.Modes;

namespace TrisoleRed.Services.Interfaces
{
    public interface IProperties
    {
        List<PropertiesDetailsModelView> GetAllProperties();
        bool AddPropty(PropertiesDetailsModelView model);
    }
}
