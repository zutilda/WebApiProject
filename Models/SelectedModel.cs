using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class SelectedModel
    {
        private Entities db = new Entities();

        public SelectedModel(Selected selected)
        {
            id_selected = selected.id_selected;
            id_users = selected.id_users;
            personal_assessment = selected.personal_assessment;
            id_hobby = selected.id_hobby;
            Hobby hob = db.Hobby.FirstOrDefault(x => x.hobby_id == selected.id_hobby);
            nameSlected = hob.hobby1;
            PhotoSlected = hob.photo;
        }
        public int id_hobby { get; set; }
        public string nameSlected { get; set; }
        public string PhotoSlected { get; set; }
        public int id_selected { get; set; }
        public int id_users { get; set; }
        public int personal_assessment { get; set; }
    }
}