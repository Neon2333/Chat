using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using ChatModel;
using Server.DAL.MySQLService;
using System.Data;

namespace Server.BLL
{
    class SvrUserSignIn
    {
        public SvrUserSignIn() { }

        /// <summary>
        /// 执行登录过程
        /// </summary>
        /// <param name="clientConnSocket"></param>
        /// <param name="packageRequestSignIn"></param>
        /// <returns></returns>
        public bool DoSignIn(Socket clientConnSocket, PackageModel packageRequestSignIn)
        {
            try
            {
                //打包实体类
                UserInfoSignIn packageUserSignIn = new UserInfoSignIn();
                if (packageRequestSignIn.Data is UserInfoSignIn)
                {
                    packageUserSignIn = packageRequestSignIn.Data as UserInfoSignIn;
                }
                packageUserSignIn.LoginTime = DateTime.Now;     //登录时间

                //写入DB
                UserInfoSignInServiceMySQL userInfoSignInServiceMySQL = new UserInfoSignInServiceMySQL();
                int operCounts = userInfoSignInServiceMySQL.InsUserInfoSignIn(packageUserSignIn);

                if (operCounts != 1)
                {
                    //写入DB失败
                    return false;
                }
                else
                {
                    //成功写入数据库，将数据echo回客户端（这里只返回2个参数，可根据需要返回其他数据）
                    PackageModel packageResponseSignUp = new PackageModel();
                    packageResponseSignUp.PackageType = PackageModel.PackageTypeDef.ResponseType_SignIn;
                    packageResponseSignUp.Success = true;

                    if (!StartUp.ss.SendDataClient(clientConnSocket, packageResponseSignUp))
                        return false;
                    Console.WriteLine($"{packageUserSignIn.UserName} SignIn succeed..");


                    //给所有客户端更新在线用户列表
                    //从DB中读取登录用户列表返回。客户端通过IP-port的形式创建package-chatMsg
                    //由服务器以IP-port从ServerSocket.connectedClients中取对应连接转发chatMsg
                    DataTable dtClientList = userInfoSignInServiceMySQL.ReadUserInfoSignIn("usrID", "usrName", "usrPortrait");
                    PackageModel packageClientListUpdate = new PackageModel();
                    packageClientListUpdate.PackageType = PackageModel.PackageTypeDef.RequestType_UpdateClientList;
                    packageClientListUpdate.Data = dtClientList;

                    
                    List<Socket> clientsConnSockets = new List<Socket>();
                    var valueEnumerator = StartUp.ss.ConnectedClients.Values.GetEnumerator();
                    while (valueEnumerator.MoveNext())
                    {
                        Socket clientsConnSocket = (valueEnumerator.Current as UserInfoSignIn).ClientConnectSocket;
                        clientsConnSockets.Add(clientsConnSocket);
                    }
                    if (!StartUp.ss.SendMsgClients(clientsConnSockets, packageClientListUpdate))
                        return false;

                    return true;
                }
            }
            catch (NullReferenceException ex)
            {
                return false;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
            catch (SocketException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }



        }

        
    }
}
