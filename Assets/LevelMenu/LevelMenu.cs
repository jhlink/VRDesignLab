﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelMenu : MonoBehaviour
{
  public List<string> LevelNames;
  public GameObject itemPrefab;
  public GameObject clickDelegate;
  public string clickCallback;

  // Use this for initialization
  void Start()
  {
    Vector3 position = gameObject.transform.position;
    int index = 0;
    const float itemHeight = .15f;
    int cnt = LevelNames.Count;
    float startY = position.y;

    foreach (string name in LevelNames)
    {
      position.y = startY + ((cnt - index) * itemHeight);
      GameObject item = Instantiate(itemPrefab, position, Quaternion.identity) as GameObject;

      item.transform.parent = gameObject.transform;

      LevelMenuItem menuItem = item.GetComponent<LevelMenuItem>() as LevelMenuItem;

      menuItem.SetupItem(name, index++, this);
    }
  }

  public void ButtonWasClicked(int buttonIndex)
  {
    clickDelegate.SendMessage(clickCallback, buttonIndex, SendMessageOptions.DontRequireReceiver);

    // hide the menu
    gameObject.SetActive(false);
  }

}
