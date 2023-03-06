using NLog;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
string FilePath = Directory.GetCurrentDirectory() + "\\Tickets.csv";

TicketFile ticketFile = new TicketFile(FilePath);
string resp = "";
do{

    Console.WriteLine("\n\t Ticket Handling System \n[1] Display Stored tickets \n[2] Submitt a ticket \nAny other input to exit");
    resp = Console.ReadLine();

    switch(resp)
    {
        case "1":

        foreach(Ticket t in ticketFile.Tickets){
            Console.WriteLine(t.Display());
        }

        break;
        case "2":

            Ticket ticket = new Ticket();
            Console.WriteLine("\nWho is submitting this ticket: ");
            ticket.submitter = Console.ReadLine();
            Console.WriteLine("\nDescribe the issue: ");
            ticket.desc = Console.ReadLine();
            Console.WriteLine("\nWhat is the priority of the issue [1-10]: ");
            ticket.priority = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nWhat is the status of the ticket \n\t [1] Submitted  \n\t [2] Working \n\t [3] Finished \n\t [4] Esclated");
                switch(Console.ReadLine())
                    {
                        case "1":
                            ticket.status = "Submitted";
                        break;

                        case "2":
                            ticket.status = "Working";
                        break;

                        case "3":
                            ticket.status = "Finished";
                        break;

                        case "4":
                            ticket.status = "Esclated";                        
                        break;

                        default:
                            ticket.status = "N/A";
                        break;
                    }
            Console.WriteLine("\nWho is to be assigned this ticket \n\t [1] Zack  \n\t [2] Jack \n\t [3] Carson ");
                switch(Console.ReadLine())
                    {
                        case "1":
                            ticket.status = "Zack";
                        break;

                        case "2":
                            ticket.status = "Jack";
                        break;

                        case "3":
                            ticket.status = "Carson";
                        break;

                        default:
                            ticket.status = "N/A";
                        break;
                    }        
            Console.WriteLine("\nWho will supervise this ticket \n\t [1] Jeff  \n\t [2] Patrick \n\t [3] Matthew ");
                switch(Console.ReadLine())
                    {
                        case "1":
                            ticket.status = "Jeff";
                        break;

                        case "2":
                            ticket.status = "Patrick";
                        break;

                        case "3":
                            ticket.status = "Matthew";
                        break;

                        default:
                            ticket.status = "N/A";
                        break;
                    } 
            ticketFile.submittTicket(ticket);       
        break;
        default:
            Console.WriteLine("Thanks for using the Ticket Handling System");
        break;

    }

}while(resp == "1" || resp == "2");