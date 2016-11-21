﻿using UnityEngine;
using System.Collections;

public class csPointKill : MonoBehaviour
{
    public static int moveA;
    public static int moveB;

    void OnMouseDown()
    {
        /* 게임 오브젝트의 위치 검색 */
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
                if ((transform.position + Vector3.forward * 0.26f) == GameObject.Find("(" + i + "," + j + ")").transform.position)
                {
                    moveA = i;
                    moveB = j;
                }
        }

        csMain.move = true;
        csMain.eat = true;

        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
            Destroy(clone);
    }
}
