using System.ComponentModel.DataAnnotations;

namespace LicensePermssion.Models;

public class VerificationModel
{
    [Required(ErrorMessage = "code is required")]
    public string? Code { get; set; }
}