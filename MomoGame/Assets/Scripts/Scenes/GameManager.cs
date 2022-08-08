using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Ready,
    Playing,
    End,
}
public class GameManager : YLUnitySingleton<GameManager>,IBaseManager
{
    public int currentLevel;
    public Texture image;
    public void Initialize()
    {
        HP = 1;
        Coin = 0;
        m_state = GameState.Playing;
        GameObject Level = YLResourcesManager.Instance.Load<GameObject>("Game/LevelItem" + currentLevel);
        GameObject levelObj = GameObject.Instantiate(Level);
        levelObj.name = Level.name;
        image = YLResourcesManager.Instance.Load<Texture>("UI/" + currentLevel);
        YLUIManager.Instance.OpenPanel<GamePanel>();
        Debug.Log(Level.name);
    }
    private GameState m_state = GameState.Ready;
    public int HP { get; set; }
    public int Coin { get; set; }
    public GameState state
    {
        get { return m_state; }
        set { m_state = value; }
    }
    public void Deinitialize()
    {
        m_state = GameState.End;
    }




}
