using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class HobbyModel
    {
        public HobbyModel(Hobby hobby)
        {
            hobby_id = hobby.hobby_id;
            hobby1 = hobby.hobby1;
            short_description = hobby.short_description;
            photo = hobby.photo;
            information_link = hobby.information_link;
            age_limit = hobby.age_limit;
        }
        public int hobby_id { get; set; }
        public string hobby1 { get; set; }
        public string short_description { get; set; }
        public string photo { get; set; }
        public string information_link { get; set; }
        public int age_limit { get; set; }
    }
}