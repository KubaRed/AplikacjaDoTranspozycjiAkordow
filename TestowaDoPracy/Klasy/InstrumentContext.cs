using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoTranspozycji.Klasy
{
    class InstrumentContext : DbContext
    {
        public DbSet<Instruments> Instrument { get; set; }
        public DbSet<Users> Users { get; set; }
       
    }
}
