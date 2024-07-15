
namespace API_Practice.Services.Contracts
{
    public interface IJsonHandler
    {


        string readJson();
        bool writeObject(object obj);
    }
}
