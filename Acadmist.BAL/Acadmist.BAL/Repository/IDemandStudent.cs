using Acadmist.BAL.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Repository
{
    public interface IDemandStudent
    {
        List<DemandListComponent> GetFeeDue(int StudentId);
        List<PaymentReceiptComponent> GetPaymentReceipt(int StudentID);
    }
}
