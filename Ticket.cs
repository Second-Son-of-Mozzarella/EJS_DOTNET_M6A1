public class Ticket
{

    public UInt64 UID {get; set;}
    public string desc {get; set;}
    public string status {get; set;}
    public string submitter {get; set;}
    public string worker {get; set;}
    public string watcher {get; set;}
    public int priority {get; set;}


    public string Display()
        {
            return $"\n \t\t UID: {UID} \n\t Submitted by {submitter}\n\tDescription - \n {desc} \n\tPriority: {priority} \n\t Assigned Worker: {worker} \n\t Assigned Supervisor: {watcher}";
        }


}