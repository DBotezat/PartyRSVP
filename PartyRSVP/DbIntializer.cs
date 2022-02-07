using PartyRSVP.Models;

namespace PartyRSVP
{
    public static class DbInitializer
    {
        public static void Initialize(MyContext context)
        {
            context.Database.EnsureCreated();


        }
    }
}
