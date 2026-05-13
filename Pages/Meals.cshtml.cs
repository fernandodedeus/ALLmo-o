using ALLmoco.Data;
using ALLmoco.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ALLmoco.Pages
{
    public class MealsModel : PageModel
    {
        private readonly AppDbContext _context;

        public MealsModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MealCheck MealCheck { get; set; } = new();
        public List<MealCheck> MealHistory { get; set; } = new();
        public int CurrentStreak { get; set; } // int para a streak
        public string? ErrorMessage { get; set; } // string dentro da classe meal para criar a mensagem de erro no preenchimento de descricao
        // string? significa “essa variável pode ser nula”, necessário para esse caso que pode ou nao existir mensagem

        public void OnGet()
        {
            MealHistory = _context.MealChecks // pega a tabela
                .OrderByDescending(x => x.Date) // ordena do mais recente pro mais antigo '=>'
                .ToList(); // transforma em lista

            CalculateStreak(); // Contagem de Streak
        }

        public async Task<IActionResult> OnPostAsync() // Recebe os dados
        {
            if (!MealCheck.AteMeal)
            {
                ErrorMessage = "Marque a refeição antes de salvar.";

                MealHistory = _context.MealChecks
                    .OrderByDescending(x => x.Date)
                    .ToList();

                CalculateStreak();

                return Page();
            }

            MealCheck.Date = DateTime.Now;
            // metodo que verifica se existe refeição do tipo selecionado, se existir ele não vai salvar a refeição, alem de que ele verifica se a ref foi marcada como feita
            bool alreadyExists = _context.MealChecks.Any(x =>
                x.MealType == MealCheck.MealType &&
                x.Date.Date == DateTime.Today &&
                x.AteMeal);

            if (alreadyExists)
            {
                ErrorMessage = "Essa refeição já foi registrada hoje.";

                MealHistory = _context.MealChecks
                    .OrderByDescending(x => x.Date)
                    .ToList();

                CalculateStreak();

                return Page();
            }

            _context.MealChecks.Add(MealCheck); // adiciona no banco

            await _context.SaveChangesAsync(); // salva

            return RedirectToPage();

            }

        private void CalculateStreak() // LINQ feito para criar uma contagem de Streak
        {
            var dates = _context.MealChecks
                .Where(x => x.AteMeal) // pega so refeições feitas
                .GroupBy(x => x.Date.Date) // agrupa por dia
                .Where(group => group.Count() >= 2) // filtra as refeições pra contar streak apenas com 2 refeições ou mais
                .Select(group => group.Key) // pega apenas a data
                .OrderByDescending(date => date)
                .ToList();

            int streak = 0;

            DateTime currentDate = DateTime.Today;

            foreach (var date in dates)
            {
                if (date == currentDate)
                {
                    streak++;
                    currentDate = currentDate.AddDays(-1);
                }
                else if (date == currentDate.AddDays(-1))
                {
                    streak++;
                    currentDate = currentDate.AddDays(-1);
                }
                else
                {
                    break;
                }
            }

            CurrentStreak = streak;
        }
    }
    }
