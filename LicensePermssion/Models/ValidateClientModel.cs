using System.ComponentModel.DataAnnotations;

namespace LicensePermssion.Models;

public class ValidateClientModel
{
   
    public string?AppSerial { get; set; }
    public string?SystemSerial { get; set; }
}