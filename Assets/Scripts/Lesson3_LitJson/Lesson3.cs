using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

public class Student2
{
    public string name;
    public int age;
    public Student2(string name, int age)
    {
        this.name = name;
        this.age = age; 
    }

    public Student2()
    {
        
    }
}
public class Test2
{
    public string name ;
    public int age ;
    public double height;
    public bool sex;
    public int[] ids;
    public List<int> ids2;

    public Dictionary<string, string> dic = new Dictionary<string, string>();
    public Dictionary<string, string> dic2 = new Dictionary<string, string>();
    public Student2 student;
    public List<Student2> students = new List<Student2>();
    private int privateI;
    protected int protectedI;
    public Test2()
    {

    }
    
    public Test2(string name,int age, double height, bool sex, int[] ids, List<int> ids2, Dictionary<string, string> dic, Dictionary<string, string> dic2, Student2 student, List<Student2> students, int privateI, int protectedI)
    {
        this.name = name;
        this.age = age;
        this.height = height;
        this.sex = sex;
        this.ids = ids;
        this.ids2 = ids2;
        this.dic = dic;
        this.dic2 = dic2;
        this.student = student;
        this.students = students;
        this.privateI = privateI;
        this.protectedI = protectedI;
    }

    public void show()
    {
        Debug.Log("name:" + name + " age:" + age + " height:" + height + " sex:" + sex + " ids:" + ids + " ids2:" + ids2 + " dic:" + dic + " dic2:" + dic2 + " student:" + student + " students:" + students + " privateI:" + privateI + " protectedI:" + protectedI);
    }
}

public class RoleData
{
    public int hp;
    public int speed;
    public int volume;
    public string resName;
    int scale;
}
public class Lesson3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 LitJson是什么
        //它是一个第三方库，用于处理json的序列化和反序列化
        //LitJson是c#编写的，体积小、速度快、易于使用
        //它可以很容易的嵌入到我们的代码中
        //只需要将LitJson代码拷贝到工程中即可
        #endregion

        #region 知识点二 LitJson的使用
        //官网前往Github下载  将代码拷贝到工程中即可
        #endregion

        #region 知识点三 使用LitJson序列化
        //方法：
        // JsonMapper.ToJson(对象)
        Test2 test = new Test2
        ("张三", 18, 1.8, true, 
        new int[] { 1, 2, 3 }, new List<int>() { 1, 2, 3 }, 
        new Dictionary<string, string>() { { "a", "1" }, { "b", "2" } }, 
        null, 
        new Student2("张三",18), 
        new List<Student2>{new Student2("ss",4)}, 5, 0);

        string jsonStr = JsonMapper.ToJson(test);
        File.WriteAllText(Application.persistentDataPath + "/Lesson3.json", jsonStr); 
        print(Application.persistentDataPath); 

        //注意:
        //1.相对JsonUtlity不需要加特性
        //2.不能序列化私有变量
        //3.支持字典类型,字典的键 建议都是字符串 因为 Json的特点 Json中的键会加上双引
        //4.需要引用LitJson命名空间
        //5.LitJson可以准确保存null类型
        #endregion

        #region 知识点四 使用LitJson反序列化
        //方法：
        //1.JsonMapper.ToObject(json字符串)
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/Lesson3.json");
        // JsonData 是LitJson提供的一个类对象 可以用键值对的形式去访问其中数据
        JsonData data = JsonMapper.ToObject(jsonStr);    //返回一个JsonData对象
        print(data["name"]);
        print(data["age"]);

        //2.通过泛型转换
        Test2 t2 = JsonMapper.ToObject<Test2>(jsonStr);
        print(t2);
        t2.show();
        //注意 ：
        //1.类结构需要无参构造函数，否则反序列化时报错
        //2.字典虽然支持 但是键在使用为数值时会有问题 需要使用字符串类型
        #endregion

        #region 注意事项
        //1.LitJson可以直接读取数据集合(数组) 
        // jsonStr = File.ReadAllText(Application.persistentDataPath + "/Array.json");
        // List<RoleData> roleDataList = JsonMapper.ToObject<List<RoleData>>(jsonStr);
        // foreach (var item in roleDataList)
        // {
        //     print(item.hp);
        // }
        // jsonStr = File.ReadAllText(Application.persistentDataPath + "/Dic.json");
        // Dictionary<string, int> roleDataDic = JsonMapper.ToObject<Dictionary<string, int>>(jsonStr);
        // foreach (var item in roleDataDic)
        // {
        //     print(item.Key);
        //     print(item.Value);
        // }

        //2.文件编码格式是UTF-8格式，否者无法加载
        #endregion

        #region 总结
        //1.LitJson提供的序列化反序列化方法 JsonMapper.ToJson和ToObject
        //2.LitJson无需加特性
        //3.LitJson不支持私有变量
        //4.LitJson支持字典序列化反序列化
        //5.LitJson可以直接将数据反序列化为数据集合
        //6.LitJson反序列化时 自定义类型需要无参构造
        //7.Json文档编码格式必须是UTF-8
        #endregion

        #region JsonUtility和LitJson的异同
        #region 相同点 
        //1.他们都是用于Json的序列化反序列化
        //2.Json文档编码格式必须是UTF-8
        //3.都是通过静态类进行方法调用
        #endregion

        #region 不同点
        //1.Jsonutlity是Unity自带，LitJson是第三方需要引用命名空间
        //2.Jsonutlity使用时自定义类需要加特性，Litison不需要
        //3.Jsonutlity支持私有变量(加特性)，LitIson不支持
        //4.Jsonutlity不支持字典,LitJson支持(但是健只能是字符串)
        //5.Jsonutlity不能直接将数据反序列化为数据集合(数组字典)，LitJson可以
        //6.Jsonutlity对自定义类不要求有无参构造，LitJson需要
        //7.Jsonutlity存储空对象时会存储默认值而不是null，LitJson会存null
        #endregion
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
