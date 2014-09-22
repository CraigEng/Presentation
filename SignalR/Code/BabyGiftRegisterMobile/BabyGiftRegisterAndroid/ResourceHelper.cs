namespace BabyGiftRegisterAndroid
{
    public static class ResourceHelper
    {
        public static int TranslateDrawable(string drawableName)
        {
            switch (drawableName)
            {
                case "MomsMamaroo":
                    return Resource.Drawable.MomsMamaroo;
                case "SimbaPlayGym":
                    return Resource.Drawable.SimbaPlayGym;
                case "ToloFirstFriendsGoKart":
                    return Resource.Drawable.ToloFirstFriendsGoKart;
                case "ToloPopUpDinosaurs":
                    return Resource.Drawable.ToloPopUpDinosaurs;
                case "ToloRollingBallShape":
                    return Resource.Drawable.ToloRollingBallShape;
                case "ToloShapeSorterPlay":
                    return Resource.Drawable.ToloShapeSorterPlay;
                case "ToloWobblyClown":
                    return Resource.Drawable.ToloWobblyClown;
                case "YoyoBlueRockingPony":
                    return Resource.Drawable.YoyoBlueRockingPony;
                default:
                    return -1;
            }
        }
    }
}