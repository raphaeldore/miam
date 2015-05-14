namespace Miam.DataLayer
{
    public interface IDatabaseHelper
    {
        void DropCreateDatabaseIfModelChanges();
        void DropCreateDatabaseAlways();

        void MigrateDatabaseToLatestVersion();

        void CreatedatabaseIfNotExists();

        void DeleteAll();


    }
}