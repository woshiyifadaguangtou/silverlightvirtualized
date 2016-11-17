using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace SilverlightApplication1.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ImageService
    {
        [OperationContract]
        public void DoWork()
        {
            // 在此处添加操作实现
            return;
        }
        [OperationContract]
        public  string DownLoad(Uri uri)
        {
            try
            {
               
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(uri);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (System.Exception ex)
            {
                //errorMsg = ex.Message;
            }
            return "";
        }
        [OperationContract]
        public Stream DownLoad1(Uri uri)
        {
            try
            {

                System.Net.WebRequest wReq = System.Net.WebRequest.Create(uri);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                return respStream;
            }
            catch (System.Exception ex)
            {
                //errorMsg = ex.Message;
            }
            return null ;
        }

        // 在此处添加更多操作并使用 [OperationContract] 标记它们
    }
}
