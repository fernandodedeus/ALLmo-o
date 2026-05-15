using ALLmoco.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ALLmoco.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public async Task<IActionResult> OnPost() // o método onpost executa o botão "Entrar"
        {
            var user = _context.Users // esse bloco inteiro procura no banco Username e Password, se não encontrar...
                .FirstOrDefault(u =>
                    u.Username == Username &&
                    u.Password == Password);

            if (user == null)
            {
                Message = "Usuário ou senha inválidos."; // retorna usuário inválido
                return Page();
            }

            // return RedirectToPage("/Index"); // se o usuário existir, esse codigo o redireciona para a página Index

            var claims = new List<Claim> // Claim é uma informação do usuário, onde ele guarda na memoria esse login
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var identity = new ClaimsIdentity( // Claims indetity cria uma identidade autenticada
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

             await HttpContext.SignInAsync( // SignInAsync é o momento que o cookie é criado 
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal); // no fim desse bloco, o asp.net vai reconhecer o usuario autenticado automaticamente

            return RedirectToPage("/Index"); // aqui redireciona o usuario logado para a página inicial (INDEX)
        }
    }
}