using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBase.ViewModels
{
    public class BookingViewModel
    {
        public string UserName { get; set; }       // Имя клиента
        public string Phone { get; set; }          // Телефон
        public int MassageId { get; set; }         // Выбранный массаж
        public int MassagerId { get; set; }        // Выбранный массажист
        public string Gender { get; set; }         // Пол массажиста
        public string City { get; set; }           // Город
        public string Address { get; set; }        // Адрес салона
        public DateTime Date { get; set; }         // Дата сеанса
    }   
}