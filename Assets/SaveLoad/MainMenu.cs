using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    //Task 3
    private int vibrate;
    private string key = "vibration";
    
    //Task 3
    void Start()
    {
        vibrate = PlayerPrefs.GetInt(key);
    }

    public enum Menu {
		MainMenu,
		NewGame,
		Continue
	}

	public Menu currentMenu;

	void OnGUI () {

		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();

		if(currentMenu == Menu.MainMenu) {

			GUILayout.Box("Last Fantasy");
			GUILayout.Space(10);

			if(GUILayout.Button("New Game")) {
				Game.current = new Game();
				currentMenu = Menu.NewGame;
			}

			if(GUILayout.Button("Continue")) {
				SaveLoad.Load();
				currentMenu = Menu.Continue;
			}

			if(GUILayout.Button("Quit")) {
				Application.Quit();
			}
		}

		else if (currentMenu == Menu.NewGame) {

			GUILayout.Box("Name Your Characters");
			GUILayout.Space(10);

			GUILayout.Label("Knight");
			Game.current.knight.name = GUILayout.TextField(Game.current.knight.name, 20);
			GUILayout.Label("Rogue");
			Game.current.rogue.name = GUILayout.TextField(Game.current.rogue.name, 20);
			GUILayout.Label("Wizard");
			Game.current.wizard.name = GUILayout.TextField(Game.current.wizard.name, 20);

			if(GUILayout.Button("Save")) {
				//Save the current Game as a new saved Game
				SaveLoad.Save();
				//Move on to game...
				Application.LoadLevel(1);
			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}

		}

		else if (currentMenu == Menu.Continue) {
			
			GUILayout.Box("Select Save File");
			GUILayout.Space(10);
			
			foreach(Game g in SaveLoad.savedGames) {
				if(GUILayout.Button(g.knight.name + " - " + g.rogue.name + " - " + g.wizard.name)) {
					Game.current = g;
					//Move on to game...
					Application.LoadLevel(1);
				}

			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}
			
		}
        //Task 3
        if (GUI.Button(new Rect(0, 10, 100, 32), "Vibrate"))
        {
            
            PlayerPrefs.SetInt(key, toggleVibrate());
            if (vibrate == 0)
            {
                Debug.Log("Vibration is on");
                Handheld.Vibrate();
            }
            else
            {
                Debug.Log("Vibration is off");
            }
        }

        GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

	}
    //Task 3
    int toggleVibrate()
    {
        if(vibrate == 0)
        {
            return vibrate = 1;
        }
        else
        {
            return vibrate = 0;
        }
    }
}
