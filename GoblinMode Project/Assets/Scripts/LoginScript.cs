using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LoginScript : MonoBehaviour
{
    private TMP_InputField usernameInputField;
    private TMP_InputField passwordInputField;
    private TextMeshProUGUI errorTextMesh;

    public GameObject MainMenu;
    public GameObject LoginMenu;

    public string username;
    // Start is called before the first frame update
    void Start()
    {
        usernameInputField = GameObject.Find("UsernameInput").gameObject.GetComponent<TMP_InputField>();
        passwordInputField = GameObject.Find("PasswordInput").gameObject.GetComponent<TMP_InputField>();
        errorTextMesh = GameObject.Find("ErrorText").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Login()
    {
        string filePath = Application.dataPath + "/UserAccounts";
        string[] userAccountDetails = File.ReadAllLines(filePath);

        string usernameInput = usernameInputField.text;
        string passwordInput = passwordInputField.text;

        bool isLogedIn = false;

        // Usernames and passwords are stored alternately 
        // Loops through usernames in userAccountDetails 
        for(int i = 0; i <= userAccountDetails.Length -1; i += 2)
        {
            if (usernameInput == userAccountDetails[i])
            {
                if (passwordInput == userAccountDetails[i + 1])
                {
                    isLogedIn = true;
                    errorTextMesh.text = "";
                    LoginMenu.SetActive(false);
                    MainMenu.SetActive(true);
                    username = usernameInput;
                    break;
                }
            }
        }
        if (isLogedIn == false)
        {
            errorTextMesh.text = "username or password is incorrect";
        }
    }
}
