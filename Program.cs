using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using tut_2.Models;

namespace tut_2
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputPath  = args.Length > 0 ? args[0] : @"Files\data.csv";
            var outputPath = args.Length > 1 ? args[1] : @"Files\result";
            var outputType = args.Length > 2 ? args[2] : "xml";


            var student_list = new List<Student>();
            bool second_time = false;

            foreach(var line in File.ReadAllLines(inputPath))
            {

                // Get info about student
                var stud_info = line.Split(",");

                // Check if student is already in list
                foreach (var old_student in student_list)
                {
                    if (old_student.fname == stud_info[0] &&
                        old_student.lname == stud_info[1])
                    {
                        // If student is already in list
                        // ad him new sutudies
                        old_student.studies.Add(
                            new Studies
                            {
                                name = stud_info[2],
                                mode = stud_info[3]
                            }
                            );
                        second_time = true;
                        continue;
                    }
                }

                // If there is no student with this name then create one
                if (!second_time)
                {

                    student_list.Add(
                        new Student
                        {
                            fname = stud_info[0],
                            lname = stud_info[1],
                            studies = new List<Studies>() { new Studies {
                                                                name = stud_info[2],
                                                                mode = stud_info[3]
                                                          } },
                            snumber = stud_info[4],
                            birthdate = stud_info[5],
                            email = stud_info[6],
                            mothersName = stud_info[7],
                            fathersName = stud_info[8]
                        }
                        );

                    
                }
                second_time = false;


            }


            var active_studies = new List<ActiveStudies>();
            var temp = false;

            foreach (var student in student_list)
            {
                foreach (var study in student.studies)
                {
                    foreach (var ac_st in active_studies)
                    {
                        if (study.name == ac_st.name)
                        {
                            ac_st.numberOfStudents = ac_st.numberOfStudents + 1;
                            temp = true;
                        }
                    }

                    if (!temp)
                    {
                        active_studies.Add(new ActiveStudies { 
                                                    name = study.name,
                                                    numberOfStudents = 1
                                                    });
                    }
                    temp = false;
                    
                }

            }


            var mine = new Univeristy
            {
                author = "Michal Kowalczyk",
                createdAt = "22-03-2020",
                students = student_list,
                activeStudies = active_studies
            };


            if (outputType == "xml")
            {
                //xml
                using var writer = new FileStream($"{outputPath}.{outputType}", FileMode.Create);
                var serializer = new XmlSerializer(typeof(Univeristy));
                serializer.Serialize(writer, mine);
            }

            if (outputType == "json")
            {
                //json
                var json_string = JsonSerializer.Serialize(mine);
                File.WriteAllText($"{outputPath}.json", json_string);
            }
            Console.WriteLine("Finish");



        }
    }
}
