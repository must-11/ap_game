using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTitle : MonoBehaviour
{
    public static int N_PLAY = 3;
    public static string[] FACULTY = new string[]{"工学部計数工学科", "医学部医学科", "法学部第1類", "理学部数学科", "経済学部経済学科",
    "教養学部教養学科", "文学部インド哲学科", "農学部獣医学科", "工学部建築学科"};
    public static int[] WINNER, OFFER;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int get_n(){
		return N_PLAY;
	}
}