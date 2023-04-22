using System;
namespace Date_Modifier;
public static class DateModifier {
    public static int GetDiff(string start,string end) {
        DateTime startDate = DateTime.Parse(start);
        DateTime endDate = DateTime.Parse(end);
        TimeSpan diff = endDate - startDate;
        return Math.Abs(diff.Days);
    }
}