﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Models.Subjects;
public class HumanitySubject:Subject
{
    public HumanitySubject(int subjectId,string subjectName) : base(subjectId,subjectName,1.0)
    {
    }
}