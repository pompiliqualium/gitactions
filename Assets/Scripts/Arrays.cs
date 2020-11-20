using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{
    public int [][] JaggedArray=new int[5][];

    public void FillArray()
    {
        for (int i = 0; i < JaggedArray.Length; i++)
        {
            JaggedArray[i]=new int[i+7];
        }
    }

    public void ShowArray()
    {
        for (int i = 0; i < JaggedArray.Length; i++)
        {
            for (int j = 0; j < JaggedArray[i].Length; j++)
            {
                Debug.Log(JaggedArray[i][j]);
            }
        }
    }
    
    
    private void Start()
    {
        FillArray();
        ShowArray();
    }
}
