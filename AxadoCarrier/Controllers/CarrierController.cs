using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AxadoCarrier.ViewModels;
using AxadoCarrier.Data.Repositories;
using AutoMapper;
using AxadoCarrier.Domain.Entities.Registers;
using PagedList;
using System.Web.Routing;

namespace AxadoCarrier.Controllers
{
   
    public class CarrierController : Controller
    {
        private readonly CarrierRepository repository = new CarrierRepository();
        private readonly RatingRepository ratingRepository = new RatingRepository();

        public async Task<ActionResult> Index(int page)
        {
            int registerPerPage = 2;

            var carriers = repository.GetAll();

            double totalRegisters = carriers.Count();
            double totalPage = (totalRegisters / registerPerPage);

            ViewBag.TotalPages = Math.Ceiling(totalPage);

            var carriersPagination = carriers.ToPagedList(page, registerPerPage);

            return View(Mapper.Map<IEnumerable<CarrierViewModel>>(carriersPagination));
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
            }

            var carrier = repository.GetById(id);

            return View(Mapper.Map<CarrierViewModel>(carrier));
        }

        public ActionResult Create()
        {
            ViewBag.cClassificacao = new SelectList(ratingRepository.GetAll(), "Id", "Descricao");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Tipo,CpfCnpj,NomeRazao,RgIe,Endereco,Numero,Bairro,Complemento,CEP,Cidade,UF,Contato,Telefone,Celular,Email,Site,Ativa,cClassificacao")] CarrierViewModel carrierViewModel)
        {
            if (ModelState.IsValid)
            {
                var mapper = Mapper.CreateMap<Carrier, CarrierViewModel>();
                var carrier = Mapper.Map<Carrier>(carrierViewModel);

                repository.Add(carrier);

                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
            }

            return View(carrierViewModel);
        }

        
         public async Task<ActionResult> Edit(int id)
         {
            if (id == null)
            {
                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
            }

            var carrier = repository.GetById(id);

            var carrierViewModel = Mapper.Map<CarrierViewModel>(carrier);

            if (carrierViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.cClassificacao = new SelectList(ratingRepository.GetAll(), "Id", "Descricao", carrier.cClassificacao);

            return View(carrierViewModel);
         }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<ActionResult> Edit([Bind(Include = "Id,Tipo,CpfCnpj,NomeRazao,RgIe,Endereco,Numero,Bairro,Complemento,CEP,Cidade,UF,Contato,Telefone,Celular,Email,Site,Ativa,cClassificacao")] CarrierViewModel carrierViewModel)
         {
             if (ModelState.IsValid)
             {
                var carrier = Mapper.Map<Carrier>(carrierViewModel);

                repository.Update(carrier);

                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
            }
             return View();
         }
        
         public async Task<ActionResult> Delete(int id)
         {
            if (id == null)
            {
                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
            }

            var carrier = repository.GetById(id);

            if (carrier == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<CarrierViewModel>(carrier));
         }

         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<ActionResult> DeleteConfirmed(int id)
         {
            var rating = repository.GetById(id);
            repository.Remove(rating);

            var routeValue = new RouteValueDictionary();
            routeValue.Add("page", "1");

            return RedirectToAction("Index", routeValue);
        }
         
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
                ratingRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
