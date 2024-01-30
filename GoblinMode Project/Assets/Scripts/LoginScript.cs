using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LoginScript : MonoBehaviour
{
    private TMP_InputField usernameInput;
    private TMP_InputField passwordInput;
    // Start is called before the first frame update
    void Start()
    {
        usernameInput = GameObject.Find("UsernameInput").gameObject.GetComponent<TMP_InputField>();
        passwordInput = GameObject.Find("PasswordInput").gameObject.GetComponent<TMP_InputField>();
    }

    public void Login()
    {
        string filePath = Application.dataPath + "/UserAccounts";
        string[] UserAccountDetails = File.ReadAllLines(filePath);

        string username = usernameInput.text;
        string password = passwordInput.text;
        
        for(int i = 0; i <= UserAccountDetails.Length -1; i += 2)
        {
            if(username == UserAccountDetails[i])
            {
                if(password == UserAccountDetails[i + 1])
                {
                    Debug.Log("Login Successful " + i);
                    i = UserAccountDetails.Length;
                }
                else
                {
                    Debug.Log("Login Unsuccessful " + i);
                }
            }
            else
            {
                Debug.Log("Login Unsuccessful " + i);
            }
        }
    }
}
