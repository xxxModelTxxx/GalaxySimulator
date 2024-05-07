using UI;

namespace Program
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            // MVP binding /////////////////////////////////////////////////////
            RenderView renderView = new RenderView();
            ////////////////////////////////////////////////////////////////////

            Application.Run(renderView);
        }
    }
}