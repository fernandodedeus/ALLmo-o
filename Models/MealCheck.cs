namespace ALLmoço.Models // Criação das tabelas em SQLite, por ser mais leve vai ser melhor pra mim
{
    public class MealCheck
    {
        public int Id { get; set; }

        public string MealType { get; set; } = string.Empty; // Nome da refeição

        public bool AteMeal { get; set; } // Se retorna verdadeiro ou falso (checkbox)

        public string Description { get; set; } = string.Empty; // Descrição ou observação da refeição

        public DateTime Date { get; set; } // Data da refeição
    }
}
