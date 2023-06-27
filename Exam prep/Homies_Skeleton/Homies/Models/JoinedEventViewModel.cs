﻿namespace Homies.Models
{
    public class JoinedEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Start { get; set; }

        public string Type { get; set; } = null!;

        public string Organiser { get; set; } = null!;
    }
}