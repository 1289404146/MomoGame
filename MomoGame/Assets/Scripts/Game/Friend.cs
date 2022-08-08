using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EFriendType
{
    AM=0,
    MR,
    CB,
    TT,
    XG
}
public class Friend : YLBaseMono
{
    public EFriendType friendTypt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("DesFriend");
            Texture texture=YLResourcesManager.Instance.Load<Texture>("UI/"+ (int)friendTypt);
            YLUIManager.Instance.GetPanel<GamePanel>().SetImage(texture);
            YLUIManager.Instance.GetPanel<GamePanel>().SetImage((int)friendTypt);
            User user =YLDataManager.Instance.GetUser("momo");
            if (GameManager.Instance.currentLevel == (int)friendTypt)
            {
                YLDataManager.Instance.GetUser("momo").Friend = GameManager.Instance.currentLevel+1;
            }
            YLDataManager.Instance.UpdateUser("momo", user);
        }
    }
    private IEnumerator DesFriend()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
