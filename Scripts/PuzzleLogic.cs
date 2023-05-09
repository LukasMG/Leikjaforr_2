using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLogic : MonoBehaviour
{
    public int puzzleID; // bý til breytur
    public int playerValue;
    public int secretValue;
    public GamaManage gamemanager;

    public bool IsCorrect(){ // bý til fallið sem sér hvort núverandi tala sé rétt
        if (playerValue == secretValue) // gá hvort þær séu eins
        {
            return true; // ef hún er eins þá skila ég true
        }
        else{ //annars skila ég false
            return false;
        }
    }

    public void setValue(int value) // Set fall fyrir playerValue
    {
        playerValue = value;
    }

    public int getValue() // get fall fyrir playervalue
    {
        return playerValue;
    }

    public void setSecretValue(int value) // set fall fyrir secret value
    {
        secretValue = value;
    }
}
