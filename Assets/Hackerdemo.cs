using System.Diagnostics;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private int level = 0;
    private string password;
    private string scramblePassword;
    private string[] level1Passwords = {"joke", "book", "dark", "funny", "cat", "hide"};
    private string[] level2Passwords = {"study", "hacker", "dance", "pocket", "mouse","teddy"};
    private string[] level3Passwords = {"language", "translate", "difficult", "stupid", "scramble", "forget"};
    private string[] level4Passwords = {"community", "cucumber", "building", "dispenser", "accurate", "package"};
    Screen currentScreen;
    enum Screen {MainMenu, Password, Success};
    // Start is called before the first frame update
    void Start()
    {
        currentScreen = Screen.MainMenu;
        ShowMenu();
    }
    void ShowMenu(){
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to\nHack Cucumber's Computer");
        Terminal.WriteLine("You need to find 4 password to access\nto Cucumber's Computer");
        Terminal.WriteLine("You can guess from the hint");
        Terminal.WriteLine("Passwords will be the words scrambled\nin the hint.");
        Terminal.WriteLine("Enter 'start' to begin");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMenu();
        }
        else if (currentScreen == Screen.MainMenu){
            HandleInputMainMenu(input);
            }
        else if (currentScreen == Screen.Password){
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Success){
            if(input == "menu"){
                Invoke("ShowMenu", 3f);
                Terminal.ClearScreen();
                Terminal.WriteLine("Loading...");
            }
            else if(input == "exit"){
                Application.Quit();
            }
            else Hack(input);
        }
        
    }
    private void HandleInputMainMenu(string input)
    {
        bool isValid = (input == "start");
            if (isValid)
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Loading...");
                LoadingScreen();
                Invoke("StartGame", 2f);
            }
            else Terminal.WriteLine("Wrong input, enter again: ");
        }

    private void StartGame()
    {   
        level += 1;
         if(level >= 5){
                Terminal.ClearScreen();
                Terminal.WriteLine("Accessing the cucumber computer.");
                Terminal.WriteLine("Loading...");
                Invoke("LoadWinSceen", 2f);
            }
        else{
            int randomWord = Random.Range(0, 6);
            Terminal.ClearScreen();
            currentScreen = Screen.Password;
            switch(level){
                case 1: 
                Terminal.WriteLine("Security level 1");
                password = level1Passwords[randomWord];
                scramblePassword = password.Anagram();
                Invoke("EnterPassword", 1.5f);
                break;
                case 2: 
                Terminal.WriteLine("Security level 2");
                password = level2Passwords[randomWord];
                scramblePassword = password.Anagram();
                Invoke("EnterPassword", 1.5f);
                break;
                case 3: 
                Terminal.WriteLine("Security level 3");
                password = level3Passwords[randomWord];
                scramblePassword = password.Anagram();
                Invoke("EnterPassword", 1.5f);
                break;
                case 4: 
                Terminal.WriteLine("Security level 4");
                password = level4Passwords[randomWord];
                scramblePassword = password.Anagram();
                Invoke("EnterPassword", 1.5f);
                break;
                default: 
                UnityEngine.Debug.LogError("Invalid level number");
                break;
        } 
        }
       
    }
    private void EnterPassword(){
        Terminal.WriteLine("Enter password");
        Terminal.WriteLine("Hint: " + scramblePassword);
        Terminal.WriteLine("Password is: ");
    }
    private void CheckPassword(string input){
        if(input == password){
            Invoke("StartGame", 2f);
            Terminal.ClearScreen();
            Terminal.WriteLine("Goodjob,");
            Terminal.WriteLine("Loading next stage...");
        }
        else{
            Terminal.WriteLine("Wrong password, try again");
            EnterPassword();
        }
            
    }
    private void LoadWinSceen(){
        Terminal.ClearScreen();
        currentScreen = Screen.Success;
        Terminal.WriteLine("Successfully, let get important data");
        Terminal.WriteLine(@"
 __
/o \_______
\__/--'='`-
"
        );
        Terminal.WriteLine("hack - Hack Cucumber's Computer");
        Terminal.WriteLine("menu - Back to menu"); 
        Terminal.WriteLine("exit - Exit game");  
        Terminal.WriteLine("Enter what to do: ");
    }
    private void LoadingScreen(){
        Terminal.WriteLine(@"
  _._     _,-'''`-._
     (,-.`._,'(       |\`-/|
         `-.-' \ )-`( , o o)
               `-    \`_`''- 
"
        );
    }
    private void Hack(string input){  
            if(input == "hack"){
                Terminal.ClearScreen();
                Terminal.WriteLine("Loading...");
                LoadingScreen();
                CheckReward();
                Invoke("Notify", 3f);  
            }
    }
    private void CheckReward(){
       ImportantData.OnChangeWallpaperButtonClicked();
    }
    private void Notify(){
        Terminal.ClearScreen();
        Terminal.WriteLine("Oh no! the cucumber has detected\nand hacked back into your system.");
        Terminal.WriteLine("Check your deskop background !!!");
        Terminal.WriteLine("Enter 'exit' to close program");
    }
}
