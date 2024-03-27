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

    public virtual ICollection<OrdineVariazione> OrdineVariaziones { get; set; } = new List<OrdineVariazione>();

    public virtual Utente UtenteRifNavigation { get; set; } = null!;
}
