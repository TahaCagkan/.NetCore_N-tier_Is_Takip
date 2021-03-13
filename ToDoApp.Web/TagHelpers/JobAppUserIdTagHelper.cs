using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Business.Abstract;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Web.TagHelpers
{
    [HtmlTargetElement("getJobAppUserId")]
    public class JobAppUserIdTagHelper : TagHelper
    {
        private readonly IJobService _jobService;
        public JobAppUserIdTagHelper(IJobService jobService)
        {
            _jobService = jobService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Job> jobs = _jobService.GetAppUserId(AppUserId);
            int jobEndedCount = jobs.Where(x => x.Status).Count();
            int jobContinueCount = jobs.Where(x => !x.Status).Count();

            string htmlString = $"<strong>Tamamladığı görev sayısı :</strong>{jobEndedCount}<br> <strong>Üsütnde çalıştığı görev sayısı :</strong>{jobContinueCount}";

            output.Content.SetHtmlContent(htmlString);
        }
    }
}
