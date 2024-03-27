using System;
using System.Collections.Generic;

namespace Abbigliamento_Task.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string Marca { get; set; } = null!;

    public string Modello { get; set; } = null!;

    public string ImgUno { get; set; } = null!;

    public string ImgDue { get; set; } = null!;

    public int CategoriaRif { get; set; }

    public virtual Categorium CategoriaRifNavigation { get; set; } = null!;

    public virtual ICollection<Variazione> Variaziones { get; set; } = new List<Variazione>();
}
