using P01_StudentSystem.Data;

static void Main()
{
    var context = new StudentSystemDbContext();

    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}