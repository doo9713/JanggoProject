﻿using UnityEngine;
using System.Collections;

public class csMoveg_Jang : MonoBehaviour
{
    public GameObject point;
    public GameObject pointkill;
    public GameObject dead;

    Transform obj;

    float speed = 0.0f;
    int tempA = 0, tempB = 0;
    int destA = 0, destB = 0;

    // Update is called once per frame
    void Update()
    {
        if (csMain.check && csMain.player && csMain.g_Jang)
        {
            if (csMain.eat)
            {
                destA = csPointKillSample.moveA;
                destB = csPointKillSample.moveB;
            }
            else
            {
                destA = csPointSample.moveA;
                destB = csPointSample.moveB;
            }

            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            obj = GameObject.Find("(" + destA + "," + destB + ")").transform;
            speed += Time.deltaTime * 5.0f;
            transform.position = Vector3.Lerp(transform.position, obj.position, speed);

            if (transform.position == obj.position)
            {
                csMain.g_coordinates[tempA, tempB] = false;
                csMain.g_coordinates[destA, destB] = true;
                csMain.player = false;
                csMain.check = false;
                csMain.g_Jang = false;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                speed = 0.0f;
            }
        }
    }

    void OnMouseDown()
    {
        if (csMain.player)
        {
            csMain.g_Ja = false;
            csMain.g_Jang = true;
            csMain.g_Sang = false;
            csMain.g_Wang = false;

            var clones = GameObject.FindGameObjectsWithTag("clone");
            foreach (var clone in clones)
                Destroy(clone);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                    if (transform.position == GameObject.Find("(" + i + "," + j + ")").transform.position)
                    {
                        tempA = i;
                        tempB = j;
                    }
            }

            for (int i = -1; i < 2; i += 2)
            {
                if (tempA + i > -1 && tempA + i < 4 && !csMain.g_coordinates[tempA + i, tempB])
                {
                    if (!csMain.r_coordinates[tempA + i, tempB])
                        Instantiate(point,
                            GameObject.Find("(" + (tempA + i) + "," + tempB + ")").transform.position + Vector3.forward * 0.26f,
                            GameObject.Find("(" + (tempA + i) + "," + tempB + ")").transform.rotation);
                    else
                        Instantiate(pointkill,
                            GameObject.Find("(" + (tempA + i) + "," + tempB + ")").transform.position - Vector3.forward * 0.26f,
                            GameObject.Find("(" + (tempA + i) + "," + tempB + ")").transform.rotation);
                }

                if (tempB + i > -1 && tempB + i < 3 && !csMain.g_coordinates[tempA, tempB + i])
                {
                    if (!csMain.r_coordinates[tempA, tempB + i])
                        Instantiate(point,
                            GameObject.Find("(" + tempA + "," + (tempB + i) + ")").transform.position + Vector3.forward * 0.26f,
                            GameObject.Find("(" + tempA + "," + (tempB + i) + ")").transform.rotation);
                    else
                        Instantiate(pointkill,
                            GameObject.Find("(" + tempA + "," + (tempB + i) + ")").transform.position - Vector3.forward * 0.26f,
                            GameObject.Find("(" + tempA + "," + (tempB + i) + ")").transform.rotation);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!gameObject.GetComponent<BoxCollider>().isTrigger)
        {
            int x, y;
            if (csMain.eat)
            {
                x = csPointKillSample.moveA;
                y = csPointKillSample.moveB;
            }
            else
            {
                x = csPointSample.moveA;
                y = csPointSample.moveB;
            }

            if (transform.position == GameObject.Find("(" + x + "," + y + ")").transform.position)
            {
                csMain.g_coordinates[x, y] = false;

                Destroy(gameObject);

                Instantiate(dead,
                     GameObject.Find("(" + (3 - csMain.deadg_Piece) + ",-1)").transform.position,
                     Quaternion.Euler(0, 0, 180));

                csMain.deadg_Piece++;
                if (csMain.deadg_Piece == 3)
                    csMain.deadg_Piece = 0;
            }
        }
    }
}