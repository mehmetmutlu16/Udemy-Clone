using Microsoft.AspNetCore.Mvc;
using proje1.Models;
using proje1.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using proje1.Data.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;



namespace proje1.Controllers
{
    public class AccountController : Controller{

        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;

        public AccountController(DataContext context,IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Logout(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);   
            return RedirectToAction("Login");

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userRepository.Users.FirstOrDefaultAsync(x => x.Eposta == model.Eposta);
                if(user == null)
                {
                    _userRepository.CreateUser(new Ogrenci{
                        Ad = model.Ad,
                        Soyad = model.Soyad,
                        OgrenciMi = model.OgrenciMi,
                        Eposta = model.Eposta,
                        Sifre = model.Sifre
                    } );
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("","Email Kullanımda.");
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated){
                return RedirectToAction("Index","Course");
            }
            return View();
            
        }

        public IActionResult Abonelik()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult OgrenciMiKontrol()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OgrenciMiKontrol(Ogrenci model)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid){
                var isUser=_userRepository.Users.FirstOrDefault(u => u.Eposta==model.Email && u.Sifre==model.Password);
                if(isUser !=null){
                    var userClaims=new List<Claim>();

                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.Idd.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, isUser.Ad ?? ""));

                    var claimsIdentity=new ClaimsIdentity(userClaims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties=new AuthenticationProperties{
                        IsPersistent=true,
                    };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    return RedirectToAction("Index", "Course");


                    
                }else{
                    ModelState.AddModelError("","hata");
                }

                }

                return View(model);


            }
           
        }
        
}