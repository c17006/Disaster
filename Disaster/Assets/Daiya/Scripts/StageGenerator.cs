using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageGenerator : MonoBehaviour {

    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト

    [SerializeField]
    private GameObject[] Block;//生成されるオブジェクト

    private int DefaultValue_x = -920;// x座標の初期値
    private int DefaultValue_y = 500;// y座標の初期値
    private int IncreaseValue_x = 80;// x座標の増加値
    private int DecrementValue_y = 80;// y座標の減少値


    void Start() {
        LoadCSVFile();
        GenerateStage();
    }

    // CSVファイル読み込み
    private void LoadCSVFile() {
        csvFile = Resources.Load("Stage" + SceneManager.GetActiveScene().buildIndex) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        // セルごとに区切ってlistに格納する
        while (reader.Peek() > -1) {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
    }

    // ステージオブジェクトを生成する
    private void GenerateStage() {
        for (int i = 0; i < csvDatas.Count; i++) {
            for (int j = 0; j < csvDatas[i].Length; j++) {
                int intcsvDatas = int.Parse(csvDatas[i][j]);
                if (intcsvDatas > 0) {
                    Instantiate(Block[intcsvDatas - 1],
                                new Vector3(DefaultValue_x + j * IncreaseValue_x, DefaultValue_y - i * DecrementValue_y, 0), Quaternion.identity);
                }
            }

        }
    }
}