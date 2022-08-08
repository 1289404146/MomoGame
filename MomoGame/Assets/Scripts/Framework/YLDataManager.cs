using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLDataManager : YLUnitySingleton<YLDataManager>, IBaseManager
{
    private Dictionary<string, User> userDict;

    public void Initialize()
    {
        userDict = new Dictionary<string, User>();
    }
    private void Start()
    {
        User user = new User();
        user.Username = "momo";
        user.Coin = 100;
        user.Friend = 0;
        user.Level = 1;
        AddUser(user.Username, user);
    }
    public void AddUser(string str,User user)
    {
        if (!userDict.ContainsKey(user.Username))
        {
            userDict[user.Username] = user;
        }
    }
    public void RemoveUser(string str)
    {
        if (userDict.ContainsKey(str))
        {
            userDict.Remove(str);
        }
    }
    public void UpdateUser(string str,User user)
    {
        if (userDict.ContainsKey(str))
        {
            userDict[str]=user;
        }
    }
    public User GetUser(string str)
    {
        if (userDict.ContainsKey(str))
        {
            return userDict[str];
        }
        return null;
    }
    public void Deinitialize()
    {
        userDict.Clear();
    }
}
