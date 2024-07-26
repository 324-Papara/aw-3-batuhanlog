namespace Para.Base.Schema;

public abstract class BaseRequest
{
    public string InsertUser { get; set; }
    public DateTime InsertDate { get; set; }
    public bool IsActive { get; set; }
}