using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace management_mvc.Models
{
    public partial class Projectdetail
    {
        public int ProjectId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Startdate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Enddate { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public decimal? UiTasksPercent { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? UiStartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? UiEndDate { get; set; }
        [Required]
        public decimal? ApiTasksPercent { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ApiStartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ApiEndDate { get; set; }
        [Required]
        public decimal? DbTasksPercent { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DbStartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DbEndDate { get; set; }
        [Required]
        public decimal? TestingTasksPercent { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? TestingStartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? TestingEndDate { get; set; }
    }
}
