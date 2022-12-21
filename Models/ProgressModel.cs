using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class ProgressModel
    {
        public ProgressModel(Progress progress)
        {
            Entities db= new Entities();
            id_progress = progress.id_progress;
            id_job = progress.id_job;
            id_selected = progress.id_selected;
            Jobs jobs = db.Jobs.FirstOrDefault(j => j.id_job== id_job);
            progressJobEvaluation = jobs.job_evaluation;
            progressJobPhoto = jobs.job_photo;
            progressJobDescription = jobs.job_description;
        }
        public int id_progress { get; set; }
        public int id_job { get; set; }
        public int id_selected { get; set; }
        public int progressJobEvaluation { get; set; }
        public string progressJobPhoto { get; set;}
        public string progressJobDescription { get; set;}

    }
}