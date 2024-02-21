using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour {

    public GameObject[] characterPrefabs;
    public Text nameInput;
    private GameObject[] characterGameObject;
    private int selectedIndex=0;
    private int length;
	// Use this for initialization
	void Start () {
        length = characterPrefabs.Length;
        characterGameObject = new GameObject[length];
        for(int i=0; i<length; i++)
        {
            characterGameObject[i] = GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation) as GameObject;
        }
        UpdateCharacterShow();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void UpdateCharacterShow()
    {
        characterGameObject[selectedIndex].SetActive(true);
        for(int i=0; i < length; i++)
        {
            if (i != selectedIndex)
            {
                characterGameObject[i].SetActive(false);
            }
        }
    }
    public void OnNextButtonClick()
    {
        selectedIndex++;
        selectedIndex %= length;
        UpdateCharacterShow();
    }
    public void OnPrevButtonClick()
    {
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length - 1;
        }
        UpdateCharacterShow();
    }
    public void OnOkButtonClick()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);//储存选择的角色
        PlayerPrefs.SetString("name", nameInput.text);//储存名字
        //加载下一个界面
    }
}
