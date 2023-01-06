using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace RestWithASPNETudemy.Model
{
    [Table("app_agenda")]
    public class AppAgendaCD
    {
        [Key]
        [Column("AGD_ID")]
        public long AGD_ID { get; set; }

        [Column("AGD_DATA")]
        public DateOnly AGD_DATA { get; set; }

        [Column("AGD_HORA")]
        public TimeOnly AGD_HORA { get; set; }

        [Column("AGD_FONECE")]
        public string AGD_FONECE { get; set; }

        [Column("AGD_LOJA")]
        public string AGD_LOJA { get; set; }

        [Column("AGD_PEDIDO_COMPRA")]
        public string AGD_PEDIDO_COMPRA { get; set; }

        [Column("AGD_NF")]
        public string AGD_NF { get; set; }

        [Column("AGD_CHAVE")]
        public string AGD_CHAVE { get; set; }

        [Column("AGD_TIPO_CAMINHAO")]
        public long AGD_TIPO_CAMINHAO { get; set; }

        [Column("AGD_TIPO_PRODUTO")]
        public long AGD_TIPO_PRODUTO { get; set; }

        [Column("AGD_VOLUME")]
        public float AGD_VOLUME { get; set; }

        [Column("AGD_TRASNP")]
        public string AGD_TRASNP { get; set; }

        [Column("AGD_LOJA_TRASNP")]
        public string AGD_LOJA_TRASNP { get; set; }

        [Column("AGD_VALOR_DESCARGA")]
        public float AGD_VALOR_DESCARGA { get; set; }

        [Column("AGD_NF_DEVOLUCAO")]
        public string AGD_NF_DEVOLUCAO { get; set; }

        [Column("AGD_CHAVE_DEVOLUCAO")]
        public string AGD_CHAVE_DEVOLUCAO { get; set; }

        [Column("AGD_SENHA_DESCARGA")]
        public string AGD_SENHA_DESCARGA { get; set; }

        [Column("AGD_STATUS")]
        public string AGD_STATUS { get; set; }

        [Column("D_E_L_E_T_")]
        public string D_E_L_E_T_ { get; set; }

    }
}
