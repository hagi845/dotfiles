using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoTestApp
{
    /// <summary>
    /// アプリケーションコードで発生および処理する例外の基底クラス
    /// </summary>
    public class AppException : Exception
    {
        public AppException(string msg) : base(msg) { }
        public AppException(string msg, Exception ex) : base(msg, ex) { }
    }
}
