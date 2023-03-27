public abstract class Ticket
{

    public UInt64 UID {get; set;}
    public string desc {get; set;}
    public string status {get; set;}
    public string submitter {get; set;}
    public string worker {get; set;}
    public string watcher {get; set;}
    public int priority {get; set;}





}

public class Defect : Ticket
{
    public string Display()
        {
            return $"\n \t\t UID: {UID} \n\t Submitted by {submitter}\n\tDescription - \n {desc} \n\tPriority: {priority} \n\t Assigned Worker: {worker} \n\t Assigned Supervisor: {watcher}";
        }
}

public class Enhancement : Ticket
{
    public string software {get; set;}
    public float cost {get; set;}
    public string reason {get; set;}
    public float Estimate {get; set;}

    public string Display()
        {
            return $"\n \t\tUID: {UID} \n\tSubmitted by {submitter}\n\t Software - {software} \n\tDescription - \n {desc} \n\t Reason for Submission - {reason} \n\tCost Estimate - {cost} \n\tTime Estaimate - {Estimate}\n\tPriority: {priority} \n\tAssigned Worker: {worker} \n\tAssigned Supervisor: {watcher}";
        }

}

public class Task : Ticket
{
    public string ProjectName {get; set;}
    public string date {get; set;}

    public string Display()
        {
            return $"\n \t\t UID: {UID} \n\t Submitted by {submitter}\n\tProject Name - {ProjectName} \n\t End Date - {date} \n\tDescription - \n\t\t {desc} \n\tPriority: {priority} \n\t Assigned Worker: {worker} \n\t Assigned Supervisor: {watcher}";
        }
}