using System;

public class Pizza
{
    private int _IdP;
    private string _Nombre;
    private double _Precio;
    private string _Ingredientes;
    private bool _LibreGluten;

    public Pizza(int _IdP, string _Nombre, double _Precio, string _Ingredientes, bool _LibreGluten)
    {
        int IdP = _IdP;
        string Nombre = _Nombre;
        double Precio = _Precio;
        string Ingredientes = _Ingredientes;
        bool LibreGluten = _LibreGluten;
    }
    public Pizza()
    { }

    public int IdP
    {
        get { return _IdP; }
        set { _IdP = value; }
    }
    public string Nombre
    {
        get { return _Nombre; }
        set { _Nombre = value; }
    }
    public double Precio
    {
        get { return _Precio; }
        set { _Precio = value; }
    }
    public string Ingredientes
    {
        get { return _Ingredientes; }
        set { _Ingredientes = value; }
    }
        public bool LibreGluten
    {
        get { return _LibreGluten; }
        set { _LibreGluten = value; }
    }
}