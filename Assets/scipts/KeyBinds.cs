using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyBinds : MonoBehaviour
{

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text right, left, down, jump;

    public static KeyCode rightKey, leftKey, jumpKey, downKey;

    private GameObject currentKey;

    public GameObject MainMenu;

    public GameObject ControlsMenu;

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Right", KeyCode.D);
        keys.Add("Left", KeyCode.A);
        keys.Add("Down", KeyCode.S);
        keys.Add("Space", KeyCode.Space);

        rightKey = keys["Right"];
        leftKey = keys["Left"];
        jumpKey = keys["Space"];
        downKey = keys["Down"];

        jump.text = keys["Space"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();

    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Text text = currentKey.transform.GetChild(0).GetComponent<Text>();
            text.text = "Press any key to rebind";
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                text.text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }

    public void saveButtons(Text text)
    {
            text.text = "";
            if (left.text == right.text || left.text == jump.text || left.text == down.text || right.text == jump.text || right.text == down.text || jump.text == down.text)
            {
               text.text = "invalid inputs (Make sure there are no conflicting binds)";
               return;
            }
            else
            {
                rightKey = keys["Right"];
                leftKey = keys["Left"];
                jumpKey = keys["Space"];
                downKey = keys["Down"];

                GoToMain();
            }
        
    }

        public void GoToMain()
    {
        MainMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }
}
