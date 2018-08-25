using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modelo.DB.Model
{
    public class Questionario
    {
        public virtual Guid IdQuestionario { get; set; }
        [Display(Name = "Entre 7 e 25 anos.")]
        public virtual Boolean Eh7ate25 { get; set; }
        [Display(Name = "Entre 26 e 45 anos.")]
        public virtual Boolean Eh26ate45 { get; set; }
        [Display(Name = "Maior que 46 anos.")]
        public virtual Boolean EhMaiorQue46 { get; set; }
        [Display(Name = "Baixo, não gosto.")]
        public virtual Boolean EhBaixo { get; set; }
        [Display(Name = "Médio, adquiro/uso por necessidade.")]
        public virtual Boolean EhMedio { get; set; }
        [Display(Name = "Alto, sou amante da tecnologia.")]
        public virtual Boolean EhAlto { get; set; }
        [Display(Name = "Celulares e Telefones(Celulares, Celulares de Mesa, Smartphones e Acessórios, Telefones)")]
        public virtual Boolean EhCelularETelefone { get; set; }
        [Display(Name = "Eletrônicos(Calculadoras, Câmeras Digitais, Drones, Walk Talk)")]
        public virtual Boolean EhEletronico { get; set; }
        [Display(Name = "Computadores(Desktop, Notebooks, Laptops, Monitores, Impressoras, Scanners, Tablets, Servidores)")]
        public virtual Boolean EhComputadores { get; set; }
        [Display(Name = "Hardwares(HDs, Drives, Fontes, Coolers, Placas de Vídeo/Mãe/Rede/Som, Processadores, etc)")]
        public virtual Boolean EhHardware { get; set; }
        [Display(Name = "Periféricos(Fones de ouvido, HeadSets, Mouse, Teclado, Gabinete, etc)")]
        public virtual Boolean EhPerifericos { get; set; }
        [Display(Name = "Área Gamer(Cadeiras, Mesas, PC, Playstation 3, Playstation 4, XBOX 360, XBOX One, etc)")]
        public virtual Boolean EhGamer { get; set; }
        public virtual Cliente Cliente { get; set; }

    }

    public class QuestionarioMap : ClassMapping<Questionario>
    {
        public QuestionarioMap()
        {
            Id(x => x.IdQuestionario, m => m.Generator(Generators.Guid));

            Property(x => x.Eh7ate25);
            Property(x => x.Eh26ate45);
            Property(x => x.EhMaiorQue46);
            Property(x => x.EhBaixo);
            Property(x => x.EhMedio);
            Property(x => x.EhAlto);
            Property(x => x.EhCelularETelefone);
            Property(x => x.EhEletronico);
            Property(x => x.EhComputadores);
            Property(x => x.EhHardware);
            Property(x => x.EhPerifericos);
            Property(x => x.EhGamer);

            //1:1
            OneToOne(x => x.Cliente, m =>
            {
                m.PropertyReference(typeof(Cliente).GetProperty("Cliente"));
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.Persist);
            });
        }
    }
}
