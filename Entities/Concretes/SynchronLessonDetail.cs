﻿using Core.Entities;

namespace Entities.Concretes
{
    public class SynchronLessonDetail : Entity<Guid>
    {
        public int Name { get; set; }
        public Guid CourseId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SynchronLessonId { get; set; }
        public Guid LessonLanguageId { get; set; }
        public Guid SubTypeId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Category Category { get; set; }
        public virtual AsyncLesson AsyncLesson { get; set; }
        public virtual LessonLanguage LessonLanguage { get; set; } 
        public virtual SubType SubType { get; set; }
    }
}

