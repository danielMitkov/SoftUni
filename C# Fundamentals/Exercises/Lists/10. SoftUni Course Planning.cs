using System.Collections.Generic;
using System.Linq;
using System;
public class Program
{
    public static void Main()
    {
        List<string> courses = Console.ReadLine().Split(", ").ToList();
        string input = string.Empty;
        while((input = Console.ReadLine()) != "course start")
        {
            string[] command = input.Split(":");
            string lessonTitle = command[1];
            switch(command[0])
            {
                case "Add":
                    if(!courses.Contains(lessonTitle))
                    {
                        courses.Add(lessonTitle);
                    }
                    break;
                case "Insert":
                    int index = int.Parse(command[2]);
                    if(index < 0 || index >= courses.Count)
                    {
                        break;
                    }
                    else if(!courses.Contains(lessonTitle))
                    {
                        courses.Insert(index,lessonTitle);
                    }
                    break;
                case "Remove":
                    if(courses.Contains(lessonTitle))
                    {
                        courses.Remove(lessonTitle);
                    }
                    else if(courses.Contains(lessonTitle + "-Exercise"))
                    {
                        courses.Remove(lessonTitle + "-Exercise");
                    }
                    break;
                case "Swap":
                    string lessonTitle2 = command[2];
                    int index1 = courses.IndexOf(lessonTitle);
                    int index2 = courses.IndexOf(lessonTitle2);
                    if(courses.Contains(lessonTitle) && courses.Contains(lessonTitle2))
                    {
                        (courses[index1], courses[index2]) = (courses[index2], courses[index1]);
                    }
                    if(courses.Contains(lessonTitle + "-Exercise") && courses.Contains(courses[index1]))
                    {
                        index1 = courses.IndexOf(lessonTitle);
                        courses.Remove(lessonTitle + "-Exercise");
                        courses.Insert(index1 + 1,lessonTitle + "-Exercise");
                    }
                    else if(courses.Contains(lessonTitle2 + "-Exercise") && courses.Contains(courses[index2]))
                    {
                        index2 = courses.IndexOf(lessonTitle2);
                        courses.Remove(lessonTitle2 + "-Exercise");
                        courses.Insert(index2 + 1,lessonTitle2 + "-Exercise");
                    }
                    break;
                case "Exercise":
                    if(courses.Contains(lessonTitle) && !courses.Contains(lessonTitle + "-Exercise"))
                    {
                        int i = courses.IndexOf(lessonTitle);
                        courses.Insert(i + 1,lessonTitle + "-Exercise");
                    }
                    else if(!courses.Contains(lessonTitle))
                    {
                        courses.Add(lessonTitle);
                        courses.Add(lessonTitle + "-Exercise");
                    }
                    break;
            }
        }
        for(int i = 0;i < courses.Count;i++)
        {
            Console.WriteLine($"{i + 1}.{courses[i]}");
        }
    }
}