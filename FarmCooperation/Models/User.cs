using Microsoft.AspNetCore.Identity;

namespace FarmCooperation.Models;

public class User : IdentityUser
{
    public string DeliveryAddress { get; set; }
}