using System.Data.Entity;

namespace Dal
{
    public class Initializer : DropCreateDatabaseIfModelChanges<Context>
    {
    }
}
