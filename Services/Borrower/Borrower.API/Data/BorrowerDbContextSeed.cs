namespace Borrower.API.Data
{
    public static class BorrowerDbContextSeed
    {
        public static async Task SeedAsync(this BorrowerDbContext db)
        {
            await db.Database.EnsureCreatedAsync();
            if (!db.Borrowers.Any())
            {
                await SeedBorrowers(db);
            }
        }

        private static async Task SeedBorrowers(BorrowerDbContext db)
        {
            await db.Borrowers.AddRangeAsync(
                new Models.Borrower
                {
                    Name = "Dariush",
                    Address = "1",
                    BirthDate = new DateTime(1987, 01, 11),
                    Education = "1",
                    RegistrationDate = new DateTime(2022, 01, 11),
                    Tel = "1"
                },
                new Models.Borrower
                {
                    Name = "Pooria",
                    Address = "1",
                    BirthDate = new DateTime(1987, 01, 11),
                    Education = "1",
                    RegistrationDate = new DateTime(2022, 01, 11),
                    Tel = "1"
                },
                new Models.Borrower
                {
                    Name = "Majid",
                    Address = "1",
                    BirthDate = new DateTime(1988, 01, 11),
                    Education = "1",
                    RegistrationDate = new DateTime(2021, 01, 11),
                    Tel = "1"
                },
                new Models.Borrower
                {
                    Name = "Saman",
                    Address = "1",
                    BirthDate = new DateTime(1989, 01, 11),
                    Education = "1",
                    RegistrationDate = new DateTime(2019, 01, 11),
                    Tel = "1"
                },
                new Models.Borrower
                {
                    Name = "Farhad",
                    Address = "1",
                    BirthDate = new DateTime(1982, 01, 11),
                    Education = "1",
                    RegistrationDate = new DateTime(2020, 01, 11),
                    Tel = "1"
                },
                new Models.Borrower
                {
                    Name = "Jian",
                    Address = "1",
                    BirthDate = new DateTime(1981, 01, 11),
                    Education = "1",
                    RegistrationDate = new DateTime(2009, 01, 11),
                    Tel = "1"
                }
            );
            await db.SaveChangesAsync();
        }       
    }
}
