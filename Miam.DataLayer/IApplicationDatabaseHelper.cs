namespace Miam.DataLayer
{
    public interface IApplicationDatabaseHelper
    {
        void DropCreateDatabaseIfModelChanges();
        void DropCreateDatabaseAlways();

        void MigrateDatabaseToLatestVersion();

        void CreatedatabaseIfNotExists();

        void ClearAllTables();

    }
}