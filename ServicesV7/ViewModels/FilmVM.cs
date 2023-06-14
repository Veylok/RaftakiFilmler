using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesV7.ViewModels
{
    public class FilmVM
    {
        public int FilmId { get; set; }

        public string FilmName { get; set; } = null!;

        public string FilmProduction { get; set; } = null!;

        public int FilmType { get; set; }

        public int FilmTime { get; set; }

        public int FilmImdb { get; set; }

        public string FilmExplanation { get; set; } = null!;
        public string FilmResimLinki { get; set; } = null!;

        public string FilmDescription { get; set;} = null!;
        //public string TypeName { get; set;} = null!;

    }
}
