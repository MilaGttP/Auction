﻿namespace Auction.Models
{
    public class Auction
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int StartPrice { get; set; }
        public User CreationUser { get; set; }
        public List<Bet> BetsList { get; set; }
    }
}