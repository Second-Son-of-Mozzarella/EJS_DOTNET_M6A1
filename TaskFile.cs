using NLog;

public class TaskFile
{
public string filePath {get; set;}
public List<Task> Tickets {get; set;}

  private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


  public TaskFile(string inputFilePath){

    filePath = inputFilePath;

    Tickets = new List<Task>();

    //populating file
    try{
        StreamReader sr = new StreamReader(filePath);

        sr.ReadLine();

        while(!sr.EndOfStream)
        {
           Task ticket = new Task();
           string line = sr.ReadLine(); 

           string[] contents = line.Split(','); 
           ticket.UID = UInt64.Parse(contents[0]);
           ticket.desc = contents[1];
           ticket.status = contents[2];
           ticket.priority = Int32.Parse(contents[3]);
           ticket.submitter = contents[4];
           ticket.worker = contents[5];
           ticket.watcher = contents[6];
           ticket.ProjectName = contents[7];
           ticket.date = contents[8];

           Tickets.Add(ticket);

        }

        sr.Close();

    }catch(Exception e){
        logger.Error(e.Message);
    }

  }

  public void submittTicket(Task ticket){
    try{

      if(Tickets.Any()){ ticket.UID = Tickets.Max(t => t.UID) + 1; }else {ticket.UID = 1;}
      
        
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{ticket.UID},{ticket.desc},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.worker},{ticket.watcher},{ticket.ProjectName},{ticket.date}");
        sw.Close();

        Tickets.Add(ticket);

        logger.Info($"Ticket #{ticket.UID} has been submitted");

    }catch(Exception e){
        logger.Error(e.Message);
    }
  }

}