using UnityEngine;

public class Test : MonoBehaviour
{
    public void PrintMessage(string message)
    {
        Debug.Log(message);
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}