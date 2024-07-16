namespace Datos.DTOs
{
    public class MsgServerMD
    {
        public bool success { get; set; }
        public object  data { get; set; }
        public int  status { get; set; }


        public static MsgServerMD errorMsg(int statusCode, string msg) { 
            return new MsgServerMD() { status = statusCode, data = new{msg = msg }, success = false };   
        }
        public static MsgServerMD resulMsg(int statusCode, object data, bool noCont = false)
        {
            return new MsgServerMD() { status = statusCode, data = data, success = false };
        }

    }
}
