using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class WorkerController : Controller
    {
        static TemplateModel vincas = new TemplateModel { Name = "Vincas", Surname = "Spiritas" };
        static TemplateModel tadas = new TemplateModel { Name = "Tadas", Surname = "Kazlauskas" };
        static TemplateModel jimmy = new TemplateModel { Name = "Jimmy", Surname = "Carr" };
        static TemplateModel ice = new TemplateModel { Name = "Ice", Surname = "Cube" };

        public static WorkerModel worker1 = new WorkerModel
        {
            Template = vincas,
            Tier = "Stalius",
            Year = 1955 - 12 - 45,
            Description = "Nėra labai geras darbuotojas",
            Id = "44549",
            StartDate = "2020-01-01",
            EndDate = "2021-02-01",
            Explanation = "Išvyka į Bahamus"
        };
        public static WorkerModel worker2 = new WorkerModel
        {
            Template = tadas,
            Tier = "Stalius",
            Year = 1946-07-07,
            Description = "Įprastas darbuotojas",
            Id = "44548",
            StartDate = "2021-02-01",
            EndDate = "2021-03-01",
            Explanation = "Išvyka į JAV"
        };
        public static WorkerModel worker3 = new WorkerModel
        {
            Template = jimmy,
            Tier = "Bibliotekininkas",
            Year = 1988-10-10,
            Description = "Metų darbuotojas",
            Id = "44547",
            StartDate = "2021-01-01",
            EndDate = "2021-06-01",
            Explanation = "Išvyka į Minską"
        };
        static WorkerModel worker4 = new WorkerModel
        {
            Template = ice,
            Tier = "Administratorius",
            Year = 1975-05-15,
            Description = "Arba gerai arba nieko.",
            Id = "44546",
            StartDate = "2021-01-01",
            EndDate = "2021-02-10",
            Explanation = "Išvyka į Vilnių"
        };

        public ActionResult Index()
        {
            List<WorkerModel> workers = new List<WorkerModel>
            {
                worker1,
                worker2,
                worker3,
                worker4
            };

            return View(workers);
        }

        public ActionResult Details(string ISBN)
        {
            return View(worker1);
        }

        public ActionResult NewWorkerForm()
        {
            return View();
        }
        public ActionResult ViewRequestsToLeave()
        {
            List<WorkerModel> workers = new List<WorkerModel>
            {
                worker1,
                worker2,
                worker3,
                worker4
            };

            return View(workers);
        }
        public ActionResult RemoveWorkerForm()
        {
            return View();
        }
        public ActionResult EditWorkerForm()
        {
            return View();
        }
        public ActionResult ConfirmLeave()
        {
            return View();
        }
        public ActionResult PublisherCreate()
        {
            return View();
        }

    }
}
