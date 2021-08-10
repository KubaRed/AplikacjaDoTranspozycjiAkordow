using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoTranspozycji.Klasy
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> User{ get; set; }
        public DbSet<Instruments> Intrument { get; set; }
        public DbSet<ChordSongs> ChordSongs{ get; set; }
        public DbSet<Songs> Song { get; set; }
    }
}
