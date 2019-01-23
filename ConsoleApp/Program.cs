using System;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            var order = new Order();
            order.PropertyChanged += (sender, eventArgs) => { Console.WriteLine($"\n    {eventArgs.PropertyName} {order}"); };
            order.Id = 10;
            order.Name = "马虎维";
            
            var ret = Console.ReadLine();
        }
    }
}
