﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class CollectionUtil
{
    public static T[] ShuffleArray<T>(T[] array)
    {
        T[] dataArray = array;
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < dataArray.Length; ++index)
        {
            random1 = UnityEngine.Random.Range(0, dataArray.Length);
            random2 = UnityEngine.Random.Range(0, dataArray.Length);

            tmp = dataArray[random1];
            dataArray[random1] = dataArray[random2];
            dataArray[random2] = tmp;
        }

        return dataArray;
    }


    public static List<T> ShuffleList<T>(List<T> list)
    {
        List<T> dataList = list;
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < dataList.Count; ++index)
        {
            random1 = UnityEngine.Random.Range(0, dataList.Count);
            random2 = UnityEngine.Random.Range(0, dataList.Count);

            tmp = dataList[random1];
            dataList[random1] = dataList[random2];
            dataList[random2] = tmp;
        }
        return dataList;
    }
}
