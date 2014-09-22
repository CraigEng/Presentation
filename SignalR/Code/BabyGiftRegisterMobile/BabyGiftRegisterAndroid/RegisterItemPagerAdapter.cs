using Android.Support.V4.App;
using BabyGiftRegisterLibrary.Managers;

namespace BabyGiftRegisterAndroid
{
    internal class RegisterItemPagerAdapter : FragmentStatePagerAdapter
    {
        private readonly RegisterItemManager _registerItemManager;

        public RegisterItemPagerAdapter(FragmentManager fm, RegisterItemManager registerItemManager)
            : base(fm)
        {
            _registerItemManager = registerItemManager;
        }

        public override int Count
        {
            get { return _registerItemManager.Length; }
        }

        public override Fragment GetItem(int position)
        {
            _registerItemManager.MoveTo(position);
            var registerItemFragment = new RegisterItemFragment {RegisterItem = _registerItemManager.Current};
            return registerItemFragment;
        }
    }
}