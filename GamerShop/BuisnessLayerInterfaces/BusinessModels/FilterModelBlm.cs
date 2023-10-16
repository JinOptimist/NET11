namespace BusinessLayerInterfaces.BusinessModels
{
    public class FilterModelBlm
    {
        public string PropName { get; set; }
        public string Expretion { get; set; }
        public Dictionary<string,string> ExpretionForDefultValue { get; set; }
        public object DefultValue { get; set; }
        public object CurrentValue { get; set; }
        public string Comparemark { get; set; }
        public string NameForUser { get; set; }
         public Type   Type { get; set; }

    }
}
