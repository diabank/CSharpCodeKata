using ProviderQuality.Console.CustomException;

namespace ProviderQuality.Console
{
    public class Award
    {
        public Award(string name, 
                     int expiresIn, 
                     int quality,
                     int maxQualityValue = 50,
                     int minQualityValue = 0)
        {
            _name = name;
            _expiresIn = expiresIn;

            if (quality > 50 || quality < 0)
                throw new AwardCustomException("Invalid Quality");

            _quality = quality;
            _maxQualityValue = maxQualityValue;
            _minQualityValue = minQualityValue;
        }

        private protected string _name { get; set; }
        public string Name => _name;

        private protected int _expiresIn { get; set; }
        public int ExpiresIn => _expiresIn;

        private protected int _quality { get; set; }
        public int Quality => _quality;

        protected int _maxQualityValue { get; set; }
        private protected int _minQualityValue { get; set; }

        private protected void ProcessExpiredIn() => _expiresIn--;

        public virtual void ProcessUpdate()
        {
            ProcessExpiredIn();

            if (_quality > _minQualityValue)
                _quality--;

            if (_expiresIn < 0 && _quality > _minQualityValue)
                _quality--;
        }

        public override string ToString()
        {
            return $"Award Name: {Name}, Expires In: {ExpiresIn}, Quality: {Quality}";
        }
    }
}
