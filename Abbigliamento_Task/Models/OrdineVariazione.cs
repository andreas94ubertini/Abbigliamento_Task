using System;
using System.Collections.Generic;

namespace Abbigliamento_Task.Models;

public partial class OrdineVariazione
{
    public int OrdineVariazioneId { get; set; }

    public int OrdineRif { get; set; }

    public int VariazioneRif { get; set; }

    public virtual Ordine OrdineRifNavigation { get; set; } = null!;

    public virtual Variazione VariazioneRifNavigation { get; set; } = null!;
}
