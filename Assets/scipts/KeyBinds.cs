using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class KeyBinds : MonoBehaviour
{

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text right, left, down, jump, leftDash, rightDash;

    public static KeyCode rightKey, leftKey, jumpKey, downKey, leftDashKey, rightDashKey;

    private GameObject currentKey;

    public GameObject MainMenu;

    public GameObject ControlsMenu;

    public static bool valid = true;

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Right", KeyCode.D);
        keys.Add("Left", KeyCode.A);
        keys.Add("Down", KeyCode.S);
        keys.Add("Space", KeyCode.Space);
        keys.Add("LeftDash", KeyCode.Z);
        keys.Add("RightDash", KeyCode.C);

        rightKey = keys["Right"];
        leftKey = keys["Left"];
        jumpKey = keys["Space"];
        downKey = keys["Down"];
        leftDashKey = keys["LeftDash"];
        rightDashKey = keys["RightDash"];

        jump.text = keys["Space"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        leftDash.text = keys["LeftDash"].ToString();
        rightDash.text = keys["RightDash"].ToString();

        

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
        valid = true;
        string[] keysArray = { right.text, left.text, down.text, jump.text, leftDash.text, rightDash.text };
        for (int i = 0; i < keysArray.Length; i++)
        {
            for (int j = 0; j < keysArray.Length; j++)
            {
                int currentIndex = i;
                if (keysArray.ElementAt(i).ToString() == keysArray.ElementAt(j).ToString())
                {
                    Debug.Log(i.ToString() + " " + j.ToString());
                    if (j == i)
                    {
                        continue;
                    }
                    else 
                    {
                        valid = false;
                        break;
                    }
                }
            }

            if (valid == false)
            {
                break;
            }
        }
        /*if (left.text == right.text || left.text == jump.text || left.text == down.text || right.text == jump.text || right.text == down.text || jump.text == down.text)
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
            leftDashKey = keys["LeftDash"];
            rightDashKey = keys["RightDash"];

        GoToMain();
        }
        */
        if (valid == false)
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
            leftDashKey = keys["LeftDash"];
            rightDashKey = keys["RightDash"];

            GoToMain();
        }

    }

        public void GoToMain()
    {
        MainMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }
}
