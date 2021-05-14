namespace ProviderQuality.Console.AwardObjects
{
    public class BlueCompareAward : Award
    {
        public BlueCompareAward(int expiresIn, int quality)
            : base("Blue Compare", expiresIn, quality)
        {

        }

        public override void ProcessUpdate()
        {
            ProcessExpiredIn();

            if (_expiresIn > 0)
            {
                _quality++;

                if (_expiresIn < 11 && _quality < 50)
                    _quality++;

                if (_expiresIn < 6 && _quality < 50)
                    _quality++;
            }
            else
                _quality = 0;

        }
    }
}
