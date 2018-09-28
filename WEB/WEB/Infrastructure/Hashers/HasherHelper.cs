using System;
using BLL.Infrastructure;
using HashidsNet;

namespace WEB.Infrastructure.Hashers
{
    /// <summary>
    /// Lazy singelton
    /// </summary>
    public static class HasherHelper
    {
        const string DEFAULT_HASH_SALT = "_VignitaDefaultHashSalt";
        const int DEFAULT_HASH_LENGTH = 5;

        private static readonly Lazy<Hashids> Lazy = 
            new Lazy<Hashids>(() => new Hashids(DEFAULT_HASH_SALT, DEFAULT_HASH_LENGTH));

        public static Hashids GetInstance => Lazy.Value;
    }

//    public static class Singleton
//    {
//        const string DEFAULT_HASH_SALT = "_VignitaDefaultHashSalt";
//        const int DEFAULT_HASH_LENGTH = 5;
//
//        // Explicit static constructor to tell C# compiler
//        // not to mark type as beforefieldinit
//        static Singleton()
//        {
//        }
//
//        public static Hashids GetInstance { get; } = new Hashids(DEFAULT_HASH_SALT, DEFAULT_HASH_LENGTH);
//    }
}
