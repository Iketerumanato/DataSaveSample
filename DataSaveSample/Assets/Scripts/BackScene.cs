using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    public void BacktoRank()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GotoOther()
    {
        SceneManager.LoadScene("OtherScene");
    }

    public void GotoSecondOther()
    {
        SceneManager.LoadScene("Other2");
    }

    public void GotoScore()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    public void GotoOtherScore()
    {
        SceneManager.LoadScene("ScoreScene 1");
    }

    public void GotoScoreText()
    {
        SceneManager.LoadScene("ScoreText");
    }
}
