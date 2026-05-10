using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcCalculator.Models
{
    public class CalculatorModel
    {
        // ============================================================
        // ЧАСТЬ 1 ПУНКТ 3: Класс модели калькулятора
        // Вариант 7: операнды - long, результат - decimal
        // ============================================================
        [Required(ErrorMessage = "Поле Operand1 обязательно для заполнения")] //ЧАСТЬ 3 ПУНКТ 1
        public long Operand1 { get; set; }
        [Range(0, 1000, ErrorMessage = "Значение Operand2 должно быть от 0 до 1000")] //ЧАСТЬ 3 ПУНКТ 1
        public long Operand2 { get; set; }
        public string Operation { get; set; }
        public decimal Result { get; set; }
    }
}