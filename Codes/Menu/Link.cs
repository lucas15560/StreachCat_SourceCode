using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void LucasItchioPage()
	{
		Application.OpenURL("https://lucas1550.itch.io/");
	}

    public void JoshuuuItchioPage()
    {
        Application.OpenURL("https://joshuuu.itch.io/short-loopable-background-music");
    }

    [DllImport("__Internal")]
	private static extern void openWindow(string url);

}