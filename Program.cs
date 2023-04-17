using NLog;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
string FilePathDefect = Directory.GetCurrentDirectory() + "\\Tickets.csv";
string FilePathTask = Directory.GetCurrentDirectory() + "\\Task.csv";
string FilePathEnhance = Directory.GetCurrentDirectory() + "\\Enhancements.csv";
// string FilePath = "Tickets.csv";


// finding all of the files
TicketFile ticketFile = new TicketFile(FilePathDefect);
TaskFile taskfile = new TaskFile(FilePathTask);
EnhancementFile enhanceFile = new EnhancementFile(FilePathEnhance);
string resp = "";
do
{

    Console.WriteLine("\n\t Ticket Handling System \n[1] Display Stored tickets \n[2] Submitt a ticket \nAny other input to exit");
    resp = Console.ReadLine();

    switch (resp)
    {
        case "1":

            Console.WriteLine("\n\t Ticket Display System \n[1] Display Defect tickets \n[2] Display Task tickets \n[3] Display Enhancement tickets \n[4] to search for a record \n[0] Any other input to exit");
            string resp2 = Console.ReadLine();

            // menu for which tickets to display
            switch (resp2)
            {
                case "1":
                    foreach (Defect t in ticketFile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                        Thread.Sleep(3000); // just to let you see what comes up before it goes back to the menu
                    }
                    break;

                case "2":

                    foreach (Task t in taskfile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                        Thread.Sleep(3000); // the same as previously stated
                    }

                    break;

                case "3":

                    foreach (Enhancement t in enhanceFile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                        Thread.Sleep(3000); // the same as previously stated
                    }

                    break;

                case "4":

                // this could be condensed down with a lot of methods which I would do if this was somthing I was sending to production

                    Console.WriteLine("What data set would you like to search \n[1] General Tickets \n[2] Task Tickets \n[3] Enhancement Tickets ");
                    string resp4 = Console.ReadLine();
                    switch (resp4)
                    {
                        case "1":
                            Console.WriteLine("What category would you like to search \n[1] priority \n[2] Status [3] submitter");
                            string resp5 = Console.ReadLine();
                            Console.WriteLine("What would you like to search for");
                            string searchOpt = Console.ReadLine();
                            switch (resp5)
                            {
                                case "1":
                                    Console.WriteLine("What status would you like to search for?");
                                    Console.WriteLine("\nWhat is the priority of the issue [1-10]: ");
                                    var generalStatus = ticketFile;


                                    foreach (Defect t in generalStatus.Tickets.Where(m => m.priority.Equals(Int32.Parse(Console.ReadLine()))))
                                    {
                                        Console.WriteLine(t.Display());
                                        Thread.Sleep(3000); // the same as previously stated
                                    }


                                    break;

                                case "2":
                                    Console.WriteLine("What status would you like to search for?");
                                    Console.WriteLine("\nWhat is the status of the ticket \n\t [1] Submitted  \n\t [2] Working \n\t [3] Finished \n\t [4] Esclated");
                                    var generalPriority = ticketFile;
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            foreach (Defect t in generalPriority.Tickets.Where(m => m.status.Contains("Submitted")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }
                                            break;

                                        case "2":
                                            foreach (Defect t in generalPriority.Tickets.Where(m => m.status.Contains("Working")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }

                                            break;

                                        case "3":
                                            foreach (Defect t in generalPriority.Tickets.Where(m => m.status.Contains("Finished")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }

                                            break;

                                        case "4":
                                            foreach (Defect t in generalPriority.Tickets.Where(m => m.status.Contains("Esclated")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }

                                            break;

                                        default:
                                            // I don't know what to keep here
                                            break;
                                    }

                                    break;


                                case "3":


                                    // looking back it would have been better to have stored all submitters as all uppercase

                                    Console.WriteLine("What submitter are you searching for?");
                                    var generalSubmitter = ticketFile;

                                    foreach (Defect t in generalSubmitter.Tickets.Where(m => m.submitter.Contains(Console.ReadLine())))
                                    {
                                        Console.WriteLine(t.Display());
                                        Thread.Sleep(3000); // the same as previously stated
                                    }




                                    break;


                                default:
                                    Console.WriteLine("Invalid Input");
                                    break;
                            }

                            break;

                        case "2":

                            Console.WriteLine("What category would you like to search \n[1] priority \n[2] Status [3] submitter");
                            string resp6 = Console.ReadLine();
                            Console.WriteLine("What would you like to search for");
                            string searchOpt2 = Console.ReadLine();
                            switch (resp6)
                            {
                                case "1":
                                    Console.WriteLine("What status would you like to search for?");
                                    Console.WriteLine("\nWhat is the priority of the issue [1-10]: ");
                                    var taskStatus = taskfile;


                                    foreach (Task t in taskStatus.Tickets.Where(m => m.priority.Equals(Int32.Parse(Console.ReadLine()))))
                                    {
                                        Console.WriteLine(t.Display());
                                        Thread.Sleep(3000); // the same as previously stated
                                    }


                                    break;

                                case "2":
                                    Console.WriteLine("What status would you like to search for?");
                                    Console.WriteLine("\nWhat is the status of the ticket \n\t [1] Submitted  \n\t [2] Working \n\t [3] Finished \n\t [4] Esclated");
                                    var taskPriority = taskfile;
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            foreach (Task t in taskPriority.Tickets.Where(m => m.status.Contains("Submitted")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }
                                            break;

                                        case "2":
                                            foreach (Task t in taskPriority.Tickets.Where(m => m.status.Contains("Working")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }

                                            break;

                                        case "3":
                                            foreach (Task t in taskPriority.Tickets.Where(m => m.status.Contains("Finished")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }

                                            break;

                                        case "4":
                                            foreach (Task t in taskPriority.Tickets.Where(m => m.status.Contains("Esclated")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }

                                            break;

                                        default:
                                            // I don't know what to keep here
                                            break;
                                    }

                                    break;


                                case "3":


                                    // looking back it would have been better to have stored all submitters as all uppercase

                                    Console.WriteLine("What submitter are you searching for?");
                                    var taskSubmitter = taskfile;

                                    foreach (Task t in taskSubmitter.Tickets.Where(m => m.submitter.Contains(Console.ReadLine())))
                                    {
                                        Console.WriteLine(t.Display());
                                        Thread.Sleep(3000); // the same as previously stated
                                    }




                                    break;


                                default:
                                    Console.WriteLine("Invalid Input");
                                    break;
                            }

                            break;

                        case "3":

                            Console.WriteLine("What category would you like to search \n[1] priority \n[2] Status [3] submitter");
                            string resp7 = Console.ReadLine();
                            Console.WriteLine("What would you like to search for");
                            string searchOpt3 = Console.ReadLine();
                            switch (resp7)
                            {
                                case "1":
                                    Console.WriteLine("What status would you like to search for?");
                                    Console.WriteLine("\nWhat is the priority of the issue [1-10]: ");
                                    var enhancementPriority = enhanceFile;


                                    foreach (Enhancement t in enhancementPriority.Tickets.Where(m => m.priority.Equals(Int32.Parse(Console.ReadLine()))))
                                    {
                                        Console.WriteLine(t.Display());
                                        Thread.Sleep(3000); // the same as previously stated
                                    }


                                    break;

                                case "2":
                                    Console.WriteLine("What status would you like to search for?");
                                    Console.WriteLine("\nWhat is the status of the ticket \n\t [1] Submitted  \n\t [2] Working \n\t [3] Finished \n\t [4] Esclated");
                                    var enhancePriority = enhanceFile;
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            foreach (Enhancement t in enhancePriority.Tickets.Where(m => m.status.Contains("Submitted")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }
                                            break;

                                        case "2":
                                            foreach (Enhancement t in enhancePriority.Tickets.Where(m => m.status.Contains("Working")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }

                                            break;

                                        case "3":
                                            foreach (Enhancement t in enhancePriority.Tickets.Where(m => m.status.Contains("Finished")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }

                                            break;

                                        case "4":
                                            foreach (Enhancement t in enhancePriority.Tickets.Where(m => m.status.Contains("Esclated")))
                                            {
                                                Console.WriteLine(t.Display());
                                                Thread.Sleep(3000); // the same as previously stated
                                            }

                                            break;

                                        default:
                                            // I don't know what to keep here
                                            break;
                                    }

                                    break;


                                case "3":


                                    // looking back it would have been better to have stored all submitters as all uppercase

                                    Console.WriteLine("What submitter are you searching for?");
                                    var enhanceSubmitter = enhanceFile;

                                    foreach (Enhancement t in enhanceSubmitter.Tickets.Where(m => m.submitter.Contains(Console.ReadLine())))
                                    {
                                        Console.WriteLine(t.Display());
                                        Thread.Sleep(3000); // the same as previously stated
                                    }




                                    break;


                                default:
                                    Console.WriteLine("Invalid Input");
                                    break;
                            }

                            break;

                        default:
                            Console.WriteLine("invalid input");
                            break;

                    }





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
            switch (Console.ReadLine())
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
            switch (Console.ReadLine())
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
            switch (Console.ReadLine())
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

            switch (resp3)
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

                    Enhancement EnhanceTicket = new Enhancement();
                    EnhanceTicket.submitter = submitter;
                    EnhanceTicket.desc = desc;
                    EnhanceTicket.status = status;
                    EnhanceTicket.priority = priority;
                    EnhanceTicket.worker = worker;
                    EnhanceTicket.watcher = watcher;

                    Console.WriteLine("What software does the ticket pretain to?");
                    EnhanceTicket.software = Console.ReadLine();

                    Console.WriteLine("What is your reason for submitting the ticket");
                    EnhanceTicket.reason = Console.ReadLine();

                    Console.WriteLine("What is the estimate cost of the ticket");
                    EnhanceTicket.Estimate = float.Parse(Console.ReadLine());

                    Console.WriteLine("What is the exceptible cost of the ticket");
                    EnhanceTicket.cost = float.Parse(Console.ReadLine());


                    break;
            }




            break;
        default:
            Console.WriteLine("Thanks for using the Ticket Handling System");
            break;

    }

} while (resp == "1" || resp == "2");