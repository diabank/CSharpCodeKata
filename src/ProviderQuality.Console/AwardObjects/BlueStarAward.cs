namespace ProviderQuality.Console.AwardObjects
{
    public class BlueStarAward : Award
    {
        public BlueStarAward(int expiresIn, int quality)
            : base("Blue Star", expiresIn, quality) { }

        public override void ProcessUpdate()
        {
            ProcessExpiredIn();

            _quality = _quality - 2;

            if (_quality < _minQualityValue)
                _quality = _minQualityValue;
        }
    }
}
