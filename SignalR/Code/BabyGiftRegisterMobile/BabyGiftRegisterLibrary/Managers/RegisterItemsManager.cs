using System;
using System.Collections.Generic;
using System.Linq;
using BabyGiftRegisterLibrary.Default;
using BabyGiftRegisterLibrary.Model;

namespace BabyGiftRegisterLibrary.Managers
{
    public class RegisterItemManager
    {
        private readonly int _lastIndex;
        private readonly IList<RegisterItem> _registerItems;
        private int _currentIndex;

        public RegisterItemManager()
        {
            _registerItems = DataGenerator.GetInitialRegisterItems();
            _lastIndex = _registerItems.Count() - 1;
        }

        public RegisterItemManager(IList<RegisterItem> registerItems)
        {
            _registerItems = registerItems;
            _lastIndex = _registerItems.Count() - 1;
        }

        public int Length
        {
            get { return _registerItems.Count; }
        }

        public RegisterItem Current
        {
            get { return _registerItems[_currentIndex]; }
        }

        public void MoveFirst()
        {
            _currentIndex = 0;
        }

        public void MoveTo(int position)
        {
            if (position >= 0 && position <= _lastIndex)
            {
                _currentIndex = position;
                return;
            }


            throw new Exception("Invalid Position.");
        }

        public void MovePrev()
        {
            if (_currentIndex > 0)
                --_currentIndex;
        }

        public void MoveNext()
        {
            if (_currentIndex < _lastIndex)
                ++_currentIndex;
        }

        public RegisterItem GetItemById(int id)
        {
            return _registerItems.FirstOrDefault(x => x.Id == id);
        }
    }
}