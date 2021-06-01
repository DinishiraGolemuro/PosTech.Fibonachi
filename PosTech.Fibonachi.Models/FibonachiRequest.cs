namespace PosTech.Fibonachi.Models
{
    /// <summary>
    /// Модель запроса на расчёт чисел Фибоначи
    /// </summary>
    public class FibonachiRequest
    {
        /// <summary>
        /// Длина последовательности
        /// </summary>
        public int SequenceLength { get; set; }
    }
}