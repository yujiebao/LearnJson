using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 使用JsonUtility反序列化
        string path = Application.persistentDataPath + "/Test.json";
        string jsonData = File.ReadAllText(path);
        // Test t1 = JsonUtility.FromJson(jsonData, typeof(Test)) as Test;
        Test t1 = JsonUtility.FromJson<Test>(jsonData);
        #endregion

        #region 注意
        //1.JsonUtility无法直接读取数据集合(数组)     通过包裹在一个类中来实现读取

        //2.文本编码格式需要使用UTF-8格式，否者无法加载
        #endregion

        #region 总结
        //1.必备知识点-File存读字符串的方法 ReadAllText相WriteAllText
        //2.Jsonutlity提供的序列化反序列化方法ToJson和FromJson
        //3.自定义类需要加上序列化特性[system.seria11zable]
        //4.私有保护成员需要加上[serializefield]
        //5.Jsonutlity不支持字典
        //6.Jsonutlity不指直接将数据反序列化为数据集合
        //7.Json文档编码格式必频UTF-8
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
