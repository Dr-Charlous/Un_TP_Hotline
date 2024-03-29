using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] CharactersWeaponnary _cW;
    [SerializeField] WeaponsLong _wLong;
    [SerializeField] WeaponsShort _wShort;

    [SerializeField] TextMeshProUGUI _textUiBullet;
    [SerializeField] TextMeshProUGUI _textUi;

    void Update()
    {
        if (_wLong.isActiveAndEnabled)
            _textUiBullet.text = _wLong.Bullets.ToString();
        else
            _textUiBullet.text = "1";

        if (_cW.WeaponData != null)
            _textUi.text = _cW.WeaponData.name;
    }
}
