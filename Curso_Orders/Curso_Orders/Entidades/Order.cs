using System;
using System.Collections.Generic;
using System.Text;
using Curso_Orders.Entidades.enums;

namespace Curso_Orders.Entidades
{
    class Order
    {
        public int id { get; set; }
        public DateTime moment { get; set; }
        public OrderStatus status { get; set; }

        public override string ToString()
        {
            return id + " , " + moment + " , " + status;
        }
    }
}
