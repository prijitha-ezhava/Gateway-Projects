using System;
using System.Collections.Generic;

namespace Assignment8
{
    public class Program
    {

        public class UserInfo
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }

        public List<UserInfo> GetUserInfo()
        {
            return new List<UserInfo>
            {
                new UserInfo{Name = "Prijitha Ezhava",Age=23, Address="Ahmedabad"},
                new UserInfo{Name = "Prijith Ezhava", Age = 28, Address="Bahrain"},
                new UserInfo{Name = "Nidhi Fulpagar", Age = 19, Address="Nagpur"},
                new UserInfo{Name = "Raghav Singh", Age = 41, Address="Gorakhpur"},
                new UserInfo{Name = "Khushbu Sengar", Age = 22, Address="Ahmedabad"},
            };
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
