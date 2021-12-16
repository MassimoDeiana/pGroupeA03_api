﻿namespace Domain
{
    public class ResultReport
    {
        public int IdStudent { get; set; }
        public int IdInterro { get; set; }
        public double Result { get; set; }
        public int Total { get; set; }

        public string Message { get; set; }

        public int IdLesson { get; set; }
    }
}