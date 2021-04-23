namespace StilSoft.Providers
{
    public interface ISettingsProvider<out T>
    {
        T Settings { get; }
        void Load();
        void Save();
    }
}