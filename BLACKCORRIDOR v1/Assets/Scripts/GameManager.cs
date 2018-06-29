using UnityEngine;

public static class GameManager {

   	public static string subtitle = "";

    public static string message = "";

    public static string help="";

    public static string lookingAtName = "";
        
    public static float subtitleTime = 0;

    public static float executedTime = 0;

    public static bool puzzled = false;

    public static bool ComputerAChecked = false;
    public static bool ComputerBChecked = false;
    public static bool MainConsoleChecked = false;

    public static int Step = 1;//todo meterle los pasos a todo

    public static GameObject LookingAt;

    public static Vector3 ryan;

}
