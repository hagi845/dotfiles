using Grpc.Core;
using Grpc.Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoTestApp
{
    class ChannelBuilder
    {
        private ChannelBuilder() { }

        public CallInvoker GetOrCreate()
        {

            var channel = new Channel("192.168.1.101", 50051, ChannelCredentials.Insecure, GetChannelOptions())
             .Intercept(GetInterCeptors().ToArray());
            return channel;
        }

        IEnumerable<Interceptor> GetInterCeptors()
        {
            yield return new Interceptors.ExceptionLoggingInterceptor();
            yield return new Interceptors.RequireLoginInterceptor();
            yield return new Interceptors.SessionInterceptor();
        }

        IEnumerable<ChannelOption> GetChannelOptions()
        {
            yield break;
        }

        public static ChannelBuilder Get() => new ChannelBuilder();
        
    }
}
