namespace DALInterfaces.Models.PcBuild;

public class Build : BaseModel
{
    public string Label { get; set; } = null!;
    public DateTime DateOfCreate { get; set; }
    public bool isVirtual { get; set; }
    public string? PhotosPath { get; set; }
    public int Rating { get; set; } = 0;
    public decimal Price { get; set; }

    public virtual Processor Processor { get; set; }
    public virtual Motherboard Motherboard { get; set; }
    public virtual Case Case { get; set; }
    public virtual Cooler Cooler { get; set; }
    public virtual ICollection<Gpu>? Gpus { get; set;  }
    public virtual ICollection<Ssd>? Ssds { get; set; }
    public virtual ICollection<Hdd>? Hdds { get; set; }
    public virtual Psu Psus { get; set; } 
    public virtual ICollection<Ram> Rams { get; set; }
    public virtual User Creator { get; set; }
    public virtual ICollection<User>? UsersWhoLikeIt { get; set; }
}