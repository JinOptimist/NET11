﻿namespace DALInterfaces.Models
{
    public class FootballClub : BaseModel
    {
        public string Name { get; set; }
        public string Stadium { get; set; }
        public string Country { get; set; }
        public User Creator { get; set; }

    }
}
