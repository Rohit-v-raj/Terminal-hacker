using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour
{
    int level;
    int index;
    string menuhint = "Press 'menu' to try other levels or    press 'exit' if you give up";
    enum screen { mainmenu, password, winscreen };
    string password;
    screen currentscreen;
    string[] level1passwords = { "casameiro", "bale", "hazard" };
    string[] level2passwords = { "chandrayaan", "mangalyaan", "vikram" };
    string[] level3passwords = { "indigo", "spicejet", "boeing" };
        // Start is called before the first frame update
    void Start()
    {
        Showmainmenu();
    }
     
    void Showmainmenu()
    {
        currentscreen = screen.mainmenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to the game of hacking!! ");
        Terminal.WriteLine("press 1 to hack Real Madrid");
        Terminal.WriteLine("press 2 to hack ISRO");
        Terminal.WriteLine("press 3 to hack KIAL");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter Your Choice");
    }
   
    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            currentscreen = screen.mainmenu;
            Showmainmenu(); }
        else if (input=="exit"||input=="close"||input=="quit")
        {
            Application.Quit();
        }
        else if (currentscreen ==screen.mainmenu)
        {

            runmainmenu(input);
        }
        else if(currentscreen==screen.password)
        {
            Checkpassword(input);
        }
    }


    void runmainmenu(string input)
    {
        bool isvalidnum = (input == "1" || input == "2" || input == "3");
            if(isvalidnum)
        {
            level = int.Parse(input);
            Startgame();
        }
       
        else
        {
            Terminal.WriteLine("Please select a valid level !!");
            Terminal.WriteLine(menuhint);
        }
    }

    
    void Startgame()
    {
        Terminal.ClearScreen();
        
        currentscreen = screen.password;
         setrandompassword();

        Terminal.WriteLine("Please enter the password,Hint: " + password.Anagram());
        Terminal.WriteLine(menuhint);
    }

     void setrandompassword()
    {
        
        switch (level)
        {
            case 1:
                index = Random.Range(0, level1passwords.Length);
                password = level1passwords[index];
                break;
            case 2:
                index = Random.Range(0, level2passwords.Length);
                password = level2passwords[index];
                break;
            case 3:
                index = Random.Range(0, level3passwords.Length);
                password = level3passwords[index];
                break;
            default:
                Debug.LogError("invalidPassword");
                break;

        }

        
    }

    void Checkpassword(string input)
    {
        if (input == password)
            Levelwin();
        else
            Startgame(); 
    }

    void Levelwin()
    {
        Terminal.ClearScreen();
        currentscreen=screen.winscreen;
        Levelreward();
        Terminal.WriteLine(menuhint);

    }

    void Levelreward()
    {
       switch(level)
        {
            case 1:
                Terminal.WriteLine(@"
       ____       ______          
|    ||    | |    |    | 
|====||----| |    |----|    
|    ||    | |___ |    |      

 WELCOME TO REAL MADRID"
);
                    break;
            case 2:
                Terminal.WriteLine("");
                Terminal.WriteLine(@"
_____    ______  _____     _____                           
  |     |_____  |____|   |     |                     
  |           | |____    |     |              
__|___  ______| |    |   |_____|
                          
  WELCOME TO ISRO"
);
                    break;
            case 3:
                Terminal.WriteLine("");
                Terminal.WriteLine(@"
       |                                            
       |                                              
 ------|------                                               
       |                                               
    ---|---                                                          
                           
WELCOME TO KIAL"
);
                break;
            default:
                Debug.LogError("Invalidlevel");
                break;
        }
         
    }
}
