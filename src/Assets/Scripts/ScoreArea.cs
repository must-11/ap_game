using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreArea : MonoBehaviour
{
    RectTransform rectTransform;
    Cards cards;
    private GameObject Card, Player, Point;
    private Quaternion q = Quaternion.identity;
    // Start is called before the first frame update
    void Start()
    {
        int T_Card = SceneMain.T_CARD;
        int N_Play = SceneTitle.N_PLAY;
        int[,] scores = SceneMain.score;
        rectTransform = GetComponent<RectTransform>();
        Card = (GameObject)Resources.Load("CardPrefab");
        Player = (GameObject)Resources.Load("PlayerTile");
        Point = (GameObject)Resources.Load("ScoreTile");
        MakingList(N_Play,T_Card, scores);
        
    }

    private void MakingList(int N_Play, int T_CARD,int[,] scores)
    {
        int i,j;
        string str;
        Vector2 localposition;
        //nに基づいてScoreAreaの中で各タイルの幅を決定
        /*幅のルール
         * Playerはカード2枚分として,横幅TileXはAreaをn+2等分(+余白)
         * 学科カードの縦幅TileYは横幅に合わせて決定
         * Player&Pointの縦幅TileXは横幅と同じ
         */
        float width,TileX,TileY;TileY = 0;
        width = rectTransform.sizeDelta.x;
        TileX = width / (T_CARD + 2);
        //学科カードの配置
        for (i = 0; i < T_CARD; i++)
        {
            localposition = new Vector2(TileX * (i + 2), 0);
            var instance = Instantiate(Card, localposition,q);
            instance.transform.SetParent(transform, false);
            cards = instance.GetComponent<Cards>();
            cards.SetFace(i);
            TileY = cards.ResizeHeight(TileX);
        }
        //各プレイヤーカードの配置
        for (j = 0; j < N_Play; j++)
        {
            localposition = new Vector2(0, -TileY-TileX*j);
            var instance = Instantiate(Player, localposition, q);
            instance.transform.SetParent(transform, false);
            str = "Player" + (j + 1).ToString();    //PlayerName
            rename(instance, "PlayerName", str);
            resize(instance, TileX * 2, TileX);
            localposition += new Vector2(TileX, 0);
            //各得点カードの配置
            for (i=0; i < T_CARD; i++)
            {
                localposition += new Vector2(TileX, 0);
                var S_instance = Instantiate(Point, localposition, q);
                S_instance.transform.SetParent(transform, false);
                rename(S_instance, "Score", scores[j, i].ToString()) ;
                resize(S_instance, TileX, TileX);
            }
        }
    }
    private void resize(GameObject gameObject,float x,float y)
    {
        RectTransform rectT;
        rectT = gameObject.GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2(x, y);
    }
    private void rename(GameObject gameObject,string ChildName,string str)
    {
        //子オブジェクトにあるTextオブジェクト"ChildName"のtextを変更する
        Transform transform = gameObject.GetComponent<Transform>();
        GameObject child;
        Text text;
        child = transform.Find(ChildName).gameObject;
        text = child.GetComponent<Text>();
        text.text = str;

    }
}
