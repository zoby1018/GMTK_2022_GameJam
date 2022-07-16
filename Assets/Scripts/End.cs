using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class End : MonoBehaviour
{

    PlayerData _player;
    [SerializeField] TextMeshProUGUI _endingText;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerData>();
        _endingText.text = _player.ending_dialogue[_player.SetEnding()];   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
