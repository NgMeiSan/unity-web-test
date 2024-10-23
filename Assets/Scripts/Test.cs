using UnityEngine;
using System.Runtime.InteropServices;
using System;
using AOT;

public class Test : MonoBehaviour
{
    #if UNITY_WEBGL
    #region  Variables~

    #region DllImport

    [DllImport("__Internal")]
    public static extern void ImportTelegramlibrary(Action onLoadedCallback);

    [DllImport("__Internal")]
    private static extern void Alert();

    [DllImport("__Internal")]
    private static extern void DebugTest();

    [DllImport("__Internal")]
    private static extern string GetUserId();

    [DllImport("__Internal")]
    private static extern string GetSampleData();

    // [DllImport("__Internal")]
    // public static extern void JsSetTimeout(string message, int timeout, Action<string> action);

    #endregion

    #endregion
    #endif

    void Start()
    {
        #if UNITY_WEBGL
        LoadTelegramLibrary();
        #endif
    }

    #if UNITY_WEBGL

    public static void AlertWeb()
    {
        Alert();
    }

    public static void PrintTelegram()
    {
        DebugTest();
    }

    public static void PrintUserId()
    {
        Debug.Log(GetUserId());
    }

    public static void LoadTelegramLibrary()
    {
        [MonoPInvokeCallback(typeof(Action))]
        static void OnTelegramLibraryLoaded()
        {
            Debug.Log("CALLBACK FROM UNITY");
        }

        ImportTelegramlibrary(OnTelegramLibraryLoaded);
    }

    [MonoPInvokeCallback(typeof(Action<string>))]
    public static void CSSharpCallback(string message)
    {
        Debug.Log($"C# callback received \"{message}\"");
    }

    public static void PrintSampleData()
    {
        // Call the JavaScript function and get the JSON string
        string sampleDataJson = GetSampleData();

        // Parse the JSON string (using UnityEngine.JsonUtility or any other JSON parser)
        SampleData userData = JsonUtility.FromJson<SampleData>(sampleDataJson);

        // Now you can use the userData object in Unity
        Debug.Log("User ID: " + userData.id);
        Debug.Log("Username: " + userData.username);
        Debug.Log("Is Bot: " + userData.is_bot);
    }

    #endif
    
    public void PrintMessage(string message)
    {
        Debug.Log(message);
    }
}

#if UNITY_WEBGL
// Define a class to match the JSON structure
[System.Serializable]
public class SampleData
{
    public int id;
    public string username;
    public bool is_bot;
}
#endif