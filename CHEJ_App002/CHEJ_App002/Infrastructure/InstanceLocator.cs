namespace CHEJ_App002.Infrastructure
{
    using CHEJ_App002.ViewModels;

    //  El patron InstaLocator es el que hace la union de la ViewModel con la View  \\
    public class InstanceLocator
    {
        #region Properties

        public MainViewModel Main
        {
            get;
            set;
        }
        
        #endregion Attributes

        #region Constructor

        public InstanceLocator()
        {
            //  Instancia de la clase MainViewModel \\
            Main = new MainViewModel();
        }

        #endregion Constructor
    }
}
