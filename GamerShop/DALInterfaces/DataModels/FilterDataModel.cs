namespace DALInterfaces.DataModels
{
    public class FilterDataModel
    {
        public string PropName { get; set; }
        public string Expretion { get; set; }
        public Dictionary<string, string> ExpretionForDefultValue { get; set; }
        public object DefultValue { get; set; }
        public  string CurrentValue { get; set; }
        public string NameForUser { get; set; }
        public string CompareMark { get; set; }
        public Type   Type { get; set; }
    }
}
