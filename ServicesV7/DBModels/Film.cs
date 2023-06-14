using System;
using System.Collections.Generic;

namespace ServicesV7.DBModels;

public partial class Film
{
    public int FilmId { get; set; }

    public string FilmName { get; set; } = null!;

    public string FilmProduction { get; set; } = null!;

    public int FilmType { get; set; }

    public int FilmTime { get; set; }

    public int FilmImdb { get; set; }

    public string FilmExplanation { get; set; } = null!;

    public string? FilmResimLinki { get; set; }

    public virtual Type FilmTypeNavigation { get; set; } = null!;
}
