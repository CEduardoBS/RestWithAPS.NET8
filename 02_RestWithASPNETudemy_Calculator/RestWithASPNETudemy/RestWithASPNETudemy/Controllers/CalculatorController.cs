using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestWithASPNETudemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{operation}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(String operation, String firstNumber, String secondNumber)
        {
            if (operation == "sum") {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
                }
            } else if (operation == "sub")
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                    return Ok(sub.ToString());
                }
            } else if (operation == "multi")
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var multi = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    return Ok(multi.ToString());
                }
            } else if (operation == "div")
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    return Ok(div.ToString());
                }
            } else if (operation == "raiz")
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var raiz = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber));
                    return Ok(raiz.ToString());
                }
            } else if (operation == "media")
            {
                if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                {
                    var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                    return Ok(media.ToString());
                }
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);



            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

    }
}