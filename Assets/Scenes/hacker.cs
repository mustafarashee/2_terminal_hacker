using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour
{
    //game configs
    const string menu = "you may type menu at any time";
    string[] level1passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2passwords = { "prisoners", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3passwords = { "telescope", "blackhole", "milkyway", "jupiter", "hubble" };

    int level;
    enum screen { MainMenu, Password, Win };
    string password;
    screen currentScreen;
    // Start is called before the first frame update
    void Start()
    {

        ShowMainMenu("hello mustafa");
    }
    void ShowMainMenu(string greeting)
    {
        currentScreen = screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("        welcome to terminal hacker\n");
        Terminal.WriteLine("press 1 for libarary hacking\npress 2 for police station hacking\npress 3 for nasa hacking");
        Terminal.WriteLine("enter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("hello mustafa");
        }

        else if (currentScreen == screen.MainMenu)
        {
            runMainMenu(input);
        }
        else if (currentScreen == screen.Password)
        {
            checkpassword(input);
        }
    }


    void runMainMenu(string input)
    {
        bool isvalidlevel = (input == "1" || input == "2" || input == "3");

        if (isvalidlevel)
        {
            level = int.Parse(input);                        //converting string input into int type
            startGame();
        }
        /*if(input=="1")
       {
           level = 1;
           password = level1passwords[2];
            startGame(level);
       }
       else if (input == "2")
       {
           level = 2;
           password = level2passwords[1];
           startGame(level);
       }
        else if (input == "3")
        {
            level = 3;
            password = level3passwords[0];
            startGame(level);
        }*/
        else if (input == "007")
        {
            Terminal.WriteLine("please choose a level mr bond");

        }
        else
        {
            Terminal.WriteLine("please choose a valid level");
            Terminal.WriteLine(menu);
        }
    }


    void startGame()
    {
        currentScreen = screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("ENTER A PASSWORD   HINT:" + password.Anagram());
        Terminal.WriteLine(menu);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1passwords.Length);
                password = level1passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2passwords.Length);
                password = level2passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3passwords.Length);
                password = level3passwords[index3];
                break;
            default:
                Debug.LogError("invalid input");             //print an error message in red
                break;

        }
    }
    void checkpassword(string input)
    {
        if (input == password)
        {
            displaywinscreen();

        }
        else
        {
            Terminal.WriteLine("sorry wrong password, try harder");
            startGame();
        }
    }

    void displaywinscreen()
    {
        currentScreen = screen.Win;
        Terminal.ClearScreen();
        getlevelrewards();
    }

    void getlevelrewards()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("HAVE A BOOK..");

                Terminal.WriteLine(@" 

    _______
   /      //
  /      //
 /______//
(______(/

");

                break;
            case 2:
                Terminal.WriteLine("HERE'S YOUR KEY BUT DONT TELL ANYONE SSSHHHH...");
                Terminal.WriteLine(@"
                   __
                  /o \_____
                  \__/-=""`
 


");
                break;
            case 3:
                Terminal.WriteLine("HERE'S YOUR LAUNCH CODES FOR ROCKET..\n 5716");
                Terminal.WriteLine(@"
  /\     |\**/|      
 /  \    \ == /
 |  |     |  |
 |  |     |  |
/ == \    \  /
|/**\|     \/
");
                break;
            default:
                Debug.LogError("INVALID INPUT");
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
