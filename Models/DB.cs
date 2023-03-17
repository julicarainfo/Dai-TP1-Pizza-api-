using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;


namespace Pizzas.API.Models;

public static class DB
{
    private static string _connectionString = @"Server=A-PHZ2-AMI-005;DataBase=PizzaDB;Trusted_Connection=True;";

    private static List<Pizza> _ListaPizza = new List<Pizza>();

    public static List<Pizza> GetAllPizza()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {

            string sql = "SELECT IdP, Nombre, Precio, Ingredientes, LibreGluten FROM Pizza";

            _ListaPizza = db.Query<Pizza>(sql).ToList();

        }

        return _ListaPizza;

    }
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
    public static int InsertPizza(Pizza p)
    {
        int RowsAf = 0;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Pizza(Nombre, Precio, Ingredientes, LibreGluten) VALUES(@Nombre, @Precio, @Ingredientes, @LibreGluten)";
            RowsAf = db.Execute(sql, new { Nombre = p.Nombre, Precio = p.Precio, Ingredientes = p.LibreGluten });
        }
        return RowsAf;
    }
    public static int DeletePizza(int IdP)
    {
        int RowsAf = 0;
        string sql = "DELETE FROM Pizza WHERE IdP = @PIdP";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            RowsAf = db.Execute(sql, new { PIdP = IdP });
        }
        return RowsAf;
    }
    public static int UpdatePizza(Pizza p)
    {
        int RowsAf = 0;
        string sql = "UPDATE Pizza SET Nombre=@Nombre, Precio=@Precio, Ingredientes=@Ingredientes,LibreGluten=@LibreGluten WHERE IdP = @IdP";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            RowsAf = db.Execute(sql, new { Nombre = p.Nombre, Precio = p.Precio, Ingredientes = p.Ingredientes, LibreGluten = p.LibreGluten });
        }
        return RowsAf;
    }
}
