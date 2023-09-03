namespace DALInterfaces.DataModels.Football
{
    public class ShortFootballLeagueDataModel
    {
       public int Id { get; set; }
       public string ShortName { get; set; }
       public string Country { get; set; }
       public UserDataModel Creator { get; set; }
       public string FullName { get; set; } 
    }
}
