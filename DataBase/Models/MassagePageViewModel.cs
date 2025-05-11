using System.Collections.Generic;
using DataBase;
using DataBase.Models;

namespace DataBase.ViewModels
{
    public class MassagePageViewModel
    {
        public List<Massager> Massagers { get; set; }
        public List<Massage> Massages { get; set; }
        public BookingViewModel Booking { get; set; }
    }
}
