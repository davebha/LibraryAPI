using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Library.DomainModels
{
    public class LibraryLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Operation { get; set; }

       
        public int? BookId { get; set; }

        [NotNull]
        public DateTime Date { get; set; }
    }
}
