using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class BunsTop : ItemBase
{
    [SerializeField, Tooltip("積まれているアイテム")]
    List<ItemData> _stackedItem = new();

    private protected override void Start()
    {
        base.Start();
    }

    private protected override void Update()
    {
        base.Update();
    }


    void CheckSandwitch()
    {
        //すぐ下のアイテムが上のバンズだったら消す
        int subTotal = 0;  //アイテム数小計
        //下に続いているセルのStateを取得する
        //挟んでいるアイテムを数えていく
        //下のバンズが見つかったら探すのをやめる。アイテムの数に応じてスコアを加算する
        subTotal = 0;   //小計をリセットする
    }


    public override void OnStacked()
    {
        //積まれた
        CheckSandwitch();
    }

}
