using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{

    private float _currentHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Image _fillImage;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _fillImage.fillAmount = Mathf.Lerp(_fillImage.fillAmount, _currentHealth / _maxHealth, Time.deltaTime * 10f);
    }


    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
    }
}
