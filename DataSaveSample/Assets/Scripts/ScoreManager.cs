using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public ScoreData scoredata;//json�ϊ�����f�[�^�̃N���X
    string Scorefilepath;// json�t�@�C���̃p�X
    string ScoreDatafileName = "ScoreData.json";// json�t�@�C����

    void Awake()
    {
        // �p�X���擾
        Scorefilepath = Application.dataPath + "/" + ScoreDatafileName;

        // �t�@�C�����Ȃ��Ƃ��A�t�@�C���쐬
        if (!File.Exists(Scorefilepath))
        {
            Save(scoredata);
        }

        // �t�@�C����ǂݍ����data�Ɋi�[
        scoredata = Load(Scorefilepath);
    }

    void Save(ScoreData data)
    {
        string json = JsonUtility.ToJson(data);                 // json�Ƃ��ĕϊ�
        StreamWriter wr = new StreamWriter(Scorefilepath, false);    // �t�@�C���������ݎw��
        wr.WriteLine(json);                                     // json�ϊ�����������������
        wr.Close();                                             // �t�@�C������
    }

    ScoreData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // �t�@�C���ǂݍ��ݎw��
        string json = rd.ReadToEnd();                           // �t�@�C�����e�S�ēǂݍ���
        rd.Close();                                             // �t�@�C������

        return JsonUtility.FromJson<ScoreData>(json);            // json�t�@�C�����^�ɖ߂��ĕԂ�
    }

    void OnDestroy()
    {
        Save(scoredata);
    }
}
