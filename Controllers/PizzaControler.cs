/*
pasos de api pizza: 
1. Create proyect 
2. chequear que postman devuel ve algo
3. git/github  
4.Crear BD
5.Get (model Bd y las tablas;home controller)
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
    public Pizza GetPizzaId(int Id)
    {
        return BD.GetPizzaById(Id);
    }
}