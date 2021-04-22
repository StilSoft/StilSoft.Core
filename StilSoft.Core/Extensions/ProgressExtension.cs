using System;

namespace StilSoft.Core.Extensions
{
    public static class ProgressExtension
    {
        public static void Report(this IProgress<ProgressInfo> progress, string message, int elapsed = 0, int total = 0)
        {
            progress.Report(new ProgressInfo { Message = message, Elapsed = elapsed, Total = total });
        }
    }
}