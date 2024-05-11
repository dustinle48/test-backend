using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using TestBackend.Domain.Contracts.Bases;

namespace TestBackend.Domain.Entities;

public enum PriceEnum
{
    Low,
    Medium,
    High
}

public enum TypeEnum
{
    Lac,
    DayChuyen,
    Nhan,
    BongTai,
    VongTay,
}

public enum GenderEnum
{
    Male,
    Female,
    Unisex,
}

public enum GoldTypeEnum
{
    Vang18K,
    Vang24K,
}

public class Product : IEntity<int>
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Index(IsUnique = true)]
    public string Pku { get; set; }

    public string Partner { get; set; } = "TKT";

    [Required]
    public PriceEnum Price { get; set; }

    public string Promotion { get; set; } = "N/A";
    public int Sale { get; set; } = 0;

    [Required]
    public TypeEnum Type { get; set; }

    public GenderEnum Gender { get; set; }
    public float Weight { get; set; }
    public GoldTypeEnum GoldType { get; set; }
    public int? Size { get; set; }

    [Required]
    public string Description { get; set; }

    public JObject Image { get; set; }
}