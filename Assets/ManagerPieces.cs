﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPieces : MonoBehaviour
{
    public GameObject knight;
    public KnightScript knightScript;
    public GameObject tower;
    public TowerScript towerScript;
    public GameObject bishop;
    public BishopScript bishopScript;
    public GameObject king;
    public KingScript kingScript;
    public GameObject queen;
    public QueenScript queenScript;

    public void initiateKnight()
    {
        knight.SetActive(true);
        knightScript.showLevels_knight();
    }

    public void initiateTower()
    {
        tower.SetActive(true);
        towerScript.showLevels_tower();
    }

    public void initiatePawn()
    {

    }

    public void initiateKing()
    {
        king.SetActive(true);
        kingScript.showLevels_king();
    }

    public void initiateQueen()
    {
        queen.SetActive(true);
        queenScript.showLevels_queen();
    }

    public void initiateBishop()
    {
        bishop.SetActive(true);
        bishopScript.showLevels_bishop();
    }
}
