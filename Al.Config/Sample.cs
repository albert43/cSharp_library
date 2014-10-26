using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Al.Config
{
    /// <summary>
    /// Config Sample class.
    /// </summary>
    public class Sample
    {
        public void setSample()
        {
            ObjectStudent st = null;
            InitialData(ref st);
            Al.Config.ConfigJson cfg = new ConfigJson("student.conf");
            cfg.setConfig<ObjectStudent>(st);
        }

        public void getSample()
        {
            Al.Config.ConfigJson cfg = new ConfigJson("student.conf");
            ObjectStudent st = cfg.getConfig<ObjectStudent>();
        }

        enum Grade
        {
            FRESHMAN,
            SOPHOMORE,
            JUNIRO,
            SENIRO
        }

        class ObjectStudent
        {
            public String name { set; get; }
            public Grade grade { set; get; }
            public ObjectClass[] classes { set; get; }
        }

        class ObjectTeacher
        {
            public String name { set; get; }
            public bool sex { set; get; }
            public int age { set; get; }
        }

        class ObjectClassTime
        {
            public System.DateTime Start { set; get; }
            public System.DateTime End { set; get; }
        }

        class ObjectClass
        {
            public String name { set; get; }
            public List<ObjectClassTime> Time;
            public ObjectTeacher teacher { set; get; }
        }

        private void InitialData(ref ObjectStudent Student)
        {
            //  Teacher
            ObjectTeacher[] Teacher = new ObjectTeacher[2];
            Teacher[0] = new ObjectTeacher();
            Teacher[0].name = "Ally";
            Teacher[0].sex = false;
            Teacher[0].age = 27;
            Teacher[1] = new ObjectTeacher();
            Teacher[1].name = "Albert";
            Teacher[1].sex = true;
            Teacher[1].age = 33;

            //  Time
            ObjectClassTime[] ClassTime = new ObjectClassTime[2];
            ClassTime[0] = new ObjectClassTime();
            ClassTime[0].Start = new DateTime(2014, 9, 15);
            ClassTime[0].End = new DateTime(2014, 12, 15);
            ClassTime[1] = new ObjectClassTime();
            ClassTime[1].Start = new DateTime(2014, 6, 17);
            ClassTime[1].End = new DateTime(2014, 9, 10);

            //  Class
            ObjectClass[] Classes = new ObjectClass[2];
            Classes[0] = new ObjectClass();
            Classes[0].name = "English";
            Classes[0].teacher = Teacher[1];
            Classes[0].Time = new List<ObjectClassTime>();
            Classes[0].Time.Add(ClassTime[0]);
            Classes[1] = new ObjectClass();
            Classes[1].name = "Chinese";
            Classes[1].teacher = Teacher[0];
            Classes[1].Time = new List<ObjectClassTime>();
            Classes[1].Time.Add(ClassTime[0]);
            Classes[1].Time.Add(ClassTime[1]);

            //  Student
            Student = new ObjectStudent();
            Student.name = "Siri";
            Student.grade = Grade.SENIRO;
            Student.classes = Classes;
        }
    }

    
}
