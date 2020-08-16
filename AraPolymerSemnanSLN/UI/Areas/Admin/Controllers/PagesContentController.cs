using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using DataLayer;
using Service.ViewModels;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PagesContent")]
    public class PagesContentController : Controller
    {
        private UnitOfWork _unitOfWork;
        private Context _Context;



        public PagesContentController()
        {
            _Context = new Context(Context.ops.dboptions);
            _unitOfWork = new UnitOfWork(_Context);
        }



        public ActionResult Index(string PageName)
        {
            VMPagesContent vMPagesContent = new VMPagesContent();
            vMPagesContent.PagesContentvm = _unitOfWork.PagesContent.GetPagesContentWithName(PageName);
            return View(vMPagesContent);
        }


        [HttpPost]
        public ActionResult Edit(VMPagesContent vMPagesContent, string submitButton)
        {
            switch (submitButton)
            {
                case "Edit":
                    _unitOfWork.PagesContent.Edit(vMPagesContent.PagesContentvm);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index", "PagesContent", new { PageName = vMPagesContent.PagesContentvm.PageName });
                case "Cancel":
                    return RedirectToAction("Index", "PagesContent", new { PageName = vMPagesContent.PagesContentvm.PageName });
                default:
                    return RedirectToAction("Index", "PagesContent", new { PageName = vMPagesContent.PagesContentvm.PageName });
            }

        }

    }  
}