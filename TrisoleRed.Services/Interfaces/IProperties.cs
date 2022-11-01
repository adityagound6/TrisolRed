using TrisoleRed.Data.Models;
using TrisoleRed.Services.Modes;

namespace TrisoleRed.Services.Interfaces
{
    public interface IProperties
    {
        List<PropertiesDetailsModelView> GetAllProperties();
        bool AddPropty(PropertiesDetailsModelView model);
        bool Update(PropertiesDetailsModelView model);
        PropertiesDetailsModelView GetById(int id);
        List<string> GetAllCity();
        List<PropertiesDetails> GetByCityName(string city);
    }
}
