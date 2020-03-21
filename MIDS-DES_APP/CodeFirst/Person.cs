using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 PersonID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public String Name { get; set; }

        [StringLength(50)]
        public String MiddleName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public String LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false)]
        public DateTime Birthday { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public String Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public String PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(13)]
        public String RFC { get; set; }

        public virtual Employee Employee { get; set; }
    }
}