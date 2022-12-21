using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class JobsModel
    {
        public JobsModel(Jobs jobs)
        {
            id_job = jobs.id_job;
            job_photo = jobs.job_photo;
            job_description = jobs.job_description;
            job_evaluation = jobs.job_evaluation;
        }
        public int id_job { get; set; }
        public string job_photo { get; set; }
        public string job_description { get; set; }
        public int job_evaluation { get; set; }
    }
}