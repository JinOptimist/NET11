using System.ComponentModel.DataAnnotations.Schema;

namespace DALInterfaces.Models.PcBuild;

public class Cooler
{
    public string Model { get; set; } = null!;
    public string? Socket { get; set; }
    public int? DissipatedPower { get; set; }
    public int? Height { get; set; }
    [NotMapped]
    public string[] SocketsData
    {
        get
        {
            if (Socket != null) return Socket.Split(';');
            return null;
        }
        set
        {
            var _data = value;
            Socket = String.Join(";", _data.ToArray());
        }
    }
}