using System;

namespace Yandex.Music.Api.Models.Common
{
    public class YErrorResponse: Exception
    {
        public YInvocationInfo InvocationInfo { get; set; }
        public YError Error { get; set; }
    }
}