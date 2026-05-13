namespace ALLmoco.Models // Criação das tabelas em SQLite, por ser mais leve vai ser melhor pra mim
{
    public class MealCheck
    {
        public int Id { get; set; }

        public string MealType { get; set; } = string.Empty; // Nome da refeição

        public bool AteMeal { get; set; } // Se retorna verdadeiro ou falso (checkbox)

        public bool DidNotEat { get; set; } // propriedade que adiciona a checkbox de falso

        public string? Description { get; set; } // Descrição ou observação da refeição

        public DateTime Date { get; set; } // Data da refeição
    }
}
