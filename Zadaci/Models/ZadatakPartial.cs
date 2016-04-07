using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Resources;

namespace Zadaci.Models
{
    [MetadataType(typeof(ZadatakMetaData))]
    public partial class Zadatak
    {
    }

    public class ZadatakMetaData
    {

        //public int Id { get; set; }
        //public System.DateTime Start { get; set; }
        //public string Naslov { get; set; }
       // public string Opis { get; set; }
        //public bool Status { get; set; }
        //public Nullable<System.DateTime> Kraj { get; set; }

        [Display(Name = "Opis")]
        [StringLength(300, ErrorMessageResourceType=(typeof(Resource)), ErrorMessageResourceName="OpisLengthErrorMessage")] // ErrorMessage = "Opis must be 20 characters or less in length.")]        
        public string Opis { get; set; }               

    }
}