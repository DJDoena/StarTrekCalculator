namespace DoenaSoft.STC
{
    sealed class MainViewModel
    {
        readonly StardateViewModel _Stardate;

        readonly WarpViewModel _Warp;

        public MainViewModel()
        {
            _Stardate = new StardateViewModel();
            _Warp = new WarpViewModel();
        }

        public StardateViewModel Stardate
            => _Stardate;

        public WarpViewModel Warp
            => _Warp;
    }
}