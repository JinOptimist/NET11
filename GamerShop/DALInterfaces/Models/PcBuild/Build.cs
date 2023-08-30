namespace DALInterfaces.Models.PcBuild;

public class Build : BaseModel
{
    public string Label { get; set; } = null!;
    public DateTime DateOfCreate { get; set; }
    public bool isVirtual { get; set; }
    public string? PhotosPath { get; set; }
    public int Rating { get; set; } = 0;
    public decimal Price { get; set; }
    public bool IsPrivate { get; set; }
    public string? PasswordForViewing { get; set; }
    public int? GpusCount { get; set; }
    public int? SsdCount { get; set; }
    public int? HddCount { get; set; }
    public int? RamCount { get; set; }

    public virtual Processor Processor { get; set; }
    public virtual Motherboard Motherboard { get; set; }
    public virtual Case? Case { get; set; }
    public virtual Cooler Cooler { get; set; }
    public virtual Gpu? Gpu { get; set;  }
    public virtual Ssd? Ssd { get; set; }
    public virtual Hdd? Hdd { get; set; }
    public virtual Psu Psu { get; set; } 
    public virtual Ram Ram { get; set; }
    public virtual User Creator { get; set; }
    public virtual ICollection<User>? UsersWhoLikeIt { get; set; }
}