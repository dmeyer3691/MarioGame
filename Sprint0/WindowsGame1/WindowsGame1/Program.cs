using System;

namespace TeamYoshiTests
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TestsMain game = new TestsMain())
            {
                game.Run();
            }
        }
    }
#endif
}

