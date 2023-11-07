using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using S5_RH.Models.back.Annonce;
using S5_RH.Models.bdd.orm;
using Question = S5_RH.Models.back.Annonce.Question;
using Diplome = S5_RH.Models.bdd.orm.Diplome;
using Qualification = S5_RH.Models.bdd.orm.Qualification;

namespace S5_RH.Controllers.Annonce;

    public class QuestionnaireController : Controller
    {
        [HttpPost]
        public ActionResult InsertionQuestionnaire()
        {
            var nombreDeQuestion = int.Parse(HttpContext.Request.Form["nombreDeQuestion"]);
            List<Question> questions = new List<Question>();
            for (int i = 1; i <= nombreDeQuestion; i++)
            {
                var nomQuestion = $"question{i}_question";
                var question = HttpContext.Request.Form[nomQuestion];
                var nomResponse = $"question{i}_reponse[]";
                var responses = HttpContext.Request.Form[nomResponse];
                var validation = $"question{i}_reponse_validation[]";
                var validity = HttpContext.Request.Form[validation];
               
                Question question1 = new Question
                {
                    Quest = question,
                    Reponses = responses,
                    Valeur = validity
                };
                
                int IdAnnonce = (int)TempData["IdAnnonce"];
                questions.Add(question1);
            }
            NouvelleAnnonce annonce =
                JsonSerializer.Deserialize<NouvelleAnnonce>((string)TempData["NouvelleAnnonce"]);
            Qualification qualification =
                JsonSerializer.Deserialize<Qualification>((string) TempData["Qualification"]);
            annonce.Sauvegarde(qualification, questions);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Index()
        {
            Diplome diplome = new Diplome
            {
                Details = "zaedsqdsq"
            };
            using (var context = ApplicationDbContextFactory.Create())
            {
                context.Diplome.Add(diplome);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
