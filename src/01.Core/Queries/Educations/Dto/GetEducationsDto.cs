﻿namespace Queries.Educations.Dto;

public class GetEducationsDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string StartDate { get; set; }
    public required string EndDate { get; set; }
    public required string Description { get; set; }
    public required int Order { get; set; } = 0;
}