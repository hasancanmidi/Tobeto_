﻿namespace Business.DTOs.Course;

public class UpdatedCourseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CourseTypeId { get; set; }
}
