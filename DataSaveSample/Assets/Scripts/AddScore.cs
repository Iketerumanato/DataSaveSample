using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddScore : MonoBehaviour
{
    /* �l */
    string[] scoreNames = { "1stSageScore", "2ndSageScore", "3rdSageScore", "4thSageScore", "5thSageScore" };// �X�R�A��
    const int ScoreCnt = ScoreData.StageScore;// �X�R�A��
    int[] NowStageScore = { 0, 0, 0, 0, 0 };
    const int MaxScore = 3;
    const int MinScore = 0;

    /* �R���|�[�l���g�擾�p */
    TMP_Text[] scoreTexts = new TMP_Text[ScoreCnt];// �X�R�A�̃e�L�X�g
    ScoreData scoredata;

    // Start is called before the first frame update
    void Start()
    {
        scoredata = GetComponent<ScoreManager>().scoredata;// �Z�[�u�f�[�^��DataManager����Q��

        for (int i = 0; i < ScoreCnt; i++)
        {
            Transform rankChilds = GameObject.Find("ScoreTexts").transform.GetChild(i);// �q�I�u�W�F�N�g�擾
            scoreTexts[i] = rankChilds.GetComponent<TMP_Text>();// �q�I�u�W�F�N�g�̃R���|�[�l���g�擾
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DispScore();
        AppDateHighScore();
    }

    #region//�X�R�A�\��
    void DispScore()
    {
        for (int i = 0; i < ScoreCnt; i++)
        {
            scoreTexts[i].text = (scoreNames[i] + " : " + scoredata.HighScore[i]);
        }
    }
    #endregion

    #region//�X�R�A���Z
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

    #region//�X�R�A�X�V�܂Ƃ�
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

    #region//�X�R�A����
    public void DelScore()
    {
        for (int i = 0; i < ScoreCnt; i++)
        {
            scoredata.HighScore[i] = 0;
        }
    }
    #endregion
}