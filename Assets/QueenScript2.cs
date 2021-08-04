﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QueenScript2 : MonoBehaviour
{
    private GameObject objectQueen;
    public GameObject queen;
    public GameObject buttonPieces;
    public GameObject buttonLevels;
    public GameObject back2scenes;
    public GameObject back2pieces;
    private GameObject target;
    private int level;
    public AudioSource rightAnswer;
    public AudioSource levelUp;
    private int count_squares = 0;
    Dictionary<string, GameObject> squares = new Dictionary<string, GameObject>();
    private bool squares_introduced = false;

    private void Start()
    {
        introduce27squares();
        count_squares = 0;
        createTarget();
    }

    public void defineLevel_queen(int num)
    {
        level = num;
        beginQueen();
        moveTarget_queen(level);
    }

    private void checkTarget_queen()
    {
        if (queen.transform.position.x == target.transform.position.x && queen.transform.position.z == target.transform.position.z)
        {
            if (level == 2)
            {
                showLevels_queen();
                levelUp.Play(0);
            }
            else if (level == 6)
            {
                levelUp.Play(0);
                showLevels_queen();
            }
            else if (level == 12)
            {
                levelUp.Play(0);
                showLevels_queen();
            }
            else if (level == 19)
            {
                levelUp.Play(0);
                showLevels_queen();
            }
            else if (level == 27)
            {
                levelUp.Play(0);
                showLevels_queen();
            }
            else
            {
                rightAnswer.Play(0);
                level++;
                moveTarget_queen(level);
            }
        }
    }

    private void moveTarget_queen(int levelNum)
    {
        switch (levelNum)
        {
            case 1: // LEVEL I - x1
                queen.transform.position = new Vector3(-0.625f, 0.0f, -4.375f);
                target.SetActive(true);
                target.transform.position = new Vector3(-0.625f, 0.1f, 0.625f);
                break;
            case 2: // LEVEL I - x2
                target.transform.position = new Vector3(-4.375f, 0.1f, 4.375f);
                break;
            case 3: // LEVEL II - x1
                queen.transform.position = new Vector3(-0.625f, 0.0f, -0.625f);
                target.SetActive(true);
                target.transform.position = new Vector3(1.875f, 0.1f, -3.125f);
                break;
            case 4: // LEVEL II - x2
                target.transform.position = new Vector3(1.875f, 0.1f, 4.375f);
                break;
            case 5: // LEVEL II - x3
                target.transform.position = new Vector3(-4.375f, 0.1f, -1.875f);
                break;
            case 6: // LEVEL II - x4
                target.transform.position = new Vector3(4.375f, 0.1f, -1.875f);
                break;
            case 7: // LEVEL III - x1
                queen.transform.position = new Vector3(-1.875f, 0.0f, -0.625f);
                target.SetActive(true);
                target.transform.position = new Vector3(1.875f, 0.1f, -4.375f);
                break;
            case 8: // LEVEL III - x2
                target.transform.position = new Vector3(1.875f, 0.1f, 4.375f);
                break;
            case 9: // LEVEL III - x3
                target.transform.position = new Vector3(4.375f, 0.1f, 1.875f);
                break;
            case 10: // LEVEL III - x4
                target.transform.position = new Vector3(-0.625f, 0.1f, 1.875f);
                break;
            case 11: // LEVEL III - x5
                target.transform.position = new Vector3(-4.375f, 0.1f, -1.875f);
                break;
            case 12: // LEVEL III - x6
                target.transform.position = new Vector3(3.125f, 0.1f, -1.875f);
                break;
            case 13: // LEVEL IV - x1
                queen.transform.position = new Vector3(3.125f, 0.0f, 3.125f);
                target.SetActive(true);
                target.transform.position = new Vector3(3.125f, 0.1f, -4.375f);
                break;
            case 14: // LEVEL IV - x2
                target.transform.position = new Vector3(3.125f, 0.1f, 4.375f);
                break;
            case 15: // LEVEL IV - x3
                target.transform.position = new Vector3(-4.375f, 0.1f, -3.125f);
                break;
            case 16: // LEVEL IV - x4
                target.transform.position = new Vector3(4.375f, 0.1f, -3.125f);
                break;
            case 17: // LEVEL IV - x5
                target.transform.position = new Vector3(4.375f, 0.1f, 0.625f);
                break;
            case 18: // LEVEL IV - x6
                target.transform.position = new Vector3(-3.125f, 0.1f, 0.625f);
                break;
            case 19: // LEVEL IV - x7
                target.transform.position = new Vector3(-0.625f, 0.1f, -1.875f);
                break;
            case 20: // LEVEL V - x1
                queen.transform.position = new Vector3(0.625f, 0.0f, -4.375f);
                target.SetActive(true);
                target.transform.position = new Vector3(-0.625f, 0.1f, -4.375f);
                break;
            case 21: // LEVEL V - x2
                target.transform.position = new Vector3(4.375f, 0.1f, -4.375f);
                break;
            case 22: // LEVEL V - x3
                target.transform.position = new Vector3(4.375f, 0.1f, -0.625f);
                break;
            case 23: // LEVEL V - x4
                target.transform.position = new Vector3(1.875f, 0.1f, -3.125f);
                break;
            case 24: // LEVEL V - x5
                target.transform.position = new Vector3(1.875f, 0.1f, 1.875f);
                break;
            case 25: // LEVEL V - x6
                target.transform.position = new Vector3(-4.375f, 0.1f, 1.875f);
                break;
            case 26: // LEVEL V - x7
                target.transform.position = new Vector3(3.125f, 0.1f, 1.875f);
                break;
            case 27: // LEVEL V - x8
                target.transform.position = new Vector3(3.125f, 0.1f, 4.375f);
                break;
        }
    }

    public void clicked_queen(GameObject queenNum)
    {
        objectQueen = queenNum;
        count_squares = 0;
        verifyPossibilities_bishop(queenNum);
        verifyPossibilities_tower(queenNum, queenNum.transform.position.x, 1);
        verifyPossibilities_tower(queenNum, queenNum.transform.position.z, 2);
        count_squares = 0;
    }

    private void createTarget()
    {
        target = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        target.GetComponent<Renderer>().material.color = Color.red;
        target.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        target.SetActive(false);
    }

    private void verifyPossibilities_tower(GameObject towerNum, float positionAxis, int axis)
    {
        float i = -4.375f;
        while (i < 4.4f)
        {
            if (positionAxis != i)
            {
                showDirections_tower(towerNum, axis, i);
            }
            i = i + 1.25f;
        }
    }

    private void verifyPossibilities_bishop(GameObject queenNum)
    {
        float i = queenNum.transform.position.x;
        float j = queenNum.transform.position.z;
        while (i < 4.375f && j < 4.375f)
        {
            i = i + 1.25f;
            j = j + 1.25f;
            showDirections_bishop(i, j);
        }

        i = queenNum.transform.position.x;
        j = queenNum.transform.position.z;
        while (i > -4.375f && j < 4.375f)
        {
            i = i - 1.25f;
            j = j + 1.25f;
            showDirections_bishop(i, j);
        }

        i = queenNum.transform.position.x;
        j = queenNum.transform.position.z;
        while (i < 4.375f && j > -4.375f)
        {
            i = i + 1.25f;
            j = j - 1.25f;
            showDirections_bishop(i, j);
        }

        i = queenNum.transform.position.x;
        j = queenNum.transform.position.z;
        while (i > -4.375f && j > -4.375f)
        {
            i = i - 1.25f;
            j = j - 1.25f;
            showDirections_bishop(i, j);
        }
    }

    private void introduce27squares()
    {
        while (count_squares < 27)
        {
            count_squares++;
            squares.Add("square" + count_squares, createSquare());
            squares["square" + count_squares].SetActive(false);
        }
        squares_introduced = true;
    }

    private GameObject createSquare()
    {
        GameObject square_aux;
        square_aux = GameObject.CreatePrimitive(PrimitiveType.Plane);
        square_aux.GetComponent<Renderer>().material.color = Color.yellow;
        square_aux.AddComponent<BoxCollider>().enabled = true;
        square_aux.AddComponent<ChangeColor>().enabled = true;
        square_aux.AddComponent<EventTrigger>().enabled = true;

        EventTrigger trigger = square_aux.GetComponent<EventTrigger>();
        EventTrigger.Entry entry_click = new EventTrigger.Entry();
        entry_click.eventID = EventTriggerType.PointerClick;
        entry_click.callback.AddListener((data) => {
            square_aux.GetComponent<ChangeColor>().Yellow();
            Move_queen(square_aux);
        });
        trigger.triggers.Add(entry_click);

        EventTrigger.Entry entry_enter = new EventTrigger.Entry();
        entry_enter.eventID = EventTriggerType.PointerEnter;
        entry_enter.callback.AddListener((data) => {
            square_aux.GetComponent<ChangeColor>().Green();
        });
        trigger.triggers.Add(entry_enter);

        EventTrigger.Entry entry_exit = new EventTrigger.Entry();
        entry_exit.eventID = EventTriggerType.PointerExit;
        entry_exit.callback.AddListener((data) => {
            square_aux.GetComponent<ChangeColor>().Yellow();
        });
        trigger.triggers.Add(entry_exit);

        square_aux.transform.localScale = new Vector3(0.125f, 0.125f, 0.125f);

        return square_aux;
    }

    private void showDirections_tower(GameObject towerNum, int axis, float pos)
    {
        count_squares++;
        squares["square" + count_squares].SetActive(true);
        if (axis == 1)
        {
            squares["square" + count_squares].transform.position = new Vector3(pos, 0.0101f, towerNum.transform.position.z);
        }
        else if (axis == 2)
        {
            squares["square" + count_squares].transform.position = new Vector3(towerNum.transform.position.x, 0.0101f, pos);
        }
    }

    private void showDirections_bishop(float axisX, float axisZ)
    {
        count_squares++;
        squares["square" + count_squares].SetActive(true);
        squares["square" + count_squares].transform.position = new Vector3(axisX, 0.0101f, axisZ);
    }

    public void Move_queen(GameObject queenDirection)
    {
        objectQueen.transform.position = queenDirection.transform.position;
        DeleteSquares_queen();
        checkTarget_queen();
    }

    private void DeleteSquares_queen()
    {
        for (int j = 1; j < 28; j++)
        {
            squares["square" + j].SetActive(false);
        }
    }

    public void beginQueen()
    {
        buttonLevels.SetActive(false);
        back2pieces.SetActive(false);
    }

    public void showLevels_queen()
    {
        buttonLevels.SetActive(true);
        buttonPieces.SetActive(false);
        back2scenes.SetActive(false);
        back2pieces.SetActive(true);
        if (squares_introduced)
        {
            DeleteSquares_queen();
        }
        target.SetActive(false);
        queen.transform.position = new Vector3(-4.375f, 0.0f, 4.375f);
    }

    public void endGame_queen()
    {
        DeleteSquares_queen();
        buttonLevels.SetActive(false);
        queen.SetActive(false);
        buttonPieces.SetActive(true);
        back2scenes.SetActive(true);
        back2pieces.SetActive(false);
        target.SetActive(false);
    }
}
