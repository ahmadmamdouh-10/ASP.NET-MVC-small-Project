using Lab.Filters;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using PagedList.Mvc;
using PagedList;

namespace Lab.Controllers
{
    public class UserController : Controller
    {
        IUnitOfWork UnitOfWork;
        IModelRepository<User> UserRepo;
        IModelRepository<Token> TokenRepo;

        public UserController(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
            UserRepo = UnitOfWork.GetUserRepo();
            TokenRepo = UnitOfWork.GetTokenRepo();

        }

        private IEnumerable<UserViewModel> GetUsers()
        {
            return
                UserRepo.Get().Select(i => new UserViewModel
                {
                    ID = i.ID,
                    UserName = i.UserName,
                    Mobile = i.Mobile,
                    Address = i.Address
                }).ToList();
        }



        [HttpGet]
        [CheckUserIdentity]
        public ActionResult Index(string searchByName = "",
                                  string searchByMobile = "",
                                  string searchByAddress = "",
                                  int? page =1)
        { 
            ViewBag.Title = "Index";
            if (searchByName != "" && searchByMobile != "" && searchByAddress != "")
                return View(GetUsers()
                    .Where(i => i.UserName.StartsWith(searchByName)
                    && i.Mobile == searchByMobile
                    && i.Address == searchByAddress
                    ).ToPagedList(page ?? 1, 5));

            else if (searchByName != "" && searchByMobile != "" && searchByAddress == "")
                return View(GetUsers()
                                    .Where(i => i.UserName.StartsWith(searchByName)
                                    && i.Mobile == searchByMobile
                                    ).ToPagedList(page ?? 1, 5));

            else if (searchByName != "" && searchByMobile == "" && searchByAddress != "")
                return View(GetUsers()
                    .Where(i => i.UserName.StartsWith(searchByName)
                    && i.Address == searchByAddress
                    ).ToPagedList(page ?? 1, 5));

            else if (searchByName == "" && searchByMobile != "" && searchByAddress != "")
                return View(GetUsers()
                    .Where(i => i.Mobile == searchByMobile
                    && i.Address == searchByAddress
                    ).ToPagedList(page ?? 1, 5));

            else if(searchByName != "" || searchByMobile != "" || searchByAddress != "")
                return View(GetUsers()
                   .Where(i => i.UserName.StartsWith(searchByName)
                   || i.Mobile == searchByMobile
                   || i.Address == searchByAddress
                   ).ToPagedList(page ?? 1, 5));
            else 
                return View(GetUsers().ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        [CheckUserIdentity]
        public ActionResult Index2()
        {
            ViewBag.Title = "Index";

            var Users = GetUsers();
            return View(Users);
        }



        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "User Login Page";
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginView user)
        {
            if (!ModelState.IsValid)
                return View();

            User SelectedUser = UserRepo.Get()
                .FirstOrDefault(i => i.UserName == user.UserName
                && i.Password == user.Password);

            if (SelectedUser == null)
                return View();

            Session["User"] = User;

            return Redirect("/User/Index");
        }

        [HttpGet]
        [CheckUserIdentity]

        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [CheckUserIdentity]
        public ActionResult Create(UserEditViewModel User)
        {
            Thread.Sleep(5000);

            ViewBag.Title = "Create User Page";

            if (ModelState.IsValid)
            {
                User Temp = User.ToModel();
                UserRepo.Add(Temp);

                TokenRepo.Add(new Token()
                {
                    UserID = Temp.ID,
                    Code = Guid.NewGuid().ToString()
                });

                UnitOfWork.Save();

                ModelState.Clear();
                return View();
            }
            return View();
        }

        [HttpGet]
        [CheckUserIdentity]

        public ActionResult Details(int? id)
        {
            if (id == null || id <= 0)
                return Redirect("/User/Login");

            ViewBag.Title = $"Details User with {id}";

            User Temp = UserRepo.Get(id.Value);
            if (Temp == null)
                return Redirect("/User/Login");

            UserViewModel userView = Temp.ToViewModel();
            return View(userView);
        }

        [HttpGet]
        [CheckUserIdentity]

        public ActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
                return Redirect("/User/Login");
            ViewBag.Title = $"Edit User with{id}";

            User Temp = UserRepo.Get(id.Value);
            if (Temp == null)
                return Redirect("/User/Login");

            UserEditViewModel userEditView = Temp.ToEditableModel();
            return View(userEditView);
        }

        [HttpPost]
        [CheckUserIdentity]
        public ActionResult Edit(UserEditViewModel User)
        {
            ViewBag.Title = $"Edit User";

            if (ModelState.IsValid)
            {
                User Temp = User.ToModel();
                UserRepo.Edit(Temp);
                UnitOfWork.Save();
                return Redirect("/User/Index");
            }
            return View();
        }


        [HttpGet]
        [CheckUserIdentity]
        public ActionResult Delete(int? id)
        {
            if (Session["User"] == null)
                return Redirect("/User/Login");

            if (id == null || id <= 0)
                return Redirect("/User/Login");


            User Temp = new User { ID = id.Value };
            UserRepo.Remove(Temp);

            UnitOfWork.Save();

            return PartialView("_UsersList", GetUsers());
        }
    }
}