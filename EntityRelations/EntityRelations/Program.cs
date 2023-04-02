using EntityRelations;
using Microsoft.EntityFrameworkCore;

var context = new ApplicationContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();