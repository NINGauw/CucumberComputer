using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;

public class ImportantData : MonoBehaviour
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    public static void ChangeDesktopWallpaper(string imagePath)
    {
        int result = SystemParametersInfo(0x0014, 0, imagePath, 0x0001);
        if (result != 0)
        {
            Debug.Log("Desktop wallpaper changed successfully.");
        }
        else
        {
            Debug.LogError("Failed to change desktop wallpaper.");
        }
    }

    // Gọi phương thức này từ đâu đó trong game của bạn khi người chơi thực hiện hành động cần đổi hình nền.
    public static void OnChangeWallpaperButtonClicked()
    {
        string imagePath = Path.Combine(Application.streamingAssetsPath, "Images/important-data.jpg"); // Đường dẫn đến hình ảnh mới của bạn
        ChangeDesktopWallpaper(imagePath);
    }
}