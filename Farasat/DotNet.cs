using Admin.Authentication;
using Admin.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat
{
    public class DotNet
    {
        public void F()
        {
            Admin.Authentication.Login obj = new Admin.Authentication.Login();
            Admin.Reporting.Login obj1 = new Admin.Reporting.Login();
        }
    }
}

namespace Admin.Authentication
{
    public class Login { }
    public class B { }
    public class C { }
}

namespace Admin.Reporting
{
    public class Login { }
    public class B { }
    public class C { }
}

namespace Admin.Transactions
{
    public class Login { }
    public class B { }
    public class C { }
}

namespace Admin.Transactions.Cash
{
    public class A { }
    public class B { }
    public class C { }
}

namespace Admin.Transactions.Credit
{
    public class A { }
    public class B { }
    public class C { }
}