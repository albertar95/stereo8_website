namespace AudioShopBackend.Services.Contracts
{
    public interface ICommonAction : IGeneralAction
    {
        IEnumerable<Models.File> GetFiles(Guid NidRelate);
        Models.File GetFile(Guid NidFile);
        IEnumerable<Models.Setting> GetSettings(int Pagesize = 100,int Skip = 0, byte State = 0);
        Models.Setting GetSetting(Guid NidSetting, byte State = 0);
        IEnumerable<Models.File> GetCommonFiles();
        bool UpdateFile(Models.File item);
        string[] GetIndexPageValues();
        IEnumerable<Models.City> GetCities();
        IEnumerable<Models.State> GetStates();
    }
}
