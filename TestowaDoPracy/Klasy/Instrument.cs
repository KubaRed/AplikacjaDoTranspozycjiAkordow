using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoTranspozycji.Klasy
{
    public class Instrument
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
    }
}
