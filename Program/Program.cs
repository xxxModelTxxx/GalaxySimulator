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
            ControlView controlView = new ControlView();
            RenderView renderView = new RenderView();
            ////////////////////////////////////////////////////////////////////

            controlView.Visible = true;
            Application.Run(renderView);
        }
    }
}