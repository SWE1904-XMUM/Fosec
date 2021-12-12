using System.Text;

namespace Fosec.Utils
{
    public static class StringUtil
    {
        public static string ByteArrayToString(byte[] byteInput)
        {
            //convert byte array to string
            StringBuilder output = new StringBuilder(byteInput.Length);
            for (int i = 0; i < byteInput.Length; i++)
            {
                output.Append(byteInput[i].ToString("X2"));
            }
            return output.ToString();
        }
    }
}