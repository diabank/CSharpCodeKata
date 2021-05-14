namespace ProviderQuality.Console.AwardObjects
{
    public class BlueFirstAward : Award
    {
        public BlueFirstAward(int expiresIn, int quality)
            : base("Blue First", expiresIn, quality)  { }

        public override void ProcessUpdate()
        {
            ProcessExpiredIn();

            if (_quality < _maxQualityValue)
                _quality++;
        }
    }
}
