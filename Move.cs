using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoD
{
    internal class Move
    {
        public static Authorizations authorizations = new Authorizations();
        public static Admin admin = new Admin();
        public static Manager manager = new Manager();
        public static Client client = new Client();
        public static Guest guest = new Guest();
        public static OrderPage orderpage = new OrderPage();
    }
}
