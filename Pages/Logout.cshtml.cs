using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ALLmoco.Pages // essa página apenas executa o html, por isso nao precisa de cshtml
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet() // onget x onpost
        {
            await HttpContext.SignOutAsync( // essa linha destroi o cookie de autenticacao
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Login");
        }
    }
}