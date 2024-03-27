using System;
using System.Collections.Generic;

namespace Abbigliamento_Task.Models;

public partial class Variazione
{
    public int VariazioneId { get; set; }

    public string Colore { get; set; } = null!;

    public string Taglia { get; set; } = null!;

    public int Qt { get; set; }

    public int ProdottoRif { get; set; }

    public virtual ICollection<OrdineVariazione> OrdineVariaziones { get; set; } = new List<OrdineVariazione>();

    public virtual ICollection<Prezzo> Prezzos { get; set; } = new List<Prezzo>();

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;
}
