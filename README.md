# Country_Road
좀비트럭: Contry Road - 모바일 하이퍼 캐주얼게임
플랫폼: Android, IOS
## 팝시클 8비트 합작 프로젝트 - Slack 연동 ver : Notification 확인가능

사용엔진버전: Unity2019.3.0f5

언어: C#

게임 default 해상도: 1080*1920


### 이슈 작성 및 플리퀘 올리는 순서

이슈는 크게 잡지않기 ex) 하루에 2개 가능한 정도의 볼륨으로

브랜치 생성
```
git checkout -b feature/이슈넘버
```

푸시 작성
```
git status
git add .
git status
git commit -m "커밋 메세지"
git push origin feature/이슈넘버
```

작업하기 전에 항상 develop에 가서 pull 받기


### Prefab 활용
작업하이라키 겹칠떄는 Prefab으로 나눠서 세분화해서 작업하기


### 변수명
1. 변수명은 camelCase로 작성합니다.

2. 명시적으로 접근자이름을 작성합니다.
```C#
int a = 0;  --- X

private a = 0; --- O
```

3. memberingOrder는 property -> public -> protected -> private 순으로 따릅니다.
```C#
public int testObjectOne = 0;

protected int testObjectTwo = 0;

private int testObjectThree = 0;
```

4. public을 지양하기위해 [SerializedField]를 사용합니다.
```C#
public int testObjectOne = 0; --- X

[SerializedField]
private int testObjectThree = 0; --- O
```


### 함수명

함수명은 파스칼케이스로 작성합니다.

함수 블록은 c#의 룰을 따라 줄바꿈한 형태로 작성합니다.
```C#
private void TestObject()
{
    if(조건문)
    {
        코드작성
    }
}
```


### 클래스

클래스명은 파스칼케이스로 작성합니다.
```C#
public class TestClass : MonoBehaviour
{
    코드작성
}
```


### Enum과 interface

enum의 경우에는 전체를 대문자로 작성하고, 제목은 _(언더바)를 사용하지 않습니다.

interface는 카멜케이스로 작성하되 뒤에는 항상 앞에 I가 붙습니다.

노출성을 고려하여 접근제어자는 자유롭게 작성합니다.

```C#
public enum TESTTYPE
{
    ONE,
    TWO,
    THREE,
}

public interface ITestCase
{
    public void TestFunc();
}
```


### delegate

모든 델리게이트는 Delegate.cs에 작성합니다.


### 주석

주석은 기능마다, 즉 함수마다 간략하게 작성하되 불필요하다면 생략도 가능, 주로 public함수에 작성합니다.
```C#

// 기능설명 주석
public test()
{
    // 필요하면 디테일한 설명
}
```


### FSM 유한상태머신

게임 플로우, 좀비, 자동차에 적용이 가능하면 하되 불필요하면 과감하게 사용하지 않기


### singleton / monosingleton 활용

singleton은 하이라키상에 존재하면 안된다.
하지만 monoBehaiviour가 필요한 singleton은 monosinglton을 사용해서
Resources/Prefab/Singleton 폴더에 매니저 프리팹을 만들자.


### 프로젝트,에셋 파일명

폴더 및 리소스는 전부 파스칼로 작성합니다.

```
Scene
    ㄴIngame
    ㄴOutgame
script
    ㄴPlayer.cs
    ㄴJoyPad.cs
Resource
    ㄴImage.jpg
```

프로젝트는 크게 이렇게 4개로 구분해서 관리한다.
```
GameResources
QuickSheet
Resources
ThirdParty(에셋관련)
```


### Scene

이번 프로젝트는 모든 게임 플로우를 한씬에서 관리합니다.

SplashScene
LoadingScene(추후에 어떻게할지 생각)
GameScene


### 하이라키 오브젝트

오브젝트명은 파스칼케이스로 작성
```
World
ㄴPlayer
ㄴEnemy
UI
ㄴJoyPad
```
