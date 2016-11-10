﻿using UnityEngine;
using System.Collections;

public class csMain : MonoBehaviour
{
    public static bool player = true;       // true is player1
                                            // false is player2
    public static bool check = false;       // move check
    public static bool[,] coordinates = new bool[4, 3];
    public static bool[,] r_coordinates = new bool[4, 3];
    public static bool[,] g_coordinates = new bool[4, 3];

    /* check all piece clicked */
    public static bool g_Jang = false;
    public static bool g_Sang = false;
    public static bool g_Wang = false;
    public static bool g_Ja = false;

    public static bool r_Jang = false;
    public static bool r_Sang = false;
    public static bool r_Wang = false;
    public static bool r_Ja = false;

    /* check eat */
    public static bool eat = false;     // ture is eat
                                        // false is not eat

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                coordinates[i, j] = false;
                r_coordinates[i, j] = false;
                g_coordinates[i, j] = false;
            }    
        }

        /* 초록말에 대한 위치지정 변수 */
        Transform g_wang = GameObject.Find("g_Wang").transform;
        Transform g_sang = GameObject.Find("g_Sang").transform;
        Transform g_jang = GameObject.Find("g_Jang").transform;
        Transform g_ja = GameObject.Find("g_Ja").transform;

        /* 빨강말에 대한 위치지정 변수 */
        Transform r_wang = GameObject.Find("r_Wang").transform;
        Transform r_sang = GameObject.Find("r_Sang").transform;
        Transform r_jang = GameObject.Find("r_Jang").transform;
        Transform r_ja = GameObject.Find("r_Ja").transform;

        /* 초록말 위치지정 */
        g_wang.position = GameObject.Find("(0,1)").transform.position;
        g_sang.position = GameObject.Find("(0,2)").transform.position;
        g_jang.position = GameObject.Find("(0,0)").transform.position;
        g_ja.position = GameObject.Find("(1,1)").transform.position;

        coordinates[0, 0] = true;
        coordinates[0, 1] = true;
        coordinates[0, 2] = true;
        coordinates[1, 1] = true;

        g_coordinates[0, 0] = true;
        g_coordinates[0, 1] = true;
        g_coordinates[0, 2] = true;
        g_coordinates[1, 1] = true;

        /* 빨강말 위치지정 */
        r_wang.position = GameObject.Find("(3,1)").transform.position;
        r_sang.position = GameObject.Find("(3,0)").transform.position;
        r_jang.position = GameObject.Find("(3,2)").transform.position;
        r_ja.position = GameObject.Find("(2,1)").transform.position;

        coordinates[3, 0] = true;
        coordinates[3, 1] = true;
        coordinates[3, 2] = true;
        coordinates[2, 1] = true;

        r_coordinates[3, 0] = true;
        r_coordinates[3, 1] = true;
        r_coordinates[3, 2] = true;
        r_coordinates[2, 1] = true;
    }
}