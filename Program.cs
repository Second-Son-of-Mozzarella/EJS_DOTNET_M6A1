using NLog;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
string FilePathDefect = Directory.GetCurrentDirectory() + "\\Tickets.csv";
string FilePathTask = Directory.GetCurrentDirectory() + "\\Task.csv";
// string FilePath = "Tickets.csv";


// finding all of the files
TicketFile ticketFile = new TicketFile(FilePathDefect);
TaskFile taskfile = new TaskFile(FilePathTask);
string resp = "";
do{

    Console.WriteLine("\n\t Ticket Handling System \n[1] Display Stored tickets \n[2] Submitt a ticket \nAny other input to exit");
    resp = Console.ReadLine();

    switch(resp)
    {
        case "1":

            Console.WriteLine("\n\t Ticket Display System \n[1] Display Defect tickets \n[2] Display Task tickets \n[3] Display Enhancement tickets \n[0] Any other input to exit");
            string resp2 = Console.ReadLine();

                // menu for which tickets to display
            switch(resp2)
            {
                case "1": 
                    foreach(Defect t in ticketFile.Tickets){
                        Console.WriteLine(t.Display());
                    }
                break;

                case "2":

                    foreach(Task t in taskfile.Tickets){
                        Console.WriteLine(t.Display());
                    }

                break;
                
                case "3":

                break;

                default: 
                // Just to do nothing
                break;
            }
        

        break;
        case "2":
            string submitter;
            string desc;
            int priority;
            string status;
            string worker;
            string watcher;


        // the next few questions apply to all tickets
            Console.WriteLine("\n\t Ticket Display System \n[1] Add a Defect ticket \n[2] Add a Task ticket \n[3] Add a Enhancement ticket \n[0] Any other input to exit");
            string resp3 = Console.ReadLine();


            Console.WriteLine("\nWho is submitting this ticket: ");
                submitter = Console.ReadLine();
                Console.WriteLine("\nDescribe the issue: ");
                desc = Console.ReadLine();
                Console.WriteLine("\nWhat is the priority of the issue [1-10]: ");
                priority = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\nWhat is the status of the ticket \n\t [1] Submitted  \n\t [2] Working \n\t [3] Finished \n\t [4] Esclated");
                    switch(Console.ReadLine())
                        {
                            case "1":
                                status = "Submitted";
                            break;

                            case "2":
                                status = "Working";
                            break;

                            case "3":
                                status = "Finished";
                            break;

                            case "4":
                                status = "Esclated";                        
                            break;

                            default:
                                status = "N/A";
                            break;
                        }
                Console.WriteLine("\nWho is to be assigned this ticket \n\t [1] Zack  \n\t [2] Jack \n\t [3] Carson ");
                    switch(Console.ReadLine())
                        {
                            case "1":
                                worker = "Zack";
                            break;

                            case "2":
                                worker = "Jack";
                            break;

                            case "3":
                                worker = "Carson";
                            break;

                            default:
                                worker = "N/A";
                            break;
                        }        
                Console.WriteLine("\nWho will supervise this ticket \n\t [1] Jeff  \n\t [2] Patrick \n\t [3] Matthew ");
                    switch(Console.ReadLine())
                        {
                            case "1":
                                watcher = "Jeff";
                            break;

                            case "2":
                                watcher = "Patrick";
                            break;

                            case "3":
                                watcher = "Matthew";
                            break;

                            default:
                                watcher = "N/A";
                            break;
                        } 
 
            switch(resp3)
            {
                case "1": // nothing to change for this ticket
                     Defect DefectTicket = new Defect();
                     DefectTicket.submitter = submitter;
                     DefectTicket.desc = desc;
                     DefectTicket.status = status;
                     DefectTicket.priority = priority;
                     DefectTicket.worker = worker;
                     DefectTicket.watcher = watcher;
                     ticketFile.submittTicket(DefectTicket); 

                break;

                case "2":
                    Task TaskTicket = new Task();
                    string day;
                    string month;
                    string year;

                     TaskTicket.submitter = submitter;
                     TaskTicket.desc = desc;
                     TaskTicket.status = status;
                     TaskTicket.priority = priority;
                     TaskTicket.worker = worker;
                     TaskTicket.watcher = watcher;


                     Console.WriteLine("What is the name of the project in question: ");
                     TaskTicket.ProjectName = Console.ReadLine();
                     Console.WriteLine("What year does the ticket need to be full filled by");
                     year = Console.ReadLine();
                     Console.WriteLine("What month does the ticket need to be full filled by");
                     month = Console.ReadLine();
                     Console.WriteLine("What day does the ticket need to be full filled by");
                     day = Console.ReadLine();
                     TaskTicket.date = $"{year}/{month}/{day}";

                     taskfile.submittTicket(TaskTicket); 
                break;

                case "3":

                break;
            }

               
                
                      
            break;
            default:
                Console.WriteLine("Thanks for using the Ticket Handling System");
            break;

    }

}while(resp == "1" || resp == "2");