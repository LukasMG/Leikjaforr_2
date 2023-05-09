using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManage : MonoBehaviour
{
    float boxX = 3.5f; // bý til breytur og array
    float boxY = 3.5f;
    public GameObject canvas;
    public pictureChange number;
    public Sprite blank;
    public int currentPuzzleIndex;

    [SerializeField]
    private PuzzleLogic[] puzzleArray;
    [SerializeField]
    private Sprite[] spriteArray;
    [SerializeField]
    private GameObject[] swordArray;
    [SerializeField]
    private GameObject[] potionArray;
    [SerializeField]
    private GameObject[] skullArray;

    private void Start() // byrja á því að randomize-a öll púsl
    {
        randomizePuzzles(swordArray, 0, puzzleArray[0]);
        randomizePuzzles(potionArray, 1, puzzleArray[1]);
        randomizePuzzles(skullArray, 0, puzzleArray[2]);
    }

    public bool AllPuzzlesFinished(){
        bool flag = false;
        for(int i = 0; i < puzzleArray.Length; i++){ // checka hvort öll púsl eru búinn
            if (!puzzleArray[i].IsCorrect()){ // ef púsl er ekki búið
                flag = true; // þá er flag breyt
            }
        }

        if (!flag){ // ef flag er enþá false, eða ekkert púsl rangt, þá greinist það hér og ég skila true
            return true;
        }
        else{ // annars skila ég false
            return false;
        }
    }

    public void Interact(Vector2 position){ // hér bý ég til notkunarfallið
        if (isNearSubmitionBox(position.x,position.y)){ // gái hvort ég sé nálægt exit kassanum
            if (AllPuzzlesFinished()) //ef ég er það þá checkar það hvort púslinn eru búinn
            {
                //Bæta við loka myndbandkeyrslu
                SceneManager.LoadScene(2); // ef það er búið þá fer ég yfir á nærstu scene-u
            }
        }else{ // ef ég er ekki nálægt púsli þá hlýtur character-inn að vera reyna að nota púsl turn
            for (int i = 0; i < puzzleArray.Length; i++) // fer í gegnum öll púsl
            {
                if (Mathf.Abs(puzzleArray[i].gameObject.transform.position.x - position.x) <= 1.0f && Mathf.Abs(puzzleArray[i].gameObject.transform.position.y - position.y) <= 1.0f) //check hvort ég sé nógu nálægt
                {
                    startPuzzleUI(i); // ef ég er það þá sendi ég hvaða púsl ég er nálægt og kveikji á UI skjá
                }
            }
        }
    }

    public bool isNearSubmitionBox(float playerX, float playerY){ // bý til fallið sem skoðar hvort hann sé nálægt exit kassa
        if (playerY >= boxY && Mathf.Abs(playerX - boxX) <= 0.5f) // gái hvort hann sé nógu nálægt kassanum
        { // ef hann er það þá skila ég True
            return true;
        }
        else
        { //annars skila ég false
            return false;
        }
    }

    public void startPuzzleUI(int i){
        canvas.SetActive(true); // kveikji á UI graphic
        puzzleArray[i].setValue(puzzleArray[i].playerValue); // stilli þannig ef notandi er búinn að láta inn númer þá er það stillt strax
        if (puzzleArray[i].getValue() > 0) // ef það er búið að láta inn value er það greint hér
        {
            number.changePicture(spriteArray[puzzleArray[i].getValue()-1]); // lætt breyta myndinni og læt hvaða value er verið að nota
        }
        currentPuzzleIndex = i; // Geymi index af pússlinu sem ég er á
    }

    public void randomizePuzzles(GameObject[] array, int check, PuzzleLogic thePuzzle) //fall sem randomize-ar púslinn
    {
        float lengthToEnable; //bý til breytu

        if (check == 0) // gá hvort það sé hálft array eða fullt array
        {
            lengthToEnable = Random.Range(1, 10); // ef fullt þá er range-ið stærra
        }
        else
        {
            lengthToEnable = Random.Range(1, 6); // annars er random-ið minna
        }

        for(int i = 0; i < lengthToEnable; i++) { // fer síðan í geggnum magnið af hlutum sem eiga að vera til staðar á leiksvæði
            array[i].SetActive(true); //og kveikji á þeim
        }
        thePuzzle.setSecretValue((int) lengthToEnable); // síðan lætt ég secret value vera jafnt hlutunum sem eru birtir
    }
    

    public void endPuzzle() // bý til fall sem lýkur UI keyrslu
    {
        number.changePicture(blank); // lætt myndina vera auða
        currentPuzzleIndex = -1; // lætt puzzleindex-ið mitt vera jafnt pússli sem er ekki til, bara til örygiss
        canvas.SetActive(false); // slekk á UI graphics
    }

    public void clickedButton1() // gá hvort ég var að ýtta á UI takka 1
    {
        puzzleArray[currentPuzzleIndex].setValue(1); // stilli value til að samsvara hvaða value takkinn inniheldur
        number.changePicture(spriteArray[0]); //Breyti mynd í UI sem samsvarar hvaða value var ýtt á
    }
    public void clickedButton2()// gá hvort ég var að ýtta á UI takka 2
    {
        puzzleArray[currentPuzzleIndex].setValue(2);// stilli value til að samsvara hvaða value takkinn inniheldur
        number.changePicture(spriteArray[1]);//Breyti mynd í UI sem samsvarar hvaða value var ýtt á
    }
    public void clickedButton3()// gá hvort ég var að ýtta á UI takka 3
    {
        puzzleArray[currentPuzzleIndex].setValue(3);// stilli value til að samsvara hvaða value takkinn inniheldur
        number.changePicture(spriteArray[2]);//Breyti mynd í UI sem samsvarar hvaða value var ýtt á
    }
    public void clickedButton4()// gá hvort ég var að ýtta á UI takka 4
    {
        puzzleArray[currentPuzzleIndex].setValue(4);// stilli value til að samsvara hvaða value takkinn inniheldur
        number.changePicture(spriteArray[3]);//Breyti mynd í UI sem samsvarar hvaða value var ýtt á
    }
    public void clickedButton5()// gá hvort ég var að ýtta á UI takka 5
    {
        puzzleArray[currentPuzzleIndex].setValue(5);// stilli value til að samsvara hvaða value takkinn inniheldur
        number.changePicture(spriteArray[4]);//Breyti mynd í UI sem samsvarar hvaða value var ýtt á
    }
    public void clickedButton6()// gá hvort ég var að ýtta á UI takka 6
    {
        puzzleArray[currentPuzzleIndex].setValue(6);// stilli value til að samsvara hvaða value takkinn inniheldur
        number.changePicture(spriteArray[5]);//Breyti mynd í UI sem samsvarar hvaða value var ýtt á
    }
    public void clickedButton7()// gá hvort ég var að ýtta á UI takka 7
    {
        puzzleArray[currentPuzzleIndex].setValue(7);// stilli value til að samsvara hvaða value takkinn inniheldur
        number.changePicture(spriteArray[6]);//Breyti mynd í UI sem samsvarar hvaða value var ýtt á
    }
    public void clickedButton8()// gá hvort ég var að ýtta á UI takka 8
    {
        puzzleArray[currentPuzzleIndex].setValue(8);// stilli value til að samsvara hvaða value takkinn inniheldur
        number.changePicture(spriteArray[7]);//Breyti mynd í UI sem samsvarar hvaða value var ýtt á
    }
    public void clickedButton9()// gá hvort ég var að ýtta á UI takka 9
    {
        puzzleArray[currentPuzzleIndex].setValue(9);// stilli value til að samsvara hvaða value takkinn inniheldur
        number.changePicture(spriteArray[8]);//Breyti mynd í UI sem samsvarar hvaða value var ýtt á
    }
}