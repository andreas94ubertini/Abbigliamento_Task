using System;
using System.Collections.Generic;

namespace Abbigliamento_Task.Models;

public partial class Ordine
{
    public int OrdineId { get; set; }

    public string NumeroOrdine { get; set; } = null!;

    public DateOnly DataEmissione { get; set; }

    public bool IsArrivato { get; set; }

    public int UtenteRif { get; set; }

    public int VariazioneRif { get; set; }

    public virtual Utente UtenteRifNavigation { get; set; } = null!;

    public virtual ICollection<Variazione> VariazioneRifs { get; set; } = new List<Variazione>();
}
