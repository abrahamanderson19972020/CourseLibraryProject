using CourseLibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseLibraryAPI.DataAccess
{
    public class CourseLibraryDbContext:DbContext
    {
        public CourseLibraryDbContext(DbContextOptions<CourseLibraryDbContext> options):base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Firstname = "Berry",
                    Lastname = "Griffin Beak Eldritch",
                    MainCategory = "Ships",
                    DateOfBirth = new DateTime(1980, 7, 23)
                },
                new Author()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Firstname = "Nancy",
                    Lastname = "Swashbuckler Rye",
                    MainCategory = "Rum",
                    DateOfBirth = new DateTime(1978, 5, 21)
                },
                new Author()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Firstname = "Eli",
                    Lastname = "Ivory Bones Sweet",
                    MainCategory = "Singing",
                    DateOfBirth = new DateTime(1957, 12, 16)
                },
                new Author()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Firstname = "Arnold",
                    Lastname = "The Unseen Stafford",
                    MainCategory = "Singing",
                    DateOfBirth = new DateTime(1957, 3, 6)
                },
                new Author()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Firstname = "Seabury",
                    Lastname = "Toxic Reyson",
                    MainCategory = "Maps",
                    DateOfBirth = new DateTime(1956, 11, 23)
                },
                new Author()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    Firstname = "Rutherford",
                    Lastname = "Fearless Cloven",
                    MainCategory = "General debauchery",
                    DateOfBirth = new DateTime(1981, 4, 5)
                },
                new Author()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    Firstname = "Atherton",
                    Lastname = "Crow Ridley",
                    MainCategory = "Rum",
                    DateOfBirth = new DateTime(1982, 10, 11)
                }
                );

            modelBuilder.Entity<Course>().HasData(
               new Course()
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   Title = "Commandeering a Ship Without Getting Caught",
                   AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers."
               },
               new Course()
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   Title = "Overthrowing Mutiny",
                   AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny."
               },
               new Course()
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   Title = "Avoiding Brawls While Drinking as Much Rum as You Desire",
                   AuthorId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk."
               },
               new Course()
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   Title = "Singalong Pirate Hits",
                   AuthorId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note."
               }
               );


            base.OnModelCreating(modelBuilder);
        }
    }
}
