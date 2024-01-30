using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SignUpScript : MonoBehaviour
{
    private TMP_InputField usernameInput;
    private TMP_InputField passwordInput;
    // Start is called before the first frame update
    void Start()
    {
        CreateTextFile();

        usernameInput = GameObject.Find("UsernameInput").gameObject.GetComponent<TMP_InputField>();
        passwordInput = GameObject.Find("PasswordInput").gameObject.GetComponent<TMP_InputField>();
    }
    public void SignUp()
    {
        string filePath = Application.dataPath + "/UserAccounts";

        string username = usernameInput.text;
        string password = passwordInput.text; 

        File.AppendAllText(filePath, username + "\n" + password + "\n");
    }
    void CreateTextFile()
    {
        string filePath = Application.dataPath + "/UserAccounts";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
    }
}
