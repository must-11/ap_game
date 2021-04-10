using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMain : MonoBehaviour
{
    private int n_play;  // プレイヤー数
    public static int[,] score;  // スコアを保持する行列

    public static int N_CARD, T_CARD, PLAYER, N;
    public static int[,] TMP;  // 選択を保持する一時的な行列

    private GameObject canvas, card, scorearea,cardarea;
    private Quaternion q;
    private CardArea cardArea;

    // Start is called before the first frame update
    void Start()
    {
        // 初期値設定
        n_play = SceneTitle.N_PLAY;
        N_CARD = n_play - 1;    //各ターンのカード枚数
        T_CARD = N_CARD + 2;    //登場カード種類
        score = new int[n_play, T_CARD];
        PLAYER = 0;
        N = 0;
        TMP = new int[n_play, T_CARD];

        // カードオブジェクト取得
        q = Quaternion.identity;
        canvas = GameObject.Find("Canvas");
        card = (GameObject)Resources.Load("CardPrefab");
        scorearea = (GameObject)Resources.Load("ScoreArea");
        cardarea = (GameObject)Resources.Load("CardArea");
        Debug.Log("Game start");
        
        Setting();
        Turn();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (PLAYER >= n_play)
        {
            // 全プレイヤーが選択したので、カードオブジェクトを削除
            DestroyCards();

            PLAYER = 0;
            TMP = new int[n_play, T_CARD];

            Debug.Log("New cards");
            // Setting();
        }*/
    }

    // canvasエリアの用意
    private void Setting()
    {
        var c_instance = Instantiate(cardarea);
        var s_instance = Instantiate(scorearea, new Vector2(600, -50), q);
        c_instance.transform.SetParent(canvas.transform, false);
        s_instance.transform.SetParent(canvas.transform, false);
        cardArea = c_instance.GetComponent<CardArea>();
    }

    private void Turn()
    {
        //1ターンのループ
        //カードの配置
        cardArea.DeliverCard(n_play, N_CARD, T_CARD);
        //カードの選択
        /*ここに処理*/

        //得点計算
        /*ここに処理*/

        //終了判定
        /*ここに処理*/
            /*if終了条件を満たす
            * SceneTitleへ*/
        //ターン終了
        Invoke("cardArea.DisCard", 1);
    }



    /*
    // 行列を入力し、[最大値, 行, 列]を返す
    private int[] GetMax(int[,] A)
    {

    } 

    // 行列を入力し、重複がある列を全て0にして返す
    private int[,] DropDuplicates(int[,] A)
    {

    }

    // 0~n-1の中からk個選ぶ順列を返す
    private int[] RamdomSample(int n, int k)
    {

    }

    // 2つの行列の和を返す
    private int[,] Addition(int[,] A, int[,]　B)
    {

    }
    */
}

