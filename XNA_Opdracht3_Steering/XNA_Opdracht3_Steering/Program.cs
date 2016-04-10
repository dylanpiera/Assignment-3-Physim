namespace Opdracht3_Steering {
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SimPhyGameWorld game = new SimPhyGameWorld())
            {
                game.Run();
            }
        }
    }
#endif
}

