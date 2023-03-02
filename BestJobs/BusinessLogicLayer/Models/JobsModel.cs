﻿using System;

namespace BusinessLogicLayer.Models
{
    public class JobsModel
    {
        public int JobsId { get; set; }
        public int HRId { get; set; }
        public string JobsName { get; set; }
        public string JobsSkill { get; set; }
        public int JobsPackage { get; set; }
        public DateTime JobsPostDate { get; set; }
        public string JobsDescription { get; set; }
        public string UserName { get; set; }
    }
}
