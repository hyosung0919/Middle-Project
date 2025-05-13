using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_InputField inputField; //inputField 연결
    public Button gameStartButton; //Button 연결

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
                Debug.Log("플레이어 이름을 입력하세요.");
                return;
            }
        }
            PlayerPrefs.SetString("PlayerName", playername);
            PlayerPrefs.Save();

            Debug.Log("플레이어 이름 저장 됨: " + playername);

            SceneManager.LoadScene("Stage_1");
        
    }
}