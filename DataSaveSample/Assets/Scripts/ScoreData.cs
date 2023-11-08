[System.Serializable]
public class ScoreData
{
    public const int StageScore = 5;//保存するデータの個数
    public int[] HighScore = new int[StageScore];//各ステージのハイスコア
}