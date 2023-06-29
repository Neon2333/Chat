2023/6/7
1.现有Message改为UserMessage类，继承自Message类
2.现有ServerSocket改为只负责socket通信的部分
3.ServerSocket类原RecvMsg方法改为RecvSendMsg方法，令增一个RecvMsg方法不含SendMsg

2023/6/8
1.DAL层，增加IUserConnectInfoService/IUserMessageService/IUserSignUpInfoService/
UserSignUpInfoServiceMySQL。具体DB的Service继承接口，试图在后续以简单工厂DataAccess+Reflection
+配置文件的方式实现不同DB的访问。

2023/6/9
经过考虑，决定将UserConnectINfo类中的relatedClient字段删除。在线用户不和其他用户关联。而只在MMessage中
增加UserIDSend,UserIDRecv，从每条消息的角度都记录发送者和接收者。为了安全性，在MMessage中只存储用户ID，
不把整个UserInfo作为字段。
用户发送消息可发送给某个人，也可先多选，然后多发。这样MMessage.UserIDRecv要改成List。

2023/6/10
1.整理思路。将UserXXXXXXInfo的类名修改为UserInfoXXXXXX。Service类也同样修改。
2.写了UserIIUserInfoSignInServiceMySQL类的InsUserConnectInfo、InsUserConnectInfos接口。

2023/6/12
1.TCP沾包：https://blog.csdn.net/m0_37947204/article/details/80490512

6/13
1.将Communication.ServerSocket类作为单纯的通信类。取消收发函数中的异步写法，改为在BLL中的业务类中异步调用收发函数。
DB操作也改为在BLL的业务类中。

6/17
事件总线(未实现)
1.断开要有事件
2.将实体类Model序列化为二进制数据，再反序列化能够得到原本的Model类吗？
所以才用XML作为数据传递媒介？Model->XML->TCP->XML->Model?
https://www.evget.com/article/2011/5/3/16124.html
https://blog.51cto.com/BADAOLIUMANGQZ/6114994
DevExpress 中 GridControl 的数据源DataTable 内容改变后 重新绑定：
```c#
GridControl1.DataSource=dt; //重新绑定
GridView1.PopulateColumns();//这句很重要，没有这句 就不显示
```
* Binding to XML Data:https://docs.devexpress.com/WindowsForms/2388/common-features/data-binding/binding-controls-to-xml-data
https://docs.devexpress.com/WindowsForms/634/controls-and-libraries/data-grid/data-binding

6/20
1.如何解决用XmlSerializer序列化和反序列化一个类, 保存到UTF-8的XML中. 产生的换行符丢失的问题
https://blog.csdn.net/w001162/article/details/1563497?spm=1035.2023.3001.6557&utm_medium=distribute.pc_relevant_bbs_down_v2.none-task-blog-2~default~ESQUERY~Rate-2-1563497-bbs-80179639.264^v3^pc_relevant_bbs_down_v2_opensearchbbsnew&depth_1-utm_source=distribute.pc_relevant_bbs_down_v2.none-task-blog-2~default~ESQUERY~Rate-2-1563497-bbs-80179639.264^v3^pc_relevant_bbs_down_v2_opensearchbbsnew
2.textEdit为什么设置AutoHeight=false，还是不能多行显示？textbox设置Multiline=true就行。
3.完成SerializeHelper.cs，增加obj->xmlstr,xmlstr->obj，obj->xmlfile,xmlfile->obj方法。
但是xml标头是utf-16编码。。。。问题未解决。

6/29
1.因为xml反序列化将PackageModel.data生成了xmlnode，暂时不知道如何生成Model类。所以改为二进制
序列化。但二进制序列化有一个Model类在Client/Server程序集中命名空间不同的问题。