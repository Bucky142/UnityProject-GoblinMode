using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class SignUpScript : MonoBehaviour
{
    private TMP_InputField usernameInput;
    private TMP_InputField passwordInput;

    private TextMeshProUGUI errorTextMesh;

    public GameObject MainMenu;
    public GameObject SignUpMenu;

    // Start is called before the first frame update
    void Start()
    {
        CreateTextFile();

        usernameInput = GameObject.Find("UsernameInput").gameObject.GetComponent<TMP_InputField>();
        passwordInput = GameObject.Find("PasswordInput").gameObject.GetComponent<TMP_InputField>();
        errorTextMesh = GameObject.Find("ErrorText").GetComponent<TextMeshProUGUI>();
    }

    void CreateTextFile()
    {
        string filePath = Application.dataPath + "/UserAccounts";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
    }

    public void SignUp()
    {
        string filePath = Application.dataPath + "/UserAccounts";

        string username = usernameInput.text;
        string password = passwordInput.text;

        if (ValidateUsernamePassword(username, password) == true)
        {
            File.AppendAllText(filePath, username + "\n" + password + "\n");
        }
    }

    bool ValidateUsernamePassword(string username, string password)
    {
        // Validate Username

        // string must contain at least one upper or lower case letter
        // may contain numbers 
        Regex usernameRegularExpression = new Regex("^(?=.*[a-zA-Z])[a-zA-Z0-9]+$");


        if (usernameRegularExpression.IsMatch(username))
        {
            // username length must be between 3 and 15 characters
            if (username.Length < 3 || username.Length > 15)
            {
                errorTextMesh.text = "username length must be between 3 and 15 characters";
                return false;
            }
        }
        else
        {
            errorTextMesh.text = "username must not contain symbols and must have a letter";
            return false;
        }

        // Validate Password

        // string must contian at least one: lower case letter, upper case letter, and a number  
        Regex passwordRegularExpression = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$");

        if (passwordRegularExpression.IsMatch(password))
        {
            // username length between 10 and 20 characters
            if (password.Length > 9 && password.Length < 21)
            {
                errorTextMesh.text = "";
                SignUpMenu.SetActive(false);
                MainMenu.SetActive(true);
                return true;
            }
            else
            {
                errorTextMesh.text = "password length must be between 10 and 20 characters";
                return false;
            }
        }
        else
        {
            errorTextMesh.text = "password must contain atleast one number, one lower-case and upper-case letter";
            return false;
        }

    }

}
