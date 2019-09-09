using System;
using System.Collections.Generic;
using System.Text;

namespace Curso_Orders.Entidades.enums
{
    enum OrderStatus : int
    {
        PendingPayments,
        Processing,
        Shipped,
        Delivered
    }
}
