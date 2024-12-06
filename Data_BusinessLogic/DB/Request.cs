using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB
{
    public class Request
    {
        public int Id { get; private set; }

        [Required]
        public DateTime StartDate { get; set; }

        [MaxLength(2048)]
        public string ProblemDescription { get; set; }

        public DateTime? CompletionDate { get; set; }

        [Required]
        public int HomeTechTypeId { get; set; }

        public int? HomeTechModelId { get; set; }

        public int? RepairPartsId { get; set; }

        [Required]
        public int ClientId { get; set; }

        public int? MasterId { get; set; }

        [Required]
        public int StatusId { get; set; }

        // Бизнес-логика
        public bool IsCompleted => CompletionDate.HasValue;
    }
}
