using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    public int faculty;
    static int seed = Environment.TickCount;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnClick() 
    {
        SceneMain.TMP[SceneMain.PLAYER, faculty] = 1;
        SceneMain.PLAYER += 1;
        Debug.Log(SceneMain.PLAYER);
    }

    //カード図面の設定
    Image image;
    public Sprite[] faces;
    public Sprite cardBack;

    public void ToggleFace(bool showFace)
    {
        if (showFace)
        {
            image.sprite = faces[faculty];
        }
        else
        {
            image.sprite = cardBack;
        }
    }

    public void SetFace(int number)
    {
        if (number < 0)
        {
            ToggleFace(false);
        }
        else
        {
            faculty = number;
            ToggleFace(true);
        }
    }

    //カードサイズの設定

    public void Resize(float scale)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = rectTransform.sizeDelta * scale;
    }

    public float ResizeHeight(float width)
    {
        //widthにあわせてリサイズする
        //戻り値はheight
        RectTransform rectTransform = GetComponent<RectTransform>();
        float oldwidth = rectTransform.sizeDelta.x;
        Resize(width / oldwidth);
        return rectTransform.sizeDelta.y;
    }


    //乱数によるfacultyの割当(未使用,CardAreaで定義)
    private int AssignNum()
    {
        int x;
        System.Random rnd = new System.Random(seed++);
        x = rnd.Next(SceneMain.T_CARD);
        return x;
    }
}