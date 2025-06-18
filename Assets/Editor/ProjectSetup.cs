#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;

public class ProjectSetup : EditorWindow
{
    private string studentNumber = "225040071";
    private static bool hasShown = false;
    
    [InitializeOnLoadMethod]
    static void AutoShow()
    {
        // Only show if student hasn't registered yet
        if (!File.Exists(Application.dataPath + "/student_info.txt"))
        {
            EditorApplication.delayCall += () => GetWindow<ProjectSetup>("Project Setup", true);
        }
    }
    
    void OnGUI()
    {
        GUILayout.Label("Enter your student number:");
        studentNumber = EditorGUILayout.TextField("Student Number", studentNumber);
        
        if (GUILayout.Button("OK"))
        {
            if (!string.IsNullOrEmpty(studentNumber))
            {
                // Save student number
                File.WriteAllText(Application.dataPath + "/student_info.txt", studentNumber);
                
                // Save hidden signature
                string signature = studentNumber + SystemInfo.deviceUniqueIdentifier;
                File.WriteAllText(Application.dataPath + "/../.signature", signature);
                
                Close();
            }
        }
    }
}
#endif