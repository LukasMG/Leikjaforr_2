using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pictureChange : MonoBehaviour
{
    private Image current; // bý til breytu

    private void Start()
    {
        current = this.GetComponent<Image>(); //næ í núverandi mynd
    }

    public void changePicture(Sprite newPic) // fæ inn nýja mind sem á að verða að núverandi mynd
    {
        current.sprite = newPic; //breyti myndinni
    }
}
