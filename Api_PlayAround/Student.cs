using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api_PlayAround
{
    internal class Student
    {
        public string login { get; set; } = "None";

        public string avatar_url { get; set; } = "None";

        public string email { get; set; } = "None";

        public string bio { get; set; } = "None";

        public Student () {}
    }
}
