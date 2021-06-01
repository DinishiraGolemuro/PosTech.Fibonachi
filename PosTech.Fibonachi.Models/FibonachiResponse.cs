namespace PosTech.Fibonachi.Models
{
    /// <summary>
    /// Модель ответа рассёта числа Фибоначи
    /// </summary>
    public class FibonachiResponse
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public FibonachiResponse(double result)
        {
            Result = result;
        }

        /// <summary>
        /// Число Фибоначи
        /// </summary>
        public double Result { get; set; }
    }
}