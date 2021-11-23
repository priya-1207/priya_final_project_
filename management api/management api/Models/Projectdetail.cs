using System;
using System.Collections.Generic;

#nullable disable

namespace management_api.Models
{
    public partial class Projectdetail
    {
        public int ProjectId { get; set; }
        public string Username { get; set; }
        public string ProjectName { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Duration { get; set; }
        public decimal? UiTasksPercent { get; set; }
        public DateTime? UiStartDate { get; set; }
        public DateTime? UiEndDate { get; set; }
        public decimal? ApiTasksPercent { get; set; }
        public DateTime? ApiStartDate { get; set; }
        public DateTime? ApiEndDate { get; set; }
        public decimal? DbTasksPercent { get; set; }
        public DateTime? DbStartDate { get; set; }
        public DateTime? DbEndDate { get; set; }
        public decimal? TestingTasksPercent { get; set; }
        public DateTime? TestingStartDate { get; set; }
        public DateTime? TestingEndDate { get; set; }
    }
}
