using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Client.Communication
{
    [Serializable]
    public class PackageType
    {
        public enum PackageTypeDef { ChatMessageType=00, 
                                     RequestType_R=10, 
                                     RequestType_C=11, 
                                     RequestType_D=12, 
                                     RequestType_U=13, 
                                     ResponseType=20,
                                     FileTransType_Send=30, 
                                     FileTransType_Recv=31
        }

        public PackageType()
        {
        }

    }
}
