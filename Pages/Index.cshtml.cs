using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ALLmoco.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if(!User.Identity?.IsAuthenticated ?? true) // essa função verifica se tem usuário logado
            {
                return RedirectToPage("/Login"); // SE nao existir, retorna a pagina de login
            }
            return Page(); // se existir redireciona normalmente para index
        }

    }
}

