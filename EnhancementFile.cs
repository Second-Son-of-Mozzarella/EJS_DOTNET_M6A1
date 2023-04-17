using NLog;

public class EnhancementFile
{
public string filePath {get; set;}
public List<Enhancement> Tickets {get; set;}

  private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


  public EnhancementFile(string inputFilePath){

    filePath = inputFilePath;

    Tickets = new List<Enhancement>();

    //populating file
    try{
        StreamReader sr = new StreamReader(filePath);

        sr.ReadLine();

        while(!sr.EndOfStream)
        {
           Enhancement ticket = new Enhancement();
           string line = sr.ReadLine(); 

           string[] contents = line.Split(','); 
           ticket.UID = UInt64.Parse(contents[0]);
           ticket.desc = contents[1];
           ticket.status = contents[2];
           ticket.priority = Int32.Parse(contents[3]);
           ticket.submitter = contents[4];
           ticket.worker = contents[5];
           ticket.watcher = contents[6];
           ticket.software = contents[7];
           ticket.reason = contents[8];
           ticket.Estimate = float.Parse(contents[9]);
           ticket.cost = float.Parse(contents[10]);

           Tickets.Add(ticket);

        }

        sr.Close();

    }catch(Exception e){
        logger.Error(e.Message);
    }

  }

  public void submittTicket(Enhancement ticket){
    try{

      if(Tickets.Any()){ ticket.UID = Tickets.Max(t => t.UID) + 1; }else {ticket.UID = 1;}
      
        
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{ticket.UID},{ticket.desc},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.worker},{ticket.watcher},{ticket.software},{ticket.reason},{ticket.Estimate},{ticket.cost}");
        sw.Close();

        Tickets.Add(ticket);

        logger.Info($"Ticket #{ticket.UID} has been submitted");

    }catch(Exception e){
        logger.Error(e.Message);
    }
  }

}