#region Declaracion
using System.Text.Json;

Venta venta = new Venta(12);
VentaConImpuestos venta1 = new(78, 15.65m);
var message2 = venta1.Impuestos(154);

var message = venta1.GetInfo();
Console.WriteLine(message + " impuestos total es " + message2);
Console.WriteLine(venta1.GetInfoCliente());
Console.WriteLine(venta1.GetInfoCliente("Bryan Rauda"));

Pago ejemplo = new();
var valor = ejemplo.Total(400m, 0.13m);
Console.WriteLine(valor);

ejemplo.Mostrar(valor);

var numbers = new MyList<int>(5);
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);
numbers.Add(6);
Console.WriteLine(numbers.GetContent());

var nombres = new MyList<string>(5);
nombres.Add("a");
nombres.Add("b");
nombres.Add("c");
nombres.Add("d");
nombres.Add("e");
nombres.Add("f");
Console.WriteLine(nombres.GetContent());

var impuestosG = new MyList<Pago>(3);
impuestosG.Add(new Pago
{
    Iva = 13
});
impuestosG.Add(new Pago
{
    Iva = 10
});
impuestosG.Add(new Pago
{
    Iva = 15
});
impuestosG.Add(new Pago
{
    Iva = 23
});
Console.WriteLine(impuestosG.GetContent());

var Bryan = new Persona()
{
    Name = "Bryan",
    Age = 19
};

string json = JsonSerializer.Serialize(Bryan);
var myJson = @"{""Name"":""Bryan"", ""Age"":19}";
Console.WriteLine(json);

Persona? yo = JsonSerializer.Deserialize<Persona>(myJson);
Console.WriteLine(yo?.Name);
Console.WriteLine(yo?.Age);
#endregion

#region Lambda
Func<int, int, int> sub = (int x, int y) => x - y;
Func<int, int> some = a =>
{
    a = a + 1;
    return a * 2;
};
Func<int, int> some2 = a => a * 2;

Console.WriteLine(sub(9, 10));
Console.WriteLine(some(10));
Console.WriteLine(some2(100));

Some((a, b) => a + b, 5);

void Some(Func<int, int, int> fn, int number)
{

    var resultado = fn(number, number);
    Console.WriteLine(resultado);
}
#endregion

#region Linq
var names = new List<string>()
{
    "José",
    "Carlos",
    "Juan",
    "Luis",
    "Ricardo",
    "Mario",
    "Manuel",
    "Francisco",
    "David",
    "Miguel",
    "María",
    "Ana",
    "Carmen",
    "Rosa",
    "Silvia",
    "Claudia",
    "Karla",
    "Gabriela",
    "Paola",
    "Jessica",
    "Ever"
};

var names2 = from alias in names
             where alias.Length > 6
             orderby alias descending
             select alias;
var nombre3 = names.Where(n => n.Length > 7).OrderByDescending(n => n).Select(n => n);
foreach (var i in nombre3)
{
    Console.WriteLine(i);
}
#endregion

#region Clases
class Venta
{
    public decimal Total { get; set; }
    public Venta(decimal total)
    {
        this.Total = total;
    }
    public string GetInfo()
    {
        return "El total es: " + Total;
    }
    private string SoloEnLaCLase()
    {
        return "El total es: " + Total;
    }
    protected string SoloHeredados()
    {
        return "El total es: " + Total;
    }
    public virtual string GetInfoCliente()
    {
        return "El cliente se llama Carlos";
    }
}
class VentaConImpuestos : Venta
{
    decimal porcentaje;
    public VentaConImpuestos(decimal total, decimal porcentaje) : base(total)
    {
        this.porcentaje = porcentaje;
    }
    public decimal Impuestos(decimal impuesto)
    {
        var total = this.Total * impuesto;
        return total;
    }
    public override string GetInfoCliente()
    {
        return "El cliente se llama Juan " + porcentaje;
    }
    public string GetInfoCliente(string cliente)
    {
        return cliente;
    }
}
public class Pago : Object, IImpuesto, ICalcular, IMostrar
{
    public decimal Iva { get; set; }
    public decimal Total(decimal cantidad, decimal impuesto)
    {
        var resultado = cantidad += cantidad * impuesto;
        return resultado;
    }
    public void Mostrar(decimal resultado)
    {
        Console.WriteLine($"El resultado es: {resultado}");
    }
    public override string ToString()
    {
        return "El monto aplicado al articulo es " + Iva;
    }
}
public class MyList<T>
{
    private List<T> _list;
    private int _limit = 5;

    public MyList(int limit)
    {
        _limit = limit;
        _list = new List<T>();
    }
    public void Add(T item)
    {
        if (_list.Count < _limit)
        {
            _list.Add(item);
        }
    }
    public string GetContent()
    {
        string content = string.Empty;
        foreach (var item in _list)
        {
            content += item + ", ";
        }
        return content;
    }
}
public class Persona
{
    public string Name { get; set; }
    public int Age { get; set; }
}
#endregion

#region Interfaz
public interface IImpuesto
{
    public decimal Iva { get; set; }
}
public interface ICalcular
{
    public decimal Total(decimal cantidad, decimal impuesto)
    {
        var resultado = 0;
        return resultado;
    }
}
public interface IMostrar
{
    public void Mostrar(decimal resultado)
    {
        Console.WriteLine("El resultado es: " + resultado);
    }
}
#endregion