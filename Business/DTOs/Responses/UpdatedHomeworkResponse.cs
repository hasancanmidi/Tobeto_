﻿namespace Business.DTOs.Responses
{
    public class UpdatedHomeworkResponse
    {
        public bool HomeWorkIsSend { get; set; }
        public string InstructorDescription { get; set; }
        public string StudentDescription { get; set; }
        public DateTime LastDate { get; set; }
        public string HomeworkTaskFile { get; set; }

    }

}