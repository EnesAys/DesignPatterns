using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
           var shoeFactory=new ShoeFactory();

           IShoe boot=shoeFactory.ProduceShoe(ShoeType.Boot);
           boot.TypeInfo();
           
           IShoe sneaker=shoeFactory.ProduceShoe(ShoeType.Sneaker);
           sneaker.TypeInfo();
           
           IShoe spikes=shoeFactory.ProduceShoe(ShoeType.Spikes);
           spikes.TypeInfo();
        }
    }
}

//Products
public interface IShoe
{
    void TypeInfo();
}

public class Boot : IShoe
{
    public void TypeInfo(){
        Console.WriteLine("My Type is boot");
    }
}
public class Sneaker : IShoe
{
    public void TypeInfo(){
        Console.WriteLine("My Type is sneaker");
    }
}
public class Spikes : IShoe
{
    public void TypeInfo(){
        Console.WriteLine("My Type is spikes");
    }
}
//Factory
public interface IShoeFactory
{
    IShoe ProduceShoe(ShoeType type);
}
public class ShoeFactory:IShoeFactory
{
    public IShoe ProduceShoe(ShoeType type)
    {
        switch (type)
        {
            case ShoeType.Boot:
                return new Boot();        
            case ShoeType.Sneaker:
                return new Sneaker();
            case ShoeType.Spikes:
                return new Spikes();            
            default:
                return new Boot();
        }
    }
}