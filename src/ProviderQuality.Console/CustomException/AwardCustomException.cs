using System;

namespace ProviderQuality.Console.CustomException
{
    public class AwardCustomException : Exception
    {
        public AwardCustomException(string message) : base(message) { }
    }
}
