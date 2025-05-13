using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_InputField inputField; //inputField ����
    public Button gameStartButton; //Button ����

    public void Start()
    {
        gameStartButton.onClick.AddListener(OngameStartButtonClicked);
    }
    public void OngameStartButtonClicked()
    {
        string playername = inputField.text;
        if (string.IsNullOrEmpty(playername))
        {
            {
                Debug.Log("�÷��̾� �̸��� �Է��ϼ���.");
                return;
            }
        }
            PlayerPrefs.SetString("PlayerName", playername);
            PlayerPrefs.Save();

            Debug.Log("�÷��̾� �̸� ���� ��: " + playername);

            SceneManager.LoadScene("Stage_1");
        
    }
}