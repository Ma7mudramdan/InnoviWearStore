using System.Collections.Generic;
using InnoviWearStore.Models;

namespace InnoviWearStore.Helpers
{
    public static class EgyptAddressData
    {
        public static List<EgyptAddress> GetAllGovernorates()
        {
            return new List<EgyptAddress>
            {
                new EgyptAddress
                {
                    Governorate = "Cairo",
                    Cities = new List<string> { "Cairo", "New Cairo", "Heliopolis", "Nasr City", "Maadi", "October 6th City", "Shubra", "Zamalek", "Downtown" },
                    Districts = new List<string> {
                        "First Settlement", "Second Settlement", "Third Settlement", "Fifth Settlement",
                        "El Rehab", "Madinaty", "Sheraton", "Abbassia", "El Nozha", "Helmeyat El Zaitoun"
                    }
                },
                new EgyptAddress
                {
                    Governorate = "Alexandria",
                    Cities = new List<string> { "Alexandria", "Borg El Arab", "Montazah", "Smouha", "Sidi Gaber", "Miami", "Agami" },
                    Districts = new List<string> {
                        "Stanley", "Cleopatra", "Roushdy", "Sporting", "Louran", "Bacchus",
                        "Gleem", "San Stefano", "Miami", "Sidi Bishr", "Mandara"
                    }
                },
                new EgyptAddress
                {
                    Governorate = "Giza",
                    Cities = new List<string> { "Giza", "6th October City", "Sheikh Zayed City", "Mohandessin", "Dokki", "Haram", "Faisal" },
                    Districts = new List<string> {
                        "Beverly Hills", "Sheikh Zayed", "October Gardens", "Hadayek October",
                        "Sodic", "Palm Hills", "Omraniya", "El Mohandessin", "Agouza"
                    }
                },
                new EgyptAddress
                {
                    Governorate = "Port Said",
                    Cities = new List<string> { "Port Said", "Port Fuad", "Al Manasra" },
                    Districts = new List<string> { "Al Zohour", "Al Sharq", "Al Arab", "Al Dawahi" }
                },
                new EgyptAddress
                {
                    Governorate = "Suez",
                    Cities = new List<string> { "Suez", "Al Arbaeen", "Al Ganayen" },
                    Districts = new List<string> { "Port Tawfik", "Al Kabanon", "Al Soor", "Faisal" }
                },
                new EgyptAddress
                {
                    Governorate = "Luxor",
                    Cities = new List<string> { "Luxor", "Karnak", "Al Qarna" },
                    Districts = new List<string> { "East Bank", "West Bank", "Al Qarna Village" }
                },
                new EgyptAddress
                {
                    Governorate = "Aswan",
                    Cities = new List<string> { "Aswan", "Edfu", "Kom Ombo" },
                    Districts = new List<string> { "City Center", "Elephantine Island", "Philae" }
                },
                new EgyptAddress
                {
                    Governorate = "Mansoura",
                    Cities = new List<string> { "Mansoura", "Talkha", "Mit Gamr" },
                    Districts = new List<string> { "El Gomhouria", "El Sekka", "El Sayeda", "Student City" }
                },
                new EgyptAddress
                {
                    Governorate = "Tanta",
                    Cities = new List<string> { "Tanta", "Al Mahalla" },
                    Districts = new List<string> { "Al Nadi", "Al Gamaa", "Al Hay Al Thamin" }
                },
                new EgyptAddress
                {
                    Governorate = "Ismailia",
                    Cities = new List<string> { "Ismailia", "Fayed" },
                    Districts = new List<string> { "Al Salam", "Al Sabah", "Second District" }
                },
                new EgyptAddress
                {
                    Governorate = "Fayoum",
                    Cities = new List<string> { "Fayoum", "Sinnuris" },
                    Districts = new List<string> { "City Center", "Al Fayoum University Area" }
                },
                new EgyptAddress
                {
                    Governorate = "Beni Suef",
                    Cities = new List<string> { "Beni Suef", "Ehnasia" },
                    Districts = new List<string> { "Al Gomhouria", "Al Qism" }
                },
                new EgyptAddress
                {
                    Governorate = "Minya",
                    Cities = new List<string> { "Minya", "Mallawi" },
                    Districts = new List<string> { "City Center", "Al Minya University" }
                },
                new EgyptAddress
                {
                    Governorate = "Assiut",
                    Cities = new List<string> { "Assiut", "Dayrout" },
                    Districts = new List<string> { "City Center", "Al Walideya" }
                },
                new EgyptAddress
                {
                    Governorate = "Sohag",
                    Cities = new List<string> { "Sohag", "Akhmim" },
                    Districts = new List<string> { "City Center", "Eastern District" }
                },
                new EgyptAddress
                {
                    Governorate = "Qena",
                    Cities = new List<string> { "Qena", "Nag Hammadi" },
                    Districts = new List<string> { "City Center", "Al Mahatta" }
                },
                new EgyptAddress
                {
                    Governorate = "Damietta",
                    Cities = new List<string> { "Damietta", "Ras El Bar" },
                    Districts = new List<string> { "City Center", "Al Gomrok" }
                }
            };
        }
    }
}