namespace Miam.DataLayer
{
    public interface IDatabaseHelper
    {
        void DropCreateDatabaseIfModelChanges();
        void DropCreateDatabaseAlways();

        void DeleteAll();


    }
}