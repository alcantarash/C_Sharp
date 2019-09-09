using System;
using Curso_Orders.Entidades;
using Curso_Orders.Entidades.enums;

namespace Curso_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                id = 1080,
                moment = DateTime.Now,
                status = OrderStatus.PendingPayments
            };

            Console.WriteLine(order);

            string txt = OrderStatus.PendingPayments.ToString();        }
    }
}
