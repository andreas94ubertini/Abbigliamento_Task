using System;
using System.Collections.Generic;

namespace Abbigliamento_Task.Models;

public partial class Prezzo
{
    public int PrezzoId { get; set; }

    public decimal PrezzoPieno { get; set; }

    public decimal? PrezzoSconto { get; set; }

    public DateOnly? DataInizio { get; set; }

    public DateOnly? DataFine { get; set; }

    public int VariazioneRif { get; set; }

    public virtual Variazione VariazioneRifNavigation { get; set; } = null!;
}
