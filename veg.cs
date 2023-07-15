using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public class veginfo
    {
        public string name { get; set; }
        public string ownername  { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public string location { get; set; }
    }

    public class vegrepositary
    {
        public readonly string connectionstring;

        public vegrepositary()
        {
            connectionstring = @"Data source=DESKTOP-23V7KHU;Initial catalog=test SQL;User Id=sa;Password=Anaiyaan@123";

        }
        public veginfo models()
        {
            veginfo v = new veginfo();
            Console.WriteLine("enter the nmae");
            v.name = Console.ReadLine();
            Console.WriteLine("enter the ownername");
            v.ownername = Console.ReadLine();
            Console.WriteLine("enter the quantity");
            v.quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the price");
            v.price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the location");
            v.location = Console.ReadLine();

            return v;
        }

        public void insert(veginfo q)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            con.Open();
            con.Execute($"exec pinsert '{q.name}','{q.ownername}','{q.quantity}','{q.price}','{q.location}'");
            con.Close();
        }
        public List<veginfo> select()
        {
            SqlConnection con = new SqlConnection(connectionstring);
            List<veginfo> res = new List<veginfo>();

            con.Open();
            res = con.Query<veginfo>("exec selects ").ToList();
            con.Close();

            foreach(var n in res)
            {
                Console.WriteLine($"name{n.name},ownername{n.ownername},quantity{n.quantity},price{n.price},location{n.location}");
            }

            return res;
        }

        public void s()
        {
            int s;
            do
            {
                Console.WriteLine("choose the option");
                Console.WriteLine("0.Exist");
                Console.WriteLine("1.insert");
                Console.WriteLine("2.select");

                s = Convert.ToInt32(Console.ReadLine());


                switch (s)
                {
                    case 0:
                        Console.WriteLine("thank u");
                        break;

                    case 1:
                        vegrepositary obj = new vegrepositary();
                        var mini = obj.models();
                        obj.insert(mini);
                        break;

                    case 2:
                        vegrepositary obj1 = new vegrepositary();
                        obj1.select();
                        break;
                }
            } while (s != 0);
        }
    }
}
