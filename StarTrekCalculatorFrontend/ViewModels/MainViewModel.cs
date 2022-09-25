namespace DoenaSoft.STC
{
    internal sealed class MainViewModel
    {
        private readonly StardateViewModel _stardate;

        private readonly WarpViewModel _warp;

        public MainViewModel()
        {
            _stardate = new StardateViewModel();

            _warp = new WarpViewModel();
        }

        public StardateViewModel Stardate => _stardate;

        public WarpViewModel Warp => _warp;
    }
}