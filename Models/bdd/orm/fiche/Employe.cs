using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace S5_RH.Models.bdd.orm.fiche;

[Table("employe")]
public class Employe
{
    [Key]
    [Column("id_employe")]
    
    public int IdEmploye { get; set; }
    [Column("id_candidature")]
    public int IdCandidature { get; set; }
   
    [Column("id_superieur")] 
    public int? IdSuperieur { get; set; }

    public Employe ObtenirEmployeParId()
    {
        using var context = ApplicationDbContextFactory.Create();
        Console.WriteLine(this.IdCandidature);
        return context.Employe.First(e => e.IdCandidature == this.IdCandidature);
    }
}