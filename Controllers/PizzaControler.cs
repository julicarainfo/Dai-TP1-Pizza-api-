/*
pasos de api pizza: 
1. Create proyect 
2. chequear que postman devuel ve algo
3. git/github  
4.Crear DB
5.Get (model DB y las tablas;home controller)
6.Test de get en postman y en chrome
7. get by id; post; delete; put
*/
using Microsoft.AspNetCore.Mvc;
using Pizzas.API.Models;
namespace Pizzas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase

{

    [HttpGet]

    public IActionResult GetAll()
    {

        IActionResult Estado;
        List<Pizza> ListaPizza;
        ListaPizza = DB.GetAllPizza();
        if (ListaPizza == null) Estado = NotFound();
        else Estado = Ok(ListaPizza);
        return Estado;

    }
    [HttpGet("{IdP}")]
    public IActionResult GetPizzaId(int IdP)
    {
        IActionResult Estado = null;
        Pizza p;
        p = DB.GetPizzaById(IdP);
        if (p == null) Estado = NotFound();
        else Estado = Ok(p);
        return Estado;
    }

    [HttpPost]
    public IActionResult CreatePizza(Pizza p)
    {
        int RowsAffected;
        RowsAffected = DB.InsertPizza(p);
        return CreatedAtAction(nameof(CreatePizza), new { IdP = p.IdP }, p);
    }
    [HttpPut("{IdP}")]
    public IActionResult Update(int IdP, Pizza p)
    {
        IActionResult Estado = null;
        Pizza pizza;
        int RowsAffected;
        if (IdP != p.IdP) Estado = BadRequest();
        else
        {
            pizza = DB.GetPizzaById(IdP);
            if (pizza == null)
            {
                Estado = NotFound();
            }
            else
            {
                RowsAffected = DB.UpdatePizza(p);
                if (RowsAffected > 0) Estado = Ok(pizza);
                else Estado = NotFound();
            }
        }
        return Estado;
    }
    [HttpDelete("{IdP}")]

    public IActionResult DeleteById(int IdP)
    {

        IActionResult Estado = null;
        Pizza p;
        int RowsAffected;
        p = DB.GetPizzaById(IdP);
        if (p == null) Estado = NotFound();
        else
        {
            RowsAffected = DB.DeletePizza(IdP);
            if (RowsAffected > 0) Estado = Ok(p);
            else Estado = NotFound();
        }
        return Estado;
    }
}