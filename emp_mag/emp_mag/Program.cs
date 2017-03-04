
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace empmanag
{
    class Program
    {
        private string id, name, email,number, cur_data, up_data;
        private int min = 15000, max = 30000, salary;
        public string salary1;
        public int no_enteries = 0;
        List<KeyValuePair <int, string>> kvp  = new List<KeyValuePair <int, string>>();
        List<KeyValuePair <int, string>> kvp3 = new List<KeyValuePair <int, string>>();

        public string e_id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string e_name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string e_email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string e_number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public void input()
        {
            Console.Clear();

            Boolean bl_id, bl_name, bl_email, bl_number;
            Regex rg_id_data = new Regex("ACE[0-9]{4}");
            Regex rg_name_data = new Regex("^[a-zA-Z]{1,40}$");
            Regex rg_number_data = new Regex("^[6-9]([0-9]{9})$");
            Regex rg_email_data = new Regex("[a-z]+[.]+[a-z]+@aspiresys.com");
            //Regex rg_salary_data = new Regex("[1-9]([0-9]{4})");
            
            Console.WriteLine(" Enter Employee ID :");
            e_id = Console.ReadLine();
            bl_id = rg_id_data.IsMatch(id);
            while (bl_id == false)
            {
                Console.WriteLine("Enter a valid Employee Id ACE followed by 4-digit number :");
                Console.WriteLine(" Enter Employee ID :");
                e_id = Console.ReadLine();
                bl_id = rg_id_data.IsMatch(id);
            }
            kvp.Add (new KeyValuePair<int, string>(0, e_id));
            kvp3.Add(new KeyValuePair<int, string>(no_enteries, e_id));


            Console.WriteLine(" Enter Employee Name :");
            e_name = Console.ReadLine();
            bl_name = rg_name_data.IsMatch(name);
            while (bl_name != true)
            {
                Console.WriteLine("Enter a valid Employee Name :");
                Console.WriteLine(" Enter Employee Name :");
                e_name = Console.ReadLine();
                bl_name = rg_name_data.IsMatch(name);
            }
            kvp.Add (new KeyValuePair<int, string>(1, e_name));
            kvp3.Add(new KeyValuePair<int, string>(no_enteries, e_name));


            Console.WriteLine(" Enter Employee e-mail id :");
            e_email = Console.ReadLine();
            bl_email = rg_email_data.IsMatch(email);
            while (bl_email != true)
            {
                Console.WriteLine("Enter a valid Employee email :");
                Console.WriteLine(" Enter Employee e-mail id :");
                e_email = Console.ReadLine();
                bl_email = rg_email_data.IsMatch(email);                
            }
            kvp.Add (new KeyValuePair<int, string>(2, e_email));
            kvp3.Add(new KeyValuePair<int, string>(no_enteries, e_email));            


            Console.WriteLine(" Enter Employee phone number :");
            e_number = Console.ReadLine();
            bl_number = rg_number_data.IsMatch(e_number);
            while (bl_number != true)
            {
                Console.WriteLine("Enter a valid Employee phone number 10 digits starting form (6-9) :");
                Console.WriteLine(" Enter Employee phone number :");
                e_number = Console.ReadLine();
                bl_number = rg_number_data.IsMatch(e_number);
            }
            kvp.Add (new KeyValuePair<int, string>(3, e_number));
            kvp3.Add(new KeyValuePair<int, string>(no_enteries, e_number));


            Console.WriteLine(" Enter Employee Salary :");
            try
            {
                salary1 = Console.ReadLine();
            }
            catch (InvalidCastException e)
            {
            }
           
            //bl_salary = rg_salary_data.IsMatch(salary1);
            //while (bl_salary != true)
            //{
            //    Console.WriteLine("Enter a validdd salary between {0} - {1}:", min, max);
            //    Console.WriteLine(" Enter Employee salary :");
            //    salary1 = Console.ReadLine();
            //    //salary = Convert.ToInt32(salary1);
            //}
            salary = Convert.ToInt32(salary1);
            while (salary>max || salary< min)
            {
                Console.WriteLine("Enter a valid salary between {0} - {1}:",min, max);
                Console.WriteLine(" Enter Employee Salary :");
                salary1 = Console.ReadLine();
                salary = Convert.ToInt32(salary1);
            }
            kvp.Add (new KeyValuePair<int, string>(4, salary1));
            kvp3.Add(new KeyValuePair<int, string>(no_enteries, salary1));
            //output();
        }

        public void view()
        {
            int j=0;
            var dict = kvp3.ToLookup(kvp1 => kvp1.Key, kvp1 => kvp1.Value);
            for(j=0;j<no_enteries; j++)
            {
                foreach(string X in dict[j])
                    Console.Write(X+"\t\t");
            }
            Console.WriteLine("\n");
        }
        public void truncate()
        {
            Console.WriteLine("quot;Are you sure ? (y or n) :");
            string st = Console.ReadLine();
            if(st=="y"||st=="Y")
            kvp.Clear();
            Console.WriteLine("Employee Management System datas are Empty To view add data ");
        }


        public void output()
        {
            Console.Clear();
            Console.WriteLine("Employee Id           : {0}", id);
            Console.WriteLine("Employee Name         : {0}", name);
            Console.WriteLine("Employee mail id      : {0}", email);
            Console.WriteLine("Employee Phone Number : {0}", number);
            Console.WriteLine("Employee Salary       : {0}", salary1);
        }
    }


    public class display
    {
       public static void Main(string[] args)
        {
            string cont;
            Program p = new Program();
            //Console.WriteLine("dd");
            do
            {
                Console.Clear();
                Console.WriteLine(" EMPLOYEE MANAGEMENT SYSTEM");
                
                Console.WriteLine(" Enter your Choice of Selection : \n 1. Enter new Enteries\n 2. View Employee Details\n 3. View Selected Employee Details\n 4. Delete Details \n 5. Update selected Employee Details");
                int choice = Convert.ToInt32(Console.ReadLine());
                //Console.ReadKey();
                switch (choice)
                {
                    case 1:                                                            // switch case to add data     
                        int i;
                        Console.WriteLine("Enter the Number of Enterie to be Entered :");
                        int no_ent = Convert.ToInt32(Console.ReadLine());
                        for (i = 0; i < no_ent; i++)
                        {
                            p.input();
                            p.output();
                            Console.ReadKey();
                            p.no_enteries++;
                        }
                        
                    break;
                    case 2:                                                             //  switch case to view the data

                    p.view();
                    break;
                    case 3:                                                             //View Selected Employee Details
                        {
                            p.view();
                           
                            
                        }
                    break;
                    case 4:                                                             //Delete Details
                        {
                            p.truncate();
                            Console.WriteLine("Employee Details have been sucessfully deleted");
                        }

                    break;
                    case 5:                                                            // Update selected Employee Details
                    {

                    }

                    break;



                }
                //Console.ReadKey();

                Console.WriteLine("Enter your choice weather you want to continue or not y/n");
                cont = Console.ReadLine();
            } while (cont == "Y" || cont == "y");
        }

        
        }
}