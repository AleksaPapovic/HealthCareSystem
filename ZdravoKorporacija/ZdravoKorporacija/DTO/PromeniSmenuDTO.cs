using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.DTO
{
    class PromeniSmenuDTO
    {
        public PromeniSmenuDTO() { }
        public PromeniSmenuDTO(DateTime Od, DateTime Do, double id, bool prva)
        {
            this.Do = Do;
            this.Od = Od;
            this.idLekara = id;
            this.prvaSmena = prva;
        }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public double idLekara { get; set; }
        public bool prvaSmena { get; set; }
    }
}
