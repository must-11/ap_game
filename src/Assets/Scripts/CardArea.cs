using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardArea : MonoBehaviour
{
    static int seed = Environment.TickCount;
    private GameObject card;
    private Quaternion q = Quaternion.identity;
    private RectTransform rectTransform;
    private float width,height;
    private const int MaxN = 5; //一列に並べる上限
    private const float gap = 0.2f; //カード幅に対する隙間幅
    Cards cards;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    //カードの配置
    public void DeliverCard(int n_play, int N_CARD, int T_CARD)
    {
        Debug.Log("カードを配置");
        int[] faculties = AssignNum(N_CARD,T_CARD);
        int i;
        width = DecideWidth(N_CARD);
        card = (GameObject)Resources.Load("CardPrefab");
        height = GetHeight(width,card);
        for (i = 0; i < N_CARD; i++)
        {
            var instance = Instantiate(card, DecidePosition(N_CARD,i), q);
            instance.transform.SetParent(transform, false);
            cards = instance.GetComponent<Cards>();
            cards.faculty = faculties[i];
            cards.ToggleFace(true);
            _= cards.ResizeHeight(width);
        }

    }

    private float DecideWidth(int N_CARD)
    {   //カード幅の決定
        float width, areawidth;
        areawidth = rectTransform.sizeDelta.x;
        if (N_CARD < MaxN)
        {
            width = areawidth / (N_CARD * (gap + 1) + gap);
        }
        else
        {
            width = areawidth / (MaxN * (gap + 1) + gap);
        }
        return width;
    }
    private float GetHeight(float width,GameObject card)
    {   //カード長の取得
        float height;
        var instance = Instantiate(card);
        cards = instance.GetComponent<Cards>();
        height = cards.ResizeHeight(width);
        Destroy(instance);
        return height;
    }
    private Vector2 DecidePosition(int N_CARD,int i)
    {   //カードの配置の決定
        float x, y, p, q;
        int row = N_CARD / MaxN + 1;   //段数
        int col = (int)Math.Ceiling((double)N_CARD / row);  //最大行数
        x = 0;y = 0;
        p = i / row; q = i % row;   //i番目のカードの座標(p,q)
        x = (p * (gap + 1) + gap) * width;
        y = (q * (gap + 1) + gap*2) * height;
        return new Vector2(x, -y);
    }

    //カードを捨てる
    public void DisCard()
    {
        foreach(Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }


    //乱数によるfacultyのシャッフル
    private int[] AssignNum(int N_CARD,int T_CARD)
    {
        int[] x= new int[T_CARD];
        int i;
        System.Random rnd = new System.Random(seed++);
        for (i = 0; i < T_CARD; i++)
        {
            x[i] = i;
        }
        int[] y = x.OrderBy(key => Guid.NewGuid()).ToArray();
        return y.Take(N_CARD).ToArray();
    }
}
