using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public ScoreData scoredata;//json変換するデータのクラス
    string Scorefilepath;// jsonファイルのパス
    string ScoreDatafileName = "ScoreData.json";// jsonファイル名

    void Awake()
    {
        // パス名取得
        Scorefilepath = Application.dataPath + "/" + ScoreDatafileName;

        // ファイルがないとき、ファイル作成
        if (!File.Exists(Scorefilepath))
        {
            Save(scoredata);
        }

        // ファイルを読み込んでdataに格納
        scoredata = Load(Scorefilepath);
    }

    void Save(ScoreData data)
    {
        string json = JsonUtility.ToJson(data);                 // jsonとして変換
        StreamWriter wr = new StreamWriter(Scorefilepath, false);    // ファイル書き込み指定
        wr.WriteLine(json);                                     // json変換した情報を書き込み
        wr.Close();                                             // ファイル閉じる
    }

    ScoreData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる

        return JsonUtility.FromJson<ScoreData>(json);            // jsonファイルを型に戻して返す
    }

    void OnDestroy()
    {
        Save(scoredata);
    }
}
