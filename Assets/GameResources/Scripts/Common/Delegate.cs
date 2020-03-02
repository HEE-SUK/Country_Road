using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CallBack();
public delegate void IndexCallBack(int _index);

public delegate void EndPosAction(BlockController roadPieceController);

public delegate SectionInfo ScrollEndDataSetting();

public delegate void ActiveCallBack(bool active);

public delegate void EnemyAttackCallBack(ZombieInfo zombieInfo);
public delegate void EnemyDieCallBack(EnemyController enemy);