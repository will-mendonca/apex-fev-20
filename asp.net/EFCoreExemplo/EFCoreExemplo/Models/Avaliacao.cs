using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreExemplo.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Aluno")]
        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [ForeignKey("Curso")]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        [ForeignKey("Instrutor")]
        [Display(Name = "Instrutor")]
        public int InstrutorId { get; set; }
        public Instrutor Instrutor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Range(1, 3)]
        [Display(Name = "Sala/Equipamento")]
        public int AvaliacaoSala { get; set; }

        [Range(1, 3)]
        [Display(Name = "Pontualidade")]
        public int AvaliacaoPontualidade { get; set; }

        [Range(1, 3)]
        [Display(Name = "Conteúdo apresentado")]
        public int AvaliacaoConteudo { get; set; }

        [Range(1, 3)]
        [Display(Name = "Instrutor")]
        public int AvaliacaoInstrutor { get; set; }

        public string Dificuldade { get; set; }

        [Display(Name = "Sugestão")]
        public string Sugestao { get; set; }

    }
}
