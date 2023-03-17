using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;


namespace Pizzas.API.Models;

public static class BD
{
    private static string _connectionString = @"Server=A-PHZ2-AMI-005;DataBase=PizzaBD;Trusted_Connection=True;";

    //private static List<Pizza> _ListaPizza = new List<Pizza>();

    public static Pizza GetPizzaById(int IdP)
    {
        Pizza p = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Pizza WHERE IdP = @PIdP";
            p = db.QueryFirstOrDefault<Pizza>(sql, new { PIdP = IdP });
        }
        return p;
    }
    public static void InsertPizza(Pizza p)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Pizza(Nombre, Precio, Ingredientes, LibreGluten) VALUES(@Nombre, @Precio, @Ingredientes, @LibreGluten)";
            db.Execute(sql, new { Nombre = p.Nombre, Precio = p.Precio, Ingredientes = p.LibreGluten });
        }
    }
    public static void DeletePizza(int IdP)
    {
        string sql = "DELETE FROM Pizza WHERE IdP = @PIdP";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { PIdP = IdP });
        }
    }
    public static void UpdatePizza(Pizza p)
    {
        string sql = "UPDATE Pizza SET Nombre=@Nombre, Precio=@Precio, Ingredientes=@Ingredientes,LibreGluten=@LibreGluten WHERE IdP = @IdP";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { Nombre = p.Nombre, Precio = p.Precio, Ingredientes = p.Ingredientes, LibreGluten = p.LibreGluten});
        }
        return p;
    }
}
