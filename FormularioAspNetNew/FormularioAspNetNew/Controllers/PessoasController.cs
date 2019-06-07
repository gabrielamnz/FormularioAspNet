using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormularioAspNetNew.Models;
using X.PagedList;

namespace FormularioAspNetNew.Controllers
{
    public class PessoasController : Controller
    {
        private CadastroContext db = new CadastroContext();

        private List<object> estados = new List<object>
        {
                new {Sigla = "AC", Nome = "Acre" },
                new {Sigla = "AL", Nome = "Alagoas" },
                new {Sigla = "AP", Nome = "Amapá" },
                new {Sigla = "AM", Nome = "Amazonas" },
                new {Sigla = "BA", Nome = "Bahia" },
                new {Sigla = "CE", Nome = "Ceará" },
                new {Sigla = "DF", Nome = "Distrito Federal" },
                new {Sigla = "ES", Nome = "Espírito Santo" },
                new {Sigla = "GO", Nome = "Goiás" },
                new {Sigla = "MA", Nome = "Maranhão" },
                new {Sigla = "MT", Nome = "Mato Grosso" },
                new {Sigla = "MS", Nome = "Mato Grosso do Sul" },
                new {Sigla = "MG", Nome = "Minas Gerais" },
                new {Sigla = "PA", Nome = "Pará" },
                new {Sigla = "PB", Nome = "Paraíba" },
                new {Sigla = "PR", Nome = "Paraná" },
                new {Sigla = "PE", Nome = "Pernambuco" },
                new {Sigla = "PI", Nome = "Piauí" },
                new {Sigla = "RJ", Nome = "Rio de Janeiro" },
                new {Sigla = "RN", Nome = "Rio Grande do Norte" },
                new {Sigla = "RS", Nome = "Rio Grande do Sul" },
                new {Sigla = "RO", Nome = "Rondônia" },
                new {Sigla = "RR", Nome = "Roraima" },
                new {Sigla = "SC", Nome = "Santa Catarina" },
                new {Sigla = "SP", Nome = "São Paulo" },
                new {Sigla = "SE", Nome = "Sergipe" },
                new {Sigla = "TO", Nome = "Tocantins" }
         };


        // GET: Pessoas
        public ActionResult Index(int pagina = 1)
        {
            var pessoas = db.Pessoas.OrderBy(p => p.CPF).ToPagedList(pagina, 3);
            return View(pessoas);
            //return View(db.Pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(string cpf)
        {
            if (cpf == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(cpf);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            ViewBag.Estados = new SelectList(estados, "Sigla", "Nome");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CPF,Nome,DataNascimento,Sexo,EstadoCivil,Estado,Cidade,Logradouro,NumeroEndereco,ComplementoEndereco,Renda")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(string cpf)
        {
            if (cpf == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(cpf);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CPF,Nome,DataNascimento,Sexo,EstadoCivil,Estado,Cidade,Logradouro,NumeroEndereco,ComplementoEndereco,Renda")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(string cpf)
        {
            if (cpf == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(cpf);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string cpf)
        {
            Pessoa pessoa = db.Pessoas.Find(cpf);
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult ValidarCPF(string cpf)
            {
            var pessoa = db.Pessoas.Find(cpf);
            return Json(pessoa == null, JsonRequestBehavior.AllowGet);
        }
    }
}
