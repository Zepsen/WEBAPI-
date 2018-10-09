using System;
using System.Threading.Tasks;

namespace WEB.Infrastructure.Extensions
{
    public static class ErrorHandlerExt
    {
        public static async Task<TResult> PipeTo<TSource, TResult>(
            this Task<TSource> dResult, Func<TSource, TResult> func)
        {
            return func(await dResult);
        }

        public static async Task<TResult> Either<TSource, TResult>(
            this Task<TSource> dResult,
            Func<TSource, bool> condition, 
            Func<TSource, TResult> ifTrue,
            Func<TSource, TResult> ifFalse)
        {
            return (condition(await dResult))
                ? ifTrue(dResult.Result)
                : ifFalse(dResult.Result);
        }

        public static async Task<TResult> Try<TSource, TResult>(
            this Task<TSource> dResult,
            Func<TSource, TResult> func,
            Func<Exception, TResult> excp)
        {
            try
            {
                return func(await dResult);
            }
            catch (Exception ex)
            {
                return excp(ex);
            }
        }
    }
}