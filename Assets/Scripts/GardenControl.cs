using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenControl : MonoBehaviour
{
    [SerializeField] private GameObject _cropPrefab;
    private GameObject _crop;
    private bool _stateGarden = false;

    public void Plant()
    {
        if (!_cropPrefab)
        {
            Debug.Log("Не указан префаб саженца");
            return;
        }
        if (!_stateGarden)
        {
            _stateGarden = true;
            _crop = Instantiate(_cropPrefab);
            _crop.transform.position = transform.position;
            
            Debug.Log("Вы посадили саженец");
        }
        else
        {
            Debug.Log("Урожай уже посажен");
        }
    }

    public void Collect()
    {
        if (!_crop)
        {
            Debug.Log("Саженца нету");
            return;
        }
        if (_stateGarden)
        {
            if (_crop.GetComponent<CropControl>()._stateCrop)
            {
                _stateGarden = false;
                Destroy(_crop);
                Debug.Log("Вы собрали урожай");
            }
            else
            {
                Debug.Log("Урожай не вырос");
            }
        }
        else
        {
            Debug.Log("Ты думаешь сможешь собрать пустоту?");
        }
    }
}
