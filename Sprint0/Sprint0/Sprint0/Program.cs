using System;

namespace TeamYoshi
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Sprint4 game = new Sprint4())
            {
                game.Run();
            }
        }
    }
#endif
}

