using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Serilog;
using Microsoft.Extensions.Logging;
namespace MyWebApp.Models{

     [Table("MarkDetails")]
    public class SubjectMark
    {
        public int Id { get; set; }

        public string Subject { get; set; } = "";

        public int Mark { get; set; }
    }

    

}

