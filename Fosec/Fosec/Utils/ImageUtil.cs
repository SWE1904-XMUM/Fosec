using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fosec.Utils
{
    public static class ImageUtil
    {
        public static string GetBase64PathByByteArray(object byteArr)
        {
            if(byteArr.GetType() != typeof(System.DBNull)) {
                return @"data:image/png;base64," + Convert.ToBase64String((byte[])byteArr);
            }
            return @"/Resources/Image/defaultProfileImage.png";
        }
    }
}