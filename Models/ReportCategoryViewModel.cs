using Microsoft.AspNetCore.Mvc.Rendering;
using ReportWebApi.Models;

// Purpose - support the list of reports with the following filtering:
//   all reports or the logged in user reports only
//   All categories or from a particular category
//   


namespace ReportWebApi.Controllers
{
    internal class ReportCategoryViewModel
    {
        public SelectList Categories { get; set; }
        public List<ReportItem> Reports { get; set; }

        public string? CreationEmail { get; set; }
        public string? CategoryList { get; set; }
    }
}