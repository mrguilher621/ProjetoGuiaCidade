﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoGuiaCidade.Models
{
    public class Item
    {
        [Key]
        public long Item_Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Imagem { get; set; }
    }
}