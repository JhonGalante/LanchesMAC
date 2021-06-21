using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMAC.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public List<PedidoDetalhe> PedidoItens { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Informe o sobrenome")]
        [Display(Name = "Sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        [Display(Name = "Endereço")]
        [StringLength(100)]
        public string Endereco1 { get; set; }

        [Required(ErrorMessage = "Informe o complemento")]
        [Display(Name = "Complemento")]
        [StringLength(100)]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Informe o seu CEP")]
        [Display(Name = "CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string Cep { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o seu telefone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o seu e-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(80)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PedidoTotal { get; set; }

        //[BindNever]
        //[ScaffoldColumn(false)]
        [Display(Name = "Data/Hora de entrega do pedido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; }

        [Display(Name = "Data/Hora de entrega do pedido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? ProdutoEntregueEm { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [Display(Name = "Itens no Pedido")]
        public int TotalItensPedido { get; set; }
    }
}
