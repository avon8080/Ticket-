using System.IO;

namespace Ticket_master
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            var file = "tickets.csv";
            Header(file);
            string menu = "";
            do
            {
                Console.Write("--Enter the corresponding # to commit to action--\n\t (W) to Write to file\n\t (R) Read file\n\t(Exit) to exit \n\tInput: ");
                menu = Console.ReadLine().ToLower();
                if (menu == "w")
                {
                    
                    Write(file);
                }
                else if (menu == "r")
                {
                    Read(file);
                }
                
            } while (menu != "exit");


        }

        public static void Header(string file)
        {
            StreamWriter streamWriter = new StreamWriter(file, false);
            streamWriter.WriteLine("ID, Summary, Status, Priority, Submitter, Assigned");
            streamWriter.Close();
        }

        public static void Write(string file)
        {
            StreamWriter streamWriter = new StreamWriter(file, true);     
            Console.WriteLine("Enter Ticket ID: ");

            var idNum = Console.ReadLine();
            
            Console.WriteLine("Enter summary: ");
            
            var summary = Console.ReadLine();
            
            Console.WriteLine("Enter Status: ");
            
            var status = Console.ReadLine();
            
            Console.WriteLine("Enter Priority: ");
            
            var priority = Console.ReadLine();
            
            Console.WriteLine("Enter Submitter: ");
            
            var submitter = Console.ReadLine();
            
            Console.WriteLine("Would you like to enter assigned watching? (y - yes or n - no");
            
            var isAssigned = Console.ReadLine().ToLower();
            
            List<String> assigned = new List<string>();
            
            while (isAssigned == "y"){
                
                Console.WriteLine("Enter name: ");
                
                assigned.Add( Console.ReadLine());
                
                Console.WriteLine("Do you want to continue (y - yes or n - no");
                
                 isAssigned = Console.ReadLine().ToLower();
            }

            var concat = "";
            for (int i = 0; i < assigned.Count; i++)
            {
                concat += string.Concat(assigned[i]);
                if (assigned.Count > 1 && i < assigned.Count - 1)
                {
                    concat += " | ";
                }
            }
            streamWriter.Write($"{idNum}, {summary}, {status}, {priority}, {submitter}, {concat}\n");
            streamWriter.Flush();
            streamWriter.Close();
        }
    
    public static void Read(string file)
    {
        if (File.Exists(file))
        {
          StreamReader sr = new StreamReader(file);

          while (sr.EndOfStream != true)
          {
              var line = sr.ReadLine();


              Console.WriteLine(line);
          }
        }
        
        

    }

    }
}


