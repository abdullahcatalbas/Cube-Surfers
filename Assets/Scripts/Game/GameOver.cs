using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    
    public static GameOver instance;
    public GameObject bg;
    public RectTransform WinUI;
    public RectTransform FailUI;
    public bool LeveL2 = false;
    public bool LeveL3 = false;
    public Text pointsText;
  

    void Awake()
    {
        instance = this;
    }
   

  
    public void SetUp()
    {
        Debug.Log("Setup");
        bg.gameObject.SetActive(true);
        pointsText.text =ScoreManager.instance.score.ToString() + "  POINTS";
        PlayerBehaviour.Instance.StopPlayer();
        if(PlayerCubeManager.Instance.listOfCubeBehaviour.Count < 1)
        {
            ActiveFailUI();

        }
        else{
            
            ActiveWinUI();
        }

       
    }
    

    public void ActiveWinUI()
    {
        WinUI.gameObject.SetActive(true);
        Vector3 defaultScale = WinUI.transform.localScale;

        WinUI.transform.localScale = Vector3.one * 0.00001f;
        WinUI.DOScale(defaultScale,1f).SetEase(Ease.OutBounce);
        LeveL2 = true;
       
        if (LeveL2 == true)
            {
                LeveL3 = true;
            }
        


        
    }
    public void ActiveFailUI()
    {
        FailUI.gameObject.SetActive(true);
        Vector3 defaultScale = FailUI.transform.localScale;

        FailUI.transform.localScale = Vector3.one * 0.00001f;
        FailUI.DOScale(defaultScale,1f).SetEase(Ease.OutBounce);

        
    }

    public void RestartGame()
    {
        LeveL2 = false;
        LeveL3 = false;
        SceneManager.LoadScene("Game");
    
    }
    public void OpenScene()
    {
        if(LeveL2 == true)
        {
           SceneManager.LoadScene("LeveL2");
        }
    }
    public void OpenScene2()
    {
       
        SceneManager.LoadScene("LeveL3");
        
    }
  

}
