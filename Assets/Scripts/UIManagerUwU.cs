using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerUwU : MonoBehaviour
{
    [SerializeField]
    private Image _liveImg;
    [SerializeField]
    private Sprite[] _liveSprites;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateLives(int nyawa)
    {
        _liveImg.sprite = _liveSprites[nyawa];
    }
}
