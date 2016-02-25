using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AxadoCarrier.ViewModels;
using AxadoCarrier.Data.Repositories;
using PagedList;
using AutoMapper;
using AxadoCarrier.Domain.Entities.Registers;
using System.Web.Routing;

namespace AxadoCarrier.Controllers
{
    public class RatingController : Controller
    {
        private readonly RatingRepository repository = new RatingRepository();

        public async Task<ActionResult> Index(int page)
        {
            int registerPerPage = 2;

            var ratings = repository.GetAll();
            double totalRegisters = ratings.Count();
            double totalPage = (totalRegisters / registerPerPage);

            ViewBag.TotalPages = Math.Ceiling(totalPage);

            var ratingsPagination = ratings.ToPagedList(page, registerPerPage);

            return View(Mapper.Map<IEnumerable<RatingViewModel>>(ratingsPagination));
        }

        public ActionResult Details(int id) {

            if (id == null)
            {
                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
            }

            var rating = repository.GetById(id);

            return View(Mapper.Map<RatingViewModel>(rating));
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descricao")] RatingViewModel ratingViewModel)
        {
            if (ModelState.IsValid)
            {
                var mapper = Mapper.CreateMap<Rating, RatingViewModel>();
                var rating = Mapper.Map<Rating>(ratingViewModel);

                repository.Add(rating);

                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
            }

            return View(ratingViewModel);
        }
        
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
            }

            var rating = repository.GetById(id);

            var ratingViewModel = Mapper.Map<RatingViewModel>(rating);

            if (ratingViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ratingViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descricao")] RatingViewModel ratingViewModel)
        {
            if (ModelState.IsValid)
            {
                var rating = Mapper.Map<Rating>(ratingViewModel);

                repository.Update(rating);

                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
                
            }

            return View(ratingViewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                var routeValue = new RouteValueDictionary();
                routeValue.Add("page", "1");

                return RedirectToAction("Index", routeValue);
            }

            var rating = repository.GetById(id);

            if (rating == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<RatingViewModel>(rating));
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
            }
            base.Dispose(disposing);
        }
    }
}
