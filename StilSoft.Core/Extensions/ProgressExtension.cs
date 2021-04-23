using System;

namespace StilSoft.Extensions
{
    public static class ProgressExtension
    {
        public static void Report(this IProgress<ProgressStatus> progress, string message, int elapsed = 0, int total = 0)
        {
            progress.Report(new ProgressStatus { Message = message, Elapsed = elapsed, Total = total });
        }
    }
}