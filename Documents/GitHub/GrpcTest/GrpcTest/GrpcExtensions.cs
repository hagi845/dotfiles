using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoTestApp
{
    public static class GrpcExtensions
    {
        /// <summary>
        /// 例外オブジェクトから GRPC Trailer を取得します
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static void HandleRpcTrailers(this AggregateException ex, Func<Metadata, bool> handler)
            => ex.Handle<RpcException>(ex2 => handler(ex2.Trailers));

        /// <summary>
        /// 例外オブジェクトから RpcException を探します。
        /// </summary>
        /// <param name="aex"></param>
        /// <returns></returns>
        public static int Handle<T>(this AggregateException aex, Func<T, bool> handler)
        {
            int count = 0;
            aex.Handle(ex =>
            {
                switch (ex)
                {
                    case T rex:
                        count++;
                        return handler(rex);
                }
                return false;
            });
            return count;
        }

        /// <summary>
        /// Trailerの集合から最初に見つかったデバッグ情報を展開します。
        /// </summary>
        /// <param name="trailers"></param>
        /// <returns>クラス名, メッセージ, スタックトレースの配列</returns>
        public static List<string> GetRpcDebugInfo(this IEnumerable<Metadata.Entry> trailers)
        {
            foreach (var t in trailers)
            {
                var ret = GetRpcDebugInfo(t).ToList();
                if (ret.Count > 0) return ret;
            }
            return null;
        }

        /// <summary>
        /// Trailerからデバッグ情報を探します。
        /// </summary>
        /// <param name="t"></param>
        /// <returns>クラス名, メッセージ, スタックトレースの配列</returns>
        public static IEnumerable<string> GetRpcDebugInfo(this Metadata.Entry t)
        {
            // 参考 https://github.com/chwarr/grpc-dotnet-google-rpc-status/blob/master/client/Program.cs
            if (t.IsBinary)
            {
                Google.Rpc.DebugInfo debugInfo;
                var stat = Google.Rpc.Status.Parser.ParseFrom(t.ValueBytes);
                foreach (var a in stat.Details)
                {
                    if (a.TryUnpack(out debugInfo))
                    {
                        yield return debugInfo.Detail;
                        yield return stat.Message;
                        foreach (var stack in debugInfo.StackEntries) yield return stack;
                        break;
                    }
                }
            }
        }
    }
}
