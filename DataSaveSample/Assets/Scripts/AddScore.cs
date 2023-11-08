using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddScore : MonoBehaviour
{
    /* 値 */
    string[] scoreNames = { "1stSageScore", "2ndSageScore", "3rdSageScore", "4thSageScore", "5thSageScore" };// スコア名
    const int ScoreCnt = ScoreData.StageScore;// スコア数
    int[] NowStageScore = { 0, 0, 0, 0, 0 };
    const int MaxScore = 3;
    const int MinScore = 0;

    /* コンポーネント取得用 */
    TMP_Text[] scoreTexts = new TMP_Text[ScoreCnt];// スコアのテキスト
    ScoreData scoredata;

    // Start is called before the first frame update
    void Start()
    {
        scoredata = GetComponent<ScoreManager>().scoredata;// セーブデータをDataManagerから参照

        for (int i = 0; i < ScoreCnt; i++)
        {
            Transform rankChilds = GameObject.Find("ScoreTexts").transform.GetChild(i);// 子オブジェクト取得
            scoreTexts[i] = rankChilds.GetComponent<TMP_Text>();// 子オブジェクトのコンポーネント取得
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DispScore();
        AppDateHighScore();
    }

    #region//スコア表示
    void DispScore()
    {
        for (int i = 0; i < ScoreCnt; i++)
        {
            scoreTexts[i].text = (scoreNames[i] + " : " + scoredata.HighScore[i]);
        }
    }
    #endregion

    #region//スコア加算
    public void PlusScore1st()
    {
        NowStageScore[0]++;
    }

    public void PlusScore2nd()
    {
        NowStageScore[1]++;
    }

    public void PlusScore3rd()
    {
        NowStageScore[2]++;
    }

    public void PlusScore4th()
    {
        NowStageScore[3]++;
    }

    public void PlusScore5th()
    {
        NowStageScore[4]++;
    }
    #endregion

    #region//スコア更新まとめ
    void AppDateHighScore()
    {
        //AppdateScore
        //Stage01
        if (NowStageScore[0] > scoredata.HighScore[0])
        {
            var rep1st = scoredata.HighScore[0];
            scoredata.HighScore[0] = NowStageScore[0];
            NowStageScore[0] = rep1st;
        }

        //Stage02
        if (NowStageScore[1] > scoredata.HighScore[1])
        {
            var rep2nd = scoredata.HighScore[1];
            scoredata.HighScore[1] = NowStageScore[1];
            NowStageScore[1] = rep2nd;
        }

        //Stage03
        if (NowStageScore[2] > scoredata.HighScore[2])
        {
            var rep3rd = scoredata.HighScore[2];
            scoredata.HighScore[2] = NowStageScore[2];
            NowStageScore[2] = rep3rd;
        }

        //Stage04
        if (NowStageScore[3] > scoredata.HighScore[3])
        {
            var rep4th = scoredata.HighScore[3];
            scoredata.HighScore[3] = NowStageScore[3];
            NowStageScore[3] = rep4th;
        }

        //Stage05
        if (NowStageScore[4] > scoredata.HighScore[4])
        {
            var rep5th = scoredata.HighScore[4];
            scoredata.HighScore[4] = NowStageScore[4];
            NowStageScore[4] = rep5th;
        }
    }
    #endregion

    #region//スコア消去
    public void DelScore()
    {
        for (int i = 0; i < ScoreCnt; i++)
        {
            scoredata.HighScore[i] = 0;
        }
    }
    #endregion
}