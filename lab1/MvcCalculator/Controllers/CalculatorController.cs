using MvcCalculator.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;


namespace MvcCalculator.Controllers
{
    
    public class CalculatorController : Controller
    {
        // ============================================================
        // ЧАСТЬ 1 ПУНКТ 4: Метод действия для GET-запроса (отображение формы)
        // ============================================================
        [HttpGet]
        public ActionResult Index()
        {
            SetOperations();
            //ЧАСТЬ 2 ПУНКТ 2
            ViewBag.ExpectedValue = 100; // любое число, с которым будем сравнивать результат
            return View(new CalculatorModel());
        }
        // ============================================================
        // ЧАСТЬ 1 ПУНКТ 4: Метод действия для POST-запроса (вычисление)
        // Используется switch-case по выбранной операции
        // ============================================================

        [HttpPost]
        public ActionResult Index(CalculatorModel model, string buttonAction)
        {
            
            // ЧАСТЬ 2 ПУНКТ 5 Проверяем, какая кнопка нажата
            if (buttonAction == "Очистить")
            {
                // Очищаем все поля модели
                model.Operand1 = 0;
                model.Operand2 = 0;
                model.Operation = null;
                model.Result = 0;

                // Очищаем ошибки валидации (если были)
                ModelState.Clear();

                // Заполняем список операций для DropDownList (чтобы он не был пустым)
                SetOperations();

                // Возвращаем представление с очищенной моделью
                return View(model);
            }

            // ЧАСТЬ 3 ПУНКТ 2 Проверяем, прошла ли модель валидацию (не пустые ли поля, в диапазоне ли числа)
            if (!ModelState.IsValid)
            {
                // Если есть ошибки — показываем форму с ошибками, не выполняя вычислений
                SetOperations();
                return View(model);
            }

                switch (model.Operation)
            {
                // ---------- ЧАСТЬ 1 (по заданию: только + и -) ----------
                case "+":
                    model.Result = model.Operand1 + model.Operand2;
                    break;

                case "-":
                    model.Result = model.Operand1 - model.Operand2;
                    break;

                // ---------- ДОПОЛНИТЕЛЬНО (часть 2 или задание преподавателя) ----------

                case "*":
                    model.Result = model.Operand1 * model.Operand2;
                    break;

                case "/":
                    if (model.Operand2 != 0)
                    {
                        model.Result = (decimal)model.Operand1 / model.Operand2;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Деление на ноль невозможно.");
                    }
                    break;

                default:
                    ModelState.AddModelError("", "Выберите операцию.");
                    break;
            }

            ModelState.Remove("Result");
            SetOperations();
            ViewBag.ExpectedValue = 100; //ЧАСТЬ 2 ПУНКТ 2
            //ЧАСТЬ 4 ПУНКТ 1
            HttpCookie cookie = new HttpCookie("LastOperation");
            cookie.Value = model.Operand1 + model.Operation + model.Operand2 + "=" + model.Result;
            Response.Cookies.Add(cookie);

            return View(model);
        }
        //ЧАСТЬ 4 ПУНКТ 1
        public ActionResult Details()
        {
            string operationString = "";

            HttpCookie cookie = Request.Cookies["LastOperation"];

            if (cookie != null)
            {
                operationString = cookie.Value;
                //ЧАСТЬ 4 ПУНКТ 2 ВАРИАНТ 3
                if (operationString.Contains("+"))
                {
                    int index = operationString.IndexOf("+");
                    operationString = operationString.Remove(index, 1);
                    operationString = operationString.Insert(index, " плюс ");
                }
                else if (operationString.Contains("-"))
                {
                    int index = operationString.IndexOf("-");
                    operationString = operationString.Remove(index, 1);
                    operationString = operationString.Insert(index, " минус ");
                }
                else if (operationString.Contains("*"))
                {
                    int index = operationString.IndexOf("*");
                    operationString = operationString.Remove(index, 1);
                    operationString = operationString.Insert(index, " умножить на ");
                }
                else if (operationString.Contains("/"))
                {
                    int index = operationString.IndexOf("/");
                    operationString = operationString.Remove(index, 1);
                    operationString = operationString.Insert(index, " разделить на ");
                }
            }
            else
            {
                operationString = "Нет данных о последней операции";
            }

            ViewBag.OperationString = operationString;
            return View();
        }

        // ============================================================
        // ЧАСТЬ 1 ПУНКТ 4 (вспомогательный метод): формирование списка для DropDownList
        // Вариант Б: используется DropDownList
        // ============================================================
        private void SetOperations()
        {
            ViewBag.OperationList = new List<SelectListItem>
            {
                new SelectListItem { Text = "+", Value = "+" },
                new SelectListItem { Text = "-", Value = "-" },
                new SelectListItem { Text = "*", Value = "*" },
                new SelectListItem { Text = "/", Value = "/" }
            };
        }
    }
}