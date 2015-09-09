namespace Miam.DataLayer
{
    public interface IApplicationDatabase
    {
        void DropCreateDatabaseIfModelChanges();
        void DropCreateDatabaseAlways();

        void MigrateDatabaseToLatestVersion();

        void CreatedatabaseIfNotExists();

        void ClearAllTables();

    }
}