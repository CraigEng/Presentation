namespace BabyGiftRegisterLibrary.Model
{
    public class RegisterItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public bool Sold { get; set; }
        public bool InRegister { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl
        {
            get { return ImageName + ".jpg"; }
        }

    }
}