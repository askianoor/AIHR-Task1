﻿using System.ComponentModel.DataAnnotations;
using Task1.Domain.Enums;

namespace Task1.Domain.Dtos;

public class CourseRequestDto
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int Duration { get; set; }

    public CourseType Type { get; set; }
    public CourseLevel Level { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
    public long CategoryId { get; set; }
    public long TutorId { get; set; }
}