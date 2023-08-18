using System.ComponentModel.DataAnnotations.Schema;

namespace DALInterfaces.Models.PcBuild;

public class Build : BaseModel
{
    public string Label { get; set; }
    public int ProcessorId { get; set; }
    public string GPUIds { get; set; }
    public int MotherboardId { get; set; }
    public string SSDIds { get; set; }
    public string HDDIds { get; set; }
    public int PSUId { get; set; }
    public string RAMIds { get; set; }
    public int ProcessorCullerId { get; set; }
    public int CaseId { get; set; }
    public DateOnly DateOfCreate { get; set; }
    public bool isVirtual { get; set; }
    public string PhotosPath { get; set; }
    public int UserId { get; set; }
    public string LikedUsersIds { get; set; }
    public int Rating { get; set; }

    [NotMapped]
    public int[] SSDIdsData
    {
        get
        {
            return Array.ConvertAll(SSDIds.Split(';'), Int32.Parse);
        }
        set
        {
            var _data = value;
            SSDIds = String.Join(";", _data.Select(p => p.ToString()).ToArray());
        }
    }
    [NotMapped]
    public int[] HDDIdsData
    {
        get
        {
            return Array.ConvertAll(HDDIds.Split(';'), Int32.Parse);
        }
        set
        {
            var _data = value;
            HDDIds = String.Join(";", _data.Select(p => p.ToString()).ToArray());
        }
    }
    [NotMapped]
    public int[] RAMIdsData
    {
        get
        {
            return Array.ConvertAll(RAMIds.Split(';'), Int32.Parse);
        }
        set
        {
            var _data = value;
            SSDIds = String.Join(";", _data.Select(p => p.ToString()).ToArray());
        }
    }
    [NotMapped]
    public int[] GPUIdsData
    {
        get
        {
            return Array.ConvertAll(GPUIds.Split(';'), Int32.Parse);
        }
        set
        {
            var _data = value;
            SSDIds = String.Join(";", _data.Select(p => p.ToString()).ToArray());
        }
    }
    [NotMapped]
    public string[] PhotosPathData
    {
        get
        {
            return GPUIds.Split(';');
        }
        set
        {
            var _data = value;
            SSDIds = String.Join(";", _data.ToArray());
        }
    }
    [NotMapped]
    public int[] LikedUsersIdsData
    {
        get
        {
            return Array.ConvertAll(LikedUsersIds.Split(';'), Int32.Parse);
        }
        set
        {
            var _data = value;
            SSDIds = String.Join(";", _data.Select(p => p.ToString()).ToArray());
        }
    }
}