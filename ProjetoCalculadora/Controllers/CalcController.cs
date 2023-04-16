using Microsoft.AspNetCore.Mvc;
using ProjetoCalculadora.Models;

namespace ProjetoCalculadora.Controllers;
[ApiController]
[Route("[controller]")]
public class CalcController : ControllerBase
{
    [HttpPost]
    public ActionResult<double> Calcular(Operacao operacao)
    {
        double resultado = 0;
        switch (operacao.Operador)
        {
             case "+":
                 resultado = operacao.Valor1 + operacao.Valor2;
                 break;
             case "-":
                 resultado = operacao.Valor1 - operacao.Valor2;
                 break;
             case "*":
                 resultado = operacao.Valor1 * operacao.Valor2;
                 break;
             case "/":
                 if (operacao.Valor2 == 0)
                 {
                     return BadRequest("Não é possivel dividir por zero");
                 }
                 resultado = operacao.Valor1 / operacao.Valor2;
                 
                 break;
             
             default:
                 return BadRequest("Operador inválido.");
        }

        return resultado;
    }
}