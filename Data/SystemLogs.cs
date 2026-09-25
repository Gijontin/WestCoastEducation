namespace WestCoastEducation;

public static class SystemLogs {
    private static List<string> SystemLog = [];

    public static void SysLog(string adminID) {
        string tempStr = $"| {DateTime.Now} | {adminID}: Made X change to Y.";
        SystemLog.Add(tempStr);
    }
}
